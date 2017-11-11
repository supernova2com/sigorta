Public Partial Class genericservisgirispopup
    Inherits System.Web.UI.Page

    Dim genericservis As New CLASSGENERICSERVIS
    Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim genericservistablo_erisim As New CLASSGENERICSERVISTABLO_ERISIM
    Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
    Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
    Dim genericserviskullanici_erisim As New CLASSGENERICSERVISKULLANICI_ERISIM
   
    Dim site As New CLASSSITE
    Dim site_erisim As New CLASSSITE_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim op As String
        op = Request.QueryString("op")
        Dim genericservispkey As String

        'Test Düğmesi Göster Yada Gösterme
        If op <> "duzenle" Then
            Button2.Visible = False
            Button7.Visible = False
            divoto.Visible = False
        Else
            Button2.Visible = True
            Button7.Visible = True
        End If

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        site = site_erisim.bultek(1)

        If Not Page.IsPostBack Then

            'iptallere göre düğmeleri gizle---------------------------------
            If Request.QueryString("hangiiptal") = "1" Then
                Buttongenericservistabloiptal.Visible = False
                inn.Value = "1"
            End If
            If Request.QueryString("hangiiptal") = "2" Then
                Buttongenericservisinputiptal.Visible = False
                inn.Value = "2"
            End If
            If Request.QueryString("hangiiptal") = "3" Then
                Buttongenericservisoutputiptal.Visible = False
                inn.Value = "3"
            End If
            If Request.QueryString("hangiiptal") = "4" Then
                Buttongenericserviskullaniciiptal.Visible = False
                inn.Value = "4"
            End If

            '---------------------------------------------------------------

            Dim innquery As String
            innquery = Request.QueryString("inn")
            If innquery <> "" Then
                inn.Value = innquery
            End If

            site = site_erisim.bultek(1)

            'GENERİC SERVİS TİPLERİNİ DOLDUR
            DropDownList1.Items.Add(New ListItem("Kayıt Listeleme", "listeleme"))
            DropDownList1.Items.Add(New ListItem("Rakam Döndürme", "rakamdondurme"))
            DropDownList1.Items.Add(New ListItem("Kayıt Ekleme", "insert"))
            DropDownList1.Items.Add(New ListItem("Kayıt Güncelleme", "update"))
            DropDownList1.Items.Add(New ListItem("Kayıt Silme", "delete"))


            'VERİTABANI TABLOLARINI DOLDUR
            Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
            Dim tablolar As New List(Of CLASSVERITABANI)
            tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
            For Each item As CLASSVERITABANI In tablolar
                DropDownList9.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
            Next

            'ŞİRKETLERİ DOLDUR
            Dim sirketler As New List(Of CLASSSIRKET)
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList12.Items.Add(New ListItem(item.sirketad, item.pkey))
            Next

            'DATA TİPLERİNİ DOLDUR
            DropDownList2.Items.Add(New ListItem("bit", "bit"))
            DropDownList2.Items.Add(New ListItem("numeric", "numeric"))
            DropDownList2.Items.Add(New ListItem("int", "int"))
            DropDownList2.Items.Add(New ListItem("float", "float"))
            DropDownList2.Items.Add(New ListItem("double", "double"))
            DropDownList2.Items.Add(New ListItem("decimal", "decimal"))
            DropDownList2.Items.Add(New ListItem("float", "float"))
            DropDownList2.Items.Add(New ListItem("real", "real"))
            DropDownList2.Items.Add(New ListItem("varchar", "varchar"))
            DropDownList2.Items.Add(New ListItem("nvarchar", "nvarchar"))
            DropDownList2.Items.Add(New ListItem("text", "text"))
            DropDownList2.Items.Add(New ListItem("ntext", "ntext"))
            DropDownList2.Items.Add(New ListItem("char", "char"))
            DropDownList2.Items.Add(New ListItem("date", "date"))
            DropDownList2.Items.Add(New ListItem("datetime", "datetime"))
            DropDownList2.Items.Add(New ListItem("image", "image"))


            If op = "yenikayit" Then
                TextBox1.Focus()
            End If

            If op = "duzenle" Then

                genericservispkey = Request.QueryString("pkey")
                Button2.Visible = True

                HttpContext.Current.Session("ltip") = "ilgili"
                HttpContext.Current.Session("genericservispkey") = genericservispkey

                'tabloları göster
                Dim ilgili_genericservistablolar As New List(Of CLASSGENERICSERVISTABLO)
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgenericservistablo.Text = genericservistablo_erisim.listele()

                'inputları göster
                Dim ilgili_genericservisinputler As New List(Of CLASSGENERICSERVISINPUT)
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgenericservisinput.Text = genericservisinput_erisim.listele()

                'outputları göster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgenericservisoutput.Text = genericservisoutput_erisim.listele()

                'kullanicilari göster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgenericserviskullanici.Text = genericserviskullanici_erisim.listele()

                Button1.Text = "Değişiklikleri Güncelle"
                genericservis = genericservis_erisim.bultek(Request.QueryString("pkey"))

                'genericservis bilgilerini göster
                TextBox14.Text = genericservis.sqlstrrun
                DropDownList1.SelectedValue = genericservis.tip
                TextBox1.Text = genericservis.ad
                TextBox2.Text = genericservis.aciklama

                'TABLO DÜZENLE İÇİN ----------------------------------------------------
                Dim genericservistabloop As String
                genericservistabloop = Request.QueryString("genericservistabloop")
                If genericservistabloop = "duzenle" Then
                    Buttongenericservistabloiptal.Visible = True
                    inn.Value = "1"
                    Buttongenericservistabloekle.Text = "Güncelle"
                    Dim genericservistablo As New CLASSGENERICSERVISTABLO
                    Dim genericservistablopkey As String
                    genericservistablopkey = Request.QueryString("genericservistablopkey")
                    genericservistablo = genericservistablo_erisim.bultek(genericservistablopkey)
                    DropDownList9.SelectedValue = genericservistablo.tabload
               
                Else
                    Buttongenericservistabloekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'input DÜZENLE İÇİN ----------------------------------------------------
                Dim genericservisinputop As String
                genericservisinputop = Request.QueryString("genericservisinputop")
                If genericservisinputop = "duzenle" Then
                    Buttongenericservisinputiptal.Visible = True
                    inn.Value = "2"
                    Buttongenericservisinputkaydet.Text = "Güncelle"
                    Dim genericservisinput As New CLASSGENERICSERVISINPUT
                    Dim genericservisinputpkey As String
                    genericservisinputpkey = Request.QueryString("genericservisinputpkey")
                    genericservisinput = genericservisinput_erisim.bultek(genericservisinputpkey)
                    TextBox3.Text = genericservisinput.paramad
                    DropDownList2.SelectedValue = genericservisinput.datatype
                Else
                    Buttongenericservisinputkaydet.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'output DÜZENLE İÇİN ----------------------------------------------------
                Dim genericservisoutputop As String
                genericservisoutputop = Request.QueryString("genericservisoutputop")
                If genericservisoutputop = "duzenle" Then
                    Buttongenericservisoutputiptal.Visible = True
                    inn.Value = "3"
                    Buttongenericservisoutputekle.Text = "Güncelle"
                    Dim genericservisoutput As New CLASSGENERICSERVISOUTPUT
                    Dim genericservisoutputpkey As String
                    genericservisoutputpkey = Request.QueryString("genericservisoutputpkey")
                    genericservisoutput = genericservisoutput_erisim.bultek(genericservisoutputpkey)
                    TextBox7.Text = genericservisoutput.outputparamname

                Else
                    Buttongenericservisoutputekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'kullanici DÜZENLE İÇİN ----------------------------------------------------
                Dim genericserviskullaniciop As String
                genericserviskullaniciop = Request.QueryString("genericserviskullaniciop")
                If genericserviskullaniciop = "duzenle" Then
                    Buttongenericserviskullaniciiptal.Visible = True
                    inn.Value = "4"
                    Buttongenericserviskullaniciekle.Text = "Güncelle"
                    Dim genericserviskullanici As New CLASSGENERICSERVISKULLANICI
                    Dim genericserviskullanicipkey As String
                    genericserviskullanicipkey = Request.QueryString("genericserviskullanicipkey")
                    genericserviskullanici = genericserviskullanici_erisim.bultek(genericserviskullanicipkey)
                    DropDownList12.SelectedValue = genericserviskullanici.sirketpkey
                Else
                    Buttongenericserviskullaniciekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------   


                'OTOMATİK DÜĞMESİ 
                If genericservis.tip = "insert" Or genericservis.tip = "update" Or genericservis.tip = "delete" Then
                    divoto.Visible = True
                Else
                    divoto.Visible = False
                End If
            End If

        End If

    End Sub


    'GENERIC SERVİS KAYDET
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim genericservis As New CLASSGENERICSERVIS
        Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM
        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'rapor adı
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Rapor adını girmediniz.</li>"
            inn.Value = "0"
        End If

        'rapor aciklama
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Rapor açıklamasını girmediniz.</li>"
            inn.Value = "0"
        End If

        'rapor aciklama
        If TextBox14.Text = "" Then
            TextBox14.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>SQL'i girmediniz.</li>"
            inn.Value = "0"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            genericservis.sqlstrrun = TextBox14.Text
            genericservis.tip = DropDownList1.SelectedValue
            genericservis.ad = TextBox1.Text
            genericservis.aciklama = TextBox2.Text

            If Request.QueryString("op") = "yenikayit" Then
                result = genericservis_erisim.Ekle(genericservis)
                If result.durum = "Kaydedildi" Then
                    inn.Value = "1"
                    Dim duzenlemelink As String
                    duzenlemelink = "genericservisgirispopup.aspx?pkey=" + CStr(result.etkilenen) + "&op=duzenle&inn=1"
                    Response.Redirect(duzenlemelink)
                End If
            End If

            If Request.QueryString("op") = "duzenle" Then
                genericservis = genericservis_erisim.bultek(Request.QueryString("pkey"))
                genericservis.sqlstrrun = TextBox14.Text
                genericservis.tip = DropDownList1.SelectedValue
                genericservis.ad = TextBox1.Text
                genericservis.aciklama = TextBox2.Text
                result = genericservis_erisim.Duzenle(genericservis)
            End If

            If result.durum = "Kaydedildi" Then
                inn.Value = "1"
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

        End If 'hata=0

    End Sub



    ' TABLOLAR EKLE
    Protected Sub Buttongenericservistabloekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericservistabloekle.Click

        Dim genericservistablo As New CLASSGENERICSERVISTABLO
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")

        Dim genericservistabloop As String
        genericservistabloop = Request.QueryString("genericservistabloop")
        inn.Value = "1"

        Dim hata As String
        Dim hatamesajlari As String = ""


        hata = "0"

        If genericservistabloop <> "duzenle" Then

            Dim bakilacak_genericservis As New CLASSGENERICSERVIS
            bakilacak_genericservis = genericservis_erisim.bultek(genericservispkey)

            '1 DEN FAZLA TABLO EKLEYEMESİN!
            Dim kactablo As Integer
            kactablo = genericservistablo_erisim.kactablovar_ilgiliserviste(genericservispkey)
            If kactablo > 0 Then
                If bakilacak_genericservis.tip = "insert" Or bakilacak_genericservis.tip = "update" Or _
                bakilacak_genericservis.tip = "delete" Then
                    hata = "1"
                    hatamesajlari = "Bu servis tipinde sadece tek tablo girişi yapabilirsiniz."
                    inn.Value = "1"
                    Labeldurumgenericservistablo.Text = "<div id=errorMsg>" + _
                    "<h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                    hatamesajlari + "</li></ol></div>"
                End If
            End If
            If hata = "0" Then
                genericservistablo.genericservispkey = genericservispkey
                genericservistablo.tabload = DropDownList9.SelectedValue
                result = genericservistablo_erisim.Ekle(genericservistablo)
            End If
        End If

        If genericservistabloop = "duzenle" Then
            Dim genericservistablopkey As String
            genericservistablopkey = Request.QueryString("genericservistablopkey")
            genericservistablo = genericservistablo_erisim.bultek(genericservistablopkey)
            genericservistablo.tabload = DropDownList9.SelectedValue
            result = genericservistablo_erisim.Duzenle(genericservistablo)
        End If


        If hata = "0" Then
            If result.etkilenen = 0 Then
                Labeldurumgenericservistablo.Text = "<div id=errorMsg>" + _
                "<h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                Labeldurumgenericservistablo.Text = "<div id=okMsg>" + _
                "<p>Değişiklikler kaydedildi. <br/></p></div>"
            End If
        End If


        'kullanilacak tabloları göster
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("genericservispkey") = genericservispkey
        Labelgenericservistablo.Text = genericservistablo_erisim.listele()


    End Sub


    'genericservisinput EKLE
    Protected Sub Buttongenericservisinputekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericservisinputkaydet.Click

        Dim hata As String

        Dim genericservisinputop As String

        Dim genericservispkey As String
        Dim genericservisinput As New CLASSGENERICSERVISINPUT
        Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
        genericservispkey = Request.QueryString("pkey")
        genericservisinputop = Request.QueryString("genericservisinputop")

        inn.Value = "2"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'paramad
        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Parametre adını girmediniz</li>"
            inn.Value = "2"
        End If

        If Len(TextBox3.Text) > 0 Then
            If Mid(TextBox3.Text, 1, 1) <> "@" Then
                'TextBox3.Focus()
                'hata = "1"
                'hatamesajlari = hatamesajlari + "<li>Tüm parametreler @ işareti ile başlamalıdır.</li>"
                'inn.Value = "2"
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            If genericservisinputop <> "duzenle" Then
                genericservisinput.genericservispkey = genericservispkey
                genericservisinput.paramad = TextBox3.Text
                genericservisinput.datatype = DropDownList2.SelectedValue
                result = genericservisinput_erisim.Ekle(genericservisinput)
            End If

            If genericservisinputop = "duzenle" Then
                Dim genericservisinputpkey As String
                genericservisinputpkey = Request.QueryString("genericservisinputpkey")
                genericservisinput = genericservisinput_erisim.bultek(genericservisinputpkey)
                genericservisinput.paramad = TextBox3.Text
                genericservisinput.datatype = DropDownList2.SelectedValue
                result = genericservisinput_erisim.Duzenle(genericservisinput)
            End If

            If result.durum = "Kaydedildi" Then
                Labeldurumgenericservisinput.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                Labeldurumgenericservisinput.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("genericservispkey") = genericservispkey
            Labelgenericservisinput.Text = genericservisinput_erisim.listele

        End If

    End Sub

    'genericservisoutput EKLE
    Protected Sub Buttongenericservisoutputekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericservisoutputekle.Click

        Dim hata As String

        Dim genericservisoutputop As String

        Dim genericservispkey As String
        Dim genericservisoutput As New CLASSGENERICSERVISOUTPUT
        Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
        genericservispkey = Request.QueryString("pkey")
        genericservisoutputop = Request.QueryString("genericservisoutputop")

        inn.Value = "3"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'paramad
        If TextBox7.Text = "" Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Paramtre adını girmediniz</li>"
            inn.Value = "3"
        End If

        If Len(TextBox7.Text) > 0 Then
            If Mid(TextBox7.Text, 1, 1) <> "@" Then
                'TextBox3.Focus()
                'hata = "1"
                'hatamesajlari = hatamesajlari + "<li>Tüm parametreler @ işareti ile başlamalıdır.</li>"
                'inn.Value = "3"
            End If
        End If

      
        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            If genericservisoutputop <> "duzenle" Then
                genericservisoutput.genericservispkey = genericservispkey
                genericservisoutput.outputparamname = TextBox7.Text
                result = genericservisoutput_erisim.Ekle(genericservisoutput)
            End If

            If genericservisoutputop = "duzenle" Then
                Dim genericservisoutputpkey As String
                genericservisoutputpkey = Request.QueryString("genericservisoutputpkey")
                genericservisoutput = genericservisoutput_erisim.bultek(genericservisoutputpkey)
                genericservisoutput.outputparamname = TextBox7.Text
                result = genericservisoutput_erisim.Duzenle(genericservisoutput)
            End If

            If result.durum = "Kaydedildi" Then
                Labeldurumgenericservisoutput.text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                Labeldurumgenericservisoutput.text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("genericservispkey") = genericservispkey
            Labelgenericservisoutput.Text = genericservisoutput_erisim.listele

        End If

    End Sub

   
    'genericserviskullanici EKLE
    Protected Sub Buttongenericserviskullaniciekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericserviskullaniciekle.Click

        Dim hata As String

        Dim genericserviskullaniciop As String

        Dim genericservispkey As String
        Dim genericserviskullanici As New CLASSGENERICSERVISKULLANICI
        Dim genericserviskullanici_erisim As New CLASSGENERICSERVISKULLANICI_ERISIM
        genericservispkey = Request.QueryString("pkey")
        genericserviskullaniciop = Request.QueryString("genericserviskullaniciop")

        inn.Value = "4"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'kullanıcı
        If DropDownList12.SelectedValue = "" Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Kullanıcıyı seçmediniz.</li>"
            inn.Value = "4"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            If genericserviskullaniciop <> "duzenle" Then
                genericserviskullanici.genericservispkey = genericservispkey
                genericserviskullanici.sirketpkey = DropDownList12.SelectedValue
                result = genericserviskullanici_erisim.Ekle(genericserviskullanici)
            End If

            If genericserviskullaniciop = "duzenle" Then
                Dim genericserviskullanicipkey As String
                genericserviskullanicipkey = Request.QueryString("genericserviskullanicipkey")
                genericserviskullanici = genericserviskullanici_erisim.bultek(genericserviskullanicipkey)
                genericserviskullanici.sirketpkey = DropDownList12.SelectedValue
                result = genericserviskullanici_erisim.Duzenle(genericserviskullanici)
            End If

            If result.durum = "Kaydedildi" Then
                Labeldurumgenericserviskullanici.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                Labeldurumgenericserviskullanici.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("genericservispkey") = genericservispkey
            Labelgenericserviskullanici.Text = genericserviskullanici_erisim.listele

        End If

    End Sub


    Protected Sub Buttongenericservistabloiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericservistabloiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")
        link = "genericservisgirispopup.aspx?op=" + op + "&pkey=" + genericservispkey + "&hangiiptal=1"
        inn.Value = "1"
        Response.Redirect(link)
    End Sub


    Protected Sub Buttongenericservisinputiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericservisinputiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")
        link = "genericservisgirispopup.aspx?op=" + op + "&pkey=" + genericservispkey + "&hangiiptal=2"
        inn.Value = "2"
        Response.Redirect(link)
    End Sub


    Protected Sub Buttongenericservisoutputiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericservisoutputiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")
        link = "genericservisgirispopup.aspx?op=" + op + "&pkey=" + genericservispkey + "&hangiiptal=3"
        inn.Value = "3"
        Response.Redirect(link)
    End Sub


    Protected Sub Buttongenericserviskullaniciiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongenericserviskullaniciiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")
        link = "genericservisgirispopup.aspx?op=" + op + "&pkey=" + genericservispkey + "&hangiiptal=4"
        inn.Value = "4"
        Response.Redirect(link)
    End Sub



    'BİLEŞENLERİ İLE BİRLİKTE TÜM GENERIC SERVİSİ SİLME
    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click

        Dim result As New CLADBOPRESULT
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")

        If genericservispkey <> "" Then

            Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM


            Dim genericservistablo_erisim As New CLASSGENERICSERVISTABLO_ERISIM
            Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
            Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
            Dim genericserviskullanici_erisim As New CLASSGENERICSERVISKULLANICI_ERISIM

            result = genericservistablo_erisim.sililgili(genericservispkey)
            result = genericservisinput_erisim.sililgili(genericservispkey)
            result = genericservisoutput_erisim.sililgili(genericservispkey)
            result = genericserviskullanici_erisim.sililgili(genericservispkey)
            result = genericservis_erisim.Sil(genericservispkey)




            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If

    End Sub



    ' GENERIC SERVİS SİLME------------
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM
            result = genericservis_erisim.Sil(Request.QueryString("pkey"))

            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If


    End Sub

    Protected Sub Buttonotomatikekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonotomatikekle.Click

        inn.Value = "2"
        Dim hata As String = "0"
        Dim hatamesajlari As String = ""

        Dim genericservis As New CLASSGENERICSERVIS
        Dim genericservispkey As String
        genericservispkey = Request.QueryString("pkey")
        genericservis = genericservis_erisim.bultek(genericservispkey)

        Dim ilgilitablo As New CLASSGENERICSERVISTABLO
        Dim ilgilitablolar As New List(Of CLASSGENERICSERVISTABLO)
        ilgilitablolar = genericservistablo_erisim.doldurilgili(genericservispkey)

        If ilgilitablolar.Count <= 0 Then
            hatamesajlari = hatamesajlari + "<li>Servise tablo eklemediniz.</li>"
            hata = "1"
        End If


        If genericservis.tip <> "insert" And genericservis.tip <> "update" And genericservis.tip <> "delete" Then
            hatamesajlari = hatamesajlari + "<li>Bu tipte bir servise otomatik parametre ekleyemeyiz.</li>"
            hata = "1"
        End If


        If hata = "1" Then
            Labelgenericservisinput.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)

            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim primarykolonlar As New List(Of CLASSVERITABANIKOLONDETAY)


            'ÖNCE TÜM INPUT PARAMETRELERİNİ SİL
            genericservisinput_erisim.sililgili(genericservispkey)


            'SQL STRING OLUŞTURMAK İÇİN DEĞİŞKENLER
            Dim otosqlinsert, otosqlupdate, otosqldelete As String
            Dim otosqlic_insert, otosqlic_update, otosqlic_delete As String
            Dim otosqlson_insert, otosqlson_update, otosqlson_delete As String

            Dim otosqlbas, otosqlson, otosqltablo As String

            otosqlinsert = ""
            otosqlupdate = ""
            otosqldelete = ""
            otosqlic_insert = ""
            otosqlic_update = ""
            otosqlic_delete = ""
            otosqlson_insert = ""
            otosqlson_update = ""
            otosqlson_delete = ""

            If genericservis.tip = "insert" Then
                otosqlbas = "insert into "
            End If
            If genericservis.tip = "update" Then
                otosqlbas = "update "
            End If
            If genericservis.tip = "delete" Then
                otosqlbas = "delete "
            End If


            'ÎNPUT PARAMETRELERİ EKLE
            For Each itemtablo As CLASSGENERICSERVISTABLO In ilgilitablolar
                ilgilitablo = genericservistablo_erisim.bultek(itemtablo.pkey)
                otosqltablo = ilgilitablo.tabload
            Next

            'SQL BAŞI 
            If genericservis.tip = "insert" Or genericservis.tip = "update" Then
                otosqlbas = otosqlbas + otosqltablo + " "
            End If
            If genericservis.tip = "delete" Then
                otosqlbas = "delete from " + otosqltablo + " "
            End If


            'PRIMARY KEY BUL 
            primarykolonlar = sqlveritabanikolondetay_erisim.bulprimarykolonlar(site.sistemveritabaniad, otosqltablo)
            If primarykolonlar.Count >= 0 Then
                For Each itemprimarycolon As CLASSVERITABANIKOLONDETAY In primarykolonlar
                    otosqlson_update = otosqlson_update + itemprimarycolon.column_name + "=@" + itemprimarycolon.column_name + " and "
                Next
                otosqlson_update = Mid(otosqlson_update, 1, Len(otosqlson_update) - 4)
                otosqlson_update = " where " + otosqlson_update
            End If
            If genericservis.tip = "delete" Then
                For Each itemprimarycolon As CLASSVERITABANIKOLONDETAY In primarykolonlar
                    Dim eklenecekinput As New CLASSGENERICSERVISINPUT
                    eklenecekinput.paramad = itemprimarycolon.column_name
                    eklenecekinput.datatype = itemprimarycolon.data_type
                    eklenecekinput.genericservispkey = genericservispkey
                    genericservisinput_erisim.Ekle(eklenecekinput)
                Next
            End If

            'TÜM KOLONLARI INPUT PARAMETRE OLARAK EKLE
            If genericservis.tip = "insert" Or genericservis.tip = "update" Then
                kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, ilgilitablo.tabload)
                For Each itemkolon As CLASSVERITABANIKOLONDETAY In kolonlar
                    Dim eklenecekinput As New CLASSGENERICSERVISINPUT
                    eklenecekinput.paramad = itemkolon.column_name
                    eklenecekinput.datatype = itemkolon.data_type
                    eklenecekinput.genericservispkey = genericservispkey
                    genericservisinput_erisim.Ekle(eklenecekinput)
                    otosqlic_insert = otosqlic_insert + "@" + itemkolon.column_name + ","
                    otosqlic_update = otosqlic_update + itemkolon.column_name + "=" + "@" + itemkolon.column_name + ","
                Next
            End If


            If genericservis.tip = "insert" Then
                otosqlinsert = otosqlbas + "values(" + Mid(otosqlic_insert, 1, Len(otosqlic_insert) - 1) + ")"
                genericservis.sqlstrrun = otosqlinsert
            End If
            If genericservis.tip = "update" Then
                otosqlupdate = otosqlbas + "set " + Mid(otosqlic_update, 1, Len(otosqlic_update) - 1) + otosqlson_update
                genericservis.sqlstrrun = otosqlupdate
            End If
            If genericservis.tip = "delete" Then
                otosqldelete = otosqlbas + otosqlson_update
                genericservis.sqlstrrun = otosqldelete
            End If

            TextBox14.Text = genericservis.sqlstrrun
            genericservis_erisim.Duzenle(genericservis)


            'inputları göster
            Dim ilgili_genericservisinputler As New List(Of CLASSGENERICSERVISINPUT)
            HttpContext.Current.Session("ltip") = "ilgili"
            Labelgenericservisinput.Text = genericservisinput_erisim.listele()



        End If



    End Sub
End Class