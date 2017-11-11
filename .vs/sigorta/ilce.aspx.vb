Public Partial Class ilce
    Inherits System.Web.UI.Page



    Dim ip_erisim As New CLASSIP_ERISIM

    Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM
    Dim loggenel As New CLASSLOGGENEL

    Dim ilce As New CLASSILCE
    Dim ilce_erisim As New CLASSILCE_ERISIM

    Dim adrescore_erisim As New CLASSADRESCORE_ERISIM

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

    Dim kullanici As New CLASSKULLANICI
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "ilce"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM
    Dim sys_erisim As New CLASSSYS_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If

        If Not Page.IsPostBack Then

            'TÜM GİRİLEN ilce BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = ilce_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Button1.Text = "Değişiklikleri Güncelle"
                ilce = ilce_erisim.bultek(Request.QueryString("pkey"))
                Textbox1.Text = ilce.ilcead
                Textbox2.Text = ilce.ilcekod
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Textbox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False

            End If

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)

        'INSERT
        If yetki.insertyetki = "Hayır" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        End If
        If yetki.insertyetki = "Evet" Then
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If

        'UPDATE
        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        End If
        If yetki.updateyetki = "Evet" And opy = "duzenle" Then
            Button1.Visible = True
        End If

        'DELETE
        If opy <> "duzenle" Then
            Buttonsil.Visible = False
        End If
        If yetki.deleteyetki = "Hayır" And opy = "duzenle" Then
            Buttonsil.Visible = False
        End If
        If yetki.deleteyetki = "Evet" And opy = "duzenle" Then
            Buttonsil.Visible = True
        End If

        'READ
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
        Dim op As String
        op = Request.QueryString("op")


        ' KONTROL ET -------------------------
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "İlçe adını girmediniz.<br/>"
        End If

        If Len(Textbox2.Text) <> 3 Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "İlçe kodu 3 karakterden oluşmalıdır.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim ilce_erisim As New CLASSilce_ERISIM
        Dim ilce As New CLASSILCE

        If hata = "0" Then

            ilce.ilcead = Textbox1.Text
            ilce.ilcekod = Textbox2.Text

            If Request.QueryString("op") = "yenikayit" Then
                result = ilce_erisim.Ekle(ilce)
            End If

            If Request.QueryString("op") = "duzenle" Then
                ilce = ilce_erisim.bultek(Request.QueryString("pkey"))
                ilce.ilcead = Textbox1.Text
                ilce.ilcekod = Textbox2.Text
                result = ilce_erisim.Duzenle(ilce)
            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = ilce_erisim.listele()

   

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click


        ilce = ilce_erisim.bultek(Request.QueryString("pkey"))
        result = ilce_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = ilce_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)
  
    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("ilce.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub



    


End Class