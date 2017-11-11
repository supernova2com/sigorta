   Grafik1 = {     
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
                         data[i] = {
                            label: result.d[i].seriad,
                            data: result.d[i].sayi,
                            color: '#'+(Math.random()*0xFFFFFF<<0).toString(16)
                         }
                    }
                    callback.call(this,data);    
                  },           
            });
        }
    }          
    Grafik1.getArray(function(data) {   
               var chart = AmCharts.makeChart("chartpolicesayi2",{
                "type": "serial",
                "theme": "light",
                "depth3D": 20,
                "angle":30,
                "categoryField": "label",
                "startDuration": 1,
                "categoryAxis": {
                       "gridPosition": "start",
                       "labelsEnabled": false,
                },
                "graphs": [
                {
                    "title": "Poliçe Sayısı",
                    "valueField": "data",
                    "colorField": "color",
                    "type": "column",
                    "lineAlpha": 0,
                    "fillAlphas": 1,
                    "balloonText": "<span style='font-size:14px'>[[category]]: <b>[[value]] poliçe</b></span>"
                }
                ],
                "valueAxes": [{
                        "axisAlpha": 0,
                        "gridAlpha": 0.1
                }],
              "export": {
    	        "enabled": false,
                "position": "bottom-right"
            },
            "titles": [
            {
                "size": 15,
                "text": ""
            }
            ],
              "dataProvider": data
        });
                      
    });
    
