let todayQuote;
let todayQuoteAuthor;

$(document).ready(() => {
    initializeView();
    bindEvents();
    getTodayQuote();
    getWeather();
});

function initializeView() {
    todayQuote = $("#quote");
    todayQuoteAuthor = $("#quoteAuthor");
}

function bindEvents() {
    $("#refreshQuote").click((e) => {
        e.preventDefault();
        getTodayQuote();
        return false;
    });
}

function getTodayQuote() {
    $.ajax({
        url: "https://talaikis.com/api/quotes/random/",
        type: "GET",
        dataType: "json"
    }).done(function (json) {
        todayQuote.text(json.quote);
        todayQuoteAuthor.text(json.author);
    }).fail(function (xhr, status, errorThrown) {
        todayQuote.text("could not get quote :( , try again later");
    });
}

function getWeather() {
    $.ajax({
        url: "http://api.openweathermap.org/data/2.5/weather",
        data: {
            APPID: "d79c4526e2834c7bb5161e07e9f1c660",
            q: "Aleppo",
            units: "metric"
        },
        type: "GET",
        dataType: "json"
    }).done(function (json) {
        $("#cityName").text(json.name);
        $("#temp").text(json.main.temp);
        $("#weatherImg").attr("src", `http://openweathermap.org/img/w/${json.weather[0].icon}.png`);
        console.log(json);
    }).fail(function (xhr, status, errorThrown) {
        $("#cityName").text("could get the weather");
    });
}

function loadHomeData() {
    $.ajax({
        url: "/Home/GetHomeData",
        data: {
        },
        type: "GET",
        dataType: "json"
    }).done(function (json) {
        console.log(json);
        $("#recipeCount").html(json.recipesCount);
        $("#ingredientCount").html(json.ingredientsCount);
        $("#categoryCount").html(json.categoriesCount);
        $("#tip").html(json.tipOfTheDay);
    }).fail(function (xhr, status, errorThrown) {
        console.log("Sorry, could not get home data");
    });
}