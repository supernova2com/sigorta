Imports System.Globalization


Partial Public Class sinirkapitakvim
    Inherits System.Web.UI.Page

    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim sinirkapitakvim As New CLASSSINIRKAPITAKVIM
    Dim sinirkapitakvim_erisim As New CLASSSINIRKAPITAKVIM_ERISIM

    Dim sinirkapi As New CLASSSINIRKAPI
    Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM


    'yetkiler icin 
    Dim tabload As String = "sinirkapitakvim"
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

            TextBox2.Attributes.Add("readonly", "readonly")
            'DropDownListbaslangicsaat.Enabled = False
            'DropDownListbaslangicdakika.Enabled = False
            'DropDownListbitissaat.Enabled = False
            'DropDownListbitisdakika.Enabled = False


            'SINIR KAPILARINI DOLDUR
            Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
            Dim sinirkapiler As New List(Of CLASSSINIRKAPI)
            sinirkapiler = sinirkapi_erisim.doldur()
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSSINIRKAPI In sinirkapiler
                DropDownList1.Items.Add(New ListItem(item.sinirkapiad, CStr(item.pkey)))
            Next


            'ŞİRKETLERİ DOLDUR
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList4.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList5.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList8.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList9.Items.Add(New ListItem("Seçiniz", "0"))

            For Each item As CLASSSIRKET In sirketler
                DropDownList2.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList3.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList4.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList5.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList6.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList7.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList8.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList9.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            Dim eklenecek As String
            'BAŞLANGIÇ SAATİ VE DAKİKASI
            For i = 0 To 23
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownListbaslangicsaat.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownListbaslangicsaat.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next
            For i = 0 To 59
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownListbaslangicdakika.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownListbaslangicdakika.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next


            'BİTİŞ SAATİ VE DAKİKASI
            For i = 0 To 23
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownListbitissaat.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownListbitissaat.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next
            For i = 0 To 60
                If i < 9 Then
                    eklenecek = "0" + CStr(i)
                    DropDownListbitisdakika.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownListbitisdakika.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next

            DropDownListbaslangicsaat.SelectedValue = "00"
            DropDownListbaslangicdakika.SelectedValue = "01"

            DropDownListbitissaat.SelectedValue = "23"
            DropDownListbitisdakika.SelectedValue = "59"


            If Request.QueryString("op") = "duzenle" Then

                '--------
                Literalinput.Visible = False
                Literalinput2.Visible = False
                Literalinput3.Visible = False

                DropDownList1.Visible = True
                sinirkapilabel.Visible = True
                '--------

                Button1.Text = "Değişiklikleri Güncelle"
                sinirkapitakvim = sinirkapitakvim_erisim.bultek(Request.QueryString("pkey"))

                DropDownList1.SelectedValue = sinirkapitakvim.sinirkapipkey
                TextBox1.Text = Format(sinirkapitakvim.gbaslangic, "dd/MM/yyyy")
                TextBox2.Text = Format(sinirkapitakvim.gbitis, "dd/MM/yyyy")
                DropDownList2.SelectedValue = sinirkapitakvim.gerceksirket1pkey
                DropDownList3.SelectedValue = sinirkapitakvim.gorevlisirket1pkey
         
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False

                'inputlari olustur 
                DropDownList1.Visible = False
                sinirkapilabel.Visible = False
                Literalinput.Visible = True
                Literalinput2.Visible = True
                Literalinput3.Visible = True

                Literalinput.Text = sinirkapi_erisim.inputlariolustur(1)
                Literalinput2.Text = sinirkapi_erisim.inputlariolustur(2)
                Literalinput3.Text = sinirkapi_erisim.inputlariolustur(3)

                TextBox1.Text = Date.Now.ToString("dd.MM.yyyy")
                TextBox2.Text = Date.Now.ToString("dd.MM.yyyy")


            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                DropDownList4.Enabled = False
                DropDownList5.Enabled = False
                Button1.Enabled = False
                DropDownListbaslangicsaat.Enabled = False
                DropDownListbaslangicdakika.Enabled = False
                DropDownListbitissaat.Enabled = False
                DropDownListbitisdakika.Enabled = False
                DropDownList8.Enabled = False
                DropDownList9.Enabled = False
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
        If opy <> "duzenle" Then
            Buttonsil.Visible = False
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
        Dim gbaslangic, gbitis As Date
        Dim op As String
        op = Request.QueryString("op")


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci

        hata = "0"

        ' KONTROL ET ---------------------------
        If op = "duzenle" Then
            If DropDownList1.SelectedValue = "0" Then
                hatamesajlari = hatamesajlari + "<li>Sınır kapısını seçmediniz.</li>"
                DropDownList1.Focus()
            End If
        End If


        'gbaslangic---------------------------
        Try
            gbaslangic = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Giriş Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'gbitis---------------------------
        Try
            gbitis = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Giriş Bitiş tarihini doğru girmediniz.</li>"
            TextBox2.Focus()
        End Try



        'gerceksirket1
        If DropDownList2.SelectedValue = "0" Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Gerçek 1. şirketi seçmediniz.</li>"
            DropDownList2.Focus()
        End If

        'gorevlisirket1
        If DropDownList3.SelectedValue = "0" Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Görevli 1. şirketi seçmediniz.</li>"
            DropDownList3.Focus()
        End If


        'gerceksirket2
        If DropDownList4.SelectedValue = "0" Then
            'hata = "1"
            'hatamesajlari = hatamesajlari + "<li>Gerçek 2. şirketi seçmediniz.</li>"
            'DropDownList4.Focus()
        End If

        'gorevlisirket2
        If DropDownList5.SelectedValue = "0" Then
            'hata = "1"
            'hatamesajlari = hatamesajlari + "<li>Görevli 2. şirketi seçmediniz.</li>"
            'DropDownList5.Focus()
        End If


        'mantıksal kontrol 
        If hata = "0" Then

            If DropDownList2.SelectedValue = DropDownList4.SelectedValue Then
                'hata = "1"
                'hatamesajlari = hatamesajlari + "<li>Gerçek şirket 1 ve 2 ayni olamaz.</li>"
                'DropDownList2.Focus()
            End If
            If DropDownList3.SelectedValue = DropDownList5.SelectedValue Then
                'hata = "1"
                'hatamesajlari = hatamesajlari + "<li>Görevli şirket 1 ve 2 ayni olamaz.</li>"
                'DropDownList3.Focus()
            End If

        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            Dim tdbaslangicf As New DateTime(gbaslangic.Year, gbaslangic.Month, gbaslangic.Day, DropDownListbaslangicsaat.SelectedValue, DropDownListbaslangicdakika.SelectedValue, 0)
            Dim tdbitisf As New DateTime(gbitis.Year, gbitis.Month, gbitis.Day, DropDownListbitissaat.SelectedValue, DropDownListbitisdakika.SelectedValue, 59)

            durumlabelkackayit.Text = ""


            If Request.QueryString("op") = "yenikayit" Then

                Dim sinirkapilar As New List(Of CLASSSINIRKAPI)
                sinirkapilar = sinirkapi_erisim.doldur

                Dim kackayit As Integer
                kackayit = 0

                For z = 1 To 3
                    For Each itemkapi As CLASSSINIRKAPI In sinirkapilar
                        Dim value, id As String
                        id = CStr(z) + "CheckBox" + CStr(itemkapi.pkey)
                        value = Request.Form(id)
                        If Not value Is Nothing Then

                            If z = 1 Then
                                If DropDownList2.SelectedValue <> "0" And DropDownList3.SelectedValue <> "0" Then
                                    sinirkapitakvim.sinirkapipkey = itemkapi.pkey
                                    sinirkapitakvim.gbaslangic = tdbaslangicf
                                    sinirkapitakvim.gbitis = tdbitisf
                                    sinirkapitakvim.gerceksirket1pkey = DropDownList2.SelectedValue
                                    sinirkapitakvim.gorevlisirket1pkey = DropDownList3.SelectedValue
                                    result = sinirkapitakvim_erisim.Ekle(sinirkapitakvim)
                                End If
                            End If

                            If z = 2 Then
                                If DropDownList4.SelectedValue <> "0" And DropDownList5.SelectedValue <> "0" Then
                                    sinirkapitakvim.sinirkapipkey = itemkapi.pkey
                                    sinirkapitakvim.gbaslangic = tdbaslangicf
                                    sinirkapitakvim.gbitis = tdbitisf
                                    sinirkapitakvim.gerceksirket1pkey = DropDownList4.SelectedValue
                                    sinirkapitakvim.gorevlisirket1pkey = DropDownList5.SelectedValue
                                    result = sinirkapitakvim_erisim.Ekle(sinirkapitakvim)
                                End If
                            End If

                            If z = 3 Then
                                If DropDownList8.SelectedValue <> "0" And DropDownList9.SelectedValue <> "0" Then
                                    sinirkapitakvim.sinirkapipkey = itemkapi.pkey
                                    sinirkapitakvim.gbaslangic = tdbaslangicf
                                    sinirkapitakvim.gbitis = tdbitisf
                                    sinirkapitakvim.gerceksirket1pkey = DropDownList8.SelectedValue
                                    sinirkapitakvim.gorevlisirket1pkey = DropDownList9.SelectedValue
                                    result = sinirkapitakvim_erisim.Ekle(sinirkapitakvim)
                                End If
                            End If
                          
                            If result.durum = "Kaydedildi" Then
                                kackayit = kackayit + 1
                            End If

                        End If
                    Next
                Next

                durumlabelkackayit.Text = CStr(kackayit) + " kayıt eklendi."
            End If 'yenikayit

            If Request.QueryString("op") = "duzenle" Then
                sinirkapitakvim = sinirkapitakvim_erisim.bultek(Request.QueryString("pkey"))
                sinirkapitakvim.sinirkapipkey = DropDownList1.SelectedValue
                sinirkapitakvim.gbaslangic = tdbaslangicf
                sinirkapitakvim.gbitis = tdbitisf
                sinirkapitakvim.gerceksirket1pkey = DropDownList2.SelectedValue
                sinirkapitakvim.gorevlisirket1pkey = DropDownList3.SelectedValue
                result = sinirkapitakvim_erisim.Duzenle(sinirkapitakvim)
            End If

            durumlabel.Text = javascript.alertresult(result)

            If result.durum = "Kaydedildi" Then
                HttpContext.Current.Session("ltip") = "tarih"
                HttpContext.Current.Session("tarih") = TextBox1.Text
                Label1.Text = sinirkapitakvim_erisim.listele()
            End If

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim sinirkapitakvim_erisim As New CLASSSINIRKAPITAKVIM_ERISIM
        result = sinirkapitakvim_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("sinirkapitakvim.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        TextBox1.Enabled = True
        'TextBox2.Enabled = True
        'DropDownList1.Enabled = True
        'DropDownList2.Enabled = True
        'DropDownList3.Enabled = True
        'DropDownListbaslangicsaat.Enabled = True
        'DropDownListbaslangicdakika.Enabled = True
        'DropDownListbitissaat.Enabled = True
        'DropDownListbitisdakika.Enabled = True

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim hata, hatamesajlari As String
        hata = "0"

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim tarih As Date

        Try
            tarih = TextBox3.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Tarihi doğru girmediniz.</li>"
            TextBox3.Focus()
        End Try


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        If hata = "0" Then
            HttpContext.Current.Session("ltip") = "tarih"
            HttpContext.Current.Session("tarih") = TextBox3.Text
            Label1.Text = sinirkapitakvim_erisim.listele()
        End If



    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = sinirkapitakvim_erisim.listele()
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click

        HttpContext.Current.Session("sirketpkey") = DropDownList6.SelectedValue
        HttpContext.Current.Session("ltip") = "gerceksirket"
        Label1.Text = sinirkapitakvim_erisim.listele()


    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click


        HttpContext.Current.Session("sirketpkey") = DropDownList7.SelectedValue
        HttpContext.Current.Session("ltip") = "gorevlisirket"
        Label1.Text = sinirkapitakvim_erisim.listele()

    End Sub
End Class