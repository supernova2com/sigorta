var raporpkey;

$(document).ready(function() {

    var yheight;
    var dheight;
    dheight=$("#pie_chart2").height();
    yheight=dheight+200;
    
    $("#pie_chart").height(yheight);
    $("#pie_chart2").height(yheight);
     
    $("#a").addClass("start active");
         
    $('#raporolusturbutton').click(function() {
         $('#portlet-config').modal('hide');
    });
    
    //ün üstteki grafik
    $('#chartpolicesayi').click(function() {
        raporpkey=32;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
        $("#ss25").val("01.01.2012 00:00:00");
        $("#ss32").val(bugunkutarih('bitis'));
    });
    
     $('#chartpolicetarih').click(function() {
        raporpkey=32;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
        $("#ss25").val(bugunkutarih('baslangic'));
        $("#ss32").val(bugunkutarih('bitis'));
    });
    
    $('#charthasartarih').click(function() {
        raporpkey=33;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
        $("#ss29").val(bugunkutarih('baslangic'));
        $("#ss33").val(bugunkutarih('bitis'));
    });
      
    $('#pie_chart').click(function() {
        raporpkey=2;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
    });
    
    $('#pie_chart2').click(function() {
        raporpkey=8;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
    });
    
    $('#pie_chart3').click(function() {
        raporpkey=6;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
    });
     
    $('#pie_chart4').click(function() {
        raporpkey=5;
        calistir(raporpkey, "portlet-config","arabirimholder","arabirimraporad","arabirimraporaciklama");  
    });
       

    //POLİÇELERİN FİRMALARA GÖRE DAĞILIMI
    PoliceGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"firmapolicedagilim" + '"}',
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
    PoliceGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#pie_chart"), data, {
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

    

    //HASARLARIN FİRMALARA GÖRE DAĞİLİMİ
     HasarGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/hasaryuklemegrafikdata",
                data: '{neyegore:"' +"hasarfirmadagilim" + '"}',
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
    HasarGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#pie_chart2"), data, {
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
    
    
    

    
     //POLİÇELERİN ZEYLCODE LARA GÖRE DAĞILIMI
    PoliceGrafikObject2 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"zeylpolicedagilim" + '"}',
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
    PoliceGrafikObject2.getArray(function(data) {
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
    
    
    
    
     //POLİÇELERİN ÜRÜN KODLARINA GÖRE DAĞILIMI
    PoliceGrafikObject3 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"urunpolicedagilim" + '"}',
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
    PoliceGrafikObject3.getArray(function(data) {
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
    
   
            
    PoliceGrafikObject4 = {     
        getArray: function(callback) {  
          var data = [];      
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"policetarihdagilim" + '"}',
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
    PoliceGrafikObject4.getArray(function(data) {
        // this code runs when the ajax call is complete...
          var plot_statistics = $.plot($("#chartpolicetarih"), 
                    [
                    {
                        data:data,
                        lines: {
                            fill: 0.6,
                            lineWidth: 0,
                        },
                        color: ['#4b8df8']
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
                $("#chartpolicetarih").bind("plothover", function (event, pos, item) {
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
                
                
                
                
                
     PoliceGrafikObject5 = {     
        getArray: function(callback) {  
          var data = [];      
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"hasartarihdagilim" + '"}',
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
    PoliceGrafikObject5.getArray(function(data) {
        // this code runs when the ajax call is complete...
          var plot_statistics = $.plot($("#charthasartarih"), 
                    [
                    {
                        data:data,
                        lines: {
                            fill: 0.6,
                            lineWidth: 0,
                        },
                        color: ['#35aa47']
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
                $("#charthasartarih").bind("plothover", function (event, pos, item) {
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
    
    
    
    
    
    //EN ÜSTTEKİ GRAFİK --------------
     PoliceGrafikObject6 = {     
        getArray: function(callback) {  
          var data = [];      
            $.ajax({
                type: "POST",
                url: "yonetimanaservis.aspx/sirketpoliceyuklemegrafikdata",
                data: '{neyegore:"' +"firmapolicedagilim_sirketkodlu" + '"}',
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
    PoliceGrafikObject6.getArray(function(data) {
        // this code runs when the ajax call is complete...
          var plot_statistics = $.plot($("#chartpolicesayi"), 
                    [
                    {
                        data:data,
                        lines: {
                            fill: 0.6,
                            lineWidth: 0,
                        },
                          color: ['#4b8df8']
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
                $("#chartpolicesayi").bind("plothover", function (event, pos, item) {
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
    
    
    
    
    
    
    
    
    

}); //document.ready



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
            
    
   function bugunkutarih(tip) {        
     
        var saatdakikakismi; 
            
        if (tip=='baslangic') {
            saatdakikakismi=" 00:00:00"
        }
        if (tip=='bitis') {
            saatdakikakismi=" 23:59:00"
        }
    
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth()+1; //January is 0!

        var yyyy = today.getFullYear();
        if(dd<10){
            dd='0'+dd
        } 
        if(mm<10){
            mm='0'+mm
        } 
        var today = dd+'.'+mm+'.'+yyyy+saatdakikakismi;
        return today
    
    }
            




 