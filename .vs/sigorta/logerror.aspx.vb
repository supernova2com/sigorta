Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class logerror
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim rapor_erisim As New CLASSRAPOR_ERISIM
    Dim errorlog_erisim As New CLASSERRORLOG_ERISIM


    'yetkiler icin 
    Dim tabload As String = "vtablo"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'KULLANICILARI DOLDUR---------------------------------------
            DropDownList3.Items.Add(New ListItem("Tümü", "0"))
            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur()
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList3.Items.Add(New ListItem(item.adsoyad, CStr(item.pkey)))
            Next

      
            TextBox1.Text = DateTime.Now.ToShortDateString
            TextBox2.Text = DateTime.Now.ToShortDateString

            If Label1.Text = "" Then
                Buttonexcel.Visible = False
                Buttonpdf.Visible = False
                Buttonword.Visible = False
            End If
        End If


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)

        If yetki.readyetki = "Hayır" Then
            Label1.Visible = False
        Else
            Label1.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------


    End Sub


    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = errorlog_erisim.listele()
        rapor_erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = errorlog_erisim.listele()
        rapor_erisim.yazdirword("ekran", rapor)
    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = errorlog_erisim.listele()
        rapor_erisim.yazdirpdf("ekran", rapor)
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

            HttpContext.Current.Session("baslangic") = baslangic
            HttpContext.Current.Session("bitis") = bitis
            HttpContext.Current.Session("kullanici") = DropDownList3.SelectedValue

            rapor = errorlog_erisim.listele()
            Label1.Text = rapor.veri

            Buttonpdf.Visible = True
            Buttonexcel.Visible = True
            Buttonword.Visible = True

        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click


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

            HttpContext.Current.Session("baslangic") = baslangic
            HttpContext.Current.Session("bitis") = bitis
            HttpContext.Current.Session("kullanici") = DropDownList3.SelectedValue

            Label1.Text = errorlog_erisim.listeleislemicin()

            Buttonpdf.Visible = False
            Buttonexcel.Visible = False
            Buttonword.Visible = False

        End If
    End Sub
End Class