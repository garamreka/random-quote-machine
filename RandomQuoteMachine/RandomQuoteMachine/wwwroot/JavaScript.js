$(document).ready(function () {

    window.baseUrl = "http://localhost:4112/";
    var randomQuote;

    $("#new-quote").on("click", function () {
        $.get(window.baseUrl + "/api", {}).done(function (data) {
            randomQuote = data["content"];
            $(".quote").text(randomQuote);
        });
    });

    $("#tweet-quote").on("click", function () {
        window.open("https://twitter.com/intent/tweet?text=" + randomQuote);
    });
});