<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sinirkapiippopup.aspx.vb" Inherits="sigorta.sinirkapiippopup" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Sınr Kapısı IP Adresleri</title>
    <style type="text/css">
        
        
body div:first-child {
    border: 40 !important;
}

        </style>
</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/sinirkapiippopup.js"></script>   

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 
  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi3icerik">IP Adresleri</a></li>
	</ul>
	
	<form id="form1" runat="server" class="uniForm">

    
    <div id="tabsbilgi3icerik">
    
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
                    <asp:Button ID="Buttonsinirkapiipiptal" runat="server" class="button" Text="İptal" />
                </td>
                
                
            </tr>
        
        </tbody>
        </table>
        
        <br/>
        
        <fieldset>
    
        
            <label for=""><em>*</em> IP Adresi Dikkate Alınsın mı? (İşaretlerseniz sadece aşağıdaki IP adreslerinden bağlantı kurulmasına izin verilir.)</label>
               <asp:CheckBox ID="CheckBox4" runat="server" class="textboxkucuk" />
               
               
            &nbsp;<asp:Button ID="Button1" runat="server" class="button" 
                    Text="Kaydet" />
       
               
        </fieldset>
      
        <br/>
        <asp:Label ID="Labelipadresleri" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Label ID="Labelipresult" runat="server" Text=""></asp:Label>
    
    </div>
  
      
	   <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>              
   
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

    
    </body> 
    


