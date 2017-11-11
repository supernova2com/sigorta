var anasayfaara = function() {

    return {
        //main function to initiate the module
        init: function() {

            $('#plakainput').bind('keypress', function(e) {
         
                    var code = (e.keyCode ? e.keyCode : e.which);
                    //space i engelle
                    if (code == 32) {
                        e.preventDefault();
                    }
                    if (code == 13) {
                        var plakainput;
                        plakainput = $("#plakainput").val();

                        if (plakainput == "") {
                            showtoast('warning', 'Uyarı', 'Plakayı girmediniz.');
                        }
                        if (plakainput != "") {
                            plakaarayonlendir(plakainput);
                        }
                    }
            });


            $('#plakaarabutton').click(function() {
                var plakainput;
                plakainput = $("#plakainput").val();

                if (plakainput == "") {
                    showtoast('warning', 'Uyarı', 'Plakayı girmediniz.');
                }
                if (plakainput != "") {
                    plakaarayonlendir(plakainput);
                }
            });

        }

    };

} ();


function plakaarayonlendir(plaka) {

    var veriler = { plaka: plaka };
    
    $.ajax({
        type: "POST",
        url: "yonetimanaservis.aspx/plakaarayonlendir",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: $.toJSON(veriler),
        async: false,
        success: function(result) {
            window.location.href=result.d;
        },
        error: function(request, status, error) {
                alert('Plakaya göre arama yaparken bir sorun oluştu. Sıkıntı şu:' + request.responseText);
        }
    });

}


 
  
  
		