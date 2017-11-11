Public Partial Class sinirkapi
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
    Dim sinirkapi As New CLASSSINIRKAPI
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    'yetkiler icin 
    Dim tabload As String = "sinirkapi"
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

            'TÜM GİRİLEN KULLANICI GRUPLARINI BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = sinirkapi_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Buttonsil.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                sinirkapi = sinirkapi_erisim.bultek(Request.QueryString("pkey"))
                Textbox1.Text = sinirkapi.sinirkapiad
                Textbox2.Text = sinirkapi.sinirkapikod
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                Textbox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
                Buttonsil.Visible = False
            End If

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        End If
        If yetki.insertyetki = "Evet" And opy = "yenikayit" Then
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If

        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        End If
        If yetki.updateyetki = "Evet" And opy = "duzenle" Then
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
        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET -----------------------------------------------
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Sınır kapısı adını girmediniz.<br/>"
        End If

        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Sınır kapısı kodunu girmediniz.<br/>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
        Dim sinirkapi As New CLASSSINIRKAPI

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                sinirkapi.sinirkapiad = Textbox1.Text
                sinirkapi.sinirkapikod = Textbox2.Text
                sinirkapi.ipdikkat = "Evet"
                result = sinirkapi_erisim.Ekle(sinirkapi)
            End If

            If Request.QueryString("op") = "duzenle" Then
                sinirkapi = sinirkapi_erisim.bultek(Request.QueryString("pkey"))
                sinirkapi.sinirkapiad = Textbox1.Text
                sinirkapi.sinirkapikod = Textbox2.Text
                result = sinirkapi_erisim.Duzenle(sinirkapi)
            End If

            durumlabel.Text = javascript.alertresult(result)
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = sinirkapi_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("sinirkapi.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = sinirkapi_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = sinirkapi_erisim.listele()

    End Sub

End Class