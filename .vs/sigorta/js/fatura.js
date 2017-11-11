$(document).ready(function() {


    $('#tumunusecbutton').click(function(event) {   
            $(':checkbox').each(function() {
                this.checked = true;                        
            });
    });



    //NUMERIC LER -----------------------------------------------
    $('#TextBox6').keypress(function(event) {
        numericyap(event, "#TextBox6");
    });
    //-----------------------------------------------------------
    
    $("#pa").addClass("active");
    $("#pa1").addClass("active");
    $('.button').button();
    getfancy();

});


function faturalandir(sirketkod, faturano, policedegeri,ay,yil) {

    $("[role=button]").hide();

    var veriler = { sirketkod: sirketkod, faturano: faturano, 
    policedegeri: policedegeri, ay: ay, yil:yil};

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/faturalandir",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.durum == 'Kaydedildi') {
                showtoast('info', 'Bilgilendirme', 'Faturalandırma işlemi başarılı');
                listeleyeniden();
            }
            if (result.d.durum != 'Kaydedildi') {
                showtoast('error', 'Hata', result.d.hatastr);
                  $("[role=button]").show();
            }
        },
        error: function(request, status, error) {
            alert('Faturalandıramıyorum:' + request.responseText);
        }
    });
}


function listeleyeniden() {
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/listelefaturarapor",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Fatura raporunu tekrar listeleyemiyorum:' + request.responseText);
        }
    });
}


function faturasil(faturano) {


    if (confirm('Bu faturayı silmek istediğinden eminmisiniz?')) {

        $("[role=button]").hide();  
        var veriler = {faturano: faturano,};
        $.ajax({
            type: "POST",
            url: "yonetimanaservis.aspx/faturasil",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            data: $.toJSON(veriler),
            success: function(result) {
                if (result.d.durum == 'Kaydedildi') {
                    showtoast('info', 'Bilgilendirme', 'Fatura silme işlemi başarılı');
                    listeleyeniden();
                }
                if (result.d.durum != 'Kaydedildi') {
                    showtoast('error', 'Hata', result.d.hatastr);
                }
            },
            error: function(request, status, error) {
                alert('Faturayı silemiyorum:' + request.responseText);
            }
        });
    
  }
}


function faturagonder(faturano) {

    var gonderilenbilgi;
    var veriler = {faturano: faturano};

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/faturaemailgonder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.durum == 'Kaydedildi') {
                gonderilenbilgi='Fatura ilgili kullanıcılara e-posta yolu ile gönderildi.<br/>' +
                "Gönderilen Kullanıcılar:<br/>" +
                result.d.hatastr + 
                "Toplam gönderilen kullanıcı sayısı:"+result.d.etkilenen.toString();
                showtoast('info', 'Bilgilendirme', gonderilenbilgi);
                listeleyeniden();
            }
            if (result.d.durum != 'Kaydedildi') {
                showtoast('error', 'Hata', result.d.hatastr);
            }
        },
        error: function(request, status, error) {
            alert('E-Posta gonderemiyorum:' + request.responseText);
        }
    });
}



