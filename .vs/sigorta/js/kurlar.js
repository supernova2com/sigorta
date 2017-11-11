

$(document).ready(function() {


//$('#aratext').focus();

    $(".accordion").accordion();

    // ARAMA DÜĞMESİ
    $('#arabutton').click(function() {
        var kriter = document.getElementById('aratext').value;
        kurgoster(kriter.replace("'", ""));
    });

    $('.button').button();


    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            kurgoster(kriter.replace("'", ""));
        }
    });




    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/kurara",
                data: "{ 'kriter': '" + request.term.replace("'", "") + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.parabirim
                        }
                    }))
                },
                error: function() {
                    alert("Kur araması yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 2
    });

});


function kurgoster(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/kurgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter.replace("'", "") + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Kurları gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            kurgoster(kriter.replace("'", ""));
        }
    }

}
