$(document).ready(function() {

    $("#kullaniciad").focus();

    $('#sifremigonderbutton').click(function(e) {
        e.preventDefault();
        var eposta = document.getElementById("eposta").value;
        var kullaniciad = document.getElementById("kullaniciad").value;
        if (eposta!="" && kullaniciad!="") {
            sifremigonder(eposta, kullaniciad); }
            else {
             showtoast("error", "HATA", "E-posta ve kullanıcı adınızı giriniz.");
            }
    });

    //eposta enter tuşu
    $('#eposta').keypress(function(e) {
        if (!!$("input[id$='eposta']").val()) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) {
                var eposta = document.getElementById("eposta").value;
                var kullaniciad = document.getElementById("kullaniciad").value;
                if (eposta!="" && kullaniciad!="") {
                    sifremigonder(eposta,kullaniciad); } else {
                        showtoast("error", "HATA", "E-posta ve kullanıcı adınızı giriniz.");
                    }
            }
        }
    });


});



function sifremigonder(eposta,kullaniciad) {

    var veriler = { eposta: eposta, kullaniciad: kullaniciad };
    $("#Labeluyari").html("");
    
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sifremigonder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async:false,
        success: function(result) {
            $("#Labeluyari").html(result.d);
        },
        error: function(request, status, error) {
            alert('Şifrenizi e-posta adresine gönderirken bir sorun oluştu.' + request.responseText);
        }
    });
}