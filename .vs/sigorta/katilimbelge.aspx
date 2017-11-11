<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="katilimbelge.aspx.vb" Inherits="sigorta.katilimbelge" %>


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
					Bilgilendirme Eğitim Katılım Belgesi<small>Eğitim Katılım belgelerini oluşturabilirsiniz.</small>
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
								Belge Yönetimi
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Bilgilendirme Eğitim Katılım Belgesi
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
								
                           <p>Aşağıdaki tablodan belgesini hazırlamak istediğiniz personeli
                           seçebilir ve yazdırabilirsiniz.</p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
					
					<!-- ARAMA PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Arama
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
									<label class="col-md-3 control-label">Personel İsmi:</label> 
									<div class="col-md-4">   
                                        <asp:TextBox ID="TextBox1" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">        
                                         <asp:Button ID="Button3" runat="server" class="btn green" Text="Ara" />                                                              
                                    </div>
								</div>	
								
								    <div class="form-group">
                            <label class="col-md-3 control-label">
                                Verildiği Tarih:</label>
                            <div class="col-md-4">
                                <asp:textbox id="TextBox2" class="form-control" autocomplete="off" runat="server"></asp:textbox>
                            </div>
                        </div>
								
						</div>
					</div>
					<!-- ARAMA PORTLATE-->
								
					
					
								
			
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Teknik Personeller
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
                                <asp:button id="Button1" runat="server" class="btn green btn-sm" text="Seçtiğim Personel(ler)in Eğitim Belgelerini Oluştur" />
                                <asp:button id="Button2" runat="server" class="btn green btn-sm" text="Tümünü Oluştur" />
							</div>	
							

						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Label1" runat="server"></asp:Label>	
                           <asp:label id="Labeluyari" runat="server"></asp:label>
                           	
							
						</div>
					</div>
					<!-- DATATABLE PORTLATE-->
							          
    
    
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />
<script type="text/javascript" src="js/katilimbelge.js?rel=4556"></script>
<uc3:headertemel id="headertemel" runat="server" /> 

 



