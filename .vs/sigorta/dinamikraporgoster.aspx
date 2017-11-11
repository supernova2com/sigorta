<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dinamikraporgoster.aspx.vb" Inherits="sigorta.dinamikraporgoster" %>


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
					Dinamik Raporlar<small>Dinamik Rapor Sonucu</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li class="btn-group">
							<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
							<span>
								Dinamik Rapor Sonuçları
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
								Raporlar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="dinamikrapor.aspx">
								Dinamik Raporlar
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
								
                           <p>Yaratmış olduğunuz dinamik rapor sonucunu bu ekrandan takip edebilirisiniz.</p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
					
					   <!-- LOG PORTLATE-->
					<div class="portlet box yellow">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bell-o"></i>Çalıştırma Logu
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
				
								<a href="javascript:;" class="remove"></a>
							</div>
							
				
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                            <asp:label id="labellog" runat="server" text=""></asp:label>
							
						</div>
					</div>
					<!-- LOG PORTLATE-->
					

					
					
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>
                                <asp:label runat="server" id="Labelraporbaslik" text="Label"></asp:label>
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
								<div class="btn-group pull-right">	
								    <asp:Button ID="Buttonpdfdinamik" class="btn red" runat="server" Text="PDF" />
									<asp:Button ID="Buttonexceldinamik" class="btn blue" runat="server" Text="EXCEL" />
									<asp:Button ID="Buttonworddinamik" class="btn white" runat="server" Text="WORD" />	
								</div>			
							</div>
						
							<div class="table-toolbar">
							</div>

							  <h3> 
                                 <asp:label runat="server" id="Labelraporaciklama" text="Label"></asp:label>  
                              </h3>
                              
                              <asp:Label ID="Label1" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- DATATABLE PORTLATE-->
					
					
					
					<!-- GRAFİK PORTLATE-->
					<div id="gportlet" class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bar-chart-o"></i><span id="grafikbaslik"></span>
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
				
								<a href="javascript:;" class="remove"></a>
							</div>
							
				
						</div>
						<div class="portlet-body">	
						
						    <div id="dinamikraporchart" class="chart">
												
						</div>
					</div>
					<!-- GRAFİK PORTLATE-->
							          
							          
    
    
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/dinamikraporcore.js"></script>
<script type="text/javascript" src="js/dinamikraporgrafikgoster.js"></script>
 



