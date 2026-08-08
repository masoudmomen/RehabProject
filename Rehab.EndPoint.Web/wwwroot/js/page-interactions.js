 
(function () {
    let scrollspyObserver = null;

    function initPageInteractions() {
        initToTop();
        initDeepLink();
        initSidebarScrollspy();
    }

    function initToTop() {
        const toTop = document.getElementById('toTop');
        if (!toTop || toTop.dataset.toTopBound) return;
        toTop.dataset.toTopBound = 'true';

        window.addEventListener('scroll', () => {
            toTop.classList.toggle('show', window.scrollY > 500);
        });
        toTop.addEventListener('click', () => {
            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
        toTop.classList.toggle('show', window.scrollY > 500);
    }

    function openDeepLinkTarget(hash) {
        if (!hash) return;
        const target = document.querySelector(hash);
        if (!target || target.tagName !== 'DETAILS') return;
        target.open = true;
        target.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }

    function initDeepLink() {
        const sidebarLinks = document.querySelectorAll('.policy-sidebar a[href^="#"]');
        sidebarLinks.forEach(link => {
            if (link.dataset.deepLinkBound) return;
            link.dataset.deepLinkBound = 'true';
            link.addEventListener('click', (e) => {
               
                e.preventDefault();
                const hash = link.getAttribute('href');
                openDeepLinkTarget(hash);
                if (history.replaceState) {
                    history.replaceState(null, '', hash);
                }
            });
        });
        if (window.location.hash) {
            openDeepLinkTarget(window.location.hash);
        }
    }

    function initSidebarScrollspy() {
        const sidebarLinks = document.querySelectorAll('.policy-sidebar a[href^="#"]');
        if (!sidebarLinks.length || !('IntersectionObserver' in window)) return;

        const sections = Array.from(sidebarLinks)
            .map(link => document.querySelector(link.getAttribute('href')))
            .filter(Boolean);
        if (!sections.length) return;

        
        if (scrollspyObserver) scrollspyObserver.disconnect();

        const setActive = (id) => {
            sidebarLinks.forEach(link => {
                link.classList.toggle('active', link.getAttribute('href') === '#' + id);
            });
        };

        scrollspyObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) setActive(entry.target.id);
            });
        }, { rootMargin: '-40% 0px -50% 0px', threshold: 0 });

        sections.forEach(section => scrollspyObserver.observe(section));
    }

    document.addEventListener('DOMContentLoaded', initPageInteractions);
     document.addEventListener('enhancedload', initPageInteractions);
     if (document.readyState === 'interactive' || document.readyState === 'complete') {
        initPageInteractions();
    }
})();
