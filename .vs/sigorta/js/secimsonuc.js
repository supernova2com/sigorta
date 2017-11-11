var raporpkey;

$(document).ready(function() {



    var pkey = getQuerystring("pkey");    
    
    if (pkey=="" || pkey==1) {
        $("#a").addClass("start active");
        $("#1").show();
        $("#2").hide();
        $("#3").hide();
        $("#4").hide();
        $("#5").hide();
        $("#6").hide();
        
    }
    
    if (pkey==2) {
       $("#b").addClass("start active");
        $("#1").hide();
        $("#2").show();
        $("#3").hide();
        $("#4").hide();
        $("#5").hide();
        $("#6").hide();
    }
    
    if (pkey==3) {
       $("#c").addClass("start active");
       $("#1").hide();
       $("#2").hide();
       $("#3").show();
       $("#4").hide();
       $("#5").hide();
       $("#6").hide();
    }
    
    if (pkey==4) {
      $("#d").addClass("start active");
       $("#1").hide();
       $("#2").hide();
       $("#3").hide();
       $("#4").show();
       $("#5").hide();
       $("#6").hide();
     }
     
    if (pkey==5) {
      $("#e").addClass("start active");
      $("#1").hide();
      $("#2").hide();
      $("#3").hide();
      $("#4").hide();
      $("#5").show();
      $("#6").hide();
    }
    
    if (pkey==6) {
      $("#f").addClass("start active");
      $("#1").hide();
      $("#2").hide();
      $("#3").hide();
      $("#4").hide();
      $("#5").hide();
      $("#6").show();
     }
           
     
    GenelGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "secimservis.aspx/grafikdata",
                data: '{neyegore:"' +"Genel" + '"}',
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
    GenelGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#chartgenel"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + series.percent.toFixed(2) + '%</div>';
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
            },
         
        });   
    });
    
    
    
    
     LefkosaGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "secimservis.aspx/grafikdata",
                data: '{neyegore:"' +"Lefkoşa" + '"}',
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
    LefkosaGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#chartlefkosa"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + series.percent.toFixed(2) + '%</div>';
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
    
    
    
    
    
    MagosaGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "secimservis.aspx/grafikdata",
                data: '{neyegore:"' +"Gazimağusa" + '"}',
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
    MagosaGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#chartmagosa"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + series.percent.toFixed(2) + '%</div>';
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
    
    
    
    
    
     GirneGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "secimservis.aspx/grafikdata",
                data: '{neyegore:"' +"Girne" + '"}',
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
    GirneGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#chartgirne"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + series.percent.toFixed(2) + '%</div>';
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
    
    
    
      GuzelyurtGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "secimservis.aspx/grafikdata",
                data: '{neyegore:"' +"Güzelyurt" + '"}',
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
    GuzelyurtGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#chartguzelyurt"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + series.percent.toFixed(2) + '%</div>';
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
    
    
    
      IuzelyurtGrafikObject1 = {     
        getArray: function(callback) {
            var data = [];
            $.ajax({
                type: "POST",
                url: "secimservis.aspx/grafikdata",
                data: '{neyegore:"' +"İskele" + '"}',
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
    IuzelyurtGrafikObject1.getArray(function(data) {
        // this code runs when the ajax call is complete...
        $.plot($("#chartiskele"), data, {
            series: {
                pie: {
                    show: true,
                     radius: 1,
                            label: {
                                show: true,
                                radius: 3 / 4,
                                formatter: function (label, series) {
                                    return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + series.percent.toFixed(2) + '%</div>';
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
            

            




 