Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Globalization.CultureInfo
Imports System.Globalization
Imports System.Xml
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Web.Script.Serialization

Public Class FireFireDamageInfoService_Erisim

    Public Function eklexml(ByVal wskullaniciad As String,
    ByVal wssifre As String,
    ByVal firedamagexml As String) As root

        Dim SBMCode As String
        Dim girdisayisi As Integer = 0

        Dim fireDamageInfo As New FireDamageInfo
        Dim fireDamageInfo_erisim As New FireDamageInfo_ERISIM

        Dim xmlhata As String = ""
        Dim root As New root
        Dim DamageLoadResult As New DamageLoadResult
        Dim ErrorInfo As New ErrorInfo

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM

        Dim hasardurumkod_erisim As New CLASSHASARDURUMKOD_ERISIM

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)
        If sirket.pkey = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 995
            ErrorInfo.Message = "Yetkisiz. Girdiğiniz kullanıcı adı ve şifre" +
            " ile herhangi bir şirket tanımlanmamış"
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim debugy As String = ""
        Dim XmlDoc As XmlDocument = New XmlDocument

        'firedamagexml normalize---
        firedamagexml = Replace(firedamagexml, "&", "-")

        Try
            XmlDoc.Load(New StringReader(firedamagexml))
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de hatalar var." + ex.Message
            root.ResultCode = 0
            ErrorInfo.Code = 998
            ErrorInfo.Message = ex.Message
            root.ErrorInfo = ErrorInfo
            Return root
        End Try

        Dim FirmCode_girdimi, ProductCode_girdimi As String '2
        Dim AgencyCode_girdimi, PolicyNumber_girdimi As String '4
        Dim TecditNumber_girdimi, FileNumber_girdimi As String '6
        Dim RequestNumber_girdimi, PolicyType_girdimi As String '8
        Dim DamageDate_girdimi, NoticeDate_girdimi As String '10
        Dim FileClosingDate_girdimi, DamageStatusCode_girdimi As String '12
        Dim ClaimOwnerCountryCode_girdimi, ClaimOwnerIdentityCode_girdimi As String '14
        Dim ClaimOwnerIdentityNo_girdimi, ClaimOwnerName_girdimi As String '16
        Dim ClaimOwnerSurname_girdimi, CurrencyCode_girdimi As String '18
        Dim ExchangeRate_girdimi, AgencyRegisterCode_girdimi As String '20
        Dim TPNo_girdimi As String '21
        Dim BuildingPaid_girdimi As String '22
        Dim ContentsPaid_girdimi As String '23
        Dim EarthquakePaid_girdimi As String '24
        Dim FloodFloodingPaid_girdimi As String '25
        Dim InternalWaterPaid_girdimi As String '26
        Dim StormPaid_girdimi As String '27
        Dim TheftPaid_girdimi As String '28
        Dim LandVehiclesPaid_girdimi As String '29
        Dim AirCraftPaid_girdimi As String '30
        Dim MaritimeVehiclesPaid_girdimi As String '31
        Dim SmokePaid_girdimi As String '32
        Dim SpaceShiftPaid_girdimi As String '33
        Dim GLKHHPaid_girdimi As String '34
        Dim MaliciousTerrorPaid_girdimi As String '35
        Dim OtherGuaranteesPaid_girdimi As String '36
        Dim BuildingPending_girdimi '37
        Dim ContentsPending_girdimi As String '38
        Dim EarthquakePending_girdimi As String '39
        Dim FloodFloodingPending_girdimi As String '40
        Dim InternalWaterPending_girdimi As String '41
        Dim StormPending_girdimi As String '42
        Dim TheftPending_girdimi As String '43
        Dim LandVehiclesPending_girdimi As String '44
        Dim AirCraftPending_girdimi As String '45
        Dim MaritimeVehiclesPending_girdimi As String '46
        Dim SmokePending_girdimi As String '47
        Dim SpaceShiftPending_girdimi As String '48
        Dim GLKHHPending_girdimi As String '49
        Dim MaliciousTerrorPending_girdimi As String '50
        Dim OtherGuaranteesPending_girdimi As String '51
        Dim PendingTotalAmount_girdimi As String '52
        Dim PendingTotalAmountTL_girdimi As String '53
        Dim PaidTotalAmount_girdimi As String '54
        Dim PaidTotalAmountTL_girdimi As String '55
        Dim RustyAmount_girdimi As String '56


        FirmCode_girdimi = "Hayır" '1
        ProductCode_girdimi = "Hayır" '2
        AgencyCode_girdimi = "Hayır" '3
        PolicyNumber_girdimi = "Hayır" '4
        TecditNumber_girdimi = "Hayır" '5
        FileNumber_girdimi = "Hayır" '6
        RequestNumber_girdimi = "Hayır" '7
        PolicyType_girdimi = "Hayır" '8
        DamageDate_girdimi = "Hayır" '9
        NoticeDate_girdimi = "Hayır" '10
        FileClosingDate_girdimi = "Hayır" '11
        DamageStatusCode_girdimi = "Hayır" '12
        ClaimOwnerCountryCode_girdimi = "Hayır" '13
        ClaimOwnerIdentityCode_girdimi = "Hayır" '14
        ClaimOwnerIdentityNo_girdimi = "Hayır" '15
        ClaimOwnerName_girdimi = "Hayır" '16
        ClaimOwnerSurname_girdimi = "Hayır" '17
        CurrencyCode_girdimi = "Hayır" '18
        ExchangeRate_girdimi = "Hayır" '19
        AgencyRegisterCode_girdimi = "Hayır" '20
        TPNo_girdimi = "Hayır" '21
        BuildingPaid_girdimi = "Hayır" '22
        ContentsPaid_girdimi = "Hayır" '23
        EarthquakePaid_girdimi = "Hayır" '24
        FloodFloodingPaid_girdimi = "Hayır" '25
        InternalWaterPaid_girdimi = "Hayır" '26
        StormPaid_girdimi = "Hayır" '27
        TheftPaid_girdimi = "Hayır" '28
        LandVehiclesPaid_girdimi = "Hayır" '29
        AirCraftPaid_girdimi = "Hayır" '30
        MaritimeVehiclesPaid_girdimi = "Hayır" '31
        SmokePaid_girdimi = "Hayır" '32
        SpaceShiftPaid_girdimi = "Hayır" '33
        GLKHHPaid_girdimi = "Hayır" '34
        MaliciousTerrorPaid_girdimi = "Hayır" '35
        OtherGuaranteesPaid_girdimi = "Hayır" '36
        BuildingPending_girdimi = "Hayır" '37
        ContentsPending_girdimi = "Hayır" '38
        EarthquakePending_girdimi = "Hayır" '39
        FloodFloodingPending_girdimi = "Hayır"  '40
        InternalWaterPending_girdimi = "Hayır"  '41
        StormPending_girdimi = "Hayır"  '42
        TheftPending_girdimi = "Hayır"  '43
        LandVehiclesPending_girdimi = "Hayır"  '44
        AirCraftPending_girdimi = "Hayır" '45
        MaritimeVehiclesPending_girdimi = "Hayır" '46
        SmokePending_girdimi = "Hayır" '47
        SpaceShiftPending_girdimi = "Hayır"  '48
        GLKHHPending_girdimi = "Hayır" '49
        MaliciousTerrorPending_girdimi = "Hayır"  '50
        OtherGuaranteesPending_girdimi = "Hayır" '51
        PendingTotalAmount_girdimi = "Hayır" '52
        PendingTotalAmountTL_girdimi = "Hayır"  '53
        PaidTotalAmount_girdimi = "Hayır" '54
        PaidTotalAmountTL_girdimi = "Hayır"  '55
        RustyAmount_girdimi = "Hayır" '56



        For Each Element As XmlElement In XmlDoc.SelectNodes("//*")

            'debugy = debugy + Element.Name + "<br/>"
            For Each Attribute As XmlAttribute In Element.Attributes

                'FirmCode 1
                If Attribute.Name = "FirmCode" Then
                    girdisayisi = girdisayisi + 1
                    FirmCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FireDamageInfo.FirmCode = Trim(Attribute.Value)
                        If sirket.sirketkod <> Attribute.Value Then
                            xmlhata = "Gönderdiğiniz XML'deki FirmCode ile giriş yaptığınız kullanıcı adı ve şifre ile" +
                            " girdiğiniz şirketin kodu uyuşmuyor."
                        End If
                    Else
                        xmlhata = "Gönderilen XML'de FirmCode boş olamaz."
                    End If
                End If


                'ProductCode 2
                If Attribute.Name = "ProductCode" Then
                    girdisayisi = girdisayisi + 1
                    ProductCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            FireDamageInfo.ProductCode = Attribute.Value
                            Dim varmi As String = "Evet"
                            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
                            varmi = urunkod_erisim.urunkodvarmi(Attribute.Value)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de ProductCode KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de ProductCode KKSBM tarafından tanımlanmamış."
                        End Try
                    Else
                        xmlhata = "Gönderilen XML'de ProductCode  boş olamaz."
                    End If
                End If


                'AgencyCode 3
                If Attribute.Name = "AgencyCode" Then
                    girdisayisi = girdisayisi + 1
                    AgencyCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FireDamageInfo.AgencyCode = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                    If FireDamageInfo.AgencyCode = "" Then
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                End If

                'PolicyNumber 4
                If Attribute.Name = "PolicyNumber" Then
                    girdisayisi = girdisayisi + 1
                    PolicyNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FireDamageInfo.PolicyNumber = Attribute.Value
                    Else
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                    If FireDamageInfo.PolicyNumber = "" Then
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                End If


                'TecditNumber 5
                If Attribute.Name = "TecditNumber" Then
                    girdisayisi = girdisayisi + 1
                    TecditNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FireDamageInfo.TecditNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                    If FireDamageInfo.TecditNumber = "" Then
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                End If

                'FileNumber 6
                If Attribute.Name = "FileNumber" Then
                    girdisayisi = girdisayisi + 1
                    FileNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FireDamageInfo.FileNumber = Attribute.Value
                    Else
                        xmlhata = "Gönderilen XML'de FileNumber boş olamaz."
                    End If
                    If FireDamageInfo.FileNumber = "" Then
                        xmlhata = "Gönderilen XML'de FileNumber boş olamaz."
                    End If
                End If

                'RequestNumber 7
                If Attribute.Name = "RequestNumber" Then
                    girdisayisi = girdisayisi + 1
                    RequestNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FireDamageInfo.RequestNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de RequestNumber boş olamaz."
                    End If
                    If FireDamageInfo.RequestNumber = "" Then
                        xmlhata = "Gönderilen XML'de RequestNumber boş olamaz."
                    End If
                End If


                'PolicyType 8 
                If Attribute.Name = "PolicyType" Then
                    girdisayisi = girdisayisi + 1
                    PolicyType_girdimi = "Evet"
                    Try
                        FireDamageInfo.PolicyType = CInt(Attribute.Value)
                        Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
                        Dim varmi As String = "Evet"
                        varmi = policetip_erisim.policetipvarmi(FireDamageInfo.PolicyType)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de PolicyType KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        FireDamageInfo.PolicyType = 0
                        xmlhata = "Gönderilen XML'de PolicyType rakam olmak zorunda veya 0 olmamalı."
                    End Try
                End If


                'DamageDate 9
                If Attribute.Name = "DamageDate" Then
                    girdisayisi = girdisayisi + 1
                    DamageDate_girdimi = "Evet"
                    Try
                        FireDamageInfo.DamageDate = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de DamageDate boş olmamalı" +
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " +
                        "şeklinde olmalıdır."
                    End Try
                End If


                'NoticeDate 10
                If Attribute.Name = "NoticeDate" Then
                    girdisayisi = girdisayisi + 1
                    NoticeDate_girdimi = "Evet"
                    Try
                        FireDamageInfo.NoticeDate = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de NoticeDate boş olmamalı" +
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " +
                        "şeklinde olmalıdır."
                    End Try
                End If

                'FileClosingDate 11
                If Attribute.Name = "FileClosingDate" Then
                    girdisayisi = girdisayisi + 1
                    FileClosingDate_girdimi = "Evet"
                    Try
                        FireDamageInfo.FileClosingDate = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de FileClosingDate boş olmamalı" +
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " +
                        "şeklinde olmalıdır."
                    End Try
                End If

                'DamageStatusCode 12
                If Attribute.Name = "DamageStatusCode" Then
                    girdisayisi = girdisayisi + 1
                    DamageStatusCode_girdimi = "Evet"
                    FireDamageInfo.DamageStatusCode = Attribute.Value
                    Try
                        Dim kodtanimlanmismi As String
                        kodtanimlanmismi = hasardurumkod_erisim.hasardurumkodvarmi(Attribute.Value)
                        If kodtanimlanmismi = "Hayır" Then
                            xmlhata = "XML'de göndermiş olduğunuz DamageStatusCode KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        xmlhata = "XML'de göndermiş olduğunuz DamageStatusCode KKSBM tarafından tanımlanmamış."
                    End Try
                End If

                'ClaimOwnerCountryCode 13
                If Attribute.Name = "ClaimOwnerCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    ClaimOwnerCountryCode_girdimi = "Evet"
                    Try
                        FireDamageInfo.ClaimOwnerCountryCode = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "ClaimOwnerCountryCode doğru değildir."
                    End Try
                    If fireDamageInfo.ClaimOwnerCountryCode = "" Then
                        xmlhata = "ClaimOwnerCountryCode boş olamaz."
                    End If
                End If



                'ClaimOwnerIdentityCode 14
                If Attribute.Name = "ClaimOwnerIdentityCode" Then
                    girdisayisi = girdisayisi + 1
                    ClaimOwnerIdentityCode_girdimi = "Evet"
                    Try
                        fireDamageInfo.ClaimOwnerIdentityCode = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "ClaimOwnerIdentityCode doğru değildir."
                    End Try
                    If fireDamageInfo.ClaimOwnerIdentityCode = "" Then
                        xmlhata = "ClaimOwnerIdentityCode boş olamaz."
                    End If
                End If


                'ClaimOwnerIdentityNo 15
                If Attribute.Name = "ClaimOwnerIdentityNo" Then
                    girdisayisi = girdisayisi + 1
                    ClaimOwnerName_girdimi = "Evet"
                    Try
                        fireDamageInfo.ClaimOwnerIdentityNo = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "ClaimOwnerIdentityNo doğru değildir."
                    End Try
                    If fireDamageInfo.ClaimOwnerIdentityNo = "" Then
                        xmlhata = "ClaimOwnerIdentityNo boş olamaz."
                    End If
                End If


                'ClaimOwnerName 16
                If Attribute.Name = "ClaimOwnerName" Then
                    girdisayisi = girdisayisi + 1
                    ClaimOwnerName_girdimi = "Evet"
                    Try
                        fireDamageInfo.ClaimOwnerName = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "ClaimOwnerName doğru değildir."
                    End Try
                    If fireDamageInfo.ClaimOwnerName = "" Then
                        xmlhata = "ClaimOwnerName boş olamaz."
                    End If
                End If

                'ClaimOwnerSurname 17
                If Attribute.Name = "ClaimOwnerSurname" Then
                    girdisayisi = girdisayisi + 1
                    ClaimOwnerSurname_girdimi = "Evet"
                    Try
                        fireDamageInfo.ClaimOwnerSurname = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "ClaimOwnerSurName doğru değildir."
                    End Try
                    If fireDamageInfo.ClaimOwnerSurname = "" Then
                        xmlhata = "ClaimOwnerSurName boş olamaz."
                    End If
                End If

                'CurrencyCode 18
                If Attribute.Name = "CurrencyCode" Then
                    girdisayisi = girdisayisi + 1
                    CurrencyCode_girdimi = "Evet"
                    Try
                        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
                        Dim varmi = "Evet"
                        fireDamageInfo.CurrencyCode = Attribute.Value
                        varmi = currencycode_erisim.currencycodevarmi(fireDamageInfo.CurrencyCode)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                    End Try
                End If

                'ExchangeRate 19
                If Attribute.Name = "ExchangeRate" Then
                    girdisayisi = girdisayisi + 1
                    ExchangeRate_girdimi = "Evet"
                    Try
                        fireDamageInfo.ExchangeRate = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de ExchangeRate hatalıdır."
                    End Try
                End If



                'AgencyRegisterCode 20
                If Attribute.Name = "AgencyRegisterCode" Then
                    girdisayisi = girdisayisi + 1
                    AgencyRegisterCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        fireDamageInfo.AgencyRegisterCode = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de AgencyRegisterCode boş olamaz."
                    End If
                End If


                'TPNo 21
                If Attribute.Name = "TPNo" Then
                    girdisayisi = girdisayisi + 1
                    TPNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            fireDamageInfo.TPNo = Trim(Attribute.Value)
                            varmi = personel_erisim.ciftkayitkontrol("tpno", fireDamageInfo.TPNo)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                        End Try
                    End If
                    If Attribute.Value = "" Then
                        fireDamageInfo.TPNo = ""
                    End If
                End If



                'BuildingPaid 22
                If Attribute.Name = "BuildingPaid" Then
                    girdisayisi = girdisayisi + 1
                    ExchangeRate_girdimi = "Evet"
                    Try
                        fireDamageInfo.BuildingPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de BuildingPaid hatalıdır."
                    End Try
                End If


                'ContentsPaid 23
                If Attribute.Name = "ContentsPaid" Then
                    girdisayisi = girdisayisi + 1
                    ContentsPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.ContentsPaid = CDbl(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de ContentsPaid hatalıdır."
                    End Try
                End If

                'EarthquakePaid 24
                If Attribute.Name = "EarthquakePaid" Then
                    girdisayisi = girdisayisi + 1
                    EarthquakePaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.EarthquakePaid = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderdiğiniz XML'de EarthquakePaid hatalıdır."
                    End Try
                End If

                'FloodFloodingPaid 25
                If Attribute.Name = "FloodFloodingPaid" Then
                    girdisayisi = girdisayisi + 1
                    FloodFloodingPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.FloodFloodingPaid = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderdiğiniz XML'de FloodFloodingPaid hatalıdır."
                    End Try
                End If


                'InternalWaterPaid 26
                If Attribute.Name = "InternalWaterPaid" Then
                    girdisayisi = girdisayisi + 1
                    InternalWaterPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.InternalWaterPaid = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderdiğiniz XML'de InternalWaterPaid hatalıdır."
                    End Try
                End If


                'StormPaid 26
                If Attribute.Name = "StormPaid" Then
                    girdisayisi = girdisayisi + 1
                    StormPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.InternalWaterPaid = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderdiğiniz XML'de StormPaid hatalıdır."
                    End Try
                End If

                'TheftPaid 28
                If Attribute.Name = "TheftPaid" Then
                    girdisayisi = girdisayisi + 1
                    TheftPaid_girdimi = "Evet"
                    Try
                        FireDamageInfo.TheftPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de TheftPaid hatalıdır."
                    End Try
                End If

                'LandVehiclesPaid 29
                If Attribute.Name = "LandVehiclesPaid" Then
                    girdisayisi = girdisayisi + 1
                    LandVehiclesPaid_girdimi = "Evet"
                    Try
                        FireDamageInfo.LandVehiclesPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de LandVehiclesPaid hatalıdır."
                    End Try
                End If

                'AirCraftPaid 30
                If Attribute.Name = "AirCraftPaid" Then
                    girdisayisi = girdisayisi + 1
                    AirCraftPaid_girdimi = "Evet"
                    Try
                        FireDamageInfo.AirCraftPaid = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de AirCraftPaid hatalıdır."
                    End Try
                End If


                'MaritimeVehiclesPaid 31
                If Attribute.Name = "MaritimeVehiclesPaid" Then
                    girdisayisi = girdisayisi + 1
                    MaritimeVehiclesPaid_girdimi = "Evet"
                    Try
                        FireDamageInfo.MaritimeVehiclesPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de MaritimeVehiclesPaid hatalıdır."
                    End Try
                End If


                'SmokePaid 32
                If Attribute.Name = "SmokePaid" Then
                    girdisayisi = girdisayisi + 1
                    SmokePaid_girdimi = "Evet"
                    Try
                        FireDamageInfo.SmokePaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de SmokePaid hatalıdır."
                    End Try
                End If

                'SpaceShiftPaid 33
                If Attribute.Name = "SpaceShiftPaid" Then
                    girdisayisi = girdisayisi + 1
                    SpaceShiftPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.SpaceShiftPaid = CDec(Attribute.Value)
                    Catch
                        xmlhata = "Gönderdiğiniz XML'de SpaceShiftPaid hatalıdır."
                    End Try
                End If


                'GLKHHPaid 34
                If Attribute.Name = "GLKHHPaid" Then
                    girdisayisi = girdisayisi + 1
                    GLKHHPaid_girdimi = "Evet"
                    Try
                        FireDamageInfo.GLKHHPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de GLKHHPaid hatalıdır."
                    End Try
                End If

                'MaliciousTerrorPaid 35
                If Attribute.Name = "MaliciousTerrorPaid" Then
                    girdisayisi = girdisayisi + 1
                    MaliciousTerrorPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.MaliciousTerrorPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de MaliciousTerrorPaid hatalıdır."
                    End Try
                End If

                'OtherGuaranteesPaid 36
                If Attribute.Name = "OtherGuaranteesPaid" Then
                    girdisayisi = girdisayisi + 1
                    OtherGuaranteesPaid_girdimi = "Evet"
                    Try
                        fireDamageInfo.OtherGuaranteesPaid = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de OtherGuaranteesPaid hatalıdır."
                    End Try
                End If

                'BuildingPending 37
                If Attribute.Name = "BuildingPending" Then
                    girdisayisi = girdisayisi + 1
                    BuildingPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.BuildingPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de BuildingPending hatalıdır."
                    End Try
                End If

                'ContentsPending 38
                If Attribute.Name = "ContentsPending" Then
                    girdisayisi = girdisayisi + 1
                    ContentsPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.ContentsPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de ContentsPending hatalıdır."
                    End Try
                End If

                'EarthQuakePending 39
                If Attribute.Name = "EarthQuakePending" Then
                    girdisayisi = girdisayisi + 1
                    EarthquakePending_girdimi = "Evet"
                    Try
                        fireDamageInfo.EarthquakePending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de EarthQuakePending hatalıdır."
                    End Try
                End If

                'FloodFloodingPending 40
                If Attribute.Name = "FloodFloodingPending" Then
                    girdisayisi = girdisayisi + 1
                    FloodFloodingPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.FloodFloodingPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de FloodFloodingPending hatalıdır."
                    End Try
                End If

                'InternalWaterPending 41
                If Attribute.Name = "InternalWaterPending" Then
                    girdisayisi = girdisayisi + 1
                    InternalWaterPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.InternalWaterPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de InternalWaterPending hatalıdır."
                    End Try
                End If

                'StormPending 42
                If Attribute.Name = "StormPending" Then
                    girdisayisi = girdisayisi + 1
                    StormPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.StormPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de StormPending hatalıdır."
                    End Try
                End If

                'TheftPending 43
                If Attribute.Name = "TheftPending" Then
                    girdisayisi = girdisayisi + 1
                    TheftPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.TheftPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de TheftPending hatalıdır."
                    End Try
                End If

                'LandVehiclesPending 44
                If Attribute.Name = "LandVehiclesPending" Then
                    girdisayisi = girdisayisi + 1
                    LandVehiclesPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.LandVehiclesPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de LandVehiclesPending hatalıdır."
                    End Try
                End If

                'AirCraftPending 45
                If Attribute.Name = "AirCraftPending" Then
                    girdisayisi = girdisayisi + 1
                    AirCraftPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.MaritmeVehiclesPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de AirCraftPending hatalıdır."
                    End Try
                End If


                'MaritimeVehiclesPending 46
                If Attribute.Name = "MaritimeVehiclesPending" Then
                    girdisayisi = girdisayisi + 1
                    MaritimeVehiclesPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.MaritmeVehiclesPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de MaritimeVehiclesPending hatalıdır."
                    End Try
                End If


                'SmokePending 47
                If Attribute.Name = "SmokePending" Then
                    girdisayisi = girdisayisi + 1
                    SmokePending_girdimi = "Evet"
                    Try
                        fireDamageInfo.SmokePending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de SmokePending hatalıdır."
                    End Try
                End If


                'SpaceShiftPending 48
                If Attribute.Name = "SpaceShiftPending" Then
                    girdisayisi = girdisayisi + 1
                    SpaceShiftPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.SpaceShiftPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de SpaceShiftPending hatalıdır."
                    End Try
                End If


                'GLKHHPending 49
                If Attribute.Name = "GLKHHPending" Then
                    girdisayisi = girdisayisi + 1
                    GLKHHPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.GLKHHPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de GLKHHPending hatalıdır."
                    End Try
                End If


                'MaliciousTerrorPending 50
                If Attribute.Name = "MaliciousTerrorPending" Then
                    girdisayisi = girdisayisi + 1
                    MaliciousTerrorPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.MaliciousTerrorPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de MaliciousTerrorPending hatalıdır."
                    End Try
                End If



                'OtherGuaranteesPending 51
                If Attribute.Name = "OtherGuaranteesPending" Then
                    girdisayisi = girdisayisi + 1
                    OtherGuaranteesPending_girdimi = "Evet"
                    Try
                        fireDamageInfo.OtherGuaranteesPending = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de OtherGuaranteesPending hatalıdır."
                    End Try
                End If


                'PendingTotalAmount 52
                If Attribute.Name = "PendingTotalAmount" Then
                    girdisayisi = girdisayisi + 1
                    PendingTotalAmount_girdimi = "Evet"
                    Try
                        fireDamageInfo.PendingTotalAmount = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de PendingTotalAmount hatalıdır."
                    End Try
                End If


                'PendingTotalAmountTL 53
                If Attribute.Name = "PendingTotalAmountTL" Then
                    girdisayisi = girdisayisi + 1
                    PendingTotalAmountTL_girdimi = "Evet"
                    Try
                        fireDamageInfo.PendingTotalAmountTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de PendingTotalAmountTL hatalıdır."
                    End Try
                End If

                'PaidTotalAmount 54
                If Attribute.Name = "PaidTotalAmount" Then
                    girdisayisi = girdisayisi + 1
                    PaidTotalAmount_girdimi = "Evet"
                    Try
                        fireDamageInfo.PaidTotalAmount = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de PaidTotalAmount hatalıdır."
                    End Try
                End If

                'PaidTotalAmountTL 55
                If Attribute.Name = "PaidTotalAmountTL" Then
                    girdisayisi = girdisayisi + 1
                    PaidTotalAmountTL_girdimi = "Evet"
                    Try
                        fireDamageInfo.PaidTotalAmountTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de PaidTotalAmountTL hatalıdır."
                    End Try
                End If

                'RustyAmount 56
                If Attribute.Name = "RustyAmount" Then
                    girdisayisi = girdisayisi + 1
                    RustyAmount_girdimi = "Evet"
                    Try
                        fireDamageInfo.RustyAmount = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de RustyAmount hatalıdır."
                    End Try
                End If

            Next

        Next


        'girilmiyenleri tespit et 
        Dim girilmeyenstr As String = "Gönderilmeyen XML Alanları:"

        '1
        If FirmCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FirmCode" + "-"
        End If

        '2
        If ProductCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductCode" + "-"
        End If

        '3
        If AgencyCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgencyCode" + "-"
        End If

        '4
        If PolicyNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyNumber" + "-"
        End If

        '5
        If TecditNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TecditNumber" + "-"
        End If

        '6
        If FileNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FileNumber" + "-"
        End If

        '7
        If RequestNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RequestNumber" + "-"
        End If


        '8
        If PolicyType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyType" + "-"
        End If

        '9
        If DamageDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamageDate" + "-"
        End If

        '10
        If NoticeDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "NoticeDate" + "-"
        End If

        '11
        If FileClosingDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FileClosingDate" + "-"
        End If

        '12
        If DamageStatusCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamageStatusCode" + "-"
        End If

        '13
        If ClaimOwnerCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimOwnerCountryCode" + "-"
        End If

        '14
        If ClaimOwnerIdentityCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverCountryCode" + "-"
        End If

        '15
        If ClaimOwnerIdentityNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimOwnerIdentityNo" + "-"
        End If

        '16
        If ClaimOwnerName_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimOwnerName" + "-"
        End If

        '17
        If ClaimOwnerSurname_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimOwnerSurname" + "-"
        End If

        '18
        If CurrencyCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CurrencyCode" + "-"
        End If

        '19
        If ExchangeRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ExchangeRate" + "-"
        End If

        '20
        If AgencyRegisterCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgencyRegisterCode" + "-"
        End If

        '21
        If TPNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TPNo" + "-"
        End If

        '22
        If BuildingPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BuildingPaid" + "-"
        End If

        '23
        If ContentsPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ContentsPaid" + "-"
        End If

        '24
        If EarthquakePaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EarthquakePaid" + "-"
        End If

        '25
        If FloodFloodingPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FloodFloodingPaid" + "-"
        End If

        '26
        If InternalWaterPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InternalWaterPaid" + "-"
        End If

        '27
        If StormPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "StormPaid" + "-"
        End If

        '28
        If TheftPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TheftPaid" + "-"
        End If

        '29
        If LandVehiclesPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "LandVehiclesPaid" + "-"
        End If

        '30
        If AirCraftPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AirCraftPaid" + "-"
        End If

        '31
        If MaritimeVehiclesPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "MaritimeVehiclesPaid" + "-"
        End If

        '32
        If SmokePaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SmokePaid" + "-"
        End If

        '33
        If SpaceShiftPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SpaceShiftPaid" + "-"
        End If

        '34
        If GLKHHPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "GLKHHPaid" + "-"
        End If

        '35
        If MaliciousTerrorPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "MaliciousTerrorPaid" + "-"
        End If

        '36
        If OtherGuaranteesPaid_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OtherGuaranteesPaid" + "-"
        End If

        '37
        If BuildingPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BuildingPending" + "-"
        End If

        '38
        If ContentsPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ContentsPending" + "-"
        End If

        '39
        If EarthquakePending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EarthquakePending" + "-"
        End If

        '40
        If FloodFloodingPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FloodFloodingPending" + "-"
        End If

        '41
        If InternalWaterPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InternalWaterPending" + "-"
        End If

        '42
        If StormPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "StormPending" + "-"
        End If

        '43
        If TheftPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TheftPending" + "-"
        End If

        '44
        If LandVehiclesPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "LandVehiclesPending" + "-"
        End If

        '45
        If AirCraftPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AirCraftPending" + "-"
        End If

        '46
        If MaritimeVehiclesPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "MaritimeVehiclesPending" + "-"
        End If

        '47
        If SmokePending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SmokePending" + "-"
        End If

        '48
        If SpaceShiftPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SpaceShiftPending" + "-"
        End If

        '49
        If GLKHHPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "GLKHHPending" + "-"
        End If

        '50
        If MaliciousTerrorPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "MaliciousTerrorPending" + "-"
        End If

        '51
        If OtherGuaranteesPending_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OtherGuaranteesPending" + "-"
        End If

        '52
        If PendingTotalAmount_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PendingTotalAmount" + "-"
        End If

        '53
        If PendingTotalAmountTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PendingTotalAmountTL" + "-"
        End If


        '54
        If PaidTotalAmount_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PaidTotalAmount" + "-"
        End If

        '55
        If PaidTotalAmountTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PaidTotalAmountTL" + "-"
        End If

        '56
        If RustyAmount_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RustyAmount" + "-"
        End If

        'xmlde hata var mı kontrol et
        If xmlhata <> "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = xmlhata
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'xml gönderilen attribute eksik mi kontrol et
        If girdisayisi <> 56 Then
            root.ResultCode = 0
            ErrorInfo.Code = 99
            ErrorInfo.Message = "Gönderdiğiniz XML'de bazı alanlar eksik yada fazladır." +
            "Toplam xml node sayısı 56 olması gerekirken siz " + CStr(girdisayisi) + " alan gönderdiniz. " +
            girilmeyenstr
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'boş olmaması gerekenleri kontrol et
        If fireDamageInfo.FirmCode = Nothing Or fireDamageInfo.ProductCode = Nothing Or
        fireDamageInfo.AgencyCode = Nothing Or fireDamageInfo.PolicyNumber = Nothing Or
        fireDamageInfo.TecditNumber = Nothing Or fireDamageInfo.FileNumber = Nothing Or
        fireDamageInfo.RequestNumber = Nothing Or fireDamageInfo.PolicyType = Nothing Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = "Gönderdiğiniz XML'de FirmCode, ProductCode," +
            " AgencyCode, PolicyNumber,TecditNumber, FileNumber, RequestNumber, PolicyType boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'SORU İŞARETİ KONTROL
        If InStr(firedamagexml, "?", CompareMethod.Text) > 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 333
            ErrorInfo.Message = "Gönderdiğiniz XML'in hiçbir yerinde ? (soru işareti) karakteri olmamalıdır."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        If fireDamageInfo.TPNo <> "" Then
            personel = personel_erisim.bul_tpnogore(fireDamageInfo.TPNo, "Evet")
            If personel.pkey = 0 Then
                root.ResultCode = 0
                ErrorInfo.Code = 503
                ErrorInfo.Message = "Gönderdiğiniz TPNo teknik personel değildir."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        If FireDamageInfo.TPNo = "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 503
            ErrorInfo.Message = "Gönderilen XML de TPNo boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        personel = personel_erisim.bul_tpnogore(fireDamageInfo.TPNo, "Evet")
        If personel.pkey = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 503
            ErrorInfo.Message = "Gönderdiğiniz TPNo teknik personel değildir."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        Dim kimliktur_erisim As New CLASSKIMLIKTUR_ERISIM
        If fireDamageInfo.ClaimOwnerIdentityCode <> "" Then
            If kimliktur_erisim.kimlikturkodvarmi(fireDamageInfo.ClaimOwnerIdentityCode) <> "Evet" Then
                root.ResultCode = 0
                ErrorInfo.Code = 700
                ErrorInfo.Message = "ClaimOwnerIdentityCode KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        'mantıksal kontrolleri yap 
        If fireDamageInfo.ClaimOwnerCountryCode = "601" And fireDamageInfo.ClaimOwnerIdentityCode = "KN" Then
            If Trim(Len(fireDamageInfo.ClaimOwnerIdentityNo)) <> 6 And Trim(Len(fireDamageInfo.ClaimOwnerIdentityNo)) <> 10 Then
                root.ResultCode = 0
                ErrorInfo.Code = 801
                ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " +
                    "6 yada 10 rakamdan oluşmalıdır. ClaimOwnerIdentityNo"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If fireDamageInfo.ClaimOwnerCountryCode = "52" And fireDamageInfo.ClaimOwnerIdentityCode = "KN" Then
            If Trim(Len(fireDamageInfo.ClaimOwnerIdentityNo)) <> 11 Then
                root.ResultCode = 0
                ErrorInfo.Code = 801
                ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " +
                    "11 rakamdan oluşmalıdır. ClaimOwnerIdentityNo"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        'MŞ YŞ UŞ KONTROLÜ
        If fireDamageInfo.ClaimOwnerCountryCode = "601" Then
            If fireDamageInfo.ClaimOwnerIdentityCode = "MŞ" Or fireDamageInfo.ClaimOwnerIdentityCode = "YŞ" _
                Or fireDamageInfo.ClaimOwnerIdentityCode = "UŞ" Then
                If Len(fireDamageInfo.ClaimOwnerIdentityNo) > 5 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 802
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" +
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. ClaimOwnerIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
        End If



        'EXCHANGERATE KONTROLLERİ VE HESAPLAMALARI
        If FireDamageInfo.CurrencyCode = "TL" Then
            If FireDamageInfo.ExchangeRate <> 1 Then
                root.ResultCode = 0
                ErrorInfo.Code = 200
                ErrorInfo.Message = "Para birimi TL olan hasarlarda ExchangeRate 1 olmalıdır."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        Dim pendingtotalamount_a As Decimal
        Dim PaidTotalAmount_a As Decimal
        Dim pendingtotalamount_up, pendingtotalamount_down As Decimal
        Dim PaidTotalAmount_up, PaidTotalAmount_down As Decimal

        pendingtotalamount_a = Math.Round(fireDamageInfo.PendingTotalAmount * fireDamageInfo.ExchangeRate, 2)
        pendingtotalamount_up = pendingtotalamount_a + 0.5
        pendingtotalamount_down = pendingtotalamount_a - 0.5
        If fireDamageInfo.PendingTotalAmountTL > pendingtotalamount_up Or fireDamageInfo.PendingTotalAmountTL < pendingtotalamount_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "PendingTotalAmountTL yanlış çevrilmiş. " +
            "Gönderilmesi Gereken Değer: " + Format(pendingtotalamount_a, "0.00") + " veya " +
            Format(pendingtotalamount_down, "0.00") + " ve " + Format(pendingtotalamount_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        PaidTotalAmount_a = Math.Round(fireDamageInfo.PaidTotalAmount * fireDamageInfo.ExchangeRate, 2)
        PaidTotalAmount_up = PaidTotalAmount_a + 0.5
        PaidTotalAmount_down = PaidTotalAmount_a - 0.5
        If fireDamageInfo.PaidTotalAmountTL > PaidTotalAmount_up Or fireDamageInfo.PaidTotalAmountTL < PaidTotalAmount_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "PaidTotalAmountTL yanlış çevrilmiş. " +
            "Gönderilmesi Gereken Değer: " + Format(PaidTotalAmount_a, "0.00") + " veya " +
            Format(PaidTotalAmount_down, "0.00") + " ve " + Format(PaidTotalAmount_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'kontrol et bakalım bu hasarın poliçesi var mı?
        Dim firepolicyinfo_erisim As New FirePolicyInfo_Erisim
        Dim hasarinpoliceleri As New List(Of FirePolicyInfo)
        hasarinpoliceleri = firepolicyinfo_erisim.policedoldur_ilgilihasar(fireDamageInfo.FirmCode,
        fireDamageInfo.ProductCode, fireDamageInfo.AgencyCode, fireDamageInfo.PolicyNumber,
        fireDamageInfo.TecditNumber, fireDamageInfo.PolicyType)

        If hasarinpoliceleri.Count = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 98
            ErrorInfo.Message = "Gönderdiğiniz Hasarın bağlı olduğu bir poliçe sisteme daha " +
            "önceden kaydedilmemiş."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'eğer xml'de hata yoksa 
        If xmlhata = "" Then

            'kontrol et bu kayit varmi.
            Dim varmi As String

            varmi = FireDamageInfo_ERISIM.ciftkayitkontrol(fireDamageInfo.FirmCode, fireDamageInfo.ProductCode,
            fireDamageInfo.PolicyType, fireDamageInfo.FileNumber, fireDamageInfo.RequestNumber)

            'yeni kayit
            If varmi = "Hayır" Then
                'yeni kayıt olduğundan yeni bir SBMCode üret
                SBMCode = sbmcodebul(fireDamageInfo)
                fireDamageInfo.FDSBMCode = SBMCode

                resultset = FireDamageInfo_ERISIM.Ekle(fireDamageInfo)
                If resultset.durum = "Kaydedildi" Then
                    root.ResultCode = 1
                    DamageLoadResult.InsertedDamageCount = 1
                    DamageLoadResult.UpdatedDamageCount = 0
                    DamageLoadResult.SBMCode = SBMCode
                    root.DamageLoadResult = DamageLoadResult
                End If
                If resultset.durum <> "Kaydedildi" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 999
                    ErrorInfo.Message = resultset.hatastr
                    root.ErrorInfo = ErrorInfo
                End If
            End If

            'düzenleme
            If varmi = "Evet" Then

                'Bu kayıt düzenlendiğinden eski SMBCode kaydedilecek
                Dim eskiFireDamageInfo As New FireDamageInfo
                eskiFireDamageInfo = FireDamageInfo_ERISIM.bultek(fireDamageInfo.FirmCode, fireDamageInfo.ProductCode, fireDamageInfo.FileNumber,
                fireDamageInfo.RequestNumber, fireDamageInfo.PolicyType)

                fireDamageInfo.SBMCode = eskiFireDamageInfo.SBMCode
                resultset = FireDamageInfo_ERISIM.Duzenle(fireDamageInfo)
                If resultset.durum = "Kaydedildi" Then
                    root.ResultCode = 1
                    DamageLoadResult.InsertedDamageCount = 0
                    DamageLoadResult.UpdatedDamageCount = 1
                    DamageLoadResult.SBMCode = fireDamageInfo.SBMCode
                    root.DamageLoadResult = DamageLoadResult
                End If
                If resultset.durum <> "Kaydedildi" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 999
                    ErrorInfo.Message = resultset.hatastr
                    root.ErrorInfo = ErrorInfo
                End If
            End If

        End If 'xmlhata=""


        'LOGLAMA İŞLEMİNİ YAP----
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "LoadFireDamageInformation",
        root.ResultCode, 0, "0", DamageLoadResult.InsertedDamageCount,
        DamageLoadResult.UpdatedDamageCount, "0", "0",
        "0", "0", "0", "0",
        "0", "0", fireDamageInfo.FirmCode, fireDamageInfo.ProductCode, fireDamageInfo.AgencyCode, fireDamageInfo.PolicyNumber,
        fireDamageInfo.TecditNumber, fireDamageInfo.FileNumber, fireDamageInfo.RequestNumber, fireDamageInfo.PolicyType, firedamagexml,
        wskullaniciad, wssifre, "Hayır", 0, "", "", "", ip_erisim.ipadresibul))

        Return root

    End Function


    Public Function sbmcodebul(ByVal fireDamageInfo As FireDamageInfo) As String

        Dim nn As String = ""
        Dim i, ekleneceksifirsayisi, kacadet As Integer
        Dim kacadetstr As String
        kacadet = hasaradet_sirketin(fireDamageInfo.FirmCode)

        kacadetstr = CStr(kacadet)

        Dim donecek As String
        donecek = "YH" + fireDamageInfo.FirmCode + fireDamageInfo.ProductCode + fireDamageInfo.ProductType +
        fireDamageInfo.FileNo + fireDamageInfo.RequestNo + CStr(kacadetstr)

        Return donecek

    End Function


    Public Function hasaradet_sirketin(ByVal FirmCode As String) As Integer

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim kackayit As Integer = 0
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", FirmCode, " "))
        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "FireDamageInfo", "count(*)", fieldopvalues)
        Return kackayit

    End Function




End Class
