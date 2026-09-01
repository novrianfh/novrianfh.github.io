namespace ProfileWeb.Data;

// ============================================================================
//  ✏️  EDIT YOUR PROFILE HERE
//  This is the ONLY file you need to touch to update the website content.
//  Everything below is placeholder data — replace the TODO values with yours.
// ============================================================================

public static class Profile
{
    // ---- Identity -----------------------------------------------------------
    public const string FullName   = "Novrian Fajar Hidayat";
    public const string Initials   = "NFH";
    public const string Role       = "Software Engineer, Solution Architects";
    public const string Location   = "Indonesia";          // TODO    
    public const string Status     = "OPEN TO FREELANCE";  // TODO: e.g. "OPEN TO WORK" / "HEADS DOWN" / "FREELANCING"
    public const string Email      = "thenovrianmail@gmail.com";
    //public const string ResumeUrl  = "assets/Novrian-Fajar-Hidayat-CV.pdf"; // TODO: drop your PDF in wwwroot/assets/

    // Short punchy tagline shown under the name in the hero.
    public const string Tagline =
        "I build fast, reliable software for the web — from .NET back-ends to the last pixel in the browser."; // TODO

    // The scrolling marquee strip. Keep entries SHORT and LOUD.
    public static readonly string[] Marquee =
    {
        "C#  /  .NET", "BLAZOR", "AZURE", "SQL", "CLEAN ARCHITECTURE",
         "REST APIs", "CI/CD", "PROBLEM SOLVER", "TYPESCRIPT"
    }; // TODO

    // ---- About ------------------------------------------------------------------
    // 2–4 short paragraphs. Write like you talk.
    public static readonly string[] About =
    {
        "Hi, I'm Novrian — a software engineer who likes turning messy problems into small, boring, dependable systems. I care about correctness, readable code, and shipping things that people actually use.", // TODO
        "My day-to-day is mostly working on a monolithic ASP.NET MVC website. I'm drawn to Blazor for building systems and solutions from the ground up.", // TODO
        "Outside of programming I like to draw, and I'm keen on graphic design and editorial design — that's what I get up to in my time away from work. That said, I'm open to offers beyond coding and engineering too.",
    };

    // Quick facts shown as a small stat grid in the About section.
    public static readonly (string Label, string Value)[] Facts =
    {
        ("EXPERIENCE", "5+ yrs"),          // TODO
        ("FOCUS", ".NET · Web"),           // TODO
        ("TIMEZONE", "GMT+7"),             // TODO
        ("LANGUAGES", "ID · EN"),          // TODO
    };

    // ---- Skills ---------------------------------------------------------------
    public static readonly SkillGroup[] Skills =
    {
        new("LANGUAGES",  new[] { "C#", "SQL", "JavaScript", "TypeScript", "HTML", "CSS" }),      
        new("FRAMEWORKS", new[] { ".NET / ASP.NET Core", "Blazor", "Entity Framework Core"}),    
        new("PLATFORM",   new[] { "Azure", "Linux", "Redis" }),                 
        new("DATA",       new[] { "SQL Server", "PostgreSQL"}),                                
        new("PRACTICES",  new[] { "Clean Architecture", "Agile / Scrum", "Code Review" }),  
    };

    // ---- Experience ---------------------------------------------------------------
    public static readonly Job[] Experience =
    {
        new(
            Company: "Logie Inc",
            Title:   "Back End Developer · Full-time · Remote",
            Period:  "Oct 2021 — Jul 2026",
            Summary: "Designed and developed secure, scalable, high-performance GraphQL APIs. Built and optimized database structures for fast, reliable data access.",
            Highlights: new[]
            {
                "Back-End Web Development",
                "TypeScript",
            }),
        new(
            Company: "Microsoft Innovation Center Yogyakarta",
            Title:   "Software Engineer Manager",
            Period:  "Jul 2017 — Jul 2020",
            Summary: "",
            Highlights: Array.Empty<string>()),
    };

    // ---- Education / Certs (optional — leave empty array to hide the block) ---
    public static readonly Job[] Education =
    {
        new(
            Company: "Universitas Gadjah Mada",          
            Title:   "S.T, Teknik Elektro (Computer Engineering)",     
            Period:  "2007 — 2012",                 
            Summary: "",
            Highlights: Array.Empty<string>()),
    };

    // ---- Projects ---------------------------------------------------------------
    public static readonly Project[] Projects =
    {
        new(
            Name: "KanvasKata",
            Blurb: "A browser-based canvas design app for building and exporting custom cards from text, images, and templates — fully client-side, no backend.",
            Tech: new[] { "Blazor WebAssembly", ".NET 10", "C#", "html2canvas" },
            Link: "https://github.com/novrianfh/KanvasKata",
            LinkLabel: "SOURCE"),
        new(
            Name: "Laporan Keuangan Masjid",
            Blurb: "Editorial design templates and posters for mosque financial reports, with a fresh color theme each month.",
            Tech: new[] { "Affinity Publisher", "Editorial Design", "Typography" },
            Link: "https://github.com/novrianfh/Laporan-Keuangan-Masjid",
            LinkLabel: "SOURCE"),
    };

    // ---- Links -----------------------------------------------------------------
    // Order matters — first one shows first. Remove any you don't use.
    public static readonly SocialLink[] Socials =
    {
        new("GitHub",   "https://github.com/novrianfh"),
        new("LinkedIn", "https://www.linkedin.com/in/novrian-fajar-85184a120/"),        
        new("Email",    "mailto:thenovrianmail@gmail.com"),
        new("Twitter/X","https://x.com/nvrnfjr"),                      
        new("Instagram","https://www.instagram.com/nvrnfjr")                      
    };
}

// ---- Types (no need to edit) ------------------------------------------------
public sealed record SkillGroup(string Name, string[] Items);
public sealed record Job(string Company, string Title, string Period, string Summary, string[] Highlights);
public sealed record Project(string Name, string Blurb, string[] Tech, string Link, string LinkLabel);
public sealed record SocialLink(string Name, string Url);
