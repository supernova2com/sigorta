<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="vkolongirispopup.aspx.vb" Inherits="sigorta.vkolongirispopup" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Tablo Kolon Açıklama Girişleri</title>


</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/vkolongirispopup.js?rel=4564674"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Tablo Kolon Açıklamaları</a></li>
	</ul>
	
	<form id="form1" runat="server" class="uniForm">
     
  
    
	<div id="tabsbilgi1icerik">	
    
  <!-- YARDIM ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Yardım</a></h3>
    <div>
        <div class="help">
            <p class="helpinner">Aşağıdaki bilgileri doldurarak veritabanı tablo kolonlarına açıklama girişi yapabilirsiniz.
            </p>
        </div>
    </div>
    </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    
    <br/><br/>

    
        <asp:Label ID="Labelinput" runat="server"></asp:Label>
        
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Tablo Kolon Açıklamalarını Kaydet" /> 
      </div>
      

	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

    
    </body> 