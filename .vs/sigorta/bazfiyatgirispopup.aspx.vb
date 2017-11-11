Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class bazfiyatgirispopup
    Inherits System.Web.UI.Page

    Dim bazfiyat As New CLASSBAZFIYAT
    Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM

    Dim bazfiyattarife As New CLASSBAZFIYATTARIFEY
    Dim bazfiyattarife_erisim As New CLASSBAZFIYATTARIFEY_ERISIM

    Dim aractarifeleri As New List(Of CLASSARACTARIFE)
    Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "bazfiyat"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("bazfiyat", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        Dim op As String

        If Not Page.IsPostBack Then

            op = Request.QueryString("op")

            If op = "duzenle" Then

                bazfiyat = bazfiyat_erisim.bultek(Request.QueryString("pkey"))
                Button3.Text = "Güncelle ve İleri ->"
                inn.Value = "1"
            End If

            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", 0))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            'POLİÇE TİPLERİNİ DOLDUR
            Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
            Dim policetipleri As New List(Of CLASSPOLICETIP)
            policetipleri = policetip_erisim.doldur()
            For Each item As CLASSPOLICETIP In policetipleri
                DropDownList2.Items.Add(New ListItem(item.policetipad, CStr(item.pkey)))
            Next

            If op = "yenikayit" Then
                Button5.Visible = False
                Labelinput.Text = bazfiyattarife_erisim.inputlariolustur(0, "yenikayit")
            End If

            If op = "duzenle" Then
                Button5.Visible = True
                bazfiyat = bazfiyat_erisim.bultek(Request.QueryString("pkey"))
                DropDownList1.SelectedValue = bazfiyat.sirketpkey
                TextBox1.Text = bazfiyat.baslangictarih
                TextBox7.Text = bazfiyat.kayittarih
                TextBox2.Text = bazfiyat.kayitno
                DropDownList2.SelectedValue = bazfiyat.policetip
                Labelinput.Text = bazfiyattarife_erisim.inputlariolustur(bazfiyat.pkey, "duzenle")
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

        'sirketpkey
        If DropDownList1.SelectedValue = "0" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Şirketi seçmediniz.</li>"
            inn.Value = "0"
        End If

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

            bazfiyat.sirketpkey = DropDownList1.SelectedValue
            bazfiyat.baslangictarih = TextBox1.Text
            bazfiyat.kayittarih = TextBox7.Text
            bazfiyat.kayitno = TextBox2.Text
            bazfiyat.policetip = DropDownList2.SelectedValue

            If Request.QueryString("op") = "yenikayit" Then
                result = bazfiyat_erisim.Ekle(bazfiyat)
                If result.durum = "Kaydedildi" Then
                    Dim duzenlemelink As String
                    duzenlemelink = "bazfiyatgirispopup.aspx?pkey=" + _
                    CStr(result.etkilenen) + "&op=duzenle"
                    inn.Value = "1"
                    Response.Redirect(duzenlemelink)
                End If
            End If

            If Request.QueryString("op") = "duzenle" Then
                bazfiyat = bazfiyat_erisim.bultek(Request.QueryString("pkey"))

                bazfiyat.sirketpkey = DropDownList1.SelectedValue
                bazfiyat.baslangictarih = TextBox1.Text
                bazfiyat.kayittarih = TextBox7.Text
                bazfiyat.kayitno = TextBox2.Text
                bazfiyat.policetip = DropDownList2.SelectedValue
                result = bazfiyat_erisim.Duzenle(bazfiyat)
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
                Dim pkey As String
                pkey = Request.QueryString("pkey")
                Dim duzenlemelink As String
                duzenlemelink = "bazfiyatgirispopup.aspx?pkey=" + _
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
        bazfiyat = bazfiyat_erisim.bultek(bazfiyatpkey)


        'önce tümünü sil---
        bazfiyattarife_erisim.ilgilisil(bazfiyatpkey)

        aractarifeleri = aractarife_erisim.doldur

        For Each itemaractarife As CLASSARACTARIFE In aractarifeleri
            'tek satır kaydet
            Dim ibazfiyattarife As New CLASSBAZFIYATTARIFEY
            ibazfiyattarife = bazfiyattarife_erisim.temizle(ibazfiyattarife)
            For i = 1 To 10
                Dim fiyat As Double
                Dim oi As String
                oi = "A" + CStr(itemaractarife.pkey) + "_" + CStr(i)

                Try
                    fiyat = Request.Form(oi)
                    If IsNumeric(fiyat) = False Then
                        fiyat = 0
                    End If
                Catch ex As Exception
                    fiyat = 0
                End Try

                ibazfiyattarife.bazfiyatpkey = bazfiyatpkey
                ibazfiyattarife.aractarifepkey = itemaractarife.pkey

                If i = 1 Then
                    ibazfiyattarife.trafikmiktar = fiyat
                End If
                If i = 2 Then
                    ibazfiyattarife.mintrafikmiktar = fiyat
                End If
                If i = 3 Then
                    ibazfiyattarife.kaskooran = fiyat
                End If
                If i = 4 Then
                    ibazfiyattarife.minkaskomiktar = fiyat
                End If
                If i = 5 Then
                    ibazfiyattarife.ftoran = fiyat
                End If
                If i = 6 Then
                    ibazfiyattarife.minftmiktar = fiyat
                End If
                If i = 7 Then
                    ibazfiyattarife.cooran = fiyat
                End If
                If i = 8 Then
                    ibazfiyattarife.cominmiktar = fiyat
                End If
                If i = 9 Then
                    ibazfiyattarife.pertkaskooran = fiyat
                End If
                If i = 10 Then
                    ibazfiyattarife.minpertkaskomiktar = fiyat
                End If
            Next
            bazfiyattarife_erisim.Ekle(ibazfiyattarife)
        Next

        Labelinput.Text = bazfiyattarife_erisim.inputlariolustur(bazfiyatpkey, "duzenle")
        inn.Value = "1"





    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click

        Dim bazfiyattarife_erisim As New CLASSBAZFIYATTARIFEY_ERISIM
        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            bazfiyat = bazfiyat_erisim.bultek(Request.QueryString("pkey"))
            result = bazfiyattarife_erisim.ilgilisil(Request.QueryString("pkey"))
            result = bazfiyat_erisim.Sil(Request.QueryString("pkey"))

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

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim eskibazfiyat As New CLASSBAZFIYAT
        Dim eski_kayitno As Integer
        bazfiyat = bazfiyat_erisim.bultek(Request.QueryString("pkey"))
        eski_kayitno = bazfiyat.kayitno - 1


        If eski_kayitno > 0 Then
            While eski_kayitno > 0
                eskibazfiyat = bazfiyat_erisim.bulsirketpkeykayitnovepolicetipgore(bazfiyat.sirketpkey, eski_kayitno, bazfiyat.policetip)
                'eğer eski baz fiyatı bulmuş ise
                If eskibazfiyat.pkey <> 0 Then
                    Labelinput.Text = bazfiyattarife_erisim.inputlariolustur(eskibazfiyat.pkey, "duzenle")
                    Exit While
                End If
                eski_kayitno = eski_kayitno - 1
            End While
        End If


    End Sub
End Class