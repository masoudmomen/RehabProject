// Facility page (Components/Facility/*): small behaviours for server-rendered markup.
// Uses event delegation on document, so it keeps working across Blazor enhanced navigation.
(function () {
    // A link to a collapsible section (<details id="...">) opens it before the browser scrolls to it,
    // e.g. the header's "+N" pills and the quick answers row's "+N more".
    function openSection(id) {
        if (!id) return;
        var el = document.getElementById(decodeURIComponent(id));
        if (el && el.tagName === "DETAILS" && !el.open) el.open = true;
    }

    document.addEventListener("click", function (e) {
        var link = e.target.closest && e.target.closest("a[href*='#']");
        if (link) {
            var url = new URL(link.href, location.href);
            if (url.pathname === location.pathname && url.hash) openSection(url.hash.slice(1));
            return;
        }

        // "Show N more" / "Show less": reveals the .fd-extra items of the enclosing .fd-more-scope.
        var more = e.target.closest && e.target.closest(".fd-more-btn");
        if (more) {
            var scope = more.closest(".fd-more-scope");
            if (!scope) return;
            var expanded = scope.classList.toggle("is-expanded");
            more.setAttribute("aria-expanded", expanded ? "true" : "false");
            var label = more.querySelector(".fd-more-label");
            if (label) label.textContent = expanded ? more.dataset.lessLabel : more.dataset.moreLabel;
            return;
        }

        // Level-of-care card "Read more" / "Show less".
        var read = e.target.closest && e.target.closest(".fd-loc-readmore");
        if (read) {
            var card = read.closest(".fd-loc-card");
            if (!card) return;
            var open = card.classList.toggle("is-open");
            read.setAttribute("aria-expanded", open ? "true" : "false");
            read.textContent = open ? "Show less" : "Read more";
        }
    }, true);

    // Arriving with a hash (or changing it) also opens that section.
    function openFromHash() { openSection(location.hash.slice(1)); }
    window.addEventListener("hashchange", openFromHash);
    document.addEventListener("DOMContentLoaded", openFromHash);
    if (window.Blazor && window.Blazor.addEventListener) {
        window.Blazor.addEventListener("enhancedload", openFromHash);
    }
})();
