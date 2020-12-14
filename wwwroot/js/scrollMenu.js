const navbar = document.querySelector('nav');
// const scrollStyle = document.querySelector('.scroll-menu');

window.addEventListener('scroll', () => {
    navbar.classList.toggle('scroll-menu', window.scrollY > 80);
});
