<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="manuelraporpopup.aspx.vb" Inherits="sigorta.manuelraporpopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Manuel Rapor Girişleri</title>
  
</style>
</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/manuelraporpopup.js"></script>   

    
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 
  <div id="tabsbilgi" style="width:100%;">
	
	<ul>
		
		<li><a href="#tabsbilgi1icerik">Temel Bilgileri</a></li>
		<li><a href="#tabsbilgi2icerik">Parametreleri</a></li>	
		<li><a href="#tabsbilgi3icerik">Kullanıcıları</a></li>

	</ul>
	
	<form id="form1" runat="server" class="uniForm">

	<asp:HiddenField ID="inn" runat="server" />   
	
	<!-- Rapor Temel Bilgiler -->	
	<div id="tabsbilgi1icerik">
	    
        <fieldset id="Fieldset1">
                   
        <div class="ctrlHolder" id="Div11">
            <label for=""><em>*</em> Rapor Adı:</label>
            <asp:TextBox ID="TextBox1" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>

        <div class="ctrlHolder" id="Div2">
            <label for=""><em>*</em> Açıklama:</label>
            <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" 
                class="textboxorta" TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>       
        </div>
       
        
        <div class="ctrlHolder" id="Div13">
            <label for=""><em>*</em> Aktif mi?</label>
            <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
        
        
            
        <div class="ctrlHolder" id="Div43">
            <label for=""><em>*</em> Zamanlama:</label>
            <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
        
                           
      </fieldset>
      
     </div> 
   <!-- tabsbilgi1 --> 
    
    <!-- Parametreleri -->
    <div id="tabsbilgi2icerik">
    
      <fieldset id="Fieldset4" >
       
        <div class="ctrlHolder" id="Div21">
            <label for=""><em>*</em> Parametre Ad:</label>
            <asp:TextBox ID="TextBox3" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>         
        </div> 
        
       <div class="ctrlHolder" id="Div4">
            <label for=""><em>*</em> Parametre Değeri:</label>
            <asp:TextBox ID="TextBox4" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>         
        </div> 
        
        
          <div class="ctrlHolder" id="Div3">
              <asp:Button ID="Buttonmanuelraporparametreekle" class="button" runat="server" Text="Ekle" />  
              <asp:Button ID="Buttonmanuelraporparametreiptal" runat="server" class="button" Text="İptal" /> 
        </div> 
             
          
        <asp:Label ID="Labeldurummanuelraporparametre" runat="server" Text=""></asp:Label>                   
        <asp:Label ID="Labelmanuelraporparametre" runat="server" Text=""></asp:Label>
              
      </fieldset>
    
    </div> 
    <!-- tabsbilgi2 Parametreleri --> 
    	
    <!-- Kullanıcıları -->
	<div id="tabsbilgi3icerik">
	    
        <fieldset id="Fieldset2">
                 
         <div class="ctrlHolder" id="Div22">
            <label for=""><em>*</em> Kullanıcı:</label>
            <asp:DropDownList ID="DropDownList3" class="textboxorta" autocomplete="off" 
                 runat="server"></asp:DropDownList>      
        </div> 
        
              
        <div class="ctrlHolder" id="Div7">
            <label for=""><em>*</em> Excel E-Posta:</label>    
            <asp:CheckBox ID="CheckBox1" class="textboxorta" runat="server" />
        </div> 
        
        <div class="ctrlHolder" id="Div8">
            <label for=""><em>*</em> Word E-Posta:</label>
             <asp:CheckBox ID="CheckBox2" class="textboxorta" runat="server" />
        </div>
        
        <div class="ctrlHolder" id="Div9">
            <label for=""><em>*</em> PDF E-Posta:</label>
             <asp:CheckBox ID="CheckBox3" class="textboxorta" runat="server" />
        </div>  
        
   
         
       <div class="ctrlHolder">
          <asp:Button ID="Buttonmanuelraporkullanicikaydet" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttonmanuelraporkullaniciiptal" runat="server" class="button" Text="İptal" /> 
        </div> 
   
       
         <asp:Label ID="Labeldurummanuelraporkullanici" runat="server" Text=""></asp:Label>
         <asp:Label ID="Labelmanuelraporkullanici" runat="server" Text=""></asp:Label>
                
      </fieldset>
      
      
    </div> 
   <!-- Kullanıcıları --> 
    
     
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet ve İleri ->" />
          <asp:Button ID="Button2" runat="server" class="button" Text="Raporu Sil" /> 
          <asp:Button ID="Button3" runat="server" class="button" 
               Text="Bileşenleri İle Birlikte Raporu Sil" /> 
      </div>
      
    </form>   
 		
			
</div> <!-- tabs bilgi -->
  
   
</body> 

    