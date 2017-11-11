<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sirkettakvim.aspx.vb" Inherits="sigorta.sirkettakvim" %>


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
	        <div class="modal fade" id="fullCalModal" >
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 class="modal-title">İşlem Bilgileri</h4>
						</div>         
                        <div id="modalBody" class="modal-body">
                            <div class="row">
							    <div class="col-md-12">
								    
                                    <asp:label id="takvimbilgilabel" runat="server" text=""></asp:label>
								    		
						        </div>
						    </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" id="Button1" class="btn blue">Kaydet</button>
			                <button type="button" class="btn default" data-dismiss="modal">Kapat</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.modal -->	
		
		
			<!-- BEGIN PAGE HEADER-->
			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN PAGE TITLE & BREADCRUMB-->
					<h3 class="page-title">
					Takvim<small>Şirketinizin yüklemiş olduğu verileri bu ekrandan takvim şeklinde takip edebilirsiniz.</small>
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
							<a href="defaultsirket.aspx">
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
							<a href="sirkettakvim.aspx">
							    Veri Yükleme Takvimi
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
					<!-- CALENDAR-->
					<div class="portlet box blue calendar">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-calendar"></i>Takvim
							</div>
						</div>
						<div class="portlet-body light-grey">
							<p>Toplu aktarımlar bittiğinde şirket takvimi devreye girecektir.</p>
							<div id="calendar">
							</div>
						</div>
					</div>
					<!-- CALENDAR -->
	
							          
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/sirkettakvim.js"></script>
<script type="text/javascript" src="js/aktifsirketsec.js"></script>
<script type="text/javascript" src="js/takvim-disable.js"></script>



 




