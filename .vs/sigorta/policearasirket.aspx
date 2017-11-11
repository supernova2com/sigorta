<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="policearasirket.aspx.vb" Inherits="sigorta.policearasirket" %>

<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register src="headertemel.ascx" tagname="headertemel" tagprefix="uc3" %>
<uc1:header id="header1" runat="server" /> 


<!-- BEGIN FORM-->
<form id="form1" runat="server" class="form-horizontal">

	<!-- BEGIN CONTENT -->
	<div class="page-content-wrapper">
		<div class="page-content">
				<!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
			<div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 class="modal-title">Çalışacağınız Şirketi Seçiniz</h4>
						</div>
						<div class="modal-body">
						    <div class="row">
								<div class="col-md-12">
								    <h5> Aktif şirketi seçiniz.</h5>
									<p>
                                        <select  class="form-control" id="aktifsirketdrop">
                                            <option></option>
                                        </select>
									</p>			
								</div>
						    </div>
						</div> <!-- modal-body -->
						<div class="modal-footer">
							<button type="button" id="aktifsirketkaydetbutton" class="btn blue">Kaydet</button>
							<button type="button" class="btn default" data-dismiss="modal">Kapat</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- /.modal -->	
		
			<!-- BEGIN PAGE HEADER-->
			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN PAGE TITLE & BREADCRUMB-->
					<h3 class="page-title">
					Poliçe Arama<small> Poliçeleri bu ekrandan sorgulayabilirsiniz.</small>
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
								Arama
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Poliçe Sorgulama
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
							        
							      
							        <!--
							         <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Ad:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox7" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									       <div class="form-group">
										        <label class="control-label col-md-4">Soyad:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox8" class="form-control" runat="server"></asp:textbox>
										        </div>
									         </div>
								          </div>
							         </div>
							         -->
							        
							        
							         <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Kimlik No:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox9" autocomplete="off" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Plaka No:</label>
										            <div class="col-md-8">
											        <asp:textbox id="TextBox10" autocomplete="off" class="form-control" runat="server"></asp:textbox>
										            </div>
									            </div>
								            </div>
							          </div>
							        
							        
							         
							        
							        
							            <div class="form-actions right">
                                            <asp:Button ID="Button1" runat="server" class="btn green" Text="Sorgula" /> 
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
								<i class="fa fa-globe"></i>Bulunan Sonuçlar
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
								    <asp:Button ID="Buttonpdfpolice" class="btn red" runat="server" Text="PDF" />
									<asp:Button ID="Buttonexcelpolice" class="btn blue" runat="server" Text="EXCEL" />
									<asp:Button ID="Buttonwordpolice" class="btn white" runat="server" Text="WORD" />	
								</div>			
							</div>
							
						    <h1 runat="server" id="policebaslik">Poliçeler</h1>	
                            <asp:Label ID="Label1" runat="server"></asp:Label>	
                            
                            <div class="table-toolbar">	
                                <div class="btn-group pull-right">	
								    <asp:Button ID="Buttonpdfhasar" class="btn red" runat="server" Text="PDF" />
									<asp:Button ID="Buttonexcelhasar" class="btn blue" runat="server" Text="EXCEL" />
									<asp:Button ID="Buttonwordhasar" class="btn white" runat="server" Text="WORD" />	
							    </div>
							</div>	
                           
                            <h1 runat="server" id="hasarbaslik">Hasarlar</h1>
                            <asp:Label ID="Label2" runat="server"></asp:Label>		
							
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
<script type="text/javascript" src="js/policearasirket.js?rnd=345623464536"></script>
<script type="text/javascript" src="js/aktifsirketsec.js"></script>

 

