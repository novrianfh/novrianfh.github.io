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
    public const string Role       = "Software Engineer"; // TODO: your headline role
    public const string Location   = "Indonesia";          // TODO
    public const string Status     = "OPEN TO WORK";       // TODO: e.g. "OPEN TO WORK" / "HEADS DOWN" / "FREELANCING"
    public const string Email      = "thenovrianmail@gmail.com";
    public const string ResumeUrl  = "assets/Novrian-Fajar-Hidayat-CV.pdf"; // TODO: drop your PDF in wwwroot/assets/

    // Short punchy tagline shown under the name in the hero.
    public const string Tagline =
        "I build fast, reliable software for the web — from .NET back-ends to the last pixel in the browser."; // TODO

    // The scrolling marquee strip. Keep entries SHORT and LOUD.
    public static readonly string[] Marquee =
    {
        "C#  /  .NET", "BLAZOR", "AZURE", "SQL", "CLEAN ARCHITECTURE",
        "DDD", "REST APIs", "CI/CD", "DOCKER", "PROBLEM SOLVER",
    }; // TODO

    // ---- About ------------------------------------------------------------------
    // 2–4 short paragraphs. Write like you talk.
    public static readonly string[] About =
    {
        "Hi, I'm Novrian — a software engineer who likes turning messy problems into small, boring, dependable systems. I care about correctness, readable code, and shipping things that people actually use.", // TODO
        "My day-to-day is mostly the .NET stack: building APIs and services, wiring up front-ends with Blazor, and keeping the database honest. I'm just as happy debugging a nasty production issue as I am designing something from scratch.", // TODO
        "Outside of work I tinker with side projects, read about systems design, and occasionally lose a weekend to a new language or framework.", // TODO
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
        new("LANGUAGES",  new[] { "C#", "SQL", "JavaScript", "TypeScript", "HTML", "CSS", "Python" }),      // TODO
        new("FRAMEWORKS", new[] { ".NET / ASP.NET Core", "Blazor", "Entity Framework Core", "xUnit" }),    // TODO
        new("PLATFORM",   new[] { "Azure", "Docker", "GitHub Actions", "Linux", "Redis" }),                 // TODO
        new("DATA",       new[] { "SQL Server", "PostgreSQL", "MongoDB" }),                                 // TODO
        new("PRACTICES",  new[] { "Clean Architecture", "TDD", "DDD", "Agile / Scrum", "Code Review" }),    // TODO
    };

    // ---- Experience ---------------------------------------------------------------
    public static readonly Job[] Experience =
    {
        new(
            Company: "Company Name",                 // TODO
            Title:   "Senior Software Engineer",     // TODO
            Period:  "2023 — Present",               // TODO
            Summary: "Lead development of X. Own the Y platform end to end.", // TODO
            Highlights: new[]
            {
                "Shipped a feature that did a measurable thing (numbers help).",     // TODO
                "Cut build/deploy time from N minutes to M.",                        // TODO
                "Mentored engineers; introduced a practice that stuck.",             // TODO
            }),
        new(
            Company: "Previous Company",             // TODO
            Title:   "Software Engineer",            // TODO
            Period:  "2020 — 2023",                  // TODO
            Summary: "Built and maintained services for A, B, and C.", // TODO
            Highlights: new[]
            {
                "Delivered project X on time and under scope creep.",   // TODO
                "Reduced error rate / latency / cost by some amount.",  // TODO
            }),
        new(
            Company: "First Company",                // TODO
            Title:   "Junior Developer",             // TODO
            Period:  "2019 — 2020",                  // TODO
            Summary: "Where it started. Learned the craft on real tickets.", // TODO
            Highlights: new[]
            {
                "Fixed bugs, wrote tests, learned to read a stack trace.", // TODO
            }),
    };

    // ---- Education / Certs (optional — leave empty array to hide the block) ---
    public static readonly Job[] Education =
    {
        new(
            Company: "University Name",              // TODO
            Title:   "B.Sc. Computer Science",      // TODO
            Period:  "2015 — 2019",                  // TODO
            Summary: "Thesis / focus area, honors, anything notable.", // TODO
            Highlights: Array.Empty<string>()),
    };

    // ---- Projects ---------------------------------------------------------------
    public static readonly Project[] Projects =
    {
        new(
            Name: "Project One",                                     // TODO
            Blurb: "One sentence on what it does and why it's cool.", // TODO
            Tech: new[] { ".NET", "Blazor", "PostgreSQL" },          // TODO
            Link: "https://github.com/novrianfh",                    // TODO: repo or live URL
            LinkLabel: "SOURCE"),
        new(
            Name: "Project Two",
            Blurb: "Another thing you built. Keep it concrete.",
            Tech: new[] { "C#", "Azure Functions", "Redis" },
            Link: "https://github.com/novrianfh",
            LinkLabel: "SOURCE"),
        new(
            Name: "Project Three",
            Blurb: "A tool, a library, a weekend hack — whatever you're proud of.",
            Tech: new[] { "TypeScript", "Node" },
            Link: "https://github.com/novrianfh",
            LinkLabel: "DEMO"),
    };

    // ---- Links -----------------------------------------------------------------
    // Order matters — first one shows first. Remove any you don't use.
    public static readonly SocialLink[] Socials =
    {
        new("GitHub",   "https://github.com/novrianfh"),                  // TODO
        new("LinkedIn", "https://www.linkedin.com/in/novrianfh"),        // TODO
        new("Email",    "mailto:thenovrianmail@gmail.com"),
        new("Twitter/X","https://x.com/novrianfh"),                      // TODO or remove
    };
}

// ---- Types (no need to edit) ------------------------------------------------
public sealed record SkillGroup(string Name, string[] Items);
public sealed record Job(string Company, string Title, string Period, string Summary, string[] Highlights);
public sealed record Project(string Name, string Blurb, string[] Tech, string Link, string LinkLabel);
public sealed record SocialLink(string Name, string Url);
