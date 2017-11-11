$(document).ready(function() {


    //$("#d").addClass("active");
    //$("#d13").addClass("active");


    //NUMERIC LER -----------------------------------------------
    $('#TextBox3').keypress(function(event) {
        corenumericyap(event, "#TextBox3");
    });
    //-----------------------------------------------------------


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