Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class hasarara
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
            kullanici_erisim.busayfayigormeyeyetkilimi("adminhasarara", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

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
            DropDownList2.Items.Add(New ListItem("Kasko", "17"))
            DropDownList2.Items.Add(New ListItem("Kısmi-Kasko", "16"))
            DropDownList2.Items.Add(New ListItem("Trafik", "15"))

     
            TextBox1.Text = DateTime.Now.AddDays(-365)
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

        'baslangictarih---------------------------
        Try
            bitis = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

      
        'sürücü ad kontrol
        If TextBox9.Text <> "" Then
            If Len(TextBox9.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Sürücü adı en az 3 karakter olmalıdır.</li>"
                TextBox9.Focus()
            End If
        End If


        'sürücü plaka kontrol
        If TextBox7.Text <> "" Then
            If Len(TextBox7.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Plaka en az 3 karakter olmalıdır.</li>"
                TextBox7.Focus()
            End If
        End If


        'sürücü ad soyad
        If TextBox9.Text = "" And TextBox10.Text <> "" Then
            If Len(TextBox10.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Sürücü soyadı en az 3 karakter olmalıdır.</li>"
                TextBox10.Focus()
            End If
        End If


        'talep ad kontrol
        If TextBox11.Text <> "" Then
            If Len(TextBox11.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Talep edenin adı en az 3 karakter olmalıdır.</li>"
                TextBox11.Focus()
            End If
        End If


        'talep  ad soyad kontrol
        If TextBox11.Text = "" And TextBox12.Text <> "" Then
            If Len(TextBox12.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Talep edenin soyadı en az 3 karakter olmalıdır.</li>"
                TextBox10.Focus()
            End If
        End If


        'talep plaka kontrol
        If TextBox13.Text <> "" Then
            If Len(TextBox13.Text) < 3 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Talep plaka en az 3 karakter olmalıdır.</li>"
                TextBox13.Focus()
            End If
        End If


        'arama kriteri girilmiş mi -----------------------------
        If TextBox3.Text = "" And TextBox6.Text = "" And Len(TextBox9.Text) < 4 And _
        Len(TextBox10.Text) < 4 And Len(TextBox7.Text) < 6 And Len(TextBox8.Text) < 3 And _
        Len(TextBox11.Text) < 4 And Len(TextBox12.Text) < 4 And Len(TextBox13.Text) < 4 And _
        Len(TextBox14.Text) < 6 Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Herhangi bir arama kriteri girmediniz.</li>"
            TextBox3.Focus()
        End If


 
        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

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

            rapor = DamageInfo_Erisim.listele
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
            aramakriteri = TextBox7.Text + " " + TextBox8.Text + " " + TextBox9.Text + " " + TextBox10.Text + " " + TextBox11.Text + " " + TextBox12.Text
            loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", "DamageInfo", _
            "Arama", "", aramakriteri, 0, "Hayır", "", "", "Web")
            loggenel_Erisim.Ekle(loggenel)

        End If

    End Sub


    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = DamageInfo_Erisim.listele
        rapor_Erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = DamageInfo_Erisim.listele
        rapor_Erisim.yazdirword("ekran", rapor)
    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = DamageInfo_Erisim.listele
        rapor_Erisim.yazdirpdf("ekran", rapor)
    End Sub


End Class