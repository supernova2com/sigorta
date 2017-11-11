$(document).ready(function() {

    $(".button").button();

    $('#kapatbutton').click(function() {
        parent.$.fancybox.close();
    })

    $('.accordion').accordion({ autoHeight: false });

});


function damagecancelsil(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/damagecancelsil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            damagecancelgoster();
        },
        error: function(request, status, error) {
            alert('Hasar iptalini silerken bir sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}



function damagecancelgoster() {

    var FirmCode, ProductCode, AgencyCode;
    var PolicyNumber, TecditNumber, FileNo;
    var RequestNo,ProductType;

    FirmCode = getQuerystring("FirmCode");
    ProductCode = getQuerystring("ProductCode");
    AgencyCode = getQuerystring("AgencyCode");
    PolicyNumber = getQuerystring("PolicyNumber");
    TecditNumber = getQuerystring("TecditNumber");
    FileNo = getQuerystring("FileNo");
    RequestNo = getQuerystring("RequestNo");
    ProductType = getQuerystring("ProductType");
    

    var veriler = { FirmCode: FirmCode, ProductCode: ProductCode, AgencyCode: AgencyCode,
    PolicyNumber: PolicyNumber, TecditNumber: TecditNumber, FileNo: FileNo, RequestNo: RequestNo, 
    ProductType: ProductType};

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/damagecancelgoster",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Hasar iptalini gösterirken sorun oluştu. Yeniden deneyin' + request.responseText);
        }
    });
}