
function shownotifc(baslik,yazi) {

    var settings = {
        theme: "lime",
        sticky: false,
        horizontalEdge: "top",
        verticalEdge: "left"
    },
    $button = $(this);
    settings.heading = baslik;

    if (!settings.sticky) {
        settings.life = 10000;
    }

    $.notific8('zindex', 11500);
    $.notific8(yazi, settings);

    $button.attr('disabled', 'disabled');

    setTimeout(function() {
        $button.removeAttr('disabled');
    }, 1000);

}

   
