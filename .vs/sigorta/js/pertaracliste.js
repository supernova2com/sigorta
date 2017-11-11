$(document).ready(function() {

    getfancy();
    
    $('#DropDownList1').change(function() {
        yap();
    });
    $('#DropDownList2').change(function() {
        yap();
    });
    $('#DropDownList3').change(function() {
        yap();
    });

});


function yap() {

    var pertaraclistesira = document.getElementById('DropDownList1').value;
    var teksayfadakacadet = document.getElementById('DropDownList2').value;
    var aracmarkapkey = document.getElementById('DropDownList3').value;
    listele(1, pertaraclistesira, teksayfadakacadet, aracmarkapkey);
}


function listele(sayfa, pertaraclistesira, teksayfadakacadet, aracmarkapkey) {

    var veriler = { sayfa: sayfa,pertaraclistesira: pertaraclistesira, teksayfadakacadet: teksayfadakacadet, 
    aracmarkapkey: aracmarkapkey };

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/listelepertaracsayfalama",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async:false,
        success: function(result) {
            $("#labelaracliste").html(result.d);
        },
        error: function(request, status, error) {
            alert('Pert araçları listelerken bir sorun oluştu:' + request.responseText);
        }
    });

    sayfalama(sayfa, pertaraclistesira, teksayfadakacadet, aracmarkapkey);

}


function sayfalama(sayfa, pertaraclistesira, teksayfadakacadet, aracmarkapkey) {

    var veriler = { sayfa: sayfa, pertaraclistesira: pertaraclistesira, teksayfadakacadet: teksayfadakacadet,
        aracmarkapkey: aracmarkapkey};

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/pertaracsayfalamayap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            $("#labelsayfalama").html(result.d);
        },
        error: function(request, status, error) {
            alert('Pert araçları sayfalarken bir sorun oluştu:' + request.responseText);
        }
    });

return false

}




