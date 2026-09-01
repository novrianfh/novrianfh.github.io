# novrianfh.github.io

Personal profile site for **Novrian Fajar Hidayat**.

- **Framework:** Blazor WebAssembly (.NET 10), standalone / fully static
- **UI:** hand-rolled **brutalist** design system — no component library, no CSS
  framework. Just `wwwroot/css/app.css`, a handful of Razor components, and
  ~50 lines of vanilla JS.
- **Hosting:** GitHub Pages (user site, served from `/`)
- **Fonts:** Space Grotesk + Space Mono (Google Fonts)
- Light / dark theme toggle, scroll-spy nav, responsive down to mobile.

---

## Edit your content

Everything you need to change lives in **one file**:

```
Data/Profile.cs
```

Name, role, tagline, about text, skills, experience, education, projects and
links are all plain C# arrays with `// TODO` markers. No HTML required.

Extras:

| Want to… | Do this |
|----------|---------|
| Add your CV | Drop the PDF in `wwwroot/assets/` and point `Profile.ResumeUrl` at it |
| Use a real photo instead of the `NFH` block | See `wwwroot/assets/README.md` |
| Change colors / borders / shadows | Edit the tokens at the top of `wwwroot/css/app.css` (section 1) |
| Reorder or rename nav sections | `Components/NavBar.razor` (`_items`) + the matching `id=` on each `<section>` in `Pages/Home.razor` |

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
  `index.html` → `404.html` (so deep links / refreshes work).
- If you later move this to a **project** site (`novrianfh.github.io/<repo>/`),
  change the base href to `/<repo>/` and add a matching step to the workflow.

---

## Project layout

```
Data/Profile.cs            ← YOUR CONTENT (edit this)
Pages/Home.razor           ← section markup, pulls from Profile
Pages/NotFound.razor       ← 404
Layout/MainLayout.razor    ← nav + footer shell
Components/
  NavBar.razor             ← sticky nav, mobile menu, scroll-spy
  ThemeToggle.razor        ← light/dark switch
  SectionHead.razor        ← numbered section headings
  TimelineList.razor       ← experience / education list
wwwroot/
  css/app.css              ← the entire brutalist design system
  js/app.js                ← theme + scroll-spy helpers
  index.html               ← <head>, fonts, pre-paint theme script
.github/workflows/deploy.yml
```
