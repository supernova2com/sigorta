<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="faturarapor.aspx.vb" Inherits="sigorta.faturarapor" %>

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
					Fatura Raporları<small>Şirket ekstre ve bakiye bilgileri ile ilgili raporları bu ekrandan görebilirsiniz.</small>
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
								Faturalandırma
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="faturarapor.aspx">
								Fatura Raporları
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
                 	
			        <!-- BİRİNCİ RAPOR PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bullhorn"></i>Hesap Hareketleri
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					        	        	   
						</div>
									
						<div class="portlet-body form">
																		
					        <div class="form-body">
							        
							         <div class="row">   
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Şirket:</label>
										            <div class="col-md-8">
											            <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
										            </div>
									            </div>
								            </div>
							         </div>
							          
							        <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Başlangıç Tarihi:</label>
										        <div class="col-md-8">
											        <asp:textbox id="TextBox1" autocomplete="off" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Bitiş Tarihi:</label>
										            <div class="col-md-8">
											            <asp:textbox id="TextBox2" autocomplete="off" class="form-control" runat="server"></asp:textbox>
										            </div>
									           </div>
								           </div>
							          </div>
							            			         
							            <div class="form-actions right">
                                            <asp:Button ID="Button1" runat="server" class="btn green" Text="Hesap Hareketleri" /> 
							            </div>
							          
							          
						                <div id="validationresult">
							                <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					                    </div>        
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- BİRİNCİ RAPOR PORTLATE-->
					
					
					
					  <!-- İKİNCİ RAPOR PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bullhorn"></i>Ekstre
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					        	        	   
						</div>
									
						<div class="portlet-body form">
																		
					        <div class="form-body">
							        
							         <div class="row">   
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Başlangıç Tarihi:</label>
										        <div class="col-md-8">
											        <asp:textbox id="TextBox3" autocomplete="off" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Bitiş Tarihi:</label>
										            <div class="col-md-8">
											            <asp:textbox id="TextBox4" autocomplete="off" class="form-control" runat="server"></asp:textbox>
										            </div>
									           </div>
								           </div>
							         </div>
							        
							            <div class="form-actions right">
                                            <asp:Button ID="Button2" runat="server" class="btn green" Text="Bakiye Raporu" /> 
							            </div> 
							            
							            
							            <div id="validationresult2">
							                <asp:Label ID="durumlabel2" runat="server"></asp:Label>   
					                    </div>   
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- İKİNCİ RAPOR PORTLATE-->
					
					
					
					   <!-- ÜÇÜNCÜ RAPOR PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bullhorn"></i>Hesap Haraketlerinin Aylara Göre Dağılımı
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					        	        	   
						</div>
									
						<div class="portlet-body form">
																		
					        <div class="form-body">
							        
							         <div class="row">   
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Şirket:</label>
										            <div class="col-md-8">
											            <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
										            </div>
									            </div>
								            </div>
								            
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Yıl:</label>
										            <div class="col-md-8">
											            <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
										            </div>
									            </div>
								            </div>
							         </div>
							          
							         			         
							            <div class="form-actions right">
                                            <asp:Button ID="Button5" runat="server" class="btn yellow" 
                                                Text="Aylara Göre Dağılım Detaylı" /> 
                                            <asp:Button ID="Button6" runat="server" class="btn blue" 
                                                Text="Aylara Göre Dağılım (Adet)" /> 
							            </div>
							          
							          
						                <div id="validationresult3">
							                <asp:Label ID="durumlabel3" runat="server"></asp:Label>  
					                    </div>        
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- ÜÇÜNCÜ RAPOR PORTLATE-->
					
					
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/faturarapor.js"></script>

 




