Public Partial Class age
    Inherits System.Web.UI.Page



    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim age As New CLASSAGE
    Dim age_erisim As New CLASSAGE_ERISIM


    'yetkiler icin 
    Dim tabload As String = "age"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then



            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = age_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                age = age_erisim.bultek(Request.QueryString("pkey"))
                TextBox1.Text = age.baslangicage
                TextBox2.Text = age.bitisage
                TextBox3.Text = age.agerate
            End If

            If Request.QueryString("op") = "yenikayit" Then
                TextBox1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                Button1.Enabled = False
            End If

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        Else
            Button1.Visible = True
        End If
        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If

        If yetki.deleteyetki = "Hayır" Then
            Buttonsil.Visible = False
        End If
        If yetki.deleteyetki = "Evet" And opy = "duzenle" Then
            Buttonsil.Visible = True
        End If

        If yetki.readyetki = "Hayır" Then
            Label1.Visible = False
        Else
            Label1.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String
        Dim agerate As Date

        hata = "0"


        'baslangicage
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Başlangıç yaşı rakamsal olmalıdır.<br/>"
        End If

        'bitisage
        If IsNumeric(TextBox2.Text) = False Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Bitiş yaşı rakamsal olmalıdır.<br/>"
        End If

        'agerate
        If IsNumeric(TextBox3.Text) = False Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Yaş Zammı oranı rakamsal olmalıdır.<br/>"
        End If

        'mantıksal kontroller 
        If hata = "0" Then
            Dim baslangicage As Integer = TextBox1.Text
            Dim bitisage As Integer = TextBox2.Text
            If baslangicage > bitisage Then
                TextBox3.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Başlangıç yaşı si bitiş yaşından büyük olamaz.<br/>"
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim age_erisim As New CLASSAGE_ERISIM
        Dim age As New CLASSAGE

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                age.baslangicage = TextBox1.Text
                age.bitisage = TextBox2.Text
                age.agerate = TextBox3.Text
                result = age_erisim.Ekle(age)
            End If

            If Request.QueryString("op") = "duzenle" Then
                age = age_erisim.bultek(Request.QueryString("pkey"))
                age.baslangicage = TextBox1.Text
                age.bitisage = TextBox2.Text
                age.agerate = TextBox3.Text

                result = age_erisim.Duzenle(age)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = age_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim age_erisim As New CLASSAGE_ERISIM
        result = age_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"

        If result.durum = "Kaydedildi" Then
            Label1.Text = age_erisim.listele()
        End If

        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("age.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

    End Sub



End Class