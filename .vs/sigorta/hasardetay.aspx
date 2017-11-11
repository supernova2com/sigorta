<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="hasardetay.aspx.vb" Inherits="sigorta.hasardetay" %>
<%@ Register src="headerfancy.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Hasar Detayları</title></head>

<uc1:header id="header1" runat="server" /> 
<script type="text/javascript" src="js/hasardetay.js?rnd=34623467247"></script>   
    
<body>

 
	
	<form id="form1" runat="server" class="uniForm">
	   
	   	<div class="row">
	        <div class="col-md-12">
	   
	   
	                <!-- POLİÇE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Poliçe
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					     
						</div>
		
						<div class="portlet-body">
	
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>    										
	
						</div>
					</div>
					<!-- POLİÇE-->
					
					
					<!-- ARAÇ-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Araç Bilgisi
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					     
						</div>
		
						<div class="portlet-body">
	
                           <asp:Label ID="Label2" runat="server" Text=""></asp:Label>   									
	
						</div>
					</div>
					
					
				    <!-- ZEYİL-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Zeyiller
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					     
						</div>
		
						<div class="portlet-body">
	
                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>   									
	
						</div>
					</div>
					
					
				    <!-- HASAR DOSYASI-->
					<div class="portlet box purple">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Hasarlar
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					     
						</div>
		
						<div class="portlet-body">
	
                             <asp:Label ID="Label3" runat="server" Text=""></asp:Label>  
                             
                             <asp:Label ID="Label4" runat="server" Text=""></asp:Label>    								
	
						</div>
					</div>
					
					
	
		            <!-- SERVİS LOGU-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Servis Logları
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					     
						</div>
		
						<div class="portlet-body">
	
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>   									
	
						</div>
					</div>
	 
     
     
	      
	       <button type="button" id="kapatbutton" class="btn purple">Tamam</button>
	       <button type="button" id="yazdirhasarbutton" class="btn green">Hasarı Yazdır</button>
	       <button type="button" id="yazdirpolicebutton" class="btn blue">Poliçeyi Yazdır</button>
	  
	  
            
            </div>
        </div>


    
         
    </form>		
			

  
  <br/> 

    
    </body> 
    
