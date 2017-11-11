Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel


<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class servicefire
    Inherits System.Web.Services.WebService

    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function LoadFirePolicy(ByVal UserName As String,
    ByVal Password As String, ByVal FireXML As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim servisad As String
        servisad = "LoadFirePolicy"

        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        Dim hesapsonuc As New hesapsonuc

        'YETKİLİMİ KONTROL ET-----------------------------------
        Dim yetkiresult As New CLADBOPRESULT
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        yetkiresult = sirket_erisim.yetkilimi(UserName, Password, servisad)

        If yetkiresult.durum = "Yetkisiz" Then
            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            'LOGLAMA İŞLEMİNİ YAP YETKİSİZ KULLANICI İÇİN
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "LoadFirePolicy",
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0", "0",
            "0", "0", "0", FireXML, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then

            Dim FirePolicyInfoService_Erisim As New FirePolicyInfoService_Erisim
            root = FirePolicyInfoService_Erisim.eklexml(UserName, Password, FireXML)

            'EĞER HATA VAR İSE LOGLAMA İŞLEMİNİ YAP
            If root.ResultCode = 0 Then
                Dim sirketlog As New CLASSSIRKET

                ErrorInfo = root.ErrorInfo
                hesapsonuc = root.hesapsonuc

                sirketlog = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)
                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "LoadFirePolicy",
                root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0,
                0, "0", "0",
                "0", "0", "0", "0", "0",
                "0", "0", "0", "0", "0",
                "0", "0", "0", "0", FireXML, UserName,
                Password, "", 0, "", "", "", ip_erisim.ipadresibul))
            End If

        End If

        Return strcevir(root, "LoadFirePolicyInformation")

    End Function



    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function LoadFireDamage(ByVal UserName As String,
    ByVal Password As String, ByVal FireDamageXML As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim servisad As String
        servisad = "LoadFireDamageInformation"

        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        'YETKİLİMİ KONTROL ET-----------------------------------
        Dim yetkiresult As New CLADBOPRESULT
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        yetkiresult = sirket_erisim.yetkilimi(UserName, Password, servisad)

        If yetkiresult.durum = "Yetkisiz" Then
            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            'LOGLAMA İŞLEMİNİ YAP YETKİSİZ KULLANICI İÇİN
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "LoadDamageInformation",
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", DamageXML, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then

            Dim DamageInfoService_Erisim As New DamageInfoService_Erisim
            root = DamageInfoService_Erisim.eklexml(UserName, Password, DamageXML)

            'EĞER HATA VAR İSE LOGLAMA İŞLEMİNİ YAP
            If root.ResultCode = 0 Then
                Dim sirketlog As New CLASSSIRKET
                sirketlog = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)
                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "LoadDamageInformation",
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
                0, "0", "0",
                "0", "0", "0", "0", "0",
                "0", "0", "0", "0", "0",
                "0", "0", "0", "0", DamageXML, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))
            End If

        End If

        Return strcevir(root, "LoadDamageInformation")

    End Function




    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function doldur_ilce(ByVal UserName As String,
    ByVal Password As String) As List(Of CLASSILCE)

        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        Dim ilceler As New List(Of CLASSILCE)
        ilceler = adrescore_erisim.doldur_ilce("doldur_ilce", UserName, Password)
        Return ilceler

    End Function

    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function doldur_bucak(ByVal UserName As String,
    ByVal Password As String, ByVal ilcepkey As String) As List(Of CLASSBUCAK)

        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        Dim bucaklar As New List(Of CLASSBUCAK)
        bucaklar = adrescore_erisim.doldur_bucak("doldur_bucak", UserName, Password, ilcepkey)
        Return bucaklar

    End Function

    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function doldur_belediye(ByVal UserName As String,
    ByVal Password As String, ByVal bucakpkey As String) As List(Of CLASSBELEDIYE)

        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        Dim belediyeler As New List(Of CLASSBELEDIYE)
        belediyeler = adrescore_erisim.doldur_belediye("doldur_belediye", UserName, Password, bucakpkey)
        Return belediyeler

    End Function

    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function doldur_mahalle(ByVal UserName As String,
    ByVal Password As String, ByVal belediyepkey As String) As List(Of CLASSMAHALLE)

        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        Dim mahalleler As New List(Of CLASSMAHALLE)
        mahalleler = adrescore_erisim.doldur_mahalle("doldur_mahalle", UserName, Password, belediyepkey)
        Return mahalleler

    End Function


    <WebMethod()>
    <System.Xml.Serialization.XmlInclude(GetType(root))>
    Public Function doldur_sokak(ByVal UserName As String,
    ByVal Password As String, ByVal mahallepkey As String) As List(Of CLASSSOKAK)

        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        Dim sokakler As New List(Of CLASSSOKAK)
        sokakler = adrescore_erisim.doldur_sokak("doldur_sokak", UserName, Password, mahallepkey)
        Return sokakler

    End Function

    Public Function strcevir(ByVal root As root, ByVal servisad As String) As String

        Dim donecek As String = ""

        If servisad = "LoadFirePolicyInformation" Then

            If Not root.PolicyLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" +
                "<PolicyLoadResult InsertedPolicyCount=" +
                Chr(34) + CStr(root.PolicyLoadResult.InsertedPolicyCount) + Chr(34) +
                " UpdatedPolicyCount=" +
                Chr(34) + CStr(root.PolicyLoadResult.UpdatedPolicyCount) + Chr(34) +
                " SBMCode=" + Chr(34) +
                CStr(root.PolicyLoadResult.SBMCode) + Chr(34) +
                "></PolicyLoadResult>" +
                "</root>"
            End If

            If root.PolicyLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" +
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) +
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" +
                "</root>"
            End If
        End If

        If servisad = "LoadFireDamageInformation" Then

            If Not root.DamageLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" +
                "<DamageLoadResult InsertedDamageCount=" +
                Chr(34) + CStr(root.DamageLoadResult.InsertedDamageCount) + Chr(34) +
                " UpdatedDamageCount=" + Chr(34) + CStr(root.DamageLoadResult.UpdatedDamageCount) + Chr(34) +
                " SBMCode=" + Chr(34) +
                CStr(root.DamageLoadResult.SBMCode) + Chr(34) +
                "></DamageLoadResult>" +
                "</root>"
            End If

            If root.DamageLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" +
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) +
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" +
                "</root>"
            End If
        End If

        Return donecek

    End Function



End Class