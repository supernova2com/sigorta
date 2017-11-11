Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class emailayar
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("ayar", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        DropDownList1.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")

        If Not Page.IsPostBack Then

            'EĞER EMAIL AYAR KAYDI VARSA BAŞKA KAYIT EKLEMESINE İZİN VERME!!
            Dim kackayit As Integer
            kackayit = emailayar_erisim.kayitsayisibul
            If kackayit > 0 Then
                Buttonyenikayit.Enabled = False
            End If
            '----------------------------------------------


            'ssl varmi
            DropDownList6.Items.Add(New ListItem("True", "True"))
            DropDownList6.Items.Add(New ListItem("False", "False"))

            'öncelik
            DropDownList1.Items.Add(New ListItem("High", "2"))
            DropDownList1.Items.Add(New ListItem("Low", "1"))
            DropDownList1.Items.Add(New ListItem("Normal", "0"))

            'use default credentials varmi
            DropDownList7.Items.Add(New ListItem("True", "True"))
            DropDownList7.Items.Add(New ListItem("False", "False"))

            'udc kullanılsın mı ?
            DropDownList4.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList4.Items.Add(New ListItem("Hayır", "Hayır"))

            'deleverymethod
            DropDownList3.Items.Add(New ListItem("SmtpDeliveryMethod.Network", "0"))
            DropDownList3.Items.Add(New ListItem("SmtpDeliveryMethod.PickupDirectoryFromIis", "2"))
            DropDownList3.Items.Add(New ListItem("SmtpDeliveryMethod.SpecifiedPickupDirectory", "1"))

            Dim emailayar As New CLASSEMAILAYAR

            'TÜM GİRİLEN emailayarLERİ BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = emailayar_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Button1.Text = "Değişiklikleri Güncelle"
                emailayar = emailayar_erisim.bul(Request.QueryString("pkey"))
                Textbox12.Text = emailayar.username
                Textbox6.Text = emailayar.password
                Textbox2.Text = emailayar.portnumber
                DropDownList6.SelectedValue = emailayar.sslvarmi
                DropDownList1.SelectedValue = emailayar.oncelik
                Textbox7.Text = emailayar.pickupdirectorylocation
                Textbox13.Text = emailayar.hostname
                DropDownList7.SelectedValue = emailayar.usedefaultcredentials
                DropDownList3.SelectedValue = emailayar.deliverymethod
                DropDownList4.SelectedValue = emailayar.udckullan
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Textbox12.Focus()
            End If

            If Request.QueryString("op") = "" Then
                DropDownList1.Enabled = False
                DropDownList6.Enabled = False
                DropDownList3.Enabled = False
                Textbox2.Enabled = False
                Textbox6.Enabled = False
                Textbox12.Enabled = False
                Textbox7.Enabled = False
                DropDownList7.Enabled = False
                DropDownList4.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False

            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String
        Dim giristarih, islemtarih As Date

        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------

        'username
        If Textbox12.Text = "" Then
            Textbox12.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Username girmediniz.<br/>"
        End If

        'password
        If Textbox6.Text = "" Then
            Textbox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Password girmediniz.<br/>"
        End If

        'portnumber
        If (Textbox2.Text = "") Or (Not (IsNumeric(Textbox2.Text) = True)) Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Port number rakamsal olmalıdır.<br/>"
        End If

        'pickup directory location
        If Textbox7.Text = "" Then
            Textbox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Pick up directory location'ı girmediniz.<br/>"
        End If

        'hostname
        If Textbox13.Text = "" Then
            Textbox13.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Hostname girmediniz.<br/>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
        Dim emailayar As New CLASSEMAILAYAR

        If hata = "0" Then

            emailayar.username = Textbox12.Text
            emailayar.password = Textbox6.Text
            emailayar.portnumber = Textbox2.Text
            emailayar.sslvarmi = DropDownList6.SelectedValue
            emailayar.oncelik = DropDownList1.SelectedValue
            emailayar.pickupdirectorylocation = Textbox7.Text
            emailayar.hostname = Textbox13.Text
            emailayar.usedefaultcredentials = DropDownList7.SelectedValue
            emailayar.deliverymethod = DropDownList3.SelectedValue
            emailayar.udckullan = DropDownList4.SelectedValue

            If Request.QueryString("op") = "yenikayit" Then
                result = emailayar_erisim.ekle(emailayar)
            End If

            If Request.QueryString("op") = "duzenle" Then

                emailayar = emailayar_erisim.bul(Request.QueryString("pkey"))

                emailayar.username = Textbox12.Text
                emailayar.password = Textbox6.Text
                emailayar.portnumber = Textbox2.Text
                emailayar.sslvarmi = DropDownList6.SelectedValue
                emailayar.oncelik = DropDownList1.SelectedValue
                emailayar.pickupdirectorylocation = Textbox7.Text
                emailayar.hostname = Textbox13.Text
                emailayar.usedefaultcredentials = DropDownList7.SelectedValue
                emailayar.deliverymethod = DropDownList3.SelectedValue
                emailayar.udckullan = DropDownList4.SelectedValue

                result = emailayar_erisim.guncelle(emailayar)
            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = emailayar_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click


        Response.Redirect("emailayar.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click


        result = emailayar_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)
        Label1.Text = emailayar_erisim.listele()

    End Sub




    Protected Sub Buttontest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttontest.Click

        Dim hata, hatamesajlari As String
        hata = "0"

        'eposta kontrol et
        If System.Text.RegularExpressions.Regex.IsMatch(Textboxeposta.Text, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") = False Then
            hata = "1"
            Textboxeposta.Focus()
            hatamesajlari = hatamesajlari + "E-Mail adresini doğru giriniz."
        End If

        If hata = "1" Then
            Label2.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
        Dim emailayar As New CLASSEMAILAYAR

        If hata = "0" Then

            emailayar = emailayar_erisim.bul(1)
            Dim email As New CLASSEMAIL
            Dim email_erisim As New CLASSEMAIL_ERISIM

            email.subject = "Test"
            email.body = "Test E-Mail"
            email.kimden = emailayar.username
            email.kime = Textboxeposta.Text
            result = email_erisim.gonder(email)
            Label2.Text = javascript.alertresult(result)

        End If

    End Sub
End Class