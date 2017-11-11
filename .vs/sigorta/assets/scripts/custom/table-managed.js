var TableManaged = function() {

    return {

        //main function to initiate the module
        init: function() {

            if (!jQuery().dataTable) {
                return;
            }

            // begin first table
            $('#sample_1').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",  
                "aaSorting": [], 
                "order": [],    
                "oLanguage": {            
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            // second table
            $('#sample_2').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
           
           $('#sample_3').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
           $('#sample_4').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
           $('#sample_5').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
           $('#sample_6').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
            $('#sample_7').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
             $('#sample_8').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
             $('#sample_9').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap",
                "aaSorting": [], 
                "order": [],          
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
             // rapor tablo
            $('#sample_r').dataTable({
                "aLengthMenu": [
                    [50, 100, 150, -1],
                    [50, 100, 150, "Tümü"] // change per page values here
                ],
                // set the initial value
                "bDestroy": true,
                "iDisplayLength": 50,
                "sPaginationType": "bootstrap", 
                "aaSorting": [], 
                "order": [],         
                "oLanguage": {
                    "sSearch": "Ara:",
                    "sProcessing": '<img src="assets/img/loading-spinner-grey.gif"/><span>&nbsp;&nbsp;Yükleniyor...</span>',
                    "sLengthMenu": "<span class='seperator'>|</span>View _MENU_ records",
                    "sInfo": "Toplam _TOTAL_ kayıt",
                    "sInfoEmpty": "Kayıt bulunamadı",
                    "sGroupActions": "_TOTAL_ records selected:  ",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sEmptyTable":  "Tabloda kayıt yok",
                    "sZeroRecords": "Bu özelliklerde herhangi bir kayıt bulunamadı",
                    "sLengthMenu": "_MENU_ kayıt",
                    "sInfoFiltered": "(_MAX_ kayıt içinden filtrelendi)",
                    "oPaginate": {
                        "sPrevious": "Önceki",
                        "sNext": "Sonraki",
                        "sPage": "Sayfa",
                        "sPageOf": "of"
                    }
                },
            });
            
            
           
                
            var table = $('#sample_1').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_2').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_3').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_4').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_5').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_6').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_7').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_8').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            var table = $('#sample_9').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
            
            var table = $('#sample_r').DataTable();
            table.on( 'draw', function () {
                 $(".button").button();
            } );
            
             

            jQuery('#sample_1_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_1_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_2_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_2_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_r_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_r_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_3_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_3_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_4_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_4_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_5_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_5_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_6_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_6_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_7_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_7_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_8_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_8_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            jQuery('#sample_9_wrapper .dataTables_filter input').addClass("form-control input-medium input-inline"); // modify table search input
            jQuery('#sample_9_wrapper .dataTables_length select').addClass("form-control input-xsmall"); // modify table per page dropdown
            
            
            

        }

    }
    
} ();