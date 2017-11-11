<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="manuelrapor.aspx.vb" Inherits="sigorta.manuelrapor" %>



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
					Manuel Raporlar<small>Manuel rapor tanımlayabilirsiniz.</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li class="btn-group">
							<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
							<span>
								Manuel Raporlar
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
							<a href="manuelrapor.aspx">
								Manuel Raporlar
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
								
                           <p>Bu ekrandan manuel raporlar tanımlayabilirsiniz. Manuel raporlar arka plan servisleri vasıtası ile 
                           tanımlanan zamanlama ayarları ile belli zamanda çalışacaktır.</p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
	
					<!-- MANUEL RAPOR YARAT PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Tanımlanmış Manuel Raporlar
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
					
								<a  target="_blank" href="servisrapor.aspx" class="btn yellow btn-sm">
									<i class="fa fa-check"></i> Manuel Raporlar
								</a>
								
								<a id="iframeyenikayit" href="manuelraporpopup.aspx?op=yenikayit" class="btn green btn-sm">
									<i class="fa fa-plus"></i> Yeni Kayıt
								</a>
								
							</div>						
							
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Label1" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- MANUEL RAPOR YARAT PORTLATE-->
					
					
						<!-- KOPYALA PORTLATE-->
					<div class="portlet box yellow">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Raporun Kopyasını Oluştur
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
                                        <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
                                    </div>
                                    
                                    <div class="col-md-4">             
                                            <asp:Button ID="Button1" runat="server" class="btn red" Text="Oluştur" /> 
                                    </div>
								</div>	
								
								
						    <div id="Div1">
							    <asp:Label ID="durumvalidatelabel2" runat="server"></asp:Label>  
					        </div>  
	
							
						</div>
					</div>
					<!-- KOPYALA PORTLATE-->
					
					
					<!-- ÇALIŞTIR PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Manuel Rapor Çalıştır
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					        

						</div>
						
						<!-- ÇALIŞTIR PORTLATE-->	
						<div class="portlet-body">
																						
								<div class="form-group">						
									<label class="col-md-3 control-label">Seç:</label> 
									<div class="col-md-4">   
                                        <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
                                    </div>
                                    <div class="col-md-4">             
                                        <asp:button runat="server" class="btn green" text="Çalıştır" 
                                            onclick="Unnamed1_Click" />
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
<script type="text/javascript" src="js/manuelrapor.js"></script>

 



