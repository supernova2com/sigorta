Public Partial Class kullanicirolbilgi1
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM
    Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI
    Dim webuye_erisim As New CLASSWEBUYE_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'eğer admin değilse
        If Session("webuye_uyetip") <> 1 Then
            Response.Redirect("bilgiyonetimgiris.aspx")
        End If

        If Not Page.IsPostBack Then

            'ANA MENULERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim anamenu_erisim As New CLASSANAMENU_ERISIM
            Dim anamenuler As New List(Of CLASSANAMENU)
            anamenuler = anamenu_erisim.doldur()
            For Each item As CLASSANAMENU In anamenuler
                DropDownList1.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
            Next


            'TÜM GİRİLEN KULLANICI GRUPLARINI BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanicirolbilgi_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Buttonsil.Visible = True

                Button1.Text = "Değişiklikleri Güncelle"
                kullanicirolbilgi = kullanicirolbilgi_erisim.bultek(Request.QueryString("pkey"))

                Textbox1.Text = kullanicirolbilgi.rolad
                Textbox2.Text = kullanicirolbilgi.yonsayfa
                DropDownList1.SelectedValue = kullanicirolbilgi.anamenupkey

            End If

            If Request.QueryString("op") = "yenikayit" Then
                Textbox1.Focus()
                Buttonsil.Visible = False
            End If


            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If


        End If

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String


        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------

        'rol adını girmediniz
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı rol ismini girmediniz.<br/>"
        End If


        'yon sayfa girmediniz
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının yönlendirileceği sayfayı girmediniz.<br/>"
        End If


        'hangi menuyu kullanacak seçilmiş mi
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının hangi menuyu kullanacağını seçmediniz.<br/>"
        End If

     
        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM
        Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                kullanicirolbilgi.rolad = Textbox1.Text
                kullanicirolbilgi.yonsayfa = Textbox2.Text
                kullanicirolbilgi.anamenupkey = DropDownList1.SelectedValue
                result = kullanicirolbilgi_erisim.Ekle(kullanicirolbilgi)
            End If

            If Request.QueryString("op") = "duzenle" Then
                kullanicirolbilgi = kullanicirolbilgi_erisim.bultek(Request.QueryString("pkey"))

                kullanicirolbilgi.rolad = Textbox1.Text
                kullanicirolbilgi.yonsayfa = Textbox2.Text
                kullanicirolbilgi.anamenupkey = DropDownList1.SelectedValue

                result = kullanicirolbilgi_erisim.Duzenle(kullanicirolbilgi)
            End If

            durumlabel.Text = javascript.alertresult(result)
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanicirolbilgi_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("kullanicirolbilgi.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = kullanicirolbilgi_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = kullanicirolbilgi_erisim.listele()

    End Sub

 
End Class