<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="defaultbilgiuyeadmin.aspx.vb" Inherits="sigorta.defaultbilgiuyeadmin" %>


<%@ Register src="headerbilgi.ascx" tagname="header" tagprefix="uc1" %>
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
				<div class="modal-dialog modal-lg">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 class="modal-title">Detaylar</h4>
						</div>
						<div class="modal-body">
						   <div class="row">
								<div class="col-md-12">
									<p id="arabirimraporaciklama"></p>	
								</div>
						    </div> 
						    <span id="arabirimholder"></span>	  
						</div> <!-- modal-body -->
						<div class="modal-footer">
						    <asp:Button ID="raporolusturbutton" runat="server" class="btn green" Text="Raporu Oluştur" /> 					
		                    <!--
							<button type="button" data-dismiss="modal" class="btn blue">Kapat</button>
							-->
							
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
					Pano <small>istatistikler ve diğer bilgiler</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li>
							<i class="fa fa-home"></i>
							<a href="defaultbilgiadmin.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="defaultbilgiadmin.aspx">
								Pano
							</a>
						</li>
					
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
				
			
			<!-- BEGIN DASHBOARD STATS -->
			<div class="row">
				<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
						<div class="visual">
							<i class="fa fa-comments"></i>
						</div>
						<div class="details">
							<div class="number">
							<asp:literal id="Literaltoplamuye" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Üye
							</div>
						</div>
						<a class="more" href="webuye.aspx">
							 Detaylar <i class="m-icon-swapright m-icon-white"></i>
						</a>
					</div>
				</div>
				<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat green">
						<div class="visual">
							<i class="fa fa-shopping-cart"></i>
						</div>
						<div class="details">
							<div class="number">
								<asp:literal id="Literaltoplampertarac" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Pert Araç
							</div>
						</div>
						<a class="more" href="pertarac.aspx">
							 Detaylar <i class="m-icon-swapright m-icon-white"></i>
						</a>
					</div>
				</div>
				<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat purple">
						<div class="visual">
							<i class="fa fa-globe"></i>
						</div>
						<div class="details">
							<div class="number">
								<asp:literal id="Literaltoplamoys" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam ÖYS
							</div>
						</div>
						<a class="more" href="oys.aspx">
							 Detaylar <i class="m-icon-swapright m-icon-white"></i>
						</a>
					</div>
				</div>
				<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat yellow">
						<div class="visual">
							<i class="fa fa-bar-chart-o"></i>
						</div>
						<div class="details">
							<div class="number">
                                <asp:literal id="Literaltoplamoym" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam ÖYA
							</div>
						</div>
						<a class="more" href="oym.aspx">
							 Detaylar <i class="m-icon-swapright m-icon-white"></i>
						</a>
					</div>
				</div>
			</div>
			<!-- END DASHBOARD STATS -->
			<div class="clearfix">
			</div>
	
	            <!-- GRAFİKLERE BAŞLADIK -->
	
			<div class="row">
	
			</div>
			
			

		</div>
	</div>
	<!-- END CONTENT -->
</div>
<!-- END CONTAINER -->

</form>

<uc2:footer id="footer" runat="server" />
<script type="text/javascript" src="js/defaultbilgiuyeadmin.js?rnd=23456"></script>


<uc3:headertemel id="headertemel" runat="server" /> 
