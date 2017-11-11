<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pertaracteklifpopup.aspx.vb" Inherits="sigorta.pertaracteklifpopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head><title>Pert Araç Teklifleri</title>

</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/pertaracteklifpopup.js?"></script>  


      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 

  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Verilen Teklifler</a></li>
	</ul>
	
	<form id="form1" runat="server" class="uniForm">
     
   
	<div id="tabsbilgi1icerik">	
      
    <div class="accordion" runat="server">
    <h3><a href="">Verilen Teklifler</a></h3>
    <div>     
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </div>

      </fieldset>
      
      <br/>
        <span id="kapatbutton" class="button">Tamam</span>	
        
      </div>
    
    </div>
     
    <br />
    
     
    </form>	
      
      
</body> 