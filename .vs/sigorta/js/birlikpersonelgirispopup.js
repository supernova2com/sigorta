

$(document).ready(function() {


    $.datepicker.setDefaults($.datepicker.regional['tr']);


    $('#TextBox7').mask("99.99.9999", { placeholder: "." });
    $('#TextBox8').mask("99.99.9999", { placeholder: "." });
    
    $('#TextBox7').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    $('#TextBox8').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


    //NUMERIC LER -----------------------------------------------
    $('#TextBox5').keypress(function(event) {
        numericyap(event, "#TextBox5");
    });
    //-----------------------------------------------------------

    $('.accordion').accordion({ autoHeight: false });

    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "selected", parseInt(currTab));

    //teknik personel mi
    $("#DropDownList1").change(function() {
        var teknikpersonelmi;
        teknikpersonelmi = document.getElementById("DropDownList1").value;
        if (teknikpersonelmi == "Hayır") {
            $("#TextBox3").val("-");
            $("#TextBox3").attr('readonly', true);
        }

        if (teknikpersonelmi == "Evet") {
            $("#TextBox3").val("");
            $("#TextBox3").attr('readonly', false);
            $("#TextBox3").focus();
        }
    });


    //eğitime katılmış mı 
    $("#DropDownList4").change(function() {
        var egitimekatilmismi;
        egitimekatilmismi = document.getElementById("DropDownList4").value;
        if (egitimekatilmismi == "Hayır") {
            $("#TextBox6").val("");
            $("#TextBox6").attr('readonly', true);
            $("#TextBox7").val("");
            $("#TextBox7").attr('readonly', true);
        }

        if (egitimekatilmismi == "Evet") {
            $("#TextBox6").val("");
            $("#TextBox6").attr('readonly', false);
            $("#TextBox6").focus();
            $("#TextBox7").val("");
            $("#TextBox7").attr('readonly', false);
        }
    });

});
