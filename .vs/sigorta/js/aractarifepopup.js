
$(document).ready(function() {

    $('.accordion').accordion({ autoHeight: false });

    $(".button").button();
    $("#tabsbilgi").tabs();

    var currTab = $("input[id$='inn']").val();
    $("#tabsbilgi").tabs("option", "selected", parseInt(currTab));

});




