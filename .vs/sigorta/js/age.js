$(document).ready(function() {

    $("#p").addClass("active");
    $("#p6").addClass("active");

    //NUMERIC LER -----------------------------------------------
    $('#TextBox1').keypress(function(event) {
        corenumericyap(event, "#TextBox1");
    });
    $('#TextBox2').keypress(function(event) {
        corenumericyap(event, "#TextBox2");
    });
    $('#TextBox3').keypress(function(event) {
        numericyap(event, "#TextBox3");
    });
    //-----------------------------------------------------------

});