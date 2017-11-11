<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kullanicirol.aspx.vb" Inherits="sigorta.kullanicirol" %>

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
					Roller<small>Bu sayfada kullanıcı rollerini düzenleyebilirsiniz.</small>
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
								Kullanıcı Yönetimi
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Kullanıcı Rolleri
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
								
                           <p>Bu bölümden farklı kullanıcı rollerini tanımlayabilirsiniz. 
                           Daha sonra tanımlamış olduğunuz bu kullanıcı rollerini, kullanıcılara 
                           atayabilirsiniz.</p>
							
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Yeni Kullanıcı Rolü
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
                                <label class="col-md-3 control-label"> Rol Adı:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textbox1" AutoCompleteType="Disabled" runat="server"
                                    maxlength="254" class="form-control"/>
                                </div>
                            </div> 
                                    
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Mensup:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList2"  class="form-control"  runat="server">
                                    </asp:DropDownList> 
                                    <span class="help-block">Bu rolün altında tanımlayacağınız kullanıcılar eğer 
                                    Sigorta Bilgi Merkezi personeli ise bu rolü kaydederken bu alanı KKSBM'yi seçiniz.
                                    Değil ise Diğer seçeneğini seçiniz.
                                    </span> 
                                </div>
                            </div> 
                                               
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yönlendirileceği Sayfa:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textbox2" AutoCompleteType="Disabled" runat="server"
                                    maxlength="254" class="form-control"/>
                                    <span class="help-block">Kullanıcının sisteme giriş yaptıktan sonra 
                                    hangi sayfaya yönleneceğini ayarlayınız. Örnek olarak 'default.aspx' gibi.</span>
                                </div>
                            </div>
                                     
	                        <div class="form-group">
                                <label class="col-md-3 control-label"> Menusu:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList1"  class="form-control"  runat="server">
                                    </asp:DropDownList> 
                                    <span class="help-block">Ayarlar bölümünde 'Ana Menu' ve 'Menu' kısmından ayarladığınız
                                    hangi menuyu kullanıcının göreceğini buradan ayarlayabilirsiniz.
                                    </span> 
                                </div>
                            </div> 
                                       
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Bu Rol Şirket Tarafında Gözüksün mü?</label>
                                <div class="col-md-4">               
                                    <input runat="server" id="CheckBox21" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bunu aktif yaparsanız şirket tarafındaki kullanıcı 
                                    yaratmaya yetkili kişiler bu rolde kullanıcılar yaratabileceklerdir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Bu Rol Sadece Merkez Acente altında yaratılabilsin mi?</label>
                                <div class="col-md-4">               
                                    <input runat="server" id="CheckBox41" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bunu aktif yaparsanız bu rol sadece merkez acentelerin altındaki 
                                    kullanıcılar için tanımlanılabilecektir.</span>
                                </div>
                            </div>   
                                      
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Tüm Şirket Bilgilerine Erişim:</label>
                                <div class="col-md-4">               
                                    <input runat="server" id="CheckBox1" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayar açık ise Poliçe Sahibinin adı soyadı açık şekilde gösterilir. Kapalı ise
                                    poliçe sahibinin adının ve soyadının sadece baş harfleri gösterilir.</span>
                                </div>
                            </div> 
                            
                            <h3>Pano Erişim</h3>
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Pano Erişim:</label>
                                <div class="col-md-4"> 
                                     <input runat="server" id="CheckBox2" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Pano bölümüne erişebilir.</span>
                                </div>
                            </div> 
                            
                           <h3>İşlem Erişim</h3>
                           
                           
                            <div class="form-group">
                                <label class="col-md-3 control-label"> İptal Listesi Erişim:</label>
                                <div class="col-md-4"> 
                                   <input runat="server" id="CheckBox51" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'İptal Listesi' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                              
                            <div class="form-group">
                                <label class="col-md-3 control-label"> İşlem Erişim:</label>
                                <div class="col-md-4"> 
                                   <input runat="server" id="CheckBox3" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Hasar İptali' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                           <h3>Arama Erişim</h3>
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Arama Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox4" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Arama' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Admin Poliçe Arama Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox43" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Poliçe Sorgulama' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Admin Hasar Arama Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox44" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Hasar Sorgulama' menüsüne erişebilir.</span>
                                </div>
                            </div>
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Para Kambiyo Arama Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox52" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Para Kambiyo Dairesi için özel olarak hazırlanan arama ekranına erişebilir.</span>
                                </div>
                            </div>  
                            
                            
                           <h3>Tanımlar Erişim</h3>
                           
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Tanımlar Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox5" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox22" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Şirket" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Acente Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox23" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Acente" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Acente Tipleri Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox38" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Acente Tipleri" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Personel Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox24" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Personel" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Araç Tarife Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox25" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Araç Tarife" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Ülke Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox26" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Ülke" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                                  
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Zeyil Kod Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox29" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Zeyil Kodları" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                           
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Ürün Kod Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox30" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Ürün Kodları" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Para Birimi Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox31" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Para Birimleri" menusune erişebilir.</span>
                                </div>
                            </div>
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Hasar Durum Kod Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox33" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Hasar Durum Kodları" menusune erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Poliçe Tip Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox36" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Poliçe Tipleri" menusune erişebilir.</span>
                                </div>
                            </div>  
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Kimlik Tür Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox42" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Tanımlamalar' menüsüne altındaki "Kimlik türleri" menusune erişebilir.</span>
                                </div>
                            </div>
                            
                            
     
                   
                           <h3>Fiyatlar Erişim</h3>
                           
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Fiyatlar Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox6" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Fiyatlar' menüsüne erişebilir.</span>
                                </div>
                            </div>
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Baz Fiyat Giriş Süresi Ayarlama:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox39" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Fiyatlar' menüsüne altında 'Baz Fiyat Giriş Süre' başlığı
                                    altına erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                          <div class="form-group">
                                <label class="col-md-3 control-label"> Döviz Kurları:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox45" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Fiyatlar' menüsüne altında 'Döviz Kurları' başlığı
                                    altına erişebilir.</span>
                                </div>
                            </div> 
                           
                           
                            
                         <h3>Belge Yönetimi</h3>
                         
                         
                         <div class="form-group">
                                <label class="col-md-3 control-label"> Birlik Personeli İçin Personel Tanım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox49" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Belge Yönetimi' menüsüne altındaki "Personel" menusune erişebilir.</span>
                                </div>
                            </div>    
                            
                         
                         <div class="form-group">
                                <label class="col-md-3 control-label"> Acente Sicil Kayıt Belgesi Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox7" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Belge Yönetimi' menüsü altında 'Acente Sicil Kayıt Belgesi' başlığı altına erişebilir.</span>
                                </div>
                         </div> 
                         
                         
                         <div class="form-group">
                                <label class="col-md-3 control-label"> Teknik Personel Belge Yönetimi Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox46" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Belge Yönetimi' menüsüne altında 'Teknik Personel Belgesi' başlığı altına erişebilir.</span>
                                </div>
                         </div> 
                         
                         
                        <div class="form-group">
                                <label class="col-md-3 control-label"> Bilgilendirme Eğitimi Katılım Belgesi Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox47" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Belge Yönetimi' menüsüne altında 'Bilgilendirme Eğitimi Katılım Belgesi' başlığı altına erişebilir.</span>
                                </div>
                         </div> 
                        
                        
                       <h3>Rapor Yetkileri</h3> 
                      
                        
                           <div class="form-group">
                                <label class="col-md-3 control-label">Özel Rapor Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox10" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Raporlar' menüsüne altındaki 'Özel Raporlar' başlığı altına erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label">Dinamik Rapor Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox48" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Raporlar' menüsüne altındaki 'Dinamik Raporlar' başlığı altına erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label">Tanımlanmış Dinamik Rapor Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox50" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Raporlar' menüsüne altındaki 'Tanımlanmış Raporlar' başlığı altına erişebilir.</span>
                                </div>
                            </div> 
                       
                            
                       <h3>Diğer Yetkiler</h3>
                                      
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Web Servis Ayarları Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox15" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'XML Web Servisleri' başlığı altındaki
                                    'Servis Ayarları' bölümüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Resim Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox8" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Resimler' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Kullanıcı Yönetimi Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox9" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Kullanıcı Yönetimi' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                             
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Faturalandırma Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox37" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Faturalandırma' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Log Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox11" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Sistem Logları' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                              
                          
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Ayar Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox13" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Ayarlar' menüsüne erişebilir.</span>
                                </div>
                            </div>
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Profil Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox16" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Ayarlar' menüsü altındaki 'Profilim'
                                    sayfasına erişebilir ve şifresini değiştirebilir.</span>
                                </div>
                            </div> 
                            
                          <h3>Şirket Tarafındaki Erişimler</h3>
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket/Acente Bölümünde Arama Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox14" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme şirket yada acente olarak giriş yapıldığında sorgulama 
                                    yetkisinin olup olmayacağı ile ilgili ayar.</span>
                                </div>
                            </div> 

                                  
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket/Acente Bölümünde Raporlara Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox20" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme şirket yada acente olarak giriş yapıldığında raporlara
                                    girmeye yetkili olup olmayacağı ile ilgili ayar.</span>
                                </div>
                            </div>  
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket/Acente Bölümünde Yeni Kullanıcı Yaratma:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox17" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme şirket yada acente olarak giriş yaptıktan 
                                    sonra kendi şirketi altında yeni kullanıcılar yaratabilir.</span>
                                </div>
                            </div> 
                            
                            
                              <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket/Acente Bölümünde Kullanıcı Listeleme:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox28" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme şirket yada acente olarak giriş yaptıktan 
                                    sonra kendi şirketi altında tanımlanmış olan tüm kullanıcıları listeleyebilir.</span>
                                </div>
                            </div>
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket/Acente Bölümünde Yeni Acente Yaratma:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox32" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme şirket yada acente olarak giriş yaptıktan 
                                    sonra kendi şirketi altında yeni merkez olmayan acenteler yaratabilir.</span>
                                </div>
                            </div> 
                            
                                                             
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Şirket/Acente Bölümünde Baz Fiyat Girişi Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox40" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sisteme şirket yada acente olarak giriş yapıldığında şirket
                                    için baz fiyatı girişi yapıp yapamayacağı ile ilgili ayar.</span>
                                </div>
                            </div>  
                                              
                            <h3>İletişim ile İlgili Erişimler</h3>
     
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Mesaj Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox12" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Mesajlarım' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Dosya Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox19" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Dosyalarım' menüsüne erişebilir.</span>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Toplu Mesaj Gönderme Yetkisi:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox18" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Belirli bir kullanıcı grubunun tümüne 
                                    yada tüm kullanıcılara ayni anda mesaj gönderebilir.</span>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Sadece Şirket İçi Mesajlaşma:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox34" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Seçmeniz halinde sadece kendi şirketi içindeki kullanıcılar 
                                    ile mesajlaşabilir.</span>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Sadece Şirket İçi Dosya Paylaşımı:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox35" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Seçmeniz halinde sadece kendi şirketi içindeki kullanıcılara 
                                    dosya gönderip alabilir.</span>
                                </div>
                            </div> 
                            
     
                            
                           <h3>Yardım Bölümüne Erişimler</h3>
     
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yardım Erişim:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox27" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Sol menüdeki 'Yardım' menüsüne erişebilir.</span>
                                </div>
                            </div> 
                            
                            
                            <div class="form-actions right">
                                <asp:Button ID="Button1" runat="server" class="btn green" Text="Kaydet" /> 
                                <asp:Button ID="Buttonsil" runat="server" class="btn green" Text="Sil" /> 
							</div>
         					
						    <div id="validationresult">
						        <asp:Label ID="durumlabel" runat="server"></asp:Label>  
						    </div> 			

						</div>
					</div>
					<!-- VERİ GİRİŞ PORTLATE-->
					
					

					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Kullanıcı Grupları
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
									<asp:Button ID="Buttonyenikayit" runat="server" class="btn green" Text="Yeni Kayıt" /> 
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
<script type="text/javascript" src="js/kullanicirol.js"></script>
<uc3:headertemel id="headertemel" runat="server" /> 
 

