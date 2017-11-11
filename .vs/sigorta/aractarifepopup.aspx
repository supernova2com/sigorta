<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="aractarifepopup.aspx.vb" Inherits="sigorta.aractarifepopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Araç Tarife Girişleri</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/aractarifepopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Araç Tarife Bilgileri</a></li>

	</ul>
	
	<form id="form1" runat="server" class="uniForm">
	
	<div id="tabsbilgi1icerik">
	
	     
       <!-- YARDIM ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Yardım</a></h3>
    <div>
        <div class="help">
            <p class="helpinner">Araç tarife kodu ve araç tarife adı girerek araç tarife tanımlarını bu ekrandan yapabilirsiniz. 
            Bu ekranda yaptığınız tanımları şirketler için baz fiyatlar eklerken kullanacaksınız. 
            </p>
        </div>
 
    <!-- YARDIM BİTTİ ---------------------- -->
    <br/>

      <fieldset id="Fieldset1" class="inlineLabels">
                 
        <div class="ctrlHolder" id="Div1">
        <label for=""><em>*</em> Araç Tarife Kodu:</label>
        <asp:TextBox ID="TextBox1" maxlength="254" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox> 
        <img border="0" style="margin-top: 5px;" src="images/help.png" onmouseover="ShowHelp('help1', 'Yardım', 
        'Örnek CX1, CY1 gibi')" onmouseout="HideHelp('help1');">
        <div id="help1" style="display:none"></div>
        </div> 
        
        <div class="ctrlHolder" id="Div2">
        <label for=""><em>*</em> Araç Tarife Adı:</label>
        <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
         
        <img border="0" style="margin-top: 5px;" src="images/help.png" onmouseover="ShowHelp('help2', 'Yardım', 
        'Örnek Salon Araç, Motorsiklet gibi')" onmouseout="HideHelp('help2');">
        <div id="help2" style="display:none"></div> 
            <asp:HiddenField ID="inn" runat="server" />   
        </div> 
               
      </fieldset>  
	   
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
      </div>   
      
      </div>
    </div>
         
    </form>		
			
</div>
    
    </body> 
    

