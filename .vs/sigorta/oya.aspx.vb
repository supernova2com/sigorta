Public Partial Class oya
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim webuye_erisim As New CLASSWEBUYE_ERISIM
    Dim webuye As New CLASSWEBUYE
    Dim oya As New CLASSOYA
    Dim oya_erisim As New CLASSOYA_ERISIM

    'yetkiler icin 
    Dim tabload As String = "oya"
    Dim yetkibilgi_erisim As New CLASSYETKIBILGI_ERISIM
    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Dim sirket As New CLASSSIRKET
    Dim sirket_erisim As New CLASSSIRKET_ERISIM

    Dim rapor As New CLASSRAPOR
    Dim rapor_erisim As New CLASSRAPOR_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetkibilgi = yetkibilgi_erisim.bul_ilgili(Session("webuye_rolpkey"), tmodul.pkey)
        If yetkibilgi.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        End If
        If yetkibilgi.insertyetki = "Evet" And opy = "yenikayit" Then
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If

        If yetkibilgi.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        End If
        If yetkibilgi.updateyetki = "Evet" And opy = "duzenle" Then
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
            Buttonpdf.Visible = False
            Buttonexcel.Visible = False
            Buttonword.Visible = False
        Else
            Label1.Visible = True
            Buttonpdf.Visible = True
            Buttonexcel.Visible = True
            Buttonword.Visible = True
        End If

        If yetkibilgi.insertyetki = "Hayır" And yetkibilgi.updateyetki = "Hayır" And _
        yetkibilgi.deleteyetki = "Hayır" And yetkibilgi.readyetki = "Hayır" Then
            Response.Redirect("yetkisizbilgi.aspx")
        End If
        'yetki kontrol----------------------------------


        If Not Page.IsPostBack Then

            'ŞİRKETLERİ DOLDUR---------------------------------------
            sirket = sirket_erisim.bultek(Session("webuye_sirketpkey"))
            DropDownList1.Items.Add(New ListItem(sirket.sirketad, sirket.pkey))


            'ACENTELERİ DOLDUR
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim acente_erisim As New CLASSACENTE_ERISIM
            Dim acenteler As New List(Of CLASSACENTE)
            acenteler = acente_erisim.doldur_merkezolmayanlar()
            For Each item As CLASSACENTE In acenteler
                DropDownList2.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
                DropDownList5.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
            Next

            'PARA BİRİMLERİNİ DOLDUR---------------------------------------
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
            Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
            Dim currencycodelar As New List(Of CLASSCURRENCYCODE)
            currencycodelar = currencycode_erisim.doldur()
            For Each item As CLASSCURRENCYCODE In currencycodelar
                DropDownList3.Items.Add(New ListItem(item.aciklama, CStr(item.pkey)))
            Next

            'ACENTE DURUMLARINI DOLDUR---------------------------------------
            DropDownList4.Items.Add(New ListItem("Seçiniz", "0"))
            Dim acentedurum_erisim As New CLASSACENTEDURUM_ERISIM
            Dim acentedurumler As New List(Of CLASSACENTEDURUM)
            acentedurumler = acentedurum_erisim.doldur()
            For Each item As CLASSACENTEDURUM In acentedurumler
                DropDownList4.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
            Next


            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                oya = oya_erisim.bultek(Request.QueryString("pkey"))

                If oya.sirketpkey <> Session("webuye_sirketpkey") Then
                    Response.Redirect("yetkisizbilgi.aspx")
                End If

                DropDownList1.SelectedValue = oya.sirketpkey
                DropDownList2.SelectedValue = oya.acentepkey
                Textbox3.Text = oya.borcmiktar
                DropDownList3.SelectedValue = oya.currencycodepkey
                TextBox4.Text = oya.sure
                DropDownList4.SelectedValue = oya.acentedurumpkey

                'KAYIDI GÖSTER
                HttpContext.Current.Session("ltip") = "oya_pkey"
                HttpContext.Current.Session("oya_pkey") = oya.pkey
                rapor = oya_erisim.listele()
                Label1.Text = rapor.veri

            End If


            If Request.QueryString("op") = "yenikayit" Then
                DropDownList1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                Textbox3.Enabled = False
                DropDownList3.Enabled = False
                TextBox4.Enabled = False
                DropDownList4.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If 'postback


        If Label1.Text = "" Then
            Buttonexcel.Visible = False
            Buttonpdf.Visible = False
            Buttonword.Visible = False
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim op As String
        op = Request.QueryString("op")

        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------

        'sirketleri kontrol et
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Şirketi seçmediniz.<br/>"
        End If


        'acente
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Borçlu acenteyi seçmediniz.<br/>"
        End If


        'borç miktar
        If IsNumeric(Textbox3.Text) = False Then
            Textbox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Borç miktarı rakamsal olmalıdır.<br/>"
        End If


        'para birimi
        If DropDownList3.SelectedValue = "0" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Para birimini seçmediniz.<br/>"
        End If

        'süre
        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Süreyi girmediniz.<br/>"
        End If

        'acente durum
        If DropDownList4.SelectedValue = "0" Then
            DropDownList4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Acente durumunu seçmediniz.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                oya.sirketpkey = DropDownList1.SelectedValue
                oya.acentepkey = DropDownList2.SelectedValue
                oya.borcmiktar = Textbox3.Text
                oya.currencycodepkey = DropDownList3.SelectedValue
                oya.sure = TextBox4.Text
                oya.acentedurumpkey = DropDownList4.SelectedValue
                oya.kullanicipkey = Session("kullanici_pkey")
                oya.kayittarih = DateTime.Now

                result = oya_erisim.Ekle(oya)

            End If

            If Request.QueryString("op") = "duzenle" Then

                oya = oya_erisim.bultek(Request.QueryString("pkey"))
                oya.sirketpkey = DropDownList1.SelectedValue
                oya.sirketpkey = DropDownList1.SelectedValue
                oya.acentepkey = DropDownList2.SelectedValue
                oya.borcmiktar = Textbox3.Text
                oya.currencycodepkey = DropDownList3.SelectedValue
                oya.sure = TextBox4.Text
                oya.acentedurumpkey = DropDownList4.SelectedValue
                oya.kullanicipkey = Session("kullanici_pkey")
                oya.guncellemetarih = DateTime.Now
                result = oya_erisim.Duzenle(oya)

            End If

            durumlabel.Text = javascript.alertresult(result)

            'KAYIDI GÖSTER
            If result.durum = "Kaydedildi" Then
                HttpContext.Current.Session("ltip") = "oya_pkey"
                HttpContext.Current.Session("oya_pkey") = result.etkilenen
                rapor = oya_erisim.listele()
                Label1.Text = rapor.veri
            End If

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("oya.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        oya = oya_erisim.bultek(Request.QueryString("pkey"))
        If oya.sirketpkey <> Session("webuye_sirketpkey") Then
            Response.Redirect("yetkisiz.aspx")
        End If

        result = oya_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        HttpContext.Current.Session("ltip") = "acentepkey"
        HttpContext.Current.Session("acentepkey") = DropDownList5.SelectedValue
        rapor = oya_erisim.listele
        Label1.Text = rapor.veri

        If rapor.kacadet > 0 Then
            Buttonexcel.Visible = True
            Buttonpdf.Visible = True
            Buttonword.Visible = True
        Else
            Buttonexcel.Visible = False
            Buttonpdf.Visible = False
            Buttonword.Visible = False
        End If

    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = oya_erisim.listele
        rapor_erisim.yazdirpdf("ekran", rapor)
    End Sub


    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = oya_erisim.listele
        rapor_erisim.yazdirexcel("ekran", rapor)
    End Sub


    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = oya_erisim.listele
        rapor_erisim.yazdirword("ekran", rapor)
    End Sub

End Class