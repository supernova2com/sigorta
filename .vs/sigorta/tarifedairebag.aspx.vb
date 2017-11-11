Public Partial Class tarifedairebag
    Inherits System.Web.UI.Page



    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim tarifedairebag As New CLASSTARIFEDAIREBAG
    Dim tarifedairebag_erisim As New CLASSTARIFEDAIREBAG_ERISIM

    'yetkiler icin 
    Dim tabload As String = "tarifedairebag"
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


            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tarifedairebag_erisim.listele()


            'TARİFE KODLARINI DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
            Dim aractarifeler As New List(Of CLASSARACTARIFE)
            aractarifeler = aractarife_erisim.doldur()
            For Each item As CLASSARACTARIFE In aractarifeler
                DropDownList1.Items.Add(New ListItem(item.tarifekod, CStr(item.pkey)))
            Next


            'ARAÇ KAYIT DAİRESİ ARAÇ TİPLERİNİ DOLDUR
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim dairearactip_erisim As New CLASSDAIREARACTIP_ERISIM
            Dim dairearactipler As New List(Of CLASSDAIREARACTIP)
            dairearactipler = dairearactip_erisim.doldur()
            For Each item As CLASSDAIREARACTIP In dairearactipler
                DropDownList2.Items.Add(New ListItem(item.dairearactipad, CStr(item.pkey)))
            Next


            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                tarifedairebag = tarifedairebag_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = tarifedairebag.aractarifepkey
                DropDownList2.SelectedValue = tarifedairebag.dairearactippkey
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                DropDownList1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
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
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Tarife kodunu seçmediniz.<br/>"
        End If

        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Araç tipini seçmediniz.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim tarifedairebag_erisim As New CLASSTARIFEDAIREBAG_ERISIM
        Dim tarifedairebag As New CLASSTARIFEDAIREBAG

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                tarifedairebag.aractarifepkey = DropDownList1.SelectedValue
                tarifedairebag.dairearactippkey = DropDownList2.SelectedValue
                result = tarifedairebag_erisim.Ekle(tarifedairebag)
            End If

            If Request.QueryString("op") = "duzenle" Then
                tarifedairebag = tarifedairebag_erisim.bultek(Request.QueryString("pkey"))
                tarifedairebag.aractarifepkey = DropDownList1.SelectedValue
                tarifedairebag.dairearactippkey = DropDownList2.SelectedValue
                result = tarifedairebag_erisim.Duzenle(tarifedairebag)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tarifedairebag_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim tarifedairebag_erisim As New CLASSTARIFEDAIREBAG_ERISIM
        result = tarifedairebag_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = tarifedairebag_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub



    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("tarifedairebag.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        DropDownList1.Enabled = True
        DropDownList2.Enabled = True

    End Sub


End Class