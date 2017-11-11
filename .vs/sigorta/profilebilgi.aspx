<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profilebilgi.aspx.vb" Inherits="sigorta.profilebilgi" %>

<%@ Register src="headerbilgi.ascx" tagname="header" tagprefix="uc1" %>
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
					Profil<small>Bilgilerinizi buradan takip edebilirsiniz.</small>
					</h3>
				    <ul class="page-breadcrumb breadcrumb">
					
						<li>
							<i class="fa fa-home"></i>
							<a href="defaultbilgiadmin.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
							<li>
							<a href="profilebilgi.aspx">
								Profil
							</a>
							
						</li>
					
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
			   <div class="col-md-12">
			   		
				
				    <div class="note note-success">
					<h4 class="block">Merhaba <asp:literal id="literaladsoyad" runat="server"></asp:literal></h4>
					<p>
						Bu ekranı kullanarak profil bilgilerinizi, yetkilerinizi görüntüleyebilirsiniz. Aşağıdaki
						formu doldurarak şifrenizi değiştirebilirsiniz. 
					</p>
								
						<p class="text-primary">E-Posta:</p>
						<p><asp:literal id="literaleposta" runat="server"></asp:literal></p>
							
						<p class="text-primary">Kullanıcı Adı:</p>
						<p><asp:literal id="literalkullaniciad" runat="server"></asp:literal></p>
						
					    <p class="text-primary">Telefon:</p>
						<p><asp:literal id="literaltelefon" runat="server"></asp:literal></p>
						
						<p class="text-primary">Adres:</p>
						<p><asp:literal id="literaladres" runat="server"></asp:literal></p>
						
						<p class="text-primary">Üyelik Tipi:</p>
						<p><asp:literal id="literaluyeliktip" runat="server"></asp:literal></p>	
						
						<p class="text-primary">Kullanıcı Rolü:</p>
						<p><asp:literal id="literalrol" runat="server"></asp:literal></p>
						
						<p class="text-primary">Üyelik Başlangıç Tarihi:</p>
						<p><asp:literal id="literalbaslangictarih" runat="server"></asp:literal></p>	
						
					    <p class="text-primary">Üyelik Bitiş Tarihi:</p>
						<p><asp:literal id="literalbitistarih" runat="server"></asp:literal></p>	
						
				
							
				    </div>
								
				
	
                    <!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Şifre Değişikliği
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
                                <label class="col-md-3 control-label"> Eski Şifre:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox1" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                       <span class="help-block">Şu anda kullandığınız ve sisteme giriş yaparken girdiğiniz şifreyi 
                                       buraya yazınız.</span>
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yeni Şifre:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox2" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                      <span class="help-block">Buraya yazdığınız şifre artık yeni şifreniz olacaktır.</span>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Yeni Şifre Tekrar:</label>
                                <div class="col-md-4"> 
                                    <asp:textbox id="TextBox3" class="form-control" runat="server"></asp:textbox>
                                     <span class="help-block">Bir üstte yazdığınız yeni şifreyi buraya tekrar yazınız.</span>
                                </div>
                            </div>   
                                                
                            
                          	<div class="form-actions right">
                                <asp:Button ID="Button1" runat="server" class="btn green" Text="Şifremi Değiştir" /> 
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
<script type="text/javascript" src="js/profilebilgi.js"></script>
<uc3:headertemel id="headertemel" runat="server" /> 

 




