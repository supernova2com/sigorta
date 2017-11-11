Public Partial Class tablobag
    Inherits System.Web.UI.Page

    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim tablobag As New CLASSTABLOBAG
    Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
    Dim site As New CLASSSITE
    Dim site_erisim As New CLASSSITE_ERISIM

    Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
    Dim tablolar As New List(Of CLASSVERITABANI)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("tablobag", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'VERİTABANI TABLOLARINI DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList3.Items.Add(New ListItem("Seçiniz", "0"))

            site = site_erisim.bultek(1)
   
            tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
            For Each item As CLASSVERITABANI In tablolar
                DropDownList1.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
                DropDownList3.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
            Next

            'TÜM GİRİLEN TABLO BAĞLARINI LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tablobag_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                tablobag = tablobag_erisim.bultek(Request.QueryString("pkey"))


                DropDownList1.SelectedValue = tablobag.tabload1
                Dim site As New CLASSSITE
                Dim site_erisim As New CLASSSITE_ERISIM
                site = site_erisim.bultek(1)
                Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
                kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, tablobag.tabload1)
                For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                    DropDownList2.Items.Add(New ListItem(item.column_name, item.column_name))
                Next
                DropDownList2.SelectedValue = tablobag.tablofield1
                DropDownList3.SelectedValue = tablobag.tabload2  
                kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, tablobag.tabload2)
                For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                    DropDownList4.Items.Add(New ListItem(item.column_name, item.column_name))
                Next
                DropDownList4.SelectedValue = tablobag.tablofield2
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                DropDownList1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                DropDownList3.Enabled = False
                DropDownList4.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String

        hata = "0"

        ' KONTROL ET -----------------------------------------
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Ana Tabloyu seçmediniz.</li>"
        End If

        If DropDownList4.SelectedValue = "0" Then
            DropDownList4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Detay Tabloyu seçmediniz.</li>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
        Dim tablobag As New CLASSTABLOBAG

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                tablobag.tabload1 = DropDownList1.SelectedValue
                tablobag.tablofield1 = DropDownList2.SelectedValue
                tablobag.tabload2 = DropDownList3.SelectedValue
                tablobag.tablofield2 = DropDownList4.SelectedValue
                result = tablobag_erisim.Ekle(tablobag)
            End If

            If Request.QueryString("op") = "duzenle" Then
                tablobag = tablobag_erisim.bultek(Request.QueryString("pkey"))
                tablobag.tabload1 = DropDownList1.SelectedValue
                tablobag.tablofield1 = DropDownList2.SelectedValue
                tablobag.tabload2 = DropDownList3.SelectedValue
                tablobag.tablofield2 = DropDownList4.SelectedValue
                result = tablobag_erisim.Duzenle(tablobag)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tablobag_erisim.listele()

        End If

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
        result = tablobag_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = tablobag_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub

    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("tablobag.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        DropDownList1.Enabled = False
        DropDownList2.Enabled = False
        DropDownList3.Enabled = False
        DropDownList4.Enabled = False

    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        If DropDownList1.SelectedValue <> "0" Then
            DropDownList2.Items.Clear()
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList1.SelectedItem.Text)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList2.Items.Add(New ListItem(item.column_name, item.column_name))
            Next
        End If

    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList3.SelectedIndexChanged

        If DropDownList3.SelectedValue <> "0" Then
            DropDownList4.Items.Clear()
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList3.SelectedItem.Text)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList4.Items.Add(New ListItem(item.column_name, item.column_name))
            Next
        End If
    End Sub
End Class