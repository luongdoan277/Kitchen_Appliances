  const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);
const IMG_WIDTH = window.innerWidth;
const slideContainer = $(".slides");
const slideImage = [...$$(".slide")];

//Button
const nextBtn = $("#next");
const preBtn = $("#pre");

slideContainer.style.width = slideImage.length * IMG_WIDTH + "px";

let counter = 0;

function next() {
    if (counter < slideImage.length - 1) {
        counter++;
    } else {
        counter = 0;
    }
    slideContainer.style.transition = "transform 0.4s ease-in-out";
    slideContainer.style.transform = "translateX(-" + IMG_WIDTH * counter + "px)";
}


setInterval(() => {
    next();
}, 3000);

nextBtn.addEventListener('click', () => {
    if (counter < slideImage.length - 1) {
        counter++;
    } else {
        counter = 0;
    }
    slideContainer.style.transition = "transform 0.4s ease-in-out";
    slideContainer.style.transform = 'translateX(' + (-IMG_WIDTH * counter) + 'px)';
});

preBtn.addEventListener('click', () => {
    if (counter == 0) {
        counter = slideImage.length - 1;
    }
    else {
        counter--;
    }
    slideContainer.style.transition = "transform 0.4s ease-in-out";
    slideContainer.style.transform = 'translateX(' + (-IMG_WIDTH * counter) + 'px)';
});
