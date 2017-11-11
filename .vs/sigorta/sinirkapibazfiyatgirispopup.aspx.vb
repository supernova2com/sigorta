Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class sinirkapibazfiyatgirispopup
    Inherits System.Web.UI.Page

    Dim sinirkapibazfiyat As New CLASSSINIRKAPIBAZFIYAT
    Dim sinirkapibazfiyat_erisim As New CLASSSINIRKAPIBAZFIYAT_ERISIM

    Dim bazfiyattarifesinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI
    Dim bazfiyattarifesinirkapi_erisim As New CLASSBAZFIYATTARIFESINIRKAPI_ERISIM

    Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
    Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM
    Dim sinirkapiaractipleri As New List(Of CLASSSINIRKAPIARACTIP)




    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "sinirkapibazfiyat"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        Dim op As String

        If Not Page.IsPostBack Then


            TextBox2.ReadOnly = True

            op = Request.QueryString("op")

            If op = "duzenle" Then

                sinirkapibazfiyat = sinirkapibazfiyat_erisim.bultek(Request.QueryString("pkey"))
                Button3.Text = "Güncelle ve İleri ->"
                inn.Value = "1"
            End If
         
            If op = "yenikayit" Then
                Button5.Visible = False
                TextBox2.Text = CStr(sinirkapibazfiyat_erisim.ensonkayitnobul + 1)
                Labelinput.Text = bazfiyattarifesinirkapi_erisim.inputlariolustur(0, "yenikayit")
            End If

            If op = "duzenle" Then
                Button5.Visible = True
                sinirkapibazfiyat = sinirkapibazfiyat_erisim.bultek(Request.QueryString("pkey"))

                TextBox1.Text = sinirkapibazfiyat.baslangictarih
                TextBox7.Text = sinirkapibazfiyat.kayittarih
                TextBox2.Text = sinirkapibazfiyat.kayitno

                Labelinput.Text = bazfiyattarifesinirkapi_erisim.inputlariolustur(sinirkapibazfiyat.pkey, "duzenle")
            End If

        End If 'postback


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button1.Visible = False
            Button3.Visible = False
        Else
            Button1.Visible = True
            Button3.Visible = True
        End If
        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        If yetki.deleteyetki = "Hayır" Then
            Button5.Visible = False
        End If
        If yetki.deleteyetki = "Evet" And opy = "duzenle" Then
            Button5.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------


    End Sub



    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangictarih, kayittarih As Date

        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"


        'baslangictarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
            inn.Value = "0"
        End Try

        'kayittarih---------------------------
        Try
            baslangictarih = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
            inn.Value = "0"
        End Try

        'kayitno
        If IsNumeric(TextBox2.Text) = False Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Kayıt numarası rakamsal olmalıdır.</li>"
            inn.Value = "0"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            hatamesajlari = ""

            sinirkapibazfiyat.baslangictarih = TextBox1.Text
            sinirkapibazfiyat.kayittarih = TextBox7.Text
            sinirkapibazfiyat.kayitno = TextBox2.Text

            If Request.QueryString("op") = "yenikayit" Then
                result = sinirkapibazfiyat_erisim.Ekle(sinirkapibazfiyat)
                If result.durum = "Kaydedildi" Then
                    Dim duzenlemelink As String
                    duzenlemelink = "sinirkapibazfiyatgirispopup.aspx?pkey=" + _
                    CStr(result.etkilenen) + "&op=duzenle"
                    inn.Value = "1"
                    Response.Redirect(duzenlemelink)
                End If
            End If

            If Request.QueryString("op") = "duzenle" Then
                sinirkapibazfiyat = sinirkapibazfiyat_erisim.bultek(Request.QueryString("pkey"))

                sinirkapibazfiyat.baslangictarih = TextBox1.Text
                sinirkapibazfiyat.kayittarih = TextBox7.Text
                sinirkapibazfiyat.kayitno = TextBox2.Text

                result = sinirkapibazfiyat_erisim.Duzenle(sinirkapibazfiyat)
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
                Dim pkey As String
                pkey = Request.QueryString("pkey")
                Dim duzenlemelink As String
                duzenlemelink = "sinirkapibazfiyatgirispopup.aspx?pkey=" + _
                CStr(pkey) + "&op=duzenle"
                inn.Value = "1"
                Response.Redirect(duzenlemelink)
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            'Label1.Text = bazfiyattarife_erisim.listele("")
        End If

    End Sub

    'bazfiyat tarifeleri kaydet...
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim bazfiyatpkey As String
        bazfiyatpkey = Request.QueryString("pkey")
        sinirkapibazfiyat = sinirkapibazfiyat_erisim.bultek(bazfiyatpkey)


        'önce tümünü sil---
        bazfiyattarifesinirkapi_erisim.ilgilisil(bazfiyatpkey)
        sinirkapiaractipleri = sinirkapiaractip_erisim.doldur

        For Each itemaractip As CLASSSINIRKAPIARACTIP In sinirkapiaractipleri
            'tek satır kaydet
            Dim ibazfiyattarifesinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI
            ibazfiyattarifesinirkapi = bazfiyattarifesinirkapi_erisim.temizle(ibazfiyattarifesinirkapi)
            For i = 1 To 5
                Dim fiyat As Double
                Dim oi As String
                oi = "A" + CStr(itemaractip.pkey) + "_" + CStr(i)

                Try
                    fiyat = Request.Form(oi)
                    If IsNumeric(fiyat) = False Then
                        fiyat = 0
                    End If
                Catch ex As Exception
                    fiyat = 0
                End Try

                ibazfiyattarifesinirkapi.bazfiyatpkey = bazfiyatpkey
                ibazfiyattarifesinirkapi.sinirkapiaractippkey = itemaractip.pkey

                If i = 1 Then
                    ibazfiyattarifesinirkapi.ucgun = fiyat
                End If
                If i = 2 Then
                    ibazfiyattarifesinirkapi.biray = fiyat
                End If
                If i = 3 Then
                    ibazfiyattarifesinirkapi.ucay = fiyat
                End If
                If i = 4 Then
                    ibazfiyattarifesinirkapi.altiay = fiyat
                End If
                If i = 5 Then
                    ibazfiyattarifesinirkapi.onikiay = fiyat
                End If
               
            Next
            bazfiyattarifesinirkapi_erisim.Ekle(ibazfiyattarifesinirkapi)
        Next

        Labelinput.Text = bazfiyattarifesinirkapi_erisim.inputlariolustur(bazfiyatpkey, "duzenle")
        inn.Value = "1"





    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click

        Dim bazfiyattarifesinirkapi_erisim As New CLASSBAZFIYATTARIFESINIRKAPI_ERISIM
        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            sinirkapibazfiyat = sinirkapibazfiyat_erisim.bultek(Request.QueryString("pkey"))
            result = bazfiyattarifesinirkapi_erisim.ilgilisil(Request.QueryString("pkey"))
            result = sinirkapibazfiyat_erisim.Sil(Request.QueryString("pkey"))

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


End Class