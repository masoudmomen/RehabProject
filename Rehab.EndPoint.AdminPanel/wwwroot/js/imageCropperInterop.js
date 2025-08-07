window.imageCropper = {
    cropper: null,

    initCropper: function (imageId) {
        var image = document.getElementById(imageId);
        if (this.cropper) this.cropper.destroy();
        this.cropper = new Cropper(image, {
            aspectRatio: 1,
            viewMode: 1
        });
    },

    getCroppedImageBase64: function () {
        if (!this.cropper) return null;
        return this.cropper.getCroppedCanvas().toDataURL("image/png");
    }
};
