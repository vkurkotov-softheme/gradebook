$(document).ajaxError(function (event, request, settings) {
    $("#error-dialog").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
});