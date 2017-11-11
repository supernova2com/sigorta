Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class dosya
    Inherits System.Web.UI.Page

    Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
    Dim dosya As New CLASSDOSYA
    Dim dosya_erisim As New CLASSDOSYA_ERISIM
    Dim javascript As New CLASSJAVASCRIPT
    Dim resultset As New CLADBOPRESULT

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_Erisim.busayfayigormeyeyetkilimi("dosya", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            'KULLANICILARI DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur_benimdisimda_dosyaicin
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList1.Items.Add(New ListItem(item.adsoyad, CStr(item.pkey)))
            Next

            'GELEN DOSYALARIMI LİSTELE
            Label1.Text = dosya_erisim.gelendosyalarim(Session("kullanici_pkey"))

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim filesize As Double
        Dim x As System.DBNull
        Dim hata, hatatxt As String
        Dim contype, filename As String
        Dim hatamesajlari As String

        hata = "0"

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci

        If DropDownList1.SelectedValue = "0" Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Göndermek istediğiniz kişiyi seçmediniz.</li>"
        End If


        If Textbox1.Text = "" Then
            hata = "1"
            hatatxt = hatamesajlari + "Dosya konusunu yazmadınız." + "<br/>"
            Textbox1.Focus()
        End If


        If FileUpload1.HasFile = False Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Göndermek istediğiniz dosyayı seçmediniz.</li>"
        End If

        'DOSYANIN BÜYÜKLÜĞÜNÜ KONTROL EDİYORUZ-----------------------------
        If FileUpload1.HasFile = True Then
            filesize = FileUpload1.PostedFile.ContentLength
            If filesize > 10000000 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Göndereceğiniz dosya 10 MB 'dan büyük olamaz. Lütfen Daha küçük bir dosya seçiniz."
            End If
        End If

        'ilgili kullanıcıya mesaj gönderme yetkisi var mı kontrol et!!
        If hata = "0" Then
            'sadece seçtiğim kullanıcıya
            Dim kullanicirol As New CLASSKULLANICIROL
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
            kullanicirol = kullanicirol_erisim.bultek(Session("kullanici_rolpkey"))
            If kullanicirol.sadecesirketicidosyagonderimi = "Evet" Then
                Dim kimekullanicipkey As String
                kimekullanicipkey = Request.Form("DropDownList1")
                Dim kimekullanici As New CLASSKULLANICI
                kimekullanici = kullanici_Erisim.bultek(kimekullanicipkey)
                'eğer admin değilse
                If kimekullanici.rolpkey <> 1 Then
                    If kimekullanici.sirketpkey <> Session("kullanici_sirketpkey") Then
                        DropDownList1.Focus()
                        hata = "1"
                        hatamesajlari = hatamesajlari + "Sadece kendi şirketiniz içinde" + _
                        " dosya alışverişi yapabilirsiniz.<br/>"
                    End If
                End If
            End If 'sadece sirket içi mesajlasma
        End If 'hata=0

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If


        If hata = "0" Then

            If FileUpload1.HasFile = True Then
                dosya.contype = FileUpload1.PostedFile.ContentType.ToString
                dosya.filesize = FileUpload1.PostedFile.ContentLength
                dosya.filename = dosya_erisim.dosyaadbul(FileUpload1.PostedFile.FileName)
            End If

            dosya.gonderenpkey = Session("kullanici_pkey")
            dosya.alanpkey = DropDownList1.SelectedValue
            dosya.msgkonu = Textbox1.Text
            dosya.gondermetarih = DateTime.Now
            dosya.okunmusmu = "Hayır"
            dosya.gonderensilmismi = "Hayır"
            dosya.alansilmismi = "Hayır"

            Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
            FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

            dosya.fileg = imageBytes

            resultset = dosya_erisim.Ekle(dosya)
            durumlabel.Text = javascript.alertresult(resultset)

        End If


    End Sub
End Class