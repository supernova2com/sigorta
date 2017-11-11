$(document).ready(function() {

    $("#c").addClass("active");
    $("#c1").addClass("active");

    $('#TextBox7').mask("99.99.9999", { placeholder: "." });
    $('#TextBox8').mask("99.99.9999", { placeholder: "." });

    $.datepicker.setDefaults($.datepicker.regional['tr']);
    $('#TextBox7').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox8').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
 

    // ARAMA DÜĞMESİ
    $('#arabutton').click(function(event) {
        var kriter = document.getElementById('aratext').value;
        webuyegoster(kriter);
    });

    $('.button').button();


    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            webuyegoster(kriter);
        }
    });


    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "bilgiservis.aspx/webuyeara",
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


function webuyegoster(kriter) {

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/webuyegoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter.replace("'", "") + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Web üyelerini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {
    if (!!$("input[id$='aratext']").val()) {
        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            webuyegoster(kriter);
        }
    }
}


function uyeaktifyap(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/uyeaktifyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            showtoast('info', 'Bilgi', 'Üye aktif hale getirildi.');
            webuyegoster("");
            return result.d;
        },
        error: function(request, status, error) {
            alert('Üye kaydını pasif yaparken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });

}


function uyepasifyap(pkey) {

    var veriler = { pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/uyepasifyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            showtoast('info', 'Bilgi', 'Üye pasif hale getirildi.');
            webuyegoster("");
            return result.d;
        },
        error: function(request, status, error) {
            alert('Üye kaydını pasif yaparken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });

}

