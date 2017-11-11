<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kullanicisifreyonetim.aspx.vb" enableEventValidation="false" Inherits="sigorta.kullanicisifreyonetim" %>

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
					Şifre Yönetimi<small>Bu sayfada kullanıcıların şifrelerini değiştirebilirsiniz.</small>
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
								Kullanıcı Yönetimi
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
							    Şifre Yönetimi
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
								
                           <p>Sisteme tanımlanmış kullanıcıların şifrelerini değiştirebilir, 
                           bu değişiklikleri ilgili kullanıcıya mesaj ve e-posta yoluyla haber 
                           verebilirsiniz.</p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					

				
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Kullanıcı Şifre Değiştirme
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
                                <label class="col-md-3 control-label"> Çalıştığı Şirket:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList5"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Çalıştığı Acente:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList6"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div>   
                                    
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Personel:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList2"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 

                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yeni Şifre:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox1" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yeni Şifre Tekrar:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox2" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div> 
                            
                 
                            
                          	<div class="form-actions right">
                                
                                <asp:Button ID="Button2" runat="server" class="btn green" Text="Hatalı Giriş Sayısını Sıfırla" /> 
                                <asp:Button ID="Button3" runat="server" class="btn green" Text="Sadece Değiştir" /> 
                                <asp:Button ID="Button1" runat="server" class="btn green" Text="Değiştir ve E-Posta Gönder" /> 
                                 
							</div>
							
						
						    <div id="validationresult">
							    <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					        </div> 
					        
					        <div id="validationresult2">
							    <asp:Label ID="durumlabelemail" runat="server"></asp:Label>  
					        </div> 
					        

					
						</div>
					</div>
					<!-- VERİ GİRİŞ PORTLATE-->
					
	
					
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/kullanicisifreyonetim.js?rnd=32467346"></script>

 


