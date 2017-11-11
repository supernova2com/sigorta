$(document).ready(function() {

    $("#d").addClass("active");
    $("#d4").addClass("active");


    getfancy();

    // TARİFE KODUNA GÖRE
    $('#arabutton1').click(function() {
        var kriter = document.getElementById('aratext1').value;
        aractarifegoster1(kriter);
    });

    // TARİFE ADINA GÖRE
    $('#arabutton2').click(function() {
        var kriter = document.getElementById('aratext2').value;
        aractarifegoster2(kriter);
    });

    
    //TARİFE KODUNA GÖRE ARAMA
    $('#aratext1').bind('keypress', function(e) {
        if (!!$("input[id$='aratext1']").val()) {
            var kriter = $("input[id$='aratext1']").val();
            aractarifegoster1(kriter);
        }
    });

    //TARİFE ADINA GÖRE ARAMA
    $('#aratext2').bind('keypress', function(e) {
        if (!!$("input[id$='aratext2']").val()) {
            var kriter = $("input[id$='aratext2']").val();
            aractarifegoster2(kriter);
        }
    });
    
    
    //TARİFE KODUNA GÖRE
    $('#aratext1').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/aractarifeara1",
                data: "{ 'kriter': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.tarifekod
                        }
                    }))
                },
                error: function() {
                    alert("Tarife koduna göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });


    //TARİFE ADINA GÖRE
    $('#aratext2').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/aractarifeara2",
                data: "{ 'kriter': '" + request.term.replace("'", "") + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.tarifead
                        }
                    }))
                },
                error: function() {
                    alert("Tarife adına göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 1
    });

}); //document.ready

//tarife koduna göre göster
function aractarifegoster1(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aractarifegoster1",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Araç tarife kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}


//tarife adına göre göster
function aractarifegoster2(kriter) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aractarifegoster2",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{kriter:"' + kriter + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Araç tarife kayıtlarını gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}




//ARAMA TEXTBOX ENTER TUŞLARA BASTIĞINDA
function aramadaentertusu() {

    if (!!$("input[id$='aratext']").val()) {

        var code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            var kriter = $("input[id$='aratext']").val();
            aractarifegoster(kriter.replace("'", ""));
        }
    }

}

