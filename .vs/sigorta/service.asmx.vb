Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class service
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function LoadPolicyInformation(ByVal UserName As String, _
    ByVal Password As String, ByVal PolicyXML As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim servisad As String
        servisad = "LoadPolicyInformation"

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
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "LoadPolicyInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", "0", _
            "0", "0", "0", PolicyXML, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then

            Dim PolicyInfoService_Erisim As New PolicyInfoService_Erisim
            root = PolicyInfoService_Erisim.eklexml(UserName, Password, PolicyXML)

            'EĞER HATA VAR İSE LOGLAMA İŞLEMİNİ YAP
            If root.ResultCode = 0 Then
                Dim sirketlog As New CLASSSIRKET

                ErrorInfo = root.ErrorInfo
                hesapsonuc = root.hesapsonuc

                sirketlog = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)
                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "LoadPolicyInformation", _
                root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", PolicyXML, UserName, _
                Password, "", 0, "", "", hesapsonuc.log, ip_erisim.ipadresibul))
            End If

        End If

        Return strcevir(root, "LoadPolicyInformation")

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function LoadDamageInformation(ByVal UserName As String, _
    ByVal Password As String, ByVal DamageXML As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim servisad As String
        servisad = "LoadDamageInformation"

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
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "LoadDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
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
                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "LoadDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", DamageXML, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))
            End If

        End If

        Return strcevir(root, "LoadDamageInformation")

    End Function


    <WebMethod()> _
    Public Function GetDamageInformation(ByVal UserName As String, _
    ByVal Password As String, _
    ByVal InfoXML As String) As String


        Dim donecek As String = ""
        Dim damageinfoservice_erisim As New DamageInfoService_Erisim
        donecek = damageinfoservice_erisim.GetDamageInformation(UserName, Password, InfoXML)
        Return donecek

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(Boolean))> _
    Public Function IsAlive() As Boolean

        Dim PolicyInfoService_erisim As New PolicyInfoService_Erisim
        Return PolicyInfoService_erisim.IsAlive()

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(String))> _
    Public Function IsDBConnAlive() As String

        Dim PolicyInfoService_erisim As New PolicyInfoService_Erisim
        Return PolicyInfoService_erisim.IsDBConnAlive

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function getVersion(ByVal UserName As String, _
    ByVal Password As String) As root

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_Erisim.kullaniciadsifredogrumu(UserName, Password)

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        ErrorInfo.Code = 0
        ErrorInfo.Message = ""
        root.ErrorInfo = ErrorInfo

        If sirket.pkey = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı ve/veya şifre yanlış girilmiştir."
            root.ErrorInfo = ErrorInfo
        End If

        'kullanici adi ve sifre doğru
        If sirket.pkey <> 0 Then
            Dim changeLog As New changeLog
            Dim change As New change
            change.changeText = "2.1"
            changeLog.change = change
            root.ResultCode = 1
            root.changeLog = changeLog
        End If

        'LOGLAMA İŞLEMİNİ YAP
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim sirketlog As New CLASSSIRKET
        sirketlog = sirket_Erisim.kullaniciadsifredogrumu(UserName, Password)
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "getVersion", _
        root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
        0, "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "", UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        Return root

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function GetInfoInsuredPeople(ByVal UserName As String, _
    ByVal Password As String, ByVal VehiclePlate As String) As root


        Dim ip_erisim As New CLASSIP_ERISIM
        Dim servisad As String
        servisad = "GetInfoInsuredPeople"

        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim gonderilenusernamepassword
        gonderilenusernamepassword = UserName + "---" + Password

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        ErrorInfo.Code = 0
        ErrorInfo.Message = ""
        root.ErrorInfo = ErrorInfo

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
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "GetInfoInsuredPeople", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", VehiclePlate, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))
        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then

            Dim sirket As New CLASSSIRKET
            sirket = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)

            Dim PolicyInfoPolis_erisim As New PolicyInfoPolis_Erisim
            root = PolicyInfoPolis_erisim.GetInfoInsuredPeople(UserName, Password, VehiclePlate)

            'LOGLAMA İŞLEMİNİ YAP YETKİSİZ KULLANICI İÇİN
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "GetInfoInsuredPeople", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", VehiclePlate, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))
        End If


        Return root

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function GetCarAddressInfo(ByVal UserName As String, _
    ByVal Password As String, ByVal VehiclePlate As String) As root


        Dim ip_erisim As New CLASSIP_ERISIM
        Dim servisad As String
        servisad = "GetCarAddressInfo"

        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim gonderilenusernamepassword
        gonderilenusernamepassword = UserName + "---" + Password

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        ErrorInfo.Code = 0
        ErrorInfo.Message = ""
        root.ErrorInfo = ErrorInfo

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
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "GetCarAddressInfo", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", VehiclePlate, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))
        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then

            Dim sirket As New CLASSSIRKET
            sirket = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)

            Dim CarAddressInfo_Erisim As New CarAddressInfo_Erisim
            root = CarAddressInfo_Erisim.GetCarAddressInfo(UserName, Password, VehiclePlate)

            'LOGLAMA İŞLEMİNİ YAP YETKİSİZ KULLANICI İÇİN
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "GetCarAddressInfo", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", VehiclePlate, UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))
        End If


        Return root

    End Function



    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function IsPolicySaved(ByVal UserName As String, _
    ByVal Password As String, ByVal FirmCode As String, _
    ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ZeylCode As String, ByVal ZeylNo As String, _
    ByVal ProductType As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim pp_string As String
        Dim servisad As String
        servisad = "IsPolicySaved"

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
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "IsPolicySaved", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "-", UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then

            Dim PolicyInfoService_Erisim As New PolicyInfoService_Erisim
            root = PolicyInfoService_Erisim.IsPolicySaved(UserName, Password, FirmCode, ProductCode, AgencyCode, _
            PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Dim sirketlog As New CLASSSIRKET

            ErrorInfo = root.ErrorInfo
            hesapsonuc = root.hesapsonuc

            sirketlog = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "IsPolicySaved", _
            root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "-", UserName, _
            Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        Return strcevir(root, "IsPolicySaved")

    End Function




    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function IsDamageSaved(ByVal UserName As String, _
    ByVal Password As String, ByVal FirmCode As String, _
    ByVal ProductCode As String, ByVal ProductType As String, _
    ByVal FileNo As String, ByVal RequestNo As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim pp_string As String
        Dim servisad As String
        servisad = "IsDamageSaved"

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
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, 0, "IsDamageSaved", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "-", UserName, Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        'YETKİLİ İSE KAYIT İŞLEMİNİ YAP--------------
        If yetkiresult.durum = "Yetkili" Then
            Dim DamageInfoService_Erisim As New DamageInfoService_Erisim
            root = DamageInfoService_Erisim.IsDamageSaved(UserName, Password, FirmCode, ProductCode, _
            ProductType, FileNo, RequestNo)

            Dim sirketlog As New CLASSSIRKET
            ErrorInfo = root.ErrorInfo
            hesapsonuc = root.hesapsonuc
            sirketlog = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)
            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirketlog.pkey, "IsDamageSaved", _
            root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "-", UserName, _
            Password, "", 0, "", "", "", ip_erisim.ipadresibul))

        End If

        Return strcevir(root, "IsDamageSaved")

    End Function




    Public Function strcevir(ByVal root As root, ByVal servisad As String) As String

        Dim donecek As String = ""

        If servisad = "LoadPolicyInformation" Then

            If Not root.PolicyLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<PolicyLoadResult InsertedPolicyCount=" + _
                Chr(34) + CStr(root.PolicyLoadResult.InsertedPolicyCount) + Chr(34) + _
                " UpdatedPolicyCount=" + _
                Chr(34) + CStr(root.PolicyLoadResult.UpdatedPolicyCount) + Chr(34) + _
                " SBMCode=" + Chr(34) + _
                CStr(root.PolicyLoadResult.SBMCode) + Chr(34) + _
                "></PolicyLoadResult>" + _
                "</root>"
            End If

            If root.PolicyLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"
            End If
        End If

        If servisad = "LoadDamageInformation" Then

            If Not root.DamageLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<DamageLoadResult InsertedDamageCount=" + _
                Chr(34) + CStr(root.DamageLoadResult.InsertedDamageCount) + Chr(34) + _
                " UpdatedDamageCount=" + Chr(34) + CStr(root.DamageLoadResult.UpdatedDamageCount) + Chr(34) + _
                " SBMCode=" + Chr(34) + _
                CStr(root.DamageLoadResult.SBMCode) + Chr(34) + _
                "></DamageLoadResult>" + _
                "</root>"
            End If

            If root.DamageLoadResult Is Nothing Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"
            End If
        End If



        If servisad = "IsPolicySaved" Then
            If root.ResultCode = 0 Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"
            End If

            If root.ResultCode = 1 Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<IsPolicySavedResult IsPolicySaved=" + _
                Chr(34) + CStr(root.varmi) + Chr(34) + _
                "></IsPolicySavedResult>" + _
                "</root>"
            End If
        End If


        If servisad = "IsDamageSaved" Then
            If root.ResultCode = 0 Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"
            End If

            If root.ResultCode = 1 Then
                donecek = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<IsDamageSavedResult IsDamageSaved=" + _
                Chr(34) + CStr(root.varmi) + Chr(34) + _
                "></IsDamageSavedResult>" + _
                "</root>"
            End If
        End If

        Return donecek

    End Function



    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function GetAttendantBorderFirms(ByVal UserName As String, _
    ByVal Password As String, ByVal qdate As String) As String

        Dim donecek As String = ""
        Dim sinirkapitakvim_erisim As New CLASSSINIRKAPITAKVIM_ERISIM
        donecek = sinirkapitakvim_erisim.GetAttendantBorderFirms(UserName, Password, qdate)
        Return donecek

    End Function


    <WebMethod()> _
  <System.Xml.Serialization.XmlInclude(GetType(root))> _
  Public Function CheckOnBorder(ByVal UserName As String, _
  ByVal Password As String) As Boolean

        Dim donecek As String = ""
        Dim sinirkapitakvim_erisim As New CLASSSINIRKAPITAKVIM_ERISIM
        donecek = sinirkapitakvim_erisim.CheckOnBorder(UserName, Password)
        Return donecek

    End Function

End Class