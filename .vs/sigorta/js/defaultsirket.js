$(document).ready(function() {


    $("#a").addClass("start active");

    bazfiyatuyari();
  
    PoliceGrafikObject = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"zeylpolicedagilim_teksirket" + '"}',
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

    PoliceGrafikObject.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#pie_chart3"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: false,
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
    
    //---------------------------------------------------------------------------------------
    
     HasarGrafikObject = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"urunpolicedagilim_teksirket" + '"}',
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

    HasarGrafikObject.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#pie_chart4"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: false,
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
    

}); //document.ready




  function bazfiyatuyari() {
        $.ajax({
            type: "POST",
            url: "yonetimanaservis.aspx/bazfiyatuyari",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true ,
            success: function(result) {
            if (result.d.durum=="Kaydedilmemiş") {
                    //shownotifc("Baz Fiyatlar","<a href='sirketbazfiyat.aspx'>"+result.d.hatastr+"</a>");
                }
            },
            error: function(request, status, error) {
                alert('Baz fiyat uyarısını oluştururken bir sorun oluştu :' + request.responseText);
            }
        });
    }



