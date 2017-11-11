
function tumilceleridoldur(id) {

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/tumilceleridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].ilcead));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}



function ilgilibucaklaridoldur(id, ilcepkey) {

    var veriler = { ilcepkey: ilcepkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/ilgilibucaklaridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].bucakad));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}


function ilgilibelediyeleridoldur(id, bucakpkey) {

    var veriler = { bucakpkey: bucakpkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/ilgilibelediyeleridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].belediyead));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}

function ilgilimahalleleridoldur(id, belediyepkey) {

    var veriler = { belediyepkey: belediyepkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/ilgilimahalleleridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].mahallead));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}



function ilgilisokaklaridoldur(id, mahallepkey) {

    var veriler = { mahallepkey: mahallepkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/ilgilisokaklaridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].sokakad));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}




function ilgilibinalaridoldur(id, sokakpkey) {

    var veriler = { sokakpkey: sokakpkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/ilgilibinalaridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].binaad));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}


function ilgiliadresleridoldur(id, binapkey) {

    var veriler = { binapkey: binapkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/ilgiliadresleridoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].diskapino));
            }
        },
        error: function(request, status, error) {
            alert('Verileri alırken bir sorun oluştu.' + request.responseText);
        }
    });
}



function sadeceistedigimilceyidoldur(id, ilcepkey) {

    var veriler = { ilcepkey: ilcepkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/sadeceistedigimilceyidoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].ilcead));
            }
        },
        error: function(request, status, error) {
            alert('Sadece istediğim ilçeyi doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}



function sadeceistedigimbucagidoldur(id, bucakpkey) {

    var veriler = { bucakpkey: bucakpkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/sadeceistedigimbucagidoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].bucakad));
            }
        },
        error: function(request, status, error) {
            alert('Sadece istediğim bucagi doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}


function sadeceistedigimbelediyeyidoldur(id, belediyepkey) {

    var veriler = { belediyepkey: belediyepkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/sadeceistedigimbelediyeyidoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].belediyead));
            }
        },
        error: function(request, status, error) {
            alert('Sadece istediğim belediyeyi doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}


function sadeceistedigimmahalleyidoldur(id, mahallepkey) {

    var veriler = { mahallepkey: mahallepkey };

    var listeid = "#" + id;
    var drop = $(listeid);

    //hepsini boşalt
    $(listeid + "> option").remove();
    drop.append($("<option></option>").val("0").html("Seçiniz"));
    $.ajax({
        type: "POST",
        url: "adresajax.aspx/sadeceistedigimmahalleyidoldur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            for (i = 0; i < result.d.length; i++) {
                drop.append($("<option></option>").val(result.d[i].pkey).html(result.d[i].mahallead));
            }
        },
        error: function(request, status, error) {
            alert('Sadece istediğim mahalleyi doldururken bir sorun oluştu.' + request.responseText);
        }
    });
}



//LİSTELEMELER -----------------------------------------------------------------------

function listele_ilgiliilceninbucaklari(ilcepkey) {

    var veriler = { ilcepkey: ilcepkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgiliilceninbucaklari",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}


function listele_ilgilibucaginbelediyeleri(bucakpkey) {

    var veriler = { bucakpkey: bucakpkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilibucaginbelediyeleri",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}

function listele_ilgilibelediyeninmahallelerini(belediyepkey) {

    var veriler = { belediyepkey: belediyepkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilibelediyeninmahallelerini",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}

function listele_ilgilibelediyeninmahallelerini_tip(belediyepkey, tip) {

    var veriler = { belediyepkey: belediyepkey, tip: tip };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilibelediyeninmahallelerini_tip",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });

}



function listele_ilgilimahalleninsokaklari(mahallepkey) {

    var veriler = { mahallepkey: mahallepkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilimahalleninsokaklari",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}



function listele_ilgilimahalleninsokaklari_sokaktur(mahallepkey, sokaktur) {

    var veriler = { mahallepkey: mahallepkey, sokaktur: sokaktur };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilimahalleninsokaklari_sokaktur",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}


function listele_ilgilisokaginbinalari(sokakpkey) {

    var veriler = { sokakpkey: sokakpkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilisokaginbinalari",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}


function listele_ilgilibinaninadresleri(binapkey) {

    var veriler = { binapkey: binapkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilibinaninadresleri",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}


function listele_ilgilikonuttipadresleri(binapkey, konuttippkey) {

    var veriler = { binapkey: binapkey, konuttippkey: konuttippkey };

    $.ajax({
        type: "POST",
        url: "adresajax.aspx/listele_ilgilikonuttipadresleri",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        data: $.toJSON(veriler),
        success: function(result) {
            $('#Label1').html(result.d);

        },
        error: function(request, status, error) {
            alert('Listeleme yapamıyorum:' + request.responseText);
        }
    });
}




