Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class sistem
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT


    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim baglantikes_erisim As New CLASSBAGLANTIKES_ERISIM
    Dim sys_erisim As New CLASSSYS_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("ayar", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            Dim site_erisim As New CLASSSITE_ERISIM
            Dim site As New CLASSSITE

            'temaları doldur
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim tema_erisim As New CLASSTEMA_ERISIM
            Dim tema As New CLASSTEMA
            Dim temalar As New List(Of CLASSTEMA)
            temalar = tema_erisim.doldur
            For Each item As CLASSTEMA In temalar
                DropDownList1.Items.Add(New ListItem(item.temaad, item.pkey))
            Next

            'veritabanı adlarını doldur------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
            Dim veritabanialan As New CLASSVERITABANIALAN
            Dim ilgiliadlar As New List(Of CLASSVERITABANI)
            ilgiliadlar = sqlveritabani_erisim.doldurveritabaniadları
            For Each item As CLASSVERITABANI In ilgiliadlar
                DropDownList2.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
            Next


            'sistemdeki diskleri doldur------------------------------------
            Dim diskler As New List(Of CLASSDISK)
            diskler = sys_erisim.sistemdiskdoldur()
            For Each item As CLASSDISK In diskler
                DropDownList4.Items.Add(New ListItem(item.diskad, item.diskad))
            Next

            'bağlantı kesme için dakikaları doldur 
            Dim i As Integer
            For i = 1 To 60
                DropDownListKacDakika.Items.Add(New ListItem(CStr(i), CStr(i)))
            Next

            Dim kayitsayisi As Integer
            kayitsayisi = site_erisim.kayitsayisibul

            If kayitsayisi = 0 Then

                Labeluyari.Text = "<div class='alert alert-danger'>" + _
                "SİSTEM AYARLARI YAPILMAMIŞ. LÜTFEN SUPERNOVA İLE TEMASA GEÇİNİZ." + _
                "</div>"

            End If

            If kayitsayisi > 0 Then
                site = site_erisim.bultek(1)
                Textbox1.Text = site.url
                Textbox13.Text = site.path
                TextBox33.Text = site.yer
                DropDownList1.SelectedValue = site.temapkey
                DropDownList2.SelectedValue = site.sistemveritabaniad
                TextBox5.Text = site.musteriadsoyad
                TextBox7.Text = site.musteriofistel
                TextBox8.Text = site.musterifax
                TextBox9.Text = site.mustericeptel
                TextBox10.Text = site.musteriemail
                TextBox6.Text = site.musteriadres
                TextBox15.Text = site.pgkullaniciad
                TextBox16.Text = site.pgsifre
                TextBox2.Text = site.kullanimbaslangictarih
                TextBox17.Text = site.yanlissifrecount
                TextBox11.Text = site.copyrighttext
                TextBox18.Text = site.faturaodemesongun

                'veritabanin tablolarını doldur.
                Dim tablolar As New List(Of CLASSVERITABANI)
                tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
                For Each item As CLASSVERITABANI In tablolar
                    DropDownList3.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
                Next

                DropDownList3.SelectedValue = site.roltabload
                TextBox19.Text = site.hataeposta


                If site.captcha = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

            End If

            sistembilgilabel.Text = sys_erisim.SistemBilgi
            labelonlinekullanici.Text = kullanici_erisim.onlinekullanicilar
            labelkesilmiskullanici.Text = baglantikes_erisim.listele


        End If 'postback

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim baslangic As Date
        Dim hata As String
        Dim hatamesajlari As String

        durumlabel.Text = ""

        hata = "0"

        'sistem url
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Lütfen site url'yi giriniz."
        End If

        'sistem path
        If Textbox13.Text = "" Then
            Textbox13.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Site tam yolunu girmediniz."
        End If

        'sistem yer
        If TextBox33.Text = "" Then
            TextBox33.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Site yerini girmediniz."
        End If

        'sistem tema
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Site temasını seçmediniz."
        End If

        'kullanimbaslangictarih---------------------------
        Try
            baslangic = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox2.Focus()
        End Try

        'sistem veritabani
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Sistemin kullandığı veritabanını seçmediniz."
        End If

        'musteri adi soyadi
        If TextBox5.Text = "" Then
            TextBox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Müşteri adı soyadını giriniz."
        End If

        'musteri ofis
        If TextBox7.Text = "" Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Müşteri ofis telefonunu giriniz."
        End If

        'musteri fax
        If TextBox8.Text = "" Then
            TextBox8.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Müşteri fax numarasını giriniz."
        End If

        'müsteri cep
        If Len(TextBox9.Text) <> 11 Then
            TextBox9.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Müşteri cep numarası 11 rakamlı olmalıdır."
        End If


        'müşteri eposta adresi
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox10.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            TextBox10.Focus()
            hatamesajlari = hatamesajlari + "Müşteri E-Mail adresini doğru giriniz."
        End If

        'müsteri adres
        If TextBox6.Text = "" Then
            TextBox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Müşteri adresini giriniz."
        End If

        'copyright yazisi
        If TextBox11.Text = "" Then
            TextBox11.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Copyright yazısını girmediniz."
        End If



        'SMS-------------------------------------------------------------
        If TextBox15.Text = "" Then
            TextBox15.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "SMS için Posta Güvercini kullanıcı adını girmediniz.<br/>"
        End If

        If TextBox16.Text = "" Then
            TextBox16.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "SMS için Posta Güvercini şifresini girmediniz.<br/>"
        End If

        If IsNumeric(TextBox17.Text) = False Then
            TextBox17.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Hatalı Şifre Sayısı rakamsal olmalıdır.<br/>"
        End If


        If Request.Form("DropDownList3") = "" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Rollerin bulunduğu tabloyu seçmediniz.<br/>"
        End If

        If IsNumeric(TextBox18.Text) = False Then
            TextBox18.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Fatura ödeme son gününü belirlemediniz.<br/>"
        End If


        'üretici e-posta
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox19.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            TextBox19.Focus()
            hatamesajlari = hatamesajlari + "Üretici E-Mail adresini doğru giriniz."
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
            'durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + hatamesajlari + "</ol></div>"
        End If

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM

        If hata = "0" Then

            site.url = Textbox1.Text
            site.path = Textbox13.Text
            site.yer = TextBox33.Text
            site.temapkey = DropDownList1.SelectedValue
            site.sistemveritabaniad = DropDownList2.SelectedValue
            site.musteriadsoyad = TextBox5.Text
            site.musteriofistel = TextBox7.Text
            site.musterifax = TextBox8.Text
            site.mustericeptel = TextBox9.Text
            site.musteriemail = TextBox10.Text
            site.musteriadres = TextBox6.Text
            site.pgkullaniciad = TextBox15.Text
            site.pgsifre = TextBox16.Text
            site.kullanimbaslangictarih = TextBox2.Text
            site.yanlissifrecount = TextBox17.Text
            site.roltabload = Request.Form("DropDownList3")
            site.copyrighttext = TextBox11.Text
            site.faturaodemesongun = TextBox18.Text
            site.hataeposta = TextBox19.Text


            If CheckBox1.Checked = True Then
                site.captcha = "Evet"
            Else
                site.captcha = "Hayır"
            End If

            Dim kayitsayisi As Integer
            kayitsayisi = site_erisim.kayitsayisibul

            If kayitsayisi = 0 Then
                result = site_erisim.Ekle(site)
            End If

            If kayitsayisi > 0 Then
                site.pkey = 1
                result = site_erisim.Duzenle(site)
            End If

            durumlabel.Text = javascript.alertresult(result)

        End If

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Dim batchislem_Erisim As New CLASSBATCHISLEMPOLICE_ERISIM
        durumlabel.Text = batchislem_Erisim.renkleriguncelle()
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click

        Dim sayi As Integer
        Dim batchislem_Erisim As New CLASSBATCHISLEMPOLICE_ERISIM
        sayi = batchislem_Erisim.rengiguncellemeyensayi()
        labeladet.Text = CStr(sayi)

    End Sub


    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Dim arackayitdaire_Erisim As New CLASSARACKAYITDAIRE_ERISIM
        arackayitdaire_Erisim.topluguncelle()
    End Sub
End Class