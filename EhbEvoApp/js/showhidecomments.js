$(function () {

    $("#show-comments-btn").on('click', function (e) {
        e.preventDefault;
        //change text
       
        //get post-div
        var feeddiv = $("#comments");
        //check if div is hidden
        if (feeddiv.is('[hidden]')) {
            feeddiv.removeAttr("hidden");
            feeddiv.show();
            $("#show-comments-btn").text("Verberg Commentaar");
        }
        else {
            feeddiv.hide();
            feeddiv.attr("hidden", "hidden");
            $("#show-comments-btn").text("Toon Commentaar");
        }

    });
});