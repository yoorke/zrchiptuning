$(document).ready(function () {
    $('#txtHeading').focus();
})

function btnContactSendMail() {
    var heading = $('#txtHeading').val();
    var email = $('#txtEmail').val();
    var message = $('#txtMessage').val();

    $.ajax({
        type: "POST",
        url: "WebMethods.aspx/SendMail",
        data: JSON.stringify({ "heading": heading, "email": email, "message": message }),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $('#contactStatusMessage').show();
            $('#message')[0].innerHTML = JSON.parse(msg.d);
            $('#contactStatusMessage').removeClass();
            $('#contactStatusMessage').addClass('statusMessage status-success');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $('#contactStatusMessage').show();
            $('#message')[0].innerHTML = JSON.parse(jqXHR.responseText)['Message'];
            $('#contactStatusMessage').removeClass().addClass('statusMessage status-danger');
        }
    })
}