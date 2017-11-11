Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class policearasirket
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim loggenel As New CLASSLOGGENEL
    Dim loggenel_Erisim As New CLASSLOGGENEL_ERISIM
    Dim PolicyInfo_Erisim As New PolicyInfo_Erisim
    Dim DamageInfo_Erisim As New DamageInfo_Erisim
    Dim rapor1 As New CLASSRAPOR
    Dim rapor2 As New CLASSRAPOR
    Dim rapor_erisim As New CLASSRAPOR_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("policearasirket", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            TextBox10.Focus()


            If HttpContext.Current.Session("plakano") <> "" Then
                HttpContext.Current.Session("plaka") = HttpContext.Current.Session("plakano")
                TextBox10.Text = HttpContext.Current.Session("plakano")
                rapor1 = PolicyInfo_Erisim.listele_sirketicin
                Label1.Text = rapor1.veri
                rapor2 = DamageInfo_Erisim.listele_sirketicin()
                Label2.Text = rapor2.veri
            End If

            'aktif şirket seçilmemişse döndür.
            If kullanici_erisim.aktifsirketsecilmismi = "Hayır" Then
                Response.Redirect("profile.aspx")
            End If

            If Label1.Text = "" Then
                Buttonexcelpolice.Visible = False
                Buttonpdfpolice.Visible = False
                Buttonwordpolice.Visible = False

                Buttonexcelhasar.Visible = False
                Buttonpdfhasar.Visible = False
                Buttonwordhasar.Visible = False

                policebaslik.Visible = False
                hasarbaslik.Visible = False


            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


        policebaslik.Visible = True
        hasarbaslik.Visible = True

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangic, bitis As Date

        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        If TextBox7.Text = "" And TextBox8.Text = "" And _
        Len(TextBox9.Text) < 3 And Len(TextBox10.Text) < 4 Then
            hata = "1"
            hatamesajlari = hatamesajlari + "Herhangi bir arama kriteri girmediniz. Kimlik en az 3, Plaka en az 4 karakter olmalıdır."
            TextBox7.Focus()
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("sorgulamatarih") = DateTime.Now
            HttpContext.Current.Session("ad") = TextBox7.Text
            HttpContext.Current.Session("soyad") = TextBox8.Text
            HttpContext.Current.Session("kimlik") = TextBox9.Text
            HttpContext.Current.Session("plaka") = TextBox10.Text

            rapor1 = PolicyInfo_Erisim.listele_sirketicin
            Label1.Text = rapor1.veri

            'EXPORT DÜĞMELERİ OLUŞTUR POLİÇE İÇİN
            If rapor1.kacadet > 0 Then
                Buttonexcelpolice.Visible = True
                Buttonpdfpolice.Visible = True
                Buttonwordpolice.Visible = True
            Else
                Buttonexcelpolice.Visible = False
                Buttonpdfpolice.Visible = False
                Buttonwordpolice.Visible = False
            End If

            '---LOGLA
            Dim aramakriteri As String
            aramakriteri = TextBox7.Text + "," + TextBox8.Text + "," + TextBox9.Text + "," + TextBox10.Text
            loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", "PolicyInfo", _
            "Arama", "", aramakriteri, 0, "Hayır", "", "", "Web")
            loggenel_Erisim.Ekle(loggenel)


            rapor2 = DamageInfo_Erisim.listele_sirketicin()
            Label2.Text = rapor2.veri


            'EXPORT DÜĞMELERİ OLUŞTUR HASAR İÇİN
            If rapor2.kacadet > 0 Then
                Buttonexcelhasar.Visible = True
                Buttonpdfhasar.Visible = True
                Buttonwordhasar.Visible = True
            Else
                Buttonexcelhasar.Visible = False
                Buttonpdfhasar.Visible = False
                Buttonwordhasar.Visible = False
            End If

        End If

    End Sub

    'POLİÇELER İÇİN EXPORT DÜĞMELERİ
    Protected Sub Buttonexcelpolice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcelpolice.Click
        rapor1 = PolicyInfo_Erisim.listele_sirketicin
        rapor_erisim.yazdirexcel("ekran", rapor1)
    End Sub

    Protected Sub Buttonwordpolice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonwordpolice.Click
        rapor1 = PolicyInfo_Erisim.listele_sirketicin
        rapor_erisim.yazdirword("ekran", rapor1)
    End Sub

    Protected Sub Buttonpdfpolice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdfpolice.Click
        rapor1 = PolicyInfo_Erisim.listele_sirketicin
        rapor_erisim.yazdirpdf("ekran", rapor1)
    End Sub


    'HASARLAR İÇİN EXPORT DÜĞMELERİ
    Protected Sub Buttonexcelhasar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcelhasar.Click
        rapor2 = DamageInfo_Erisim.listele_sirketicin
        rapor_erisim.yazdirexcel("ekran", rapor2)
    End Sub

    Protected Sub Buttonwordhasar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonwordhasar.Click
        rapor2 = DamageInfo_Erisim.listele_sirketicin
        rapor_erisim.yazdirword("ekran", rapor2)
    End Sub

    Protected Sub Buttonpdfhasar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdfhasar.Click
        rapor2 = DamageInfo_Erisim.listele_sirketicin
        rapor_erisim.yazdirpdf("ekran", rapor2)
    End Sub


End Class