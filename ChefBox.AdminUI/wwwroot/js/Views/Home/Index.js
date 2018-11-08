$(document).ready(() => {
   loadHomeData();
});

function loadHomeData() {
    $.ajax({
        url: "/Home/GetHomeData",
        data: {
        },
        type: "GET",
        dataType: "json",
    }).done(function (json) {
        console.log(json);
        $("#recipeCount").html(json.recipesCount);
        $("#ingredientCount").html(json.ingredientsCount);
        $("#categoryCount").html(json.categoriesCount);
        $("#tip").html(json.tipOfTheDay);
    }).fail(function (xhr, status, errorThrown) {
            alert("Sorry, could not get home data");
    });
}