<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="sigorta.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="Button6" runat="server" Text="Read Excel" />
    <br />
    <br />
    <br />
        <asp:Button ID="Button7" runat="server" Text="LoadFirePolicy XML Olustur" />
    <br />
    <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="400px" TextMode="MultiLine" Width="100%"></asp:TextBox>
        <br />
        <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    
    
    
                      <!-- 
				<li id="a" class="start">
					<a href="default.aspx">
						<i class="fa fa-home"></i>
						<span class="title">
							Pano
						</span>
					</a>
				</li>
				<li id="b">
					<a href="javascript:;">
						<i class="fa fa-tasks"></i>
						<span class="title">
							İşlemler
						</span>
						<span class="arrow open">
						</span>
					</a>
					<ul class="sub-menu">		
						<li id="b1">
							<a href="hasariptal.aspx">
							    <i class="fa fa-briefcase"></i>
								<span class="badge badge-roundless badge-success">
									yeni
								</span>
								Hasar İptali
							</a>
						</li>
						<li id="b2">
							<a href="hasariptalliste.aspx">
							    <i class="fa fa-list"></i>
								İptal Listesi
							</a>
						</li>	
					</ul>
				</li>
				<li id="c">
					<a href="javascript:;">
						<i class="fa fa-search-plus"></i>
						<span class="title">
							Arama
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="c1">
							<a href="policeara.aspx">
							<i class="fa fa-coffee"></i>
								Poliçe Sorgulama
							</a>
						</li>
						<li id="c2">
							<a href="hasarara.aspx">
							<i class="fa fa-bolt"></i>
								 Hasar Sorgulama
							</a>
						</li>					
					</ul>
				</li>
				<li id="d">
					<a href="javascript:;">
						<i class="fa fa-puzzle-piece"></i>
						<span class="title">
							Tanımlamalar
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="d1">
							<a href="sirket.aspx">
							<i class="fa fa-table"></i>
								 Şirket
							</a>
						</li>
						<li id="d2">
							<a href="acente.aspx">
							<i class="fa fa-certificate"></i>
								 Acente
							</a>
						</li>
						<li id="d3">
							<a href="personel.aspx">
							<i class="fa fa-bolt"></i>
								 Personel
							</a>
						</li>
						<li id="d4">
							<a href="aractarife.aspx">
							<i class="fa fa-bars"></i>
								 Araç Tarife
							</a>
						</li>
						<li id="d5">
							<a href="ulke.aspx">
							<i class="fa fa-globe"></i>
								 Ülke
							</a>
						</li>
						
					</ul>
				</li>
				<li id="e">
					<a href="javascript:;">
						<i class="fa fa-table"></i>
						<span class="title">
							Fiyatlar
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="e1">
							<a href="bazfiyat.aspx">
							<i class="fa fa-money"></i>
								 Baz Fiyatlar
							</a>
						</li>
						<li id="e2">
							<a href="kur.aspx">
							<i class="fa fa-turkish-lira"></i>
								 Döviz Kurları
							</a>
						</li>
						
					</ul>
				</li>
				<li id="f">
					<a href="javascript:;">
						<i class="fa-building-o"></i>
						<span class="title">
							Belge Yönetimi
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="f1">
							<a href="acentebelge.aspx">
								<i class="fa fa-file"></i>
								Acente Sicil<br>
								Kayıt Belgesi
							</a>
						</li>
						<li id="f2">
							<a href="teknikpersonelbelge.aspx">
								<i class="fa fa-file-o"></i>
								Teknik Personel<br>
								Belgesi
							</a>
						</li>
						<li id="f3">
							<a href="katilimbelge.aspx">
								<i class="fa fa-files-o"></i>
								Bilgilendirme Eğitimi<br>
								Katılım Belgesi
							</a>
						</li>
					</ul>
				</li>
				<li id="g">
					<a href="javascript:;">
						<i class="fa fa-sitemap"></i>
						<span class="title">
							XML Web Servisleri
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="g1">
							<a target="_blank" href="servislink.aspx">
								<i class="fa fa-briefcase"></i>
								<span class="badge badge-warning badge-roundless">
									yeni
								</span>
								Web Servisleri
							</a>
						</li>
						<li id="g2">
							<a href="servisayar.aspx">
								<i class="fa fa-briefcase"></i>
								<span class="badge badge-warning badge-roundless">
									yeni
								</span>
								Servis Ayarları
							</a>
						</li>
					</ul>
				</li>
				<li id="h">
					<a href="javascript:;">
						<i class="fa fa-gift"></i>
						<span class="title">
							Resimler
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="h1">
							<a href="galeri.aspx">
							<i class="fa fa-archive"></i>
								 Resim Galerileri
							</a>
						</li>
						<li id="h2">
							<a href="resim.aspx">
							<i class="fa fa-picture-o"></i>
								 Resimler
							</a>
						</li>
					</ul>
				</li>
				<li id="i">
					<a href="javascript:;">
						<i class="fa fa-user"></i>
						<span class="title">
							Kullanıcı Yönetimi
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="i1">
							<a href="kullanici.aspx?op=yenikayit">			
							<i class="fa fa-male"></i>
								 Kullanıcılar
							</a>
						</li>
						<li id="i2">
							<a href="kullanicigrup.aspx">
								<i class="fa fa-folder-o"></i>
								 Kullanıcı Grupları
							</a>
						</li>	
						<li id="i3">
							<a href="kullanicirol.aspx?op=yenikayit">
								<i class="fa fa-gavel"></i>
								 Kullanıcı Rolleri
							</a>
						</li>
						<li id="i4">
							<a href="kullanicisifreyonetim.aspx">
								<i class="fa fa-key"></i>
								 Şifre Yönetimi
							</a>
						</li>
					
					</ul>
				</li>
				<li id="j">
					<a href="javascript:;">
						<i class="fa fa-bar-chart-o"></i>
						<span class="title">
							Raporlar
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="j1">
							<a href="table_basic.html">
							<i class="fa fa-bar-chart-o"></i>
								 Rapor 1
							</a>
						</li>
					</ul>
				</li>
				<li id="k">
					<a href="javascript:;">
						<i class="fa fa-file-text"></i>
						<span class="title">
							Loglar
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="k1">
							<a href="log.aspx">
							  <i class="fa fa-folder-open"></i>
								 Sistem Logları
							</a>
						</li>
						<li id="k2">
							<a href="logservis.aspx">
							  <i class="fa fa-folder"></i>
								 Servis Logları
							</a>
						</li>
					</ul>
				</li>
				<li id="l">
					<a href="javascript:;">
						<i class="fa fa-envelope"></i>
						<span class="title">
							Mesajlarım
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="l1">
							<a href="mesaj.aspx">
							<i class="fa fa-users"></i>
								 Yeni Mesaj
							</a>
						</li>
						<li id="l2">
							<a href="gelenmesaj.aspx">
							<i class="fa fa-mail-forward"></i>
								 Gelen Mesajlarım
							</a>
						</li>
						<li id="l3">
							<a href="gonderilenmesaj.aspx">
							<i class="fa fa-envelope-o"></i>
								 Gönderdiğim Mesajlarım
							</a>
						</li>
					</ul>
				</li>
				<li id="n">
					<a href="javascript:;">
						<i class="fa fa-file"></i>
						<span class="title">
							Dosyalarım
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="n1">
							<a href="dosya.aspx">
							<i class="fa fa-paperclip"></i>
								 Yeni Dosya
							</a>
						</li>
						<li id="n2">
							<a href="gelendosya.aspx">
							<i class="fa fa-mail-forward"></i>
								 Gelen Dosyalarım
							</a>
						</li>
						<li id="n3">
							<a href="gonderilendosya.aspx">
							<i class="fa fa-clipboard"></i>
								 Gönderdiğim Dosyalarım
							</a>
						</li>
					</ul>
				</li>
				<li id="m" class="last ">
					<a href="javascript:;">
						<i class="fa fa-cogs"></i>
						<span class="title">
							Ayarlar
						</span>
						<span class="arrow ">
						</span>
					</a>
					<ul class="sub-menu">
						<li id="m1">
							<a href="profile.aspx">
							<i class="fa fa-user"></i>
								 Profilim
							</a>
						</li>
						<li id="m2">
							<a href="sistem.aspx">
							<i class="fa fa-flash"></i>
								 Sistem Ayarları
							</a>
						</li>
						<li id="m3">
							<a href="emailayar.aspx">
							<i class="fa fa-sun-o"></i>
								 E-Posta Ayarları

							</a>
						</li>
						<li id="m4">
							<a href="anamenu.aspx">
							<i class="fa fa-inbox"></i>
								 Ana Menuler
							</a>
						</li>
						<li id="m5">
							<a href="menu.aspx?op=yenikayit">
							<i class="fa fa-gears"></i>
								 Menuler
							</a>
						</li>
					</ul>
				</li>
			</ul>	
			-->
    </form>
    
    
    
                      </body>
</html>
