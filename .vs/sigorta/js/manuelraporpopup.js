var manuelraporpkey;

$(document).ready(function() {

    manuelraporpkey = getQuerystring("pkey");
    var op = getQuerystring("op");

    if (op == "yenikayit") {
        $("#TextBox1").focus();
    }

    $('.accordion').accordion({ autoHeight: false });
    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#tabsbilgi").tabs({ activate: function(event, ui) {
        var op = getQuerystring("op");

        if ((op == "yenikayit") && ui.newTab.index() == 1) {
            $("#Buttonmanuelraporparametreekle").hide();
            var txt = "Yeni kayıt yaparken gösterilecek rapor alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi2icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 2) {
            $("#Buttonmanuelraporkullanicikaydet").hide();
            var txt = "Yeni kayıt yaparken gösterilecek rapor alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi3icerik").hide();

        }
    }
    });

});



function manuelraporkullanicisil(pkey) {

    $.ajax({
        type: "POST",
        url: "manuelraporservis.aspx/manuelraporkullanicisil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            $("#Labeldurummanuelraporkullanici").html(result.d.hatastr);
            manuelraporkullanicigoster(manuelraporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili kullanıcıyı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}


function manuelraporparametresil(pkey) {

    $.ajax({
        type: "POST",
        url: "manuelraporservis.aspx/manuelraporparametresil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            $("#Labeldurummanuelraporparametre").html(result.d.hatastr);
            manuelraporparametregoster(manuelraporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili parametreyi silerken bir sorun oluştu.' + request.responseText);
        }
    });

}



// GÖSTERMELER ------------------------------------------------------------
//parametre göster

function manuelraporparametregoster(manuelraporpkey) {

    $.ajax({
        type: "POST",
        url: "manuelraporservis.aspx/manuelraporparametregoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{manuelraporpkey:"' + manuelraporpkey + '"}',
        success: function(result) {
            $('#Labelmanuelraporparametre').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Parametreleri gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


function manuelraporkullanicigoster(manuelraporpkey) {

    $.ajax({
        type: "POST",
        url: "manuelraporservis.aspx/manuelraporkullanicigoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{manuelraporpkey:"' + manuelraporpkey + '"}',
        success: function(result) {
            $('#Labelmanuelraporkullanici').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Kullanıcıları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}