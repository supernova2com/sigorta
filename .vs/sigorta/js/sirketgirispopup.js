
$(document).ready(function() {


    $("#Buttonacenteekle").show();
    $("#Button4").show();
    
    //LOGO YU DEĞİŞTİRDİĞİNDE
    $("#DropDownList1").change(function() {
        var resimpkey;
        resimpkey = document.getElementById("DropDownList1").value;
        logoolustur(resimpkey);
    });


    //NUMERIC LER -----------------------------------------------
    $('#TextBox1').keypress(function(event) {
        numericyap(event, "#TextBox1");
    });
    $('#TextBox4').keypress(function(event) {
        numericyap(event, "#TextBox4");
    });
    $('#TextBox5').keypress(function(event) {
        numericyap(event, "#TextBox5");
    });
    $('#TextBox13').keypress(function(event) {
        corenumericyap(event, "#TextBox13");
    });
    //-----------------------------------------------------------

    $('.accordion').accordion({ heightStyle: "content" });
    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#tabsbilgi").tabs({ activate: function(event, ui) {
        var op = getQuerystring("op");
        if ((op == "yenikayit") && ui.newTab.index() == 2) {
            $("#Buttonacenteekle").hide();
            var txt = "Yeni kayıt yaparken şirkete acente ekleyemezsiniz.";
            showdialogbox("HATA", txt);

        }
        if ((op == "yenikayit") && ui.newTab.index() == 3) {
            $("#Button4").hide();
            var txt = "Yeni kayıt yaparken şirkete ip adresi ekleyemezsiniz.";
            showdialogbox("HATA", txt);
        }

        if ((op == "yenikayit") && ui.newTab.index() == 4) {
            $("#Button5").hide();
            var txt = "Yeni kayıt yaparken fatura e-posta adresi ekleyemezsiniz.";
            showdialogbox("HATA", txt);
        }
    }
    });




});      //document.ready


//sirketin altındaki acenteyi siler
function sirketacentebagsil(pkey) {

    var sirketpkey = getQuerystring("pkey");

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketacentebagsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            sirketacentebaggoster(sirketpkey);
            sirketcalisangoster(sirketpkey);
        },
        error: function() {
            alert('Şirketin ilgili acentesini silerken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


//şirketin altındaki acenteleri gösterir.
function sirketacentebaggoster(sirketpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketacentebaggoster_sirketegore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sirketpkey:"' + sirketpkey + '"}',
        success: function(result) {
            $('#Labelacenteleri').html(result.d);
            $('#Labelacenteresult').html("");
            return result.d;
        },
        error: function() {
            alert('Şirketin ilgili acente kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//sirketin bağlandığı ip adresini siler
function sirketipbagsil(pkey) {

    var sirketpkey = getQuerystring("pkey");

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketipbagsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            sirketipbaggoster(sirketpkey);
        },
        error: function() {
            alert('Şirketin bağlanabileceği ip adresini silerken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


//şirketin ip adreslerini gösterir.
function sirketipbaggoster(sirketpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketipbaggoster_sirketegore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sirketpkey:"' + sirketpkey + '"}',
        success: function(result) {
            $('#Labelipadresleri').html(result.d);
            $('#Labelipresult').html("");
            return result.d;
        },
        error: function() {
            alert('Şirketin ip adreslerini gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}




//sirketin fatura e-posta adresini siler
function sirketfaturabagsil(pkey) {

    var sirketpkey = getQuerystring("pkey");

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketfaturabagsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            sirketfaturabaggoster(sirketpkey);
        },
        error: function() {
            alert('Şirketin fatura gönderilecek e-posta adreslierini silerken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


//şirketin fatura gönderilecek e-posta adreslerini gösterir.
function sirketfaturabaggoster(sirketpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketfaturabaggoster_sirketegore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sirketpkey:"' + sirketpkey + '"}',
        success: function(result) {
            $('#Labelfaturaepostaadresleri').html(result.d);
            $('#Labelfaturaepostaresult').html("");
            return result.d;
        },
        error: function() {
            alert('Şirketin fatura gönderilecek e-posta adreslerini gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//şirketin çalışanlarını gösterir.
function sirketcalisangoster(sirketpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketcalisangoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sirketpkey:"' + sirketpkey + '"}',
        success: function(result) {
            $('#Labelpersoneli').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Şirketin ip adreslerini gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}



//resim değiştiğinde logo yu altta oluştur.
function logoolustur(resimpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/logoolustur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{resimpkey:"' + resimpkey + '"}',
        async: false,
        success: function(result) {
            $("#Labellogo").html(result.d);
        },
        error: function() {
            alert('Şirketin logosunu oluştururken bir sorun oluştu. Yeniden deneyin');
        }
    });

}

