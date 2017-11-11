<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="yetkigirispopup.aspx.vb" Inherits="sigorta.yetkigirispopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Yetkiler</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/yetkigirispopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 
  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Kullanıcı Rolleri Yetkileri</a></li>
	</ul>
	
	<form id="form1" runat="server" class="uniForm">
     
  
	<div id="tabsbilgi1icerik">	
    
  <!-- YARDIM ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Yardım</a></h3>
    <div>
        <div class="help">
            <p class="helpinner">Aşağıdan kullanıcı rollerinin yetkilerini ayarlayabilirsiniz.
            </p>
            
            <asp:Label ID="Label1" runat="server" Text="" style="color: #006600"></asp:Label>
            
        </div>
    </div>
    </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    
    <br/><br/>
	
      <fieldset id="Fieldset1" class="inlineLabels">
          
        <asp:HiddenField ID="inn" runat="server" /> 
          
          <asp:Label ID="Labelinput" runat="server"></asp:Label>
                                  
            <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Yetkileri Kaydet" /> 
      </div>
      
    </div> <!-- tabsbilgi1 --> 
    

 
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
 </body> 