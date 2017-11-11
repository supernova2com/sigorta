<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kur.aspx.vb" Inherits="sigorta.kur" %>


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
					Döviz Kurları<small>Merkez Bankasından döviz kurlarını yükleyebilirsiniz.</small>
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
								Fiyatlar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
							    Döviz Kurları
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
								
                           <p>Döviz kurlarını bu ekrandan sorgulayabilir ve KKTC Merkez Bankasından 
                           çekerek sisteme yükleyebilirsiniz. </p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
				
					<!-- KUR ÇEKME PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Döviz Kurlarını KKTC Merkez Bankasından Al
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
	
	                          <div class="row">
							        <div class="col-md-6">
								        <div class="form-group">
									        <label class="control-label col-md-4">Başlangıç Tarihi:</label>
									        <div class="col-md-8">
                                                <asp:textbox id="TextBox3" class="form-control" runat="server"></asp:textbox>
									        </div>
								        </div>
							        </div>
							        <div class="col-md-6">
								        <div class="form-group">
									        <label class="control-label col-md-4">Bitiş Tarihi:</label>
									        <div class="col-md-8">
										       <asp:textbox id="TextBox4" class="form-control" runat="server"></asp:textbox>
									        </div>
								        </div>
							        </div>
						        </div>
                                                
                            
                          	<div class="form-actions right">
                                <asp:Button ID="Button1" runat="server" class="btn green" Text="Bağlan ve Kurları Çek" /> 
							</div>
							
						
						    <div id="validationresult">
							    <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					        </div>  														
						 
					
						</div>
					</div>
					<!-- KUR ÇEKME PORTLATE-->
					
					
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
						
							
						<div class="portlet-body form">
																													
					        <div class="form-body">
							        
						        <div class="row">
							        <div class="col-md-4">
								        <div class="form-group">
									        <label class="control-label col-md-5">Başlangıç Tarihi:</label>
									        <div class="col-md-7">
                                                <asp:textbox id="TextBox1" class="form-control" runat="server"></asp:textbox>
									        </div>
								        </div>
							        </div>
							        <div class="col-md-4">
								        <div class="form-group">
									        <label class="control-label col-md-4">Bitiş Tarihi:</label>
									        <div class="col-md-8">
										       <asp:textbox id="TextBox2" class="form-control" runat="server"></asp:textbox>
									        </div>
								        </div>
							        </div>
							          <div class="col-md-4">
								        <div class="form-group">
									        <div class="col-md-8">
									            <asp:Button ID="Button2" runat="server" class="btn green" Text="Sorgula" /> 
									        </div>
								        </div>
							        </div>
						        </div> <!-- row -->
							
						    </div>
					
					    </div>
					
					</div>
					<!-- ARAMA PORTLATE-->
	
					
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Döviz Kurları
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
<script type="text/javascript" src="js/kur.js"></script>

 


