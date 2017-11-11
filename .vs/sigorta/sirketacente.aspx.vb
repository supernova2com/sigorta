Public Partial Class sirketacente
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI

    Dim acente As New CLASSACENTE
    Dim acente_Erisim As New CLASSACENTE_ERISIM
    Dim sirketacentebag As New CLASSSIRKETACENTEBAG
    Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Buttonsil.Visible = False

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirketacente", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'ŞİRKETLERİ DOLDUR
            Dim sirket As New CLASSSIRKET
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            sirket = sirket_erisim.bultek(Session("kullanici_sirketpkey"))
            DropDownList5.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList5.Items.Add(New ListItem(sirket.sirketad, CStr(sirket.pkey)))


            'BU KULLANICININ EKLEMİŞ OLDUĞU TÜM ACENTELERİ BUL
            HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi"
            Label1.Text = acente_Erisim.listele_sirketadminicin

            If Request.QueryString("op") = "duzenle" Then

                Button1.Text = "Değişiklikleri Güncelle"
                acente = acente_Erisim.bultek(Request.QueryString("pkey"))

                'önce bak bakalım bu acenteyi sen mi yarattın 
                If acente.guncelleyenkullanicipkey = Session("kullanici_pkey") Then

                    DropDownList5.SelectedValue = Session("kullanici_sirketpkey")
                    Textboxacentepkey.Text = acente.pkey
                    Textbox2.Text = acente.acentead
                    Textbox1.Text = acente.sicilno
                    Textbox3.Text = acente.yetkiadsoyad
                    Textbox4.Text = acente.yetkikimlikno
                    Textbox5.Text = acente.yetkiceptel
                    TextBox6.Text = acente.yetkiemail
                    TextBox7.Text = acente.tel
                    TextBox8.Text = acente.fax
                End If

                If kullanici.ekleyenkullanicipkey <> Session("kullanici_pkey") Then
                    'Dim msg As String
                    'msg = "Bu acente üzerinde düzenleme yapmaya yetkili değilsiniz."
                    'durumlabel.Text = javascript.alert(msg, "alert", 10, "warning")
                End If

            End If 'düzenle

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then

                DropDownList5.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Textbox3.Enabled = False
                Textbox4.Enabled = False
                Textbox5.Enabled = False
                TextBox6.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If


        End If 'postback

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String


        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------
        'sirketleri kontrol et
        If DropDownList5.SelectedValue = "0" Then
            DropDownList5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Acentenin çalıştığı şirketi seçmediniz.<br/>"
        End If


        'sicil no
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Acente sicil numarasını girmediniz.<br/>"
        End If

        'acente ad
        If Request.Form("Textbox2") = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Acente adını girmediniz.<br/>"
        End If


        'kullanıcı kimlik kartı
        If Len(Textbox4.Text) < 6 Then
            Textbox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı kimlik kartı numarasını 6'dan büyük olmalıdır.<br/>"
        End If

        'ceptel
        If Len(Textbox5.Text) <> 10 Then
            Textbox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Acente yetkilisinin cep telefonunu 10 rakamdan oluşmalıdır.<br/>"
        End If

        'eposta kontrol et
        If System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            Textbox3.Focus()
            hatamesajlari = hatamesajlari + "Acente yetkilisinin E-Mail adresini doğru giriniz.<br/>"
        End If

        'telefon
        If TextBox7.Text <> "" Then
            If Len(TextBox7.Text) <> 11 Then
                Textbox5.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Acente yetkilisinin sabit telefon numarası" + _
                " 11 rakamdan oluşmalı ve 0392 ile başlamalıdır.<br/>"

            End If
        End If

        'fax
        If TextBox8.Text <> "" Then
            If Len(TextBox8.Text) <> 11 Then
                TextBox8.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Acente yetkilisinin fax numarası " + _
                "11 rakamdan oluşmalıdır.<br/>"
            End If
        End If

        If hata = "0" Then

            'kontrol et bakalım bu acente sicil no ile bir acente tanımlanmışmı
            Dim tanimlanmisacente As New CLASSACENTE
            tanimlanmisacente = acente_Erisim.bulsicilnogore(Textbox1.Text)

            'demekki tanımlanmamış
            If tanimlanmisacente.pkey = 0 Then
                Textbox1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + _
                "Bu sicil numaralı bir acente KKSBM tarafından tanımlanmamış."
            End If

            If Request.Form("Textboxacentepkey") = "" Then
                Textbox1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + _
                "Acente sicil numarasını düzgün girmediniz."
            End If

        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        If hata = "0" Then

            acente = acente_Erisim.bultek(Request.Form("Textboxacentepkey"))

            acente.merkezmi = "Hayır"
            acente.acentead = Request.Form("Textbox2")
            acente.sicilno = UCase(Textbox1.Text)
            acente.aktifmi = "Evet"
            acente.yetkiadsoyad = Textbox3.Text
            acente.yetkikimlikno = Textbox4.Text
            acente.yetkiceptel = Textbox5.Text
            acente.yetkiemail = TextBox6.Text
            acente.tel = TextBox7.Text
            acente.fax = TextBox8.Text
            acente.guncelleyenkullanicipkey = Session("kullanici_pkey")
            acente.guncellenmetarih = DateTime.Now

            result = acente_Erisim.Duzenle(acente)
            durumlabel.Text = javascript.alertresult(result)

            'sirket acente bağ ekle 
            If result.durum = "Kaydedildi" Then
                sirketacentebag.acentepkey = acente.pkey
                sirketacentebag.sirketpkey = DropDownList5.SelectedValue
                sirketacentebag_erisim.Ekle(sirketacentebag)
            End If

            HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi"
            Label1.Text = acente_Erisim.listele_sirketadminicin

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("sirketacente.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim pkey As String
        pkey = Request.QueryString("pkey")
        'sirketacentebag_erisim.Sililgiliacente()
        result = acente_Erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub

End Class