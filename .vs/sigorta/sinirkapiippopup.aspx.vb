Imports System.Net

Partial Public Class sinirkapiippopup
    Inherits System.Web.UI.Page


    Dim ip_erisim As New CLASSIP_ERISIM


    Dim kullanici As New CLASSKULLANICI
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim result As New CLADBOPRESULT

    Dim sinirkapiip_erisim As New CLASSSINIRKAPIIP_ERISIM

    Dim sinirkapi As New CLASSSINIRKAPI
    Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM


    'yetkiler icin 
    Dim tabload As String = "sinirkapiip"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM
    Dim sys_erisim As New CLASSSYS_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Button1.Visible = False



        Dim op As String
        op = Request.QueryString("op")

        TextBox11.Focus()

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then


            'cidr DOLDUR ---------------------------------
            DropDownList4.Items.Add(New ListItem("32", "32"))
            DropDownList4.Items.Add(New ListItem("24", "24"))
            DropDownList4.Items.Add(New ListItem("16", "16"))
            DropDownList4.Items.Add(New ListItem("8", "8"))

            'IP DUZENLE
            Dim sinirkapiipop As String
            sinirkapiipop = Request.QueryString("sinirkapiipop")
            If sinirkapiipop = "duzenle" Then
                Buttonipeklebutton.Visible = True
                Buttonipeklebutton.Text = "Güncelle"
                Dim sinirkapiip As New CLASSSINIRKAPIIP
                Dim sinirkapiippkey As String
                sinirkapiippkey = Request.QueryString("sinirkapiippkey")
                sinirkapiip = sinirkapiip_erisim.bultek(sinirkapiippkey)
                DropDownList4.SelectedValue = sinirkapiip.cidr
                TextBox11.Text = sinirkapiip.ip
            Else
                Buttonipeklebutton.Text = "Ekle"
            End If
            '--------------------------------------------------------------------------------

            'ip adreslerini göster
            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("sinirkapipkey") = Request.QueryString("pkey")
            Labelipadresleri.Text = sinirkapiip_erisim.listele()

            sinirkapi = sinirkapi_erisim.bultek(Request.QueryString("pkey"))

            'If sinirkapi.ipdikkat = "Evet" Then
            'CheckBox4.Checked = True
            'Else
            'CheckBox4.Checked = False
            'End If

            CheckBox4.Checked = True
            CheckBox4.Enabled = False


        End If 'postback


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" Then
            Buttonipeklebutton.Visible = False
        Else
            Buttonipeklebutton.Visible = True
        End If
        If yetki.updateyetki = "Hayır" Then
            Buttonipeklebutton.Visible = False
        Else
            Buttonipeklebutton.Visible = True
        End If
        If yetki.readyetki = "Hayır" Then
            Labelipadresleri.Visible = False
        Else
            Labelipadresleri.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------


    End Sub


    'IP EKLEME GUNCELLEME
    Protected Sub Buttonipeklebutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonipeklebutton.Click

        Dim sinirkapiipop As String
        sinirkapiipop = Request.QueryString("sinirkapiipop")

        Dim result As New CLADBOPRESULT
        Dim sinirkapiip As New CLASSSINIRKAPIIP
        Dim sinirkapiip_erisim As New CLASSSINIRKAPIIP_ERISIM
        Dim hata As String

        Dim hatamesajlari As String

        hata = "0"

        'ip adresi
        If TextBox11.Text = "" Then
            TextBox11.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>IP adresini girmediniz.</li>"
        End If

        If TextBox11.Text <> "" Then
            Try
                Dim ipaddress As IPAddress
                ipaddress.Parse(TextBox11.Text)
            Catch ex As Exception
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Girdiğiniz ip adresi doğru değildir.</li>"
            End Try
        End If

        Try
            IPAddress.Parse(TextBox11.Text)
        Catch ex As Exception
            TextBox11.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>IP adresini düzgün girmediniz.</li>"
        End Try

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            If sinirkapiipop <> "duzenle" Then
                sinirkapiip.sinirkapipkey = Request.QueryString("pkey")
                sinirkapiip.ip = TextBox11.Text
                sinirkapiip.cidr = DropDownList4.SelectedValue
                result = sinirkapiip_erisim.Ekle(sinirkapiip)
            End If

            If sinirkapiipop = "duzenle" Then
                Dim sinirkapiippkey As String
                sinirkapiippkey = Request.QueryString("sinirkapiippkey")
                sinirkapiip = sinirkapiip_erisim.bultek(sinirkapiippkey)
                sinirkapiip.cidr = DropDownList4.SelectedValue
                sinirkapiip.ip = TextBox11.Text
                result = sinirkapiip_erisim.Duzenle(sinirkapiip)
            End If


            If result.durum = "Kaydedildi" Then
                Labelipresult.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                Labelipresult.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("sinirkapipkey") = Request.QueryString("pkey")
            Labelipadresleri.Text = sinirkapiip_erisim.listele()

        End If

    End Sub



    Protected Sub Buttonsinirkapiipiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonsinirkapiipiptal.Click

        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim pkey As String
        pkey = Request.QueryString("pkey")
        link = "sinirkapiippopup.aspx?op=" + op + "&pkey=" + pkey + "&sinirkapiipop=yenikayit" + "&hangiiptal=1"

        Response.Redirect(link)

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim pkey As String = Request.QueryString("pkey")
        sinirkapi = sinirkapi_erisim.bultek(pkey)
        If CheckBox4.Checked = True Then
            sinirkapi.ipdikkat = "Evet"
        Else
            sinirkapi.ipdikkat = "Hayır"
        End If

        result = sinirkapi_erisim.Duzenle(sinirkapi)
        If result.durum = "Kaydedildi" Then
            Labelipresult.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
        Else
            Labelipresult.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
            result.hatastr + "</li></ol></div>"
        End If

    End Sub


End Class