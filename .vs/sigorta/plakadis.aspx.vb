Public Partial Class plakadis
    Inherits System.Web.UI.Page




    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim plakadis As New CLASSPLAKADIS
    Dim plakadis_erisim As New CLASSPLAKADIS_ERISIM

    'yetkiler icin 
    Dim tabload As String = "plakadis"
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

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                plakadis = plakadis_erisim.bultek(Request.QueryString("pkey"))
                TextBox1.Text = plakadis.plaka
                TextBox2.Text = plakadis.dogrucc
                TextBox3.Text = plakadis.arackayitcc
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False

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
            Buttonyenikayit.Visible = True
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

        hata = "0"

        ' KONTROL ET ---------------------------
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Plaka girilmelidir.<br/>"
        End If

        If IsNumeric(TextBox2.Text) = False Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Doğru CC rakamsal olmalıdır.<br/>"
        End If

        If IsNumeric(TextBox3.Text) = False Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç Kayıt CC rakamsal olmalıdır.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim plakadis_erisim As New CLASSPLAKADIS_ERISIM
        Dim plakadis As New CLASSPLAKADIS

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                plakadis.plaka = TextBox1.Text
                plakadis.dogrucc = TextBox2.Text
                plakadis.arackayitcc = TextBox3.Text
                plakadis.eklenmetarih = DateTime.Now
                plakadis.kullanicipkey = Session("kullanici_pkey")
                result = plakadis_erisim.Ekle(plakadis)
            End If

            If Request.QueryString("op") = "duzenle" Then
                plakadis = plakadis_erisim.bultek(Request.QueryString("pkey"))
                plakadis.plaka = TextBox1.Text
                plakadis.dogrucc = TextBox2.Text
                plakadis.arackayitcc = TextBox3.Text
                result = plakadis_erisim.Duzenle(plakadis)
            End If

            'lokal veritabanındaki cc bilgisini güncelle
            If result.durum = "Kaydedildi" Then
                Dim arackayitdaireresult As New CLADBOPRESULT
                Dim arackayitdaire As New CLASSARACKAYITDAIRE
                Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
                arackayitdaire = arackayitdaire_erisim.bultek(plakadis.plaka)
                'eğer böyle bir kayıt var ise
                If arackayitdaire.KatKod <> 0 Then
                    arackayitdaire.MotorGuc = plakadis.dogrucc
                    arackayitdaireresult = arackayitdaire_erisim.Duzenle(arackayitdaire)
                End If
            End If

            durumlabel.Text = javascript.alertresult(result)

            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = plakadis_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim plakadis_erisim As New CLASSPLAKADIS_ERISIM
        result = plakadis_erisim.Sil(Request.QueryString("pkey"))

        'HttpContext.Current.Session("ltip") = "TÜMÜ"
        'Label1.Text = plakadis_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("plakadis.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True

    End Sub

    Protected Sub Buttonarackayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonarackayit.Click

        Dim hata, hatamesajlari As String
        hata = "0"

        ' KONTROL ET ---------------------------
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Plaka girilmelidir.<br/>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            Dim arackayitdaire As New CLASSARACKAYITDAIRE
            Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
            arackayitdaire = arackayitdaire_erisim.sorgula_plakayagore(TextBox1.Text)
            TextBox3.Text = arackayitdaire.MotorGuc
        End If


    End Sub
End Class