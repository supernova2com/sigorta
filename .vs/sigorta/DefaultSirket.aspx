<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DefaultSirket.aspx.vb" Inherits="sigorta.defaultsirket" %>

<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register src="headertemel.ascx" tagname="headertemel" tagprefix="uc3" %>

<uc1:header id="header1" runat="server" /> 


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
					Pano <small>istatistikler ve diğer bilgiler</small>
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
							<a href="#">
								Pano
							</a>
						</li>
					
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
				
			
			<!-- BEGIN DASHBOARD STATS GENERAL -->
			<div class="row">
				<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
						<div class="visual">
							<i class="fa fa-comments"></i>
						</div>
						<div class="details">
							<div class="number">
							<asp:literal id="Literaltoplampolice" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Poliçe
							</div>
						</div>
						<a class="more" href="#">
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
								<asp:literal id="Literaltoplamhasar" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Hasar
							</div>
						</div>
						<a class="more" href="#">
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
								<asp:literal id="Literaltoplamsirket" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Şirket
							</div>
						</div>
						<a class="more" href="#">
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
                                <asp:literal id="Literaltoplamacente" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Acente
							</div>
						</div>
						<a class="more" href="#">
							 Detaylar <i class="m-icon-swapright m-icon-white"></i>
						</a>
					</div>
				</div>
			</div>
			<!-- END DASHBOARD STATS GENERAL -->
			<div class="clearfix">
			</div>
			
			
			
			<!-- BEGIN DASHBOARD STATS ŞİRKETE ÖZEL -->
			<div class="row">
				<div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
						<div class="visual">
							<i class="fa fa-comments"></i>
						</div>
						<div class="details">
							<div class="number">
							<asp:literal id="Literaltoplampolice_sirketicin" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Poliçelerim
							</div>
						</div>
						<a class="more" href="#">
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
								<asp:literal id="Literaltoplamhasar_sirketicin" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Hasarlarım
							</div>
						</div>
						<a class="more" href="#">
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
								<asp:literal id="Literaltoplamsirket_sirketicin" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Şirketim
							</div>
						</div>
						<a class="more" href="#">
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
                                <asp:literal id="Literaltoplamacente_sirketicin" runat="server"></asp:literal>
							</div>
							<div class="desc">
								 Toplam Acentelerim
							</div>
						</div>
						<a class="more" href="#">
							 Detaylar <i class="m-icon-swapright m-icon-white"></i>
						</a>
					</div>
				</div>
			</div>
			<!-- END DASHBOARD STATS ŞİRKETE ÖZEL -->
			
			
			
			<div class="clearfix">
			</div>
			
			
				<div class="row">
				<!-- ŞİRKET POLİÇE GRAFİK -->
				<div class="col-md-6">
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-reorder"></i>Yüklenen Poliçelerin Zeyil Kodlarına Göre Dağılımı
							</div>
							<div class="tools">
								<a href="javascript:;" class="reload">
								</a>
							</div>
						</div>
						<div class="portlet-body">
							<div id="pie_chart3" class="chart">
							</div>
						</div>
					</div>
				</div>
				
				<!-- HASAR GRAFİK -->
				<div class="col-md-6">
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-reorder"></i>Yüklenen Poliçelerin Ürün Kodlarına Göre Dağılımı 
							</div>
							<div class="tools">
								<a href="javascript:;" class="reload">
								</a>
							</div>
						</div>
						<div class="portlet-body">
							<div id="pie_chart4" class="chart">
							</div>
						</div>
					</div>
				</div>
				
				
				</div>
			
			

		</div>
	</div>
	<!-- END CONTENT -->
</div>
<!-- END CONTAINER -->

<uc2:footer id="footer" runat="server" />
<script type="text/javascript" src="js/defaultsirket.js?rel=334536366665433545334645663"></script>
<script type="text/javascript" src="js/aktifsirketsec.js"></script>

<uc3:headertemel id="headertemel" runat="server" /> 
