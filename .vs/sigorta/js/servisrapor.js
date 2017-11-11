

function ozelraporlogsil(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/ozelraporlogsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            ozelraporloggoster();
        },
        error: function(request, status, error) {
            alert('İlgili raporu silerken bir sorun oluştu.' + request.responseText);
        }
    });

}



function ozelraporloggoster() {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/ozelraporloggoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Raporları gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}