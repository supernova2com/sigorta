
$(document).ready(function() {


    //TÜR DEĞİŞTİĞİNDE
    $('#DropDownList2').change(function() {
        var tur = document.getElementById('DropDownList2').value;
        if (tur == "Gecikme") {
            $('#TextBox3').show();
            $('#Button3').show();
        }
        if (tur == "Ödeme") {
            $('#TextBox3').hide();
            $('#Button3').hide();
        }
    });


    //NUMERIC LER -----------------------------------------------
    $('#TextBox2').keypress(function(event) {
        numericyap(event, "#TextBox2");
    });
    //-----------------------------------------------------------

    $('.accordion').accordion({ autoHeight: false });

    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "selected", parseInt(currTab));

    var k;
    k = getQuerystring("k");
    if (k == 1) {
        $("#tabsbilgi").tabs("option", "active", 1);
    }


});



function ekstregoster() {

    var firmcode;
    firmcode = getQuerystring("firmcode");
    
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/ekstregoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{firmcode:"' + firmcode + '"}',
        async: false,
        success: function(result) {
            $('#Label1').html(result.d);
        },
        error: function(request, status, error) {
            alert('İlgili firmanın eksteresini gösterirken bir sorun oluştu.' + request.responseText);
        }
    });

}

function hesapsil(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/hesapsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            ekstregoster();
        },
        error: function(request, status, error) {
            alert('İlgili hesabı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}