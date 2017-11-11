$(document).ready(function() {

    //DİNAMİK RAPOR TANIMLANIRKEN TANIMLANMIŞ GRAFİĞİ GÖSTERMEK İÇİN
    dinamikraporgrafikgoster();

}); //document.ready



function dinamikraporgrafikgoster() {

    var raporpkey;
    raporpkey=getQuerystring("raporpkey");

  grafikbilgibul(raporpkey, function(result) {
    
    //EĞER GRAFİK YOK İSE GÖSTERME
    if (result.d[0] == undefined) {
        $("#gportlet").hide();
    }
     
    if (result.d[0] != undefined) {

          $("#grafikbaslik").html(result.d[0].grafikbaslik);
          $("#dinamikraporchart").height(result.d[0].yukseklik);
          $("#dinamikraporchart").width(result.d[0].genislik);
          
          var grafiktip;
          var labelgosterilsinmi,legendgosterilsinmi;
          var labelgosterilsinmi_bool,legendgosterilsinmi_bool;
          var labelseffaflik;
          var labelarkaplanrengi;
          
          grafiktip=result.d[0].grafiktip;
          labelseffaflik=result.d[0].labelseffaflik.toString()
          labelseffaflik=labelseffaflik.replace(",",".");
          labelarkaplanrengi="#"+result.d[0].labelarkaplanrengi;
    
          
          //--------------------------------------------------
          if (result.d[0].labelgosterilsinmi=="Evet"){
            labelgosterilsinmi_bool=true;
          }
          if (result.d[0].labelgosterilsinmi=="Hayır"){
            labelgosterilsinmi_bool=false;
          }
          
         //-------------------------------------------------- 
          if (result.d[0].legendgosterilsinmi=="Evet"){
            legendgosterilsinmi_bool=true;
          }
          if (result.d[0].legendgosterilsinmi=="Hayır"){
            legendgosterilsinmi_bool=false;
          }
          
          
          if (grafiktip=="pie") { 
          
                    DinamikRaporGrafikObject = {     
                    getArray: function(callback) {
                    var data = [];
                    $.ajax({
                        type: "POST",
                        url: "dinamikraporservis.aspx/grafikdata",
                        data: '{raporpkey:"' +raporpkey + '"}',
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
            DinamikRaporGrafikObject.getArray(function(data) {
            // this code runs when the ajax call is complete...
            $.plot($("#dinamikraporchart"), data, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                                label: {
                                        show: labelgosterilsinmi_bool,
                                        radius: 3 / 4,
                                        formatter: function (label, series) {
                                            return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                        },
                                        background: {
                                            opacity: labelseffaflik,
                                            color: labelarkaplanrengi
                                        }
                                    }
                            }
                    },
                    legend: {
                        show: legendgosterilsinmi_bool
                    }
                });   
            });
        
        } //pie ise 
        
        
        
         if (grafiktip=="line") { 
          
                    DinamikRaporGrafikObject = {     
                    getArray: function(callback) {
                    var data = [];
                    $.ajax({
                        type: "POST",
                        url: "dinamikraporservis.aspx/grafikdata",
                        data: '{raporpkey:"' +raporpkey + '"}',
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function(result) {
                                for (i=0; i<result.d.length; i++) {
                                    data.push([String(result.d[i].seriad),result.d[i].sayi]); 
                                } 
                                callback.call(this,data);    
                            },              
                        });
                    }
                }
                DinamikRaporGrafikObject.getArray(function(data) {
                // this code runs when the ajax call is complete...
                var plot_statistics = $.plot($("#dinamikraporchart"), 
                    [
                    {
                        data:data,
                        lines: {
                            fill: 0.6,
                            lineWidth: 0,
                        },
                        color: [labelarkaplanrengi]
                    },
                    {
                        data: data,
                        points: {
                            show: true,
                            fill: true,
                            radius: 5,
                            fillColor: "#f89f9f",
                            lineWidth: 3
                        },
                        color: '#fff',
                        shadowSize: 0
                    },
                    ], 
                    {             
                    xaxis: {
                        tickLength: 1,
                        tickDecimals: 0,                        
                        mode: "categories",
                        font: {
                            lineHeight: 14,
                            style: "normal",
                            variant: "small-caps",
                            color: "#6F7B8A"
                        }
                    },
                    yaxis: {
                        ticks: 1,
                        tickDecimals: 0,
                        tickColor: "#eee",
                        font: {
                            lineHeight: 14,
                            style: "normal",
                            variant: "small-caps",
                            color: "#6F7B8A"
                        }
                    },
                    grid: {
                        hoverable: true,
                        clickable: true,
                        tickColor: "#eee",
                        borderColor: "#eee",
                        borderWidth: 1
                    }
                });
            });       
            var previousPoint = null;
                $("#dinamikraporchart").bind("plothover", function (event, pos, item) {
                    $("#x").text(pos.x.toFixed(2));
                    $("#y").text(pos.y.toFixed(2));
                    if (item) {
                        if (previousPoint != item.dataIndex) {
                            previousPoint = item.dataIndex;

                            $("#tooltip").remove();
                            var x = item.datapoint[0].toFixed(2),
                                y = item.datapoint[1].toFixed(2);

                            showChartTooltip(item.pageX, item.pageY, item.datapoint[0], item.datapoint[1] + ' kayıt');
                        }
                    } else {
                        $("#tooltip").remove();
                        previousPoint = null;
                    }
            });
    
     
        } //line ise 
         
     } //pkey<>0 
          
   });  //grafikbilgibul callback  
   
 } //end of function
 
 
 
 
function showChartTooltip(x, y, xValue, yValue) {
                $('<div id="tooltip" class="chart-tooltip">'+yValue+'<\/div>').css({
                    position: 'absolute',
                    display: 'none',
                    top: y - 40,
                    left: x - 40,
                    border: '0px solid #ccc',
                    padding: '2px 6px',
                    'background-color': '#fff',
                }).appendTo("body").fadeIn(200);
            }


