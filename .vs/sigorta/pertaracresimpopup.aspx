<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pertaracresimpopup.aspx.vb" Inherits="sigorta.pertaracresimpopup" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head><title>Pert Araç Resimleri</title>

</head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/pertaracresimpopup.js?"></script>  

<!-- BX SLIDER -->
<script type="text/javascript" src="assets/plugins/bxslider/jquery.bxslider.min.js"></script>
<link href="assets/plugins/bxslider/jquery.bxslider.css" rel="stylesheet" />
<script type="text/javascript" src="assets/plugins/bxslider/bxsliderpertarac.js"></script> 

      
  <body style="font-size:75%; margin-top:0px; margin-left:0px;">
 


  <div id="tabsbilgi" style="width:100%;">
	<ul>
		<li><a href="#tabsbilgi1icerik">Araç Resimleri</a></li>
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
     
    
    <div id="slideraccordion" class="accordion" runat="server">
    <h3><a href="">Resimler</a></h3>
    <div>     
            <asp:Literal ID="Literalslide" runat="server"></asp:Literal>
    </div>
    </div>
	
	
	 <div id="resimeklemeaccordion" class="accordion" runat="server">
    <h3><a href="">Resim Ekleme</a></h3>
    <div>
      <fieldset id="Fieldset1" class="inlineLabels">                                   
        <div class="ctrlHolder" id="Div5">
        <label for=""><em>*</em> Resim:</label>
            <asp:FileUpload ID="FileUpload1" class="textboxorta" runat="server" />         
        </div> 
        

        
           <div class="buttonHolder">
          <asp:Button ID="Button3" runat="server" class="button" Text="Kaydet" /> 
           
          </div>
       
        <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>
        
      </fieldset>
      </div>
      </div>
      
 
     <br />
    <br />
   
    <div id="resimgridaccordion" class="accordion" runat="server">
    <h3><a href="">Pert Araç Resimleri</a></h3>
    <div>
     <asp:Label ID="Label1" runat="server"></asp:Label>   
	          
	    </div>
      </div>
        
     
    
      </div> <!-- tabsbilgi1 --> 
   
	             
      
    </form>		
			
</div> <!-- tabs bilgi -->
   

</body> 