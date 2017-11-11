Public Partial Class aracmarka
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim aracmarka As New CLASSARACMARKA
    Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

    'yetkibilgiler icin 
    Dim tabload As String = "aracmarka"
    Dim yetkibilgi_erisim As New CLASSYETKIBILGI_ERISIM
    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            'ARAÇ CİNLSERİNİ DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim araccins_erisim As New CLASSARACCINS_ERISIM
            Dim araccinsler As New List(Of CLASSARACCINS)
            araccinsler = araccins_erisim.doldur()
            For Each item As CLASSARACCINS In araccinsler
                DropDownList1.Items.Add(New ListItem(item.cinsad, CStr(item.pkey)))
            Next

            'TÜM GİRİLEN ARAÇ MARKALARINI LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = aracmarka_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                aracmarka = aracmarka_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = aracmarka.araccinspkey
                TextBox2.Text = aracmarka.markaad
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox2.Focus()
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                TextBox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If


        'yetkibilgi kontrol ------------------------------
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
        'yetkibilgi kontrol----------------------------------

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String

        hata = "0"

        'arac cins 
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç cinsini seçmediniz.<br/>"
        End If

        'arac markası
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç markasını girilmelidir.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM
        Dim aracmarka As New CLASSARACMARKA

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                aracmarka.araccinspkey = DropDownList1.SelectedValue
                aracmarka.markaad = TextBox2.Text
                result = aracmarka_erisim.Ekle(aracmarka)
            End If

            If Request.QueryString("op") = "duzenle" Then
                aracmarka = aracmarka_erisim.bultek(Request.QueryString("pkey"))
                aracmarka.araccinspkey = DropDownList1.SelectedValue
                aracmarka.markaad = TextBox2.Text
                result = aracmarka_erisim.Duzenle(aracmarka)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = aracmarka_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM
        result = aracmarka_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = aracmarka_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("aracmarka.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

        DropDownList1.Enabled = True
        TextBox2.Enabled = True

    End Sub

End Class