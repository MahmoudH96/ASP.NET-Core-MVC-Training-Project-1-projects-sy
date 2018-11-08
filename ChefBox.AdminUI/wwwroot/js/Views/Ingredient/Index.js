let ingredientNameInput;
let ingredientDescriptionInput;

$(document).ready(() => {
    initializeView();
    bindEvents();
});

function initializeView() {
    ingredientName = $("#ingredientName");
    ingredientDescription = $("#ingredientDescription");
}

function bindEvents() {
    $(document).on('click', '.remove-ingredient', (e) => {
        const row = $(e.target).closest("tr");
        swal({
            icon: "warning",
            title: `Are you sure that you want to remove ${row.data("name")}?`,
            text: "You will be able to recover it later",
            icon: "warning",
            buttons: [
                'Cancel',
                'Remove it'
            ],
            dangerMode: true
        }).then(function (isConfirm) {
            if (isConfirm) {
                removeFromServer(row);
            }
        })
    });

    $("#addIngredientForm").submit((e) => {
        e.preventDefault();

        return false;
    });
}
function removeFromServer(row) {
    const removedItemId = row.data('id');
    $.ajax({
        url: `/Ingredient/RemoveIngredient/${removedItemId}`,
        type: "DELETE",
        dataType: "json",
    }).done(function (json) {
            row.remove();
            toastr.success('Ingredient removed successfully', 'Success');
    }).fail(function (xhr, status, errorThrown) {
            toastr.error('Failed to remove ingredient', 'Error');
    });

}

function addIngredient() {
    if (!ingredientNameInput.val()) {
        toastr.error('Please enter ingredient name', 'error !');
        return;
    }

    $('#productsTable > tbody:last-child').append(getItemTr(nameInput.val(), priceInput.val()));
    toastr.success('Product added successfully', 'Success');
}

function submitAddIngredientAjax() {
    $.ajax({
        url: "/Ingredient/IngredientForm",
        data: {
            Name: ingredientNameInput.val(),
            Description: ingredientDescriptionInput.val()
        },
        type: "POST",
        dataType: "json",
    }).done(function (json) {

    }).fail(function (xhr, status, errorThrown) {
        toastr.error("Could not add ingredient, please try again later", "Oops !");
    });
}

function getIngredientTr(name, price) {
    return ` <tr>
            <td>${name}</td>
            <td>${price}</td>
            <td class="text-center">
                <button class="btn btn-danger btn-sm remove-product">
                    <i class="fas fa-trash-alt"></i>
                </button>
            </td>
        </tr>`;
}