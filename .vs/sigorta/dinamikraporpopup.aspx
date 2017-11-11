<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dinamikraporpopup.aspx.vb" ValidateRequest="false"  Inherits="sigorta.dinamikraporpopup" %>
<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Dinamik Rapor Girişleri</title>
  
</style>
</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/dinamikraporpopup.js"></script>   

    
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 
  <div id="tabsbilgi" style="width:100%;">
	
	<ul>		
		<li><a href="#tabsbilgi1icerik">Temel Bilgileri</a></li>
		<li><a href="#tabsbilgi2icerik">Rapor Tabloları</a></li>	
		<li><a href="#tabsbilgi3icerik">Gösterilecek Alanlar</a></li>
		<li><a href="#tabsbilgi4icerik">Koşullar</a></li>
		<li><a href="#tabsbilgi5icerik">Sıralama</a></li>	
		<li><a href="#tabsbilgi6icerik">Gruplama</a></li>	
		<li><a href="#tabsbilgi7icerik">Grup Rakam</a></li>
		<li><a href="#tabsbilgi8icerik">Grafik</a></li>
		<li><a href="#tabsbilgi9icerik">Zamanlama</a></li>	
		<li><a href="#tabsbilgi10icerik">Erişim</a></li>
	    <li><a href="#tabsbilgi11icerik">Sınırlandırma</a></li>			
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
            <label for=""><em>*</em> Rapor Tipi:</label>
            <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
        
        
        <div class="ctrlHolder" id="Div40">
            <label for=""><em>*</em> SQL:</label>
            <asp:TextBox ID="TextBox14" maxlength="254" runat="server" autocomplete="off" 
                class="textboxorta" TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>       
        </div>
        
        
        <div class="ctrlHolder" id="Div43">
            <label for=""><em>*</em> Arabirim Oluşturulsun mu?</label>
            <asp:DropDownList ID="DropDownList25" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
        
        
        <div class="ctrlHolder" id="Div51">
            <label for=""><em>*</em> Toplamlar Gösterilsin mi?</label>
            <asp:DropDownList ID="DropDownList29" class="textboxorta" runat="server"></asp:DropDownList>      
        </div>
      
                         
      </fieldset>
      
     </div> 
   <!-- tabsbilgi1 --> 
    
    <!-- Kullanılacak Tablolar -->
    <div id="tabsbilgi2icerik">
    
      <fieldset id="Fieldset4" >
       
        <div class="ctrlHolder" id="Div21">
            <label for=""><em>*</em> Tablo Adı:</label>
            <asp:DropDownList ID="DropDownList9" class="textboxorta" runat="server"></asp:DropDownList>            
            <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="tabloaciklama1"></span>  
        </div> 
        
        
          <div class="ctrlHolder" id="Div3">
              <asp:Button ID="Buttonkullanilacaktabloekle" class="button" runat="server" Text="Ekle" />  
        </div> 
             
          
        <asp:Label ID="Labeldurumkullanilacaktablo" runat="server" Text=""></asp:Label>                   
        <asp:Label ID="Labelkullanilacaktablo" runat="server" Text=""></asp:Label>
              
      </fieldset>
    
    </div> 
    <!-- tabsbilgi2 --> 
    	
    <!-- gösterilecek alanlar -->
	<div id="tabsbilgi3icerik">
	    
        <fieldset id="Fieldset2">
                 
         <div class="ctrlHolder" id="Div22">
            <label for=""><em>*</em> Tablo:</label>
            <asp:DropDownList ID="DropDownList10" class="textboxorta" autocomplete="off" 
                 runat="server" AutoPostBack="True"></asp:DropDownList> 
                  <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="tabloaciklama2"></span>     
        </div> 
        
              
        <div class="ctrlHolder" id="Div7">
            <label for=""><em>*</em> Alan Adı:</label>
            <asp:DropDownList ID="DropDownList2" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
            <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="kolonaciklama2"></span>     
        </div> 
        
        <div class="ctrlHolder" id="Div8">
            <label for=""><em>*</em> Sql Alias:</label>
            <asp:TextBox ID="TextBox3" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div9">
            <label for=""><em>*</em> Kolon Başlığı:</label>
            <asp:TextBox ID="TextBox4" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>  
        
        <div class="ctrlHolder" id="Div1">
            <label for=""><em>*</em> Sırası:</label>
            <asp:TextBox ID="TextBox5" maxlength="2" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>       
        </div> 
        
        
         <div class="ctrlHolder" id="Div52">
            <label for=""><em>*</em> Ek Kelime:</label>
            <asp:DropDownList ID="DropDownList30" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div> 
        
        <div class="ctrlHolder">
          <asp:Button ID="Buttongosterilecealankaydet" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttongosterilecealaniptal" runat="server" class="button" Text="İptal" /> 
           <span id="siralamabutton" class="button">Sıralama Seçenekleri</span> 
        </div> 
   
       
         <asp:Label ID="Labeldurumgosterilecekfield" runat="server" Text=""></asp:Label>
         <asp:Label ID="Labelgosterilecekfield" runat="server" Text=""></asp:Label>
                
      </fieldset>
      
      
      	    <div id="hatadialog2">
                <asp:Label ID="Labelsiralamagosterilecekfield" runat="server"></asp:Label> 
			</div>
      
    </div> 
   <!-- tabsbilgi3 --> 
    
     
    <!-- koşullar -->
    <div id="tabsbilgi4icerik">    
   
        <fieldset id="Fieldset5" >
           
         <div class="ctrlHolder" id="Div23">
            <label for=""><em>*</em> Koşul Tablo Adı:</label>
            <asp:DropDownList ID="DropDownList11" class="textboxorta"  autocomplete="off" 
                 runat="server" AutoPostBack="True"></asp:DropDownList> 
                 <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="tabloaciklama4"></span>           
          </div>
         
         <div class="ctrlHolder" id="Div16">
            <label for=""><em>*</em> Alan Adı:</label>
            <asp:DropDownList ID="DropDownList3" class="textboxorta"  autocomplete="off" runat="server"></asp:DropDownList>            
            <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="kolonaciklama4"></span>   
          </div>
            
        <div class="ctrlHolder" id="Div5">
            <label for=""><em>*</em> Koşul Operatörü:</label>
            <asp:DropDownList ID="DropDownList4" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
           
         <div class="ctrlHolder" id="Div6">
            <label for=""><em>*</em> Run-Time (Arabirim):</label>
            <asp:DropDownList ID="DropDownList5" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>          
         </div> 
          
        <div class="ctrlHolder" id="Div10">
            <label for=""><em>*</em> Değer:</label>
            <asp:TextBox ID="TextBox7" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div38">
            <label for=""><em>*</em> Arabirim Tipi:</label>
            <asp:DropDownList ID="DropDownList22" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
        
         <div class="ctrlHolder" id="Div39">
            <label for=""><em>*</em> Liste:</label>
            <asp:DropDownList ID="DropDownList23" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
        
           <div class="ctrlHolder" id="Div36">
            <label for=""><em>*</em> Arabirim Form Etiketi (Adı):</label>
            <asp:TextBox ID="TextBox12" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
           
        <div class="ctrlHolder" id="Div12">
            <label for=""><em>*</em> Mantık Operatörü:</label>
            <asp:DropDownList ID="DropDownList6" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
        
        <div class="ctrlHolder" id="Div4">
            <label for=""><em>*</em> Sıra:</label>
            <asp:TextBox ID="TextBox6" maxlength="50" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div45">
            <label for=""><em>*</em> Koşul Grup No:</label>
            <asp:TextBox ID="TextBox17" maxlength="50" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>       
        </div>
        
       <div class="ctrlHolder" id="Div46">
            <label for=""><em>*</em> Grup Mantık Operatörü:</label>
            <asp:DropDownList ID="DropDownList26" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
        
         <div class="ctrlHolder" id="Div47">
            <label for=""><em>*</em> Sezon Değişkeni:</label>
            <asp:TextBox ID="TextBox18" maxlength="50" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>        
        </div>
        
        
        <div class="ctrlHolder">
          <asp:Button ID="Buttonkosulfieldekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttonkosulfieldiptal" runat="server" class="button" Text="İptal" />
        </div> 
      
         <asp:Label ID="Labelkosulfield" runat="server" Text=""></asp:Label>
        
      </fieldset>
      
    </div> 
    <!-- tabsbilgi4 --> 
        
    <!-- siralama -->
    <div id="tabsbilgi5icerik">
    
        <fieldset id="Fieldset3">
       
       
        <div class="ctrlHolder" id="Div24">
            <label for=""><em>*</em> Sıralama Tablo Adı:</label>
            <asp:DropDownList ID="DropDownList12" class="textboxorta" autocomplete="off" 
                runat="server" AutoPostBack="True"></asp:DropDownList> 
               <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="tabloaciklama5"></span>           
        </div> 
        
        <div class="ctrlHolder" id="Div20">
            <label for=""><em>*</em> Alan Adı:</label>
            <asp:DropDownList ID="DropDownList7" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>            
            <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="kolonaciklama5"></span> 
        </div> 
             
        <div class="ctrlHolder" id="Div14">
            <label for=""><em>*</em> Sıra:</label>
            <asp:TextBox ID="TextBox8" maxlength="50" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div15">
            <label for=""><em>*</em> Sıralama Türü:</label>
            <asp:DropDownList ID="DropDownList8" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
        
         <div class="ctrlHolder">
          <asp:Button ID="Buttonsiralamaekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttonsiralamafieldiptal" runat="server" class="button" Text="İptal" />
        </div> 
             
          
        <asp:Label ID="Labelsiralamafield" runat="server" Text=""></asp:Label>
              
      </fieldset>
    
    </div>
    <!-- tabsbilgi5 --> 
    
    
    
    <!-- gruplama -->
    <div id="tabsbilgi6icerik">
    
        <fieldset id="Fieldset6">
          
        <div class="ctrlHolder" id="Div26">
            <label for=""><em>*</em> Gruplanacak Rapor Başlıkları:</label>
            <asp:DropDownList ID="DropDownList13" class="textboxorta" autocomplete="off" 
                runat="server"></asp:DropDownList>            
        </div> 
        
        
          <div class="ctrlHolder" id="Div37">
            <label for=""><em>*</em> Grup Sırası:</label>
            <asp:TextBox ID="TextBox13" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>              
        </div> 
               
         <div class="ctrlHolder">
          <asp:Button ID="Buttongrupfieldekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttongrupfieldiptal" runat="server" class="button" Text="İptal" />
             <span id="Buttongrupsiralama" class="button">Sıralama Seçenekleri</span> 
        </div> 
        
        <asp:Label ID="Labelgrupfield" runat="server" Text=""></asp:Label>
        
         <div id="hatadialog3">
                <asp:Label ID="Labelgrupfieldsiralama" runat="server"></asp:Label> 
			</div>
                     
      </fieldset>
    
    </div>
    <!-- tabsbilgi6 --> 
    
    
     <!-- Rakamlar -->
	<div id="tabsbilgi7icerik">
	    
        <fieldset id="Fieldset7">
                 
         <div class="ctrlHolder" id="Div27">
            <label for=""><em>*</em> Tablo:</label>
            <asp:DropDownList ID="DropDownList14" class="textboxorta" autocomplete="off" 
            runat="server" AutoPostBack="True"></asp:DropDownList> 
             <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="tabloaciklama7"></span>     
        </div>   
              
        <div class="ctrlHolder" id="Div28">
            <label for=""><em>*</em> Alan Adı:</label>
            <asp:DropDownList ID="DropDownList15" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
            <span style="margin-left:10px;margin-top:5px;display: inline-block;" id="kolonaciklama7"></span>  
        </div> 
        
        <div class="ctrlHolder" id="Div41">
            <label for=""><em>*</em> Tip:</label>
            <asp:DropDownList ID="DropDownList24" class="textboxorta" autocomplete="off" 
            runat="server"></asp:DropDownList>      
        </div>  
        
         <div class="ctrlHolder" id="Div25">
            <label for=""><em>*</em> Fonksiyon Adı:</label>
            <asp:DropDownList ID="DropDownList16" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div> 
        
        <div class="ctrlHolder" id="Div29">
            <label for=""><em>*</em> Sql Alias:</label>
            <asp:TextBox ID="TextBox9" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div42">
            <label for=""><em>*</em> Manuel Sql:</label>
            <asp:TextBox ID="TextBox15" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
       <div class="ctrlHolder" id="Div44">
            <label for=""><em>*</em> Kolon Başlığı:</label>
            <asp:TextBox ID="TextBox16" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
    
       
        <div class="ctrlHolder">
          <asp:Button ID="Buttonaggfuncekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttonaggfunciptal" runat="server" class="button" Text="İptal" /> 
        </div> 
   
         <asp:Label ID="Labelaggfunc" runat="server" Text=""></asp:Label>
                
      </fieldset>
      
    </div> 
   <!-- tabsbilgi7icerik --> 
   
   
     <!-- Grafik -->
	<div id="tabsbilgi8icerik">
	    
        <fieldset>
          
        <div class="ctrlHolder" id="Div58">
            <label for=""><em>*</em> Grafik Başlığı:</label>
            <asp:TextBox ID="TextBox11" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
              
         <div class="ctrlHolder" id="Div54">
            <label for=""><em>*</em> Grafik Tipi:</label>
            <asp:DropDownList ID="DropDownList32" class="textboxorta" autocomplete="off" 
            runat="server" ></asp:DropDownList>      
        </div>  
        
          <div class="ctrlHolder" id="Div61">
            <label for=""><em>*</em> Genişlik:</label>
            <asp:TextBox ID="TextBox21" maxlength="3" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
         <div class="ctrlHolder" id="Div62">
            <label for=""><em>*</em> Yükseklik:</label>
            <asp:TextBox ID="TextBox22" maxlength="3" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>  
              
        <div class="ctrlHolder" id="Div55">
            <label for=""><em>*</em> Kolon Seri Adı:</label>
            <asp:DropDownList ID="DropDownList33" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div> 
        
        <div class="ctrlHolder" id="Div56">
            <label for=""><em>*</em> Kolon Sayı Adı:</label>
            <asp:DropDownList ID="DropDownList34" class="textboxorta" autocomplete="off" 
            runat="server"></asp:DropDownList>      
        </div>  
        
         <div class="ctrlHolder" id="Div57">
            <label for=""><em>*</em> Label Gösterilsin mi?</label>
            <asp:DropDownList ID="DropDownList35" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div> 
        
        <div class="ctrlHolder" id="Div65">
            <label for=""><em>*</em> Label Arka Plan Rengi:</label>
            <asp:TextBox ID="TextBox23" maxlength="10" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div63">
            <label for=""><em>*</em> Label Şeffaflık:</label>
             <asp:TextBox ID="TextBox19" maxlength="5" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div64">
            <label for=""><em>*</em> Legend Gösterilsin mi?</label>
            <asp:DropDownList ID="DropDownList37" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>  
        

        <div class="ctrlHolder">
          <asp:Button ID="Buttondinamikraporgrafikekle" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Buttondinamikraporgrafikiptal" runat="server" class="button" Text="İptal" /> 
        </div> 
   
         <asp:Label ID="Labelgrafik" runat="server" Text=""></asp:Label>
                
      </fieldset>
      
    </div> 
   <!-- tabsbilgi8icerik --> 
   
   
     
   
   <!-- Zamanlama -->
    <div id="tabsbilgi9icerik">
    
      <fieldset id="Fieldset8" >
       
        <div class="ctrlHolder" id="Div30">
            <label for=""><em>*</em> Zamanlama Adı:</label>
            <asp:TextBox ID="TextBox10" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>                 
        </div> 
        
           <div class="ctrlHolder" id="Div17">
            <label for=""><em>*</em> Seçiniz:</label>
            <asp:DropDownList ID="DropDownList31" class="textboxorta" autocomplete="off" 
                   runat="server"></asp:DropDownList>      
        </div> 
           
          <div class="ctrlHolder" id="Div31">
              <asp:Button ID="Buttondinamikraporzamanlamaekle" class="button" runat="server" Text="Ekle" />  
              <asp:Button ID="Buttondinamikraporzamanlamaiptal" runat="server" class="button" Text="İptal" /> 
        </div> 
              
        <asp:Label ID="Labeldinamikraporzamanlamadurum" runat="server" Text=""></asp:Label>      
        <asp:Label ID="Labeldinamikraporzamanlama" runat="server" Text=""></asp:Label>                   
            
      </fieldset>
    
    </div> 
    <!-- tabsbilgi9 --> 
    
   
   
    <!-- Kullanıcı Erişim -->
    <div id="tabsbilgi10icerik">
    
       <div class="ctrlHolder" id="Div48">
            <label for=""><em>*</em> Kullanıcı Grubu:</label>
            <asp:DropDownList ID="DropDownList27" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>      
        
        <div class="ctrlHolder" id="Div50">
            <label for=""><em>*</em> Zamanlama:</label>
            <asp:DropDownList ID="DropDownList28" class="textboxorta" autocomplete="off" runat="server"></asp:DropDownList>      
        </div>
        
        <div class="ctrlHolder" id="Div49">
          <asp:Button ID="Button5" class="button" runat="server" Text="İlgili Kullanıcı Grubununun Tümünü Ekle" />  
        </div>
                 
        <asp:Label ID="Labeleklenenler" runat="server"></asp:Label>                    
        <br />
        <hr/>
        
    
      <fieldset id="Fieldset9" >
       
        <div class="ctrlHolder" id="Div18">
            <label for=""><em>*</em> Kullanıcı Adı:</label>
            <asp:DropDownList ID="DropDownList17" class="textboxorta" runat="server"></asp:DropDownList>            
        </div>     
        
        <div class="ctrlHolder" id="Div32">
            <label for=""><em>*</em> Oto Gönderme:</label>
            <asp:DropDownList ID="DropDownList18" class="textboxorta" runat="server"></asp:DropDownList>            
        </div> 
        
        <div class="ctrlHolder" id="Div33">
            <label for=""><em>*</em> Zamanlama:</label>
            <asp:DropDownList ID="DropDownList19" class="textboxorta" runat="server"></asp:DropDownList>            
        </div> 
        
        <div class="ctrlHolder" id="Div34">
            <label for=""><em>*</em> E-Posta:</label>
            <asp:DropDownList ID="DropDownList20" class="textboxorta" runat="server"></asp:DropDownList>            
        </div> 
        
        <div class="ctrlHolder" id="Div35">
            <label for=""><em>*</em> E-Posta Dosya Eklenti:</label>
            <asp:DropDownList ID="DropDownList21" class="textboxorta" runat="server"></asp:DropDownList>            
        </div> 
           
          <div class="ctrlHolder" id="Div19">
              <asp:Button ID="Buttondinamikkullanicibagekle" class="button" runat="server" Text="Ekle" />  
              <asp:Button ID="Buttondinamikkullanicibagiptal" class="button" runat="server" Text="İptal" /> 
        </div> 
                 
        <asp:Label ID="Labeldinamikkullanicibag" runat="server" Text=""></asp:Label>                   
            
      </fieldset>
    
    </div> 
    <!-- tabsbilgi10 --> 
    
    
     <!-- Sınırlandırma  -->
    <div id="tabsbilgi11icerik">
    
      <fieldset>
       
        <div class="ctrlHolder" id="Div67">
            <label for=""><em>*</em> Java Script:</label>
                <asp:TextBox ID="TextBox20"  runat="server" autocomplete="off" 
                class="textboxorta" width="650px" Height="400px" TextMode="MultiLine"></asp:TextBox>                         
        </div>  
        
           
          <div class="ctrlHolder" id="Div72">
              <asp:Button ID="Buttondinamikraporjavascriptekle" class="button" runat="server" Text="Ekle" />  
              <asp:Button ID="Buttondinamikraporjavascriptiptal" class="button" runat="server" Text="İptal" /> 
        </div> 
                 
        <asp:Label ID="Labeldinamikraporjavascript" runat="server" Text=""></asp:Label>                   
         
         <h2>'runtime' Alanları</h2>
       <asp:Label ID="Labeldinamikraporjavascriptyardimci" runat="server" Text=""></asp:Label>    
       
             
      </fieldset>
    
    </div> 
    <!-- tabsbilgi11 --> 
    
    <div id="hatadialog"><div id="hatatxt"></div></div>


	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet ve İleri ->" />
          <asp:Button ID="Button3" runat="server" class="button" Text="Test Et" /> 
          <asp:Button ID="Button6" runat="server" class="button" Text="Oto Düzelt" /> 
          <asp:Button ID="Button4" runat="server" class="button" Text="Sql Göster" />   
          <asp:Button ID="Button2" runat="server" class="button" Text="Raporu Sil" /> 
          <asp:Button ID="Button7" runat="server" class="button" 
               Text="Bileşenleri İle Birlikte Raporu Sil" /> 
      </div>
      
    </form>   
 		
			
</div> <!-- tabs bilgi -->
  
   
</body> 

    