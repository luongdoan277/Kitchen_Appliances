const closePopup = document.querySelector('.close-popup');
const Popup = document.querySelector('.payment');
const openPopup = document.querySelector('#payment');


openPopup.addEventListener('click', function () {
    Popup.classList.add('popup-active');
});

closePopup.addEventListener('click', function () {
    Popup.classList.remove('popup-active');
});

