$(document).ready(function() {

    $("#j").addClass("active");
    $("#j3").addClass("active");

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').mask("99.99.9999", { placeholder: "." });

    $('#TextBox3').mask("99.99.9999", { placeholder: "." });
    $('#TextBox4').mask("99.99.9999", { placeholder: "." });

    $('#TextBox5').mask("99.99.9999", { placeholder: "." });
    $('#TextBox6').mask("99.99.9999", { placeholder: "." });

    $('#TextBox7').mask("99.99.9999", { placeholder: "." });
    $('#TextBox8').mask("99.99.9999", { placeholder: "." });

    $('#TextBox11').mask("99.99.9999", { placeholder: "." });
    $('#TextBox12').mask("99.99.9999", { placeholder: "." });


    //NUMERIC LER -----------------------------------------------
    $('#TextBox13').keypress(function(event) {
        numericyap(event, "#TextBox13");
    });
    //-----------------------------------------------------------

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
    $('#TextBox11').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox12').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

});