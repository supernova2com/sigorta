﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="structurestyle.aspx.vb" Inherits="sigorta.structurestyle" %>


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
					Yapı Tarzı<small> Yapı Tarzı (StructureStyle) tanımlarını bu sayfadan yapabilirsiniz.</small>
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
								Yangın
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="structurestyle.aspx">
							   Yapı Tarzı (Structure Style)
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
	
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Yapı Tarzı Kaydı
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
                                <label class="col-md-3 control-label"> Yapı Tarzı Kodu:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="TextBox1" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Açıklama:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="TextBox2" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
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
								<i class="fa fa-globe"></i>Yapı Tarzi (Structure Style)
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
								<a href="javascript:;" class="reload"></a>
								<a href="javascript:;" class="remove"></a>
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
<script type="text/javascript" src="js/structurestyle.js"></script>

 





