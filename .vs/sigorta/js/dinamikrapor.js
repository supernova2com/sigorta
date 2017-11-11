$(document).ready(function() {

    $("#j").addClass("active");
    $("#j1").addClass("active");

    $('.accordion').accordion({ autoHeight: false });
    $('.button').button();

    getfancy();

    $('#raporolusturbutton').click(function() {
        var raporpkey = document.getElementById("DropDownList1").value;
        if (raporpkey != "0") {
            var link;
            raporpkeykaydet(raporpkey);
        }
    });

    //ÇALIŞTIR DÜĞMESİNE BASTIĞINDA OLACAKLAR
    $('#Buttoncalistir').click(function() {
        var raporpkey = document.getElementById("DropDownList1").value;
        if (raporpkey != "0") {
        
            var arabirimholderid = "arabirimholder";
            var arabirimraporadid = 'arabirimraporad';
            var arabirimraporaciklamaid = 'arabirimraporaciklama';
            
            calistir(raporpkey, "portlet-config", arabirimholderid, arabirimraporadid, arabirimraporaciklamaid);
        }
    });

});           //document.ready




/* -------------Poliçelerin Ürün Kodlarına Göre Dağılımı------------
@AUTHOR: SUPERNOVA TİCARET VE YAZILIM 
@Bu dosya yazılım tarafından 21.04.2016 17:32:23 tarihinde otomatik olarak oluşturuldu. */



