<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="genericservisgirispopup.aspx.vb" Inherits="sigorta.genericservisgirispopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Generic Servis Girişleri</title>
  
</style>
</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/genericservisgirispopup.js"></script>   

    
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 
  <div id="tabsbilgi" style="width:100%;">
	
	<ul>
		
		<li><a href="#tabsbilgi1icerik">Temel Bilgileri</a></li>
		<li><a href="#tabsbilgi2icerik">Tabloları</a></li>	
		<li><a href="#tabsbilgi3icerik">Input Parametreleri</a></li>
		<!-- <li><a href="#tabsbilgi4icerik">Output Parametreleri</a></li> -->
		<li><a href="#tabsbilgi5icerik">Kullanıcıları</a></li>	
	</ul>
	
	<form id="form1" runat="server" class="uniForm">

	<asp:HiddenField ID="inn" runat="server" />   
	
	<!-- Rapor Temel Bilgiler -->	
	<div id="tabsbilgi1icerik">
	    
        <fieldset id="Fieldset1">
                   
        <div class="ctrlHolder" id="Div11">
            <label for=""><em>*</em> Servis Adı:</label>
            <asp:TextBox ID="TextBox1" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>

        <div class="ctrlHolder" id="Div2">
            <label for=""><em>*</em> Servis Açıklama:</label>
            <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" 
                class="textboxorta" TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>       
        </div>
       
        
        <div class="ctrlHolder" id="Div13">
            <label for=""><em>*</em> Servis Tipi:</label>
            <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
        
        
        <div class="ctrlHolder" id="Div40">
            <label for=""><em>*</em> SQL:</label>
            <asp:TextBox ID="TextBox14" maxlength="254" runat="server" autocomplete="off" 
                class="textboxorta" TextMode="MultiLine" Width="600px" Height="150px"></asp:TextBox>       
        </div>
        
       
                         
      </fieldset>
      
     </div> 
   <!-- tabsbilgi1 --> 
    
    <!-- Tablolar -->
    <div id="tabsbilgi2icerik">
    
      <fieldset id="Fieldset4" >
       
        <div class="ctrlHolder" id="Div21">
            <label for=""><em>*</em> Tablo Adı:</label>
            <asp:DropDownList ID="DropDownList9" class="textboxorta" runat="server"></asp:DropDownList>            
            <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="tabloaciklama1"></span>  
        </div> 
        
        
          <div class="ctrlHolder" id="Div3">
              <asp:Button ID="Buttongenericservistabloekle" class="button" runat="server" Text="Kaydet" />  
              <asp:Button ID="Buttongenericservistabloiptal" runat="server" class="button" Text="İptal" /> 
        </div> 
             
          
        <asp:Label ID="Labeldurumgenericservistablo" runat="server" Text=""></asp:Label>                   
        <asp:Label ID="Labelgenericservistablo" runat="server" Text=""></asp:Label>
              
      </fieldset>
    
    </div> 
    <!-- tabsbilgi2 --> 
    	
    <!-- Input Parametreler -->
	<div id="tabsbilgi3icerik">
	    
        <fieldset id="Fieldset2">
                      
                
        <div class="ctrlHolder" id="Div8">
            <label for=""><em>*</em> Parametre Adı:</label>
            <asp:TextBox ID="TextBox3" maxlength="100" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
         <div runat="server" id="divoto" class="ctrlHolder">
            <label for=""><em>*</em> Otomatik Ekle:</label>
              <asp:Button ID="Buttonotomatikekle" runat="server" class="button" Text="Benim İçin Otomatik Olarak Parametreleri ve SQL'i Düzenle" /> 
        </div>
        
        
          <div class="ctrlHolder" id="Div1">
            <label for=""><em>*</em> Data Tipi:</label>
             <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
        
        
        
       
        <div class="ctrlHolder">
          <asp:Button ID="Buttongenericservisinputkaydet" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttongenericservisinputiptal" runat="server" class="button" Text="İptal" /> 
        </div> 
   
       
         <asp:Label ID="Labeldurumgenericservisinput" runat="server" Text=""></asp:Label>
         <asp:Label ID="Labelgenericservisinput" runat="server" Text=""></asp:Label>
                
      </fieldset>
      
      
      
    </div> 
   <!-- tabsbilgi3 --> 
    
     
    <!-- Output Paramtreler -->
    <!--
    <div id="tabsbilgi4icerik">    
   
        <fieldset id="Fieldset5" >
           
          
        <div class="ctrlHolder" id="Div10">
            <label for=""><em>*</em> Parametre Adı:</label>
            <asp:TextBox ID="TextBox7" maxlength="100" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
             
      
        <div class="ctrlHolder">
          <asp:Button ID="Buttongenericservisoutputekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttongenericservisoutputiptal" runat="server" class="button" Text="İptal" />
        </div> 
      
       
         <asp:Label ID="Labeldurumgenericservisoutput" runat="server"></asp:Label>
      
         <asp:Label ID="Labelgenericservisoutput" runat="server" Text=""></asp:Label>
        
      </fieldset>
      
    </div> 
    -->
    <!-- tabsbilgi4 --> 
        
    <!-- siralama -->
    <div id="tabsbilgi5icerik">
    
        <fieldset id="Fieldset3">
       
       
        <div class="ctrlHolder" id="Div24">
            <label for=""><em>*</em> Şirket Adı:</label>
            <asp:DropDownList ID="DropDownList12" class="textboxorta" autocomplete="off" 
                runat="server"></asp:DropDownList>   
        </div> 
        
          
         <div class="ctrlHolder">
          <asp:Button ID="Buttongenericserviskullaniciekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttongenericserviskullaniciiptal" runat="server" class="button" Text="İptal" />
        </div> 
             
          
         <asp:Label ID="Labeldurumgenericserviskullanici" runat="server"></asp:Label>
             
          
        <asp:Label ID="Labelgenericserviskullanici" runat="server" Text=""></asp:Label>
              
      </fieldset>
    
    </div>
    <!-- tabsbilgi5 --> 
    
    
    
    <div id="hatadialog"><div id="hatatxt"></div></div>


	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet ve İleri ->" />
          <asp:Button ID="Button2" runat="server" class="button" Text="Servisi Sil" /> 
          <asp:Button ID="Button7" runat="server" class="button" Text="Servisi Tüm Bileşenleri ile Birlikte Sil" /> 
      </div>
      
    </form>   
 		
			
</div> <!-- tabs bilgi -->
  
   
</body> 

    
