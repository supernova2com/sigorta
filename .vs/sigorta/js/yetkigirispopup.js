
$(document).ready(function() {

    $('input[type="text"][data-durum="disableolacak"]').attr("disabled", true);

    $("#Button1").show();

    $('.accordion').accordion({ autoHeight: false });


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





