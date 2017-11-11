$(document).ready(function() {

    $("#k").addClass("active");
    $("#k3").addClass("active");

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').mask("99.99.9999", { placeholder: "." });

    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#TextBox1').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


    $('#TextBox2').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


});



function okunduyap(pkey) {

    var veriler = { pkey: pkey};

    $.ajax({
        type: "POST",
        url: "errorservis.aspx/okunduyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.durum == "Kaydedildi") {
                var okundubutton = '#okundubutton' + pkey;
                var okunmadibutton = '#okunmadibutton' + pkey;
                $(okundubutton).hide();
                $(okunmadibutton).show();
                showtoast("success", "KAYIT", "Başarılı bir şekilde kaydedildi.");
            }

        },
        error: function(request, status, error) {
            alert('Hata oluştu:' + request.responseText);
        }
    });
}


function okunmadiyap(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "errorservis.aspx/okunmadiyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
        if (result.d.durum == "Kaydedildi") {
            var okundubutton = '#okundubutton' + pkey;
            var okunmadibutton = '#okunmadibutton' + pkey;
                $(okundubutton).show();
                $(okunmadibutton).hide();
                showtoast("success", "KAYIT", "Başarılı bir şekilde kaydedildi.");
            }

        },
        error: function(request, status, error) {
            alert('Hata oluştu:' + request.responseText);
        }
    });
}


function sil(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "errorservis.aspx/sil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.durum == "Kaydedildi") {
                var id = '#silbutton' + pkey;
                $(id).hide();
                showtoast("success", "KAYIT", "Başarılı bir şekilde kaydedildi.");
                listele();
            }

        },
        error: function(request, status, error) {
            alert('Hata oluştu:' + request.responseText);
        }
    });
}


function eposta(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "errorservis.aspx/epostagonder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
        if (result.d.durum == "Kaydedildi") {
                var id = '#epostabutton' + pkey;
                $(id).hide();
                showtoast("success", "KAYIT", "E-Posta başarılı bir şekilde gönderildi.");
            }

        },
        error: function(request, status, error) {
            alert('Hata oluştu:' + request.responseText);
        }
    });
}




function listele() {
    $.ajax({
        type: "POST",
        url: "errorservis.aspx/listele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function(result) {
                $('#Label1').html(result.d);
        },
        error: function(request, status, error) {
            alert('Hata oluştu:' + request.responseText);
        }
    });
}

