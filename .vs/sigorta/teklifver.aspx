<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="teklifver.aspx.vb" Inherits="sigorta.teklifver" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head><title>Pert Araç İçin Teklif</title>

</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/teklifver.js?"></script>  

    
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Araç Teklifi</a></li>
	</ul>
	
	<form id="form1" runat="server" class="uniForm">
     
  
    
	<div id="tabsbilgi1icerik">	
    
  <!-- SEÇİLEN ARAÇ BİLGİLERİ ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Seçilen Araç</a></h3>
    <div>
        <div class="help">
            <table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td>
                        <asp:Label ID="Labelaracbilgi1" runat="server"></asp:Label>
                    </td>
          
                    <td>
                       <div style="min-width:250px;"></div>
                    </td>
                    
                    <td>
                        <asp:Label ID="Labelaracbilgi2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    
    <br/><br/>
     
    
  
	 <div  class="accordion" runat="server">
    <h3><a href="">Teklif</a></h3>
    <div>
      <fieldset id="Fieldset1" class="inlineLabels">                                   
        
        
        <div class="ctrlHolder" id="Div5">
        <label for=""><em>*</em> Teklif Tutarı:</label>       
            <asp:TextBox  ID="TextBox1" class="textboxorta" runat="server"></asp:TextBox>
        </div> 
        
        <div class="ctrlHolder" id="Div1">
        <label for=""><em>*</em> Teklif Vermek İstediğiniz Para Birimi:</label>         
               <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server"></asp:DropDownList>       
        </div> 
        
        
         <div class="buttonHolder">
          <asp:Button ID="Button1" runat="server" class="button" Text="Teklifimi Gönder" /> 
           
          </div>
       
        <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>
        
      </fieldset>
      </div>
      </div>
      
 
     <br />
    <br />
   
   
    
      </div> <!-- tabsbilgi1 --> 
   
	             
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

</body> 