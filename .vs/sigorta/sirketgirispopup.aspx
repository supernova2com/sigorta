<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sirketgirispopup.aspx.vb" Inherits="sigorta.sirketgirispopup" %>
<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Şirket Girişleri</title>
    <style type="text/css">
        
        
body div:first-child {
    border: 40 !important;
}

        .style1
        {
            width: 100%;
        }
        .style2
        {}
        .style3
        {
            width: 96px;
        }
    </style>
</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/sirketgirispopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 
  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Şirket Temel Bilgileri</a></li>
		<li><a href="#tabsbilgi2icerik">Web Servis Ayarları</a></li>
		<li><a href="#tabsbilgi3icerik">Acenteleri</a></li>
		<li><a href="#tabsbilgi4icerik">IP Adresleri</a></li>
		<li><a href="#tabsbilgi5icerik">Fatura E-Posta Adresleri</a></li>
		<li><a href="#tabsbilgi6icerik">Şirket Logosu</a></li>
		

	</ul>
	
	<form id="form1" runat="server" class="uniForm">
		
	<div id="tabsbilgi1icerik">
	
	
       <!-- YARDIM ------------------------------- -->
        <div class="accordion">
        <h3><a href="">Yardım</a></h3>
        <div>
            <div class="help">
                <p class="helpinner">Aşağıdaki tabları kullanarak şirket bilgilerini kaydetmek için gereken bilgileri
                girerek şirket kaydını yapabilirsiniz.
                </p>
            </div>
        </div>
        </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    <BR/><BR/>
	

	  <asp:HiddenField ID="inn" runat="server" />   
	    
      <fieldset id="Fieldset1" class="inlineLabels">
          
          
        <div class="ctrlHolder" id="Div15">
        <label for=""><em>*</em> Şirket/Kurum Tipi:</label>
            <asp:DropDownList class="textboxorta" ID="DropDownList3" runat="server"></asp:DropDownList>
        </div> 
               
        <div class="ctrlHolder" id="Div1">
        <label for=""><em>*</em> Şirket/Kurum Kodu:</label>
        <asp:TextBox ID="TextBox1" maxlength="3" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox> 
        </div> 
        
          <div class="ctrlHolder" id="Div11">
        <label for=""><em>*</em> Şirket/Kurum Adı:</label>
         <asp:TextBox ID="TextBox2" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>

        <div class="ctrlHolder" id="Div2">
        <label for=""><em>*</em> Yetkili Kişi Adı Soyadı:</label>
         <asp:TextBox ID="TextBox3" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
           <div class="ctrlHolder" id="Div13">
        <label for=""><em>*</em> Şirket/Kurum Adresi:</label>
         <asp:TextBox ID="TextBox10"  runat="server" class="textboxorta" autocomplete="off" TextMode="MultiLine"></asp:TextBox>       
        </div>
        
           <div class="ctrlHolder" id="Div3">
        <label for=""><em>*</em> Şirket/Kurum Telefonu:</label>
         <asp:TextBox ID="TextBox4" maxlength="11" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>       
        </div>  
        
        
           <div class="ctrlHolder" id="Div4">
        <label for=""><em>*</em> Şirket/Kurum Faks Numarası:</label>
         <asp:TextBox ID="TextBox5" maxlength="11" runat="server" autocomplete="off" class="textboxkucuk"></asp:TextBox>       
        </div> 
        
           <div class="ctrlHolder" id="Div5">
        <label for=""><em>*</em> Şirket/Kurum E-Posta Adresi:</label>
         <asp:TextBox ID="TextBox6" maxlength="254" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox>       
        </div>
        
        <div class="ctrlHolder" id="Div10">
        <label for=""><em>*</em> Aktif mi?</label>
               <asp:CheckBox ID="CheckBox1" runat="server" class="textboxkucuk" />
        </div>  
               
      </fieldset>
      
    </div> <!-- tabsbilgi1 --> 
    
    	
	<div id="tabsbilgi2icerik">
	    
      <fieldset id="Fieldset2" class="inlineLabels">
                 
        <div class="ctrlHolder" id="Div7">
        <label for=""><em>*</em> Web Servis Kullanıcı Adı:</label>
        <asp:TextBox ID="TextBox7" maxlength="50" runat="server" autocomplete="off" class="textboxorta"></asp:TextBox> 
        </div> 
        
        <div class="ctrlHolder" id="Div8">
        <label for=""><em>*</em> Web Servis Şifresi:</label>
         <asp:TextBox ID="TextBox8" maxlength="50" runat="server" class="textboxorta"></asp:TextBox>       
            <asp:Button ID="Button3" runat="server" Text="Görüntüle" class="button" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        
        <div class="ctrlHolder" id="Div9">
        <label for=""><em>*</em> Web Servis Şifresi Tekrar:</label>
         <asp:TextBox ID="TextBox9" maxlength="50" runat="server" class="textboxorta"></asp:TextBox>       
        </div>  
        
        
       <div class="ctrlHolder" id="Div21">
        <label for=""><em>*</em> Dakikada Maks Servis Talebi:</label>
         <asp:TextBox ID="TextBox13" maxlength="3" runat="server" class="textboxorta"></asp:TextBox>       
        </div>  
        
        
        
        
        <div class="ctrlHolder" id="Div6">
        <label for=""><em>*</em> Toplu Yükleme?</label>
            <asp:CheckBox ID="CheckBox2" runat="server" class="textboxkucuk" />
        </div>
        
        <div class="ctrlHolder" id="Div14">
        <label for=""><em>*</em> Test Servisine Erişim?</label>
           <asp:CheckBox ID="CheckBox3" runat="server" class="textboxkucuk" />
        </div>
        
        <br/><br/>
        
       <div class="ctrlHolder" id="Div16">
       <label for=""><em>*</em> GetCarAddressInfo:</label>
           <asp:CheckBox ID="CheckBox10" runat="server" class="textboxkucuk" />
       </div> 
       
       <div class="ctrlHolder" id="Div17">
       <label for=""><em>*</em> GetDamageInformation:</label>
           <asp:CheckBox ID="CheckBox11" runat="server" class="textboxkucuk" />
       </div>  
       
       <div class="ctrlHolder" id="Div18">
       <label for=""><em>*</em> GetInfoInsuredPeople:</label>
           <asp:CheckBox ID="CheckBox12" runat="server" class="textboxkucuk" />
       </div>  
       
       <div class="ctrlHolder" id="Div19">
       <label for=""><em>*</em> LoadDamageInformation:</label>
           <asp:CheckBox ID="CheckBox13" runat="server" class="textboxkucuk" />
       </div>  
       
       <div class="ctrlHolder" id="Div20">
       <label for=""><em>*</em> LoadPolicyInformation:</label>
           <asp:CheckBox ID="CheckBox14" runat="server" class="textboxkucuk" />
       </div>     
        
              
      </fieldset>
      
    </div> <!-- tabsbilgi2 --> 
    
    
    
   
    <div id="tabsbilgi3icerik">    

        <table class="pure-table pure-table-bordered">
        <tbody>
        
            <tr>
                <td>Acente</td>
                <td>İşlem</td>
                <td>İptal</td>
            </tr>

            <tr>
                <td style="text-align: left;">        
                    <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server">
                    </asp:DropDownList>             
                </td>
                <td>
                    <asp:Button ID="Buttonacenteekle" runat="server" class="button" Text="Ekle" />
                </td>
                
                <td>
                   <asp:Button ID="Buttonacenteiptal" runat="server" class="button" Text="İptal" />
                </td>
                
            </tr>
        
        </tbody>
        </table>
       
        <br/>
        <h2>Şirketin/Kurumun Acenteleri</h2>
        <asp:Label ID="Labelacenteleri" runat="server" Text=""></asp:Label>
        <h2>Şirketin/Kurumun Çalışanları</h2>
        <asp:Label ID="Labelpersoneli" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Label ID="Labelacenteresult" runat="server" Text=""></asp:Label>
    
      
    </div> <!-- tabsbilgi3 --> 
    
    
   
    
    <div id="tabsbilgi4icerik">
    
     <table class="pure-table pure-table-bordered">
        <tbody>
        
            <tr>
                <td>CIDR Notation</td>
                <td>IP ADRESİ</td>
                <td>İşlem</td>
                <td>İptal</td>
            </tr>

            <tr>
                <td>
                   <asp:DropDownList ID="DropDownList4" class="textboxorta" Width="60px" runat="server"></asp:DropDownList>       
                </td>
                
                <td style="text-align: left;">        
                    <asp:TextBox ID="TextBox11" class="textboxorta" autocomplete="off" runat="server"></asp:TextBox>             
                </td>
                
                <td>
                    <asp:Button ID="Buttonipeklebutton" runat="server" class="button" Text="Ekle" />
                </td>
                
                 <td>
                    <asp:Button ID="Buttonsirketipbagiptal" runat="server" class="button" Text="İptal" />
                </td>
                
                
            </tr>
        
        </tbody>
        </table>
        
        <br/>
        
        <fieldset>
    
            <div class="ctrlHolder" id="Div12">
            <label for=""><em>*</em> IP Adresi Dikkate Alınsın mı? (İşaretlerseniz sadece aşağıdaki IP adreslerinden bağlantı kurulmasına izin verilir.)</label>
               <asp:CheckBox ID="CheckBox4" runat="server" class="textboxkucuk" />
            </div>  
               
        </fieldset>
       
        <br/>
        <h2>Şirketin Web Servislerine Bağlanabileceği IP Adresleri</h2>
        <asp:Label ID="Labelipadresleri" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Label ID="Labelipresult" runat="server" Text=""></asp:Label>
    

    </div>
    
    
    
     <div id="tabsbilgi5icerik">
    
     <table class="pure-table pure-table-bordered">
        <tbody>
        
            <tr>
                <td>E-POSTA ADRESİ</td>
                <td>İşlem</td>
                <td>İptal</td>
            </tr>

            <tr>
                <td style="text-align: left;">        
                    <asp:TextBox ID="TextBox12" class="textboxorta" autocomplete="off" runat="server"></asp:TextBox>
                
                </td>
                <td>
                    <asp:Button ID="Buttonsirketfaturabagekle" runat="server" class="button" 
                        Text="Ekle" /></td>
                <td>
          <asp:Button ID="Buttonsirketfaturabagiptal" runat="server" class="button" Text="İptal" /> 
                </td>
            </tr>
        
        </tbody>
        </table>
        
        <br/>
        
       
        <h2>Fatura Gönderilecek E-Posta Adresleri</h2>
        <asp:Label ID="Labelfaturaepostaadresleri" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Label ID="Labelfaturaepostaresult" runat="server" Text=""></asp:Label>
    

    </div>
    
    
    
    
    <div id="tabsbilgi6icerik">
	    
	    <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td class="style3">

        <label for="">Şirket/Kurum Logosu:</label></td>
                <td>
            <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
      

      
      <asp:Label ID="Labellogo" runat="server" Text=""></asp:Label>
      
                </td>
            </tr>
        </table>
      
    </div> <!-- tabsbilgi6 --> 
    
    
      
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
          <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
      </div>
      
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
    

