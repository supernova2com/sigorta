$(document).ready(function() {


    $("#h").addClass("active");
    $("#h2").addClass("active");
    
    $(".accordion").accordion({ autoHeight: false });

    // ARAMA DÜĞMESİ
    $('#arabutton').click(function() {
        var kriter = document.getElementById('aratext').value;
        tekresimgoster(kriter);
    });


    $('.button').button();

    getfancy();

    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            tekresimgoster(kriter);
        }
    });

    //GALERİ ADINA GÖRE ARA
    $('#arabutton2').click(function() {
        var galeripkey = document.getElementById('DropDownList5').value;
        tekresimgoster_galeriyegore(galeripkey);
    });


    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/tekresimara",
                data: "{ 'kriter': '" + request.term.replace("'", "") + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.baslik
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


function tekresimgoster(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/tekresimgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter.replace("'", "") + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Resimleri gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}

function tekresimgoster_galeriyegore(galeripkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/tekresimgoster_galeriyegore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{galeripkey:"' + galeripkey + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Galeriye göre resim ararken bir sorun oluştu. Yeniden deneyin');
        }
    });
}



//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            tekresimgoster(kriter.replace("'", ""));
        }
    }
}
    
    
    
