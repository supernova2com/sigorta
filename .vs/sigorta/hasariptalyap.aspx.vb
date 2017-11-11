Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class hasariptalyap
    Inherits System.Web.UI.Page

    Dim damagecancel As New CLASSDAMAGECANCEL
    Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasariptalyap", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'İPTAL TİPLERİNİ DOLDUR
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList1.Items.Add(New ListItem("Kimlik", "Kimlik"))
            DropDownList1.Items.Add(New ListItem("Plaka", "Plaka"))
            DropDownList1.Items.Add(New ListItem("Her İkisinden", "Her İkisinden"))


            'KULLANICILARI DOLDUR---------------------------------------
            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur()
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList2.Items.Add(New ListItem(item.adsoyad, CStr(item.pkey)))
            Next

            DropDownList2.SelectedValue = Session("kullanici_pkey")
            DropDownList2.Enabled = False

            Dim op, pkey As String
            Dim FirmCode, ProductCode, AgencyCode As String
            Dim PolicyNumber, TecditNumber, FileNo As String
            Dim RequestNo, ProductType As String

            op = Request.QueryString("op")
            FirmCode = Request.QueryString("FirmCode")
            ProductCode = Request.QueryString("ProductCode")
            AgencyCode = Request.QueryString("AgencyCode")
            PolicyNumber = Request.QueryString("PolicyNumber")
            TecditNumber = Request.QueryString("TecditNumber")
            FileNo = Request.QueryString("FileNo")
            RequestNo = Request.QueryString("RequestNo")
            ProductType = Request.QueryString("ProductType")


            TextBox1.Focus()
            TextBox1.Text = Date.Now.ToString


            If op = "yenikayit" Then
                Button2.Visible = False
            End If


            If op = "duzenle" Then

                pkey = Request.QueryString("pkey")
                Button2.Visible = True
                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                damagecancel = damagecancel_erisim.bultek(pkey)

                TextBox1.Text = damagecancel.iptaltarih
                DropDownList1.SelectedValue = damagecancel.iptaltur
                DropDownList2.SelectedValue = damagecancel.iptalkullanicipkey

            End If


        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM


            result = damagecancel_erisim.Sil(Request.QueryString("pkey"))
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


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim hata As String

        Dim damagecancel As New CLASSDAMAGECANCEL
        Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM

        Dim FirmCode, ProductCode, AgencyCode As String
        Dim PolicyNumber, TecditNumber, FileNo As String
        Dim RequestNo, ProductType As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        Dim iptaltarih As Date

        hata = "0"

        'iptaltarih---------------------------
        Try
            iptaltarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>İptal tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try


        'iptal türü
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>İptal türünü seçmediniz.</li>"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            hatamesajlari = ""

            FirmCode = Request.QueryString("FirmCode")
            ProductCode = Request.QueryString("ProductCode")
            AgencyCode = Request.QueryString("AgencyCode")
            PolicyNumber = Request.QueryString("PolicyNumber")
            TecditNumber = Request.QueryString("TecditNumber")
            FileNo = Request.QueryString("FileNo")
            RequestNo = Request.QueryString("RequestNo")
            ProductType = Request.QueryString("ProductType")

            If DropDownList1.SelectedValue <> "Her İkisinden" Then

                damagecancel.FirmCode = FirmCode
                damagecancel.ProductCode = ProductCode
                damagecancel.AgencyCode = AgencyCode
                damagecancel.PolicyNumber = PolicyNumber
                damagecancel.TecditNumber = TecditNumber
                damagecancel.FileNo = FileNo
                damagecancel.RequestNo = RequestNo
                damagecancel.ProductType = ProductType
                damagecancel.iptaltur = DropDownList1.SelectedValue
                damagecancel.iptaltarih = TextBox1.Text
                damagecancel.iptalkullanicipkey = Session("kullanici_pkey")
                damagecancel.kayittarih = DateTime.Now


                If Request.QueryString("op") = "yenikayit" Then
                    result = damagecancel_erisim.Ekle(damagecancel)
                End If

                If Request.QueryString("op") = "duzenle" Then
                    damagecancel = damagecancel_erisim.bultek(Request.QueryString("pkey"))

                    damagecancel.FirmCode = FirmCode
                    damagecancel.ProductCode = ProductCode
                    damagecancel.AgencyCode = AgencyCode
                    damagecancel.PolicyNumber = PolicyNumber
                    damagecancel.TecditNumber = TecditNumber
                    damagecancel.FileNo = FileNo
                    damagecancel.RequestNo = RequestNo
                    damagecancel.ProductType = ProductType
                    damagecancel.iptaltur = DropDownList1.SelectedValue
                    damagecancel.iptaltarih = TextBox1.Text
                    damagecancel.iptalkullanicipkey = Session("kullanici_pkey")
                    damagecancel.kayittarih = DateTime.Now
                    result = damagecancel_erisim.Duzenle(damagecancel)
                End If

            End If 'her ikisinden değil ise


            If DropDownList1.SelectedValue = "Her İkisinden" Then

                damagecancel.FirmCode = FirmCode
                damagecancel.ProductCode = ProductCode
                damagecancel.AgencyCode = AgencyCode
                damagecancel.PolicyNumber = PolicyNumber
                damagecancel.TecditNumber = TecditNumber
                damagecancel.FileNo = FileNo
                damagecancel.RequestNo = RequestNo
                damagecancel.ProductType = ProductType
                damagecancel.iptaltur = "Kimlik"
                damagecancel.iptaltarih = TextBox1.Text
                damagecancel.iptalkullanicipkey = Session("kullanici_pkey")
                damagecancel.kayittarih = DateTime.Now
                If Request.QueryString("op") = "yenikayit" Then
                    result = damagecancel_erisim.Ekle(damagecancel)
                End If
                damagecancel.FirmCode = FirmCode
                damagecancel.ProductCode = ProductCode
                damagecancel.AgencyCode = AgencyCode
                damagecancel.PolicyNumber = PolicyNumber
                damagecancel.TecditNumber = TecditNumber
                damagecancel.FileNo = FileNo
                damagecancel.RequestNo = RequestNo
                damagecancel.ProductType = ProductType
                damagecancel.iptaltur = "Plaka"
                damagecancel.iptaltarih = TextBox1.Text
                damagecancel.iptalkullanicipkey = Session("kullanici_pkey")
                damagecancel.kayittarih = DateTime.Now
                If Request.QueryString("op") = "yenikayit" Then
                    result = damagecancel_erisim.Ekle(damagecancel)
                End If


                If Request.QueryString("op") = "duzenle" Then
                    damagecancel = damagecancel_erisim.bultek(Request.QueryString("pkey"))

                    damagecancel.FirmCode = FirmCode
                    damagecancel.ProductCode = ProductCode
                    damagecancel.AgencyCode = AgencyCode
                    damagecancel.PolicyNumber = PolicyNumber
                    damagecancel.TecditNumber = TecditNumber
                    damagecancel.FileNo = FileNo
                    damagecancel.RequestNo = RequestNo
                    damagecancel.ProductType = ProductType
                    damagecancel.iptaltur = DropDownList1.SelectedValue
                    damagecancel.iptaltarih = TextBox1.Text
                    damagecancel.iptalkullanicipkey = Session("kullanici_pkey")
                    damagecancel.kayittarih = DateTime.Now
                    result = damagecancel_erisim.Duzenle(damagecancel)

                    damagecancel.FirmCode = FirmCode
                    damagecancel.ProductCode = ProductCode
                    damagecancel.AgencyCode = AgencyCode
                    damagecancel.PolicyNumber = PolicyNumber
                    damagecancel.TecditNumber = TecditNumber
                    damagecancel.FileNo = FileNo
                    damagecancel.RequestNo = RequestNo
                    damagecancel.ProductType = ProductType
                    damagecancel.iptaltur = "Plaka"
                    damagecancel.iptaltarih = TextBox1.Text
                    damagecancel.iptalkullanicipkey = Session("kullanici_pkey")
                    damagecancel.kayittarih = DateTime.Now
                    result = damagecancel_erisim.Duzenle(damagecancel)
                End If

            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If


        End If

    End Sub
End Class