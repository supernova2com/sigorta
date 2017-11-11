Imports System.Globalization.CultureInfo
Imports System.Globalization


Partial Public Class policeara
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
            kullanici_erisim.busayfayigormeyeyetkilimi("adminpoliceara", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'anasayfadan plaka arama ile geldi...
            Dim plaka As String
            plaka = Request.QueryString("plaka")

            If HttpContext.Current.Session("plakano") <> "" Then
                rapor1 = PolicyInfo_Erisim.listele
                Label1.Text = rapor1.veri
                rapor2 = DamageInfo_Erisim.listele()
                Label2.Text = rapor2.veri
                '---LOGLA
                Dim aramakriteri As String
                aramakriteri = TextBox8.Text + "," + TextBox9.Text + "," + TextBox10.Text
                loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", "PolicyInfo", _
                "Arama", "", plaka, 0, "Hayır", "", "", "Web")
                loggenel_Erisim.Ekle(loggenel)
            End If



            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Tümü", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
            Next

            'ÜRÜN KODLARINI DOLDUR 
            DropDownList2.Items.Add(New ListItem("Tümü", "0"))
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
            Dim urunkodlari As New List(Of CLASSURUNKOD)
            urunkodlari = urunkod_erisim.doldur()
            For Each item As CLASSURUNKOD In urunkodlari
                DropDownList2.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
            Next

            'PARA BİRİMLERİNİ DOLDUR
            DropDownList3.Items.Add(New ListItem("Tümü", "0"))
            DropDownList3.Items.Add(New ListItem("Dolar", "USD"))
            DropDownList3.Items.Add(New ListItem("Euro", "EUR"))
            DropDownList3.Items.Add(New ListItem("Sterlin", "STG"))
            DropDownList3.Items.Add(New ListItem("Türk Lirası", "TL"))

            'TARİFE KODLARINI DOLDUR
            DropDownList4.Items.Add(New ListItem("Tümü", "0"))
            Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
            Dim aractarifeler As New List(Of CLASSARACTARIFE)
            aractarifeler = aractarife_erisim.doldur()
            For Each item As CLASSARACTARIFE In aractarifeler
                DropDownList4.Items.Add(New ListItem(item.tarifekod, CStr(item.tarifekod)))
            Next

            'ZEYİL KODLARINI DOLDUR 
            DropDownList5.Items.Add(New ListItem("Tümü", "0"))
            DropDownList5.Items.Add(New ListItem("P veya T", "P veya T"))
            Dim zeyilkod_erisim As New CLASSZEYLCODE_ERISIM
            Dim zeylkodlar As New List(Of CLASSZEYLCODE)
            zeylkodlar = zeyilkod_erisim.doldur()
            For Each item As CLASSZEYLCODE In zeylkodlar
                DropDownList5.Items.Add(New ListItem(item.kod, CStr(item.kod)))
            Next


            '-------------------------------
            TextBox1.Text = DateTime.Now.AddDays(-365)

            TextBox2.Text = DateTime.Now.ToShortDateString

            If Label1.Text = "" Then
                Buttonexcelpolice.Visible = False
                Buttonpdfpolice.Visible = False
                Buttonwordpolice.Visible = False

                Buttonexcelhasar.Visible = False
                Buttonpdfhasar.Visible = False
                Buttonwordhasar.Visible = False
                baslikhasar.Visible = False
                baslikpolice.Visible = False
            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        baslikhasar.Visible = True
        baslikpolice.Visible = True

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
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitis = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        If TextBox12.Text <> "" Then
            If IsNumeric(TextBox12.Text) = False Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Gün sayısı rakamsal olmalıdır.</li>"
                TextBox1.Focus()
            End If
        End If

        'arama kriteri girilmiş mi -----------------------------
        If TextBox6.Text = "" And Len(TextBox7.Text) < 3 And TextBox8.Text = "" And _
        Len(TextBox9.Text) < 4 And Len(TextBox10.Text) < 4 Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Herhangi bir arama kriteri girmediniz.</li>"
            TextBox6.Focus()
        End If


        'mantıksal kontrol 
        'plaka
        If TextBox8.Text <> "" Then
            If Len(TextBox8.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Plaka en az 3 karakter olmalıdır.</li>"
                TextBox8.Focus()
            End If
        End If

        'ad
        If TextBox9.Text <> "" Then
            If Len(TextBox9.Text) < 1 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Ad en az 1 karakter olmalıdır.</li>"
                TextBox9.Focus()
            End If
        End If

        'ad soyad
        If TextBox9.Text = "" And TextBox10.Text <> "" Then
            If Len(TextBox10.Text) < 1 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Soyad en az 1 karakter olmalıdır.</li>"
                TextBox10.Focus()
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("baslangic") = baslangic
            HttpContext.Current.Session("bitis") = bitis
            HttpContext.Current.Session("sirket") = DropDownList1.SelectedValue
            HttpContext.Current.Session("urunkodu") = DropDownList2.SelectedValue
            HttpContext.Current.Session("parabirimi") = DropDownList3.SelectedValue
            HttpContext.Current.Session("policeno") = TextBox6.Text
            HttpContext.Current.Session("kimlikno") = TextBox7.Text
            HttpContext.Current.Session("plakano") = TextBox8.Text
            HttpContext.Current.Session("ad") = TextBox9.Text
            HttpContext.Current.Session("soyad") = TextBox10.Text
            HttpContext.Current.Session("tarife") = DropDownList4.SelectedValue
            HttpContext.Current.Session("gun") = TextBox12.Text
            HttpContext.Current.Session("zeylcode") = DropDownList5.SelectedValue

            rapor1 = PolicyInfo_Erisim.listele
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
            aramakriteri = TextBox8.Text + "," + TextBox9.Text + "," + TextBox10.Text
            loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", "PolicyInfo", _
            "Arama", "", aramakriteri, 0, "Hayır", "", "", "Web")
            loggenel_Erisim.Ekle(loggenel)


            rapor2 = DamageInfo_Erisim.listele()
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
        rapor1 = PolicyInfo_Erisim.listele
        rapor_erisim.yazdirexcel("ekran", rapor1)
    End Sub

    Protected Sub Buttonwordpolice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonwordpolice.Click
        rapor1 = PolicyInfo_Erisim.listele
        rapor_erisim.yazdirword("ekran", rapor1)
    End Sub

    Protected Sub Buttonpdfpolice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdfpolice.Click
        rapor1 = PolicyInfo_Erisim.listele
        rapor_erisim.yazdirpdf("ekran", rapor1)
    End Sub


    'HASARLAR İÇİN EXPORT DÜĞMELERİ
    Protected Sub Buttonexcelhasar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcelhasar.Click
        rapor2 = DamageInfo_Erisim.listele()
        rapor_erisim.yazdirexcel("ekran", rapor2)
    End Sub

    Protected Sub Buttonwordhasar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonwordhasar.Click
        rapor2 = DamageInfo_Erisim.listele()
        rapor_erisim.yazdirword("ekran", rapor2)
    End Sub

    Protected Sub Buttonpdfhasar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdfhasar.Click
        rapor2 = DamageInfo_Erisim.listele()
        rapor_erisim.yazdirpdf("ekran", rapor2)
    End Sub

End Class