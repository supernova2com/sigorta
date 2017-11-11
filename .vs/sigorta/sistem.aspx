<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sistem.aspx.vb" enableEventValidation="false" Inherits="sigorta.sistem" %>
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
				<div class="modal-dialog modal-lg">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 class="modal-title">Bağlantı</h4>
						</div>
						<div class="modal-body">
						   <div class="row">
								<div class="col-md-12">
									
									
							        <div class="form-group">
                                        <label class="col-md-3 control-label"> Kaç Dakikalığına Kesilecek:</label>
                                        <div class="col-md-4"> 
                                            <asp:dropdownlist id="DropDownListKacDakika" runat="server" class="form-control"></asp:dropdownlist>
                                        </div>
                                    </div>
									
									
			
									
								</div>
						    </div> 
						    <span id="arabirimholder"></span>	  
						</div> <!-- modal-body -->
						<div class="modal-footer">
						      <button id="modelbutton" class="btn green"> Bağlantıyı Kes</button> 
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
					Sistem Ayarları<small>Bu sayfada sistem ayarlarını yapılandırabilirsiniz.</small>
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
								Ayarlar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Sistem Ayarları
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
								
                           <p>Burada sistem ile ilgili genel ayarları yapabilirisiniz.
                            Bu ayarlar ile oynamadan önce lütfen Supernova ile iletişime geçiniz. 
                            Yanlış bir ayar yapılması halinde sisteminiz düzgün çalışmayabilir.</p>
							
							<asp:Label ID="Labeluyari" runat="server" style="color: #FF0000"></asp:Label>
					
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
					<!-- SİSTEM VE DİSK BİLGİLERİ-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Sistem ve Disk Bilgileri
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
		
		
		                    <div class="row">
		                        
		                        <div class="col-md-12">
							        <asp:Label ID="sistembilgilabel" runat="server"></asp:Label>  
							    </div>    
							  
							    <div class="col-md-6">
							        <h3>Disk Bilgileri</h3>   
                                    Disk: <asp:DropDownList ID="DropDownList4" runat="server" class="textboxkucuk">
                                    </asp:DropDownList>
                                    <br/><br/>
                                    <asp:Label ID="diskbilgilabel" runat="server"></asp:Label>  
                                </div>
                                
                                <div class="col-md-6">
							       <div id="pie_chart" class="chart"></div>
							    </div>
							        
							</div> 
		 
						</div>
						 
							    
					</div>
					<!-- SİSTEM BİLGİLERİ PORTLATE-->
					
					
					
				    <!-- ONLINE KULLANICILAR -->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Online Kullanıcılar
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
		                    <div class="row"> 
		                        <div class="col-md-12">
                                    <asp:Label ID="labelonlinekullanici" runat="server"></asp:Label>  
                                </div>
							</div> 
						</div>
						 
							    
					</div>
					<!-- ONLINE KULLANICILAR PORTLATE-->
					
					
					
					
					 <!-- BAĞLANTISI KESİLMİŞ KULLANICILAR -->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Şu Anda Bağlantısı Kesilmiş Kullanıcılar
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
		                    <div class="row"> 
		                        <div class="col-md-12">
                                    <asp:Label ID="labelkesilmiskullanici" runat="server"></asp:Label>  
                                </div>
							</div> 
						</div>
						 
							    
					</div>
					 <!-- BAĞLANTISI KESİLMİŞ KULLANICILAR -->
					
					
					
								
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Sistem Ayarları
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
						
						    <h3>Genel Ayarlar</h3>   
						   
		                    <div class="form-group">
                                <label class="col-md-3 control-label"> Site Url:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textbox1" autocomplete="off" AutoCompleteType="Disabled" runat="server" size="254" 
                                    maxlength="254" type="text" class="form-control"/>
                                </div>
                            </div>   
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Site Yolu:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textbox13" autocomplete="off" AutoCompleteType="Disabled" runat="server" size="254" 
                                    maxlength="254" type="text" class="form-control"/>
                                </div>
                            </div> 
                           
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Site Yeri:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox33" autocomplete="off" AutoCompleteType="Disabled" runat="server" size="254" 
                                    maxlength="254" type="text" class="form-control"/>
                                </div>
                            </div>  
                                   
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Sistem Teması?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="textboxorta">
                                    </asp:DropDownList>
                                </div>
                            </div>  
                                        
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Sistem Hangi Veritabanını Kullansın?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList2" runat="server" class="textboxorta">
                                    </asp:DropDownList>
                                </div>
                            </div> 
                            
                                <div class="form-group">
                                <label class="col-md-3 control-label"> Kullanım Başlangıç Tarihi:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox2" autocomplete="off" AutoCompleteType="Disabled" runat="server" size="254" 
                                    maxlength="254" type="text" class="form-control"/>
                                </div>
                            </div>                   
                             
                            <h3>Müşteri Ayarları</h3>  
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> İsmi:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox5" autocomplete="off" AutoCompleteType="Disabled" runat="server" size="254" 
                                    maxlength="254" type="text" class="form-control"/>
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Ofis Telefonu:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox7" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div> 
                                              
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Fax:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox8" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div> 
                
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Cep Telefonu:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox9" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> E-Posta:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox10" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>  
                                                      
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Adres:</label> 
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox6" autocomplete="off" runat="server" class="form-control" 
                                    TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Copyright Yazısı:</label> 
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox11" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>  
                            
                            
                           <div class="form-group">
                              <label class="col-md-3 control-label"> Fatura Ödeme Son Günü:</label>
                              <div class="col-md-4"> 
                                 <asp:TextBox ID="TextBox18" runat="server" class="form-control"></asp:TextBox>         
                              </div>
                            </div>  
                            
                            
                              <h3>Üretici E-Posta Adresi</h3>  
                                  <div class="form-group">
                                <label class="col-md-3 control-label"> E-Posta:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox19" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                     <span class="help-block">Sistemde oluşan hatalar otomatik olarak burada yazdığınız e-posta adresine gönderilir.           
                                    </span>
                                </div>
                            </div> 
                              
                             
                             <h3>Posta Güvercini SMS Web Servisi Ayarları</h3>  
                              
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Posta Güvericini Kullanıcı Adı:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox ID="TextBox15" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>  
                            
                            
                            <div class="form-group">	
                                <label class="col-md-3 control-label">Posta Güvercini Şifre:</label>
                                <div class="col-md-4">  
                                    <asp:TextBox ID="TextBox16" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                        
							<h3>Güvenlik Ayarları</h3>  
			    
							<div class="form-group">
                              <label class="col-md-3 control-label"> Hatalı Şifre Sayısı:</label>
                              <div class="col-md-4"> 
                                 <asp:TextBox ID="TextBox17" runat="server" class="form-control"></asp:TextBox>
                                     <span class="help-block">Kullanıcı, şifresini 1 gün içerisinde 
                                     burada belirttiğiniz sayıda hatalı girdiği takdirde hesabı 'Aktif' durumdan 
                                     'Pasif' durumuna otomatik olarak çevrilir.            
                                    </span>
                              </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Rollerin Bulunduğu Tablo:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList3" runat="server" class="textboxorta">
                                    </asp:DropDownList>
                                     <span class="help-block">Kullanıcı rollerinin içerdiği yetkilerin 
                                     hangi tabloda tutulduğunu seçiniz.            
                                    </span>
                                </div>
                            </div>  

              
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Captcha:</label>
                                <div class="col-md-4"> 
                                   <input runat="server" id="CheckBox1" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme giriş yapılarken forma Captcha kontrolü ekler.</span>
                                </div>
                            </div> 
                            
                            
                                
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Poliçe Bilgileri Güncelleme:</label>
                                <div class="col-md-4"> 
                                 <asp:Button ID="Button3" runat="server" class="btn green" Text="Güncelle" /> 
                                 <asp:Button ID="Button4" runat="server" class="btn green" Text="Güncellenmeyen Adet" /> 
                                    <asp:label runat="server" text="" id="labeladet"></asp:label>
                                 <span class="help-block">PolicyInfo tablosundaki Color kolonunu şimdiki tarihe göre günceller. </span>
                                </div>
                            </div>   
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> CC Güncelleme:</label>
                                <div class="col-md-4"> 
                                 <asp:Button ID="Button5" runat="server" class="btn green" Text="CC Güncelle" /> 
                                 <span class="help-block">Araç kayıt dairesinden alınan ve lokal veritabanında saklanan<br/> 
                                 1. Motosiklet veya Motobisiklet tipinde ve 499 veya 4999 olan CC'leri 50CC'ye günceller.<br/>
                                 2. Motosiklet veya Motobisiklet tipinde ve 973 olan CC'leri 97CC'ye günceller.<br/>
                                 3. Motosiklet veya Motobisiklet tipinde ve 999 olan CC'leri 99CC'ye günceller.
                                </span>
                                </div>
                            </div>  
							
						
						  	<div class="form-actions right">
                                <asp:Button ID="Button2" runat="server" class="btn green" Text="Kaydet" /> 
							</div>
							
							
						    <div id="validationresult">
							    <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					        </div>  														
						 
					
						</div>
					</div>
					<!-- VERİ GİRİŞ PORTLATE-->
							          
    
			
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/sistem.js?rnd=363"></script>
 




