
$(document).ready(function() {

    $("#m").addClass("active");
    $("#m5").addClass("active");
    
    
   $(".sortable").sortable({
        placeholder: "ui-state-highlight",
        axis:'y',
   });
    
 
    $('#siralamabutton').click(function() {
        var anamenupkey = document.getElementById('DropDownList9').value;
        if (anamenupkey!="0"){
            showdialogbox("Sıralama Seçenekleri", "--");
            siralamagosterrecursive(anamenupkey);
        }
        
    });


    //NUMERIC LER -----------------------------------------------
    $('#Textbox2').keypress(function(event) {
        numericyap(event, "#Textbox2");
    });
    //-----------------------------------------


    //ARAMADA SADECE BABA MENULERİ DOLDUR
    $('#DropDownList7').change(function() {
        var anamenupkey = document.getElementById('DropDownList7').value;
        doldursadecebaba("DropDownList8", anamenupkey);
    });

    //SADECE BABA MENULERİ DOLDUR
    $('#DropDownList2').change(function() {
        var babami = document.getElementById('DropDownList2').value;
        var anamenupkey = document.getElementById('DropDownList1').value;
        if (babami != "Evet") {
            doldursadecebaba("DropDownList3", anamenupkey);
        }
    });

});

//SADECE BABA MENULERI DOLDUR
function doldursadecebaba(id, anamenupkey) {

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("999").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/doldursadecebaba",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{anamenupkey:"' + anamenupkey + '"}',
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].baslik));
            }
        },
        error: function(request, status, error) {
            alert('Sadece Ana (Baba) menuleri doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}


function siralamagosterrecursive(anamenupkey) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/siralamagosterrecursive",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{anamenupkey:"' + anamenupkey + '"}',
        success: function(result) {
            $('#Labelsiralamamenu').html(result.d);         
        },
        error: function(request, status, error) {
            alert('Menüleri gösterirken bir sorun oluştu. Yeniden deneyin'+ request.responseText);
        }
    });
}


function menuyuyenile() {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/menuyuyenile",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            $('#Literalmenu').html(result.d);
        },
        error: function(request, status, error) {
            alert('Menüleri gösterirken bir sorun oluştu. Yeniden deneyin'+ request.responseText);
        }
    });
}
