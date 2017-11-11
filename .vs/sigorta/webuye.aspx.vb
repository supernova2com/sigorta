Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class webuye
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim webuye_erisim As New CLASSWEBUYE_ERISIM
    Dim webuye As New CLASSWEBUYE

    'yetkiler icin 
    Dim tabload As String = "webuye"
    Dim yetkibilgi_erisim As New CLASSYETKIBILGI_ERISIM
    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            'ÜYELİK TİPLERİNİ DOLDUR---------------------------------
            DropDownList1.Items.Add(New ListItem("Üye", "3"))
            DropDownList1.Items.Add(New ListItem("Şirket Admin", "2"))
            DropDownList1.Items.Add(New ListItem("Admin", "1"))

            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList2.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            'ROLLERİ DOLDUR---------------------------------------
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
            Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM
            Dim kullanicirolbilgiler As New List(Of CLASSKULLANICIROLBILGI)
            kullanicirolbilgiler = kullanicirolbilgi_erisim.doldur()
            For Each item As CLASSKULLANICIROLBILGI In kullanicirolbilgiler
                DropDownList3.Items.Add(New ListItem(item.rolad, CStr(item.pkey)))
            Next

            'TÜM GİRİLEN WEB ÜYELERİNİ BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = webuye_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Buttonsil.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                webuye = webuye_erisim.bultek(Request.QueryString("pkey"))

                DropDownList2.SelectedValue = webuye.sirketpkey
                DropDownList1.SelectedValue = webuye.uyetip
                TextBox1.Text = webuye.adsoyad
                TextBox2.Text = webuye.adres
                TextBox3.Text = webuye.telefon
                TextBox4.Text = webuye.eposta
                TextBox5.Text = webuye.kullaniciad
                TextBox6.Text = webuye.kullanicisifre
                If webuye.aktifmi = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
                TextBox7.Text = webuye.uyebaslangictarih
                TextBox8.Text = webuye.uyebitistarih
                DropDownList3.SelectedValue = webuye.rolpkey

            End If

            If Request.QueryString("op") = "yenikayit" Then
                TextBox7.Text = DateTime.Now.ToShortDateString
                DropDownList1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                TextBox7.Enabled = False
                TextBox8.Enabled = False
                DropDownList3.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If 'postback

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetkibilgi = yetkibilgi_erisim.bul_ilgili(Session("webuye_rolpkey"), tmodul.pkey)
        If yetkibilgi.insertyetki = "Hayır" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        Else
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If
        If yetkibilgi.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        If yetkibilgi.deleteyetki = "Hayır" Then
            Buttonsil.Visible = False
        End If
        If yetkibilgi.deleteyetki = "Evet" And opy = "duzenle" Then
            Buttonsil.Visible = True
        End If
        If yetkibilgi.readyetki = "Hayır" Then
            Label1.Visible = False
        Else
            Label1.Visible = True
        End If
        If yetkibilgi.insertyetki = "Hayır" And yetkibilgi.updateyetki = "Hayır" And _
        yetkibilgi.deleteyetki = "Hayır" And yetkibilgi.readyetki = "Hayır" Then
            Response.Redirect("yetkisizbilgi.aspx")
        End If
        'yetki kontrol----------------------------------


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim d, uyebaslangictarih, uyebitistarih As Date

        Dim hata, hatamesajlari As String
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim op As String
        op = Request.QueryString("op")

        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------
        'sirketleri kontrol et
        If DropDownList1.SelectedValue = "1" Or DropDownList1.SelectedValue = "2" Then
            If DropDownList2.SelectedValue = "0" Then
                DropDownList2.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Web üyesinin çalıştığı şirketi seçmediniz.<br/>"
            End If
        End If

        If DropDownList3.SelectedValue = "0" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Web üyesinin rolünü seçmediniz.<br/>"
        End If

        'adsoyad girmediniz
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Üye ad soyadını girmediniz.<br/>"
        End If

        'kullanıcı adres girmediniz
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Adresi girmediniz.<br/>"
        End If

        'telefonu girmediniz
        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Telefonu girmediniz.<br/>"
        End If

        'eposta kontrol et
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox4.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            TextBox3.Focus()
            hatamesajlari = hatamesajlari + "E-Posta adresini doğru giriniz.<br/>"
        End If

        'kullanıcı adını girmediniz
        If TextBox5.Text = "" Then
            TextBox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı adını girmediniz.<br/>"
        End If

        'şifre
        If Len(TextBox6.Text) < 5 Then
            TextBox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Şifre en az 5 karakter olmalıdır.<br/>"
        End If


        'üye başlangıc tarihi
        Try
            uyebaslangictarih = TextBox7.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Üye başlangıç tarihi geçerli bir tarih değil.<br/>"
            TextBox7.Focus()
        End Try

        'üye bitiş tarihi
        Try
            uyebitistarih = TextBox8.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Üye bitiş tarihi geçerli bir tarih değil.<br/>"
            TextBox8.Focus()
        End Try

        If hata = "0" Then
            'mantıksal kontrol 
            If uyebaslangictarih > uyebitistarih Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Üyelik başlangıç tarihi üyelik bitiş tarihinden büyük olamaz.<br/>"
                TextBox8.Focus()
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim webuye As New CLASSWEBUYE

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                webuye.sirketpkey = DropDownList2.SelectedValue
                webuye.uyetip = DropDownList1.SelectedValue
                webuye.adsoyad = TextBox1.Text
                webuye.adres = TextBox2.Text
                webuye.telefon = TextBox3.Text
                webuye.eposta = TextBox4.Text
                webuye.kullaniciad = TextBox5.Text
                webuye.kullanicisifre = TextBox6.Text
                If CheckBox1.Checked = True Then
                    webuye.aktifmi = "Evet"
                Else
                    webuye.aktifmi = "Hayır"
                End If
                webuye.uyebaslangictarih = TextBox7.Text
                webuye.uyebitistarih = TextBox8.Text
                webuye.rolpkey = DropDownList3.SelectedValue

                result = webuye_erisim.Ekle(webuye)

            End If

            If Request.QueryString("op") = "duzenle" Then
                webuye = webuye_erisim.bultek(Request.QueryString("pkey"))

                webuye.sirketpkey = DropDownList2.SelectedValue
                webuye.uyetip = DropDownList1.SelectedValue
                webuye.adsoyad = TextBox1.Text
                webuye.adres = TextBox2.Text
                webuye.telefon = TextBox3.Text
                webuye.eposta = TextBox4.Text
                webuye.kullaniciad = TextBox5.Text
                webuye.kullanicisifre = TextBox6.Text
                If CheckBox1.Checked = True Then
                    webuye.aktifmi = "Evet"
                Else
                    webuye.aktifmi = "Hayır"
                End If
                webuye.uyebaslangictarih = TextBox7.Text
                webuye.uyebitistarih = TextBox8.Text
                webuye.rolpkey = DropDownList3.SelectedValue

                result = webuye_erisim.Duzenle(webuye)
            End If

            'E-POSTA GÖNDER---
            If result.durum = "Kaydedildi" Then

                'e-mail gönder
                Dim emailbody As String
                Dim resultemail As New CLADBOPRESULT
                Dim email As New CLASSEMAIL
                Dim email_erisim As New CLASSEMAIL_ERISIM
                Dim emailayar As New CLASSEMAILAYAR
                Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

                emailayar = emailayar_erisim.bul(1)

                Dim gonderilenwebuye As New CLASSWEBUYE
                gonderilenwebuye = webuye_erisim.bultek(result.etkilenen)

                email.kime = webuye.eposta
                email.kimden = emailayar.username
                email.subject = "KKSRSB Kullanıcı Tanımı / Güncellemesi"

                emailbody = "Kuzey Kıbrıs Sigorta & Reasürans Şirketler Birliği<br/>" + _
                "<br/>" + _
                "Değerli Kullanıcımız" + "<br/>" + _
                "Kullanıcı Adı:" + webuye.kullaniciad + "<br/>" + _
                "Şifreniz:" + webuye.kullanicisifre + "<br/>" + _
                "Üyelik Başlangıç Tarihiniz:" + webuye.uyebaslangictarih + "<br/>" + _
                "Üyelik Bitiş Tarihiniz:" + webuye.uyebitistarih + "<br/>" + _
                "Kullanıcı bilgileriniz eklenmiş ve/veya güncellenmiştir." + "<br/>"
  
                email.body = emailbody
                resultemail = email_erisim.gonder(email)
                durumlabelemail.Text = javascript.alertresultmail(result)

            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = webuye_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("webuye.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = webuye_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub


End Class