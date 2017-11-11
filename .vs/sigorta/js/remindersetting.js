$(document).ready(function() {

    $("#m").addClass("active");
    $("#m9").addClass("active");

    $('#Textbox7').mask("99.99.9999", { placeholder: "." });

    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#Textbox7').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


 });