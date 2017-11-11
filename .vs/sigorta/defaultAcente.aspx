<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="defaultAcente.aspx.vb" Inherits="sigorta.defaultacente" %>


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
			
		
		
			<!-- DATATABLE PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Kuzey Kıbrıs Sigorta Bilgi Merkezi
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
								<a href="javascript:;" class="reload"></a>
								<a href="javascript:;" class="remove"></a>
							</div>
							
							<div class="actions">
								
							</div>		
													
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                             <asp:label id="Label1" runat="server" text="Label"></asp:label>	
							
						</div>
					</div>
					<!-- DATATABLE PORTLATE-->
	
			
			

		</div>
	</div>
	<!-- END CONTENT -->
</div>
<!-- END CONTAINER -->

<uc2:footer id="footer" runat="server" />
<script type="text/javascript" src="js/defaultacente.js?rnd=35433545334645663"></script>
<script type="text/javascript" src="js/aktifsirketsec.js"></script>

<uc3:headertemel id="headertemel" runat="server" /> 
