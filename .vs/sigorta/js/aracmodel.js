$(document).ready(function() {

    $("#a").addClass("active");
    $("#a3").addClass("active");

    //ARAÇ CİNSİ DEĞİŞTİĞİNDE ARAÇ MARKALARI DOLDURUYORUZ
    $('#DropDownList1').change(function() {
        var araccinspkey = document.getElementById('DropDownList1').value;
        if (araccinspkey != "0") {
            doldurmarka("DropDownList2", araccinspkey);
        }
    });

});


//ARAÇ CİNSİ DEĞİŞTİĞİNDE ARAÇ MARKALARINI DOLDUR
function doldurmarka(id, araccinspkey) {

    var veriler = {araccinspkey: araccinspkey};
    
    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/dolduraracmarka_cinsegore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].markaad));
            }
        },
        error: function(request, status, error) {
            alert('İlgili markaları doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}






