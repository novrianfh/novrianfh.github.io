# novrianfh.github.io

Personal profile site for **Novrian Fajar Hidayat**.

- **Framework:** Blazor WebAssembly (.NET 10), standalone / fully static
- **UI:** hand-rolled **brutalist** design system — no component library, no CSS
  framework. Just `wwwroot/css/app.css`, a handful of Razor components, and
  ~50 lines of vanilla JS.
- **Hosting:** GitHub Pages (user site, served from `/`)
- **Fonts:** Space Grotesk + Space Mono (Google Fonts)
- Light / dark theme toggle, scroll-spy nav, responsive down to mobile.
- **Blog** (`/blogs`) and **static pages** (`/pages/*`) rendered from Markdown
  files — drop in a `.md`, nothing else to wire up.

---

## Edit your content

### The profile (home page)

Everything on the home page lives in **one file**:

```
Data/Profile.cs
```

Name, role, tagline, about text, skills, experience, education, projects and
links are all plain C# arrays with `// TODO` markers. No HTML required.

### Blog posts & pages (Markdown)

Add a `.md` file — the filename is the URL slug:

```
wwwroot/content/blogs/my-post.md   →  /blogs/my-post   (also listed on /blogs)
wwwroot/content/pages/privacy-policy.md  →  /pages/privacy-policy
```

Each file starts with a front-matter block:

```markdown
---
title: My Post
date: 2026-09-01
description: Short summary for the list + <meta description>.
tags: dotnet, blazor        # blogs only
draft: false                # true = hidden everywhere
---

# My Post
Body in **Markdown**…
```

The list of files (`wwwroot/content/{blogs,pages}.json`) is regenerated from
disk by an MSBuild target on every build — you never hand-edit it. Full details
in `wwwroot/content/README.md`.

**Privacy policy for a Play Store app:** edit
`wwwroot/content/pages/privacy-policy.md` (it's a fill-in-the-blanks template)
and give the store the URL `https://novrianfh.github.io/pages/privacy-policy`.

Extras:

| Want to… | Do this |
|----------|---------|
| Add your CV | Drop the PDF in `wwwroot/assets/` and point `Profile.ResumeUrl` at it |
| Use a real photo instead of the `NFH` block | See `wwwroot/assets/README.md` |
| Change colors / borders / shadows | Edit the tokens at the top of `wwwroot/css/app.css` (section 1) |
| Reorder or rename nav sections | `Components/NavBar.razor` (`_sections`) + the matching `id=` on each `<section>` in `Pages/Home.razor` |

---

## Run locally

```bash
dotnet run
```

Then open the URL it prints (e.g. `http://localhost:5130`).
Hot reload works: `dotnet watch`.

---

## Deploy to GitHub Pages

1. **Create the repo** on GitHub named exactly **`novrianfh.github.io`**.
2. Push this project to its `main` branch:

   ```bash
   git remote add origin https://github.com/novrianfh/novrianfh.github.io.git
   git push -u origin main
   ```

3. In the repo: **Settings → Pages → Build and deployment → Source = GitHub Actions**.
4. The workflow at `.github/workflows/deploy.yml` builds on every push to `main`
   and publishes to `https://novrianfh.github.io/`.

### Notes

- This is a **user site** served from `/`, so `<base href="/">` in
  `wwwroot/index.html` is already correct — no rewriting needed.
- The workflow adds `.nojekyll` (so `_framework/` is served) and copies
  `index.html` → `404.html` — this is what makes deep links like
  `/blogs/my-post` and `/pages/privacy-policy` work on refresh / direct hit.
- If you later move this to a **project** site (`novrianfh.github.io/<repo>/`),
  change the base href to `/<repo>/` and add a matching step to the workflow.

---

## Project layout

```
Data/Profile.cs            ← YOUR HOME-PAGE CONTENT (edit this)
Pages/
  Home.razor               ← section markup, pulls from Profile
  Blogs.razor              ← /blogs  — post list
  BlogPost.razor           ← /blogs/{slug}
  PagesIndex.razor         ← /pages  — page list
  StaticPage.razor         ← /pages/{slug}
  NotFound.razor           ← 404
Layout/MainLayout.razor    ← nav + footer shell
Components/
  NavBar.razor             ← sticky nav, mobile menu, scroll-spy
  ThemeToggle.razor        ← light/dark switch
  SectionHead.razor        ← numbered section headings
  TimelineList.razor       ← experience / education list
  ArticleView.razor        ← loads + renders one Markdown doc
Services/ContentService.cs ← fetches .md, parses front matter, renders (Markdig)
wwwroot/
  css/app.css              ← the entire brutalist design system
  js/app.js                ← theme + scroll-spy helpers
  index.html               ← <head>, fonts, pre-paint theme script
  content/                 ← YOUR BLOG POSTS & PAGES (.md files)
.github/workflows/deploy.yml
```
