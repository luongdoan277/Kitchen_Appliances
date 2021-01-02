const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);
const IMG_WIDTH = window.innerWidth;
const slideContainer = $(".slides");
const slideImage = [...$$(".slide")];


//Button
const nextBtn = $("#next");
const preBtn = $("#pre");

slideContainer.style.width = IMG_WIDTH + "px";
//slideImage.style.minWidth = IMG_WIDTH + "px";

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

//-----------------------------------Product Demo-------------------------------

const productList = $('.product-list');
const productItem = [...$$('.product')];

const nextPro = $('#nextPro');
const prePro = $('#prePro');

const imgProduct = 270;

productList.style.width = (productItem.length - 5) * imgProduct + "px";

let index = 0;

nextPro.addEventListener('click', () => {
    if (index < productItem.length/2 - 5) {
        index++;
    } else {
        index = 0;
    }
    productList.style.transition = "transform 0.4s ease-in-out";
    productList.style.transform = 'translateX(' + (-imgProduct * index) + 'px)';
});

prePro.addEventListener('click', () => {
    if (index == 0) {
        index = productItem.length/2 - 5;
    }
    else {
        index--;
    }
    productList.style.transition = "transform 0.4s ease-in-out";
    productList.style.transform = 'translateX(' + (-imgProduct * index) + 'px)';
});




//

const navLinks = document.querySelectorAll('.link');

navLinks.forEach((link) => {
    link.addEventListener("click", () => {

        navLinks.forEach(link => link.classList.remove("active"));
        link.classList.add('active');
    })
});
//----------------------------------------------------------------------


function checkout() {
    const cart = document.querySelector('.cart-icon');
    const checkout = document.querySelector('.cart-checkout');

    cart.addEventListener('click', () => {
        checkout.classList.toggle('active-checkout');
    });
}
checkout();