Public Partial Class profilebilgi
    Inherits System.Web.UI.Page


    Dim webuye_erisim As New CLASSWEBUYE_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

       

            Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI
            Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM

            Dim uyeliktip As String
            Dim webuye As New CLASSWEBUYE
            webuye = webuye_erisim.bultek(Session("webuye_pkey"))
            kullanicirolbilgi = kullanicirolbilgi_erisim.bultek(webuye.rolpkey)

            literaladsoyad.Text = webuye.adsoyad
            literaleposta.Text = webuye.eposta
            literalkullaniciad.Text = webuye.kullaniciad
            literaltelefon.Text = webuye.telefon
            literaladres.Text = webuye.adres

            Select Case webuye.uyetip
                Case 1 : uyeliktip = "Admin"
                Case 2 : uyeliktip = "Şirket Admin"
                Case 3 : uyeliktip = "Üye"
            End Select

            If webuye.uyetip = "1" Then
                uyeliktip = "Admin"
            End If

            literaluyeliktip.Text = uyeliktip
            literalrol.Text = kullanicirolbilgi.rolad
            literalbaslangictarih.Text = webuye.uyebaslangictarih
            literalbitistarih.Text = webuye.uyebitistarih

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String

        durumlabel.Text = ""
        hata = "0"

        Dim javascript As New CLASSJAVASCRIPT

        Dim kullanicipkey As String
        kullanicipkey = Session("webuye_pkey")

        ' KONTROL ET ---------------------------
        'eski şifrenizi girmediniz.
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Eski şifrenizi girmediniz.<br/>"
        End If

        'kullanıcı şifre girmediniz
        If Len(Textbox2.Text) < 5 Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Yeni şifreniz en az 5 karakter olmalıdır.<br/>"
        End If

        If Textbox2.Text <> TextBox3.Text Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Yeni şifreleriniz birbiri ile uymuyor." + _
            " Yazdığınız yeni şifrelerin birbiriyle ayni olup olmadığını kontrol ediniz.<br/>"
        End If

        'eski şifre doğrumu kontrol et
        If hata = "0" Then
            Dim webuye As New CLASSWEBUYE
            webuye = webuye_erisim.bultek(kullanicipkey)
            If webuye.kullanicisifre <> Textbox1.Text Then
                Textbox1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Eski şifreniz doğru değil. Lütfen kontrol ediniz.<br/>"
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            Dim result As New CLADBOPRESULT
            Dim webuye As New CLASSWEBUYE
            webuye = webuye_erisim.bultek(kullanicipkey)
            webuye.kullanicisifre = Textbox2.Text
            result = webuye_erisim.Duzenle(webuye)
            durumlabel.Text = javascript.alertresult(result)


        End If


    End Sub

 
End Class