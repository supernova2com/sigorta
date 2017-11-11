$(document).ready(function() {

    //İLÇE DEĞİŞTİĞİNDE BUCAKLARI GÖSTER
    $('#DropDownList1').change(function() {
        var ilcepkey = document.getElementById('DropDownList1').value;
        if (ilcepkey != "0") {
            listele_ilgiliilceninbucaklari(ilcepkey);
        }
    });

});