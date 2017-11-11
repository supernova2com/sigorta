<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="hasariptal.aspx.vb" Inherits="sigorta.hasariptal" %>


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
					Hasar İptal<small>Dilediğiniz hasar yada poliçeyi bu ekrandan silebilir veya hasarları bu ekrandan iptal edebilirsiniz.</small>
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
								İşlemler
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Hasar İptali
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
						
						   <p>1. Toplu silme menüsünü kullanarak dilediğiniz şirkete ait tüm poliçe, hasar ve log dosyalarını silebilirsiniz.
								
                           <p>2. İşlem kısmından "Hasar İptal" seçerek İptal işlemi yapmak istediğiniz hasar kaydını aşağıdaki formu kullanarak 
                           arayınız. Bulunan kayıtlarda 'İptal' düğmesine basıp ilgili bilgileri girerek
                           hasarı iptal edebilirsiniz.</p>
                           
                           <p>3. İşlem kısmından "Hasar Silme" seçerek silmek istediğiniz hasar kaydını aşağıdaki formu kullanarak 
                           arayınız. Bulunan kayıtlarda 'Sil' düğmesine basıp ilgili bilgileri girerek
                           hasarı silebilirsiniz.</p>
                           
                           <p>4. İşlem kısmından "Poliçe Silme" seçerek silmek istediğiniz poliçe kaydını aşağıdaki formu kullanarak 
                           arayınız. Bulunan kayıtlarda 'Sil' düğmesine basıp ilgili bilgileri girerek
                           poliçeyi silebilirsiniz.</p>
							
							<asp:Label ID="Labeluyari" runat="server" style="color: #FF0000"></asp:Label>
					
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
				
					<!-- TOPLU SİLME PORTLATE-->
					<div class="portlet box blue">
						
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Toplu Poliçe,Hasar ve Log Silme İşlemleri
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
							            <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Şirket:</label>
										        <div class="col-md-8">
                                                    <asp:dropdownlist id="DropDownList4" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
							            </div>
							        </div>
							           


							         <div class="form-actions right">
                                        <asp:Button ID="Button_policesil" runat="server" class="btn red" Text="Poliçelerini Sil" /> 
                                        <asp:Button ID="Button_hasarsil" runat="server" class="btn red" Text="Hasarlarını Sil" /> 
                                        <asp:Button ID="Button_logsil" runat="server" class="btn red" Text="Loglarını Sil" /> 
							         </div>
							          
						     
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
							
					<!-- ARAMA PORTLATE-->
					<div class="portlet box blue">
						
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Hasar İptali, Hasar yada Poliçe Silme İşlemi İçin Arama
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
							            <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">İşlem:</label>
										        <div class="col-md-8">
                                                    <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
							            </div>
							        </div>
							           
							        
							        <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Başlangıç Tarihi:</label>
										        <div class="col-md-8">
                                                    <asp:textbox id="TextBox1" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Bitiş Tarihi:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox2" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
							        </div>
						
							        <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Şirket:</label>
										        <div class="col-md-8">
                                                    <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Ürün Kodu:</label>
										        <div class="col-md-8">
											        <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
										        </div>
									        </div>
								        </div>
							        </div>
						
							         <div class="row">
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Dosya No:</label>
										            <div class="col-md-8">
											            <asp:textbox id="TextBox3" class="form-control" runat="server"></asp:textbox>
										            </div>
									            </div>
								            </div>
								            <div class="col-md-6">
									            <div class="form-group">
										            <label class="control-label col-md-4">Poliçe No:</label>
										            <div class="col-md-8">
											            <asp:textbox id="TextBox6" class="form-control" runat="server"></asp:textbox>
										            </div>
									            </div>
								            </div>
							         </div>
							      
							         <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Sürücü Ad:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox9" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Sürücü Soyad:</label>
										            <div class="col-md-8">
											        <asp:textbox id="TextBox10" class="form-control" runat="server"></asp:textbox>
										            </div>
									            </div>
								            </div>
							          </div>
							          
							         <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Sürücü Kimlik No:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox7" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									       <div class="form-group">
										        <label class="control-label col-md-4">Sürücü Plaka No:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox8" class="form-control" runat="server"></asp:textbox>
										        </div>
									         </div>
								          </div>
							         </div>
							          
							          
							           <div class="row">
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Talep Eden Ad:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox11" class="form-control" runat="server"></asp:textbox>
										        </div>
									        </div>
								        </div>
								        <div class="col-md-6">
									        <div class="form-group">
										        <label class="control-label col-md-4">Talep Eden Soyad:</label>
										            <div class="col-md-8">
											        <asp:textbox id="TextBox12" class="form-control" runat="server"></asp:textbox>
										            </div>
									            </div>
								            </div>
							          </div>
							                       
							        
   
							        <div class="row">
							            <div class="col-md-6">
									       <div class="form-group">
										        <label class="control-label col-md-4">Talep Kimlik No:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox14" class="form-control" runat="server"></asp:textbox>
										        </div>
									         </div>
								         </div>
								        <div class="col-md-6">
									       <div class="form-group">
										        <label class="control-label col-md-4">Talep Plaka No:</label>
										        <div class="col-md-8">
											       <asp:textbox id="TextBox13" class="form-control" runat="server"></asp:textbox>
										        </div>
									         </div>
								          </div>
							         </div>
							             

							         <div class="form-actions right">
                                        <asp:Button ID="Button1" runat="server" class="btn green" Text="Sorgula" /> 
							         </div>
							          
							          
						            <div id="validationresult">
							           <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					                </div>        
							        
							        
						        </div> <!-- form body -->

						</div> <!-- portlet body -->
					</div>
					<!-- ARAMA PORTLATE-->
							          
    
			
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Bulunan Sonuçlar
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
						
							<div class="table-toolbar">
								
								<div class="btn-group pull-right">	
								    <asp:Button ID="Buttonpdf" class="btn red" runat="server" Text="PDF" />
									<asp:Button ID="Buttonexcel" class="btn blue" runat="server" Text="EXCEL" />
									<asp:Button ID="Buttonword" class="btn white" runat="server" Text="WORD" />	
								</div>	
								
							</div>
						
                            <asp:Label ID="Label2" runat="server"></asp:Label>		
							
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
<script type="text/javascript" src="js/hasariptal.js?rnd=3562346245"></script>

 



