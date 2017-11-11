Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class sirketbazfiyatgirispopup
    Inherits System.Web.UI.Page


    Dim bazfiyat As New CLASSBAZFIYAT
    Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM

    Dim bazfiyattarife As New CLASSBAZFIYATTARIFEY
    Dim bazfiyattarife_erisim As New CLASSBAZFIYATTARIFEY_ERISIM

    Dim aractarifeleri As New List(Of CLASSARACTARIFE)
    Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirketbazfiyatgirispopup", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        'silme düğmesini disable et çünkü burası şirket
        Button5.Visible = False

        Dim op As String

        If Not Page.IsPostBack Then

            op = Request.QueryString("op")

            If op = "duzenle" Then
                Button3.Text = "Güncelle ve İleri ->"
            End If

            'BAK BAKALIM SÜRE DURUMU TAMAM MI 
            Dim bazfiyatgirissure_erisim As New CLASSBAZFIYATGIRISSURE_ERISIM
            Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
            bazfiyatgirissure = bazfiyatgirissure_erisim.sureyetkilimi

            If bazfiyatgirissure.pkey = 0 Then
                durumlabel.Text = "Bu zaman aralığı zarfında baz fiyat girişi yada düzenlemesi yapamazsınız."
                Button1.Visible = False
                Button3.Visible = False
                Button5.Visible = False
            End If


            If bazfiyatgirissure.pkey <> 0 Then

                Dim dn As Date
                dn = Date.Now
                TextBox2.ReadOnly = True
                TextBox1.ReadOnly = True
                TextBox7.ReadOnly = True
                TextBox2.Text = bazfiyatgirissure.kayitno
                TextBox1.Text = bazfiyatgirissure.gecerlilikbaslangic
                TextBox7.Text = DateTime.Now.ToShortDateString

                If op = "yenikayit" Then
                    TextBox7.Text = dn.ToShortDateString
                End If
                Dim policetip As New CLASSPOLICETIP
                Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
                policetip = policetip_erisim.bultek(bazfiyatgirissure.policetip)
                DropDownList2.Items.Add(New ListItem(policetip.policetipad, CStr(policetip.pkey)))
                DropDownList2.SelectedValue = bazfiyatgirissure.policetip

                uyarilabel.Text = "Baz fiyatlarınızı ancak " + CStr(bazfiyatgirissure.girisbaslangic) + " ile " + _
                CStr(bazfiyatgirissure.girisbitis) + " tarihleri arasında girmeniz gerekmektedir." + "<br/>"

                bilgilendirmelabel.Text = "Gireceğiniz baz fiyatlar " + _
                CStr(bazfiyatgirissure.gecerlilikbaslangic) + " tarihinden itibaren geçerli olacaktır."

            End If

            'SADECE AKTİF ŞİRKETİ DOLDUR---------------------------------------
            Dim sirket As New CLASSSIRKET
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim aktifsirketpkey = Session("kullanici_aktifsirket")
            sirket = sirket_erisim.bultek(aktifsirketpkey)
            DropDownList1.Items.Add(New ListItem(sirket.sirketad, CStr(sirket.pkey)))


            If op = "yenikayit" Then
                Button5.Visible = False
                Labelinput.Text = bazfiyattarife_erisim.inputlariolustur(0, "yenikayit")
            End If

            If op = "duzenle" Then

                bazfiyat = bazfiyat_erisim.bultek(Request.QueryString("pkey"))
                'BAK BAKALIM BU PKEY Lİ BAZ FİYAT O ŞİRKETİN Mİ 
                If bazfiyat.sirketpkey = Session("aktif_sirketpkey") Then
                    Response.Redirect("yetkisiz.aspx")
                End If

                If bazfiyatgirissure.kayitno <> bazfiyat.kayitno Then
                    Response.Redirect("yetkisiz.aspx")
                End If

                DropDownList1.SelectedValue = bazfiyat.sirketpkey
                TextBox1.Text = bazfiyat.baslangictarih
                TextBox7.Text = bazfiyat.kayittarih
                TextBox2.Text = bazfiyat.kayitno
                DropDownList2.SelectedValue = bazfiyat.policetip
                Labelinput.Text = bazfiyattarife_erisim.inputlariolustur(bazfiyat.pkey, "duzenle")


            End If

        End If 'postback


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
                    duzenlemelink = "sirketbazfiyatgirispopup.aspx?pkey=" + _
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


End Class