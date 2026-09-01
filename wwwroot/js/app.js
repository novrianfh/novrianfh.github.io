// Tiny vanilla helpers for the brutalist profile site.
// No framework, no dependencies.
window.profileWeb = (function () {
    const root = document.documentElement;

    function getTheme() {
        return root.getAttribute('data-theme') || 'light';
    }

    function setTheme(theme) {
        root.setAttribute('data-theme', theme);
        try { localStorage.setItem('theme', theme); } catch (e) { /* ignore */ }
        const meta = document.querySelector('meta[name="theme-color"]');
        if (meta) meta.setAttribute('content', theme === 'dark' ? '#0a0a0a' : '#f4f4ef');
        return theme;
    }

    function toggleTheme() {
        return setTheme(getTheme() === 'dark' ? 'light' : 'dark');
    }

    // Highlights the nav link whose section is currently on screen.
    let spyObserver = null;
    function initScrollSpy() {
        if (spyObserver) spyObserver.disconnect();
        const sections = document.querySelectorAll('section[id]');
        if (!sections.length) return;

        spyObserver = new IntersectionObserver((entries) => {
            entries.forEach((entry) => {
                if (!entry.isIntersecting) return;
                const id = entry.target.getAttribute('id');
                document.querySelectorAll('[data-nav]').forEach((link) => {
                    link.classList.toggle('is-active', link.getAttribute('data-nav') === id);
                });
            });
        }, { rootMargin: '-45% 0px -50% 0px', threshold: 0 });

        sections.forEach((s) => spyObserver.observe(s));
    }

    // Smooth-scroll to whatever element the URL hash points at. Used after a
    // cross-page nav like /blogs -> /#work, where the browser's own jump fires
    // before Blazor has rendered the target section.
    function scrollToHash() {
        const hash = window.location.hash;
        if (!hash || hash.length < 2) return;
        let el = null;
        try { el = document.querySelector(hash); } catch (e) { return; }
        if (el) el.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }

    // Close the mobile menu after the user taps a link (handled in Blazor too,
    // this is just a belt-and-braces for hash navigation).
    function closeMobileMenuOnHashChange(dotNetRef) {
        window.addEventListener('hashchange', () => {
            if (dotNetRef) dotNetRef.invokeMethodAsync('CloseMenu');
        });
    }

    return { getTheme, setTheme, toggleTheme, initScrollSpy, scrollToHash, closeMobileMenuOnHashChange };
})();
