Public Partial Class tarifesinirkapibag
    Inherits System.Web.UI.Page



    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim tarifesinirkapibag As New CLASSTARIFESINIRKAPIBAG
    Dim tarifesinirkapibag_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM

    'yetkiler icin 
    Dim tabload As String = "tarifesinirkapibag"
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
            Label1.Text = tarifesinirkapibag_erisim.listele()


            'TARİFE KODLARINI DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
            Dim aractarifeler As New List(Of CLASSARACTARIFE)
            aractarifeler = aractarife_erisim.doldur()
            For Each item As CLASSARACTARIFE In aractarifeler
                DropDownList1.Items.Add(New ListItem(item.tarifekod, CStr(item.pkey)))
            Next


            'SINIR KAPISI ARAÇ TİPLERİNİ DOLDUR
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM
            Dim sinirkapiaractipler As New List(Of CLASSSINIRKAPIARACTIP)
            sinirkapiaractipler = sinirkapiaractip_erisim.doldur()
            For Each item As CLASSSINIRKAPIARACTIP In sinirkapiaractipler
                DropDownList2.Items.Add(New ListItem(item.sinirkapiaractipad, CStr(item.pkey)))
            Next


            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                tarifesinirkapibag = tarifesinirkapibag_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = tarifesinirkapibag.aractarifepkey
                DropDownList2.SelectedValue = tarifesinirkapibag.sinirkapiaractippkey
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

        Dim tarifesinirkapibag_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM
        Dim tarifesinirkapibag As New CLASSTARIFESINIRKAPIBAG

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                tarifesinirkapibag.aractarifepkey = DropDownList1.SelectedValue
                tarifesinirkapibag.sinirkapiaractippkey = DropDownList2.SelectedValue
                result = tarifesinirkapibag_erisim.Ekle(tarifesinirkapibag)
            End If

            If Request.QueryString("op") = "duzenle" Then
                tarifesinirkapibag = tarifesinirkapibag_erisim.bultek(Request.QueryString("pkey"))
                tarifesinirkapibag.aractarifepkey = DropDownList1.SelectedValue
                tarifesinirkapibag.sinirkapiaractippkey = DropDownList2.SelectedValue
                result = tarifesinirkapibag_erisim.Duzenle(tarifesinirkapibag)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tarifesinirkapibag_erisim.listele()

        End If

    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim tarifesinirkapibag_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM
        result = tarifesinirkapibag_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = tarifesinirkapibag_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub



    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("tarifesinirkapibag.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        DropDownList1.Enabled = True
        DropDownList2.Enabled = True

    End Sub


End Class