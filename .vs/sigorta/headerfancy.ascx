<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="headerfancy.ascx.vb" Inherits="sigorta.headerfancy" %>
<!DOCTYPE html>


<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
<meta charset="utf-8"/>
<title>Mahalle Sakinleri Otomasyon Projesi</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN PACE PLUGIN FILES -->
<script src="assets/plugins/pace/pace.min.js" type="text/javascript"></script>
<link href="assets/plugins/pace/themes/pace-theme-barber-shop.css" rel="stylesheet" type="text/css"/>
<!-- END PACE PLUGIN FILES --><!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="assets/css/googlefonts.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->

<!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2.css"/>
<link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2-metronic.css"/>
<link rel="stylesheet" href="assets/plugins/data-tables/DT_bootstrap.css"/>
<link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-switch/css/bootstrap-switch.min.css"/>
<link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
<link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-toastr/toastr.min.css"/>
<link rel="stylesheet" type="text/css" href="assets/plugins/jquery-notific8/jquery.notific8.min.css"/>
<!-- END PAGE LEVEL STYLES -->

<!-- BEGIN THEME STYLES -->
<link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
<link href="assets/css/custom.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/pages/error.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
<script src="assets/plugins/respond.min.js"></script>
<script src="assets/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
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
<!--
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>
-->
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
			<img src="assets/img/logo.png" alt="logo" class="img-responsive hidden-xs"/>
		</a>
		<!-- END LOGO -->
		<!-- BEGIN RESPONSIVE MENU TOGGLER -->
		<a href="javascript:;" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
			<img src="assets/img/menu-toggler.png" alt=""/>
		</a>
		<!-- END RESPONSIVE MENU TOGGLER -->
		<!-- BEGIN TOP NAVIGATION MENU -->
		<ul class="nav navbar-nav pull-right">
			
			<!-- BEGIN NOTIFICATION DROPDOWN -->
			<li class="dropdown" id="header_notification_bar">
				<a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
					<i class="fa fa-file"></i>
					<span class="badge">
						 <asp:Label ID="Labelokunmamisdosyasayisi" runat="server" Text=""></asp:Label>
					</span>
				</a>
				<ul class="dropdown-menu extended notification">
					<li>
						<p>
						    <asp:Label ID="Labelokunmamisdosyasayisi2" runat="server" Text=""></asp:Label> yeni dosyanız var.
						</p>
					</li>
					<li>
						<ul class="dropdown-menu-list scroller" style="height: 250px;">
							<asp:Label ID="Labeldosyaonizle" runat="server" Text=""></asp:Label>	
						</ul>
					</li>
					<li class="external">
						<a href="gelendosya.aspx">
							 Tüm Dosyalarımı Göster <i class="m-icon-swapright"></i>
						</a>
					</li>
				</ul>
			</li>
			<!-- END NOTIFICATION DROPDOWN -->
			
			<!-- BEGIN INBOX DROPDOWN -->
			<li class="dropdown" id="header_inbox_bar">
				<a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
					<i class="fa fa-envelope"></i>
					<span class="badge">
                        <asp:Label ID="Labelokunmamismesajsayisi2" runat="server" Text=""></asp:Label>
					</span>
				</a>
				<ul class="dropdown-menu extended inbox">
					<li>
						<p>
							  <asp:Label ID="Labelokunmamismesajsayisi" runat="server" Text=""></asp:Label> yeni mesajınız var.
						</p>
					</li>
					<li>
						<ul class="dropdown-menu-list scroller" style="height: 250px;">
                            <asp:Label ID="Labelmsgonizle" runat="server" Text=""></asp:Label>					
						</ul>
					</li>
					<li class="external">
						<a href="gelenmesaj.aspx">
							 Tüm mesajlarımı göster <i class="m-icon-swapright"></i>
						</a>
					</li>
				</ul>
			</li>
			<!-- END INBOX DROPDOWN -->
			
			
			<!-- BEGIN TODO DROPDOWN -->
		
			<li class="dropdown" id="header_task_bar">
				<a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
					<i class="fa fa-bell"></i>
					<span class="badge">
						 <asp:Label ID="Labelokunmamiserrorsayi" runat="server" Text=""></asp:Label>
					</span>
				</a>
				<ul class="dropdown-menu extended tasks">
					<li>
						<p>
							Sistemde <asp:Label ID="Labelokunmamiserrorsayi2" runat="server" Text=""></asp:Label> adet hata oluşmuş
						</p>
					</li>
					<li>
						<ul class="dropdown-menu-list scroller" style="height: 250px;">
							<asp:Label ID="Labelerroronizle" runat="server" Text=""></asp:Label>					
						</ul>
					</li>
					<li class="external">
						<a href="logerror.aspx">
							 Tüm oluşan hataları göster <i class="m-icon-swapright"></i>
						</a>
					</li>
				</ul>
			</li>
		
			<!-- END TODO DROPDOWN -->
			
			<!-- BEGIN USER LOGIN DROPDOWN -->
			<li class="dropdown user">
				<a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
					
					
					<asp:Literal ID="Literalloginresim" runat="server"></asp:Literal>
					
					<span class="username">
                        <asp:Literal ID="Literalloginkullaniciad" runat="server"></asp:Literal>
					</span>
					<i class="fa fa-angle-down"></i>
				</a>
				<ul class="dropdown-menu">
					<li>
						<a href="profile.aspx">
							<i class="fa fa-user"></i> Profilim
						</a>
					</li>
					<!--
					<li>
						<a href="page_calendar.html">
							<i class="fa fa-calendar"></i> Takvim
						</a>
					</li>
					-->
					<li>
						<a href="mesaj.aspx">
							<i class="fa fa-mail-forward"></i> Yeni Mesaj
						</a>
					</li>
					<li>
						<a href="gelenmesaj.aspx">
							<i class="fa fa-envelope"></i> Gelen Kutusu
							<span class="badge badge-danger">
                                <asp:Label ID="Labelokunmamismesajsayisi3" runat="server" Text=""></asp:Label>
							</span>
						</a>
					</li>
					<!--
					<li>
						<a href="#">
							<i class="fa fa-tasks"></i> Görevlerim
							<span class="badge badge-success">
								 7
							</span>
						</a>
					</li>
					<li class="divider">
					</li>
					-->
					<li>
						<a href="javascript:;" id="trigger_fullscreen">
							<i class="fa fa-arrows"></i> Tam Ekran
						</a>
					</li>
					<li>
						<a href="extra_lock.aspx">
							<i class="fa fa-lock"></i> Kilitle
						</a>
					</li>
					<li>
						<a href="logout.aspx">
							<i class="fa fa-key"></i> Çıkış
						</a>
					</li>
				</ul>
			</li>
			<!-- END USER LOGIN DROPDOWN -->
		</ul>
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




