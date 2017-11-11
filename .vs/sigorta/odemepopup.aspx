<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="odemepopup.aspx.vb" Inherits="sigorta.odeme" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Ödeme Girişleri</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/odemepopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Ödeme Bilgileri</a></li>
	    <li><a href="#tabsbilgi2icerik">Hesap Hareketleri</a></li>
	    <li><a href="#tabsbilgi3icerik">Ödenmiş Faturalar</a></li>
	    <li><a href="#tabsbilgi4icerik">Ödenmemiş Faturalar</a></li>
	</ul>
	
	<form id="form1" runat="server" class="uniForm">
	
	<asp:HiddenField ID="inn" runat="server" />   
	    
	<div id="tabsbilgi1icerik">

      <fieldset id="Fieldset1" class="inlineLabels">
          
       <div class="ctrlHolder" id="Div3">
            <label for=""><em>*</em> Tür:</label>
            <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server"></asp:DropDownList>
        </div>
        
        
        <div class="ctrlHolder" id="Div9">
            <label for=""><em>*</em> Şirket:</label>
            <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server"></asp:DropDownList>
        </div>
                  
        <div class="ctrlHolder" id="Div4">
            <label for=""><em>*</em> Tarih:</label>
            <asp:TextBox ID="TextBox1" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
        </div> 
                      
        <div class="ctrlHolder" id="Div1">
            <label for=""><em>*</em> Tutar:</label>
            <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
        </div> 
        
        
        <div class="ctrlHolder" id="Div5">
            <label for=""><em>*</em> Gecikme Oranı %:</label>
            <asp:TextBox ID="TextBox3" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
            <asp:Button class="button" ID="Button3" runat="server" Text="Hesapla" />
        </div> 
        
            <div class="ctrlHolder" id="Div2">
            <label for=""><em>*</em> Açıklama:</label>
            <asp:TextBox ID="TextBox4" maxlength="254" runat="server" autocomplete="off" 
                    class="textboxorta" TextMode="MultiLine"></asp:TextBox> 
        </div> 
 
       
      </fieldset>
      
    </div> <!-- tabsbilgi1içerik --> 
    
    
    <div id="tabsbilgi2icerik">
       <asp:Label ID="Label1" runat="server"></asp:Label>              
    </div>
      
    <div id="tabsbilgi3icerik">
       <asp:Label ID="Label3" runat="server"></asp:Label>              
    </div>
    
     <div id="tabsbilgi4icerik">
       <asp:Label ID="Label4" runat="server"></asp:Label>              
    </div>
	   
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
      </div>
      
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
    
