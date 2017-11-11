$(document).ready(function() {

    $('.accordion').accordion({ heightStyle: "content" });
    $(".button").button();
    $("#tabsbilgi").tabs();


    $('#kapatbutton').click(function() {
        parent.$.fancybox.close();
    })


});   //document ready
