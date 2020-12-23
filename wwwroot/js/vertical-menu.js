const itemClick = document.querySelectorAll(".item");
const childLayout = document.querySelectorAll(".child-layout");

console.log(childLayout);
console.log(itemClick);

itemClick.forEach((item, index) => {
    item.addEventListener('click', function () {
        childLayout[index].classList.toggle('active-menu');
        item.classList.toggle('active-a')
    });
});
