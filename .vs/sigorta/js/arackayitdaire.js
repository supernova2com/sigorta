$(document).ready(function() {

    $("#b").addClass("active");
    $("#b4").addClass("active");

    //NUMERIC LER -----------------------------------------------
    $('#TextBox2').keypress(function(event) {
        corenumericyap(event, "#TextBox2");
    });
    $('#TextBox5').keypress(function(event) {
        corenumericyap(event, "#TextBox5");
    });
    $('#TextBox6').keypress(function(event) {
        corenumericyap(event, "#TextBox6");
    });
    //-----------------------------------------------------------

    // PLAKAYA GÖRE ARAMA
    $('#arabutton1').click(function(event) {
        event.preventDefault();
        var PlakaNo = document.getElementById('aratext1').value;
        var l;
        l = PlakaNo.length;
        if (l > 2) {
            plakalistele(PlakaNo);
        }
        if (l <= 2) {
            showtoast("error", "HATA", "Plaka 2 karakterden fazla olmalıdır.");
        }
    });

    //plaka boşlukları temizle
    $("#aratext1").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            // I have tried setting those
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#aratext1").val(($("#aratext1").val()).toUpperCase().replace(" ", ""));
    });


    //plaka boşlukları temizle
    $("#TextBox1").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            // I have tried setting those
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#TextBox1").val(($("#TextBox1").val()).toUpperCase().replace(" ", ""));
    });


    //plaka boşlukları temizle
    $("#TextBox7").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            // I have tried setting those
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#TextBox7").val(($("#TextBox7").val()).toUpperCase().replace(" ", ""));
    });


    //PLAKA AUTO COMPLETE
    $('#aratext1').autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "yonetimanaservis.aspx/autocompletearackayitdaire",
                data: "{ 'PlakaNo': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function(data) { return data; },
                success: function(data) {
                    response($.map(data.d, function(item) {
                        return {
                            value: item.PlakaNo
                        }
                    }))
                },
                error: function() {
                    alert("Plakaya göre arama yaparken bir sorun oluştu");
                }
            });
        },
        minLength: 2
    });



});     // document.ready



function plakalistele(PlakaNo) {

    var veriler = { PlakaNo: PlakaNo };

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/arackayitdairelistele",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Plakaya göre arama yaparken bir sorun oluştu. Yeniden deneyin');
        }
    });
}