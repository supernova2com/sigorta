Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class log
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim rapor_erisim As New CLASSRAPOR_ERISIM
    Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("log", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then


            'ORTAM DOLDUR---------------------------------------
            DropDownList5.Items.Add(New ListItem("Tümü", "0"))
            DropDownList5.Items.Add(New ListItem("Web", "Web"))
            DropDownList5.Items.Add(New ListItem("Mobil", "Mobil"))


            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            'ACENTELERİ DOLDUR---------------------------------------
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim acente_erisim As New CLASSACENTE_ERISIM
            Dim acenteler As New List(Of CLASSACENTE)
            acenteler = acente_erisim.doldur()
            For Each item As CLASSACENTE In acenteler
                DropDownList2.Items.Add(New ListItem(item.acentead, CStr(item.pkey)))
            Next

            'KULLANICILARI DOLDUR---------------------------------------
            DropDownList3.Items.Add(New ListItem("Tümü", "0"))
            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur()
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList3.Items.Add(New ListItem(item.adsoyad, CStr(item.pkey)))
            Next

            'İŞLEMLERİ DOLDUR-----------------------------------------
            DropDownList4.Items.Add(New ListItem("Tümü", "0"))
            DropDownList4.Items.Add(New ListItem("Giriş", "Giriş"))
            DropDownList4.Items.Add(New ListItem("Hatalı Giriş", "Hatalı Giriş"))
            DropDownList4.Items.Add(New ListItem("Şifre Değişikliği", "Şifre Değişikliği"))
            DropDownList4.Items.Add(New ListItem("Arama", "Arama"))
            DropDownList4.Items.Add(New ListItem("Hasar İptal Silme", "Hasar İptal Silme"))


            TextBox1.Text = DateTime.Now.ToShortDateString
            TextBox2.Text = DateTime.Now.ToShortDateString

            If Label1.Text = "" Then
                Buttonexcel.Visible = False
                Buttonpdf.Visible = False
                Buttonword.Visible = False
            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangic, bitis As Date

        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangic = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'baslangictarih---------------------------
        Try
            bitis = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("ortam") = DropDownList5.SelectedValue
            HttpContext.Current.Session("baslangic") = baslangic
            HttpContext.Current.Session("bitis") = bitis
            HttpContext.Current.Session("sirket") = DropDownList1.SelectedValue
            HttpContext.Current.Session("acente") = DropDownList2.SelectedValue
            HttpContext.Current.Session("kullanici") = DropDownList3.SelectedValue
            HttpContext.Current.Session("islem") = DropDownList4.SelectedValue
            rapor = loggenel_erisim.listele()
            Label1.Text = rapor.veri

            Buttonpdf.Visible = True
            Buttonexcel.Visible = True
            Buttonword.Visible = True

        End If

    End Sub


    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = loggenel_erisim.listele()
        rapor_erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = loggenel_erisim.listele()
        rapor_erisim.yazdirword("ekran", rapor)
    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = loggenel_erisim.listele()
        rapor_erisim.yazdirpdf("ekran", rapor)
    End Sub



End Class