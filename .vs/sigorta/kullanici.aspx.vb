Public Partial Class kullanici
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI

    'yetkiler icin 
    Dim tabload As String = "kullanici"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("kullanici", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList5.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList5.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            'ACENTELERİ DOLDUR 
            DropDownList6.Items.Add(New ListItem("Seçiniz", "0"))
            Dim acente_erisim As New CLASSACENTE_ERISIM
            Dim acenteler As New List(Of CLASSACENTE)
            acenteler = acente_erisim.doldur()
            For Each item As CLASSACENTE In acenteler
                DropDownList6.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
            Next

            'KULLANICI GRUPLARINI DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
            Dim kullanicigruplari As New List(Of CLASSKULLANICIGRUP)
            kullanicigruplari = kullanicigrup_erisim.doldur()
            For Each item As CLASSKULLANICIGRUP In kullanicigruplari
                DropDownList1.Items.Add(New ListItem(item.grupad, CStr(item.pkey)))
            Next

            'PERSONELLERİ DOLDUR---------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim personel_erisim As New CLASSPERSONEL_ERISIM
            Dim personeller As New List(Of CLASSPERSONEL)
            personeller = personel_erisim.doldur()
            For Each item As CLASSPERSONEL In personeller
                DropDownList2.Items.Add(New ListItem(item.personeladsoyad, CStr(item.pkey)))
            Next

            'ROLLERİ DOLDUR---------------------------------------
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
            Dim roller As New List(Of CLASSKULLANICIROL)
            roller = kullanicirol_erisim.doldur
            For Each item As CLASSKULLANICIROL In roller
                DropDownList3.Items.Add(New ListItem(item.rolad, CStr(item.pkey)))
            Next

            'RESİMLERİ DOLDUR---------------------------------------
            DropDownList4.Items.Add(New ListItem("Seçiniz", "0"))
            Dim resim_erisim As New CLASSTEKRESIM_ERISIM
            Dim resimler As New List(Of CLASSTEKRESIM)
            resimler = resim_erisim.doldur()
            For Each item As CLASSTEKRESIM In resimler
                DropDownList4.Items.Add(New ListItem(item.baslik, CStr(item.pkey)))
            Next

            'TÜM GİRİLEN KULLANICILARI BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanici_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Textbox2.ReadOnly = True
                Buttonsil.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                kullanici = kullanici_erisim.bultek(Request.QueryString("pkey"))

                DropDownList5.SelectedValue = kullanici.sirketpkey
                DropDownList6.SelectedValue = kullanici.acentepkey
                DropDownList1.SelectedValue = kullanici.kullanicigruppkey
                DropDownList2.SelectedValue = kullanici.personelpkey
                DropDownList3.SelectedValue = kullanici.rolpkey
                DropDownList4.SelectedValue = kullanici.resimpkey

                If kullanici.aktifmi = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                Textbox1.Text = kullanici.kullaniciad
                Textbox2.Text = kullanici.kullanicisifre
                TextBox3.Text = kullanici.eposta

                If kullanici.emailgonderilsinmi = "Evet" Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If

            End If

            If Request.QueryString("op") = "yenikayit" Then
                Textbox2.ReadOnly = False
                DropDownList1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then


                DropDownList5.Enabled = False
                DropDownList6.Enabled = False
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                DropDownList4.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                TextBox3.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If 'postback


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
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM


        Dim op As String
        op = Request.QueryString("op")

        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------
        'sirketleri kontrol et
        If DropDownList5.SelectedValue = "0" Then
            DropDownList5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının çalıştığı şirketi seçmediniz.<br/>"
        End If

        'acente kontrol et
        If Request.Form("DropDownList6") = "0" Then
            DropDownList6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının çalıştığı acenteyi seçmediniz.<br/>"
        End If

        'kullanıcı grubunu
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı grubunu seçmediniz.<br/>"
        End If

        'personeli seçmediniz
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Personeli seçmediniz.<br/>"
        End If

        'rolü kontrol
        If DropDownList3.SelectedValue = "0" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Rolü seçmediniz.<br/>"
        End If

        'resimi kontrol
        If DropDownList4.SelectedValue = "0" Then
            DropDownList4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Resimi seçmediniz.<br/>"
        End If

        'kullanıcı adsoyad girmediniz
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı adını girmediniz.<br/>"
        End If

        'kullanıcı şifre girmediniz
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı şifresini girmediniz.<br/>"
        End If


        'eposta kontrol et
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox3.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            TextBox3.Focus()
            hatamesajlari = hatamesajlari + "Kullanıcı E-Mail adresini doğru giriniz."
        End If

        If hata = "0" Then
            'BAK BAKALIM BU KULLANICI DAHA ÖNCE TANIMLANMIŞ MI!
            Dim tanimlanmismi As String
            tanimlanmismi = kullanici_erisim.teknikpersoneltanimlanmismi(Textbox2.Text)
            If tanimlanmismi = "Evet" And op = "yenikayit" Then
                hata = "1"
                Textbox2.Focus()
                hatamesajlari = hatamesajlari + "Bu teknik personel daha önceden tanımlanmış."
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanici As New CLASSKULLANICI

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                kullanici.sirketpkey = DropDownList5.SelectedValue
                kullanici.acentepkey = Request.Form("DropDownList6")
                kullanici.kullanicigruppkey = DropDownList1.SelectedValue
                kullanici.personelpkey = DropDownList2.SelectedValue
                kullanici.rolpkey = DropDownList3.SelectedValue
                kullanici.resimpkey = DropDownList4.SelectedValue

                If CheckBox1.Checked = True Then
                    kullanici.aktifmi = "Evet"
                Else
                    kullanici.aktifmi = "Hayır"
                End If

                kullanici.adsoyad = DropDownList2.SelectedItem.Text
                kullanici.kullaniciad = Textbox1.Text
                kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(Textbox2.Text)
                kullanici.eposta = TextBox3.Text

                If CheckBox2.Checked = True Then
                    kullanici.emailgonderilsinmi = "Evet"
                Else
                    kullanici.emailgonderilsinmi = "Hayır"
                End If

                kullanici.ekleyenkullanicipkey = Session("kullanici_pkey")
                kullanici.eklemetarih = DateTime.Now

                result = kullanici_erisim.Ekle(kullanici)

            End If

            If Request.QueryString("op") = "duzenle" Then
                kullanici = kullanici_erisim.bultek(Request.QueryString("pkey"))

                kullanici.sirketpkey = DropDownList5.SelectedValue
                kullanici.acentepkey = Request.Form("DropDownList6")
                kullanici.kullanicigruppkey = DropDownList1.SelectedValue
                kullanici.personelpkey = DropDownList2.SelectedValue
                kullanici.rolpkey = DropDownList3.SelectedValue
                kullanici.resimpkey = DropDownList4.SelectedValue

                If CheckBox1.Checked = True Then
                    kullanici.aktifmi = "Evet"
                Else
                    kullanici.aktifmi = "Hayır"
                End If

                kullanici.adsoyad = DropDownList2.SelectedItem.Text
                kullanici.kullaniciad = Textbox1.Text
                'kullanici.kullanicisifre = Textbox2.Text
                kullanici.eposta = TextBox3.Text

                If CheckBox2.Checked = True Then
                    kullanici.emailgonderilsinmi = "Evet"
                Else
                    kullanici.emailgonderilsinmi = "Hayır"
                End If

                kullanici.guncelleyenkullanicipkey = Session("kullanici_pkey")
                kullanici.guncellemetarih = DateTime.Now

                result = kullanici_erisim.Duzenle(kullanici)
            End If

            'E-POSTA GÖNDER---
            If result.durum = "Kaydedildi" And Request.QueryString("op") = "yenikayit" Then

                'e-mail gönder
                Dim emailbody As String
                Dim resultemail As New CLADBOPRESULT
                Dim email As New CLASSEMAIL
                Dim email_erisim As New CLASSEMAIL_ERISIM
                Dim emailayar As New CLASSEMAILAYAR
                Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

                emailayar = emailayar_erisim.bul(1)

                Dim gonderenkullanici As New CLASSKULLANICI
                gonderenkullanici = kullanici_erisim.bultek(Session("kullanici_pkey"))

                email.kime = kullanici.eposta
                email.kimden = emailayar.username
                email.subject = "KKSBM Kullanıcı Tanımı / Güncellemesi"

                emailbody = "Kuzey Kıbrıs Sigorta Bilgi Merkezi<br/>" + _
                "<br/>" + _
                "Değerli Kullanıcımız" + "<br/>" + _
                "Kullanıcı Adı:" + kullanici.kullaniciad + "<br/>" + _
                "Şifreniz:" + CStr(Textbox2.Text) + "<br/>" + _
                "Şirket:" + sirket_erisim.bultek(kullanici.sirketpkey).sirketad + "<br/>" + _
                "Acente:" + acente_erisim.bultek(kullanici.acentepkey).acentead + "<br/>" + _
                "Kullanıcı bilgileriniz eklenmiş ve/veya güncellenmiştir." + "<br/>" + _
                "<a href='http://kksbm.org/' target='_blank'>" + _
                "http://kksbm.org" + "</a><br/>"

                email.body = emailbody

                resultemail = email_erisim.gonder(email)
                durumlabelemail.Text = javascript.alertresultmail(result)

                'mesaj gönder-----------------------
                Dim msg As New CLASSMSG
                Dim msg_erisim As New CLASSMSG_ERISIM

                msg.gonderenpkey = Session("kullanici_pkey")
                msg.alanpkey = Request.Form("DropDownList2")
                msg.msgkonu = "KKSBM Kullanıcı Tanımı / Güncellenmesi Bilgilendirilmesi"
                msg.msgmetin = emailbody
                msg.alansilmismi = "Hayır"
                msg.gonderensilmismi = "Hayır"
                msg.gondermetarih = DateTime.Now
                msg.okunmusmu = "Hayır"

                msg_erisim.ekle(msg)

            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = kullanici_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("kullanici.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = kullanici_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub


End Class