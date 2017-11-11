$(document).ready(function() {



    $("#e").addClass("active");
    $("#e3").addClass("active");

    //NUMERIC LER -----------------------------------------------
    $('#TextBox1').keypress(function(event) {
        numericyap(event, "#TextBox1");
    });
    //-----------------------------------------------------------


    $('#TextBox3').mask("99.99.9999", { placeholder: "." });
    $('#TextBox4').mask("99.99.9999", { placeholder: "." });
    $('#TextBox5').mask("99.99.9999", { placeholder: "." });
    $('#TextBox6').mask("99.99.9999", { placeholder: "." });

    $.datepicker.setDefaults($.datepicker.regional['tr']);
    
    $('#TextBox3').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    $('#TextBox4').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    $('#TextBox5').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    $('#TextBox6').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


});