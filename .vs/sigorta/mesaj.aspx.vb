Public Partial Class mesaj
    Inherits System.Web.UI.Page

    Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
    Dim msg_erisim As New CLASSMSG_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_Erisim.busayfayigormeyeyetkilimi("mesaj", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            'KULLANICI GRUPLARINI DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
            Dim kullanicigruplari As New List(Of CLASSKULLANICIGRUP)
            kullanicigruplari = kullanicigrup_erisim.doldur()
            For Each item As CLASSKULLANICIGRUP In kullanicigruplari
                DropDownList1.Items.Add(New ListItem(item.grupad, CStr(item.pkey)))
            Next

            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))

            Dim kullanicirol As New CLASSKULLANICIROL
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
            kullanicirol = kullanicirol_erisim.bultek(Session("kullanici_rolpkey"))

            If kullanicirol.toplumesajyetki = "Evet" Then
                'TOPLU MESAJ
                DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
                DropDownList3.Items.Add(New ListItem("Sadece Seçtiğim Kullanıcıya", "1"))
                DropDownList3.Items.Add(New ListItem("Seçtiğim Kullanıcı Grubuna", "2"))
                DropDownList3.Items.Add(New ListItem("Tüm Kullanıcılara", "3"))
            End If

            If kullanicirol.toplumesajyetki = "Hayır" Then
                'TOPLU MESAJ
                DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
                DropDownList3.Items.Add(New ListItem("Sadece Seçtiğim Kullanıcıya", "1"))
            End If

            'AKTİF/PASİF
            DropDownList4.Items.Add(New ListItem("Aktif", "Aktif"))
            DropDownList4.Items.Add(New ListItem("Pasif", "Pasif"))
            DropDownList4.Items.Add(New ListItem("Tümü", "Tümü"))


            'GELEN MESAJLARIMI LİSTELE
            Label1.Text = msg_erisim.gelenmesajlarim(Session("kullanici_pkey"))


        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim dboresult As New CLADBOPRESULT
        Dim javascript As New CLASSJAVASCRIPT
        Dim hata As String = "0"
        Dim hatamesajlari As String = ""
        Dim alanpkey, msgkonu, msgmetin As String
        Dim emailayar As New CLASSEMAILAYAR
        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
        Dim email As New CLASSEMAIL
        Dim email_erisim As New CLASSEMAIL_ERISIM
        Dim hangisi_aktifpasif As String

        hangisi_aktifpasif = DropDownList4.SelectedValue


        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM

        emailayar = emailayar_erisim.bul(1)



        If DropDownList3.SelectedValue = "0" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Toplu mesaj seçeneğini ayarlamadınız.<br/>"
        End If


        'sadece seçtiğim kullanıcıya ise
        If DropDownList3.SelectedValue = "1" Then

            'kullanici grubu seçmediniz
            If DropDownList1.SelectedValue = "0" Then
                DropDownList1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Kullanıcı grubunu seçmediniz.<br/>"
            End If

            'kullanici adını seçmediniz
            If Request.Form("DropDownList2") = "0" Then
                DropDownList1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Kullanıcı adını seçmediniz.<br/>"
            End If

        End If


        'sadece seçtiğim kullanıcı grubuna
        If DropDownList3.SelectedValue = "2" Then

            'kullanici grubu seçmediniz
            If DropDownList1.SelectedValue = "0" Then
                DropDownList1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Kullanıcı grubunu seçmediniz.<br/>"
            End If

        End If

        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Mesaj konusunu girmediniz.<br/>"
        End If


        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Mesaj metnini girmediniz.<br/>"
        End If

        'ilgili kullanıcıya mesaj gönderme yetkisi var mı kontrol et!!
        If hata = "0" Then
            'sadece seçtiğim kullanıcıya
            If DropDownList3.SelectedValue = "1" Then
                Dim kullanicirol As New CLASSKULLANICIROL
                Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
                kullanicirol = kullanicirol_erisim.bultek(Session("kullanici_rolpkey"))
                If kullanicirol.toplumesajyetki = "Hayır" Then
                    If kullanicirol.sadecesirketicimesajlasma = "Evet" Then
                        Dim kimekullanicipkey As String
                        kimekullanicipkey = Request.Form("DropDownList2")
                        Dim kimekullanici As New CLASSKULLANICI
                        kimekullanici = kullanici_Erisim.bultek(kimekullanicipkey)
                        If kimekullanici.sirketpkey <> Session("kullanici_sirketpkey") Then
                            DropDownList2.Focus()
                            hata = "1"
                            hatamesajlari = hatamesajlari + "Sadece kendi şirketiniz içinde" + _
                            " mesajlaşabilirsiniz.<br/>"
                        End If
                    End If 'sadece sirket içi mesajlasma
                End If ' toplumesaj hayır
            End If ' sadece seçtiğim kullanıcıya
        End If 'hata=0


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        'MESAJ GÖNDER ----------------------------------------
        If hata = "0" Then

            Dim alankullanici As New CLASSKULLANICI

            alanpkey = Request.Form("DropDownList2")
            alankullanici = kullanici_Erisim.bultek(alanpkey)
            msgkonu = Textbox1.Text
            msgmetin = Textbox2.Text


            'sadece o kullaniciya
            If DropDownList3.SelectedValue = "1" Then

                msg.alanpkey = alanpkey
                msg.msgkonu = msgkonu
                msg.msgmetin = msgmetin
                msg.gonderenpkey = Session("kullanici_pkey")
                msg.alansilmismi = "Hayır"
                msg.gonderensilmismi = "Hayır"
                msg.gondermetarih = DateTime.Now
                msg.okunmusmu = "Hayır"
                dboresult = msg_erisim.ekle(msg)

                durumlabel.Text = javascript.alertresult(dboresult)

                If alankullanici.emailgonderilsinmi = "Evet" Then
                    'EPOSTA GÖNDER--------------------------------------------------
                    email.kimden = emailayar.username
                    email.kime = alankullanici.eposta
                    email.subject = "KKSBM Gönderen:" + HttpContext.Current.Session("kullanici_adsoyad") + _
                    " Konu:" + msg.msgkonu
                    email.body = msg.msgmetin
                    email_erisim.gonder(email)
                End If

            End If 'sadece o kullanıcı


            'seçtiğim kullanıcı grubuna
            If DropDownList3.SelectedValue = "2" Then

                Dim aktifpasif_gonderilecekmi As String = "Hayır"

                Dim secilengrupkullanicilar As New List(Of CLASSKULLANICI)
                secilengrupkullanicilar = kullanici_Erisim.doldur_kullanicigruppkeyegore(DropDownList1.SelectedValue)
                For Each item As CLASSKULLANICI In secilengrupkullanicilar

                    alankullanici = kullanici_Erisim.bultek(item.pkey)

                    If hangisi_aktifpasif = "Aktif" Then
                        If alankullanici.aktifmi = "Evet" Then
                            aktifpasif_gonderilecekmi = "Evet"
                        End If
                    End If
                    If hangisi_aktifpasif = "Pasif" Then
                        If alankullanici.aktifmi = "Hayır" Then
                            aktifpasif_gonderilecekmi = "Evet"
                        End If
                    End If
                    If hangisi_aktifpasif = "Tümü" Then
                        aktifpasif_gonderilecekmi = "Evet"
                    End If

                    If aktifpasif_gonderilecekmi = "Evet" Then

                        msg.alanpkey = item.pkey
                        msg.msgkonu = msgkonu
                        msg.msgmetin = msgmetin
                        msg.gonderenpkey = Session("kullanici_pkey")
                        msg.alansilmismi = "Hayır"
                        msg.gonderensilmismi = "Hayır"
                        msg.gondermetarih = DateTime.Now
                        msg.okunmusmu = "Hayır"
                        dboresult = msg_erisim.ekle(msg)

                        If alankullanici.emailgonderilsinmi = "Evet" Then
                            'EPOSTA GÖNDER--------------------------------------------------
                            email.kimden = emailayar.username
                            email.kime = alankullanici.eposta
                            email.subject = "KKSBM Gönderen:" + HttpContext.Current.Session("kullanici_adsoyad") + _
                            " Konu:" + msg.msgkonu
                            email.body = msg.msgmetin
                            email_erisim.gonder(email)
                        End If

                    End If 'aktifpasif_gonderilecekmi = "Evet"

                Next

                durumlabel.Text = javascript.alertresult(dboresult)

            End If '2


            'tüm kullanıcılara
            If DropDownList3.SelectedValue = "3" Then
                Dim tumkullanicilar As New List(Of CLASSKULLANICI)
                tumkullanicilar = kullanici_Erisim.doldurbenimdisimda
                For Each item As CLASSKULLANICI In tumkullanicilar

                    alankullanici = kullanici_Erisim.bultek(item.pkey)

                    msg.alanpkey = item.pkey
                    msg.msgkonu = msgkonu
                    msg.msgmetin = msgmetin
                    msg.gonderenpkey = Session("kullanici_pkey")
                    msg.alansilmismi = "Hayır"
                    msg.gonderensilmismi = "Hayır"
                    msg.gondermetarih = DateTime.Now
                    msg.okunmusmu = "Hayır"
                    dboresult = msg_erisim.ekle(msg)

                    If alankullanici.emailgonderilsinmi = "Evet" Then
                        'EPOSTA GÖNDER--------------------------------------------------
                        email.kimden = emailayar.username
                        email.kime = alankullanici.eposta
                        email.subject = "KKSBM Gönderen:" + HttpContext.Current.Session("kullanici_adsoyad") + _
                        " Konu:" + msg.msgkonu
                        email.body = msg.msgmetin
                        email_erisim.gonder(email)
                    End If

                Next

                durumlabel.Text = javascript.alertresult(dboresult)

            End If '3

        End If 'hata=0


    End Sub
End Class