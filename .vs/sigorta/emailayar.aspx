<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="emailayar.aspx.vb" Inherits="sigorta.emailayar" %>

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
					E-Posta<small>Bu sayfada sistem e-posta gönderim ayarlarını yapılandırabilirsiniz.</small>
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
							<a href="default.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
							<li>
							<a href="#">
								Ayarlar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								E-Posta Gönderim Ayarları
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
								
                           <p>Sistemin e-posta göndermek için ihtiyaç duyduğu ayarları 
                           bu ekrandan yapmalısınız. Bu ekrandan ayar yapmadan önce 
                           Supernova'ya danışabilirsiniz. </p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
					
					<!-- ARAMA PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Arama
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
									<label class="col-md-3 control-label">Hostname:</label> 
									<div class="col-md-4">   
									    <input id="aratext" type="text" class="form-control" />
                                    </div>
                                    <div class="col-md-4">   
                                             <button id="arabutton" class="btn green">Ara</button>
                                    </div>
								</div>	
	
							
						</div>
					</div>
					<!-- ARAMA PORTLATE-->
					
					
				
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>E-Posta Gönderim Ayarları
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
						
						    <h3>E-Posta Gönderim Ayarlar</h3>   
						   
		                    <div class="form-group">
                                <label class="col-md-3 control-label"> E-Posta Kullanıcı Adı Hostname:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textbox12" AutoCompleteType="Disabled" runat="server" 
                                    maxlength="254" class="form-control"/>    
                                </div>
                            </div>   
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> E-Posta Şifre (Password):</label>
                                <div class="col-md-4"> 
                                       <asp:TextBox id="Textbox6" AutoCompleteType="Disabled" runat="server" 
                                        maxlength="254" class="form-control"/>  
                                </div>
                            </div> 
                           
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Port Numarası:</label>
                                <div class="col-md-4"> 
                                     <asp:TextBox id="Textbox2" AutoCompleteType="Disabled" runat="server"
                                     maxlength="254" class="form-control"/>  
                                </div>
                            </div>  
                                   
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> SSL Varmı?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList6"  class="form-control"  runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>  
                                        
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Öncelik:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>                  
 
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Pickup Directory Location:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox7" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Hostname:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox13" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div> 
                                              
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Use Default Credentials?</label>
                                <div class="col-md-4"> 
                                      <asp:DropDownList ID="DropDownList7" class="form-control"  runat="server">
                                      </asp:DropDownList>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Delivery Method:</label>
                                <div class="col-md-4"> 
                                      <asp:DropDownList ID="DropDownList3" class="form-control"  runat="server">
                                      </asp:DropDownList>
                                </div>
                            </div> 
                
                            <div class="form-group">
                                <label class="col-md-3 control-label"> UDC Kullanılsın mı?</label>
                                <div class="col-md-4"> 
                                     <asp:DropDownList ID="DropDownList4" class="form-control" runat="server">
                                     </asp:DropDownList>
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
								<i class="fa fa-globe"></i>E-Posta Gönderim Ayarları
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
					
					
					
						
					<!-- TEST E-MAIL PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Test
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
									
							</div>						
							
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
							
							
							<div class="form-group">
                                <label class="col-md-3 control-label"> Gönderilecek E-Posta Adresi:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textboxeposta" AutoCompleteType="Disabled" runat="server" 
                                    maxlength="254" class="form-control"/>    
                                </div>
                            </div>   
                            
                            <div class="form-actions right">
							        <asp:Button ID="Buttontest" runat="server" class="btn green" Text="Test E-Posta Gönder" /> 
							</div>	
							
							
                           <asp:Label ID="Label2" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- TEST E-MAIL PORTLATE-->
							          
							          
    
			
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/emailayar.js"></script>
 




