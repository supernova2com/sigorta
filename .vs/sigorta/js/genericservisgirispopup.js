var genericservispkey;

$(document).ready(function() {


    var op;
    op = getQuerystring("op");
    if (op == "yenikayit") {
        $("#TextBox1").focus();
    }

    genericservispkey = getQuerystring("pkey");

    $('.accordion').accordion({ autoHeight: false });
    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#tabsbilgi").tabs({ activate: function(event, ui) {
        var op = getQuerystring("op");

        if ((op == "yenikayit") && ui.newTab.index() == 1) {
            $("#Buttongosterilecekfieldekle").hide();
            var txt = "Yeni kayıt yaparken tablo ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi2icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 2) {
            $("#Buttongosterilecekfieldekle").hide();
            var txt = "Yeni kayıt yaparken input parametre ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi3icerik").hide();

        }
        if ((op == "yenikayit") && ui.newTab.index() == 3) {
            $("#Buttonkosulfieldekle").hide();
            var txt = "Yeni kayıt yaparken output parametre ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi4icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 4) {
            $("#Buttonsiralamafieldekle").hide();
            var txt = "Yeni kayıt yaparken kullanıcı ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi5icerik").hide();
        }
        }
    });


    $('#DropDownList9').change(function() {
        var f = document.getElementById("DropDownList9");
        var tabload = f.options[f.selectedIndex].text;
        bul_vtablo("tabloaciklama1", tabload);

        
        
});




});           //document.ready


//SİLEMELER


// tablo sil
function genericservistablosil(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericservistablosil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
            genericservistablogoster(genericservispkey);
        },
        error: function(request, status, error) {
            alert('Sorun oluştu.' + request.responseText);
        }
    });

}


// input sil
function genericservisinputsil(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericservisinputsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
            genericservisinputgoster(genericservispkey);
        },
        error: function(request, status, error) {
            alert('Sorun oluştu.' + request.responseText);
        }
    });

}



// output sil
function genericservisoutputsil(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericservisoutputsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
            genericservisoutputgoster(genericservispkey);
        },
        error: function(request, status, error) {
            alert('Sorun oluştu.' + request.responseText);
        }
    });

}


// kullanici sil
function genericserviskullanicisil(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericserviskullanicisil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
            genericserviskullanicigoster(genericservispkey);
        },
        error: function(request, status, error) {
            alert('Sorun oluştu.' + request.responseText);
        }
    });

}



// GÖSTERMELER ------------------------------------------------------------

//tablo gösterir.
function genericservistablogoster(genericservispkey) {

    var veriler = { genericservispkey: genericservispkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericservistablogoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Labelgenericservistablo').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Tabloları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}

//input gösterir.
function genericservisinputgoster(genericservispkey) {

    var veriler = { genericservispkey: genericservispkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericservisinputgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Labelgenericservisinput').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Input parametrelerini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//output gösterir.
function genericservisoutputgoster(genericservispkey) {

    var veriler = { genericservispkey: genericservispkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericservisoutputgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Labelgenericservisoutput').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Output parametrelerini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//kullanici gösterir.
function genericserviskullanicigoster(genericservispkey) {

    var veriler = { genericservispkey: genericservispkey };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/genericserviskullanicigoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Labelgenericserviskullanici').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Kullanıcıları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}



//TABLO AÇIKLAMA BİLGİLERİ
function bul_vtablo(id, tabload) {

    var spanid = "#" + id;
    var span = $(spanid);

    var veriler = { tabload: tabload };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/bul_vtablo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            span.html(result.d.aciklama);
        },
        error: function(request, status, error) {
            alert('Tablo açıklama bilgisini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//KOLON AÇIKLAMA BİLGİSİNİ BUL
function bul_vkolon(id, tabload, kolonad) {

    var spanid = "#" + id;
    var span = $(spanid);

    var veriler = { tabload: tabload, kolonad: kolonad };

    $.ajax({
        type: "POST",
        url: "genericservisajax.aspx/bul_vkolon",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            span.html(result.d.kolonaciklama);
        },
        error: function(request, status, error) {
            alert('Tablo açıklama bilgisini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}








