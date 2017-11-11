$(document).ready(function() {

    $("#b").addClass("active");
    $("#b2").addClass("active");

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').mask("99.99.9999", { placeholder: "." });
    $('#TextBox3').mask("99.99.9999", { placeholder: "." });
    $('#TextBox4').mask("99.99.9999", { placeholder: "." });


    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#TextBox1').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy",
        onSelect: function() {
            $("#TextBox3").val("");
            $("#TextBox4").val("");
        }
    });

    $('#TextBox2').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy",
        onSelect: function() {
            $("#TextBox3").val("");
            $("#TextBox4").val("");
        }
    });

    $('#TextBox3').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy",
        onSelect: function() {
            $("#TextBox1").val("");
            $("#TextBox2").val("");
        }
    });

    $('#TextBox4').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy",
        onSelect: function() {
            $("#TextBox1").val("");
            $("#TextBox2").val("");
        }
    });


    $("#TextBox1").keypress(function() {
        if ($("#TextBox1").val() != "") {
            $("#TextBox3").val("");
            $("#TextBox4").val("");
        }
    });

    $("#TextBox2").keypress(function() {
        if ($("#TextBox2").val() != "") {
            $("#TextBox3").val("");
            $("#TextBox4").val("");
        }
    });

    $("#TextBox3").keypress(function() {
        if ($("#TextBox3").val() != "") {
            $("#TextBox1").val("");
            $("#TextBox2").val("");
        }
    });

    $("#TextBox4").keypress(function() {
        if ($("#TextBox4").val() != "") {
            $("#TextBox1").val("");
            $("#TextBox2").val("");
        }
    });


});
