using System.Net;
using System.Net.Http.Json;
using System.Text;
using Markdig;

namespace ProfileWeb.Services;

/// <summary>Metadata about one Markdown document, read from its YAML front matter.</summary>
public sealed record ContentItem
{
    public required string Slug { get; init; }
    public required string Title { get; init; }
    public DateOnly? Date { get; init; }
    public string? Description { get; init; }
    public string[] Tags { get; init; } = Array.Empty<string>();
    public bool Draft { get; init; }
    public int ReadingMinutes { get; init; }
}

/// <summary>A rendered document: its metadata plus the HTML body.</summary>
public sealed record RenderedContent(ContentItem Meta, string Html);

/// <summary>
/// Loads Markdown files from wwwroot/content/{blogs,pages} at runtime.
/// The list of files comes from content/{blogs,pages}.json, which MSBuild
/// regenerates from disk on every build (see ProfileWeb.csproj).
/// </summary>
public sealed class ContentService
{
    private readonly HttpClient _http;
    private readonly MarkdownPipeline _pipeline;

    private IReadOnlyList<ContentItem>? _blogList;
    private readonly Dictionary<string, RenderedContent?> _cache = new();

    public ContentService(HttpClient http, MarkdownPipeline pipeline)
    {
        _http = http;
        _pipeline = pipeline;
    }

    // ---- Blog ------------------------------------------------------------------

    /// <summary>All published posts, newest first. Drafts are hidden.</summary>
    public async Task<IReadOnlyList<ContentItem>> GetBlogPostsAsync()
    {
        if (_blogList is not null) return _blogList;

        var slugs = await ReadIndexAsync("content/blogs.json");
        var items = new List<ContentItem>();

        foreach (var slug in slugs)
        {
            var doc = await GetRenderedAsync("blogs", slug);
            if (doc is not null && !doc.Meta.Draft)
                items.Add(doc.Meta);
        }

        _blogList = items
            .OrderByDescending(i => i.Date ?? DateOnly.MinValue)
            .ThenBy(i => i.Title, StringComparer.OrdinalIgnoreCase)
            .ToList();

        return _blogList;
    }

    public Task<RenderedContent?> GetBlogPostAsync(string slug) => GetRenderedAsync("blogs", slug);

    // ---- Pages ---------------------------------------------------------------

    public Task<IReadOnlyList<ContentItem>> GetPagesAsync() => GetListAsync("pages");

    public Task<RenderedContent?> GetPageAsync(string slug) => GetRenderedAsync("pages", slug);

    // ---- Internals --------------------------------------------------------------

    private async Task<IReadOnlyList<ContentItem>> GetListAsync(string folder)
    {
        var slugs = await ReadIndexAsync($"content/{folder}.json");
        var items = new List<ContentItem>();
        foreach (var slug in slugs)
        {
            var doc = await GetRenderedAsync(folder, slug);
            if (doc is not null && !doc.Meta.Draft) items.Add(doc.Meta);
        }
        return items.OrderBy(i => i.Title, StringComparer.OrdinalIgnoreCase).ToList();
    }

    private async Task<string[]> ReadIndexAsync(string path)
    {
        try
        {
            return await _http.GetFromJsonAsync<string[]>(path) ?? Array.Empty<string>();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }

    private async Task<RenderedContent?> GetRenderedAsync(string folder, string slug)
    {
        slug = Sanitize(slug);
        var key = $"{folder}/{slug}";
        if (_cache.TryGetValue(key, out var cached)) return cached;

        RenderedContent? result = null;
        try
        {
            var resp = await _http.GetAsync($"content/{folder}/{slug}.md");
            if (resp.StatusCode != HttpStatusCode.NotFound)
            {
                resp.EnsureSuccessStatusCode();
                var raw = await resp.Content.ReadAsStringAsync();
                result = Build(slug, raw);
            }
        }
        catch
        {
            result = null;
        }

        _cache[key] = result;
        return result;
    }

    private RenderedContent Build(string slug, string raw)
    {
        var (front, body) = SplitFrontMatter(raw);

        var meta = new ContentItem
        {
            Slug = slug,
            Title = front.GetValueOrDefault("title") ?? Prettify(slug),
            Date = DateOnly.TryParse(front.GetValueOrDefault("date"), out var d) ? d : null,
            Description = front.GetValueOrDefault("description") ?? front.GetValueOrDefault("summary"),
            Tags = ParseList(front.GetValueOrDefault("tags")),
            Draft = front.GetValueOrDefault("draft") is "true" or "yes",
            ReadingMinutes = Math.Max(1, (int)Math.Ceiling(WordCount(body) / 200.0)),
        };

        var html = Markdown.ToHtml(body, _pipeline);
        return new RenderedContent(meta, html);
    }

    // Very small YAML-front-matter reader: only `key: value` lines between the
    // opening and closing `---` fences. Good enough for post metadata.
    private static (Dictionary<string, string> Front, string Body) SplitFrontMatter(string raw)
    {
        raw = raw.Replace("\r\n", "\n").TrimStart('﻿');
        var front = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (!raw.StartsWith("---\n")) return (front, raw);

        var end = raw.IndexOf("\n---", 4, StringComparison.Ordinal);
        if (end < 0) return (front, raw);

        var block = raw.Substring(4, end - 4);
        foreach (var line in block.Split('\n'))
        {
            var i = line.IndexOf(':');
            if (i <= 0) continue;
            var k = line[..i].Trim();
            var v = line[(i + 1)..].Trim().Trim('"', '\'');
            if (k.Length > 0) front[k] = v;
        }

        var bodyStart = raw.IndexOf('\n', end + 1);
        var body = bodyStart < 0 ? string.Empty : raw[(bodyStart + 1)..];
        return (front, body);
    }

    private static string[] ParseList(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return Array.Empty<string>();
        value = value.Trim().TrimStart('[').TrimEnd(']');
        return value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(t => t.Trim('"', '\''))
                    .Where(t => t.Length > 0)
                    .ToArray();
    }

    private static int WordCount(string text)
    {
        var n = 0; var inWord = false;
        foreach (var c in text)
        {
            if (char.IsWhiteSpace(c)) { inWord = false; }
            else if (!inWord) { inWord = true; n++; }
        }
        return n;
    }

    private static string Sanitize(string slug) =>
        new(slug.Where(c => char.IsLetterOrDigit(c) || c is '-' or '_').ToArray());

    private static string Prettify(string slug)
    {
        var s = slug.Replace('-', ' ').Replace('_', ' ').Trim();
        return s.Length == 0 ? slug : char.ToUpperInvariant(s[0]) + s[1..];
    }
}
