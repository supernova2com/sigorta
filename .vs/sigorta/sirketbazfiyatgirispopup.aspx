<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sirketbazfiyatgirispopup.aspx.vb" Inherits="sigorta.sirketbazfiyatgirispopup" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Şirket İçin Baz Fiyatları</title>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/sirketbazfiyatgirispopup.js?rel=457457"></script>  

<style type="text/css">
.computergenerated {
    text-align:right;
} 
.computergeneratedn {
    text-align:right;
} 



</style>

</head>
      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Baz Fiyat Temel Bilgiler</a></li>
		<li><a href="#tabsbilgi2icerik">Baz Fiyatlar</a></li>

	</ul>
	
	<form id="form1" runat="server" class="uniForm">
     
  
    
	<div id="tabsbilgi1icerik">	
    
  <!-- YARDIM ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Yardım</a></h3>
    <div>
 
            <p>Aşağıdaki bilgileri doldurarak baz fiyatları kaydını yapabilirsiniz.
            <br/><br/>
            <asp:Label ID="uyarilabel" runat="server" style="color: #FF0000"></asp:Label> 
            <BR/>
             <asp:Label ID="bilgilendirmelabel" runat="server" style="color: #FF0000"></asp:Label>       
            </p>                     
    </div>
    </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    
    <br/><br/>
	
      <fieldset id="Fieldset1" class="inlineLabels">
          
        <asp:HiddenField ID="inn" runat="server" /> 
         
                                  
        <div class="ctrlHolder" id="Div5">
        <label for=""><em>*</em> Şirket:</label>
            <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server">
            </asp:DropDownList>
        </div> 
        
          <div class="ctrlHolder" id="Div2">
        <label for=""><em>*</em> Kayıt No:</label>
         <asp:TextBox ID="TextBox2" maxlength="254" runat="server" class="textboxkucuk" autocomplete="off" ></asp:TextBox>               
        </div>   
                          
        <div class="ctrlHolder" id="Div1">
        <label for=""><em>*</em> Başlangıç Tarihi:</label>
        <asp:TextBox ID="TextBox1" maxlength="10" runat="server" class="textboxkucuk" 
                autocomplete="off" ReadOnly="True"></asp:TextBox> 
        </div> 
        
                               
        <div class="ctrlHolder" id="Div9">
        <label for=""><em>*</em> Kayıt Tarihi:</label>
        <asp:TextBox ID="TextBox7" maxlength="10" runat="server" class="textboxkucuk" 
                autocomplete="off" ReadOnly="True"></asp:TextBox> 
        </div>
     
        
          <div class="ctrlHolder" id="Div10">
        <label for=""><em>*</em> Poliçe Tipi:</label>
            <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server">
            </asp:DropDownList>
        </div>  
        
           <div class="buttonHolder">
          <asp:Button ID="Button3" runat="server" class="button" Text="Kaydet ve İleri ->" /> 
           <asp:Button ID="Button5" runat="server" class="button" Text="Sil" /> 
          </div>
       
      </fieldset>
      
    </div> <!-- tabsbilgi1 --> 
    
    
    <div id="tabsbilgi2icerik"> 
    <p style="text-align:center; font-weight:bold; color:Green;">Aşağıda kaydettiğiniz baz fiyatlar BSİV ve GARANTİ FONU hariç girilmelidir.</p>
        <asp:Label ID="Labelinput" runat="server"></asp:Label>
        
       <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Baz Fiyatları Kaydet" /> 
      </div>
      
    </div>
    
   
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
      
    <br />
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
