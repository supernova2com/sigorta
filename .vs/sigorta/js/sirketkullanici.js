$(document).ready(function() {


    $("#i").addClass("active");
    $("#i1").addClass("active");


    //NUMERIC LER -----------------------------------------------
    $('#Textbox1').keypress(function(event) {
        corenumericyap(event, "#Textbox1");
    });
    //-----------------------------------------------------------

    //BUL DÜĞMESİNE BASTIĞINDA
    $('#bulbutton').click(function() {
        kontrol();
    });
    //TP NUMARASINDAN FOCUS OUT OLDUĞUNDA
    $('#Textbox2').focusout(function() {
        kontrol();
    });
    $('#Textbox2').keypress(function() {
        //kontrol();
    });


    //ŞİRKET DEĞİŞTİĞİNDE İLGİLİ ACENTELERİ DOLDUR
    $('#DropDownList5').change(function() {
        var sirketpkey = document.getElementById('DropDownList5').value;
        if (sirketpkey != "0") {
            doldursirketinacenteleri("DropDownList6", sirketpkey);
        }
    });


    //ACENTE DEĞİŞTİĞİNDE ROLLERİ DOLDUR
    $('#DropDownList6').change(function() {
        var sirketpkey = document.getElementById('DropDownList5').value;
        var acentepkey = document.getElementById('DropDownList6').value;
        
        if (sirketpkey != "0" && acentepkey != "0") {
            doldurrollersirketicin("DropDownList7", sirketpkey, acentepkey);
        }
    });


    // ARAMA DÜĞMESİ
    $('#arabutton').click(function(event) {
        var kriter = document.getElementById('aratext').value;
        kullanicigoster_sirkettarafinda(kriter);
    });

    $('.button').button();


    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            kullanicigoster_sirkettarafinda(kriter);
        }
    });


    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/kullaniciara_sirkettarafinda",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.adsoyad
                        }
                    }))
                },
                error: function() {
                    alert("Arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 2
    });

});


function kontrol() {

    var kimlikno = document.getElementById('Textbox1').value;
    var tpno = document.getElementById('Textbox2').value;
    if (kimlikno != "" && tpno != "") {
        kimliknovetpnokontrol(kimlikno, tpno);
    }
}

function kullanicigoster_sirkettarafinda(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/kullanicigoster_sirkettarafinda",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter.replace("'", "") + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Kullanıcıları gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            kullanicigoster_sirkettarafinda(kriter);
        }
    }

}

//DOLDUR ŞİRKETİN ACENTELERİ
function doldursirketinacenteleri(id, sirketpkey) {

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/doldursirketinacentelerionunekledigi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sirketpkey:"' + sirketpkey + '"}',
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].acentead));
            }
        },
        error: function() {
            alert('İlgili şirketin acentelerini doldururken bir sorun oluştu.');
        }
    });
}


//DOLDUR ROLLER
function doldurrollersirketicin(id, sirketpkey, acentepkey) {

    var veriler = {sirketpkey: sirketpkey, acentepkey: acentepkey};
    
    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/doldurrollersirketicin",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].rolad));
            }
        },
        error: function() {
            alert('İlgili rolleri doldururken bir sorun oluştu.');
        }
    });
}







function kimliknovetpnokontrol(kimlikno,tpno) {

    var veriler = {kimlikno: kimlikno, tpno: tpno};

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/kimliknovetpnokontrol",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.pkey > 0) {
                showtoast('info', 'Bilgi', 'Eşleşme sağlandı.');
                $('#Textbox3').val(result.d.personeladsoyad);
                $('#Textbox4').val(turkcelericikar(result.d.personeladsoyad));
            }
            if (result.d.pkey <= 0) {
                showtoast('error', 'Uyarı', 'Girdiğiniz kimlik numarası ve TP no ile eşleşen'+
                'bir personel Sigorta Bilgi Merkezi tarafından tanımlanmamış');
            }

        },
        error: function() {
            alert('Kimlik no ve tpno eşleştirirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


 function turkcelericikar(str) {
     var string;
     string = str;
     var letters = {"ı": "i", "ş": "s", "ğ": "g", "ü": "u", "ö": "o", "ç": "c", "Ç": "c", "İ": "i", "I": "i", "Ş": "s", "Ğ": "g", "Ü": "u", "Ö": "o", "Ç": "c" };
     string = string.replace(/(([ışğüöçİIŞĞÜÇÖ]))/g, function(letter) { return letters[letter]; })
     string = string.replace(" ", "");
     string = string.toLowerCase();
     string = string.trim();
     string = string.replace(/ /g, '');
     return string;
 }