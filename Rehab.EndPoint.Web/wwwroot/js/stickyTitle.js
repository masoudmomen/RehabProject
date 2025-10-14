
document.addEventListener("DOMContentLoaded", function () {
    const titles = document.querySelectorAll(".section-title");

    const observer = new IntersectionObserver(
        entries => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    titles.forEach(t => t.classList.remove("active"));
                    entry.target.classList.add("active");
                }
            });
        },
        {
            root: null,
            rootMargin: "0px",
            threshold: 0.5
        }
    );

    titles.forEach(title => observer.observe(title));
});