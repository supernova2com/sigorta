Public Partial Class mahalle
    Inherits System.Web.UI.Page


    Dim ip_erisim As New CLASSIP_ERISIM
    Dim adrescore_erisim As New CLASSADRESCORE_ERISIM

    Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM
    Dim loggenel As New CLASSLOGGENEL

    Dim mahalle As New CLASSMAHALLE
    Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

    Dim kullanici As New CLASSKULLANICI
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Dim ilce As New CLASSILCE
    Dim ilce_erisim As New CLASSILCE_ERISIM
    Dim bucak As New CLASSBUCAK
    Dim bucak_erisim As New CLASSBUCAK_ERISIM
    Dim belediye As New CLASSBELEDIYE
    Dim belediye_erisim As New CLASSBELEDIYE_ERISIM


    'yetkiler icin 
    Dim tabload As String = "mahalle"
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

            Dim mahalle As New CLASSMAHALLE
            Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

            'İLÇELERİ DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim ilce_erisim As New CLASSILCE_ERISIM
            Dim ilceler As New List(Of CLASSILCE)
            ilceler = ilce_erisim.doldur
            For Each item As CLASSILCE In ilceler
                DropDownList1.Items.Add(New ListItem(item.ilcead, CStr(item.pkey)))
            Next

            'TİPLERİ DOLDUR
            DropDownList4.Items.Add(New ListItem("Mahalle", "Mahalle"))
            DropDownList4.Items.Add(New ListItem("Köy", "Köy"))


            'TÜM GİRİLEN mahalle BUL 
            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = mahalle_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"

                mahalle = mahalle_erisim.bultek(Request.QueryString("pkey"))

                belediye = belediye_erisim.bultek(mahalle.belediyepkey)
                bucak = bucak_erisim.bultek(belediye.bucakpkey)
                ilce = ilce_erisim.bultek(bucak.ilcepkey)

                DropDownList1.SelectedValue = ilce.pkey

                'BUCAKLARI DOLDUR 
                DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
                Dim bucakler As New List(Of CLASSBUCAK)
                bucakler = bucak_erisim.doldurilgili(ilce.pkey)
                For Each item As CLASSBUCAK In bucakler
                    DropDownList2.Items.Add(New ListItem(item.bucakad, CStr(item.pkey)))
                Next
                DropDownList2.SelectedValue = bucak.pkey

                'BELDİYELERİ DOLDUR 
                DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
                Dim belediyeler As New List(Of CLASSBELEDIYE)
                belediyeler = belediye_erisim.doldurilgili(bucak.pkey)
                For Each item As CLASSBELEDIYE In belediyeler
                    DropDownList3.Items.Add(New ListItem(item.belediyead, CStr(item.pkey)))
                Next

                DropDownList3.SelectedValue = mahalle.belediyepkey
                Textbox1.Text = mahalle.mahallead
                DropDownList4.SelectedValue = mahalle.tip
                If mahalle.muhtarivarmi = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
                Textbox2.Text = mahalle.postakod

            End If

            If Request.QueryString("op") = "yenikayit" Then
                DropDownList1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
                DropDownList4.Enabled = False

            End If

        End If


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)

        'INSERT YETKİ
        If yetki.insertyetki = "Hayır" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        End If
        If yetki.insertyetki = "Evet" Then
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If

        'UPDATE YETKİ
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



        'ilceyi seçtimi --------------------
        If DropDownList1.SelectedValue = "" Or DropDownList1.SelectedValue = "0" Or _
        IsNumeric(DropDownList1.SelectedValue) = False Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "İlçeyı girmediniz.<br/>"
        End If


        'bucak seçtimi --------------------
        If Request.Form("DropDownList2") = "" Or Request.Form("DropDownList2") = "0" Or _
        IsNumeric(Request.Form("DropDownList2")) = False Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Bucağı girmediniz.<br/>"
        End If

        'belediye seçtimi --------------------
        If Request.Form("DropDownList3") = "" Or Request.Form("DropDownList3") = "0" Or _
        IsNumeric(Request.Form("DropDownList3")) = False Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Belediyeyi girmediniz.<br/>"
        End If

        ' mahalle adı -------------------------
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Mahalle adını girmediniz.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        Dim mahalle As New CLASSMAHALLE

        If hata = "0" Then

            mahalle.belediyepkey = Request.Form("DropDownList3")
            mahalle.mahallead = UCase(Textbox1.Text)
            mahalle.tip = DropDownList4.SelectedValue
            If CheckBox1.Checked = True Then
                mahalle.muhtarivarmi = "Evet"
            Else
                mahalle.muhtarivarmi = "Hayır"
            End If
            mahalle.postakod = Textbox2.Text


            If Request.QueryString("op") = "yenikayit" Then
                result = mahalle_erisim.Ekle(mahalle)
            End If

            If Request.QueryString("op") = "duzenle" Then
                mahalle = mahalle_erisim.bultek(Request.QueryString("pkey"))
                mahalle.belediyepkey = Request.Form("DropDownList3")
                mahalle.mahallead = UCase(Textbox1.Text)
                mahalle.tip = DropDownList4.SelectedValue
                If CheckBox1.Checked = True Then
                    mahalle.muhtarivarmi = "Evet"
                Else
                    mahalle.muhtarivarmi = "Hayır"
                End If

                mahalle.postakod = Textbox2.Text
                result = mahalle_erisim.Duzenle(mahalle)
            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = mahalle_erisim.listele()


        End If


    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        'yetkilimi -------------------------
        Dim result As New CLADBOPRESULT
        Dim hata As String = "0"
        Dim hatamesajlari As String = ""

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If
        '----------------------------------------------------------------------------------

        If hata = "0" Then

            mahalle = mahalle_erisim.bultek(Request.QueryString("pkey"))
            result = mahalle_erisim.Sil(Request.QueryString("pkey"))
            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = mahalle_erisim.listele()
            durumlabel.Text = javascript.alertresult(result)
        

        End If

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("mahalle.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub



End Class