$(document).ready(function () {

    $("#loading-image").ajaxStart(function () {
        $(this).show();
    });

    $("#loading-image").ajaxStop(function () {
        $(this).hide();
    });

});