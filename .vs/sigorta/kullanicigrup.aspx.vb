﻿Public Partial Class kullanicigrup
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
    Dim kullanicigrup As New CLASSKULLANICIGRUP
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    'yetkiler icin 
    Dim tabload As String = "kullanicigrup"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("kullanicigrup", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'TÜM GİRİLEN KULLANICI GRUPLARINI BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanicigrup_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Buttonsil.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                kullanicigrup = kullanicigrup_erisim.bultek(Request.QueryString("pkey"))
                Textbox1.Text = kullanicigrup.grupad

                If kullanicigrup.grupsirkettarafindasecilebilsinmi = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
               
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                Textbox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                Textbox1.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
                Buttonsil.Visible = False
            End If

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        End If
        If yetki.insertyetki = "Evet" And opy = "yenikayit" Then
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If

        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        End If
        If yetki.updateyetki = "Evet" And opy = "duzenle" Then
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
        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET -----------------------------------------------
        'kullanıcı grup ad
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı grubu ismini girmediniz.<br/>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
        Dim kullanicigrup As New CLASSKULLANICIGRUP

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                kullanicigrup.grupad = Textbox1.Text

                If CheckBox1.Checked = True Then
                    kullanicigrup.grupsirkettarafindasecilebilsinmi = "Evet"
                Else
                    kullanicigrup.grupsirkettarafindasecilebilsinmi = "Hayır"
                End If

                result = kullanicigrup_erisim.Ekle(kullanicigrup)
            End If

            If Request.QueryString("op") = "duzenle" Then
                kullanicigrup = kullanicigrup_erisim.bultek(Request.QueryString("pkey"))
                kullanicigrup.grupad = Textbox1.Text

                If CheckBox1.Checked = True Then
                    kullanicigrup.grupsirkettarafindasecilebilsinmi = "Evet"
                Else
                    kullanicigrup.grupsirkettarafindasecilebilsinmi = "Hayır"
                End If

                result = kullanicigrup_erisim.Duzenle(kullanicigrup)
            End If

            durumlabel.Text = javascript.alertresult(result)
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanicigrup_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("kullanicigrup.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = kullanicigrup_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = kullanicigrup_erisim.listele()

    End Sub

End Class