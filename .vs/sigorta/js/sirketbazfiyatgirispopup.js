
$(document).ready(function() {


    $('#bb3').css("border-left-style", "none");
    $('#bb5').css("border-left-style", "none");
    $('#bb7').css("border-left-style", "none");
    $('#bb9').css("border-left-style", "none");
    $('#bb11').css("border-left-style", "none");


    $('td[id $= "-1"]').css("background-color", "#e0e0d1");
    $('td[id $= "-2"]').css("background-color", "#e0e0d1");

    $('td[id $= "-3"]').css("background-color", "lightyellow");
    $('td[id $= "-4"]').css("background-color", "lightyellow");

    $('td[id $= "-5"]').css("background-color", "#e0e0d1");
    $('td[id $= "-6"]').css("background-color", "#e0e0d1");

    $('td[id $= "-7"]').css("background-color", "lightyellow");
    $('td[id $= "-8"]').css("background-color", "lightyellow");

    $('td[id $= "-9"]').css("background-color", "#e0e0d1");
    $('td[id $= "-10"]').css("background-color", "#e0e0d1");


    $('input[type="text"]').keypress(function(event) {
        numericyap(event, "#TextBox1");
    });
    $('input[type="text"][data-durum="disableolacak"]').attr("disabled", true);
    $('input[type="text"][data-durum="disableolacak"]').hide();

    $('.computergenerated').mask("99,99", { placeholder: "" });

    //NUMERIC LER -----------------------------------------------
    $('#TextBox2').keypress(function(event) {
        numericyap(event, "#TextBox2");
    });
    //-----------------------------------------------------------

    var op = getQuerystring("op");

    $('.accordion').accordion({ autoHeight: false });

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox7').mask("99.99.9999", { placeholder: "." });

    $(".button").button();
    $("#tabsbilgi").tabs();


    if (op == "yenikayit") {
        $("#Labelinput").hide();
    }

    if (op == "duzenle") {
        $("#Labelinput").show();
        $("#tabsbilgi").tabs("option", "active", 1);
    }

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


});      //document ready





