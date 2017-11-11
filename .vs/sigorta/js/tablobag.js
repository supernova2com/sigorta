$(document).ready(function() {

    $("#z").addClass("active");
    $("#z3").addClass("active");

    $('#DropDownList2').change(function() {
        var f = document.getElementById("DropDownList1");
        var tabload = f.options[f.selectedIndex].text;
        var kolonad = document.getElementById('DropDownList2').value;
        bul_vtablo("help1", tabload);
        bul_vkolon("help2", tabload, kolonad);
    });

    $('#DropDownList4').change(function() {
        var f = document.getElementById("DropDownList3");
        var tabload = f.options[f.selectedIndex].text;
        var kolonad = document.getElementById('DropDownList4').value;
        bul_vtablo("help3", tabload);
        bul_vkolon("help4", tabload, kolonad);
    });

});



//TABLO AÇIKLAMA BİLGİLERİ
function bul_vtablo(id, tabload) {

    var spanid = "#" + id;
    var span = $(spanid);

    var veriler = { tabload: tabload };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bul_vtablo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            span.html(result.d.aciklama);
        },
        error: function(request, status, error) {
            alert('Tablo açıklama bilgisini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}


//KOLON AÇIKLAMA BİLGİSİNİ BUL
function bul_vkolon(id, tabload, kolonad) {

    var spanid = "#" + id;
    var span = $(spanid);

    var veriler = { tabload: tabload, kolonad: kolonad };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bul_vkolon",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            span.html(result.d.kolonaciklama);
        },
        error: function(request, status, error) {
            alert('Tablo açıklama bilgisini gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}