﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sirketfatura.aspx.vb" Inherits="sigorta.sirketfatura" %>


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
					Faturalarım<small> Buradan KKSBM tarafından kesilen faturalarınızı görebilirsiniz.</small>
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
								Yönetim
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="sirketfatura.aspx">
							    Faturalar
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
	
	
					
					<!-- FATURALAR DATATABLE PORTLATE-->
					<div class="portlet box yellow">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Faturalarım
							</div>
							
						
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Labelfatura" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- FATURALAR DATATABLE PORTLATE-->
					
					
					
						<!-- ÖDEMELER DATATABLE PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Ödemelerim
							</div>
							
						
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Labelodeme" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- ÖDEMELER DATATABLE PORTLATE-->
							          
    
			
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/sirketfatura.js"></script>

 




