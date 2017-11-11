Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class bilgiservis
    Inherits System.Web.UI.Page


    '--ARAÇ MARKALARINI DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dolduraracmarka_cinsegore(ByVal araccinspkey As String) As List(Of CLASSARACMARKA)

        Dim aracmarkalari As New List(Of CLASSARACMARKA)

        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM
        aracmarkalari = aracmarka_erisim.doldur_araccinsgore(araccinspkey)
        Return aracmarkalari

    End Function


    '--ARAÇ MODELLERİNİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dolduraracmodel(ByVal araccinspkey As String, _
    ByVal aracmarkapkey As String) As List(Of CLASSARACMODEL)

        Dim aracmodelleri As New List(Of CLASSARACMODEL)
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM
        aracmodelleri = aracmodel_erisim.doldur_cinsvemarkayagore(araccinspkey, aracmarkapkey)
        Return aracmodelleri

    End Function


    '--TARİH DOĞRUMU
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function tarihdogrumu(ByVal tarih As String) As String

        Dim dogrumu As String = "Evet"

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim d As Date

        Try
            d = tarih
        Catch
            dogrumu = "Hayır"
        End Try

        Return dogrumu

    End Function


    '--PERT ARAÇ RESMİNİ SİL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function pertaracresimsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM

        result = pertaracresim_erisim.Sil(pkey)
        Return result

    End Function


    '--PERT ARAÇ RESİMLERİNİ LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function pertaracresimlistele(ByVal pertaracpkey As String) As String

        Dim donecek As String
        Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM
        donecek = pertaracresim_erisim.listele(pertaracpkey)
        Return donecek

    End Function



    '--PERT ARAÇ ANA RESİM YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function pertaracresimanaresimyap(ByVal pertaracpkey As String, _
    ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM
        result = pertaracresim_erisim.anaresimyap(pertaracpkey, pkey)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function webuyegoster(ByVal kriter As String) As String

        Dim donecek As String
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        HttpContext.Current.Session("ltip") = "adsoyad"
        HttpContext.Current.Session("kriter") = kriter
        donecek = webuye_erisim.listele()
        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function webuyeara(ByVal kriter As String) As List(Of CLASSWEBUYE)

        Dim webuye_erisim As New CLASSWEBUYE_ERISIM

        HttpContext.Current.Session("ltip") = "adsoyad"
        HttpContext.Current.Session("kriter") = kriter
        Return (webuye_erisim.ara("adsoyad", kriter))

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function uyeaktifyap(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim webuye As New CLASSWEBUYE

        webuye = webuye_erisim.bultek(pkey)
        webuye.aktifmi = "Evet"
        result = webuye_erisim.Duzenle(webuye)
        Return result

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function uyepasifyap(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim webuye As New CLASSWEBUYE

        webuye = webuye_erisim.bultek(pkey)
        webuye.aktifmi = "Hayır"
        result = webuye_erisim.Duzenle(webuye)
        Return result

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function logincontrol(ByVal kullaniciad As String, ByVal kullanicisifre As String) As CLADBOPRESULT

        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim result As New CLADBOPRESULT
        result = webuye_erisim.logincontrol(kullaniciad, kullanicisifre)
        Return result

    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bilgigrafikdata(ByVal neyegore As String) As List(Of CLASSGRAFIKBILGI)

        Dim pertarac_Erisim As New CLASSPERTARAC_ERISIM
        Return pertarac_Erisim.grafikdata(neyegore)

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function sifremigonder(ByVal eposta As String) As String

        Dim donecek As String
        Dim result As New CLADBOPRESULT

        Dim webuye_Erisim As New CLASSWEBUYE_ERISIM
        result = webuye_Erisim.sifremigonder(eposta)

        If result.durum = "Kaydedildi" Then
            donecek = "<div class='alert alert-success'>" + _
            "Şifreniz e-posta adresinize başarılı bir şekilde gönderildi" + _
            "</div>"
        End If

        If result.durum <> "Kaydedildi" Then
            donecek = "<div class='alert alert-danger'>" + result.hatastr + "</div>"
        End If

        Return donecek

    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listelepertaracsayfalama(ByVal sayfa As String, _
    ByVal pertaraclistesira As String, ByVal teksayfadakacadet As String, _
    ByVal aracmarkapkey As String) As String

        Dim donecek As String
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM

        HttpContext.Current.Session("safya") = sayfa
        HttpContext.Current.Session("pertaraclistesira") = pertaraclistesira
        HttpContext.Current.Session("teksayfadakacadet") = teksayfadakacadet
        HttpContext.Current.Session("aracmarkapkey") = aracmarkapkey
        donecek = pertarac_erisim.listeleblog()

        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function pertaracsayfalamayap(ByVal sayfa As String, _
    ByVal pertaraclistesira As String, ByVal teksayfadakacadet As String, _
    ByVal aracmarkapkey As String) As String

        Dim donecek As String
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM

        HttpContext.Current.Session("safya") = sayfa
        HttpContext.Current.Session("pertaraclistesira") = pertaraclistesira
        HttpContext.Current.Session("teksayfadakacadet") = teksayfadakacadet
        HttpContext.Current.Session("aracmarkapkey") = aracmarkapkey
        donecek = pertarac_erisim.sayfalamayap

        Return donecek

    End Function




    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function teklifokunduyap(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim teklif_erisim As New CLASSTEKLIF_ERISIM

        Dim teklif As New CLASSTEKLIF

        teklif = teklif_erisim.bultek(pkey)
        teklif.okunmusmu = "Evet"
        result = teklif_erisim.Duzenle(teklif)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function teklifokunmadiyap(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim teklif_erisim As New CLASSTEKLIF_ERISIM

        Dim teklif As New CLASSTEKLIF

        teklif = teklif_erisim.bultek(pkey)
        teklif.okunmusmu = "Hayır"
        result = teklif_erisim.Duzenle(teklif)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function gelenteklifgoster() As String

        Dim donecek As String
        Dim teklif_erisim As New CLASSTEKLIF_ERISIM
        HttpContext.Current.Session("ltip") = "sirketin"
        donecek = teklif_erisim.listele_sirketin
        Return donecek

    End Function


End Class