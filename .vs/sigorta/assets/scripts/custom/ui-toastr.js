var UIToastr = function() {

    return {
        //main function to initiate the module
        init: function() {

            var i = -1,
                toastCount = 0,
                $toastlast,
                getMessage = function() {
                    var msgs = ['Hello, some notification sample goes here',
                        '<div><input class="form-control input-small" value="textbox"/>&nbsp;<a href="http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes" target="_blank">Check this out</a></div><div><button type="button" id="okBtn" class="btn blue">Close me</button><button type="button" id="surpriseBtn" class="btn default" style="margin: 0 8px 0 8px">Surprise me</button></div>',
                        'Did you like this one ? :)',
                        'Totally Awesome!!!',
                        'Yeah, this is the Metronic!',
                        'Explore the power of Metronic. Purchase it now!'
                    ];
                    i++;
                    if (i === msgs.length) {
                        i = 0;
                    }

                    return msgs[i];
                };

            $('#plakaarabutton').click(function() {

                var toastCount = 0;
                var shortCutFunction = 'info';
                var msg = 'Plakay� girmediniz';
                var title = 'Uyar�' || '';
                var $showDuration = 1000;
                var $hideDuration = 1000;
                var $timeOut = 1500;
                var $extendedTimeOut = 2000;
                var $showEasing = 'swing';
                var $hideEasing = 'linear';
                var $showMethod = 'fadeIn';
                var $hideMethod = 'fadeOut';
                var toastIndex = toastCount++;

                toastr.options = {
                    closeButton: $('#closeButton').prop('checked'),
                    debug: $('#debugInfo').prop('checked'),
                    positionClass: $('#positionGroup input:checked').val() || 'toast-top-right',
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
                    msg = getMessage();
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
            });
            $('#cleartoasts').click(function() {
                toastr.clear();
            });

        }

    };

} ();