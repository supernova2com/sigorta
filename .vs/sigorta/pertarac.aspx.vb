Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class pertarac
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim webuye_erisim As New CLASSWEBUYE_ERISIM
    Dim webuye As New CLASSWEBUYE
    Dim pertarac As New CLASSPERTARAC
    Dim pertarac_erisim As New CLASSPERTARAC_ERISIM

    'yetkiler icin 
    Dim tabload As String = "pertarac"
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

            'ARAMA İÇİN ŞİRKETLERİ DOLDUR
            DropDownList8.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList8.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            'ŞİRKETLERİ DOLDUR---------------------------------------
            sirket = sirket_erisim.bultek(Session("webuye_sirketpkey"))
            DropDownList1.Items.Add(New ListItem(sirket.sirketad, sirket.pkey))

            'ARAÇ CİNSLERİNİ DOLDUR
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim araccins_erisim As New CLASSARACCINS_ERISIM
            Dim araccinsler As New List(Of CLASSARACCINS)
            araccinsler = araccins_erisim.doldur()
            For Each item As CLASSARACCINS In araccinsler
                DropDownList2.Items.Add(New ListItem(item.cinsad, CStr(item.pkey)))
            Next

            'PARA BİRİMLERİNİ DOLDUR---------------------------------------
            DropDownList7.Items.Add(New ListItem("Seçiniz", "0"))
            Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
            Dim currencycodelar As New List(Of CLASSCURRENCYCODE)
            currencycodelar = currencycode_erisim.doldur()
            For Each item As CLASSCURRENCYCODE In currencycodelar
                DropDownList7.Items.Add(New ListItem(item.aciklama, CStr(item.pkey)))
            Next

            'KOLTUK SAYILARINI DOLDUR--------------------------------------
            DropDownList5.Items.Add(New ListItem("2 Kapı", "2"))
            DropDownList5.Items.Add(New ListItem("3 Kapı", "3"))
            DropDownList5.Items.Add(New ListItem("4 Kapı", "4"))
            DropDownList5.Items.Add(New ListItem("5 Kapı", "5"))

            'İMAL YILLARINI DOLDUR-----------------------------------------
            DropDownList6.Items.Add(New ListItem("Seçiniz", "0"))
            Dim i As Integer
            Dim simdikiyil As Integer
            simdikiyil = DateTime.Now.Year
            For i = simdikiyil To 1920 Step -1
                DropDownList6.Items.Add(New ListItem(CStr(i), CStr(i)))
            Next


            If Request.QueryString("op") = "duzenle" Then

                Button1.Text = "Değişiklikleri Güncelle"
                pertarac = pertarac_erisim.bultek(Request.QueryString("pkey"))

                If pertarac.sirketpkey <> Session("webuye_sirketpkey") Then
                    Response.Redirect("yetkisizbilgi.aspx")
                End If

                DropDownList1.SelectedValue = pertarac.sirketpkey
                DropDownList2.SelectedValue = pertarac.araccinspkey

                'ARAÇ MARKALARINI DOLDUR
                DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
                Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM
                Dim aracmarkaleri As New List(Of CLASSARACMARKA)
                aracmarkaleri = aracmarka_erisim.doldur_araccinsgore(DropDownList2.SelectedValue)
                For Each item As CLASSARACMARKA In aracmarkaleri
                    DropDownList3.Items.Add(New ListItem(item.markaad, CStr(item.pkey)))
                Next
                DropDownList3.SelectedValue = pertarac.aracmarkapkey


                'ARAÇ MODELLERİNİ DOLDUR
                DropDownList4.Items.Add(New ListItem("Seçiniz", "0"))
                Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM
                Dim aracmodelleri As New List(Of CLASSARACMODEL)
                aracmodelleri = aracmodel_erisim.doldur_cinsvemarkayagore(DropDownList2.SelectedValue, _
                DropDownList3.SelectedValue)
                For Each item As CLASSARACMODEL In aracmodelleri
                    DropDownList4.Items.Add(New ListItem(item.modelad, CStr(item.pkey)))
                Next
                DropDownList4.SelectedValue = pertarac.aracmodelpkey

                TextBox3.Text = pertarac.plaka
                TextBox4.Text = pertarac.sasino
                TextBox5.Text = pertarac.motorno
                DropDownList5.SelectedValue = pertarac.koltuksayi
                TextBox7.Text = pertarac.motorgucu
                DropDownList6.SelectedValue = pertarac.imalyil
                TextBox8.Text = pertarac.kazatarih
                TextBox9.Text = pertarac.odenenhasar
                TextBox11.Text = pertarac.piyasadeger
                TextBox12.Text = pertarac.ilanbaslangictarih
                TextBox13.Text = pertarac.ilanbitistarih
                DropDownList7.SelectedValue = pertarac.currencycodepkey
                TextBox14.Text = pertarac.hemensatisfiyat

                HttpContext.Current.Session("ltip") = "pertarac_pkey"
                HttpContext.Current.Session("pertarac_pkey") = pertarac.pkey
                rapor = pertarac_erisim.listele()
                Label1.Text = rapor.veri

            End If


            If Request.QueryString("op") = "yenikayit" Then
                DropDownList1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                DropDownList4.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                DropDownList5.Enabled = False
                TextBox7.Enabled = False
                DropDownList6.Enabled = False
                TextBox8.Enabled = False
                TextBox9.Enabled = False
                TextBox11.Enabled = False
                TextBox12.Enabled = False
                TextBox13.Enabled = False
                DropDownList7.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
                TextBox14.Enabled = False

            End If

        End If 'postback


        If Label1.Text = "" Then
            Buttonexcel.Visible = False
            Buttonpdf.Visible = False
            Buttonword.Visible = False
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim d As Date
        Dim ilanbaslangic, ilanbitis As Date

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


        'arac cins
        If Request.Form("DropDownList2") = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç cinsini seçmediniz.<br/>"
        End If


        'arac markasını
        If Request.Form("DropDownList3") = "0" Or Request.Form("DropDownList3") = "" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç markası seçmediniz.<br/>"
        End If


        'arac model
        If Request.Form("DropDownList4") = "0" Or Request.Form("DropDownList4") = "" Then
            DropDownList4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç modelini seçmediniz.<br/>"
        End If


        'plaka
        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Plakayı girmediniz.<br/>"
        End If

        'sasino
        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Şasi numarasını girmediniz.<br/>"
        End If

        'motorno
        If TextBox5.Text = "" Then
            TextBox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Motor numarasını girmediniz.<br/>"
        End If

        'koltuk sayisi
        If DropDownList5.SelectedValue = "0" Then
            DropDownList5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kapı sayısını seçmediniz.<br/>"
        End If

        'motor gücü
        If IsNumeric(TextBox7.Text) = False Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Motor gücü rakamsal olmalıdır.<br/>"
        End If


        'imal yılı
        If DropDownList6.SelectedValue = "0" Then
            DropDownList6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "İmal yılını seçmediniz.<br/>"
        End If

        'kaza tarihi
        Try
            d = TextBox8.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Kaza tarihi geçerli bir tarih değil."
            TextBox8.Focus()
        End Try


        'ödenen hasar 
        If IsNumeric(TextBox9.Text) = False Then
            TextBox9.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Ödenen hasar rakamsal olmalıdır.<br/>"
        End If
        'currency code
        If DropDownList7.SelectedValue = "0" Then
            DropDownList7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Para birimini seçmediniz.<br/>"
        End If


        'piyasa değeri 
        If IsNumeric(TextBox11.Text) = False Then
            TextBox11.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Piyasa değeri rakamsal olmalıdır.<br/>"
        End If


        'hemen satış fiyatı
        If IsNumeric(TextBox14.Text) = False Then
            TextBox14.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Hemen satış fiyatı rakamsal olmalıdır.<br/>"
        End If

        'ilan başlangıç tarihi
        Try
            ilanbaslangic = TextBox12.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "İlan başlangıç tarihi geçerli bir tarih değildir."
            TextBox12.Focus()
        End Try

        'ilan bitiş tarihi
        Try
            ilanbitis = TextBox13.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "İlan bitiş tarihi geçerli bir tarih değildir."
            TextBox13.Focus()
        End Try

        'mantıksal kontrol 
        If hata = 0 Then
            If ilanbaslangic > ilanbitis Then
                hata = "1"
                hatamesajlari = hatamesajlari + "İlan başlangıç tarihi ilan bitiş tarihinden büyük olamaz."
                TextBox12.Focus()
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                pertarac.sirketpkey = DropDownList1.SelectedValue
                pertarac.araccinspkey = Request.Form("DropDownList2")
                pertarac.aracmarkapkey = Request.Form("DropDownList3")
                pertarac.aracmodelpkey = Request.Form("DropDownList4")
                pertarac.plaka = TextBox3.Text
                pertarac.sasino = TextBox4.Text
                pertarac.motorno = TextBox5.Text
                pertarac.koltuksayi = DropDownList5.SelectedValue
                pertarac.motorgucu = TextBox7.Text
                pertarac.imalyil = DropDownList6.SelectedValue
                pertarac.kazatarih = TextBox8.Text
                pertarac.odenenhasar = TextBox9.Text
                pertarac.piyasadeger = TextBox11.Text
                pertarac.ilanbaslangictarih = TextBox12.Text
                pertarac.ilanbitistarih = TextBox13.Text
                pertarac.currencycodepkey = DropDownList7.SelectedValue
                pertarac.kullanicipkey = Session("webuye_pkey")
                pertarac.kayittarih = DateTime.Now
                pertarac.hemensatisfiyat = TextBox14.Text


                result = pertarac_erisim.Ekle(pertarac)

            End If

            If Request.QueryString("op") = "duzenle" Then

                pertarac = pertarac_erisim.bultek(Request.QueryString("pkey"))

                pertarac.sirketpkey = DropDownList1.SelectedValue
                pertarac.araccinspkey = Request.Form("DropDownList2")
                pertarac.aracmarkapkey = Request.Form("DropDownList3")
                pertarac.aracmodelpkey = Request.Form("DropDownList4")
                pertarac.plaka = TextBox3.Text
                pertarac.sasino = TextBox4.Text
                pertarac.motorno = TextBox5.Text
                pertarac.koltuksayi = DropDownList5.SelectedValue
                pertarac.motorgucu = TextBox7.Text
                pertarac.imalyil = DropDownList6.SelectedValue
                pertarac.kazatarih = TextBox8.Text
                pertarac.odenenhasar = TextBox9.Text
                pertarac.piyasadeger = TextBox11.Text
                pertarac.ilanbaslangictarih = TextBox12.Text
                pertarac.ilanbitistarih = TextBox13.Text
                pertarac.currencycodepkey = DropDownList7.SelectedValue
                pertarac.kullanicipkey = Session("webuye_pkey")
                pertarac.guncellemetarih = DateTime.Now
                pertarac.hemensatisfiyat = TextBox14.Text

                result = pertarac_erisim.Duzenle(pertarac)

            End If

            durumlabel.Text = javascript.alertresult(result)

            'Kaydedilen kaydı göster
            If result.durum = "Kaydedildi" Then
                HttpContext.Current.Session("ltip") = "pertarac_pkey"
                HttpContext.Current.Session("pertarac_pkey") = result.etkilenen
                rapor = pertarac_erisim.listele()
                Label1.Text = rapor.veri
            End If

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("pertarac.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        pertarac = pertarac_erisim.bultek(Request.QueryString("pkey"))
        If pertarac.sirketpkey <> Session("webuye_sirketpkey") Then
            Response.Redirect("yetkisiz.aspx")
        End If

        result = pertarac_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'şirket kontrol et
        If DropDownList8.SelectedValue = "0" Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirketi seçmediniz.</li>"
            DropDownList8.Focus()
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("ltip") = "sirket"
            HttpContext.Current.Session("sirketpkey") = DropDownList8.SelectedValue
            rapor = pertarac_erisim.listele
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

        End If

    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = pertarac_erisim.listele
        rapor_erisim.yazdirpdf("ekran", rapor)
    End Sub


    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = pertarac_erisim.listele
        rapor_erisim.yazdirexcel("ekran", rapor)
    End Sub


    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = pertarac_erisim.listele
        rapor_erisim.yazdirword("ekran", rapor)
    End Sub


End Class