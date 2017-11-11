<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="acente.aspx.vb" Inherits="sigorta.acente" %>


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
					Acente<small>Bu sayfada acenteleri tanımlayabilirsiniz.</small>
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
								Tanımlamalar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Acente
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
								
                           <p>'Yeni Kayıt' etiketli düğmeyi kullanarak yeni acente kaydı yapabilirsiniz.
                            Acente adına göre kayıtlar içinde arama yapabilirsiniz. İlgili kaydı seçerek o kayıt 
                            üzerinde değiştirme ve silme işlemleri gerçekleştirebilirsiniz. </p>
							
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
									<label class="col-md-3 control-label">Acente İsmi:</label> 
									<div class="col-md-4">   
                                         <input id="aratext1" type="text" class="form-control" />
                                    </div>
                                    <div class="col-md-4">   
                                         <button id="arabutton1" class="btn green"> Ara</button>                                       
                                    </div>
                                </div>
                                    
                                   
                                   <div class="form-group">	 
                                    <label class="col-md-3 control-label">Sicil Numarası:</label> 
									<div class="col-md-4">   
                                         <input id="aratext2" type="text" class="form-control" />
                                    </div>
                                    <div class="col-md-4">   
                                         <button id="arabutton2" class="btn green"> Ara</button>                                       
                                    </div>
                                    
								</div>	
								
								
							    <div id="validationresult">
							       <asp:Label ID="Labeluyari" runat="server"></asp:Label>  
					            </div>  
							
						</div>
					</div>
					<!-- ARAMA PORTLATE-->
							          
    
			
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Acente Bilgileri
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
								<a runat="server" id="iframeyenikayit" href="acentegirispopup.aspx?op=yenikayit" class="btn green btn-sm">
									<i class="fa fa-plus"></i> Yeni Kayıt
								</a>
								
								<asp:button id="Buttonaktifyap" runat="server" class="btn green btn-sm" text="Seçtiğim Acente(ler)i Aktif Yap" />
                                <asp:button id="Buttonpasifyap" runat="server" class="btn green btn-sm" text="Seçtiğim Acente(ler)i Pasif Yap" />
                                <asp:button id="Buttonaktifvepasif" runat="server" class="btn green btn-sm" text="Seçtiklerimi Aktif Diğerlerini Pasif Yap" />
                                
                                <asp:button id="Buttonpasifgoster" runat="server" class="btn purple btn-sm" text="Pasifler Göster" />
                                <asp:button id="Buttonaktifgoster" runat="server" class="btn blue btn-sm" text="Aktifleri Göster" />
                                
							</div>						
							
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Label1" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- DATATABLE PORTLATE-->
							          
    
    
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/acente.js?rel=3eryhrthrth464567"></script>
 




