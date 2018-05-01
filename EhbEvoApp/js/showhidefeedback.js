$(function () {

    $("#show-feedback-btn").on('click', function (e) {
        e.preventDefault;
        //change text
       
        //get post-div
        var feeddiv = $("#feedback");
        //check if div is hidden
        if (feeddiv.is('[hidden]')) {
            feeddiv.removeAttr("hidden");
            feeddiv.show();
            $("#show-feedback-btn").text("Verberg Feedback");
        }
        else {
            feeddiv.hide();
            feeddiv.attr("hidden", "hidden");
            $("#show-feedback-btn").text("Bekijk Feedback");
        }

    });
});