
$(document).ready(function() {

    $("#d").addClass("active");
    $("#d3").addClass("active");
    
    $('.accordion').accordion({ autoHeight: false });
    $('.button').button();

    getfancy();

    // YETKİLİ KİŞİ ADINA GÖRE ARA
    $('#arabutton1').click(function() {
        var kriter = document.getElementById('aratext1').value;
        personelgoster1(kriter);
    });



    //PERSONEL AD SOYADINA GÖRE
    $('#TextBox1').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/personelara1",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.personeladsoyad
                        }
                    }))
                },
                error: function() {
                    alert("Personel adına soyadına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


    //KİMLİK NUMARASINA GÖRE
    $('#TextBox2').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/personelara2",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.kimlikno
                        }
                    }))
                },
                error: function() {
                    alert("Kimlik numarasına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


    //TP NUMARASINA GÖRE ARA
    $('#TextBox3').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/personelara3",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.tpno
                        }
                    }))
                },
                error: function() {
                    alert("tp numarasına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


}); //document.ready

//tarife koduna göre göster
function personelgoster1(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/personelgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Personel kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext1']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext1']").val();
            personelgoster1(kriter);
        }
    }

}


function onayla(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/onayla",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            if (result.d.durum == 'Kaydedildi') {
                showtoast('info', 'Bilgilendirme', 'Onaylama işlemi başarılı');
                //personelgoster1("");
            }
            if (result.d.durum != 'Kaydedildi') {
                showtoast('error', 'Hata', result.d.hatastr);
            }          
        },
        error: function() {
            alert('Personeli onaylarken bir sorun oluştu. Yeniden deneyin');
        }
    });
}

