$(document).ready(function() {

    $("#j").addClass("active");
    $("#j2").addClass("active");

    $('#TextBox1').mask("99.99.9999", { placeholder: "." });
    $('#TextBox2').mask("99.99.9999", { placeholder: "." });

    $('#TextBox3').mask("99.99.9999", { placeholder: "." });
    $('#TextBox4').mask("99.99.9999", { placeholder: "." });

    $('#TextBox5').mask("99.99.9999", { placeholder: "." });
    $('#TextBox6').mask("99.99.9999", { placeholder: "." });

    $('#TextBox7').mask("99.99.9999", { placeholder: "." });
    $('#TextBox8').mask("99.99.9999", { placeholder: "." });

    $('#TextBox9').mask("99.99.9999", { placeholder: "." });
    $('#TextBox10').mask("99.99.9999", { placeholder: "." });

    $('#TextBox11').mask("99.99.9999", { placeholder: "." });
    $('#TextBox12').mask("99.99.9999", { placeholder: "." });

    $('#TextBox14').mask("99.99.9999", { placeholder: "." });
    $('#TextBox15').mask("99.99.9999", { placeholder: "." });

    //NUMERIC LER -----------------------------------------------
    $('#TextBox13').keypress(function(event) {
        numericyap(event, "#TextBox13");
    });
    //-----------------------------------------------------------


    //NUMERIC LER -----------------------------------------------
    $('#hi0oran').keypress(function(event) {
        corenumericyap(event, "#hi0oran");
    });

    $('#hi10oran').keypress(function(event) {
        corenumericyap(event, "#hi10oran");
    });
    $('#hi20oran').keypress(function(event) {
        corenumericyap(event, "#hi20oran");
    });
    $('#hi30oran').keypress(function(event) {
        corenumericyap(event, "#hi30oran");
    });
    $('#hi40oran').keypress(function(event) {
        corenumericyap(event, "#hi40oran");
    });
    $('#hz0oran').keypress(function(event) {
        corenumericyap(event, "#hz0oran");
    });
    $('#hz15oran').keypress(function(event) {
        corenumericyap(event, "#hz15oran");
    });
    $('#hz20oran').keypress(function(event) {
        corenumericyap(event, "#hz20oran");
    });
    $('#hz25oran').keypress(function(event) {
        corenumericyap(event, "#hz25oran");
    });
    $('#hz30oran').keypress(function(event) {
        corenumericyap(event, "#hz30oran");
    });
    $('#hz35oran').keypress(function(event) {
        corenumericyap(event, "#hz35oran");
    });
    $('#hz40oran').keypress(function(event) {
        corenumericyap(event, "#hz40oran");
    });
    $('#hz50oran').keypress(function(event) {
        corenumericyap(event, "#hz50oran");
    });
    $('#yz0oran').keypress(function(event) {
        corenumericyap(event, "#yz0oran");
    });
    $('#yz15oran').keypress(function(event) {
        corenumericyap(event, "#yz15oran");
    });
    $('#yz30oran').keypress(function(event) {
        corenumericyap(event, "#yz30oran");
    });
    $('#cc0oran').keypress(function(event) {
        corenumericyap(event, "#cc0oran");
    });
    $('#cc5oran').keypress(function(event) {
        corenumericyap(event, "#cc5oran");
    });
    $('#cc15oran').keypress(function(event) {
        corenumericyap(event, "#cc15oran");
    });
    $('#cc20oran').keypress(function(event) {
        corenumericyap(event, "#cc20oran");
    });
    $('#cc25oran').keypress(function(event) {
        corenumericyap(event, "#cc25oran");
    });
    $('#cc30oran').keypress(function(event) {
        corenumericyap(event, "#cc30oran");
    });
    $('#cc35oran').keypress(function(event) {
        corenumericyap(event, "#cc35oran");
    });
    $('#cc45oran').keypress(function(event) {
        corenumericyap(event, "#cc45oran");
    });
    $('#cc50oran').keypress(function(event) {
        corenumericyap(event, "#cc50oran");
    });
    $('#cc75oran').keypress(function(event) {
        corenumericyap(event, "#cc77oran");
    });
    //-----------------------------------------------------------


   
   
  


    $.datepicker.setDefaults($.datepicker.regional['tr']);

    $('#TextBox1').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox2').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox3').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox4').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox5').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox6').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox7').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox8').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox9').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox10').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox11').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
    $('#TextBox12').datepicker({
        'changeMonth': true,
        'changeYear': true,
        'dateFormat': "dd.mm.yy"
    });
 
});