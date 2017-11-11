<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bilgiyonetimgiris.aspx.vb" Inherits="sigorta.bilgiyonetimgiris" %>


<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
<meta charset="utf-8"/>
<title>Kuzey Kıbrıs Türk Cumhuriyeti Sigorta ve Reasürans Şirketler Birliği</title>
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
<!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2.css"/>
<link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2-metronic.css"/>
<!-- END PAGE LEVEL SCRIPTS -->
<!-- BEGIN THEME STYLES -->
<link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
<link href="assets/css/pages/login.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->

<!-- TOAST -->
<script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="assets/plugins/bootstrap-toastr/toastr.min.css"/>
<script src="assets/plugins/bootstrap-toastr/toastr.min.js"></script>
<!-- END TOAST -->


</head>
<!-- BEGIN BODY -->
<body class="login">
<!-- BEGIN LOGO -->
<div class="logo">
	<a href="bilgiyonetimgiris.aspx">
		<img src="assets/img/logo-bilgi.png" alt=""/>
	</a>
</div>
<!-- END LOGO -->
<!-- BEGIN LOGIN -->
<div class="content">
	<!-- BEGIN LOGIN FORM -->
	<form runat="server" id="form1">
	
		<h3 class="form-title">Giriş yapınız</h3>
		
		<span>
            <asp:Label ID="Labeluyari" runat="server" Text=""></asp:Label>
		</span>
	
		<div class="form-group">
			<!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
			<label class="control-label visible-ie8 visible-ie9">Kullanıcı Adı</label>
			<div class="input-icon">
				<i class="fa fa-user"></i>	
                <asp:TextBox class="form-control placeholder-no-fix" ID="TextBox1" 
                    autocomplete="off" placeholder="Kullanıcı Adı" runat="server" 
                    MaxLength="25"></asp:TextBox>
			</div>
		</div>
		<div class="form-group">
			<label class="control-label visible-ie8 visible-ie9">Şifre</label>
			<div class="input-icon">
				<i class="fa fa-lock"></i>
				<asp:TextBox class="form-control placeholder-no-fix" ID="TextBox2" 
                    autocomplete="off" placeholder="Şifre" runat="server" MaxLength="25" 
                    TextMode="Password"></asp:TextBox>
			</div>
		</div>
		
	
		<div class="form-actions">
            <asp:Button class="btn yellow pull-right" ID="Button1" runat="server" Text="Giriş" />
			<i class="m-icon-swapright m-icon-white"></i>
		
		</div>

		<div class="forget-password">
			<p>		 
				<a href="sifremiunuttumbilgi.aspx" id="forget-password">
					Şifremi unuttum 
				</a>	 
			</p>		
		</div>
	
	</form>
	<!-- END LOGIN FORM -->	
</div> <!-- CONTENT-->




<!-- BEGIN COPYRIGHT -->
<div class="copyright">
	 2015 &copy; 
    Kuzey Kıbrıs Türk Cumhuriyeti Sigorta ve Reasürans Şirketler Birliği
</div>
<!-- END COPYRIGHT -->
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
<script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
<script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="assets/scripts/core/app.js" type="text/javascript"></script>
<script src="assets/scripts/custom/login.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->

<!-- BX SLIDER -->
<script type="text/javascript" src="assets/plugins/bxslider/jquery.bxslider.min.js"></script>
<link href="assets/plugins/bxslider/jquery.bxslider.css" rel="stylesheet" />
<script type="text/javascript" src="assets/plugins/bxslider/bxsliderstart.js"></script>

<script type="text/javascript">
		jQuery(document).ready(function() {     
		  App.init();
		});
	</script>
<!-- END JAVASCRIPTS -->
<script type="text/javascript" src="js/core.js"></script>
<script type="text/javascript" src="js/json.js"></script>
<script type="text/javascript" src="js/bilgiyonetimgiris.js"></script>
</body>
<!-- END BODY -->
</html>
