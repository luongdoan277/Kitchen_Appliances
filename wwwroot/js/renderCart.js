const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);
function addToCart(ProductID) {
    $.ajax({
        url: 'https://localhost:44358/Cart/AddToCart?ProductID=' + ProductID,
        type: 'GET'
    }).done(function (response) {
        RenderCart(response);
        console.log(response);
        alertify.success('Success add a product');
    });
}
$("#change-item-cart").on("click", ".delete-items i", function (){
    $.ajax({
        url: '/deleteItem/' + $(this).data("id"),
        type: 'GET'
    }).done(function (response) {
        RenderCart(response);
        alertify.success('Delete product success');
    });
})

function deleteItemList(id) {
    $.ajax({
        url: '/deleteItemList/' + id,
        type: 'GET'
    }).done(function (response) {
        RenderCart(response);
        alertify.success('Delete product success');
    });
}
function saveItemList(id){
    $.ajax({
        url: '/saveItemList/' + id + '/' + $('#qty-item-' + id).val(),
        type: 'GET'
    }).done(function (response) {
        RenderCart(response);
        alertify.success('Update product success');
    });
}

function RenderListCart(response){
    $("#list-item-cart").empty();
    $("#list-item-cart").html(response);
}

function RenderCart(response){
    $("#change-item-cart").empty();
    $("#change-item-cart").html(response);
    $("#total-quantity-show").text($("#total_quantity").val());
}
