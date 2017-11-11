<%@ Page Language="vb" AutoEventWireup="false" validateRequest="false" CodeBehind="policedetay.aspx.vb" Inherits="sigorta.policedetay" %>
<%@ Register src="headerfancy.ascx" tagname="header" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<head><title>Poliçe Detayları</title></head>

<uc1:header id="header1" runat="server" /> 

<script type="text/javascript" src="js/policedetay.js"></script>   
    
<body>
	
	<form id="form1" runat="server">
	
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
	
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label> <br/>           
	                        <asp:Label ID="Labeldigerkisiler" runat="server" Text=""></asp:Label>												
	
						</div>
					</div>
					<!-- POLİÇE-->
					
					
					<!-- ARAÇ-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Araç
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
					
					
				    <!-- PRİM-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Primler
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
	                         <asp:Label ID="Label7" runat="server" Text=""></asp:Label> 										
						</div>
						
					</div>
					
					
							
				    <!-- Zeyil-->
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
		
	
                 
	                <!-- Hasar-->
					<div class="portlet box purple">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Hasar Dosyaları
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
	                          
	                          
	                           <h3>Talep</h3>
	                           <asp:Label ID="Label4" runat="server" Text=""></asp:Label>   
	             									
						</div>
						
					</div>

	     
	   
	 
	             
	             				
				    <!-- Servis Logu-->
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
                 
	     
	     	</div>
	     </div>      
	             
      
    </form>		

   

  <br/> 

    
    </body> 
    
