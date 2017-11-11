<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="logerror.aspx.vb" Inherits="sigorta.logerror" %>


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
					Hata Logları<small>Sistemde oluşan hataları bu ekrandan takip edebilirsiniz.</small>
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
								Sistem Logları
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Hata Logları
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
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Başlangıç Tarihi:</label>
										        <div class="col-md-8">
                                                    <asp:textbox id="TextBox1" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Bitiş Tarihi:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox2" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
							        </div>
						
						
						
							         <div class="row">
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Kullanıcı:</label>
										            <div class="col-md-8">
											            <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
										            </div>
									            </div>
								            </div>
							         </div>
							        
							       
							         <div class="form-actions right">
                                        <asp:Button ID="Button1" runat="server" class="btn green" Text="Sorgula Rapor İçin" /> 
                                        <asp:Button ID="Button2" runat="server" class="btn yellow" Text="Sorgula İşlem İçin" /> 
							         </div>
							          
							          
						             <div id="validationresult">
							            <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					                 </div>        
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- ARAMA PORTLATE-->
							          
    
			
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Arama Sonuçları
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
								
								<div class="btn-group pull-right">	
								    <asp:Button ID="Buttonpdf" class="btn red" runat="server" Text="PDF" />
									<asp:Button ID="Buttonexcel" class="btn blue" runat="server" Text="EXCEL" />
									<asp:Button ID="Buttonword" class="btn white" runat="server" Text="WORD" />	
								</div>	
								
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
<script type="text/javascript" src="js/logerror.js"></script>

 




