$(document).ready(function() {

    $("#tabsbilgi").tabs();
    $('.accordion').accordion({ heightStyle: "content" });
    $(".button").button();

    $('#TextBox1').focus();

    //NUMERIC LER -----------------------------------------------
    $('#TextBox1').keypress(function(event) {
        numericyap(event, "#TextBox1");
    });
    //-----------------------------------------------------------

});