
$(document).ready(function() {

    $('input[type="text"]').keypress(function(event) {
        numericyap(event, "#TextBox1");
    });
    $('input[type="text"][data-durum="disableolacak"]').attr("disabled", true);
    $('.computergenerated').mask("99,99", { placeholder: "" });
    
    $("#Button1").show();

    //NUMERIC LER -----------------------------------------------
    $('#TextBox2').keypress(function(event) {
        corenumericyap(event, "#TextBox2");
    });
    //-----------------------------------------------------------


    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#TextBox1').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });

    $('#TextBox7').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


    var op = getQuerystring("op");
    
    //ŞİRKET DEĞİŞTİĞİNDE KAYIT NUMARASINI BUL
    $("#DropDownList1").change(function() {
   
        var sirketpkey;
        sirketpkey = document.getElementById("DropDownList1").value;
        if (op == "yenikayit" && sirketpkey != "0") {
            kayitnobul(sirketpkey);
        }
    });


    $('.accordion').accordion({ autoHeight: false });

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox7').mask("99.99.9999", { placeholder: "." });

    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#tabsbilgi").tabs({ activate: function(event, ui) {
        var op = getQuerystring("op");
        if ((op == "yenikayit") && ui.newTab.index() == 1) {
            var txt = "Öncelikle Kaydet ve İleri -> etiketli düğmeyle kayıt yapınız.";
            $("#Button1").hide();
            showdialogbox("HATA", txt);

        }
    }
    });


});   //document ready


//sirketin kayıt numarasını bulmaya yarayan fonksiyon
function kayitnobul(sirketpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/kayitnobul",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sirketpkey:"' + sirketpkey + '"}',
        async: false,
        success: function(result) {
            $("#TextBox2").val(result.d);
        },
        error: function() {
            alert('Şirketin baz fiyat tarifesi kayıt numarasını bulmaya çalışırken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


