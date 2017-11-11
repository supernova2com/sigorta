<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sirketacente.aspx.vb" Inherits="sigorta.sirketacente" %>



<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register src="headertemel.ascx" tagname="headertemel" tagprefix="uc3" %>
<uc1:header id="header1" runat="server" /> 


<!-- BEGIN FORM-->
<form id="form1" runat="server" class="form-horizontal">

	<!-- BEGIN CONTENT -->
	<div class="page-content-wrapper">
		<div class="page-content">
		
			<!-- BEGIN PAGE HEADER-->
			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN PAGE TITLE & BREADCRUMB-->
					<h3 class="page-title">
					Acenteler<small>Bu sayfada şirketinizin altında çalışan acenteleri tanımlayabilirsiniz.</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li class="btn-group">
							<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
							<span>
								İşlemler
							</span>
							<i class="fa fa-angle-down"></i>
							</button>
							<ul class="dropdown-menu pull-right" role="menu">		
							</ul>
						</li>
						<li>
							<i class="fa fa-home"></i>
							<a href="defaultsirket.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
							<li>
							<a href="#">
								Kullanıcı Yönetimi
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
							    Kullanıcılar
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
                    <!-- YARDIM PORTLATE-->
					<div class="portlet box red">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bell-o"></i>Yardım
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
				
								<a href="javascript:;" class="remove"></a>
							</div>
							
				
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <p>Şirketiniz altında çalışan acenteleri buradan sisteme tanımlayabilirsiniz. Burada tanımladığınız her acenteye 
                           ayrıca kullanıcılarda ekleyebilirisiniz. Eklediğiniz bu kullanıcılar sisteme giriş yapıp sorgulama yapabilirler. </p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
				
				
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Şirketler İçin Acente Ekleme
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
	
	                        <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList5"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                                    
    
	                        <div class="form-group">
                                <label class="col-md-3 control-label"> Acente Sicil No:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox1" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      MaxLength="15" class="form-control"/> 
                                      <span id="bulbutton" class="btn green">Bul</span>  
                                      <span class="help-block">Acente sicil no formatı TKSA-01/2011, GKSA-01/2011 veya BSA-01/2011
                                      formatında olabilir.</span>
                                </div>
                            </div> 
                            
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Acente Anahtarı:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textboxacentepkey" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      MaxLength="10" ReadOnly="True" class="form-control"/> 
                                </div>
                            </div>   
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Acente Adı:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox2" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control" ReadOnly="True"/>    
                                </div>
                            </div>
		                   
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Yetkili Ad Soyadı:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox3" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Yetkili Kimlik No:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox4" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yetkili Cep Telefonu:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox5" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="10" class="form-control"/>    
                                </div>
                            </div>  
                    
                                    
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yetkili E-Posta Adresi:</label>
                                <div class="col-md-4"> 
                                    <asp:textbox id="TextBox6" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Ofis Telefon:</label>
                                <div class="col-md-4"> 
                                    <asp:textbox id="TextBox7" MaxLength="11" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Ofis Fax:</label>
                                <div class="col-md-4"> 
                                    <asp:textbox id="TextBox8"  autocomplete="off" class="form-control" 
                                        runat="server" MaxLength="11"></asp:textbox>
                                </div>
                            </div>       
  
                            
                            
                          	<div class="form-actions right">
                                <asp:Button ID="Button1" runat="server" class="btn green" Text="Kaydet" /> 
                                <asp:Button ID="Buttonsil" runat="server" class="btn green" Text="Sil" /> 
							</div>
							
						
						    <div id="validationresult">
							    <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					        </div>  
				
					
						</div>
					</div>
					<!-- VERİ GİRİŞ PORTLATE-->
					
	
					
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Eklediğim Acenteler
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
									<asp:Button ID="Buttonyenikayit" runat="server" class="btn green" Text="Yeni Kayıt" /> 
							</div>						
							
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Label1" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- DATATABLE PORTLATE-->
					
					
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/sirketacente.js"></script>

 




