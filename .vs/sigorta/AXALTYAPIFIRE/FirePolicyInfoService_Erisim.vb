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


Public Class FirePolicyInfoService_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull
    Dim ip_erisim As New CLASSIP_ERISIM

    '------------------------------EKLE-------------------------------------------
    Public Function eklexml(ByVal wskullaniciad As String,
    ByVal wssifre As String,
    ByVal firexml As String) As root

        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim firePolicyInfo_erisim As New FirePolicyInfo_Erisim
        Dim firePolicy As New FirePolicyInfo

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim core_erisim As New CLASSCORE_ERISIM

        Dim FSBMCode As String = ""
        Dim girdisayisi As Integer = 0
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim xmlhata As String = ""
        Dim root As New root
        Dim PolicyLoadResult As New PolicyLoadResult
        Dim ErrorInfo As New ErrorInfo

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)
        If sirket.pkey = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 995
            ErrorInfo.Message = "Yetkisiz. Girdiğiniz kullanıcı adı ve şifre ile " +
            "herhangi bir şirket tanımlanmamış"
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        Dim zeylcode As New CLASSZEYLCODE
        Dim zeylcode_erisim As New CLASSZEYLCODE_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM


        Dim debugy As String = ""
        Dim XmlDoc As XmlDocument = New XmlDocument

        'policexml normalize---
        firexml = Replace(firexml, "&", "&amp;")

        Try
            XmlDoc.Load(New StringReader(firexml))
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de hatalar var." + ex.Message
            root.ResultCode = 0
            ErrorInfo.Code = 998
            ErrorInfo.Message = ex.Message
            root.ErrorInfo = ErrorInfo
            Return root
        End Try

        Dim color As String

        Dim FirmCode_girdimi, ProductCode_girdimi As String '1
        Dim AgencyCode_girdimi, PolicyNumber_girdimi As String '2
        Dim TecditNumber_girdimi, ZeylCode_girdimi As String '3
        Dim ZeyilNo_girdimi, PolicyType_girdimi As String '4
        Dim ArrangeDate_girdimi, StartDate_girdimi As String '5
        Dim EndDate_girdimi, PolicyOwnerCountryCode_girdimi As String '6
        Dim PolicyOwnerIdentityCode_girdimi, PolicyOwnerIdentityNo_girdimi As String '7
        Dim PolicyOwnerName_girdimi, PolicyOwnerSurname_girdimi As String '8
        Dim InsuredTitle_girdimi, RiskAddress_ilcekod_girdimi As String '9
        Dim RiskAddress_bucakkod_girdimi, RiskAddress_belediyekod_girdimi As String '10
        Dim RiskAddress_mahallekod_girdimi, RiskAddress_sokakkod_girdimi As String '11
        Dim FirstBeneficiary_girdimi, Creditor_girdimi As String '12
        Dim RiskType_girdimi, StructureStyle_girdimi As String '13
        Dim OfficeBlock_girdimi, Activity_girdimi As String '14
        Dim AgencyRegisterCode_girdimi, TPNo_girdimi As String '15
        Dim Building_girdimi, Contents_girdimi As String '16
        Dim EartQuake_girdimi, FloodFlooding_girdimi As String '17
        Dim InternalWater_girdimi, Storm_girdimi As String '18
        Dim Theft_girdimi, LandVehicles_girdimi As String '19
        Dim AirCraft_girdimi, MaritimeVehicles_girdimi As String '20
        Dim Smoke_girdimi, SpaceShift_girdimi As String '21
        Dim GLKHH_girdimi, MaliciousTerror_girdimi As String '22
        Dim OtherGuarentees_girdimi, Latitude_girdimi As String '23
        Dim Longitude_girdimi, BuildingValue_girdimi As String '24
        Dim ContentsValue_girdimi, CurrencyCode_girdimi As String '25
        Dim ExchangeRate_girdimi, FirePremium_girdimi As String '26
        Dim SupplementaryGuaranteePremium_girdimi, EarthquakePremium_girdimi As String '27
        Dim OtherFees_girdimi, TotalPremium_girdimi As String '28
        Dim FirePremiumTL_girdimi, SupplementaryGuaranteePremiumTL_girdimi As String '29
        Dim EarthquakePremiumTL_girdimi, OtherFeesTL_girdimi As String '30
        Dim TotalPremiumTL_girdimi, PolicyPremiumTL_girdimi As String '31

        FirmCode_girdimi = "Hayır" '1
        ProductCode_girdimi = "Hayır" '2
        AgencyCode_girdimi = "Hayır" '3
        PolicyNumber_girdimi = "Hayır" '4
        TecditNumber_girdimi = "Hayır" '5
        ZeylCode_girdimi = "Hayır" '6
        ZeyilNo_girdimi = "Hayır" '7
        PolicyType_girdimi = "Hayır" '8
        ArrangeDate_girdimi = "Hayır" '9
        StartDate_girdimi = "Hayır" '10
        EndDate_girdimi = "Hayır" '11
        PolicyOwnerCountryCode_girdimi = "Hayır" '12
        PolicyOwnerIdentityCode_girdimi = "Hayır" '13
        PolicyOwnerIdentityNo_girdimi = "Hayır" '14
        PolicyOwnerName_girdimi = "Hayır" '15
        PolicyOwnerSurname_girdimi = "Hayır" '16
        InsuredTitle_girdimi = "Hayır" '17
        RiskAddress_ilcekod_girdimi = "Hayır" '18
        RiskAddress_bucakkod_girdimi = "Hayır" '19
        RiskAddress_belediyekod_girdimi = "Hayır" '20
        RiskAddress_mahallekod_girdimi = "Hayır" '21
        RiskAddress_sokakkod_girdimi = "Hayır" '22
        FirstBeneficiary_girdimi = "Hayır" '23
        Creditor_girdimi = "Hayır" '24
        RiskType_girdimi = "Hayır" '25
        StructureStyle_girdimi = "Hayır" '26
        OfficeBlock_girdimi = "Hayır" '27
        Activity_girdimi = "Hayır" '28
        AgencyRegisterCode_girdimi = "Hayır" '29
        TPNo_girdimi = "Hayır" '30
        Building_girdimi = "Hayır" '31
        Contents_girdimi = "Hayır" '32

        EartQuake_girdimi = "Hayır" '33
        FloodFlooding_girdimi = "Hayır" '34
        InternalWater_girdimi = "Hayır" '35
        Storm_girdimi = "Hayır" '36
        Theft_girdimi = "Hayır" '37
        LandVehicles_girdimi = "Hayır" '38
        AirCraft_girdimi = "Hayır" '39
        MaritimeVehicles_girdimi = "Hayır" '40
        Smoke_girdimi = "Hayır" '41
        SpaceShift_girdimi = "Hayır" '42
        GLKHH_girdimi = "Hayır" '43
        MaliciousTerror_girdimi = "Hayır" '44
        OtherGuarentees_girdimi = "Hayır" '45
        Latitude_girdimi = "Hayır" '46
        Longitude_girdimi = "Hayır" '47
        BuildingValue_girdimi = "Hayır" '48
        ContentsValue_girdimi = "Hayır" '49
        CurrencyCode_girdimi = "Hayır" '50
        ExchangeRate_girdimi = "Hayır" '51

        FirePremium_girdimi = "Hayır" '52
        SupplementaryGuaranteePremium_girdimi = "Hayır" '53
        EarthquakePremium_girdimi = "Hayır" '54
        OtherFees_girdimi = "Hayır" '55
        TotalPremium_girdimi = "Hayır" '56
        FirePremiumTL_girdimi = "Hayır" '57
        SupplementaryGuaranteePremiumTL_girdimi = "Hayır" '58
        EarthquakePremiumTL_girdimi = "Hayır" '59
        OtherFeesTL_girdimi = "Hayır" '60
        TotalPremiumTL_girdimi = "Hayır" '61
        PolicyPremiumTL_girdimi = "Hayır" '62



        For Each Element As XmlElement In XmlDoc.SelectNodes("//*")
            'debugy = debugy + Element.Name + "<br/>"
            For Each Attribute As XmlAttribute In Element.Attributes

                'FirmCode 1
                If Attribute.Name = "FirmCode" Then
                    girdisayisi = girdisayisi + 1
                    FirmCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FirePolicy.FirmCode = Attribute.Value
                        If sirket.sirketkod <> Attribute.Value Then
                            xmlhata = "Gönderdiğiniz XML'deki FirmCode " +
                            "ile giriş yaptığınız kullanıcı adı ve şifre ile" +
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
                            Dim varmi As String = "Evet"
                            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
                            FirePolicy.ProductCode = Trim(Attribute.Value)
                            varmi = urunkod_erisim.urunkodvarmi(FirePolicy.ProductCode)
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
                        FirePolicy.AgencyCode = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                    If FirePolicy.AgencyCode = "" Then
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                End If

                'PolicyNumber 4
                If Attribute.Name = "PolicyNumber" Then
                    girdisayisi = girdisayisi + 1
                    PolicyNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FirePolicy.PolicyNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                    If FirePolicy.PolicyNumber = "" Then
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                End If

                'TecditNumber 5
                If Attribute.Name = "TecditNumber" Then
                    girdisayisi = girdisayisi + 1
                    TecditNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        FirePolicy.TecditNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                    If FirePolicy.TecditNumber = "" Then
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                End If


                'ZeylCode 6
                If Attribute.Name = "ZeylCode" Then
                    girdisayisi = girdisayisi + 1
                    ZeylCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            FirePolicy.ZeylCode = Trim(Attribute.Value)
                            varmi = zeylcode_erisim.zeylkodvarmi(FirePolicy.ZeylCode)
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

                'ZeylNo 7
                If Attribute.Name = "ZeyilNo" Then
                    girdisayisi = girdisayisi + 1
                    ZeyilNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        firePolicy.ZeyilNo = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de ZeyilNo  boş olamaz."
                    End If
                    If firePolicy.ZeyilNo = "" Then
                        xmlhata = "Gönderilen XML'de ZeyilNo boş olamaz."
                    End If
                End If

                'PolicyType 8
                If Attribute.Name = "PolicyType" Then
                    girdisayisi = girdisayisi + 1
                    PolicyType_girdimi = "Evet"
                    Try
                        FirePolicy.PolicyType = CInt(Attribute.Value)
                        Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
                        Dim varmi As String = "Evet"
                        varmi = policetip_erisim.policetipvarmi(FirePolicy.PolicyType)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de PolicyType KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        FirePolicy.PolicyType = 0
                        xmlhata = "Gönderilen XML'de PolicyType rakam olmak zorunda veya 0 olmamalı."
                    End Try
                End If


                'ArrangeDate 9
                If Attribute.Name = "ArrangeDate" Then
                    girdisayisi = girdisayisi + 1
                    ArrangeDate_girdimi = "Evet"
                    Try
                        FirePolicy.ArrangeDate = Attribute.Value
                    Catch
                        xmlhata = "Gönderilen XML'de ArrangeDate boş olmamalı" +
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " +
                        "şeklinde olmalıdır."
                    End Try
                End If


                'StartDate 10
                If Attribute.Name = "StartDate" Then
                    girdisayisi = girdisayisi + 1
                    StartDate_girdimi = "Evet"
                    Try
                        FirePolicy.StartDate = Attribute.Value
                    Catch
                        xmlhata = "Gönderilen XML'de StartDate boş olmamalı" +
                        " veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " +
                        "şeklinde olmalıdır."
                    End Try
                End If


                'EndDate 11
                If Attribute.Name = "EndDate" Then
                    girdisayisi = girdisayisi + 1
                    EndDate_girdimi = "Evet"
                    Try
                        FirePolicy.EndDate = Attribute.Value
                    Catch
                        xmlhata = "Gönderilen XML'de EndDate boş olmamalı veya formatı hatalıdır. Tarih formatı yyyy-MM-dd " +
                        "şeklinde olmalıdır."
                    End Try
                End If


                'PolicyOwnerCountryCode 12
                If Attribute.Name = "PolicyOwnerCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerCountryCode_girdimi = "Evet"
                    FirePolicy.PolicyOwnerCountryCode = Attribute.Value
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de PolicyOwnerCountryCode boş olmamalıdır."
                    End If
                End If

                'PolicyOwnerIdentityCode 13
                If Attribute.Name = "PolicyOwnerIdentityCode" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerIdentityCode_girdimi = "Evet"
                    FirePolicy.PolicyOwnerIdentityCode = Attribute.Value
                End If


                'PolicyOwnerIdentityNo 14
                If Attribute.Name = "PolicyOwnerIdentityNo" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerIdentityNo_girdimi = "Evet"
                    Try
                        FirePolicy.PolicyOwnerIdentityNo = Attribute.Value
                    Catch
                        FirePolicy.PolicyOwnerIdentityNo = Nothing
                    End Try
                End If


                'PolicyOwnerName 15
                If Attribute.Name = "PolicyOwnerName" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerName_girdimi = "Evet"
                    FirePolicy.PolicyOwnerName = Attribute.Value
                End If

                'PolicyOwnerSurname 16
                If Attribute.Name = "PolicyOwnerSurname" Then
                    girdisayisi = girdisayisi + 1
                    PolicyOwnerSurname_girdimi = "Evet"
                    FirePolicy.PolicyOwnerSurname = Attribute.Value
                End If


                'InsuredTitle 17
                If Attribute.Name = "InsuredTitle" Then
                    girdisayisi = girdisayisi + 1
                    InsuredTitle_girdimi = "Evet"
                    Try
                        firePolicy.InsuredTitle = CInt(Attribute.Value)
                        Dim insuredtitle_erisim As New CLASSINSUREDTITLE_ERISIM
                        If insuredtitle_erisim.kodvarmi(Attribute.Value) <> "Evet" Then
                            xmlhata = "Gönderilen XML'de InsuredTitle kodu KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de InsuredTitle kodu doğru gönderilmemiş."
                    End Try
                End If

                'RiskAddress_ilcekod 18
                If Attribute.Name = "RiskAddress_ilcekod" Then
                    girdisayisi = girdisayisi + 1
                    RiskAddress_ilcekod_girdimi = "Evet"
                    Try
                        firePolicy.RiskAddress_ilcekod = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de İlçe kodu rakamsal olmalıdır."
                    End Try
                End If


                'RiskAddress_bucakkod 19
                If Attribute.Name = "RiskAddress_bucakkod" Then
                    girdisayisi = girdisayisi + 1
                    RiskAddress_bucakkod_girdimi = "Evet"
                    Try
                        firePolicy.RiskAddress_bucakkod = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Bucak kodu rakamsal olmalıdır."
                    End Try
                End If



                'RiskAddress_belediyekod 20
                If Attribute.Name = "RiskAddress_belediyekod" Then
                    girdisayisi = girdisayisi + 1
                    RiskAddress_belediyekod_girdimi = "Evet"
                    Try
                        firePolicy.RiskAddress_belediyekod = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Belediye kodu rakamsal olmalıdır."
                    End Try
                End If


                'RiskAddress_mahallekod 21
                If Attribute.Name = "RiskAddress_mahallekod" Then
                    girdisayisi = girdisayisi + 1
                    RiskAddress_mahallekod_girdimi = "Evet"
                    Try
                        firePolicy.RiskAddress_mahallekod = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Mahalle kodu rakamsal olmalıdır."
                    End Try
                End If


                'RiskAddress_sokakkod 22
                If Attribute.Name = "RiskAddress_sokakkod" Then
                    girdisayisi = girdisayisi + 1
                    RiskAddress_sokakkod_girdimi = "Evet"
                    Try
                        firePolicy.RiskAddress_sokakkod = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Sokak kodu rakamsal olmalıdır."
                    End Try
                End If


                'FirstBeneficiary 23
                If Attribute.Name = "FirstBeneficiary" Then
                    girdisayisi = girdisayisi + 1
                    FirstBeneficiary_girdimi = "Evet"
                    FirePolicy.FirstBeneficiary = Attribute.Value
                End If


                'Creditor 24
                If Attribute.Name = "Creditor" Then
                    girdisayisi = girdisayisi + 1
                    Creditor_girdimi = "Evet"
                    Try
                        FirePolicy.Creditor = CInt(Attribute.Value)
                        If FirePolicy.Creditor And FirePolicy.Creditor <> 1 Then
                            xmlhata = "Gönderilen XML'de Creditor değeri 0 yada 1 olabilir."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Creditor değeri 0 yada 1 olabilir."
                    End Try
                End If


                'RiskType 25
                If Attribute.Name = "RiskType" Then
                    girdisayisi = girdisayisi + 1
                    RiskType_girdimi = "Evet"
                    Try
                        firePolicy.RiskType = CInt(Attribute.Value)
                        Dim risktype_erisim As New CLASSRISKTYPE_ERISIM
                        If risktype_erisim.kodvarmi(Attribute.Value) <> "Evet" Then
                            xmlhata = "Gönderilen XML'de RiskType kodu KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de RiskType değeri yanlış gönderildi."
                    End Try
                End If

                'StructureStyle 26
                If Attribute.Name = "StructureStyle" Then
                    girdisayisi = girdisayisi + 1
                    StructureStyle_girdimi = "Evet"
                    Try
                        firePolicy.StructureStyle = CInt(Attribute.Value)
                        Dim structurestyle_erisim As New CLASSSTRUCTURESTYLE_ERISIM
                        If structurestyle_erisim.kodvarmi(Attribute.Value) <> "Evet" Then
                            xmlhata = "Gönderilen XML'de StructureStyle kodu KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de StructureStyle değeri yanlış gönderildi."
                    End Try
                End If


                'OfficeBlock 27
                If Attribute.Name = "OfficeBlock" Then
                    girdisayisi = girdisayisi + 1
                    OfficeBlock_girdimi = "Evet"
                    Try
                        firePolicy.OfficeBlock = Attribute.Value
                        If firePolicy.OfficeBlock <> 0 And firePolicy.OfficeBlock <> 1 Then
                            xmlhata = "Gönderilen XML'de OfficeBlock 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de OfficeBlock değeri yanlış gönderildi."
                    End Try
                End If


                'Activity 28
                If Attribute.Name = "Activity" Then
                    girdisayisi = girdisayisi + 1
                    Activity_girdimi = "Evet"

                    Try
                        firePolicy.Activity = Attribute.Value
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Activity değeri yanlış gönderildi."
                    End Try

                    firePolicy.Activity = Attribute.Value
                End If


                'AgencyRegisterCode 29
                If Attribute.Name = "AgencyRegisterCode" Then
                    girdisayisi = girdisayisi + 1
                    AgencyRegisterCode_girdimi = "Evet"
                    Try
                        FirePolicy.AgencyRegisterCode = Attribute.Value
                    Catch ex As Exception
                        FirePolicy.AgencyRegisterCode = ""
                    End Try
                End If


                'TPNo 30
                If Attribute.Name = "TPNo" Then
                    girdisayisi = girdisayisi + 1
                    TPNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            FirePolicy.TPNo = Trim(Attribute.Value)
                            varmi = personel_erisim.ciftkayitkontrol("tpno", FirePolicy.TPNo)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                        End Try
                    End If
                    If Attribute.Value = "" Then
                        FirePolicy.TPNo = ""
                    End If
                End If



                'Building 31
                If Attribute.Name = "Building" Then
                    girdisayisi = girdisayisi + 1
                    Building_girdimi = "Evet"
                    Try
                        FirePolicy.Building = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de Building 0 yada 1 den oluşmalıdır."
                        End If
                    Catch
                        xmlhata = "Gönderilen XML'de Building boş olmamalıdır."
                    End Try
                End If


                'Contents 32
                If Attribute.Name = "Contents" Then
                    girdisayisi = girdisayisi + 1
                    Contents_girdimi = "Evet"
                    Try
                        FirePolicy.Contents = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de Contents 0 yada 1 den oluşmalıdır."
                        End If
                    Catch
                        xmlhata = "Gönderilen XML'de Contents boş olmamalıdır."
                    End Try
                End If


                'EartQuake 33
                If Attribute.Name = "EartQuake" Then
                    girdisayisi = girdisayisi + 1
                    EartQuake_girdimi = "Evet"
                    Try
                        FirePolicy.EartQuake = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de EarthQuake 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de EarthQuake yanlış gönderildi."
                    End Try
                End If


                'FloodFlooding 34
                If Attribute.Name = "FloodFlooding" Then
                    girdisayisi = girdisayisi + 1
                    FloodFlooding_girdimi = "Evet"
                    Try
                        FirePolicy.FloodFlooding = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de FloodFlooding 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de FloodFlooding yanlış gönderildi."
                    End Try
                End If


                'InternalWater 35
                If Attribute.Name = "InternalWater" Then
                    girdisayisi = girdisayisi + 1
                    InternalWater_girdimi = "Evet"
                    Try
                        FirePolicy.InternalWater = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de InternalWater 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de InternalWater yanlış gönderildi."
                    End Try
                End If


                'Storm 36
                If Attribute.Name = "Storm" Then
                    girdisayisi = girdisayisi + 1
                    Storm_girdimi = "Evet"
                    Try
                        FirePolicy.Storm = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de Storm 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Storm yanlış gönderildi."
                    End Try
                End If


                'Theft 37
                If Attribute.Name = "Theft" Then
                    girdisayisi = girdisayisi + 1
                    Theft_girdimi = "Evet"
                    Try
                        FirePolicy.Theft = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de Theft 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Theft yanlış gönderildi."
                    End Try
                End If


                'LandVehicles 38
                If Attribute.Name = "LandVehicles" Then
                    girdisayisi = girdisayisi + 1
                    LandVehicles_girdimi = "Evet"
                    Try
                        FirePolicy.LandVehicles = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de LandVehicles 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de LandVehicles yanlış gönderildi."
                    End Try
                End If


                'AirCraft 39
                If Attribute.Name = "AirCraft" Then
                    girdisayisi = girdisayisi + 1
                    AirCraft_girdimi = "Evet"
                    Try
                        FirePolicy.AirCraft = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de AirCraft 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de AirCraft yanlış gönderildi."
                    End Try
                End If


                'MaritimeVehicles 40
                If Attribute.Name = "MaritimeVehicles" Then
                    girdisayisi = girdisayisi + 1
                    MaritimeVehicles_girdimi = "Evet"
                    Try
                        FirePolicy.MaritimeVehicles = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de MaritimeVehicles 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de MaritimeVehicles yanlış gönderildi."
                    End Try
                End If


                'Smoke 41
                If Attribute.Name = "Smoke" Then
                    girdisayisi = girdisayisi + 1
                    Smoke_girdimi = "Evet"
                    Try
                        FirePolicy.Smoke = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de Smoke 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de Smoke yanlış gönderildi."
                    End Try
                End If


                'SpaceShift 42
                If Attribute.Name = "SpaceShift" Then
                    girdisayisi = girdisayisi + 1
                    SpaceShift_girdimi = "Evet"
                    Try
                        FirePolicy.SpaceShift = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de SpaceShift 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de SpaceShift yanlış gönderildi."
                    End Try
                End If

                'GLKHH 43
                If Attribute.Name = "GLKHH" Then
                    girdisayisi = girdisayisi + 1
                    GLKHH_girdimi = "Evet"
                    Try
                        FirePolicy.GLKHH = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de GLKHH 0 yada 1 den oluşmalıdır."
                        End If
                    Catch
                        xmlhata = "Gönderilen XML'de GLKHH yanlış gönderildi."
                    End Try
                End If

                'MaliciousTerror 44
                If Attribute.Name = "MaliciousTerror" Then
                    girdisayisi = girdisayisi + 1
                    MaliciousTerror_girdimi = "Evet"
                    Try
                        FirePolicy.MaliciousTerror = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de MaliciousTerror 0 yada 1 den oluşmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de MaliciousTerror yanlış gönderildi."
                    End Try
                End If


                'OtherGuarentees 45
                If Attribute.Name = "OtherGuarentees" Then
                    girdisayisi = girdisayisi + 1
                    OtherGuarentees_girdimi = "Evet"
                    Try
                        FirePolicy.OtherGuarentees = Attribute.Value
                        If Attribute.Value <> "0" And Attribute.Value <> "1" Then
                            xmlhata = "Gönderilen XML'de OtherGuarentees 0 yada 1 den oluşmalıdır."
                        End If
                    Catch
                        FirePolicy.OtherGuarentees = Nothing
                    End Try
                End If

                'Latitude 46
                If Attribute.Name = "Latitude" Then
                    girdisayisi = girdisayisi + 1
                    Latitude_girdimi = "Evet"
                    Try
                        FirePolicy.Latitude = CDec(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de Latitude değeri decimal olmalıdır."
                    End Try
                End If

                'Longitude 47
                If Attribute.Name = "Longitude" Then
                    girdisayisi = girdisayisi + 1
                    Longitude_girdimi = "Evet"
                    Try
                        FirePolicy.Longitude = CDec(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de Longitude değeri decimal olmalıdır."
                    End Try
                End If

                'BuildingValue 48
                If Attribute.Name = "BuildingValue" Then
                    girdisayisi = girdisayisi + 1
                    BuildingValue_girdimi = "Evet"
                    Try
                        FirePolicy.BuildingValue = CDec(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de BuildingValue değeri decimal olmalıdır."
                    End Try
                End If

                'ContentsValue 49
                If Attribute.Name = "ContentsValue" Then
                    girdisayisi = girdisayisi + 1
                    ContentsValue_girdimi = "Evet"
                    Try
                        FirePolicy.ContentsValue = CDec(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de ContentsValue değeri decimal olmalıdır."
                    End Try
                End If

                'CurrencyCode 50
                If Attribute.Name = "CurrencyCode" Then
                    girdisayisi = girdisayisi + 1
                    CurrencyCode_girdimi = "Evet"
                    Try
                        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
                        Dim varmi = "Evet"
                        FirePolicy.CurrencyCode = Attribute.Value
                        varmi = currencycode_erisim.currencycodevarmi(FirePolicy.CurrencyCode)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                    End Try
                End If

                'ExchangeRate 51
                If Attribute.Name = "ExchangeRate" Then
                    girdisayisi = girdisayisi + 1
                    ExchangeRate_girdimi = "Evet"
                    Try
                        FirePolicy.ExchangeRate = Attribute.Value
                    Catch ex As Exception
                        FirePolicy.ExchangeRate = 0
                        xmlhata = "Gönderilen XML'de ExchangeRate rakamsal olmalıdır."
                    End Try
                End If

                'FirePremium 52
                If Attribute.Name = "FirePremium" Then
                    girdisayisi = girdisayisi + 1
                    FirePremium_girdimi = "Evet"
                    Try
                        FirePolicy.FirePremium = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de FirePremium rakamsal olmalıdır."
                        FirePolicy.FirePremium = Nothing
                    End Try
                End If

                'SupplementaryGuaranteePremium 53
                If Attribute.Name = "SupplementaryGuaranteePremium" Then
                    girdisayisi = girdisayisi + 1
                    SupplementaryGuaranteePremium_girdimi = "Evet"
                    Try
                        FirePolicy.SupplementaryGuaranteePremium = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de SupplementaryGuaranteePremium rakamsal olmalıdır."
                        FirePolicy.SupplementaryGuaranteePremium = Nothing
                    End Try
                End If


                'EarthquakePremium 54
                If Attribute.Name = "EarthquakePremium" Then
                    girdisayisi = girdisayisi + 1
                    EarthquakePremium_girdimi = "Evet"
                    Try
                        FirePolicy.EarthquakePremium = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de EarthquakePremium rakamsal olmalıdır."
                        FirePolicy.EarthquakePremium = Nothing
                    End Try
                End If

                'OtherFees 55
                If Attribute.Name = "OtherFees" Then
                    girdisayisi = girdisayisi + 1
                    OtherFees_girdimi = "Evet"
                    Try
                        FirePolicy.OtherFees = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de OtherFees rakamsal olmalıdır."
                        FirePolicy.OtherFees = Nothing
                    End Try
                End If

                'TotalPremium 56
                If Attribute.Name = "TotalPremium" Then
                    girdisayisi = girdisayisi + 1
                    TotalPremium_girdimi = "Evet"
                    Try
                        FirePolicy.TotalPremium = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de TotalPremium rakamsal olmalıdır."
                        FirePolicy.TotalPremium = Nothing
                    End Try
                End If

                'FirePremiumTL 57
                If Attribute.Name = "FirePremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    FirePremiumTL_girdimi = "Evet"
                    Try
                        FirePolicy.FirePremiumTL = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de FirePremiumTL rakamsal olmalıdır."
                        FirePolicy.FirePremiumTL = Nothing
                    End Try
                End If

                'SupplementaryGuaranteePremiumTL 58
                If Attribute.Name = "SupplementaryGuaranteePremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    SupplementaryGuaranteePremiumTL_girdimi = "Evet"
                    Try
                        FirePolicy.SupplementaryGuaranteePremiumTL = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de SupplementaryGuaranteePremiumTL rakamsal olmalıdır."
                        FirePolicy.SupplementaryGuaranteePremiumTL = Nothing
                    End Try
                End If


                'EarthquakePremiumTL 59
                If Attribute.Name = "EarthquakePremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    EarthquakePremiumTL_girdimi = "Evet"
                    Try
                        FirePolicy.EarthquakePremiumTL = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de EarthquakePremiumTL rakamsal olmalıdır."
                        FirePolicy.EarthquakePremiumTL = Nothing
                    End Try
                End If


                'OtherFeesTL 60
                If Attribute.Name = "OtherFeesTL" Then
                    girdisayisi = girdisayisi + 1
                    OtherFeesTL_girdimi = "Evet"
                    Try
                        firePolicy.OtherFeesTL = CDbl(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de OtherFeesTL rakamsal olmalıdır."
                        firePolicy.OtherFeesTL = Nothing
                    End Try
                End If


                'TotalPremiumTL 61
                If Attribute.Name = "TotalPremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    TotalPremiumTL_girdimi = "Evet"
                    Try
                        FirePolicy.TotalPremiumTL = CDec(Attribute.Value)
                    Catch
                        xmlhata = "Gönderilen XML'de TotalPremiumTL boş olamaz."
                        FirePolicy.TotalPremiumTL = Nothing
                    End Try
                End If

                'PolicyPremiumTL 62
                If Attribute.Name = "PolicyPremiumTL" Then
                    girdisayisi = girdisayisi + 1
                    PolicyPremiumTL_girdimi = "Evet"
                    Try
                        FirePolicy.PolicyPremiumTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        xmlhata = "Gönderilen XML'de PolicyPremiumTL Value boş olamaz."
                        FirePolicy.PolicyPremiumTL = Nothing
                    End Try
                End If


                'debugy = debugy + Attribute.Name + ":" + Attribute.Value + "<br/>"
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
        If ZeylCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ZeylCode" + "-"
        End If

        '7
        If ZeyilNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ZeyilNo" + "-"
        End If

        '8
        If PolicyType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyType" + "-"
        End If

        '9
        If ArrangeDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ArrangeDate" + "-"
        End If

        '10
        If StartDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "StartDate" + "-"
        End If

        '11
        If EndDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EndDate" + "-"
        End If

        '12
        If PolicyOwnerCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerCountryCode" + "-"
        End If

        '13
        If PolicyOwnerIdentityCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerIdentityCode" + "-"
        End If

        '14
        If PolicyOwnerIdentityNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerIdentityNo" + "-"
        End If

        '15
        If PolicyOwnerName_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerName" + "-"
        End If

        '16
        If PolicyOwnerSurname_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyOwnerSurname" + "-"
        End If

        '17
        If InsuredTitle_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InsuredTitle" + "-"
        End If

        '18
        If RiskAddress_ilcekod_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RiskAddress_ilcekod" + "-"
        End If

        '19
        If RiskAddress_bucakkod_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RiskAddress_bucakkod" + "-"
        End If

        '20
        If RiskAddress_belediyekod_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RiskAddress_belediyekod" + "-"
        End If

        '21
        If RiskAddress_mahallekod_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RiskAddress_mahallekod" + "-"
        End If

        '22
        If RiskAddress_sokakkod_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RiskAddress_sokakkod" + "-"
        End If

        '23
        If FirstBeneficiary_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FirstBeneficiary" + "-"
        End If

        '24
        If Creditor_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Creditor" + "-"
        End If

        '25
        If RiskType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RiskType" + "-"
        End If

        '26
        If StructureStyle_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "StructureStyle" + "-"
        End If

        '27
        If OfficeBlock_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OfficeBlock" + "-"
        End If

        '28
        If Activity_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Activity" + "-"
        End If

        '29
        If AgencyRegisterCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgencyRegisterCode" + "-"
        End If

        '30
        If TPNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TPNo" + "-"
        End If

        '31
        If Building_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Building" + "-"
        End If

        '32
        If Contents_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Contents" + "-"
        End If

        '33
        If EartQuake_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EartQuake" + "-"
        End If

        '34
        If FloodFlooding_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FloodFlooding" + "-"
        End If

        '35
        If InternalWater_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InternalWater" + "-"
        End If

        '36
        If Storm_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Storm" + "-"
        End If

        '37
        If Theft_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Theft" + "-"
        End If

        '38
        If LandVehicles_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "LandVehicles" + "-"
        End If

        '39
        If AirCraft_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AirCraft" + "-"
        End If

        '40
        If MaritimeVehicles_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "MaritimeVehicles" + "-"
        End If

        '41
        If Smoke_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Smoke" + "-"
        End If

        '42
        If SpaceShift_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SpaceShift" + "-"
        End If

        '43
        If GLKHH_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "GLKHH" + "-"
        End If

        '44
        If MaliciousTerror_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "MaliciousTerror" + "-"
        End If

        '45
        If OtherGuarentees_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OtherGuarentees" + "-"
        End If

        '46
        If Latitude_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Latitude" + "-"
        End If

        '47
        If Longitude_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Longitude" + "-"
        End If

        '48
        If BuildingValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "BuildingValue" + "-"
        End If

        '49
        If ContentsValue_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ContentsValue" + "-"
        End If

        '50
        If CurrencyCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CurrencyCode" + "-"
        End If

        '51
        If ExchangeRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ExchangeRate" + "-"
        End If

        '52
        If FirePremium_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FirePremium" + "-"
        End If

        '53
        If SupplementaryGuaranteePremium_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SupplementaryGuaranteePremium" + "-"
        End If

        '54
        If EarthquakePremium_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EarthquakePremium" + "-"
        End If

        '55
        If OtherFees_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OtherFees" + "-"
        End If

        '56
        If TotalPremium_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TotalPremium" + "-"
        End If

        '57
        If FirePremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FirePremiumTL" + "-"
        End If

        '58
        If SupplementaryGuaranteePremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SupplementaryGuaranteePremiumTL" + "-"
        End If

        '59
        If EarthquakePremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EarthquakePremiumTL" + "-"
        End If

        '60
        If OtherFeesTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "OtherFeesTL" + "-"
        End If

        '61
        If TotalPremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TotalPremiumTL" + "-"
        End If

        '62
        If PolicyPremiumTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyPremiumTL" + "-"
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
        If girdisayisi <> 62 Then
            root.ResultCode = 0
            ErrorInfo.Code = 99
            ErrorInfo.Message = "Gönderdiğiniz XML'de bazı alanlar eksik yada fazladır." +
            "Toplam xml node sayısı 62 olması gerekirken siz " + CStr(girdisayisi) + " alan gönderdiniz. " +
            girilmeyenstr
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'boş olmaması gerekenleri kontrol et
        If FirePolicy.FirmCode = Nothing Or FirePolicy.ProductCode = Nothing Or
        FirePolicy.AgencyCode = Nothing Or FirePolicy.PolicyNumber = Nothing Or
        FirePolicy.TecditNumber = Nothing Or FirePolicy.ZeylCode = Nothing Or
        FirePolicy.ZeyilNo = Nothing Or FirePolicy.PolicyType = Nothing Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = "Gönderdiğiniz XML'de FirmCode, ProductCode, AgencyCode, PolicyNumber, " +
            "TecditNumber, ZeylCode, ZeylNo, PolicyType boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'SORU İŞARETİ KONTROL
        If InStr(firexml, "?", CompareMethod.Text) > 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 333
            ErrorInfo.Message = "Gönderdiğiniz XML'in hiçbir yerinde ? (soru işareti) karakteri olmamalıdır."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'Creditor First Beneficiary 
        If firePolicy.Creditor = 1 Then
            If firePolicy.FirstBeneficiary = "" Then
                xmlhata = "Gönderilen XML'de Creditor değeri 1 ise FirstBeneficiary boş olamaz."
            End If
        End If
        If firePolicy.Creditor = 0 Then
            If firePolicy.FirstBeneficiary <> "" Then
                xmlhata = "Gönderilen XML'de Creditor değeri 0 ise FirstBeneficiary boş olmalıdır."
            End If
        End If

        'PolicyPremium 0 dan büyük olamaz P ve T olan poliçeler için
        If firePolicy.ZeylCode = "P" Or firePolicy.ZeylCode = "T" Then
            If firePolicy.FirePremium <= 0 Then
                xmlhata = "FirePremium'dan 0 dan büyük olmalıdır. 0 primli bir poliçe kesemezsiniz."
            End If
        End If

        'InsurancePremium PolicyPremium kontrolu
        If firePolicy.PolicyPremiumTL > firePolicy.TotalPremiumTL Then
            xmlhata = "PolicyPremiumTL TotalPremiumTL'dan büyük olamaz."
        End If

        'TARİHLERİ KONTROL ET ----------------------------------
        Dim fark_startend As Integer
        Dim StartDate, EndDate As DateTime
        StartDate = FirePolicy.StartDate
        EndDate = FirePolicy.EndDate

        fark_startend = EndDate.Subtract(StartDate).Days
        If fark_startend < 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = "Poliçenin başlangıç tarihi poliçenin bitiş tarihinden büyük olmamalıdır."
            root.ErrorInfo = ErrorInfo
            Return root
        End If
        '------------------------------------------------------

        'AgencyRegisterCode kontrolü
        Try
            Dim varmi As String = "Evet"
            varmi = acente_erisim.ciftkayitkontrol("sicilno", FirePolicy.AgencyRegisterCode)
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

        If FirePolicy.AgencyRegisterCode = "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 501
            ErrorInfo.Message = "Gönderilen XML de AgencyRegisterCode boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        Try
            acente = acente_erisim.bulsicilnogore(FirePolicy.AgencyRegisterCode)
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
        sirket = sirket_erisim.bultek_sirketkodagore(FirePolicy.FirmCode)
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
            ErrorInfo.Message = "'" + acente.acentead + "' adlı acente " + sirket.sirketad + " isimli " +
            "şirketin acentesi değildir."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'TPNo kontrol
        'TPNO'yu boş göndermiş.
        If FirePolicy.TPNo = "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 503
            ErrorInfo.Message = "Gönderilen XML de TPNo boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        Try
            personel = personel_erisim.bul_tpnogore(FirePolicy.TPNo, "Evet")
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



        'PolicyOwnerCountryCode veya Surname kontrolü
        If firePolicy.PolicyOwnerIdentityCode = "KN" Or firePolicy.PolicyOwnerIdentityCode = "PN" Then
            If firePolicy.PolicyOwnerCountryCode = "" Or firePolicy.PolicyOwnerIdentityNo = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 430
                ErrorInfo.Message = "Kimlik türü KN yada PN olan poliçelerde " +
                "PolicyOwnerCountryCode yada PolicyOwnerIdentityNo boş olamaz."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        'PolicyOwner
        If FirePolicy.PolicyOwnerCountryCode = "601" And FirePolicy.PolicyOwnerIdentityCode = "KN" Then
            If Trim(Len(FirePolicy.PolicyOwnerIdentityNo)) <> 6 And Trim(Len(FirePolicy.PolicyOwnerIdentityNo)) <> 10 Then
                root.ResultCode = 0
                ErrorInfo.Code = 801
                ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " +
                    "6 yada 10 rakamdan oluşmalıdır. PolicyOwnerIdentityNo"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If FirePolicy.PolicyOwnerCountryCode = "52" And FirePolicy.PolicyOwnerIdentityCode = "KN" Then
            If Trim(Len(FirePolicy.PolicyOwnerIdentityNo)) <> 11 Then
                root.ResultCode = 0
                ErrorInfo.Code = 801
                ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " +
                    "11 rakamdan oluşmalıdır. PolicyOwnerIdentityNo"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        'EXCHANGERATE KONTROLLERİ VE HESAPLAMALARI
        Dim firepremium_a As Decimal
        Dim totalpremium_a As Decimal
        Dim otherfees_a As Decimal
        Dim firepremium_down, firepremium_up As Decimal
        Dim totalpremium_down, totalpremium_up As Decimal
        Dim otherfees_down, otherfees_up As Decimal

        If FirePolicy.CurrencyCode = "TL" Then
            If FirePolicy.ExchangeRate <> 1 Then
                root.ResultCode = 0
                ErrorInfo.Code = 200
                ErrorInfo.Message = "Para birimi TL olan poliçelerde ExchangeRate 1 olmalıdır."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        firepremium_a = Math.Round(FirePolicy.FirePremium * FirePolicy.ExchangeRate, 2)
        firepremium_up = firepremium_a + 0.25
        firepremium_down = firepremium_a - 0.25
        If FirePolicy.FirePremiumTL > firepremium_up Or FirePolicy.FirePremiumTL < firepremium_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "FirePremiumTL yanlış çevrilmiş. " +
            "Gönderilmesi Gereken Değer: " + Format(firepremium_a, "0.00") + " veya " +
            Format(firepremium_down, "0.00") + " ve " + Format(firepremium_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        totalpremium_a = Math.Round(FirePolicy.TotalPremium * FirePolicy.ExchangeRate, 2)
        totalpremium_up = totalpremium_a + 0.25
        totalpremium_down = totalpremium_a - 0.25
        If FirePolicy.TotalPremiumTL > totalpremium_up Or FirePolicy.TotalPremiumTL < totalpremium_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "TotalPremiumTL yanlış çevrilmiş. " +
            "Gönderilmesi Gereken Değer: " + Format(totalpremium_a, "0.00") + " veya " +
            Format(totalpremium_down, "0.00") + " ve " + Format(totalpremium_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        otherfees_a = Math.Round(FirePolicy.OtherFees * FirePolicy.ExchangeRate, 2)
        otherfees_up = otherfees_a + 0.25
        otherfees_down = otherfees_a - 0.25
        If FirePolicy.OtherFeesTL > otherfees_up Or FirePolicy.OtherFeesTL < otherfees_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "OtherFeesTL yanlış çevrilmiş. " +
            "Gönderilmesi Gereken Değer: " + Format(otherfees_a, "0.00") + " veya " +
            Format(otherfees_down, "0.00") + " ve " + Format(otherfees_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        Dim adreskontrolresult As New CLADBOPRESULT
        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        adreskontrolresult = adrescore_erisim.adreskontrolugectimi(site, firePolicy.RiskAddress_ilcekod, firePolicy.RiskAddress_bucakkod,
        firePolicy.RiskAddress_belediyekod, firePolicy.RiskAddress_mahallekod,
        firePolicy.RiskAddress_sokakkod)
        If adreskontrolresult.durum = "Hayır" Then
            root.ResultCode = 0
            ErrorInfo.Code = 700
            ErrorInfo.Message = adreskontrolresult.hatastr
            root.ErrorInfo = ErrorInfo
            Return root
        End If




        'MANTIKSAL KONTROL ZEYİL SIRA KONTROL -----------------------
        Dim iptalsayisi As Integer = 0
        Dim ysayisi As Integer = 0
        Dim psayisi As Integer = 0
        Dim tsayisi As Integer = 0
        Dim kacadet As Integer = 0
        Dim varmi_aynisi As String = "Hayır"

        Dim sonzeyil As New FirePolicyInfo

        kacadet = firePolicyInfo_erisim.ciftkayitkontrol(FirePolicy.FirmCode, FirePolicy.ProductCode,
        FirePolicy.AgencyCode, FirePolicy.PolicyNumber, FirePolicy.TecditNumber, FirePolicy.ZeylCode,
        FirePolicy.ZeyilNo, FirePolicy.PolicyType)
        If kacadet > 0 Then
            varmi_aynisi = "Evet"
        End If

        sonzeyil = firePolicyInfo_erisim.sonzeyilbul(FirePolicy.FirmCode, FirePolicy.ProductCode, FirePolicy.AgencyCode,
        FirePolicy.PolicyNumber, FirePolicy.TecditNumber, FirePolicy.PolicyType)


        'YENİ BİR POLİCE İSE
        If varmi_aynisi = "Hayır" Then

            Dim arazeyilmi As String = "Hayır"
            If sonzeyil.FirmCode <> "" Then
                Try
                    Dim gelen_zeyilno, sonzeyil_zeylno As Integer
                    sonzeyil_zeylno = CInt(sonzeyil.ZeyilNo)
                    gelen_zeyilno = CInt(FirePolicy.ZeyilNo)

                    If gelen_zeyilno < sonzeyil_zeylno Then
                        arazeyilmi = "Evet"
                    End If
                Catch EX As Exception
                End Try
            End If

            If arazeyilmi = "Evet" Then
                If FirePolicy.ZeylCode = "X" Or FirePolicy.ZeylCode = "x" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 996
                    ErrorInfo.Message = "Gönderdiğiniz Zeyil numarası bu poliçenin " +
                    " son zeyilinden küçük olduğundan X zeyili gelemez."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

            If arazeyilmi = "Hayır" Then

                iptalsayisi = firePolicyInfo_erisim.policede_iptalzeyilikacadet(FirePolicy.FirmCode, FirePolicy.ProductCode,
                FirePolicy.AgencyCode, FirePolicy.PolicyNumber, FirePolicy.TecditNumber, FirePolicy.PolicyType)

                ysayisi = firePolicyInfo_erisim.policede_yzeyilikacadet(FirePolicy.FirmCode, FirePolicy.ProductCode,
                FirePolicy.AgencyCode, FirePolicy.PolicyNumber, FirePolicy.TecditNumber, FirePolicy.PolicyType)

                psayisi = firePolicyInfo_erisim.policede_pzeyilikacadet(FirePolicy.FirmCode, FirePolicy.ProductCode,
                FirePolicy.AgencyCode, FirePolicy.PolicyNumber, FirePolicy.TecditNumber, FirePolicy.PolicyType)

                tsayisi = firePolicyInfo_erisim.policede_tzeyilikacadet(FirePolicy.FirmCode, FirePolicy.ProductCode,
                FirePolicy.AgencyCode, FirePolicy.PolicyNumber, FirePolicy.TecditNumber, FirePolicy.PolicyType)


                If psayisi > 0 Then
                    If FirePolicy.ZeylCode = "p" Or FirePolicy.ZeylCode = "P" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "Ayni poliçeye birden fazla P gelemez."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If psayisi <= 0 And tsayisi <= 0 Then
                    If FirePolicy.ZeylCode = "v" Or FirePolicy.ZeylCode = "V" Or
                    FirePolicy.ZeylCode = "r" Or FirePolicy.ZeylCode = "R" Or
                    FirePolicy.ZeylCode = "x" Or FirePolicy.ZeylCode = "X" Or
                    FirePolicy.ZeylCode = "y" Or FirePolicy.ZeylCode = "Y" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "P yada T zeyili olmayan poliçeye V,R,X,Y zeyili gelemez."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If iptalsayisi > ysayisi Then
                    If FirePolicy.ZeylCode <> "y" And FirePolicy.ZeylCode <> "Y" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "İptali olan bir poliçeye iptal zeyilinden sonra ancak Y zeyili " +
                        "(Yürürlüğe Alma Zeyili) gelebilir"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If FirePolicy.ZeylCode = "y" Or FirePolicy.ZeylCode = "Y" Then
                    If iptalsayisi = 0 Or iptalsayisi < ysayisi Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "İptali olmayan bir poliçeye Y zeyili gelemez." +
                        " Y ancak X'den sonra gelebilir."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If 'ara zeyil Hayır



            'ZEYİL TARİH KONTROL
            If FirePolicy.ZeylCode = "V" Or FirePolicy.ZeylCode = "R" Or FirePolicy.ZeylCode = "X" Then
                'son zeyil var
                If sonzeyil.FirmCode <> "" Then
                    If sonzeyil.EndDate > FirePolicy.EndDate Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 996
                        ErrorInfo.Message = "Gönderdiğiniz zeyilin bitiş tarihi " +
                        CStr(sonzeyil.Contents) + " tarihinden büyük olmalıdır. Son Zeyil: " + CStr(sonzeyil.TecditNumber) + "-" + CStr(sonzeyil.ZeylCode)
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If

        End If 'YENİ BİR POLİÇE İSE



        'rengi bul
        If FirePolicy.ZeylCode = "P" Or FirePolicy.ZeylCode = "T" Then
            color = firePolicyInfo_erisim.renkbul(FirePolicy.FirmCode, FirePolicy.ProductCode, FirePolicy.AgencyCode, FirePolicy.PolicyNumber,
            FirePolicy.TecditNumber, FirePolicy.ZeylCode, FirePolicy.ZeyilNo, FirePolicy.PolicyType)
            FirePolicy.Color = color
            'color = "black"
        End If


        'KONTROLLER BİTTİ -------------------------------------------------------------------------------------------------




        'KAYIT YAPMA İŞLEMLERİ --------------------------------------------------------------------------------------------
        'yeni kayit
        If varmi_aynisi = "Hayır" Then

            'yeni kayıt olduğundan yeni bir SBMCODE üretiyoruz
            FSBMCode = firePolicyInfo_erisim.fsbmcodebul(FirePolicy)
            FirePolicy.FSBMCode = FSBMCode

            'yeni bir kayıt ve ayni zeyil numarasından varmı kontrol et.
            Dim aynimi As String
            aynimi = firePolicyInfo_erisim.zeyilnumarasi_aynimi(firePolicy.FirmCode, firePolicy.ProductCode,
            firePolicy.AgencyCode, firePolicy.PolicyNumber, firePolicy.TecditNumber, firePolicy.ZeyilNo,
            firePolicy.PolicyType)

            If aynimi = "Evet" Then
                root.ResultCode = 0
                ErrorInfo.Code = 994
                ErrorInfo.Message = "Bu poliçenin zeyilleri arasında ayni zeyil numarasına sahip zeyil " +
                "daha önce kaydedilmiş"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            resultset = firePolicyInfo_erisim.Ekle(firePolicy)
            If resultset.durum = "Kaydedildi" Then
                root.ResultCode = 1
                PolicyLoadResult.InsertedPolicyCount = 1
                PolicyLoadResult.UpdatedPolicyCount = 0
                PolicyLoadResult.SBMCode = FSBMCode
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
            Dim eskipolice As New FirePolicyInfo
            eskipolice = firePolicyInfo_erisim.bultek_pk(firePolicy.FirmCode, firePolicy.ProductCode, firePolicy.AgencyCode,
            firePolicy.PolicyNumber, firePolicy.TecditNumber, firePolicy.ZeylCode,
            firePolicy.ZeyilNo, firePolicy.PolicyType)

            firePolicy.FSBMCode = eskipolice.FSBMCode
            firePolicy.pkey = eskipolice.pkey
            resultset = firePolicyInfo_erisim.Duzenle(FirePolicy)
            If resultset.durum = "Kaydedildi" Then
                root.ResultCode = 1
                PolicyLoadResult.InsertedPolicyCount = 0
                PolicyLoadResult.UpdatedPolicyCount = 1
                PolicyLoadResult.SBMCode = firePolicy.FSBMCode
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
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "LoadFirePolicy",
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, PolicyLoadResult.InsertedPolicyCount,
        PolicyLoadResult.UpdatedPolicyCount, firePolicy.FirmCode, firePolicy.ProductCode,
        firePolicy.AgencyCode, firePolicy.PolicyNumber, firePolicy.TecditNumber, firePolicy.ZeylCode,
        firePolicy.ZeyilNo, firePolicy.PolicyType, firePolicy.FirmCode, "0", "0", "0",
        "0", "0", "0", "0", firexml, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        Return root

    End Function




End Class
