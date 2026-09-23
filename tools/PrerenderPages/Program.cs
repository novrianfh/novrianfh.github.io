// Prerenders wwwroot/content/pages/*.md into standalone static HTML files
// under wwwroot/pages/{slug}.html.
//
// Why: the Blazor WASM app renders "/pages/{slug}" entirely client-side.
// On GitHub Pages, a direct request for that URL has no matching physical
// file, so it falls back to 404.html (a copy of index.html) — the app still
// renders fine once JavaScript boots, but the HTTP status code is always
// 404. Tools that check status without running JS (Play Store's privacy
// policy URL check, crawlers, link validators) see a broken link.
//
// This produces a real file at that path so GitHub Pages serves it
// directly with a 200, independent of the SPA fallback trick.
//
// Usage: dotnet run -- <sourceContentPagesDir> <siteWwwrootDir>
//   sourceContentPagesDir: .../wwwroot/content/pages
//   siteWwwrootDir:        .../wwwroot   (output goes to <siteWwwrootDir>/pages)

using Markdig;

if (args.Length < 2)
{
    Console.Error.WriteLine("Usage: PrerenderPages <contentPagesDir> <wwwrootDir>");
    return 1;
}

var contentDir = args[0];
var wwwrootDir = args[1];
var outDir = Path.Combine(wwwrootDir, "pages");
Directory.CreateDirectory(outDir);

var pipeline = new MarkdownPipelineBuilder()
    .UseAdvancedExtensions()
    .UseYamlFrontMatter()
    .UseAutoLinks()
    .Build();

var mdFiles = Directory.GetFiles(contentDir, "*.md");
Console.WriteLine($"Prerendering {mdFiles.Length} page(s) from {contentDir} -> {outDir}");

foreach (var mdPath in mdFiles)
{
    var slug = Path.GetFileNameWithoutExtension(mdPath);
    var raw = File.ReadAllText(mdPath);
    var (front, body) = SplitFrontMatter(raw);

    if (front.GetValueOrDefault("draft") is "true" or "yes")
    {
        Console.WriteLine($"  skip {slug} (draft)");
        continue;
    }

    var title = front.GetValueOrDefault("title") ?? Prettify(slug);
    var description = front.GetValueOrDefault("description") ?? front.GetValueOrDefault("summary") ?? "";
    var html = Markdown.ToHtml(body, pipeline);

    var page = RenderPage(title, description, slug, html);
    var outPath = Path.Combine(outDir, $"{slug}.html");
    File.WriteAllText(outPath, page);
    Console.WriteLine($"  wrote {outPath}");
}

return 0;

static string RenderPage(string title, string description, string slug, string bodyHtml) => $$"""
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>{{Escape(title)}} — Novrian Fajar Hidayat</title>
    <meta name="description" content="{{Escape(description)}}" />
    <meta name="robots" content="index, follow" />
    <meta property="og:type" content="article" />
    <meta property="og:title" content="{{Escape(title)}}" />
    <meta property="og:description" content="{{Escape(description)}}" />
    <meta property="og:url" content="https://novrianfh.github.io/pages/{{slug}}" />
    <link rel="canonical" href="https://novrianfh.github.io/pages/{{slug}}" />

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Space+Grotesk:wght@400;500;700&family=Space+Mono:wght@400;700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="/css/app.css" />
    <link rel="icon" type="image/svg+xml" href="/favicon.svg" />

    <script>
        (function () {
            try {
                var t = localStorage.getItem('theme');
                if (!t) t = matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
                document.documentElement.setAttribute('data-theme', t);
            } catch (e) { document.documentElement.setAttribute('data-theme', 'light'); }
        })();
    </script>
</head>
<body>
    <section class="section">
        <div class="wrap wrap--reading">
            <article>
                <a class="link article__back" href="/">← Home</a>
                <header class="article__head">
                    <h1 class="article__title">{{Escape(title)}}</h1>
                </header>
                <div class="prose">{{bodyHtml}}</div>
            </article>
        </div>
    </section>
</body>
</html>
""";

static string Escape(string s) => s
    .Replace("&", "&amp;")
    .Replace("\"", "&quot;")
    .Replace("<", "&lt;")
    .Replace(">", "&gt;");

static string Prettify(string slug)
{
    var s = slug.Replace('-', ' ').Replace('_', ' ').Trim();
    return s.Length == 0 ? slug : char.ToUpperInvariant(s[0]) + s[1..];
}

// Same tiny YAML-front-matter reader as Services/ContentService.cs.
static (Dictionary<string, string> Front, string Body) SplitFrontMatter(string raw)
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
