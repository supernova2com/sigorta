<%@ Page Language="vb" AutoEventWireup="false" ValidateRequest="false" CodeBehind="hasarsilyap.aspx.vb" Inherits="sigorta.hasarsilyap" %>


<%@ Register src="adminheader2.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Hasar Silme İşlemi</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/hasarsilyap.js"></script>   
    
<body style="font-size:75%; margin-top:0px; margin-left:0px;">

  
  <div id="tabsbilgi" style="width:100%;">
	
	<form id="form1" runat="server" class="uniForm">
	   
	   
	    <!-- GİRİŞ ------------------------------- -->
        <div class="accordion">
        <h3><a href="">Hasar Silme İşlemi</a></h3>
        <div>
        <div class="help">
                
        <h4>Hasarı silmeden önce aşağıdaki XML'i bilgisayarınıza kaydediniz. Hatalı bir 
            silme işlemi durumunda bu kayıt ile hasarı sisteme tekrardan kaydedebilirsiniz.</h4>  
        
            <asp:TextBox ID="TextBox1" style="width:100%;height:225px;" class="textboxorta" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" class="button" Text="Sil" /> 
  
                
	        <br />
            <br />
  
                
	       <asp:Label ID="durumlabel" runat="server" Text=""></asp:Label>             
	   
      
            </div>
        </div>
        </div>
    <!-- GİRİŞ BİTTİ ---------------------- -->
    	 
       
    </form>		
			
</div> <!-- tabs bilgi -->
   

  <br/> 

</body> 
    

