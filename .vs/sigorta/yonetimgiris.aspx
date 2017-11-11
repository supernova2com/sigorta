<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="yonetimgiris.aspx.vb" Inherits="sigorta.yonetimgiris" %>

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
<title>Kuzey Kıbrıs Sigorta Bilgi Merkezi</title>
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
	
</head>
<!-- BEGIN BODY -->
<body class="login">
<!-- BEGIN LOGO -->
<div class="logo">
	<a href="default.aspx">
		<img src="assets/img/logo-big.png" alt=""/>
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
		
		<div id="capkontrol" runat="server">
		<div class="form-group">
			<label class="control-label visible-ie8 visible-ie9">Resim Doğrulama</label>
			<div class="input-icon">
                <cc1:CaptchaControl ID="CaptchaControl1" runat="server" />
				<i class="fa fa-desktop"></i><asp:TextBox class="form-control placeholder-no-fix" ID="TextBox3" 
                    autocomplete="off" placeholder="Captcha" runat="server" MaxLength="10"></asp:TextBox>
			</div>
		</div>
		</div>
		
		<div class="form-actions">
            <asp:Button class="btn green pull-right" ID="Button1" runat="server" Text="Giriş" />
			<i class="m-icon-swapright m-icon-white"></i>
		
		</div>
		<div class="forget-password">
			<p>		 
				<a href="sifremiunuttum.aspx" id="forget-password">
					Şifremi unuttum 
				</a>	 
			</p>		
		</div>
	</form>
	<!-- END LOGIN FORM -->	
	
	
		
</div> <!-- CONTENT-->

<br/><br/>



<div class="container">
<div class="row">

    <ul class="bxslider">
        <li><img src="assets/plugins/bxslider/timage/AIG_LOGO.png"/></li>		
	    <li><img src="assets/plugins/bxslider/timage/akfinans.png"/></li>	
	    <li><img src="assets/plugins/bxslider/timage/anadolu_hayat.png"/></li> 	
	    <li><img src="assets/plugins/bxslider/timage/anadolusigorta.png"/></li>	
	    <li><img src="assets/plugins/bxslider/timage/ascan.png"/></li>	
        <li><img src="assets/plugins/bxslider/timage/aveon.png"/></li>		
        <li><img src="assets/plugins/bxslider/timage/axa_sigorta_logo.png"/></li>
	    <li><img src="assets/plugins/bxslider/timage/BeySigorta.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/cansigorta.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/CapitalInsuranceLogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/commericial.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/creditwest.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/daglilogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/eurocity.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/goldlogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/groupama.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/gunes.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/guven.png"/></li>	  
	    <li><img src="assets/plugins/bxslider/timage/iktisatsigortalogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/kibrissigorta.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/limasol.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/mapfre.png"/> </li>  
	    <li><img src="assets/plugins/bxslider/timage/NorthprimeLogo.png"/></li>
	    <li><img src="assets/plugins/bxslider/timage/secure.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/sekersigorta.png"/> </li>
	    <li><img src="assets/plugins/bxslider/timage/tower.png"/></li>
	    <li><img src="assets/plugins/bxslider/timage/TurkSigortaLogo.png"/></li>
	    <li><img src="assets/plugins/bxslider/timage/universallogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/ziraatlogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/zirvelogo.png"/></li>  
	    <li><img src="assets/plugins/bxslider/timage/zurichlogo.png"/></li>	
    </ul>

</div>
</div>
    
    


<!-- BEGIN COPYRIGHT -->
<div class="copyright">
	 2014 &copy; 
    <asp:Label ID="Labelcopyright" runat="server" Text="Label"></asp:Label><br/>
   
    <asp:literal id="Literalziyaretcisayi" runat="server"></asp:literal>
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
<script type="text/javascript" src="js/yonetimgiris.js"></script>
</body>
<!-- END BODY -->
</html>
