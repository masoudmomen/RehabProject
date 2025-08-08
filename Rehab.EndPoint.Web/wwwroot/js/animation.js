const initPageAnimations = () => {

    // Smooth scroll animation on load or enhanced navigation
    const runEntryAnimations = () => {
        const cards = document.querySelectorAll('.service-item, .value-card');
        cards.forEach(card => {
            card.style.opacity = '0';
            card.style.transform = 'translateY(30px)';
            card.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
        });

        document.querySelectorAll('.service-item, .value-card, .stat-item').forEach(el => {
            el.classList.add('test');
        });

        const observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.style.opacity = '1';
                    entry.target.style.transform = 'translateY(0)';
                }
            });
        });

        cards.forEach(card => observer.observe(card));
    };

    // Stat counter animation
    const animateCounter = (element, start, end, duration) => {
        let startTimestamp = null;

        const step = timestamp => {
            if (!startTimestamp) startTimestamp = timestamp;
            const progress = Math.min((timestamp - startTimestamp) / duration, 1);
            const current = Math.floor(progress * (end - start) + start);
            element.textContent = `${current}${element.textContent.includes('%') ? '%' : '+'}`;
            if (progress < 1) {
                requestAnimationFrame(step);
            }
        };

        requestAnimationFrame(step);
    };

    // Stat observer for triggering counters
    const statsObserver = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const number = entry.target.querySelector('.stat-number');
                const text = number?.textContent ?? '';
                const value = parseInt(text.replace(/\D/g, ''), 10);
                number.textContent = `0${text.includes('%') ? '%' : '+'}`;
                animateCounter(number, 0, value, 2000);
                statsObserver.unobserve(entry.target);
            }
        });
    });

    document.querySelectorAll('.stat-item').forEach(stat => {
        statsObserver.observe(stat);
    });

    runEntryAnimations();
};

// Export if needed in a module context
export { initPageAnimations };

// Trigger on load or enhanced navigation
window.addEventListener('load', () => initPageAnimations());
window.blazor?.addEventListener?.('enhancedload', () => initPageAnimations());
//function createAlert() {
//    alert("Hello");
//}