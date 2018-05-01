$(function () {

    $("#show-post-btn").on('click', function (e) {
        e.preventDefault;
        //change text
       
        //get post-div
        var postdiv = $("#org-post");
        //check if div is hidden
        if (postdiv.is('[hidden]')) {
            postdiv.removeAttr("hidden");
            postdiv.show();
            $("#show-post-btn").text("Verberg originele post");
        }
        else {
            postdiv.hide();
            postdiv.attr("hidden", "hidden");
            $("#show-post-btn").text("Bekijk originele post");
        }

    });
});