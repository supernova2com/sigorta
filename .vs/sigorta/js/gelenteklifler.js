$(document).ready(function() {
    $("#e").addClass("active");
    $("#e1").addClass("active");



});


function gelenteklifgoster() {

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/gelenteklifgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Gelen teklifleri gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}



function okunduyap(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/teklifokunduyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            showtoast('info', 'Bilgi', 'Teklif okundu olarak işaretlendi.');
            gelenteklifgoster();
            return result.d;
        },
        error: function(request, status, error) {
            alert('Teklifi okundu olarak işaretlerken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });

}


function okunmadiyap(pkey) {

    var veriler = { pkey: pkey };

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/teklifokunmadiyap",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            showtoast('info', 'Bilgi', 'Teklif okunmadı olarak işaretlendi.');
            gelenteklifgoster();
            return result.d;
        },
        error: function(request, status, error) {
            alert('Teklifi okunmadı olarak işaretlerken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });

}