$(document).ready(function() {

    $(".button").button();
    


    $('#yazdirhasarbutton').click(function() {
        $("table").removeClass('pure-table pure-table-bordered');
        $('#policebaslik').hide();
        $('#Label1').hide();
        $('#aracbilgibaslik').hide();
        $('#Label2').hide();
        $('#zeyilbaslik').hide();
        $('#Label6').hide();
        $('#servislogbaslik').hide();
        $('#Label5').hide();
        $('.button').hide();
        $('#Label1').hide();
        $('#Label2').hide();      
        window.print();
    })


    $('#yazdirpolicebutton').click(function() {
        $("table").removeClass('pure-table pure-table-bordered');
        $('#hasardosyabaslik').hide();
        $('#Label3').hide();
        $('#talepbaslik').hide();
        $('#Label4').hide();
        $('#servislogbaslik').hide();
        $('#Label5').hide();       
        $('.button').hide();
        window.print();
    })


    //$('.accordion').accordion({ autoHeight: false });
    
    $('#kapatbutton').click(function() {
        parent.$.fancybox.close();
    })

   

});