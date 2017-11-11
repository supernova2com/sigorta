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

Public Class DamageInfoService_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull
    Dim getdamagelog As String
    Dim ip_erisim As New CLASSIP_ERISIM
    Dim DamageInfo_erisim As New DamageInfo_Erisim
    Dim kimlikplakapolicehasar_erisim As New CLASSKIMLIKPLAKAPOLICEHASAR_ERISIM
    Dim damageinfoservicekontrol_erisim As New DamageInfoServiceKontrol_Erisim




    '------------------------------EKLE-------------------------------------------
    Public Function eklexml(ByVal wskullaniciad As String, _
    ByVal wssifre As String, _
    ByVal damagexml As String) As root


        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM
        Dim core_erisim As New CLASSCORE_ERISIM

        Dim SBMCode As String
        Dim girdisayisi As Integer = 0

        Dim DamageInfo As New DamageInfo
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
            ErrorInfo.Message = "Yetkisiz. Girdiğiniz kullanıcı adı ve şifre" + _
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

        'damagexml normalize---
        damagexml = Replace(damagexml, "&", "-")

        Try
            XmlDoc.Load(New StringReader(damagexml))
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de hatalar var." + ex.Message
            root.ResultCode = 0
            ErrorInfo.Code = 998
            ErrorInfo.Message = ex.Message
            root.ErrorInfo = ErrorInfo
            Return root
        End Try

        Dim FirmCode_girdimi, ProductCode_girdimi, AgencyCode_girdimi As String
        Dim PolicyNumber_girdimi, TecditNumber_girdimi, FileNo_girdimi As String
        Dim RequestNo_girdimi, DriverPlateCountryCode_girdimi, DriverPlateNumber_girdimi As String
        Dim AccidentDate_girdimi As String, AccidentLocation_girdimi, InformingDate_girdimi As String
        Dim DriverCountryCode_girdimi, DriverIdentityCode_girdimi, DriverIdentityNo_girdimi As String
        Dim DriverName_girdimi As String, DriverSurname_girdimi, ClaimantCountryCode_girdimi As String
        Dim ClaimantIdentityCode_girdimi, ClaimantIdentityNo_girdimi, ClaimantName_girdimi As String
        Dim ClaimantSurname_girdimi, AppealDate_girdimi, ClaimantPlateCountryCode_girdimi As String
        Dim ClaimantPlateNumber_girdimi, ExchangeRate_girdimi As String
        Dim DamageReason_girdimi As String
        Dim DamageStatusCode_girdimi As String
        Dim EstimatedMaterialDamage_girdimi As String
        Dim PaidMaterialDamage_girdimi As String
        Dim CloseDate_girdimi As String
        Dim EstimatedCorporalDamage_girdimi As String
        Dim PaidCorporalDamage_girdimi As String
        Dim TotalLost_girdimi As String
        'Dim TariffCode_girdimi As String
        Dim CurrencyCode_girdimi As String
        Dim EstimatedMaterialAmountTL_girdimi As String
        Dim PaidMaterialAmountTL_girdimi As String
        Dim EstimatedCorporalAmountTL_girdimi As String
        Dim PaidCorporalAmountTL_girdimi As String
        Dim ProductType_girdimi As String
        'Dim SBMCode_girdimi As String
        'Dim AgencyRegisterCode_girdimi as string
        Dim TPNo_girdimi As String


        FirmCode_girdimi = "Hayır"
        ProductCode_girdimi = "Hayır"
        AgencyCode_girdimi = "Hayır"
        PolicyNumber_girdimi = "Hayır"
        TecditNumber_girdimi = "Hayır"
        FileNo_girdimi = "Hayır"
        RequestNo_girdimi = "Hayır"
        DriverPlateCountryCode_girdimi = "Hayır"
        DriverPlateNumber_girdimi = "Hayır"
        AccidentDate_girdimi = "Hayır"
        AccidentLocation_girdimi = "Hayır"
        InformingDate_girdimi = "Hayır"
        DriverCountryCode_girdimi = "Hayır"
        DriverIdentityCode_girdimi = "Hayır"
        DriverIdentityNo_girdimi = "Hayır"
        DriverName_girdimi = "Hayır"
        DriverSurname_girdimi = "Hayır"
        ClaimantCountryCode_girdimi = "Hayır"
        ClaimantIdentityCode_girdimi = "Hayır"
        ClaimantIdentityNo_girdimi = "Hayır"
        ClaimantName_girdimi = "Hayır"
        ClaimantSurname_girdimi = "Hayır"
        AppealDate_girdimi = "Hayır"
        ClaimantPlateCountryCode_girdimi = "Hayır"
        ClaimantPlateNumber_girdimi = "Hayır"
        DamageReason_girdimi = "Hayır"
        DamageStatusCode_girdimi = "Hayır"
        EstimatedMaterialDamage_girdimi = "Hayır"
        PaidMaterialDamage_girdimi = "Hayır"
        CloseDate_girdimi = "Hayır"
        EstimatedCorporalDamage_girdimi = "Hayır"
        PaidCorporalDamage_girdimi = "Hayır"
        TotalLost_girdimi = "Hayır"
        'TariffCode_girdimi = "Hayır"
        CurrencyCode_girdimi = "Hayır"
        EstimatedMaterialAmountTL_girdimi = "Hayır"
        PaidMaterialAmountTL_girdimi = "Hayır"
        EstimatedCorporalAmountTL_girdimi = "Hayır"
        PaidCorporalAmountTL_girdimi = "Hayır"
        ProductType_girdimi = "Hayır"
        'SBMCode_girdimi = "Hayır"
        ExchangeRate_girdimi = "Hayır"
        'AgencyRegisterCode_girdimi="Hayır"
        TPNo_girdimi = "Hayır"


        For Each Element As XmlElement In XmlDoc.SelectNodes("//*")

            'debugy = debugy + Element.Name + "<br/>"
            For Each Attribute As XmlAttribute In Element.Attributes

                'FirmCode 1
                If Attribute.Name = "FirmCode" Then
                    girdisayisi = girdisayisi + 1
                    FirmCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        DamageInfo.FirmCode = Trim(Attribute.Value)
                        If sirket.sirketkod <> Attribute.Value Then
                            xmlhata = "Gönderdiğiniz XML'deki FirmCode " + _
                            "ile giriş yaptığınız kullanıcı adı ve şifre ile" + _
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
                            DamageInfo.ProductCode = Attribute.Value
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
                        DamageInfo.AgencyCode = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                    If DamageInfo.AgencyCode = "" Then
                        xmlhata = "Gönderilen XML'de AgencyCode boş olamaz."
                    End If
                End If

                'PolicyNumber 4
                If Attribute.Name = "PolicyNumber" Then
                    girdisayisi = girdisayisi + 1
                    PolicyNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        DamageInfo.PolicyNumber = Attribute.Value
                    Else
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                    If DamageInfo.PolicyNumber = "" Then
                        xmlhata = "Gönderilen XML'de PolicyNumber boş olamaz."
                    End If
                End If


                'TecditNumber 5
                If Attribute.Name = "TecditNumber" Then
                    girdisayisi = girdisayisi + 1
                    TecditNumber_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        DamageInfo.TecditNumber = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                    If DamageInfo.TecditNumber = "" Then
                        xmlhata = "Gönderilen XML'de TecditNumber boş olamaz."
                    End If
                End If

                'FileNo 6
                If Attribute.Name = "FileNo" Then
                    girdisayisi = girdisayisi + 1
                    FileNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        DamageInfo.FileNo = Attribute.Value
                    Else
                        xmlhata = "Gönderilen XML'de FileNo boş olamaz."
                    End If
                    If DamageInfo.FileNo = "" Then
                        xmlhata = "Gönderilen XML'de FileNo boş olamaz."
                    End If
                End If

                'RequestNo 7
                If Attribute.Name = "RequestNo" Then
                    girdisayisi = girdisayisi + 1
                    RequestNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        DamageInfo.RequestNo = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de RequestNo boş olamaz."
                    End If
                    If DamageInfo.RequestNo = "" Then
                        xmlhata = "Gönderilen XML'de RequestNo boş olamaz."
                    End If

                End If

                'DriverPlateCountryCode 8
                If Attribute.Name = "DriverPlateCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    DriverPlateCountryCode_girdimi = "Evet"
                    DamageInfo.DriverPlateCountryCode = Attribute.Value
                End If

                'DriverPlateNumber 9
                If Attribute.Name = "DriverPlateNumber" Then
                    girdisayisi = girdisayisi + 1
                    DriverPlateNumber_girdimi = "Evet"
                    Try
                        DamageInfo.DriverPlateNumber = Replace(Trim(UCase(Attribute.Value)), " ", "")
                    Catch ex As Exception
                    End Try
                End If


                'AccidentDate 10
                If Attribute.Name = "AccidentDate" Then
                    girdisayisi = girdisayisi + 1
                    AccidentDate_girdimi = "Evet"
                    Try
                        DamageInfo.AccidentDate = Attribute.Value
                        If DamageInfo.AccidentDate > Date.Now Then
                            xmlhata = "Kaza tarihi şimdiki tarihten büyük olmamalıdır."
                        End If
                    Catch
                        DamageInfo.AccidentDate = Nothing
                        xmlhata = "Kaza tarihi (AccidentDate) geçerli bir tarih değildir."
                    End Try
                End If

                'AccidentLocation 11
                If Attribute.Name = "AccidentLocation" Then
                    girdisayisi = girdisayisi + 1
                    AccidentLocation_girdimi = "Evet"
                    DamageInfo.AccidentLocation = Attribute.Value
                End If

                'InformingDate 12
                If Attribute.Name = "InformingDate" Then
                    girdisayisi = girdisayisi + 1
                    InformingDate_girdimi = "Evet"
                    Try
                        DamageInfo.InformingDate = Attribute.Value
                    Catch
                        DamageInfo.InformingDate = Nothing
                        xmlhata = "Kaza bildirim tarihi (InformingDate) geçerli bir tarih değildir."
                    End Try
                End If


                'DriverCountryCode 13
                If Attribute.Name = "DriverCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    DriverIdentityCode_girdimi = "Evet"
                    DriverCountryCode_girdimi = "Evet"
                    DamageInfo.DriverCountryCode = Attribute.Value
                End If

                'DriverIdentityCode 14
                If Attribute.Name = "DriverIdentityCode" Then
                    girdisayisi = girdisayisi + 1
                    DriverIdentityNo_girdimi = "Evet"
                    DamageInfo.DriverIdentityCode = Attribute.Value
                End If


                'DriverIdentityNo buraya kontrol ekle boş gönderemesin... 15
                If Attribute.Name = "DriverIdentityNo" Then
                    girdisayisi = girdisayisi + 1
                    DriverIdentityNo_girdimi = "Evet"
                    DamageInfo.DriverIdentityNo = Attribute.Value
                End If

                'DriverName 16
                If Attribute.Name = "DriverName" Then
                    girdisayisi = girdisayisi + 1
                    DriverName_girdimi = "Evet"
                    DamageInfo.DriverName = Attribute.Value
                End If


                'DriverSurname 17
                If Attribute.Name = "DriverSurname" Then
                    girdisayisi = girdisayisi + 1
                    DriverSurname_girdimi = "Evet"
                    DamageInfo.DriverSurname = Attribute.Value
                End If

                'ClaimantCountryCode 18
                If Attribute.Name = "ClaimantCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantCountryCode_girdimi = "Evet"
                    DamageInfo.ClaimantCountryCode = Attribute.Value
                End If

                'ClaimantIdentityCode 19
                If Attribute.Name = "ClaimantIdentityCode" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantIdentityCode_girdimi = "Evet"
                    DamageInfo.ClaimantIdentityCode = Attribute.Value
                End If

                'ClaimantIdentityNo 20
                If Attribute.Name = "ClaimantIdentityNo" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantIdentityNo_girdimi = "Evet"
                    DamageInfo.ClaimantIdentityNo = Attribute.Value
                End If


                'ClaimantName 21
                If Attribute.Name = "ClaimantName" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantName_girdimi = "Evet"
                    DamageInfo.ClaimantName = Attribute.Value
                End If

                'ClaimantSurname 22
                If Attribute.Name = "ClaimantSurname" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantSurname_girdimi = "Evet"
                    DamageInfo.ClaimantSurname = Attribute.Value
                End If

                'AppealDate 23
                If Attribute.Name = "AppealDate" Then
                    girdisayisi = girdisayisi + 1
                    AppealDate_girdimi = "Evet"
                    Try
                        DamageInfo.AppealDate = Attribute.Value
                    Catch
                        DamageInfo.AppealDate = Nothing
                    End Try
                End If

                'ClaimantPlateCountryCode 24
                If Attribute.Name = "ClaimantPlateCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantPlateCountryCode_girdimi = "Evet"
                    DamageInfo.ClaimantPlateCountryCode = Attribute.Value
                End If

                'ClaimantPlateNumber 25
                If Attribute.Name = "ClaimantPlateNumber" Then
                    girdisayisi = girdisayisi + 1
                    ClaimantPlateNumber_girdimi = "Evet"
                    Try
                        DamageInfo.ClaimantPlateNumber = Replace(Trim(UCase(Attribute.Value)), " ", "")
                    Catch ex As Exception
                    End Try
                End If

                'DamageReason 26
                If Attribute.Name = "DamageReason" Then
                    girdisayisi = girdisayisi + 1
                    DamageReason_girdimi = "Evet"
                    DamageInfo.DamageReason = Attribute.Value
                End If


                'DamageStatusCode 27
                If Attribute.Name = "DamageStatusCode" Then
                    girdisayisi = girdisayisi + 1
                    DamageStatusCode_girdimi = "Evet"
                    DamageInfo.DamageStatusCode = Attribute.Value
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


                'EstimatedMaterialDamage 28
                If Attribute.Name = "EstimatedMaterialDamage" Then
                    girdisayisi = girdisayisi + 1
                    EstimatedMaterialDamage_girdimi = "Evet"
                    Try
                        DamageInfo.EstimatedMaterialDamage = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.EstimatedMaterialDamage = 0
                    End Try
                End If

                'PaidMaterialDamage 29
                If Attribute.Name = "PaidMaterialDamage" Then
                    girdisayisi = girdisayisi + 1
                    PaidMaterialDamage_girdimi = "Evet"
                    Try
                        DamageInfo.PaidMaterialDamage = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.PaidMaterialDamage = 0
                    End Try
                End If

                'CloseDate 30
                If Attribute.Name = "CloseDate" Then
                    girdisayisi = girdisayisi + 1
                    CloseDate_girdimi = "Evet"
                    Try
                        DamageInfo.CloseDate = Attribute.Value
                    Catch
                        DamageInfo.CloseDate = Nothing
                    End Try
                End If


                'EstimatedCorporalDamage 31
                If Attribute.Name = "EstimatedCorporalDamage" Then
                    girdisayisi = girdisayisi + 1
                    EstimatedCorporalDamage_girdimi = "Evet"
                    Try
                        DamageInfo.EstimatedCorporalDamage = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.EstimatedCorporalDamage = 0
                    End Try
                End If

                'PaidCorporalDamage 32
                If Attribute.Name = "PaidCorporalDamage" Then
                    girdisayisi = girdisayisi + 1
                    PaidCorporalDamage_girdimi = "Evet"
                    Try
                        DamageInfo.PaidCorporalDamage = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.PaidCorporalDamage = 0
                    End Try
                End If


                'TotalLost 33
                If Attribute.Name = "TotalLost" Then
                    girdisayisi = girdisayisi + 1
                    TotalLost_girdimi = "Evet"
                    Try
                        DamageInfo.TotalLost = Attribute.Value
                        If DamageInfo.TotalLost <> "0" And DamageInfo.TotalLost <> "1" Then
                            xmlhata = "Gönderilen XML'de TotalLost 0 yada 1 gönderilmeli."
                        End If
                    Catch
                        DamageInfo.TotalLost = "0"
                    End Try
                End If


                'CurrencyCode 34
                If Attribute.Name = "CurrencyCode" Then
                    girdisayisi = girdisayisi + 1
                    CurrencyCode_girdimi = "Evet"
                    Try
                        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM
                        Dim varmi = "Evet"
                        DamageInfo.CurrencyCode = Attribute.Value
                        varmi = currencycode_erisim.currencycodevarmi(DamageInfo.CurrencyCode)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de CurrencyCode olmalı ve KKSBM tarafından tanımlanmış olmalıdır."
                    End Try
                End If


                'EstimatedMaterialAmountTL 35
                If Attribute.Name = "EstimatedMaterialAmountTL" Then
                    girdisayisi = girdisayisi + 1
                    EstimatedMaterialAmountTL_girdimi = "Evet"
                    Try
                        DamageInfo.EstimatedMaterialAmountTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.EstimatedMaterialAmountTL = 0
                    End Try
                End If

                'PaidMaterialAmountTL 36
                If Attribute.Name = "PaidMaterialAmountTL" Then
                    girdisayisi = girdisayisi + 1
                    PaidMaterialAmountTL_girdimi = "Evet"
                    Try
                        DamageInfo.PaidMaterialAmountTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.PaidMaterialAmountTL = 0
                    End Try
                End If

                'EstimatedCorporalAmountTL 37
                If Attribute.Name = "EstimatedCorporalAmountTL" Then
                    girdisayisi = girdisayisi + 1
                    EstimatedCorporalAmountTL_girdimi = "Evet"
                    Try
                        DamageInfo.EstimatedCorporalAmountTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.EstimatedCorporalAmountTL = 0
                    End Try
                End If

                'PaidCorporalAmountTL 38
                If Attribute.Name = "PaidCorporalAmountTL" Then
                    girdisayisi = girdisayisi + 1
                    PaidCorporalAmountTL_girdimi = "Evet"
                    Try
                        DamageInfo.PaidCorporalAmountTL = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.PaidCorporalAmountTL = 0
                    End Try
                End If


                'ProductType 39
                If Attribute.Name = "ProductType" Then
                    girdisayisi = girdisayisi + 1
                    ProductType_girdimi = "Evet"
                    DamageInfo.ProductType = Attribute.Value
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de ProductType  boş olamaz."
                    End If
                End If


                'ExchangeRate 40
                If Attribute.Name = "ExchangeRate" Then
                    girdisayisi = girdisayisi + 1
                    ExchangeRate_girdimi = "Evet"
                    Try
                        DamageInfo.ExchangeRate = CDec(Attribute.Value)
                    Catch ex As Exception
                        DamageInfo.ExchangeRate = 0
                    End Try
                End If


                'TPNo 41
                If Attribute.Name = "TPNo" Then
                    girdisayisi = girdisayisi + 1
                    TPNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            DamageInfo.TPNo = Trim(Attribute.Value)
                            varmi = personel_erisim.ciftkayitkontrol("tpno", DamageInfo.TPNo)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                        End Try
                    End If
                    If Attribute.Value = "" Then
                        DamageInfo.TPNo = ""
                    End If
                End If


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
        If FileNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FileNo" + "-"
        End If
        If RequestNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "RequestNo" + "-"
        End If
        If DriverPlateCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverPlateCountryCode" + "-"
        End If
        If DriverPlateNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverPlateNumber" + "-"
        End If
        If AccidentDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AccidentDate" + "-"
        End If
        If AccidentLocation_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AccidentLocation" + "-"
        End If
        If InformingDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "InformingDate" + "-"
        End If
        If DriverCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverCountryCode" + "-"
        End If
        If DriverIdentityCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverIdentityCode" + "-"
        End If
        If DriverIdentityNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverIdentityNo" + "-"
        End If
        If DriverName_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverName" + "-"
        End If
        If DriverSurname_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DriverSurname" + "-"
        End If
        If ClaimantCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantCountryCode" + "-"
        End If
        If ClaimantIdentityCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantIdentityCode" + "-"
        End If
        If ClaimantIdentityNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantIdentityNo" + "-"
        End If
        If ClaimantName_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantName" + "-"
        End If
        If ClaimantSurname_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantSurname" + "-"
        End If
        If AppealDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AppealDate" + "-"
        End If
        If ClaimantPlateCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantPlateCountryCode" + "-"
        End If
        If ClaimantPlateNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ClaimantPlateNumber" + "-"
        End If
        If DamageReason_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamageReason" + "-"
        End If
        If DamageStatusCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "DamageStatusCode" + "-"
        End If
        If EstimatedMaterialDamage_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EstimatedMaterialDamage" + "-"
        End If
        If PaidMaterialDamage_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PaidMaterialDamage" + "-"
        End If
        If CloseDate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CloseDate" + "-"
        End If
        If EstimatedCorporalDamage_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EstimatedCorporalDamage" + "-"
        End If
        If PaidCorporalDamage_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PaidCorporalDamage" + "-"
        End If
        If TotalLost_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TotalLost" + "-"
        End If
        'TariffCode_girdimi = "Hayır"
        If CurrencyCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CurrencyCode" + "-"
        End If
        If EstimatedMaterialAmountTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EstimatedMaterialAmountTL" + "-"
        End If
        If PaidMaterialAmountTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PaidMaterialAmountTL" + "-"
        End If
        If EstimatedCorporalAmountTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EstimatedCorporalAmountTL" + "-"
        End If
        If PaidCorporalAmountTL_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PaidCorporalAmountTL" + "-"
        End If
        If ProductType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductType" + "-"
        End If
        If ExchangeRate_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ExchangeRate" + "-"
        End If
        If TPNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TPNo" + "-"
        End If


        'ProductType kontrolü yap
        Try
            Dim varmi As String
            Dim producttype_erisim As New CLASSPRODUCTTYPE_ERISIM
            Dim urunkod As New CLASSURUNKOD
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
            urunkod = urunkod_erisim.bultek_kodagore(DamageInfo.ProductCode)
            varmi = producttype_erisim.ciftkayitkontrol(urunkod.pkey, DamageInfo.ProductType)
            If varmi = "Hayır" Then
                xmlhata = "Gönderilen XML'de ProductType KKSBM tarafından tanımlanmamış."
            End If
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de ProductType KKSBM tarafından tanımlanmamış."
        End Try


        'xmlde hata var mı kontrol et
        If xmlhata <> "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = xmlhata
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'xml gönderilen attribute eksik mi kontrol et
        If girdisayisi <> 41 Then
            root.ResultCode = 0
            ErrorInfo.Code = 99
            ErrorInfo.Message = "Gönderdiğiniz XML'de bazı alanlar eksik yada fazladır." + _
            "Toplam xml node sayısı 41 olması gerekirken siz " + CStr(girdisayisi) + " alan gönderdiniz. " + _
            girilmeyenstr
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'boş olmaması gerekenleri kontrol et
        If DamageInfo.FirmCode = Nothing Or DamageInfo.ProductCode = Nothing Or _
        DamageInfo.AgencyCode = Nothing Or DamageInfo.PolicyNumber = Nothing Or _
        DamageInfo.TecditNumber = Nothing Or DamageInfo.FileNo = Nothing Or _
        DamageInfo.RequestNo = Nothing Or DamageInfo.ProductType = Nothing Then
            root.ResultCode = 0
            ErrorInfo.Code = 997
            ErrorInfo.Message = "Gönderdiğiniz XML'de FirmCode, ProductCode," + _
            " AgencyCode, PolicyNumber,TecditNumber, FileNo, RequestNo, ProductType boş olamaz."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'Plaka Kontrol 
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim
        Dim plakaresult As New CLADBOPRESULT
        plakaresult = plakakontrol_erisim.plakakontrolbasit(DamageInfo.TariffCode, DamageInfo.DriverPlateNumber)
        If plakaresult.durum = "Hata Var" Then
            root.ResultCode = 0
            ErrorInfo.Code = 500
            ErrorInfo.Message = plakaresult.hatastr
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'SORU İŞARETİ KONTROL
        If InStr(damagexml, "?", CompareMethod.Text) > 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 333
            ErrorInfo.Message = "Gönderdiğiniz XML'in hiçbir yerinde ? (soru işareti) karakteri olmamalıdır."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        'TPNo kontrol
        If DamageInfo.AccidentDate > "05.04.2016" Then

            If DamageInfo.TPNo = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 503
                ErrorInfo.Message = "Gönderilen XML de TPNo boş olamaz."
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            personel = personel_erisim.bul_tpnogore(DamageInfo.TPNo, "Evet")
            If personel.pkey = 0 Then
                root.ResultCode = 0
                ErrorInfo.Code = 503
                ErrorInfo.Message = "Gönderdiğiniz TPNo teknik personel değildir."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)


        'kombinasyonkontrol 
        Dim kombinasyonroot As New root
        kombinasyonroot = damageinfoservicekontrol_erisim.kombinasyonkontrol(servisayar, DamageInfo)
        If kombinasyonroot.ResultCode = 0 Then
            root.ResultCode = kombinasyonroot.ResultCode
            root.ErrorInfo = kombinasyonroot.ErrorInfo
            Return root
        End If

        'DriverIdentityCode kontrolu
        Dim kimliktur_erisim As New CLASSKIMLIKTUR_ERISIM

        If DamageInfo.DriverIdentityCode <> "" Then
            If kimliktur_erisim.kimlikturkodvarmi(DamageInfo.DriverIdentityCode) <> "Evet" Then
                root.ResultCode = 0
                ErrorInfo.Code = 700
                ErrorInfo.Message = "DriverIdentityCode KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If DamageInfo.ClaimantIdentityCode <> "" Then
            If kimliktur_erisim.kimlikturkodvarmi(DamageInfo.ClaimantIdentityCode) <> "Evet" Then
                root.ResultCode = 0
                ErrorInfo.Code = 700
                ErrorInfo.Message = "ClaimantIdentityCode KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If



        'bu kontrolleri sadece kaza tarihi 01.03.2014 tarihinden büyük olanlar için uygula
        If DamageInfo.AccidentDate > "01.03.2014" Then

            'mantıksal kontrolleri yap 
            If DamageInfo.DriverCountryCode = "601" And DamageInfo.DriverIdentityCode = "KN" Then
                If Trim(Len(DamageInfo.DriverIdentityNo)) <> 6 And Trim(Len(DamageInfo.DriverIdentityNo)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. DriverIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If DamageInfo.DriverCountryCode = "52" And DamageInfo.DriverIdentityCode = "KN" Then
                If Trim(Len(DamageInfo.DriverIdentityNo)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. DriverIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If DamageInfo.ClaimantCountryCode = "601" And DamageInfo.ClaimantIdentityCode = "KN" Then
                If Trim(Len(DamageInfo.ClaimantIdentityNo)) <> 6 And Trim(Len(DamageInfo.ClaimantIdentityNo)) <> 10 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "6 yada 10 rakamdan oluşmalıdır. ClaimantIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If DamageInfo.ClaimantCountryCode = "52" And DamageInfo.ClaimantIdentityCode = "KN" Then
                If Trim(Len(DamageInfo.ClaimantIdentityNo)) <> 11 Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 801
                    ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan kayıtlarda kimlik numarası " + _
                    "11 rakamdan oluşmalıdır. ClaimantIdentityNo"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'MŞ YŞ UŞ KONTROLÜ
            If DamageInfo.DriverCountryCode = "601" Then
                If DamageInfo.DriverIdentityCode = "MŞ" Or DamageInfo.DriverIdentityCode = "YŞ" _
                Or DamageInfo.DriverIdentityCode = "UŞ" Then
                    If Len(DamageInfo.DriverIdentityNo) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. DriverIdentityNo"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If
            If DamageInfo.ClaimantCountryCode = "601" Then
                If DamageInfo.ClaimantIdentityCode = "MŞ" Or DamageInfo.ClaimantIdentityCode = "YŞ" _
                Or DamageInfo.ClaimantIdentityCode = "UŞ" Then
                    If Len(DamageInfo.ClaimantIdentityNo) > 5 Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 802
                        ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü MŞ, YŞ veya UŞ olan kayıtlarda" + _
                        " kimlik numarası en fazla 5 rakamdan oluşmalıdır. ClaimantIdentityNo"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If
            End If

        End If


        'EXCHANGERATE KONTROLLERİ VE HESAPLAMALARI
        If DamageInfo.CurrencyCode = "TL" Then
            If DamageInfo.ExchangeRate <> 1 Then
                root.ResultCode = 0
                ErrorInfo.Code = 200
                ErrorInfo.Message = "Para birimi TL olan hasarlarda ExchangeRate 1 olmalıdır."
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If

        Dim estimatedmaterialdamage_a As Decimal
        Dim paidcorporaldamage_a As Decimal
        Dim paidmaterialdamage_a As Decimal
        Dim estimatedcorporaldamage_a As Decimal
        Dim estimatedmaterialdamage_up, estimatedmaterialdamage_down As Decimal
        Dim paidcorporaldamage_up, paidcorporaldamage_down As Decimal
        Dim paidmaterialdamage_up, paidmaterialdamage_down As Decimal
        Dim estimatedcorporaldamage_up, estimatedcorporaldamage_down As Decimal


        estimatedmaterialdamage_a = Math.Round(DamageInfo.EstimatedMaterialDamage * DamageInfo.ExchangeRate, 2)
        estimatedmaterialdamage_up = estimatedmaterialdamage_a + 0.5
        estimatedmaterialdamage_down = estimatedmaterialdamage_a - 0.5
        If DamageInfo.EstimatedMaterialAmountTL > estimatedmaterialdamage_up Or DamageInfo.EstimatedMaterialAmountTL < estimatedmaterialdamage_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "EstimatedMaterialAmountTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(estimatedmaterialdamage_a, "0.00") + " veya " + _
            Format(estimatedmaterialdamage_down, "0.00") + " ve " + Format(estimatedmaterialdamage_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        paidcorporaldamage_a = Math.Round(DamageInfo.PaidCorporalDamage * DamageInfo.ExchangeRate, 2)
        paidcorporaldamage_up = paidcorporaldamage_a + 0.5
        paidcorporaldamage_down = paidcorporaldamage_a - 0.5
        If DamageInfo.PaidCorporalAmountTL > paidcorporaldamage_up Or DamageInfo.PaidCorporalAmountTL < paidcorporaldamage_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "PaidCorporalAmountTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(paidcorporaldamage_a, "0.00") + " veya " + _
            Format(paidcorporaldamage_down, "0.00") + " ve " + Format(paidcorporaldamage_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        paidmaterialdamage_a = Math.Round(DamageInfo.PaidMaterialDamage * DamageInfo.ExchangeRate, 2)
        paidmaterialdamage_up = paidmaterialdamage_a + 0.5
        paidmaterialdamage_down = paidmaterialdamage_a - 0.5
        If DamageInfo.PaidMaterialAmountTL > paidmaterialdamage_up Or DamageInfo.PaidMaterialAmountTL < paidmaterialdamage_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "PaidMaterialAmountTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(paidmaterialdamage_a, "0.00") + " veya " + _
            Format(paidmaterialdamage_down, "0.00") + " ve " + Format(paidmaterialdamage_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If

        estimatedcorporaldamage_a = Math.Round(DamageInfo.EstimatedCorporalDamage * DamageInfo.ExchangeRate, 2)
        estimatedcorporaldamage_up = estimatedcorporaldamage_a + 0.5
        estimatedcorporaldamage_down = estimatedcorporaldamage_a - 0.5
        If DamageInfo.EstimatedCorporalAmountTL > estimatedcorporaldamage_up Or DamageInfo.EstimatedCorporalAmountTL < estimatedcorporaldamage_down Then
            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "EstimatedCorporalAmountTL yanlış çevrilmiş. " + _
            "Gönderilmesi Gereken Değer: " + Format(estimatedcorporaldamage_a, "0.00") + " veya " + _
            Format(estimatedcorporaldamage_down, "0.00") + " ve " + Format(estimatedcorporaldamage_up, "0.00") + " arası olmalı."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'kontrol et bakalım bu hasarın poliçesi var mı?
        Dim policyinfo_erisim As New PolicyInfo_Erisim
        Dim hasarinpoliceleri As New List(Of PolicyInfo)
        hasarinpoliceleri = policyinfo_erisim.policedoldur_ilgilihasar(DamageInfo.FirmCode, _
        DamageInfo.ProductCode, DamageInfo.AgencyCode, DamageInfo.PolicyNumber, _
        DamageInfo.TecditNumber, DamageInfo.ProductType)
        If hasarinpoliceleri.Count = 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 98
            ErrorInfo.Message = "Gönderdiğiniz Hasarın bağlı olduğu bir poliçe sisteme daha " + _
            "önceden kaydedilmemiş."
            root.ErrorInfo = ErrorInfo
            Return root
        End If


        'TariffCode ve CurrencyCode ve AgencyRegisterCode ve PolicyType'i bağlı olduğu poliçeden al
        For Each policeitem As PolicyInfo In hasarinpoliceleri
            DamageInfo.TariffCode = policeitem.TariffCode
            DamageInfo.CurrencyCode = policeitem.CurrencyCode
            DamageInfo.AgencyRegisterCode = policeitem.AgencyRegisterCode
            DamageInfo.PolicyType = policeitem.PolicyType
            Exit For
        Next


        'eğer xml'de hata yoksa 
        If xmlhata = "" Then

            'kontrol et bu kayit varmi.
            Dim varmi As String

            varmi = DamageInfo_erisim.ciftkayitkontrol(DamageInfo.FirmCode, DamageInfo.ProductCode, _
            DamageInfo.FileNo, DamageInfo.RequestNo, DamageInfo.ProductType)


            'yeni kayit
            If varmi = "Hayır" Then
                'yeni kayıt olduğundan yeni bir SBMCode üret
                SBMCode = sbmcodebul(DamageInfo)
                DamageInfo.SBMCode = SBMCode

                resultset = DamageInfo_erisim.Ekle(DamageInfo)
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
                Dim eskidamageinfo As New DamageInfo
                eskidamageinfo = DamageInfo_erisim.bultek(DamageInfo.FirmCode, DamageInfo.ProductCode, DamageInfo.FileNo, _
                DamageInfo.RequestNo, DamageInfo.ProductType)

                DamageInfo.SBMCode = eskidamageinfo.SBMCode
                resultset = DamageInfo_erisim.Duzenle(DamageInfo)
                If resultset.durum = "Kaydedildi" Then
                    root.ResultCode = 1
                    DamageLoadResult.InsertedDamageCount = 0
                    DamageLoadResult.UpdatedDamageCount = 1
                    DamageLoadResult.SBMCode = DamageInfo.SBMCode
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
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "LoadDamageInformation", _
        root.ResultCode, 0, "0", DamageLoadResult.InsertedDamageCount, _
        DamageLoadResult.UpdatedDamageCount, "0", "0", _
        "0", "0", "0", "0", _
        "0", "0", DamageInfo.FirmCode, DamageInfo.ProductCode, DamageInfo.AgencyCode, DamageInfo.PolicyNumber, _
        DamageInfo.TecditNumber, DamageInfo.FileNo, DamageInfo.RequestNo, DamageInfo.ProductType, damagexml, _
        wskullaniciad, wssifre, "Hayır", 0, "", "", "", ip_erisim.ipadresibul))

        Return root

    End Function


    Public Function sbmcodebul(ByVal DamageInfo As DamageInfo) As String

        Dim nn As String = ""
        Dim kacadet As Integer
        Dim kacadetstr As String
        kacadet = hasaradet_sirketin(DamageInfo.FirmCode)
        kacadetstr = CStr(kacadet)

        Dim donecek As String
        donecek = "MH" + DamageInfo.FirmCode + DamageInfo.ProductCode + DamageInfo.ProductType + _
        DamageInfo.FileNo + DamageInfo.RequestNo + CStr(kacadetstr)

        Return donecek

    End Function


    '--- ŞİRKETİN KAÇ HASAR I VAR -------------------------------------------------------
    Function hasaradet_sirketin(ByVal FirmCode As String) As Integer

        Dim sqlstr As String
        Dim kacadet As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where FirmCode=@FirmCode"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kacadet = 0
        Else
            kacadet = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kacadet


    End Function


    Public Function GetDamageInformation(ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal InfoXML As String) As String

        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        Dim servisad As String
        servisad = "GetDamageInformation"


        Dim girdisayisi As Integer = 0
        Dim damagelist As New List(Of Damage)

        Dim Info As New Info

        Dim xmlhata As String = ""
        Dim root As New root
        Dim DamageLoadResult As New DamageLoadResult
        Dim ErrorInfo As New ErrorInfo

        Dim sifresahibisirket As New CLASSSIRKET
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        'TÜM İP YETKİLİMİ KONTROL ET
        Dim yetkiresult As New CLADBOPRESULT
        yetkiresult = sirket_erisim.yetkilimi(wskullaniciad, wssifre, "GetDamageInformation")
        If yetkiresult.durum = "Yetkisiz" Then

            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "GetDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr

        End If

        sifresahibisirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."


        Dim policetip_erisim As New CLASSPOLICETIP_ERISIM
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

        Dim debugy As String = ""
        Dim XmlDoc As XmlDocument = New XmlDocument

        'damagexml normalize--
        InfoXML = Replace(InfoXML, "&", "&amp;")

        Try
            XmlDoc.Load(New StringReader(InfoXML))
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de hatalar var." + ex.Message
            root.ResultCode = 0
            ErrorInfo.Code = 998
            ErrorInfo.Message = ex.Message
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr

        End Try

        Dim FirmCode_girdimi As String
        Dim ProductCode_girdimi, ProductType_girdimi, PolicyType_girdimi, TariffCode_girdimi As String
        Dim AuthorizedDrivers_girdimi, EnginePower_girdimi, Capacity_girdimi, CarType_girdimi As String
        Dim ProductionYear_girdimi, UsingStyle_girdimi, FuelType_girdimi, SteeringSide_girdimi As String
        Dim PlateNumber_girdimi, PlateCountryCode_girdimi, SIdentityCountryCode_girdimi, SIdentityCode_girdimi As String
        Dim SIdentityNumber_girdimi As String

        Dim IdentityNumber1_girdimi, IdentityCountryCode1_girdimi, IdentityCode1_girdimi As String
        Dim IdentityBirthDate1_girdimi, IdentityDriverLicenceNo1_girdimi, IdentityDriverLicenceGivenDate1_girdimi As String
        Dim IdentityDriverLicenceType1_girdimi As String

        Dim IdentityNumber2_girdimi, IdentityCountryCode2_girdimi, IdentityCode2_girdimi As String
        Dim IdentityBirthDate2_girdimi, IdentityDriverLicenceNo2_girdimi, IdentityDriverLicenceGivenDate2_girdimi As String
        Dim IdentityDriverLicenceType2_girdimi As String

        Dim IdentityNumber3_girdimi, IdentityCountryCode3_girdimi, IdentityCode3_girdimi As String
        Dim IdentityBirthDate3_girdimi, IdentityDriverLicenceNo3_girdimi, IdentityDriverLicenceGivenDate3_girdimi As String
        Dim IdentityDriverLicenceType3_girdimi As String

        Dim IdentityNumber4_girdimi, IdentityCountryCode4_girdimi, IdentityCode4_girdimi As String
        Dim IdentityBirthDate4_girdimi, IdentityDriverLicenceNo4_girdimi, IdentityDriverLicenceGivenDate4_girdimi As String
        Dim IdentityDriverLicenceType4_girdimi As String

        Dim IdentityNumber5_girdimi, IdentityCountryCode5_girdimi, IdentityCode5_girdimi As String
        Dim IdentityBirthDate5_girdimi, IdentityDriverLicenceNo5_girdimi, IdentityDriverLicenceGivenDate5_girdimi As String
        Dim IdentityDriverLicenceType5_girdimi As String

        Dim IdentityNumber6_girdimi, IdentityCountryCode6_girdimi, IdentityCode6_girdimi
        Dim IdentityBirthDate6_girdimi, IdentityDriverLicenceNo6_girdimi, IdentityDriverLicenceGivenDate6_girdimi As String
        Dim IdentityDriverLicenceType6_girdimi As String

        Dim AgencyRegisterCode_girdimi As String
        Dim TPNo_girdimi As String

        FirmCode_girdimi = "Hayır"
        ProductCode_girdimi = "Hayır"
        ProductType_girdimi = "Hayır"
        PolicyType_girdimi = "Hayır"
        TariffCode_girdimi = "Hayır"
        AuthorizedDrivers_girdimi = "Hayır"
        EnginePower_girdimi = "Hayır"
        Capacity_girdimi = "Hayır"
        CarType_girdimi = "Hayır"
        ProductionYear_girdimi = "Hayır"
        UsingStyle_girdimi = "Hayır"
        FuelType_girdimi = "Hayır"
        SteeringSide_girdimi = "Hayır"
        PlateNumber_girdimi = "Hayır"
        PlateCountryCode_girdimi = "Hayır"
        SIdentityCountryCode_girdimi = "Hayır"
        SIdentityCode_girdimi = "Hayır"
        SIdentityNumber_girdimi = "Hayır"

        IdentityNumber1_girdimi = "Hayır"
        IdentityCountryCode1_girdimi = "Hayır"
        IdentityCode1_girdimi = "Hayır"
        IdentityBirthDate1_girdimi = "Hayır"
        IdentityDriverLicenceNo1_girdimi = "Hayır"
        IdentityDriverLicenceGivenDate1_girdimi = "Hayır"
        IdentityDriverLicenceType1_girdimi = "Hayır"

        IdentityNumber2_girdimi = "Hayır"
        IdentityCountryCode2_girdimi = "Hayır"
        IdentityCode2_girdimi = "Hayır"
        IdentityBirthDate2_girdimi = "Hayır"
        IdentityDriverLicenceNo2_girdimi = "Hayır"
        IdentityDriverLicenceGivenDate2_girdimi = "Hayır"
        IdentityDriverLicenceType2_girdimi = "Hayır"

        IdentityNumber3_girdimi = "Hayır"
        IdentityCountryCode3_girdimi = "Hayır"
        IdentityCode3_girdimi = "Hayır"
        IdentityBirthDate3_girdimi = "Hayır"
        IdentityDriverLicenceNo3_girdimi = "Hayır"
        IdentityDriverLicenceGivenDate3_girdimi = "Hayır"
        IdentityDriverLicenceType3_girdimi = "Hayır"

        IdentityNumber4_girdimi = "Hayır"
        IdentityCountryCode4_girdimi = "Hayır"
        IdentityCode4_girdimi = "Hayır"
        IdentityBirthDate4_girdimi = "Hayır"
        IdentityDriverLicenceNo4_girdimi = "Hayır"
        IdentityDriverLicenceGivenDate4_girdimi = "Hayır"
        IdentityDriverLicenceType4_girdimi = "Hayır"

        IdentityNumber5_girdimi = "Hayır"
        IdentityCountryCode5_girdimi = "Hayır"
        IdentityCode5_girdimi = "Hayır"
        IdentityBirthDate5_girdimi = "Hayır"
        IdentityDriverLicenceNo5_girdimi = "Hayır"
        IdentityDriverLicenceGivenDate5_girdimi = "Hayır"
        IdentityDriverLicenceType5_girdimi = "Hayır"

        IdentityNumber6_girdimi = "Hayır"
        IdentityCountryCode6_girdimi = "Hayır"
        IdentityCode6_girdimi = "Hayır"
        IdentityBirthDate6_girdimi = "Hayır"
        IdentityDriverLicenceNo6_girdimi = "Hayır"
        IdentityDriverLicenceGivenDate6_girdimi = "Hayır"
        IdentityDriverLicenceType6_girdimi = "Hayır"

        AgencyRegisterCode_girdimi = "Hayır"
        TPNo_girdimi = "Hayır"

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim dairearactip As New CLASSDAIREARACTIP
        Dim dairearactip_erisim As New CLASSDAIREARACTIP_ERISIM
        Dim tuzukaractip As New CLASSTUZUKARACTIP
        Dim tuzukaractip_erisim As New CLASSTUZUKARACTIP_ERISIM
        Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM
        Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM

        For Each Element As XmlElement In XmlDoc.SelectNodes("//*")

            For Each Attribute As XmlAttribute In Element.Attributes

                'FirmCode 1
                If Attribute.Name = "FirmCode" Then
                    girdisayisi = girdisayisi + 1
                    FirmCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Info.FirmCode = Attribute.Value
                            If sifresahibisirket.sirketkod <> Attribute.Value Then
                                xmlhata = "Gönderdiğiniz XML'deki FirmCode " + _
                                "ile giriş yaptığınız kullanıcı adı ve şifre ile" + _
                                " girdiğiniz şirketin kodu uyuşmuyor."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de FirmCode KKSBM tarafından tanımlanmamış."
                        End Try
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
                            Info.ProductCode = Attribute.Value
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
                        xmlhata = "Gönderilen XML'de ProductCode boş olamaz."
                    End If
                End If


                'ProductType 3
                If Attribute.Name = "ProductType" Then
                    girdisayisi = girdisayisi + 1
                    ProductType_girdimi = "Evet"
                    Try
                        Info.ProductType = Attribute.Value
                    Catch ex As Exception
                        Info.ProductType = ""
                        xmlhata = "Gönderilen XML'de ProductType geçerli bir değer değildir."
                    End Try
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de ProductType boş olamaz."
                    End If
                End If



                'PolicyType 4
                If Attribute.Name = "PolicyType" Then
                    girdisayisi = girdisayisi + 1
                    PolicyType_girdimi = "Evet"
                    Try
                        Info.PolicyType = CInt(Attribute.Value)
                        Dim varmi As String = "Evet"
                        varmi = policetip_erisim.policetipvarmi(Info.PolicyType)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de PolicyType KKSBM tarafından tanımlanmamış."
                        End If
                    Catch ex As Exception
                        Info.PolicyType = 0
                        xmlhata = "Gönderilen XML'de PolicyType rakam olmak zorunda veya 0 olmamalı."
                    End Try
                End If


                'TariffCode 5
                If Attribute.Name = "TariffCode" Then
                    girdisayisi = girdisayisi + 1
                    TariffCode_girdimi = "Evet"
                    Try
                        Dim varmi As String = "Evet"
                        Info.TariffCode = Attribute.Value
                        varmi = aractarife_erisim.kodvarmi(Info.TariffCode)
                        If varmi = "Hayır" Then
                            xmlhata = "Gönderilen XML'de TariffCode KKSBM tarafından tanımlanmamıştır."
                        End If
                    Catch ex As Exception
                        Info.TariffCode = ""
                    End Try
                End If


                'AuthorizedDrivers 6
                If Attribute.Name = "AuthorizedDrivers" Then
                    Try
                        girdisayisi = girdisayisi + 1
                        AuthorizedDrivers_girdimi = "Evet"
                        If Attribute.Value = "A" Or Attribute.Value = "N" Or Attribute.Value = "a" Or Attribute.Value = "n" Then
                            Info.AuthorizedDrivers = UCase(Attribute.Value)
                        Else
                            xmlhata = "Gönderdiğiniz XML'de AuthorizedDrivers 'A' veya 'N' olmalıdır."
                        End If
                    Catch ex As Exception
                        xmlhata = "Gönderdiğiniz XML'de AuthorizedDrivers 'A' veya 'N' olmalıdır."
                    End Try
                End If


                'EnginePower 7
                If Attribute.Name = "EnginePower" Then
                    girdisayisi = girdisayisi + 1
                    EnginePower_girdimi = "Evet"
                    Try
                        Info.EnginePower = Attribute.Value
                    Catch ex As Exception
                        Info.EnginePower = 0
                        xmlhata = "Gönderilen XML'de EnginePower rakamsal olmalıdır."
                    End Try
                End If


                'Capacity 8
                If Attribute.Name = "Capacity" Then
                    girdisayisi = girdisayisi + 1
                    Capacity_girdimi = "Evet"
                    Try
                        Info.Capacity = CInt(Attribute.Value)
                    Catch ex As Exception
                        Info.Capacity = 0
                    End Try
                End If


                'CarType 9
                If Attribute.Name = "CarType" Then
                    girdisayisi = girdisayisi + 1
                    CarType_girdimi = "Evet"
                    Info.CarType = Attribute.Value
                    If Info.CarType = "" Then
                        xmlhata = "Gönderilen XML'de CarType boş olamaz."
                    End If
                End If


                'ProductionYear 10
                If Attribute.Name = "ProductionYear" Then
                    girdisayisi = girdisayisi + 1
                    ProductionYear_girdimi = "Evet"
                    Try
                        Info.ProductionYear = CInt(Attribute.Value)
                        If Len(Info.ProductionYear) <> 4 Then
                            xmlhata = "Gönderilen XML'de ProductionYear 4 karakterden oluşmalıdır."
                        End If

                    Catch ex As Exception
                        Info.ProductionYear = 0
                    End Try
                End If


                'UsingStyle 11
                If Attribute.Name = "UsingStyle" Then
                    girdisayisi = girdisayisi + 1
                    UsingStyle_girdimi = "Evet"
                    Info.UsingStyle = Attribute.Value
                End If




                'FuelType 12
                If Attribute.Name = "FuelType" Then
                    girdisayisi = girdisayisi + 1
                    FuelType_girdimi = "Evet"
                    Try
                        Info.FuelType = Attribute.Value
                    Catch ex As Exception
                        Info.FuelType = 0
                    End Try
                End If



                'SteeringSide 13
                If Attribute.Name = "SteeringSide" Then
                    girdisayisi = girdisayisi + 1
                    SteeringSide_girdimi = "Evet"
                    Try
                        Info.SteeringSide = Trim(Attribute.Value)
                    Catch ex As Exception
                        Info.SteeringSide = "0"
                    End Try
                End If


                'PlateNumber 14
                If Attribute.Name = "PlateNumber" Then
                    girdisayisi = girdisayisi + 1
                    PlateNumber_girdimi = "Evet"
                    Info.PlateNumber = Trim(Attribute.Value)
                End If

                'PlateCountryCode 15
                If Attribute.Name = "PlateCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    PlateCountryCode_girdimi = "Evet"
                    Info.PlateCountryCode = Attribute.Value
                End If


                'SIdentityCountryCode 16
                If Attribute.Name = "SIdentityCountryCode" Then
                    girdisayisi = girdisayisi + 1
                    SIdentityCountryCode_girdimi = "Evet"
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de SIdentityCountryCode boş olamaz."
                    End If
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            Dim ulke_erisim As New CLASSULKE_ERISIM
                            Info.SIdentityCountryCode = Attribute.Value
                            varmi = ulke_erisim.ulkekodvarmi(Info.SIdentityCountryCode)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de SIdentityCountryCode KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de SIdentityCountryCode KKSBM tarafından tanımlanmamış."
                        End Try
                    End If
                End If

                'SIdentityCode 17
                If Attribute.Name = "SIdentityCode" Then
                    girdisayisi = girdisayisi + 1
                    SIdentityCode_girdimi = "Evet"
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de SIdentityCode boş olamaz."
                    End If
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            Dim kimliktur_erisim As New CLASSKIMLIKTUR_ERISIM
                            Info.SIdentityCode = Attribute.Value
                            varmi = kimliktur_erisim.kimlikturkodvarmi(Info.SIdentityCode)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de SIdentityCode KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de SIdentityCode KKSBM tarafından tanımlanmamış."
                        End Try
                    End If
                End If


                'SIdentityNumber 18
                If Attribute.Name = "SIdentityNumber" Then
                    girdisayisi = girdisayisi + 1
                    SIdentityNumber_girdimi = "Evet"
                    Info.SIdentityNumber = Trim(Attribute.Value)
                    If Attribute.Value = "" Then
                        xmlhata = "Gönderilen XML'de SIdentityNumber boş olamaz."
                    End If
                End If


                '---------------------------------------------------------------------------------
                'IdentityNumber1 19
                If Attribute.Name = "IdentityNumber1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNumber1_girdimi = "Evet"
                    Info.IdentityNumber1 = Attribute.Value
                End If
                'IdentityCountryCode1 20
                If Attribute.Name = "IdentityCountryCode1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCountryCode1_girdimi = "Evet"
                    Info.IdentityCountryCode1 = Attribute.Value
                End If
                'IdentityCode1 21
                If Attribute.Name = "IdentityCode1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode1_girdimi = "Evet"
                    Info.IdentityCode1 = Attribute.Value
                End If
                'IdentityBirthDate1 22
                If Attribute.Name = "IdentityBirthDate1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityBirthDate1_girdimi = "Evet"
                    Try
                        Info.IdentityBirthDate1 = Attribute.Value
                    Catch
                        Info.IdentityBirthDate1 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceNo1 23
                If Attribute.Name = "IdentityDriverLicenceNo1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceNo1_girdimi = "Evet"
                    Info.IdentityDriverLicenceNo1 = Attribute.Value
                End If
                'IdentityDriverLicenceGivenDate1 24
                If Attribute.Name = "IdentityDriverLicenceGivenDate1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceGivenDate1_girdimi = "Evet"
                    Try
                        Info.IdentityDriverLicenceGivenDate1 = Attribute.Value
                    Catch
                        Info.IdentityDriverLicenceGivenDate1 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceType1 25
                If Attribute.Name = "IdentityDriverLicenceType1" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceType1_girdimi = "Evet"
                    Info.IdentityDriverLicenceType1 = Attribute.Value
                End If





                '--------------------------------------------------------
                'IdentityNumber2 26
                If Attribute.Name = "IdentityNumber2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNumber2_girdimi = "Evet"
                    Info.IdentityNumber2 = Attribute.Value
                End If
                'IdentityCountryCode2 27
                If Attribute.Name = "IdentityCountryCode2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCountryCode2_girdimi = "Evet"
                    Info.IdentityCountryCode2 = Attribute.Value
                End If
                'IdentityCode2 28
                If Attribute.Name = "IdentityCode2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode2_girdimi = "Evet"
                    Info.IdentityCode2 = Attribute.Value
                End If
                'IdentityBirthDate2 29
                If Attribute.Name = "IdentityBirthDate2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityBirthDate2_girdimi = "Evet"
                    Try
                        Info.IdentityBirthDate2 = Attribute.Value
                    Catch
                        Info.IdentityBirthDate2 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceNo2 30
                If Attribute.Name = "IdentityDriverLicenceNo2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceNo2_girdimi = "Evet"
                    Info.IdentityDriverLicenceNo2 = Attribute.Value
                End If
                'IdentityDriverLicenceGivenDate2 31
                If Attribute.Name = "IdentityDriverLicenceGivenDate2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceGivenDate2_girdimi = "Evet"
                    Try
                        Info.IdentityDriverLicenceGivenDate2 = Attribute.Value
                    Catch
                        Info.IdentityDriverLicenceGivenDate2 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceType2 32
                If Attribute.Name = "IdentityDriverLicenceType2" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceType2_girdimi = "Evet"
                    Info.IdentityDriverLicenceType2 = Attribute.Value
                End If


                '--------------------------------------------------------
                'IdentityNumber3 33
                If Attribute.Name = "IdentityNumber3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNumber3_girdimi = "Evet"
                    Info.IdentityNumber3 = Attribute.Value
                End If
                'IdentityCountryCode3 34
                If Attribute.Name = "IdentityCountryCode3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCountryCode3_girdimi = "Evet"
                    Info.IdentityCountryCode3 = Attribute.Value
                End If
                'IdentityCode3 35
                If Attribute.Name = "IdentityCode3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode3_girdimi = "Evet"
                    Info.IdentityCode3 = Attribute.Value
                End If
                'IdentityBirthDate3 36
                If Attribute.Name = "IdentityBirthDate3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityBirthDate3_girdimi = "Evet"
                    Try
                        Info.IdentityBirthDate3 = Attribute.Value
                    Catch
                        Info.IdentityBirthDate3 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceNo3 37
                If Attribute.Name = "IdentityDriverLicenceNo3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceNo3_girdimi = "Evet"
                    Info.IdentityDriverLicenceNo3 = Attribute.Value
                End If
                'IdentityDriverLicenceGivenDate3 38
                If Attribute.Name = "IdentityDriverLicenceGivenDate3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceGivenDate3_girdimi = "Evet"
                    Try
                        Info.IdentityDriverLicenceGivenDate3 = Attribute.Value
                    Catch
                        Info.IdentityDriverLicenceGivenDate3 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceType3 39
                If Attribute.Name = "IdentityDriverLicenceType3" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceType3_girdimi = "Evet"
                    Info.IdentityDriverLicenceType3 = Attribute.Value
                End If




                '--------------------------------------------------------
                'IdentityNumber4 40
                If Attribute.Name = "IdentityNumber4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNumber4_girdimi = "Evet"
                    Info.IdentityNumber4 = Attribute.Value
                End If
                'IdentityCountryCode4 41
                If Attribute.Name = "IdentityCountryCode4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCountryCode4_girdimi = "Evet"
                    Info.IdentityCountryCode4 = Attribute.Value
                End If
                'IdentityCode4 42
                If Attribute.Name = "IdentityCode4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode4_girdimi = "EVet"
                    Info.IdentityCode4 = Attribute.Value
                End If
                'IdentityBirthDate4 43
                If Attribute.Name = "IdentityBirthDate4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityBirthDate4_girdimi = "Evet"
                    Try
                        Info.IdentityBirthDate4 = Attribute.Value
                    Catch
                        Info.IdentityBirthDate4 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceNo4 44
                If Attribute.Name = "IdentityDriverLicenceNo4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceNo4_girdimi = "Evet"
                    Info.IdentityDriverLicenceNo4 = Attribute.Value
                End If
                'IdentityDriverLicenceGivenDate4 45
                If Attribute.Name = "IdentityDriverLicenceGivenDate4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceGivenDate4_girdimi = "Evet"
                    Try
                        Info.IdentityDriverLicenceGivenDate4 = Attribute.Value
                    Catch
                        Info.IdentityDriverLicenceGivenDate4 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceType4 46
                If Attribute.Name = "IdentityDriverLicenceType4" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceType4_girdimi = "Evet"
                    Info.IdentityDriverLicenceType4 = Attribute.Value
                End If


                '--------------------------------------------------------
                'IdentityNumber5 47
                If Attribute.Name = "IdentityNumber5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNumber5_girdimi = "Evet"
                    Info.IdentityNumber5 = Attribute.Value
                End If
                'IdentityCountryCode5 48
                If Attribute.Name = "IdentityCountryCode5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCountryCode5_girdimi = "Evet"
                    Info.IdentityCountryCode5 = Attribute.Value
                End If
                'IdentityCode5 49
                If Attribute.Name = "IdentityCode5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode5_girdimi = "Evet"
                    Info.IdentityCode5 = Attribute.Value
                End If
                'IdentityBirthDate5 50
                If Attribute.Name = "IdentityBirthDate5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityBirthDate5_girdimi = "Evet"
                    Try
                        Info.IdentityBirthDate5 = Attribute.Value
                    Catch
                        Info.IdentityBirthDate5 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceNo5 51
                If Attribute.Name = "IdentityDriverLicenceNo5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceNo5_girdimi = "Evet"
                    Info.IdentityDriverLicenceNo5 = Attribute.Value
                End If
                'IdentityDriverLicenceGivenDate5 52
                If Attribute.Name = "IdentityDriverLicenceGivenDate5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceGivenDate5_girdimi = "Evet"
                    Try
                        Info.IdentityDriverLicenceGivenDate5 = Attribute.Value
                    Catch
                        Info.IdentityDriverLicenceGivenDate5 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceType5 53
                If Attribute.Name = "IdentityDriverLicenceType5" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceType5_girdimi = "Evet"
                    Info.IdentityDriverLicenceType5 = Attribute.Value
                End If


                '--------------------------------------------------------
                'IdentityNumber6 54
                If Attribute.Name = "IdentityNumber6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityNumber6_girdimi = "Evet"
                    Info.IdentityNumber6 = Attribute.Value
                End If
                'IdentityCountryCode6 55
                If Attribute.Name = "IdentityCountryCode6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCountryCode6_girdimi = "Evet"
                    Info.IdentityCountryCode6 = Attribute.Value
                End If
                'IdentityCode6 56
                If Attribute.Name = "IdentityCode6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityCode6_girdimi = "Evet"
                    Info.IdentityCode6 = Attribute.Value
                End If
                'IdentityBirthDate6 57
                If Attribute.Name = "IdentityBirthDate6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityBirthDate6_girdimi = "Evet"
                    Try
                        Info.IdentityBirthDate6 = Attribute.Value
                    Catch
                        Info.IdentityBirthDate6 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceNo6 58
                If Attribute.Name = "IdentityDriverLicenceNo6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceNo6_girdimi = "Evet"
                    Info.IdentityDriverLicenceNo6 = Attribute.Value
                End If
                'IdentityDriverLicenceGivenDate6 59
                If Attribute.Name = "IdentityDriverLicenceGivenDate6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceGivenDate6_girdimi = "Evet"
                    Try
                        Info.IdentityDriverLicenceGivenDate6 = Attribute.Value
                    Catch
                        Info.IdentityDriverLicenceGivenDate6 = Nothing
                    End Try
                End If
                'IdentityDriverLicenceType6 60
                If Attribute.Name = "IdentityDriverLicenceType6" Then
                    girdisayisi = girdisayisi + 1
                    IdentityDriverLicenceType6_girdimi = "Evet"
                    Info.IdentityDriverLicenceType6 = Attribute.Value
                End If


                'AgencyRegisterCode 61
                If Attribute.Name = "AgencyRegisterCode" Then
                    girdisayisi = girdisayisi + 1
                    AgencyRegisterCode_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Info.AgencyRegisterCode = Trim(Attribute.Value)
                    Else
                        xmlhata = "Gönderilen XML'de AgencyRegisterCode boş olamaz."
                    End If
                End If


                'TPNo 62
                If Attribute.Name = "TPNo" Then
                    girdisayisi = girdisayisi + 1
                    TPNo_girdimi = "Evet"
                    If Attribute.Value <> "" Then
                        Try
                            Dim varmi As String = "Evet"
                            Info.TPNo = Trim(Attribute.Value)
                            varmi = personel_erisim.ciftkayitkontrol("tpno", Info.TPNo)
                            If varmi = "Hayır" Then
                                xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                            End If
                        Catch ex As Exception
                            xmlhata = "Gönderilen XML'de TPNo KKSBM tarafından tanımlanmamış."
                        End Try
                    Else
                        xmlhata = "Gönderilen XML'de TPNo boş olamaz."
                    End If
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
        If ProductType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductType" + "-"
        End If
        '4
        If PolicyType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PolicyType" + "-"
        End If
        '5
        If TariffCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TariffCode" + "-"
        End If
        '6
        If AuthorizedDrivers_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AuthorizedDrivers" + "-"
        End If
        '7
        If EnginePower_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "EnginePower" + "-"
        End If
        '8
        If Capacity_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "Capacity" + "-"
        End If
        '9
        If CarType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "CarType" + "-"
        End If
        '10
        If ProductionYear_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "ProductionYear" + "-"
        End If
        '11
        If UsingStyle_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "UsingStyle" + "-"
        End If
        '12
        If FuelType_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "FuelType" + "-"
        End If
        '13
        If SteeringSide_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SteeringSide" + "-"
        End If
        '14
        If PlateNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PlateNumber" + "-"
        End If
        '15
        If PlateCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "PlateCountryCode" + "-"
        End If
        '16
        If SIdentityCountryCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SIdentityCountryCode" + "-"
        End If
        '17
        If SIdentityCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SIdentityCode" + "-"
        End If
        '18
        If SIdentityNumber_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "SIdentityNumber" + "-"
        End If
        '19
        If IdentityNumber1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNumber1" + "-"
        End If
        '20
        If IdentityCountryCode1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCountryCode1" + "-"
        End If
        '21
        If IdentityCode1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode1" + "-"
        End If
        '22
        If IdentityBirthDate1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityBirthDate1" + "-"
        End If
        '23
        If IdentityDriverLicenceNo1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceNo1" + "-"
        End If
        '24
        If IdentityDriverLicenceGivenDate1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceGivenDate1" + "-"
        End If
        '25
        If IdentityDriverLicenceType1_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceType1" + "-"
        End If
        '26
        If IdentityNumber2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNumber2" + "-"
        End If
        '27
        If IdentityCountryCode2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCountryCode2" + "-"
        End If
        '28
        If IdentityCode2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode2" + "-"
        End If
        '29
        If IdentityBirthDate2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityBirthDate2" + "-"
        End If
        '30
        If IdentityDriverLicenceNo2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceNo2" + "-"
        End If
        '31
        If IdentityDriverLicenceGivenDate2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceGivenDate2" + "-"
        End If
        '32
        If IdentityDriverLicenceType2_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceType2" + "-"
        End If
        '33
        If IdentityNumber3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNumber3" + "-"
        End If
        '34
        If IdentityCountryCode3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCountryCode3" + "-"
        End If
        '35
        If IdentityCode3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode3" + "-"
        End If
        '36
        If IdentityBirthDate3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityBirthDate3" + "-"
        End If
        '37
        If IdentityDriverLicenceNo3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceNo3" + "-"
        End If
        '38
        If IdentityDriverLicenceGivenDate3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceGivenDate3" + "-"
        End If
        '39
        If IdentityDriverLicenceType3_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceType3" + "-"
        End If
        '40
        If IdentityNumber4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNumber4" + "-"
        End If
        '41
        If IdentityCountryCode4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCountryCode4" + "-"
        End If
        '42
        If IdentityCode4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode4" + "-"
        End If
        '43
        If IdentityBirthDate4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityBirthDate4" + "-"
        End If
        '44
        If IdentityDriverLicenceNo4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceNo4" + "-"
        End If
        '45
        If IdentityDriverLicenceGivenDate4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceGivenDate4" + "-"
        End If
        '46
        If IdentityDriverLicenceType4_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceType4" + "-"
        End If
        '47
        If IdentityNumber5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNumber5" + "-"
        End If
        '48
        If IdentityCountryCode5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCountryCode5" + "-"
        End If
        '49
        If IdentityCode5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode5" + "-"
        End If
        '50
        If IdentityBirthDate5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityBirthDate5" + "-"
        End If
        '51
        If IdentityDriverLicenceNo5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceNo5" + "-"
        End If
        '52
        If IdentityDriverLicenceGivenDate5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceGivenDate5" + "-"
        End If
        '53
        If IdentityDriverLicenceType5_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceType5" + "-"
        End If
        '54
        If IdentityNumber6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityNumber6" + "-"
        End If
        '55
        If IdentityCountryCode6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCountryCode6" + "-"
        End If
        '56
        If IdentityCode6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityCode6" + "-"
        End If
        '57
        If IdentityBirthDate6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityBirthDate6" + "-"
        End If
        '58
        If IdentityDriverLicenceNo6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceNo6" + "-"
        End If
        '59
        If IdentityDriverLicenceGivenDate6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceGivenDate6" + "-"
        End If
        '60
        If IdentityDriverLicenceType6_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "IdentityDriverLicenceType6" + "-"
        End If
        '61
        If AgencyRegisterCode_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "AgencyRegisterCode" + "-"
        End If
        '62
        If TPNo_girdimi = "Hayır" Then
            girilmeyenstr = girilmeyenstr + "TPNo" + "-"
        End If


        If girdisayisi <> 62 Then
            root.ResultCode = 0
            ErrorInfo.Code = 99
            ErrorInfo.Message = "Gönderdiğiniz XML'de bazı alanlar eksik yada fazladır." + _
            "Toplam xml node sayısı 62 olması gerekirken siz " + CStr(girdisayisi) + " alan gönderdiniz. " + _
            "Girilmeyen alanlar: " + girilmeyenstr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr
        End If

        'ProductType kontrolü yap
        Try
            Dim varmi As String
            Dim producttype_erisim As New CLASSPRODUCTTYPE_ERISIM
            Dim urunkod As New CLASSURUNKOD
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM
            urunkod = urunkod_erisim.bultek_kodagore(Info.ProductCode)
            varmi = producttype_erisim.ciftkayitkontrol(urunkod.pkey, Info.ProductType)
            If varmi = "Hayır" Then
                xmlhata = "Gönderilen XML'de ProductType KKSBM tarafından tanımlanmamış."
            End If
        Catch ex As Exception
            xmlhata = "Gönderilen XML'de ProductType KKSBM tarafından tanımlanmamış."
        End Try

        'steeringside kontrol 
        If Info.TariffCode <> "CZ312" And Info.TariffCode <> "CZ9" And _
        Info.TariffCode <> "CZ801" And Info.TariffCode <> "CZ802" And _
        Info.TariffCode = "CY1" And Info.TariffCode = "CY70" Then
            If Info.SteeringSide <> "R" And Info.SteeringSide <> "L" Then
                xmlhata = "CZ312,CZ9,CZ801,CZ802,CY1,CY70 dışında Gönderilen XML'de" + _
                " SteeringSide L yada R olmalıdır. Boş olmamalıdır."
            End If
        End If


        'FuelType kontrolu
        If Info.TariffCode <> "CZ312" And Info.TariffCode <> "CZ9" Then
            Try
                Dim fueltype_erisim As New CLASSFUELTYPE_ERISIM
                Dim varmi As String = "Evet"
                Info.FuelType = Trim(Info.FuelType)
                varmi = fueltype_erisim.fueltypevarmi(Info.FuelType)
                If varmi = "Hayır" Then
                    xmlhata = "Gönderilen XML'de FuelType KKSBM tarafından tanımlanmamış."
                End If
            Catch ex As Exception
                xmlhata = "Gönderilen XML'de FuelType KKSBM tarafından tanımlanmamış."
            End Try
        End If
        If Info.TariffCode <> "CZ312" And Info.TariffCode <> "CZ9" Then
            If IsNumeric(Info.FuelType) = False Then
                xmlhata = "CZ312 VE CZ9 dışındaki tarife kodları için gönderilen XML'de FuelType boş olamaz."
            End If
        End If



        'CAR TYPE KONTROLU YAP 
        If IsNumeric(Info.PolicyType) = True Then
            'normal ve ihale tipi poliçelerde cartype kontrolü
            If Info.PolicyType = 1 Or Info.PolicyType = 2 Then
                If dairearactip_erisim.ciftkayitkontrol(Info.CarType) = "Hayır" Then
                    xmlhata = "Gönderilen XML'de CarType SBM tarafından tanımlanmamış. Normal veya İhale Tipi"
                End If
            End If

            'sınır kapısı kontrol 
            If Info.PolicyType = 3 Then
                If sinirkapiaractip_erisim.ciftkayitkontrol(Info.CarType) = "Hayır" Then
                    xmlhata = "Gönderilen XML'de CarType SBM tarafından tanımlanmamış. Sınır Kapısı Tipi"
                End If
            End If
        End If



        'xmlde hata var mı kontrol et
        If xmlhata <> "" Then
            root.ResultCode = 0
            ErrorInfo.Code = 800
            ErrorInfo.Message = xmlhata
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr
        End If


        'AgencyRegisterCode kontrolü Sınır Kapısı ise Kontrol 
        If Info.PolicyType = 3 Then

            Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
            Dim varmikapikod As String
            varmikapikod = sinirkapi_erisim.varmikapikod(Info.AgencyRegisterCode)

            Dim varmi_gercekagencyregistercode As String
            varmi_gercekagencyregistercode = acente_erisim.ciftkayitkontrol("sicilno", Info.AgencyRegisterCode)

            If varmikapikod = "Hayır" And varmi_gercekagencyregistercode = "Hayır" Then

                root.ResultCode = 0
                ErrorInfo.Code = 800
                ErrorInfo.Message = "Gönderdiğiniz AgencyRegisterCode herhangi bir sınır kapısı için tanımlanmamış veya AgencyRegisterCode doğru bir acente değil."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If

        End If 'PolicyType=3


        'AgencyRegisterCode kontrolü
        'PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2
        If Info.PolicyType = 1 Or Info.PolicyType = 2 Then

            acente = acente_erisim.bulsicilnogore(Info.AgencyRegisterCode)

            If acente.aktifmi = "Hayır" Then
                root.ResultCode = 0
                ErrorInfo.Code = 501
                ErrorInfo.Message = acente.acentead + " aktif değildir."
                root.ErrorInfo = ErrorInfo


                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If


            'ACENTE O ŞİRKETİN Mİ
            sirket = sirket_erisim.bultek_sirketkodagore(Info.FirmCode)
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

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If


        End If 'PolicyInfo.PolicyType = 1 Or PolicyInfo.PolicyType = 2


        'SORU İŞARETİ KONTROL
        If InStr(InfoXML, "?", CompareMethod.Text) > 0 Then
            root.ResultCode = 0
            ErrorInfo.Code = 333
            ErrorInfo.Message = "Gönderdiğiniz XML'in hiçbir yerinde ? (soru işareti) karakteri olmamalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
           root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
           0, "0", "0", _
           "0", "0", "0", "0", "0", _
           "0", "0", "0", "0", "0", _
           "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr

        End If


        'TPNo kontrol
        If Info.TPNo <> "" Then
            personel = personel_erisim.bul_tpnogore(Info.TPNo, "Evet")
            If personel.pkey = 0 Then
                root.ResultCode = 0
                ErrorInfo.Code = 503
                ErrorInfo.Message = "Gönderdiğiniz TPNo teknik personel değildir."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr
            End If
        End If




        'MANTIKSAL KONTROLLER ---
        If Info.SIdentityCountryCode = "601" And Info.SIdentityCode = "KN" Then
            If Len(Trim(Info.SIdentityNumber)) <> 6 And Trim(Len(Info.SIdentityNumber)) <> 10 Then
                root.ResultCode = 0
                ErrorInfo.Code = 801
                ErrorInfo.Message = "Ülke kodu 601 ve kimlik türü KN olan sorgularda kimlik numarası " + _
                "6 yada 10 rakamdan oluşmalıdır."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr
            End If
        End If
        If Info.SIdentityCountryCode = "52" And Info.SIdentityCode = "KN" Then
            If Len(Trim(Info.SIdentityNumber)) <> 11 Then
                root.ResultCode = 0
                ErrorInfo.Code = 801
                ErrorInfo.Message = "Ülke kodu 52 ve kimlik türü KN olan sorgularda kimlik numarası " + _
                "11 rakamdan oluşmalıdır."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr
            End If
        End If


        'PLAKA KONTROL
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim
        Dim plakaresult As New CLADBOPRESULT
        plakaresult = plakakontrol_erisim.plakakontrolbasit(Info.TariffCode, Info.PlateNumber)
        If plakaresult.durum = "Hata Var" Then
            root.ResultCode = 0
            ErrorInfo.Code = 500
            ErrorInfo.Message = plakaresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr
        End If

        'GÖNDERİLEN TARIFF CODE İLE CARTYPE BİRBİRİ İLE EŞLEŞİYOR MU NORMAL VE İHALE TİPİ POLİÇELERDE?
        If Info.PolicyType = 1 Or Info.PolicyType = 2 Then
            Dim tarifedairebag_erisim As New CLASSTARIFEDAIREBAG_ERISIM
            Dim aractarife As New CLASSARACTARIFE
            aractarife = aractarife_erisim.bultarifekodagore(Info.TariffCode)
            dairearactip = dairearactip_erisim.bultek_adagore(Info.CarType)
            If tarifedairebag_erisim.ciftkayitkontrol(aractarife.pkey, dairearactip.pkey) = "Hayır" Then

                Dim gonderebilecegi As String
                gonderebilecegi = tarifedairebag_erisim.gonderebilecegi_cartype(aractarife.pkey)
                root.ResultCode = 0
                ErrorInfo.Code = 444
                ErrorInfo.Message = "Gönderdiğiniz tarife kodu ile CarType eşleştirilmemiş. (Normal, İhale). " + _
                aractarife.tarifekod + " (" + aractarife.tarifead + ") için gönderebileceğiniz CarType lar: " + _
                gonderebilecegi + " dir."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If
        End If



        'GÖNDERİLEN TARIFF CODE İLE CARTYPE BİRBİRİ İLE EŞLEŞİYOR MU SINIR KAPISI?
        If Info.PolicyType = 3 Then

            Dim tarifesinirkapibag_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM
            aractarife = aractarife_erisim.bultarifekodagore(Info.TariffCode)
            sinirkapiaractip = sinirkapiaractip_erisim.bultek_adagore(Info.CarType)
            If tarifesinirkapibag_erisim.ciftkayitkontrol(aractarife.pkey, sinirkapiaractip.pkey) = "Hayır" Then

                Dim gonderebilecegi As String
                gonderebilecegi = tarifesinirkapibag_erisim.gonderebilecegi_cartype(aractarife.pkey)
                root.ResultCode = 0
                ErrorInfo.Code = 444
                ErrorInfo.Message = "Gönderdiğiniz tarife kodu ile CarType eşleştirilmemiş. (Sınır Kapısı)." + _
                aractarife.tarifekod + " (" + aractarife.tarifead + ") için gönderebileceğiniz CarType lar: " + _
                gonderebilecegi + " dir."
                root.ErrorInfo = ErrorInfo


                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If

        End If



        'Plaka girildi ise PlateCountryCode boş gelemez
        If Info.PlateNumber <> "" Then
            If Info.PlateCountryCode = "" Then

                root.ResultCode = 0
                ErrorInfo.Code = 449
                ErrorInfo.Message = "PlateNumber boş gönderilmeyen sorgularda PlateCountryCode boş olamaz."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If
        End If

        'name driver gelen poliçelerde en az identityno1 gelmek zorunda
        If Info.AuthorizedDrivers = "N" Then

            If Info.IdentityNumber1 = "" Then

                root.ResultCode = 0
                ErrorInfo.Code = 450
                ErrorInfo.Message = "NameDriver olan poliçelerde IdentityNumber1 boş olamaz."
                root.ErrorInfo = ErrorInfo

                logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                0, "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", "0", _
                "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                "</root>"

                Return root.GetDamageResultStr

            End If

        End If


        Dim kombinasyonroot As New root
        kombinasyonroot = damageinfoservicekontrol_erisim.kombinasyonkontrol2(wskullaniciad, wssifre, sifresahibisirket, Info, InfoXML)

        If kombinasyonroot.ResultCode = 0 Then

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
            kombinasyonroot.ResultCode, kombinasyonroot.ErrorInfo.Code, kombinasyonroot.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            kombinasyonroot.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(kombinasyonroot.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(kombinasyonroot.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(kombinasyonroot.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return kombinasyonroot.GetDamageResultStr

        End If



        Dim calculations2_erisim As New Calculations2_Erisim
        Dim araliktaki_tek_hasar As New tekdamage
        Dim araliktaki_tum_hasarlar As New List(Of tekdamage)

        Dim donecekdamages As New List(Of Damage)
        Dim donecekdamage_plaka_icin As New Damage
        Dim donecekdamage_s1_icin As New Damage
        Dim donecekdamage_1_icin As New Damage
        Dim donecekdamage_2_icin As New Damage
        Dim donecekdamage_3_icin As New Damage
        Dim donecekdamage_4_icin As New Damage
        Dim donecekdamage_5_icin As New Damage
        Dim donecekdamage_6_icin As New Damage


        'INFORMATION TAG OLUŞTUR -----------------------------------------------------
        Dim donecekLivePolicyControl As Integer
        donecekLivePolicyControl = kimlikplakapolicehasar_erisim.plakada_canlipolicevarmi(Info.PlateNumber, Info.ProductCode, Info.FirmCode)

        'ARAÇ KAYIT DAİRESİ KONTROL --------------------------------
        Dim donecekcc As String
        Dim donecekccrate As Integer
        Dim informationtag As String

        If Info.PlateCountryCode = 601 Then
            getdamagelog = getdamagelog + "Ülke kodu 601 olduğundan araç kayıt dairesine bağlanıp sorgulama yapıyorum." + "--"
            Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
            Dim arackayitbilgi As New CLASSARACKAYITDAIRE
            arackayitbilgi = arackayitdaire_erisim.sorgula_plakayagore_servisicin(Info.PlateNumber)
            'eğer doğru çalışmadı ise
            If arackayitbilgi.KatKod = 0 Then
                getdamagelog = getdamagelog + "Araç Kayıt Dairesi Çalışmadı. Gönderilen Plaka:" + arackayitbilgi.Model + "--" + _
                "Gelen Cevap:" + arackayitbilgi.PlakaNo + "--"
                donecekcc = CStr(Info.EnginePower)
            End If
            'eğer doğru çalıştı ise
            If arackayitbilgi.KatKod <> 0 Then
                getdamagelog = getdamagelog + "Araç Kayıt Dairesinden dönen CC Rate:" + CStr(arackayitbilgi.MotorGuc) + "--"
                getdamagelog = getdamagelog + "Araç Kayıt Dairesi Gönderilen Plaka:" + CStr(arackayitbilgi.PlakaNo) + "--"
                donecekcc = CStr(Info.EnginePower)
                If Info.EnginePower <> arackayitbilgi.MotorGuc Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "Gönderdiğiniz CC değeri ile Araç Kayıt Dairesinde kayıtlı CC birbirini tutmuyor. " + _
                    "Araç Kayıt:" + CStr(arackayitbilgi.MotorGuc) + "CC -- Sizin Gönderdiğiniz:" + CStr(Info.EnginePower) + "CC"
                    root.ErrorInfo = ErrorInfo

                    logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
                    root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
                    0, "0", "0", _
                    "0", "0", "0", "0", "0", _
                    "0", "0", "0", "0", "0", _
                    "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

                    root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
                    "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
                    " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
                    "</root>"

                    Return root.GetDamageResultStr
                End If 'Engine Power
            End If 'KatKod
        End If '601


        If Info.PlateCountryCode <> 601 Then
            donecekcc = CStr(Info.EnginePower)
        End If

        'ccrate bul 
        donecekccrate = calculations2_erisim.tuzukccoranbul(Info.TariffCode, Info.CarType, Info.EnginePower)

        Dim age_rate1, age_rate2, age_rate3, age_rate4, age_rate5, age_rate6 As String
        age_rate1 = ""
        age_rate2 = ""
        age_rate3 = ""
        age_rate4 = ""
        age_rate5 = ""
        age_rate6 = ""

        If Info.AuthorizedDrivers = "N" Then

            'agerate value bul
            If Not Info.IdentityBirthDate1 Is Nothing Then
                donecekdamage_1_icin.AgeRate = calculations2_erisim.tuzukyasoranbul(Info.IdentityBirthDate1)
                age_rate1 = CStr(donecekdamage_1_icin.AgeRate)
            Else
                getdamagelog = getdamagelog + "1. Sürücü için doğum tarihi gönderilmediğinden AgeRateValue'yu hesaplayamıyorum." + "--"
            End If
            If Not Info.IdentityBirthDate2 Is Nothing Then
                donecekdamage_2_icin.AgeRate = calculations2_erisim.tuzukyasoranbul(Info.IdentityBirthDate2)
                age_rate2 = CStr(donecekdamage_2_icin.AgeRate)
            Else
                getdamagelog = getdamagelog + "2. Sürücü için doğum tarihi gönderilmediğinden AgeRateValue'yu hesaplayamıyorum." + "--"
            End If
            If Not Info.IdentityBirthDate3 Is Nothing Then
                donecekdamage_3_icin.AgeRate = calculations2_erisim.tuzukyasoranbul(Info.IdentityBirthDate3)
                age_rate3 = CStr(donecekdamage_3_icin.AgeRate)
            Else
                getdamagelog = getdamagelog + "3. Sürücü için doğum tarihi gönderilmediğinden AgeRateValue'yu hesaplayamıyorum." + "--"
            End If
            If Not Info.IdentityBirthDate4 Is Nothing Then
                donecekdamage_4_icin.AgeRate = calculations2_erisim.tuzukyasoranbul(Info.IdentityBirthDate4)
                age_rate4 = CStr(donecekdamage_4_icin.AgeRate)
            Else
                getdamagelog = getdamagelog + "4. Sürücü için doğum tarihi gönderilmediğinden AgeRateValue'yu hesaplayamıyorum." + "--"
            End If
            If Not Info.IdentityBirthDate5 Is Nothing Then
                donecekdamage_5_icin.AgeRate = calculations2_erisim.tuzukyasoranbul(Info.IdentityBirthDate5)
                age_rate5 = CStr(donecekdamage_5_icin.AgeRate)
            Else
                getdamagelog = getdamagelog + "5. Sürücü için doğum tarihi gönderilmediğinden AgeRateValue'yu hesaplayamıyorum." + "--"
            End If
            If Not Info.IdentityBirthDate6 Is Nothing Then
                donecekdamage_6_icin.AgeRate = calculations2_erisim.tuzukyasoranbul(Info.IdentityBirthDate6)
                age_rate6 = CStr(donecekdamage_6_icin.AgeRate)
            Else
                getdamagelog = getdamagelog + "6. Sürücü için doğum tarihi gönderilmediğinden AgeRateValue'yu hesaplayamıyorum." + "--"
            End If

        End If


        Dim AnyDriverRate As Integer = 0
        If Info.AuthorizedDrivers = "A" Then
            AnyDriverRate = 50
        End If

        informationtag = "<Information>" + _
        "<Info LivePolicyControl=" + Chr(34) + CStr(donecekLivePolicyControl) + Chr(34) + _
        " CC=" + Chr(34) + donecekcc + Chr(34) + _
        " CCRate=" + Chr(34) + CStr(donecekccrate) + Chr(34) + _
        " AnyDriverRate=" + Chr(34) + CStr(AnyDriverRate) + Chr(34) + "/>" + _
        "</Information>"
        'INFORMATION TAG OLUŞTURMA BİTTİ -------------------------------------------------------


        'KONTROLLER BİTTİ INFORMATION TAG OLUŞTURULDU HESAPLAMALAR BAŞLIYOR ----------------------------------------
        'KONTROLLER BİTTİ INFORMATION TAG OLUŞTURULDU HESAPLAMALAR BAŞLIYOR ----------------------------------------
        'KONTROLLER BİTTİ INFORMATION TAG OLUŞTURULDU HESAPLAMALAR BAŞLIYOR ----------------------------------------


        'İŞLEMLER BAŞLADI ------------------------------
        'önce aralığı bul-------------------------------
        Dim DamageInfoServiceHelper_erisim As New DamageInfoServiceHelper_Erisim

        Dim araliklar As New List(Of CLASSARALIK)
        Dim araliksayisi As Integer = 0
        araliklar = araliklaribul()
        araliksayisi = araliklar.Count

        getdamagelog = getdamagelog + "Toplam " + CStr(araliksayisi) + " aralık adeti bulundu.--"

        Dim plaka_icin As String
        Dim donecektotal_damage_count_plaka_icin As Integer = 0
        Dim donecektotal_damage_cost_plaka_icin As Decimal = 0
        Dim total_damage_count_plaka_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_plaka_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_plaka_icin As Integer
        Dim damageless_rate_plaka_icin As Integer

        Dim policy_s1_icin As String
        Dim donecektotal_damage_count_s1_icin As Integer = 0
        Dim donecektotal_damage_cost_s1_icin As Decimal = 0
        Dim total_damage_count_s1_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_s1_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_s1_icin As Integer
        Dim damageless_rate_s1_icin As Integer

        Dim policy_1_icin As String
        Dim donecektotal_damage_count_1_icin As Integer = 0
        Dim donecektotal_damage_cost_1_icin As Decimal = 0
        Dim total_damage_count_1_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_1_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_1_icin As Integer
        Dim damageless_rate_1_icin As Integer

        Dim policy_2_icin As String
        Dim donecektotal_damage_count_2_icin As Integer = 0
        Dim donecektotal_damage_cost_2_icin As Decimal = 0
        Dim total_damage_count_2_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_2_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_2_icin As Integer
        Dim damageless_rate_2_icin As Integer

        Dim policy_3_icin As String
        Dim donecektotal_damage_count_3_icin As Integer = 0
        Dim donecektotal_damage_cost_3_icin As Decimal = 0
        Dim total_damage_count_3_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_3_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_3_icin As Integer
        Dim damageless_rate_3_icin As Integer

        Dim policy_4_icin As String
        Dim donecektotal_damage_count_4_icin As Integer = 0
        Dim donecektotal_damage_cost_4_icin As Decimal = 0
        Dim total_damage_count_4_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_4_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_4_icin As Integer
        Dim damageless_rate_4_icin As Integer

        Dim policy_5_icin As String
        Dim donecektotal_damage_count_5_icin As Integer = 0
        Dim donecektotal_damage_cost_5_icin As Decimal = 0
        Dim total_damage_count_5_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_5_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_5_icin As Integer
        Dim damageless_rate_5_icin As Integer

        Dim policy_6_icin As String
        Dim donecektotal_damage_count_6_icin As Integer = 0
        Dim donecektotal_damage_cost_6_icin As Decimal = 0
        Dim total_damage_count_6_icin(araliksayisi - 1) As Decimal
        Dim total_damage_cost_6_icin(araliksayisi - 1) As Decimal
        Dim damage_rate_6_icin As Integer
        Dim damageless_rate_6_icin As Integer

        Dim araliktaki_hasar_listesi_plaka_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_s1_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_1_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_2_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_3_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_4_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_5_icin(araliksayisi - 1) As List(Of tekdamage)
        Dim araliktaki_hasar_listesi_6_icin(araliksayisi - 1) As List(Of tekdamage)

        Dim plaka_icin_damage As New Damage
        Dim sindentitynumber1_icin_damage As New Damage
        Dim indentitynumber1_icin_damage As New Damage
        Dim indentitynumber2_icin_damage As New Damage
        Dim indentitynumber3_icin_damage As New Damage
        Dim indentitynumber4_icin_damage As New Damage
        Dim indentitynumber5_icin_damage As New Damage
        Dim indentitynumber6_icin_damage As New Damage

        Dim girdiplaka(araliksayisi - 1) As String
        Dim girdis(araliksayisi - 1) As String
        Dim girdi1(araliksayisi - 1) As String
        Dim girdi2(araliksayisi - 1) As String
        Dim girdi3(araliksayisi - 1) As String
        Dim girdi4(araliksayisi - 1) As String
        Dim girdi5(araliksayisi - 1) As String
        Dim girdi6(araliksayisi - 1) As String

        Dim aralikcnt As Integer = 0
        For Each itemaralik As CLASSARALIK In araliklar
            girdiplaka(aralikcnt) = "Hayır"
            girdis(aralikcnt) = "Hayır"
            girdi1(aralikcnt) = "Hayır"
            girdi2(aralikcnt) = "Hayır"
            girdi3(aralikcnt) = "Hayır"
            girdi4(aralikcnt) = "Hayır"
            girdi5(aralikcnt) = "Hayır"
            girdi6(aralikcnt) = "Hayır"
            aralikcnt = aralikcnt + 1
        Next

        aralikcnt = 0
        'TÜM TOTAL DAMAGE COUNTLARI SIFIRLA
        For Each itemaralik As CLASSARALIK In araliklar
            total_damage_count_plaka_icin(aralikcnt) = 0
            total_damage_count_s1_icin(aralikcnt) = 0
            total_damage_count_1_icin(aralikcnt) = 0
            total_damage_count_2_icin(aralikcnt) = 0
            total_damage_count_3_icin(aralikcnt) = 0
            total_damage_count_4_icin(aralikcnt) = 0
            total_damage_count_5_icin(aralikcnt) = 0
            total_damage_count_6_icin(aralikcnt) = 0
            aralikcnt = aralikcnt + 1
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + " " + CStr(aralikcnt) + _
            ". Nolu Aralık Başlangıç Tarihi:" + CStr(itemaralik.baslangic) + " Bitiş Tarihi:" + CStr(itemaralik.bitis) + ". --"
        Next

        plaka_icin = Info.PlateNumber
        policy_s1_icin = Info.SIdentityNumber
        policy_1_icin = Info.IdentityNumber1
        policy_2_icin = Info.IdentityNumber2
        policy_3_icin = Info.IdentityNumber3
        policy_4_icin = Info.IdentityNumber4
        policy_5_icin = Info.IdentityNumber5
        policy_6_icin = Info.IdentityNumber6

        Dim ms_birkerebilegirdimi As String = "Hayır"
        Dim plaka_birkerebilegirdimi As String = "Hayır"
        Dim s1_birkerebilegirdimi As String = "Hayır"
        Dim d1_birkerebilegirdimi As String = "Hayır"
        Dim d2_birkerebilegirdimi As String = "Hayır"
        Dim d3_birkerebilegirdimi As String = "Hayır"
        Dim d4_birkerebilegirdimi As String = "Hayır"
        Dim d5_birkerebilegirdimi As String = "Hayır"
        Dim d6_birkerebilegirdimi As String = "Hayır"

        aralikcnt = 0




        'PLAKAYA BAKILIP BAKILMADIĞINI BUL ------------------------------------------
        Dim plakayami_bakilacak As String = "Hayır"
        Dim ekleneceklog As String = ""
        If (Info.TariffCode = "CZ301" Or Info.TariffCode = "CZ400" Or _
        Info.TariffCode = "CZ406" Or Info.TariffCode = "CZ600") And Info.PlateNumber <> "" Then
            plakayami_bakilacak = "Evet"
            ekleneceklog = "TariffCode CZ301,CZ400,CZ406,CZ600 olduğundan ve PlateNumber boş olmadığından plakaya bakıyorum. --"
        End If
        If (Info.SIdentityCode <> "KN" And Info.SIdentityCode <> "PN" And Info.SIdentityCode <> "GK") And Info.PlateNumber <> "" Then
            plakayami_bakilacak = "Evet"
            ekleneceklog = "SIdentityCode KN,PN yada GK olmadığından ve PlateNumber boş olmadığından plakaya bakıyorum. --"
        End If




        'ARALIKLAR ARASI DAMAGE LARINI BUL KİMLİK İÇİN
        For Each itemaralik As CLASSARALIK In araliklar

            getdamagelog = getdamagelog + "****" + CStr(aralikcnt + 1) + ". aralık için başladı--"


            'PLAKAYA BAK S için
            If plakayami_bakilacak = "Evet" Then
                getdamagelog = getdamagelog + ekleneceklog
                ms_birkerebilegirdimi = "Evet"
                girdis(aralikcnt) = "Evet"
                araliktaki_hasar_listesi_s1_icin(aralikcnt) = _
                damagebul_plakayagore(Info.PlateNumber, itemaralik.baslangic, itemaralik.bitis)
                total_damage_count_s1_icin(aralikcnt) = araliktaki_hasar_listesi_s1_icin(aralikcnt).Count
                donecektotal_damage_count_s1_icin = donecektotal_damage_count_s1_icin + araliktaki_hasar_listesi_s1_icin(aralikcnt).Count
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve S1 için" + _
                " MŞ numarası bulundu ve" + _
                " bu sorgu için MŞ numarası " + Info.SIdentityNumber + " dır.--" + _
                "Plakaya göre sorgulama yapıyorum. " + CStr(Info.PlateNumber) + "--"
            End If

            'KİMLİĞE BAK S için
            If (Info.SIdentityCode = "KN" Or Info.SIdentityCode = "PN" Or Info.SIdentityCode = "GK") And plakayami_bakilacak = "Hayır" Then
                getdamagelog = getdamagelog + "Poliçe sahibi için Plaka yerine kimliğe bakılıyor. --"
                If Info.SIdentityNumber <> "" Then
                    girdis(aralikcnt) = "Evet"
                    s1_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_s1_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.SIdentityCountryCode, Info.SIdentityNumber, Info.SIdentityCode, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_s1_icin(aralikcnt) = araliktaki_hasar_listesi_s1_icin(aralikcnt).Count
                    donecektotal_damage_count_s1_icin = donecektotal_damage_count_s1_icin + araliktaki_hasar_listesi_s1_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve S1 için" + _
                    " kimlik numarası KN veya PN veya GK olan kimlik numarası bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.SIdentityNumber + " dır.--"
                End If
            End If

            'SÜRÜCÜ 1
            If Info.IdentityCode1 = "KN" Or Info.IdentityCode1 = "PN" Or Info.SIdentityCode = "GK" Then
                If Info.IdentityNumber1 <> "" Then
                    girdi1(aralikcnt) = "Evet"
                    d1_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_1_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.IdentityCountryCode1, Info.IdentityNumber1, Info.IdentityCode1, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_1_icin(aralikcnt) = araliktaki_hasar_listesi_1_icin(aralikcnt).Count
                    donecektotal_damage_count_1_icin = donecektotal_damage_count_1_icin + araliktaki_hasar_listesi_1_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve 1 için" + _
                    " kimlik numarası KN veya PN veya GK olan kimlik numarası bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.IdentityNumber1 + " dır.--"
                End If
            End If

            'SÜRÜCÜ 2
            If Info.IdentityCode2 = "KN" Or Info.IdentityCode2 = "PN" Or Info.SIdentityCode = "GK" Then
                If Info.IdentityNumber2 <> "" Then
                    girdi2(aralikcnt) = "Evet"
                    d2_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_2_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.IdentityCountryCode2, Info.IdentityNumber2, Info.IdentityCode2, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_2_icin(aralikcnt) = araliktaki_hasar_listesi_2_icin(aralikcnt).Count
                    donecektotal_damage_count_2_icin = donecektotal_damage_count_2_icin + araliktaki_hasar_listesi_2_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve 2 için" + _
                    " kimlik numarası KN veya PN veya GK olan kimlik numarası bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.IdentityNumber2 + " dır.--"
                End If
            End If

            'SÜRÜCÜ 3
            If Info.IdentityCode3 = "KN" Or Info.IdentityCode3 = "PN" Or Info.SIdentityCode = "GK" Then
                If Info.IdentityNumber3 <> "" Then
                    girdi3(aralikcnt) = "Evet"
                    d3_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_3_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.IdentityCountryCode3, Info.IdentityNumber3, Info.IdentityCode3, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_3_icin(aralikcnt) = araliktaki_hasar_listesi_3_icin(aralikcnt).Count
                    donecektotal_damage_count_3_icin = donecektotal_damage_count_3_icin + araliktaki_hasar_listesi_3_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve 3 için" + _
                    " kimlik numarası KN veya PN veya GK olan kimlik numarası bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.IdentityNumber3 + " dır.--"
                End If
            End If

            'SÜRÜCÜ 4
            If Info.IdentityCode4 = "KN" Or Info.IdentityCode4 = "PN" Or Info.SIdentityCode = "GK" Then
                If Info.IdentityNumber4 <> "" Then
                    girdi4(aralikcnt) = "Evet"
                    d4_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_4_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.IdentityCountryCode4, Info.IdentityNumber4, Info.IdentityCode4, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_4_icin(aralikcnt) = araliktaki_hasar_listesi_4_icin(aralikcnt).Count
                    donecektotal_damage_count_4_icin = donecektotal_damage_count_4_icin + araliktaki_hasar_listesi_4_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve 4 için" + _
                    " kimlik numarası KN veya PN veya GK olan kimlik numarası bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.IdentityNumber4 + " dır.--"
                End If
            End If

            'SÜRÜCÜ 5
            If Info.IdentityCode5 = "KN" Or Info.IdentityCode5 = "PN" Or Info.SIdentityCode = "GK" Then
                If Info.IdentityNumber5 <> "" Then
                    girdi5(aralikcnt) = "Evet"
                    d5_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_5_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.IdentityCountryCode5, Info.IdentityNumber5, Info.IdentityCode5, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_5_icin(aralikcnt) = araliktaki_hasar_listesi_5_icin(aralikcnt).Count
                    donecektotal_damage_count_5_icin = donecektotal_damage_count_5_icin + araliktaki_hasar_listesi_5_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve 5 için" + _
                    " kimlik numarası KN veya PN veya GK olan kimlik numarası bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.IdentityNumber5 + " dır.--"
                End If
            End If

            'SÜRÜCÜ 6
            If Info.IdentityCode6 = "KN" Or Info.IdentityCode6 = "PN" Or Info.SIdentityCode = "GK" Then
                If Info.IdentityNumber6 <> "" Then
                    girdi6(aralikcnt) = "Evet"
                    d6_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_6_icin(aralikcnt) = _
                    damagebul_kimligegore(Info.IdentityCountryCode6, Info.IdentityNumber6, Info.IdentityCode6, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_6_icin(aralikcnt) = araliktaki_hasar_listesi_6_icin(aralikcnt).Count
                    donecektotal_damage_count_6_icin = donecektotal_damage_count_6_icin + araliktaki_hasar_listesi_6_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve 6 için" + _
                    " kimlik numarası KN veya PN veya GK olan sorgu bulundu ve" + _
                    " bu sorgu için kimlik numarası " + Info.IdentityNumber6 + " dır.--"
                End If
            End If

            aralikcnt = aralikcnt + 1
        Next


        'PLAKAYA GÖRE ARALIKTAKİ HASARLARI BUL
        aralikcnt = 0
        If s1_birkerebilegirdimi = "Hayır" And d1_birkerebilegirdimi = "Hayır" And _
        d2_birkerebilegirdimi = "Hayır" And d3_birkerebilegirdimi = "Hayır" And _
        d4_birkerebilegirdimi = "Hayır" And d5_birkerebilegirdimi = "Hayır" And _
        d6_birkerebilegirdimi = "Hayır" Then
            For Each itemaralik As CLASSARALIK In araliklar
                If Info.PlateNumber <> "" Then
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + "--PLAKAYA GÖRE SORGULAMA YAPIYORUM. KN VEYA PN VEYA GK olan KİMLİK BULAMADIM. --"
                    girdiplaka(aralikcnt) = "Evet"
                    plaka_birkerebilegirdimi = "Evet"
                    araliktaki_hasar_listesi_plaka_icin(aralikcnt) = _
                    damagebul_plakayagore(Info.PlateNumber, itemaralik.baslangic, itemaralik.bitis)
                    total_damage_count_plaka_icin(aralikcnt) = araliktaki_hasar_listesi_plaka_icin(aralikcnt).Count
                    donecektotal_damage_count_plaka_icin = donecektotal_damage_count_plaka_icin + araliktaki_hasar_listesi_plaka_icin(aralikcnt).Count
                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + CStr(aralikcnt + 1) + ". aralık ve plaka bulundu" + _
                    " bu sorgu için plaka " + Info.PlateNumber + " dır.--"
                End If
                aralikcnt = aralikcnt + 1
            Next
        End If

        aralikcnt = 0

        'araliklar arasinda dolaş ve o aralığın içindeki tüm hasarların toplamlarını bul
        For Each itemaralik As CLASSARALIK In araliklar

            'plaka için başla 
            If girdiplaka(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_plaka_icin(aralikcnt)
                    donecektotal_damage_cost_plaka_icin = donecektotal_damage_cost_plaka_icin + Item.DamageCost
                Next
            End If

            's1 için başla 
            If girdis(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_s1_icin(aralikcnt)
                    donecektotal_damage_cost_s1_icin = donecektotal_damage_cost_s1_icin + Item.DamageCost
                Next
            End If

            '1 için başla 
            If girdi1(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_1_icin(aralikcnt)
                    donecektotal_damage_cost_1_icin = donecektotal_damage_cost_1_icin + Item.DamageCost
                Next
            End If

            '2 için başla 
            If girdi2(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_2_icin(aralikcnt)
                    donecektotal_damage_cost_2_icin = donecektotal_damage_cost_2_icin + Item.DamageCost
                Next
            End If

            '3 için başla 
            If girdi3(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_1_icin(aralikcnt)
                    donecektotal_damage_cost_3_icin = donecektotal_damage_cost_3_icin + Item.DamageCost
                Next
            End If

            '4 için başla 
            If girdi4(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_1_icin(aralikcnt)
                    donecektotal_damage_cost_4_icin = donecektotal_damage_cost_4_icin + Item.DamageCost
                Next
            End If

            '5 için başla 
            If girdi5(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_1_icin(aralikcnt)
                    donecektotal_damage_cost_5_icin = donecektotal_damage_cost_5_icin + Item.DamageCost
                Next
            End If

            '6 için başla 
            If girdi6(aralikcnt) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_1_icin(aralikcnt)
                    donecektotal_damage_cost_6_icin = donecektotal_damage_cost_6_icin + Item.DamageCost
                Next
            End If

            aralikcnt = aralikcnt + 1

        Next

        'HER ARALIKTAKİ TOPLAM DAMAGECOST U BUL 
        Dim xy As Integer = 0
        For Each itemaralik As CLASSARALIK In araliklar

            If girdiplaka(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_plaka_icin(xy)
                    total_damage_cost_plaka_icin(xy) = total_damage_cost_plaka_icin(xy) + Item.DamageCost
                Next
            End If

            If girdis(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_s1_icin(xy)
                    total_damage_cost_s1_icin(xy) = total_damage_cost_s1_icin(xy) + Item.DamageCost
                Next
            End If
            If girdi1(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_1_icin(xy)
                    total_damage_cost_1_icin(xy) = total_damage_cost_1_icin(xy) + Item.DamageCost
                Next
            End If
            If girdi2(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_2_icin(xy)
                    total_damage_cost_2_icin(xy) = total_damage_cost_2_icin(xy) + Item.DamageCost
                Next
            End If
            If girdi3(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_3_icin(xy)
                    total_damage_cost_3_icin(xy) = total_damage_cost_3_icin(xy) + Item.DamageCost
                Next
            End If
            If girdi4(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_4_icin(xy)
                    total_damage_cost_4_icin(xy) = total_damage_cost_4_icin(xy) + Item.DamageCost
                Next
            End If
            If girdi5(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_5_icin(xy)
                    total_damage_cost_5_icin(xy) = total_damage_cost_5_icin(xy) + Item.DamageCost
                Next
            End If
            If girdi6(xy) = "Evet" Then
                For Each Item As tekdamage In araliktaki_hasar_listesi_6_icin(xy)
                    total_damage_cost_6_icin(xy) = total_damage_cost_6_icin(xy) + Item.DamageCost
                Next
            End If
            xy = xy + 1
        Next

        Dim ikidecimal As New CLASSIKIDECIMAL


        'PLAKA İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If plaka_birkerebilegirdimi = "Evet" Or ms_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_plaka_icin, total_damage_cost_plaka_icin, "PLAKA", plaka_icin, "")
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_plaka_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_plaka_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_plaka_icin.Policy = plaka_icin
        donecekdamage_plaka_icin.TotalDamageCount = donecektotal_damage_count_plaka_icin
        donecekdamage_plaka_icin.TotalDamageCost = donecektotal_damage_cost_plaka_icin
        donecekdamage_plaka_icin.Hangisi = "plaka"



        'S1 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL 
        If s1_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_s1_icin, total_damage_cost_s1_icin, "KİMLİK", policy_s1_icin, Info.SIdentityCountryCode)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_s1_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_s1_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_s1_icin.Policy = policy_s1_icin
        donecekdamage_s1_icin.TotalDamageCount = donecektotal_damage_count_s1_icin
        donecekdamage_s1_icin.TotalDamageCost = donecektotal_damage_cost_s1_icin
        donecekdamage_s1_icin.Hangisi = "s1"


        '1 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If d1_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_1_icin, total_damage_cost_1_icin, "KİMLİK", policy_1_icin, Info.IdentityCountryCode1)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_1_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_1_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_1_icin.Policy = policy_1_icin
        donecekdamage_1_icin.TotalDamageCount = donecektotal_damage_count_1_icin
        donecekdamage_1_icin.TotalDamageCost = donecektotal_damage_cost_1_icin
        donecekdamage_1_icin.Hangisi = "d1"

        '2 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If d2_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_2_icin, total_damage_cost_2_icin, "KİMLİK", policy_2_icin, Info.IdentityCountryCode2)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_2_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_2_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_2_icin.Policy = policy_2_icin
        donecekdamage_2_icin.TotalDamageCount = donecektotal_damage_count_2_icin
        donecekdamage_2_icin.TotalDamageCost = donecektotal_damage_cost_2_icin
        donecekdamage_2_icin.Hangisi = "d2"

        '3 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If d3_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_3_icin, total_damage_cost_3_icin, "KİMLİK", policy_3_icin, Info.IdentityCountryCode3)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_3_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_3_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_3_icin.Policy = policy_3_icin
        donecekdamage_3_icin.TotalDamageCount = donecektotal_damage_count_3_icin
        donecekdamage_3_icin.TotalDamageCost = donecektotal_damage_cost_3_icin
        donecekdamage_3_icin.Hangisi = "d3"

        '4 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If d4_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_4_icin, total_damage_cost_4_icin, "KİMLİK", policy_4_icin, Info.IdentityCountryCode4)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_4_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_4_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_4_icin.Policy = policy_4_icin
        donecekdamage_4_icin.TotalDamageCount = donecektotal_damage_count_4_icin
        donecekdamage_4_icin.TotalDamageCost = donecektotal_damage_cost_4_icin
        donecekdamage_4_icin.Hangisi = "d4"

        '5 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If d5_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_5_icin, total_damage_cost_5_icin, "KİMLİK", policy_5_icin, Info.IdentityCountryCode5)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_5_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_5_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_5_icin.Policy = policy_5_icin
        donecekdamage_5_icin.TotalDamageCount = donecektotal_damage_count_5_icin
        donecekdamage_5_icin.TotalDamageCost = donecektotal_damage_cost_5_icin
        donecekdamage_5_icin.Hangisi = "d5"

        '6 İÇİN DAMAGERATE VE DAMAGELESS RATE BUL
        If d6_birkerebilegirdimi = "Evet" Then
            ikidecimal = tekkisiicinhesapla_zamveindirim(Info, araliklar, total_damage_count_6_icin, total_damage_cost_6_icin, "KİMLİK", policy_6_icin, Info.IdentityCountryCode6)
        Else
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If
        donecekdamage_6_icin.DamagelessRate = ikidecimal.damagelessrate
        donecekdamage_6_icin.DamageRate = ikidecimal.damagerate
        donecekdamage_6_icin.Policy = policy_6_icin
        donecekdamage_6_icin.TotalDamageCount = donecektotal_damage_count_6_icin
        donecekdamage_6_icin.TotalDamageCost = donecektotal_damage_cost_6_icin
        donecekdamage_6_icin.Hangisi = "d6"

        Dim dahaoncepoliceyadahasarivarmi As String

        Dim SIdentityNumber_kesilmis As String = ""
        Dim IdentityNumber1_kesilmis As String = ""
        Dim IdentityNumber2_kesilmis As String = ""
        Dim IdentityNumber3_kesilmis As String = ""
        Dim IdentityNumber4_kesilmis As String = ""
        Dim IdentityNumber5_kesilmis As String = ""
        Dim IdentityNumber6_kesilmis As String = ""

        If Info.SIdentityCountryCode = "601" Then
            If Len(Info.SIdentityNumber) = 10 Then
                SIdentityNumber_kesilmis = Mid(Info.SIdentityNumber, 5, 6)
            End If
        End If
        If Info.IdentityCountryCode1 = "601" Then
            If Len(Info.IdentityNumber1) = 10 Then
                IdentityNumber1_kesilmis = Mid(Info.IdentityNumber1, 5, 6)
            End If
        End If
        If Info.IdentityCountryCode2 = "602" Then
            If Len(Info.IdentityNumber2) = 10 Then
                IdentityNumber2_kesilmis = Mid(Info.IdentityNumber2, 5, 6)
            End If
        End If
        If Info.IdentityCountryCode3 = "603" Then
            If Len(Info.IdentityNumber3) = 10 Then
                IdentityNumber3_kesilmis = Mid(Info.IdentityNumber3, 5, 6)
            End If
        End If
        If Info.IdentityCountryCode4 = "604" Then
            If Len(Info.IdentityNumber4) = 10 Then
                IdentityNumber4_kesilmis = Mid(Info.IdentityNumber4, 5, 6)
            End If
        End If
        If Info.IdentityCountryCode5 = "605" Then
            If Len(Info.IdentityNumber5) = 10 Then
                IdentityNumber5_kesilmis = Mid(Info.IdentityNumber5, 5, 6)
            End If
        End If
        If Info.IdentityCountryCode6 = "606" Then
            If Len(Info.IdentityNumber6) = 10 Then
                IdentityNumber6_kesilmis = Mid(Info.IdentityNumber6, 5, 6)
            End If
        End If









        'KİMLİK VE PLAKAYA BİRLİKTE BAK  ----------------
        Dim s1hepbirlikte As New CLASSLOGVEDECIMAL
        Dim IdentityNumber1birlikte As New CLASSLOGVEDECIMAL
        Dim IdentityNumber2birlikte As New CLASSLOGVEDECIMAL
        Dim IdentityNumber3birlikte As New CLASSLOGVEDECIMAL
        Dim IdentityNumber4birlikte As New CLASSLOGVEDECIMAL
        Dim IdentityNumber5birlikte As New CLASSLOGVEDECIMAL
        Dim IdentityNumber6birlikte As New CLASSLOGVEDECIMAL
        s1hepbirlikte = DamageInfoServiceHelper_erisim.kimlikplakabirlikte(Info, "PolicyOwnerIdentityNo", Info.SIdentityNumber, araliklar)
        getdamagelog = getdamagelog + s1hepbirlikte.logx
        If s1hepbirlikte.hasaroran >= donecekdamage_s1_icin.DamageRate And s1hepbirlikte.simdikiyilhasarvarmi = "Evet" Then
            getdamagelog = getdamagelog + s1hepbirlikte.logx
            getdamagelog = getdamagelog + "Kimlik ve plakaya birlikte bakıldığında bulunan " +
                " hasar zammı değeri şu ana kadar hesaplanan hasar zammı değerinden büyük. " +
                " Bu sebepten S1 için hasar zammını " + CStr(s1hepbirlikte.hasaroran) + " çıkartıyorum.--"
            donecekdamage_s1_icin.DamageRate = s1hepbirlikte.hasaroran
            donecekdamage_s1_icin.DamagelessRate = s1hepbirlikte.hasarsizlikoran
        End If










        'DAHA ÖNCE POLİÇESİ VE HASARI YOKSA SIFIRLA --------------------------------------------------
        If plaka_birkerebilegirdimi = "Evet" Or ms_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.plakada_policevarmi(Info.PlateNumber)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.PlateNumber + " plakası için " + _
                " daha önce herhangi bir poliçe olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.--"
                donecekdamage_s1_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_s1_icin.DamageRate = ikidecimal.damagerate
            End If
        End If

        If s1_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.SIdentityNumber, Info.SIdentityCountryCode)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.SIdentityNumber + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + SIdentityNumber_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_s1_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_s1_icin.DamageRate = ikidecimal.damagerate
            End If
        End If
        If d1_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.IdentityNumber1, Info.IdentityCountryCode1)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.IdentityNumber1 + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + IdentityNumber1_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_1_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_1_icin.DamageRate = ikidecimal.damagerate
            End If
        End If
        If d2_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.IdentityNumber2, Info.IdentityCountryCode2)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.IdentityNumber2 + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + IdentityNumber2_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_2_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_2_icin.DamageRate = ikidecimal.damagerate
            End If
        End If
        If d3_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.IdentityNumber3, Info.IdentityCountryCode3)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.IdentityNumber3 + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + IdentityNumber3_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_3_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_3_icin.DamageRate = ikidecimal.damagerate
            End If
        End If
        If d4_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.IdentityNumber4, Info.IdentityCountryCode4)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.IdentityNumber4 + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + IdentityNumber4_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_4_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_4_icin.DamageRate = ikidecimal.damagerate
            End If
        End If
        If d5_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.IdentityNumber5, Info.IdentityCountryCode5)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.IdentityNumber5 + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + IdentityNumber5_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_5_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_5_icin.DamageRate = ikidecimal.damagerate
            End If
        End If
        If d6_birkerebilegirdimi = "Evet" Then
            dahaoncepoliceyadahasarivarmi = kimlikplakapolicehasar_erisim.kimlikte_hasaryadapolicevarmi(Info.IdentityNumber6, Info.IdentityCountryCode5)
            If dahaoncepoliceyadahasarivarmi = "Hayır" Then
                getdamagelog = getdamagelog + "&nbsp;&nbsp;" + Info.IdentityNumber6 + " kimlik numarası için " + _
                " daha önce herhangi bir poliçe olmadığından ve hasarıda olmadığından herhangi bir hasar zammı yada hasarsızlık indirimi " + _
                " dönmüyorum.-- Ayrıca " + IdentityNumber6_kesilmis + " kimlik numarasına da bakıldı."
                donecekdamage_6_icin.DamagelessRate = ikidecimal.damagelessrate
                donecekdamage_6_icin.DamageRate = ikidecimal.damagerate
            End If
        End If



        'ANYMOTOR İSE VE PLAKAYA GÖRE-----
        If plaka_birkerebilegirdimi = "Evet" Then
            If plaka_icin = "ANYMOTOR" Then
                getdamagelog = getdamagelog + "Plaka için ANYMOTOR gönderildiğinden " + _
                "herhangi bir hasar zammı yada hasarsızlık indirimi uygulamıyorum--"
                donecekdamage_plaka_icin.DamagelessRate = 0
                donecekdamage_plaka_icin.DamageRate = 0
                donecekdamage_plaka_icin.Policy = "ANYMOTOR"
                donecekdamage_plaka_icin.TotalDamageCount = 0
                donecekdamage_plaka_icin.TotalDamageCost = 0
            End If
        End If

        'EĞER PLAKA TR İLE BAŞLIYOR İSE 
        If plaka_birkerebilegirdimi = "Evet" Then
            If Len(plaka_icin) > 2 Then
                If Mid(plaka_icin, 1, 2) = "TR" Then
                    getdamagelog = getdamagelog + "TR Plaka gönderildiğinden " + _
                    "herhangi bir hasar zammı yada hasarsızlık indirimi uygulamıyorum--"
                    donecekdamage_plaka_icin.DamagelessRate = 0
                    donecekdamage_plaka_icin.DamageRate = 0
                    donecekdamage_plaka_icin.Policy = plaka_icin
                    donecekdamage_plaka_icin.TotalDamageCount = 0
                    donecekdamage_plaka_icin.TotalDamageCost = 0
                End If
            End If
        End If

        'ANYMOTOR İSE VE MENŞEYE GÖRE----
        If ms_birkerebilegirdimi = "Evet" Then
            If plaka_icin = "ANYMOTOR" Then
                getdamagelog = getdamagelog + "Plaka için ANYMOTOR gönderildiğinden " + _
                "herhangi bir hasar zammı yada hasarsızlık indirimi uygulamıyorum--"
                donecekdamage_s1_icin.DamagelessRate = 0
                donecekdamage_s1_icin.DamageRate = 0
                donecekdamage_s1_icin.Policy = "ANYMOTOR"
                donecekdamage_s1_icin.TotalDamageCount = 0
                donecekdamage_s1_icin.TotalDamageCost = 0
            End If
        End If


        '------------------------------------------------------------------------------------
        Dim damages As New List(Of Damage)
        If s1_birkerebilegirdimi = "Evet" Or d1_birkerebilegirdimi = "Evet" Or _
        d2_birkerebilegirdimi = "Evet" Or d3_birkerebilegirdimi = "Evet" Or _
        d4_birkerebilegirdimi = "Evet" Or d5_birkerebilegirdimi = "Evet" Or _
        d6_birkerebilegirdimi = "Evet" Then
            damages.Add(donecekdamage_s1_icin)
            damages.Add(donecekdamage_1_icin)
            damages.Add(donecekdamage_2_icin)
            damages.Add(donecekdamage_3_icin)
            damages.Add(donecekdamage_4_icin)
            damages.Add(donecekdamage_5_icin)
            damages.Add(donecekdamage_6_icin)
        End If

        If plaka_birkerebilegirdimi = "Evet" Or ms_birkerebilegirdimi = "Evet" Then
            damages.Remove(donecekdamage_s1_icin)
            damages.Add(donecekdamage_plaka_icin)
        End If


        'SON OLARAK DÖNEN TÜM DEĞERLER 
        Dim sonhesaplananlog As String = ""
        sonhesaplananlog = sonhesaplananlog + "----"
        sonhesaplananlog = sonhesaplananlog + "HESAPLANAN SON DEĞERLER--"

        If plaka_birkerebilegirdimi = "Evet" Or ms_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "S1 (PLAKA) Hasarsızlık İndirimi: %" + CStr(donecekdamage_plaka_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "S1 (PLAKA) Hasar Zammı: %" + CStr(donecekdamage_plaka_icin.DamageRate) + "--"
        End If
        If s1_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "S1 Hasarsızlık İndirimi: %" + CStr(donecekdamage_s1_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "S1 Hasar Zammı: %" + CStr(donecekdamage_s1_icin.DamageRate) + "--"
        End If

        If d1_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "Sürücü 1 Hasarsızlık İndirimi: %" + CStr(donecekdamage_1_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "Sürücü1 Hasar Zammı: %" + CStr(donecekdamage_1_icin.DamageRate) + "--"
        End If
        If d2_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "Sürücü 2 Hasarsızlık İndirimi: %" + CStr(donecekdamage_2_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "Sürücü2 Hasar Zammı: %" + CStr(donecekdamage_2_icin.DamageRate) + "--"
        End If
        If d3_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "Sürücü 3 Hasarsızlık İndirimi: %" + CStr(donecekdamage_3_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "Sürücü3 Hasar Zammı: %" + CStr(donecekdamage_3_icin.DamageRate) + "--"
        End If
        If d4_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "Sürücü 4 Hasarsızlık İndirimi: %" + CStr(donecekdamage_4_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "Sürücü4 Hasar Zammı: %" + CStr(donecekdamage_4_icin.DamageRate) + "--"
        End If
        If d5_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "Sürücü 5 Hasarsızlık İndirimi: %" + CStr(donecekdamage_5_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "Sürücü5 Hasar Zammı: %" + CStr(donecekdamage_5_icin.DamageRate) + "--"
        End If
        If d6_birkerebilegirdimi = "Evet" Then
            sonhesaplananlog = sonhesaplananlog + "Sürücü 6 Hasarsızlık İndirimi: %" + CStr(donecekdamage_6_icin.DamagelessRate) + "--"
            sonhesaplananlog = sonhesaplananlog + "Sürücü6 Hasar Zammı: %" + CStr(donecekdamage_6_icin.DamageRate) + "--"
        End If
        getdamagelog = getdamagelog + sonhesaplananlog

        '----------------------------------------------------------------------------------------------

        root.ResultCode = 1
        root.Damages = damages
        ErrorInfo.Code = 0
        ErrorInfo.Message = getdamagelog
        root.ErrorInfo = ErrorInfo
        root.informationtag = informationtag

        Dim donecekstr As String = ""

        'BAŞARILI İSE GETDAMAGELOG LU KAYDET ODA ERRORINFO.MESSAGE DA KAYITLI ZATEN
        If root.ResultCode = 1 Then

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sifresahibisirket.pkey, "GetDamageInformation", _
            root.ResultCode, root.ErrorInfo.Code, "", 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", InfoXML, wskullaniciad, wssifre, "", 0, "", root.ErrorInfo.Message, "", ip_erisim.ipadresibul))

            'Dim degistirilecek As String = Chr(34) + "0" + Chr(34)
            'Dim olacak = Chr(34) + Chr(34)

            Dim icdamage As String = ""
            Dim g_agerate, g_damagerate, g_damagelessrate, g_totaldamagecost As String

            For Each itemdamage As Damage In root.Damages

                'eğer birşey göndermiş ise
                If itemdamage.Policy <> "" Then
                    icdamage = icdamage + "<Damage Policy=" + Chr(34) + CStr(itemdamage.Policy) + Chr(34) + _
                    " AgeRate=" + Chr(34) + CStr(itemdamage.AgeRate) + Chr(34) + _
                    " TotalDamageCount=" + Chr(34) + CStr(itemdamage.TotalDamageCount) + Chr(34) + _
                    " TotalDamageCost=" + Chr(34) + Format(itemdamage.TotalDamageCost, "0.00") + Chr(34) + _
                    " DamageRate=" + Chr(34) + CStr(itemdamage.DamageRate) + Chr(34) + _
                    " DamagelessRate=" + Chr(34) + CStr(itemdamage.DamagelessRate) + Chr(34) + "/>"
                End If

                'birşey göndermemiş ise sende boş dön
                If itemdamage.Policy = "" Then
                    icdamage = icdamage + "<Damage Policy=" + Chr(34) + CStr(itemdamage.Policy) + Chr(34) + _
                    " AgeRate=" + Chr(34) + Chr(34) + _
                    " TotalDamageCount=" + Chr(34) + Chr(34) + _
                    " TotalDamageCost=" + Chr(34) + Chr(34) + _
                    " DamageRate=" + Chr(34) + Chr(34) + _
                    " DamagelessRate=" + Chr(34) + Chr(34) + "/>"
                End If

            Next
            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + "1" + Chr(34) + ">" + _
            root.informationtag + _
            "<Damages>" + _
            icdamage + _
            "</Damages>" + _
            "</root>"

            Return root.GetDamageResultStr

        End If


    End Function


    'GetDamageInformation servisi için kimliğe göre damage buluyoruz
    Public Function damagebul_kimligegore(ByVal IdentityCountryCode As String, _
    ByVal DriverIdentityNo As String, _
    ByVal DriverIdentityCode As String, _
    ByVal aralikbaslangic As DateTime, _
    ByVal aralikbitis As DateTime) As List(Of tekdamage)

        Dim PaidAmountTotal As Decimal
        Dim PaidMaterialAmountTL, PaidCorporalAmountTL As Decimal

        Dim AccidentDate As Date
        Dim kazatarihleri As New List(Of CLASSKAZATARIH)
        Dim kazatarih_erisim As New CLASSKAZATARIH_ERISIM
        kazatarihleri.Clear()

        Dim donecek_araliktakitekdamagelist As New List(Of tekdamage)
        Dim tekdamage As New tekdamage

        Dim girmismi As String = "Hayır"
        Dim iptaledilmismi As String
        Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM

        Dim zx As Integer = 1
        Dim kdamage As New DamageInfo


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim sqldevam As String
        If IdentityCountryCode = "601" Then
            If Len(DriverIdentityNo) = 10 Then
                Dim kesilmiskimlik As String = Mid(DriverIdentityNo, 5, 6)
                sqldevam = " or DriverIdentityNo='" + kesilmiskimlik + "'"
                getdamagelog = getdamagelog + "Ayrıca " + kesilmiskimlik + " numarasına da bakıyorum. --"
            End If
        End If

        sqlstr = "select FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo," + _
        "RequestNo,ProductType,DriverIdentityNo, " + _
        "PaidMaterialAmountTL,PaidCorporalAmountTL, " + _
        "AccidentDate from DamageInfo " + _
        "where (DriverIdentityNo=@DriverIdentityNo" + sqldevam + " )" + _
        " and (DamageStatusCode='KP' or DamageStatusCode='OD') and " + _
        "(AccidentDate<=@aralikbaslangic and AccidentDate>=@aralikbitis) and " + _
        "(PaidMaterialAmountTL>0 or PaidCorporalAmountTL>0) and " + _
        "DriverIdentityCode=@DriverIdentityCode"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@DriverIdentityNo", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = DriverIdentityNo
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@aralikbaslangic", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = aralikbaslangic
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aralikbitis", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        param3.Value = aralikbitis
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@DriverIdentityCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = DriverIdentityCode
        komut.Parameters.Add(param4)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                girmismi = "Evet"

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    kdamage.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    kdamage.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    kdamage.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    kdamage.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    kdamage.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    kdamage.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    kdamage.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    kdamage.ProductType = veri.Item("ProductType")
                End If

                iptaledilmismi = damagecancel_erisim.hasariptaledilmismi(kdamage.FirmCode, _
                kdamage.ProductCode, kdamage.AgencyCode, kdamage.PolicyNumber, _
                kdamage.TecditNumber, kdamage.FileNo, kdamage.RequestNo, kdamage.ProductType, "Kimlik")

                If iptaledilmismi = "Hayır" Then

                    If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                        tekdamage.Policy = veri.Item("DriverIdentityNo")
                    End If

                    If Not veri.Item("PaidMaterialAmountTL") Is System.DBNull.Value Then
                        PaidMaterialAmountTL = veri.Item("PaidMaterialAmountTL")
                    Else
                        PaidMaterialAmountTL = 0
                    End If
                    If Not veri.Item("PaidCorporalAmountTL") Is System.DBNull.Value Then
                        PaidCorporalAmountTL = veri.Item("PaidCorporalAmountTL")
                    Else
                        PaidCorporalAmountTL = 0
                    End If
                    PaidAmountTotal = PaidMaterialAmountTL + PaidCorporalAmountTL

                    tekdamage.DamageCost = PaidAmountTotal


                    'EĞER 0 DAN BÜYÜK BİR RAKAM ÖDENMİŞ İSE
                    If tekdamage.DamageCost > 1 Then
                        'BU KAZA TARİHİNDE SADECE TEK BİR KAZA YI EKLE
                        If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                            AccidentDate = veri.Item("AccidentDate")
                            If kazatarih_erisim.butarihvarmi(kazatarihleri, AccidentDate) = "Hayır" Then
                                kazatarihleri.Add(New CLASSKAZATARIH(AccidentDate))
                                donecek_araliktakitekdamagelist.Add(New tekdamage(tekdamage.Policy, tekdamage.DamageCost))
                            End If
                        End If
                    End If


                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + "&nbsp;&nbsp;" + DriverIdentityNo + " kimlik numarası için: " + _
                    " ve " + CStr(aralikbaslangic) + " ile " + CStr(aralikbitis) + " tarihleri arasında:--" + _
                    CStr(kdamage.FirmCode) + "-" + CStr(kdamage.ProductCode) + "-" + _
                    CStr(kdamage.AgencyCode) + "-" + CStr(kdamage.PolicyNumber) + _
                    CStr(kdamage.TecditNumber) + "-" + CStr(kdamage.FileNo) + CStr(kdamage.RequestNo) + _
                    " Ödenen Hasar Tutarı:" + Format(tekdamage.DamageCost, "0.00") + "--"

                End If

                zx = zx + 1

            End While

        End Using

        If girmismi = "Hayır" Then
            getdamagelog = getdamagelog + "&nbsp;&nbsp;" + DriverIdentityNo + " kimlik numarası için: " + _
            " ve " + CStr(aralikbaslangic) + " ile " + CStr(aralikbitis) + " tarihleri arasında:--" + _
            "iptal edilmemiş herhangi bir hasar kaydı bulamadım.--"
        End If

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek_araliktakitekdamagelist

    End Function



    'GetDamageInformation servisi için plakaya göre damage buluyoruz
    Public Function damagebul_plakayagore(ByVal DriverPlateNumber As String, _
    ByVal aralikbaslangic As DateTime, _
    ByVal aralikbitis As DateTime) As List(Of tekdamage)

        Dim kiralikplaka_ek As String
        Dim sql_kiralikaracdevam = ""
        Dim kiralikmi As String = "Hayır"

        If Len(DriverPlateNumber) > 1 Then
            'eğer başı Z ile başlıyor ise
            If Mid(DriverPlateNumber, 1, 1) = "Z" Then
                kiralikmi = "Evet"
                kiralikplaka_ek = Mid(DriverPlateNumber, 2, Len(DriverPlateNumber)) + "Z"
                sql_kiralikaracdevam = " or DriverPlateNumber=@DriverPlateNumber2"
                getdamagelog = getdamagelog + "Plakanın başı Z ile başladığından ayrıca " + kiralikplaka_ek + " plakasınıda sorguluyorum.--"
            End If
            'eğer sonu z ile bitiyor ise
            If Mid(DriverPlateNumber, Len(DriverPlateNumber), 1) = "Z" Then
                kiralikmi = "Evet"
                kiralikplaka_ek = "Z" + Mid(DriverPlateNumber, 1, Len(DriverPlateNumber) - 1)
                sql_kiralikaracdevam = " or DriverPlateNumber=@DriverPlateNumber2"
                getdamagelog = getdamagelog + "Plakanın sonu Z ile bittiğinden ayrıca " + kiralikplaka_ek + " plakasınıda sorguluyorum.--"
            End If
        End If

        Dim girmismi As String = "Hayır"

        Dim PaidAmountTotal As Decimal
        Dim PaidMaterialAmountTL, PaidCorporalAmountTL As Decimal

        Dim AccidentDate As Date
        Dim kazatarihleri As New List(Of CLASSKAZATARIH)
        Dim kazatarih_erisim As New CLASSKAZATARIH_ERISIM
        kazatarihleri.Clear()

        Dim iptaledilmismi As String
        Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM

        Dim zx As Integer = 1
        Dim kdamage As New DamageInfo
        Dim donecek_araliktakitekdamagelist As New List(Of tekdamage)
        Dim tekdamage As New tekdamage

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo," + _
        "RequestNo,ProductType, DriverIdentityNo,DriverPlateNumber,PaidMaterialAmountTL,PaidCorporalAmountTL," + _
        "AccidentDate from DamageInfo " + _
        "where (DriverPlateNumber=@DriverPlateNumber " + sql_kiralikaracdevam + ")" + _
        " and (DamageStatusCode='KP' or DamageStatusCode='OD') and " + _
        "(AccidentDate<=@aralikbaslangic and AccidentDate>=@aralikbitis)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@DriverPlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = DriverPlateNumber
        komut.Parameters.Add(param1)

        If kiralikmi = "Evet" Then
            Dim param2 As New SqlParameter("@DriverPlateNumber2", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = kiralikplaka_ek
            komut.Parameters.Add(param2)
        End If

        Dim param3 As New SqlParameter("@aralikbaslangic", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        param3.Value = aralikbaslangic
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@aralikbitis", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        param4.Value = aralikbitis
        komut.Parameters.Add(param4)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                girmismi = "Evet"

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    kdamage.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    kdamage.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    kdamage.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    kdamage.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    kdamage.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    kdamage.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    kdamage.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    kdamage.ProductType = veri.Item("ProductType")
                End If

                iptaledilmismi = damagecancel_erisim.hasariptaledilmismi(kdamage.FirmCode, _
                 kdamage.ProductCode, kdamage.AgencyCode, kdamage.PolicyNumber, _
                 kdamage.TecditNumber, kdamage.FileNo, kdamage.RequestNo, kdamage.ProductType, "Plaka")

                If iptaledilmismi = "Hayır" Then

                    If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                        tekdamage.Policy = veri.Item("DriverPlateNumber")
                    End If

                    If Not veri.Item("PaidMaterialAmountTL") Is System.DBNull.Value Then
                        PaidMaterialAmountTL = veri.Item("PaidMaterialAmountTL")
                    Else
                        PaidMaterialAmountTL = 0
                    End If
                    If Not veri.Item("PaidCorporalAmountTL") Is System.DBNull.Value Then
                        PaidCorporalAmountTL = veri.Item("PaidCorporalAmountTL")
                    Else
                        PaidCorporalAmountTL = 0
                    End If
                    PaidAmountTotal = PaidMaterialAmountTL + PaidCorporalAmountTL

                    tekdamage.DamageCost = PaidAmountTotal


                    'EĞER 0 DAN BÜYÜK BİR RAKAM ÖDENMİŞ İSE
                    If tekdamage.DamageCost > 1 Then
                        'BU KAZA TARİHİNDE SADECE TEK BİR KAZA YI EKLE
                        If DriverPlateNumber <> "ANYMOTOR" Then
                            If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                                AccidentDate = veri.Item("AccidentDate")
                                If kazatarih_erisim.butarihvarmi(kazatarihleri, AccidentDate) = "Hayır" Then
                                    kazatarihleri.Add(New CLASSKAZATARIH(AccidentDate))
                                    donecek_araliktakitekdamagelist.Add(New tekdamage(tekdamage.Policy, tekdamage.DamageCost))
                                End If
                            End If
                        End If
                    End If


                    'GETDAMAGELOG---------------------------------------------
                    getdamagelog = getdamagelog + "&nbsp;&nbsp;" + DriverPlateNumber + " " + kiralikplaka_ek + " plaka(lar)ı için: " + _
                    " ve " + CStr(aralikbaslangic) + " ile " + CStr(aralikbitis) + " tarihleri arasında:--" + _
                    CStr(kdamage.FirmCode) + "-" + CStr(kdamage.ProductCode) + "-" + _
                    CStr(kdamage.AgencyCode) + "-" + CStr(kdamage.PolicyNumber) + _
                    CStr(kdamage.TecditNumber) + "-" + CStr(kdamage.FileNo) + CStr(kdamage.RequestNo) + _
                    " Ödenen Hasar Tutarı:" + Format(tekdamage.DamageCost, "0.00") + "--"

                End If

                zx = zx + 1

            End While

        End Using

        If girmismi = "Hayır" Then
            getdamagelog = getdamagelog + "&nbsp;&nbsp;" + DriverPlateNumber + " " + kiralikplaka_ek + " plaka(lar)ı için: " + _
            " ve " + CStr(aralikbaslangic) + " ile " + CStr(aralikbitis) + " tarihleri arasında:--" + _
            "iptal edilmemiş herhangi bir hasar kaydı bulamadım.--"
        End If


        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek_araliktakitekdamagelist

    End Function



    Function tekkisiicinhesapla_zamveindirim(ByVal Info As Info, ByVal araliklar As List(Of CLASSARALIK), _
    ByVal t_damage_count() As Decimal, ByVal t_damage_cost() As Decimal, _
    ByVal nerden As String, ByVal kriter As String, _
    ByVal identitycountrycode As String) As CLASSIKIDECIMAL

        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim
        getdamagelog = getdamagelog + "BU " + nerden + " (" + kriter + ")" + " İÇİN BAŞLADI----"

        Dim eksok As Integer = 0
        Dim ikidecimal As New CLASSIKIDECIMAL

        ikidecimal.damagerate = 0
        ikidecimal.damagelessrate = 0

        'S1 İÇİN DAMAGERATE VE DAMAGELESS RATE İ BUL --------------------------------
        Dim simdikiyil, bironcekiyil, ikioncekiyil, uconcekiyil, dortoncekiyil As String

        dortoncekiyil = "yok"
        uconcekiyil = "yok"
        ikioncekiyil = "yok"
        bironcekiyil = "yok"
        simdikiyil = "yok"

        Dim a_cnt As Integer = 0
        'EN YENİ TARİHTEN EN ESKİ TARİHE GÖRE ARALIK  GEL
        For Each itemaralik As CLASSARALIK In araliklar
            If t_damage_count(a_cnt) > 0 And a_cnt = 0 Then
                simdikiyil = "var"
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + "Şimdiki yıl için hasarı var--"
            End If
            If t_damage_count(a_cnt) > 0 And a_cnt = 1 Then
                bironcekiyil = "var"
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + "Bir önceki yıl için hasarı var--"
            End If
            If t_damage_count(a_cnt) > 0 And a_cnt = 2 Then
                ikioncekiyil = "var"
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + "İki önceki yıl için hasarı var--"
            End If
            If t_damage_count(a_cnt) > 0 And a_cnt = 3 Then
                uconcekiyil = "var"
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + "Üç önceki yıl için hasarı var--"
            End If
            If t_damage_count(a_cnt) > 0 And a_cnt = 4 Then
                dortoncekiyil = "var"
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + "Dört önceki yıl için hasarı var--"
            End If
            a_cnt = a_cnt + 1
        Next

        'ÖNCE HERŞEYİ SIFIRLA 
        ikidecimal.damagerate = 0
        ikidecimal.damagelessrate = 0

        'SENARYO 1 ve SENARYO 2 Yİ UYGULA HASAR ORANI BULMAK İÇİN-----------------------------------------
        If simdikiyil = "var" Then
            If t_damage_count(0) > 0 Then

                If t_damage_count(0) > 1 Then
                    eksok = (t_damage_count(0) - 1) * 5
                End If

                ikidecimal.damagerate = tuzukhasargecirbul(t_damage_cost(0)) + eksok
                'GETDAMAGELOG---------------------------------------------
                getdamagelog = getdamagelog + "Şimdiki yıl için hasarı var ve toplam hasar sayısı:" + _
                CStr(t_damage_count(0)) + "-- Toplam ödenen hasar ücreti " + Format(t_damage_cost(0), "0.00") + " dır.--" + _
                "Şimdiki yıl için " + CStr(t_damage_count(0)) + " adet hasarı olduğundan ayrıca %" + CStr(eksok) + _
                " hasar zammı ekledim ve %" + CStr(ikidecimal.damagerate) + " hasar zammı gönderdim.--"
            End If
        End If

        'SENARYO 3.2 
        If simdikiyil = "var" And bironcekiyil = "yok" Then
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı var ve bir önceki yıl için hasarı yok.--" + _
            "Bu sebepten herhangi bir hasar zammı yada hasarsızlık indirimi uygulamadım.--"
        End If

        'SENARY0 3.3
        If simdikiyil = "yok" And bironcekiyil = "var" Then
            ikidecimal.damagelessrate = 10
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı yok ve bir önceki yıl için hasarı var.--" + _
            "Bu sebepten %10 luk hasarsızlık indirimi uyguladım.--"
        End If

        'SENARYO 3.4
        If simdikiyil = "yok" And bironcekiyil = "yok" And ikioncekiyil = "var" Then
            ikidecimal.damagelessrate = 20
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı yok ve bir önceki yıl için hasarı yok" + _
            " ve iki önceki yıl için hasarı var.--" + _
            "Bu sebepten %20 lik hasarsızlık indirimi uyguladım.--"
        End If

        'SENARYO 3.5
        If simdikiyil = "yok" And bironcekiyil = "yok" And ikioncekiyil = "yok" And uconcekiyil = "var" Then
            ikidecimal.damagelessrate = 30
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı yok ve bir önceki yıl için hasarı yok" + _
            " ve iki önceki yıl için hasarı yok ve üç önceki yıl için hasarı var.--" + _
            "Bu sebepten %30 lik hasarsızlık indirimi uyguladım.--"
        End If

        'SENARYO 3.6
        If simdikiyil = "yok" And bironcekiyil = "yok" And ikioncekiyil = "yok" And uconcekiyil = "yok" Then
            ikidecimal.damagelessrate = 40
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı yok bir önceki yıl için hasarı yok" + _
            " iki önceki yıl için hasarı yok ve üç önceki yıl hasarı yok. --" + _
            "Bu sebepten %40 lik hasarsızlık indirimi uyguladım.--"
        End If

        'SENARYO 3.7 
        If simdikiyil = "yok" And bironcekiyil = "yok" And ikioncekiyil = "yok" _
        And uconcekiyil = "yok" And dortoncekiyil = "var" Then
            ikidecimal.damagelessrate = 40
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı yok bir önceki yıl için hasarı yok" + _
            " iki önceki yıl için hasarı yok ve üç önceki yıl hasarı yok ve dört önceki yıl için hasarı var.--" + _
            "Bu sebepten %40 lik hasarsızlık indirimi uyguladım.--"
        End If

        'SENARYO 3.8 
        If simdikiyil = "yok" And bironcekiyil = "yok" And ikioncekiyil = "yok" _
        And uconcekiyil = "yok" And dortoncekiyil = "yok" Then
            ikidecimal.damagelessrate = 40
            ikidecimal.damagerate = 0
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Şimdiki yıl için hasarı yok bir önceki yıl için hasarı yok" + _
            " iki önceki yıl için hasarı yok ve üç önceki yıl hasarı yok ve dört önceki yıl için hasarı yok.--" + _
            "Bu sebepten %40 lik hasarsızlık indirimi uyguladım.--"
        End If

        If nerden = "PLAKA" And kriter = "ANYMOTOR" Then
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "ANYMOTOR VE PLAKAYA göre sorgulama yaptığımdan herhangi bir " + _
            "hasar zammı yada hasarsızlık indirimi uygulamadım.--"
            ikidecimal.damagelessrate = 0
            ikidecimal.damagerate = 0
        End If



        'PLAKA İSE SİSTEME İLK KAYIT TARİHE BAK VE ONA GÖRE İNDİRİM HAKKINI KISITLA 
        'KİMLİK İSE ARALIKLARA GÖRE POLİÇELERİNİ BUL VE POLİÇE SAYISINA GÖRE İNDİRİM HAKKINI KISITLA
        If nerden = "KİMLİK" Then
            If ikidecimal.damagelessrate > 0 Then
                Dim maksindirimihakki As Integer
                'maksindirimihakki = PolicyInfo2_erisim.kimlikte_yillaragorepolicesayisinagore_maxindirimhakki(kriter, identitycountrycode)
                maksindirimihakki = kimlikplakapolicehasar_erisim.kimlikte_sistemkayittarihegore_maxindirimhakki(identitycountrycode, kriter)
                getdamagelog = getdamagelog + "Kimliğe göre sisteme ilk kayıt tarihine göre kazanabileceği maksimum indirim hakkı oranı %:" + CStr(maksindirimihakki) + " dır. --"
                If ikidecimal.damagelessrate > maksindirimihakki Then
                    getdamagelog = getdamagelog + "Bu sebepten indirim oranını %" + CStr(maksindirimihakki) + " olarak değiştiriyorum. --"
                    ikidecimal.damagelessrate = maksindirimihakki
                End If
            End If
        End If
        If nerden = "PLAKA" Then
            If ikidecimal.damagelessrate > 0 Then
                Dim maksindirimihakki As Integer
                'maksindirimihakki = PolicyInfo2_erisim.plakada_yillaragorepolicesayisinagore_maxindirimhakki(kriter, identitycountrycode)
                maksindirimihakki = kimlikplakapolicehasar_erisim.plakada_sistemkayittarihegore_maxindirimhakki(kriter)
                getdamagelog = getdamagelog + "Plakaya göre sisteme ilk kayıt tarihine göre kazanabileceği maksimum indirim hakkı oranı %:" + CStr(maksindirimihakki) + " dır. --"
                If ikidecimal.damagelessrate > maksindirimihakki Then
                    getdamagelog = getdamagelog + "Bu sebepten indirim oranını %" + CStr(maksindirimihakki) + " olarak değiştiriyorum. --"
                    ikidecimal.damagelessrate = maksindirimihakki
                End If
            End If
        End If

        getdamagelog = getdamagelog + "BU " + nerden + " İÇİN BİTTİ----"

        Return ikidecimal

    End Function

    Public Function tuzukhasargecirbul(ByVal deger As Decimal) As Integer

        Dim hasargeciroran As Integer

        If deger <= 1000 Then
            hasargeciroran = 15
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 1000 TL'eşit veya altında olduğundan" + _
            " %15 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If
        If deger > 1000 And deger <= 2000 Then
            hasargeciroran = 20
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 1000 TL'den büyük ve 2000 TL'den küçük ve eşit olduğundan " + _
            "%20 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If
        If deger > 2000 And deger <= 3500 Then
            hasargeciroran = 25
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 2000 TL'den büyük ve 3500 TL'den küçük ve eşit olduğundan " + _
            "%25 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If
        If deger > 3500 And deger <= 5000 Then
            hasargeciroran = 30
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 3500 TL'den büyük ve 5000 TL'den küçük ve eşit olduğundan " + _
            "%30 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If
        If deger > 5000 And deger <= 8000 Then
            hasargeciroran = 35
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 5000 TL'den büyük ve 8000 TL'den küçük ve eşit olduğundan " + _
            "%35 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If
        If deger > 8000 And deger <= 15000 Then
            hasargeciroran = 40
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 8000 TL'den büyük ve 15000 TL'den küçük ve eşit olduğundan " + _
            "%40 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If
        If deger > 15000 Then
            hasargeciroran = 50
            'GETDAMAGELOG---------------------------------------------
            getdamagelog = getdamagelog + "Ödenen hasar ücreti 15000 TL'den büyük olduğundan " + _
            "%50 lik bir hasar zammı uygulanacak, eğer hasarsızlık indirimi hakkı yoksa.--"
        End If

        Return hasargeciroran

    End Function




    Function araliklaribul() As List(Of CLASSARALIK)

        Dim i As Integer
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim simdikitarih As Date
        simdikitarih = Date.Now

        Dim sistem_baslangictarih As Date = site.kullanimbaslangictarih
        sistem_baslangictarih = site.kullanimbaslangictarih

        Dim araliksayisi As Integer = 0
        Dim aralik As New CLASSARALIK
        Dim araliklar As New List(Of CLASSARALIK)

        i = 0
        aralik.baslangic = DateTime.Now
        While aralik.baslangic > sistem_baslangictarih
            aralik.baslangic = DateTime.Now.AddDays(i * -365)
            If DateTime.Now.AddDays((i + 1) * -365) > sistem_baslangictarih Then
                aralik.bitis = DateTime.Now.AddDays((i + 1) * -365)
            Else
                aralik.bitis = sistem_baslangictarih
            End If
            araliklar.Add(New CLASSARALIK(aralik.baslangic, aralik.bitis))
            aralik.baslangic = aralik.baslangic.AddDays(-365)
            i = i + 1
            araliksayisi = araliksayisi + 1

        End While

        Return araliklar

    End Function


    Public Function IsDamageSaved(ByVal UserName As String, _
   ByVal Password As String, ByVal FirmCode As String, _
   ByVal ProductCode As String, ByVal Producttype As String, _
   ByVal FileNo As String, ByVal RequestNo As String) As root


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

        'FileNo
        If FileNo = "" Then
            xmlhata = "FileNo parametresini yanlış gönderdiniz."
        End If

        'RequestNo
        If RequestNo = "" Then
            xmlhata = "RequestNo parametresini yanlış gönderdiniz."
        End If

        'ProductType
        If Producttype = "" Then
            xmlhata = "ProductType parametresini yanlış gönderdiniz."
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

            Dim DamageInfo_Erisim As New DamageInfo_Erisim
            Dim varmi As String
            varmi = DamageInfo_Erisim.ciftkayitkontrol(FirmCode, ProductCode, FileNo, RequestNo, Producttype)

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
