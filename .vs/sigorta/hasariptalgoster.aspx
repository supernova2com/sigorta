<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="hasariptalgoster.aspx.vb" Inherits="sigorta.hasariptalgoster" %>
<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Hasar İptalleri</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/hasariptalgoster.js"></script>   
    
<body style="font-size:75%; margin-top:0px; margin-left:0px;">

  
  <div id="tabsbilgi" style="width:100%;">
	
	<form id="form1" runat="server" class="uniForm">
	   
	   
	    <!-- YARDIM ------------------------------- -->
        <div class="accordion">
        <h3><a href="">Detaylı Bilgiler</a></h3>
        <div>
            <div class="help">
                 <h1>Hasar İptalleri</h1>
	             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>              
	  
	               
	             <br/> 
	             <span id="kapatbutton" class="button">Tamam</span>
	             
	       
	             
            </div>
        </div>
        </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    
    
	 
       
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
    
