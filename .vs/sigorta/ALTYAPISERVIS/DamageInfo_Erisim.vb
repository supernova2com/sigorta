'1212 GetDamageInformation

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

Public Class DamageInfo_Erisim

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



    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal DamageInfo As DamageInfo) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into DamageInfo values (@FirmCode," + _
        "@ProductCode,@AgencyCode,@PolicyNumber,@TecditNumber," + _
        "@FileNo,@RequestNo,@DriverPlateCountryCode,@DriverPlateNumber," + _
        "@AccidentDate,@AccidentLocation,@InformingDate,@DriverCountryCode," + _
        "@DriverIdentityCode,@DriverIdentityNo,@DriverName,@DriverSurname," + _
        "@ClaimantCountryCode,@ClaimantIdentityCode,@ClaimantIdentityNo,@ClaimantName," + _
        "@ClaimantSurname,@AppealDate,@ClaimantPlateCountryCode,@ClaimantPlateNumber," + _
        "@DamageReason,@DamageStatusCode,@EstimatedMaterialDamage,@PaidMaterialDamage," + _
        "@CloseDate,@EstimatedCorporalDamage,@PaidCorporalDamage,@TotalLost," + _
        "@TariffCode,@CurrencyCode,@EstimatedMaterialAmountTL,@PaidMaterialAmountTL," + _
        "@EstimatedCorporalAmountTL,@PaidCorporalAmountTL,@ProductType,@SBMCode,@ExchangeRate," + _
        "@AgencyRegisterCode,@TPNo,@PolicyType)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param1.Direction = ParameterDirection.Input
        If DamageInfo.FirmCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = DamageInfo.FirmCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param2.Direction = ParameterDirection.Input
        If DamageInfo.ProductCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = DamageInfo.ProductCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param3.Direction = ParameterDirection.Input
        If DamageInfo.AgencyCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = DamageInfo.AgencyCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param4.Direction = ParameterDirection.Input
        If DamageInfo.PolicyNumber = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = DamageInfo.PolicyNumber
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
        param5.Direction = ParameterDirection.Input
        If DamageInfo.TecditNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = DamageInfo.TecditNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar, 15)
        param6.Direction = ParameterDirection.Input
        If DamageInfo.FileNo = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = DamageInfo.FileNo
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar, 2)
        param7.Direction = ParameterDirection.Input
        If DamageInfo.RequestNo = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = DamageInfo.RequestNo
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@DriverPlateCountryCode", SqlDbType.VarChar, 3)
        param8.Direction = ParameterDirection.Input
        If DamageInfo.DriverPlateCountryCode = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = DamageInfo.DriverPlateCountryCode
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@DriverPlateNumber", SqlDbType.VarChar, 50)
        param9.Direction = ParameterDirection.Input
        If DamageInfo.DriverPlateNumber = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = DamageInfo.DriverPlateNumber
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@AccidentDate", SqlDbType.Date)
        param10.Direction = ParameterDirection.Input
        If DamageInfo.AccidentDate Is Nothing Or DamageInfo.AccidentDate = "00:00:00" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = DamageInfo.AccidentDate
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@AccidentLocation", SqlDbType.VarChar, 40)
        param11.Direction = ParameterDirection.Input
        If DamageInfo.AccidentLocation = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = DamageInfo.AccidentLocation
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@InformingDate", SqlDbType.DateTime)
        param12.Direction = ParameterDirection.Input
        If DamageInfo.InformingDate Is Nothing Or DamageInfo.InformingDate = "00:00:00" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = DamageInfo.InformingDate
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@DriverCountryCode", SqlDbType.VarChar, 5)
        param13.Direction = ParameterDirection.Input
        If DamageInfo.DriverCountryCode = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = DamageInfo.DriverCountryCode
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@DriverIdentityCode", SqlDbType.VarChar, 3)
        param14.Direction = ParameterDirection.Input
        If DamageInfo.DriverIdentityCode = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = DamageInfo.DriverIdentityCode
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@DriverIdentityNo", SqlDbType.VarChar, 50)
        param15.Direction = ParameterDirection.Input
        If DamageInfo.DriverIdentityNo = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = DamageInfo.DriverIdentityNo
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@DriverName", SqlDbType.VarChar, 50)
        param16.Direction = ParameterDirection.Input
        If DamageInfo.DriverName = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = DamageInfo.DriverName
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@DriverSurname", SqlDbType.VarChar, 50)
        param17.Direction = ParameterDirection.Input
        If DamageInfo.DriverSurname = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = DamageInfo.DriverSurname
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@ClaimantCountryCode", SqlDbType.VarChar, 5)
        param18.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantCountryCode = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = DamageInfo.ClaimantCountryCode
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@ClaimantIdentityCode", SqlDbType.VarChar, 3)
        param19.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantIdentityCode = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = DamageInfo.ClaimantIdentityCode
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@ClaimantIdentityNo", SqlDbType.VarChar, 50)
        param20.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantIdentityNo = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = DamageInfo.ClaimantIdentityNo
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@ClaimantName", SqlDbType.VarChar, 50)
        param21.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantName = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = DamageInfo.ClaimantName
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@ClaimantSurname", SqlDbType.VarChar, 50)
        param22.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantSurname = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = DamageInfo.ClaimantSurname
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@AppealDate", SqlDbType.Date)
        param23.Direction = ParameterDirection.Input
        If DamageInfo.AppealDate Is Nothing Or DamageInfo.AppealDate = "00:00:00" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = DamageInfo.AppealDate
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@ClaimantPlateCountryCode", SqlDbType.VarChar, 10)
        param24.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantPlateCountryCode = "" Then
            param24.Value = System.DBNull.Value
        Else
            param24.Value = DamageInfo.ClaimantPlateCountryCode
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@ClaimantPlateNumber", SqlDbType.VarChar, 50)
        param25.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantPlateNumber = "" Then
            param25.Value = System.DBNull.Value
        Else
            param25.Value = DamageInfo.ClaimantPlateNumber
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@DamageReason", SqlDbType.VarChar, 15)
        param26.Direction = ParameterDirection.Input
        If DamageInfo.DamageReason = "" Then
            param26.Value = System.DBNull.Value
        Else
            param26.Value = DamageInfo.DamageReason
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar, 10)
        param27.Direction = ParameterDirection.Input
        If DamageInfo.DamageStatusCode = "" Then
            param27.Value = System.DBNull.Value
        Else
            param27.Value = DamageInfo.DamageStatusCode
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@EstimatedMaterialDamage", SqlDbType.Decimal)
        param28.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedMaterialDamage = 0 Then
            param28.Value = 0
        Else
            param28.Value = DamageInfo.EstimatedMaterialDamage
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@PaidMaterialDamage", SqlDbType.Decimal)
        param29.Direction = ParameterDirection.Input
        If DamageInfo.PaidMaterialDamage = 0 Then
            param29.Value = 0
        Else
            param29.Value = DamageInfo.PaidMaterialDamage
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@CloseDate", SqlDbType.Date)
        param30.Direction = ParameterDirection.Input
        If DamageInfo.CloseDate Is Nothing Or DamageInfo.CloseDate = "00:00:00" Then
            param30.Value = System.DBNull.Value
        Else
            param30.Value = DamageInfo.CloseDate
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@EstimatedCorporalDamage", SqlDbType.Decimal)
        param31.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedCorporalDamage = 0 Then
            param31.Value = 0
        Else
            param31.Value = DamageInfo.EstimatedCorporalDamage
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@PaidCorporalDamage", SqlDbType.Decimal)
        param32.Direction = ParameterDirection.Input
        If DamageInfo.PaidCorporalDamage = 0 Then
            param32.Value = 0
        Else
            param32.Value = DamageInfo.PaidCorporalDamage
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@TotalLost", SqlDbType.VarChar, 1)
        param33.Direction = ParameterDirection.Input
        If DamageInfo.TotalLost = "" Then
            param33.Value = System.DBNull.Value
        Else
            param33.Value = DamageInfo.TotalLost
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@TariffCode", SqlDbType.VarChar, 5)
        param34.Direction = ParameterDirection.Input
        If DamageInfo.TariffCode = "" Then
            param34.Value = System.DBNull.Value
        Else
            param34.Value = DamageInfo.TariffCode
        End If
        komut.Parameters.Add(param34)

        Dim param35 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
        param35.Direction = ParameterDirection.Input
        If DamageInfo.CurrencyCode = "" Then
            param35.Value = System.DBNull.Value
        Else
            param35.Value = DamageInfo.CurrencyCode
        End If
        komut.Parameters.Add(param35)

        Dim param36 As New SqlParameter("@EstimatedMaterialAmountTL", SqlDbType.Decimal)
        param36.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedMaterialAmountTL = 0 Then
            param36.Value = 0
        Else
            param36.Value = DamageInfo.EstimatedMaterialAmountTL
        End If
        komut.Parameters.Add(param36)

        Dim param37 As New SqlParameter("@PaidMaterialAmountTL", SqlDbType.Decimal)
        param37.Direction = ParameterDirection.Input
        If DamageInfo.PaidMaterialAmountTL = 0 Then
            param37.Value = 0
        Else
            param37.Value = DamageInfo.PaidMaterialAmountTL
        End If
        komut.Parameters.Add(param37)

        Dim param38 As New SqlParameter("@EstimatedCorporalAmountTL", SqlDbType.Decimal)
        param38.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedCorporalAmountTL = 0 Then
            param38.Value = 0
        Else
            param38.Value = DamageInfo.EstimatedCorporalAmountTL
        End If
        komut.Parameters.Add(param38)

        Dim param39 As New SqlParameter("@PaidCorporalAmountTL", SqlDbType.Decimal)
        param39.Direction = ParameterDirection.Input
        If DamageInfo.PaidCorporalAmountTL = 0 Then
            param39.Value = 0
        Else
            param39.Value = DamageInfo.PaidCorporalAmountTL
        End If
        komut.Parameters.Add(param39)

        Dim param40 As New SqlParameter("@ProductType", SqlDbType.VarChar, 2)
        param40.Direction = ParameterDirection.Input
        If DamageInfo.ProductType = "" Then
            param40.Value = System.DBNull.Value
        Else
            param40.Value = DamageInfo.ProductType
        End If
        komut.Parameters.Add(param40)

        Dim param41 As New SqlParameter("@SBMCode", SqlDbType.VarChar, 100)
        param41.Direction = ParameterDirection.Input
        If DamageInfo.SBMCode = "" Then
            param41.Value = System.DBNull.Value
        Else
            param41.Value = DamageInfo.SBMCode
        End If
        komut.Parameters.Add(param41)


        Dim param42 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
        param42.Direction = ParameterDirection.Input
        If DamageInfo.ExchangeRate = 0 Then
            param42.Value = 0
        Else
            param42.Value = DamageInfo.ExchangeRate
        End If
        komut.Parameters.Add(param42)

        Dim param43 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar)
        param43.Direction = ParameterDirection.Input
        If DamageInfo.AgencyRegisterCode = "" Then
            param43.Value = System.DBNull.Value
        Else
            param43.Value = DamageInfo.AgencyRegisterCode
        End If
        komut.Parameters.Add(param43)

        Dim param44 As New SqlParameter("@TPNo", SqlDbType.VarChar)
        param44.Direction = ParameterDirection.Input
        If DamageInfo.TPNo = "" Then
            param44.Value = System.DBNull.Value
        Else
            param44.Value = DamageInfo.TPNo
        End If
        komut.Parameters.Add(param44)

        Dim param45 As New SqlParameter("@PolicyType", SqlDbType.Int)
        param45.Direction = ParameterDirection.Input
        If DamageInfo.PolicyType = 0 Then
            param45.Value = 0
        Else
            param45.Value = DamageInfo.PolicyType
        End If
        komut.Parameters.Add(param45)

        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return resultset

    End Function


    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal DamageInfo As DamageInfo) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        komut.Connection = db_baglanti
        sqlstr = "update DamageInfo set " + _
        "AgencyCode=@AgencyCode," + _
        "PolicyNumber=@PolicyNumber," + _
        "TecditNumber=@TecditNumber," + _
        "DriverPlateCountryCode=@DriverPlateCountryCode," + _
        "DriverPlateNumber=@DriverPlateNumber," + _
        "AccidentDate=@AccidentDate," + _
        "AccidentLocation=@AccidentLocation," + _
        "InformingDate=@InformingDate," + _
        "DriverCountryCode=@DriverCountryCode," + _
        "DriverIdentityCode=@DriverIdentityCode," + _
        "DriverIdentityNo=@DriverIdentityNo," + _
        "DriverName=@DriverName," + _
        "DriverSurname=@DriverSurname," + _
        "ClaimantCountryCode=@ClaimantCountryCode," + _
        "ClaimantIdentityCode=@ClaimantIdentityCode," + _
        "ClaimantIdentityNo=@ClaimantIdentityNo," + _
        "ClaimantName=@ClaimantName," + _
        "ClaimantSurname=@ClaimantSurname," + _
        "AppealDate=@AppealDate," + _
        "ClaimantPlateCountryCode=@ClaimantPlateCountryCode," + _
        "ClaimantPlateNumber=@ClaimantPlateNumber," + _
        "DamageReason=@DamageReason," + _
        "DamageStatusCode=@DamageStatusCode," + _
        "EstimatedMaterialDamage=@EstimatedMaterialDamage," + _
        "PaidMaterialDamage=@PaidMaterialDamage," + _
        "CloseDate=@CloseDate," + _
        "EstimatedCorporalDamage=@EstimatedCorporalDamage," + _
        "PaidCorporalDamage=@PaidCorporalDamage," + _
        "TotalLost=@TotalLost," + _
        "TariffCode=@TariffCode," + _
        "CurrencyCode=@CurrencyCode," + _
        "EstimatedMaterialAmountTL=@EstimatedMaterialAmountTL," + _
        "PaidMaterialAmountTL=@PaidMaterialAmountTL," + _
        "EstimatedCorporalAmountTL=@EstimatedCorporalAmountTL," + _
        "PaidCorporalAmountTL=@PaidCorporalAmountTL," + _
        "SBMCode=@SBMCode," + _
        "ExchangeRate=@ExchangeRate," + _
        "AgencyRegisterCode=@AgencyRegisterCode," + _
        "TPNo=@TPNo," + _
        "PolicyType=@PolicyType" + _
        " where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "FileNo=@FileNo and " + _
        "RequestNo=@RequestNo and " + _
        "ProductType=@ProductType"

        '41 adet değişken var.

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param1.Direction = ParameterDirection.Input
        If DamageInfo.AgencyCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = DamageInfo.AgencyCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param2.Direction = ParameterDirection.Input
        If DamageInfo.PolicyNumber = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = DamageInfo.PolicyNumber
        End If
        komut.Parameters.Add(param2)


        Dim param3 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
        param3.Direction = ParameterDirection.Input
        If DamageInfo.TecditNumber = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = DamageInfo.TecditNumber
        End If
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@DriverPlateCountryCode", SqlDbType.VarChar, 3)
        param4.Direction = ParameterDirection.Input
        If DamageInfo.DriverPlateCountryCode = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = DamageInfo.DriverPlateCountryCode
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@DriverPlateNumber", SqlDbType.VarChar, 50)
        param5.Direction = ParameterDirection.Input
        If DamageInfo.DriverPlateNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = DamageInfo.DriverPlateNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@AccidentDate", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        If DamageInfo.AccidentDate Is Nothing Or DamageInfo.AccidentDate = "00:00:00" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = DamageInfo.AccidentDate
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@AccidentLocation", SqlDbType.VarChar, 40)
        param7.Direction = ParameterDirection.Input
        If DamageInfo.AccidentLocation = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = DamageInfo.AccidentLocation
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@InformingDate", SqlDbType.DateTime)
        param8.Direction = ParameterDirection.Input
        If DamageInfo.InformingDate Is Nothing Or DamageInfo.InformingDate = "00:00:00" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = DamageInfo.InformingDate
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@DriverCountryCode", SqlDbType.VarChar, 5)
        param9.Direction = ParameterDirection.Input
        If DamageInfo.DriverCountryCode = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = DamageInfo.DriverCountryCode
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@DriverIdentityCode", SqlDbType.VarChar, 3)
        param10.Direction = ParameterDirection.Input
        If DamageInfo.DriverIdentityCode = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = DamageInfo.DriverIdentityCode
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@DriverIdentityNo", SqlDbType.VarChar, 50)
        param11.Direction = ParameterDirection.Input
        If DamageInfo.DriverIdentityNo = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = DamageInfo.DriverIdentityNo
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@DriverName", SqlDbType.VarChar, 50)
        param12.Direction = ParameterDirection.Input
        If DamageInfo.DriverName = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = DamageInfo.DriverName
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@DriverSurname", SqlDbType.VarChar, 50)
        param13.Direction = ParameterDirection.Input
        If DamageInfo.DriverSurname = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = DamageInfo.DriverSurname
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@ClaimantCountryCode", SqlDbType.VarChar, 5)
        param14.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantCountryCode = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = DamageInfo.ClaimantCountryCode
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@ClaimantIdentityCode", SqlDbType.VarChar, 3)
        param15.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantIdentityCode = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = DamageInfo.ClaimantIdentityCode
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@ClaimantIdentityNo", SqlDbType.VarChar, 50)
        param16.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantIdentityNo = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = DamageInfo.ClaimantIdentityNo
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@ClaimantName", SqlDbType.VarChar, 50)
        param17.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantName = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = DamageInfo.ClaimantName
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@ClaimantSurname", SqlDbType.VarChar, 50)
        param18.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantSurname = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = DamageInfo.ClaimantSurname
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@AppealDate", SqlDbType.Date)
        param19.Direction = ParameterDirection.Input
        If DamageInfo.AppealDate Is Nothing Or DamageInfo.AppealDate = "00:00:00" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = DamageInfo.AppealDate
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@ClaimantPlateCountryCode", SqlDbType.VarChar, 10)
        param20.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantPlateCountryCode = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = DamageInfo.ClaimantPlateCountryCode
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@ClaimantPlateNumber", SqlDbType.VarChar, 50)
        param21.Direction = ParameterDirection.Input
        If DamageInfo.ClaimantPlateNumber = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = DamageInfo.ClaimantPlateNumber
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@DamageReason", SqlDbType.VarChar, 15)
        param22.Direction = ParameterDirection.Input
        If DamageInfo.DamageReason = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = DamageInfo.DamageReason
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar, 10)
        param23.Direction = ParameterDirection.Input
        If DamageInfo.DamageStatusCode = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = DamageInfo.DamageStatusCode
        End If
        komut.Parameters.Add(param23)


        Dim param24 As New SqlParameter("@EstimatedMaterialDamage", SqlDbType.Decimal)
        param24.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedMaterialDamage = 0 Then
            param24.Value = 0
        Else
            param24.Value = DamageInfo.EstimatedMaterialDamage
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@PaidMaterialDamage", SqlDbType.Decimal)
        param25.Direction = ParameterDirection.Input
        If DamageInfo.PaidMaterialDamage = 0 Then
            param25.Value = 0
        Else
            param25.Value = DamageInfo.PaidMaterialDamage
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@CloseDate", SqlDbType.Date)
        param26.Direction = ParameterDirection.Input
        If DamageInfo.CloseDate Is Nothing Or DamageInfo.CloseDate = "00:00:00" Then
            param26.Value = System.DBNull.Value
        Else
            param26.Value = DamageInfo.CloseDate
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@EstimatedCorporalDamage", SqlDbType.Decimal)
        param27.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedCorporalDamage = 0 Then
            param27.Value = 0
        Else
            param27.Value = DamageInfo.EstimatedCorporalDamage
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@PaidCorporalDamage", SqlDbType.Decimal)
        param28.Direction = ParameterDirection.Input
        If DamageInfo.PaidCorporalDamage = 0 Then
            param28.Value = 0
        Else
            param28.Value = DamageInfo.PaidCorporalDamage
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@TotalLost", SqlDbType.VarChar, 1)
        param29.Direction = ParameterDirection.Input
        If DamageInfo.TotalLost = "" Then
            param29.Value = System.DBNull.Value
        Else
            param29.Value = DamageInfo.TotalLost
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@TariffCode", SqlDbType.VarChar, 5)
        param30.Direction = ParameterDirection.Input
        If DamageInfo.TariffCode = "" Then
            param30.Value = System.DBNull.Value
        Else
            param30.Value = DamageInfo.TariffCode
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
        param31.Direction = ParameterDirection.Input
        If DamageInfo.CurrencyCode = "" Then
            param31.Value = System.DBNull.Value
        Else
            param31.Value = DamageInfo.CurrencyCode
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@EstimatedMaterialAmountTL", SqlDbType.Decimal)
        param32.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedMaterialAmountTL = 0 Then
            param32.Value = 0
        Else
            param32.Value = DamageInfo.EstimatedMaterialAmountTL
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@PaidMaterialAmountTL", SqlDbType.Decimal)
        param33.Direction = ParameterDirection.Input
        If DamageInfo.PaidMaterialAmountTL = 0 Then
            param33.Value = 0
        Else
            param33.Value = DamageInfo.PaidMaterialAmountTL
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@EstimatedCorporalAmountTL", SqlDbType.Decimal)
        param34.Direction = ParameterDirection.Input
        If DamageInfo.EstimatedCorporalAmountTL = 0 Then
            param34.Value = 0
        Else
            param34.Value = DamageInfo.EstimatedCorporalAmountTL
        End If
        komut.Parameters.Add(param34)

        Dim param35 As New SqlParameter("@PaidCorporalAmountTL", SqlDbType.Decimal)
        param35.Direction = ParameterDirection.Input
        If DamageInfo.PaidCorporalAmountTL = 0 Then
            param35.Value = 0
        Else
            param35.Value = DamageInfo.PaidCorporalAmountTL
        End If
        komut.Parameters.Add(param35)


        Dim param36 As New SqlParameter("@SBMCode", SqlDbType.VarChar, 100)
        param36.Direction = ParameterDirection.Input
        If DamageInfo.SBMCode = "" Then
            param36.Value = System.DBNull.Value
        Else
            param36.Value = DamageInfo.SBMCode
        End If
        komut.Parameters.Add(param36)


        Dim param37 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param37.Direction = ParameterDirection.Input
        If DamageInfo.FirmCode = "" Then
            param37.Value = System.DBNull.Value
        Else
            param37.Value = DamageInfo.FirmCode
        End If
        komut.Parameters.Add(param37)

        Dim param38 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param38.Direction = ParameterDirection.Input
        If DamageInfo.ProductCode = "" Then
            param38.Value = System.DBNull.Value
        Else
            param38.Value = DamageInfo.ProductCode
        End If
        komut.Parameters.Add(param38)

        Dim param39 As New SqlParameter("@FileNo", SqlDbType.VarChar, 15)
        param39.Direction = ParameterDirection.Input
        If DamageInfo.FileNo = "" Then
            param39.Value = System.DBNull.Value
        Else
            param39.Value = DamageInfo.FileNo
        End If
        komut.Parameters.Add(param39)

        Dim param40 As New SqlParameter("@RequestNo", SqlDbType.VarChar, 2)
        param40.Direction = ParameterDirection.Input
        If DamageInfo.RequestNo = "" Then
            param40.Value = System.DBNull.Value
        Else
            param40.Value = DamageInfo.RequestNo
        End If
        komut.Parameters.Add(param40)

        Dim param41 As New SqlParameter("@ProductType", SqlDbType.VarChar, 2)
        param41.Direction = ParameterDirection.Input
        If DamageInfo.ProductType = "" Then
            param41.Value = System.DBNull.Value
        Else
            param41.Value = DamageInfo.ProductType
        End If
        komut.Parameters.Add(param41)

        Dim param42 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
        param42.Direction = ParameterDirection.Input
        If DamageInfo.ExchangeRate = 0 Then
            param42.Value = 0
        Else
            param42.Value = DamageInfo.ExchangeRate
        End If
        komut.Parameters.Add(param42)

        Dim param43 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar, 20)
        param43.Direction = ParameterDirection.Input
        If DamageInfo.AgencyRegisterCode = "" Then
            param43.Value = System.DBNull.Value
        Else
            param43.Value = DamageInfo.AgencyRegisterCode
        End If
        komut.Parameters.Add(param43)

        Dim param44 As New SqlParameter("@TPNo", SqlDbType.VarChar, 20)
        param44.Direction = ParameterDirection.Input
        If DamageInfo.TPNo = "" Then
            param44.Value = System.DBNull.Value
        Else
            param44.Value = DamageInfo.TPNo
        End If
        komut.Parameters.Add(param44)

        Dim param45 As New SqlParameter("@PolicyType", SqlDbType.Int)
        param45.Direction = ParameterDirection.Input
        If DamageInfo.PolicyType = 0 Then
            param45.Value = 0
        Else
            param45.Value = DamageInfo.PolicyType
        End If
        komut.Parameters.Add(param45)


        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    'TOPLAM HASAR SAYISINI BUL---------------------------------------
    Public Function toplamhasarsayisi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            toplam = 0
        Else
            toplam = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return toplam

    End Function


    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal FileNo As String, ByVal RequestNo As String, ByVal ProductType As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo " + _
        " and ProductType=@ProductType"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = FileNo
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = RequestNo
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = ProductType
        komut.Parameters.Add(param5)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    'TOPLAM HASAR SAYISINI BUL ŞİRKET İÇİN---------------------------------------
    Public Function toplamhasarsayisi_sirketicin(ByVal sirketpkey As String) As Integer

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_erisim.bultek(sirketpkey)

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where FirmCode=@FirmCode"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirket.sirketkod
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            toplam = 0
        Else
            toplam = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return toplam

    End Function


    Public Function grafikdata(ByVal neyegore As String) As List(Of CLASSGRAFIKBILGI)


        Dim komut As New SqlCommand
        Dim donecekgrafikbilgi As New CLASSGRAFIKBILGI
        Dim donecekgrafikbilgiler As New List(Of CLASSGRAFIKBILGI)
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        If neyegore = "hasarfirmadagilim" Then

            sqlstr = "select COUNT(*) as sayi,firmcode from DamageInfo group by firmcode order by firmcode"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("firmcode") Is System.DBNull.Value Then
                        firmcode = veri.Item("firmcode")
                        donecekgrafikbilgi.seriad = sirket_erisim.bultek_sirketkodagore(firmcode).sirketad
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using

        End If

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekgrafikbilgiler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10, kol11 As String

        Dim saf1, saf2, saf3, saf4, saf5 As String
        Dim saf6, saf7, saf8, saf9, saf10, saf11 As String


        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Plaka</th>" + _
        "<th>SBM Code</th>" + _
        "<th>Bilgiler</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Dosya No", GetType(String))
        table.Columns.Add("Kaza Tarihi", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        table.Columns.Add("Kimlik", GetType(String))
        table.Columns.Add("Plaka", GetType(String))
        table.Columns.Add("SBM Code", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(10)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Dosya No", fbaslik))
        pdftable.AddCell(New Phrase("Kaza Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Ad Soyad", fbaslik))
        pdftable.AddCell(New Phrase("Kimlik", fbaslik))
        pdftable.AddCell(New Phrase("Plaka", fbaslik))
        pdftable.AddCell(New Phrase("SBM Code", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            sqldevam = " and FirmCode=@FirmCode"
        End If

        'urun kodu seçilmişse
        If HttpContext.Current.Session("urunkodu") <> "0" Then
            sqldevam = sqldevam + " and ProductCode=@ProductCode"
        End If

        'dosya no seçilmişse
        If HttpContext.Current.Session("dosyano") <> "" Then
            sqldevam = sqldevam + " and FileNo=@FileNo"
        End If

        'policeno
        If HttpContext.Current.Session("policeno") <> "" Then
            sqldevam = sqldevam + " and PolicyNumber=@PolicyNumber"
        End If

        'kimlikno
        If HttpContext.Current.Session("kimlikno") <> "" Then
            sqldevam = sqldevam + " and DriverIdentityNo=@DriverIdentityNo"
        End If

        'plakano
        If HttpContext.Current.Session("plakano") <> "" Then
            sqldevam = sqldevam + " and DriverPlateNumber=@DriverPlateNumber"
        End If

        'sürücü ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and DriverName LIKE '%'+@DriverName+'%'"
        End If

        'sürücü soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and DriverSurname LIKE '%'+@DriverSurname+'%'"
        End If


        'talep ad
        If HttpContext.Current.Session("talepad") <> "" Then
            sqldevam = sqldevam + " and ClaimantName LIKE '%'+@ClaimantName+'%'"
        End If

        'talep soyad
        If HttpContext.Current.Session("talepsoyad") <> "" Then
            sqldevam = sqldevam + " and ClaimantSurname LIKE '%'+@ClaimantSurname+'%'"
        End If

        'talep plakano
        If HttpContext.Current.Session("talepplakano") <> "" Then
            sqldevam = sqldevam + " and ClaimantPlateNumber=@ClaimantPlateNumber"
        End If

        'talep kimlikno
        If HttpContext.Current.Session("talepkimlikno") <> "" Then
            sqldevam = sqldevam + " and ClaimantIdentityNo=@ClaimantIdentityNo"
        End If


        sqlstr = "select * from DamageInfo where " + _
        "(Convert(DATE,AccidentDate)>=@baslangic and Convert(DATE,AccidentDate)<=@bitis)" + _
        sqldevam

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = Current.Session("bitis")

        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            komut.Parameters.Add("@FirmCode", SqlDbType.VarChar)
            komut.Parameters("@FirmCode").Value = HttpContext.Current.Session("sirket")
        End If

        'urun kodu seçilmişse
        If HttpContext.Current.Session("urunkodu") <> "0" Then
            komut.Parameters.Add("@ProductCode", SqlDbType.VarChar)
            komut.Parameters("@ProductCode").Value = HttpContext.Current.Session("urunkodu")
        End If

        'dosya no seçilmişse
        If HttpContext.Current.Session("dosyano") <> "" Then
            komut.Parameters.Add("@FileNo", SqlDbType.VarChar)
            komut.Parameters("@FileNo").Value = HttpContext.Current.Session("dosyano")
        End If

        'police no seçilmişse
        If HttpContext.Current.Session("policeno") <> "" Then
            komut.Parameters.Add("@PolicyNumber", SqlDbType.VarChar)
            komut.Parameters("@PolicyNumber").Value = HttpContext.Current.Session("policeno")
        End If

        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlikno") <> "" Then
            komut.Parameters.Add("@DriverIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@DriverIdentityNo").Value = HttpContext.Current.Session("kimlikno")
        End If

        'plaka no seçilmişse
        If HttpContext.Current.Session("plakano") <> "" Then
            komut.Parameters.Add("@DriverPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@DriverPlateNumber").Value = HttpContext.Current.Session("plakano")
        End If

        'sürücü ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@DriverName", SqlDbType.VarChar)
            komut.Parameters("@DriverName").Value = HttpContext.Current.Session("ad")
        End If

        'sürücü soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@DriverSurname", SqlDbType.VarChar)
            komut.Parameters("@DriverSurname").Value = HttpContext.Current.Session("soyad")
        End If

        'talep ad seçilmiş ise
        If HttpContext.Current.Session("talepad") <> "" Then
            komut.Parameters.Add("@ClaimantName", SqlDbType.VarChar)
            komut.Parameters("@ClaimantName").Value = HttpContext.Current.Session("talepad")
        End If

        'talep soyad seçilmiş ise
        If HttpContext.Current.Session("talepsoyad") <> "" Then
            komut.Parameters.Add("@ClaimantSurname", SqlDbType.VarChar)
            komut.Parameters("@ClaimantSurname").Value = HttpContext.Current.Session("talepsoyad")
        End If

        'talep plaka no seçilmişse
        If HttpContext.Current.Session("talepplakano") <> "" Then
            komut.Parameters.Add("@ClaimantPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@ClaimantPlateNumber").Value = HttpContext.Current.Session("talepplakano")
        End If

        'talep kimlik no seçilmişse
        If HttpContext.Current.Session("talepkimlikno") <> "" Then
            komut.Parameters.Add("@ClaimantIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@ClaimantIdentityNo").Value = HttpContext.Current.Session("talepkimlikno")
        End If


        girdi = "0"

        Dim link As String
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType As String
        Dim SBMCode As String
        Dim DriverPlateNumber, AccidentDate As String
        Dim DriverIdentityNo As String
        Dim DriverName, DriverSurname As String
        Dim dugme As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    'PRİMARY KEY DOLDUR
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                    Else
                        FirmCode = "0"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                    Else
                        ProductCode = "0"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                    Else
                        AgencyCode = "0"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                    Else
                        PolicyNumber = "0"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                    Else
                        TecditNumber = "0"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                    Else
                        FileNo = "0"
                    End If

                    If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                        RequestNo = veri.Item("RequestNo")
                    Else
                        RequestNo = "0"
                    End If
                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = veri.Item("ProductType")
                    Else
                        ProductType = "0"
                    End If
                    '---------------------------------------

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_erisim.bultek_sirketkodagore(FirmCode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                        saf1 = sirket.sirketad
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + ProductCode + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol3 = "<td>" + AgencyCode + "</td>"
                        saf3 = AgencyCode
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol4 = "<td>" + PolicyNumber + "</td>"
                        saf4 = PolicyNumber
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                        kol5 = "<td>" + FileNo + "</td>"
                        saf5 = FileNo
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                        AccidentDate = veri.Item("AccidentDate")
                        kol6 = "<td>" + AccidentDate + "</td>"
                        saf6 = AccidentDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    '---DRIVER NAME -----------------------------------------------------
                    If Not veri.Item("DriverName") Is System.DBNull.Value Then
                        DriverName = veri.Item("DriverName")
                        saf7 = DriverName
                    Else
                        DriverName = ""
                        saf7 = "-"
                    End If

                    If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                        DriverSurname = veri.Item("DriverSurname")
                    Else
                        DriverSurname = ""
                    End If

                    kol7 = "<td>" + UCase(DriverName) + " " + UCase(DriverSurname) + "</td>"
                    saf7 = UCase(DriverName) + " " + UCase(DriverSurname)


                    If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                        DriverIdentityNo = veri.Item("DriverIdentityNo")
                        kol8 = "<td>" + DriverIdentityNo + "</td>"
                        saf8 = DriverIdentityNo
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If


                    If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                        DriverPlateNumber = veri.Item("DriverPlateNumber")
                        kol9 = "<td>" + DriverPlateNumber + "</td>"
                        saf9 = DriverPlateNumber
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If


                    If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                        SBMCode = veri.Item("SBMCode")
                        kol10 = "<td>" + SBMCode + "</td>"
                        saf10 = SBMCode
                    Else
                        kol10 = "<td>-</td>"
                        saf10 = "-"
                    End If

                    link = "hasardetay.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    dugme = "<span class='button'>Bilgiler</span>"

                    kol11 = "<td><span class='iframeyenikayit' href=" + link + ">" + _
                    dugme + "</a></td>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11


                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9, saf10)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
                    pdftable.AddCell(New Phrase(saf9, fdata))
                    pdftable.AddCell(New Phrase(saf10, fdata))

                    recordcount = recordcount + 1


                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function


    '--- POLİÇENİN HASARLARINI BUL -------------------------------------------------------
    Function hasardoldur_ilgilipolice(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As List(Of DamageInfo)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekDamageInfo As New DamageInfo
        Dim DamageInfolar As New List(Of DamageInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and ProductType=@ProductType "

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = AgencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = PolicyNumber
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = TecditNumber
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ProductType
        komut.Parameters.Add(param6)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekDamageInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekDamageInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    donecekDamageInfo.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    donecekDamageInfo.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("DriverPlateCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverPlateCountryCode = veri.Item("DriverPlateCountryCode")
                End If

                If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverPlateNumber = veri.Item("DriverPlateNumber")
                End If

                If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                    donecekDamageInfo.AccidentDate = veri.Item("AccidentDate")
                Else
                    donecekDamageInfo.AccidentDate = "00:00:00"
                End If

                If Not veri.Item("AccidentLocation") Is System.DBNull.Value Then
                    donecekDamageInfo.AccidentLocation = veri.Item("AccidentLocation")
                End If

                If Not veri.Item("InformingDate") Is System.DBNull.Value Then
                    donecekDamageInfo.InformingDate = veri.Item("InformingDate")
                Else
                    donecekDamageInfo.InformingDate = "00:00:00"
                End If

                If Not veri.Item("DriverCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverCountryCode = veri.Item("DriverCountryCode")
                End If

                If Not veri.Item("DriverIdentityCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverIdentityCode = veri.Item("DriverIdentityCode")
                End If

                If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverIdentityNo = veri.Item("DriverIdentityNo")
                End If

                If Not veri.Item("DriverName") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverName = veri.Item("DriverName")
                Else
                    donecekDamageInfo.DriverName = ""
                End If

                If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverSurname = veri.Item("DriverSurname")
                End If

                If Not veri.Item("ClaimantCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantCountryCode = veri.Item("ClaimantCountryCode")
                End If

                If Not veri.Item("ClaimantIdentityCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantIdentityCode = veri.Item("ClaimantIdentityCode")
                End If

                If Not veri.Item("ClaimantIdentityNo") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantIdentityNo = veri.Item("ClaimantIdentityNo")
                End If

                If Not veri.Item("ClaimantName") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantName = veri.Item("ClaimantName")
                End If

                If Not veri.Item("ClaimantSurname") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantSurname = veri.Item("ClaimantSurname")
                Else
                    donecekDamageInfo.ClaimantSurname = ""
                End If

                If Not veri.Item("AppealDate") Is System.DBNull.Value Then
                    donecekDamageInfo.AppealDate = veri.Item("AppealDate")
                Else
                    donecekDamageInfo.AppealDate = "00:00:00"
                End If

                If Not veri.Item("ClaimantPlateCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantPlateCountryCode = veri.Item("ClaimantPlateCountryCode")
                End If

                If Not veri.Item("ClaimantPlateNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantPlateNumber = veri.Item("ClaimantPlateNumber")
                End If

                If Not veri.Item("DamageReason") Is System.DBNull.Value Then
                    donecekDamageInfo.DamageReason = veri.Item("DamageReason")
                End If

                If Not veri.Item("DamageStatusCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DamageStatusCode = veri.Item("DamageStatusCode")
                Else
                    donecekDamageInfo.DamageStatusCode = ""
                End If

                If Not veri.Item("EstimatedMaterialDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedMaterialDamage = veri.Item("EstimatedMaterialDamage")
                End If

                If Not veri.Item("PaidMaterialDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidMaterialDamage = veri.Item("PaidMaterialDamage")
                End If

                If Not veri.Item("CloseDate") Is System.DBNull.Value Then
                    donecekDamageInfo.CloseDate = veri.Item("CloseDate")
                Else
                    donecekDamageInfo.CloseDate = "00:00:00"
                End If

                If Not veri.Item("EstimatedCorporalDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedCorporalDamage = veri.Item("EstimatedCorporalDamage")
                End If

                If Not veri.Item("PaidCorporalDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidCorporalDamage = veri.Item("PaidCorporalDamage")
                End If

                If Not veri.Item("TotalLost") Is System.DBNull.Value Then
                    donecekDamageInfo.TotalLost = veri.Item("TotalLost")
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekDamageInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekDamageInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("EstimatedMaterialAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedMaterialAmountTL = veri.Item("EstimatedMaterialAmountTL")
                End If

                If Not veri.Item("PaidMaterialAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidMaterialAmountTL = veri.Item("PaidMaterialAmountTL")
                End If

                If Not veri.Item("EstimatedCorporalAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedCorporalAmountTL = veri.Item("EstimatedCorporalAmountTL")
                End If

                If Not veri.Item("PaidCorporalAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidCorporalAmountTL = veri.Item("PaidCorporalAmountTL")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekDamageInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekDamageInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekDamageInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekDamageInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekDamageInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekDamageInfo.PolicyType = veri.Item("PolicyType")
                End If


                DamageInfolar.Add(New DamageInfo(donecekDamageInfo.FirmCode, _
                donecekDamageInfo.ProductCode, donecekDamageInfo.AgencyCode, donecekDamageInfo.PolicyNumber, donecekDamageInfo.TecditNumber, _
                donecekDamageInfo.FileNo, donecekDamageInfo.RequestNo, donecekDamageInfo.DriverPlateCountryCode, donecekDamageInfo.DriverPlateNumber, _
                donecekDamageInfo.AccidentDate, donecekDamageInfo.AccidentLocation, donecekDamageInfo.InformingDate, donecekDamageInfo.DriverCountryCode, _
                donecekDamageInfo.DriverIdentityCode, donecekDamageInfo.DriverIdentityNo, donecekDamageInfo.DriverName, donecekDamageInfo.DriverSurname, _
                donecekDamageInfo.ClaimantCountryCode, donecekDamageInfo.ClaimantIdentityCode, donecekDamageInfo.ClaimantIdentityNo, donecekDamageInfo.ClaimantName, _
                donecekDamageInfo.ClaimantSurname, donecekDamageInfo.AppealDate, donecekDamageInfo.ClaimantPlateCountryCode, donecekDamageInfo.ClaimantPlateNumber, _
                donecekDamageInfo.DamageReason, donecekDamageInfo.DamageStatusCode, donecekDamageInfo.EstimatedMaterialDamage, donecekDamageInfo.PaidMaterialDamage, _
                donecekDamageInfo.CloseDate, donecekDamageInfo.EstimatedCorporalDamage, donecekDamageInfo.PaidCorporalDamage, donecekDamageInfo.TotalLost, _
                donecekDamageInfo.TariffCode, donecekDamageInfo.CurrencyCode, donecekDamageInfo.EstimatedMaterialAmountTL, donecekDamageInfo.PaidMaterialAmountTL, _
                donecekDamageInfo.EstimatedCorporalAmountTL, donecekDamageInfo.PaidCorporalAmountTL, donecekDamageInfo.ProductType, donecekDamageInfo.SBMCode, _
                donecekDamageInfo.ExchangeRate, donecekDamageInfo.AgencyRegisterCode,donecekDamageInfo.TPNo, donecekDamageInfo.PolicyType))

            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return DamageInfolar

    End Function


    'POLİÇENİN HASARLARI TABLOSU OLUŞTUR.
    Public Function policeninhasari_tablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16 As String
        Dim kol17, kol18, kol19, kol20, kol21 As String

        Dim basliklar, tabloson As String
        Dim policeninhasarlari As New List(Of DamageInfo)

        policeninhasarlari = hasardoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_4'>" + _
        "<thead>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Kazanın Haber Verildiği Tarih</th>" + _
        "<th>Dosya Kapanma Tarihi</th>" + _
        "<th>Sürücü Ad Soyad</th>" + _
        "<th>Sürücü Ülke Kodu</th>" + _
        "<th>Sürücü Kimlik Türü</th>" + _
        "<th>Sürücü Kimlik</th>" + _
        "<th>Plaka</th>" + _
        "<th>Tahmini Maddi Hasar Tutarı</th>" + _
        "<th>Ödenen Maddi Hasar</th>" + _
        "<th>Tahmini Bedensel Hasar Tutarı</th>" + _
        "<th>Ödenen Bedensel Hasar</th>" + _
        "<th>Dosya Durumu</th>" + _
        "<th>Tarife Kodu</th>" + _
        "<th>Para Birimi</th>" + _
        "<th>SBMCode</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itemhasar As DamageInfo In policeninhasarlari

            kol1 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(itemhasar.FirmCode)).sirketad + "</td>"
            kol2 = "<td>" + CStr(itemhasar.ProductCode) + "</td>"
            kol3 = "<td>" + CStr(itemhasar.AgencyCode) + "</td>"
            kol4 = "<td>" + CStr(itemhasar.PolicyNumber) + "</td>"
            kol5 = "<td>" + CStr(itemhasar.FileNo) + "</td>"
            kol6 = "<td>" + CStr(itemhasar.AccidentDate) + "</td>"
            kol7 = "<td>" + CStr(itemhasar.InformingDate) + "</td>"
            kol8 = "<td>" + CStr(itemhasar.CloseDate) + "</td>"
            kol9 = "<td>" + CStr(itemhasar.DriverName) + " " + CStr(itemhasar.DriverSurname) + "</td>"
            kol10 = "<td>" + CStr(itemhasar.DriverCountryCode) + "</td>"
            kol11 = "<td>" + CStr(itemhasar.DriverIdentityCode) + "</td>"
            kol12 = "<td>" + CStr(itemhasar.DriverIdentityNo) + "</td>"
            kol13 = "<td>" + CStr(itemhasar.DriverPlateNumber) + "</td>"
            kol14 = "<td>" + Format(itemhasar.EstimatedMaterialDamage, "0.00") + "</td>"
            kol15 = "<td>" + Format(itemhasar.PaidMaterialDamage, "0.00") + "</td>"
            kol16 = "<td>" + Format(itemhasar.EstimatedCorporalDamage, "0.00") + "</td>"
            kol17 = "<td>" + Format(itemhasar.PaidCorporalDamage, "0.00") + "</td>"
            kol18 = "<td>" + CStr(itemhasar.DamageStatusCode) + "</td>"
            kol19 = "<td>" + CStr(itemhasar.TariffCode) + "</td>"
            kol20 = "<td>" + CStr(itemhasar.CurrencyCode) + "</td>"
            kol21 = "<td>" + CStr(itemhasar.SBMCode) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12 + kol13 + _
            kol14 + kol15 + kol16 + kol17 + kol18 + kol19 + kol20 + kol21

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function



    'POLİÇENİN HASARLARI TABLOSU OLUŞTUR.
    Public Function policeninhasari_tablo_sirketicin(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String

        Dim basliklar, tabloson As String
        Dim policeninhasarlari As New List(Of DamageInfo)

        policeninhasarlari = hasardoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Dosya Kapanma Tarihi</th>" + _
        "<th>Sürücü Ad Soyad</th>" + _
        "<th>Plaka</th>" + _
        "<th>Dosya Durumu</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itemhasar As DamageInfo In policeninhasarlari

            kol1 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(itemhasar.FirmCode)).sirketad + "</td>"
            kol2 = "<td>" + CStr(itemhasar.ProductCode) + "</td>"
            kol3 = "<td>" + CStr(itemhasar.AgencyCode) + "</td>"
            kol4 = "<td>" + CStr(itemhasar.PolicyNumber) + "</td>"
            kol5 = "<td>" + CStr(itemhasar.FileNo) + "</td>"
            kol6 = "<td>" + CStr(itemhasar.AccidentDate) + "</td>"
            kol7 = "<td>" + CStr(itemhasar.CloseDate) + "</td>"
            kol8 = "<td>" + CStr(itemhasar.DriverName) + " " + CStr(itemhasar.DriverSurname) + "</td>"
            kol9 = "<td>" + CStr(itemhasar.DriverPlateNumber) + "</td>"
            kol10 = "<td>" + CStr(itemhasar.DamageStatusCode) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    'HASAR TALEP TABLO
    Public Function talepbilgi_tablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String


        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String

        Dim basliklar, tabloson As String
        Dim policeninhasarlari As New List(Of DamageInfo)

        policeninhasarlari = hasardoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_5'>" + _
        "<thead>" + _
        "<th>Talep No</th>" + _
        "<th>Talep Ülke Kodu</th>" + _
        "<th>Kimlik Türü</th>" + _
        "<th>Kimlik No</th>" + _
        "<th>Talep Sahibi Adı Soyadı</th>" + _
        "<th>Başvuru Tarihi</th>" + _
        "<th>Plaka Ülke Kodu</th>" + _
        "<th>Plaka</th>" + _
        "<th>Tahmini Maddi Hasar</th>" + _
        "<th>Ödenen Maddi Hasar</th>" + _
        "<th>Tahmini Bedensel Hasar</th>" + _
        "<th>Ödenen Bedensel Hasar</th>" + _
        "<th>Durum</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itemhasar As DamageInfo In policeninhasarlari

            kol1 = "<tr><td>" + CStr(itemhasar.RequestNo) + "</td>"
            kol2 = "<td>" + CStr(itemhasar.ClaimantCountryCode) + "</td>"
            kol3 = "<td>" + CStr(itemhasar.ClaimantIdentityCode) + "</td>"
            kol4 = "<td>" + CStr(itemhasar.ClaimantIdentityNo) + "</td>"
            kol5 = "<td>" + CStr(itemhasar.ClaimantName) + " " + CStr(itemhasar.ClaimantSurname) + "</td>"
            kol6 = "<td>" + CStr(itemhasar.AppealDate) + "</td>"
            kol7 = "<td>" + CStr(itemhasar.ClaimantPlateCountryCode) + "</td>"
            kol8 = "<td>" + CStr(itemhasar.ClaimantPlateNumber) + "</td>"
            kol9 = "<td>" + Format(itemhasar.EstimatedMaterialDamage, "0.00") + "</td>"
            kol10 = "<td>" + Format(itemhasar.PaidMaterialDamage, "0.00") + "</td>"
            kol11 = "<td>" + Format(itemhasar.EstimatedCorporalDamage, "0.00") + "</td>"
            kol12 = "<td>" + Format(itemhasar.PaidCorporalDamage, "0.00") + "</td>"
            kol13 = "<td>" + CStr(itemhasar.DamageStatusCode) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12 + kol13

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    'HASAR TALEP TABLO
    Public Function talepbilgi_tablo_sirketicin(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String


        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String


        Dim basliklar, tabloson As String
        Dim policeninhasarlari As New List(Of DamageInfo)

        policeninhasarlari = hasardoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Talep No</th>" + _
        "<th>Talep Sahibi</th>" + _
        "<th>Plaka</th>" + _
        "<th>Ödenen Maddi Hasar</th>" + _
        "<th>Ödenen Bedensel Hasar</th>" + _
        "<th>Durum</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itemhasar As DamageInfo In policeninhasarlari

            kol1 = "<tr><td>" + CStr(itemhasar.RequestNo) + "</td>"
            kol2 = "<td>" + CStr(itemhasar.ClaimantName) + "</td>"
            kol3 = "<td>" + CStr(itemhasar.ClaimantPlateNumber) + "</td>"
            kol4 = "<td>" + Format(itemhasar.PaidMaterialDamage, "0.00") + "</td>"
            kol5 = "<td>" + Format(itemhasar.PaidCorporalDamage, "0.00") + "</td>"
            kol6 = "<td>" + CStr(itemhasar.DamageStatusCode) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    '-----HASAR İPTAL İŞLEMİ İÇİN TABLO OLUŞTUR--------------------------------------
    Public Function listelehasariptalicin() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13 As String

        Dim saf1, saf2, saf3, saf4, saf5 As String
        Dim saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12, saf13 As String


        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Plaka</th>" + _
        "<th>Hasar Bilgi</th>" + _
        "<th>İptal İşlemi</th>" + _
        "<th>İptal Bilgi</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Dosya No", GetType(String))
        table.Columns.Add("Kaza Tarihi", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        table.Columns.Add("Kimlik", GetType(String))
        table.Columns.Add("Plaka", GetType(String))

        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(9)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Dosya No", fbaslik))
        pdftable.AddCell(New Phrase("Kaza Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Ad Soyad", fbaslik))
        pdftable.AddCell(New Phrase("Kimlik", fbaslik))
        pdftable.AddCell(New Phrase("Plaka", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            sqldevam = " and FirmCode=@FirmCode"
        End If

        'urun kodu seçilmişse
        If HttpContext.Current.Session("urunkodu") <> "0" Then
            sqldevam = sqldevam + " and ProductCode=@ProductCode"
        End If

        'dosya no seçilmişse
        If HttpContext.Current.Session("dosyano") <> "" Then
            sqldevam = sqldevam + " and FileNo=@FileNo"
        End If

        'policeno
        If HttpContext.Current.Session("policeno") <> "" Then
            sqldevam = sqldevam + " and PolicyNumber=@PolicyNumber"
        End If

        'kimlikno
        If HttpContext.Current.Session("kimlikno") <> "" Then
            sqldevam = sqldevam + " and DriverIdentityNo=@DriverIdentityNo"
        End If

        'plakano
        If HttpContext.Current.Session("plakano") <> "" Then
            sqldevam = sqldevam + " and DriverPlateNumber=@DriverPlateNumber"
        End If

        'ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and DriverName LIKE '%'+@DriverName+'%'"
        End If

        'soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and DriverSurname LIKE '%'+@DriverSurname+'%'"
        End If

        'talep ad
        If HttpContext.Current.Session("talepad") <> "" Then
            sqldevam = sqldevam + " and ClaimantName LIKE '%'+@ClaimantName+'%'"
        End If

        'talep soyad
        If HttpContext.Current.Session("talepsoyad") <> "" Then
            sqldevam = sqldevam + " and ClaimantSurname LIKE '%'+@ClaimantSurname+'%'"
        End If

        'talep plakano
        If HttpContext.Current.Session("talepplakano") <> "" Then
            sqldevam = sqldevam + " and ClaimantPlateNumber=@ClaimantPlateNumber"
        End If

        'talep kimlikno
        If HttpContext.Current.Session("talepkimlikno") <> "" Then
            sqldevam = sqldevam + " and ClaimantIdentityNo=@ClaimantIdentityNo"
        End If


        sqlstr = "select * from DamageInfo where " + _
        "(Convert(DATE,AccidentDate)>=@baslangic and Convert(DATE,AccidentDate)<=@bitis)" + _
        sqldevam

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = Current.Session("bitis")

        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            komut.Parameters.Add("@FirmCode", SqlDbType.VarChar)
            komut.Parameters("@FirmCode").Value = HttpContext.Current.Session("sirket")
        End If

        'urun kodu seçilmişse
        If HttpContext.Current.Session("urunkodu") <> "0" Then
            komut.Parameters.Add("@ProductCode", SqlDbType.VarChar)
            komut.Parameters("@ProductCode").Value = HttpContext.Current.Session("urunkodu")
        End If

        'dosya no seçilmişse
        If HttpContext.Current.Session("dosyano") <> "" Then
            komut.Parameters.Add("@FileNo", SqlDbType.VarChar)
            komut.Parameters("@FileNo").Value = HttpContext.Current.Session("dosyano")
        End If

        'police no seçilmişse
        If HttpContext.Current.Session("policeno") <> "" Then
            komut.Parameters.Add("@PolicyNumber", SqlDbType.VarChar)
            komut.Parameters("@PolicyNumber").Value = HttpContext.Current.Session("policeno")
        End If

        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlikno") <> "" Then
            komut.Parameters.Add("@DriverIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@DriverIdentityNo").Value = HttpContext.Current.Session("kimlikno")
        End If

        'sürücü plaka no seçilmişse
        If HttpContext.Current.Session("plakano") <> "" Then
            komut.Parameters.Add("@DriverPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@DriverPlateNumber").Value = HttpContext.Current.Session("plakano")
        End If


        'sürücü ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@DriverName", SqlDbType.VarChar)
            komut.Parameters("@DriverName").Value = HttpContext.Current.Session("ad")
        End If

        'sürücü soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@DriverSurname", SqlDbType.VarChar)
            komut.Parameters("@DriverSurname").Value = HttpContext.Current.Session("soyad")
        End If

        'talep ad seçilmiş ise
        If HttpContext.Current.Session("talepad") <> "" Then
            komut.Parameters.Add("@ClaimantName", SqlDbType.VarChar)
            komut.Parameters("@ClaimantName").Value = HttpContext.Current.Session("talepad")
        End If

        'talep soyad seçilmiş ise
        If HttpContext.Current.Session("talepsoyad") <> "" Then
            komut.Parameters.Add("@ClaimantSurname", SqlDbType.VarChar)
            komut.Parameters("@ClaimantSurname").Value = HttpContext.Current.Session("talepsoyad")
        End If

        'talep plaka no seçilmişse
        If HttpContext.Current.Session("talepplakano") <> "" Then
            komut.Parameters.Add("@ClaimantPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@ClaimantPlateNumber").Value = HttpContext.Current.Session("talepplakano")
        End If

        'talep kimlik no seçilmişse
        If HttpContext.Current.Session("talepkimlikno") <> "" Then
            komut.Parameters.Add("@ClaimantIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@ClaimantIdentityNo").Value = HttpContext.Current.Session("talepkimlikno")
        End If

        girdi = "0"


        Dim damagacancel As New CLASSDAMAGECANCEL
        Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM
        Dim iptaller As New List(Of CLASSDAMAGECANCEL)

        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType As String
        Dim DriverPlateNumber, AccidentDate As String
        Dim DriverIdentityNo As String
        Dim DriverName, DriverSurname As String
        Dim hasariniptalivarmi As String

        Dim dugmebilgi As String
        Dim dugmeiptal As String
        Dim linkbilgi As String
        Dim linkiptal As String
        Dim linkiptalgoster As String
        Dim dugmeiptalgoster As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    'PRİMARY KEY DOLDUR
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                    Else
                        FirmCode = "0"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                    Else
                        ProductCode = "0"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                    Else
                        AgencyCode = "0"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                    Else
                        PolicyNumber = "0"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                    Else
                        TecditNumber = "0"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                    Else
                        FileNo = "0"
                    End If

                    If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                        RequestNo = veri.Item("RequestNo")
                    Else
                        RequestNo = "0"
                    End If

                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = veri.Item("ProductType")
                    Else
                        ProductType = "0"
                    End If
                    '-------------------------------------------------------------------------


                    'HASARIN İPTALİ VARMİ KONTROL ET
                    hasariniptalivarmi = damagecancel_erisim.hasariniptalivarmi(FirmCode, ProductCode, _
                    AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType)
                    '-------------------------------------------------------------------------

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_erisim.bultek_sirketkodagore(FirmCode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                        saf1 = sirket.sirketad
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + ProductCode + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol3 = "<td>" + AgencyCode + "</td>"
                        saf3 = AgencyCode
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol4 = "<td>" + PolicyNumber + "</td>"
                        saf4 = PolicyNumber
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                        kol5 = "<td>" + FileNo + "</td>"
                        saf5 = FileNo
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                        AccidentDate = veri.Item("AccidentDate")
                        kol6 = "<td>" + AccidentDate + "</td>"
                        saf6 = AccidentDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    '---DRIVER NAME -----------------------------------------------------
                    If Not veri.Item("DriverName") Is System.DBNull.Value Then
                        DriverName = veri.Item("DriverName")
                        saf7 = DriverName
                    Else
                        DriverName = ""
                        saf7 = "-"
                    End If

                    If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                        DriverSurname = veri.Item("DriverSurname")
                    Else
                        DriverSurname = ""
                    End If

                    kol7 = "<td>" + UCase(DriverName) + " " + UCase(DriverSurname) + "</td>"
                    saf7 = UCase(DriverName) + " " + UCase(DriverSurname)


                    If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                        DriverIdentityNo = veri.Item("DriverIdentityNo")
                        kol8 = "<td>" + DriverIdentityNo + "</td>"
                        saf8 = DriverIdentityNo
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If


                    If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                        DriverPlateNumber = veri.Item("DriverPlateNumber")
                        kol9 = "<td>" + DriverPlateNumber + "</td>"
                        saf9 = DriverPlateNumber
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If


                    'BİLGİ KOLUNU -------------------------------------------------------------
                    linkbilgi = "hasardetay.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType) + "&" + _
                    "op=yenikayit"

                    dugmebilgi = "<span class='button'>Bilgiler</span>"

                    kol10 = "<td><span class='iframeyenikayit' href=" + linkbilgi + ">" + _
                    dugmebilgi + "</a></td>"


                    'İPTAL KOLONU ---------------------------------------------------------------
                    linkiptal = "hasariptalyap.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType) + "&" + _
                    "op=yenikayit"

                    dugmeiptal = "<button class='btn btn-sm red filter-cancel'>" + _
                    "<i class='fa fa-times'></i> İptal</button>"


                    kol11 = "<td><span class='iframeyenikayit' href=" + linkiptal + ">" + _
                    dugmeiptal + "</a></td>"



                    'İPTAL GÖSTER KOLONU 
                    linkiptalgoster = "hasariptalgoster.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    dugmeiptalgoster = "<span class='button'>İptaller</span>"

                    kol12 = "<td><span class='iframeyenikayit' href=" + linkiptalgoster + ">" + _
                    dugmeiptalgoster + "</a></td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12


                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
                    pdftable.AddCell(New Phrase(saf9, fdata))

                    recordcount = recordcount + 1


                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function





    '---------------------------------listele--------------------------------------
    Public Function listele_sirketicin() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String

        Dim saf1, saf2, saf3, saf4, saf5 As String
        Dim saf6, saf7, saf8, saf9, saf10 As String


        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Plaka</th>" + _
        "<th>Bilgiler</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Dosya No", GetType(String))
        table.Columns.Add("Kaza Tarihi", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        table.Columns.Add("Plaka", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(8)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Dosya No", fbaslik))
        pdftable.AddCell(New Phrase("Kaza Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Ad Soyad", fbaslik))
        pdftable.AddCell(New Phrase("Plaka", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------


        'kimlikno
        If HttpContext.Current.Session("kimlik") <> "" Then
            sqldevam = sqldevam + " and DriverIdentityNo=@DriverIdentityNo"
        End If

        'plakano
        If HttpContext.Current.Session("plaka") <> "" Then
            sqldevam = sqldevam + " and DriverPlateNumber=@DriverPlateNumber"
        End If

        'ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and DriverName=@DriverName"
        End If

        'soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and DriverSurname=@DriverSurname"
        End If

        sqlstr = "select * from DamageInfo where " + _
        "1=1 " + sqldevam

        komut = New SqlCommand(sqlstr, db_baglanti)


        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlik") <> "" Then
            komut.Parameters.Add("@DriverIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@DriverIdentityNo").Value = HttpContext.Current.Session("kimlik")
        End If

        'plaka no seçilmişse
        If HttpContext.Current.Session("plaka") <> "" Then
            komut.Parameters.Add("@DriverPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@DriverPlateNumber").Value = HttpContext.Current.Session("plaka")
        End If

        'ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@DriverName", SqlDbType.VarChar)
            komut.Parameters("@DriverName").Value = HttpContext.Current.Session("ad")
        End If

        'soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@DriverSurname", SqlDbType.VarChar)
            komut.Parameters("@DriverSurname").Value = HttpContext.Current.Session("soyad")
        End If

        girdi = "0"

        Dim link As String
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType As String
        Dim DriverPlateNumber, AccidentDate As String
        Dim DriverIdentityNo As String
        Dim DriverName, DriverSurname As String
        Dim dugme As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    'PRİMARY KEY DOLDUR
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                    Else
                        FirmCode = "0"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                    Else
                        ProductCode = "0"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                    Else
                        AgencyCode = "0"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                    Else
                        PolicyNumber = "0"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                    Else
                        TecditNumber = "0"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                    Else
                        FileNo = "0"
                    End If

                    If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                        RequestNo = veri.Item("RequestNo")
                    Else
                        RequestNo = "0"
                    End If

                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = veri.Item("ProductType")
                    Else
                        ProductType = "0"
                    End If
                    '---------------------------------------

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_erisim.bultek_sirketkodagore(FirmCode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                        saf1 = sirket.sirketad
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + ProductCode + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol3 = "<td>" + AgencyCode + "</td>"
                        saf3 = AgencyCode
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol4 = "<td>" + PolicyNumber + "</td>"
                        saf4 = PolicyNumber
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                        kol5 = "<td>" + FileNo + "</td>"
                        saf5 = FileNo
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                        AccidentDate = veri.Item("AccidentDate")
                        kol6 = "<td>" + AccidentDate + "</td>"
                        saf6 = AccidentDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    '---DRIVER NAME -----------------------------------------------------
                    If Not veri.Item("DriverName") Is System.DBNull.Value Then
                        DriverName = veri.Item("DriverName")
                        saf7 = DriverName
                    Else
                        DriverName = ""
                        saf7 = "-"
                    End If

                    If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                        DriverSurname = veri.Item("DriverSurname")
                    Else
                        DriverSurname = ""
                    End If

                    kol7 = "<td>" + UCase(DriverName) + " " + UCase(DriverSurname) + "</td>"
                    saf7 = UCase(DriverName) + " " + UCase(DriverSurname)



                    If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                        DriverPlateNumber = veri.Item("DriverPlateNumber")
                        kol8 = "<td>" + DriverPlateNumber + "</td>"
                        saf8 = DriverPlateNumber
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If

                    link = "hasardetaysirket.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    dugme = "<span class='button'>Bilgiler</span>"

                    kol9 = "<td><span class='iframeyenikayit' href=" + link + ">" + _
                    dugme + "</a></td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9


                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))

                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function


    'tanımlamalardan ülke silmeye çalışırken bu fonksiyon ile kontrol yapılır.
    Function ulkevarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where " + _
        "DriverPlateCountryCode=@kod " + _
        "or DriverCountryCode=@kod " + _
        "or ClaimantCountryCode=@kod " + _
        "or ClaimantPlateCountryCode=@kod "

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
        komut.Parameters.Add(param1)

        veri = komut.ExecuteReader
        While veri.Read()
            varmi = "Evet"
            Exit While
        End While

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return varmi

    End Function


    Function hasardurumkodvarmi(ByVal DamageStatusCode As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where DamageStatusCode=@DamageStatusCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = DamageStatusCode
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return varmi

    End Function



    'tanımlamalardan kimlik türü silmeye çalışırken bu fonksiyon ile kontrol yapılır.
    Function kimlikturvarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where " + _
        "DriverIdentityCode=@kod " + _
        "or ClaimantIdentityCode=@kod "

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
        komut.Parameters.Add(param1)

        veri = komut.ExecuteReader
        While veri.Read()
            varmi = "Evet"
            Exit While
        End While

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function bultek(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal FileNo As String, ByVal RequestNo As String, ByVal ProductType As String)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekDamageInfo As New DamageInfo
        Dim DamageInfolar As New List(Of DamageInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo" + _
        " and ProductType=@ProductType"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = FileNo
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = RequestNo
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = ProductType
        komut.Parameters.Add(param5)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekDamageInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekDamageInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    donecekDamageInfo.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    donecekDamageInfo.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("DriverPlateCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverPlateCountryCode = veri.Item("DriverPlateCountryCode")
                End If

                If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverPlateNumber = veri.Item("DriverPlateNumber")
                End If

                If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                    donecekDamageInfo.AccidentDate = veri.Item("AccidentDate")
                Else
                    donecekDamageInfo.AccidentDate = "00:00:00"
                End If

                If Not veri.Item("AccidentLocation") Is System.DBNull.Value Then
                    donecekDamageInfo.AccidentLocation = veri.Item("AccidentLocation")
                End If

                If Not veri.Item("InformingDate") Is System.DBNull.Value Then
                    donecekDamageInfo.InformingDate = veri.Item("InformingDate")
                Else
                    donecekDamageInfo.InformingDate = "00:00:00"
                End If

                If Not veri.Item("DriverCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverCountryCode = veri.Item("DriverCountryCode")
                End If

                If Not veri.Item("DriverIdentityCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverIdentityCode = veri.Item("DriverIdentityCode")
                End If

                If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverIdentityNo = veri.Item("DriverIdentityNo")
                End If

                If Not veri.Item("DriverName") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverName = veri.Item("DriverName")
                End If

                If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverSurname = veri.Item("DriverSurname")
                Else
                    donecekDamageInfo.DriverSurname = ""
                End If

                If Not veri.Item("ClaimantCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantCountryCode = veri.Item("ClaimantCountryCode")
                End If

                If Not veri.Item("ClaimantIdentityCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantIdentityCode = veri.Item("ClaimantIdentityCode")
                End If

                If Not veri.Item("ClaimantIdentityNo") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantIdentityNo = veri.Item("ClaimantIdentityNo")
                End If

                If Not veri.Item("ClaimantName") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantName = veri.Item("ClaimantName")
                End If

                If Not veri.Item("ClaimantSurname") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantSurname = veri.Item("ClaimantSurname")
                Else
                    donecekDamageInfo.ClaimantSurname = ""
                End If

                If Not veri.Item("AppealDate") Is System.DBNull.Value Then
                    donecekDamageInfo.AppealDate = veri.Item("AppealDate")
                Else
                    donecekDamageInfo.AppealDate = "00:00:00"
                End If

                If Not veri.Item("ClaimantPlateCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantPlateCountryCode = veri.Item("ClaimantPlateCountryCode")
                End If

                If Not veri.Item("ClaimantPlateNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantPlateNumber = veri.Item("ClaimantPlateNumber")
                End If

                If Not veri.Item("DamageReason") Is System.DBNull.Value Then
                    donecekDamageInfo.DamageReason = veri.Item("DamageReason")
                End If

                If Not veri.Item("DamageStatusCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DamageStatusCode = veri.Item("DamageStatusCode")
                End If

                If Not veri.Item("EstimatedMaterialDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedMaterialDamage = veri.Item("EstimatedMaterialDamage")
                End If

                If Not veri.Item("PaidMaterialDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidMaterialDamage = veri.Item("PaidMaterialDamage")
                End If

                If Not veri.Item("CloseDate") Is System.DBNull.Value Then
                    donecekDamageInfo.CloseDate = veri.Item("CloseDate")
                Else
                    donecekDamageInfo.CloseDate = "00:00:00"
                End If

                If Not veri.Item("EstimatedCorporalDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedCorporalDamage = veri.Item("EstimatedCorporalDamage")
                End If

                If Not veri.Item("PaidCorporalDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidCorporalDamage = veri.Item("PaidCorporalDamage")
                End If

                If Not veri.Item("TotalLost") Is System.DBNull.Value Then
                    donecekDamageInfo.TotalLost = veri.Item("TotalLost")
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekDamageInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekDamageInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("EstimatedMaterialAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedMaterialAmountTL = veri.Item("EstimatedMaterialAmountTL")
                End If

                If Not veri.Item("PaidMaterialAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidMaterialAmountTL = veri.Item("PaidMaterialAmountTL")
                End If

                If Not veri.Item("EstimatedCorporalAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedCorporalAmountTL = veri.Item("EstimatedCorporalAmountTL")
                End If

                If Not veri.Item("PaidCorporalAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidCorporalAmountTL = veri.Item("PaidCorporalAmountTL")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekDamageInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekDamageInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekDamageInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekDamageInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekDamageInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekDamageInfo.PolicyType = veri.Item("PolicyType")
                End If

            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekDamageInfo


    End Function


    Function bultek_qrkodgore(ByVal SBMCode As String)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekDamageInfo As New DamageInfo
        Dim DamageInfolar As New List(Of DamageInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where SBMCode=@SBMCode"
  
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@SBMCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = SBMCode
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekDamageInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekDamageInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    donecekDamageInfo.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    donecekDamageInfo.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("DriverPlateCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverPlateCountryCode = veri.Item("DriverPlateCountryCode")
                End If

                If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverPlateNumber = veri.Item("DriverPlateNumber")
                End If

                If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                    donecekDamageInfo.AccidentDate = veri.Item("AccidentDate")
                Else
                    donecekDamageInfo.AccidentDate = "00:00:00"
                End If

                If Not veri.Item("AccidentLocation") Is System.DBNull.Value Then
                    donecekDamageInfo.AccidentLocation = veri.Item("AccidentLocation")
                End If

                If Not veri.Item("InformingDate") Is System.DBNull.Value Then
                    donecekDamageInfo.InformingDate = veri.Item("InformingDate")
                Else
                    donecekDamageInfo.InformingDate = "00:00:00"
                End If

                If Not veri.Item("DriverCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverCountryCode = veri.Item("DriverCountryCode")
                End If

                If Not veri.Item("DriverIdentityCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverIdentityCode = veri.Item("DriverIdentityCode")
                End If

                If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverIdentityNo = veri.Item("DriverIdentityNo")
                End If

                If Not veri.Item("DriverName") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverName = veri.Item("DriverName")
                End If

                If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                    donecekDamageInfo.DriverSurname = veri.Item("DriverSurname")
                Else
                    donecekDamageInfo.DriverSurname = ""
                End If

                If Not veri.Item("ClaimantCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantCountryCode = veri.Item("ClaimantCountryCode")
                End If

                If Not veri.Item("ClaimantIdentityCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantIdentityCode = veri.Item("ClaimantIdentityCode")
                End If

                If Not veri.Item("ClaimantIdentityNo") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantIdentityNo = veri.Item("ClaimantIdentityNo")
                End If

                If Not veri.Item("ClaimantName") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantName = veri.Item("ClaimantName")
                End If

                If Not veri.Item("ClaimantSurname") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantSurname = veri.Item("ClaimantSurname")
                Else
                    donecekDamageInfo.ClaimantSurname = ""
                End If

                If Not veri.Item("AppealDate") Is System.DBNull.Value Then
                    donecekDamageInfo.AppealDate = veri.Item("AppealDate")
                Else
                    donecekDamageInfo.AppealDate = "00:00:00"
                End If

                If Not veri.Item("ClaimantPlateCountryCode") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantPlateCountryCode = veri.Item("ClaimantPlateCountryCode")
                End If

                If Not veri.Item("ClaimantPlateNumber") Is System.DBNull.Value Then
                    donecekDamageInfo.ClaimantPlateNumber = veri.Item("ClaimantPlateNumber")
                End If

                If Not veri.Item("DamageReason") Is System.DBNull.Value Then
                    donecekDamageInfo.DamageReason = veri.Item("DamageReason")
                End If

                If Not veri.Item("DamageStatusCode") Is System.DBNull.Value Then
                    donecekDamageInfo.DamageStatusCode = veri.Item("DamageStatusCode")
                End If

                If Not veri.Item("EstimatedMaterialDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedMaterialDamage = veri.Item("EstimatedMaterialDamage")
                End If

                If Not veri.Item("PaidMaterialDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidMaterialDamage = veri.Item("PaidMaterialDamage")
                End If

                If Not veri.Item("CloseDate") Is System.DBNull.Value Then
                    donecekDamageInfo.CloseDate = veri.Item("CloseDate")
                Else
                    donecekDamageInfo.CloseDate = "00:00:00"
                End If

                If Not veri.Item("EstimatedCorporalDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedCorporalDamage = veri.Item("EstimatedCorporalDamage")
                End If

                If Not veri.Item("PaidCorporalDamage") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidCorporalDamage = veri.Item("PaidCorporalDamage")
                End If

                If Not veri.Item("TotalLost") Is System.DBNull.Value Then
                    donecekDamageInfo.TotalLost = veri.Item("TotalLost")
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekDamageInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekDamageInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("EstimatedMaterialAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedMaterialAmountTL = veri.Item("EstimatedMaterialAmountTL")
                End If

                If Not veri.Item("PaidMaterialAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidMaterialAmountTL = veri.Item("PaidMaterialAmountTL")
                End If

                If Not veri.Item("EstimatedCorporalAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.EstimatedCorporalAmountTL = veri.Item("EstimatedCorporalAmountTL")
                End If

                If Not veri.Item("PaidCorporalAmountTL") Is System.DBNull.Value Then
                    donecekDamageInfo.PaidCorporalAmountTL = veri.Item("PaidCorporalAmountTL")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekDamageInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekDamageInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekDamageInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekDamageInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekDamageInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekDamageInfo.PolicyType = veri.Item("PolicyType")
                End If


            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekDamageInfo


    End Function




    Function sil(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekDamageInfo As New DamageInfo
        Dim DamageInfolar As New List(Of DamageInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from DamageInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo " + _
        " and ProductType=@ProductType"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = AgencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = PolicyNumber
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = TecditNumber
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = FileNo
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = RequestNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)


        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return resultset

    End Function


    



    '-----HASAR SİLME İŞLEMİ İÇİN TABLO OLUŞTUR--------------------------------------
    Public Function listelehasarsilmeicin() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13 As String

        Dim saf1, saf2, saf3, saf4, saf5 As String
        Dim saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12, saf13 As String


        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Plaka</th>" + _
        "<th>Hasar Bilgi</th>" + _
        "<th>Silme İşlemi</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Dosya No", GetType(String))
        table.Columns.Add("Kaza Tarihi", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        table.Columns.Add("Kimlik", GetType(String))
        table.Columns.Add("Plaka", GetType(String))

        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(9)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Dosya No", fbaslik))
        pdftable.AddCell(New Phrase("Kaza Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Ad Soyad", fbaslik))
        pdftable.AddCell(New Phrase("Kimlik", fbaslik))
        pdftable.AddCell(New Phrase("Plaka", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            sqldevam = " and FirmCode=@FirmCode"
        End If

        'urun kodu seçilmişse
        If HttpContext.Current.Session("urunkodu") <> "0" Then
            sqldevam = sqldevam + " and ProductCode=@ProductCode"
        End If

        'dosya no seçilmişse
        If HttpContext.Current.Session("dosyano") <> "" Then
            sqldevam = sqldevam + " and FileNo=@FileNo"
        End If

        'policeno
        If HttpContext.Current.Session("policeno") <> "" Then
            sqldevam = sqldevam + " and PolicyNumber=@PolicyNumber"
        End If

        'kimlikno
        If HttpContext.Current.Session("kimlikno") <> "" Then
            sqldevam = sqldevam + " and DriverIdentityNo=@DriverIdentityNo"
        End If

        'plakano
        If HttpContext.Current.Session("plakano") <> "" Then
            sqldevam = sqldevam + " and DriverPlateNumber=@DriverPlateNumber"
        End If

        'sürücü ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and DriverName LIKE '%'+@DriverName+'%'"
        End If

        'sürücü soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and DriverSurname LIKE '%'+@DriverSurname+'%'"
        End If

        'talep ad
        If HttpContext.Current.Session("talepad") <> "" Then
            sqldevam = sqldevam + " and ClaimantName LIKE '%'+@ClaimantName+'%'"
        End If

        'talep soyad
        If HttpContext.Current.Session("talepsoyad") <> "" Then
            sqldevam = sqldevam + " and ClaimantSurname LIKE '%'+@ClaimantSurname+'%'"
        End If

        'talep plakano
        If HttpContext.Current.Session("talepplakano") <> "" Then
            sqldevam = sqldevam + " and ClaimantPlateNumber=@ClaimantPlateNumber"
        End If

        'talep kimlikno
        If HttpContext.Current.Session("talepkimlikno") <> "" Then
            sqldevam = sqldevam + " and ClaimantIdentityNo=@ClaimantIdentityNo"
        End If



        sqlstr = "select * from DamageInfo where " + _
        "(Convert(DATE,AccidentDate)>=@baslangic and Convert(DATE,AccidentDate)<=@bitis)" + _
        sqldevam

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = Current.Session("bitis")

        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            komut.Parameters.Add("@FirmCode", SqlDbType.VarChar)
            komut.Parameters("@FirmCode").Value = HttpContext.Current.Session("sirket")
        End If

        'urun kodu seçilmişse
        If HttpContext.Current.Session("urunkodu") <> "0" Then
            komut.Parameters.Add("@ProductCode", SqlDbType.VarChar)
            komut.Parameters("@ProductCode").Value = HttpContext.Current.Session("urunkodu")
        End If

        'dosya no seçilmişse
        If HttpContext.Current.Session("dosyano") <> "" Then
            komut.Parameters.Add("@FileNo", SqlDbType.VarChar)
            komut.Parameters("@FileNo").Value = HttpContext.Current.Session("dosyano")
        End If

        'police no seçilmişse
        If HttpContext.Current.Session("policeno") <> "" Then
            komut.Parameters.Add("@PolicyNumber", SqlDbType.VarChar)
            komut.Parameters("@PolicyNumber").Value = HttpContext.Current.Session("policeno")
        End If

        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlikno") <> "" Then
            komut.Parameters.Add("@DriverIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@DriverIdentityNo").Value = HttpContext.Current.Session("kimlikno")
        End If

        'plaka no seçilmişse
        If HttpContext.Current.Session("plakano") <> "" Then
            komut.Parameters.Add("@DriverPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@DriverPlateNumber").Value = HttpContext.Current.Session("plakano")
        End If


        'sürücü ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@DriverName", SqlDbType.VarChar)
            komut.Parameters("@DriverName").Value = HttpContext.Current.Session("ad")
        End If

        'sürücü soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@DriverSurname", SqlDbType.VarChar)
            komut.Parameters("@DriverSurname").Value = HttpContext.Current.Session("soyad")
        End If


        'talep ad seçilmiş ise
        If HttpContext.Current.Session("talepad") <> "" Then
            komut.Parameters.Add("@ClaimantName", SqlDbType.VarChar)
            komut.Parameters("@ClaimantName").Value = HttpContext.Current.Session("talepad")
        End If

        'talep soyad seçilmiş ise
        If HttpContext.Current.Session("talepsoyad") <> "" Then
            komut.Parameters.Add("@ClaimantSurname", SqlDbType.VarChar)
            komut.Parameters("@ClaimantSurname").Value = HttpContext.Current.Session("talepsoyad")
        End If

        'talep plaka no seçilmişse
        If HttpContext.Current.Session("talepplakano") <> "" Then
            komut.Parameters.Add("@ClaimantPlateNumber", SqlDbType.VarChar)
            komut.Parameters("@ClaimantPlateNumber").Value = HttpContext.Current.Session("talepplakano")
        End If


        'talep kimlik no seçilmişse
        If HttpContext.Current.Session("talepkimlikno") <> "" Then
            komut.Parameters.Add("@ClaimantIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@ClaimantIdentityNo").Value = HttpContext.Current.Session("talepkimlikno")
        End If

        girdi = "0"


        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType As String
        Dim DriverPlateNumber, AccidentDate As String
        Dim DriverIdentityNo As String
        Dim DriverName, DriverSurname As String
        Dim hasariniptalivarmi As String

        Dim dugmesil As String
        Dim linksil As String
        Dim linkiptalgoster As String
        Dim dugmeiptalgoster As String
        Dim linkbilgi As String
        Dim dugmebilgi As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    'PRİMARY KEY DOLDUR
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                    Else
                        FirmCode = "0"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                    Else
                        ProductCode = "0"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                    Else
                        AgencyCode = "0"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                    Else
                        PolicyNumber = "0"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                    Else
                        TecditNumber = "0"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                    Else
                        FileNo = "0"
                    End If

                    If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                        RequestNo = veri.Item("RequestNo")
                    Else
                        RequestNo = "0"
                    End If

                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = veri.Item("ProductType")
                    Else
                        ProductType = "0"
                    End If
                    '-------------------------------------------------------------------------


                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_erisim.bultek_sirketkodagore(FirmCode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                        saf1 = sirket.sirketad
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + ProductCode + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol3 = "<td>" + AgencyCode + "</td>"
                        saf3 = AgencyCode
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol4 = "<td>" + PolicyNumber + "</td>"
                        saf4 = PolicyNumber
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                        kol5 = "<td>" + FileNo + "</td>"
                        saf5 = FileNo
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("AccidentDate") Is System.DBNull.Value Then
                        AccidentDate = veri.Item("AccidentDate")
                        kol6 = "<td>" + AccidentDate + "</td>"
                        saf6 = AccidentDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    '---DRIVER NAME -----------------------------------------------------
                    If Not veri.Item("DriverName") Is System.DBNull.Value Then
                        DriverName = veri.Item("DriverName")
                        saf7 = DriverName
                    Else
                        DriverName = ""
                        saf7 = "-"
                    End If

                    If Not veri.Item("DriverSurname") Is System.DBNull.Value Then
                        DriverSurname = veri.Item("DriverSurname")
                    Else
                        DriverSurname = ""
                    End If

                    kol7 = "<td>" + UCase(DriverName) + " " + UCase(DriverSurname) + "</td>"
                    saf7 = UCase(DriverName) + " " + UCase(DriverSurname)


                    If Not veri.Item("DriverIdentityNo") Is System.DBNull.Value Then
                        DriverIdentityNo = veri.Item("DriverIdentityNo")
                        kol8 = "<td>" + DriverIdentityNo + "</td>"
                        saf8 = DriverIdentityNo
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If


                    If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                        DriverPlateNumber = veri.Item("DriverPlateNumber")
                        kol9 = "<td>" + DriverPlateNumber + "</td>"
                        saf9 = DriverPlateNumber
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If


                    'BİLGİ KOLUNU -------------------------------------------------------------
                    linkbilgi = "hasardetay.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType) + _
                    "op=yenikayit"

                    dugmebilgi = "<span class='button'>Bilgiler</span>"

                    kol10 = "<td><span class='iframeyenikayit' href=" + linkbilgi + ">" + _
                    dugmebilgi + "</a></td>"


                    'SİLME KOLONU ---------------------------------------------------------------
                    linksil = "hasarsilyap.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "FileNo=" + Trim(FileNo) + "&" + _
                    "RequestNo=" + Trim(RequestNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    dugmesil = "<button class='btn btn-sm red filter-cancel'>" + _
                    "<i class='fa fa-times'></i> Sil</button>"

                    kol11 = "<td><span class='iframeyenikayit' href=" + linksil + ">" + _
                    dugmesil + "</a></td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11


                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
                    pdftable.AddCell(New Phrase(saf9, fdata))

                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function


    Public Function xmlolustur(ByVal damageinfo As DamageInfo) As String


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim donecekxml As String = ""


        donecekxml = "<root>" + _
        "<DamageInfo FirmCode=" + Chr(34) + CStr(damageinfo.FirmCode) + Chr(34) + " " + _
        "ProductCode=" + Chr(34) + CStr(damageinfo.ProductCode) + Chr(34) + " " + _
        "AgencyCode=" + Chr(34) + CStr(damageinfo.AgencyCode) + Chr(34) + " " + _
        "PolicyNumber=" + Chr(34) + CStr(damageinfo.PolicyNumber) + Chr(34) + " " + _
        "TecditNumber=" + Chr(34) + CStr(damageinfo.TecditNumber) + Chr(34) + " " + _
        "FileNo=" + Chr(34) + CStr(damageinfo.FileNo) + Chr(34) + " " + _
        "RequestNo=" + Chr(34) + CStr(damageinfo.RequestNo) + Chr(34) + " " + _
        "DriverPlateCountryCode=" + Chr(34) + CStr(damageinfo.DriverPlateCountryCode) + Chr(34) + " " + _
        "DriverPlateNumber=" + Chr(34) + CStr(damageinfo.DriverPlateNumber) + Chr(34) + " " + _
        "AccidentDate=" + Chr(34) + CStr(damageinfo.AccidentDate) + Chr(34) + " " + _
        "AccidentLocation=" + Chr(34) + CStr(damageinfo.AccidentLocation) + Chr(34) + " " + _
        "InformingDate=" + Chr(34) + CStr(damageinfo.InformingDate) + Chr(34) + " " + _
        "DriverCountryCode=" + Chr(34) + CStr(damageinfo.DriverCountryCode) + Chr(34) + " " + _
        "DriverIdentityCode=" + Chr(34) + CStr(damageinfo.DriverIdentityCode) + Chr(34) + " " + _
        "DriverIdentityNo=" + Chr(34) + CStr(damageinfo.DriverIdentityNo) + Chr(34) + " " + _
        "DriverName=" + Chr(34) + CStr(damageinfo.DriverName) + Chr(34) + " " + _
        "DriverSurname=" + Chr(34) + CStr(damageinfo.DriverSurname) + Chr(34) + " " + _
        "ClaimantCountryCode=" + Chr(34) + CStr(damageinfo.ClaimantCountryCode) + Chr(34) + " " + _
        "ClaimantIdentityCode=" + Chr(34) + CStr(damageinfo.ClaimantIdentityCode) + Chr(34) + " " + _
        "ClaimantIdentityNo=" + Chr(34) + CStr(damageinfo.ClaimantIdentityNo) + Chr(34) + " " + _
        "ClaimantName=" + Chr(34) + CStr(damageinfo.ClaimantName) + Chr(34) + " " + _
        "ClaimantSurname=" + Chr(34) + CStr(damageinfo.ClaimantSurname) + Chr(34) + " " + _
        "AppealDate=" + Chr(34) + CStr(damageinfo.AppealDate) + Chr(34) + " " + _
        "ClaimantPlateCountryCode=" + Chr(34) + CStr(damageinfo.ClaimantPlateCountryCode) + Chr(34) + " " + _
        "ClaimantPlateNumber=" + Chr(34) + CStr(damageinfo.ClaimantPlateNumber) + Chr(34) + " " + _
        "DamageReason=" + Chr(34) + CStr(damageinfo.DamageReason) + Chr(34) + " " + _
        "DamageStatusCode=" + Chr(34) + CStr(damageinfo.DamageStatusCode) + Chr(34) + " " + _
        "EstimatedMaterialDamage=" + Chr(34) + CStr(damageinfo.EstimatedMaterialDamage) + Chr(34) + " " + _
        "PaidMaterialDamage=" + Chr(34) + CStr(damageinfo.PaidMaterialDamage) + Chr(34) + " " + _
        "CloseDate=" + Chr(34) + CStr(damageinfo.CloseDate) + Chr(34) + " " + _
        "EstimatedCorporalDamage=" + Chr(34) + CStr(damageinfo.EstimatedCorporalDamage) + Chr(34) + " " + _
        "PaidCorporalDamage=" + Chr(34) + CStr(damageinfo.PaidCorporalDamage) + Chr(34) + " " + _
        "TotalLost=" + Chr(34) + CStr(damageinfo.TotalLost) + Chr(34) + " " + _
        "TariffCode=" + Chr(34) + CStr(damageinfo.TariffCode) + Chr(34) + " " + _
        "CurrencyCode=" + Chr(34) + CStr(damageinfo.CurrencyCode) + Chr(34) + " " + _
        "EstimatedMaterialAmountTL=" + Chr(34) + CStr(damageinfo.EstimatedMaterialAmountTL) + Chr(34) + " " + _
        "PaidMaterialAmountTL=" + Chr(34) + CStr(damageinfo.PaidMaterialAmountTL) + Chr(34) + " " + _
        "EstimatedCorporalAmountTL=" + Chr(34) + CStr(damageinfo.EstimatedCorporalAmountTL) + Chr(34) + " " + _
        "PaidCorporalAmountTL=" + Chr(34) + CStr(damageinfo.PaidCorporalAmountTL) + Chr(34) + " " + _
        "ProductType=" + Chr(34) + CStr(damageinfo.ProductType) + Chr(34) + " " + _
        "SBMCode=" + Chr(34) + CStr(damageinfo.SBMCode) + Chr(34) + " " + _
        "ExchangeRate=" + Chr(34) + CStr(damageinfo.ExchangeRate) + Chr(34) + " " + _
        "TPNo=" + Chr(34) + CStr(damageinfo.TPNo) + Chr(34) + " " + _
        "></DamageInfo></root>"

        Return donecekxml

    End Function



   

End Class
