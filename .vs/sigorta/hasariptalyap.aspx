<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="hasariptalyap.aspx.vb" Inherits="sigorta.hasariptalyap" %>

<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Hasar İptal İşlemi</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/hasariptalyap.js"></script>   
    
<body style="font-size:75%; margin-top:0px; margin-left:0px;">

  
  <div id="tabsbilgi" style="width:100%;">
	
	<form id="form1" runat="server" class="uniForm">
	   
	   
	    <!-- GİRİŞ ------------------------------- -->
        <div class="accordion">
        <h3><a href="">Hasar İptal İşlemi</a></h3>
        <div>
        <div class="help">
                
              
        <fieldset id="Fieldset1" class="inlineLabels">  
                                          
            <div class="ctrlHolder" id="Div1">
                <label for=""><em>*</em> İptal Tarihi:</label>
                <asp:TextBox ID="TextBox1" maxlength="10" runat="server" class="textboxkucuk" autocomplete="off"></asp:TextBox> 
            </div> 
        
                               
            <div class="ctrlHolder" id="Div9">
                <label for=""><em>*</em> İptal Eden:</label>
                 <asp:DropDownList ID="DropDownList2" class="textboxorta" runat="server">
                </asp:DropDownList>   
            </div>
     
        
            <div class="ctrlHolder" id="Div10">
                <label for=""><em>*</em> İptal Tipi:</label>
                <asp:DropDownList ID="DropDownList1" class="textboxorta" runat="server">
                </asp:DropDownList>
            </div>  
        
            <div class="buttonHolder">
                <asp:Button ID="Button1" runat="server" class="button" Text="Kaydet" /> 
                <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
            </div>
       
      </fieldset>
                
	       <asp:Label ID="Label1" runat="server" Text=""></asp:Label>    
	       <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>             
	   
      
            </div>
        </div>
        </div>
    <!-- GİRİŞ BİTTİ ---------------------- -->
    	 
       
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

</body> 
    
