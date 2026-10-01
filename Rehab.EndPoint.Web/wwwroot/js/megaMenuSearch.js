// Client-side filtering for the mega-menu tabs (they are statically rendered).
//
//   <input data-mega-search="#id">          search box; filters the container #id
//   [data-search-text="..."]                an item inside #id, matched against the search
//   <button data-mega-filter="#id" data-value="West">
//                                           optional filter buttons ("all" = no filter);
//                                           items opt in with data-filter="West"
//   [data-search-group]                     optional wrapper hidden when none of its items show
//   [data-search-count]                     optional element inside #id showing the visible count
//   [data-mega-search-empty]                sibling of #id shown when nothing matches
//
// Delegated on document so it keeps working after Blazor enhanced navigation.
(function () {
    function apply(container) {
        var term = (container.getAttribute('data-term') || '').trim().toLowerCase();
        var filter = container.getAttribute('data-filter-value') || 'all';
        var visible = 0;

        container.querySelectorAll('[data-search-text]').forEach(function (item) {
            var matchText = !term || item.getAttribute('data-search-text').indexOf(term) !== -1;
            var matchFilter = filter === 'all' || item.getAttribute('data-filter') === filter;
            var show = matchText && matchFilter;
            item.hidden = !show;
            if (show) visible++;
        });

        container.querySelectorAll('[data-search-group]').forEach(function (group) {
            group.hidden = !group.querySelector('[data-search-text]:not([hidden])');
        });

        container.querySelectorAll('[data-search-count]').forEach(function (el) {
            el.textContent = visible;
        });

        var empty = container.parentElement.querySelector('[data-mega-search-empty]');
        if (empty) empty.hidden = visible > 0;
    }

    document.addEventListener('input', function (e) {
        var input = e.target;
        if (!input.matches || !input.matches('[data-mega-search]')) return;

        var container = document.querySelector(input.getAttribute('data-mega-search'));
        if (!container) return;

        container.setAttribute('data-term', input.value);
        apply(container);
    });

    document.addEventListener('click', function (e) {
        var button = e.target.closest && e.target.closest('[data-mega-filter]');
        if (!button) return;

        var container = document.querySelector(button.getAttribute('data-mega-filter'));
        if (!container) return;

        button.parentElement.querySelectorAll('[data-mega-filter]').forEach(function (b) {
            var active = b === button;
            b.classList.toggle('active', active);
            b.setAttribute('aria-pressed', active ? 'true' : 'false');
        });

        container.setAttribute('data-filter-value', button.getAttribute('data-value') || 'all');
        apply(container);
    });
})();
