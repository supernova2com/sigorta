Public Partial Class cc
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim cc As New CLASSCC
    Dim cc_erisim As New CLASSCC_ERISIM


    'yetkiler icin 
    Dim tabload As String = "cc"
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

            'TÜZÜKTEKİ ARAÇ TİPLERİNİ DOLDUR
            Dim tuzukaractip_erisim As New CLASSTUZUKARACTIP_ERISIM
            Dim tuzukaractipler As New List(Of CLASSTUZUKARACTIP)
            tuzukaractipler = tuzukaractip_erisim.doldur()
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSTUZUKARACTIP In tuzukaractipler
                DropDownList1.Items.Add(New ListItem(item.tuzukaractipad, CStr(item.pkey)))
            Next

            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = cc_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                cc = cc_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = cc.tuzukaractippkey
                TextBox1.Text = cc.baslangicc
                TextBox2.Text = cc.bitiscc
                TextBox3.Text = cc.oran
            End If

            If Request.QueryString("op") = "yenikayit" Then
                DropDownList1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
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
        Dim oran As Date

        hata = "0"

        ' KONTROL ET ---------------------------
        If DropDownList1.SelectedValue = "0" Then
            hatamesajlari = hatamesajlari + "<li>Tüzükte tanımlı araç tipini seçmediniz.</li>"
            DropDownList1.Focus()
        End If

        'baslangicc
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Başlangıç cc'si rakamsal olmalıdır.<br/>"
        End If

        'bitiscc
        If IsNumeric(TextBox2.Text) = False Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Bitiş cc'si rakamsal olmalıdır.<br/>"
        End If

        'oran
        If IsNumeric(TextBox3.Text) = False Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "CC Zammı oranı rakamsal olmalıdır.<br/>"
        End If

        'mantıksal kontroller 
        If hata = "0" Then
            Dim baslangicc As Integer = TextBox1.Text
            Dim bitiscc As Integer = TextBox2.Text
            If baslangicc > bitiscc Then
                TextBox3.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Başlangıç cc si bitiş cc sinden büyük olamaz.<br/>"
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim cc_erisim As New CLASSCC_ERISIM
        Dim cc As New CLASSCC

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                cc.tuzukaractippkey = DropDownList1.SelectedValue
                cc.baslangicc = TextBox1.Text
                cc.bitiscc = TextBox2.Text
                cc.oran = TextBox3.Text
                result = cc_erisim.Ekle(cc)
            End If

            If Request.QueryString("op") = "duzenle" Then
                cc = cc_erisim.bultek(Request.QueryString("pkey"))
                cc.tuzukaractippkey = DropDownList1.SelectedValue
                cc.baslangicc = TextBox1.Text
                cc.bitiscc = TextBox2.Text
                cc.oran = TextBox3.Text

                result = cc_erisim.Duzenle(cc)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = cc_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim cc_erisim As New CLASSCC_ERISIM
        result = cc_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"

        If result.durum = "Kaydedildi" Then
            Label1.Text = cc_erisim.listele()
        End If

        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("cc.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

        DropDownList1.Enabled = True

    End Sub


End Class