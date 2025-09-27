let galleries = {};
let currentImageIndex = 0;
let currentGalleryId = null;

window.initGalleries = function () {
    galleries = {};
    document.querySelectorAll("[data-images]").forEach(el => {
        try {
            const images = JSON.parse(el.dataset.images);
            if (Array.isArray(images) && images.length > 0) {
                galleries[el.id] = images;
            }
        } catch (e) {
            console.error("Invalid gallery data", e);
        }
    });
};

function ensureGalleriesInitialized() {
    if (Object.keys(galleries).length === 0) {
        window.initGalleries();
    }
}

window.openLightbox = function (galleryId, index) {
     window.initGalleries();
    if (!galleries[galleryId]) {
        ensureGalleriesInitialized();
    }
    if (!galleries[galleryId]) return;

    currentGalleryId = galleryId;
    currentImageIndex = index;

    const imgData = galleries[galleryId][index];
    const lightboxImage = document.getElementById("lightboxImage");

    if (lightboxImage) {
        lightboxImage.src = imgData.imageAddress;
        lightboxImage.alt = imgData.title;
    }

    const modal = new bootstrap.Modal(document.getElementById("lightboxModal"));
    modal.show();
};

window.prevImage = function () {
    if (!currentGalleryId) return;

    const images = galleries[currentGalleryId];
    currentImageIndex = (currentImageIndex - 1 + images.length) % images.length;

    const imgData = images[currentImageIndex];
    const lightboxImage = document.getElementById("lightboxImage");

    if (lightboxImage) {
        lightboxImage.src = imgData.imageAddress;
        lightboxImage.alt = imgData.title;
    }
};

window.nextImage = function () {
    if (!currentGalleryId) return;

    const images = galleries[currentGalleryId];
    currentImageIndex = (currentImageIndex + 1) % images.length;

    const imgData = images[currentImageIndex];
    const lightboxImage = document.getElementById("lightboxImage");

    if (lightboxImage) {
        lightboxImage.src = imgData.imageAddress;
        lightboxImage.alt = imgData.title;
    }
};

 
document.addEventListener("DOMContentLoaded", window.initGalleries);

// Observe DOM changes (SSR navigations replace body content without full reload)
const observer = new MutationObserver((mutations) => {
    let shouldInit = false;
    for (const mutation of mutations) {
        if (mutation.type === "childList") {
            mutation.addedNodes.forEach(node => {
                if (node.nodeType === 1) {
                    if (node.hasAttribute && node.hasAttribute("data-images")) {
                        shouldInit = true;
                    }
                    if (!shouldInit && node.querySelector && node.querySelector("[data-images]")) {
                        shouldInit = true;
                    }
                }
            });
        }
    }
    if (shouldInit) {
        window.initGalleries();
    }
});

observer.observe(document.documentElement || document.body, { childList: true, subtree: true });
