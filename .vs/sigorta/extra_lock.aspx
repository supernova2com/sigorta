<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="extra_lock.aspx.vb" Inherits="sigorta.extra_lock" %>
<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
<meta charset="utf-8"/>
<title>Ekran Kilidi</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="assets/css/googlefonts.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
<link href="assets/css/pages/lock.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico"/>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body>
<div class="page-lock">
	<div class="page-logo">
		<a class="brand" href="index.html">
			<img src="assets/img/logo-big.png" alt="logo"/>
		</a>
	</div>
	<div class="page-body">
        <asp:Label ID="Labelimage" runat="server" Text=""></asp:Label>
		<div class="page-lock-info">
			<h1>
                <asp:Literal ID="Literaladsoyad" runat="server"></asp:Literal></h1>
			<span class="email">
				 <asp:Literal ID="Literalemail" runat="server"></asp:Literal>
			</span>
			<span class="locked">
				 Kilitli
			</span>
			<!-- <form class="form-inline"> -->
				<div class="input-group input-medium">
					<input type="text" class="form-control" id="password" autocomplete="off" placeholder="Şifre">
					<span class="input-group-btn">
					    <button id="girbutton" class="btn blue icn-only"><i class="m-icon-swapright m-icon-white"></i></button>			
					</span>
				</div>
				<!-- /input-group -->
				<div class="relogin">
					<a href="yonetimgiris.aspx">
					    <asp:Literal ID="Literaladsoyaddegilmi" runat="server"></asp:Literal>
					</a>
				</div>
			<!-- </form> -->
		</div>
	</div>
	<div class="page-footer">
		 2014 &copy; <asp:Label ID="Labelcopyright" runat="server" Text="Label"></asp:Label>
	</div>
</div>
<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
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
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="assets/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
<!-- END PAGE LEVEL PLUGINS -->
<script src="assets/scripts/core/app.js"></script>
<script src="assets/scripts/custom/lock.js"></script>
<script>
jQuery(document).ready(function() {    
   App.init();
   Lock.init();
});
</script>
<!-- END JAVASCRIPTS -->
<script type="text/javascript" src="js/extra_lock.js"></script>
</body>
<!-- END BODY -->
</html>
