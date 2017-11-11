$(document).ready(function() {

    $(".button").button();

    $('#kapatbutton').click(function() {
        parent.$.fancybox.close();
    })

    $('.accordion').accordion({ autoHeight: false });

});