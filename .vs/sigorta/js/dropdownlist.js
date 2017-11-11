$(document).ready(function() {


    $("#z").addClass("active");
    $("#z4").addClass("active");
    

   $('#DropDownList3').change(function() {
        var tabload = document.getElementById('DropDownList1').value;
        var deger = document.getElementById('DropDownList2').value;
        var yazi= document.getElementById('DropDownList3').value;
        if (tabload != "0" && deger!="0" && yazi!="=") {
            sqlolustur(deger,yazi,tabload);
        }
    });




});


  function sqlolustur(deger, yazi, tabload) {

        var veriler = { deger: deger, yazi: yazi, tabload:tabload};

        $.ajax({
            type: "POST",
            url: "dinamikraporservis.aspx/otosqlolustur",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true ,
            data: $.toJSON(veriler),
            success: function(result) {
                $('#TextBox2').val(result.d);
            },
            error: function(request, status, error) {
                alert('Otomatik sql string oluşturamıyorum:' + request.responseText);
            }
        });
    }