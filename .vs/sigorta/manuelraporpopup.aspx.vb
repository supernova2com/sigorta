Public Partial Class manuelraporpopup
    Inherits System.Web.UI.Page

    Dim manuelrapor As New CLASSMANUELRAPOR
    Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    Dim manuelraporparametre As New CLASSMANUELRAPORPARAMETRE
    Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM

    Dim manuelraporkullanici As New CLASSMANUELRAPORKULLANICI
    Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim op As String
        op = Request.QueryString("op")
        Dim manuelraporpkey As String

        'Test Düğmesi Göster Yada Gösterme
        If op <> "duzenle" Then
            Button2.Visible = False
            Button3.Visible = False

        Else
            Button2.Visible = True
            Button3.Visible = True
        End If

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        If Session("kullanici_rolpkey") <> "2" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'iptallere göre düğmeleri gizle---------------------------------
            If Request.QueryString("hangiiptal") = "1" Then
                Buttonmanuelraporparametreiptal.Visible = False
                inn.Value = "1"
            End If
            If Request.QueryString("hangiiptal") = "2" Then
                Buttonmanuelraporkullaniciiptal.Visible = False
                inn.Value = "2"
            End If
           
            '---------------------------------------------------------------

            Dim innquery As String
            innquery = Request.QueryString("inn")
            If innquery <> "" Then
                inn.Value = innquery
            End If

            If innquery = "1" Then
                TextBox3.Focus()
            End If


            'KULLANICILARI DOLDUR
            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList3.Items.Add(New ListItem(item.adsoyad, item.pkey))
            Next

            'RAPOR AKTİD PASİF DOLDUR 
            DropDownList1.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList1.Items.Add(New ListItem("Hayır", "Hayır"))

            'ZAMANLAMALARI DOLDUR
            Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
            Dim remindersettinglar As New List(Of CLASSREMINDERSETTING)
            remindersettinglar = remindersetting_erisim.doldur
            For Each item As CLASSREMINDERSETTING In remindersettinglar
                DropDownList2.Items.Add(New ListItem(item.reminder_name, item.pkey))
            Next

            If op = "yenikayit" Then
                Button2.Visible = False
                TextBox1.Focus()
            End If

            If op = "duzenle" Then

                manuelraporpkey = Request.QueryString("pkey")
                Button2.Visible = True

                HttpContext.Current.Session("ltip") = "ilgili"
                HttpContext.Current.Session("manuelraporpkey") = manuelraporpkey

                'parametreleri
                Dim ilgili_manuelraporparametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelmanuelraporparametre.Text = manuelraporparametre_erisim.listele()

                'kullanicilari
                Dim ilgili_manuelraporkullanicilar As New List(Of CLASSMANUELRAPORKULLANICI)
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelmanuelraporkullanici.Text = manuelraporkullanici_erisim.listele()


                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                manuelrapor = manuelrapor_erisim.bultek(Request.QueryString("pkey"))

                'manuelrapor bilgiler
                TextBox1.Text = manuelrapor.ad
                TextBox2.Text = manuelrapor.aciklama
                DropDownList1.SelectedValue = manuelrapor.aktifmi
                DropDownList2.SelectedValue = manuelrapor.remindersettingpkey


                'MANUELRAPORPARAMETRE DÜZENLE İÇİN ----------------------------------------------------
                Dim manuelraporparametreop As String
                manuelraporparametreop = Request.QueryString("manuelraporparametreop")
                If manuelraporparametreop = "duzenle" Then
                    Buttonmanuelraporparametreiptal.Visible = True
                    inn.Value = "1"
                    Buttonmanuelraporparametreekle.Text = "Güncelle"
                    Dim manuelraporparametre As New CLASSMANUELRAPORPARAMETRE
                    Dim manuelraporparametrepkey As String
                    manuelraporparametrepkey = Request.QueryString("manuelraporparametrepkey")
                    manuelraporparametre = manuelraporparametre_erisim.bultek(manuelraporparametrepkey)
                    TextBox3.Text = manuelraporparametre.sad
                    TextBox4.Text = manuelraporparametre.sdeger

                Else
                    Buttonmanuelraporparametreekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------


                'MANUELRAPORKULLANICI DÜZENLE İÇİN ----------------------------------------------------
                Dim manuelraporkullaniciop As String
                manuelraporkullaniciop = Request.QueryString("manuelraporkullaniciop")
                If manuelraporkullaniciop = "duzenle" Then
                    inn.Value = "2"
                    Buttonmanuelraporkullaniciiptal.Visible = True
                    Buttonmanuelraporkullanicikaydet.Text = "Güncelle"

                    Dim manuelraporkullanici As New CLASSMANUELRAPORKULLANICI

                    Dim manuelraporkullanicipkey As String
                    manuelraporkullanicipkey = Request.QueryString("manuelraporkullanicipkey")
                    manuelraporkullanici = manuelraporkullanici_erisim.bultek(manuelraporkullanicipkey)
                    DropDownList3.SelectedValue = manuelraporkullanici.kullanicipkey
                    If manuelraporkullanici.epostaexcel = "Evet" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If
                    If manuelraporkullanici.epostaword = "Evet" Then
                        CheckBox2.Checked = True
                    Else
                        CheckBox2.Checked = False
                    End If
                    If manuelraporkullanici.epostapdf = "Evet" Then
                        CheckBox3.Checked = True
                    Else
                        CheckBox3.Checked = False
                    End If
                Else
                    Buttonmanuelraporkullanicikaydet.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

            End If

        End If 'postback


    End Sub


    'MANUEL RAPORU KAYDET
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim manuelrapor As New CLASSMANUELRAPOR
        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
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

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            manuelrapor.ad = TextBox1.Text
            manuelrapor.aciklama = TextBox2.Text
            manuelrapor.aktifmi = DropDownList1.SelectedValue
            manuelrapor.remindersettingpkey = DropDownList2.SelectedValue

            If Request.QueryString("op") = "yenikayit" Then
                result = manuelrapor_erisim.Ekle(manuelrapor)
                If result.durum = "Kaydedildi" Then
                    inn.Value = "1"
                    Dim duzenlemelink As String
                    duzenlemelink = "manuelraporpopup.aspx?pkey=" + CStr(result.etkilenen) + "&op=duzenle&inn=1"
                    Response.Redirect(duzenlemelink)
                End If
            End If

            If Request.QueryString("op") = "duzenle" Then
                manuelrapor = manuelrapor_erisim.bultek(Request.QueryString("pkey"))

                manuelrapor.ad = TextBox1.Text
                manuelrapor.aciklama = TextBox2.Text
                manuelrapor.aktifmi = DropDownList1.SelectedValue
                manuelrapor.remindersettingpkey = DropDownList2.SelectedValue
                result = manuelrapor_erisim.Duzenle(manuelrapor)
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


    ' RAPOR SİLME------------
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
            result = manuelrapor_erisim.Sil(Request.QueryString("pkey"))

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

    'PARAMETRE EKLE
    Protected Sub Buttonmanuelraporparametreekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonmanuelraporparametreekle.Click

        Dim hata As String
        Dim manuelraporparametre As New CLASSMANUELRAPORPARAMETRE
        Dim manuelraporpkey As String
        manuelraporpkey = Request.QueryString("pkey")

        inn.Value = "1"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Parametre adını girmediniz.</li>"
            inn.Value = "1"
        End If

        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Parametre değerini girmediniz.</li>"
            inn.Value = "1"
        End If

        If hata = "1" Then
            Labeldurummanuelraporparametre.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            Dim manuelraporparametreop As String
            manuelraporparametreop = Request.QueryString("manuelraporparametreop")

            If manuelraporparametreop <> "duzenle" Then
                manuelraporparametre.manuelraporpkey = manuelraporpkey
                manuelraporparametre.sad = TextBox3.Text
                manuelraporparametre.sdeger = TextBox4.Text
                result = manuelraporparametre_erisim.Ekle(manuelraporparametre)
            End If

            If manuelraporparametreop = "duzenle" Then
                Dim manuelraporparametrepkey As String
                manuelraporparametrepkey = Request.QueryString("manuelraporparametrepkey")
                manuelraporparametre = manuelraporparametre_erisim.bultek(manuelraporparametrepkey)
                manuelraporparametre.manuelraporpkey = manuelraporpkey
                manuelraporparametre.manuelraporpkey = manuelraporpkey
                manuelraporparametre.sad = TextBox3.Text
                manuelraporparametre.sdeger = TextBox4.Text
                result = manuelraporparametre_erisim.Duzenle(manuelraporparametre)
            End If

            If result.etkilenen = 0 Then
                Labeldurummanuelraporparametre.Text = "<div id=errorMsg>" + _
                "<h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                Labeldurummanuelraporparametre.Text = "<div id=okMsg>" + _
                "<p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

            'parametereleri göster
            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = manuelraporpkey
            Labelmanuelraporparametre.Text = manuelraporparametre_erisim.listele


        End If 'hata=0
       

    End Sub


    'KULLANICI EKLE
    Protected Sub Buttonmanuelraporkullanicikaydet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonmanuelraporkullanicikaydet.Click

        Dim hata As String
        Dim manuelraporkullanici As New CLASSMANUELRAPORKULLANICI
        Dim manuelraporpkey As String
        manuelraporpkey = Request.QueryString("pkey")

        inn.Value = "2"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        If DropDownList3.SelectedValue = "0" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Kullanıcıyı seçmediniz.</li>"
            inn.Value = "2"
        End If

        If hata = "1" Then
            Labeldurummanuelraporparametre.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            Dim manuelraporkullaniciop As String
            manuelraporkullaniciop = Request.QueryString("manuelraporkullaniciop")

            If manuelraporkullaniciop <> "duzenle" Then
                manuelraporkullanici.manuelraporpkey = manuelraporpkey
                manuelraporkullanici.kullanicipkey = DropDownList3.SelectedValue

                If CheckBox1.Checked = True Then
                    manuelraporkullanici.epostaexcel = "Evet"
                Else
                    manuelraporkullanici.epostaexcel = "Hayır"
                End If
                If CheckBox2.Checked = True Then
                    manuelraporkullanici.epostaword = "Evet"
                Else
                    manuelraporkullanici.epostaword = "Hayır"
                End If
                If CheckBox3.Checked = True Then
                    manuelraporkullanici.epostapdf = "Evet"
                Else
                    manuelraporkullanici.epostapdf = "Hayır"
                End If
                result = manuelraporkullanici_erisim.Ekle(manuelraporkullanici)
            End If

            If manuelraporkullaniciop = "duzenle" Then
                Dim manuelraporkullanicipkey As String
                manuelraporkullanicipkey = Request.QueryString("manuelraporkullanicipkey")


                manuelraporkullanici = manuelraporkullanici_erisim.bultek(manuelraporkullanicipkey)

                manuelraporkullanici.kullanicipkey = DropDownList3.SelectedValue

                If CheckBox1.Checked = True Then
                    manuelraporkullanici.epostaexcel = "Evet"
                Else
                    manuelraporkullanici.epostaexcel = "Hayır"
                End If
                If CheckBox2.Checked = True Then
                    manuelraporkullanici.epostaword = "Evet"
                Else
                    manuelraporkullanici.epostaword = "Hayır"
                End If
                If CheckBox3.Checked = True Then
                    manuelraporkullanici.epostapdf = "Evet"
                Else
                    manuelraporkullanici.epostapdf = "Hayır"
                End If

                result = manuelraporparametre_erisim.Duzenle(manuelraporparametre)
            End If

            If result.etkilenen = 0 Then
                Labeldurummanuelraporparametre.Text = "<div id=errorMsg>" + _
                "<h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                Labeldurummanuelraporparametre.Text = "<div id=okMsg>" + _
                "<p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

            'parametereleri göster
            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = manuelraporpkey
            Labelmanuelraporkullanici.Text = manuelraporkullanici_erisim.listele


        End If 'hata=0

    End Sub


    Protected Sub Buttonmanuelraporparametreiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonmanuelraporparametreiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim manuelraporpkey As String
        manuelraporpkey = Request.QueryString("pkey")
        link = "manuelraporpopup.aspx?op=" + op + "&pkey=" + manuelraporpkey + "&hangiiptal=1"
        inn.Value = "1"
        Response.Redirect(link)
    End Sub

    Protected Sub Buttonmanuelraporkullaniciiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonmanuelraporkullaniciiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim manuelraporpkey As String
        manuelraporpkey = Request.QueryString("pkey")
        link = "manuelraporpopup.aspx?op=" + op + "&pkey=" + manuelraporpkey + "&hangiiptal=2"
        inn.Value = "2"
        Response.Redirect(link)
    End Sub


  
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim result As New CLADBOPRESULT
        Dim manuelraporpkey As String
        manuelraporpkey = Request.QueryString("pkey")

        If manuelraporpkey <> "" Then

            Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM

            Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM
            Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

            result = manuelraporparametre_erisim.sililgili(manuelraporpkey)
            result = manuelraporkullanici_erisim.sililgili(manuelraporpkey)
            result = manuelrapor_erisim.Sil(manuelraporpkey)


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
End Class