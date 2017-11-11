<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="tanimlanmisrapor.aspx.vb" Inherits="sigorta.tanimlanmisrapor" %>


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
			<div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 id="arabirimraporad" class="modal-title"></h4>
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
					Tanımlanmış Raporlar<small>Size özel tanımlanmış raporlar.</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li class="btn-group">
							<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
							<span>
								Tanımlanmış Raporlar
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
							<a href="tanımlanmisrapor.aspx">
								Tanımlanmışlar Raporlar
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
								
                           <p>Bu ekrandan size özel olarak tanımlanan raporlara ulaşabilirsiniz.</p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					

					
					
					<!-- ÇALIŞTIR PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Tanımlanmış Rapor Çalıştır
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
									<label class="col-md-3 control-label">Seç:</label> 
									<div class="col-md-4">   
                                        <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
                                    </div>
                                    <div class="col-md-4">             
                                        <span class="btn green" id="Buttoncalistir" />Çalıştır</span>
                                    </div>
								</div>	
								
								
						    <div id="validationresult">
							    <asp:Label ID="durumvalidatelabel" runat="server"></asp:Label>  
					        </div>  
	
							
						</div>
					</div>
					<!-- ÇALIŞTIR PORTLATE-->
					
	
							          
 
    
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/dinamikrapor.js"></script>
<script type="text/javascript" src="js/dinamikraporcore.js"></script>
<script type="text/javascript" src="js/tanimlanmisrapor.js?rel=346346"></script>
 



