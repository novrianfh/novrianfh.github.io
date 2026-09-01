# assets/

Drop your real files here — they are referenced from `Data/Profile.cs`.

| File | Referenced as | Notes |
|------|---------------|-------|
| `Novrian-Fajar-Hidayat-CV.pdf` | `Profile.ResumeUrl` | Your CV. Rename in `Profile.cs` if you use a different name. |
| `profile.jpg` (optional) | hero portrait | To use a photo instead of the initials block, edit `Pages/Home.razor` — swap the `<span>@Profile.Initials</span>` line for `<img src="assets/profile.jpg" alt="Novrian Fajar Hidayat" />`. |

Anything you put in `wwwroot/` is copied verbatim to the published site.
