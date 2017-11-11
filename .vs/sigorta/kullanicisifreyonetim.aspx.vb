Public Partial Class kullanicisifreyonetim
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("kullanicisifreyonetim", Session("kullanici_rolpkey"))
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

         
            'PERSONELLERİ DOLDUR---------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim personel_erisim As New CLASSPERSONEL_ERISIM
            Dim personeller As New List(Of CLASSPERSONEL)
            personeller = personel_erisim.doldur()
            For Each item As CLASSPERSONEL In personeller
                DropDownList2.Items.Add(New ListItem(item.personeladsoyad, CStr(item.pkey)))
            Next

        End If 'postback

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim hata, hatamesajlari As String
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


        'personeli seçmediniz
        If Request.Form("DropDownList2") = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Personeli seçmediniz.<br/>"
        End If

        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı şifresini girmediniz.<br/>"
        End If

        'kullanıcı yeni şifre tekrar girmediniz
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı şifresinin tekrarını girmediniz.<br/>"
        End If

        If hata = "0" Then
            If Textbox1.Text <> Textbox2.Text Then
                Textbox2.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Girdiğiniz şifreler birbiri ile ayni değil.<br/>"
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        If hata = "0" Then

            kullanici = kullanici_erisim.bultek(Request.Form("DropDownList2"))
            kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(Textbox1.Text)
            result = kullanici_erisim.Duzenle(kullanici)

            durumlabel.Text = javascript.alertresult(result)

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
            email.subject = "KKSBM Şifre Değişikliği Bilgilendirilmesi"

            emailbody = "Kuzey Kıbrıs Sigorta Bilgi Merkezi<br/>" + _
            "<br/>" + _
            "Değerli Kullanıcımız" + "<br/>" + _
            "Kullanıcı Adı:" + kullanici.kullaniciad + "<br/>" + _
            "Yeni Şifreniz:" + CStr(Textbox1.Text) + "<br/>" + _
            "Şirket:" + sirket_erisim.bultek(kullanici.sirketpkey).sirketad + "<br/>" + _
            "Acente:" + acente_erisim.bultek(kullanici.acentepkey).acentead + "<br/>" + _
            "<a href='https://www.kksbm.org' target='_blank'>" + _
            "https://www.kksbm.org" + "</a><br/>"

            email.body = emailbody

            resultemail = email_erisim.gonder(email)
            durumlabelemail.Text = javascript.alertresultmail(result)

            'mesaj gönder-----------------------
            Dim msg As New CLASSMSG
            Dim msg_erisim As New CLASSMSG_ERISIM

            msg.gonderenpkey = Session("kullanici_pkey")
            msg.alanpkey = Request.Form("DropDownList2")
            msg.msgkonu = "KKSBM Şifre Değişikliği Bilgilendirilmesi"
            msg.msgmetin = emailbody
            msg.alansilmismi = "Hayır"
            msg.gonderensilmismi = "Hayır"
            msg.gondermetarih = DateTime.Now
            msg.okunmusmu = "Hayır"

            msg_erisim.ekle(msg)

        End If


    End Sub

  
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim hata, hatamesajlari As String
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

        'personeli seçmediniz
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Personeli seçmediniz.<br/>"
        End If

      
        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        If hata = "0" Then

            Dim result As New CLADBOPRESULT

            Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM
            kullanici = kullanici_erisim.bultek(Request.Form("DropDownList2"))
            result = loggenel_erisim.hatalisifresifirla(kullanici.pkey)
            durumlabel.Text = javascript.alertresult(result)


            'İŞLEMİ YAPTIKTAN SONRA ESKİ DURUMUNA GETİR.----------------------
            Dim acenteler As New List(Of CLASSACENTE)
            Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
            acenteler = sirketacentebag_erisim.doldursirketinacenteleri_acentetipinde(DropDownList5.SelectedValue)
            DropDownList6.Items.Clear()
            DropDownList6.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSACENTE In acenteler
                DropDownList6.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
            Next
            DropDownList6.SelectedValue = Request.Form("DropDownList6")

            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur_acentepkeyegore(Request.Form("DropDownList6"))
            DropDownList2.Items.Clear()
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList2.Items.Add(New ListItem(item.adsoyad, CStr(item.pkey)))
            Next
            DropDownList2.SelectedValue = Request.Form("DropDownList2")


        End If


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim hata, hatamesajlari As String
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


        'personeli seçmediniz
        If Request.Form("DropDownList2") = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Personeli seçmediniz.<br/>"
        End If

        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı şifresini girmediniz.<br/>"
        End If

        'kullanıcı yeni şifre tekrar girmediniz
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı şifresinin tekrarını girmediniz.<br/>"
        End If

        If hata = "0" Then
            If Textbox1.Text <> Textbox2.Text Then
                Textbox2.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Girdiğiniz şifreler birbiri ile ayni değil.<br/>"
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI
        Dim subject As String

        If hata = "0" Then

            kullanici = kullanici_erisim.bultek(Request.Form("DropDownList2"))
            kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(Textbox1.Text)
            result = kullanici_erisim.Duzenle(kullanici)

            durumlabel.Text = javascript.alertresult(result)

            'e-mail gönder
            Dim emailbody As String
           
            subject = "KKSBM Şifre Değişikliği Bilgilendirilmesi"

            emailbody = "Kuzey Kıbrıs Sigorta Bilgi Merkezi<br/>" + _
            "<br/>" + _
            "Değerli Kullanıcımız" + "<br/>" + _
            "Kullanıcı Adı:" + kullanici.kullaniciad + "<br/>" + _
            "Yeni Şifreniz:" + CStr(Textbox1.Text) + "<br/>" + _
            "Şirket:" + sirket_erisim.bultek(kullanici.sirketpkey).sirketad + "<br/>" + _
            "Acente:" + acente_erisim.bultek(kullanici.acentepkey).acentead + "<br/>" + _
            "<a href='https://www.kksbm.org' target='_blank'>" + _
            "https://www.kksbm.org" + "</a><br/>"


            'mesaj gönder-----------------------
            Dim msg As New CLASSMSG
            Dim msg_erisim As New CLASSMSG_ERISIM

            msg.gonderenpkey = Session("kullanici_pkey")
            msg.alanpkey = Request.Form("DropDownList2")
            msg.msgkonu = "KKSBM Şifre Değişikliği Bilgilendirilmesi"
            msg.msgmetin = emailbody
            msg.alansilmismi = "Hayır"
            msg.gonderensilmismi = "Hayır"
            msg.gondermetarih = DateTime.Now
            msg.okunmusmu = "Hayır"

            msg_erisim.ekle(msg)

        End If


    End Sub
End Class