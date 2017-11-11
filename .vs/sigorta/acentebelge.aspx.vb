Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class acentebelge
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("acentebelge", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            Dim t As Date
            t = Date.Now
            TextBox2.Text = t.ToString("dd.MM.yyyy")

            'Dim acente_erisim As New CLASSACENTE_ERISIM
            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = acente_erisim.listelebelgeicin

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        'verildigi tarih kontrol et
        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, kayittarih As Date
        Dim hata As String = 0
        Dim verildigitarih As Date
        Try
            verildigitarih = TextBox2.Text
        Catch
            hata = "1"
            Label1.Text = "<div class='alert alert-danger'>" + _
            "Verildiği tarihi düzgün giriniz." + _
            "</div>"
            TextBox2.Focus()
        End Try


        If hata = "0" Then

            Dim tumacenteler As New List(Of CLASSACENTE)
            Dim acente_erisim As New CLASSACENTE_ERISIM
            Dim inp As String
            Dim secim As String

            Dim acentepkeystring As String = ""
            tumacenteler = acente_erisim.doldur()

            For Each acenteitem As CLASSACENTE In tumacenteler

                inp = "A_" + CStr(acenteitem.pkey)
                secim = Request.Form(inp)
                If secim = "on" Then
                    acentepkeystring = acentepkeystring + CStr(acenteitem.pkey) + ","
                End If
            Next

            If Len(acentepkeystring) <= 0 Then
                Labeluyari.Text = "<div class='alert alert-danger'>" + _
                "Belgesini yazdırmak için herhangi bir kayıt seçmediniz." + _
                "</div>"
            End If

            If Len(acentepkeystring) > 0 Then
                acentepkeystring = Mid(acentepkeystring, 1, Len(acentepkeystring) - 1)
                acente_erisim.belgeolustur(acentepkeystring, verildigitarih)
            End If


        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click


        'verildigi tarih kontrol et
        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, kayittarih As Date
        Dim hata As String = 0
        Dim verildigitarih As Date
        Try
            verildigitarih = TextBox2.Text
        Catch
            hata = "1"
            Label1.Text = "<div class='alert alert-danger'>" + _
            "Verildiği tarihi düzgün giriniz." + _
            "</div>"
            TextBox2.Focus()
        End Try


        If hata = "0" Then

            Dim tumacenteler As New List(Of CLASSACENTE)
            Dim acente_erisim As New CLASSACENTE_ERISIM


            Dim acentepkeystring As String = ""
            tumacenteler = acente_erisim.doldur()

            For Each acenteitem As CLASSACENTE In tumacenteler
                acentepkeystring = acentepkeystring + CStr(acenteitem.pkey) + ","
            Next

            If Len(acentepkeystring) > 0 Then
                acentepkeystring = Mid(acentepkeystring, 1, Len(acentepkeystring) - 1)
                acente_erisim.belgeolustur(acentepkeystring, verildigitarih)
            End If

        End If


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim acente_erisim As New CLASSACENTE_ERISIM
        HttpContext.Current.Session("ltip") = "acentead"
        HttpContext.Current.Session("acentead") = TextBox1.Text
        Label1.Text = acente_erisim.listelebelgeicin

    End Sub
End Class