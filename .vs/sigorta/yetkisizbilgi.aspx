﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="yetkisizbilgi.aspx.vb" Inherits="sigorta.yetkisizbilgi" %>


<%@ Register src="headerbilgi.ascx" tagname="header" tagprefix="uc1" %>
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
					Yetkisiz<small></small>
					</h3>
				    <ul class="page-breadcrumb breadcrumb">
					
						<li>
							<i class="fa fa-home"></i>
							<a href="default.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
							<li>
							<a href="yetkisizbilgi.aspx">
								Yetkisiz
							</a>
							
						</li>
					
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
				<!-- BEGIN PAGE CONTENT-->
			<div class="row">
				<div class="col-md-12 page-404">
					<div class="number">
						 YETKİSİZ
					</div>
					<div class="details">
						<h3>Bu bölüme girmeye yetkili değilsiniz.</h3>
						<p>
							 Sizi anasayfanıza yönlendirebiliriz.<br/>
                            <asp:literal id="literalyonlenlink" runat="server"></asp:literal>
						</p>
					</div>
					
				</div>
		    </div>


	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 

 




