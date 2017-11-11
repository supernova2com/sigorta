<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="servisrapor.aspx.vb" Inherits="sigorta.servisrapor" %>


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
					Servis Raporları<small>Otomatik olarak oluşturulmuş raporlar.</small>
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
								Raporlar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="servisrapor.aspx">
								Servis Raporları
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
                 	
			        <!-- BİRİNCİ RAPOR PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bullhorn"></i>Servis Tarafından Oluşturulmuş Raporlar
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					        	        	   
						</div>
									
						<div class="portlet-body form">
																		
					        <div class="form-body">
							       
							        <div class="row">   
								            <div class="col-md-12">
                                                <asp:label runat="server" id="Label1" text=""></asp:label>
								            </div>
							         </div>
							          
							     
							              
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- BİRİNCİ RAPOR PORTLATE-->
					
					
					
					
				
										          
   			
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/servisrapor.js"></script>


 




