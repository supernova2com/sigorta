Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class ozelrapor
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim ozelrapor_erisim As New CLASSOZELRAPOR_ERISIM
    Dim ozelrapor2_erisim As New CLASSOZELRAPOR2_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'mukerrer poliçe raporunu disable et
        'Button6.Enabled = False


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("ozelrapor", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

     
            'PARA BİRİMLERİ DOLDUR---------------------------------
            DropDownList3.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList11.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList40.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
            Dim currencycodelar As New List(Of CLASSCURRENCYCODE)
            currencycodelar = currencycode_erisim.doldur()
            For Each item As CLASSCURRENCYCODE In currencycodelar
                DropDownList3.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
                DropDownList11.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
                DropDownList40.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
            Next


            'ÜRÜN KODLARINI DOLDUR 
            DropDownList5.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList9.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList20.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList23.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
            Dim urunkodlari As New List(Of CLASSURUNKOD)
            urunkodlari = urunkod_erisim.doldur()
            For Each item As CLASSURUNKOD In urunkodlari
                DropDownList5.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
                DropDownList9.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
                DropDownList20.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
                DropDownList23.Items.Add(New ListItem(item.aciklama, CStr(item.kod)))
            Next


            'TARİFE KODLARINI DOLDUR
            DropDownList6.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList10.Items.Add(New ListItem("Tümü", "Tümü"))
            'DropDownList24.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
            Dim aractarifeler As New List(Of CLASSARACTARIFE)
            aractarifeler = aractarife_erisim.doldur()
            For Each item As CLASSARACTARIFE In aractarifeler
                DropDownList6.Items.Add(New ListItem(item.tarifekod, CStr(item.tarifekod)))
                DropDownList10.Items.Add(New ListItem(item.tarifekod, CStr(item.tarifekod)))
                DropDownList24.Items.Add(New ListItem(item.tarifekod, CStr(item.tarifekod)))
            Next


            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList2.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList4.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList12.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList18.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList21.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList25.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList2.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList4.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList12.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList18.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList21.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
                DropDownList25.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
            Next

            'POLİÇE TİPLERİ DOLDUR
            DropDownList13.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList14.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList19.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList22.Items.Add(New ListItem("Tümü", "Tümü"))
            Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
            Dim policetipleri As New List(Of CLASSPOLICETIP)
            policetipleri = policetip_erisim.doldur()
            For Each item As CLASSPOLICETIP In policetipleri
                DropDownList13.Items.Add(New ListItem(item.policetipad, CStr(item.kod)))
                DropDownList14.Items.Add(New ListItem(item.policetipad, CStr(item.kod)))
                DropDownList19.Items.Add(New ListItem(item.policetipad, CStr(item.kod)))
                DropDownList22.Items.Add(New ListItem(item.policetipad, CStr(item.kod)))
            Next


            'HANGİ POLİÇELER
            DropDownList15.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList15.Items.Add(New ListItem("Canlı", "green"))

            DropDownList16.Items.Add(New ListItem("StartDate", "StartDate"))
            DropDownList16.Items.Add(New ListItem("ArrangeDate", "ArrangeDate"))

            DropDownList17.Items.Add(New ListItem("StartDate", "StartDate"))
            DropDownList17.Items.Add(New ListItem("ArrangeDate", "ArrangeDate"))

            'HASAR TÜR
            DropDownList38.Items.Add(New ListItem("Poliçenin Bağlı Olduğu", "policebagli"))
            DropDownList38.Items.Add(New ListItem("Kaza Tarihine Göre", "kazatarih"))

            DropDownList39.Items.Add(New ListItem("Poliçenin Bağlı Olduğu", "policebagli"))
            DropDownList39.Items.Add(New ListItem("Kaza Tarihine Göre", "kazatarih"))

            TextBox1.Text = DateTime.Now.AddYears(-1)
            TextBox2.Text = DateTime.Now.ToShortDateString

            TextBox3.Text = DateTime.Now.AddYears(-1)
            TextBox4.Text = DateTime.Now.ToShortDateString

            TextBox5.Text = DateTime.Now.AddYears(-1)
            TextBox6.Text = DateTime.Now.ToShortDateString

            TextBox7.Text = DateTime.Now.AddYears(-1)
            TextBox8.Text = DateTime.Now.ToShortDateString

            TextBox9.Text = DateTime.Now.AddYears(-1)
            TextBox10.Text = DateTime.Now.ToShortDateString

            TextBox11.Text = DateTime.Now.AddYears(-1)
            TextBox12.Text = DateTime.Now.ToShortDateString

            TextBox14.Text = DateTime.Now.AddMonths(-1)
            TextBox15.Text = DateTime.Now.ToShortDateString


            'default değerleri yükle
            hi0oran.Text = "0"
            hi10oran.Text = "10"
            hi20oran.Text = "20"
            hi30oran.Text = "30"
            hi40oran.Text = "40"
            hz0oran.Text = "0"
            hz15oran.Text = "15"
            hz20oran.Text = "20"
            hz25oran.Text = "25"
            hz30oran.Text = "30"
            hz35oran.Text = "35"
            hz40oran.Text = "40"
            hz50oran.Text = "50"
            yz0oran.Text = "0"
            yz15oran.Text = "15"
            yz30oran.Text = "30"
            cc0oran.Text = "0"
            cc5oran.Text = "5"
            cc15oran.Text = "15"
            cc20oran.Text = "20"
            cc25oran.Text = "25"
            cc30oran.Text = "30"
            cc35oran.Text = "35"
            cc45oran.Text = "45"
            cc50oran.Text = "50"
            cc75oran.Text = "75"


            'sınır kapısı raporları için saat ve dakikaları dolduruyoruz
            Dim eklenecek As String = ""
            For i = 0 To 23
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownList26.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList28.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList30.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList32.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList34.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList36.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownList26.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList28.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList30.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList32.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList34.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList36.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next

            For i = 0 To 59
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownList27.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList29.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList31.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList33.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList35.Items.Add(New ListItem(eklenecek, eklenecek))
                    DropDownList37.Items.Add(New ListItem(eklenecek, eklenecek))

                Else
                    DropDownList27.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList29.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList31.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList33.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList35.Items.Add(New ListItem(CStr(i), CStr(i)))
                    DropDownList37.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next


            DropDownList26.SelectedValue = "08"
            DropDownList27.SelectedValue = "00"
            DropDownList28.SelectedValue = "17"
            DropDownList29.SelectedValue = "00"

            DropDownList30.SelectedValue = "17"
            DropDownList31.SelectedValue = "01"
            DropDownList32.SelectedValue = "23"
            DropDownList33.SelectedValue = "59"

            DropDownList34.SelectedValue = "00"
            DropDownList35.SelectedValue = "00"
            DropDownList36.SelectedValue = "07"
            DropDownList37.SelectedValue = "59"

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox2.Focus()
        End Try

        If hata = "1" Then
            durumlabel.Text = javascript.alert_istedigimyere("validationresult", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "4"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("firmcode") = DropDownList2.SelectedValue
            Response.Redirect("ozelraporyazdir.aspx")

        End If


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox3.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox3.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox4.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox4.Focus()
        End Try

        If hata = "1" Then
            durumlabel2.Text = javascript.alert_istedigimyere("validationresult2", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then


            HttpContext.Current.Session("hangirapor") = "7"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("firmcode") = DropDownList1.SelectedValue
            HttpContext.Current.Session("currencycode") = DropDownList3.SelectedValue
            HttpContext.Current.Session("productcode") = DropDownList5.SelectedValue
            HttpContext.Current.Session("tariffcode") = DropDownList6.SelectedValue
            HttpContext.Current.Session("policytype") = DropDownList13.SelectedValue
            HttpContext.Current.Session("hangipoliceler") = "Tümü"
            HttpContext.Current.Session("tarihtip") = DropDownList16.SelectedValue
            HttpContext.Current.Session("hangihasar") = DropDownList38.SelectedValue

            HttpContext.Current.Session("rbaslik") = "Şirket Genel Prim ve Hasar"

            Response.Redirect("ozelraporyazdir.aspx")

        End If


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox5.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox5.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox6.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox6.Focus()
        End Try

        If hata = "1" Then
            durumlabel3.Text = javascript.alert_istedigimyere("validationresult3", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "6"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("firmcode") = DropDownList4.SelectedValue
            Response.Redirect("ozelraporyazdir.aspx")

        End If


    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox7.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox7.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox8.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox8.Focus()
        End Try


        If hata = "1" Then
            durumlabel5.Text = javascript.alert_istedigimyere("validationresult5", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "7"
            HttpContext.Current.Session("firmcode") = "Tümü"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("currencycode") = DropDownList11.SelectedValue
            HttpContext.Current.Session("productcode") = DropDownList9.SelectedValue
            HttpContext.Current.Session("tariffcode") = DropDownList10.SelectedValue
            HttpContext.Current.Session("policytype") = DropDownList14.SelectedValue
            HttpContext.Current.Session("hangipoliceler") = DropDownList15.SelectedValue
            HttpContext.Current.Session("tarihtip") = DropDownList17.SelectedValue
            HttpContext.Current.Session("hangihasar") = DropDownList39.SelectedValue
            HttpContext.Current.Session("rbaslik") = "Sektör Genel Prim ve Hasar"
            Response.Redirect("ozelraporyazdir.aspx")

        End If

    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click

        Dim donecek As String

        Dim mukerrerrapor_erisim As New CLASSMUKERRERRAPOR_ERISIM
        donecek = mukerrerrapor_erisim.mukerrerplakabul(DropDownList12.SelectedValue)

        durumlabel6.Text = donecek

    End Sub

   
    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox9.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox9.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox10.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox10.Focus()
        End Try

        If hata = "1" Then
            durumlabel7.Text = javascript.alert_istedigimyere("validationresult7", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "8"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("FirmCode") = DropDownList18.SelectedValue
            HttpContext.Current.Session("PolicyType") = DropDownList19.SelectedValue
            HttpContext.Current.Session("ProductCode") = DropDownList20.SelectedValue
            Response.Redirect("ozelraporyazdir.aspx")

        End If


    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button8.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox11.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox11.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox12.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox12.Focus()
        End Try

        'kontrol baz fiyat
        If IsNumeric(TextBox13.Text) = False Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Kontrol baz fiyatı rakamsal olmalıdır.</li>"
            TextBox13.Focus()
        End If

        If hata = 0 Then
            If CDbl(TextBox13.Text) <= 0 Then
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Kontrol baz fiyatı 0 dan büyük olmalıdır.</li>"
                TextBox13.Focus()
            End If
        End If


        If hata = "1" Then
            durumlabel8.Text = javascript.alert_istedigimyere("validationresult8", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then


            If IsNumeric(hi0oran.Text) = False Then
                HttpContext.Current.Session("hi0oran") = "0"
            Else
                HttpContext.Current.Session("hi0oran") = hi0oran.Text
            End If

            If IsNumeric(hi10oran.Text) = False Then
                HttpContext.Current.Session("hi10oran") = "0"
            Else
                HttpContext.Current.Session("hi10oran") = hi10oran.Text
            End If

            If IsNumeric(hi20oran.Text) = False Then
                HttpContext.Current.Session("hi20oran") = "20"
            Else
                HttpContext.Current.Session("hi20oran") = hi20oran.Text
            End If

            If IsNumeric(hi30oran.Text) = False Then
                HttpContext.Current.Session("hi30oran") = "30"
            Else
                HttpContext.Current.Session("hi30oran") = hi30oran.Text
            End If

            If IsNumeric(hi40oran.Text) = False Then
                HttpContext.Current.Session("hi40oran") = "40"
            Else
                HttpContext.Current.Session("hi40oran") = hi40oran.Text
            End If

            If IsNumeric(hz0oran.Text) = False Then
                HttpContext.Current.Session("hz0oran") = "0"
            Else
                HttpContext.Current.Session("hz0oran") = hz0oran.Text
            End If

            If IsNumeric(hz15oran.Text) = False Then
                HttpContext.Current.Session("hz15oran") = "15"
            Else
                HttpContext.Current.Session("hz15oran") = hz15oran.Text
            End If

            If IsNumeric(hz20oran.Text) = False Then
                HttpContext.Current.Session("hz20oran") = "20"
            Else
                HttpContext.Current.Session("hz20oran") = hz20oran.Text
            End If

            If IsNumeric(hz25oran.Text) = False Then
                HttpContext.Current.Session("hz25oran") = "25"
            Else
                HttpContext.Current.Session("hz25oran") = hz25oran.Text
            End If

            If IsNumeric(hz30oran.Text) = False Then
                HttpContext.Current.Session("hz30oran") = "30"
            Else
                HttpContext.Current.Session("hz30oran") = hz30oran.Text
            End If

            If IsNumeric(hz35oran.Text) = False Then
                HttpContext.Current.Session("hz35oran") = "35"
            Else
                HttpContext.Current.Session("hz35oran") = hz35oran.Text
            End If

            If IsNumeric(hz40oran.Text) = False Then
                HttpContext.Current.Session("hz40oran") = "40"
            Else
                HttpContext.Current.Session("hz40oran") = hz40oran.Text
            End If

            If IsNumeric(hz50oran.Text) = False Then
                HttpContext.Current.Session("hz50oran") = "50"
            Else
                HttpContext.Current.Session("hz50oran") = hz50oran.Text
            End If

            If IsNumeric(yz0oran.Text) = False = "0" Then
                HttpContext.Current.Session("yz0oran") = "0"
            Else
                HttpContext.Current.Session("yz0oran") = yz0oran.Text
            End If

            If IsNumeric(yz15oran.Text) = False Then
                HttpContext.Current.Session("yz15oran") = "15"
            Else
                HttpContext.Current.Session("yz15oran") = yz15oran.Text
            End If

            If IsNumeric(yz30oran.Text) = False Then
                HttpContext.Current.Session("yz30oran") = "30"
            Else
                HttpContext.Current.Session("yz30oran") = yz30oran.Text
            End If

            If IsNumeric(cc0oran.Text) = False Then
                HttpContext.Current.Session("cc0oran") = "0"
            Else
                HttpContext.Current.Session("cc0oran") = cc0oran.Text
            End If

            If IsNumeric(cc5oran.Text) = False Then
                HttpContext.Current.Session("cc5oran") = "5"
            Else
                HttpContext.Current.Session("cc5oran") = cc5oran.Text
            End If

            If IsNumeric(cc15oran.Text) = False Then
                HttpContext.Current.Session("cc15oran") = "15"
            Else
                HttpContext.Current.Session("cc15oran") = cc15oran.Text
            End If

            If IsNumeric(cc20oran.Text) = False Then
                HttpContext.Current.Session("cc20oran") = "20"
            Else
                HttpContext.Current.Session("cc20oran") = cc20oran.Text
            End If

            If IsNumeric(cc25oran.Text) = False Then
                HttpContext.Current.Session("cc25oran") = "25"
            Else
                HttpContext.Current.Session("cc25oran") = cc25oran.Text
            End If

            If IsNumeric(cc30oran.Text) = False Then
                HttpContext.Current.Session("cc30oran") = "30"
            Else
                HttpContext.Current.Session("cc30oran") = cc30oran.Text
            End If

            If IsNumeric(cc35oran.Text) = False Then
                HttpContext.Current.Session("cc35oran") = "35"
            Else
                HttpContext.Current.Session("cc35oran") = cc35oran.Text
            End If

            If IsNumeric(cc45oran.Text) = False Then
                HttpContext.Current.Session("cc45oran") = "45"
            Else
                HttpContext.Current.Session("cc45oran") = cc45oran.Text
            End If

            If IsNumeric(cc50oran.Text) = False Then
                HttpContext.Current.Session("cc50oran") = "50"
            Else
                HttpContext.Current.Session("cc50oran") = cc50oran.Text
            End If

            If IsNumeric(cc75oran.Text) = False Then
                HttpContext.Current.Session("cc75oran") = "75"
            Else
                HttpContext.Current.Session("cc75oran") = cc75oran.Text
            End If

            HttpContext.Current.Session("hangirapor") = "9"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("FirmCode") = DropDownList21.SelectedValue
            HttpContext.Current.Session("PolicyType") = DropDownList22.SelectedValue
            HttpContext.Current.Session("ProductCode") = DropDownList23.SelectedValue
            HttpContext.Current.Session("TariffCode") = DropDownList24.SelectedValue
            HttpContext.Current.Session("kontrolbazfiyat") = TextBox13.Text
            HttpContext.Current.Session("CurrencyCode") = DropDownList40.SelectedValue

            Response.Redirect("ozelraporyazdir.aspx")

        End If

    End Sub



    'MOTOR GÜCÜNE GÖRE RAPORLA
    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button9.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox3.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox3.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox4.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox4.Focus()
        End Try

        If hata = "1" Then
            durumlabel2.Text = javascript.alert_istedigimyere("validationresult2", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "1"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("firmcode") = DropDownList1.SelectedValue
            HttpContext.Current.Session("currencycode") = DropDownList3.SelectedValue
            HttpContext.Current.Session("productcode") = DropDownList5.SelectedValue
            HttpContext.Current.Session("tariffcode") = DropDownList6.SelectedValue
            HttpContext.Current.Session("policytype") = DropDownList13.SelectedValue
            HttpContext.Current.Session("hangipoliceler") = "Tümü"
            HttpContext.Current.Session("tarihtip") = DropDownList16.SelectedValue

            HttpContext.Current.Session("rbaslik") = "Motor Gücüne Göre Poliçe/Hasar"
            Response.Redirect("ozelraporyazdir2.aspx")

        End If


    End Sub

    'SINIR KAPISI RAPORU
    Protected Sub Button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button10.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox14.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox14.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox15.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox15.Focus()
        End Try

        If hata = "1" Then
            durumlabel2.Text = javascript.alert_istedigimyere("validationresult9", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "2"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("firmcode") = DropDownList25.SelectedValue

            HttpContext.Current.Session("bir_baslangic_saat") = DropDownList26.SelectedValue
            HttpContext.Current.Session("bir_baslangic_dakika") = DropDownList27.SelectedValue
            HttpContext.Current.Session("bir_bitis_saat") = DropDownList28.SelectedValue
            HttpContext.Current.Session("bir_bitis_dakika") = DropDownList29.SelectedValue

            HttpContext.Current.Session("iki_baslangic_saat") = DropDownList30.SelectedValue
            HttpContext.Current.Session("iki_baslangic_dakika") = DropDownList31.SelectedValue
            HttpContext.Current.Session("iki_bitis_saat") = DropDownList32.SelectedValue
            HttpContext.Current.Session("iki_bitis_dakika") = DropDownList33.SelectedValue

            HttpContext.Current.Session("uc_baslangic_saat") = DropDownList34.SelectedValue
            HttpContext.Current.Session("uc_baslangic_dakika") = DropDownList35.SelectedValue
            HttpContext.Current.Session("uc_bitis_saat") = DropDownList36.SelectedValue
            HttpContext.Current.Session("uc_bitis_dakika") = DropDownList37.SelectedValue


            Response.Redirect("ozelraporyazdir2.aspx")

        End If

    End Sub

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button11.Click


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, bitistarih As Date

        Dim hata As String
        Dim hatamesajlari As String

        hata = "0"

        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox7.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox7.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitistarih = TextBox8.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox8.Focus()
        End Try


        If hata = "1" Then
            durumlabel5.Text = javascript.alert_istedigimyere("validationresult5", hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("hangirapor") = "12"
            HttpContext.Current.Session("firmcode") = "Tümü"
            HttpContext.Current.Session("baslangictarih") = baslangictarih
            HttpContext.Current.Session("bitistarih") = bitistarih
            HttpContext.Current.Session("currencycode") = DropDownList11.SelectedValue
            HttpContext.Current.Session("productcode") = DropDownList9.SelectedValue
            HttpContext.Current.Session("tariffcode") = DropDownList10.SelectedValue
            HttpContext.Current.Session("policytype") = DropDownList14.SelectedValue
            HttpContext.Current.Session("hangipoliceler") = DropDownList15.SelectedValue
            HttpContext.Current.Session("tarihtip") = DropDownList17.SelectedValue
            HttpContext.Current.Session("hangihasar") = DropDownList39.SelectedValue
            HttpContext.Current.Session("rbaslik") = "Sektör Genel Prim ve Hasar"
            Response.Redirect("ozelraporyazdir.aspx")

        End If

    End Sub
End Class