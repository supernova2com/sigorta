$(document).ready(function() {

    $("#eposta").focus();

    $('#sifremigonderbutton').click(function(e) {
        e.preventDefault();
        var eposta = document.getElementById("eposta").value;
        sifremigonder(eposta);
    });

    //eposta enter tuşu
    $('#eposta').keypress(function(e) {
        if (!!$("input[id$='eposta']").val()) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) {
                var eposta = document.getElementById("eposta").value;
                sifremigonder(eposta);
            }
        }
    });


});



function sifremigonder(eposta) {

    $("#Labeluyari").html("");

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/sifremigonder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{eposta:"' + eposta + '"}',
        async: false,
        success: function(result) {
            $("#Labeluyari").html(result.d);
        },
        error: function() {
            alert('Şifrenizi e-posta adresine gönderirken bir sorun oluştu.');
        }
    });
}