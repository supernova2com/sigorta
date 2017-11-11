Public Partial Class acentegirispopup
    Inherits System.Web.UI.Page

    Dim acente As New CLASSACENTE
    Dim acente_erisim As New CLASSACENTE_ERISIM
    Dim result As New CLADBOPRESULT
    Dim sirket_erisim As New CLASSSIRKET_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    'yetkiler icin 
    Dim tabload As String = "acente"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirket", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Dim op As String
            op = Request.QueryString("op")
            TextBox1.Focus()

            'ACENTE TİPLERİ DOLDUR---------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim acentetip_erisim As New CLASSACENTETIP_ERISIM
            Dim acentetipler As New List(Of CLASSACENTETIP)
            acentetipler = acentetip_erisim.doldur()
            For Each item As CLASSACENTETIP In acentetipler
                DropDownList2.Items.Add(New ListItem(item.acentetipad, CStr(item.pkey)))
            Next

            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList1.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList1.Items.Add(New ListItem("Hayır", "Hayır"))


            If Request.QueryString("op") = "yenikayit" Then
                Button2.Visible = False
                Labelsirket.Text = sirket_erisim.sirketsecmeinputolustur("0", "yenikayit")
            End If

            If Request.QueryString("op") = "duzenle" Then

                Button2.Visible = True
                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                acente = acente_erisim.bultek(Request.QueryString("pkey"))

                Labelsirket.Text = sirket_erisim.sirketsecmeinputolustur(CStr(Request.QueryString("pkey")), "duzenle")

                TextBox1.Text = acente.acentead
                TextBox2.Text = acente.sicilno

                If acente.aktifmi = "Evet" Then
                    CheckBox1.Checked = True
                End If
                If acente.aktifmi = "Hayır" Then
                    CheckBox1.Checked = False
                End If

                DropDownList1.SelectedValue = acente.merkezmi
                TextBox3.Text = acente.yetkiadsoyad
                TextBox4.Text = acente.yetkikimlikno
                TextBox5.Text = acente.yetkiceptel
                TextBox6.Text = acente.yetkiemail
                TextBox7.Text = acente.tel
                TextBox8.Text = acente.fax
                DropDownList2.SelectedValue = acente.acentetippkey

            End If

        End If 'postback 

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
        'yetki kontrol--------------------------------------------------------------------------

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'acente ad
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Acente adını girmediniz.</li>"
            inn.Value = "0"
        End If

        'sicilno
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Acente sicil numarasını girmediniz.</li>"
            inn.Value = "0"
        End If

        'merkez mi 
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Acentenin merkez olup olmadığını girmediniz.</li>"
            inn.Value = "0"
        End If

        'acente tip
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Acentenin tipini seçmediniz.</li>"
            inn.Value = "0"
        End If

        'yeyki ad soyad
        If TextBox3.Text = "" Then
            'TextBox3.Focus()
            'hata = "1"
            'hatamesajlari = hatamesajlari + "<li>Acente yetkilisinin adı soyadını girmediniz.</li>"
            'inn.Value = "0"
        End If

        'kimlik
        If TextBox4.Text = "" Then
            'TextBox4.Focus()
            'hata = "1"
            'hatamesajlari = hatamesajlari + "<li>Acente yetkilisinin kimlik numarasını girmediniz.</li>"
            'inn.Value = "0"
        End If

        'ceptel
        If Len(TextBox5.Text) <> 10 Then
            'TextBox5.Focus()
            'hata = "1"
            'hatamesajlari = hatamesajlari + "<li>Acente yetkilisinin cep telefonunu 10 rakamdan oluşmalıdır.</li>"
            'inn.Value = "0"
        End If

        'eposta kontrol et
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            'hata = "1"
            'TextBox3.Focus()
            'hatamesajlari = hatamesajlari + "<li>Acente yetkilisinin E-Mail adresini doğru giriniz.</li>"
        End If

        'telefon
        If TextBox7.Text <> "" Then
            If Len(TextBox7.Text) <> 11 Then
                TextBox7.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Acente yetkilisinin sabit telefon numarası" + _
                " 11 rakamdan oluşmalı ve 0392 ile başlamalıdır.</li>"
                inn.Value = "0"
            End If
        End If

        'fax
        If TextBox8.Text <> "" Then
            If Len(TextBox8.Text) <> 11 Then
                TextBox8.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Acente yetkilisinin fax numarası " + _
                "11 rakamdan oluşmalı ve 0392 ile başlamalıdır.</li>"
                inn.Value = "0"
            End If
        End If

        'şirket seçmiş mi ?
        If sirketacentebagkac_adetisaretledi() = 0 Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Acentenin bağlı olduğu şirketi seçmediniz.</li>"
            inn.Value = "0"
        End If

        'eğer merkez ise sadece bir şirket işaretleyebilir kontrolu 
        If hata = "0" Then
            'merkez ise
            If DropDownList1.SelectedValue = "Evet" Then
                Dim kactaneisaretledi As Integer
                kactaneisaretledi = sirketacentebagkac_adetisaretledi()
                If kactaneisaretledi > 1 Then
                    hata = "1"
                    hatamesajlari = hatamesajlari + "<li>Merkez acente sadece tek bir şirkette çalışabilir. Çünkü merkez " + _
                    "acente halihazırda şirkettir</li>"
                    inn.Value = "0"
                End If
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            hatamesajlari = ""

            acente.acentead = TextBox1.Text
            acente.sicilno = TextBox2.Text

            If CheckBox1.Checked = True Then
                acente.aktifmi = "Evet"
            End If
            If CheckBox1.Checked = False Then
                acente.aktifmi = "Hayır"
            End If

            acente.merkezmi = DropDownList1.SelectedValue
            acente.yetkiadsoyad = TextBox3.Text
            acente.yetkikimlikno = TextBox4.Text
            acente.yetkiceptel = TextBox5.Text
            acente.yetkiemail = TextBox6.Text
            acente.tel = TextBox7.Text
            acente.fax = TextBox8.Text
            acente.ekleyenkullanicipkey = Session("kullanici_pkey")
            acente.eklenmetarih = DateTime.Now
            acente.acentetippkey = DropDownList2.SelectedValue


            If Request.QueryString("op") = "yenikayit" Then
                result = acente_erisim.Ekle(acente)

                'sirketacentebag kaydet.
                If result.durum = "Kaydedildi" Then
                    sirketacentebagkaydet(result.etkilenen)
                    Labelsirket.Text = sirket_erisim.sirketsecmeinputolustur(CStr(result.etkilenen), "duzenle")
                End If

            End If

            If Request.QueryString("op") = "duzenle" Then
                acente = acente_erisim.bultek(Request.QueryString("pkey"))

                acente.acentead = TextBox1.Text
                acente.sicilno = TextBox2.Text

                If CheckBox1.Checked = True Then
                    acente.aktifmi = "Evet"
                End If
                If CheckBox1.Checked = False Then
                    acente.aktifmi = "Hayır"
                End If

                acente.merkezmi = DropDownList1.SelectedValue
                acente.yetkiadsoyad = TextBox3.Text
                acente.yetkikimlikno = TextBox4.Text
                acente.yetkiceptel = TextBox5.Text
                acente.yetkiemail = TextBox6.Text
                acente.tel = TextBox7.Text
                acente.fax = TextBox8.Text
                acente.guncelleyenkullanicipkey = Session("kullanici_pkey")
                acente.guncellenmetarih = DateTime.Now
                acente.acentetippkey = DropDownList2.SelectedValue

                result = acente_erisim.Duzenle(acente)

                'sirketacentebag kaydet.
                If result.durum = "Kaydedildi" Then
                    sirketacentebagkaydet(acente.pkey)
                    Labelsirket.Text = sirket_erisim.sirketsecmeinputolustur(CStr(acente.pkey), "duzenle")
                End If

            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If


            'Label1.Text = acente_erisim.listele("")
        End If

    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
            Dim acente_erisim As New CLASSACENTE_ERISIM

            sirketacentebag_erisim.silacentenincalistigitumsirketler(Request.QueryString("pkey"))
            result = acente_erisim.Sil(Request.QueryString("pkey"))
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


    Public Function sirketacentebagkaydet(ByVal acentepkey As Integer)

        Dim sirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim value As String
        Dim id_o As String

        Dim tumsirketler As New List(Of CLASSSIRKET)
        tumsirketler = sirket_erisim.doldur

        'önce bu acentenin çalıştığı tüm sirketleri sil
        sirketacentebag_erisim.silacentenincalistigitumsirketler(acentepkey)

        For Each itemsirket As CLASSSIRKET In tumsirketler
            id_o = "A_" + CStr(itemsirket.pkey)
            value = Request.Form(id_o)
            If Not value Is Nothing Then
                sirketacentebag.sirketpkey = itemsirket.pkey
                sirketacentebag.acentepkey = acentepkey
                sirketacentebag_erisim.Ekle(sirketacentebag)
            End If
        Next

    End Function


    Public Function sirketacentebagkac_adetisaretledi() As Integer

        Dim sirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim value As String
        Dim id_o As String
        Dim count As Integer = 0

        Dim tumsirketler As New List(Of CLASSSIRKET)
        tumsirketler = sirket_erisim.doldur

        For Each itemsirket As CLASSSIRKET In tumsirketler
            id_o = "A_" + CStr(itemsirket.pkey)
            value = Request.Form(id_o)
            If Not value Is Nothing Then
                count = count + 1
            End If
        Next

        Return count

    End Function

End Class