<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="fatura.aspx.vb" Inherits="sigorta.fatura" %>

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
					Fatura<small>Şirketlere buradan fatura kesebilirsiniz.</small>
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
							<a href="#">
								Fatura
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
                 	
			        <!-- ARAMA PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bullhorn"></i>Fatura Oluştur
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
										        <label class="control-label col-md-4">Ay:</label>
										        <div class="col-md-8">
                                                    <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Yıl:</label>
										        <div class="col-md-8">
											        <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
							        </div>
						
						
							         <div class="row">   
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Poliçe Ederi:</label>
										            <div class="col-md-8">
											            <asp:textbox id="TextBox6" autocomplete="off" class="form-control" runat="server">1,25</asp:textbox>
										            </div>
									            </div>
								            </div> 
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Ürün Kodu:</label>
										            <div class="col-md-8">
											            <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
										            </div>
									            </div>
								            </div>
							         </div>
							        
							          
							        <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Poliçe Tipi:</label>
										        <div class="col-md-8">
											        <asp:dropdownlist id="DropDownList4" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Aktif:</label>
										            <div class="col-md-8">
											            <asp:dropdownlist id="DropDownList5" class="form-control" runat="server"></asp:dropdownlist>
										            </div>
									           </div>
								           </div>
							          </div>
							            
							         
							            <div class="form-actions right">
                                            <asp:Button ID="Button1" runat="server" class="btn green" Text="ARA" /> 
							            </div>
							          
							          
						                <div id="validationresult">
							                <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					                    </div>        
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- ARAMA PORTLATE-->

					
					
					<!-- İŞLEMLER PORTLATE -->
					<div id="islemportlet" runat="server" class="portlet box red">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-money"></i>İşlemler
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
						    <div class="portlet-body form">											
					            <div class="form-body">
					               <div class="row">	  
                                       <asp:Button ID="buttonsecfatura" class="btn green" runat="server" Text="Seçtiklerimi Faturalandır" />
                                       <asp:Button ID="buttonsecyazdir" class="btn blue" runat="server" Text="Seçtiklerimi Yazdır" />
                                       <asp:Button ID="buttonsecgonder" class="btn yellow" runat="server" Text="Seçtiklerime E-Posta Gönder" />	
							       </div>
					           </div>       
					         </div>					                 
                                    			
						</div>
					</div>	
					<!-- İŞLEMLER PORTLATE-->
					
					

				    <!-- DATATABLE PORTLATE -->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Faturalar
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
                                <span id="tumunusecbutton" class="btn green btn-sm"><i class="fa fa-check"></i>Tümünü Seç</span>
							</div>	
												
							
						</div>
						<div class="portlet-body">	
					
							 <h2><asp:Label ID="Labelbaslik" runat="server"></asp:Label></h2> 
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
<script type="text/javascript" src="js/fatura.js?rel=3grtgrtgh4564564"></script>

 



