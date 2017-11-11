$(document).ready(function() {


    $('#kapatbutton').click(function() {
        parent.$.fancybox.close();
    })

});


function tekpolice_digerkisilertablo(FirmCode, ProductCode, AgencyCode,
PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType) {

    var veriler = { FirmCode: FirmCode, ProductCode: ProductCode, AgencyCode: AgencyCode,
        PolicyNumber: PolicyNumber, TecditNumber: TecditNumber, ZeylCode: ZeylCode, ZeylNo: ZeylNo,
        ProductType: ProductType
    };

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/tekpolice_digerkisilertablo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Labeldigerkisiler').html(result.d);
            return result.d;
        },
        error: function(request, status, error) {
            alert('Diğer kişileri gösterirken bir sorun oluştu.' + request.responseText);
        }
    });
}
