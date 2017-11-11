Public Partial Class odeme
    Inherits System.Web.UI.Page

    Dim hesap As New CLASSHESAP
    Dim hesap_erisim As New CLASSHESAP_ERISIM
    Dim result As New CLADBOPRESULT
    Dim sirket As New CLASSSIRKET
    Dim sirket_erisim As New CLASSSIRKET_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim doldurulacakhesap As New CLASSHESAP
    Dim faturano, op, firmcode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("odemepopup", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            op = Request.QueryString("op")
            faturano = Request.QueryString("faturano")
            firmcode = Request.QueryString("firmcode")


            TextBox1.Focus()
            hesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")

            'HESAP HAREKETLERİNİ LİSTELE 
            HttpContext.Current.Session("ltip") = "ekstre"
            HttpContext.Current.Session("firmcode") = firmcode
            Label1.Text = hesap_erisim.listele()
            Label3.Text = hesap_erisim.listele_odenmemisodenmemis("Ödenmiş")
            Label4.Text = hesap_erisim.listele_odenmemisodenmemis("Ödenmemiş")

            'TÜRLERİ DOLDUR 
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList2.Items.Add(New ListItem("Ödeme", "Ödeme"))
            DropDownList2.Items.Add(New ListItem("Gecikme", "Gecikme"))

            'ŞİRKETLERİ DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.sirketkod)))
            Next
  
            If Request.QueryString("op") = "yenikayit" Then
                Button2.Visible = False
                TextBox1.Focus()

                doldurulacakhesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
                DropDownList1.SelectedValue = doldurulacakhesap.firmcode
                TextBox1.Text = Date.Now
                TextBox4.Text = faturano + " fatura numarasının ödemesi"
                TextBox2.Text = doldurulacakhesap.tutar


            End If

            If Request.QueryString("op") = "duzenle" Then

                Button2.Visible = True
                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                hesap = hesap_erisim.bultek(Request.QueryString("pkey"))

                DropDownList1.SelectedValue = doldurulacakhesap.firmcode
                TextBox1.Text = hesap.tarih
                TextBox2.Text = hesap.tutar
                TextBox4.Text = hesap.aciklama


            End If


        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim tarih As Date
        Dim hesap As New CLASSHESAP
        Dim hesap_erisim As New CLASSHESAP_ERISIM

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'tur seçilmişmi
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>İşlem türünü seçmediniz.</li>"
            inn.Value = "0"
        End If


        'sirket seçilmişmi 
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirket seçmediniz.</li>"
            inn.Value = "0"
        End If


        'tarih---------------------------
        Try
            tarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Ödeme tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try


        'tutar----------------------------
        If IsNumeric(TextBox2.Text) = False Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Tutar rakamsal olmalıdır. </li>"
            inn.Value = "0"
        End If


        If hata = "0" Then
            'mantıksal kontrol 
            If DropDownList2.SelectedValue = "Gecikme" Then
                If IsNumeric(TextBox3.Text) = False Then
                    TextBox3.Focus()
                    hata = "1"
                    hatamesajlari = hatamesajlari + "<li>Gecikme oranı rakamsal olmalıdır. </li>"
                    inn.Value = "0"
                End If
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            faturano = Request.QueryString("faturano")

            hatamesajlari = ""
            hesap.firmcode = DropDownList1.SelectedValue
            hesap.faturano = faturano
            hesap.tarih = tarih
            hesap.tutar = TextBox2.Text
            hesap.aciklama = TextBox4.Text
            hesap.ay = tarih.Month
            hesap.yil = tarih.Year
            hesap.eder = 0

            hesap.tur = DropDownList2.SelectedValue
            If DropDownList2.SelectedValue = "Ödeme" Then
                hesap.oran = 0
                hesap.tip = "Gider"
            End If
            If DropDownList2.SelectedValue = "Gecikme" Then
                hesap.oran = TextBox3.Text
                hesap.tip = "Gelir"
            End If



            If Request.QueryString("op") = "yenikayit" Then
                result = hesap_erisim.Ekle(hesap)
            End If

            If Request.QueryString("op") = "duzenle" Then
                hesap = hesap_erisim.bultek(Request.QueryString("pkey"))

                hesap.firmcode = DropDownList1.SelectedValue
                hesap.faturano = faturano
                hesap.tarih = tarih
                hesap.tutar = TextBox2.Text
                hesap.aciklama = TextBox4.Text
                hesap.ay = tarih.Month
                hesap.yil = tarih.Year
                hesap.eder = 0

                hesap.tur = DropDownList2.SelectedValue
                If DropDownList2.SelectedValue = "Ödeme" Then
                    hesap.oran = 0
                    hesap.tip = "Gider"
                End If
                If DropDownList2.SelectedValue = "Gecikme" Then
                    hesap.oran = TextBox3.Text
                    hesap.tip = "Gelir"
                End If

                result = hesap_erisim.Duzenle(hesap)

            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
                HttpContext.Current.Session("ltip") = "ekstre"
                HttpContext.Current.Session("firmcode") = CStr(hesap.firmcode)
                Label1.Text = hesap_erisim.listele()
                Label3.Text = hesap_erisim.listele_odenmemisodenmemis("Ödenmiş")
                Label4.Text = hesap_erisim.listele_odenmemisodenmemis("Ödenmemiş")
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

        End If

    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then


            Dim hesap_erisim As New CLASSHESAP_ERISIM

            result = hesap_erisim.Sil(Request.QueryString("pkey"))
            durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"

            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If


    End Sub



    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim hata As String
        Dim hatamesajlari As String
        hata = "0"

        If IsNumeric(TextBox2.Text) = False Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Tutar rakamsal olmalıdır. </li>"
            inn.Value = "0"
        End If

        If IsNumeric(TextBox3.Text) = False Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Oran rakamsal olmalıdır. </li>"
            inn.Value = "0"
        End If

        If hata = "0" Then
            TextBox2.Text = (TextBox2.Text / 100) * TextBox3.Text
        End If

    End Sub
End Class