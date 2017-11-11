
$(document).ready(function() {

    $('#DropDownList1').change(function() {
        var merkezmi = document.getElementById('DropDownList1').value;
        if (merkezmi == "Evet") {

            $("#DropDownList2").val("2");
            var sirketpkey = null;
            var inputElements = document.getElementsByClassName('sirketcheckbox');

            for (var i = 0; inputElements[i]; ++i) {
                if (inputElements[i].checked) {
                    sirketpkey = inputElements[i].value;
                    break;
                }
            } //end for

            if (sirketpkey != null) {
                otodoldurform(sirketpkey);
            }

        } //end if

    });


    //NUMERIC LER -----------------------------------------------
    $('#TextBox4').keypress(function(event) {
        numericyap(event, "#TextBox4");
    });
    //-----------------------------------------------------------
    //NUMERIC LER -----------------------------------------------
    $('#TextBox5').keypress(function(event) {
        numericyap(event, "#TextBox5");
    });
    //-----------------------------------------------------------
    //NUMERIC LER -----------------------------------------------
    $('#TextBox7').keypress(function(event) {
        numericyap(event, "#TextBox7");
    });
    //NUMERIC LER -----------------------------------------------
    $('#TextBox8').keypress(function(event) {
        numericyap(event, "#TextBox8");
    });
    //-----------------------------------------------------------


    $('.accordion').accordion({ autoHeight: false });

    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "selected", parseInt(currTab));

    getfancy();



});


function otodoldurform(sirketpkey) {

        var veriler = { sirketpkey: sirketpkey};

        $.ajax({
            type: "POST",
            url: "yonetimanaservis.aspx/sirketbul",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            data: $.toJSON(veriler),
            success: function(result) {
                $("#TextBox3").val(result.d.yetkilikisiadsoyad);
                $("#TextBox6").val(result.d.eposta);
                $("#TextBox7").val(result.d.ofistelefon);
                $("#TextBox8").val(result.d.faks);
            },
            error: function(request, status, error) {
                alert('Formu otomatik doldururken bir sorun oluştu:' + request.responseText);
            }
        });
    }




