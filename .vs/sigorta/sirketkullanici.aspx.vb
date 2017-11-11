Public Partial Class sirketkullanici
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim personel As New CLASSPERSONEL
    Dim personel_Erisim As New CLASSPERSONEL_ERISIM
    Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
    Dim bulunanilkgruppkey As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirketkullanici", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'ŞİRKETLERİ DOLDUR
            Dim sirket As New CLASSSIRKET
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            sirket = sirket_erisim.bultek(Session("kullanici_sirketpkey"))
            DropDownList5.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList5.Items.Add(New ListItem(sirket.sirketad, CStr(sirket.pkey)))

            'KULLANICI GRUPLARINI DOLDUR ŞİRKET TARAFINDA
            Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
            Dim kullanicigruplar As New List(Of CLASSKULLANICIGRUP)
            kullanicigruplar = kullanicigrup_erisim.doldur_sirkettaraficin()
            For Each item As CLASSKULLANICIGRUP In kullanicigruplar
                bulunanilkgruppkey = item.pkey
            Next


            If Request.QueryString("op") = "duzenle" Then

                Textbox5.ReadOnly = True
                Buttonsil.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                kullanici = kullanici_erisim.bultek(Request.QueryString("pkey"))

                'önce bak bakalım bu kullaniciyi sen mi yarattın 
                If kullanici.ekleyenkullanicipkey = Session("kullanici_pkey") Then

                    DropDownList5.SelectedValue = kullanici.sirketpkey

                    'ACENTELERİ(DOLDUR)
                    DropDownList6.Items.Add(New ListItem("Seçiniz", "0"))
                    Dim acente As New CLASSACENTE
                    Dim acente_erisim As New CLASSACENTE_ERISIM
                    Dim acenteler As New List(Of CLASSACENTE)
                    Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
                    Dim sirketacentebaglar As New List(Of CLASSSIRKETACENTEBAG)
                    acenteler = sirketacentebag_erisim.doldursirketinacenteleri_acentetipindeonunekledigi(kullanici.sirketpkey)
                    For Each item As CLASSACENTE In acenteler
                        DropDownList6.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
                    Next

                    'KULLANICI ROLLERİNİ DOLDUR
                    Dim kullaniciroller As New List(Of CLASSKULLANICIROL)
                    Dim kullanicirol As New CLASSKULLANICIROL
                    Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
                    acente = acente_erisim.bultek(kullanici.acentepkey)
                    If acente.merkezmi = "Evet" Then
                        kullaniciroller = kullanicirol_erisim.doldur_sadecesirketinverebilecegi_rol("Evet")
                    End If
                    If acente.merkezmi = "Hayır" Then
                        kullaniciroller = kullanicirol_erisim.doldur_sadecesirketinverebilecegi_rol("Hayır")
                    End If
                    For Each item As CLASSKULLANICIROL In kullaniciroller
                        DropDownList7.Items.Add(New ListItem(item.rolad, CStr(item.pkey)))
                    Next


                    DropDownList6.SelectedValue = kullanici.acentepkey
                    DropDownList7.SelectedValue = kullanici.rolpkey
                    personel = personel_Erisim.bultek(kullanici.personelpkey)
                    Textbox1.Text = personel.kimlikno
                    Textbox2.Text = personel.tpno
                    Textbox3.Text = kullanici.adsoyad
                    Textbox4.Text = kullanici.kullaniciad
                    Textbox5.Text = kullanici.kullanicisifre
                    If kullanici.aktifmi = "Evet" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If
                    TextBox6.Text = kullanici.eposta

                End If

                If kullanici.ekleyenkullanicipkey <> Session("kullanici_pkey") Then
                    Dim msg As String
                    msg = "Bu kullanıcı üzerinde düzenleme yapmaya yetkili değilsiniz."
                    durumlabel.Text = javascript.alert(msg, "alert", 10, "warning")
                End If

            End If 'düzenle

            If Request.QueryString("op") = "yenikayit" Then
                Textbox5.ReadOnly = False
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then

                DropDownList5.Enabled = False
                DropDownList6.Enabled = False
                DropDownList7.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Textbox3.Enabled = False
                Textbox4.Enabled = False
                Textbox5.Enabled = False
                TextBox6.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

            'BU KULLANICININ EKLEMİŞ OLDUĞU TÜM KULLANICILARI BUL
            HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi"
            Label1.Text = kullanici_erisim.listele()

            'BU KULLANICININ TANIMLAYABİLECEĞİ ROLLER HAKKINDA BİLGİ VER 
            HttpContext.Current.Session("ltip") = "sirketadminyardimci"
            Label2.Text = kullanicirol_erisim.listele_kullanicitarafiicin


        End If 'postback

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM
        Dim hata, hatamesajlari As String
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
        If Request.Form("DropDownList6") = "0" Or Request.Form("DropDownList6") = Nothing Then
            DropDownList6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının çalıştığı acenteyi seçmediniz.<br/>"
        End If

        'kullanici rolunu kontrol et
        If Request.Form("DropDownList7") = "0" Or Request.Form("DropDownList7") = Nothing Then
            DropDownList7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının rolünü seçmediniz.<br/>"
        End If


        'kullanıcı kimlik kartı
        If Len(Textbox1.Text) <> 6 And Len(Textbox1.Text) <> 10 And Len(Textbox1.Text) <> 11 Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı kimlik kartı numarası 6,10 yada 11 rakamdan oluşmalıdır.<br/>"
        End If

        'tp no
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Teknik personel numarasını girmediniz.<br/>"
        End If

        'ad soyadı girmediniz
        If Textbox3.Text = "" Then
            Textbox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Ad soyadı girmediniz.<br/>"
        End If


        'kullanıcı adını girmediniz
        If Request.Form("Textbox4") = "" Then
            Textbox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı adını soyadı girmediniz.<br/>"
        End If

        'kullanıcı sifresini girmediniz
        If Textbox5.Text = "" Then
            Textbox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı şifresini girmediniz.<br/>"
        End If


        'eposta kontrol et
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            Textbox3.Focus()
            hatamesajlari = hatamesajlari + "Müşteri E-Mail adresini doğru giriniz."
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

        If hata = "0" Then

            Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
            Dim kullanicigruplar As New List(Of CLASSKULLANICIGRUP)
            kullanicigruplar = kullanicigrup_erisim.doldur_sirkettaraficin()
            For Each item As CLASSKULLANICIGRUP In kullanicigruplar
                bulunanilkgruppkey = item.pkey
            Next

            'kontrol et bakalım bu tp ve kimlik kartı numaraları bir personel tanımlanmış mı. 
            Dim personel_erisim As New CLASSPERSONEL_ERISIM
            Dim tanimlanmismi As String
            tanimlanmismi = personel_erisim.tpnovekimliknovarmi(Textbox2.Text, Textbox1.Text)

            If tanimlanmismi = "Hayır" Then
                Textbox1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + _
                "Bu kimlik numarası ve teknik personel numaralı personel " + _
                "Sigorta Bilgi Merkezi tarafından tanımlanmamış."
            End If
        
        End If


        'kullaniciyi pasif yapmasına izin verme 
        If Request.QueryString("op") = "duzenle" Then
            If CheckBox1.Checked = False Then
                CheckBox1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Kullacıyı pasif yapamazsınız."
            End If
        End If

        If hata = "1" Then
            DropDownList5.SelectedValue = "0"
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanici As New CLASSKULLANICI

        If hata = "0" Then

            Dim tekresim As New CLASSTEKRESIM
            Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM

            If Request.QueryString("op") = "yenikayit" Then

                kullanici.sirketpkey = DropDownList5.SelectedValue
                kullanici.acentepkey = Request.Form("DropDownList6")
                kullanici.rolpkey = Request.Form("DropDownList7")
                kullanici.kullanicigruppkey = bulunanilkgruppkey
                tekresim = tekresim_erisim.bulekkodagore(Session("kullanici_aktifsirket"))
                kullanici.resimpkey = tekresim.pkey
                personel = personel_Erisim.bultpnovekimliknogore(Textbox2.Text, Textbox1.Text)
                kullanici.personelpkey = personel.pkey
                kullanici.adsoyad = personel.personeladsoyad
                kullanici.kullaniciad = Request.Form("Textbox4")
                kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(Textbox5.Text)
                kullanici.eposta = TextBox6.Text
                If CheckBox1.Checked = True Then
                    kullanici.aktifmi = "Evet"
                Else
                    kullanici.aktifmi = "Hayır"
                End If
                kullanici.emailgonderilsinmi = "Hayır"
                kullanici.ekleyenkullanicipkey = Session("kullanici_pkey")
                kullanici.eklemetarih = DateTime.Now

                result = kullanici_erisim.Ekle(kullanici)

            End If

            If Request.QueryString("op") = "duzenle" Then
                kullanici = kullanici_erisim.bultek(Request.QueryString("pkey"))

                kullanici.sirketpkey = DropDownList5.SelectedValue
                kullanici.acentepkey = Request.Form("DropDownList6")
                kullanici.rolpkey = Request.Form("DropDownList7")
                kullanici.kullanicigruppkey = bulunanilkgruppkey
                personel = personel_Erisim.bultpnovekimliknogore(Textbox2.Text, Textbox1.Text)
                kullanici.personelpkey = personel.pkey
                kullanici.adsoyad = personel.personeladsoyad
                kullanici.kullaniciad = Textbox4.Text
                'kullanici.kullanicisifre = Textbox5.Text
                kullanici.eposta = TextBox6.Text
                If CheckBox1.Checked = True Then
                    kullanici.aktifmi = "Evet"
                Else
                    kullanici.aktifmi = "Hayır"
                End If
                kullanici.emailgonderilsinmi = "Hayır"
                kullanici.guncelleyenkullanicipkey = Session("kullanici_pkey")
                kullanici.guncellemetarih = DateTime.Now

                result = kullanici_erisim.Duzenle(kullanici)
            End If

            durumlabel.Text = javascript.alertresult(result)

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
                "<a href='http://kksbm.supernova2.com' target='_blank'>" + _
                "http://kksbm.supernova2.com" + "</a><br/>" + _
                "Kullanıcı Adı:" + kullanici.kullaniciad + "<br/>" + _
                "Şifreniz:" + CStr(Textbox5.Text)

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

            HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi"
            Label1.Text = kullanici_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("sirketkullanici.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = kullanici_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub


End Class