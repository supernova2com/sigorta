Public Partial Class plakasinirkapi
    Inherits System.Web.UI.Page

    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim plakasinirkapi As New CLASSPLAKASINIRKAPI
    Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "plakasinirkapi"
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

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                plakasinirkapi = plakasinirkapi_erisim.bultek(Request.QueryString("pkey"))
                TextBox1.Text = plakasinirkapi.plaka
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                TextBox1.Enabled = False
   
                Button1.Enabled = False
                Buttonsil.Enabled = False
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
            Buttonyenikayit.Visible = True
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

        hata = "0"

        ' KONTROL ET ---------------------------
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Plaka girilmelidir.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM
        Dim plakasinirkapi As New CLASSPLAKASINIRKAPI

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                plakasinirkapi.plaka = TextBox1.Text
                result = plakasinirkapi_erisim.Ekle(plakasinirkapi)
            End If

            If Request.QueryString("op") = "duzenle" Then
                plakasinirkapi = plakasinirkapi_erisim.bultek(Request.QueryString("pkey"))
                plakasinirkapi.plaka = TextBox1.Text
                result = plakasinirkapi_erisim.Duzenle(plakasinirkapi)
            End If

            durumlabel.Text = javascript.alertresult(result)

            If result.durum = "Kaydedildi" Then
                HttpContext.Current.Session("ltip") = "TÜMÜ"
                Label1.Text = plakasinirkapi_erisim.listele()
            End If

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM
        result = plakasinirkapi_erisim.Sil(Request.QueryString("pkey"))

        'HttpContext.Current.Session("ltip") = "TÜMÜ"
        'Label1.Text = plakasinirkapi_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("plakasinirkapi.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True

    End Sub

  

End Class