---
title: Hello, World
date: 2026-09-01
description: First post. What this blog is for and how it's built.
tags: meta, blazor, markdown
draft: false
---

# Hello, World

This is the first post on my blog. It lives as a plain Markdown file at
`wwwroot/content/blogs/hello-world.md` and is rendered at runtime by
[Markdig](https://github.com/xoofx/markdig).

## Why a file-based blog

- **No CMS, no database.** A post is a `.md` file in the repo.
- **Version controlled.** Every edit is a commit.
- **Portable.** The same files would work in any static-site generator.

## Writing a new post

1. Create `wwwroot/content/blogs/my-post.md`
2. Add the front matter block (between the `---` fences)
3. Commit and push — the build regenerates the index automatically

That's it. The post shows up on `/blogs` sorted by `date`, newest first.

## Formatting works

> Blockquotes render as brutalist callouts.

Inline `code`, and fenced blocks:

```csharp
public static string Greet(string name) => $"Hello, {name}!";
```

| Thing        | Supported |
|--------------|-----------|
| Tables       | yes       |
| Task lists   | yes       |
| Footnotes    | yes       |

Set `draft: true` in the front matter to keep a post out of the list while you
work on it.
