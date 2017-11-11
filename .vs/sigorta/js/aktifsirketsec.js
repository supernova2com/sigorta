$(document).ready(function() {


var aktifsirketsecilmismi;

    window.setInterval(function(){
        
        if (aktifsirketsecilmismi!="Evet") {
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/aktifsirketsecilmismi",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(result) {
                aktifsirketsecilmismi=result.d;
                if (result.d=="Hayır") {
                    $('#portlet-config').modal('show');  
                    showtoast('warning', 'Uyarı', 'Lütfen aktif şirketi seçiniz.');
                }
                },
                error: function(request, status, error) {
                    alert('Aktif şirketi bulmaya çalışırken bir sorun oluştu:' + request.responseText);
                }
            });
        }
    }, 3000);
   
    $('#aktifsirketkaydetbutton').click(function() {
         var aktifsirketpkey = document.getElementById("aktifsirketdrop").value;
         if (aktifsirketpkey!="0") {
             aktifsirketkaydet(aktifsirketpkey);
         }    
    });
    
   aktifsirketsecilmismifonksiyon = {     
       modeldialoggoster: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/aktifsirketsecilmismi",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function(result) {
                    callback.call(this,result);
                },            
            });
        }
    }

    // this code runs when the ajax call is complete...  
   aktifsirketsecilmismifonksiyon.modeldialoggoster(function(result) {      
        if (result.d=="Hayır") {
            showtoast('warning', 'Uyarı', 'Lütfen aktif şirketi seçiniz.');
            aktifsirketleridoldur();
            $('#portlet-config').modal('show');         
        }
         if (result.d=="Evet") {
            //aktifsirketleridoldur();
            //aktifsirketbul();
            //$('#portlet-config').modal('show');         
        }
    });
  
 });// document ready
 
 
 
 function aktifsirketleridoldur() {

    var aktifsirketdrop = $("#aktifsirketdrop");
    //hepsini boşalt
    $("#aktifsirketdrop> option").remove();

    aktifsirketdrop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aktifsirketleridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                aktifsirketdrop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].sirketad));
            }
        },
        error: function() {
            alert('İlgili acentenin çalıştığı şirketleri seçerken bir sorun oluştu.');
        }
    });
}


function aktifsirketkaydet(aktifsirketpkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aktifsirketkaydet",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{aktifsirketpkey:"' + aktifsirketpkey + '"}',
        success: function(result) {
        if (result.d.durum=="Kaydedildi") {
          $('#portlet-config').modal('hide');  
          }
        },
        error: function(request, status, error) {
            alert('Aktif şirketi kaydetmeye çalışırken bir sorun oluştu:' + request.responseText);
        }
    });
}



function aktifsirketbul() {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aktifsirketbul",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            //return result.d;
            $("#aktifsirketdrop").val(result.d);
        },
        error: function(request, status, error) {
            alert('Aktif şirketi bulmaya çalışırken bir sorun oluştu:' + request.responseText);
        }
    });
}


function aktifsirketsecilmismi() {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/aktifsirketsecilmismi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
        if (result.d=="Hayır") {
            $('#portlet-config').modal('show');  
            showtoast('warning', 'Uyarı', 'Lütfen aktif şirketi seçiniz.');
          }
        },
        error: function(request, status, error) {
            alert('Aktif şirketi bulmaya çalışırken bir sorun oluştu:' + request.responseText);
        }
    });
}
