var g_kullanicipkey;

$(document).ready(function() {

    //c diskini göster
    ggosterim("C:");
    diskbilgi("C:");

    $("#m").addClass("active");
    $("#m2").addClass("active");

    //NUMERIC LER -----------------------------------------------
    $('#TextBox7').keypress(function(event) {
        numericyap(event, "#TextBox7");
    });
    $('#TextBox8').keypress(function(event) {
        numericyap(event, "#TextBox8");
    });
    $('#TextBox9').keypress(function(event) {
        numericyap(event, "#TextBox9");
    });
    $('#TextBox17').keypress(function(event) {
        numericyap(event, "#TextBox17");
    });
    $('#TextBox18').keypress(function(event) {
        corenumericyap(event, "#TextBox18");
    });
    //-----------------------------------------------------------

    $('.accordion').accordion({ autoHeight: false });
    $('.button').button();

    $('#TextBox2').mask("99.99.9999", { placeholder: "." });


    //VERİTABANI ADI DEĞİŞTİĞİNDE TABLOLARI DOLDUR
    $('#DropDownList2').change(function() {
        var veritabaniad = document.getElementById('DropDownList2').value;
        if (veritabaniad != "0") {
            veritabanitablodoldur("DropDownList3", veritabaniad);
        }
    });


    //DİSK DROPDOWN DEĞİŞTİĞİNDE
    $('#DropDownList4').change(function() {
        var surucu=document.getElementById('DropDownList4').value;
         ggosterim(surucu);
         diskbilgi(surucu);
    });
    
     
    //BAĞLANTIYI KES DÜĞMESİNE BASILDIĞINDA
    $('#modelbutton').click(function(e) {
        
          e.preventDefault();
          var kacdakika = document.getElementById('DropDownListKacDakika').value;     
           
          var veriler = {kacdakika: kacdakika, kullanicipkey: g_kullanicipkey};
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/baglantikesyap",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: $.toJSON(veriler),
                success: function(result) {
                    $("#portlet-config").modal('hide');
                    listeleonline(); 
                    listelekesilmis();  
                },
                error: function(request, status, error) {
                    alert('Kullanıcının bağlantısını keserken bir sorun oluştu:' + request.responseText);
                }           
             }); 
                
    }); //click
    
    

});  //document.ready



//DOLDUR VERİTABANIN TABLOLARINI
function veritabanitablodoldur(id, veritabaniad) {

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/veritabanitablodoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{veritabaniad:"' + veritabaniad + '"}',
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].ilgiliad).html(result.d[i].ilgiliad));
            }
        },
        error: function(request, status, error) {
            alert('İlgili tabloları doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}



function ggosterim(surucu) { 

  //DİSK ALANI GRAFİK GÖSTERİM
        diskObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "coreservis.aspx/diskgrafikdata",
                data: '{surucu:"' + surucu + '"}',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function(result) {
                    for (i=0; i<result.d.length; i++) {
                         data[i] = {
                            label: result.d[i].seriad,
                            data: result.d[i].sayi
                         }
                    }
                    callback.call(this,data);
                },            
            });
        }
    }
    diskObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#pie_chart"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                },
                                background: {
                                    opacity: 0.5,
                                    color: '#000'
                                }
                            }
                    }
            },
            legend: {
                show: true
            }
        });   
    });
    
  }
  
  
  function diskbilgi(surucu) {
    var veriler = {surucu: surucu};
    $.ajax({
        type: "POST",
        url: "coreservis.aspx/diskbilgi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
             $('#diskbilgilabel').html(result.d);
        },
        error: function(request, status, error) {
            alert('Disk bilgilerini alırken bir sorun oluştu:' + request.responseText);
        }
    });
}



  function listeleonline() {
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/listeleonline",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
             $('#labelonlinekullanici').html(result.d);
        },
        error: function(request, status, error) {
            alert('Online kullanıcıları gösterirken bir sorun oluştu:' + request.responseText);
        }
    });
 }
 
 
   function listelekesilmis() {
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/listelekesilmis",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
             $('#labelkesilmiskullanici').html(result.d);
        },
        error: function(request, status, error) {
            alert('Bağlantısı kesilmiş kullanıcıları gösterirken bir sorun oluştu:' + request.responseText);
        }
    });
 }
 
 
 
 

  function baglantikessil(pkey) {
  
    var veriler = {pkey: pkey };
    
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/baglantikessil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
              listeleonline(); 
              listelekesilmis();  
        },
        error: function(request, status, error) {
            alert('Bağlantıyı açarken bir sorun oluştu:' + request.responseText);
        }
    });
 }


function baglantikes(kullanicipkey) {
    $("#portlet-config").modal('show');
    g_kullanicipkey=kullanicipkey;
}







