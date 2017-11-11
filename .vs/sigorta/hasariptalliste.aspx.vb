Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class hasariptalliste
    Inherits System.Web.UI.Page

    Dim rapor As New CLASSRAPOR
    Dim rapor_Erisim As New CLASSRAPOR_ERISIM

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim loggenel As New CLASSLOGGENEL
    Dim loggenel_Erisim As New CLASSLOGGENEL_ERISIM
    Dim damagecancel_Erisim As New CLASSDAMAGECANCEL_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasariptalliste", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            TextBox1.Text = DateTime.Now.ToShortDateString
            TextBox2.Text = DateTime.Now.ToShortDateString

            If Label2.Text = "" Then
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
        Dim iptalbaslangic, iptalbitis As Date
        Dim kayitbaslangic, kayitbitis As Date
        Dim neyegore As String

        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'iptal baslangictarih---------------------------
        If TextBox1.Text <> "" Then
            neyegore = "iptal"
            Try
                iptalbaslangic = TextBox1.Text
            Catch
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>İptal Başlangıç tarihini doğru girmediniz.</li>"
                TextBox1.Focus()
            End Try
        End If


        'iptal bitistarih---------------------------
        If TextBox2.Text <> "" Then
            neyegore = "iptal"
            Try
                iptalbitis = TextBox2.Text
            Catch
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
                TextBox2.Focus()
            End Try
        End If


        'kayit baslangictarih---------------------------
        If TextBox3.Text <> "" Then
            neyegore = "kayit"
            Try
                kayitbaslangic = TextBox3.Text
            Catch
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Kayıt Başlangıç tarihini doğru girmediniz.</li>"
                TextBox3.Focus()
            End Try
        End If


        'kayit bitistarih---------------------------
        If TextBox4.Text <> "" Then
            neyegore = "kayit"
            Try
                kayitbitis = TextBox4.Text
            Catch
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Kayıt Bitiş tarihini doğru girmediniz.</li>"
                TextBox4.Focus()
            End Try
        End If

        If (TextBox1.Text <> "" And TextBox2.Text = "") Or _
        (TextBox1.Text = "" And TextBox2.Text <> "") Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>İptal Başlangıç tarihini ve bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End If


        If (TextBox3.Text <> "" And TextBox4.Text = "") Or _
        (TextBox3.Text = "" And TextBox4.Text <> "") Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Kayıt Başlangıç tarihini ve bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End If



        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("neyegore") = neyegore
            HttpContext.Current.Session("iptalbaslangic") = iptalbaslangic
            HttpContext.Current.Session("iptalbitis") = iptalbitis
            HttpContext.Current.Session("kayitbaslangic") = kayitbaslangic
            HttpContext.Current.Session("kayitbitis") = kayitbitis

            rapor = damagecancel_Erisim.listele()
            Label2.Text = rapor.veri

            'EXPORT DÜĞMELERİ OLUŞTUR POLİÇE İÇİN
            If rapor.kacadet > 0 Then
                Buttonexcel.Visible = True
                Buttonpdf.Visible = True
                Buttonword.Visible = True
            Else
                Buttonexcel.Visible = False
                Buttonpdf.Visible = False
                Buttonword.Visible = False
            End If

        End If

    End Sub



    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = damagecancel_Erisim.listele
        rapor_Erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = damagecancel_Erisim.listele
        rapor_Erisim.yazdirword("ekran", rapor)
    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = damagecancel_Erisim.listele
        rapor_Erisim.yazdirpdf("ekran", rapor)
    End Sub



End Class