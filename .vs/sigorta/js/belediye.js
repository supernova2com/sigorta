

$(document).ready(function() {

    //İLÇE DEĞİŞTİĞİNDE BUCAKLARI DOLDURUYORUZ
    $('#DropDownList1').change(function() {
        $("#DropDownList2" + "> option").remove();
        var ilcepkey = document.getElementById('DropDownList1').value;
        if (ilcepkey != "0") {
            ilgilibucaklaridoldur("DropDownList2", ilcepkey);
            listele_ilgiliilceninbucaklari(ilcepkey);
        }
    });


    //BUCAK DEĞİŞTİĞİNDE İLGİLİ BUCAKLARI LİSTELİYORUZ
    $('#DropDownList2').change(function() {
        var bucakpkey = document.getElementById('DropDownList2').value;
        if (bucakpkey != "0") {
            listele_ilgilibucaginbelediyeleri(bucakpkey);
        }
    });



    //KAYDET BUTTON
    $('#Button1').click(function(e) {

        var hata, hatamesajlari;
        var ilcepkey, bucakpkey, belediyead;

        ilcepkey = document.getElementById('DropDownList1').value;
        bucakpkey = document.getElementById('DropDownList2').value;
        belediyead = document.getElementById('Textbox1').value;

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

        //belediye ad
        if (belediyead == "") {
            $('#TextBox1').focus();
            hata = "1";
            showtoast("error", "HATA", "Belediye adını girmediniz.");
        }

        if (hata == "1") {
            e.preventDefault();
        }


    }); //KAYDET BUTTON


});  //document.ready