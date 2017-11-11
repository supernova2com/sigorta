var raporpkey;

$(document).ready(function() {


    //NUMERIC LER -----------------------------------------------
    $('#TextBox5').keypress(function(event) {
        corenumericyap(event, "#TextBox5");
    });
    $('#TextBox6').keypress(function(event) {
        corenumericyap(event, "#TextBox6");
    });
    $('#TextBox17').keypress(function(event) {
        corenumericyap(event, "#TextBox17");
    });
    $('#TextBox8').keypress(function(event) {
        corenumericyap(event, "#TextBox8");
    });
    $('#TextBox13').keypress(function(event) {
        corenumericyap(event, "#TextBox13");
    });


    //GRAFİKLER İÇİN 
    $('#TextBox21').keypress(function(event) {
        corenumericyap(event, "#TextBox21");
    });
    $('#TextBox22').keypress(function(event) {
        corenumericyap(event, "#TextBox22");
    });
    $('#TextBox19').keypress(function(event) {
        numericyap(event, "#TextBox19");
    });

    //-----------------------------------------------------------

    // COLOR PICKUP --------------------------------------- 
    $("#TextBox23").ColorPicker({
        onSubmit: function(hsb, hex, rgb, el) {
            $(el).val(hex);
            $(el).ColorPickerHide();
        },
        onBeforeShow: function() {
            $(this).ColorPickerSetColor(this.value);
        }
    })
    .bind('keyup', function() {
        $(this).ColorPickerSetColor(this.value);
    });


    $("#sortable").disableSelection();
    $("#sortablegrup").disableSelection();

    $("#Buttongrupsiralama").button();
    $("#siralamabutton").button();

    $('#siralamabutton').click(function() {
        var raporpkey = getQuerystring("pkey");
        if (raporpkey != "0") {
            showdialogbox2("Sıralama Seçenekleri", "");
            siralamagoster(raporpkey);
        }
    });

    $('#Buttongrupsiralama').click(function() {
        var raporpkey = getQuerystring("pkey");
        if (raporpkey != "0") {
            showdialogbox3("Sıralama Seçenekleri", "");
            grupfieldsiralamagoster(raporpkey);
        }
    });

    //alias larda boşlukları engelle
    $('#TextBox3').bind('keypress', function(e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 32) {
            e.preventDefault();
        }
    });
    $('#TextBox9').bind('keypress', function(e) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 32) {
            e.preventDefault();
        }
    });

    $('#DropDownList2').change(function() {
        var alanadi = document.getElementById('DropDownList2').value;
        $("#TextBox3").val(alanadi);
        $("#TextBox4").focus();

        var f = document.getElementById("DropDownList10");
        var tabload = f.options[f.selectedIndex].text;
        var kolonad = document.getElementById('DropDownList2').value;
        bul_vtablo("tabloaciklama2", tabload);
        bul_vkolon("kolonaciklama2", tabload, kolonad);

    });


    $('#DropDownList15').change(function() {
        var alanadi = document.getElementById('DropDownList15').value;
        $("#TextBox9").val("ss" + alanadi);
    });


    //kosul field de runtime evet ise 
    $('#DropDownList18').change(function() {
        var otogonder = document.getElementById('DropDownList18').value;
        if (otogonder == "Evet") {
            $("#DropDownList20").val("Evet");
            $("#DropDownList21").val("Evet");
            $("#DropDownList20").show();
            $("#DropDownList21").show();

        }
        if (otogonder == "Hayır") {
            $("#DropDownList20").val("Hayır");
            $("#DropDownList21").val("Hayır");
            $("#DropDownList20").hide();
            $("#DropDownList21").hide();
        }
    });


    //aggregate fonksiyon sistem yada manuel
    $('#DropDownList24').change(function() {
        var fonksiyontip = document.getElementById('DropDownList24').value;
        if (fonksiyontip == "Sistem") {
            $("#DropDownList16").show();
            $("#DropDownList16").focus();
            $("#TextBox15").val("");
            $("#TextBox15").hide();
        }
        if (fonksiyontip == "Manuel") {
            $("#DropDownList16").hide();
            $("#TextBox15").show();
            $("#TextBox15").focus();
        }
    });


    $('#DropDownList22').change(function() {
        var arabirimtip = document.getElementById('DropDownList22').value;
        if (arabirimtip != "0") {
            if (arabirimtip == "DropDownList") {
                $("#DropDownList23").show();
            }
            if (arabirimtip == "TextBox") {
                $("#DropDownList23").hide();
            }
        }
    });


    raporpkey = getQuerystring("pkey");

    //NUMERIC LER -----------------------------------------------
    $('#TextBox5').keypress(function(event) {
        numericyap(event, "#TextBox5");
    });
    $('#TextBox8').keypress(function(event) {
        numericyap(event, "#TextBox8");
    });
    $('#TextBox13').keypress(function(event) {
        numericyap(event, "#TextBox13");
    });
    $('#TextBox17').keypress(function(event) {
        numericyap(event, "#TextBox17");
    });
    //-----------------------------------------------------------

    $("#Buttonacenteekle").show();
    $("#Button4").show();

    //NUMERIC LER -----------------------------------------------
    $('#TextBox5').keypress(function(event) {
        numericyap(event, "#TextBox5");
    });
    //-----------------------------------------------------------

    $('.accordion').accordion({ autoHeight: false });
    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#tabsbilgi").tabs({ activate: function(event, ui) {
        var op = getQuerystring("op");

        if ((op == "yenikayit") && ui.newTab.index() == 1) {
            $("#Buttongosterilecekfieldekle").hide();
            var txt = "Yeni kayıt yaparken rapor tablosu ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi2icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 2) {
            $("#Buttongosterilecekfieldekle").hide();
            var txt = "Yeni kayıt yaparken gösterilecek rapor alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi3icerik").hide();

        }
        if ((op == "yenikayit") && ui.newTab.index() == 3) {
            $("#Buttonkosulfieldekle").hide();
            var txt = "Yeni kayıt yaparken koşul rapor alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi4icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 4) {
            $("#Buttonsiralamafieldekle").hide();
            var txt = "Yeni kayıt yaparken sıralama rapor alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi5icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 5) {
            $("#Buttongrupfieldekle").hide();
            var txt = "Yeni kayıt yaparken gruplama alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi6icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 6) {
            $("#Buttonaggfuncekle").hide();
            var txt = "Yeni kayıt yaparken grup rakam alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi7icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 7) {
            $("#Buttondinamikraporgrafikekle").hide();
            var txt = "Yeni kayıt yaparken grafik ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi8icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 8) {
            $("#Buttondinamikraporzamanlamaekle").hide();
            var txt = "Yeni kayıt yaparken zamanlama alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi9icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 9) {
            $("#Buttondinamikkullanicibagekle").hide();
            var txt = "Yeni kayıt yaparken erişim alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi10icerik").hide();
        }

        if ((op == "yenikayit") && ui.newTab.index() == 10) {
            $("#Buttondinamikjavascriptekle").hide();
            var txt = "Yeni kayıt yaparken Sınırlandırma alanları ekleyemezsiniz.";
            showdialogbox("HATA", txt);
            $("#tabsbilgi11icerik").hide();
        }

    }
    });


    //TABLO SEÇTİĞİNDE TABLO AÇIKLAMASINI GÖSTER
    $('#DropDownList9').change(function() {
        var tabload = document.getElementById('DropDownList9').value;
        bul_vtablo("tabloaciklama1", tabload);
    });
    $('#DropDownList3').change(function() {
        var f = document.getElementById("DropDownList11");
        var tabload = f.options[f.selectedIndex].text;
        var kolonad = document.getElementById('DropDownList3').value;
        bul_vtablo("tabloaciklama4", tabload);
        bul_vkolon("kolonaciklama4", tabload, kolonad);
    });
    $('#DropDownList7').change(function() {
        var f = document.getElementById("DropDownList12");
        var tabload = f.options[f.selectedIndex].text;
        var kolonad = document.getElementById('DropDownList7').value;
        bul_vtablo("tabloaciklama5", tabload);
        bul_vkolon("kolonaciklama5", tabload, kolonad);
    });
    $('#DropDownList15').change(function() {
        var f = document.getElementById("DropDownList14");
        var tabload = f.options[f.selectedIndex].text;
        var kolonad = document.getElementById('DropDownList15').value;
        bul_vtablo("tabloaciklama7", tabload);
        bul_vkolon("kolonaciklama7", tabload, kolonad);
    });








});         //document.ready


//SİLEMELER
//kullanilacak tablo sil
function kullanilacaktablosil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/kullanilacaktablosil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            $("#Labeldurumkullanilacaktablo").html(result.d.hatastr);
            kullanilacaktablogoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili tabloyu silerken bir sorun oluştu.' + request.responseText);
        }
    });

}



//kullanici bag sil
function dinamikkullanicibagsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikkullanicibagsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            $("#Labeldurumkullanilacaktablo").html(result.d.hatastr);
            kullanilacaktablogoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili tabloyu silerken bir sorun oluştu.' + request.responseText);
        }
    });

}



//gosterilecek field sil
function gosterilecekfieldsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/gosterilecekfieldsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
                gosterilecekfieldgoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}


//kosul field sil
function kosulfieldsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/kosulfieldsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            kosulfieldgoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}

//siralama field sil
function siralamafieldsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/siralamafieldsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            siralamafieldgoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}

//grup field sil
function grupfieldsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/grupfieldsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
            grupfieldgoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}

//aggfunc sil
function aggfuncsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/aggfuncsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            if (result.d.durum == "Kayıt yapılamadı.") {
                showdialogbox("HATA", result.d.hatastr);
            }
                aggfuncgoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });
}


//dinamikraporgrafik sil
function dinamikraporgrafiksil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikraporgrafiksil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler), 
        async: false,
        success: function(result) {
            dinamikraporgrafikgoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili grafiği silerken sorun oluştu.' + request.responseText);
        }
    });
}


//dinamikkullanicibag sil
function dinamikkullanicibagsil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikkullanicibagsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        async: false,
        success: function(result) {
            dinamikkullanicibaggoster(raporpkey);
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}

//dinamikraporzamanlama sil
function dinamikraporzamanlamasil(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikraporzamanlamasil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        async: false,
        success: function(result) {
            if (result.d.durum == "Kaydedildi") {
                dinamikraporzamanlamagoster(raporpkey);
            }
            if (result.d.durum != "Kaydedildi") {
                $("#Labeldinamikraporzamanlamadurum").html(result.d.hatastr);
            }
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}


//dinamikraporjavascript sil
function dinamikraporjavascriptsil(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikraporjavascriptsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            if (result.d.durum == "Kaydedildi") {
                dinamikraporjavascriptgoster(raporpkey);
            }
            if (result.d.durum != "Kaydedildi") {
                $("#Labeldinamikraporjavascriptdurum").html(result.d.hatastr);
            }
        },
        error: function(request, status, error) {
            alert('İlgili alanı silerken bir sorun oluştu.' + request.responseText);
        }
    });

}


// GÖSTERMELER ------------------------------------------------------------
//kullanilacakfield gösterir.
function kullanilacaktablogoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/kullanilacaktablogoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelkullanilacaktablo').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}
//gosterilecekfield gösterir.
function gosterilecekfieldgoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/gosterilecekfieldgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelgosterilecekfield').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}
//kosullarfield gösterir.
function kosulfieldgoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/kosulfieldgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelkosulfield').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}
//siralamafield gösterir.
function siralamafieldgoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/siralamafieldgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelsiralamafield').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
        alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}
//grupfield gösterir.
function grupfieldgoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/grupfieldgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelgrupfield').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}
//aggfunc gösterir.
function aggfuncgoster(raporpkey) {
    
    var veriler = { raporpkey: raporpkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/aggfuncgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelaggfunc').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}

//grafik gösterir.
function dinamikraporgrafikgoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikraporgrafikgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labelgrafik').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Grafikleri gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}

//dinamikkullanicibag gösterir.
function dinamikkullanicibaggoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikkullanicibaggoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labeldinamikkullanicibag').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Kullanıcılar gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}
//dinamikraporzamanlama gösterir.
function dinamikraporzamanlamagoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikraporzamanlamagoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        success: function(result) {
            $('#Labeldinamikraporzamanlama').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Kullanıcılar gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//dinamikraporjavascript gösterir.
function dinamikraporjavascriptgoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/dinamikraporjavascriptgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Labeldinamikraporjavascript').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('İlgili alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}



//AJAX SIRALAMA İÇİN
function siralamagoster(raporpkey) {

    var veriler = { raporpkey: raporpkey};
        
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/siralamagoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),       
        async:false,
        success: function(result) {
            $('#Labelsiralamagosterilecekfield').html(result.d);         
        },
        error: function(request, status, error) {
            alert('Gösterilecek alanları gösterirken bir sorun oluştu. Yeniden deneyin'+ request.responseText);
        }
    });
}


//AJAX SIRALAMA İÇİN
function grupfieldsiralamagoster(raporpkey) {

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/grupfieldsiralamagoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),  
        async: false,
        success: function(result) {
            $('#Labelgrupfieldsiralama').html(result.d);
        },
        error: function(request, status, error) {
            alert('Grup alanları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//TABLO AÇIKLAMA BİLGİLERİ
function bul_vtablo(id, tabload) {

    var spanid = "#" + id;
    var span = $(spanid);
    
    var veriler = { tabload: tabload };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bul_vtablo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            span.html(result.d.aciklama);
        },
        error: function(request, status, error) {
            alert('Tablo açıklama bilgisini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//KOLON AÇIKLAMA BİLGİSİNİ BUL
function bul_vkolon(id, tabload, kolonad) {

    var spanid = "#" + id;
    var span = $(spanid);

    var veriler = { tabload: tabload, kolonad:kolonad };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bul_vkolon",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            span.html(result.d.kolonaciklama);
        },
        error: function(request, status, error) {
            alert('Tablo açıklama bilgisini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}








