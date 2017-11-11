Public Partial Class dropdownlist
    Inherits System.Web.UI.Page



    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim dropdownlist As New CLASSDROPDOWNLIST
    Dim dropdownlist_erisim As New CLASSDROPDOWNLIST_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("dropdownlist", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then


            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))

            'TÜM TABLOLARI DOLDUR
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
            Dim tablolar As New List(Of CLASSVERITABANI)
            tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSVERITABANI In tablolar
                DropDownList1.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
            Next

            'TÜM GİRİLEN ÜLKELERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = dropdownlist_erisim.listele()




            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                dropdownlist = dropdownlist_erisim.bultek(Request.QueryString("pkey"))
                TextBox1.Text = dropdownlist.ad
                DropDownList1.SelectedValue = dropdownlist.tabload
                'TABLONUN KOLONLARINI DOLDUR---
                Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
                kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, dropdownlist.tabload)

                DropDownList2.Items.Clear()
                DropDownList3.Items.Clear()
                DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
                DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
                For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                    DropDownList2.Items.Add(New ListItem(item.column_name, item.column_name))
                    DropDownList3.Items.Add(New ListItem(item.column_name, item.column_name))
                Next
                DropDownList2.SelectedValue = dropdownlist.degerkolon
                DropDownList3.SelectedValue = dropdownlist.yazikolon

                TextBox2.Text = dropdownlist.sqlstropsiyonel
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                TextBox1.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                TextBox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If


    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String

        hata = "0"

        ' KONTROL ET ---------------------------
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Liste adı girilmelidir.<br/>"
        End If


        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Tablo adı seçilmelidir.<br/>"
        End If

        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Değer kolonunu seçmediniz.<br/>"
        End If


        If DropDownList3.SelectedValue = "0" Then
            DropDownList3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Yetki kolonunu seçmediniz.<br/>"
        End If


        If hata = "0" Then
            If TextBox2.Text <> "" Then
                'sql calisiyormu kontrol et 
                Dim sqlcalisiyormuresult As New CLADBOPRESULT
                sqlcalisiyormuresult = dropdownlist_erisim.sqlcalisiyormu(TextBox2.Text)
                If sqlcalisiyormuresult.durum <> "Kaydedildi" Then
                    TextBox2.Focus()
                    hata = "1"
                    hatamesajlari = hatamesajlari + "Yazdığınız sql düzgün çalışmıyor.<br/>" + _
                    sqlcalisiyormuresult.hatastr
                End If
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim dropdown_erisim As New CLASSDROPDOWNLIST_ERISIM

        Dim ulke As New CLASSULKE

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then

                dropdownlist.ad = TextBox1.Text
                dropdownlist.tabload = DropDownList1.SelectedValue
                dropdownlist.degerkolon = DropDownList2.SelectedValue
                dropdownlist.yazikolon = DropDownList3.SelectedValue
                dropdownlist.sqlstropsiyonel = TextBox2.Text
                result = dropdownlist_erisim.Ekle(dropdownlist)
            End If

            If Request.QueryString("op") = "duzenle" Then
                dropdownlist = dropdownlist_erisim.bultek(Request.QueryString("pkey"))
                dropdownlist.ad = TextBox1.Text
                dropdownlist.tabload = DropDownList1.SelectedValue
                dropdownlist.degerkolon = DropDownList2.SelectedValue
                dropdownlist.yazikolon = DropDownList3.SelectedValue
                dropdownlist.sqlstropsiyonel = TextBox2.Text
                result = dropdownlist_erisim.Duzenle(dropdownlist)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = dropdownlist_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim dropdownlist_erisim As New CLASSDROPDOWNLIST_ERISIM
        result = dropdownlist_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = dropdownlist_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("dropdownlist.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        Textbox1.Enabled = True
        TextBox2.Enabled = True

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        If DropDownList1.SelectedValue <> "0" Then


            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            DropDownList2.Items.Clear()
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList1.SelectedItem.Text)
            DropDownList2.Items.Clear()
            DropDownList3.Items.Clear()
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList2.Items.Add(New ListItem(item.column_name, item.column_name))
                DropDownList3.Items.Add(New ListItem(item.column_name, item.column_name))
            Next

            dropdownlist_erisim.otosqlolustur(DropDownList2.SelectedItem.Text, _
            DropDownList3.SelectedItem.Text, _
            DropDownList1.SelectedItem.Text)


            'TextBox2.Text = otosqlolustur(DropDownList1.SelectedValue)


        End If

    End Sub



End Class