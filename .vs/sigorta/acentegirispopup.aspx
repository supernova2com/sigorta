<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="acentegirispopup.aspx.vb"  ValidateRequest="false" Inherits="sigorta.acentegirispopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Acente Girişleri</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/acentegirispopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Acente Bilgileri</a></li>


	</ul>
	
	<form id="form1" runat="server" class="uniForm">
	
	<div id="tabsbilgi1icerik">

	
      <fieldset id="Fieldset1" class="inlineLabels">
          
        <asp:HiddenField ID="inn" runat="server" />   
                    
        <div class="ctrlHolder" id="Div4">
            <label for=""><em>*</em> Şirket:</label>
            <asp:Label ID="Labelsirket" runat="server" Text=""></asp:Label>
        </div> 
                      
        <div class="ctrlHolder" id="Div1">
            <label for=""><em>*</em> Acente Adı:</label>
            <asp:TextBox ID="TextBox1" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
        </div> 
        
        <div class="ctrlHolder" id="Div2">
            <label for=""><em>*</em> Acente Sicil No:</label>
            <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
        <div class="ctrlHolder" id="Div3">
            <label for=""><em>*</em> Aktif mi?</label>
            <asp:CheckBox ID="CheckBox1" class="textboxkucuk" runat="server" />  
        </div> 
        
        
        <div class="ctrlHolder" id="Div5">
            <label for=""><em>*</em> Merkez mi?</label>
            <asp:DropDownList class="textboxorta" ID="DropDownList1" runat="server"></asp:DropDownList>
        </div> 
        
        
        <div class="ctrlHolder" id="Div6">
            <label for=""><em>*</em> Yetkili Ad Soyad:</label>
            <asp:TextBox ID="TextBox3" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
        <div class="ctrlHolder" id="Div7">
            <label for=""><em>*</em> Yetkili Kimlik No:</label>
            <asp:TextBox ID="TextBox4" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
        <div class="ctrlHolder" id="Div8">
            <label for=""><em>*</em> Yetkili Cep No:</label>
            <asp:TextBox ID="TextBox5" maxlength="10" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
        <div class="ctrlHolder" id="Div9">
            <label for=""><em>*</em> Yetkili E-Mail:</label>
            <asp:TextBox ID="TextBox6" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
        <div class="ctrlHolder" id="Div10">
            <label for=""><em>*</em> Acente Telefon:</label>
            <asp:TextBox ID="TextBox7" maxlength="11" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        <div class="ctrlHolder" id="Div11">
            <label for=""><em>*</em> Acente Fax:</label>
            <asp:TextBox ID="TextBox8" maxlength="11" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
       <div class="ctrlHolder" id="Div12">
            <label for=""><em>*</em> Acente Tipi:</label>
           <asp:DropDownList class="textboxorta" ID="DropDownList2" runat="server"></asp:DropDownList>
        </div> 
               
               
      </fieldset>
      
    </div> <!-- tabsbilgi1içerik --> 
    
    
	   
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
      </div>
      
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
    
