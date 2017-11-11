Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class remindersetting
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If

        'eğer super admin değilse bu sayfayı göremesin
        If Session("kullanici_rolpkey") <> "2" Then
            Response.Redirect("yetkisiz.aspx")
        End If


        If Not Page.IsPostBack Then

            'ssl varmi
            DropDownList1.Items.Add(New ListItem("Aktif", "Aktif"))
            DropDownList1.Items.Add(New ListItem("Pasif", "Pasif"))

            'öncelik
            DropDownList2.Items.Add(New ListItem("Hayır", "Hayır"))
            DropDownList2.Items.Add(New ListItem("Evet", "Evet"))


          
            Dim remindersetting As New CLASSREMINDERSETTING
            Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM


            'TÜM GİRİLEN REMINDERSETTING BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = remindersetting_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Button1.Text = "Değişiklikleri Güncelle"
                remindersetting = remindersetting_erisim.bultek(Request.QueryString("pkey"))

                Textbox1.Text = remindersetting.reminder_name
                Textbox2.Text = remindersetting.reminder_schedule_minute
                Textbox3.Text = remindersetting.reminder_schedule_hour
                Textbox4.Text = remindersetting.reminder_schedule_day_of_month
                Textbox5.Text = remindersetting.reminder_schedule_month
                Textbox6.Text = remindersetting.reminder_schedule_weekday
                Textbox7.Text = remindersetting.reminder_schedule_end_date
                DropDownList1.SelectedValue = remindersetting.reminder_status
                DropDownList2.SelectedValue = remindersetting.ayinsongunucalissinmi

            End If

            If Request.QueryString("op") = "yenikayit" Then
                Textbox1.Focus()
            End If

            If Request.QueryString("op") = "" Then
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Textbox3.Enabled = False
                Textbox4.Enabled = False
                Textbox5.Enabled = False
                Textbox6.Enabled = False
                Textbox7.Enabled = False
                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False

            End If

        End If

    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim bitistarih As Date

        Dim hata, hatamesajlari As String
        Dim giristarih, islemtarih As Date

        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------


        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Zamanlama adını girmediniz.<br/>"
        End If

        'minute
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Dakikayı girmediniz.<br/>"
        End If

        'hour
        If Textbox3.Text = "" Then
            Textbox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Saati girmediniz.<br/>"
        End If


        'Ayın Hangi Günleri
        If Textbox4.Text = "" Then
            Textbox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Ayın hangi günlerini girmediniz.<br/>"
        End If


        'Yılın hangi Ayları
        If Textbox5.Text = "" Then
            Textbox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Yılın hangi aylarını girmediniz.<br/>"
        End If


        'Haftanın Hangi Günleri
        If Textbox6.Text = "" Then
            Textbox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Haftanın hangi günlerini girmediniz.<br/>"
        End If


        'bitistarih---------------------------
        Try
            bitistarih = Textbox7.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "Bitiş tarihini doğru girmediniz.<br/>"
            Textbox7.Focus()
        End Try


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
        Dim remindersetting As New CLASSREMINDERSETTING

        If hata = "0" Then

            remindersetting.reminder_name = Textbox1.Text
            remindersetting.reminder_schedule_minute = Textbox2.Text
            remindersetting.reminder_schedule_hour = Textbox3.Text
            remindersetting.reminder_schedule_day_of_month = Textbox4.Text
            remindersetting.reminder_schedule_month = Textbox5.Text
            remindersetting.reminder_schedule_weekday = Textbox6.Text
            remindersetting.reminder_schedule_end_date = Textbox7.Text
            remindersetting.reminder_status = DropDownList1.SelectedValue
            remindersetting.ayinsongunucalissinmi = DropDownList2.SelectedValue
            remindersetting.reminder_date_added = DateTime.Now


            If Request.QueryString("op") = "yenikayit" Then
                result = remindersetting_erisim.Ekle(remindersetting)
            End If

            If Request.QueryString("op") = "duzenle" Then

                remindersetting = remindersetting_erisim.bultek(Request.QueryString("pkey"))
                remindersetting.reminder_name = Textbox1.Text
                remindersetting.reminder_schedule_minute = Textbox2.Text
                remindersetting.reminder_schedule_hour = Textbox3.Text
                remindersetting.reminder_schedule_day_of_month = Textbox4.Text
                remindersetting.reminder_schedule_month = Textbox5.Text
                remindersetting.reminder_schedule_weekday = Textbox6.Text
                remindersetting.reminder_schedule_end_date = Textbox7.Text
                remindersetting.reminder_status = DropDownList1.SelectedValue
                remindersetting.ayinsongunucalissinmi = DropDownList2.SelectedValue

                result = remindersetting_erisim.Duzenle(remindersetting)
            End If

            durumlabel.Text = javascript.alertresult(result)
            Label1.Text = remindersetting_erisim.listele()

        End If

    End Sub


    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
        result = remindersetting_erisim.Sil(Request.QueryString("pkey"))

        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = remindersetting_erisim.listele()
        durumlabel.Text = javascript.alertresult(result)

    End Sub


    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("remindersetting.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub


End Class