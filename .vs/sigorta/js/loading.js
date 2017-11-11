
 $(document).ready(function() {

     $("#wait").bind("ajaxStart", function() {
        // $('#wait').center();
        //var overlay = jQuery('<div id="overlay"> </div>'); overlay.appendTo(document.body);
         $(this).show();
         $('#wait').html("<img alt='Yükleniyor' src='resimler/indicator3.gif'></img>");
         $('#wait').center();

    }).bind("ajaxStop", function() {
    // $('#overlay').remove();
        // $('#wait').center();
         $(this).hide();
         $('#wait').html("");
    });

});


jQuery.fn.center = function() {
    this.css("position", "absolute");
    this.css("top", (( $(window).height() - this.outerHeight()) / 2) +  $(window).scrollTop() + "px");
    this.css("left", (( $(window).width() - this.outerWidth()) / 2) +  $(window).scrollLeft() + "px");
    this.css("z-index", 999);
    this.css("border-color","Black");
    this.css("border-style","solid");
    this.css("border-width", "thin");
 
    return this;
} 