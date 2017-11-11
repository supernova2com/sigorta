
$(document).ready(function() {

    $('.accordion').accordion({ heightStyle: "content" });

    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#tabsbilgi").tabs({ activate: function(event, ui) {
        var op = getQuerystring("op");
        if ((op == "yenikayit") && ui.newTab.index() == 1) {
            var txt = "Öncelikle Kaydet ve İleri -> etiketli düğmeyle kayıt yapınız.";
            $("#Button1").hide();
            showdialogbox("HATA", txt);

        }
    }
    });


});   //document ready


function pertaracresimsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/pertaracresimsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            pertaracresimlistele();
        },
        error: function(request, status, error) {
            alert('Resmi silmeye çalışırken bir sorun oluştu.' + request.responseText);
        }
    });

}

function pertaracresimanaresim(pkey) {

    var pertaracpkey;
    pertaracpkey = getQuerystring("pertaracpkey");
    
    var veriler = { pertaracpkey: pertaracpkey, pkey: pkey };

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/pertaracresimanaresimyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            pertaracresimlistele();
        },
        error: function(request, status, error) {
            alert('Resmi silmeye çalışırken bir sorun oluştu.' + request.responseText);
        }
    });

}


function pertaracresimlistele() {


    var pertaracpkey = getQuerystring("pertaracpkey");
    var veriler = { pertaracpkey: pertaracpkey };
    
    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/pertaracresimlistele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            $('#Label1').html(result.d);
        },
        error: function(request, status, error) {
            alert('Pert araç resimlerini listelemeye çalışırken bir sorun oluştu.' + request.responseText);
        }
    });

}




