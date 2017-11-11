Public Partial Class ihalesinir
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim ihalesinir As New CLASSIHALESINIR
    Dim ihalesinir_erisim As New CLASSIHALESINIR_ERISIM


    'yetkiler icin 
    Dim tabload As String = "ihalesinir"
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

            'ŞİRKETLERİ DOLDUR
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = ihalesinir_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                ihalesinir = ihalesinir_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = ihalesinir.sirketpkey
                TextBox1.Text = ihalesinir.baslangictarih
                TextBox2.Text = ihalesinir.bitistarih
                TextBox3.Text = ihalesinir.maksadet
            End If

            If Request.QueryString("op") = "yenikayit" Then
                TextBox1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                Button1.Enabled = False
                Buttonsil.Visible = False
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

        If yetki.deleteyetki = "Hayır" And opy = "duzenle" Then
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
        Dim baslangictarih, bitistarih, maksadet, gecerlilikbitis As Date

        hata = "0"

        ' KONTROL ET ---------------------------
        If DropDownList1.SelectedValue = "0" Then
            hatamesajlari = hatamesajlari + "<li>Şirketi seçmediniz.</li>"
            DropDownList1.Focus()
        End If

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Giriş Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Giriş Bitiş tarihini doğru girmediniz.</li>"
            TextBox2.Focus()
        End Try


        'maksadet
        If IsNumeric(TextBox3.Text) = False Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Maksimum girebileceği adet rakamsal olmalıdır.<br/>"
        End If

        'mantıksal kontroller 
        If hata = "0" Then
            If baslangictarih > bitistarih Then
                TextBox3.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Giriş başlangıç tarihi giriş bitiş tarihinden büyük olamaz.<br/>"
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim ihalesinir_erisim As New CLASSIHALESINIR_ERISIM
        Dim ihalesinir As New CLASSIHALESINIR

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                ihalesinir.sirketpkey = DropDownList1.SelectedValue
                ihalesinir.baslangictarih = TextBox1.Text
                ihalesinir.bitistarih = TextBox2.Text
                ihalesinir.maksadet = TextBox3.Text

                result = ihalesinir_erisim.Ekle(ihalesinir)
            End If

            If Request.QueryString("op") = "duzenle" Then
                ihalesinir = ihalesinir_erisim.bultek(Request.QueryString("pkey"))
                ihalesinir.sirketpkey = DropDownList1.SelectedValue
                ihalesinir.baslangictarih = TextBox1.Text
                ihalesinir.bitistarih = TextBox2.Text
                ihalesinir.maksadet = TextBox3.Text

                result = ihalesinir_erisim.Duzenle(ihalesinir)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = ihalesinir_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim ihalesinir_erisim As New CLASSIHALESINIR_ERISIM
        result = ihalesinir_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"

        If result.durum = "Kaydedildi" Then
            Label1.Text = ihalesinir_erisim.listele()
        End If

        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("ihalesinir.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

        DropDownList1.Enabled = True

    End Sub


End Class