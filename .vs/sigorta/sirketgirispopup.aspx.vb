Imports System.Net

Partial Public Class sirketgirispopup
    Inherits System.Web.UI.Page


    Dim sirket As New CLASSSIRKET
    Dim sirket_erisim As New CLASSSIRKET_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
    Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
    Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM


    'yetkiler icin 
    Dim tabload As String = "sirket"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim op As String
        op = Request.QueryString("op")

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirket", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            'acente iptal---------------------------------
            If Request.QueryString("hangiiptal") = "2" Then
                Buttonacenteiptal.Visible = False
                inn.Value = "2"
            End If
            'ip iptal--------------------------------------
            If Request.QueryString("hangiiptal") = "3" Then
                Buttonsirketipbagiptal.Visible = False
                inn.Value = "3"
            End If
            'fatura e-posta iptal--------------------------
            If Request.QueryString("hangiiptal") = "4" Then
                Buttonsirketfaturabagiptal.Visible = False
                inn.Value = "4"
            End If



            DropDownList3.Items.Add(New ListItem("ŞİRKET", "ŞİRKET"))
            DropDownList3.Items.Add(New ListItem("KKSBM", "KKSBM"))
            DropDownList3.Items.Add(New ListItem("POLİS", "POLİS"))
            DropDownList3.Items.Add(New ListItem("SUPERNOVA", "SUPERNOVA"))
            DropDownList3.Items.Add(New ListItem("DİĞER", "DİĞER"))

            TextBox2.Focus()

            'ACENTELERİ DOLDUR---------------------------------------
            Dim acente_erisim As New CLASSACENTE_ERISIM
            Dim acenteler As New List(Of CLASSACENTE)
            acenteler = acente_erisim.doldur()
            For Each item As CLASSACENTE In acenteler
                DropDownList2.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
            Next


            ' RESİMLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
            Dim tekresimler As New List(Of CLASSTEKRESIM)
            tekresimler = tekresim_erisim.doldur()
            For Each item As CLASSTEKRESIM In tekresimler
                DropDownList1.Items.Add(New ListItem(item.baslik, CStr(item.pkey)))
            Next

            'CIDRNOTATION DOLDUR ---------------------------------
            DropDownList4.Items.Add(New ListItem("32", "32"))
            DropDownList4.Items.Add(New ListItem("24", "24"))
            DropDownList4.Items.Add(New ListItem("16", "16"))
            DropDownList4.Items.Add(New ListItem("8", "8"))



            'ACENTELERİ DUZENLE
            Dim sirketacentebagop As String
            sirketacentebagop = Request.QueryString("sirketacentebagop")
            If sirketacentebagop = "duzenle" Then
                Buttonacenteiptal.Visible = True
                inn.Value = "2"
                Buttonacenteekle.Text = "Güncelle"
                Dim sirketacentebag As New CLASSSIRKETACENTEBAG
                Dim sirketacentebagpkey As String
                sirketacentebagpkey = Request.QueryString("sirketacentebagpkey")
                sirketacentebag = sirketacentebag_erisim.bultek(sirketacentebagpkey)
                DropDownList2.SelectedValue = sirketacentebag.acentepkey
            Else
                Buttonacenteekle.Text = "Ekle"
            End If
            'IP DUZENLE
            Dim sirketipbagop As String
            sirketipbagop = Request.QueryString("sirketipbagop")
            If sirketipbagop = "duzenle" Then
                Buttonipeklebutton.Visible = True
                inn.Value = "3"
                Buttonipeklebutton.Text = "Güncelle"
                Dim sirketipbag As New CLASSSIRKETIPBAG
                Dim sirketipbagpkey As String
                sirketipbagpkey = Request.QueryString("sirketipbagpkey")
                sirketipbag = sirketipbag_erisim.bultek(sirketipbagpkey)
                DropDownList4.SelectedValue = sirketipbag.cidrnotation
                TextBox11.Text = sirketipbag.ipadres
            Else
                Buttonipeklebutton.Text = "Ekle"
            End If
            '--------------------------------------------------------------------------------
            'ŞİRKET FATURA E-POSTA DÜZENLE
            Dim sirketfaturabagop As String
            sirketfaturabagop = Request.QueryString("sirketfaturabagop")
            If sirketfaturabagop = "duzenle" Then
                Buttonsirketfaturabagiptal.Visible = True
                inn.Value = "4"
                Buttonsirketfaturabagekle.Text = "Güncelle"
                Dim sirketfaturabag As New CLASSSIRKETFATURABAG
                Dim sirketfaturabagpkey As String
                sirketfaturabagpkey = Request.QueryString("sirketfaturabagpkey")
                sirketfaturabag = sirketfaturabag_erisim.bultek(sirketfaturabagpkey)
                TextBox12.Text = sirketfaturabag.eposta
            Else
                Buttonsirketfaturabagekle.Text = "Ekle"
            End If
            '--------------------------------------------------------------------------------


            If op = "yenikayit" Then
                Button2.Visible = False
                TextBox1.Text = sirket_erisim.sirketkodubul()
            End If


            If op = "duzenle" Then

                Button2.Visible = True

                'sirket logosunu göster
                Labellogo.Text = sirket_erisim.logoolustur(Request.QueryString("pkey"))

                'acentelerini göster... 
                Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
                Labelacenteleri.Text = sirketacentebag_erisim.listele("sirket", Request.QueryString("pkey"))
                'ip adreslerini göster
                Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
                Labelipadresleri.Text = sirketipbag_erisim.listele("sirket", Request.QueryString("pkey"))

                Dim personel_erisim As New CLASSPERSONEL_ERISIM

                Labelpersoneli.Text = _
                personel_erisim.sirketinpersonellerinilistele(Request.QueryString("pkey"))

                Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM
                Labelfaturaepostaadresleri.Text = _
                sirketfaturabag_erisim.listele("sirket", Request.QueryString("pkey"))


                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                sirket = sirket_erisim.bultek(Request.QueryString("pkey"))

                'sirket logosunu göster
                Labellogo.Text = sirket_erisim.logoolustur(sirket.resimpkey)

                TextBox1.Text = sirket.sirketkod
                TextBox2.Text = sirket.sirketad
                TextBox3.Text = sirket.yetkilikisiadsoyad
                TextBox10.Text = sirket.adres
                TextBox4.Text = sirket.ofistelefon
                TextBox5.Text = sirket.faks
                TextBox6.Text = sirket.eposta

                If sirket.aktifmi = "Evet" Then
                    CheckBox1.Checked = True
                End If
                If sirket.aktifmi = "Hayır" Then
                    CheckBox1.Checked = False
                End If

                DropDownList1.SelectedValue = sirket.resimpkey

                If sirket.testerisim = "Evet" Then
                    CheckBox3.Checked = True
                End If
                If sirket.testerisim = "Hayır" Then
                    CheckBox3.Checked = False
                End If

                If sirket.topluyukleme = "Evet" Then
                    CheckBox2.Checked = True
                End If
                If sirket.topluyukleme = "Hayır" Then
                    CheckBox2.Checked = False
                End If

                TextBox7.Text = sirket.wskullaniciad
                TextBox8.Text = sirket.wssifre
                TextBox9.Text = sirket.wssifre

                TextBox8.Attributes("value") = sirket.wssifre
                TextBox9.Attributes("value") = sirket.wssifre

                If sirket.ipdikkat = "Evet" Then
                    CheckBox4.Checked = True
                End If
                If sirket.ipdikkat = "Hayır" Then
                    CheckBox4.Checked = False
                End If


                DropDownList3.SelectedValue = sirket.tip

                If sirket.GetCarAddressInfo_yetki = "Evet" Then
                    CheckBox10.Checked = True
                End If
                If sirket.GetCarAddressInfo_yetki = "Hayır" Then
                    CheckBox10.Checked = False
                End If

                If sirket.GetDamageInformation_yetki = "Evet" Then
                    CheckBox11.Checked = True
                End If
                If sirket.GetDamageInformation_yetki = "Hayır" Then
                    CheckBox11.Checked = False
                End If

                If sirket.GetInfoInsuredPeople_yetki = "Evet" Then
                    CheckBox12.Checked = True
                End If
                If sirket.GetInfoInsuredPeople_yetki = "Hayır" Then
                    CheckBox12.Checked = False
                End If

                If sirket.LoadDamageInformation_yetki = "Evet" Then
                    CheckBox13.Checked = True
                End If
                If sirket.LoadDamageInformation_yetki = "Hayır" Then
                    CheckBox13.Checked = False
                End If

                If sirket.LoadPolicyInformation_yetki = "Evet" Then
                    CheckBox14.Checked = True
                End If
                If sirket.LoadPolicyInformation_yetki = "Hayır" Then
                    CheckBox14.Checked = False
                End If

                TextBox13.Text = sirket.maksservistalepdakika


            End If 'op=duzenle

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
        Else
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

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim ekmesaj As String = ""

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'sirket kodu
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirket kodunu girmediniz.</li>"
            inn.Value = "0"
        End If

        'sirket ad
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirket adını girmediniz.</li>"
            inn.Value = "0"
        End If

        'sirket yetkilikişi
        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirket yetkili kişi adını girmediniz.</li>"
            inn.Value = "0"
        End If

        'sirket adres
        If TextBox10.Text = "" Then
            TextBox10.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şriket adresini girmediniz.</li>"
            inn.Value = "0"
        End If

        'sirket ofis telefon
        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şriket ofis telefonunu girmediniz.</li>"
            inn.Value = "0"
        End If

        'sirket eposta adresi
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            TextBox6.Focus()
            hatamesajlari = hatamesajlari + "<li>Şirket E-Posta adresini doğru giriniz.</li>"
        End If

        'sirket resim
        If DropDownList1.SelectedValue = "0" Then
            hata = "1"
            DropDownList1.Focus()
            hatamesajlari = hatamesajlari + "<li>Şirket logosunu seçmediniz.</li>"
            inn.Value = "5"
        End If

        'ws kullanıcı adı
        If TextBox7.Text = "" Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirket web servis kullanıcı adını girmediniz.</li>"
            inn.Value = "1"
        End If

        'ws sifre
        If Len(TextBox8.Text) < 1 Then
            TextBox8.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirket web servis şifresi en az 1 karakter olmalıdır.</li>"
            inn.Value = "1"
        End If

        'sifre kontrol
        If TextBox8.Text <> TextBox9.Text Then
            TextBox9.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Girdiğiniz web servis şifreleri birbiriyle uyuşmuyor.</li>"
            inn.Value = "1"
        End If

        'maks servis talebi
        If IsNumeric(TextBox13.Text) = False Then
            TextBox13.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Maksimum servis talebi rakamsal olmalıdır.</li>"
            inn.Value = "1"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            hatamesajlari = ""

            sirket.sirketkod = TextBox1.Text
            sirket.sirketad = TextBox2.Text
            sirket.yetkilikisiadsoyad = TextBox3.Text
            sirket.adres = TextBox10.Text
            sirket.ofistelefon = TextBox4.Text
            sirket.faks = TextBox5.Text
            sirket.eposta = TextBox6.Text

            If CheckBox1.Checked = True Then
                sirket.aktifmi = "Evet"
            End If
            If CheckBox1.Checked = False Then
                sirket.aktifmi = "Hayır"
            End If

            sirket.resimpkey = DropDownList1.SelectedValue

            If CheckBox3.Checked = True Then
                sirket.testerisim = "Evet"
            End If
            If CheckBox3.Checked = False Then
                sirket.testerisim = "Hayır"
            End If

            If CheckBox2.Checked = True Then
                sirket.topluyukleme = "Evet"
            End If
            If CheckBox2.Checked = False Then
                sirket.topluyukleme = "Hayır"
            End If

            sirket.wskullaniciad = TextBox7.Text
            sirket.wssifre = TextBox8.Text

            If CheckBox4.Checked = True Then
                sirket.ipdikkat = "Evet"
            End If
            If CheckBox4.Checked = False Then
                sirket.ipdikkat = "Hayır"
            End If

            sirket.tip = DropDownList3.SelectedValue


            If CheckBox10.Checked = True Then
                sirket.GetCarAddressInfo_yetki = "Evet"
            End If
            If CheckBox10.Checked = False Then
                sirket.GetCarAddressInfo_yetki = "Hayır"
            End If

            If CheckBox11.Checked = True Then
                sirket.GetDamageInformation_yetki = "Evet"
            End If
            If CheckBox11.Checked = False Then
                sirket.GetDamageInformation_yetki = "Hayır"
            End If

            If CheckBox12.Checked = True Then
                sirket.GetInfoInsuredPeople_yetki = "Evet"
            End If
            If CheckBox12.Checked = False Then
                sirket.GetInfoInsuredPeople_yetki = "Hayır"
            End If

            If CheckBox13.Checked = True Then
                sirket.LoadDamageInformation_yetki = "Evet"
            End If
            If CheckBox13.Checked = False Then
                sirket.LoadDamageInformation_yetki = "Hayır"
            End If

            If CheckBox14.Checked = True Then
                sirket.LoadPolicyInformation_yetki = "Evet"
            End If
            If CheckBox14.Checked = False Then
                sirket.LoadPolicyInformation_yetki = "Hayır"
            End If

            sirket.maksservistalepdakika = TextBox13.Text


            If Request.QueryString("op") = "yenikayit" Then
                result = sirket_erisim.Ekle(sirket)
                If result.durum = "Kaydedildi" Then
                    Dim duzenlemelink As String
                    duzenlemelink = "sirketgirispopup.aspx?pkey=" + CStr(result.etkilenen) + "&op=duzenle"
                    Response.Redirect(duzenlemelink)
                End If
            End If

            If Request.QueryString("op") = "duzenle" Then
                sirket = sirket_erisim.bultek(Request.QueryString("pkey"))

                sirket.sirketkod = TextBox1.Text
                sirket.sirketad = TextBox2.Text
                sirket.yetkilikisiadsoyad = TextBox3.Text
                sirket.adres = TextBox10.Text
                sirket.ofistelefon = TextBox4.Text
                sirket.faks = TextBox5.Text
                sirket.eposta = TextBox6.Text

                If CheckBox1.Checked = True Then
                    sirket.aktifmi = "Evet"
                End If
                If CheckBox1.Checked = False Then
                    sirket.aktifmi = "Hayır"
                End If

                sirket.resimpkey = DropDownList1.SelectedValue

                If CheckBox3.Checked = True Then
                    sirket.testerisim = "Evet"
                End If
                If CheckBox3.Checked = False Then
                    sirket.testerisim = "Hayır"
                End If

                If CheckBox2.Checked = True Then
                    sirket.topluyukleme = "Evet"
                End If
                If CheckBox2.Checked = False Then
                    sirket.topluyukleme = "Hayır"
                End If

                sirket.wskullaniciad = TextBox7.Text
                sirket.wssifre = TextBox8.Text

                If CheckBox4.Checked = True Then
                    sirket.ipdikkat = "Evet"
                End If
                If CheckBox4.Checked = False Then
                    sirket.ipdikkat = "Hayır"
                End If

                sirket.tip = DropDownList3.SelectedValue

                If CheckBox10.Checked = True Then
                    sirket.GetCarAddressInfo_yetki = "Evet"
                End If
                If CheckBox10.Checked = False Then
                    sirket.GetCarAddressInfo_yetki = "Hayır"
                End If

                If CheckBox11.Checked = True Then
                    sirket.GetDamageInformation_yetki = "Evet"
                End If
                If CheckBox11.Checked = False Then
                    sirket.GetDamageInformation_yetki = "Hayır"
                End If

                If CheckBox12.Checked = True Then
                    sirket.GetInfoInsuredPeople_yetki = "Evet"
                End If
                If CheckBox12.Checked = False Then
                    sirket.GetInfoInsuredPeople_yetki = "Hayır"
                End If

                If CheckBox13.Checked = True Then
                    sirket.LoadDamageInformation_yetki = "Evet"
                End If
                If CheckBox13.Checked = False Then
                    sirket.LoadDamageInformation_yetki = "Hayır"
                End If

                If CheckBox14.Checked = True Then
                    sirket.LoadPolicyInformation_yetki = "Evet"
                End If
                If CheckBox14.Checked = False Then
                    sirket.LoadPolicyInformation_yetki = "Hayır"
                End If

                sirket.maksservistalepdakika = TextBox13.Text

                result = sirket_erisim.Duzenle(sirket)
                Labellogo.Text = sirket_erisim.logoolustur(Request.QueryString("pkey"))

                'şirketin altındaki tüm acenteleri pasif yap
                If sirket.aktifmi = "Hayır" Then

                    Dim result As New CLADBOPRESULT
                    Dim acente_erisim As New CLASSACENTE_ERISIM
                    Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
                    Dim busirketinaltindakiacenteler As New List(Of CLASSACENTE)
                    busirketinaltindakiacenteler = sirketacentebag_erisim.doldursirketinacenteleri_acentetipinde(sirket.pkey)

                    For Each acenteitem As CLASSACENTE In busirketinaltindakiacenteler
                        acenteitem.aktifmi = "Hayır"
                        result = acente_erisim.Duzenle(acenteitem)
                        If result.durum = "Kaydedildi" Then
                            ekmesaj = ekmesaj + acenteitem.acentead + " isimli acente pasif hale getirildi.<br/>"
                        End If
                    Next

                End If

            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/>" + _
                ekmesaj + "</p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            'Label1.Text = sirket_erisim.listele("")
        End If

    End Sub



    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim sirket_erisim As New CLASSSIRKET_ERISIM

            result = sirket_erisim.Sil(Request.QueryString("pkey"))

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


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        inn.Value = "1"
        If TextBox7.Text <> "" Then
            Label1.Text = TextBox7.Text
        End If

    End Sub

    'ACENTE EKLEME GÜNCELLEME
    Protected Sub Buttonacenteekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonacenteekle.Click

        Dim sirketacentebagop As String
        sirketacentebagop = Request.QueryString("sirketacentebagop")


        Dim result As New CLADBOPRESULT
        Dim personel_erisim As New CLASSPERSONEL_ERISIM

        Dim sirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM

        If sirketacentebagop <> "duzenle" Then
            sirketacentebag.sirketpkey = Request.QueryString("pkey")
            sirketacentebag.acentepkey = DropDownList2.SelectedValue
            result = sirketacentebag_erisim.Ekle(sirketacentebag)
        End If
        If sirketacentebagop = "duzenle" Then
            Dim sirketacentebagpkey As String
            sirketacentebagpkey = Request.QueryString("sirketacentebagpkey")
            sirketacentebag = sirketacentebag_erisim.bultek(sirketacentebagpkey)
            sirketacentebag.acentepkey = DropDownList2.SelectedValue
            result = sirketacentebag_erisim.Duzenle(sirketacentebag)
        End If

        inn.Value = "2"

        If result.durum = "Kaydedildi" Then
            Labelacenteresult.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
        Else
            Labelacenteresult.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
            result.hatastr + "</li></ol></div>"
        End If

        Labelacenteleri.Text = sirketacentebag_erisim.listele("sirket", Request.QueryString("pkey"))
        Labelpersoneli.Text = personel_erisim.sirketinpersonellerinilistele(Request.QueryString("pkey"))


    End Sub

    'IP EKLEME GUNCELLEME
    Protected Sub Buttonipeklebutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonipeklebutton.Click

        Dim sirketipbagop As String
        sirketipbagop = Request.QueryString("sirketipbagop")

        Dim result As New CLADBOPRESULT
        Dim sirketipbag As New CLASSSIRKETIPBAG
        Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'ip adresi
        If TextBox11.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>IP adresini girmediniz.</li>"
            inn.Value = "3"
        End If


        If TextBox11.Text <> "" Then
            Try
                Dim ipaddress As IPAddress
                ipaddress.Parse(TextBox11.Text)
            Catch ex As Exception
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Girdiğiniz ip adresi doğru değildir.</li>"
                inn.Value = "3"
            End Try
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then


            If sirketipbagop <> "duzenle" Then
                sirketipbag.sirketpkey = Request.QueryString("pkey")
                sirketipbag.ipadres = TextBox11.Text
                sirketipbag.cidrnotation = DropDownList4.SelectedValue
                result = sirketipbag_erisim.Ekle(sirketipbag)
                inn.Value = "3"
            End If

            If sirketipbagop = "duzenle" Then
                Dim sirketipbagpkey As String
                sirketipbagpkey = Request.QueryString("sirketipbagpkey")
                sirketipbag = sirketipbag_erisim.bultek(sirketipbagpkey)
                sirketipbag.cidrnotation = DropDownList4.SelectedValue
                sirketipbag.ipadres = TextBox11.Text
                result = sirketipbag_erisim.Duzenle(sirketipbag)
                inn.Value = "3"
            End If


            If result.durum = "Kaydedildi" Then
                Labelipresult.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                Labelipresult.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            End If

            Labelipadresleri.Text = sirketipbag_erisim.listele("sirket", Request.QueryString("pkey"))

        End If

    End Sub


    Protected Sub Buttonsirketfaturabagekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonsirketfaturabagekle.Click

        Dim sirketfaturabagop As String
        sirketfaturabagop = Request.QueryString("sirketfaturabagop")

        Dim result As New CLADBOPRESULT
        Dim sirketfaturabag As New CLASSSIRKETFATURABAG
        Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM
        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'fatura eposta adresi
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox12.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            TextBox12.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>E-Posta adresini düzgün girmediniz.</li>"
            inn.Value = "4"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            If sirketfaturabagop <> "duzenle" Then
                sirketfaturabag.sirketpkey = Request.QueryString("pkey")
                sirketfaturabag.eposta = TextBox12.Text
                result = sirketfaturabag_erisim.Ekle(sirketfaturabag)
                inn.Value = "4"
            End If
            If sirketfaturabagop = "duzenle" Then
                Dim sirketfaturabagpkey As String
                sirketfaturabagpkey = Request.QueryString("sirketfaturabagpkey")
                sirketfaturabag = sirketfaturabag_erisim.bultek(sirketfaturabagpkey)
                sirketfaturabag.eposta = TextBox12.Text
                result = sirketfaturabag_erisim.Duzenle(sirketfaturabag)
            End If


            If result.durum = "Kaydedildi" Then
                Labelfaturaepostaresult.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                Labelfaturaepostaresult.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            End If
            Labelfaturaepostaadresleri.Text = sirketfaturabag_erisim.listele("sirket", Request.QueryString("pkey"))

        End If

    End Sub

    Protected Sub Buttonacenteiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonacenteiptal.Click

        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim pkey As String
        pkey = Request.QueryString("pkey")
        link = "sirketgirispopup.aspx?op=" + op + "&pkey=" + pkey + "&sirketacentebagop=yenikayit" + "&hangiiptal=2"
        inn.Value = "2"
        Response.Redirect(link)

    End Sub


    Protected Sub Buttonsirketipbagiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonsirketipbagiptal.Click

        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim pkey As String
        pkey = Request.QueryString("pkey")
        link = "sirketgirispopup.aspx?op=" + op + "&pkey=" + pkey + "&sirketipbagop=yenikayit" + "&hangiiptal=3"
        inn.Value = "3"
        Response.Redirect(link)

    End Sub


    Protected Sub Buttonsirketfaturabagiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonsirketfaturabagiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim pkey As String
        pkey = Request.QueryString("pkey")
        link = "sirketgirispopup.aspx?op=" + op + "&pkey=" + pkey + "&sirketfaturabagop=yenikayit" + "&hangiiptal=4"
        inn.Value = "4"
        Response.Redirect(link)

    End Sub
End Class