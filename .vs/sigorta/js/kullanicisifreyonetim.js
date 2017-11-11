$(document).ready(function() {


    $("#i").addClass("active");
    $("#i4").addClass("active");

    //ŞİRKET DEĞİŞTİĞİNDE İLGİLİ ACENTELERİ DOLDUR
    $('#DropDownList5').change(function() {
        var sirketpkey = document.getElementById('DropDownList5').value;
        if (sirketpkey != "0") {
            doldursirketinacenteleri("DropDownList6", sirketpkey);
        }
    });

    //ACENTELER DEĞİŞTİĞİNDE İLGİLİ PERSONELLERİ DOLDUR
    $('#DropDownList6').change(function() {
        var sirketpkey = document.getElementById('DropDownList5').value;
        var acentepkey = document.getElementById('DropDownList6').value;
        if (sirketpkey != "0" && acentepkey != "0") {
            doldursirketinacentekullanicilari("DropDownList2", sirketpkey,acentepkey);
        }
    });


    // ARAMA DÜĞMESİ
    $('#arabutton').click(function(event) {
        var kriter = document.getElementById('aratext').value;
        kullanicigoster(kriter);
    });

    $('.button').button();


    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            kullanicigoster(kriter);
        }
    });


    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/kullaniciara",
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


function kullanicigoster(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/kullanicigoster",
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
            kullanicigoster(kriter);
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
        url: "yonetimanaservis.aspx/doldursirketinacenteleri",
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


//DOLDUR ŞİRKETİN VE ACENTENİN KULLANICILARI
function doldursirketinacentekullanicilari(id, sirketpkey, acentepkey) {


    var veriler = {sirketpkey: sirketpkey, acentepkey: acentepkey};
    
    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/doldursirketinacentelerinkullanicilari",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].adsoyad));
            }
        },
        error: function(request, status, error) {
            alert('İlgili acentenin kullanıcılarını doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}


