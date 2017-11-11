<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="personelgirispopup.aspx.vb" Inherits="sigorta.personelgirispopup" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Personel Girişleri</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/personelgirispopup.js?rnd=346346"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Personel Bilgileri</a></li>

	</ul>
	
	<form id="form1" runat="server" class="uniForm">
	
	<div id="tabsbilgi1icerik">
	
	     
       <!-- YARDIM ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Yardım</a></h3>
    <div>
        <div class="help">
            <p class="helpinner">Aşağıdaki bilgileri doldurarak personel kaydını yapabilirsiniz.
            </p>
        </div>
    </div>
    </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    <BR/><BR/>
	
      <fieldset id="Fieldset1" class="inlineLabels">
          
         <asp:HiddenField ID="inn" runat="server" /> 
         
         
        <div class="ctrlHolder" id="Div14">
        <h2>Kişi Bilgileri</h2>
        </div>
                                  
        <div class="ctrlHolder" id="Div1">
        <label for=""><em>*</em> Kimlik No:</label>
        <asp:TextBox ID="TextBox1" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
        </div> 
        
    
        <div class="ctrlHolder" id="Div2">
        <label for=""><em>*</em> Ad Soyad:</label>
         <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        <div class="ctrlHolder" id="Div15">
        <label for=""><em>*</em> E-Posta:</label>
         <asp:TextBox ID="TextBox9" maxlength="254" runat="server" autocomplete="off" 
                 class="textboxorta"></asp:TextBox>               
        </div>
        
        
        <div class="ctrlHolder" id="Div3">
        <label for=""><em>*</em> Teknik Personel mi?</label>
                  <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server">
                  </asp:DropDownList>
        </div> 
        
        
        <div class="ctrlHolder" id="Div4">
        <label for=""><em>*</em> TP No:</label>
         <asp:TextBox ID="TextBox3" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>               
        </div> 
        
        
         <div class="ctrlHolder" id="Div7">
        <label for=""><em>*</em> Cep Telefonu:</label>
         <asp:TextBox ID="TextBox5" maxlength="10" runat="server" autocomplete="off" 
                 class="textboxorta"></asp:TextBox>               
        </div>
        
         
       <div class="ctrlHolder" id="Div6">
        <label for=""><em>*</em> Bölge:</label>
               <asp:DropDownList ID="DropDownList3" class="textboxorta" runat="server"></asp:DropDownList>   
        </div>
        
        
        <div class="ctrlHolder" id="Div8">
        <label for=""><em>*</em> Adres:</label>
         <asp:TextBox ID="TextBox4" maxlength="254" runat="server" autocomplete="off" 
                 class="textboxorta" Height="88px" TextMode="MultiLine" Width="350px"></asp:TextBox>               
        </div>
        
        
        <div class="ctrlHolder" id="Div12">
        <label for=""><em>*</em> Belge Tarihi:</label>
         <asp:TextBox ID="TextBox8" maxlength="10" runat="server" autocomplete="off" 
                 class="textboxorta" Height="22px"></asp:TextBox>               
        </div>
        
        
       <div class="ctrlHolder" id="Div13">
       <h2>Eğitim Bilgileri</h2>
        </div>
        
        
        <div class="ctrlHolder" id="Div9">
        <label for=""><em>*</em> Eğitime Katıldı mı?</label>
               <asp:DropDownList ID="DropDownList4" class="textboxorta" runat="server"></asp:DropDownList>   
        </div>
        
        
        <div class="ctrlHolder" id="Div10">
        <label for=""><em>*</em> Eğitim No:</label>
         <asp:TextBox ID="TextBox6" maxlength="10" runat="server" autocomplete="off" 
                 class="textboxorta"></asp:TextBox>               
        </div>
        
         <div class="ctrlHolder" id="Div11">
        <label for=""><em>*</em> Eğitim Verildiği Tarih:</label>
         <asp:TextBox ID="TextBox7" maxlength="10" runat="server" autocomplete="off" 
                 class="textboxorta"></asp:TextBox>               
        </div>
        
        
        <div class="ctrlHolder" id="Div5">
        <label for=""><em>*</em> Onaylanmış mı?:</label>
               <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server"></asp:DropDownList>   
        </div>
        
        
   
        
      </fieldset>
      
    </div> <!-- tabsbilgi3 --> 
    
	   
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
      </div>
      
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
    
