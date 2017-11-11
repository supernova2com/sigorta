$(document).ready(function() {


    $("#TextBox7").keypress(function() {
        if (document.getElementById("TextBox7").value != "") {
            $("#TextBox9").val("");
            $("#TextBox10").val("");
        }
    });

    $("#TextBox9").keypress(function() {
        if (document.getElementById("TextBox9").value != "") {
            $("#TextBox10").val("");
        }
    });

    $("#TextBox10").keypress(function() {
        if (document.getElementById("TextBox10").value != "") {
            $("#TextBox9").val("");
        }
    });


    $("#TextBox10").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            // I have tried setting those
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#TextBox10").val(($("#TextBox10").val()).toUpperCase().replace(" ",""));  
    });



    $("#c").addClass("active");
    $("#c1").addClass("active");


});

