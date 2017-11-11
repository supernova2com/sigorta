<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="birlikpersoneltanim.aspx.vb" Inherits="sigorta.birlikpersoneltanim" %>


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
					Personel<small>Bu sayfada personelleri tanımlayabilirsiniz.</small>
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
								Personel
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
								
                           <p>'Yeni Kayıt' etiketli düğmeyi kullanarak 
                            tüm çalışanları sisteme ekleyebilirsiniz. Personel ismine göre arama yapabilir, 
                            dilediğiniz personel kaydı üzerinde düzenleme ve silme işlemi yapabilirsiniz.   </p>
							
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
                                         <asp:Button ID="Button1" runat="server" class="btn green" Text="Ara" />                                     
                                         <asp:Button ID="Button4" runat="server" class="btn green" Text="Onaylanmamışlar" />                               
                                    </div>
								</div>	
								
								
								<div class="form-group">						
									<label class="col-md-3 control-label">Kimlik Numarası:</label> 
									<div class="col-md-4">   
                                           <asp:TextBox ID="TextBox2" class="form-control" autocomplete="off" 
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">        
                                            <asp:Button ID="Button2" runat="server" class="btn green" 
                                            Text="Ara" />                              
                                    </div>
								</div>
								
									
								<div class="form-group">						
									<label class="col-md-3 control-label">TP Numarası:</label> 
									<div class="col-md-4">   
                                             <asp:TextBox ID="TextBox3" class="form-control" autocomplete="off" 
                                             runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">        
                                             <asp:Button ID="Button3" runat="server" class="btn green" 
                                             Text="Ara" />                          
                                    </div>
								</div>		

						</div>
					</div>
					<!-- ARAMA PORTLATE-->
							          
    
			
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Personel Bilgileri
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
								<a id="iframeyenikayit" runat="server" href="birlikpersonelgirispopup.aspx?op=yenikayit" class="btn green btn-sm">
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
					<!-- DATATABLE PORTLATE-->
							          
    
    
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/birlikpersoneltanim.js"></script>
 




