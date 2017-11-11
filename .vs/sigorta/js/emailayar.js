$(document).ready(function() {


    $("#m").addClass("active");
    $("#m3").addClass("active");



    //NUMERIC LER -----------------------------------------------
    $('#Textbox2').keypress(function(event) {
        numericyap(event, "#Textbox2");
    });
    //-----------------------------------------------------------

    //$('#aratext').focus();
    $('.accordion').accordion({ autoHeight: false });

    // ARAMA DÜĞMESİ
    $('#arabutton').click(function(event) {
        event.preventDefault();
        var kriter = document.getElementById('aratext').value;
        emailayargoster(kriter.replace("'", ""));
    });

    $('.button').button();


    //ARAMA TEXTBOX IN İÇİNE TUŞLARA BASTIĞINDA
    $('#aratext').bind('keypress', function(e) {
        if (!!$("input[id$='aratext']").val()) {
            var kriter = $("input[id$='aratext']").val();
            emailayargoster(kriter.replace("'", ""));
        }
    });


    // AUTO COMPLETE EXTENDER
    $('#aratext').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/emailayarara",
                data: "{ 'kriter': '" + request.term.replace("'", "") + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.hostname
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


function emailayargoster(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/emailayargoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter.replace("'", "") + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('E-Mail ayarlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            emailayargoster(kriter.replace("'", ""));
        }
    }

}