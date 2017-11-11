$(document).ready(function() {

    if (!jQuery().fullCalendar) {
        return;
    }

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var h = {};

    if ($('#calendar').width() <= 400) {
        $('#calendar').addClass("mobile");
        h = {
            left: 'title, prev, next',
            center: '',
            right: 'today,month,agendaWeek,agendaDay'
        };
    } else {
        $('#calendar').removeClass("mobile");
        if (App.isRTL()) {
            h = {
                right: 'title',
                center: '',
                left: 'prev,next,today,month,agendaWeek,agendaDay'
            };
        } else {
            h = {
                left: 'title',
                center: '',
                right: 'prev,next,today,month,agendaWeek,agendaDay'
            };
        }
    }

    // $('#calendar').fullCalendar('destroy'); // destroy the calendar


    $.ajax({
        type: "POST",
        url: "takvimservis.aspx/doldurhepsi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(result) {
            $('#calendar').fullCalendar({
                disableDragging: false,
                header: h,
                editable: true,
                timeFormat: '',
                eventClick: function(calEvent, jsEvent, view) {


                    bilgiolustur(formatJSONDate(calEvent.start), calEvent.tip);
                    $('#fullCalModal').modal();
                    
                    //$('#servisbilgiconfig').modal();
                    //$('#portlet-config').modal('show');     
                    //date.format();
                    //bilgiler(calEvent.tip, calEvent.pkey);
                },
                events: $.map(result.d, function(item, i) {
                    var event = new Object();
                    event.tip = item.tip;
                    event.id = item.id;
                    event.start = new Date(item.start);
                    event.end = new Date(item.end);
                    event.title = item.title;
                    event.backgroundColor = item.backgroundColor;
                    event.pkey = item.pkey;
                    event.allDay = item.allDay;
                    event.editable = item.editable;
                    return event;
                })
            });
        },
        error: function() {
            alert('Takvim bilgilerini oluþtururken bir sorun oluþtu. Yeniden deneyin!!');
        }
    }); //ajax



});  //document.ready



function bilgiolustur(tarih,tip) {

    var veriler = { tarih:tarih, tip: tip};

    $.ajax({
        type: "POST",
        url: "takvimservis.aspx/takvimbilgi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        success: function(result) {
            //alert(result.d);
            $("#takvimbilgilabel").html(result.d);
        },
        error: function(request, status, error) {
            alert('Takvim bilgilerini getirirken bir sorun oluþtu.' + request.responseText);
        }
    });
}