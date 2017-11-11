Public Partial Class yonetimgiris
    Inherits System.Web.UI.Page

    Dim loggenel As New CLASSLOGGENEL
    Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM

    Dim ziyaretci As New CLASSZIYARETCI
    Dim ziyaretci_erisim As New CLASSZIYARETCİ_ERISIM

    Dim ip_erisim As New CLASSIP_ERISIM


    Dim site As New CLASSSITE
    Dim site_erisim As New CLASSSITE_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        site = site_erisim.bultek(1)
        Session("veritabaniad") = site.sistemveritabaniad


        If Not Page.IsPostBack Then

            'logla 
            ziyaretci.ipadres = ip_erisim.ipadresibul
            ziyaretci.tarih = DateTime.Now
            ziyaretci_erisim.Ekle(ziyaretci)

            Literalziyaretcisayi.Text = "Bugün " + "<b>" + CStr(ziyaretci_erisim.bugunkuziyaretcisayisi) + "</b>" + _
            " olmak üzere toplam " + "<b>" + CStr(ziyaretci_erisim.toplamziyaretcisayisi) + "</b>" + " ziyaretçi."


            If Session("kullanici_baglantikesildimi") = "Evet" Then
                Labeluyari.Text = "<div class='alert alert-danger'>" + _
                "Bağlantınız sistem yöneticiniz tarafından geçici bir süreliğine kesilmiştir." + _
                "</div>"
            End If
        End If

        Dim capqs As String
        capqs = Request.QueryString("cap")

        If capqs = "error" Then
            Labeluyari.Text = "<div class='alert alert-danger'>" + _
             "Resim doğrulama yanlış girdiniz." + _
             "</div>"
        End If

        Labelcopyright.Text = site.copyrighttext

        If site.captcha = "Evet" Then
            capkontrol.Visible = True
        Else
            capkontrol.Visible = False
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim captchadogrumu As Boolean
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim kacyanlis, sistem_yanlissifrecount As Integer
        sistem_yanlissifrecount = site.yanlissifrecount
        Dim cokkezyanlisgirdi = "Hayır"

        Dim result As New CLADBOPRESULT
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim kullaniciad, kullanicisifre As String
        Dim hata As String = ""
        Dim hatamsg As String = ""

        kullaniciad = TextBox1.Text
        kullanicisifre = TextBox2.Text


        '--------------CAPCHA ------------------------------------
        captchadogrumu = False
        If site.captcha = "Evet" Then
            If TextBox3.Text <> "" Then
                CaptchaControl1.ValidateCaptcha(TextBox3.Text)
                If CaptchaControl1.UserValidated = True Then
                    captchadogrumu = True
                End If
            End If

            If captchadogrumu = False Then
                Response.Redirect("yonetimgiris.aspx?cap=error")
            End If
        End If
        '--------------------------------------------------------

        If site.captcha = "Hayır" Then
            captchadogrumu = True
        End If

        If captchadogrumu = True Then

            result = kullanici_erisim.logincontrol(kullaniciad, kullanicisifre)
            kacyanlis = kullanici_erisim.sifresinikackereyanlisgirmis(DateTime.Now, kullaniciad)

            If kacyanlis >= sistem_yanlissifrecount Then
                cokkezyanlisgirdi = "Evet"
                Labeluyari.Text = "<div class='alert alert-danger'>" + _
                "Şifrenizi bugün içerisinde " + CStr(sistem_yanlissifrecount) + _
                " sayısına eşit yada bu sayıdan fazla miktarda hatalı girdiniz. " + _
                " Şifrenizin sıfırlanması için lütfen KKSBM ile iletişime geçiniz." + _
                "</div>"
            End If

            If result.durum = "Hayır" Then
                Labeluyari.Text = "<div class='alert alert-danger'>" + _
                result.hatastr + _
                "</div>"

                '---LOGLA
                loggenel = New CLASSLOGGENEL(0, DateTime.Now, 0, "", _
                "kullanici", "Hatalı Giriş", "", "", 0, _
                "Hayır", kullaniciad, kullanicisifre, "Web")

                loggenel_erisim.Ekle(loggenel)
            End If

            If cokkezyanlisgirdi = "Hayır" And result.durum = "Evet" Then

                '---LOGLA --------------------------------------------------------------
                loggenel = New CLASSLOGGENEL(0, DateTime.Now, result.etkilenen, "", _
                "kullanici", "Giriş", "", "", 0, "Hayır", kullaniciad, kullanicisifre, "Web")
                loggenel_erisim.Ekle(loggenel)

                Dim kullanicirol As New CLASSKULLANICIROL
                Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
                Dim kullanici As New CLASSKULLANICI
                kullanici = kullanici_erisim.bultek(result.etkilenen)
                kullanicirol = kullanicirol_erisim.bultek(kullanici.rolpkey)
                Session("kullanici_pkey") = kullanici.pkey
                Session("kullanici_adsoyad") = kullanici.adsoyad
                Session("kullanici_rolpkey") = kullanicirol.pkey
                Session("kullanici_resimpkey") = kullanici.resimpkey
                Session("kullanici_sirketpkey") = kullanici.sirketpkey
                Session("kullanici_acentepkey") = kullanici.acentepkey
                Session("kullanici_eposta") = kullanici.eposta
                Session("kullanici_mensup") = kullanicirol.mensup
                Session("veritabaniad") = site.sistemveritabaniad


                'bu adam şirket admini aktif şirketini otomatik at
                If kullanici.rolpkey = "2" Or kullanici.rolpkey = "3" Or kullanici.rolpkey = "6" Or kullanici.rolpkey = "7" Then
                    Session("kullanici_aktifsirket") = CStr(kullanici.sirketpkey)
                End If

                Response.Redirect(kullanicirol.yonsayfa)


            End If

        End If 'captcha doğruysa 


    End Sub


End Class