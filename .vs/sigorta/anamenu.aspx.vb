Public Partial Class anamenu
    Inherits System.Web.UI.Page




    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim anamenu As New CLASSANAMENU
    Dim anamenu_erisim As New CLASSANAMENU_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("ayar", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then


            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = anamenu_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                anamenu = anamenu_erisim.bultek(Request.QueryString("pkey"))
                TextBox2.Text = anamenu.ad
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

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String

        hata = "0"

        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Menu adını girilmelidir.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim anamenu_erisim As New CLASSANAMENU_ERISIM
        Dim anamenu As New CLASSANAMENU

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                anamenu.ad = TextBox2.Text
                result = anamenu_erisim.Ekle(anamenu)
            End If

            If Request.QueryString("op") = "duzenle" Then
                anamenu = anamenu_erisim.bultek(Request.QueryString("pkey"))
                anamenu.ad = TextBox2.Text
                result = anamenu_erisim.Duzenle(anamenu)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = anamenu_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim anamenu_erisim As New CLASSANAMENU_ERISIM
        result = anamenu_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = anamenu_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("anamenu.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox2.Enabled = True

    End Sub



End Class