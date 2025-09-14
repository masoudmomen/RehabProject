let galleries = {};
let currentImageIndex = 0;
let currentGalleryId = null;

window.initGalleries = function () {
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

window.openLightbox = function (galleryId, index) {
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
