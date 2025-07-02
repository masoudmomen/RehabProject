export function initialize() {
    // Smooth scrolling for navigation links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Header scroll effect
    let lastScrollTop = 0;
    window.addEventListener('scroll', () => {
        const header = document.querySelector('header');
        if (header) {
            const scrollTop = window.pageYOffset || document.documentElement.scrollTop;

            if (scrollTop > lastScrollTop && scrollTop > 100) {
                header.style.transform = 'translateY(-100%)';
            } else {
                header.style.transform = 'translateY(0)';
            }
            lastScrollTop = scrollTop;
        }
    });

    // Fade in animation on scroll
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
            }
        });
    }, observerOptions);

    document.querySelectorAll('.fade-in').forEach(el => {
        observer.observe(el);
    });

    // Gallery navigation
    document.querySelectorAll('.gallery-dot').forEach(dot => {
        dot.addEventListener('click', function () {
            this.parentNode.querySelectorAll('.gallery-dot').forEach(d => d.classList.remove('active'));
            this.classList.add('active');
        });
    });

    // Treatment card click handling
    document.querySelectorAll('.treatment-card').forEach(card => {
        card.addEventListener('click', function () {
            const treatment = this.querySelector('h3').textContent.toLowerCase();
            alert(`Showing ${treatment} treatment centers...`);
        });
    });

    // Add staggered animation to cards
    const cards = document.querySelectorAll('.center-card, .treatment-card, .insurance-card, .resource-card');
    cards.forEach((card, index) => {
        card.style.animationDelay = `${index * 0.1}s`;
    });
}