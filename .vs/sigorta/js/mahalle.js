

$(document).ready(function() {

    //İLÇE DEĞİŞTİĞİNDE BUCAKLARI DOLDURUYORUZ
    $('#DropDownList1').change(function() {
        $("#DropDownList2" + "> option").remove();
        $("#DropDownList3" + "> option").remove();
        var ilcepkey = document.getElementById('DropDownList1').value;
        if (ilcepkey != "0") {
            ilgilibucaklaridoldur("DropDownList2", ilcepkey);
            listele_ilgiliilceninbucaklari(ilcepkey);
        }
    });

    //BUCAK DEĞİŞTİĞİNDE BELEDİYELERİ DOLDURUYORUZ
    $('#DropDownList2').change(function() {
        $("#DropDownList3" + "> option").remove();
        var bucakpkey = document.getElementById('DropDownList2').value;
        if (bucakpkey != "0") {
            ilgilibelediyeleridoldur("DropDownList3", bucakpkey);
            listele_ilgilibucaginbelediyeleri(bucakpkey);
        }
    });

    //BELEDİYE DEĞİŞTİĞİNDE MAHALLELERİ LİSTELEME YAP
    $('#DropDownList3').change(function() {
        var belediyepkey = document.getElementById('DropDownList3').value;
        if (belediyepkey != "0") {
            listele_ilgilibelediyeninmahallelerini(belediyepkey);
        }
    });


    //TİP LERE GÖRE LİSTELE
    $('#DropDownList4').change(function() {
        var belediyepkey = document.getElementById('DropDownList3').value;
        var tip = document.getElementById('DropDownList4').value;
        if (belediyepkey != "0") {
            listele_ilgilibelediyeninmahallelerini_tip(belediyepkey, tip);
        }
    });




    //KAYDET BUTTON
    $('#Button1').click(function(e) {

        var hata, hatamesajlari;
        var ilcepkey, bucakpkey, belediyepkey, belediyead;

        ilcepkey = document.getElementById('DropDownList1').value;
        bucakpkey = document.getElementById('DropDownList2').value;
        belediyepkey = document.getElementById('DropDownList3').value;
        mahallead = document.getElementById('Textbox1').value;

        hata = "0";

        //ilcepkey
        if (ilcepkey == "0" || ilcepkey == "") {
            $('#DropDownList1').focus();
            hata = "1";
            showtoast("error", "HATA", "İlçeyi seçmediniz.");
        }

        //bucakpkey
        if (bucakpkey == "0" || bucakpkey == "") {
            $('#DropDownList2').focus();
            hata = "1";
            showtoast("error", "HATA", "Bucağı seçmediniz.");
        }

        //belediyepkey
        if (belediyepkey == "0" || belediyepkey == "") {
            $('#DropDownList3').focus();
            hata = "1";
            showtoast("error", "HATA", "Belediyeyi seçmediniz.");
        }

        //belediye ad
        if (mahallead == "") {
            $('#TextBox1').focus();
            hata = "1";
            showtoast("error", "HATA", "Mahalle adını girmediniz.");
        }

        if (hata == "1") {
            e.preventDefault();
        }


    }); //KAYDET BUTTON


});  //document.ready





