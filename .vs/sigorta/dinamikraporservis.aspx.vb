Imports System.Globalization.CultureInfo
Imports System.Globalization


Partial Public Class dinamikraporservis
    Inherits System.Web.UI.Page


    'kullanilacak tablo goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kullanilacaktablogoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = kullanilacaktablo_erisim.listele()

        Return donecek
    End Function
    'gosterilecefield goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function gosterilecekfieldgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = gosterilecekfield_erisim.listele()

        Return donecek
    End Function
    'kosulfield goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kosulfieldgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = kosulfield_erisim.listele()

        Return donecek
    End Function
    'siralamafield goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function siralamafieldgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = siralamafield_erisim.listele()

        Return donecek
    End Function
    'grupfield goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function grupfieldgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = grupfield_erisim.listele()

        Return donecek
    End Function
    'aggfunc goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aggfuncgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = aggfunc_erisim.listele()

        Return donecek
    End Function

    'grafik goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporgrafikgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = dinamikraporgrafik_erisim.listele()

        Return donecek
    End Function

    'dinamikraporzamanlama goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporzamanlamabaggoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = dinamikraporzamanlama_erisim.listele()

        Return donecek
    End Function

    'dinamikkullanici goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikkullanicibaggoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = dinamikkullanicibag_erisim.listele()

        Return donecek
    End Function


    'dinamikrapor zamanlama göster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporzamanlamagoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = dinamikraporzamanlama_erisim.listele()

        Return donecek
    End Function


    'SİLMELER ----------------------------------------------------------------------------
    'kullanilacaktablo sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kullanilacaktablosil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        result = kullanilacaktablo_erisim.Sil(pkey)
        Return result

    End Function
    'gosterilecekfield sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function gosterilecekfieldsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        result = gosterilecekfield_erisim.Sil(pkey)
        Return result

    End Function
    'kosulfield sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kosulfieldsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        result = kosulfield_erisim.Sil(pkey)
        Return result

    End Function
    'siralamafield sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function siralamafieldsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
        result = siralamafield_erisim.Sil(pkey)
        Return result

    End Function
    'grupfield sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function grupfieldsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        result = grupfield_erisim.Sil(pkey)
        Return result

    End Function
    'aggfunc sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aggfuncsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
        result = aggfunc_erisim.Sil(pkey)
        Return result

    End Function

    'dinamikraporgrafik sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporgrafiksil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
        result = dinamikraporgrafik_erisim.Sil(pkey)
        Return result

    End Function

    'dinamikraporzamanlama sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporzamanlamasil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
        result = dinamikraporzamanlama_erisim.Sil(pkey)
        Return result

    End Function

    'dinamikkullanicibag sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikkullanicibagsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
        result = dinamikkullanicibag_erisim.Sil(pkey)
        Return result

    End Function


    'GOSTERİLECEKFIELD SIRALAMA YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Sub gosterilecekfieldsiralamayap(ByVal raporpkey As String, ByVal degerler As String)

        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        gosterilecekfield_erisim.siralamayap(raporpkey, degerler)

    End Sub
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function siralamagoster(ByVal raporpkey As String) As String

        Dim jvstring As String
        jvstring = "<script>" + _
        "jQuery(document).ready(function() {" + _
        "$('#sortable').bind('sortupdate', function(event, ui) {" + _
        "var raporpkey;" + _
        "var siralaarr = new Array();" + _
        "var degerler = '';" + _
        "siralaarr = $(this).sortable('toArray');" + _
        "$.each(siralaarr, function(key, value) {" + _
            "degerler = degerler + value + ','" + _
        "});" + _
        "raporpkey= getQuerystring('pkey');" + _
        "degerler = degerler.substring(0, degerler.length - 1);" + _
        "var veriler = {raporpkey:raporpkey, degerler: degerler};" + _
        "$.ajax({" + _
        "type:   'POST'," + _
        "url:    'dinamikraporservis.aspx/gosterilecekfieldsiralamayap'," + _
        "contentType:  'application/json; charset=utf-8'," + _
        "dataType:  'json'," + _
        "data: $.toJSON(veriler),  " + _
        "success: function(result) {" + _
        "siralamagoster(raporpkey);" + _
        "gosterilecekfieldgoster(raporpkey);" + _
        "}," + _
        "error: function() {" + _
        "alert('Sıralama işlemini gerçekleştiremiyorum.');" + _
        "}" + _
        "});" + _
        "});" + _
            "$('.sortable').sortable({" + _
                "placeholder:  'ui-state-highlight'," + _
                "axis:   'y'," + _
            "});" + _
        "});" + _
        "</script>"

        Dim donecek As String
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        donecek = gosterilecekfield_erisim.siralamagoster(raporpkey) + jvstring
        Return donecek

    End Function


    'ARABİRİM OLUŞTUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function arabirimolustur(ByVal raporpkey As String) As String

        Dim donecek As String
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        donecek = dinamikrapor_erisim.arabirimolustur(raporpkey)
        Return donecek

    End Function


    'RAPOR BULTEK
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function bultek(ByVal raporpkey As String) As CLASSDINAMIKRAPOR

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)

        Return dinamikrapor

    End Function


    'VERİLERİ SESSİON A KAYDET
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function raporpkeykaydet(ByVal raporpkey As String)

        HttpContext.Current.Session("raporpkey") = raporpkey

    End Function


    'GRUP SIRALAMA YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Sub grupfieldsiralamayap(ByVal raporpkey As String, ByVal degerler As String)

        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        grupfield_erisim.siralamayap(raporpkey, degerler)

    End Sub
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function grupfieldsiralamagoster(ByVal raporpkey As String) As String

        Dim jvstring As String
        jvstring = "<script>" + _
        "jQuery(document).ready(function() {" + _
        "$('#sortablegrup').bind('sortupdate', function(event, ui) {" + _
        "var raporpkey;" + _
        "var siralaarr = new Array();" + _
        "var degerler = '';" + _
        "siralaarr = $(this).sortable('toArray');" + _
        "$.each(siralaarr, function(key, value) {" + _
            "degerler = degerler + value + ','" + _
        "});" + _
        "raporpkey= getQuerystring('pkey');" + _
        "degerler = degerler.substring(0, degerler.length - 1);" + _
        "var veriler = {raporpkey:raporpkey, degerler: degerler};" + _
        "$.ajax({" + _
        "type:   'POST'," + _
        "url:    'dinamikraporservis.aspx/grupfieldsiralamayap'," + _
        "contentType:  'application/json; charset=utf-8'," + _
        "dataType:  'json'," + _
        "data: $.toJSON(veriler),  " + _
        "success: function(result) {" + _
        "grupfieldsiralamagoster(raporpkey);" + _
        "grupfieldgoster(raporpkey);" + _
        "}," + _
        "error: function() {" + _
        "alert('Sıralama işlemini gerçekleştiremiyorum.');" + _
        "}" + _
        "});" + _
        "});" + _
            "$('#sortablegrup').sortable({" + _
                "placeholder:  'ui-state-highlight'," + _
                "axis:   'y'," + _
            "});" + _
        "});" + _
        "</script>"

        Dim donecek As String
        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        donecek = grupfield_erisim.siralamagoster(raporpkey) + jvstring
        Return donecek

    End Function



    'OTO SQL OLUŞTUR DROPDOWN LİST İÇİN
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function otosqlolustur(ByVal deger As String, _
      ByVal yazi As String, ByVal tabload As String) As String

        Dim donecek As String
        Dim dropdownlist_erisim As New CLASSDROPDOWNLIST_ERISIM
        donecek = dropdownlist_erisim.otosqlolustur(deger, yazi, tabload)
        Return donecek

    End Function


    'RAPOR BİLGİLERİNİ BUL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function bultek_rapor(ByVal raporpkey As String) As CLASSDINAMIKRAPOR

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
        Return dinamikrapor

    End Function


    'GRAFİK BİLGİLERİNİ BUL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function bultek_grafikbilgi_raporpkeyden(ByVal raporpkey As String) As List(Of CLASSDINAMIKRAPORGRAFIK)

        Dim dinamikraporgrafikler As New List(Of CLASSDINAMIKRAPORGRAFIK)
        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
        dinamikraporgrafikler = dinamikraporgrafik_erisim.doldurilgili(raporpkey)
        Return dinamikraporgrafikler

    End Function


    'GRAFİK BİLGİSİ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function grafikdata(ByVal raporpkey As String) As List(Of CLASSGRAFIKBILGI)

        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
        Return (dinamikraporgrafik_erisim.grafikdatagonder(raporpkey))

    End Function


    'VTABLO 
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bul_vtablo(ByVal tabload As String) As CLASSVTABLO

        Dim vtablo As New CLASSVTABLO
        Dim vtablo_erisim As New CLASSVTABLO_ERISIM
        vtablo = vtablo_erisim.bultabloadagore(tabload)
        Return vtablo

    End Function

    'VKOLON
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bul_vkolon(ByVal tabload As String, ByVal kolonad As String) As CLASSVKOLON

        Dim vkolon As New CLASSVKOLON
        Dim vkolon_erisim As New CLASSVKOLON_ERISIM
        vkolon = vkolon_erisim.bultablovekolonadagore(tabload, kolonad)
        Return vkolon

    End Function


    'dinamikraporjavascript goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporjavascriptgoster(ByVal raporpkey As String) As String
        Dim donecek As String

        Dim dinamikraporjavascript_erisim As New CLASSDINAMIKRAPORJAVASCRIPT_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("raporpkey") = raporpkey
        donecek = dinamikraporjavascript_erisim.listele()

        Return donecek
    End Function

    'dinamikraporjavascript sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dinamikraporjavascriptsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim dinamikraporjavascript_erisim As New CLASSDINAMIKRAPORJAVASCRIPT_ERISIM
        result = dinamikraporjavascript_erisim.Sil(pkey)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function javascriptdosyayarartvegom(ByVal raporpkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim dinamikraporjavascript_erisim As New CLASSDINAMIKRAPORJAVASCRIPT_ERISIM
        result = dinamikraporjavascript_erisim.javascriptdosyayarartvegom(raporpkey)
        Return result

    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ikitariharasigunfark(ByVal tarih1 As String, ByVal tarih2 As String) As String

        Dim donecek As Integer
        Dim farkgun As Integer

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangic, bitis As Date

        Try
            baslangic = tarih1
        Catch
            Return "-"
        End Try

        Try
            bitis = tarih2
        Catch
            Return "-"
        End Try

        farkgun = bitis.Subtract(baslangic).Days
        Return farkgun

    End Function


End Class