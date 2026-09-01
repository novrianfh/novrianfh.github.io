# content/

Markdown content rendered by the site at runtime.

```
content/
  blogs/*.md   → listed at /blogs, each post at /blogs/<filename>
  pages/*.md   → listed at /pages, each page at /pages/<filename>
  blogs.json   → auto-generated list of blog slugs  (do not edit / git-ignored)
  pages.json   → auto-generated list of page slugs   (do not edit / git-ignored)
  assets/      → images etc. referenced from Markdown
```

## Add a post or page

1. Create a file, e.g. `content/blogs/my-first-post.md`.
   The **filename becomes the URL slug** — use `kebab-case`, no spaces.
2. Start it with a front-matter block:

   ```markdown
   ---
   title: My First Post
   date: 2026-09-01
   description: One-line summary shown in the list and as the page meta description.
   tags: dotnet, blazor
   draft: false
   ---

   # My First Post

   Body goes here…
   ```

3. Build / run. The index (`blogs.json` / `pages.json`) is regenerated from the
   `.md` files on disk by an MSBuild target — you never edit it by hand.

### Front-matter fields

| Field         | Blog | Page | Notes |
|---------------|:----:|:----:|-------|
| `title`       | ✔    | ✔    | Falls back to a prettified slug if omitted. |
| `date`        | ✔    | ✔    | `YYYY-MM-DD`. Blog list sorts by this, newest first. |
| `description` | ✔    | ✔    | Also used as `summary`. |
| `tags`        | ✔    | –    | Comma-separated: `tags: a, b, c`. |
| `draft`       | ✔    | ✔    | `true` hides it from the list and the site. |

## Images

Put files in `content/assets/` and reference them from the site root:

```markdown
![Diagram](/content/assets/diagram.png)
```

## Privacy policy for an app store

`content/pages/privacy-policy.md` is a fill-in-the-blanks template. Edit it, then
give the store this URL:

```
https://novrianfh.github.io/pages/privacy-policy
```

Need more than one? Add `content/pages/privacy-policy-<appname>.md` and link to
`/pages/privacy-policy-<appname>`.
