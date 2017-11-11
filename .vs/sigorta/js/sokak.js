

$(document).ready(function() {

    //İLÇE DEĞİŞTİĞİNDE BUCAKLARI DOLDURUYORUZ
    $('#DropDownList1').change(function() {
        $("#DropDownList3" + "> option").remove();
        $("#DropDownList4" + "> option").remove();
        var ilcepkey = document.getElementById('DropDownList1').value;
        if (ilcepkey != "0") {
            ilgilibucaklaridoldur("DropDownList2", ilcepkey);
            listele_ilgiliilceninbucaklari(ilcepkey);
        }
    });

    //BUCAK DEĞİŞTİĞİNDE BELEDİYELERİ DOLDURUYORUZ
    $('#DropDownList2').change(function() {
        $("#DropDownList4" + "> option").remove();
        var bucakpkey = document.getElementById('DropDownList2').value;
        if (bucakpkey != "0") {
            ilgilibelediyeleridoldur("DropDownList3", bucakpkey);
            listele_ilgilibucaginbelediyeleri(bucakpkey);
        }
    });

    //BELEDİYE DEĞİŞTİĞİNDE MAHALLERİ DOLDURUYORUZ
    $('#DropDownList3').change(function() {
        $("#DropDownList4" + "> option").remove();
        var belediyepkey = document.getElementById('DropDownList3').value;
        if (belediyepkey != "0") {
            ilgilimahalleleridoldur("DropDownList4", belediyepkey);
            listele_ilgilibelediyeninmahallelerini(belediyepkey);
        }
    });


    //MAHALLE DEĞİŞTİĞİNDE SOKAKLARI LİSTELEME YAP
    $('#DropDownList4').change(function() {
        var mahallepkey = document.getElementById('DropDownList4').value;
        if (mahallepkey != "0") {
            listele_ilgilimahalleninsokaklari(mahallepkey);
        }
    });

    //İLGİLİ TÜRDEKİ SOKAKLARI DOLDUR
    $('#DropDownList5').change(function() {
        var mahallepkey = document.getElementById('DropDownList4').value;
        var sokaktur = document.getElementById('DropDownList5').value;
        if (mahallepkey != "0") {
            listele_ilgilimahalleninsokaklari_sokaktur(mahallepkey, sokaktur);
        }
    });


    //KAYDET BUTTON
    $('#Button1').click(function(e) {

        var hata, hatamesajlari;
        var ilcepkey, bucakpkey, belediyepkey, mahallepkey, belediyead;

        ilcepkey = document.getElementById('DropDownList1').value;
        bucakpkey = document.getElementById('DropDownList2').value;
        belediyepkey = document.getElementById('DropDownList3').value;
        mahallepkey = document.getElementById('DropDownList4').value;
        sokakad = document.getElementById('Textbox1').value;

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

        //mahallepkey
        if (mahallepkey == "0" || mahallepkey == "") {
            $('#DropDownList4').focus();
            hata = "1";
            showtoast("error", "HATA", "Mahalleyi seçmediniz.");
        }

        //sokak ad
        if (sokakad == "") {
            $('#TextBox1').focus();
            hata = "1";
            showtoast("error", "HATA", "Sokak adını girmediniz.");
        }

        if (hata == "1") {
            e.preventDefault();
        }


    }); //KAYDET BUTTON


});   //document.ready



