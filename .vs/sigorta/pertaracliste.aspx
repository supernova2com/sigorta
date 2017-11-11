<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pertaracliste.aspx.vb" Inherits="sigorta.pertaracliste" %>



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
					Pert Araçlar <small>Pert Araçlar İle İlgili İşlemler</small>
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
							<a href="defaultbilgiadmin.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="pertaracliste.aspx">
							    Pert Araç Listesi
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
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-sort-alpha-asc"></i>Gösterim Seçenekleri
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
				
								<a href="javascript:;" class="remove"></a>
							</div>
							
				
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
							
								   <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Marka:</label>
										        <div class="col-md-8">
                                                     <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
							        </div>
							
							        <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Sıralama:</label>
										        <div class="col-md-8">
                                                     <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Tek Sayfada Kaç Adet?</label>
										        <div class="col-md-8">
											       <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
							        </div>
							        	        
							
						</div>
					</div>
					<!-- GÖSTERİM SEÇENEKLERİ -->
					
					
					
		
		
					
					
		    <!-- BEGIN PAGE CONTENT-->
			<div class="row">
				<div class="col-md-12 blog-page">
					<div class="row">
						<div class="col-md-10 col-sm-9 article-block">
						    <h1>Pert Araçlar</h1>
                             <asp:label id="labelaracliste" runat="server" text="Label"></asp:label>
						</div>	
						
						
						<!--end col-md-9-->
						<div class="col-md-2 col-sm-3 blog-sidebar">
							<h3>Populer</h3>
							<div class="top-news">
								<a href="#" class="btn red">
									<span>
										 Mets
									</span>
									<em>Posted</em>
									<em>
									<i class="fa fa-tags"></i>
									Mole </em>
									<i class="fa fa-briefcase top-news-icon"></i>
								</a>
								<a href="#" class="btn green">
									<span>
										 Top Week
									</span>
									<em>Posted </em>
									<em>
									<i class="fa fa-tags"></i>
									Intere </em>
									<i class="fa fa-music top-news-icon"></i>
								</a>
								<a href="#" class="btn blue">
									<span>
										 Gold Price Falls
									</span>
									<em>Posted </em>
									<em>
									<i class="fa fa-tags"></i>
									USA, Business, Apple </em>
									<i class="fa fa-globe top-news-icon"></i>
								</a>
								<a href="#" class="btn yellow">
									<span>
										 Study Abroad
									</span>
									<em>Posted</em>
									<em>
									<i class="fa fa-tags"></i>
									Education, </em>
									<i class="fa fa-book top-news-icon"></i>
								</a>
								<a href="#" class="btn purple">
									<span>
										 Top Dest
									</span>
									<em>Posted3</em>
									<em>
									<i class="fa fa-tags"></i>
									Places, </em>
									<i class="fa fa-bolt top-news-icon"></i>
								</a>
							</div>
							<div class="space20">
							</div>
							
						
						
						</div>
						<!--end col-md-3-->
					</div>
						

                    <asp:label id="labelsayfalama" runat="server" text="Label"></asp:label>
					
						
				</div>
			</div>
			<!-- END PAGE CONTENT-->
				
				
					
					
	
					
			
							          
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/pertaracliste.js"></script>

