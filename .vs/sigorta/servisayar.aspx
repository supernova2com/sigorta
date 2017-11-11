<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="servisayar.aspx.vb" Inherits="sigorta.servisayar" %>
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
					Servis Ayarları<small></small>
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
								XML Web Servisleri
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Servis Ayarları
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
								
                           <p>Bu sayfada web servislerin davranışları ile ilgili ayarlamalar 
					        yapabilirsiniz. Bu sayfada yaptığınız ayarlar tüm sigorta şirketlerine yansıyacaktır.</p>
								
						    <asp:Label ID="Labeluyari" runat="server" style="color: #FF0000"></asp:Label>	
						    
						</div>
					
					</div>
					<!-- YARDIM PORTLATE-->
					
								
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>XML Web Servis Ayarları
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
					
					<h2>Poliçe Yükleme İle İlgili Ayarlar</h2>
						   
		                    <div class="form-group">
                                <label class="col-md-3 control-label"> Baz Fiyatları Logla ve Dikkate Al:</label>
                                <div class="col-md-4"> 
                                   <input runat="server" id="CheckBox1" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayarı kapatırsanız baz fiyat hesaplama logları sistemde tutulmaz.</span>
                                </div>
                            </div>   
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> IP Adreslerini Dikkate Al:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox2" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayarı kapatırsanız şirketler diledikleri ip adreslerinden 
                                    web servislerine bağlanabilir.</span>
                                </div>
                            </div> 
                            
                            
                              <div class="form-group">
                                <label class="col-md-3 control-label"> Tarife Kod Kontrolü:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox3" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayarı açarsanız 'Plaka' başka bir TariffCode 
                                    ile daha önce kaydedilmiş ise tekrar kayıt yapılmasına izin verilmez.
                                   </span>
                                </div>
                            </div> 
                            
                            
                              <div class="form-group">
                                <label class="col-md-3 control-label"> Sınır Kapısı Takvim Kontrolü:</label>
                                <div class="col-md-4"> 
                                    <input runat="server" id="CheckBox4" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayarı açarsanız sadece Takvim'de belirtmiş olduğunuz 
                                    görevli şirketler o günlerde poliçe yükleyebilirler.
                                   </span>
                                </div>
                            </div> 
                            
                               <div class="form-group">
                                <label class="col-md-3 control-label"> Son Zeyil  Kontrolü:</label>
                                <div class="col-md-5"> 
                                    <input runat="server" id="CheckBox5" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayarı açarsanız 'Gönderdiğiniz zeyilin bitiş tarihi, son zeyilin bitiş 
                                    tarihinden büyük olması kontrolünü' devreye almış olursunuz.
                                   </span>
                                </div>
                            </div> 
                            
                            
                               <div class="form-group">
                                <label class="col-md-3 control-label"> Ek Sürücü Kontrolü:</label>
                                <div class="col-md-5"> 
                                    <input runat="server" id="CheckBox6" 
                                    type="checkbox" checked class="make-switch switch-large" 
                                    data-label-icon="fa fa-fullscreen" 
                                    data-on-label="<i class='fa fa-check'></i>" 
                                    data-off-label="<i class='fa fa-times'></i>"> 
                                    <span class="help-block">Bu ayarı açarsanız 'İsme göre düzenlenen poliçelerde sigortalıya ilaveten en fazla 1 sürücü eklenilebilir kontrolünü' 
                                    devreye almış olursunuz.
                                   
                                </span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Düzenleme/Bitiş Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox7" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız 'Poliçenin düzenleme tarihi poliçenin bitiş
                                    tarihinden büyük olmamalıdır. (997)' kontrolünü devreye almış olursunuz. </span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Plaka Sınır Kapı Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox8" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız normal poliçeler için Plakanın ilk 3 karakteri
                                    harf ise veya Z veya T ile başlayıp plakanın ilk 4 karakteri rakam ise ve en fazla
                                    7 karakter ise kaydedilmesine izin verme kontrolünü devreye almış olursunuz. (Hata
                                    Kodu: 494) </span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Kiralık Araç Plaka Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox9" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız başı yada sonu Z ile biten plakalar için
                                    (ZZ dışında) tarife kodu sadece CZ406 veya CY70 olabilir kontrolünü devreye almış
                                    olursunuz. (Hata Kodu: 496) </span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Ticari Araç Plaka Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox10" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız başı T ile başlayan plakalar için (TR dışında)
                                    tarife kodu sadece CZ400,CZ600,CZ605,CZ300,CZ301 olabilir kontrolünü devreye almış
                                    olursunuz. (Hata Kodu: 495)</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                KKTC Plaka Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox11" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız KKTC Plaka gereklilikleri kontrol edilir.
                                    (Hata Kodu: 499)</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                RUM Plaka Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox12" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız RUM Plaka gereklilikleri kontrol edilir.
                                    (Hata Kodu: 498)</span>
                            </div>
                        </div>
                        
                        
                          <div class="form-group">
                            <label class="col-md-3 control-label">
                                R Zeyili Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox13" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız poliçe zeyili yükleren R zeyili geldiğinde poliçeye ait
                                 son zeyildeki kimlik no, plaka no ve otherfees in ayni olup olmadığı kontrol edilir. Ayni ise hata döner
                                (Hata Kodu: 555)</span>
                            </div>
                        </div>
                        
                        
                        
                        <h2>
                            Hasar Yükleme İle İlgili Ayarlar</h2>
                            
                            
                                    <div class="form-group">
                            <label class="col-md-3 control-label">
                                Hasar Kimlik Kontrolü:</label>
                            <div class="col-md-5">
                                <input runat="server" id="CheckBox14" type="checkbox" checked class="make-switch switch-large"
                                    data-label-icon="fa fa-fullscreen" data-on-label="<i class='fa fa-check'></i>"
                                    data-off-label="<i class='fa fa-times'></i>">
                                <span class="help-block">Bu ayarı açarsanız Hasar dosyalarındaki sürücü kimlik no ve talep eden kimlik no kontrolünü
                                devreye almış olursunuz. (Hata Kodu: 504 ve 509)</span>
                            </div>
                        </div>
                            
                            
                            
                            
                            
                        <div class="form-actions right">
                            <asp:button id="Button2" runat="server" class="btn green" text="Kaydet" />
                        </div>
                        <div id="validationresult">
                            <asp:label id="durumlabel" runat="server"></asp:label>
                        </div>
                    </div>
                </div>
                <!-- VERİ GİRİŞ PORTLATE-->
            </div>
            <!-- col md12 -->
        </div>
        <!-- row -->
    </div>
    <!-- page-content-wrapper -->
</div>
<!-- page content -->
</form>
<uc2:footer ID="footer" runat="server" />

<script type="text/javascript" src="js/servisayar.js"></script>

<uc3:headertemel ID="headertemel" runat="server" />
