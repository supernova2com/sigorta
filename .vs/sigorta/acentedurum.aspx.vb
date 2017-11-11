Public Partial Class acentedurum
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim acentedurum As New CLASSACENTEDURUM
    Dim acentedurum_erisim As New CLASSACENTEDURUM_ERISIM

    'yetkiler icin 
    Dim tabload As String = "acentedurum"
    Dim yetkibilgi_erisim As New CLASSYETKIBILGI_ERISIM
    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then


            'TÜM GİRİLEN ACENTE DURUMLARINI LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = acentedurum_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                acentedurum = acentedurum_erisim.bultek(Request.QueryString("pkey"))
                TextBox2.Text = acentedurum.ad
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox2.Focus()
            End If

            If Request.QueryString("op") = "" Then
                TextBox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If


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

        Dim hata, hatamesajlari As String

        hata = "0"

        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Poliçe türü adını girilmelidir.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim acentedurum_erisim As New CLASSACENTEDURUM_ERISIM
        Dim acentedurum As New CLASSACENTEDURUM

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                acentedurum.ad = UCase(TextBox2.Text)
                result = acentedurum_erisim.Ekle(acentedurum)
            End If

            If Request.QueryString("op") = "duzenle" Then
                acentedurum = acentedurum_erisim.bultek(Request.QueryString("pkey"))
                acentedurum.ad = UCase(TextBox2.Text)
                result = acentedurum_erisim.Duzenle(acentedurum)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = acentedurum_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim acentedurum_erisim As New CLASSACENTEDURUM_ERISIM
        result = acentedurum_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = acentedurum_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub



    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("acentedurum.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox2.Enabled = True

    End Sub


End Class