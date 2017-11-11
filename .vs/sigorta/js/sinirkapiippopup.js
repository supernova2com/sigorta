
$(document).ready(function() {


    $('.accordion').accordion({ heightStyle: "content" });
    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "active", parseInt(currTab));

    $("#TextBox11").focus();

});        //document.ready



//kullaniciun bağlandığı ip adresini siler
function sinirkapiipsil(pkey) {

    var sinirkapipkey = getQuerystring("pkey");

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sinirkapiipsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        async: false,
        success: function(result) {
            sinirkapiipgoster(sinirkapipkey);
        },
        error: function() {
            alert('Sınır kapısının ip adresini silerken bir sorun oluştu. Yeniden deneyin');
        }
    });

}

//şirketin ip adreslerini gösterir.
function sinirkapiipgoster(sinirkapipkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/sinirkapiipgoster_sinirkapigore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{sinirkapipkey:"' + sinirkapipkey + '"}',
        success: function(result) {
            $('#Labelipadresleri').html(result.d);
            $('#Labelipresult').html("");
            return result.d;
        },
        error: function() {
            alert('Sınır kapısının adreslerini gösterirken bir sorun oluştu. Yeniden deneyin');
        }
    });
}









