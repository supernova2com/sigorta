

$(document).ready(function() {


    //GİRİŞ DÜĞMESİNİ BASTIĞINDA
    $('#Button1').click(function(e) {

        var hata = "0";
        $('#Labeluyari').hide();


        var kullaniciad = document.getElementById('TextBox1').value;
        var kullanicisifre = document.getElementById('TextBox2').value;

        hata = "0";

        if (kullaniciad == "") {
            showtoast("error", "HATA", "Kullanıcı adınızı girmediniz.");
            hata = "1";
            e.preventDefault();
        }

        if (kullanicisifre == "") {
            showtoast("error", "HATA", "Kullanıcı şifrenizi girmediniz.");
            hata = "1";
            e.preventDefault();
        }


        if (hata == "0") {
            logincontrol(kullaniciad, kullanicisifre, function(result) {
                if (result.d.durum == "Hayır") {
                    hata = "1";
                    showtoast("error", "HATA", result.d.hatastr);
                    $('#TextBox1').focus();
                    e.preventDefault();
                }
            });
        } //hata==0

    });

});



function logincontrol(kullaniciad,kullanicisifre,callback) {

    var veriler = { kullaniciad: kullaniciad, kullanicisifre: kullanicisifre};

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/logincontrol",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            if (typeof (callback) === 'function') {
                callback(result);
            }
        },
        error: function(request, status, error) {
            //var msg;
            //msg="Giriş yapmaya çalışırken bir sorun oluştu." + request.responseText;
            //showtoast("error", "HATA", msg);
        }
    });

}