$(document).ready(function() {

    $("#plakainput").bind('keyup', function(e) {
        if (e.which >= 97 && e.which <= 122) {
            var newKey = e.which - 32;
            // I have tried setting those
            e.keyCode = newKey;
            e.charCode = newKey;
        }   
        $("#plakainput").val(($("#plakainput").val()).toUpperCase().replace(" ", ""));
    });
    

   $("#g1").click(function() {
        $("#g").addClass("active");
        $("#g1").addClass("active");
    }); 

});

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function parseLocalNum(num) {
    return num.replace(",", ".");
}

function tersparseLocalNum(num) {
    return num.replace(".", ",");
}


function corenumericyap(event, idx) {
    if (event.which != 0) {
        // nokta koyarsa engelle
        if (event.which == 46 || event.which == 58 || event.which == 59) {
            event.preventDefault();
        }
        if ((event.which < 46 || event.which > 59) && event.which != 8) {
            event.preventDefault();
        } // prevent if not number
    }
}

function numericyap(event, idx) {
    if (event.which != 0) {
        // nokta koyarsa engelle
        if (event.which == 46 || event.which == 58 || event.which == 59) {
            event.preventDefault();
        }
        if ((event.which < 46 || event.which > 59) && event.which != 8 && event.which != 44) {
            event.preventDefault();
        } // prevent if not number/comma
    }
    if (event.which == 44 && $(idx).val().indexOf(',') != -1) {
        event.preventDefault();
    } // prevent if already comma
}


function getfancy() {
    $(".iframeyenikayit").fancybox({
        'centerOnScroll': true,
        'width': '100%',
        'height': '100%',
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'type': 'iframe',
        'title': 'Bilgi',
        'autoDimensions': false,
        'fixed':false,
        'showCloseButton': true,
        'fitToView': false,
        'autoSize': false
    });
    
    $("#iframeyenikayit").fancybox({
        'centerOnScroll': true,
        'width': '100%',
        'height': '100%',
        'transitionIn': 'fade',
        'transitionOut': 'fade',
        'type': 'iframe',
        'title': 'Bilgi',
        'autoDimensions': false,
        'fixed':false,
        'showCloseButton' : true,
        'fitToView': false,
        'autoSize': false
    });
    
}


function getQuerystring(key, default_) {
    if (default_ == null) default_ = "";
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    if (qs == null)
        return default_;
    else
        return qs[1];
}


function formatJSONDate(jsonDate) {
    var newDate = dateFormat(jsonDate, "dd.mm.yyyy"); return newDate;
}

/* HATA DİYALOGU GOSTER */
function showdialogbox(title, hatatxt) {
    $('#hatatxt').html(hatatxt);
    $('#hatadialog').dialog({
        resizable: false,
        title: title,
        width: '500',
        minHeight: '0',
        modal: false,
        closeOnEscape: true,
        buttons: [{
            text: "Tamam",
            click: function() {
                $(this).dialog("close");
            }
        }]
      
    });
}


/* HATA DİYALOGU GOSTER */
function showdialogbox2(title, hatatxt) {
    $('#hatatxt2').html(hatatxt);
    $('#hatadialog2').dialog({
        resizable: false,
        title: title,
        width: '500',
        minHeight: '0',
        modal: false,
        closeOnEscape: true,
        buttons: [{
            text: "Tamam",
            click: function() {
                $(this).dialog("close");
            }
    }]

        });
    }


    /* HATA DİYALOGU GOSTER */
    function showdialogbox3(title, hatatxt) {
        $('#hatatxt3').html(hatatxt);
        $('#hatadialog3').dialog({
            resizable: false,
            title: title,
            width: '500',
            minHeight: '0',
            modal: false,
            closeOnEscape: true,
            buttons: [{
                text: "Tamam",
                click: function() {
                    $(this).dialog("close");
                }
}]

            });
        }


function inputLimiter(e, allow) {
    var AllowableCharacters = '';

    if (allow == 'Letters') { AllowableCharacters = ' ABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZabcçdefgğhıijklmnoöpqrsştuüvwxyz'; }
    if (allow == 'Numbers') { AllowableCharacters = '1234567890'; }
    if (allow == 'NameCharacters') { AllowableCharacters = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-.\''; }
    if (allow == 'NameCharactersAndNumbers') { AllowableCharacters = '1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-\''; }

    var k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
    if (k != 13 && k != 8 && k != 0) {
        if ((e.ctrlKey == false) && (e.altKey == false)) {
            return (AllowableCharacters.indexOf(String.fromCharCode(k)) != -1);
        } else {
            return true;
        }
    } else {
        return true;
    }
}



//success info warning error
function showtoast(tip, title, msg) {

    var toastCount = 0;
    var shortCutFunction = tip;
    //var msg = 'Plakayı girmediniz';
    //var title = 'Uyarı' || '';
    var $showDuration = 450;
    var $hideDuration = 190;
    var $timeOut = 1500;
    var $extendedTimeOut = 2000;
    var $showEasing = 'swing';
    var $hideEasing = 'linear';
    var $showMethod = 'fadeIn';
    var $hideMethod = 'fadeOut';
    var toastIndex = toastCount++;

    toastr.options = {
        closeButton: 1,
        debug: $('#debugInfo').prop('checked'),
        positionClass: 'toast-top-center',
        onclick: null
    };

    if ($('#addBehaviorOnToastClick').prop('checked')) {
        toastr.options.onclick = function() {
            alert('You can perform some custom action after a toast goes away');
        };
    }

    //if ($showDuration.val().length) {
    toastr.options.showDuration = $showDuration;
    //}

    //if ($hideDuration.val().length) {
    toastr.options.hideDuration = $hideDuration;
    //}

    //if ($timeOut.val().length) {
    toastr.options.timeOut = $timeOut;
    //}

    //if ($extendedTimeOut.val().length) {
    toastr.options.extendedTimeOut = $extendedTimeOut;
    //}

    //if ($showEasing.val().length) {
    toastr.options.showEasing = $showEasing;
    //}

    //if ($hideEasing.val().length) {
    toastr.options.hideEasing = $hideEasing;
    //}

    //if ($showMethod.val().length) {
    toastr.options.showMethod = $showMethod;
    //}

    //if ($hideMethod.val().length) {
    toastr.options.hideMethod = $hideMethod;
    //}

    if (!msg) {
        msg = "";
    }

    $("#toastrOptions").text("Command: toastr[" + shortCutFunction + "](\"" + msg + (title ? "\", \"" + title : '') + "\")\n\ntoastr.options = " + JSON.stringify(toastr.options, null, 2));

    var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
    $toastlast = $toast;
    if ($toast.find('#okBtn').length) {
        $toast.delegate('#okBtn', 'click', function() {
            alert('you clicked me. i was toast #' + toastIndex + '. goodbye!');
            $toast.remove();
        });
    }
    if ($toast.find('#surpriseBtn').length) {
        $toast.delegate('#surpriseBtn', 'click', function() {
            alert('Surprise! you clicked me. i was toast #' + toastIndex + '. You could perform an action here.');
        });
    }

    $('#clearlasttoast').click(function() {
        toastr.clear($toastlast);
    });

}


$('#cleartoasts').click(function() {
    toastr.clear();
});
            

