
$(document).ready(function() {

    $('#TextBox8').mask("99.99.9999", { placeholder: "." });
    $('#TextBox12').mask("99.99.9999", { placeholder: "." });
    $('#TextBox13').mask("99.99.9999", { placeholder: "." });

    $.datepicker.setDefaults($.datepicker.regional['tr']);
    $('#TextBox8').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox12').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox13').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });


    //NUMERIC LER -----------------------------------------------
    $('#TextBox9').keypress(function(event) {
        numericyap(event, "#TextBox9");
    });
    //-----------------------------------------------------------

    //NUMERIC LER -----------------------------------------------
    $('#TextBox11').keypress(function(event) {
        numericyap(event, "#TextBox11");
    });
    //-----------------------------------------------------------

    //NUMERIC LER -----------------------------------------------
    $('#TextBox7').keypress(function(event) {
        corenumericyap(event, "#TextBox7");
    });
    //-----------------------------------------------------------



    //PLAKA YAP
    $("#TextBox3").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            e.keyCode = newKey;
            e.charCode = newKey;
        }
        $("#TextBox3").val(($("#TextBox3").val()).toUpperCase().replace(" ", ""));
    });



    //ARAÇ CİNSİ DEĞİŞTİĞİNDE ARAÇ MARKALARI DOLDURUYORUZ
    $('#DropDownList2').change(function() {
        var araccinspkey = document.getElementById('DropDownList2').value;
        if (araccinspkey != "0") {
            doldurmarka("DropDownList3", araccinspkey);
        }
    });

    //ARAÇ MARKASI DEĞİŞTİĞİNDE ARAÇ MODELLERİNİ DOLDURUYORUZ
    $('#DropDownList3').change(function() {
        var araccinspkey = document.getElementById('DropDownList2').value;
        var aracmarkapkey = document.getElementById('DropDownList3').value;
        if (araccinspkey != "0" && aracmarkapkey != "0") {
            doldurmodel("DropDownList4", araccinspkey, aracmarkapkey);
        }
    });


    //KAYDET BUTTON
    $('#Button1').click(function(e) {

        var hata, hatamesajlari;
        var sirketpkey, araccinspkey, aracmarkapkey, aracmodelpkey;
        var plaka, sasino, motorno, koltuksayi, motorgucu, imalyil;
        var kazatarih, odenenhasar, piyasadeger, ilanbaslangictarih;
        var ilanbitistarih, currencycodepkey;
        var hemensatisfiyat;
        var k_koltuksayi, k_motorgucu, k_imalyil, k_odenenhasar, k_piyasadeger, k_hemensatisfiyat;

        sirketpkey = document.getElementById('DropDownList1').value;
        araccinspkey = document.getElementById('DropDownList2').value;
        aracmarkapkey = document.getElementById('DropDownList3').value;
        aracmodelpkey = document.getElementById('DropDownList4').value;
        plaka = document.getElementById('TextBox3').value;
        sasino = document.getElementById('TextBox4').value;
        motorno = document.getElementById('TextBox5').value;
        koltuksayi = document.getElementById('DropDownList5').value;
        motorgucu = document.getElementById('TextBox7').value;
        imalyil = document.getElementById('DropDownList6').value;
        kazatarih = document.getElementById('TextBox8').value;
        odenenhasar = document.getElementById('TextBox9').value;
        piyasadeger = document.getElementById('TextBox11').value;   
        ilanbaslangictarih = document.getElementById('TextBox12').value;
        ilanbitistarih = document.getElementById('TextBox13').value;
        currencycodepkey = document.getElementById('DropDownList7').value;
        hemensatisfiyat = document.getElementById('TextBox14').value;

        k_koltuksayi = parseLocalNum(koltuksayi);
        k_motorgucu = parseLocalNum(motorgucu);
        k_imalyil = parseLocalNum(imalyil);
        k_odenenhasar = parseLocalNum(odenenhasar);
        k_piyasadeger = parseLocalNum(piyasadeger);
        k_hemensatisfiyat = parseLocalNum(hemensatisfiyat);

        hata = "0";

        //sirketpkey
        if (sirketpkey == "0" || sirketpkey == "") {
            $('#DropDownList1').focus();
            hata = "1";
            showtoast("error", "HATA", "Şirketi seçmediniz.");
        }

        //araccinspkey
        if (araccinspkey == "0" || araccinspkey == "") {
            $('#DropDownList2').focus();
            hata = "1";
            showtoast("error", "HATA", "Araç cinsini seçmediniz.");
        }

        //aracmarkapkey
        if (aracmarkapkey == "0" || aracmarkapkey == "") {
            $('#DropDownList3').focus();
            hata = "1";
            showtoast("error", "HATA", "Araç markasını seçmediniz.");
        }

        //aracmodelpkey
        if (aracmodelpkey == "0" || aracmodelpkey == "") {
            $('#DropDownList3').focus();
            hata = "1";
            showtoast("error", "HATA", "Araç modelini seçmediniz.");
        }

        //plaka
        if (plaka == "") {
            $('#TextBox3').focus();
            hata = "1";
            showtoast("error", "HATA", "Plakayı girmediniz.");
        }

        //sasino
        if (sasino == "") {
            $('#TextBox4').focus();
            hata = "1";
            showtoast("error", "HATA", "Şasi numarasını girmediniz.");
        }

        //koltuksayi 
        if (isNumber(k_koltuksayi) == false || k_koltuksayi == 0) {
            $('#DropDownList5').focus();
            hata = "1";
            showtoast("error", "HATA", "Kapı sayısı rakamsal olmalıdır.");

        }

        //motorgucu
        if (isNumber(k_motorgucu) == false) {
            $('#Textbox7').focus();
            hata = "1";
            showtoast("error", "HATA", "Motor gücü rakamsal olmalıdır.");
        }

        //imalyil
        if (isNumber(k_imalyil) == false || k_imalyil == 0) {
            $('#DropDownList6').focus();
            hata = "1";
            showtoast("error", "HATA", "İmal yılı rakamsal olmalıdır.");
        }


        //kaza tarihi
        tarihdogrumu(kazatarih, function(result) {
            if (result.d == "Hayır") {
                $('#TextBox8').focus();
                hata = "1";
                showtoast("error", "HATA", "Kaza tarihi düzgün girmediniz.");
            }
        });


        //odenenhasar
        if (isNumber(k_odenenhasar) == false) {
            $('#TextBox9').focus();
            hata = "1";
            showtoast("error", "HATA", "Ödenen hasar rakamsal olmalıdır.");
        }

        //hemen satış fiyatı
        if (isNumber(k_hemensatisfiyat) == false) {
            $('#TextBox14').focus();
            hata = "1";
            showtoast("error", "HATA", "Hemen satış fiyatı rakamsal olmalıdır.");
        }


        //currencycode
        if (currencycodepkey == "0" || currencycodepkey == "") {
            $('#DropDownList7').focus();
            hata = "1";
            showtoast("error", "HATA", "Para birimini seçmediniz.");
        }


        //piyasadeğer
        if (isNumber(k_piyasadeger) == false) {
            $('#TextBox11').focus();
            hata = "1";
            showtoast("error", "HATA", "Piyasa değeri rakamsal olmalıdır.");
        }


        //ilan başlangıç tarihi
        tarihdogrumu(ilanbaslangictarih, function(result) {
            if (result.d == "Hayır") {
                $('#TextBox12').focus();
                hata = "1";
                showtoast("error", "HATA", "İlan başlangıç tarihini düzgün girmediniz.");
            }
        });


        //ilan bitis tarihi
        tarihdogrumu(ilanbitistarih, function(result) {
            if (result.d == "Hayır") {
                $('#TextBox13').focus();
                hata = "1";
                showtoast("error", "HATA", "İlan bitiş tarihini düzgün girmediniz.");
            }
        });


        if (hata == "1") {
            e.preventDefault();
        }


    }); //KAYDET BUTTON



});    //document.ready




function tarihdogrumu(tarih,callback) {

    var veriler = {tarih: tarih};

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/tarihdogrumu",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            if (typeof (callback) === 'function') {
              callback(result);
            }
        },
        error: function(request, status, error) {
            //alert('Tarih bilgisinin doğru olup olmadığını kontrol ederken bir sorun oluştu:' + request.responseText);
        }
    });
}




//ARAÇ CİNSİ DEĞİŞTİĞİNDE ARAÇ MARKALARINI DOLDUR
function doldurmarka(id, araccinspkey) {

    var veriler = { araccinspkey: araccinspkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/dolduraracmarka_cinsegore",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].markaad));
            }
        },
        error: function(request, status, error) {
            alert('İlgili markaları doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}


//ARAÇ MARKALARINI DEĞİŞTİĞİNDE ARAÇ MODELLERİNİ DOLDUR
function doldurmodel(id, araccinspkey, aracmarkapkey) {

    var veriler = { araccinspkey: araccinspkey, aracmarkapkey: aracmarkapkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();

    drop.append($("<option></option>").val("0").html("Seçiniz"));

    $.ajax({
        type: "POST",
        url: "bilgiservis.aspx/dolduraracmodel",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].modelad));
            }
        },
        error: function(request, status, error) {
            alert('İlgili modelleri doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}