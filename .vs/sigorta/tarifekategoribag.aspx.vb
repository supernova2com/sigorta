Public Partial Class tarifekategoribag
    Inherits System.Web.UI.Page

    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim tarifekategoribag As New CLASSTARIFEKATEGORIBAG
    Dim tarifekategoribag_erisim As New CLASSTARIFEKATEGORIBAG_ERISIM

    'yetkiler icin 
    Dim tabload As String = "tarifekategoribag"
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
            Label1.Text = tarifekategoribag_erisim.listele()


            'TARİFE KODLARINI DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
            Dim aractarifeler As New List(Of CLASSARACTARIFE)
            aractarifeler = aractarife_erisim.doldur()
            For Each item As CLASSARACTARIFE In aractarifeler
                DropDownList1.Items.Add(New ListItem(item.tarifekod, CStr(item.pkey)))
            Next


            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                tarifekategoribag = tarifekategoribag_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = tarifekategoribag.aractarifepkey
                TextBox1.Text = tarifekategoribag.kategorikod
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                DropDownList1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
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
        If yetki.insertyetki <> "Evet" And yetki.updateyetki <> "Evet" And _
        yetki.deleteyetki <> "Evet" And yetki.readyetki <> "Evet" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String

        hata = "0"

        ' KONTROL ET ---------------------------
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Tarife kodunu seçmediniz.<br/>"
        End If

        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kategori kodu rakamsal olmalıdır.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim tarifekategoribag_erisim As New CLASSTARIFEKATEGORIBAG_ERISIM
        Dim tarifekategoribag As New CLASSTARIFEKATEGORIBAG

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                tarifekategoribag.aractarifepkey = DropDownList1.SelectedValue
                tarifekategoribag.kategorikod = TextBox1.Text
                result = tarifekategoribag_erisim.Ekle(tarifekategoribag)
            End If

            If Request.QueryString("op") = "duzenle" Then
                tarifekategoribag = tarifekategoribag_erisim.bultek(Request.QueryString("pkey"))
                tarifekategoribag.aractarifepkey = DropDownList1.SelectedValue
                tarifekategoribag.kategorikod = TextBox1.Text
                result = tarifekategoribag_erisim.Duzenle(tarifekategoribag)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tarifekategoribag_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim tarifekategoribag_erisim As New CLASSTARIFEKATEGORIBAG_ERISIM
        result = tarifekategoribag_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = tarifekategoribag_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub



    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("tarifekategoribag.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        DropDownList1.Enabled = True
        TextBox1.Enabled = True

    End Sub

End Class