
$(document).ready(function() {

    $("#k").addClass("active");
    $("#k3").addClass("active");

});

function backservislogsil(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/backservislogsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            backservisloggoster();
        },
        error: function(request, status, error) {
            alert('İlgili logu silerken bir sorun oluştu.' + request.responseText);
        }
    });

}



function backservisloggoster() {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/backservisloggoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Back Servis loglarını gösterirken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}