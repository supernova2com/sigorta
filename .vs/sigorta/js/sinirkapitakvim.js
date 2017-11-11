$(document).ready(function() {


    $("#r").addClass("active");
    $("#r2").addClass("active");

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    //$('#TextBox2').mask("99.99.9999", { placeholder: "." });
    $('#TextBox3').mask("99.99.9999", { placeholder: "." });

    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#TextBox1').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    //$('#TextBox2').datepicker({
    //'changeMonth': true,
    //'changeYear': true,
    //'dateFormat': "dd.mm.yy"
    //});

    $('#TextBox3').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


    $('#DropDownList2').change(function() {
        var gerceksirket1pkey = document.getElementById('DropDownList2').value;
        $("#DropDownList3").val(gerceksirket1pkey);
    });
    $('#DropDownList4').change(function() {
        var gerceksirket2pkey = document.getElementById('DropDownList4').value;
        $("#DropDownList5").val(gerceksirket2pkey);
    });
    $('#DropDownList8').change(function() {
        var gerceksirket3pkey = document.getElementById('DropDownList8').value;
        $("#DropDownList9").val(gerceksirket3pkey);
    });



    $('#TextBox1').focusout(function() {
        var baslangictarih = document.getElementById('TextBox1').value;
        $("#TextBox2").val(baslangictarih);
    });

    $('#TextBox1').change(function() {
        var baslangictarih = document.getElementById('TextBox1').value;
        $("#TextBox2").val(baslangictarih);
    });



});