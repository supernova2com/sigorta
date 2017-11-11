Public Partial Class msgservis
    Inherits System.Web.UI.Page


    'MSG GÖNDERENLERİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function msggonderilecekliste() As List(Of CLASSKULLANICI)
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Return (kullanici_erisim.doldurbenimdisimda())
    End Function

    'AJAX MESAJ SERVİSİ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function ajaxmsgekle(ByVal alanpkey As String, ByVal msgmetin As String, _
    ByVal msgkonu As String, ByVal op As String, ByVal tmesaj As String) As String

        Dim site_erisim As New CLASSSITE_ERISIM

        Dim site As New CLASSSITE
        site = site_erisim.bultek(1)


        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM
        Dim dboresult As New CLADBOPRESULT
        Dim email As New CLASSEMAIL
        Dim email_erisim As New CLASSEMAIL_ERISIM


        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim epostaalacak As New CLASSKULLANICI
        Dim epostaalacak_erisim As New CLASSKULLANICI_ERISIM

        kullanici = kullanici_erisim.bultek(HttpContext.Current.Session("kullanicipkey"))
        epostaalacak = kullanici_erisim.bultek(alanpkey)

        If tmesaj = "Hayır" Then

            msg.alanpkey = alanpkey
            msg.msgkonu = msgkonu
            msg.msgmetin = msgmetin
            msg.gonderenpkey = kullanici.pkey
            msg.alansilmismi = "Hayır"
            msg.gonderensilmismi = "Hayır"
            msg.gondermetarih = DateTime.Now
            msg.okunmusmu = "Hayır"

            If op = "yenikayit" Then
                dboresult = msg_erisim.ekle(msg)
            End If

            'If epostaalacak.emailgonderilsinmi = "Evet" Then
            'EPOSTA GÖNDER--------------------------------------------------
            'email.kimden = site.kimdenmail
            'email.kime = epostaalacak.gercekeposta

            'email.subject = " Gönderen:" + HttpContext.Current.Session("adsoyad") + _
            '" Konu:" + msg.msgkonu

            'email.body = msg.msgmetin
            'If epostaalacak.emailgonderilsinmi = "Evet" Then
            'email_erisim.gonder(email)
            'End If
            '-------------------------------------------------------------
            'End If

            Return dboresult.durum

        End If

        If tmesaj = "Evet" Then

            Dim tumkullanicilar As New List(Of CLASSKULLANICI)
            tumkullanicilar = kullanici_erisim.doldur()

            For Each item As CLASSKULLANICI In tumkullanicilar

                msg.alanpkey = item.pkey
                msg.msgkonu = msgkonu
                msg.msgmetin = msgmetin
                msg.gonderenpkey = kullanici.pkey
                msg.alansilmismi = "Hayır"
                msg.gonderensilmismi = "Hayır"
                msg.gondermetarih = DateTime.Now
                msg.okunmusmu = "Hayır"

                dboresult = msg_erisim.ekle(msg)

            Next

        End If

    End Function


    'AJAX MESAJ SİL SERVİSİ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub ajaxmsgsil(ByVal pkey As String)

        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.sil(pkey)

    End Sub


    'AJAX ALAN SİLMİŞMİ DÜZENLE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub ajaxalansilmismiduzenle(ByVal pkey As String)

        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.alansilmismiduzenle(pkey)

    End Sub


    'AJAX MESAJ LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function ajaxmsglistele() As String


        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM
        Return (msg_erisim.listeleilgili(HttpContext.Current.Session("kullanici_pkey")))

    End Function


    'AJAX MESAJI OKUNDU YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub ajaxmsgokunduyap(ByVal pkey As String)

        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.okunduyap(pkey)

    End Sub


    'AJAX MESAJI OKUNMAMIS MSG SAYISI
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function okunmamismsgsayisi() As String

        Dim kimin As String
        kimin = HttpContext.Current.Session("kullanici_pkey")
        Dim msg As New CLASSMSG
        Dim msg_erisim As New CLASSMSG_ERISIM
        Return (CStr(msg_erisim.okunmamismsgsayisi(kimin)))

    End Function


    'ALAN KİŞİ DOSYAYI SİLMİŞ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub msgalansil(ByVal pkey As String)

        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.alansilmismiduzenle(pkey)

    End Sub

    'GÖNDEREN KİŞİ MESAJI SİLMİŞ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub msggonderensil(ByVal pkey As String)

        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.gonderensilmismiduzenle(pkey)

    End Sub

    'MESAJ OKUNDU YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub msgokunduyap(ByVal pkey As String)

        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.okunduyap(pkey)

    End Sub


    'MESAJ OKUNMADI YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub msgokunmadiyap(ByVal pkey As String)


        Dim msg_erisim As New CLASSMSG_ERISIM
        msg_erisim.okunmadiyap(pkey)

    End Sub


    'GELEN MESAJLARIMI LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function gelenmesajlarimilistele() As String

        Dim donecek As String

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")
        Dim msg_erisim As New CLASSMSG_ERISIM
        donecek = msg_erisim.gelenmesajlarim(kimin)

        Return donecek

    End Function


    'GÖNDERDİĞİM MESAJLARIMI LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function gonderdigimmesajlarilistele() As String

        Dim donecek As String

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")

        Dim msg_erisim As New CLASSMSG_ERISIM
        donecek = msg_erisim.gonderdigimmesajlarim(kimin)

        Return donecek

    End Function



    'MESAJLARI ÖZİZLE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function msgonizle() As String

        Dim donecek As String

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")

        Dim msg_erisim As New CLASSMSG_ERISIM
        donecek = msg_erisim.msgonizle(kimin)

        Return donecek

    End Function



    '-------------------------------------------------------------------------------------
    '---------------------------DOSYA-----------------------------------------------------
    '----------------------------------------------------------------------------------

    'ALAN KİŞİ DOSYAYI SİLMİŞ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub dosyaalansil(ByVal pkey As String)

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM
        dosya_erisim.alansilmismiduzenle(pkey)

    End Sub

    'DOSYA OKUNDU YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub dosyaokunduyap(ByVal pkey As String)

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM
        dosya_erisim.okunduyap(pkey)

    End Sub


    'DOSYA OKUNMADI YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub dosyaokunmadiyap(ByVal pkey As String)

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM
        dosya_erisim.okunmadiyap(pkey)

    End Sub

    'OKUNMAMIS DOSYA SAYISI
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function okunmamisdosyasayisi() As Integer

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM
        Return (dosya_erisim.okunmamisdosyasayisi(kimin))

    End Function


    'DOSYA ÖNİZLEME
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function dosyaonizle() As String

        Dim donecek As String

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM

        donecek = dosya_erisim.dosyaonizle(kimin)
        Return donecek

    End Function



    'GELEN DOSYALARIMI LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function gelendosyalarimlistele() As String

        Dim donecek As String

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM

        donecek = dosya_erisim.gelendosyalarim(kimin)

        Return donecek

    End Function


    'GÖNDERDİĞİM DOSYALARIMI LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function gonderdigimdosyalarimlistele() As String

        Dim donecek As String

        Dim kimin As Integer
        kimin = HttpContext.Current.Session("kullanici_pkey")

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM

        donecek = dosya_erisim.gonderdigimdosyalarim(kimin)

        Return donecek

    End Function



    'GÖNDEREN KİŞİ DOSYAYI SİLMİŞ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Sub dosyagonderensil(ByVal pkey As String)

        Dim dosya As New CLASSDOSYA
        Dim dosya_erisim As New CLASSDOSYA_ERISIM
        dosya_erisim.gonderensilmismiduzenle(pkey)

    End Sub



    'KULLANICILARI DOLDURUYORUZ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function kullanicidoldur() As List(Of CLASSKULLANICI)

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Return kullanici_erisim.doldur

    End Function


    'KULLANICI TİPLERİNİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function kullanicigrupdoldur() As List(Of CLASSKULLANICIGRUP)

        Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM
        Dim kullanicigruplari As New List(Of CLASSKULLANICIGRUP)
        kullanicigruplari = kullanicigrup_erisim.doldur
        Return kullanicigruplari

    End Function


    'KULLANICI LİSTESİNİ DOLDUR KULLANICIGRUPPKEY E GÖRE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
     Public Shared Function kullanicidoldur_kullanicigrupgore(ByVal kullanicigruppkey As String) _
     As List(Of CLASSKULLANICI)

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullaniciler As New List(Of CLASSKULLANICI)
        kullaniciler = kullanici_erisim.doldur_kullanicigruppkeyegore(kullanicigruppkey)

        Return kullaniciler

    End Function


End Class