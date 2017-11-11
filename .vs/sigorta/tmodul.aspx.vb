Public Partial Class tmodul
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM
    Dim site As New CLASSSITE
    Dim site_erisim As New CLASSSITE_ERISIM

    Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
    Dim tablolar As New List(Of CLASSVERITABANI)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("tmodul", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            site = site_erisim.bultek(1)

            'VERİTABANI TABLOLARINI DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
            For Each item As CLASSVERITABANI In tablolar
                DropDownList1.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
            Next

            'TÜM GİRİLEN MODÜLLERİ LİSTELE
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tmodul_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"

                tmodul = tmodul_erisim.bultek(Request.QueryString("pkey"))

                DropDownList1.SelectedValue = tmodul.tabload
                TextBox1.Text = tmodul.ad
                TextBox3.Text = tmodul.aciklama

            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                TextBox1.Focus()
            End If

            If Request.QueryString("op") = "" Then

                DropDownList1.Enabled = False
                TextBox1.Enabled = False
                TextBox3.Enabled = False
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
            hatamesajlari = hatamesajlari + "<li>Tabloyu seçmediniz.</li>"
        End If

        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Modül adını girmediniz.</li>"
        End If

        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Açıklamayı girmediniz.</li>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim tmodul_erisim As New CLASSTMODUL_ERISIM
        Dim tmodul As New CLASSTMODUL

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                tmodul.tabload = DropDownList1.SelectedValue
                tmodul.ad = TextBox1.Text
                tmodul.aciklama = TextBox3.Text
                result = tmodul_erisim.Ekle(tmodul)
            End If

            If Request.QueryString("op") = "duzenle" Then
                tmodul = tmodul_erisim.bultek(Request.QueryString("pkey"))
                tmodul.tabload = DropDownList1.SelectedValue
                tmodul.ad = TextBox1.Text
                tmodul.aciklama = TextBox3.Text
                result = tmodul_erisim.Duzenle(tmodul)
            End If

            durumlabel.Text = javascript.alertresult(result)

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = tmodul_erisim.listele()

        End If

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim tmodul_erisim As New CLASSTMODUL_ERISIM
        result = tmodul_erisim.Sil(Request.QueryString("pkey"))
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = tmodul_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub

    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("tmodul.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        DropDownList1.Enabled = False
        DropDownList1.Enabled = False
   
    End Sub



End Class