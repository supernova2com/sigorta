Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class hasariptal
    Inherits System.Web.UI.Page

    Dim rapor As New CLASSRAPOR
    Dim rapor_Erisim As New CLASSRAPOR_ERISIM

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim loggenel As New CLASSLOGGENEL
    Dim loggenel_Erisim As New CLASSLOGGENEL_ERISIM
    Dim DamageInfo_Erisim As New DamageInfo_Erisim


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasariptal", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Button_policesil.Enabled = False
            Button_hasarsil.Enabled = False
            Button_logsil.Enabled = False


            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Tümü", "0"))
            DropDownList4.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList4.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
            Next

            'ÜRÜN KODLARINI DOLDUR 
            DropDownList2.Items.Add(New ListItem("Tümü", "0"))
            DropDownList2.Items.Add(New ListItem("Kasko", "17"))
            DropDownList2.Items.Add(New ListItem("Kısmi-Kasko", "16"))
            DropDownList2.Items.Add(New ListItem("Trafik", "15"))

            'KAYITLARI DOLDUR
            DropDownList3.Items.Add(New ListItem("Hasar İptal", "Hasar İptal"))

            If Session("kullanici_rolpkey") = 2 Then
                DropDownList3.Items.Add(New ListItem("Hasar Silme", "Hasar Silme"))
                DropDownList3.Items.Add(New ListItem("Poliçe Silme", "Poliçe Silme"))
            End If


            TextBox1.Text = DateTime.Now.AddDays(-365).ToShortDateString
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
        Dim baslangic, bitis As Date

        Dim ne As String
        Dim hata As String

        ne = DropDownList3.SelectedValue

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
            TextBox2.Focus()
        End Try

        If hata = "0" Then

            'EĞER HASAR İPTAL YADA HASAR SİLME SEÇİLMİŞ İSE HERHANGİ BİR KRİTER GİRİLMİŞ İSE
            If DropDownList3.SelectedValue = "Hasar İptal" Or DropDownList3.SelectedValue = "Hasar Silme" Then
                If TextBox3.Text = "" And TextBox6.Text = "" And TextBox9.Text = "" And _
                TextBox10.Text = "" And TextBox7.Text = "" And TextBox8.Text = "" And _
                TextBox11.Text = "" And TextBox12.Text = "" And TextBox13.Text = "" And _
                TextBox14.Text = "" Then
                    hata = "1"
                    hatamesajlari = hatamesajlari + "<li>Herhangi bir arama kriteri girmediniz.</li>"
                    TextBox3.Focus()
                End If
            End If

            If DropDownList3.SelectedValue = "Poliçe Silme" Then
                If TextBox3.Text = "" And TextBox6.Text = "" And TextBox9.Text = "" And _
                TextBox10.Text = "" And TextBox7.Text = "" And TextBox8.Text = "" Then
                    hata = "1"
                    hatamesajlari = hatamesajlari + "<li>Herhangi bir arama kriteri girmediniz.</li>"
                    TextBox3.Focus()
                End If
            End If

        End If


        If hata = "0" Then
            'mantıksal kontrol eğer birlik personeli ise sadece son 1 yıl içerisinde arama yapabilir.
            Dim kullanici_rolpkey As String
            kullanici_rolpkey = Session("kullanici_rolpkey")
            If kullanici_rolpkey = "7" Then
                If TextBox1.Text < Date.Now.AddDays(-365) Then
                    hata = "1"
                    hatamesajlari = hatamesajlari + "<li>Sadece son 1 yıl içerisinde arama yapabilirsiniz.</li>"
                    TextBox1.Focus()
                End If
            End If
        End If



        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            If ne = "Hasar İptal" Then

                HttpContext.Current.Session("baslangic") = baslangic
                HttpContext.Current.Session("bitis") = bitis
                HttpContext.Current.Session("sirket") = DropDownList1.SelectedValue
                HttpContext.Current.Session("urunkodu") = DropDownList2.SelectedValue
                HttpContext.Current.Session("dosyano") = TextBox3.Text
                HttpContext.Current.Session("policeno") = TextBox6.Text
                HttpContext.Current.Session("ad") = TextBox9.Text
                HttpContext.Current.Session("soyad") = TextBox10.Text
                HttpContext.Current.Session("kimlikno") = TextBox7.Text
                HttpContext.Current.Session("plakano") = TextBox8.Text
                HttpContext.Current.Session("talepad") = TextBox11.Text
                HttpContext.Current.Session("talepsoyad") = TextBox12.Text
                HttpContext.Current.Session("talepplakano") = TextBox13.Text
                HttpContext.Current.Session("talepkimlikno") = TextBox14.Text

                rapor = DamageInfo_Erisim.listelehasariptalicin
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

                '---LOGLA
                Dim aramakriteri As String
                aramakriteri = TextBox7.Text + " " + TextBox8.Text + " " + TextBox9.Text + " " + TextBox10.Text
                loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", "DamageCancel", _
                "Arama", "", aramakriteri, 0, "Hayır", "", "", "Web")
                loggenel_Erisim.Ekle(loggenel)

            End If


            If ne = "Hasar Silme" Then

                Buttonexcel.Visible = False
                Buttonpdf.Visible = False
                Buttonword.Visible = False

                HttpContext.Current.Session("baslangic") = baslangic
                HttpContext.Current.Session("bitis") = bitis
                HttpContext.Current.Session("sirket") = DropDownList1.SelectedValue
                HttpContext.Current.Session("urunkodu") = DropDownList2.SelectedValue
                HttpContext.Current.Session("dosyano") = TextBox3.Text
                HttpContext.Current.Session("policeno") = TextBox6.Text
                HttpContext.Current.Session("ad") = TextBox9.Text
                HttpContext.Current.Session("soyad") = TextBox10.Text
                HttpContext.Current.Session("kimlikno") = TextBox7.Text
                HttpContext.Current.Session("plakano") = TextBox8.Text
                HttpContext.Current.Session("talepad") = TextBox11.Text
                HttpContext.Current.Session("talepsoyad") = TextBox12.Text
                HttpContext.Current.Session("talepplakano") = TextBox13.Text
                HttpContext.Current.Session("talepkimlikno") = TextBox14.Text

                rapor = DamageInfo_Erisim.listelehasarsilmeicin
                Label2.Text = rapor.veri


            End If

            If ne = "Poliçe Silme" Then

                Dim PolicyInfo_erisim As New PolicyInfo_Erisim

                HttpContext.Current.Session("baslangic") = baslangic
                HttpContext.Current.Session("bitis") = bitis
                HttpContext.Current.Session("sirket") = DropDownList1.SelectedValue
                HttpContext.Current.Session("urunkodu") = DropDownList2.SelectedValue
                HttpContext.Current.Session("parabirimi") = "0"
                HttpContext.Current.Session("policeno") = TextBox6.Text
                HttpContext.Current.Session("kimlikno") = TextBox7.Text
                HttpContext.Current.Session("plakano") = TextBox8.Text
                HttpContext.Current.Session("ad") = TextBox9.Text
                HttpContext.Current.Session("soyad") = TextBox10.Text
                HttpContext.Current.Session("tarife") = "0"
                HttpContext.Current.Session("gun") = ""
                HttpContext.Current.Session("zeylcode") = "0"

                rapor = PolicyInfo_erisim.listelesilmeicin
                Label2.Text = rapor.veri

            End If


        End If 'hata=0

    End Sub


    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = DamageInfo_Erisim.listelehasariptalicin
        rapor_Erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = DamageInfo_Erisim.listelehasariptalicin
        rapor_Erisim.yazdirword("ekran", rapor)
    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = DamageInfo_Erisim.listelehasariptalicin
        rapor_Erisim.yazdirpdf("ekran", rapor)
    End Sub

    Protected Sub Button_policesil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_policesil.Click

        Dim hata As String
        Dim hatamesajlari As String
        Dim result As New CLADBOPRESULT
        Dim batchislem_erisim As New CLASSBATCHISLEMPOLICE_ERISIM
        Dim sirketkod As String
        sirketkod = DropDownList4.SelectedValue

        hata = "0"

        If sirketkod = "0" Then
            hata = "1"
            DropDownList4.Focus()
            hatamesajlari = "Şirketi seçmediniz."
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            result = batchislem_erisim.sil_sirketin(sirketkod)
            durumlabel.Text = javascript.alertresult(result)
        End If


    End Sub

    Protected Sub Button_hasarsil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_hasarsil.Click

        Dim hata As String
        Dim hatamesajlari As String
        Dim result As New CLADBOPRESULT
        Dim batchislemdamage_erisim As New CLASSBATCHISLEMDAMAGE_ERISIM
        Dim sirketkod As String
        sirketkod = DropDownList4.SelectedValue

        hata = "0"

        If sirketkod = "0" Then
            hata = "1"
            DropDownList4.Focus()
            hatamesajlari = "Şirketi seçmediniz."
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            result = batchislemdamage_erisim.sil_sirketin(sirketkod)
            durumlabel.Text = javascript.alertresult(result)
        End If


    End Sub

    Protected Sub Button_logsil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_logsil.Click


        Dim hata As String
        Dim hatamesajlari As String
        Dim result As New CLADBOPRESULT
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim sirketkod As String
        sirketkod = DropDownList4.SelectedValue
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        hata = "0"

        If sirketkod = "0" Then
            hata = "1"
            DropDownList4.Focus()
            hatamesajlari = "Şirketi seçmediniz."
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then
            sirket = sirket_erisim.bultek_sirketkodagore(sirketkod)
            result = logservis_erisim.sil_sirketin(sirket.pkey)
            durumlabel.Text = javascript.alertresult(result)
        End If



    End Sub
End Class