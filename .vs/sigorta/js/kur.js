﻿$(document).ready(function() {

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').mask("99.99.9999", { placeholder: "." });
    $('#TextBox3').mask("99.99.9999", { placeholder: "." });
    $('#TextBox4').mask("99.99.9999", { placeholder: "." });


    $.datepicker.setDefaults($.datepicker.regional['tr']);
    
    //---------------------------------------------------------------------------------
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
    //----------------------------------------------------------------------------------
 
    $("#e").addClass("active");
    $("#e2").addClass("active");

    $('.button').button();
    getfancy();

});