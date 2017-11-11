Public Partial Class bazfiyatgirissure
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
    Dim bazfiyatgirissure_erisim As New CLASSBAZFIYATGIRISSURE_ERISIM


    'yetkiler icin 
    Dim tabload As String = "bazfiyatgirissure"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("bazfiyatgirissure", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'POLİÇE TİPLERİNİ DOLDUR
            Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
            Dim policetipleri As New List(Of CLASSPOLICETIP)
            policetipleri = policetip_erisim.doldur()
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSPOLICETIP In policetipleri
                DropDownList1.Items.Add(New ListItem(item.policetipad, CStr(item.pkey)))
            Next

            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = bazfiyatgirissure_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                bazfiyatgirissure = bazfiyatgirissure_erisim.bultek(Request.QueryString("pkey"))
                TextBox3.Text = bazfiyatgirissure.girisbaslangic
                TextBox4.Text = bazfiyatgirissure.girisbitis
                TextBox5.Text = bazfiyatgirissure.gecerlilikbaslangic
                TextBox6.Text = bazfiyatgirissure.gecerlilikbitis
                DropDownList1.SelectedValue = bazfiyatgirissure.policetip
                TextBox1.Text = bazfiyatgirissure.kayitno
            End If

            If Request.QueryString("op") = "yenikayit" Then
                TextBox1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                TextBox1.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                DropDownList1.Enabled = False
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
        Dim girisbaslangic, girisbitis, gecerlilikbaslangic, gecerlilikbitis As Date


        hata = "0"

        ' KONTROL ET ---------------------------
        If DropDownList1.SelectedValue = "0" Then
            hatamesajlari = hatamesajlari + "<li>Poliçe tipini seçmediniz.</li>"
            DropDownList1.Focus()
        End If

        'girisbaslangic---------------------------
        Try
            girisbaslangic = TextBox3.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Giriş Başlangıç tarihini doğru girmediniz.</li>"
            TextBox3.Focus()
        End Try

        'girisbitis---------------------------
        Try
            girisbitis = TextBox4.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Giriş Bitiş tarihini doğru girmediniz.</li>"
            TextBox4.Focus()
        End Try

        'gecerlilikbaslangic---------------------------
        Try
            gecerlilikbaslangic = TextBox5.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Geçerlilik Başlangıç tarihini doğru girmediniz.</li>"
            TextBox5.Focus()
        End Try

        'gecerlilikbitis---------------------------
        Try
            gecerlilikbitis = TextBox6.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Geçerlilik Bitiş tarihini doğru girmediniz.</li>"
            TextBox6.Focus()
        End Try


        'kayit numarası
        If IsNumeric(TextBox1.Text) = False Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kayıt numarası rakamsal olmalıdır.<br/>"
        End If

        'mantıksal kontroller 
        If hata = "0" Then
            If girisbaslangic > girisbitis Then
                TextBox3.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Giriş başlangıç tarihi giriş bitiş tarihinden büyük olamaz.<br/>"
            End If
            If gecerlilikbaslangic > gecerlilikbitis Then
                TextBox5.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Geçerlilik başlangıç tarihi geçerlilik bitiş" + _
                " tarihinden büyük olamaz.<br/>"
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim bazfiyatgirissure_erisim As New CLASSBAZFIYATGIRISSURE_ERISIM
        Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                bazfiyatgirissure.girisbaslangic = TextBox3.Text
                bazfiyatgirissure.girisbitis = TextBox4.Text
                bazfiyatgirissure.gecerlilikbaslangic = TextBox5.Text
                bazfiyatgirissure.gecerlilikbitis = TextBox6.Text
                bazfiyatgirissure.policetip = DropDownList1.SelectedValue
                bazfiyatgirissure.kayitno = TextBox1.Text
                result = bazfiyatgirissure_erisim.Ekle(bazfiyatgirissure)
            End If

            If Request.QueryString("op") = "duzenle" Then
                bazfiyatgirissure = bazfiyatgirissure_erisim.bultek(Request.QueryString("pkey"))
                bazfiyatgirissure.girisbaslangic = TextBox3.Text
                bazfiyatgirissure.girisbitis = TextBox4.Text
                bazfiyatgirissure.gecerlilikbaslangic = TextBox5.Text
                bazfiyatgirissure.gecerlilikbitis = TextBox6.Text
                bazfiyatgirissure.policetip = DropDownList1.SelectedValue
                bazfiyatgirissure.kayitno = TextBox1.Text
                result = bazfiyatgirissure_erisim.Duzenle(bazfiyatgirissure)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = bazfiyatgirissure_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim bazfiyatgirissure_erisim As New CLASSBAZFIYATGIRISSURE_ERISIM
        result = bazfiyatgirissure_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"

        If result.durum = "Kaydedildi" Then
            Label1.Text = bazfiyatgirissure_erisim.listele()
        End If

        durumlabel.Text = javascript.alertresult(result)

    End Sub




    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("bazfiyatgirissure.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        DropDownList1.Enabled = True

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        If DropDownList1.SelectedValue <> "0" Then
            TextBox1.Text = CStr(bazfiyatgirissure_erisim.sonkayitnobul(DropDownList1.SelectedValue))
            TextBox3.Focus()
        End If 'en son kayit numarasını bul 



    End Sub
End Class