Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class faturarapor
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim ozelrapor_erisim As New CLASSOZELRAPOR_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("faturarapor", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'YILLARI DOLDUR
            Dim simdikiyil As Integer
            simdikiyil = DateTime.Now.Year
            For i = simdikiyil To 2002 Step -1
                DropDownList3.Items.Add(New ListItem(CStr(i), CStr(i)))
            Next

            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList2.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
                DropDownList2.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            TextBox1.Text = "01.01.2012"
            TextBox2.Text = DateTime.Now.ToShortDateString


            TextBox3.Text = "01.01.2012"
            TextBox4.Text = DateTime.Now.ToShortDateString

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        If hata = "1" Then
            durumlabel.Text = javascript.alert_istedigimyere("validationresult", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "1"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("sirketpkey") = DropDownList1.SelectedValue
            Response.Redirect("ozelraporyazdir.aspx")

        End If


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih----------------------
        Try
            baslangictarih = TextBox3.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox3.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox4.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox4.Focus()
        End Try

        If hata = "1" Then
            durumlabel2.Text = javascript.alert_istedigimyere("validationresult2", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "2"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            Response.Redirect("ozelraporyazdir.aspx")

        End If

    End Sub

   


    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        If hata = "1" Then
            durumlabel.Text = javascript.alert_istedigimyere("validationresult", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "10"
            HttpContext.Current.Session("sirketpkey") = DropDownList2.SelectedValue
            HttpContext.Current.Session("yil") = DropDownList3.SelectedValue
            Response.Redirect("ozelraporyazdir.aspx")

        End If

    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        If hata = "1" Then
            durumlabel.Text = javascript.alert_istedigimyere("validationresult", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "11"
            HttpContext.Current.Session("sirketpkey") = DropDownList2.SelectedValue
            HttpContext.Current.Session("yil") = DropDownList3.SelectedValue
            Response.Redirect("ozelraporyazdir.aspx")

        End If

    End Sub
End Class