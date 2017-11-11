Public Partial Class menu
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim menu_erisim As New CLASSMENU_ERISIM
    Dim menu As New CLASSMENU
    Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
    Dim roltabload As String
    Dim veritabaniad As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_Erisim.busayfayigormeyeyetkilimi("ayar", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'Labelsiralamamenu.Text = menu_erisim.siralamagosterrecursive(1, 0)

            'ARAMADA SEÇİNİZ LERİ KOY 
            DropDownList6.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList7.Items.Add(New ListItem("Seçiniz", "0"))

            'ANA MENULERI DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim anamenu_erisim As New CLASSANAMENU_ERISIM
            Dim anamenuler As New List(Of CLASSANAMENU)
            anamenuler = anamenu_erisim.doldur()
            For Each item As CLASSANAMENU In anamenuler
                DropDownList1.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
                DropDownList6.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
                DropDownList7.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
                DropDownList9.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
            Next

            'BAŞLIK MENULERINİ DOLDUR
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))

            'ÖNCE SİSTEMİN KULLANDIĞI HAK TABLOSUNU BUL 
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            roltabload = site.roltabload
            veritabaniad = site.sistemveritabaniad


            'TABLO KOLONLARINI DOLDUR
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(veritabaniad, roltabload)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList4.Items.Add(New ListItem(item.column_name, item.column_name))
            Next


            'MODULLERİ DOLDUR
            DropDownList10.Items.Add(New ListItem("Seçiniz", "0"))
            Dim tmodul_erisim As New CLASSTMODUL_ERISIM
            Dim tmoduller As New List(Of CLASSTMODUL)
            tmoduller = tmodul_erisim.doldur()
            For Each item As CLASSTMODUL In tmoduller
                DropDownList10.Items.Add(New ListItem(item.ad, item.pkey))
            Next

            'BAŞLIK MI---------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList2.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList2.Items.Add(New ListItem("Hayır", "Hayır"))

            'HANGİ SAYFADA AÇILSIN 
            DropDownList5.Items.Add(New ListItem("Ayni Sayfada", "Ayni Sayfada"))
            DropDownList5.Items.Add(New ListItem("Yeni Sayfada", "Yeni Sayfada"))

            'HERZAMAN GÖZÜKSÜN MÜ
            DropDownList11.Items.Add(New ListItem("Hayır", "Hayır"))
            DropDownList11.Items.Add(New ListItem("Evet", "Evet"))


            'TÜM GİRİLEN MENULERİ BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = menu_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Buttonsil.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                menu = menu_erisim.bultek(Request.QueryString("pkey"))

                DropDownList1.SelectedValue = menu.anamenupkey
                Textbox1.Text = menu.baslik
                Textbox2.Text = menu.sira
                Textbox3.Text = menu.tip
                TextBox4.Text = menu.iconclass
                Textbox5.Text = menu.anaclass
                Textbox6.Text = menu.idismi
                TextBox7.Text = menu.ekhtml
                Textbox8.Text = menu.link
                DropDownList4.SelectedValue = menu.hakkolon
                DropDownList2.SelectedValue = menu.baslikmi
                DropDownList11.SelectedValue = menu.herzamangozuksunmu

                'SADECE BABA MENU LERİ DOLDUR
                DropDownList3.Items.Clear()
                DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
                Dim menuler As New List(Of CLASSMENU)
                menuler = menu_erisim.doldursadecebaba(menu.anamenupkey)
                For Each item As CLASSMENU In menuler
                    DropDownList3.Items.Add(New ListItem(item.baslik, CStr(item.pkey)))
                Next
                DropDownList3.SelectedValue = menu.babaid
                DropDownList5.SelectedValue = menu.neredeacilsin
                DropDownList10.SelectedValue = menu.modulpkey

            End If

            If Request.QueryString("op") = "yenikayit" Then
                DropDownList1.Focus()
                Buttonsil.Visible = False
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                DropDownList4.Enabled = False
                DropDownList5.Enabled = False
                DropDownList10.Enabled = False
                DropDownList11.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Textbox3.Enabled = False
                TextBox4.Enabled = False
                Textbox5.Enabled = False
                Textbox6.Enabled = False
                TextBox7.Enabled = False
                Textbox8.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
                DropDownList5.Enabled = False


            End If

        End If 'postback

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String


        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Ana menüyü seçmediniz.<br/>"
        End If


        ' BAŞLIK MI DEĞİL Mİ EVET HAYIR SEÇMEMİŞ ---------------------------
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Başlık olup olmadığını seçmediniz.<br/>"
        End If


        'sira
        If IsNumeric(Textbox2.Text) = False Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Sıra numarası rakamsal olmalıdır.<br/>"
        End If

        'tip    
        If Textbox3.Text = "" Then
            Textbox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Tipi girmediniz.<br/>"
        End If

        'iconclass
        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "İkon classını girmediniz.<br/>"
        End If

        'anaclass
        If Textbox5.Text = "" Then
            'Textbox5.Focus()
            'hata = "1"
            'hatamesajlari = hatamesajlari + "Ana classını girmediniz.<br/>"
        End If


        'id
        If Textbox6.Text = "" Then
            Textbox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "ID yi girmediniz.<br/>"
        End If


        'link
        If Textbox8.Text = "" Then
            Textbox8.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Gideceği linki yazmadınız.<br/>"
        End If


        ' modul
        If DropDownList10.SelectedValue = "0" Then
            'DropDownList10.Focus()
            'hata = "1"
            'hatamesajlari = hatamesajlari + "Bağlı modülünü seçmediniz.<br/>"
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim menu_erisim As New CLASSMENU_ERISIM
        Dim menu As New CLASSMENU

        If hata = "0" Then

            If DropDownList3.SelectedValue = Nothing Then
                DropDownList3.SelectedValue = 0
            End If

            If Request.QueryString("op") = "yenikayit" Then

                menu.baslik = Textbox1.Text
                menu.sira = Textbox2.Text
                menu.tip = Textbox3.Text
                menu.anamenupkey = DropDownList1.SelectedValue
                menu.iconclass = TextBox4.Text
                menu.anaclass = Textbox5.Text
                menu.idismi = Textbox6.Text
                menu.ekhtml = TextBox7.Text
                menu.link = Textbox8.Text
                menu.hakkolon = DropDownList4.SelectedValue
                menu.babaid = Request.Form("DropDownList3")
                menu.baslikmi = DropDownList2.SelectedValue
                menu.neredeacilsin = DropDownList5.SelectedValue
                menu.modulpkey = DropDownList10.SelectedValue
                menu.herzamangozuksunmu = DropDownList11.SelectedValue

                result = menu_erisim.Ekle(menu)

            End If

            If Request.QueryString("op") = "duzenle" Then
                menu = menu_erisim.bultek(Request.QueryString("pkey"))

                menu.baslik = Textbox1.Text
                menu.sira = Textbox2.Text
                menu.tip = Textbox3.Text
                menu.anamenupkey = DropDownList1.SelectedValue
                menu.iconclass = TextBox4.Text
                menu.anaclass = Textbox5.Text
                menu.idismi = Textbox6.Text
                menu.ekhtml = TextBox7.Text
                menu.link = Textbox8.Text
                menu.hakkolon = DropDownList4.SelectedValue
                menu.babaid = Request.Form("DropDownList3")
                menu.baslikmi = DropDownList2.SelectedValue
                menu.neredeacilsin = DropDownList5.SelectedValue
                menu.modulpkey = DropDownList10.SelectedValue
                menu.herzamangozuksunmu = DropDownList11.SelectedValue

                result = menu_erisim.Duzenle(menu)
            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = menu_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("menu.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = menu_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim hata, hatamesajlari As String
        durumlabel.Text = ""
        hata = "0"

        ' KONTROL ET ---------------------------
        If DropDownList6.SelectedValue = "0" Then
            DropDownList6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Başlıkları göstermek istediğiniz ana menüyü seçmediniz.<br/>"
        End If

        If hata = "1" Then
            durumlabelarama.Text = javascript.alert_istedigimyere("validationresult2", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            HttpContext.Current.Session("ltip") = "sadecebaba"
            HttpContext.Current.Session("anamenupkey") = DropDownList6.SelectedValue
            Label1.Text = menu_erisim.listele()
        End If

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim hata, hatamesajlari As String
        durumlabel.Text = ""
        hata = "0"

        'ana menu seçilmiş mi
        If DropDownList7.SelectedValue = "0" Then
            DropDownList7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Alt başlıklarını göstermek istediğiniz ana menüyü seçmediniz.<br/>"
        End If

        'başlık seçilmiş mi
        If Request.Form("DropDownList8") = "0" Or Request.Form("DropDownList8") = Nothing Then
            DropDownList8.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Alt başlıklarını göstermek istediğiniz ana başlığı seçmediniz.<br/>"
        End If

        If hata = "1" Then
            durumlabelarama.Text = javascript.alert_istedigimyere("validationresult2", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            HttpContext.Current.Session("ltip") = "altbaslik"
            HttpContext.Current.Session("anamenupkey") = DropDownList7.SelectedValue
            HttpContext.Current.Session("babaid") = Request.Form("DropDownList8")
            Label1.Text = menu_erisim.listele()
        End If


    End Sub
End Class