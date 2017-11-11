Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class fatura
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim rapor_erisim As New CLASSRAPOR_ERISIM
    Dim fatura_erisim As New CLASSFATURA_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("fatura", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        'İŞLEMLER PORTLATE İNİ GÖSTER YADA GÖSTERME
        If Label1.Text = "" Then
            islemportlet.Visible = False
        Else
            islemportlet.Visible = True
        End If
        '--------------------------------------------

        If Not Page.IsPostBack Then

            'AYLARI DOLDUR 
            DropDownList1.Items.Add(New ListItem("Ocak", "1"))
            DropDownList1.Items.Add(New ListItem("Şubat", "2"))
            DropDownList1.Items.Add(New ListItem("Mart", "3"))
            DropDownList1.Items.Add(New ListItem("Nisan", "4"))
            DropDownList1.Items.Add(New ListItem("Mayıs", "5"))
            DropDownList1.Items.Add(New ListItem("Haziran", "6"))
            DropDownList1.Items.Add(New ListItem("Temmuz", "7"))
            DropDownList1.Items.Add(New ListItem("Ağustos", "8"))
            DropDownList1.Items.Add(New ListItem("Eylül", "9"))
            DropDownList1.Items.Add(New ListItem("Ekim", "10"))
            DropDownList1.Items.Add(New ListItem("Kasım", "11"))
            DropDownList1.Items.Add(New ListItem("Aralık", "12"))

            'YILLARI DOLDUR
            Dim simdikiyil As Integer
            simdikiyil = DateTime.Now.Year
            For i = simdikiyil To 2002 Step -1
                DropDownList2.Items.Add(New ListItem(CStr(i), CStr(i)))
            Next


            'ÜRÜN KODLARINI DOLDUR 
            DropDownList3.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
            Dim urunkodlari As New List(Of CLASSURUNKOD)
            urunkodlari = urunkod_erisim.doldur()
            For Each item As CLASSURUNKOD In urunkodlari
                DropDownList3.Items.Add(New ListItem(CStr(item.aciklama), CStr(item.kod)))
            Next

            'POLİÇE TİPLERİNİ DOLDUR
            DropDownList4.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
            Dim policetipleri As New List(Of CLASSPOLICETIP)
            policetipleri = policetip_erisim.doldur()
            For Each item As CLASSPOLICETIP In policetipleri
                DropDownList4.Items.Add(New ListItem(CStr(item.policetipad), CStr(item.kod)))
            Next
            DropDownList4.Items.Add(New ListItem("NORMAL ve SINIR KAPISI", "4"))

            'AKTİF
            DropDownList5.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList5.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList5.Items.Add(New ListItem("Hayır", "Hayır"))



            'BİR AY ÖNCEYİ SELECT HALİNDE YAPIYORUZ ---------------------------
            Dim simdikiay As Integer
            simdikiay = Date.Now.Month
            If simdikiay = 1 Then
                DropDownList2.SelectedValue = Date.Now.Year - 1
            End If
            If simdikiay > 1 Then
                DropDownList2.SelectedValue = Date.Now.Year
            End If

            If simdikiay = 1 Then
                DropDownList1.SelectedValue = "12"
            End If
            If simdikiay > 1 Then
                DropDownList1.SelectedValue = CStr(simdikiay - 1)
            End If
            '-------------------------------------------------------------------

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


        If IsNumeric(TextBox6.Text) = False Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Eder rakamsal olmalıdır.</li>"
            TextBox6.Focus()
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            islemportlet.Visible = True
            HttpContext.Current.Session("hangirapor") = "1"
            HttpContext.Current.Session("ay") = DropDownList1.SelectedValue
            HttpContext.Current.Session("yil") = DropDownList2.SelectedValue
            HttpContext.Current.Session("eder") = TextBox6.Text
            HttpContext.Current.Session("urunkod") = DropDownList3.SelectedValue
            HttpContext.Current.Session("policetip") = DropDownList4.SelectedValue
            HttpContext.Current.Session("aktif") = DropDownList5.SelectedValue

            rapor = fatura_erisim.temelrapor

            Labelbaslik.Text = rapor.baslik
            Label1.Text = rapor.veri



        End If

    End Sub

   

    'SEÇTİKLERİMİ FATURALANDIR.
    Protected Sub buttonsecfatura_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonsecfatura.Click


        Dim fatura_erisim As New CLASSFATURA_ERISIM
        Dim result As New CLADBOPRESULT
        Dim oncedenhesap As New CLASSHESAP
        Dim hesap As New CLASSHESAP
        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirketler As New List(Of CLASSSIRKET)

        Dim checkid, faturano, ay, yil As String
        Dim secim As String
        Dim bpkey As Integer
        Dim girdi As String = "Hayır"

        Dim eder As Decimal
        Dim policeadeti As Integer
        Dim policedegeri As Decimal

        ay = DropDownList1.SelectedValue
        yil = DropDownList2.SelectedValue

        sirketler = sirket_erisim.dolduraktifsecenek(DropDownList5.SelectedValue)
        For Each item As CLASSSIRKET In sirketler

            checkid = "A_" + item.sirketkod
            secim = Request.Form(checkid)

            If secim = "on" Then

                girdi = "Evet"

                'önceki faturayı sil
                hesap_erisim.sil_coklu(item.sirketkod, ay, yil, "Gelir", "Fatura")

                bpkey = hesap_erisim.pkeybul
                faturano = CStr(item.sirketkod) + "-" + CStr(bpkey) + _
                "-" + CStr(yil) + CStr(ay)

                hesap.firmcode = item.sirketkod
                hesap.aciklama = "Otomatik Faturalandırma İşlemi"
                hesap.faturano = faturano
                hesap.tarih = DateTime.Now
                hesap.tip = "Gelir"

                '---------------------------------------------------------
                eder = TextBox6.Text
                policeadeti = fatura_erisim.sayibul(item.sirketkod)
                policedegeri = policeadeti * eder
                '---------------------------------------------------------

                hesap.tutar = policedegeri
                hesap.ay = ay
                hesap.yil = yil
                hesap.eder = HttpContext.Current.Session("eder")
                hesap.tur = "Fatura"

                result = hesap_erisim.Ekle(hesap)

            End If

        Next

        'TEKRAR GÖSTER
        If girdi = "Evet" Then
            rapor = fatura_erisim.temelrapor
            Labelbaslik.Text = rapor.baslik
            Label1.Text = rapor.veri
        End If


    End Sub

    'PDF YAZDIR SEÇTİKLERİMİ 
    Protected Sub buttonsecyazdir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonsecyazdir.Click

        Dim girdi As String = "Hayır"
        Dim hesaplar As New List(Of CLASSHESAP)
        Dim hesap As New CLASSHESAP
        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirketler As New List(Of CLASSSIRKET)

        Dim checkid, ay, yil As String
        Dim secim As String

        ay = DropDownList1.SelectedValue
        yil = DropDownList2.SelectedValue

        sirketler = sirket_erisim.dolduraktifsecenek(DropDownList5.SelectedValue)
        For Each item As CLASSSIRKET In sirketler
            checkid = "A_" + item.sirketkod
            secim = Request.Form(checkid)
            If secim = "on" Then
                girdi = "Evet"
                hesap = hesap_erisim.bulcoklu(item.sirketkod, Session("ay"), Session("yil"), "Gelir", "Fatura")
                If hesap.pkey > 0 Then
                    hesaplar.Add(New CLASSHESAP(hesap.pkey, hesap.firmcode, hesap.faturano, hesap.tip, hesap.tarih, _
                    hesap.tutar, hesap.aciklama, hesap.ay, hesap.yil, hesap.eder, hesap.tur, hesap.oran))
                End If
            End If
        Next

        If girdi = "Evet" Then
            hesap_erisim.pdfolustur(hesaplar, "ekran")
        End If


    End Sub

    'E-POSTA GÖNDER SEÇTİKLERİMİ
    Protected Sub buttonsecgonder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonsecgonder.Click


        Dim hesaplar As New List(Of CLASSHESAP)
        Dim hesap As New CLASSHESAP
        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirketler As New List(Of CLASSSIRKET)

        Dim checkid, ay, yil As String
        Dim secim As String

        ay = DropDownList1.SelectedValue
        yil = DropDownList2.SelectedValue

        sirketler = sirket_erisim.dolduraktifsecenek(DropDownList5.SelectedValue)
        For Each item As CLASSSIRKET In sirketler
            checkid = "A_" + item.sirketkod
            secim = Request.Form(checkid)
            If secim = "on" Then
                hesap = hesap_erisim.bulcoklu(item.sirketkod, Session("ay"), Session("yil"), "Gelir", "Fatura")
                If hesap.pkey > 0 Then
                    result = hesap_erisim.emailgonder(hesap.faturano)
                End If
            End If
        Next

        durumlabel.Text = javascript.alertresult(result)

    End Sub
End Class