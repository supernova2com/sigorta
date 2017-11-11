
$(document).ready(function() {


    $("#resimonizlemedialog").dialog({ autoOpen: false });

    // ARAMA DÜĞMESİ
    $('#arabutton').click(function() {
        var kriter = document.getElementById('aratext').value;
        carouselresimgoster(kriter.replace("'", ""));
    });



    $('#Button2').click(function() {
        var pkey;
        var hata = 0;
        pkey = getParameterByName("pkey");
        //alert(pkey);
        if (pkey == 'undefined' || pkey == "") {
            hata = 1;
            alert("Alttan herhangi bir karosel resmi seçiniz");
        }
        if (hata == 0) {
            carouselresimonizlethumb(pkey);
            resimonizlemedialog_goster();
        }
    });



    $('.button').button();

    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            carouselresimgoster(kriter.replace("'", ""));
        }
    });


    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/carouselresimara",
                data: "{ 'kriter': '" + request.term.replace("'", "") + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.resimalt
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




function carouselresimonizlethumb(pkey) {
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/carouselresimonizlethumb",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' +pkey + '"}',
        success: function(result) {
            $('#onizle').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Karosel Resimleri gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            carouselresimgoster(kriter.replace("'", ""));
        }
    }

}


function resimonizlemedialog_goster() {
    // DİALOGU GOSTER -------------------------------------
    $('#resimonizlemedialog').dialog("destroy");
    $('#resimonizlemedialog').dialog('option', 'position', 'center');
    $('#resimonizlemedialog').dialog({
        resizable: false,
        title: 'Resim Önizleme',
        width: '800',
        modal: true,
        buttons:
			     {
			         "Kapat": function() {
			             $(this).dialog('close');
			         }
			     }
    });
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null) return "";
    else return decodeURIComponent(results[1].replace(/\+/g, " "));
}


