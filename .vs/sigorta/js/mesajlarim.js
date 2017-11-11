$(document).ready(function() {

    $("#l").addClass("active");

    var url=document.URL;
    
    var varmi=url.indexOf("mesaj.aspx");
    if (varmi>0) { 
        $("#l1").addClass("active");
        $("#l2").removeClass("active");
        $("#l3").removeClass("active");
    }

    var varmi = url.indexOf("gelenmesaj.aspx");
    if (varmi > 0) {
        $("#l2").addClass("active");
        $("#l1").removeClass("active");
        $("#l3").removeClass("active");
    }

    var varmi = url.indexOf("gonderilenmesaj.aspx");
    if (varmi > 0) {
        $("#l3").addClass("active");
        $("#l1").removeClass("active");
        $("#l2").removeClass("active");
    }



    //KULLANICI GRUBU DEĞİŞTİĞİNDE
    $('#DropDownList1').change(function() {
        var kullanicigruppkey = document.getElementById('DropDownList1').value;
        if (kullanicigruppkey != "0") {
            doldurkullanicilar_grupagore("DropDownList2", kullanicigruppkey);
        }
    });


});                    //document.ready


//İLGİLİ GRUPTAKİ KULLANICILARI DOLDURUYORUZ.
function doldurkullanicilar_grupagore(id, kullanicigruppkey) {

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/doldurkullanicilar_grupagore_mesajicin",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kullanicigruppkey:"' + kullanicigruppkey + '"}',
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].adsoyad));
            }
        },
        error: function() {
            alert('İlgili kullanıcıları doldururken bir sorun oluştu.');
        }
    });
}


//MSG ALAN SİL
function msgalansil(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/msgalansil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gelenmesajlarimilistele();
            okunmamismsgsayisi();
            msgonizle();
        },
        error: function() {
            alert('Mesajı silerken bir sorun oluştu.');
        }
    });
}



//DOSYA GÖNDEREN SİL
function msggonderensil(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/msggonderensil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gonderdigimmesajlarimilistele();
        },
        error: function() {
            alert('Mesajı silerken bir sorun oluştu.');
        }
    });
}



//MSG OKUNDU YAP
function msgokunduyap(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/msgokunduyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gelenmesajlarimilistele();
            okunmamismsgsayisi();
            msgonizle();
        },
        error: function() {
            alert('Mesajı okundu olarak işaretlerken bir sorun oluştu.');
        }
    });
}


//DOSYA OKUNMADI YAP
function msgokunmadiyap(pkey) {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/msgokunmadiyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            gelenmesajlarimilistele();
            okunmamismsgsayisi();
            msgonizle();
        },
        error: function() {
            alert('Mesajı okunmadı olarak işaretlerken bir sorun oluştu.');
        }
    });
}



//GELEN MESAJLARIMI LİSTELE
function gelenmesajlarimilistele() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/gelenmesajlarimilistele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#Label1').html(result.d);
        },
        error: function() {
            alert('Gelen mesajlarımı listelerken bir sorun oluştu.');
        }
    });
}



//GÖNDERDİĞİM MESAJLARI LİSTELE
function gonderdigimmesajlarimilistele() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/gonderdigimmesajlarilistele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#Label1').html(result.d);
        },
        error: function() {
            alert('Gönderdiğim mesajları listelerken bir sorun oluştu.');
        }
    });
}



function okunmamismsgsayisi() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/okunmamismsgsayisi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#header1_Labelokunmamismesajsayisi').html(result.d);
            $('#header1_Labelokunmamismesajsayisi2').html(result.d);
            $('#header1_Labelokunmamismesajsayisi3').html(result.d);
        },
        error: function() {
            alert('Okunmamış mesaj sayılarını gösterirken  bir sorun oluştu.');
        }
    });
}


function msgonizle() {

    $.ajax({
        type: "POST",
        url: "msgservis.aspx/msgonizle",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            $('#header1_Labelmsgonizle').html(result.d);
        },
        error: function() {
            alert('Mesajları önizlerken bir sorun oluştu.');
        }
    });
}









