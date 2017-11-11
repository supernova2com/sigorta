Public Partial Class teklifver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TextBox1.Focus()

        If Not Page.IsPostBack Then

            'eğer paralı üye değilse teklif veremez.
            If Session("webuye_uyetip") <> "3" Then
                Response.Redirect("yetkisizbilgi.aspx")
            End If

            'PARA BİRİMLERİNİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
            Dim currencycodelar As New List(Of CLASSCURRENCYCODE)
            currencycodelar = currencycode_erisim.doldur()
            For Each item As CLASSCURRENCYCODE In currencycodelar
                DropDownList1.Items.Add(New ListItem(item.aciklama, CStr(item.pkey)))
            Next

            Dim pertaracpkey As String
            Dim tekliftip As String
            pertaracpkey = Request.QueryString("pertaracpkey")
            tekliftip = Request.QueryString("tekliftip")

            If tekliftip = "1" Then
                Button1.Text = "Teklifimi Gönder"
                TextBox1.ReadOnly = False
            End If

            If tekliftip = "2" Then
                Button1.Text = "Hemen Satın Al"
                TextBox1.ReadOnly = True
                Dim pertarac As New CLASSPERTARAC
                Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
                pertarac = pertarac_erisim.bultek(pertaracpkey)
                TextBox1.Text = pertarac.hemensatisfiyat
                DropDownList1.SelectedValue = pertarac.currencycodepkey
            End If


            If IsNumeric(pertaracpkey) = True Then

                'ARAÇ BİLGİLERİNİ BUL
                Dim pertarac As New CLASSPERTARAC
                Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
                pertarac = pertarac_erisim.bultek(pertaracpkey)


                Dim aracbilgiyazi1 As String
                Dim aracbilgiyazi2 As String
                Dim araccins As New CLASSARACCINS
                Dim araccins_erisim As New CLASSARACCINS_ERISIM

                Dim sirket As New CLASSSIRKET
                Dim sirket_erisim As New CLASSSIRKET_ERISIM

                Dim aracmodel As New CLASSARACMODEL
                Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

                Dim aracmarka As New CLASSARACMARKA
                Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

                Dim currencycode As New CLASSCURRENCYCODE

                Dim webuye As New CLASSWEBUYE
                Dim webuye_erisim As New CLASSWEBUYE_ERISIM


                sirket = sirket_erisim.bultek(pertarac.sirketpkey)

                araccins = araccins_erisim.bultek(pertarac.araccinspkey)
                aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
                aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
                currencycode = currencycode_erisim.bultek(pertarac.currencycodepkey)
                webuye = webuye_erisim.bultek(pertarac.kullanicipkey)

                Labelaracbilgi1.Text = _
                "Şirket: " + "<b>" + sirket.sirketad + "</b><br/>" + _
                "Araç Cinsi: " + "<b>" + araccins.cinsad + "</b><br/>" + _
                "Araç Markası: " + "<b>" + aracmarka.markaad + "</b><br/>" + _
                "Araç Modeli: " + "<b>" + aracmodel.modelad + "</b><br/>" + _
                "Plaka: " + "<b>" + pertarac.plaka + "</b><br/>" + _
                "Şasi No: " + "<b>" + pertarac.sasino + "</b><br/>" + _
                "Motor No: " + "<b>" + pertarac.motorno + "</b><br/>" + _
                "Kapı Sayısı: " + "<b>" + CStr(pertarac.koltuksayi) + "</b>"

                Labelaracbilgi2.Text = _
                "Motor Gücü: " + "<b>" + CStr(pertarac.motorgucu) + "</b><br/>" + _
                "İmal Yılı: " + "<b>" + CStr(pertarac.imalyil) + "</b><br/>" + _
                "Kaza Tarihi: " + "<b>" + pertarac.kazatarih + "</b><br/>" + _
                "Ödenen Hasar: " + "<b>" + Format(pertarac.odenenhasar, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                "Piyasa Değeri: " + "<b>" + Format(pertarac.piyasadeger, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                "İlan Başlangıç Tarihi: " + "<b>" + pertarac.ilanbaslangictarih + "</b><br/>" + _
                "İlan Bitiş Tarihi: " + "<b>" + pertarac.ilanbitistarih + "</b><br/>" + _
                "Kayıt Yapan: " + "<b>" + webuye.adsoyad + "</b>"


            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String
        Dim hatamesajlari As String
        Dim pertaracpkey As String
        Dim tekliftip As String
        Dim tekliftip_database As String
        pertaracpkey = Request.QueryString("pertaracpkey")
        tekliftip = Request.QueryString("tekliftip")

        If tekliftip = "1" Then
            tekliftip_database = "Teklif"
        End If
        If tekliftip = "2" Then
            tekliftip_database = "Hemen Satın Alma"
        End If


        hata = "0"

        'HATA KONTROL
        If tekliftip_database = "" Then
            hata = "1"
            hatamesajlari = hatamesajlari + "Teklif tipini seçmediniz.<br/>"
        End If

        If IsNumeric(pertaracpkey) = False Then
            hata = "1"
            hatamesajlari = hatamesajlari + "Teklif vermek istediğiniz pert aracı tekrar seçiniz.<br/>"
        End If

        If IsNumeric(TextBox1.Text) = False Then
            hata = "1"
            hatamesajlari = hatamesajlari + "Teklif fiyatını girmediniz.<br/>"
            TextBox1.Focus()
        End If

        If DropDownList1.SelectedValue = "0" Then
            hata = "1"
            hatamesajlari = hatamesajlari + "Teklif para birimini seçmediniz.<br/>"
            DropDownList1.Focus()
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            Dim teklif As New CLASSTEKLIF
            Dim teklif_erisim As New CLASSTEKLIF_ERISIM
            Dim result As New CLADBOPRESULT
            Dim pertarac As New CLASSPERTARAC
            Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
            Dim webuye As New CLASSWEBUYE
            Dim webuye_erisim As New CLASSWEBUYE_ERISIM

            pertarac = pertarac_erisim.bultek(pertaracpkey)

            teklif.uyepkey = Session("webuye_pkey")
            teklif.pertaracpkey = pertaracpkey
            teklif.tutar = TextBox1.Text
            teklif.tutarcurrencypkey = DropDownList1.SelectedValue
            teklif.tekliftarih = DateTime.Now
            teklif.okunmusmu = "Hayır"
            teklif.sirketpkey = pertarac.sirketpkey
            teklif.tip = tekliftip_database
            result = teklif_erisim.Ekle(teklif)


            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Teklifiniz başarılı bir şekilde alınmıştır. <br/>" + _
                "</p></div>"

                teklif = teklif_erisim.bultek(result.etkilenen)

                Dim resultemail As New CLADBOPRESULT
                Dim emailbody As String
                Dim email As New CLASSEMAIL
                Dim email_erisim As New CLASSEMAIL_ERISIM
                Dim emailayar As New CLASSEMAILAYAR
                Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
                emailayar = emailayar_erisim.bul(1)
                webuye = webuye_erisim.bultek(teklif.uyepkey)


                'TEKLİFİ VEREN KİŞİYE E-POSTA GÖNDER 
                email.kime = webuye.eposta
                email.kimden = emailayar.username
                email.subject = "Teklif No: " + CStr(teklif.pkey) + " ile ilgili"
                email.body = emailbodyolustur(teklif)
                resultemail = email_erisim.gonder(email)

                'TEKLİFİ ALAN KİŞİYE E-POSTA GÖNDER
                email.kime = webuye_erisim.bul_sirketpkeyegore(teklif.sirketpkey).eposta
                resultemail = email_erisim.gonder(email)

            End If

            If result.durum <> "Kaydedildi" Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

        End If

    End Sub

    'Verilmiş olan teklifi e-posta olarak göndermek için oluşturulan e-posta metni.
    Function emailbodyolustur(ByVal teklif As CLASSTEKLIF) As String

        Dim donecek As String

        Dim teklifverenwebuye As New CLASSWEBUYE
        Dim teklifverenwebuye_erisim As New CLASSWEBUYE_ERISIM

        Dim teklifalanwebuye As New CLASSWEBUYE
        Dim teklifalanwebuye_erisim As New CLASSWEBUYE_ERISIM

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Dim pertarac As New CLASSPERTARAC
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM

        Dim araccins As New CLASSARACCINS
        Dim araccins_Erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM


        teklifverenwebuye = teklifverenwebuye_erisim.bultek(teklif.uyepkey)
        teklifalanwebuye = teklifalanwebuye_erisim.bul_sirketpkeyegore(teklif.sirketpkey)
        sirket = sirket_erisim.bultek(teklif.sirketpkey)
        pertarac = pertarac_erisim.bultek(teklif.pertaracpkey)
        araccins = araccins_Erisim.bultek(pertarac.araccinspkey)
        aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
        aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
        currencycode = currencycode_erisim.bultek(teklif.tutarcurrencypkey)

        donecek = "Kuzey Kıbrıs Sigorta & Reasürans Şirketler Birliği<br/>" + _
        "<br/>" + _
        "<b>Değerli Üyemiz</b>" + "<br/><br/>" + _
        "Teklif Verilen Araç Cinsi: " + "<b>" + araccins.cinsad + "</b><br/>" + _
        "Teklif Verilen Araç Markası: " + "<b>" + aracmarka.markaad + "</b><br/>" + _
        "Teklif Verilen Araç Modeli: " + "<b>" + aracmodel.modelad + "</b><br/>" + _
        "Teklif Verilen Araç Plakası: " + "<b>" + pertarac.plaka + "</b><br/>" + _
        "----------------------------------------------" + "<br/>" + _
        "Teklif Tipi: " + "<b>" + teklif.tip + "</b><br/>" + _
        "Teklif Tarihi: " + "<b>" + teklif.tekliftarih + "</b><br/>" + _
        "Teklif Veren Kişinin Adı Soyadı: " + "<b>" + teklifverenwebuye.adsoyad + "</b><br/>" + _
        "Teklif Veren Kişinin Telefonu: " + "<b>" + teklifverenwebuye.telefon + "</b><br/>" + _
        "Teklif Veren Kişinin E-Posta Adresi: " + "<b>" + teklifverenwebuye.eposta + "</b><br/>" + _
        "Teklif Tutarı: " + "<b>" + Format(teklif.tutar, "0.00") + " " + currencycode.aciklama + "</b><br/>" + _
        "----------------------------------------------" + "<br/>" + _
        "Teklifi Alan Şirket: " + "<b>" + sirket.sirketad + "</b><br/>" + _
        "Teklifi Alan Kişinin Adı Soyadı: " + "<b>" + teklifalanwebuye.adsoyad + "</b><br/>" + _
        "Teklifi Alan Kişinin Telefonu: " + "<b>" + teklifalanwebuye.telefon + "</b><br/>" + _
        "Teklifi Alan Kişinin E-Posta Adresi: " + "<b>" + teklifalanwebuye.eposta + "</b><br/>"

        Return donecek

    End Function

End Class