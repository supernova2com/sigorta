$(document).ready(function() {


    $('.accordion').accordion({ autoHeight: false });
    $('.button').button();

    $('#aktar1').bind('click', function(e) {

        var aktarilacak, hata, aktarilacak_d;
        hata = 0;

        hedef = document.getElementById("TextBox3").value;
        kaynak = document.getElementById("DropDownList1").value;

        if (kaynak == "") {
            hata = 1;
        }

        if (hata == 0) {
            if (hedef == "") {
                $('#TextBox3').val(kaynak);
            }
            if (hedef != "") {
                $('#TextBox3').val($('#TextBox3').val() + "," + kaynak);
                //alert("erboo");
            }
        }
    });



    $('#aktar2').bind('click', function(e) {

        var aktarilacak, hata, aktarilacak_d;
        hata = 0;

        hedef = document.getElementById("TextBox3").value;
        kaynak = document.getElementById("DropDownList2").value;

        if (kaynak == "") {
            hata = 1;
        }

        if (hata == 0) {
            if (hedef == "") {
                $('#TextBox3').val(kaynak);
            }
            if (hedef != "") {
                $('#TextBox3').val($('#TextBox3').val() + "," + kaynak);
                //alert("erboo");
            }
        }
    });

});  //document.ready