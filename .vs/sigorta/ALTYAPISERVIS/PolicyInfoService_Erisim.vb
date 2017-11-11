Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Globalization.CultureInfo
Imports System.Globalization
Imports System.Xml
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Security


Public Class PolicyInfoService_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull
    Dim ip_erisim As New CLASSIP_ERISIM

    '------------------------------EKLE-------------------------------------------
    Public Function eklexml(ByVal wskullaniciad As String, _
    ByVal wssifre As String, _
    ByVal policexml As String) As root


        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)

        Dim policyinfo_erisim As New PolicyInfo_Erisim
        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."


        Dim policyinfoservicekontrol_erisim As New PolicyInfoServiceKontrol_Erisim
        Dim policyinfoservicehelper_erisim As New PolicyInfoServiceHelper_Erisim


        Dim core_erisim As New CLASSCORE_ERISIM

        Dim SBMCode As String
        Dim girdisayisi As Integer = 0

        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim PolicyInfo As New PolicyInfo
        Dim xmlhata As String = ""
        Dim root As New root
        Dim PolicyLoadResult As New PolicyLoadResult
        Dim ErrorInfo As New ErrorInfo
        Dim hesapsonuc As New hesapsonuc

        hesapsonuc.sonuckodu = 1
        hesapsonuc.hatamsg = ""
        hesapsonuc.log = ""
        root.hesapsonuc = hesapsonuc

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)
        If sirket.pkey = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 995
            ErrorInfo.Message = "Yetkisiz. Girdiğiniz kullanıcı adı ve şifre ile " + _
            "herhangi bir şirket tanımlanmamış"
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        Dim aractarife As New CLASSARACTARIFE
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

        Dim zeylcode As New CLASSZEYLCODE
        Dim zeylcode_erisim As New CLASSZEYLCODE_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM

        Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM
        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM

        Dim debugy As String = ""
        Dim XmlDoc As XmlDocument = New XmlDocument

        'policexml normalize---
        policexml = Replace(policexml, "&", "&amp;")

        Try
            XmlDoc.Load(New StringReader(policexml))
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de hatalar var." + ex.Message
            root.ResultCode = 0
            ErrorInfo.Code = 998
            ErrorInfo.Message = ex.Message
            root.ErrorInfo = ErrorInfo
            Return root
        End Try

        Dim color As String

        Dim FirmCode_girdimi, ProductCode_girdimi, AgencyCode_girdimi As String
        Dim PolicyNumber_girdimi, TecditNumber_girdimi, ZeylCode_girdimi As String
        Dim ZeylNo_girdimi, PolicyType_girdimi, PolicyOwnerCountryCode_girdimi As String
        Dim PolicyOwnerIdentityCode_girdimi, PolicyOwnerIdentityNo_girdimi, PolicyOwnerName_girdimi As String
        Dim PolicyOwnerSurname_girdimi, PolicyOwnerBirthDate_girdimi, AddressLine1_girdimi As String
        Dim AddressLine2_girdimi, AddressLine3_girdimi, PlateCountryCode_girdimi As String
        Dim PlateNumber_girdimi, Brand_girdimi, Model_girdimi As String
        Dim ChassisNumber_girdimi, EngineNumber_girdimi, EnginePower_girdimi As String
        Dim ProductionYear_girdimi, Capacity_girdimi, CarType_girdimi As String
        Dim UsingStyle_girdimi, TariffCode_girdimi, ArrangeDate_girdimi As String
        Dim StartDate_girdimi, EndDate_girdimi, Material_girdimi As String
        Dim Corporal_girdimi, CurrencyCode_girdimi, PublicValue_girdimi As String
        Dim AuthorizedDrivers_girdimi, CountryCode1_girdimi, IdentityCode1_girdimi As String
        Dim IdentityNo1_girdimi, Name1_girdimi, Surname1_girdimi As String
        Dim BirthDate1_girdimi, DriverLicenceNo1_girdimi, DriverLicenceGivenDate1_girdimi As String
        Dim DriverLicenceType1_girdimi, CountryCode2_girdimi, IdentityCode2_girdimi As String
        Dim IdentityNo2_girdimi, Name2_girdimi, Surname2_girdimi As String
        Dim BirthDate2_girdimi, DriverLicenceNo2_girdimi, DriverLicenceGivenDate2_girdimi As String
        Dim DriverLicenceType2_girdimi, CountryCode3_girdimi, IdentityCode3_girdimi As String
        Dim IdentityNo3_girdimi, Name3_girdimi, Surname3_girdimi As String
        Dim BirthDate3_girdimi, DriverLicenceNo3_girdimi, DriverLicenceGivenDate3_girdimi As String
        Dim DriverLicenceType3_girdimi, CountryCode4_girdimi, IdentityCode4_girdimi As String
        Dim IdentityNo4_girdimi, Name4_girdimi, Surname4_girdimi As String
        Dim BirthDate4_girdimi, DriverLicenceNo4_girdimi, DriverLicenceGivenDate4_girdimi As String
        Dim DriverLicenceType4_girdimi, CountryCode5_girdimi, IdentityCode5_girdimi As String
        Dim IdentityNo5_girdimi, Name5_girdimi, Surname5_girdimi As String
        Dim BirthDate5_girdimi, DriverLicenceNo5_girdimi, DriverLicenceGivenDate5_girdimi As String
        Dim DriverLicenceType5_girdimi, CountryCode6_girdimi, IdentityCode6_girdimi As String
        Dim IdentityNo6_girdimi, Name6_girdimi, Surname6_girdimi As String
        Dim BirthDate6_girdimi, DriverLicenceNo6_girdimi, DriverLicenceGivenDate6_girdimi As String
        Dim DriverLicenceType6_girdimi, InsurancePremium_girdimi, AssistantFees_girdimi As String
        Dim OtherFees_girdimi, BasePriceValue_girdimi As String
        Dim CCRateValue_girdimi, DamageRateValue_girdimi, AgeRateValue_girdimi As String
        Dim DamagelessRateValue_girdimi As String
        Dim ProductType_girdimi As String
        Dim FuelType_girdimi As String
        Dim SteeringSide_girdimi As String
        Dim AnyDriverRateValue_girdimi As String
        Dim PolicyPremium_girdimi As String
        Dim PolicyPremiumTL_girdimi As String
        Dim InsurancePremiumTL_girdimi As String
        Dim PublicValueTL_girdimi As String
        Dim DamageRate_girdimi As String
        Dim DamagelessRate_girdimi As String
        Dim AnyDriverRate_girdimi As String
        Dim AgeRate_girdimi As String
        Dim CCRate_girdimi As String
        Dim Creditor_girdimi As String
        Dim FirstBeneficiary_girdimi As String
        Dim ExchangeRate_girdimi As String
        Dim AgencyRegisterCode_girdimi As String
        Dim TPNo_girdimi As String

        FirmCode_girdimi = "Hayır"
        ProductCode_girdimi = "Hayır"
        AgencyCode_girdimi = "Hayır"
        PolicyNumber_girdimi = "Hayır"
        TecditNumber_girdimi = "Hayır"
        ZeylCode_girdimi = "Hayır"
        ZeylNo_girdimi = "Hayır"
        PolicyType_girdimi = "Hayır"
        PolicyOwnerCountryCode_girdimi = "Hayır"
        PolicyOwnerIdentityCode_girdimi = "Hayır"
        PolicyOwnerIdentityNo_girdimi = "Hayır"
        PolicyOwnerName_girdimi = "Hayır"
        PolicyOwnerSurname_girdimi = "Hayır"
        PolicyOwnerBirthDate_girdimi = "Hayır"
        AddressLine1_girdimi = "Hayır"
        AddressLine2_girdimi = "Hayır"
        AddressLine3_girdimi = "Hayır"
        PlateCountryCode_girdimi = "Hayır"
        PlateNumber_girdimi = "Hayır"
        Brand_girdimi = "Hayır"
        Model_girdimi = "Hayır"
        ChassisNumber_girdimi = "Hayır"
        EngineNumber_girdimi = "Hayır"
        EnginePower_girdimi = "Hayır"
        ProductionYear_girdimi = "Hayır"
        Capacity_girdimi = "Hayır"
        CarType_girdimi = "Hayır"
        UsingStyle_girdimi = "Hayır"
        TariffCode_girdimi = "Hayır"
        ArrangeDate_girdimi = "Hayır"
        StartDate_girdimi = "Hayır"
        EndDate_girdimi = "Hayır"
        Material_girdimi = "Hayır"
        Corporal_girdimi = "Hayır"
        CurrencyCode_girdimi = "Hayır"
        PublicValue_girdimi = "Hayır"
        AuthorizedDrivers_girdimi = "Hayır"
        CountryCode1_girdimi = "Hayır"
        IdentityCode1_girdimi = "Hayır"
        IdentityNo1_girdimi = "Hayır"
        Name1_girdimi = "Hayır"
        Surname1_girdimi = "Hayır"
        BirthDate1_girdimi = "Hayır"
        DriverLicenceNo1_girdimi = "Hayır"
        DriverLicenceGivenDate1_girdimi = "Hayır"
        DriverLicenceType1_girdimi = "Hayır"
        CountryCode2_girdimi = "Hayır"
        IdentityCode2_girdimi = "Hayır"
        IdentityNo2_girdimi = "Hayır"
        Name2_girdimi = "Hayır"
        Surname2_girdimi = "Hayır"
        BirthDate2_girdimi = "Hayır"
        DriverLicenceNo2_girdimi = "Hayır"
        DriverLicenceGivenDate2_girdimi = "Hayır"
        DriverLicenceType2_girdimi = "Hayır"
        CountryCode3_girdimi = "Hayır"
        IdentityCode3_girdimi = "Hayır"
        IdentityNo3_girdimi = "Hayır"
        Name3_girdimi = "Hayır"
        Surname3_girdimi = "Hayır"
        BirthDate3_girdimi = "Hayır"
        DriverLicenceNo3_girdimi = "Hayır"
        DriverLicenceGivenDate3_girdimi = "Hayır"
        DriverLicenceType3_girdimi = "Hayır"
        CountryCode4_girdimi = "Hayır"
        IdentityCode4_girdimi = "Hayır"
        IdentityNo4_girdimi = "Hayır"
        Name4_girdimi = "Hayır"
        Surname4_girdimi = "Hayır"
        BirthDate4_girdimi = "Hayır"
        DriverLicenceNo4_girdimi = "Hayır"
        DriverLicenceGivenDate4_girdimi = "Hayır"
        DriverLicenceType4_girdimi = "Hayır"
        CountryCode5_girdimi = "Hayır"
        IdentityCode5_girdimi = "Hayır"
        IdentityNo5_girdimi = "Hayır"
        Name5_girdimi = "Hayır"
        Surname5_girdimi = "Hayır"
        BirthDate5_girdimi = "Hayır"
        DriverLicenceNo5_girdimi = "Hayır"
        DriverLicenceGivenDate5_girdimi = "Hayır"
        DriverLicenceType5_girdimi = "Hayır"
        CountryCode6_girdimi = "Hayır"
        IdentityCode6_girdimi = "Hayır"
        IdentityNo6_girdimi = "Hayır"
        Name6_girdimi = "Hayır"
        Surname6_girdimi = "Hayır"
        BirthDate6_girdimi = "Hayır"
        DriverLicenceNo6_girdimi = "Hayır"
        DriverLicenceGivenDate6_girdimi = "Hayır"
        DriverLicenceType6_girdimi = "Hayır"
        InsurancePremium_girdimi = "Hayır"
        AssistantFees_girdimi = "Hayır"
        OtherFees_girdimi = "Hayır"
        BasePriceValue_girdimi = "Hayır"
        CCRateValue_girdimi = "Hayır"
        DamageRateValue_girdimi = "Hayır"
        AgeRateValue_girdimi = "Hayır"
        DamagelessRateValue_girdimi = "Hayır"
        ProductType_girdimi = "Hayır"
        FuelType_girdimi = "Hayır"
        SteeringSide_girdimi = "Hayır"
        AnyDriverRateValue_girdimi = "Hayır"
        PolicyPremium_girdimi = "Hayır"
        PolicyPremiumTL_girdimi = "Hayır"
        InsurancePremiumTL_girdimi = "Hayır"
        PublicValueTL_girdimi = "Hayır"
        DamageRate_girdimi = "Hayır"
        DamagelessRate_girdimi = "Hayır"
        AnyDriverRate_girdimi = "Hayır"
        AgeRate_girdimi = "Hayır"
        CCRate_girdimi = "Hayır"
        Creditor_girdimi = "Hayır"
        FirstBeneficiary_girdimi = "Hayır"
        ExchangeRate_girdimi = "Hayır"
        AgencyRegisterCode_girdimi = "Hayır"
        TPNo_girdimi = "Hayır"


        Dim calculations2_erisim As New Calculations2_Erisim
        Dim dairearactip_erisim As New CLASSDAIREARACTIP_ERISIM

        For Each Element As XmlElement In XmlDoc.SelectNodes("//*")
            'debugy = debugy + Element.Name + "<br/>"
            For Each Attribute As XmlAttribute In Element.Attributes

                'FirmCode
                If Attribute.Name = "FirmCode" Then
                    girdisayisi = girdisayisi + 1
                    FirmCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        PolicyInfo.FirmCode = Attribute.Value
                        If sirket.sirketkod <> Attribute.Value Then
                            xmlhata = "Gönderdiğiniz XML'deki FirmCode " + _
                            "ile giriş yaptığınız kullanıcı adı ve şifre ile" + _
                            " girdiğiniz şirketin kodu uyuşmuyor."
                        End If
                    Else
                        xmlhata = "Gönderilen XML'de FirmCode boş olamaz."
                    End If
                End If

                'ProductCode
                If Attribute.Name = "ProductCode" Then
                    girdisayisi = girdisayisi + 1
                    ProductCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
                            PolicyInfo.ProductCode = Trim(Attribute.Value)
                            varmi = urunkod_erisim.urunkodvarmi(PolicyInfo.ProductCode)
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

                'AgencyCode
                If Attribute.Name = "AgencyCode" Then
                    girdisayisi = girdisayisi + 1
                    AgencyCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        PolicyInfo.AgencyCode = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                    If PolicyInfo.AgencyCode = "" Then
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                End If

                'PolicyNumber
                If Attribute.Name = "PolicyNumber" Then
                    girdisayisi = girdisayisi + 1
                    PolicyNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        PolicyInfo.PolicyNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                    If PolicyInfo.PolicyNumber = "" Then
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                End If

                'TecditNumber
                If Attribute.Name = "TecditNumber" Then
                    girdisayisi = girdisayisi + 1
                    TecditNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        PolicyInfo.TecditNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                    If PolicyInfo.TecditNumber = "" Then
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                End If


                'ZeylCode
                If Attribute.Name = "ZeylCode" Then
                    girdisayisi = girdisayisi + 1
                    ZeylCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            PolicyInfo.ZeylCode = Trim(Attribute.Value)
                            varmi = zeylcode_erisim.zeylkodvarmi(PolicyInfo.ZeylCode)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de ZeylCode KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de ZeylCode KKSBM tarafından tanımlanmamış."
                        End Try
                    Else
                        xmlhata = "Gönderilen XML'de ZeylCode boş olamaz."
                    End If
                End If

                'ZeylNo
                If Attribute.Name = "ZeylNo" Then
                    girdisayisi = girdisayisi + 1
                    ZeylNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        PolicyInfo.ZeylNo = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de ZeylNo  boş olamaz."
                    End If
                    If PolicyInfo.ZeylNo = "" Then
                        xmlhata = "Gönderilen XML'de ZeylNo boş olamaz."
                    End If
                End If

                'PolicyType
                If Attribute.Name = "PolicyType" Then
                    girdisayisi = girdisayisi + 1
                    PolicyType_girdimi = "Evet"
                    Try
                        PolicyInfo.PolicyType = CInt(Attribute.Value)
                        Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
                        Dim varmi As String = "Evet"
                        varmi = policetip_erisim.policetipvarmi(PolicyInfo.PolicyType)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de PolicyType KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        PolicyInfo.PolicyType = 0
                        xmlhata = "Gönderilen XML'de PolicyType rakam olmak zorunda veya 0 olmamalı."
                    End Try
                End If

                'PolicyOwnerCountryCode
                If Attribute.Name = "PolicyOwnerCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerCountryCode_girdimi = "Evet"
                    PolicyInfo.PolicyOwnerCountryCode = Attribute.Value
                End If

                'PolicyOwnerIdentityCode
                If Attribute.Name = "PolicyOwnerIdentityCode" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerIdentityCode_girdimi = "Evet"
                    PolicyInfo.PolicyOwnerIdentityCode = Attribute.Value
                End If

                'PolicyOwnerIdentityNo
                If Attribute.Name = "PolicyOwnerIdentityNo" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerIdentityNo_girdimi = "Evet"
                    PolicyInfo.PolicyOwnerIdentityNo = Attribute.Value
                End If

                'PolicyOwnerName
                If Attribute.Name = "PolicyOwnerName" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerName_girdimi = "Evet"
                    PolicyInfo.PolicyOwnerName = Attribute.Value
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de PolicyOwnerName boş olmamalıdır."
                    End If
                End If

                'PolicyOwnerSurname
                If Attribute.Name = "PolicyOwnerSurname" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerSurname_girdimi = "Evet"
                    PolicyInfo.PolicyOwnerSurname = Attribute.Value
                End If


                'PolicyOwnerBirthDate
                If Attribute.Name = "PolicyOwnerBirthDate" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerBirthDate_girdimi = "Evet"
                    Try
                        PolicyInfo.PolicyOwnerBirthDate = Attribute.Value
                    Catch
                        PolicyInfo.PolicyOwnerBirthDate = Nothing
                    End Try
                End If


                'AddressLine1
                If Attribute.Name = "AddressLine1" Then
                    girdisayisi = girdisayisi + 1
                    AddressLine1_girdimi = "Evet"
                    PolicyInfo.AddressLine1 = Attribute.Value
                End If

                'AddressLine2
                If Attribute.Name = "AddressLine2" Then
                    girdisayisi = girdisayisi + 1
                    AddressLine2_girdimi = "Evet"
                    PolicyInfo.AddressLine2 = Attribute.Value
                End If


                'AddressLine3
                If Attribute.Name = "AddressLine3" Then
                    girdisayisi = girdisayisi + 1
                    AddressLine3_girdimi = "Evet"
                    PolicyInfo.AddressLine3 = Attribute.Value
                End If

                'PlateCountryCode
                If Attribute.Name = "PlateCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    PlateCountryCode_girdimi = "Evet"
                    If IsNumeric(Attribute.Value) = True Then
                        PolicyInfo.PlateCountryCode = Attribute.Value
                    Else
                        PolicyInfo.PlateCountryCode = 0
                    End If
                End If


                'PlateNumber
                If Attribute.Name = "PlateNumber" Then
                    girdisayisi = girdisayisi + 1
                    PlateNumber_girdimi = "Evet"
                    Try
                        PolicyInfo.PlateNumber = Replace(Trim(UCase(Attribute.Value)), " ", "")
                        If Len(Attribute.Value) = 0 Then
                            xmlhata = "Gönderilen XML'de PlateNumber boş olmamalıdır."
                        End If
                    Catch ex As Exception
                    End Try
                End If


                'Brand
                If Attribute.Name = "Brand" Then
                    girdisayisi = girdisayisi + 1
                    Brand_girdimi = "Evet"
                    PolicyInfo.Brand = Attribute.Value
                End If


                'Model
                If Attribute.Name = "Model" Then
                    girdisayisi = girdisayisi + 1
                    Model_girdimi = "Evet"
                    PolicyInfo.Model = Attribute.Value
                End If


                'ChassisNumber
                If Attribute.Name = "ChassisNumber" Then
                    girdisayisi = girdisayisi + 1
                    ChassisNumber_girdimi = "Evet"
                    PolicyInfo.ChassisNumber = Attribute.Value
                End If


                'EngineNumber
                If Attribute.Name = "EngineNumber" Then
                    girdisayisi = girdisayisi + 1
                    EngineNumber_girdimi = "Evet"
                    PolicyInfo.EngineNumber = Attribute.Value
                End If


                'EnginePower
                If Attribute.Name = "EnginePower" Then
                    girdisayisi = girdisayisi + 1
                    EnginePower_girdimi = "Evet"
                    Try
                        PolicyInfo.EnginePower = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.EnginePower = 0
                        xmlhata = "Gönderilen XML'de EnginePower rakamsal olmalıdır."
                    End Try
                End If


                'ProductionYear
                If Attribute.Name = "ProductionYear" Then
                    girdisayisi = girdisayisi + 1
                    ProductionYear_girdimi = "Evet"
                    Try
                        PolicyInfo.ProductionYear = CInt(Attribute.Value)
                        If Len(PolicyInfo.ProductionYear) <> 4 Then
                            xmlhata = "Gönderilen XML'de ProductionYear 4 karakterden oluşmalıdır."
                        End If

                    Catch ex As Exception
                        PolicyInfo.ProductionYear = 0
                    End Try
                End If


                'Capacity
                If Attribute.Name = "Capacity" Then
                    girdisayisi = girdisayisi + 1
                    Capacity_girdimi = "Evet"
                    Try
                        PolicyInfo.Capacity = CInt(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.Capacity = 0
                    End Try
                End If


                'CarType
                If Attribute.Name = "CarType" Then
                    girdisayisi = girdisayisi + 1
                    CarType_girdimi = "Evet"
                    PolicyInfo.CarType = Attribute.Value
                End If


                'UsingStyle
                If Attribute.Name = "UsingStyle" Then
                    girdisayisi = girdisayisi + 1
                    UsingStyle_girdimi = "Evet"
                    PolicyInfo.UsingStyle = Attribute.Value
                End If


                'TariffCode
                If Attribute.Name = "TariffCode" Then
                    girdisayisi = girdisayisi + 1
                    TariffCode_girdimi = "Evet"
                    Try
                        Dim varmi As String = "Evet"
                        PolicyInfo.TariffCode = Attribute.Value
                        varmi = aractarife_erisim.kodvarmi(PolicyInfo.TariffCode)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de TariffCode KKSBM tarafından tanımlanmamıştır."
                        End If
                    Catch ex As Exception
                        PolicyInfo.TariffCode = ""
                    End Try
                End If


                'ArrangeDate
                If Attribute.Name = "ArrangeDate" Then
                    girdisayisi = girdisayisi + 1
                    ArrangeDate_girdimi = "Evet"
                    Try
                        PolicyInfo.ArrangeDate = Attribute.Value
                    Catch
                        xmlhata = "Gönderilen XML'de ArrangeDate boş olmamalı" + _
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " + _
                        "şeklinde olmalıdır."
                        PolicyInfo.ArrangeDate = Nothing
                    End Try
                End If


                'StartDate
                If Attribute.Name = "StartDate" Then
                    girdisayisi = girdisayisi + 1
                    StartDate_girdimi = "Evet"
                    Try
                        PolicyInfo.StartDate = Attribute.Value
                    Catch
                        xmlhata = "Gönderilen XML'de StartDate boş olmamalı" + _
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " + _
                        "şeklinde olmalıdır."
                        PolicyInfo.StartDate = Nothing
                    End Try
                End If


                'EndDate
                If Attribute.Name = "EndDate" Then
                    girdisayisi = girdisayisi + 1
                    EndDate_girdimi = "Evet"
                    Try
                        PolicyInfo.EndDate = Attribute.Value
                    Catch
                        xmlhata = "Gönderilen XML'de EndDate boş olmamalı" + _
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " + _
                        "şeklinde olmalıdır."
                        PolicyInfo.EndDate = Nothing
                    End Try
                End If


                'Material
                If Attribute.Name = "Material" Then
                    girdisayisi = girdisayisi + 1
                    Material_girdimi = "Evet"
                    Try
                        PolicyInfo.Material = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.Material = 0
                    End Try
                End If


                'Corporal
                If Attribute.Name = "Corporal" Then
                    girdisayisi = girdisayisi + 1
                    Corporal_girdimi = "Evet"
                    Try
                        PolicyInfo.Corporal = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.Corporal = 0
                    End Try
                End If


                'CurrencyCode
                If Attribute.Name = "CurrencyCode" Then
                    girdisayisi = girdisayisi + 1
                    CurrencyCode_girdimi = "Evet"
                    Try
                        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
                        Dim varmi = "Evet"
                        PolicyInfo.CurrencyCode = Attribute.Value
                        varmi = currencycode_erisim.currencycodevarmi(PolicyInfo.CurrencyCode)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                    End Try
                End If


                'PublicValue
                If Attribute.Name = "PublicValue" Then
                    girdisayisi = girdisayisi + 1
                    PublicValue_girdimi = "Evet"
                    Try
                        PolicyInfo.PublicValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.PublicValue = 0
                    End Try
                End If


                'AuthorizedDrivers
                If Attribute.Name = "AuthorizedDrivers" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        AuthorizedDrivers_girdimi = "Evet"
                        If Attribute.Value = "A" Or Attribute.Value = "N" Or Attribute.Value = "a" Or Attribute.Value = "n" Then
                            PolicyInfo.AuthorizedDrivers = UCase(Attribute.Value)
                        Else
                            xmlhata = "Gönderdiğiniz XML'de AuthorizedDrivers 'A' veya 'N' olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de AuthorizedDrivers 'A' veya 'N' olmalıdır."
                    End Try
                End If

                '---1----------------------------------------------------------
                'CountryCode1
                If Attribute.Name = "CountryCode1" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        CountryCode1_girdimi = "Evet"
                        PolicyInfo.CountryCode1 = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.CountryCode1 = ""
                    End Try
                End If
                'IdentityCode1
                If Attribute.Name = "IdentityCode1" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        IdentityCode1_girdimi = "Evet"
                        PolicyInfo.IdentityCode1 = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.IdentityCode1 = ""
                    End Try
                End If

                'IdentityNo1
                If Attribute.Name = "IdentityNo1" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        IdentityNo1_girdimi = "Evet"
                        PolicyInfo.IdentityNo1 = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.IdentityNo1 = ""
                    End Try
                End If
                'Name1
                If Attribute.Name = "Name1" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        Name1_girdimi = "Evet"
                        PolicyInfo.Name1 = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.Name1 = ""
                    End Try
                End If
                'Surname1
                If Attribute.Name = "Surname1" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        Surname1_girdimi = "Evet"
                        PolicyInfo.Surname1 = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.Surname1 = ""
                    End Try
                End If
                'BirthDate1
                If Attribute.Name = "BirthDate1" Then
                    girdisayisi = girdisayisi + 1
                    BirthDate1_girdimi = "Evet"
                    Try
                        PolicyInfo.BirthDate1 = Attribute.Value
                    Catch
                        PolicyInfo.BirthDate1 = Nothing
                    End Try
                End If
                'DriverLicenceNo1
                If Attribute.Name = "DriverLicenceNo1" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        DriverLicenceNo1_girdimi = "Evet"
                        PolicyInfo.DriverLicenceNo1 = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.DriverLicenceNo1 = ""
                    End Try
                End If
                'DriverLicenceGivenDate1
                If Attribute.Name = "DriverLicenceGivenDate1" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceGivenDate1_girdimi = "Evet"
                    Try
                        PolicyInfo.DriverLicenceGivenDate1 = Attribute.Value
                    Catch
                        PolicyInfo.DriverLicenceGivenDate1 = Nothing
                    End Try
                End If
                'DriverLicenceType1
                If Attribute.Name = "DriverLicenceType1" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceType1_girdimi = "Evet"
                    PolicyInfo.DriverLicenceType1 = Attribute.Value
                End If

                '---2----------------------------------------------------------
                'CountryCode2
                If Attribute.Name = "CountryCode2" Then
                    girdisayisi = girdisayisi + 1
                    CountryCode2_girdimi = "Evet"
                    PolicyInfo.CountryCode2 = Attribute.Value
                End If
                'IdentityCode2
                If Attribute.Name = "IdentityCode2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode2_girdimi = "Evet"
                    PolicyInfo.IdentityCode2 = Attribute.Value
                End If
                'IdentityNo2
                If Attribute.Name = "IdentityNo2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNo2_girdimi = "Evet"
                    PolicyInfo.IdentityNo2 = Attribute.Value
                End If
                'Name2
                If Attribute.Name = "Name2" Then
                    girdisayisi = girdisayisi + 1
                    Name2_girdimi = "Evet"
                    PolicyInfo.Name2 = Attribute.Value
                End If
                'Surname2
                If Attribute.Name = "Surname2" Then
                    girdisayisi = girdisayisi + 1
                    Surname2_girdimi = "Evet"
                    PolicyInfo.Surname2 = Attribute.Value
                End If
                'BirthDate2
                If Attribute.Name = "BirthDate2" Then
                    girdisayisi = girdisayisi + 1
                    BirthDate2_girdimi = "Evet"
                    Try
                        PolicyInfo.BirthDate2 = Attribute.Value
                    Catch
                        PolicyInfo.BirthDate2 = Nothing
                    End Try
                End If
                'DriverLicenceNo2
                If Attribute.Name = "DriverLicenceNo2" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceNo2_girdimi = "Evet"
                    PolicyInfo.DriverLicenceNo2 = Attribute.Value
                End If
                'DriverLicenceGivenDate2
                If Attribute.Name = "DriverLicenceGivenDate2" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceGivenDate2_girdimi = "Evet"
                    Try
                        PolicyInfo.DriverLicenceGivenDate2 = Attribute.Value
                    Catch
                        PolicyInfo.DriverLicenceGivenDate2 = Nothing
                    End Try
                End If
                'DriverLicenceType2
                If Attribute.Name = "DriverLicenceType2" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceType2_girdimi = "Evet"
                    PolicyInfo.DriverLicenceType2 = Attribute.Value
                End If


                '---3----------------------------------------------------------
                'CountryCode3
                If Attribute.Name = "CountryCode3" Then
                    girdisayisi = girdisayisi + 1
                    CountryCode3_girdimi = "Evet"
                    PolicyInfo.CountryCode3 = Attribute.Value
                End If
                'IdentityCode3
                If Attribute.Name = "IdentityCode3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode3_girdimi = "Evet"
                    PolicyInfo.IdentityCode3 = Attribute.Value
                End If
                'IdentityNo3
                If Attribute.Name = "IdentityNo3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNo3_girdimi = "Evet"
                    PolicyInfo.IdentityNo3 = Attribute.Value
                End If
                'Name3
                If Attribute.Name = "Name3" Then
                    girdisayisi = girdisayisi + 1
                    Name3_girdimi = "Evet"
                    PolicyInfo.Name3 = Attribute.Value
                End If
                'Surname3
                If Attribute.Name = "Surname3" Then
                    girdisayisi = girdisayisi + 1
                    Surname3_girdimi = "Evet"
                    PolicyInfo.Surname3 = Attribute.Value
                End If
                'BirthDate3
                If Attribute.Name = "BirthDate3" Then
                    girdisayisi = girdisayisi + 1
                    BirthDate3_girdimi = "Evet"
                    Try
                        PolicyInfo.BirthDate3 = Attribute.Value
                    Catch
                        PolicyInfo.BirthDate3 = Nothing
                    End Try
                End If
                'DriverLicenceNo3
                If Attribute.Name = "DriverLicenceNo3" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceNo3_girdimi = "Evet"
                    PolicyInfo.DriverLicenceNo3 = Attribute.Value
                End If
                'DriverLicenceGivenDate3
                If Attribute.Name = "DriverLicenceGivenDate3" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceGivenDate3_girdimi = "Evet"
                    Try
                        PolicyInfo.DriverLicenceGivenDate3 = Attribute.Value
                    Catch
                        PolicyInfo.DriverLicenceGivenDate3 = Nothing
                    End Try
                End If
                'DriverLicenceType3
                If Attribute.Name = "DriverLicenceType3" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceType3_girdimi = "Evet"
                    PolicyInfo.DriverLicenceType3 = Attribute.Value
                End If


                '---4----------------------------------------------------------
                'CountryCode4
                If Attribute.Name = "CountryCode4" Then
                    girdisayisi = girdisayisi + 1
                    CountryCode4_girdimi = "Evet"
                    PolicyInfo.CountryCode4 = Attribute.Value
                End If
                'IdentityCode4
                If Attribute.Name = "IdentityCode4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode4_girdimi = "Evet"
                    PolicyInfo.IdentityCode4 = Attribute.Value
                End If
                'IdentityNo4
                If Attribute.Name = "IdentityNo4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNo4_girdimi = "Evet"
                    PolicyInfo.IdentityNo4 = Attribute.Value
                End If
                'Name4
                If Attribute.Name = "Name4" Then
                    girdisayisi = girdisayisi + 1
                    Name4_girdimi = "Evet"
                    PolicyInfo.Name4 = Attribute.Value
                End If
                'Surname4
                If Attribute.Name = "Surname4" Then
                    girdisayisi = girdisayisi + 1
                    Surname4_girdimi = "Evet"
                    PolicyInfo.Surname4 = Attribute.Value
                End If
                'BirthDate4
                If Attribute.Name = "BirthDate4" Then
                    girdisayisi = girdisayisi + 1
                    BirthDate4_girdimi = "Evet"
                    Try
                        PolicyInfo.BirthDate4 = Attribute.Value
                    Catch
                        PolicyInfo.BirthDate4 = Nothing
                    End Try
                End If
                'DriverLicenceNo4
                If Attribute.Name = "DriverLicenceNo4" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceNo4_girdimi = "Evet"
                    PolicyInfo.DriverLicenceNo4 = Attribute.Value
                End If
                'DriverLicenceGivenDate4
                If Attribute.Name = "DriverLicenceGivenDate4" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceGivenDate4_girdimi = "Evet"
                    Try
                        PolicyInfo.DriverLicenceGivenDate4 = Attribute.Value
                    Catch
                        PolicyInfo.DriverLicenceGivenDate4 = Nothing
                    End Try
                End If
                'DriverLicenceType4
                If Attribute.Name = "DriverLicenceType4" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceType4_girdimi = "Evet"
                    PolicyInfo.DriverLicenceType4 = Attribute.Value
                End If


                '---5----------------------------------------------------------
                'CountryCode5
                If Attribute.Name = "CountryCode5" Then
                    girdisayisi = girdisayisi + 1
                    CountryCode5_girdimi = "Evet"
                    PolicyInfo.CountryCode5 = Attribute.Value
                End If
                'IdentityCode5
                If Attribute.Name = "IdentityCode5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode5_girdimi = "Evet"
                    PolicyInfo.IdentityCode5 = Attribute.Value
                End If
                'IdentityNo5
                If Attribute.Name = "IdentityNo5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNo5_girdimi = "Evet"
                    PolicyInfo.IdentityNo5 = Attribute.Value
                End If
                'Name5
                If Attribute.Name = "Name5" Then
                    girdisayisi = girdisayisi + 1
                    Name5_girdimi = "Evet"
                    PolicyInfo.Name5 = Attribute.Value
                End If
                'Surname5
                If Attribute.Name = "Surname5" Then
                    girdisayisi = girdisayisi + 1
                    Surname5_girdimi = "Evet"
                    PolicyInfo.Surname5 = Attribute.Value
                End If
                'BirthDate5
                If Attribute.Name = "BirthDate5" Then
                    girdisayisi = girdisayisi + 1
                    BirthDate5_girdimi = "Evet"
                    Try
                        PolicyInfo.BirthDate5 = Attribute.Value
                    Catch
                        PolicyInfo.BirthDate5 = Nothing
                    End Try
                End If
                'DriverLicenceNo5
                If Attribute.Name = "DriverLicenceNo5" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceNo5_girdimi = "Evet"
                    PolicyInfo.DriverLicenceNo5 = Attribute.Value
                End If
                'DriverLicenceGivenDate5
                If Attribute.Name = "DriverLicenceGivenDate5" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceGivenDate5_girdimi = "Evet"
                    Try
                        PolicyInfo.DriverLicenceGivenDate5 = Attribute.Value
                    Catch
                        PolicyInfo.DriverLicenceGivenDate5 = Nothing
                    End Try
                End If
                'DriverLicenceType5
                If Attribute.Name = "DriverLicenceType5" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceType5_girdimi = "Evet"
                    PolicyInfo.DriverLicenceType5 = Attribute.Value
                End If


                '---6----------------------------------------------------------
                'CountryCode6
                If Attribute.Name = "CountryCode6" Then
                    girdisayisi = girdisayisi + 1
                    CountryCode6_girdimi = "Evet"
                    PolicyInfo.CountryCode6 = Attribute.Value
                End If
                'IdentityCode6
                If Attribute.Name = "IdentityCode6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode6_girdimi = "Evet"
                    PolicyInfo.IdentityCode6 = Attribute.Value
                End If
                'IdentityNo6
                If Attribute.Name = "IdentityNo6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNo6_girdimi = "Evet"
                    PolicyInfo.IdentityNo6 = Attribute.Value
                End If
                'Name6
                If Attribute.Name = "Name6" Then
                    girdisayisi = girdisayisi + 1
                    Name6_girdimi = "Evet"
                    PolicyInfo.Name6 = Attribute.Value
                End If
                'Surname6
                If Attribute.Name = "Surname6" Then
                    girdisayisi = girdisayisi + 1
                    Surname6_girdimi = "Evet"
                    PolicyInfo.Surname6 = Attribute.Value
                End If
                'BirthDate6
                If Attribute.Name = "BirthDate6" Then
                    girdisayisi = girdisayisi + 1
                    BirthDate6_girdimi = "Evet"
                    Try
                        PolicyInfo.BirthDate6 = Attribute.Value
                    Catch
                        PolicyInfo.BirthDate6 = Nothing
                    End Try
                End If
                'DriverLicenceNo6
                If Attribute.Name = "DriverLicenceNo6" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceNo6_girdimi = "Evet"
                    PolicyInfo.DriverLicenceNo6 = Attribute.Value
                End If
                'DriverLicenceGivenDate6
                If Attribute.Name = "DriverLicenceGivenDate6" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceGivenDate6_girdimi = "Evet"
                    Try
                        PolicyInfo.DriverLicenceGivenDate6 = Attribute.Value
                    Catch
                        PolicyInfo.DriverLicenceGivenDate6 = Nothing
                    End Try
                End If
                'DriverLicenceType6
                If Attribute.Name = "DriverLicenceType6" Then
                    girdisayisi = girdisayisi + 1
                    DriverLicenceType6_girdimi = "Evet"
                    PolicyInfo.DriverLicenceType6 = Attribute.Value
                End If


                'InsurancePremium
                If Attribute.Name = "InsurancePremium" Then
                    girdisayisi = girdisayisi + 1
                    InsurancePremium_girdimi = "Evet"
                    Try
                        PolicyInfo.InsurancePremium = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.InsurancePremium = 0
                        xmlhata = "Gönderilen XML'de InsuarencePremium boş olamaz."
                    End Try
                End If


                'AssistantFees
                If Attribute.Name = "AssistantFees" Then
                    girdisayisi = girdisayisi + 1
                    AssistantFees_girdimi = "Evet"
                    Try
                        PolicyInfo.AssistantFees = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.AssistantFees = 0
                        xmlhata = "Gönderilen XML'de AssistantFees boş olamaz."
                    End Try
                End If


                'OtherFees
                If Attribute.Name = "OtherFees" Then
                    girdisayisi = girdisayisi + 1
                    OtherFees_girdimi = "Evet"
                    Try
                        PolicyInfo.OtherFees = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.OtherFees = 0
                        xmlhata = "Gönderilen XML'de OtherFees boş olamaz."
                    End Try
                End If



                'BasePriceValue
                If Attribute.Name = "BasePriceValue" Then
                    girdisayisi = girdisayisi + 1
                    BasePriceValue_girdimi = "Evet"
                    Try
                        PolicyInfo.BasePriceValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.BasePriceValue = 0
                        xmlhata = "Gönderilen XML'de BasePriceValue boş olamaz."
                    End Try
                End If


                'CCRateValue
                If Attribute.Name = "CCRateValue" Then
                    girdisayisi = girdisayisi + 1
                    CCRateValue_girdimi = "Evet"
                    Try
                        PolicyInfo.CCRateValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.CCRateValue = 0
                        xmlhata = "Gönderilen XML'de CCRateValue boş olamaz."
                    End Try
                End If


                'DamageRateValue
                If Attribute.Name = "DamageRateValue" Then
                    girdisayisi = girdisayisi + 1
                    DamageRateValue_girdimi = "Evet"
                    Try
                        PolicyInfo.DamageRateValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.DamageRateValue = 0
                        xmlhata = "Gönderilen XML'de DamageRate Value boş olamaz."
                    End Try
                End If

                'AgeRateValue
                If Attribute.Name = "AgeRateValue" Then
                    girdisayisi = girdisayisi + 1
                    AgeRateValue_girdimi = "Evet"
                    Try
                        PolicyInfo.AgeRateValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.AgeRateValue = 0
                        xmlhata = "Gönderilen XML'de AgeRateValue Value boş olamaz."
                    End Try
                End If


                'DamagelessRateValue
                If Attribute.Name = "DamagelessRateValue" Then
                    girdisayisi = girdisayisi + 1
                    DamagelessRateValue_girdimi = "Evet"
                    Try
                        PolicyInfo.DamagelessRateValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.DamagelessRateValue = 0
                        xmlhata = "Gönderilen XML'de DamagelessRateValue Value boş olamaz."
                    End Try
                End If


                'ProductType
                If Attribute.Name = "ProductType" Then
                    girdisayisi = girdisayisi + 1
                    ProductType_girdimi = "Evet"
                    Try
                        PolicyInfo.ProductType = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.ProductType = ""
                        xmlhata = "Gönderilen XML'de ProductType geçerli bir değer değildir."
                    End Try
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de ProductType boş olamaz."
                    End If
                End If


                'FuelType
                If Attribute.Name = "FuelType" Then
                    girdisayisi = girdisayisi + 1
                    FuelType_girdimi = "Evet"
                    Try
                        PolicyInfo.FuelType = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.FuelType = 0
                    End Try
                End If


                'SteeringSide
                If Attribute.Name = "SteeringSide" Then
                    girdisayisi = girdisayisi + 1
                    SteeringSide_girdimi = "Evet"
                    Try
                        PolicyInfo.SteeringSide = Trim(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.SteeringSide = "0"
                    End Try
                End If



                'AnyDriverRateValue
                If Attribute.Name = "AnyDriverRateValue" Then
                    girdisayisi = girdisayisi + 1
                    AnyDriverRateValue_girdimi = "Evet"
                    Try
                        PolicyInfo.AnyDriverRateValue = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.AnyDriverRateValue = 0
                        xmlhata = "Gönderilen XML'de AnyDriverRateValue Value boş olamaz."
                    End Try
                End If


                'PolicyPremium
                If Attribute.Name = "PolicyPremium" Then
                    girdisayisi = girdisayisi + 1
                    PolicyPremium_girdimi = "Evet"
                    Try
                        PolicyInfo.PolicyPremium = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.PolicyPremium = 0
                        xmlhata = "Gönderilen XML'de PolicyPremium Value boş olamaz."
                    End Try
                End If

                'PolicyPremiumTL
                If Attribute.Name = "PolicyPremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    PolicyPremiumTL_girdimi = "Evet"
                    Try
                        PolicyInfo.PolicyPremiumTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.PolicyPremiumTL = 0
                        xmlhata = "Gönderilen XML'de PolicyPremiumTL Value boş olamaz."
                    End Try
                End If


                'InsurancePremiumTL
                If Attribute.Name = "InsurancePremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    InsurancePremiumTL_girdimi = "Evet"
                    Try
                        PolicyInfo.InsurancePremiumTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.InsurancePremiumTL = 0
                        xmlhata = "Gönderilen XML'de InsurancePremiumTL Value boş olamaz."
                    End Try
                End If


                'PublicValueTL
                If Attribute.Name = "PublicValueTL" Then
                    girdisayisi = girdisayisi + 1
                    PublicValueTL_girdimi = "Evet"
                    Try
                        PolicyInfo.PublicValueTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.PublicValueTL = 0
                        xmlhata = "Gönderilen XML'de PublicValueTL Value boş olamaz."
                    End Try
                End If


                'DamageRate
                If Attribute.Name = "DamageRate" Then
                    girdisayisi = girdisayisi + 1
                    DamageRate_girdimi = "Evet"
                    Try
                        PolicyInfo.DamageRate = CInt(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.DamageRate = 0
                        xmlhata = "Gönderilen XML'de DamageRate Value boş olamaz."
                    End Try
                End If

                'DamagelessRate
                If Attribute.Name = "DamagelessRate" Then
                    girdisayisi = girdisayisi + 1
                    DamagelessRate_girdimi = "Evet"
                    Try
                        PolicyInfo.DamagelessRate = CInt(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.DamagelessRate = 0
                        xmlhata = "Gönderilen XML'de DamagelessRate Value boş olamaz."
                    End Try
                End If


                'AnyDriverRate
                If Attribute.Name = "AnyDriverRate" Then
                    girdisayisi = girdisayisi + 1
                    AnyDriverRate_girdimi = "Evet"
                    Try
                        PolicyInfo.AnyDriverRate = CInt(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.AnyDriverRate = 0
                        xmlhata = "Gönderilen XML'de AnyDriverRate Value boş olamaz."
                    End Try
                End If

                'AgeRate
                If Attribute.Name = "AgeRate" Then
                    girdisayisi = girdisayisi + 1
                    AgeRate_girdimi = "Evet"
                    Try
                        PolicyInfo.AgeRate = CInt(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.AgeRate = 0
                        xmlhata = "Gönderilen XML'de AgeRate Value boş olamaz."
                    End Try
                End If


                'CCRate
                If Attribute.Name = "CCRate" Then
                    girdisayisi = girdisayisi + 1
                    CCRate_girdimi = "Evet"
                    Try
                        PolicyInfo.CCRate = CInt(Attribute.Value)
                    Catch ex As Exception
                        PolicyInfo.CCRate = 0
                        xmlhata = "Gönderilen XML'de CCRate boş olamaz."
                    End Try
                End If



                'Creditor
                If Attribute.Name = "Creditor" Then
                    girdisayisi = girdisayisi + 1
                    Creditor_girdimi = "Evet"
                    Try
                        PolicyInfo.Creditor = CInt(Attribute.Value)
                        If PolicyInfo.Creditor <> 0 And PolicyInfo.Creditor <> 1 Then
                            xmlhata = "Gönderilen XML'de Creditor değeri 1 yada 0 olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Creditor değeri 1 yada 0 olmalıdır."
                    End Try
                End If


                'FirstBeneficiary
                If Attribute.Name = "FirstBeneficiary" Then
                    girdisayisi = girdisayisi + 1
                    FirstBeneficiary_girdimi = "Evet"
                    Try
                        PolicyInfo.FirstBeneficiary = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.FirstBeneficiary = ""
                    End Try
                End If

                'ExchangeRate
                If Attribute.Name = "ExchangeRate" Then
                    girdisayisi = girdisayisi + 1
                    ExchangeRate_girdimi = "Evet"
                    Try
                        PolicyInfo.ExchangeRate = Attribute.Value
                    Catch ex As Exception
                        PolicyInfo.ExchangeRate = 0
                        xmlhata = "Gönderilen XML'de ExchangeRate rakamsal olmalıdır."
                    End Try
                End If


                'AgencyRegisterCode
                If Attribute.Name = "AgencyRegisterCode" Then
                    girdisayisi = girdisayisi + 1
                    AgencyRegisterCode_girdimi = "Evet"
                    PolicyInfo.AgencyRegisterCode = Attribute.Value
                End If

                'TPNo
                If Attribute.Name = "TPNo" Then
                    girdisayisi = girdisayisi + 1
                    TPNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            PolicyInfo.TPNo = Trim(Attribute.Value)
                            varmi = personel_erisim.ciftkayitkontrol("tpno", PolicyInfo.TPNo)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                        End Try
                    End If
                    If Attribute.Value = "" Then
                        PolicyInfo.TPNo = ""
                    End If
                End If

                'debugy = debugy + Attribute.Name + ":" + Attribute.Value + "<br/>"
            Next

        Next

        'girilmiyenleri tespit et 
        Dim girilmeyenstr As String = "Gönderilmeyen XML Alanları:"

        If FirmCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FirmCode" + "-"
        End If
        If ProductCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductCode" + "-"
        End If
        If AgencyCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgencyCode" + "-"
        End If
        If PolicyNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyNumber" + "-"
        End If
        If TecditNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TecditNumber" + "-"
        End If
        If ZeylCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ZeylCode" + "-"
        End If
        If ZeylNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ZeylNo" + "-"
        End If
        If PolicyType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyType" + "-"
        End If
        If PolicyOwnerCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerCountryCode" + "-"
        End If
        If PolicyOwnerIdentityCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerIdentityCode" + "-"
        End If
        If PolicyOwnerIdentityNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerIdentityNo" + "-"
        End If
        If PolicyOwnerName_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerName" + "-"
        End If
        If PolicyOwnerSurname_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerSurname" + "-"
        End If
        If PolicyOwnerBirthDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerBirthDate" + "-"
        End If
        If AddressLine1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AddressLine1" + "-"
        End If
        If AddressLine2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AddressLine2" + "-"
        End If
        If AddressLine3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AddressLine3" + "-"
        End If
        If PlateCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PlateCountryCode" + "-"
        End If
        If PlateNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PlateNumber" + "-"
        End If
        If Brand_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Brand" + "-"
        End If
        If Model_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Model" + "-"
        End If
        If ChassisNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ChassisNumber" + "-"
        End If
        If EngineNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EngineNumber" + "-"
        End If
        If EnginePower_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EnginePower" + "-"
        End If
        If ProductionYear_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductionYear" + "-"
        End If
        If Capacity_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Capacity" + "-"
        End If
        If CarType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CarType" + "-"
        End If
        If UsingStyle_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "UsingStyle" + "-"
        End If
        If TariffCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TariffCode" + "-"
        End If
        If ArrangeDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ArrangeDate" + "-"
        End If
        If StartDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "StartDate" + "-"
        End If
        If EndDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EndDate" + "-"
        End If
        If Material_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Material" + "-"
        End If
        If Corporal_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Corporal" + "-"
        End If
        If CurrencyCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CurrencyCode" + "-"
        End If
        If PublicValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PublicValue" + "-"
        End If
        If AuthorizedDrivers_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AuthorizedDrivers" + "-"
        End If
        If CountryCode1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CountryCode1" + "-"
        End If
        If IdentityCode1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode1" + "-"
        End If
        If IdentityNo1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNo1" + "-"
        End If
        If Name1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Name1" + "-"
        End If
        If Surname1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Surname1" + "-"
        End If
        If BirthDate1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BirthDate1" + "-"
        End If
        If DriverLicenceNo1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceNo1" + "-"
        End If
        If DriverLicenceGivenDate1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceGivenDate1" + "-"
        End If
        If DriverLicenceType1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceType1" + "-"
        End If
        If CountryCode2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CountryCode2" + "-"
        End If
        If IdentityCode2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode2" + "-"
        End If
        If IdentityNo2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNo2" + "-"
        End If
        If Name2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Name2" + "-"
        End If
        If Surname2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Surname2" + "-"
        End If
        If BirthDate2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BirthDate2" + "-"
        End If
        If DriverLicenceNo2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceNo2" + "-"
        End If
        If DriverLicenceGivenDate2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceGivenDate2" + "-"
        End If
        If DriverLicenceType2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceType2" + "-"
        End If
        If CountryCode3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CountryCode3" + "-"
        End If
        If IdentityCode3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode3" + "-"
        End If
        If IdentityNo3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNo3" + "-"
        End If
        If Name3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Name3" + "-"
        End If
        If Surname3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Surname3" + "-"
        End If
        If BirthDate3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BirthDate3" + "-"
        End If
        If DriverLicenceNo3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceNo3" + "-"
        End If
        If DriverLicenceGivenDate3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceGivenDate3" + "-"
        End If
        If DriverLicenceType3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceType3" + "-"
        End If
        If CountryCode4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CountryCode4" + "-"
        End If
        If IdentityCode4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode4" + "-"
        End If
        If IdentityNo4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNo4" + "-"
        End If
        If Name4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Name4" + "-"
        End If
        If Surname4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Surname4" + "-"
        End If
        If BirthDate4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BirthDate4" + "-"
        End If
        If DriverLicenceNo4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceNo4" + "-"
        End If
        If DriverLicenceGivenDate4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceGivenDate4" + "-"
        End If
        If DriverLicenceType4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceType4" + "-"
        End If
        If CountryCode5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CountryCode5" + "-"
        End If
        If IdentityCode5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode5" + "-"
        End If
        If IdentityNo5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNo5" + "-"
        End If
        If Name5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Name5" + "-"
        End If
        If Surname5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Surname5" + "-"
        End If
        If BirthDate5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BirthDate5" + "-"
        End If
        If DriverLicenceNo5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceNo5" + "-"
        End If
        If DriverLicenceGivenDate5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceGivenDate5" + "-"
        End If
        If DriverLicenceType5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceType5" + "-"
        End If
        If CountryCode6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CountryCode6" + "-"
        End If
        If IdentityCode6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode6" + "-"
        End If
        If IdentityNo6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNo6" + "-"
        End If
        If Name6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Name6" + "-"
        End If
        If Surname6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Surname6" + "-"
        End If
        If BirthDate6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BirthDate6" + "-"
        End If
        If DriverLicenceNo6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceNo6" + "-"
        End If
        If DriverLicenceGivenDate6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceGivenDate6" + "-"
        End If
        If DriverLicenceType6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverLicenceType6" + "-"
        End If
        If InsurancePremium_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InsurancePremium" + "-"
        End If
        If AssistantFees_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AssistantFees" + "-"
        End If
        If OtherFees_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OtherFees" + "-"
        End If
        If BasePriceValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BasePriceValue" + "-"
        End If
        If CCRateValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CCRateValue" + "-"
        End If
        If DamageRateValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamageRateValue" + "-"
        End If
        If AgeRateValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgeRateValue" + "-"
        End If
        If DamagelessRateValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamagelessRateValue" + "-"
        End If
        If ProductType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductType" + "-"
        End If
        If FuelType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FuelType" + "-"
        End If
        If SteeringSide_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SteeringSide" + "-"
        End If
        If AnyDriverRateValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AnyDriverRateValue" + "-"
        End If
        If PolicyPremium_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyPremium" + "-"
        End If
        If PolicyPremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyPremiumTL" + "-"
        End If
        If InsurancePremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InsurancePremiumTL" + "-"
        End If
        If PublicValueTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PublicValueTL" + "-"
        End If
        If DamageRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductType" + "-"
        End If
        If DamagelessRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamagelessRate" + "-"
        End If
        If AnyDriverRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AnyDriverRate" + "-"
        End If
        If AgeRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgeRate" + "-"
        End If
        If CCRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CCRate" + "-"
        End If
        If Creditor_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Creditor" + "-"
        End If
        If FirstBeneficiary_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FirstBeneficiary" + "-"
        End If
        If ExchangeRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ExchangeRate" + "-"
        End If
        If AgencyRegisterCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgencyRegisterCode" + "-"
        End If
        If TPNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TPNo" + "-"
        End If


        'Creditor First Beneficiary 
        If PolicyInfo.Creditor = 1 Then
            If PolicyInfo.FirstBeneficiary = "" Then
                xmlhata = "Gönderilen XML'de Creditor değeri 1 ise FirstBeneficiary boş olamaz."
            End If
        End If
        If PolicyInfo.Creditor = 0 Then
            If PolicyInfo.FirstBeneficiary <> "" Then
                xmlhata = "Gönderilen XML'de Creditor değeri 0 ise FirstBeneficiary boş olmalıdır."
            End If
        End If


        'ProductType kontrolü yap
        Try
            Dim varmi As String
            Dim producttype_erisim As New CLASSPRODUCTTYPE_ERISIM
            Dim urunkod As New CLASSURUNKOD
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
            urunkod = urunkod_erisim.bultek_kodagore(PolicyInfo.ProductCode)
            varmi = producttype_erisim.ciftkayitkontrol(urunkod.pkey, PolicyInfo.ProductType)
            If varmi = "Hayır" Then
                xmlhata = "Gönderilen XML'de ProductType KKSBM tarafından tanımlanmamış."
            End If
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de ProductType KKSBM tarafından tanımlanmamış."
        End Try

        'FuelType kontrolu
        If PolicyInfo.ArrangeDate >= "05.04.2016" Then
            If PolicyInfo.TariffCode = "P" Or PolicyInfo.TariffCode = "T" Then
                If PolicyInfo.TariffCode <> "CZ312" And PolicyInfo.TariffCode <> "CZ9" Then
                    Try
                        Dim fueltype_erisim As New CLASSFUELTYPE_ERISIM
                        Dim varmi As String = "Evet"
                        PolicyInfo.FuelType = Trim(PolicyInfo.FuelType)
                        varmi = fueltype_erisim.fueltypevarmi(PolicyInfo.FuelType)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de FuelType KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de FuelType KKSBM tarafından tanımlanmamış."
                    End Try
                End If
                If PolicyInfo.TariffCode <> "CZ312" And PolicyInfo.TariffCode <> "CZ9" Then
                    If IsNumeric(PolicyInfo.FuelType) = False Then
                        xmlhata = "CZ312 VE CZ9 dışındaki tarife kodları için gönderilen XML'de FuelType boş olamaz."
                    End If
                End If
            End If
        End If


        'steeringside kontrol 
        If PolicyInfo.ArrangeDate >= "05.04.2016" Then
            If PolicyInfo.TariffCode = "P" Or PolicyInfo.TariffCode = "T" Then
                If PolicyInfo.TariffCode <> "CZ312" And PolicyInfo.TariffCode <> "CZ9" And _
                PolicyInfo.TariffCode <> "CZ801" And PolicyInfo.TariffCode <> "CZ802" And _
                PolicyInfo.TariffCode <> "CY1" And PolicyInfo.TariffCode <> "CY70" Then
                    If PolicyInfo.SteeringSide <> "R" And PolicyInfo.SteeringSide <> "L" Then
                        xmlhata = "CZ312,CZ9,CZ801,CZ802,CY1,CY70 dışında Gönderilen XML'de" + _
                        " SteeringSide L yada R olmalıdır. Boş olmamalıdır."
                    End If
                End If
            End If
        End If

        'PolicyPremium 0 dan büyük olamaz P ve T olan poliçeler için
        If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
            If PolicyInfo.PolicyPremium <= 0 Then
                xmlhata = "PolicyPremium'dan 0 dan büyük olmalıdır. 0 primli bir poliçe kesemezsiniz."
            End If
        End If

        'InsurancePremium PolicyPremium kontrolu
        If PolicyInfo.InsurancePremium > PolicyInfo.PolicyPremium Then
            xmlhata = "InsurancePremium PolicyPremium'dan büyük olamaz."
        End If


        'InsurancePremiumtl PolicyPremiumtl kontrolu
        If PolicyInfo.InsurancePremiumTL > PolicyInfo.PolicyPremiumTL Then
            xmlhata = "InsurancePremiumTL PolicyPremiumTL'den büyük olamaz."
        End If

        'model and brand kontrolü
        If PolicyInfo.ArrangeDate >= "06.29.2016" Then

            'CZ312,CZ9 VE CZ801 için kontrol yapma
            If PolicyInfo.TariffCode <> "CZ312" And PolicyInfo.TariffCode <> "CZ9" And PolicyInfo.TariffCode <> "CZ801" Then
                If PolicyInfo.Brand = "" Then
                    xmlhata = "Gönderilen XML'de Brand boş olmamalıdır."
                End If
                If PolicyInfo.ZeylCode <> "X" Then
                    If PolicyInfo.Model = "" Then
                        xmlhata = "Gönderilen XML'de Model boş olmamalıdır."
                    End If
                End If
            End If

            'CZ801 için sadece brand kontrolü olacak.
            If PolicyInfo.TariffCode = "CZ801" Then
                If PolicyInfo.Brand = "" Then
                    xmlhata = "Gönderilen XML'de Brand boş olmamalıdır. CZ801 için."
                End If
            End If

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
        If girdisayisi <> 117 Then
            root.ResultCode = 0
            ErrorInfo.Code = 99
            ErrorInfo.Message = "Gönderdiğiniz XML'de bazı alanlar eksik yada fazladır." + _
            "Toplam xml node sayısı 117 olması gerekirken siz " + CStr(girdisayisi) + " alan gönderdiniz. " + _
            girilmeyenstr
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'boş olmaması gerekenleri kontrol et
        If PolicyInfo.FirmCode = Nothing Or PolicyInfo.ProductCode = Nothing Or _
        PolicyInfo.AgencyCode = Nothing Or PolicyInfo.PolicyNumber = Nothing Or _
        PolicyInfo.TecditNumber = Nothing Or PolicyInfo.ZeylCode = Nothing Or _
        PolicyInfo.ZeylNo = Nothing Or PolicyInfo.ProductType = Nothing Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = "Gönderdiğiniz XML'de FirmCode, ProductCode, ProductType, AgencyCode, PolicyNumber, " + _
            "TecditNumber, ZeylCode, ZeylNo boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'SORU İŞARETİ KONTROL
        If InStr(policexml, "?", CompareMethod.Text) > 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 333
            ErrorInfo.Message = "Gönderdiğiniz XML'in hiçbir yerinde ? (soru işareti) karakteri olmamalıdır."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'TARİHLERİ KONTROL ET ----------------------------------
        Dim fark_startend As Integer
        Dim StartDate, EndDate, ArrangeDate As DateTime
        StartDate = PolicyInfo.StartDate
        EndDate = PolicyInfo.EndDate
        ArrangeDate = PolicyInfo.ArrangeDate
        fark_startend = EndDate.Subtract(StartDate).Days
        If fark_startend < 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = "Poliçenin başlangıç tarihi poliçenin bitiş tarihinden büyük olmamalıdır."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'SERVİS AYAR AÇIKSA
        If servisayar.duzenlemebitiskontrol = "Evet" Then
            If PolicyInfo.ArrangeDate > PolicyInfo.EndDate Then
                root.ResultCode = 0
                ErrorInfo.Code = 997
                ErrorInfo.Message = "Poliçenin düzenleme tarihi poliçenin bitiş tarihinden büyük olmamalıdır."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        '------------------------------------------------------


        'veri mantıksal kontrol yap 
        'mantıksal kontrolleri yap 
        If PolicyInfo.PolicyOwnerIdentityCode = "KN" Or PolicyInfo.PolicyOwnerIdentityCode = "PN" Then
            If PolicyInfo.PolicyOwnerBirthDate Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 997
                ErrorInfo.Message = "Poliçe sahibinin doğum tarihi (PolicyOwnerBirthDate) geçerli bir tarih değildir."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        '2011 Yılından Önceki poliçeleri sıfırla ----------------
        If PolicyInfo.StartDate < "01.01.2011" Then
            PolicyInfo.PolicyOwnerIdentityCode = ""
            PolicyInfo.PolicyOwnerCountryCode = ""
            PolicyInfo.PlateCountryCode = ""
            PolicyInfo.IdentityCode1 = ""
            PolicyInfo.CountryCode1 = ""
        End If


        If PolicyInfo.ArrangeDate > "05.04.2016" Then
            If PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2 Then
                'AgencyRegisterCode kontrolü
                Try
                    Dim varmi As String = "Evet"
                    varmi = acente_erisim.ciftkayitkontrol("sicilno", PolicyInfo.AgencyRegisterCode)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 501
                        ErrorInfo.Message = "Gönderilen XML de AgencyRegisterCode tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 501
                    ErrorInfo.Message = "Gönderilen XML de AgencyRegisterCode tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try

                If PolicyInfo.AgencyRegisterCode = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 501
                    ErrorInfo.Message = "Gönderilen XML de AgencyRegisterCode boş olamaz."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                Try
                    acente = acente_erisim.bulsicilnogore(PolicyInfo.AgencyRegisterCode)
                    If acente.aktifmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 501
                        ErrorInfo.Message = acente.acentead + " aktif değildir."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                End Try


                'ACENTE O ŞİRKETİN Mİ
                sirket = sirket_erisim.bultek_sirketkodagore(PolicyInfo.FirmCode)
                Dim gonderdigisirketinacentesimi As String
                gonderdigisirketinacentesimi = "Hayır"
                Dim sirketacentebaglar As New List(Of CLASSSIRKETACENTEBAG)
                Dim sirketacentebag As New CLASSSIRKETACENTEBAG
                Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
                sirketacentebaglar = sirketacentebag_erisim.doldur_sirketinacenteleri(sirket.pkey)
                For Each item As CLASSSIRKETACENTEBAG In sirketacentebaglar
                    If item.acentepkey = acente.pkey And item.sirketpkey = sirket.pkey Then
                        gonderdigisirketinacentesimi = "Evet"
                        Exit For
                    End If
                Next
                If gonderdigisirketinacentesimi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 502
                    ErrorInfo.Message = "'" + acente.acentead + "' adlı acente " + sirket.sirketad + " isimli " + _
                    "şirketin acentesi değildir."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

            End If 'PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2

            'TPNo kontrol
            'TPNO'yu boş göndermiş.
            If PolicyInfo.TPNo = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 503
                ErrorInfo.Message = "Gönderilen XML de TPNo boş olamaz."
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            Try
                personel = personel_erisim.bul_tpnogore(PolicyInfo.TPNo, "Evet")
                If personel.pkey = 0 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 503
                    ErrorInfo.Message = "Gönderdiğiniz TPNo teknik personel değildir."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 503
                ErrorInfo.Message = "Gönderdiğiniz TPNo teknik personel değildir."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try

        End If ' "05.04.2016"


        'PLAKA KONTROL ---------------------------------------------------------------
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim
        Dim plakaresult As New CLADBOPRESULT
        plakaresult = plakakontrol_erisim.plakakontrolbasit(PolicyInfo.TariffCode, PolicyInfo.PlateNumber)
        If plakaresult.durum = "Hata Var" Then
            root.ResultCode = 0
            ErrorInfo.Code = 500
            ErrorInfo.Message = plakaresult.hatastr
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'PLAKA KONTROL SERVİS AYARINDAKİ
        If servisayar.plakasinirkapikontrol = "Evet" Then
            If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                If PolicyInfo.TariffCode <> "CZ801" Or PolicyInfo.TariffCode <> "CZ9" Then
                    plakaresult = plakakontrol_erisim.plakakontrol_servisayar(PolicyInfo.PolicyType, PolicyInfo.PlateNumber)
                    If plakaresult.durum = "Hata Var" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 494
                        ErrorInfo.Message = plakaresult.hatastr
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
        End If

        'PLAKA KONTROL BAŞI T
        If servisayar.plakaticariarackontrol = "Evet" Then
            If PolicyInfo.PlateCountryCode = "600" Or PolicyInfo.PlateCountryCode = "601" Then
                If PolicyInfo.StartDate > "05.04.2017" Then
                    If Len(PolicyInfo.PlateNumber) >= 2 Then
                        If Mid(PolicyInfo.PlateNumber, 1, 2) <> "TR" Then
                            If Mid(PolicyInfo.PlateNumber, 1, 1) = "T" Then
                                If PolicyInfo.TariffCode <> "CZ400" And PolicyInfo.TariffCode <> "CZ600" _
                                And PolicyInfo.TariffCode <> "CZ605" And PolicyInfo.TariffCode <> "CZ300" _
                                And PolicyInfo.TariffCode <> "CZ301" And PolicyInfo.TariffCode <> "CZ312" Then
                                    root.ResultCode = 0
                                    ErrorInfo.Code = 495
                                    ErrorInfo.Message = "Bu plaka için tarife kodu sadece CZ400,CZ600,CZ605,CZ300,CZ301,CZ312 olabilir."
                                    root.ErrorInfo = ErrorInfo
                                    Return root
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If


        'PLAKA KONTROL BAŞI VEYA SONU Z İSE 
        If servisayar.plakakiralikarackontrol = "Evet" Then
            If PolicyInfo.PlateCountryCode = "600" Or PolicyInfo.PlateCountryCode = "601" Then
                If PolicyInfo.StartDate > "05.04.2017" Then
                    If Len(PolicyInfo.PlateNumber) >= 2 Then
                        If Mid(PolicyInfo.PlateNumber, 1, 2) <> "ZZ" Then
                            If Mid(PolicyInfo.PlateNumber, 1, 1) = "Z" Or Mid(PolicyInfo.PlateNumber, Len(PolicyInfo.PlateNumber), 1) = "Z" Then
                                If PolicyInfo.TariffCode <> "CZ406" And PolicyInfo.TariffCode <> "CY70" And PolicyInfo.TariffCode <> "CZ600" Then
                                    root.ResultCode = 0
                                    ErrorInfo.Code = 496
                                    ErrorInfo.Message = "Bu plaka için tarife kodu sadece CZ406, CY70, CZ600 olabilir."
                                    root.ErrorInfo = ErrorInfo
                                    Return root
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If



        'DİĞER PLAKA KONTROLÜ
        If PolicyInfo.StartDate > "02.16.2017" Then
            If PolicyInfo.PolicyType = 1 Then
                If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                    If PolicyInfo.PlateCountryCode <> "601" And PolicyInfo.PlateCountryCode <> "600" Then
                        plakaresult = plakakontrol_erisim.plakakontroldiger(PolicyInfo.PlateNumber, PolicyInfo)
                        If plakaresult.durum = "Hata Var" Then
                            'root.ResultCode = 0
                            'ErrorInfo.Code = 497
                            'ErrorInfo.Message = plakaresult.hatastr
                            'root.ErrorInfo = ErrorInfo
                            'Return root
                        End If
                    End If
                End If
            End If
        End If

        'KKTC PLAKALARI KONTROL
        If servisayar.plakakktckontrol = "Evet" Then
            If PolicyInfo.PlateCountryCode = "601" Then
                plakaresult = plakakontrol_erisim.plakakontrolkktcplaka(PolicyInfo.PlateNumber, PolicyInfo)
                If plakaresult.durum = "Hata Var" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 499
                    ErrorInfo.Message = plakaresult.hatastr
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
        End If

        'RUM PLAKALAR KONTROL
        If servisayar.plakarumkontrol = "Evet" Then
            If PolicyInfo.PlateCountryCode = "600" Then
                plakaresult = plakakontrol_erisim.plakakontrolrumplaka(PolicyInfo.PlateNumber, PolicyInfo)
                If plakaresult.durum = "Hata Var" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 498
                    ErrorInfo.Message = plakaresult.hatastr
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
        End If
        '------------------------------------------------------------------------

        'PlateCountryCode 600 kontrolü
        If PolicyInfo.StartDate > "01.22.2017" Then
            If PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2 Then
                If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                    If PolicyInfo.PlateCountryCode = "600" Then
                        'admin bu plakalara yetki vermiş mi?
                        Dim plaka_kacadet As Integer
                        plaka_kacadet = plakasinirkapi_erisim.kacadet(PolicyInfo.PlateNumber)
                        If plaka_kacadet <= 0 Then
                            'root.ResultCode = 0
                            'ErrorInfo.Code = 420
                            'ErrorInfo.Message = "Normal ve İhale tipi poliçelerde zeyil kodu P veya T ise PlateCountryCode 600 olmamalıdır. Tanımlı plaka değil."
                            'root.ErrorInfo = ErrorInfo
                            'Return root
                        End If
                    End If
                End If
            End If
        End If

        Dim kombinasyonroot As New root
        kombinasyonroot = policyinfoservicekontrol_erisim.kombinasyonkontrol(PolicyInfo)
        If kombinasyonroot.ResultCode = 0 Then
            root.ResultCode = kombinasyonroot.ResultCode
            root.ErrorInfo = kombinasyonroot.ErrorInfo
            Return root
        End If

        'PolicyOwnerName veya Surname kontrolü
        If PolicyInfo.PolicyOwnerIdentityCode = "KN" Or PolicyInfo.PolicyOwnerIdentityCode = "PN" Then
            If PolicyInfo.PolicyOwnerName = "" Or PolicyInfo.PolicyOwnerSurname = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 430
                ErrorInfo.Message = "Kimlik türü KN yada PN olan poliçelerde " + _
                "PolicyOwnerName yada PolicyOwnerSurname boş olamaz."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        'name driver gelen poliçelerde en az identityno1 gelmek zorunda
        If PolicyInfo.AuthorizedDrivers = "N" Then
            If PolicyInfo.PolicyOwnerIdentityCode = "KN" Or PolicyInfo.PolicyOwnerIdentityCode = "PN" Then
                If PolicyInfo.Name1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 431
                    ErrorInfo.Message = "NameDriver olarak düzenlenen poliçelerde Name1 boş olamaz."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
        End If


        If PolicyInfo.ArrangeDate > "01.03.2014" Then

            'MŞ YŞ UŞ KONTROLÜ ----------------------
            If PolicyInfo.PolicyOwnerCountryCode = "601" Then
                If PolicyInfo.PolicyOwnerIdentityCode = "MŞ" Or PolicyInfo.PolicyOwnerIdentityCode = "YŞ" _
                Or PolicyInfo.PolicyOwnerIdentityCode = "UŞ" Then
                    If Len(PolicyInfo.PolicyOwnerIdentityNo) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. PolicyOwnerIdentityNo"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.CountryCode1 = "601" Then
                If PolicyInfo.IdentityCode1 = "MŞ" Or PolicyInfo.IdentityCode1 = "YŞ" _
                Or PolicyInfo.IdentityCode1 = "UŞ" Then
                    If Len(PolicyInfo.IdentityNo1) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. IdentityNo1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.CountryCode2 = "601" Then
                If PolicyInfo.IdentityCode2 = "MŞ" Or PolicyInfo.IdentityCode2 = "YŞ" _
                Or PolicyInfo.IdentityCode2 = "UŞ" Then
                    If Len(PolicyInfo.IdentityNo2) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. IdentityNo2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.CountryCode3 = "601" Then
                If PolicyInfo.IdentityCode3 = "MŞ" Or PolicyInfo.IdentityCode3 = "YŞ" _
                Or PolicyInfo.IdentityCode3 = "UŞ" Then
                    If Len(PolicyInfo.IdentityNo3) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. IdentityNo3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.CountryCode4 = "601" Then
                If PolicyInfo.IdentityCode4 = "MŞ" Or PolicyInfo.IdentityCode4 = "YŞ" _
                Or PolicyInfo.IdentityCode4 = "UŞ" Then
                    If Len(PolicyInfo.IdentityNo4) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. IdentityNo4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.CountryCode5 = "601" Then
                If PolicyInfo.IdentityCode5 = "MŞ" Or PolicyInfo.IdentityCode5 = "YŞ" _
                Or PolicyInfo.IdentityCode5 = "UŞ" Then
                    If Len(PolicyInfo.IdentityNo5) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. IdentityNo5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.CountryCode6 = "601" Then
                If PolicyInfo.IdentityCode6 = "MŞ" Or PolicyInfo.IdentityCode6 = "YŞ" _
                Or PolicyInfo.IdentityCode6 = "UŞ" Then
                    If Len(PolicyInfo.IdentityNo6) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. IdentityNo6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If


            'PolicyOwner
            If PolicyInfo.PolicyOwnerCountryCode = "601" And PolicyInfo.PolicyOwnerIdentityCode = "KN" Then
                If Trim(Len(PolicyInfo.PolicyOwnerIdentityNo)) <> 6 And Trim(Len(PolicyInfo.PolicyOwnerIdentityNo)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. PolicyOwnerIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.PolicyOwnerCountryCode = "52" And PolicyInfo.PolicyOwnerIdentityCode = "KN" Then
                If Trim(Len(PolicyInfo.PolicyOwnerIdentityNo)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. PolicyOwnerIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

            'IdentityNo1
            If PolicyInfo.CountryCode1 = "601" And PolicyInfo.IdentityCode1 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo1)) <> 6 And Trim(Len(PolicyInfo.IdentityNo1)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. IdentityNo1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.CountryCode1 = "52" And PolicyInfo.IdentityCode1 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo1)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. IdentityNo1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'IdentityNo2
            If PolicyInfo.CountryCode2 = "601" And PolicyInfo.IdentityCode2 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo2)) <> 6 And Trim(Len(PolicyInfo.IdentityNo2)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. IdentityNo2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.CountryCode2 = "52" And PolicyInfo.IdentityCode2 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo2)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. IdentityNo2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'IdentityNo3
            If PolicyInfo.CountryCode3 = "601" And PolicyInfo.IdentityCode3 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo3)) <> 6 And Trim(Len(PolicyInfo.IdentityNo3)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. IdentityNo3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.CountryCode3 = "52" And PolicyInfo.IdentityCode3 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo3)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. IdentityNo3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'IdentityNo4
            If PolicyInfo.CountryCode4 = "601" And PolicyInfo.IdentityCode4 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo4)) <> 6 And Trim(Len(PolicyInfo.IdentityNo4)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. IdentityNo4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.CountryCode4 = "52" And PolicyInfo.IdentityCode4 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo4)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. IdentityNo4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'IdentityNo5
            If PolicyInfo.CountryCode5 = "601" And PolicyInfo.IdentityCode5 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo5)) <> 6 And Trim(Len(PolicyInfo.IdentityNo5)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. IdentityNo5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.CountryCode5 = "52" And PolicyInfo.IdentityCode5 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo5)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. IdentityNo5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'IdentityNo6
            If PolicyInfo.CountryCode6 = "601" And PolicyInfo.IdentityCode6 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo6)) <> 6 And Trim(Len(PolicyInfo.IdentityNo6)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. IdentityNo6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.CountryCode6 = "52" And PolicyInfo.IdentityCode6 = "KN" Then
                If Trim(Len(PolicyInfo.IdentityNo6)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. IdentityNo6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
        End If


        'EXCHANGERATE KONTROLLERİ VE HESAPLAMALARI
        Dim insurancepremium_a As Decimal
        Dim policypremium_a As Decimal
        Dim publicvalue_a As Decimal
        Dim insurancepremium_down, insurancepremium_up As Decimal
        Dim policypremium_down, policypremium_up As Decimal
        Dim publicvalue_down, publicvalue_up As Decimal

        If PolicyInfo.CurrencyCode = "TL" Then
            If PolicyInfo.ExchangeRate <> 1 Then
                root.ResultCode = 0
                ErrorInfo.Code = 200
                ErrorInfo.Message = "Para birimi TL olan poliçelerde ExchangeRate 1 olmalıdır."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        insurancepremium_a = Math.Round(PolicyInfo.InsurancePremium * PolicyInfo.ExchangeRate, 2)
        insurancepremium_up = insurancepremium_a + 0.25
        insurancepremium_down = insurancepremium_a - 0.25
        If PolicyInfo.InsurancePremiumTL > insurancepremium_up Or PolicyInfo.InsurancePremiumTL < insurancepremium_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "InsurancePremiumTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(insurancepremium_a, "0.00") + " veya " + _
            Format(insurancepremium_down, "0.00") + " ve " + Format(insurancepremium_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        policypremium_a = Math.Round(PolicyInfo.PolicyPremium * PolicyInfo.ExchangeRate, 2)
        policypremium_up = policypremium_a + 0.25
        policypremium_down = policypremium_a - 0.25
        If PolicyInfo.PolicyPremiumTL > policypremium_up Or PolicyInfo.PolicyPremiumTL < policypremium_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "PolicyPremiumTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(policypremium_a, "0.00") + " veya " + _
            Format(policypremium_down, "0.00") + " ve " + Format(policypremium_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        publicvalue_a = Math.Round(PolicyInfo.PublicValue * PolicyInfo.ExchangeRate, 2)
        publicvalue_up = publicvalue_a + 0.25
        publicvalue_down = publicvalue_a - 0.25
        If PolicyInfo.PublicValueTL > publicvalue_up Or PolicyInfo.PublicValueTL < publicvalue_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "PublicValueTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(publicvalue_a, "0.00") + " veya " + _
            Format(publicvalue_down, "0.00") + " ve " + Format(publicvalue_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        Dim arackayitlog As String = ""

        'CARTYPE KONTROLE GİRİP GİRMEYECEĞİNİ TESPİT ET ----------------------------------------
        Dim cartypekontrolune_girilecekmi As String = "Evet"
        Dim sonpyadatzeyili As New PolicyInfo
        If PolicyInfo.ZeylCode <> "P" And PolicyInfo.ZeylCode <> "T" Then
            sonpyadatzeyili = PolicyInfo2_erisim.sonpyadatzeyilibul(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
            PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.ProductType)
            'ZEYİLİ VAR
            If sonpyadatzeyili.FirmCode <> "" Then
                'VE ZEYİL ESKİ BİR ZEYİL
                If sonpyadatzeyili.ArrangeDate < "05.04.2016" Then '4 Mayıs 2016
                    cartypekontrolune_girilecekmi = "Hayır"
                End If
            End If
            'ZEYİLİ YOK SADECE KENDİSİ
            If sonpyadatzeyili.FirmCode Is Nothing Then
                cartypekontrolune_girilecekmi = "Hayır"
            End If

            'YENİ EKLENEN 4 Ekim 2017
            If PolicyInfo.TariffCode = "CZ301" And PolicyInfo.CarType = "Birleştirilen Araç" Then
                cartypekontrolune_girilecekmi = "Hayır"
            End If

        End If

        If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
            If PolicyInfo.ArrangeDate > "05.04.2016" Then
                cartypekontrolune_girilecekmi = "Evet"
            End If
        End If

        If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
            If PolicyInfo.ArrangeDate < "05.04.2016" Then
                cartypekontrolune_girilecekmi = "Hayır"
            End If

     

        End If



        If cartypekontrolune_girilecekmi = "Evet" Then

            If PolicyInfo.CarType = "" Or PolicyInfo.CarType Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 444
                ErrorInfo.Message = "Gönderilen XML'de CarType boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            'CARTYPE CONTROL ------------------------------------------------------------
            If PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2 Then
                If PolicyInfo.CarType <> "" Then
                    If dairearactip_erisim.ciftkayitkontrol(PolicyInfo.CarType) = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 444
                        ErrorInfo.Message = "Gönderilen XML'de CarType SBM tarafından tanımlanmamış. (Normal ve İhale Tipi)"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If PolicyInfo.PolicyType = 3 Then
                If PolicyInfo.CarType <> "" Then
                    Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM
                    If PolicyInfo.ArrangeDate > "01.01.2017" Then
                        If sinirkapiaractip_erisim.ciftkayitkontrol(PolicyInfo.CarType) = "Hayır" Then
                            root.ResultCode = 0
                            ErrorInfo.Code = 444
                            ErrorInfo.Message = "Gönderilen XML'de CarType SBM tarafından tanımlanmamış. (Sınır Kapısı)"
                            root.ErrorInfo = ErrorInfo
                            Return root
                        End If
                    End If
                End If
            End If
            '------------------------------------------------------

            'GÖNDERİLEN TARIFF CODE İLE CARTYPE BİRBİRİ İLE EŞLEŞİYOR MU NORMAL VE İHALE TİPİ POLİÇELERDE?
            If PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2 Then
                Dim dairearactip As New CLASSDAIREARACTIP
                Dim tarifedairebag_erisim As New CLASSTARIFEDAIREBAG_ERISIM
                aractarife = aractarife_erisim.bultarifekodagore(PolicyInfo.TariffCode)
                dairearactip = dairearactip_erisim.bultek_adagore(PolicyInfo.CarType)
                If tarifedairebag_erisim.ciftkayitkontrol(aractarife.pkey, dairearactip.pkey) = "Hayır" Then
                    Dim gonderebilecegi As String
                    gonderebilecegi = tarifedairebag_erisim.gonderebilecegi_cartype(aractarife.pkey)
                    root.ResultCode = 0
                    ErrorInfo.Code = 444
                    ErrorInfo.Message = "Gönderdiğiniz tarife kodu ile CarType eşleştirilmemiş. (Normal, İhale). " + _
                    aractarife.tarifekod + " (" + aractarife.tarifead + ") için gönderebileceğiniz CarType lar: " + _
                    gonderebilecegi + " dir."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            '------------------------------------------------------------------------------------


            'SINIR KAPISI-----------------------------------------------------------------------------
            'GÖNDERİLEN TARIFF CODE İLE CARTYPE BİRBİRİ İLE EŞLEŞİYOR MU SINIR KAPISI İÇİN?
            If PolicyInfo.PolicyType = 3 Then
                Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
                Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM
                Dim tarifesinirkapibag_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM
                aractarife = aractarife_erisim.bultarifekodagore(PolicyInfo.TariffCode)
                sinirkapiaractip = sinirkapiaractip_erisim.bultek_adagore(PolicyInfo.CarType)
                If PolicyInfo.ArrangeDate > "01.01.2017" Then
                    If tarifesinirkapibag_erisim.ciftkayitkontrol(aractarife.pkey, sinirkapiaractip.pkey) = "Hayır" Then
                        Dim gonderebilecegi As String
                        gonderebilecegi = tarifesinirkapibag_erisim.gonderebilecegi_cartype(aractarife.pkey)
                        root.ResultCode = 0
                        ErrorInfo.Code = 444
                        ErrorInfo.Message = "Gönderdiğiniz tarife kodu ile CarType eşleştirilmemiş. (Sınır Kapısı)." + _
                        aractarife.tarifekod + " (" + aractarife.tarifead + ") için gönderebileceğiniz CarType lar: " + _
                        gonderebilecegi + " dir."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
                Dim sinirkapiyetkiresult As New CLADBOPRESULT
                'TOPLU SINIR KAPISI KONTROLLERİ
                sinirkapiyetkiresult = policyinfoservicehelper_erisim.sinirkapitoplukontrolyetkilimi(PolicyInfo, servisayar)
                If sinirkapiyetkiresult.durum = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = sinirkapiyetkiresult.etkilenen
                    ErrorInfo.Message = sinirkapiyetkiresult.hatastr
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
                'SINIR KAPISI İÇİN YETKİLİ İSE 
                If sinirkapiyetkiresult.durum = "Evet" Then
                    PolicyInfo.BorderCode = sinirkapi_erisim.bordercodebul(PolicyInfo.AgencyRegisterCode)
                End If
            End If 'PolicyInfo.PolicyType = 3


            'ARAÇ KAYIT DAİRESİ KONTROL ---------------------------------------------------------
            If PolicyInfo.PlateCountryCode = "601" Then
                arackayitlog = arackayitlog + " Ülke kodu 601 olduğundan Araç Kayıt Dairesine bağlanıyorum. --"
                Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
                Dim arackayitbilgi As New CLASSARACKAYITDAIRE
                arackayitbilgi = arackayitdaire_erisim.sorgula_plakayagore_servisicin(PolicyInfo.PlateNumber)
                'eğer doğru çalışmadı ise
                If arackayitbilgi.KatKod = 0 Then
                    arackayitlog = arackayitlog + "Araç Kayıt Dairesi Çalışmadı. Gönderilen Plaka:" + arackayitbilgi.Model + "--" + _
                    "Gelen Cevap:" + arackayitbilgi.PlakaNo + "--"
                End If
                'eğer doğru çalıştı ise
                If arackayitbilgi.KatKod <> 0 Then
                    arackayitlog = arackayitlog + "Araç Kayıt Dairesinden dönen CC Rate:" + CStr(arackayitbilgi.MotorGuc) + "--"
                    arackayitlog = arackayitlog + "Araç Kayıt Dairesi Gönderilen Plaka:" + CStr(arackayitbilgi.PlakaNo) + "--"
                    If PolicyInfo.EnginePower <> arackayitbilgi.MotorGuc Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "Gönderdiğiniz CC değeri ile Araç Kayıt Dairesinde kayıtlı CC birbirini tutmuyor. " + _
                        "Araç Kayıt:" + CStr(arackayitbilgi.MotorGuc) + "CC -- Sizin Gönderdiğiniz:" + CStr(PolicyInfo.EnginePower) + "CC"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                    'CC RATE İ HESAPLA VE KONTROL ET DOĞRU CCRate GÖNDERMİŞ Mİ?
                    If cartypekontrolune_girilecekmi = "Evet" Then
                        Dim hesaplananccrate As Integer
                        hesaplananccrate = calculations2_erisim.tuzukccoranbul(PolicyInfo.TariffCode, PolicyInfo.CarType, arackayitbilgi.MotorGuc)
                        If PolicyInfo.PolicyType = 1 Then
                            If hesaplananccrate <> PolicyInfo.CCRate Then
                                root.ResultCode = 0
                                ErrorInfo.Code = 456
                                ErrorInfo.Message = "CCRate değeri hesaplanan CCRate değeri ile uyuşmadı. Hesaplanan: %" + CStr(hesaplananccrate) + "."
                                root.ErrorInfo = ErrorInfo
                                Return root
                            End If 'hesaplananccrate <> PolicyInfo.CCRate
                        End If 'cartypekontrolune_girilecekmi = "Evet"
                    End If
                End If 'arackayitbilgi.KatKod <> 0
            End If 'ülke kodu 601
            '---------------------------------------------------------------------------------------
        End If 'cartypekontrolune_girilecekmi ="Evet"


        'İHALE TİPİ POLİÇELERDE İHALE KURUM KONTROL
        If PolicyInfo.PolicyType = 2 Then
            Dim ihalekurum_erisim As New CLASSIHALEKURUM_ERISIM
            Dim ihalekurumresult As New CLADBOPRESULT
            ihalekurumresult = ihalekurum_erisim.kurumkontrol(PolicyInfo)
            If ihalekurumresult.durum = "Evet" Then
                root.ResultCode = 0
                ErrorInfo.Code = ihalekurumresult.etkilenen
                ErrorInfo.Message = ihalekurumresult.hatastr
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        'SON ZEYİLİ BULUYUROZ
        Dim sonzeyil As New PolicyInfo
        sonzeyil = PolicyInfo2_erisim.sonzeyilbul(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
        PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, _
        PolicyInfo.ZeylCode, PolicyInfo.ZeylNo, PolicyInfo.ProductType)

        'ŞİMDİKİ GELEN ZEYİL R İSE SON ZEYİL'E BAKIP DEĞİŞMESİ GEREKEN DEĞERLERİ KONTROL ET
        If servisayar.rzeyilkontrol = "Evet" Then

            If PolicyInfo.ZeylCode = "R" Or PolicyInfo.ZeylCode = "r" Then

                sonzeyil = PolicyInfo2_erisim.sonzeyilbul(PolicyInfo.FirmCode, PolicyInfo.ProductCode, PolicyInfo.AgencyCode, _
                PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ZeylCode, PolicyInfo.ZeylCode, _
                PolicyInfo.ProductType)

                If (PolicyInfo.PolicyOwnerIdentityCode = sonzeyil.PolicyOwnerIdentityNo And PolicyInfo.PlateNumber = sonzeyil.PlateNumber) And _
                (PolicyInfo.OtherFees = sonzeyil.OtherFees) Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 555
                    ErrorInfo.Message = "Gönderdiğiniz zeyilde PolicyOwnerIdentityNo yada plakayı değiştirmelisiniz." + _
                    "Yada otherfees değeri son gönderdiğiniz zeyilden farklı olmalı."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

            End If
        End If




        'PUBLICVALUE ve PUBLICVALUETL KONTROLÜ---------------------------
        Dim arakontrolagirecekmi_publicvalue As String = "Hayır"
        'R V X Y PublicValue 0 dan büyük göndermesine engel oluyoruz
        If PolicyInfo.ZeylCode = "R" Or PolicyInfo.ZeylCode = "V" Or PolicyInfo.ZeylCode = "X" Or PolicyInfo.ZeylCode = "Y" Then
            'son zeyil var
            If sonzeyil.FirmCode <> "" Then
                If sonzeyil.StartDate > "01.22.2017" Then
                    arakontrolagirecekmi_publicvalue = "Evet"
                End If
            End If
        End If
        If PolicyInfo.StartDate > "01.22.2017" Then
            If PolicyInfo.ProductCode = "15" Then
                If PolicyInfo.PublicValue > 0 Or PolicyInfo.PublicValueTL > 0 Then
                    If (PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T") Or arakontrolagirecekmi_publicvalue = "Evet" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 997
                        ErrorInfo.Message = "Trafik poliçelerinde PublicValue ve PublicValueTL 0 dan büyük olamaz."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
        End If
        '----------------------------------------------------------------------------------



        'NAME1, NAME2, NAME3 NAME 4 KONTROL ----------------------------------------------
        Dim arakontrolagirecekmi_rvy As String = "Hayır"
        'R V X Y için name2,name3 ... göndermesine engel oluyoruz.
        If PolicyInfo.ZeylCode = "R" Or PolicyInfo.ZeylCode = "V" Or PolicyInfo.ZeylCode = "Y" Then
            'son zeyil var
            If sonzeyil.FirmCode <> "" Then
                If sonzeyil.StartDate > "01.22.2017" Then
                    arakontrolagirecekmi_rvy = "Evet"
                End If
            End If
        End If



        'Name 2,3,4,5,6 kontrolü
        If servisayar.eksurucukontrol = "Evet" Then
            If PolicyInfo.ArrangeDate > "01.22.2017" Then
                If PolicyInfo.TariffCode <> "CZ9" And PolicyInfo.TariffCode <> "CZ400" And _
                PolicyInfo.TariffCode <> "CZ600" And PolicyInfo.TariffCode <> "CZ605" Then
                    If PolicyInfo.PolicyType = 1 Then
                        If PolicyInfo.AuthorizedDrivers = "N" Then
                            If (PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T") Or arakontrolagirecekmi_rvy = "Evet" Then
                                'name2 kontrolüne girecekmi ------------------------------
                                Dim name2kontrolünegirecekmi As String = "Evet"
                                If PolicyInfo.PolicyOwnerName = PolicyInfo.Name1 And _
                                PolicyInfo.PolicyOwnerSurname = PolicyInfo.Surname1 And _
                                PolicyInfo.PolicyOwnerIdentityNo = PolicyInfo.IdentityNo1 Then
                                    name2kontrolünegirecekmi = "Hayır"
                                End If
                                If name2kontrolünegirecekmi = "Evet" Then
                                    If PolicyInfo.Name2 <> "" Or PolicyInfo.Surname2 <> "" Then
                                        root.ResultCode = 0
                                        ErrorInfo.Code = 421
                                        ErrorInfo.Message = "İsme göre düzenlenen poliçelerde sigortalıya ilaveten en fazla 1 sürücü eklenilebilir. Name2 veya Surname2 boş olmalıdır."
                                        root.ErrorInfo = ErrorInfo
                                        Return root
                                    End If
                                End If
                                If PolicyInfo.Name3 <> "" Or PolicyInfo.Surname3 <> "" Then
                                    root.ResultCode = 0
                                    ErrorInfo.Code = 422
                                    ErrorInfo.Message = "İsme göre düzenlenen poliçelerde sigortalıya ilaveten en fazla 1 sürücü eklenilebilir. Name3 veya Surname3 boş olmalıdır."
                                    root.ErrorInfo = ErrorInfo
                                    Return root
                                End If
                                If PolicyInfo.Name4 <> "" Or PolicyInfo.Surname4 <> "" Then
                                    root.ResultCode = 0
                                    ErrorInfo.Code = 423
                                    ErrorInfo.Message = "İsme göre düzenlenen poliçelerde sigortalıya ilaveten en fazla 1 sürücü eklenilebilir. Name4 veya Surname4 boş olmalıdır."
                                    root.ErrorInfo = ErrorInfo
                                    Return root
                                End If
                                If PolicyInfo.Name5 <> "" Or PolicyInfo.Surname5 <> "" Then
                                    root.ResultCode = 0
                                    ErrorInfo.Code = 424
                                    ErrorInfo.Message = "İsme göre düzenlenen poliçelerde sigortalıya ilaveten en fazla 1 sürücü eklenilebilir. Name5 veya Surname5 boş olmalıdır."
                                    root.ErrorInfo = ErrorInfo
                                    Return root
                                End If
                                If PolicyInfo.Name6 <> "" Or PolicyInfo.Surname6 <> "" Then
                                    root.ResultCode = 0
                                    ErrorInfo.Code = 425
                                    ErrorInfo.Message = "İsme göre düzenlenen poliçelerde sigortalıya ilaveten en fazla 1 sürücü eklenilebilir. Name6 veya Surname6 boş olmalıdır."
                                    root.ErrorInfo = ErrorInfo
                                    Return root
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If 'servis ayar
        '--------------------------------------------------------

        'MANTIKSAL KONTROL ZEYİL SIRA KONTROL -----------------------
        Dim iptalsayisi As Integer = 0
        Dim ysayisi As Integer = 0
        Dim psayisi As Integer = 0
        Dim tsayisi As Integer = 0
        Dim varmi_aynisi As String = "Hayır"

        varmi_aynisi = policyinfo_erisim.ciftkayitkontrol(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
        PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ZeylCode, _
        PolicyInfo.ZeylNo, PolicyInfo.ProductType)

        'YENİ BİR POLİCE İSE
        If varmi_aynisi = "Hayır" Then

            Dim arazeyilmi As String = "Hayır"
            If sonzeyil.FirmCode <> "" Then
                Try
                    Dim gelen_zeyilno, sonzeyil_zeylno As Integer
                    sonzeyil_zeylno = CInt(sonzeyil.ZeylNo)
                    gelen_zeyilno = CInt(PolicyInfo.ZeylNo)

                    If gelen_zeyilno < sonzeyil_zeylno Then
                        arazeyilmi = "Evet"
                    End If
                Catch EX As Exception
                End Try
            End If

            If arazeyilmi = "Evet" Then
                If PolicyInfo.ZeylCode = "X" Or PolicyInfo.ZeylCode = "x" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 996
                    ErrorInfo.Message = "Gönderdiğiniz Zeyil numarası bu poliçenin " + _
                    " son zeyilinden küçük olduğundan X zeyili gelemez."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

            If arazeyilmi = "Hayır" Then

                iptalsayisi = policyinfo_erisim.policede_iptalzeyilikacadet(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
                PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ProductType)

                ysayisi = policyinfo_erisim.policede_yzeyilikacadet(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
                PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ProductType)

                psayisi = policyinfo_erisim.policede_pzeyilikacadet(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
                PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ProductType)

                tsayisi = policyinfo_erisim.policede_tzeyilikacadet(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
                PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ProductType)


                If psayisi > 0 Then
                    If PolicyInfo.ZeylCode = "p" Or PolicyInfo.ZeylCode = "P" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "Ayni poliçeye birden fazla P gelemez."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If psayisi <= 0 And tsayisi <= 0 Then
                    If PolicyInfo.ZeylCode = "v" Or PolicyInfo.ZeylCode = "V" Or _
                    PolicyInfo.ZeylCode = "r" Or PolicyInfo.ZeylCode = "R" Or _
                    PolicyInfo.ZeylCode = "x" Or PolicyInfo.ZeylCode = "X" Or _
                    PolicyInfo.ZeylCode = "y" Or PolicyInfo.ZeylCode = "Y" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "P yada T zeyili olmayan poliçeye V,R,X,Y zeyili gelemez."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If iptalsayisi > ysayisi Then
                    If PolicyInfo.ZeylCode <> "y" And PolicyInfo.ZeylCode <> "Y" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "İptali olan bir poliçeye iptal zeyilinden sonra ancak Y zeyili " + _
                        "(Yürürlüğe Alma Zeyili) gelebilir"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.ZeylCode = "y" Or PolicyInfo.ZeylCode = "Y" Then
                    If iptalsayisi = 0 Or iptalsayisi < ysayisi Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "İptali olmayan bir poliçeye Y zeyili gelemez." + _
                        " Y ancak X'den sonra gelebilir."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If 'ara zeyil Hayır



            'ZEYİL TARİH KONTROL
            If servisayar.sonzeyilbitistarihkontrol = "Evet" Then
                If PolicyInfo.StartDate > "01.22.2017" Then
                    If PolicyInfo.ZeylCode = "V" Or PolicyInfo.ZeylCode = "R" Or PolicyInfo.ZeylCode = "X" Then
                        'son zeyil var
                        If sonzeyil.FirmCode <> "" Then
                            If sonzeyil.EndDate > PolicyInfo.EndDate Then
                                root.ResultCode = 0
                                ErrorInfo.Code = 996
                                ErrorInfo.Message = "Gönderdiğiniz zeyilin bitiş tarihi " + _
                                CStr(sonzeyil.EndDate) + " tarihinden büyük olmalıdır. Son Zeyil: " + CStr(sonzeyil.TecditNumber) + "-" + CStr(sonzeyil.ZeylCode)
                                root.ErrorInfo = ErrorInfo
                                Return root
                            End If
                        End If
                    End If
                End If
            End If


            'İHALE TİPİ POLİÇELERİN KOTA KONTROLU YENİ KAYITTA 
            If PolicyInfo.PolicyType = 2 Then
                'P ve T ler için kota kontrolüne gir
                If PolicyInfo.ZeylCode = "P" And PolicyInfo.ZeylCode = "T" Then
                    Dim ihalekotaresult As New CLADBOPRESULT
                    ihalekotaresult = logservis_erisim.ihalekontrol(sirket.pkey)
                    If ihalekotaresult.durum = "Evet" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = ihalekotaresult.etkilenen
                        ErrorInfo.Message = ihalekotaresult.hatastr
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If 'PolicyInfo.PolicyType = 2 

        End If 'varmi=Hayır Yeni Kayıt ise


        '--TARİFE KODU PLAKA KONTROLU --------------------------------------------------------------
        'bu plaka başka tariffcode ile kaydedilmişmi 
        'TR333 gibi mi ?
        If plakakontrol_erisim.ilkkayitplakasimi(PolicyInfo.PlateNumber) = "Hayır" Then
            'cz9 lara bakma 
            If PolicyInfo.TariffCode <> "CZ9" Then
                If PolicyInfo.PolicyType = 1 Then
                    'Zeyl Kodu x,r,v olanlara bakma 
                    If (PolicyInfo.ZeylCode <> "X" And PolicyInfo.ZeylCode <> "x") And _
                    (PolicyInfo.ZeylCode <> "R" And PolicyInfo.ZeylCode <> "r") And _
                    (PolicyInfo.ZeylCode <> "V" And PolicyInfo.ZeylCode <> "v") Then

                        'eğer servis ayarlarında bu kontrol açık ise
                        If servisayar.tarifekodkontrol = "Evet" Then
                            'başka tarife kodu ile bu plaka var mı ?
                            If PolicyInfo2_erisim.ayniplakabaskatariffcodesirketsiz_varmi(PolicyInfo.TariffCode, _
                             PolicyInfo.ProductCode, PolicyInfo.PlateNumber, PolicyInfo.StartDate, PolicyInfo.PolicyType, _
                             PolicyInfo.PlateCountryCode) = "Evet" Then

                                root.ResultCode = 0
                                ErrorInfo.Code = 802
                                ErrorInfo.Message = "Bu plaka başka bir TariffCode " + _
                                " ile daha önce kaydedilmiş. Bu plakanın tarife kodunu kontrol ediniz."
                                root.ErrorInfo = ErrorInfo
                                Return root
                            End If
                        End If

                    End If
                End If
            End If
        End If
        '--------------------------------------------------------------------------------------------


        'hesaplamalar doğrumu gönderilen değerler kontrol et 
        hesapsonuc = calculations2_erisim.hesapla(PolicyInfo)

        'EĞER BAZ FİYAT SINIRLARI DAHİLİNDE DEĞİLSE
        StartDate = PolicyInfo.StartDate
        EndDate = PolicyInfo.EndDate
        If PolicyInfo.PolicyType = 1 Then
            If PolicyInfo.ArrangeDate > "01.01.2016" Then
                If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                    If EndDate.Subtract(StartDate).Days > 360 Then

                        'BAZ FİYAT KONTROLÜ
                        If hesapsonuc.hatakodu = 100 Or hesapsonuc.hatakodu = 101 Then
                            root.ResultCode = hesapsonuc.sonuckodu
                            ErrorInfo.Code = hesapsonuc.hatakodu
                            ErrorInfo.Message = hesapsonuc.hatamsg
                            root.ErrorInfo = ErrorInfo
                            Return root
                        End If

                        'BAZ FİYATI 0 BULDU
                        If hesapsonuc.hatakodu = 99 Then
                            root.ResultCode = hesapsonuc.sonuckodu
                            ErrorInfo.Code = hesapsonuc.hatakodu
                            ErrorInfo.Message = hesapsonuc.hatamsg
                            root.ErrorInfo = ErrorInfo
                            Return root
                        End If

                        'YAŞ ZAMMI ORANI KONTROLÜNÜ YAP
                        If hesapsonuc.hatakodu = 105 Then
                            'root.ResultCode = hesapsonuc.sonuckodu
                            'ErrorInfo.Code = hesapsonuc.hatakodu
                            'ErrorInfo.Message = hesapsonuc.hatamsg
                            'root.ErrorInfo = ErrorInfo
                            'Return root
                        End If

                        'CC ZAMMI ORANI KONTROLÜNÜ YAP
                        'cartype gerekli tüzükte tanımlı cc oranını bulmak için ---
                        If cartypekontrolune_girilecekmi = "Evet" Then
                            If hesapsonuc.hatakodu = 106 Then
                                root.ResultCode = hesapsonuc.sonuckodu
                                ErrorInfo.Code = hesapsonuc.hatakodu
                                ErrorInfo.Message = hesapsonuc.hatamsg
                                root.ErrorInfo = ErrorInfo
                                Return root
                            End If
                        End If

                    End If '360 gün
                End If 'ZeylCode
            End If 'ArrangeDate
        End If 'Type=1

        'arac kayıt dairesindeki logu ekle hesap loga
        hesapsonuc.log = arackayitlog + hesapsonuc.log
        root.hesapsonuc = hesapsonuc

        'rengi bul
        If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
            color = policyinfo_erisim.renkbul(PolicyInfo.FirmCode, PolicyInfo.ProductCode, PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, _
            PolicyInfo.TecditNumber, PolicyInfo.ZeylCode, PolicyInfo.ZeylNo, PolicyInfo.ProductType)
            PolicyInfo.Color = color
            'color = "black"
        End If


        'KONTROLLER BİTTİ -------------------------------------------------------------------------------------------------



        'KAYIT YAPMA İŞLEMLERİ --------------------------------------------------------------------------------------------
        'KAYIT YAPMA İŞLEMLERİ --------------------------------------------------------------------------------------------
        'yeni kayit
        If varmi_aynisi = "Hayır" Then

            'yeni kayıt olduğundan yeni bir SBMCODE üretiyoruz
            SBMCode = policyinfoservicehelper_erisim.sbmcodebul(PolicyInfo)
            PolicyInfo.SBMCode = SBMCode

            'yeni bir kayıt ve ayni zeyil numarasından varmı kontrol et.
            Dim aynimi As String
            aynimi = policyinfo_erisim.zeyilnumarasi_aynimi(PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
            PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ZeylNo, _
            PolicyInfo.ProductType)

            If aynimi = "Evet" Then
                root.ResultCode = 0
                ErrorInfo.Code = 994
                ErrorInfo.Message = "Bu poliçenin zeyilleri arasında ayni zeyil numarasına sahip zeyil " + _
                "daha önce kaydedilmiş"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            resultset = policyinfo_erisim.Ekle(PolicyInfo)
            If resultset.durum = "Kaydedildi" Then
                root.ResultCode = 1
                PolicyLoadResult.InsertedPolicyCount = 1
                PolicyLoadResult.UpdatedPolicyCount = 0
                PolicyLoadResult.SBMCode = SBMCode
                root.PolicyLoadResult = PolicyLoadResult
            End If
            If resultset.durum <> "Kaydedildi" Then
                root.ResultCode = 0
                ErrorInfo.Code = 999
                ErrorInfo.Message = resultset.hatastr
                root.ErrorInfo = ErrorInfo
            End If
        End If

        'düzenleme
        If varmi_aynisi = "Evet" Then

            'daha önceden kayıtlı bir poliçe olduğundan daha önce verilen SBMCODE'U buluyoruz.
            Dim eskipolice As New PolicyInfo
            eskipolice = policyinfo_erisim.bultek(PolicyInfo.FirmCode, PolicyInfo.ProductCode, PolicyInfo.AgencyCode, _
            PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ZeylCode, _
            PolicyInfo.ZeylNo, PolicyInfo.ProductType)
            PolicyInfo.SBMCode = eskipolice.SBMCode

            resultset = policyinfo_erisim.Duzenle(PolicyInfo)
            If resultset.durum = "Kaydedildi" Then
                root.ResultCode = 1
                PolicyLoadResult.InsertedPolicyCount = 0
                PolicyLoadResult.UpdatedPolicyCount = 1
                PolicyLoadResult.SBMCode = PolicyInfo.SBMCode
                root.PolicyLoadResult = PolicyLoadResult
            End If
            If resultset.durum <> "Kaydedildi" Then
                root.ResultCode = 0
                ErrorInfo.Code = 999
                ErrorInfo.Message = resultset.hatastr
                root.ErrorInfo = ErrorInfo
            End If
        End If



        'LOGLAMA İŞLEMİNİ YAP----
        Dim logservis As New CLASSLOGSERVIS
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "LoadPolicyInformation", _
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, PolicyLoadResult.InsertedPolicyCount, _
        PolicyLoadResult.UpdatedPolicyCount, PolicyInfo.FirmCode, PolicyInfo.ProductCode, _
        PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber, PolicyInfo.ZeylCode, _
        PolicyInfo.ZeylNo, PolicyInfo.ProductType, PolicyInfo.FirmCode, "0", "0", "0", _
        "0", "0", "0", "0", policexml, wskullaniciad, wssifre, "", 0, "", "", root.hesapsonuc.log, ip_erisim.ipadresibul))

        Return root

    End Function


   




   


    Public Function IsAlive() As Boolean

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        Dim b As Boolean
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        Try
            db_baglanti.Open()
            b = True
        Catch ex As Exception
            b = False
        End Try
        Return b

    End Function

    Public Function IsDBConnAlive() As String

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        Dim b As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        Try
            db_baglanti.Open()
            b = "1"
        Catch ex As Exception
            b = "0"
        End Try
        Return b

    End Function

    Public Function IsPolicySaved(ByVal UserName As String, _
    ByVal Password As String, ByVal FirmCode As String, _
    ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ZeylCode As String, ByVal ZeylNo As String, _
    ByVal ProductType As String) As root


        Dim xmlhata As String = ""
        Dim root As New root
        Dim DamageLoadResult As New DamageLoadResult
        Dim ErrorInfo As New ErrorInfo

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket_erisim.tumipyetkilimi = "Hayır" Then
            root.ResultCode = 0
            ErrorInfo.Code = 3
            ErrorInfo.Message = "Yetkisiz. Bu IP adresi ile web servisine bağlanmaya yetkiniz yoktur."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'KULLANICI ADI VE ŞİFREYİ KONTROL ET
        sirket = sirket_erisim.kullaniciadsifredogrumu(UserName, Password)
        If sirket.pkey = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 995
            ErrorInfo.Message = "Yetkisiz. Girdiğiniz kullanıcı adı ve şifre" + _
            " ile herhangi bir şirket tanımlanmamış"
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'KULLANICI ADI ŞİFRE DOĞRU İSE IP Yİ KONTROL ET
        If sirket.pkey > 0 Then
            Dim result As New CLADBOPRESULT
            result = sirket_erisim.ipadresi_yekilimi(sirket.pkey)
            If result.durum = "Hayır" Then
                root.ResultCode = result.etkilenen
                ErrorInfo.Code = 995
                ErrorInfo.Message = result.hatastr
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        If sirket.sirketkod <> FirmCode Then
            xmlhata = "Bu FirmCode ile sorgulama yapamazsınız."
        End If


        'GÖNDERİLEN DEĞERLERİ KONTROL ET 

        'FirmCode
        If Len(FirmCode) <> 3 Then
            xmlhata = "FirmCode parametresini yanlış gönderdiniz."
        End If

        'ProductCode
        If Len(ProductCode) <> 2 Then
            xmlhata = "ProductCode parametresini yanlış gönderdiniz."
        End If
        If Len(ProductCode) = 2 Then
            Try
                Dim varmi As String = "Evet"
                Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
                ProductCode = Trim(ProductCode)
                varmi = urunkod_erisim.urunkodvarmi(ProductCode)
                If varmi = "Hayır" Then
                    xmlhata = "Gönderilen XML'de ProductCode KKSBM tarafından tanımlanmamış."
                End If
            Catch ex As Exception
                xmlhata = "Gönderilen XML'de ProductCode KKSBM tarafından tanımlanmamış."
            End Try
        Else
            xmlhata = "Gönderilen XML'de ProductCode  boş olamaz."
        End If

        'AgencyCode
        If AgencyCode = "" Then
            xmlhata = "AgencyCode parametresini yanlış gönderdiniz."
        End If

        'PolicyNumber
        If PolicyNumber = "" Then
            xmlhata = "PolicyNumber parametresini yanlış gönderdiniz."
        End If

        'TecditNumber
        If TecditNumber = "" Then
            xmlhata = "TecditNumber parametresini yanlış gönderdiniz."
        End If


        'ZeylCode
        If ZeylCode <> "" Then
            Try
                Dim varmi As String = "Evet"
                Dim zeylcode_erisim As New CLASSZEYLCODE_ERISIM
                varmi = zeylcode_erisim.zeylkodvarmi(ZeylCode)
                If varmi = "Hayır" Then
                    xmlhata = "Gönderilen XML'de ZeylCode KKSBM tarafından tanımlanmamış."
                End If
            Catch ex As Exception
                xmlhata = "Gönderilen XML'de ZeylCode KKSBM tarafından tanımlanmamış."
            End Try
        Else
            xmlhata = "Gönderilen XML'de ZeylCode  boş olamaz."
        End If

        'ZeylNo
        If ZeylNo = "" Then
            xmlhata = "ZeylNo parametresini yanlış gönderdiniz."
        End If

        'ProductType
        If ProductType = "" Then
            xmlhata = "PolicyType parametresini yanlış gönderdiniz."
        End If

        If xmlhata <> "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 800
            ErrorInfo.Message = xmlhata
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'Herhangi bir hata yoksa
        If xmlhata = "" Then

            Dim PolicyInfo_Erisim As New PolicyInfo_Erisim
            Dim varmi As String
            varmi = PolicyInfo_Erisim.ciftkayitkontrol(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
            TecditNumber, ZeylCode, ZeylNo, ProductType)
            If varmi = "Evet" Then
                root.varmi = True
            End If
            If varmi = "Hayır" Then
                root.varmi = False
            End If

            root.ResultCode = 1
            root.ErrorInfo = ErrorInfo
            Return root

        End If

    End Function


   





End Class
