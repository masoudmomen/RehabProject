window.footerScrollWatcher = {
    init: function (dotNetHelper) {
        window.addEventListener('scroll', function () {
            const footer = document.getElementById('footer');

            const scrollHeight = document.documentElement.scrollHeight;
            const scrollTop = window.scrollY || document.documentElement.scrollTop;
            const windowHeight = window.innerHeight || document.documentElement.clientHeight;

            const expanded = (scrollTop + windowHeight >= scrollHeight - 5);
         
            if (expanded) {
                footer.classList.add('expanded');
            } else {
                footer.classList.remove('expanded');
            }

            dotNetHelper.invokeMethodAsync("SetFooterExpanded", expanded);

        });
    }
};
window.bootstrap = window.bootstrap || {};
window.bootstrap.Lightbox = {
    open: function () {
        var modal = new bootstrap.Modal(document.getElementById('lightboxModal'));
        modal.show();
    }
}