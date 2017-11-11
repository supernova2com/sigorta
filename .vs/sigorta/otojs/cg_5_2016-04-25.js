/* -------------Poliçelerin Ürün Kodlarına Göre Dağılımı------------
@AUTHOR: SUPERNOVA TİCARET VE YAZILIM 
@Bu dosya yazılım tarafından 25.04.2016 14:28:09 tarihinde otomatik olarak oluşturuldu. */



$(document).ready(function() {




$('#raporolusturbutton').click(function(e) {
var ss3;
var ss4;
ss3=document.getElementById('ss3').value;
ss4=document.getElementById('ss4').value;
ikitariharasigunfark(ss3,ss4, function (result) {
            if (result.d == '-') {
               e.preventDefault();
             }
            if (result.d > 30) {
              e.preventDefault();
              showtoast("error", "Hata","En Fazla 30 günlük rapor alabilirsiniz");
            }
      });




});
//---------------------




}); //document.ready
