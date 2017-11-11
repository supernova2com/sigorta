$(document).ready(function() {

    $("#n").addClass("active");

    var url=document.URL;
    
    var varmi=url.indexOf("dosya.aspx");
    if (varmi>0) { 
        $("#n1").addClass("active");
        $("#n2").removeClass("active");
        $("#n3").removeClass("active");
    }

    var varmi = url.indexOf("gelendosya.aspx");
    if (varmi > 0) {
        $("#n2").addClass("active");
        $("#n1").removeClass("active");
        $("#n3").removeClass("active");
    }

    var varmi = url.indexOf("gonderilendosya.aspx");
    if (varmi > 0) {
        $("#n3").addClass("active");
        $("#n1").removeClass("active");
        $("#n2").removeClass("active");
    }


}); //document.ready


//DOSYA ALAN SİL
function dosyaalansil(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/dosyaalansil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gelendosyalarimlistele();
            okunmamisdosyasayisi();
            dosyaonizle();
        },
        error: function() {
            alert('Dosyayı silerken bir sorun oluştu.');
        }
    });
}



//DOSYA GÖNDEREN SİL
function dosyagonderensil(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/dosyagonderensil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gonderdigimdosyalarimlistele();
        },
        error: function() {
            alert('Dosyayı silerken bir sorun oluştu.');
        }
    });
}



//DOSYA OKUNDU YAP
function dosyaokunduyap(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/dosyaokunduyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gelendosyalarimlistele();
            okunmamisdosyasayisi();
            dosyaonizle();
        },
        error: function() {
            alert('Dosyayı okundu olarak işaretlerken bir sorun oluştu.');
        }
    });
}


//DOSYA OKUNMADI YAP
function dosyaokunmadiyap(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/dosyaokunmadiyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gelendosyalarimlistele();
            okunmamisdosyasayisi();
            dosyaonizle();
        },
        error: function() {
            alert('Dosyayı okunmadı olarak işaretlerken bir sorun oluştu.');
        }
    });
}



//GELEN DOSYALARIMI LİSTELE
function gelendosyalarimlistele() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/gelendosyalarimlistele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#Label1').html(result.d);
        },
        error: function() {
            alert('Gelen dosyalarınızı listelerken bir sorun oluştu.');
        }
    });
}



//GÖNDERDİĞİM DOSYALARIMI LİSTELE
function gonderdigimdosyalarimlistele() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/gonderdigimdosyalarimlistele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#Label1').html(result.d);
        },
        error: function() {
            alert('Gönderdiğim dosyalarınızı listelerken bir sorun oluştu.');
        }
    });
}


function okunmamisdosyasayisi() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/okunmamisdosyasayisi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#header1_Labelokunmamisdosyasayisi').html(result.d);
            $('#header1_Labelokunmamisdosyasayisi2').html(result.d);
            $('#header1_Labelokunmamisdosyasayisi3').html(result.d);
        },
        error: function() {
            alert('Okunmamış dosya sayılarını gösterirken  bir sorun oluştu.');
        }
    });
}


function dosyaonizle() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/dosyaonizle",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#header1_Labeldosyaonizle').html(result.d);
        },
        error: function() {
            alert('Dosyaları önizlerken bir sorun oluştu.');
        }
    });
}


