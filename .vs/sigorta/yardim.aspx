<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="yardim.aspx.vb" Inherits="sigorta.yardim" %>


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
							<h4 class="modal-title">Modal title</h4>
						</div>
						<div class="modal-body">
							 Widget settings form goes here
						</div>
						<div class="modal-footer">
							<button type="button" class="btn blue">Save changes</button>
							<button type="button" class="btn default" data-dismiss="modal">Close</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- /.modal -->
			<!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
			<!-- BEGIN PAGE HEADER-->
			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN PAGE TITLE & BREADCRUMB-->
					<h3 class="page-title">
					Yardım <small>Genel Yardım Konuları</small>
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
							<a href="yardim.aspx">
								Yardım
							</a>
						</li>
				
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			<!-- BEGIN PAGE CONTENT-->
			<div class="row">
				<div class="col-md-3">
					<ul class="ver-inline-menu tabbable margin-bottom-10">
						<li class="active">
							<a data-toggle="tab" href="#tab_1">
								<i class="fa fa-briefcase"></i> Sigortacılık Terimleri
							</a>
							<span class="after">
							</span>
						</li>
						<!--
						<li>
							<a data-toggle="tab" href="#tab_2">
								<i class="fa fa-group"></i> Web Servis Dokümantasyonu
							</a>
						</li>
						
						<li>
							<a data-toggle="tab" href="#tab_3">
								<i class="fa fa-leaf"></i> Terms Of Service
							</a>
						</li>
						<li>
							<a data-toggle="tab" href="#tab_1">
								<i class="fa fa-info-circle"></i> License Terms
							</a>
						</li>
						<li>
							<a data-toggle="tab" href="#tab_2">
								<i class="fa fa-tint"></i> Payment Rules
							</a>
						</li>
						<li>
							<a data-toggle="tab" href="#tab_3">
								<i class="fa fa-plus"></i> Other Questions
							</a>
						</li>
						-->
					</ul>
				</div>
				<div class="col-md-9">
					<div class="tab-content">
						<div id="tab_1" class="tab-pane active">
							<div id="accordion1" class="panel-group">
								<div class="panel panel-success">
									<div class="panel-heading">
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_1">
											 1. TEAP
										</a>
										</h4>
									</div>
									<div id="accordion1_1" class="panel-collapse collapse in">
										<div class="panel-body">
											 Tavsiye Edilen Asgari Prim anlamına gelmektedir.
										</div>
									</div>
								</div>
								<div class="panel panel-success">
									<div class="panel-heading">
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_2">
											 2. Tecdit
										</a>
										</h4>
									</div>
									<div id="accordion1_2" class="panel-collapse collapse">
										<div class="panel-body">
											 Sigorta poliçeleri 1 yıl süre için hazırlanır. Yıl sonunda yapılan poliçenin yenilenmesine tecdit
                                             denir. Tecdit müşterinin isteği doğrultusunda tanzim edilir.
										</div>
									</div>
								</div>
								<div class="panel panel-success">
									<div class="panel-heading">
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_3">
											 3. Prim
										</a>
										</h4>
									</div>
									<div id="accordion1_3" class="panel-collapse collapse">
										<div class="panel-body">
											 Sigortacılıkta prim, sigortanın satışını yapan yetkili merci tarafından verilen teminatı satın almak
                                             için sigorta ettiren veya sigortalının ödediği sigorta ücretine denir. Prim her sigorta branşına göre
                                             farklı riziko şartlarına göre belirlenir. Sigorta primleri branş dışında poliçedeli teminatlar ve kişinin 
                                             özellik ve ihtiyaçlarına göre değişkenlik gösterir.
										</div>
									</div>
								</div>
								<div class="panel panel-success">
									<div class="panel-heading">
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_4">
											 4. Poliçe
										</a>
										</h4>
									</div>
									<div id="accordion1_4" class="panel-collapse collapse">
										<div class="panel-body">
											 <p>Poliçe, sigorta anlaşmasının yazılı şeklidir. Bu belgenin içeriğinde bulunması gereken bilgiler şunlardır:</p>
                                                
                                                <p>1. Sigortacı ile sigortalı / sigorta ettirenin ve varsa menfaattarın ismi, adresi</p>
                                                <p>2. Sigortanın konusu ve Verilen teminatlar</p>
                                                <p>3. Teminat başlangıç ve bitiş tarihleri</p>
                                                <p>4. Sigorta bedeli</p>
                                                <p>5. Prim tutarı ve ödeme şartları</p>
                                                <p>6. Tanzim tarihi</p>
										</div>
									</div>
								</div>
								<div class="panel panel-success">
									<div class="panel-heading">
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_5">
											 5. Risk
										</a>
										</h4>
									</div>
									<div id="accordion1_5" class="panel-collapse collapse">
										<div class="panel-body">
                                            Gerçekleşmemiş,Gerçekleşme ihtimali olan,Ne zaman gerçekleşeceği belli olmayan ve Gerçekleşeceği takdirde maddi/manevi kayba neden olan olaylardır
										</div>
									</div>
								</div>
								
							</div>
						</div>
						<div id="tab_2" class="tab-pane">
							<div id="accordion2" class="panel-group">
								<div class="panel panel-success">
									<div class="panel-heading">
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_1">
											 1. Web Servis Dokümantasyonu
										</a>
										</h4>
									</div>
									<div id="accordion2_1" class="panel-collapse collapse in">
										<div class="panel-body">
											
											<!--
											<p>
												 Geliştiriciler için web servis dokümantasyonunu buradan <a target="_blank" href="KKSBM-XMLAPI.doc"> indirebilirsiniz.</a>
											</p>
											-->
										
										</div>
									</div>
								</div>
					
						
							</div>
						</div>
					
					</div>
				</div>
			</div>
			<!-- END PAGE CONTENT-->
		</div>
	</div>
	<!-- END CONTENT -->
</div>
<!-- END CONTAINER -->

<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/yardim.js"></script>

