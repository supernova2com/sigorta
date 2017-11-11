
function siteobjesi() {
}

var siteobje = new siteobjesi();

/* SİTE OBJESİNİ DOLDUR  --------------- */
function siteobjesidoldur(cb) {

    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/siteobjesidoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: cb,
        async:false,
        error: function() {
            alert('Ürün objesini dolduruken bir sorun oluştu.');
        }
    });
    return siteobjesi;
}

$(document).ready(function() {

    function cb(result) {
        siteobje = result.d;
    }
    siteobjesidoldur(cb);
 
    $("#resimonizledialog").dialog({ autoOpen: false });
    $('.button').button();

    // BACKGROUNG RESMİ GÖSTER
    $('#bgresim').click(function() {
        resimonizledialog_goster();
        $('#onizle').html("<img height=300px width=300px src="+ siteobje.path + "resimler/bg.jpg></img>")
    });

    // SEPETTEKİ ÇÖP KUTUSU RESMİ GÖSTER
    $('#copkutusu').click(function() {
        resimonizledialog_goster();
        $('#onizle').html("<img height=300px width=300px src="+ siteobje.path +"resimler/rclbin.jpg></img>")
    });


    // SEPET RESMİ
    $('#sepet').click(function() {
        resimonizledialog_goster();
        $('#onizle').html("<img height=300px width=300px src=" + siteobje.path + "resimler/sepet.jpg></img>")

    });


});


function resimonizledialog_goster() {
    // DİALOGU GOSTER -------------------------------------
    $('#resimonizledialog').dialog("destroy");
    $('#resimonizledialog').dialog('option', 'position', 'center');
    $('#resimonizledialog').dialog({
        resizable: false,
        title: 'Resim Önizleme',
        width: '800',
        modal: true,
        buttons:
			     {
			         "Kapat": function() {
			             $(this).dialog('close');
			         }
			     }
    });
}