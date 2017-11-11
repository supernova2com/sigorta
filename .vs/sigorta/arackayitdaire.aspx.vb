﻿Public Partial Class arackayitdaire
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim arackayitdaire As New CLASSARACKAYITDAIRE
    Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM

    'yetkiler icin 
    Dim tabload As String = "arackayitdaire"
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
                arackayitdaire = arackayitdaire_erisim.bultek(Request.QueryString("PlakaNo"))
                TextBox1.Text = arackayitdaire.PlakaNo
                TextBox2.Text = arackayitdaire.KatKod
                TextBox3.Text = arackayitdaire.Marka
                TextBox4.Text = arackayitdaire.Tip
                TextBox5.Text = arackayitdaire.Model
                TextBox6.Text = arackayitdaire.MotorGuc
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
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
            hatamesajlari = hatamesajlari + "Kategori kodu rakamsal olmalıdır.<br/>"
        End If

        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Markayı girmediniz.<br/>"
        End If

        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç tipini girmediniz.<br/>"
        End If

        If IsNumeric(TextBox5.Text) = False Then
            TextBox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç modeli rakamsal olmalıdır.<br/>"
        End If

        If IsNumeric(TextBox6.Text) = False Then
            TextBox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Motor gücü rakamsal olmalıdır.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
        Dim arackayitdaire As New CLASSARACKAYITDAIRE

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                arackayitdaire.PlakaNo = TextBox1.Text
                arackayitdaire.KatKod = TextBox2.Text
                arackayitdaire.Marka = TextBox3.Text
                arackayitdaire.Tip = TextBox4.Text
                arackayitdaire.Model = TextBox5.Text
                arackayitdaire.MotorGuc = TextBox6.Text
                result = arackayitdaire_erisim.Ekle(arackayitdaire)
            End If

            If Request.QueryString("op") = "duzenle" Then
                arackayitdaire = arackayitdaire_erisim.bultek(Request.QueryString("PlakaNo"))
                arackayitdaire.PlakaNo = TextBox1.Text
                arackayitdaire.KatKod = TextBox2.Text
                arackayitdaire.Marka = TextBox3.Text
                arackayitdaire.Tip = TextBox4.Text
                arackayitdaire.Model = TextBox5.Text
                arackayitdaire.MotorGuc = TextBox6.Text
                result = arackayitdaire_erisim.Duzenle(arackayitdaire)
            End If

            durumlabel.Text = javascript.alertresult(result)

            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = arackayitdaire_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
        result = arackayitdaire_erisim.Sil(Request.QueryString("PlakaNo"))

        'HttpContext.Current.Session("ltip") = "TÜMÜ"
        'Label1.Text = arackayitdaire_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("arackayitdaire.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True

    End Sub

   
    Protected Sub Buttoncek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttoncek.Click

        Dim basplaka As String = ""
        Dim hata, hatamesajlari As String
        hata = "0"

        Dim result As New CLADBOPRESULT
        Dim arackayitdaire_Erisim As New CLASSARACKAYITDAIRE_ERISIM


        ' KONTROL ET ---------------------------
        If Len(TextBox7.Text) <> 2 Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "İlk 2 plaka başlangıç harfleri girilmelidir.<br/>"
        End If

        If hata = "1" Then
            Labeltopluceksonuc.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            result = arackayitdaire_Erisim.istenileni_cek(TextBox7.Text)
            Labeltopluceksonuc.Text = "Durum:" + CStr(result.durum) + "<br/>" + _
            "Eklenen:" + CStr(result.etkilenen) + "<br/>" + _
            "Kaydedilemeyen:" + CStr(result.hatastr)

        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim basplaka As String = ""
        Dim hata, hatamesajlari As String
        hata = "0"

        Dim result As New CLADBOPRESULT
        Dim arackayitdaire_Erisim As New CLASSARACKAYITDAIRE_ERISIM


        ' KONTROL ET ---------------------------
        If Len(TextBox7.Text) <> 1 Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Sadece plakanın ilk harfi girilmelidir.<br/>"
        End If

        If hata = "1" Then
            Labeltopluceksonuc.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            result = arackayitdaire_Erisim.istenileni_cek(TextBox7.Text)
            Labeltopluceksonuc.Text = "Durum:" + CStr(result.durum) + "<br/>" + _
            "Eklenen:" + CStr(result.etkilenen) + "<br/>" + _
            "Kaydedilemeyen:" + CStr(result.hatastr)

        End If


    End Sub
End Class