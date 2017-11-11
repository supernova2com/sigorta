<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="anagaleripopup.aspx.vb" Inherits="sigorta.anagaleripopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head><title>Resim Galerisi</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/anagaleripopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
    

 
  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Galeri Bilgileri</a></li>
	</ul>
	
	 <form id="form1" runat="server" class="uniForm">
	 
	<div id="tabsbilgi1icerik">
	 
	    <table border="0">           
	            
	        <tr>   
	        <td>* Galeri Adı:</td>
	        <td><asp:TextBox ID="TextBox10" runat="server" Width="200px" class="textboxorta"></asp:TextBox></td>
            </tr>
	        
	        
	        <tr>  
	        <td> <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
            <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> </td>  
            <td>&nbsp;</td>
            </tr>
	        
	        
	        <tr>
	        <td colspan="2"> 
            <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>   
            </td> 
            </tr>
            
            
	    </table> 
	
     </div>
    
    </form>
    
  </div> 
			
	
   
    
    </body> 
    

