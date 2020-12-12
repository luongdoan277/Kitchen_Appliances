const galleryImg = document.querySelector(".gallery-img");
const previewImg = document.querySelectorAll(".image-preview img");

previewImg.forEach((preview) => {
  preview.addEventListener("click",function() {
        galleryImg.src = preview.src;
  });
});
