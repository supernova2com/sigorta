$(document).ready(function() {

    $("#f").addClass("active");
    $("#f2").addClass("active");


    $('#TextBox2').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
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

});

