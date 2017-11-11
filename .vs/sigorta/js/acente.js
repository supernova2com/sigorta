
$(document).ready(function() {

    $("#d").addClass("active");
    $("#d2").addClass("active");

    $('.accordion').accordion({ autoHeight: false });
    $('.button').button();

    getfancy();



    // ACENTE YETKİLİ KİŞİ ADINA GÖRE ARA
    $('#arabutton1').click(function(event) {
        event.preventDefault();
        var kriter = document.getElementById('aratext1').value;
        acentegoster1(kriter);
    });
    $('#aratext1').keypress(function(e) {
        if (e.keyCode == 13) {
            var kriter = document.getElementById('aratext1').value;
            acentegoster1(kriter);
        }
    });

    // ACENTE SİCİL NUMARASINA GÖRE ARA
    $('#arabutton2').click(function(event) {
        event.preventDefault();
        var kriter = document.getElementById('aratext2').value;
        acentegoster2(kriter);
    });
    $('#aratext2').keypress(function(e) {
        if (e.keyCode == 13) {
            var kriter = document.getElementById('aratext2').value;
            acentegoster2(kriter);
        }
    });





    //YETKİLİ KİŞİ GÖRE
    $('#aratext1').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/acenteara1",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.acentead
                        }
                    }))
                },
                error: function() {
                    alert("Acente adına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


    //SİCİL NO GÖRE
    $('#aratext2').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/acenteara2",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.sicilno
                        }
                    }))
                },
                error: function() {
                    alert("Acente sicil numarasına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


});  //document.ready

//yetkili kişi ismine göre acenteler
function acentegoster1(kriter) {

    var veriler = { kriter: kriter };
    
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/acentegoster1",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Acente kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//sicil numarasına göre arama
function acentegoster2(kriter) {

    var veriler = { kriter: kriter };

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/acentegoster2",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Acente kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}




function aktifyap(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aktifyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            showtoast('info', 'Bilgi', 'Acente aktivasyonu başarılı.');
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Acente kaydını aktif yaparken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


function pasifyap(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/pasifyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            showtoast('info', 'Bilgi', 'Acente pasif hale getirildi.');
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Acente kaydını pasif yaparken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


function getfancy() {
    $(".iframeyenikayit").fancybox({
        'centerOnScroll': true,
        'width': '100%',
        'height': '100%',
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'type': 'iframe',
        'title': 'Bilgi',
        'autoDimensions': false,
        'fixed': false,
        'showCloseButton': true,
        'fitToView': false,
        'autoSize': false
    });

    $("#iframeyenikayit").fancybox({
        'centerOnScroll': true,
        'width': '100%',
        'height': '100%',
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'type': 'iframe',
        'title': 'Bilgi',
        'autoDimensions': false,
        'fixed': false,
        'showCloseButton': true,
        'fitToView': false,
        'autoSize': false
    });

}


