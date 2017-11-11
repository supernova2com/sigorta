
$(document).ready(function() {

    $('input[type="text"]').keypress(function(event) {
        numericyap(event, "#TextBox1");
    });
    $('input[type="text"][data-durum="disableolacak"]').attr("disabled", true);
    $('.computergenerated').mask("99,99", { placeholder: "" });

    $("#Button1").show();

    //NUMERIC LER -----------------------------------------------
    $('#TextBox2').keypress(function(event) {
        corenumericyap(event, "#TextBox2");
    });
    //-----------------------------------------------------------


    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#TextBox1').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    $('#TextBox7').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


    var op = getQuerystring("op");


    $('.accordion').accordion({ autoHeight: false });

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox7').mask("99.99.9999", { placeholder: "." });

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



