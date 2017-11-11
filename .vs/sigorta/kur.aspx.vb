Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class kur
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim kur_erisim As New CLASSKUR_ERISIM

    'yetkiler icin 
    Dim tabload As String = "kur"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("kur", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            TextBox1.Text = DateTime.Now.ToShortDateString
            TextBox2.Text = DateTime.Now.ToShortDateString
            TextBox3.Text = DateTime.Now.ToShortDateString
            TextBox4.Text = DateTime.Now.ToShortDateString

            HttpContext.Current.Session("baslangic") = DateTime.Now.ToShortDateString
            HttpContext.Current.Session("bitis") = DateTime.Now.ToShortDateString

            Label1.Text = kur_erisim.listele

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        If yetki.updateyetki = "Hayır" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
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
            baslangic = TextBox3.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Başlangıç tarihini doğru girmediniz.<br/>"
            TextBox3.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitis = TextBox4.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Bitiş tarihini doğru girmediniz.<br/>"
            TextBox4.Focus()
        End Try


        If hata = "0" Then
            If baslangic > bitis Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Başlangıç tarihi bitiş tarihinden " + _
                "büyük olmamalıdır.<br/>"
                TextBox4.Focus()
            End If
        End If

        If hata = "0" Then
            If baslangic.DayOfWeek = DayOfWeek.Saturday Or _
            baslangic.DayOfWeek = DayOfWeek.Sunday Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Başlangıç tarihi haftasonu olmamalıdır.<br/>"
                TextBox3.Focus()
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            kur_erisim.kurcekmerkezbankasindan(baslangic, bitis)
            durumlabel.Text = javascript.alert("Kurlar Başarılı" + _
            " Bir Şekilde Merkez Bankasından Çekildi.", "success", 10, "check")
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
            hatamesajlari = hatamesajlari + "Başlangıç tarihini doğru girmediniz.<br/>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitis = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Bitiş tarihini doğru girmediniz.<br/>"
            TextBox2.Focus()
        End Try


        If hata = "0" Then
            If baslangic > bitis Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Başlangıç tarihi bitiş tarihinden " + _
                "büyük olmamalıdır.<br/>"
                TextBox1.Focus()
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("baslangic") = baslangic
            HttpContext.Current.Session("bitis") = bitis
            Label1.Text = kur_erisim.listele()

        End If


    End Sub


End Class