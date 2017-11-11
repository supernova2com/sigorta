
$(document).ready(function() {


    $("#d").addClass("active");
    $("#d1").addClass("active");

    $('.accordion').accordion({ autoHeight: false });
    $('.button').button();

    getfancy();

    // YETKİLİ KİŞİ ADINA GÖRE ARA
    $('#arabutton1').click(function(event) {
        event.preventDefault();
        var kriter = document.getElementById('aratext1').value;
        sirketgoster1(kriter);
    });



    //YETKİLİ KİŞİ GÖRE
    $('#aratext1').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/sirketara1",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.yetkilikisiadsoyad
                        }
                    }))
                },
                error: function() {
                    alert("Yetkili kişi adına soyadına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


});   //document.ready

//tarife koduna göre göster
function sirketgoster1(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sirketgoster1",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Şirket kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext1']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext1']").val();
            sirketgoster1(kriter);
        }
    }

}

