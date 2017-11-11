var scriptload;

//DİNAMİK RAPOR İÇİN GEREKLİ OLAN CORE FONKSİYONLAR
function arabirimolustur(arabirimholderid, raporpkey) {

    var veriler = { raporpkey: raporpkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/arabirimolustur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: $.toJSON(veriler),
        success: function(result) {
            $(arabirimholderid).html(result.d);
        },
        error: function(request, status, error) {
            alert('Dinamik rapor için arabirim oluşturamıyorum:' + request.responseText);
        }
    });
}


function arabirimbaslikolustur(arabirimraporadid, arabirimraporaciklamaid, raporpkey) {
 
    var veriler = { raporpkey: raporpkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bultek",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: $.toJSON(veriler),
        success: function(result) {
            $(arabirimraporadid).html(result.d.raporad);
            $(arabirimraporaciklamaid).html(result.d.aciklama);
        },
        error: function(request, status, error) {
            alert('Dinamik rapor için başlık oluşturamıyorum:' + request.responseText);
        }
    });
}


function raporpkeykaydet(raporpkey) {

    var veriler = { raporpkey: raporpkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/raporpkeykaydet",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: $.toJSON(veriler),
        success: function(result) {
        },
        error: function(request, status, error) {
            alert('Rapor anahtarını kaydedemiyorum:' + request.responseText);
        }
    });
}


function calistir(raporpkey, portletid, arabirimholder,arabirimraporad,arabirimraporaciklama) {

    javascriptdosyayarartvegom(raporpkey);
    raporpkeykaydet(raporpkey); 
    var arabirimholderid = '#'+ arabirimholder;
    var arabirimraporadid ='#'+ arabirimraporad;
    var arabirimraporaciklamaid = '#' + arabirimraporaciklama;

    var veriler = { raporpkey: raporpkey };
    
    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bultek_rapor",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: $.toJSON(veriler),
        success: function(result) {
            if (result.d.arabirimolsunmu == "Evet") {
                arabirimbaslikolustur(arabirimraporadid, arabirimraporaciklamaid,raporpkey);
                arabirimolustur(arabirimholderid, raporpkey);
                $('#' + portletid).modal('show');
            }
            if (result.d.arabirimolsunmu == "Hayır") {
                var link;
                link = "dinamikraporgoster.aspx?raporpkey=" + raporpkey;
                window.location.href = link;
            }
        },
        error: function(request, status, error) {
            alert('Raporu çalıştıramıyorum:' + request.responseText);
        }
    });
}


function grafikbilgibul(raporpkey,callback) {

    var veriler = { raporpkey: raporpkey };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/bultek_grafikbilgi_raporpkeyden",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: $.toJSON(veriler),
        success: function(result) {
            if (typeof (callback) === 'function') {
                callback(result);
            }
        },
        error: function(request, status, error) {
            alert('Dinamik rapor grafik bilgilerini alamıyorum:' + request.responseText);
        }
    });
}


function javascriptdosyayarartvegom(raporpkey) {

  var veriler = { raporpkey: raporpkey };

  $.ajax({
      type: "POST",
      url: "dinamikraporservis.aspx/javascriptdosyayarartvegom",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      async: false,
      data: $.toJSON(veriler),
      success: function(result) {
          if (result.d.etkilenen == 1) {
              if (scriptload != 1) {
                  $.getScript(result.d.durum)
                    .done(function(script, textStatus) {
                        console.log(textStatus);
                        scriptload = 1;
                    })
                    .fail(function(jqxhr, settings, exception) {
                        alert("Sınırlandırma Javascript'i yükleyemedim.")
                    });
              }
          }
      },
      error: function(request, status, error) {
          alert('Dinamik rapor grafik bilgilerini alamıyorum:' + request.responseText);
      }
  });
}


function ikitariharasigunfark(tarih1, tarih2, callback) {

    var veriler = { tarih1: tarih1, tarih2: tarih2 };

    $.ajax({
        type: "POST",
        url: "dinamikraporservis.aspx/ikitariharasigunfark",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: $.toJSON(veriler),
        success: function(result) {
            if (typeof (callback) === 'function') {
                callback(result);
            }
        },
        error: function(request, status, error) {
            alert('İki tarih arasındaki gün farkını hesaplayamadım.:' + request.responseText);
        }
    });
}










