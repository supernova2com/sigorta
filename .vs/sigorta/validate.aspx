<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="validate.aspx.vb" Inherits="sigorta.validate" %>

<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="headertemel.ascx" TagName="headertemel" TagPrefix="uc3" %>
<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Kuzey Kıbrıs Sigorta Bilgi Merkezi</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN PACE PLUGIN FILES -->

    <script src="assets/plugins/pace/pace.min.js" type="text/javascript"></script>

    <link href="assets/plugins/pace/themes/pace-theme-barber-shop.css" rel="stylesheet"
        type="text/css" />
    <!-- END PACE PLUGIN FILES -->
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="assets/css/googlefonts.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2-metronic.css" />
    <link rel="stylesheet" href="assets/plugins/data-tables/DT_bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-switch/css/bootstrap-switch.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
    <link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-toastr/toastr.min.css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/jquery-notific8/jquery.notific8.min.css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages/error.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
<script src="assets/plugins/respond.min.js"></script>
<script src="assets/plugins/excanvas.min.js"></script> 
<![endif]-->

    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>

    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>

    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <script src="assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js"
        type="text/javascript"></script>

    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>

    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>

    <script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>

    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>

    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->

    <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>

    <script type="text/javascript" src="assets/plugins/data-tables/jquery.dataTables.js"></script>

    <script type="text/javascript" src="assets/plugins/data-tables/DT_bootstrap.js"></script>

    <script src="assets/plugins/bootstrap-sessiontimeout/jquery.sessionTimeout.js" type="text/javascript"></script>

    <!-- PANEL İÇİN GEREKLİ -->

    <script src="assets/scripts/custom/tasks.js" type="text/javascript"></script>

    <script src="assets/plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>

    <script src="assets/plugins/flot/jquery.flot.min.js" type="text/javascript"></script>

    <script src="assets/plugins/flot/jquery.flot.pie.min.js"></script>

    <script src="assets/plugins/flot/jquery.flot.resize.min.js" type="text/javascript"></script>

    <script src="assets/plugins/flot/jquery.flot.categories.min.js" type="text/javascript"></script>

    <script src="assets/plugins/jquery.pulsate.min.js" type="text/javascript"></script>

    <script src="assets/plugins/bootstrap-daterangepicker/moment.min.js" type="text/javascript"></script>

    <script src="assets/plugins/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>

    <script src="assets/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>

    <script src="assets/plugins/gritter/js/jquery.gritter.js" type="text/javascript"></script>

    <script src="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.js" type="text/javascript"></script>

    <script src="assets/plugins/jquery.sparkline.min.js" type="text/javascript"></script>

    <!-- BEGIN PAGE LEVEL SCRIPTS -->

    <script type="text/javascript" src="assets/scripts/core/app.js"></script>

    <script type="text/javascript" src="assets/scripts/custom/table-managed.js"></script>

    <script src="assets/plugins/bootstrap-toastr/toastr.min.js"></script>

    <script src="assets/scripts/custom/ui-toastr.js"></script>

    <script src="assets/scripts/custom/portlet-draggable.js"></script>

    <script src="assets/scripts/core/app.js"></script>

    <script src="assets/plugins/jquery-notific8/jquery.notific8.min.js"></script>

    <script src="assets/scripts/custom/ui-notific8.js"></script>

    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- JSON -->

    <script type="text/javascript" src="js/json.js"></script>

    <script type="text/javascript">
    jQuery(document).ready(function() {
        TableManaged.init();
    });
    </script>

    <asp:Literal ID="Literalaktifjavascript" runat="server"></asp:Literal>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed page-full-width">
    <!-- BEGIN HEADER -->
    <div class="header navbar navbar-fixed-top">
        <!-- BEGIN TOP NAVIGATION BAR -->
        <div class="header-inner">
            <!-- BEGIN LOGO -->
            <a class="navbar-brand" href="default.aspx">
                <img src="assets/img/logo.png" alt="logo" class="img-responsive hidden-xs" />
            </a>
            <!-- END LOGO -->
            <!-- BEGIN RESPONSIVE MENU TOGGLER -->
            <a href="javascript:;" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <img src="assets/img/menu-toggler.png" alt="" />
            </a>
            <!-- END RESPONSIVE MENU TOGGLER -->
            <!-- BEGIN TOP NAVIGATION MENU -->
            <!-- END TOP NAVIGATION MENU -->
        </div>
        <!-- END TOP NAVIGATION BAR -->
    </div>
    <!-- END HEADER -->
    <div class="clearfix">
    </div>
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
        <div class="page-content-wrapper">
            <div class="page-content">
                <!-- BEGIN FORM-->
                <form id="form1" runat="server" class="form-horizontal">
                <!-- BEGIN CONTENT -->
           
                    <!-- BEGIN PAGE HEADER-->
                    <div class="row">
                        <div class="col-md-12">
                            <!-- DATATABLE PORTLATE-->
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-globe"></i>Belge Bilgileri
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="note note-success">
                                        <p>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
                                    </div>
                                    <div class="note note-info">
                                        <p>
                                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
                                    </div>
                                    <div class="note note-info">
                                        <p>
                                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p>
                                    </div>
                                </div>
                            </div>
                            <!-- DATATABLE PORTLATE-->
                            <!-- GENEL ŞARTLAR PORTLATE-->
                            <div id="portlategenelsartlar" runat="server" class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-globe"></i>Motorlu Araçlar Üçüncü Şahıs Zorunlu Trafik Sigortaları
                                        Genel Şartları
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <p>
                                        <strong>Motorlu Ara&ccedil;lar</strong></p>
                                    <p>
                                        <strong>&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Zorunlu Trafik Sigortaları</strong></p>
                                    <p>
                                        <strong>Genel Şartları</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>Madde 1- AMA&Ccedil;</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Genel Şartların &nbsp;amacı, &nbsp;Değiştirilmiş şekliyle Fasıl 333 Motorlu Ara&ccedil;lar
                                        (&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Sigortası) Yasası veya yerini alan herhangi
                                        bir yasada,&nbsp; motorlu taşıtın yol &uuml;zerinde kullanılması&nbsp; sonucunda
                                        motorlu taşıtı kullanan kişiye y&uuml;klenen hukuki sorumluluk&nbsp; i&ccedil;in&nbsp;
                                        d&uuml;zenlenen Motorlu Ara&ccedil;lar Zorunlu &Uuml;&ccedil;&uuml;nc&uuml; Şahıs
                                        &nbsp;Sigortasına y&ouml;nelik ilgililerin hak ve y&uuml;k&uuml;ml&uuml;l&uuml;klerine
                                        ilişkin usul ve esasların d&uuml;zenlenmesidir.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>Madde 2- &nbsp;SİGORTANIN KAPSAMI</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Değiştirilmiş şekliyle Fasıl 333 Motorlu Ara&ccedil;lar (&Uuml;&ccedil;&uuml;nc&uuml;
                                        Şahıs Sigortası) Yasası kuralları &ccedil;er&ccedil;evesinde, sigorta şirketi ve/veya
                                        sigorta acentesi tarafından d&uuml;zenlenen bir poli&ccedil;ede tanımlanan motorlu
                                        taşıt aracının poli&ccedil;ede belirtilen s&uuml;re i&ccedil;inde &nbsp;motorlu
                                        taşıtın yol &uuml;zerinde kullanılması&nbsp; sonucu veya nedeniyle herhangi bir
                                        kişinin &ouml;l&uuml;m&uuml; veya bedensel zarara uğraması ile ilgili olarak doğacak
                                        herhangi bir y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;, acil tıbbi&nbsp; tedavi masraflarının
                                        &ouml;denmesiyle ilgili y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; ve mala yapılan zararla
                                        ilgili y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; kapsar.&nbsp; &nbsp;&nbsp;</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>Madde 3 &ndash; &Uuml;&Ccedil;&Uuml;NC&Uuml; ŞAHISLARA KARŞI Y&Uuml;K&Uuml;ML&Uuml;L&Uuml;K</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <ol start="3">
                                        <li><strong>(1) Motorlu Taşıt Aracı Kullananların Zorunlu &Uuml;&ccedil;&uuml;nc&uuml;
                                            Şahıs Sigortası </strong></li>
                                    </ol>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        Sigorta şirketi, sigortalı motorlu taşıt aracının &nbsp;yol &uuml;zerinde kullanılması
                                        esnasında neden olduğu kaza neticesinde, &nbsp;Değiştirilmiş şekliyle Fasıl 333
                                        Motorlu Ara&ccedil;lar (&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Sigortası) Yasasında
                                        belirtilmiş olan y&uuml;k&uuml;ml&uuml;l&uuml;k sınırları dahilinde;</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>3.(1 (a) </strong>Herhangi bir kişinin &ouml;l&uuml;m&uuml; veya bedensel
                                        zarara uğraması ile ilgili olarak doğacak herhangi bir &nbsp;y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;,</p>
                                    <p>
                                        <strong>3.(1) (b)</strong> Herhangi bir kişinin acil tıbbi tedavi masraflarının
                                        &ouml;denmesi ile ilgili y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;,</p>
                                    <p>
                                        <strong>3.(1)(c)</strong> Mala/m&uuml;lke verilen zararlarla ilgili y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;,</p>
                                    <p>
                                        tazmin eder.</p>
                                    <p>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                                    <p>
                                        <strong>3.(2)</strong> <strong>Yasal Temsilcilere Tazminat&nbsp; </strong>
                                    </p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Sigorta şirketi, bu poli&ccedil;e ile tazmin edilmeye hak kazanan herhangi bir kişinin
                                        &ouml;lmesi halinde, bu gibi bir şahsın &ouml;l&uuml;m&uuml;nden &ouml;nce uygulanabilecek
                                        şartlara ve sınırlamalara bağlı olarak &nbsp;kişisel yasal temsilcilerini tazmin
                                        eder.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>3.(3) Y&uuml;k&uuml;ml&uuml;l&uuml;k&nbsp; Sınırlarının&nbsp;&nbsp; Uygulanması&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </strong>
                                    </p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Kazanın&nbsp; birden &ccedil;ok kişiye tazminat &ouml;denmesini gerektirmesi halinde,
                                        sigorta şirketinin y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; Fasıl 333 Motorlu Ara&ccedil;lar
                                        (&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Sigortası) Yasası&rsquo;nda belirtilmiş olan
                                        toplam y&uuml;k&uuml;ml&uuml;l&uuml;k sınırlarını ge&ccedil;emez.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>3.(4) Temsiliyet &nbsp;ve Savunma </strong>
                                    </p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        Sigorta Şirketi, kendi tercihine bağlı olarak,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>3.(4)(a)</strong> Tazminat konusu olabilecek herhangi bir &ouml;l&uuml;mle
                                        ilgili olarak herhangi bir resmi soruşturma veya belirleyici araştırmada temsilci
                                        bulundurabilir.</p>
                                    <p>
                                        <strong>3.(4)(b)</strong> Tazminat konusu olabilecek herhangi bir olaya neden olan
                                        eylem ve su&ccedil; iddiası ile ilgili olarak, herhangi bir yetkili mahkemede yapılan
                                        davalarda savunmayı &uuml;stlenebilir.</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>3.(5) Harcamalar&nbsp;&nbsp; </strong>
                                    </p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Sigorta Şirketi, kendi yazılı onayı ile meydana gelen t&uuml;m masraf ve harcamaları
                                        &ouml;der.</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>3.(6) Kazadan Sonra Koruma ve &Ccedil;ekme Masrafları</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Bu poli&ccedil;e ile sigortalanan motorlu&nbsp; taşıt aracı zarar ziyan nedeni ile
                                        hareket edemez hale gelirse, Şirket y&uuml;k&uuml;ml&uuml;l&uuml;k sınırları koşullarına
                                        bağlı olarak motorlu&nbsp; taşıt aracının&nbsp; korunma ve en yakın tamirciye &ccedil;ekilmesi
                                        i&ccedil;in yapılan makul masrafları karşılar.</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 4- Y&Uuml;K&Uuml;ML&Uuml;L&Uuml;K (TEMİNAT) KAPSAMI DIŞINDA KALAN HALLER</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Aşağıdaki haller poli&ccedil;enin y&uuml;k&uuml;ml&uuml;l&uuml;k kapsamı dışındadır:</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>4.(1)</strong> S&ouml;z konusu poli&ccedil;enin sigorta&nbsp; ettiği &nbsp;bir
                                        &nbsp;kişinin, kişilerin veya kişiler grubunun&nbsp; işinde&nbsp; &ccedil;alıştırılan&nbsp;
                                        bir&nbsp; kişinin &ccedil;alıştırılmasından &ouml;t&uuml;r&uuml; ve&nbsp; &ccedil;alıştırıldığı&nbsp;
                                        sırada&nbsp; ortaya&nbsp; &ccedil;ıkan bir olay sonucu &ouml;l&uuml;m&uuml; veya
                                        bedensel zarara uğraması ile ilgili bir y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(2)</strong> Para&nbsp; veya &uuml;cret&nbsp; karşılığı&nbsp; veya&nbsp;
                                        bir&nbsp; iş s&ouml;zleşmesi&nbsp; nedeniyle veya bir&nbsp; iş s&ouml;zleşmesine
                                        dayanarak yolcu taşıyan taşıtlar&nbsp; dışında,&nbsp; tazminat&nbsp;&nbsp;&nbsp;
                                        talebine konu&nbsp; teşkil eden olayın meydana&nbsp; geldiği&nbsp; zaman bir motorlu&nbsp;
                                        taşıt&nbsp; &uuml;zerinde&nbsp; veya&nbsp; i&ccedil;inde&nbsp; taşınmakta olan kişilerin&nbsp;
                                        &ouml;l&uuml;m&uuml; veya&nbsp; bedensel&nbsp; zarara uğraması&nbsp; veya&nbsp;
                                        b&ouml;yle&nbsp; bir taşıta girdiği, taşıt&nbsp; &uuml;zerine&nbsp; &ccedil;ıktığı
                                        veya taşıttan indiği sırada&nbsp; herhangi&nbsp; bir kişinin &ouml;l&uuml;m&uuml;
                                        veya&nbsp; bedensel&nbsp; zarara&nbsp; uğraması nedeniyle doğan sorumluluğu,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(3)</strong> Motorlu taşıt aracına y&uuml;kletilmekte olan veya motorlu
                                        taşıt aracından boşaltılmakta olan veya motorlu taşıt aracıyla taşınmakta olan herhangi
                                        bir eşyaya karşı y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;,&nbsp;</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(4)</strong> Sigorta edilen kişiye veya sigorta edilen kişinin aile efradına
                                        ait olan veya emaneten ellerinde veya g&ouml;zetim veya denetimleri altında bulunan
                                        herhangi bir eşyaya karşı y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(5</strong>) Titreşim veya motorlu taşıt aracının ağırlığı veya taşıdığı
                                        y&uuml;k&uuml;n ağırlığı y&uuml;z&uuml;nden herhangi bir k&ouml;pr&uuml;ye, ara&ccedil;
                                        tartısına, &uuml;zerinden yol ge&ccedil;en kemerlere, yola veya altındaki herhangi
                                        bir şeye yapılan zararlarla ilgili y&uuml;k&uuml;ml&uuml;l&uuml;kleri,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(6)</strong> Tek bir olay sonucu meydana gelen herhangi bir kaza veya
                                        zincirleme kazalar i&ccedil;in Fasıl 333 Motorlu Ara&ccedil;lar (&Uuml;&ccedil;&uuml;nc&uuml;
                                        Şahıs Sigortası) Yasası&rsquo;nda yer alan rakamın&nbsp; &uuml;st&uuml;ndeki mal
                                        zararlarına ilişkin y&uuml;k&uuml;ml&uuml;l&uuml;kleri,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(7)</strong> Yolcu taşıyan toplu taşıma ara&ccedil;ları minib&uuml;s ve
                                        otob&uuml;slerde, tek bir olay sonucu meydana gelen her bir kaza veya zincirleme
                                        kazalar i&ccedil;in olay başına Fasıl 333 Motorlu Ara&ccedil;lar (&Uuml;&ccedil;&uuml;nc&uuml;
                                        Şahıs Sigortası) Yasası&rsquo;nda yer alan rakamın&nbsp; &uuml;st&uuml;ndeki, kişilerin
                                        &ouml;l&uuml;m&uuml; veya bedensel zarara uğraması ile ilgili&nbsp; y&uuml;k&uuml;ml&uuml;l&uuml;kleri,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(8)</strong> Yolcu taşıyan toplu taşıma ara&ccedil;ları minib&uuml;s ve
                                        otob&uuml;sler&nbsp; dışında kalan ara&ccedil;larda&nbsp; tek bir olay sonucu meydana
                                        gelen her bir kaza veya zincirleme kazalar i&ccedil;in olay Fasıl 333 Motorlu Ara&ccedil;lar
                                        (&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Sigortası) Yasası&rsquo;nda yer alan rakamın&nbsp;
                                        &uuml;st&uuml;ndeki, kişilerin &ouml;l&uuml;m&uuml; veya bedensel zarara uğraması
                                        ile ilgili y&uuml;k&uuml;ml&uuml;l&uuml;kleri;</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(9)</strong>Doğrudan veya dolaylı olarak, radyasyon iyonizasyonu veya
                                        herhangi bir n&uuml;kleer yakıttan yayılan radyasyonun bulaşmasından veya n&uuml;kleer
                                        yakıtın yanmasından &ccedil;ıkan n&uuml;kleer atıkların sebep olduğu veya katkıda
                                        bulunduğu herhangi t&uuml;rdeki bir zarardan doğan y&uuml;k&uuml;ml&uuml;l&uuml;kle
                                        ilgili olarak. (Bu istisna ama&ccedil;ları i&ccedil;in yanma her t&uuml;rl&uuml;
                                        n&uuml;kleer f&uuml;zyonu anlatır),</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(10)</strong>Aşağıdaki nedenlerin, doğrudan veya dolaylı olarak, uzaktan
                                        yakından sebep olduğu, katkıda bulunduğu veya bunlardan kaynaklanan veya bunlara
                                        bağlantılı olarak meydana gelen kaza, zarar, ziyan veya y&uuml;k&uuml;ml&uuml;l&uuml;k
                                        (Yasal gereklilikleri yerine getirmek i&ccedil;in gerekli olduğu kadarının dışında
                                        ):</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>4.(10)(a)</strong> Savaş, istila, yabancı d&uuml;şmanlık eylemleri veya
                                        savaş benzeri operasyonlar (savaş ilan edilsin veya edilmesin) i&ccedil; savaş,
                                        isyan, ihtilal, ayaklanma, askeri ve gasp edilmiş iktidar,</p>
                                    <p>
                                        <strong>4.(10)(b)</strong> Grev, lokavt, g&ouml;steri, sivil karışıklık</p>
                                    <p>
                                        <strong>4.(10)(c)</strong> Tevkif, el koyma, m&uuml;sadere veya bunlara teşebb&uuml;s,
                                        tehdit</p>
                                    <p>
                                        <strong>4.(10)(d)</strong> Sel baskını, tayfun, kasırga, hortum, fırtına, volkan
                                        patlaması, deprem veya başka doğal afet veya bu sayılan olaylardan doğrudan veya
                                        dolaylı olarak kaynaklanan olaylar. Bu durumlarda herhangi bir talepte bulunması
                                        halinde, tazminat talep eden kişi kazanın, zarar ziyanın veya y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;n
                                        yukarıda bahsedilen olaylardan veya bunların sonu&ccedil;larından bağımsız meydana
                                        geldiğini ve bunlarla hi&ccedil;bir ilişkisi bulunmadığını veya bunlardan kaynaklanmadığını
                                        veya bunların katkısının bulunmadığını veya bu olayların hi&ccedil;biri ile a&ccedil;ıklanamayacağını
                                        kanıtlamak zorundadır;</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 5&nbsp; - HASAR VE TAZMİNAT</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(1) Rizikonun Ger&ccedil;ekleşmesi Halinde Poli&ccedil;e Sahibinin Y&uuml;k&uuml;ml&uuml;l&uuml;kleri</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Poli&ccedil;e sahibi, rizikonun ger&ccedil;ekleşmesi halinde aşağıdaki hususlar
                                        yerine getirmekle y&uuml;k&uuml;ml&uuml;d&uuml;r:<br />
                                    </p>
                                    <p>
                                        <strong>5.(1)(a)</strong> Rizikonun ger&ccedil;ekleştiğini &ouml;ğrendiği tarihten
                                        itibaren en ge&ccedil; yedi iş g&uuml;n&uuml; &nbsp;i&ccedil;inde sigortacıya &nbsp;bildirimde
                                        bulunmak,<br />
                                        <strong>5.(1)(b)</strong>Sigortalı değilmiş&ccedil;esine gerekli kurtarma ve koruma
                                        &ouml;nlemlerini almak ve bu ama&ccedil;la sigortacı tarafından verilen talimata
                                        elinden geldiği kadar uymak,<br />
                                        <strong>5.(1)(c)</strong> Sigortacının isteği &uuml;zerine, olayın ve zararın nedeni
                                        ile hangi hal ve şartlar altında ger&ccedil;ekleştiğini ve sonu&ccedil;larını tespite,
                                        tazminat y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; ve miktarı ile r&uuml;cu haklarının
                                        kullanılmasına yararlı elde edilmesi m&uuml;mk&uuml;n gerekli bilgi ve belgeleri
                                        gecikmeksizin sigortacıya vermek,<br />
                                        <strong>5.(1)(&ccedil;)</strong> Tazminat y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; ve
                                        miktarı ile r&uuml;cu haklarının saptanması i&ccedil;in sigortacının veya yetkili
                                        kıldığı temsilcilerinin sigorta kapsamında yer alan konularda ve bunlarla ilgili
                                        belgeler &uuml;zerinde yapacakları araştırma ve incelemelere izin vermek,</p>
                                    <p>
                                        <strong>5.(1)(d)</strong> Zarardan dolayı t&uuml;m mektuplar talep ilanları celpnameler
                                        ve &ccedil;ağrılar alınır alınmaz ve bu t&uuml;r herhangi bir olayla ilgili olarak
                                        yaklaşmakta olan dava soruşturmaları hakkında bilgi sahibi olunur olunmaz şirkete
                                        bildirmek veya iletmek,<br />
                                        <strong>5.(1)(e)</strong> Sigorta konusu ile ilgili başka sigorta s&ouml;zleşmeleri
                                        varsa bunları sigortacıya bildirmek,</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(2) </strong><strong>Rizikonun Ger&ccedil;ekleşmesi Halinde Sigorta Şirketinin
                                            Hakları ve Y&uuml;k&uuml;ml&uuml;l&uuml;kleri</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(2)(a)</strong>Sigortacı, &nbsp;zarar ve ziyan talebinde bulunan &uuml;&ccedil;&uuml;nc&uuml;
                                        kişlerle doğrudan doğruya temasa ge&ccedil;erek anlaşma hakkına sahiptir. Ancak
                                        sigortacının yazılı izni olmadık&ccedil;a poli&ccedil;e sahibi&nbsp; tazminat talebini
                                        kısmen veya tamamen kabule yetkili olmadığı gibi zarar g&ouml;renlere sigorta şirketi
                                        adına herhangi bir tazminat &ouml;demesinde de bulunamaz bu t&uuml;r kişilere yaptığı
                                        &ouml;demeleri sigorta şirketinden talep edemez.</p>
                                    <p>
                                        <strong>5.(2)(b)</strong> Sigorta Şirketi;</p>
                                    <p>
                                        <strong>5.(2)(b)(i)</strong> Talep edilen tazminat ve giderleri hak sahibinin, kaza
                                        ve zarara ilişkin tesbit tutanağını veya sigorta eksper veya bilirkişi raporunu
                                        ve gerekli diğer belgeleri sigorta şirketinin merkezine veya sigortanın yapıldığı
                                        acenteye ilettiği tarihten itibaren,</p>
                                    <p>
                                        <strong>5.(2)(b)(ii)</strong> Yaralanan kimselerin ilkyardım, muayene ve kontrol
                                        veya bu yaralanmadan &ouml;t&uuml;r&uuml; ayakta hastahane, klinik ve diğer yerlerdeki
                                        tedavi giderleri ile tedavinin gerektirdiği diğer giderleri, belgeleri ile birlikte
                                        sigorta şirketinin merkezine veya sigortanın yapıldığı acenteye ilettiği tarihten
                                        itibaren, &ouml;demekle y&uuml;k&uuml;ml&uuml; olur.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(3)</strong> Hasar halinde, hasar g&ouml;ren par&ccedil;a, onarımı m&uuml;mk&uuml;n
                                        değilse veya eşdeğeri par&ccedil;a ile değiştirilme imkanı yok ise yenisi ile değiştirilir.
                                        Bu durumda motorlu ara&ccedil;ta bir kıymet artışı meydana gelse dahi bu fark tazminat
                                        miktarından indirilemez.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(4) </strong>Dava a&ccedil;ılması halinde, sigorta poli&ccedil;esinde
                                        yazılı limitlere kadar davanın takip ve idaresi sigorta şirketine ait olup, poli&ccedil;e
                                        sahibi sigortacının g&ouml;stereceği avukata gereken vekaletnameyi vermek zorundadır.
                                        Sigortacı dava masrafları ile kendi atadığı avukatlık &uuml;cretlerini &ouml;demekle
                                        y&uuml;k&uuml;ml&uuml;d&uuml;r. Şu kadar ki h&uuml;kmolunan tazminat poli&ccedil;ede
                                        yazılı sorumluluk limitlerini aşarsa, sigorta şirketinin sorumluluğu poli&ccedil;ede
                                        yazılı y&uuml;k&uuml;ml&uuml;l&uuml;k limitlerine kadardır. &nbsp;</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(5</strong>) Sigortalı ve eylemlerinden sorumlu tutulduğu kimseler aleyhine
                                        cezai kovuşturmaya ge&ccedil;ilmesi halinde, sanığın izni ile sigorta şirketi de
                                        savunmaya iştirak eder. Bu takdirde, sigorta şirketi yalnız kendi atadığı avukatın
                                        giderlerini &ouml;der.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(6)</strong> Cezai kovuşturmadan doğan t&uuml;m giderler ile muhtemel
                                        para cezaları sigorta teminatı dışındadır.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(7) Sigortacının Halefiyeti</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Sigortacı, &ouml;dediği tazminat tutarınca, hukuken sigortalının yerine ge&ccedil;er.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(8) Bazı Şartlardan Ka&ccedil;ınma ve Geri Alma (R&uuml;cu) Hakkı</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>5.(8)(a)</strong> Sigorta Şirketinin, bu poli&ccedil;enin şartları gereği
                                        veya ilgili yasalarda y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml; bulunmayan bir sebepten
                                        bir miktarı &uuml;&ccedil;&uuml;nc&uuml; şahıslara &ouml;demek zorunda kalması halinde,
                                        motorlu aracı kullanan s&uuml;r&uuml;c&uuml; bu miktarı şirkete geri &ouml;der.</p>
                                    <p>
                                        <strong>5.(8)(b)</strong> Motorlu aracın, &nbsp;alkoll&uuml; i&ccedil;kilerin etkisi
                                        altında olup, g&uuml;venli s&uuml;rme yeteneklerini kaybetmiş olan veya uyuşturucu
                                        veya keyif verici maddeler almış kimseler tarafından sevk ve idare edilmesi halinde
                                        sebebiyet verilen zarar ve ziyana ilişkin talepler sigortacı tarafından &nbsp;&uuml;&ccedil;&uuml;nc&uuml;
                                        kişilere &ouml;dendikten sonra meydana gelen hasarlar motorlu aracı kullanan s&uuml;r&uuml;c&uuml;ye
                                        r&uuml;cu edilir</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 6- TAHKİM&nbsp; KOMİSYONU</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Poli&ccedil;e sahibi veya sigorta s&ouml;zleşmesinden menfaat sağlayan ger&ccedil;ek
                                        veya t&uuml;zel kişiler, riski &uuml;stlenen&nbsp; taraf&nbsp; arasında &nbsp;poli&ccedil;e
                                        ve/veya s&ouml;zleşmeden kaynaklanan herhangi bir uyuşmazlık halinde &nbsp;Değiştirilmiş
                                        şekliyle 60/2010 sayılı&nbsp; Sigorta&nbsp; Hizmetleri (D&uuml;zenleme ve Denetim)
                                        Yasasının 67&rsquo;inci &nbsp;maddesine uyarınca &nbsp;Sigorta Tahkim Komisyonuna
                                        başvurma hakkına sahiptirler.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>Madde 7- &Ccedil;EŞİTLİ H&Uuml;K&Uuml;MLER</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>7.(1) &nbsp;Sigorta &Uuml;cretinin &Ouml;denmesi ve Sigortacının Sorumluluğunun
                                            Başlaması</strong></p>
                                    <p>
                                        Sigorta priminin tamamı peşin &ouml;denir ve sorumluluk başlar.</p>
                                    <p>
                                        <strong>7.(2) Poli&ccedil;e Sahibinin S&ouml;zleşme Yapıldığı Sırada Beyan Y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>7.(2)(a) </strong>Sigorta şirketi, bu s&ouml;zleşmeyi, poli&ccedil;e sahibinin
                                        teklifnamede, teklifname yoksa poli&ccedil;e ve eklerinde yazılı beyanına dayanarak
                                        yapmıştır.</p>
                                    <p>
                                        <strong>7.(2)(b)</strong>Poli&ccedil;e sahibi veya tazmin edilmeyi talep eden herhangi
                                        bir kişinin herhangi bir şeyin yapılması veya yapılmamasına ilişkin bu &nbsp;poli&ccedil;enin
                                        &nbsp;şartlarına riayet &nbsp;etmesi veya yerine &nbsp;getirmesi ve teklifteki beyan
                                        ve &nbsp;cevapların &nbsp;doğruluğu, şirketin &nbsp;&nbsp;bu poli&ccedil;e uyarınca
                                        herhangi bir y&uuml;k&uuml;ml&uuml;l&uuml;k ile ilgili &ouml;deme yapması i&ccedil;in
                                        &ouml;rnek şartları temsil eder.<br />
                                    </p>
                                    <p>
                                        <strong>7.(3)Poli&ccedil;e Sahibinin &nbsp;Beyanı Ger&ccedil;eğe Aykırı veya Eksik ise,
                                            Sigorta şirketinin s&ouml;zleşmeyi daha ağır şartlarla yapmasını gerektirecek hallerde:<br />
                                            <br />
                                        </strong>
                                    </p>
                                    <ol start="7">
                                        <li><strong>(3)(a)</strong>Sigorta şirketi durumu &ouml;ğrendiği tarihten itibaren yedi
                                            iş g&uuml;n&uuml; i&ccedil;inde prim farkının &ouml;denmesi hususunu poli&ccedil;e
                                            sahibine ihtar eder sigortalı talep edilen prim farkını ihtarın tebliğ tarihini
                                            izleyen yedi iş g&uuml;n&uuml; i&ccedil;inde prim farkına &ouml;demez veya &ouml;demeyeceğini
                                            bildirirse s&ouml;zleşme Değiştirilmiş şekliyle Fasıl 333 Motorlu Ara&ccedil;lar
                                            (&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Sigortası) Yasası&rsquo;nda belirtilen koşullara
                                            uygun bir şekilde feshedilir.<br />
                                            <strong>7. (3)(b)</strong>S&ouml;zleşmenin feshi halinde feshin h&uuml;k&uuml;m
                                            ifade ettiği tarihe kadar ge&ccedil;en s&uuml;renin primi, g&uuml;n esası &uuml;zerinden
                                            hesap edilir ve fazlası geri verilir. Prim farkının s&uuml;resinde istenmemesi halinde
                                            fesih hakkı d&uuml;şer.</li>
                                        <li><strong>(3)(c)</strong>Ger&ccedil;eğe aykırı beyan hali zararı doğuran olayın meydana
                                            gelmesinden sonra &ouml;ğrenilmişse sigorta şirketi bu zarardan dolayı &ouml;denmiş
                                            ve &ouml;denecek tazminatın kasten yapılmış olması halinde tamamını, kasıt olmaması
                                            halinde ise alınan prim ile alınması gereken prim arasındaki oran kadar kısmı dışında
                                            kalan kısım i&ccedil;in poli&ccedil;e sahibine r&uuml;cu edebilir.<br />
                                        </li>
                                    </ol>
                                    <p>
                                        <strong>7.(4) Sigortalının Sigorta S&uuml;resi İ&ccedil;inde İhbar Y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;
                                            ve Sonu&ccedil;ları</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>7.(4)(a)</strong>S&ouml;zleşmenin yapılmasından sonra, teklifnamede, teklifname
                                        yoksa poli&ccedil;e ve eklerinde belirtilen rizikoların artacak şekilde değişmesi
                                        halinde poli&ccedil;e sahibi yedi iş g&uuml;n&uuml; i&ccedil;inde durumu sigorta
                                        şirketine bildirmekle y&uuml;k&uuml;ml&uuml;d&uuml;r.</p>
                                    <p>
                                        <strong>7(4)(b)</strong> Değişiklik, sigortacının s&ouml;zleşmeyi yapmamasını veya
                                        daha ağır şartlarla yapmasını gerektiren hallerde ise;<br />
                                        <strong>7(4)(b)(i) </strong>Prim farkını talep etmek suretiyle s&ouml;zleşmeyi y&uuml;r&uuml;rl&uuml;kte
                                        tutar. Poli&ccedil;e sahibi, talep edilen prim farkını yedi g&uuml;n i&ccedil;inde
                                        kabul edip prim farkını &ouml;demediği takdirde s&ouml;zleşme Değiştirilmiş şekliyle
                                        Fasıl 333 Motorlu Ara&ccedil;lar (&Uuml;&ccedil;&uuml;nc&uuml; Şahıs Sigortası)
                                        Yasası&rsquo;nda belirtilen koşullara uygun bir şekilde feshedilir.<strong><br />
                                            7(4)(b)(ii)</strong>Feshin h&uuml;k&uuml;m ifade ettiği tarihe kadar ge&ccedil;en
                                        s&uuml;renin primi, g&uuml;n esası &uuml;zerinden hesap edilir ve fazlası geri verilir.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>7.(5)Birden &Ccedil;ok Sigorta</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Bu poli&ccedil;e uyarınca talep hakkı doğduğu sırada aynı y&uuml;k&uuml;ml&uuml;l&uuml;ğ&uuml;
                                        kapsayan başka bir sigorta bulunması halinde,&nbsp; talebin ve bununla ilgili masraf
                                        ve harcamalar sigorta şirketleri tarafından eşit oranda &ouml;denir.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>7.(6) Sigortalı Aracın M&uuml;lkiyetin Değişmesi</strong></p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>7.(6)(a)</strong>Sigorta s&ouml;zleşmesi, s&ouml;zleşmeye taraf olan poli&ccedil;e
                                        sahibini takip eder. Poli&ccedil;e sahibi sahip olduğu yeni araca ilişkin bilgileri
                                        motorlu aracın m&uuml;lkiyeti adına ge&ccedil;tiği anda sigortacıya bildirir. Poli&ccedil;e
                                        ara&ccedil; sınıfında herhangi bir değişiklik olması durumunda veya poli&ccedil;e
                                        ve eklerinde belirtilen rizikoların artacak şekilde değişmesi halinde sigortalı
                                        prim farkını peşin olarak &ouml;demekle y&uuml;k&uuml;ml&uuml;d&uuml;r. Rizikonun
                                        azalacak şekilde değişmesi halinde prim iadesi yapılır.</p>
                                    <p>
                                        <strong>7.(6)(b)</strong>S&ouml;zleşme s&uuml;resi i&ccedil;inde; sigortalı aracın
                                        m&uuml;lkiyetinin değişmesi halinde (&ouml;l&uuml;m hali hari&ccedil;) sigorta s&ouml;zleşmesi
                                        fesih olur.<br />
                                        <strong>7.(6)(c)</strong>Feshin h&uuml;k&uuml;m ifade ettiği tarihe kadar ge&ccedil;en
                                        s&uuml;renin primi, g&uuml;n esası &uuml;zerinden hesap edilir ve fazlası Sigortalıya
                                        verilir.</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 8- TEBLİĞ ve İHBARLAR</strong></p>
                                    <p>
                                        <em>&nbsp;</em></p>
                                    <p>
                                        <em><strong>8.(1)</strong></em><em> Poli&ccedil;e sahibinin bildirimleri, &nbsp;sigorta
                                            şirketinin merkezine imza karşılığı yazılı olarak veya iadeli taahh&uuml;tl&uuml;
                                            mektupla yapılır.<br />
                                            <strong>8.(2)</strong> Sigortacının bildirimleri de poli&ccedil;e sahibinin poli&ccedil;ede
                                            g&ouml;sterilen adresine veya bu adres değişmişse son bildirilen adresine aynı surette
                                            yapılır.<br />
                                            <strong>8.(3)</strong> Taraflara imza karşılığında elden verilen mektupla yapılan
                                            bildirimler de taahh&uuml;tl&uuml; mektup h&uuml;km&uuml;ndedir.<br />
                                            <br />
                                        </em>
                                    </p>
                                    <p>
                                        <strong>Madde 9- TİCARİ ve MESLEKİ SIRLARIN&nbsp; SAKLI TUTULMASI</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Sigortacı ve sigortacı adına hareket edenler bu s&ouml;zleşmenin yapılması dolayısıyla
                                        poli&ccedil;e sahibine ait olarak &ouml;ğreneceği ticari ve mesleki sırların saklı
                                        tutulmamasından doğacak zararlardan sorumludurlar. Bu hususta 60/2010 sayılı yasa
                                        tahtında oluşturulan Sigorta Bilgi Merkezi&rsquo;ne sigorta şirketi tarafından paylaşılan
                                        bilgilerden dolayı sigorta ettiren sigorta şirketi hakkında şikayette bulunamaz.</p>
                                    <p>
                                        <strong>&nbsp;</strong></p>
                                    <p>
                                        <strong>Madde 10- Yetkili Mahkeme</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Yetkili mahkeme Kuzey Kıbrıs T&uuml;rk Cumhuriyeti Mahkemeleridir</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 11- ZAMANAŞIMI</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Sigorta s&ouml;zleşmesinden doğan b&uuml;t&uuml;n talepler poli&ccedil;enin tanzim
                                        edildiği tarihte y&uuml;r&uuml;rl&uuml;kte olan ilgili yasalar &ccedil;er&ccedil;evesinde
                                        zaman aşımına uğrar.</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 12 &ndash; &Ouml;ZEL ŞARTLAR</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        S&ouml;zleşmeye bu genel şartlara ve varsa bunlarla ilişkin klozlara aykırı olmamak
                                        kaydıyla &ouml;zel şartlar konulabilir.<strong><br />
                                            &nbsp;</strong></p>
                                    <p>
                                        <strong>Madde 13 &ndash;SİGORTANIN&nbsp; COĞRAFİ SINIRI </strong>
                                    </p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Bu sigorta,&nbsp; Kuzey Kıbrıs T&uuml;rk Cumhuriyeti&nbsp; sınırları i&ccedil;inde
                                        ge&ccedil;erlidir.</p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        <strong>Madde 14-&nbsp; SİGORTANIN&nbsp; BAŞLANGICI&nbsp; ve SONU</strong></p>
                                    <p>
                                        &nbsp;</p>
                                    <p>
                                        Sigorta, poli&ccedil;enin &uuml;zerinde belirtileni tarih ve saat itibarıyla ge&ccedil;erlilik
                                        kazanır ve sona erme tarihinde saat &ouml;glen 12.00&rsquo;de sona erer. &Ouml;nceden
                                        d&uuml;zenlenen sigorta poli&ccedil;eleri başlangı&ccedil; tarihinde &nbsp;&ouml;glen
                                        saat 12.00 de ge&ccedil;erlilik kazanır.<br />
                                    </p>
                                </div>
                            </div>
                            <!-- DATATABLE PORTLATE-->
                            <!-- DATATABLE PORTLATE-->
                            <div id="portlate" runat="server" class="portlet box red">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-barcode"></i>Belge Üzerinde Kullanabileceğiniz QRCODE Örnekleri
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <img runat="server" id="barkodimg1" />
                                        </div>
                                        <div class="col-md-3">
                                            <img runat="server" id="barkodimg2" />
                                        </div>
                                        <div class="col-md-3">
                                            <img runat="server" id="barkodimg3" />
                                        </div>
                                        <div class="col-md-3">
                                            <img runat="server" id="barkodimg4" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- DATATABLE PORTLATE-->
                        </div>
                        <!-- col md12 -->
                    </div>
                    <!-- row -->
         
         
                </form>
            </div>
        </div>
        </div>
        <uc2:footer ID="footer" runat="server" />
        <uc3:headertemel ID="headertemel" runat="server" />
