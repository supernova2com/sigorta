Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class personelgirispopup
    Inherits System.Web.UI.Page


    Dim personel As New CLASSPERSONEL
    Dim personel_erisim As New CLASSPERSONEL_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "personel"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("personel", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then


            DropDownList1.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList1.Items.Add(New ListItem("Hayır", "Hayır"))

            DropDownList2.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList2.Items.Add(New ListItem("Hayır", "Hayır"))

            DropDownList3.Items.Add(New ListItem("Lefkoşa", "Lefkoşa"))
            DropDownList3.Items.Add(New ListItem("Gazimağusa", "Gazimağusa"))
            DropDownList3.Items.Add(New ListItem("Girne", "Girne"))
            DropDownList3.Items.Add(New ListItem("Güzelyurt", "Güzelyurt"))
            DropDownList3.Items.Add(New ListItem("Lefke", "Lefke"))

            DropDownList4.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList4.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList4.Items.Add(New ListItem("Hayır", "Hayır"))



            If Request.QueryString("op") = "yenikayit" Then
                Button2.Visible = False
            End If

            If Request.QueryString("op") = "duzenle" Then

                Button2.Visible = True
                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                personel = personel_erisim.bultek(Request.QueryString("pkey"))
                TextBox2.Text = personel.personeladsoyad
                TextBox1.Text = personel.kimlikno
                DropDownList1.SelectedValue = personel.teknikpersonelmi
                TextBox3.Text = personel.tpno
                TextBox5.Text = personel.ceptel
                TextBox4.Text = personel.adres
                DropDownList3.SelectedValue = personel.bolge
                DropDownList4.SelectedValue = personel.egitimekatildimi
                TextBox6.Text = personel.egitimno
                DropDownList2.SelectedValue = personel.onaylanmismi

                If personel.verildigitarih Is Nothing Then
                    personel.verildigitarih = "00:00:00"
                End If
                TextBox7.Text = personel.verildigitarih

                If personel.belgetarih Is Nothing Then
                    personel.belgetarih = "00:00:00"
                End If
                TextBox8.Text = personel.belgetarih
                TextBox9.Text = personel.epostap

            End If

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        If yetki.deleteyetki = "Hayır" Then
            Button2.Visible = False
        End If
        If yetki.deleteyetki = "Evet" And opy = "duzenle" Then
            Button2.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM

        durumlabel.Text = ""
        Dim hatamesajlari As String
        Dim verildigitarih, belgetarih As Date

        hata = "0"


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, kayittarih As Date


        'personel ad soyad
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Personel adını soyadını girmediniz.</li>"
            inn.Value = "0"
        End If


        'kimlik numarası
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Personel kimlik kartı numarasını girmediniz.</li>"
            inn.Value = "0"
        End If

        'eğer teknik personel ise
        If DropDownList1.SelectedValue = "Evet" Then
            'teknik personel no kontrol et
            If TextBox3.Text = "" Then
                TextBox3.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>TP numarasını girmediniz.</li>"
                inn.Value = "0"
            End If
        End If

        'egitime katılmıs mı 
        If DropDownList4.SelectedValue = "0" Then
            DropDownList4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Eğitime katılıp katılmadığını seçmediniz.</li>"
            inn.Value = "0"
        End If



        'verildigi tarih kontrol et
        If TextBox7.Text <> "" Then
            Try
                verildigitarih = TextBox7.Text
            Catch
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Verildiği tarihi doğru girmediniz.</li>"
                TextBox7.Focus()
                inn.Value = "0"
            End Try
        End If

        'belge tarih kontrol et
        If TextBox8.Text <> "" Then
            Try
                belgetarih = TextBox8.Text
            Catch
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Belge tarihi doğru girmediniz.</li>"
                TextBox8.Focus()
                inn.Value = "0"
            End Try
        End If


        'eposta kontrol et
        If TextBox9.Text <> "" Then
            If System.Text.RegularExpressions.Regex.IsMatch(TextBox9.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
                hata = "1"
                TextBox9.Focus()
                hatamesajlari = hatamesajlari + "<li>Kullanıcı E-Mail adresini doğru giriniz.</li>"
            End If
        End If


        If TextBox5.Text = "" Then
            TextBox5.Text = "-"
        End If

        'mantıksal kontrol 
        If DropDownList4.SelectedValue = "Evet" And (TextBox6.Text = "" Or TextBox7.Text = "") Then
            TextBox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Eğitim numarasını veya verildiği tarihi girmediniz.</li>"
            inn.Value = "0"
        End If

        If DropDownList4.SelectedValue = "Hayır" And (TextBox6.Text <> "" Or TextBox7.Text <> "") Then
            TextBox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Eğitime katılmayan bir personelin " + _
            "eğitim katılım numarası yada eğitim verildiği tarih olamaz.</li>"
            inn.Value = "0"
        End If

        If TextBox7.Text = "" Or TextBox7.Text = "00.." Then
            TextBox7.Text = "00:00:00"
        End If

        If TextBox8.Text = "" Or TextBox8.Text = "00.." Then
            TextBox8.Text = "00:00:00"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            hatamesajlari = ""

            If Request.QueryString("op") = "yenikayit" Then

                personel.personeladsoyad = TextBox2.Text
                personel.kimlikno = TextBox1.Text
                personel.teknikpersonelmi = DropDownList1.SelectedValue
                personel.tpno = TextBox3.Text
                personel.ceptel = TextBox5.Text
                personel.adres = TextBox4.Text
                personel.bolge = DropDownList3.SelectedValue
                personel.egitimekatildimi = DropDownList4.SelectedValue
                personel.egitimno = TextBox6.Text
                personel.onaylanmismi = DropDownList2.SelectedValue
                personel.verildigitarih = TextBox7.Text
                personel.belgetarih = TextBox8.Text
                personel.islemkullanicipkey = Session("kullanici_pkey")
                personel.epostap = TextBox9.Text

                result = personel_erisim.Ekle(personel)

            End If

            If Request.QueryString("op") = "duzenle" Then

                personel = personel_erisim.bultek(Request.QueryString("pkey"))
                personel.personeladsoyad = TextBox2.Text
                personel.kimlikno = TextBox1.Text
                personel.teknikpersonelmi = DropDownList1.SelectedValue
                personel.tpno = TextBox3.Text
                personel.ceptel = TextBox5.Text
                personel.adres = TextBox4.Text
                personel.bolge = DropDownList3.SelectedValue
                personel.egitimekatildimi = DropDownList4.SelectedValue
                personel.egitimno = TextBox6.Text
                personel.onaylanmismi = DropDownList2.SelectedValue
                personel.verildigitarih = TextBox7.Text
                personel.belgetarih = TextBox8.Text
                personel.islemkullanicipkey = Session("kullanici_pkey")
                personel.epostap = TextBox9.Text

                result = personel_erisim.Duzenle(personel)

            End If


            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If


        End If

    End Sub



    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click


        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim personel_erisim As New CLASSPERSONEL_ERISIM

            result = personel_erisim.Sil(Request.QueryString("pkey"))
            durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"

            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If


    End Sub
End Class