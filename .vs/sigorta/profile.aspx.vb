Public Partial Class profile
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim loggenel As New CLASSLOGGENEL
    Dim loggenel_Erisim As New CLASSLOGGENEL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("profile", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'aktif şirket seçimini göster yada gösterme
            If Session("kullanici_mensup") = "DİĞER" Then
                aktifsirketsec.Visible = True
                aktifsirketbilgi.Visible = True
                'aktif şirketileri doldur 
                Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
                Dim sirketler As New List(Of CLASSSIRKET)
                sirketler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler_sirkettipinde(Session("kullanici_acentepkey"))
                For Each item As CLASSSIRKET In sirketler
                    DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                Next
                DropDownList1.SelectedValue = Session("kullanici_aktifsirket")

            Else
                aktifsirketsec.Visible = False
                aktifsirketbilgi.Visible = False
            End If


            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("profile", Session("kullanici_rolpkey"))
            End If

            Dim kullanicirol As New CLASSKULLANICIROL
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

            Dim kullanicigrup As New CLASSKULLANICIGRUP
            Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM


            Dim kullanici As New CLASSKULLANICI
            kullanici = kullanici_erisim.bultek(Session("kullanici_pkey"))
            kullanicigrup = kullanicigrup_erisim.bultek(kullanici.kullanicigruppkey)
            kullanicirol = kullanicirol_erisim.bultek(kullanici.rolpkey)

            literaladsoyad.Text = kullanici.adsoyad
            literaleposta.Text = kullanici.eposta
            literalkullaniciad.Text = kullanici.kullaniciad
            literalgrup.Text = kullanicigrup.grupad
            literalrol.Text = kullanicirol.rolad

            Dim aktifsirket As New CLASSSIRKET
            Dim sirket As New CLASSSIRKET
            Dim sirket_Erisim As New CLASSSIRKET_ERISIM
            Dim acente As New CLASSACENTE
            Dim acente_erisim As New CLASSACENTE_ERISIM

            sirket = sirket_Erisim.bultek(Session("kullanici_sirketpkey"))
            acente = acente_erisim.bultek(Session("kullanici_acentepkey"))

            literalsirket.Text = sirket.sirketad
            literalacente.Text = acente.acentead

            literalsistemkayittarih.Text = CStr(kullanici.eklemetarih)
            Dim ekleyenkullanici As New CLASSKULLANICI
            ekleyenkullanici = kullanici_erisim.bultek(kullanici.ekleyenkullanicipkey)
            literalsistemkayityapan.Text = ekleyenkullanici.adsoyad

            literalhesapsonguncellemetarihi.Text = CStr(kullanici.guncellemetarih)

            If HttpContext.Current.Session("kullanici_mensup") = "DİĞER" Then
                If kullanici_erisim.aktifsirketsecilmismi = "Evet" Then
                    aktifsirket = sirket_Erisim.bultek(HttpContext.Current.Session("kullanici_aktifsirket"))
                    literalaktifsirket.Text = aktifsirket.sirketad
                End If
            End If

            'rol tablosunu tablosunu göster
            If Session("kullanici_mensup") = "DİĞER" Then
                HttpContext.Current.Session("ltip") = "sirketprofil"
                Label1.Text = kullanicirol_erisim.listele_kullanicitarafiicin
            End If

            If Session("kullanici_mensup") = "KKSBM" Then
                HttpContext.Current.Session("ltip") = "tekkisiyetki"
                Label1.Text = kullanicirol_erisim.listele()
            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM
        Dim hata, hatamesajlari As String

        durumlabel.Text = ""
        hata = "0"

        Dim javascript As New CLASSJAVASCRIPT
       
        Dim kullanicipkey As String
        kullanicipkey = Session("kullanici_pkey")

        ' KONTROL ET ---------------------------
        'eski şifrenizi girmediniz.
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Eski şifrenizi girmediniz.<br/>"
        End If

        'kullanıcı şifre girmediniz
        If Len(Textbox2.Text) < 5 Then
            Textbox2.Focus()
            'hata = "1"
            'hatamesajlari = hatamesajlari + "Yeni şifreniz en az 5 karakter olmalıdır.<br/>"
        End If

        If Textbox2.Text <> TextBox3.Text Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Yeni şifreleriniz birbiri ile uymuyor." + _
            " Yazdığınız yeni şifrelerin birbiriyle ayni olup olmadığını kontrol ediniz.<br/>"
        End If

        'eski şifre doğrumu kontrol et
        If hata = "0" Then
            Dim kullanici As New CLASSKULLANICI
            kullanici = kullanici_erisim.bultek(kullanicipkey)
            If kullanici.kullanicisifre <> sifreleme_erisim.getMD5Hash(Textbox1.Text) Then
                Textbox1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Eski şifreniz doğru değil. Lütfen kontrol ediniz.<br/>"
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            Dim result As New CLADBOPRESULT
            Dim kullanici As New CLASSKULLANICI
            kullanici = kullanici_erisim.bultek(kullanicipkey)
            kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(Textbox2.Text)
            result = kullanici_erisim.Duzenle(kullanici)
            durumlabel.Text = javascript.alertresult(result)

            '---LOGLA
            loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", "kullanici", _
            "Şifre Değişikliği", "", "", 0, "Hayır", kullanici.kullaniciad, kullanici.kullanicisifre, "Web")
            loggenel_erisim.Ekle(loggenel)

        End If


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim javascript_erisim As New CLASSJAVASCRIPT
        Dim result As New CLADBOPRESULT
        result.durum = "Kaydedildi"
        result.etkilenen = 1
        result.hatastr = ""
        Session("kullanici_aktifsirket") = DropDownList1.SelectedValue
        durumlabel2.Text = javascript_erisim.alertresult_istedigimyere("validationresult2", result)


    End Sub
End Class