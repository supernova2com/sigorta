Imports System.Web.Script.Serialization
Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class arackayittest
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then
            Textbox1.Focus()
        End If 'postback


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim ci As CultureInfo = New CultureInfo("de-DE")
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim hata As String
        Dim hatamesajlari As String

        durumlabel.Text = ""
        hata = "0"

        If Len(Textbox1.Text) < 3 Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Plakayı girmediniz.<br/>"
        End If


        If hata = "0" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        If hata = "0" Then

            Try
                Dim arackayitdaire As New CLASSARACKAYITDAIRE
                Dim js As New JavaScriptSerializer()
                Dim arackayitcevap As String
                Dim AracKayitServis As New AracKayitServis.AracBilgisiServiceClient
                arackayitcevap = AracKayitServis.PlakayaGoreAracBilgisiGetir(Textbox1.Text)

                If Len(arackayitcevap) > 0 Then
                    arackayitcevap = Replace(arackayitcevap, ".", "")
                End If

                arackayitdaire = js.Deserialize(Of CLASSARACKAYITDAIRE)(arackayitcevap)
                durumlabel.Text = javascript.alert("Servis Çalışıyor", "success", "10", "success")

                Labelserviscevap.Text = "Plaka No: " + arackayitdaire.PlakaNo + "<br/>" + _
                "Kategori Kodu: " + CStr(arackayitdaire.KatKod) + "<br/>" + _
                "Marka: " + arackayitdaire.Marka + "<br/>" + _
                "Model: " + CStr(arackayitdaire.Model) + "<br/>" + _
                "Motor Gücü: " + CStr(arackayitdaire.MotorGuc) + "<br/>" + _
                "Tipi: " + arackayitdaire.Tip + "<br/>"

            Catch ex As Exception
                durumlabel.Text = javascript.alert(ex.Message, "danger", 10, "warning")
            End Try



        End If 'hata =0



    End Sub

End Class