let ingredientNameInput;
let ingredientDescriptionInput;

$(document).ready(() => {
    initializeView();
    bindEvents();
});

function initializeView() {
    ingredientNameInput = $("#ingredientName");
    ingredientDescriptionInput = $("#ingredientDescription");
}

function bindEvents() {
    $(document).on('click', '.remove-ingredient', (e) => {
        const row = $(e.target).closest("tr");
        swal({
            icon: "warning",
            title: `Are you sure that you want to remove ${row.data("name")}?`,
            text: "You will be able to recover it later",
            buttons: [
                'Cancel',
                'Remove it'
            ],
            dangerMode: true
        }).then(function (isConfirm) {
            if (isConfirm) {
                removeFromServer(row);
            }
        });
    });

    $("#addIngredientForm").submit((e) => {
        e.preventDefault();
        addIngredient();
        return false;
    });
}
function removeFromServer(row) {
    const removedItemId = row.data('id');
    $.ajax({
        url: `/Ingredient/RemoveIngredient/${removedItemId}`,
        type: "DELETE",
        dataType: "json"
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
    submitAddIngredientAjax();
}

function submitAddIngredientAjax() {

    const ingredientData = {
        Name: ingredientNameInput.val(),
        Description: ingredientDescriptionInput.val()
    };
    $.ajax({
        url: "/Ingredient/IngredientForm",
        data: ingredientData,
        type: "POST",
        dataType: "json"
    }).done(function (json) {
        console.log(json);
        $('#ingredientTable > tbody:last-child').append(getIngredientTr(json));
        toastr.success(`${json.name} had been added successfully`, 'Success');

    }).fail(function (xhr, status, errorThrown) {
        toastr.error("Could not add ingredient, please try again later", "Oops !");
    });
}

function getIngredientTr(ingredientData) {
    return `<tr data-id="${ingredientData.id}"
                data-name="${ingredientData.name}">
                <td>${ingredientData.name}</td>
                <td>0</td>
                <td>${ingredientData.description}</td>
                <td>
                    <a asp-controller="Ingredient"
                        asp-action="IngredientForm"
                        asp-route-id="@ingredient.Id"
                        class="btn btn-secondary btn-sm">
                        <i class="fas fa-edit"></i>
                    </a>
                    <a href="#" 
                        class="btn btn-danger btn-sm remove-ingredient">
                        <i class="fas fa-trash"></i>
                    </a>
                </td>
            </tr>`;
}