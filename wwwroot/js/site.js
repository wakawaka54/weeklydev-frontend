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