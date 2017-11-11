$(document).ready(function() {


    $('#bulbutton').click(function() {
        var sicilno = document.getElementById('Textbox1').value;
        var sirketpkey = document.getElementById('DropDownList5').value;
        
        if (sirketpkey !="0" && sicilno != "") {
            bulacente(sicilno, sirketpkey);}
            else {
            showtoast('error', 'Uyarı', 'Şirketi ve sicil numarasını giriniz.');
        }
    });


    //NUMERIC LER -----------------------------------------------
    $('#Textbox4').keypress(function(event) {
        corenumericyap(event, "#Textbox4");
    });
    //-----------------------------------------------------------
    //NUMERIC LER -----------------------------------------------
    $('#Textbox5').keypress(function(event) {
        corenumericyap(event, "#Textbox5");
    });
    //-----------------------------------------------------------
    //NUMERIC LER -----------------------------------------------
    $('#TextBox7').keypress(function(event) {
        corenumericyap(event, "#TextBox7");
    });
    //-----------------------------------------------------------
    //NUMERIC LER -----------------------------------------------
    $('#TextBox8').keypress(function(event) {
        corenumericyap(event, "#TextBox8");
    });
    //-----------------------------------------------------------

    $("#i").addClass("active");
    $("#i3").addClass("active");

});




function bulacente(sicilno,sirketpkey) {

    var veriler = {sicilno:sicilno, sirketpkey:sirketpkey};

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/bulacente",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.pkey == 0) {
                showtoast('warning', 'Uyarı', 'Böyle bir sicil numarasına sahip herhangi bir acente KKSBM tarafından tanımlanmamış.');
            }
            if (result.d.pkey > 0) {
                if (result.d.merkezmi == "Evet") {
                    showtoast('warning', 'Uyarı', 'Merkez acente tanımlayamazsınız.');
                }
            }
            if (result.d.pkey > 0 && result.d.merkezmi == "Hayır") {
                acenteoncedentanimlanmismi(result.d.pkey);
                showtoast('info', 'Bilgi', 'Acente bilgileri bulundu...');
                $("#Textbox2").val(result.d.acentead);
                $("#Textboxacentepkey").val(result.d.pkey);
                $("#Textbox3").val(result.d.yetkiadsoyad);
                $("#Textbox4").val(result.d.yetkikimlikno);
                $("#Textbox5").val(result.d.yetkiceptel);
                $("#TextBox6").val(result.d.yetkiemail);
                $("#TextBox7").val(result.d.tel);
                $("#TextBox8").val(result.d.fax);
                $("#Textbox3").focus();
            }
        },
        error: function(request, status, error) {
            alert('Acente bilgilerini bulmaya çalışırken bir sorun oluştu:' + request.responseText);
        }
    });
}



function aktifyapsirkettaraf(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aktifyapsirkettaraf",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Acente kaydını aktif yaparken bir sorun oluştu. Yeniden deneyin');
        }
    });

}


function pasifyapsirkettaraf(pkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/pasifyapsirkettaraf",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{pkey:"' + pkey + '"}',
        success: function(result) {
            $('#Label1').html(result.d);
            return result.d;
        },
        error: function() {
            alert('Acente kaydını pasif yaparken bir sorun oluştu. Yeniden deneyin');
        }
    });

}




function acenteoncedentanimlanmismi(acentepkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/acenteoncedentanimlanmismi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{acentepkey:"' + acentepkey + '"}',
        success: function(result) {
            //alert(result.d.length);
            if (result.d =="Evet") {
                showtoast('info', 'Bilgilendirme', 'Bu acente daha önce tanımlanmış.');
            }
        },
        error: function() {
            alert('Acentenin daha önceden tanımlanıp tanımlanmadığını bulamıyorum.');
        }
    });

}
    