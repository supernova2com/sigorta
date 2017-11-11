$(document).ready(function() {

    $("#password").focus();

    $('#girbutton').click(function(e) {
        e.preventDefault();
        var password = document.getElementById("password").value;
        lockyonlendir(password);
    });

    //password enter tuşu
    $('#password').keypress(function(e) {
        if (!!$("input[id$='password']").val()) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) {
                var password = document.getElementById("password").value;
                lockyonlendir(password);
            }
        }
    });


});



function lockyonlendir(password) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/lockyonlendir",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{password:"' + password + '"}',
        success: function(result) {
                window.location.href=result.d;
        },
        error: function() {
            alert('Yönlendirme yaparken bir sorun oluştu.');
        }
    });
}