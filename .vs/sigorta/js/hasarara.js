﻿$(document).ready(function() {

    $("#c").addClass("active");
    $("#c2").addClass("active");

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').mask("99.99.9999", { placeholder: "." });

    //PLAKA YAP
    $("#TextBox8").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#TextBox8").val(($("#TextBox8").val()).toUpperCase().replace(" ", ""));
    });

    //PLAKA YAP
    $("#TextBox13").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#TextBox13").val(($("#TextBox13").val()).toUpperCase().replace(" ", ""));
    });


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
