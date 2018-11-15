$(document).ready(() => {
    initializeView();
});

function initializeView() {
    $("#recipeIngredientsTable").DataTable();
    ClassicEditor
        .create(document.querySelector('#Description'))
        .then(editor => {
            console.log(editor);
        })
        .catch(error => {
            console.error(error);
        });
}

function bindEvents() {

}

function validateForm() {
}

