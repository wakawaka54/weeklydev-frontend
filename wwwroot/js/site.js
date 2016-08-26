// Write your Javascript code.

//Survey Modal
$(function () {
    $('#survey').on('click', function () {
        var serviceUrl = "/Survey?ajax=true";

        $.ajax({
            type: "GET",
            url: serviceUrl,
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            $("#surveyAjax").html(data);
        }

        function errorFunc(err) {
            console.log(err);
        }
    });
});

//ProjectWell
//TODO - ADD ERROR HANDLING
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
function upvoteComplete(id) {
    $(`#upvote-${id} > i`).addClass('voted');
    $(`#downvote-${id} > i`).removeClass('voted');
    let votes = parseInt($(`#votes-${id}`).text());
    $(`#votes-${id}`).text(votes + 1);
    console.log(`#upvote-${id}`);
}

function downvoteComplete(id) {
    console.log(`#downvote-${id}`);
    $(`#upvote-${id} > i`).removeClass('voted');
    $(`#downvote-${id} > i`).addClass('voted');
    let votes = parseInt($(`#votes-${id}`).text());
    $(`#votes-${id}`).text(votes - 1);
}