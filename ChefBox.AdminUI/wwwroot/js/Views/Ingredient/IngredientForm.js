let nameInput;
let nameInputValidation;

let descriptionInput;
let descriptionInputValidation;

$(document).ready(() => {
    initializeView();
    bindEvent();
});

function initializeView() {
    nameInput = $("#Name");
    nameInputValidation = $("#nameValidation");

    descriptionInput = $("#Description");
    descriptionInputValidation = $("#descriptionValidation");
}

function bindEvent() {
    $("#ingredientForm").submit((e) => {
        if (!validateForm()) {
            e.preventDefault();
        }
    });
}

function validateForm() {
    let isValid = true;
    if (!nameInput.val()) {
        nameInput.addClass("border border-danger");
        nameInputValidation.text("Please enter the ingredient name");
        isValid &= false;
    } else {
        nameInput.removeClass("border border-danger");
        nameInput.addClass("border border-success");
        nameInputValidation.text(null);
    }
    if (descriptionInput.val() && (descriptionInput.val().length < 5 || descriptionInput.val().length > 250)) {
        descriptionInput.addClass("border border-danger");
        descriptionInputValidation.text("Description should be between 5 and 250 characters");
        isValid &= false;
    } else {
        descriptionInput.removeClass("border border-danger");
        descriptionInput.addClass("border border-success");
        descriptionInputValidation.text(null);
    }
    return isValid;
}