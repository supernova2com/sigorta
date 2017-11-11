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
Imports System.Web.HttpUtility.HtmlEncode


Public Class PolicyInfo_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull
    Dim ip_erisim As New CLASSIP_ERISIM



    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal PolicyInfo As PolicyInfo) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into PolicyInfo values (@FirmCode," + _
        "@ProductCode,@AgencyCode,@PolicyNumber,@TecditNumber," + _
        "@ZeylCode,@ZeylNo,@PolicyType,@PolicyOwnerCountryCode," + _
        "@PolicyOwnerIdentityCode,@PolicyOwnerIdentityNo,@PolicyOwnerName,@PolicyOwnerSurname," + _
        "@PolicyOwnerBirthDate,@AddressLine1,@AddressLine2,@AddressLine3," + _
        "@PlateCountryCode,@PlateNumber,@Brand,@Model," + _
        "@ChassisNumber,@EngineNumber,@EnginePower,@ProductionYear," + _
        "@Capacity,@CarType,@UsingStyle,@TariffCode," + _
        "@ArrangeDate,@StartDate,@EndDate,@Material," + _
        "@Corporal,@CurrencyCode,@PublicValue,@AuthorizedDrivers," + _
        "@CountryCode1,@IdentityCode1,@IdentityNo1,@Name1," + _
        "@Surname1,@BirthDate1,@DriverLicenceNo1,@DriverLicenceGivenDate1," + _
        "@DriverLicenceType1,@CountryCode2,@IdentityCode2,@IdentityNo2," + _
        "@Name2,@Surname2,@BirthDate2,@DriverLicenceNo2," + _
        "@DriverLicenceGivenDate2,@DriverLicenceType2,@CountryCode3,@IdentityCode3," + _
        "@IdentityNo3,@Name3,@Surname3,@BirthDate3," + _
        "@DriverLicenceNo3,@DriverLicenceGivenDate3,@DriverLicenceType3,@CountryCode4," + _
        "@IdentityCode4,@IdentityNo4,@Name4,@Surname4," + _
        "@BirthDate4,@DriverLicenceNo4,@DriverLicenceGivenDate4,@DriverLicenceType4," + _
        "@CountryCode5,@IdentityCode5,@IdentityNo5,@Name5," + _
        "@Surname5,@BirthDate5,@DriverLicenceNo5,@DriverLicenceGivenDate5," + _
        "@DriverLicenceType5,@CountryCode6,@IdentityCode6,@IdentityNo6," + _
        "@Name6,@Surname6,@BirthDate6,@DriverLicenceNo6," + _
        "@DriverLicenceGivenDate6,@DriverLicenceType6,@InsurancePremium,@AssistantFees," + _
        "@OtherFees,@BasePriceValue,@CCRateValue,@DamageRateValue," + _
        "@AgeRateValue,@DamagelessRateValue,@Color,@ProductType," + _
        "@FuelType,@SteeringSide,@AnyDriverRateValue,@PolicyPremium," + _
        "@PolicyPremiumTL,@InsurancePremiumTL,@PublicValueTL,@DamageRate," + _
        "@DamagelessRate,@AnyDriverRate,@AgeRate,@CCRate," + _
        "@SBMCode,@Creditor,@FirstBeneficiary,@ExchangeRate," + _
        "@AgencyRegisterCode,@TPNo,@BorderCode)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param1.Direction = ParameterDirection.Input
        If PolicyInfo.FirmCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = PolicyInfo.FirmCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param2.Direction = ParameterDirection.Input
        If PolicyInfo.ProductCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = PolicyInfo.ProductCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param3.Direction = ParameterDirection.Input
        If PolicyInfo.AgencyCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = PolicyInfo.AgencyCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param4.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyNumber = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = PolicyInfo.PolicyNumber
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
        param5.Direction = ParameterDirection.Input
        If PolicyInfo.TecditNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = PolicyInfo.TecditNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar, 1)
        param6.Direction = ParameterDirection.Input
        If PolicyInfo.ZeylCode = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = PolicyInfo.ZeylCode
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar, 15)
        param7.Direction = ParameterDirection.Input
        If PolicyInfo.ZeylNo = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = PolicyInfo.ZeylNo
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@PolicyType", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyType = 0 Then
            param8.Value = 0
        Else
            param8.Value = PolicyInfo.PolicyType
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@PolicyOwnerCountryCode", SqlDbType.VarChar, 3)
        param9.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerCountryCode = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = PolicyInfo.PolicyOwnerCountryCode
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@PolicyOwnerIdentityCode", SqlDbType.VarChar, 2)
        param10.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerIdentityCode = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = PolicyInfo.PolicyOwnerIdentityCode
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@PolicyOwnerIdentityNo", SqlDbType.VarChar, 15)
        param11.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerIdentityNo = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = PolicyInfo.PolicyOwnerIdentityNo
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@PolicyOwnerName", SqlDbType.VarChar, 50)
        param12.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerName = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = PolicyInfo.PolicyOwnerName
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@PolicyOwnerSurname", SqlDbType.VarChar, 30)
        param13.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerSurname = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = PolicyInfo.PolicyOwnerSurname
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@PolicyOwnerBirthDate", SqlDbType.Date)
        param14.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerBirthDate Is Nothing Or PolicyInfo.PolicyOwnerBirthDate = "00:00:00" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = PolicyInfo.PolicyOwnerBirthDate
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@AddressLine1", SqlDbType.VarChar, 50)
        param15.Direction = ParameterDirection.Input
        If PolicyInfo.AddressLine1 = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = PolicyInfo.AddressLine1
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@AddressLine2", SqlDbType.VarChar, 50)
        param16.Direction = ParameterDirection.Input
        If PolicyInfo.AddressLine2 = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = PolicyInfo.AddressLine2
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@AddressLine3", SqlDbType.VarChar, 50)
        param17.Direction = ParameterDirection.Input
        If PolicyInfo.AddressLine3 = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = PolicyInfo.AddressLine3
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@PlateCountryCode", SqlDbType.VarChar, 3)
        param18.Direction = ParameterDirection.Input
        If PolicyInfo.PlateCountryCode = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = PolicyInfo.PlateCountryCode
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@PlateNumber", SqlDbType.VarChar, 15)
        param19.Direction = ParameterDirection.Input
        If PolicyInfo.PlateNumber = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = UCase(PolicyInfo.PlateNumber)
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@Brand", SqlDbType.VarChar, 30)
        param20.Direction = ParameterDirection.Input
        If PolicyInfo.Brand = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = PolicyInfo.Brand
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@Model", SqlDbType.VarChar, 30)
        param21.Direction = ParameterDirection.Input
        If PolicyInfo.Model = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = PolicyInfo.Model
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@ChassisNumber", SqlDbType.VarChar, 30)
        param22.Direction = ParameterDirection.Input
        If PolicyInfo.ChassisNumber = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = PolicyInfo.ChassisNumber
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@EngineNumber", SqlDbType.VarChar, 30)
        param23.Direction = ParameterDirection.Input
        If PolicyInfo.EngineNumber = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = PolicyInfo.EngineNumber
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@EnginePower", SqlDbType.Int)
        param24.Direction = ParameterDirection.Input
        If PolicyInfo.EnginePower = 0 Then
            param24.Value = 0
        Else
            param24.Value = PolicyInfo.EnginePower
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@ProductionYear", SqlDbType.Int)
        param25.Direction = ParameterDirection.Input
        If PolicyInfo.ProductionYear = 0 Then
            param25.Value = 0
        Else
            param25.Value = PolicyInfo.ProductionYear
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@Capacity", SqlDbType.Int)
        param26.Direction = ParameterDirection.Input
        If PolicyInfo.Capacity = 0 Then
            param26.Value = 0
        Else
            param26.Value = PolicyInfo.Capacity
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@CarType", SqlDbType.VarChar, 25)
        param27.Direction = ParameterDirection.Input
        If PolicyInfo.CarType = "" Then
            param27.Value = System.DBNull.Value
        Else
            param27.Value = PolicyInfo.CarType
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@UsingStyle", SqlDbType.VarChar, 15)
        param28.Direction = ParameterDirection.Input
        If PolicyInfo.UsingStyle = "" Then
            param28.Value = System.DBNull.Value
        Else
            param28.Value = PolicyInfo.UsingStyle
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@TariffCode", SqlDbType.VarChar, 5)
        param29.Direction = ParameterDirection.Input
        If PolicyInfo.TariffCode = "" Then
            param29.Value = System.DBNull.Value
        Else
            param29.Value = PolicyInfo.TariffCode
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@ArrangeDate", SqlDbType.Date)
        param30.Direction = ParameterDirection.Input
        If PolicyInfo.ArrangeDate Is Nothing Or PolicyInfo.ArrangeDate = "00:00:00" Then
            param30.Value = System.DBNull.Value
        Else
            param30.Value = PolicyInfo.ArrangeDate
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@StartDate", SqlDbType.DateTime)
        param31.Direction = ParameterDirection.Input
        If PolicyInfo.StartDate Is Nothing Or PolicyInfo.StartDate = "00:00:00" Then
            param31.Value = System.DBNull.Value
        Else
            param31.Value = PolicyInfo.StartDate
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@EndDate", SqlDbType.Date)
        param32.Direction = ParameterDirection.Input
        If PolicyInfo.EndDate Is Nothing Or PolicyInfo.EndDate = "00:00:00" Then
            param32.Value = System.DBNull.Value
        Else
            param32.Value = PolicyInfo.EndDate
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@Material", SqlDbType.Decimal)
        param33.Direction = ParameterDirection.Input
        If PolicyInfo.Material = 0 Then
            param33.Value = 0
        Else
            param33.Value = PolicyInfo.Material
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@Corporal", SqlDbType.Decimal)
        param34.Direction = ParameterDirection.Input
        If PolicyInfo.Corporal = 0 Then
            param34.Value = 0
        Else
            param34.Value = PolicyInfo.Corporal
        End If
        komut.Parameters.Add(param34)

        Dim param35 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
        param35.Direction = ParameterDirection.Input
        If PolicyInfo.CurrencyCode = "" Then
            param35.Value = System.DBNull.Value
        Else
            param35.Value = PolicyInfo.CurrencyCode
        End If
        komut.Parameters.Add(param35)

        Dim param36 As New SqlParameter("@PublicValue", SqlDbType.Decimal)
        param36.Direction = ParameterDirection.Input
        If PolicyInfo.PublicValue = 0 Then
            param36.Value = 0
        Else
            param36.Value = PolicyInfo.PublicValue
        End If
        komut.Parameters.Add(param36)

        Dim param37 As New SqlParameter("@AuthorizedDrivers", SqlDbType.VarChar, 1)
        param37.Direction = ParameterDirection.Input
        If PolicyInfo.AuthorizedDrivers = "" Then
            param37.Value = System.DBNull.Value
        Else
            param37.Value = PolicyInfo.AuthorizedDrivers
        End If
        komut.Parameters.Add(param37)

        Dim param38 As New SqlParameter("@CountryCode1", SqlDbType.VarChar, 3)
        param38.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode1 = "" Then
            param38.Value = System.DBNull.Value
        Else
            param38.Value = PolicyInfo.CountryCode1
        End If
        komut.Parameters.Add(param38)

        Dim param39 As New SqlParameter("@IdentityCode1", SqlDbType.VarChar, 2)
        param39.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode1 = "" Then
            param39.Value = System.DBNull.Value
        Else
            param39.Value = PolicyInfo.IdentityCode1
        End If
        komut.Parameters.Add(param39)

        Dim param40 As New SqlParameter("@IdentityNo1", SqlDbType.VarChar, 15)
        param40.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo1 = "" Then
            param40.Value = System.DBNull.Value
        Else
            param40.Value = PolicyInfo.IdentityNo1
        End If
        komut.Parameters.Add(param40)

        Dim param41 As New SqlParameter("@Name1", SqlDbType.VarChar, 50)
        param41.Direction = ParameterDirection.Input
        If PolicyInfo.Name1 = "" Then
            param41.Value = System.DBNull.Value
        Else
            param41.Value = PolicyInfo.Name1
        End If
        komut.Parameters.Add(param41)

        Dim param42 As New SqlParameter("@Surname1", SqlDbType.VarChar, 30)
        param42.Direction = ParameterDirection.Input
        If PolicyInfo.Surname1 = "" Then
            param42.Value = System.DBNull.Value
        Else
            param42.Value = PolicyInfo.Surname1
        End If
        komut.Parameters.Add(param42)

        Dim param43 As New SqlParameter("@BirthDate1", SqlDbType.Date)
        param43.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.BirthDate1 = "00:00:00" Then
            param43.Value = System.DBNull.Value
        Else
            param43.Value = PolicyInfo.BirthDate1
        End If
        komut.Parameters.Add(param43)

        Dim param44 As New SqlParameter("@DriverLicenceNo1", SqlDbType.VarChar, 15)
        param44.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo1 = "" Then
            param44.Value = System.DBNull.Value
        Else
            param44.Value = PolicyInfo.DriverLicenceNo1
        End If
        komut.Parameters.Add(param44)

        Dim param45 As New SqlParameter("@DriverLicenceGivenDate1", SqlDbType.Date)
        param45.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate1 Is Nothing Or PolicyInfo.DriverLicenceGivenDate1 = "00:00:00" Then
            param45.Value = System.DBNull.Value
        Else
            param45.Value = PolicyInfo.DriverLicenceGivenDate1
        End If
        komut.Parameters.Add(param45)

        Dim param46 As New SqlParameter("@DriverLicenceType1", SqlDbType.VarChar, 1)
        param46.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType1 = "" Then
            param46.Value = System.DBNull.Value
        Else
            param46.Value = PolicyInfo.DriverLicenceType1
        End If
        komut.Parameters.Add(param46)

        Dim param47 As New SqlParameter("@CountryCode2", SqlDbType.VarChar, 3)
        param47.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode2 = "" Then
            param47.Value = System.DBNull.Value
        Else
            param47.Value = PolicyInfo.CountryCode2
        End If
        komut.Parameters.Add(param47)

        Dim param48 As New SqlParameter("@IdentityCode2", SqlDbType.VarChar, 2)
        param48.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode2 = "" Then
            param48.Value = System.DBNull.Value
        Else
            param48.Value = PolicyInfo.IdentityCode2
        End If
        komut.Parameters.Add(param48)

        Dim param49 As New SqlParameter("@IdentityNo2", SqlDbType.VarChar, 15)
        param49.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo2 = "" Then
            param49.Value = System.DBNull.Value
        Else
            param49.Value = PolicyInfo.IdentityNo2
        End If
        komut.Parameters.Add(param49)

        Dim param50 As New SqlParameter("@Name2", SqlDbType.VarChar, 50)
        param50.Direction = ParameterDirection.Input
        If PolicyInfo.Name2 = "" Then
            param50.Value = System.DBNull.Value
        Else
            param50.Value = PolicyInfo.Name2
        End If
        komut.Parameters.Add(param50)

        Dim param51 As New SqlParameter("@Surname2", SqlDbType.VarChar, 30)
        param51.Direction = ParameterDirection.Input
        If PolicyInfo.Surname2 = "" Then
            param51.Value = System.DBNull.Value
        Else
            param51.Value = PolicyInfo.Surname2
        End If
        komut.Parameters.Add(param51)

        Dim param52 As New SqlParameter("@BirthDate2", SqlDbType.Date)
        param52.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.BirthDate2 = "00:00:00" Then
            param52.Value = System.DBNull.Value
        Else
            param52.Value = PolicyInfo.BirthDate2
        End If
        komut.Parameters.Add(param52)

        Dim param53 As New SqlParameter("@DriverLicenceNo2", SqlDbType.VarChar, 15)
        param53.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo2 = "" Then
            param53.Value = System.DBNull.Value
        Else
            param53.Value = PolicyInfo.DriverLicenceNo2
        End If
        komut.Parameters.Add(param53)

        Dim param54 As New SqlParameter("@DriverLicenceGivenDate2", SqlDbType.Date)
        param54.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate2 Is Nothing Or PolicyInfo.DriverLicenceGivenDate2 = "00:00:00" Then
            param54.Value = System.DBNull.Value
        Else
            param54.Value = PolicyInfo.DriverLicenceGivenDate2
        End If
        komut.Parameters.Add(param54)

        Dim param55 As New SqlParameter("@DriverLicenceType2", SqlDbType.VarChar, 1)
        param55.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType2 = "" Then
            param55.Value = System.DBNull.Value
        Else
            param55.Value = PolicyInfo.DriverLicenceType2
        End If
        komut.Parameters.Add(param55)

        Dim param56 As New SqlParameter("@CountryCode3", SqlDbType.VarChar, 3)
        param56.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode3 = "" Then
            param56.Value = System.DBNull.Value
        Else
            param56.Value = PolicyInfo.CountryCode3
        End If
        komut.Parameters.Add(param56)

        Dim param57 As New SqlParameter("@IdentityCode3", SqlDbType.VarChar, 2)
        param57.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode3 = "" Then
            param57.Value = System.DBNull.Value
        Else
            param57.Value = PolicyInfo.IdentityCode3
        End If
        komut.Parameters.Add(param57)

        Dim param58 As New SqlParameter("@IdentityNo3", SqlDbType.VarChar, 15)
        param58.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo3 = "" Then
            param58.Value = System.DBNull.Value
        Else
            param58.Value = PolicyInfo.IdentityNo3
        End If
        komut.Parameters.Add(param58)

        Dim param59 As New SqlParameter("@Name3", SqlDbType.VarChar, 50)
        param59.Direction = ParameterDirection.Input
        If PolicyInfo.Name3 = "" Then
            param59.Value = System.DBNull.Value
        Else
            param59.Value = PolicyInfo.Name3
        End If
        komut.Parameters.Add(param59)

        Dim param60 As New SqlParameter("@Surname3", SqlDbType.VarChar, 30)
        param60.Direction = ParameterDirection.Input
        If PolicyInfo.Surname3 = "" Then
            param60.Value = System.DBNull.Value
        Else
            param60.Value = PolicyInfo.Surname3
        End If
        komut.Parameters.Add(param60)

        Dim param61 As New SqlParameter("@BirthDate3", SqlDbType.Date)
        param61.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.BirthDate3 = "00:00:00" Then
            param61.Value = System.DBNull.Value
        Else
            param61.Value = PolicyInfo.BirthDate3
        End If
        komut.Parameters.Add(param61)

        Dim param62 As New SqlParameter("@DriverLicenceNo3", SqlDbType.VarChar, 15)
        param62.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo3 = "" Then
            param62.Value = System.DBNull.Value
        Else
            param62.Value = PolicyInfo.DriverLicenceNo3
        End If
        komut.Parameters.Add(param62)

        Dim param63 As New SqlParameter("@DriverLicenceGivenDate3", SqlDbType.Date)
        param63.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate3 Is Nothing Or PolicyInfo.DriverLicenceGivenDate3 = "00:00:00" Then
            param63.Value = System.DBNull.Value
        Else
            param63.Value = PolicyInfo.DriverLicenceGivenDate3
        End If
        komut.Parameters.Add(param63)

        Dim param64 As New SqlParameter("@DriverLicenceType3", SqlDbType.VarChar, 1)
        param64.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType3 = "" Then
            param64.Value = System.DBNull.Value
        Else
            param64.Value = PolicyInfo.DriverLicenceType3
        End If
        komut.Parameters.Add(param64)

        Dim param65 As New SqlParameter("@CountryCode4", SqlDbType.VarChar, 3)
        param65.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode4 = "" Then
            param65.Value = System.DBNull.Value
        Else
            param65.Value = PolicyInfo.CountryCode4
        End If
        komut.Parameters.Add(param65)

        Dim param66 As New SqlParameter("@IdentityCode4", SqlDbType.VarChar, 2)
        param66.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode4 = "" Then
            param66.Value = System.DBNull.Value
        Else
            param66.Value = PolicyInfo.IdentityCode4
        End If
        komut.Parameters.Add(param66)

        Dim param67 As New SqlParameter("@IdentityNo4", SqlDbType.VarChar, 15)
        param67.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo4 = "" Then
            param67.Value = System.DBNull.Value
        Else
            param67.Value = PolicyInfo.IdentityNo4
        End If
        komut.Parameters.Add(param67)

        Dim param68 As New SqlParameter("@Name4", SqlDbType.VarChar, 50)
        param68.Direction = ParameterDirection.Input
        If PolicyInfo.Name4 = "" Then
            param68.Value = System.DBNull.Value
        Else
            param68.Value = PolicyInfo.Name4
        End If
        komut.Parameters.Add(param68)

        Dim param69 As New SqlParameter("@Surname4", SqlDbType.VarChar, 30)
        param69.Direction = ParameterDirection.Input
        If PolicyInfo.Surname4 = "" Then
            param69.Value = System.DBNull.Value
        Else
            param69.Value = PolicyInfo.Surname4
        End If
        komut.Parameters.Add(param69)

        Dim param70 As New SqlParameter("@BirthDate4", SqlDbType.Date)
        param70.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.BirthDate4 = "00:00:00" Then
            param70.Value = System.DBNull.Value
        Else
            param70.Value = PolicyInfo.BirthDate4
        End If
        komut.Parameters.Add(param70)

        Dim param71 As New SqlParameter("@DriverLicenceNo4", SqlDbType.VarChar, 15)
        param71.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo4 = "" Then
            param71.Value = System.DBNull.Value
        Else
            param71.Value = PolicyInfo.DriverLicenceNo4
        End If
        komut.Parameters.Add(param71)

        Dim param72 As New SqlParameter("@DriverLicenceGivenDate4", SqlDbType.Date)
        param72.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate4 Is Nothing Or PolicyInfo.DriverLicenceGivenDate4 = "00:00:00" Then
            param72.Value = System.DBNull.Value
        Else
            param72.Value = PolicyInfo.DriverLicenceGivenDate4
        End If
        komut.Parameters.Add(param72)

        Dim param73 As New SqlParameter("@DriverLicenceType4", SqlDbType.VarChar, 1)
        param73.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType4 = "" Then
            param73.Value = System.DBNull.Value
        Else
            param73.Value = PolicyInfo.DriverLicenceType4
        End If
        komut.Parameters.Add(param73)

        Dim param74 As New SqlParameter("@CountryCode5", SqlDbType.VarChar, 3)
        param74.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode5 = "" Then
            param74.Value = System.DBNull.Value
        Else
            param74.Value = PolicyInfo.CountryCode5
        End If
        komut.Parameters.Add(param74)

        Dim param75 As New SqlParameter("@IdentityCode5", SqlDbType.VarChar, 2)
        param75.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode5 = "" Then
            param75.Value = System.DBNull.Value
        Else
            param75.Value = PolicyInfo.IdentityCode5
        End If
        komut.Parameters.Add(param75)

        Dim param76 As New SqlParameter("@IdentityNo5", SqlDbType.VarChar, 15)
        param76.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo5 = "" Then
            param76.Value = System.DBNull.Value
        Else
            param76.Value = PolicyInfo.IdentityNo5
        End If
        komut.Parameters.Add(param76)

        Dim param77 As New SqlParameter("@Name5", SqlDbType.VarChar, 50)
        param77.Direction = ParameterDirection.Input
        If PolicyInfo.Name5 = "" Then
            param77.Value = System.DBNull.Value
        Else
            param77.Value = PolicyInfo.Name5
        End If
        komut.Parameters.Add(param77)

        Dim param78 As New SqlParameter("@Surname5", SqlDbType.VarChar, 30)
        param78.Direction = ParameterDirection.Input
        If PolicyInfo.Surname5 = "" Then
            param78.Value = System.DBNull.Value
        Else
            param78.Value = PolicyInfo.Surname5
        End If
        komut.Parameters.Add(param78)

        Dim param79 As New SqlParameter("@BirthDate5", SqlDbType.Date)
        param79.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.BirthDate5 = "00:00:00" Then
            param79.Value = System.DBNull.Value
        Else
            param79.Value = PolicyInfo.BirthDate5
        End If
        komut.Parameters.Add(param79)

        Dim param80 As New SqlParameter("@DriverLicenceNo5", SqlDbType.VarChar, 15)
        param80.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo5 = "" Then
            param80.Value = System.DBNull.Value
        Else
            param80.Value = PolicyInfo.DriverLicenceNo5
        End If
        komut.Parameters.Add(param80)

        Dim param81 As New SqlParameter("@DriverLicenceGivenDate5", SqlDbType.Date)
        param81.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate5 Is Nothing Or PolicyInfo.DriverLicenceGivenDate5 = "00:00:00" Then
            param81.Value = System.DBNull.Value
        Else
            param81.Value = PolicyInfo.DriverLicenceGivenDate5
        End If
        komut.Parameters.Add(param81)

        Dim param82 As New SqlParameter("@DriverLicenceType5", SqlDbType.VarChar, 1)
        param82.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType5 = "" Then
            param82.Value = System.DBNull.Value
        Else
            param82.Value = PolicyInfo.DriverLicenceType5
        End If
        komut.Parameters.Add(param82)

        Dim param83 As New SqlParameter("@CountryCode6", SqlDbType.VarChar, 3)
        param83.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode6 = "" Then
            param83.Value = System.DBNull.Value
        Else
            param83.Value = PolicyInfo.CountryCode6
        End If
        komut.Parameters.Add(param83)

        Dim param84 As New SqlParameter("@IdentityCode6", SqlDbType.VarChar, 2)
        param84.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode6 = "" Then
            param84.Value = System.DBNull.Value
        Else
            param84.Value = PolicyInfo.IdentityCode6
        End If
        komut.Parameters.Add(param84)

        Dim param85 As New SqlParameter("@IdentityNo6", SqlDbType.VarChar, 15)
        param85.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo6 = "" Then
            param85.Value = System.DBNull.Value
        Else
            param85.Value = PolicyInfo.IdentityNo6
        End If
        komut.Parameters.Add(param85)

        Dim param86 As New SqlParameter("@Name6", SqlDbType.VarChar, 50)
        param86.Direction = ParameterDirection.Input
        If PolicyInfo.Name6 = "" Then
            param86.Value = System.DBNull.Value
        Else
            param86.Value = PolicyInfo.Name6
        End If
        komut.Parameters.Add(param86)

        Dim param87 As New SqlParameter("@Surname6", SqlDbType.VarChar, 30)
        param87.Direction = ParameterDirection.Input
        If PolicyInfo.Surname6 = "" Then
            param87.Value = System.DBNull.Value
        Else
            param87.Value = PolicyInfo.Surname6
        End If
        komut.Parameters.Add(param87)

        Dim param88 As New SqlParameter("@BirthDate6", SqlDbType.Date)
        param88.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.BirthDate6 = "00:00:00" Then
            param88.Value = System.DBNull.Value
        Else
            param88.Value = PolicyInfo.BirthDate6
        End If
        komut.Parameters.Add(param88)

        Dim param89 As New SqlParameter("@DriverLicenceNo6", SqlDbType.VarChar, 15)
        param89.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo6 = "" Then
            param89.Value = System.DBNull.Value
        Else
            param89.Value = PolicyInfo.DriverLicenceNo6
        End If
        komut.Parameters.Add(param89)

        Dim param90 As New SqlParameter("@DriverLicenceGivenDate6", SqlDbType.Date)
        param90.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate6 Is Nothing Or PolicyInfo.DriverLicenceGivenDate6 = "00:00:00" Then
            param90.Value = System.DBNull.Value
        Else
            param90.Value = PolicyInfo.DriverLicenceGivenDate6
        End If
        komut.Parameters.Add(param90)

        Dim param91 As New SqlParameter("@DriverLicenceType6", SqlDbType.VarChar, 1)
        param91.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType6 = "" Then
            param91.Value = System.DBNull.Value
        Else
            param91.Value = PolicyInfo.DriverLicenceType6
        End If
        komut.Parameters.Add(param91)

        Dim param92 As New SqlParameter("@InsurancePremium", SqlDbType.Decimal)
        param92.Direction = ParameterDirection.Input
        If PolicyInfo.InsurancePremium = 0 Then
            param92.Value = 0
        Else
            param92.Value = PolicyInfo.InsurancePremium
        End If
        komut.Parameters.Add(param92)

        Dim param93 As New SqlParameter("@AssistantFees", SqlDbType.Decimal)
        param93.Direction = ParameterDirection.Input
        If PolicyInfo.AssistantFees = 0 Then
            param93.Value = 0
        Else
            param93.Value = PolicyInfo.AssistantFees
        End If
        komut.Parameters.Add(param93)

        Dim param94 As New SqlParameter("@OtherFees", SqlDbType.Decimal)
        param94.Direction = ParameterDirection.Input
        If PolicyInfo.OtherFees = 0 Then
            param94.Value = 0
        Else
            param94.Value = PolicyInfo.OtherFees
        End If
        komut.Parameters.Add(param94)


        Dim param95 As New SqlParameter("@BasePriceValue", SqlDbType.Decimal)
        param95.Direction = ParameterDirection.Input
        If PolicyInfo.BasePriceValue = 0 Then
            param95.Value = 0
        Else
            param95.Value = PolicyInfo.BasePriceValue
        End If
        komut.Parameters.Add(param95)

        Dim param96 As New SqlParameter("@CCRateValue", SqlDbType.Decimal)
        param96.Direction = ParameterDirection.Input
        If PolicyInfo.CCRateValue = 0 Then
            param96.Value = 0
        Else
            param96.Value = PolicyInfo.CCRateValue
        End If
        komut.Parameters.Add(param96)

        Dim param97 As New SqlParameter("@DamageRateValue", SqlDbType.Decimal)
        param97.Direction = ParameterDirection.Input
        If PolicyInfo.DamageRateValue = 0 Then
            param97.Value = 0
        Else
            param97.Value = PolicyInfo.DamageRateValue
        End If
        komut.Parameters.Add(param97)

        Dim param98 As New SqlParameter("@AgeRateValue", SqlDbType.Decimal)
        param98.Direction = ParameterDirection.Input
        If PolicyInfo.AgeRateValue = 0 Then
            param98.Value = 0
        Else
            param98.Value = PolicyInfo.AgeRateValue
        End If
        komut.Parameters.Add(param98)

        Dim param99 As New SqlParameter("@DamagelessRateValue", SqlDbType.Decimal)
        param99.Direction = ParameterDirection.Input
        If PolicyInfo.DamagelessRateValue = 0 Then
            param99.Value = 0
        Else
            param99.Value = PolicyInfo.DamagelessRateValue
        End If
        komut.Parameters.Add(param99)

        Dim param100 As New SqlParameter("@Color", SqlDbType.VarChar)
        param100.Direction = ParameterDirection.Input
        If PolicyInfo.Color = "" Then
            param100.Value = System.DBNull.Value
        Else
            param100.Value = PolicyInfo.Color
        End If
        komut.Parameters.Add(param100)


        Dim param101 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param101.Direction = ParameterDirection.Input
        If PolicyInfo.ProductType = "" Then
            param101.Value = System.DBNull.Value
        Else
            param101.Value = PolicyInfo.ProductType
        End If
        komut.Parameters.Add(param101)

        Dim param102 As New SqlParameter("@FuelType", SqlDbType.Int)
        param102.Direction = ParameterDirection.Input
        If PolicyInfo.FuelType = 0 Then
            param102.Value = 0
        Else
            param102.Value = PolicyInfo.FuelType
        End If
        komut.Parameters.Add(param102)

        Dim param103 As New SqlParameter("@SteeringSide", SqlDbType.VarChar)
        param103.Direction = ParameterDirection.Input
        If PolicyInfo.SteeringSide = "" Then
            param103.Value = System.DBNull.Value
        Else
            param103.Value = PolicyInfo.SteeringSide
        End If
        komut.Parameters.Add(param103)

        Dim param104 As New SqlParameter("@AnyDriverRateValue", SqlDbType.Decimal)
        param104.Direction = ParameterDirection.Input
        If PolicyInfo.AnyDriverRateValue = 0 Then
            param104.Value = 0
        Else
            param104.Value = PolicyInfo.AnyDriverRateValue
        End If
        komut.Parameters.Add(param104)

        Dim param105 As New SqlParameter("@PolicyPremium", SqlDbType.Decimal)
        param105.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyPremium = 0 Then
            param105.Value = 0
        Else
            param105.Value = PolicyInfo.PolicyPremium
        End If
        komut.Parameters.Add(param105)

        Dim param106 As New SqlParameter("@PolicyPremiumTL", SqlDbType.Decimal)
        param106.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyPremiumTL = 0 Then
            param106.Value = 0
        Else
            param106.Value = PolicyInfo.PolicyPremiumTL
        End If
        komut.Parameters.Add(param106)

        Dim param107 As New SqlParameter("@InsurancePremiumTL", SqlDbType.Decimal)
        param107.Direction = ParameterDirection.Input
        If PolicyInfo.InsurancePremiumTL = 0 Then
            param107.Value = 0
        Else
            param107.Value = PolicyInfo.InsurancePremiumTL
        End If
        komut.Parameters.Add(param107)

        Dim param108 As New SqlParameter("@PublicValueTL", SqlDbType.Decimal)
        param108.Direction = ParameterDirection.Input
        If PolicyInfo.PublicValueTL = 0 Then
            param108.Value = 0
        Else
            param108.Value = PolicyInfo.PublicValueTL
        End If
        komut.Parameters.Add(param108)

        Dim param109 As New SqlParameter("@DamageRate", SqlDbType.Int)
        param109.Direction = ParameterDirection.Input
        If PolicyInfo.DamageRate = 0 Then
            param109.Value = 0
        Else
            param109.Value = PolicyInfo.DamageRate
        End If
        komut.Parameters.Add(param109)

        Dim param110 As New SqlParameter("@DamagelessRate", SqlDbType.Int)
        param110.Direction = ParameterDirection.Input
        If PolicyInfo.DamagelessRate = 0 Then
            param110.Value = 0
        Else
            param110.Value = PolicyInfo.DamagelessRate
        End If
        komut.Parameters.Add(param110)

        Dim param111 As New SqlParameter("@AnyDriverRate", SqlDbType.Int)
        param111.Direction = ParameterDirection.Input
        If PolicyInfo.AnyDriverRate = 0 Then
            param111.Value = 0
        Else
            param111.Value = PolicyInfo.AnyDriverRate
        End If
        komut.Parameters.Add(param111)

        Dim param112 As New SqlParameter("@AgeRate", SqlDbType.Int)
        param112.Direction = ParameterDirection.Input
        If PolicyInfo.AgeRate = 0 Then
            param112.Value = 0
        Else
            param112.Value = PolicyInfo.AgeRate
        End If
        komut.Parameters.Add(param112)

        Dim param113 As New SqlParameter("@CCRate", SqlDbType.Int)
        param113.Direction = ParameterDirection.Input
        If PolicyInfo.CCRate = 0 Then
            param113.Value = 0
        Else
            param113.Value = PolicyInfo.CCRate
        End If
        komut.Parameters.Add(param113)

        Dim param114 As New SqlParameter("@SBMCode", SqlDbType.VarChar)
        param114.Direction = ParameterDirection.Input
        If PolicyInfo.SBMCode = "" Then
            param114.Value = System.DBNull.Value
        Else
            param114.Value = PolicyInfo.SBMCode
        End If
        komut.Parameters.Add(param114)


        Dim param115 As New SqlParameter("@Creditor", SqlDbType.Int)
        param115.Direction = ParameterDirection.Input
        If PolicyInfo.Creditor = 0 Then
            param115.Value = 0
        Else
            param115.Value = PolicyInfo.Creditor
        End If
        komut.Parameters.Add(param115)


        Dim param116 As New SqlParameter("@FirstBeneficiary", SqlDbType.VarChar)
        param116.Direction = ParameterDirection.Input
        If PolicyInfo.FirstBeneficiary = "" Then
            param116.Value = System.DBNull.Value
        Else
            param116.Value = PolicyInfo.FirstBeneficiary
        End If
        komut.Parameters.Add(param116)


        Dim param117 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
        param117.Direction = ParameterDirection.Input
        If PolicyInfo.ExchangeRate = 0 Then
            param117.Value = 0
        Else
            param117.Value = PolicyInfo.ExchangeRate
        End If
        komut.Parameters.Add(param117)


        Dim param118 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar)
        param118.Direction = ParameterDirection.Input
        If PolicyInfo.AgencyRegisterCode = "" Then
            param118.Value = System.DBNull.Value
        Else
            param118.Value = PolicyInfo.AgencyRegisterCode
        End If
        komut.Parameters.Add(param118)

        Dim param119 As New SqlParameter("@TPNo", SqlDbType.VarChar)
        param119.Direction = ParameterDirection.Input
        If PolicyInfo.TPNo = "" Then
            param119.Value = System.DBNull.Value
        Else
            param119.Value = PolicyInfo.TPNo
        End If
        komut.Parameters.Add(param119)

        Dim param120 As New SqlParameter("@BorderCode", SqlDbType.VarChar, 5)
        param120.Direction = ParameterDirection.Input
        If PolicyInfo.BorderCode = "" Then
            param120.Value = System.DBNull.Value
        Else
            param120.Value = PolicyInfo.BorderCode
        End If
        komut.Parameters.Add(param120)


        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı"
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
    Function Duzenle(ByVal PolicyInfo As PolicyInfo) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update PolicyInfo set " + _
        "PolicyType=@PolicyType," + _
        "PolicyOwnerCountryCode=@PolicyOwnerCountryCode," + _
        "PolicyOwnerIdentityCode=@PolicyOwnerIdentityCode," + _
        "PolicyOwnerIdentityNo=@PolicyOwnerIdentityNo," + _
        "PolicyOwnerName=@PolicyOwnerName," + _
        "PolicyOwnerSurname=@PolicyOwnerSurname," + _
        "PolicyOwnerBirthDate=@PolicyOwnerBirthDate," + _
        "AddressLine1=@AddressLine1," + _
        "AddressLine2=@AddressLine2," + _
        "AddressLine3=@AddressLine3," + _
        "PlateCountryCode=@PlateCountryCode," + _
        "PlateNumber=@PlateNumber," + _
        "Brand=@Brand," + _
        "Model=@Model," + _
        "ChassisNumber=@ChassisNumber," + _
        "EngineNumber=@EngineNumber," + _
        "EnginePower=@EnginePower," + _
        "ProductionYear=@ProductionYear," + _
        "Capacity=@Capacity," + _
        "CarType=@CarType," + _
        "UsingStyle=@UsingStyle," + _
        "TariffCode=@TariffCode," + _
        "ArrangeDate=@ArrangeDate," + _
        "StartDate=@StartDate," + _
        "EndDate=@EndDate," + _
        "Material=@Material," + _
        "Corporal=@Corporal," + _
        "CurrencyCode=@CurrencyCode," + _
        "PublicValue=@PublicValue," + _
        "AuthorizedDrivers=@AuthorizedDrivers," + _
        "CountryCode1=@CountryCode1," + _
        "IdentityCode1=@IdentityCode1," + _
        "IdentityNo1=@IdentityNo1," + _
        "Name1=@Name1," + _
        "Surname1=@Surname1," + _
        "BirthDate1=@BirthDate1," + _
        "DriverLicenceNo1=@DriverLicenceNo1," + _
        "DriverLicenceGivenDate1=@DriverLicenceGivenDate1," + _
        "DriverLicenceType1=@DriverLicenceType1," + _
        "CountryCode2=@CountryCode2," + _
        "IdentityCode2=@IdentityCode2," + _
        "IdentityNo2=@IdentityNo2," + _
        "Name2=@Name2," + _
        "Surname2=@Surname2," + _
        "BirthDate2=@BirthDate2," + _
        "DriverLicenceNo2=@DriverLicenceNo2," + _
        "DriverLicenceGivenDate2=@DriverLicenceGivenDate2," + _
        "DriverLicenceType2=@DriverLicenceType2," + _
        "CountryCode3=@CountryCode3," + _
        "IdentityCode3=@IdentityCode3," + _
        "IdentityNo3=@IdentityNo3," + _
        "Name3=@Name3," + _
        "Surname3=@Surname3," + _
        "BirthDate3=@BirthDate3," + _
        "DriverLicenceNo3=@DriverLicenceNo3," + _
        "DriverLicenceGivenDate3=@DriverLicenceGivenDate3," + _
        "DriverLicenceType3=@DriverLicenceType3," + _
        "CountryCode4=@CountryCode4," + _
        "IdentityCode4=@IdentityCode4," + _
        "IdentityNo4=@IdentityNo4," + _
        "Name4=@Name4," + _
        "Surname4=@Surname4," + _
        "BirthDate4=@BirthDate4," + _
        "DriverLicenceNo4=@DriverLicenceNo4," + _
        "DriverLicenceGivenDate4=@DriverLicenceGivenDate4," + _
        "DriverLicenceType4=@DriverLicenceType4," + _
        "CountryCode5=@CountryCode5," + _
        "IdentityCode5=@IdentityCode5," + _
        "IdentityNo5=@IdentityNo5," + _
        "Name5=@Name5," + _
        "Surname5=@Surname5," + _
        "BirthDate5=@BirthDate5," + _
        "DriverLicenceNo5=@DriverLicenceNo5," + _
        "DriverLicenceGivenDate5=@DriverLicenceGivenDate5," + _
        "DriverLicenceType5=@DriverLicenceType5," + _
        "CountryCode6=@CountryCode6," + _
        "IdentityCode6=@IdentityCode6," + _
        "IdentityNo6=@IdentityNo6," + _
        "Name6=@Name6," + _
        "Surname6=@Surname6," + _
        "BirthDate6=@BirthDate6," + _
        "DriverLicenceNo6=@DriverLicenceNo6," + _
        "DriverLicenceGivenDate6=@DriverLicenceGivenDate6," + _
        "DriverLicenceType6=@DriverLicenceType6," + _
        "InsurancePremium=@InsurancePremium," + _
        "AssistantFees=@AssistantFees," + _
        "OtherFees=@OtherFees," + _
        "BasePriceValue=@BasePriceValue," + _
        "CCRateValue=@CCRateValue," + _
        "DamageRateValue=@DamageRateValue," + _
        "AgeRateValue=@AgeRateValue," + _
        "DamagelessRateValue=@DamagelessRateValue," + _
        "Color=@Color," + _
        "FuelType=@FuelType," + _
        "SteeringSide=@SteeringSide," + _
        "AnyDriverRateValue=@AnyDriverRateValue," + _
        "PolicyPremium=@PolicyPremium," + _
        "PolicyPremiumTL=@PolicyPremiumTL," + _
        "InsurancePremiumTL=@InsurancePremiumTL," + _
        "PublicValueTL=@PublicValueTL," + _
        "DamageRate=@DamageRate," + _
        "DamagelessRate=@DamagelessRate," + _
        "AnyDriverRate=@AnyDriverRate," + _
        "AgeRate=@AgeRate," + _
        "CCRate=@CCRate," + _
        "SBMCode=@SBMCode," + _
        "Creditor=@Creditor," + _
        "FirstBeneficiary=@FirstBeneficiary," + _
        "ExchangeRate=@ExchangeRate," + _
        "AgencyRegisterCode=@AgencyRegisterCode," + _
        "TPNo=@TPNo," + _
        "BorderCode=@BorderCode" + _
        " where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "ProductType=@ProductType and " + _
        "AgencyCode=@AgencyCode and " + _
        "PolicyNumber=@PolicyNumber and " + _
        "TecditNumber=@TecditNumber and " + _
        "ZeylCode=@ZeylCode and " + _
        "ZeylNo=@ZeylNo"


        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param1.Direction = ParameterDirection.Input
        If PolicyInfo.FirmCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = PolicyInfo.FirmCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param2.Direction = ParameterDirection.Input
        If PolicyInfo.ProductCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = PolicyInfo.ProductCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param3.Direction = ParameterDirection.Input
        If PolicyInfo.AgencyCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = PolicyInfo.AgencyCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param4.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyNumber = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = PolicyInfo.PolicyNumber
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
        param5.Direction = ParameterDirection.Input
        If PolicyInfo.TecditNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = PolicyInfo.TecditNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar, 1)
        param6.Direction = ParameterDirection.Input
        If PolicyInfo.ZeylCode = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = PolicyInfo.ZeylCode
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar, 15)
        param7.Direction = ParameterDirection.Input
        If PolicyInfo.ZeylNo = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = PolicyInfo.ZeylNo
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@PolicyType", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyType = 0 Then
            param8.Value = 0
        Else
            param8.Value = PolicyInfo.PolicyType
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@PolicyOwnerCountryCode", SqlDbType.VarChar, 3)
        param9.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerCountryCode = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = PolicyInfo.PolicyOwnerCountryCode
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@PolicyOwnerIdentityCode", SqlDbType.VarChar, 2)
        param10.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerIdentityCode = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = PolicyInfo.PolicyOwnerIdentityCode
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@PolicyOwnerIdentityNo", SqlDbType.VarChar, 15)
        param11.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerIdentityNo = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = PolicyInfo.PolicyOwnerIdentityNo
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@PolicyOwnerName", SqlDbType.VarChar, 50)
        param12.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerName = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = PolicyInfo.PolicyOwnerName
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@PolicyOwnerSurname", SqlDbType.VarChar, 30)
        param13.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerSurname = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = PolicyInfo.PolicyOwnerSurname
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@PolicyOwnerBirthDate", SqlDbType.Date)
        param14.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyOwnerBirthDate Is Nothing Or PolicyInfo.PolicyOwnerBirthDate = "00:00:00" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = PolicyInfo.PolicyOwnerBirthDate
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@AddressLine1", SqlDbType.VarChar, 50)
        param15.Direction = ParameterDirection.Input
        If PolicyInfo.AddressLine1 = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = PolicyInfo.AddressLine1
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@AddressLine2", SqlDbType.VarChar, 50)
        param16.Direction = ParameterDirection.Input
        If PolicyInfo.AddressLine2 = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = PolicyInfo.AddressLine2
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@AddressLine3", SqlDbType.VarChar, 50)
        param17.Direction = ParameterDirection.Input
        If PolicyInfo.AddressLine3 = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = PolicyInfo.AddressLine3
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@PlateCountryCode", SqlDbType.VarChar, 3)
        param18.Direction = ParameterDirection.Input
        If PolicyInfo.PlateCountryCode = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = PolicyInfo.PlateCountryCode
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@PlateNumber", SqlDbType.VarChar, 15)
        param19.Direction = ParameterDirection.Input
        If PolicyInfo.PlateNumber = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = UCase(PolicyInfo.PlateNumber)
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@Brand", SqlDbType.VarChar, 30)
        param20.Direction = ParameterDirection.Input
        If PolicyInfo.Brand = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = PolicyInfo.Brand
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@Model", SqlDbType.VarChar, 30)
        param21.Direction = ParameterDirection.Input
        If PolicyInfo.Model = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = PolicyInfo.Model
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@ChassisNumber", SqlDbType.VarChar, 30)
        param22.Direction = ParameterDirection.Input
        If PolicyInfo.ChassisNumber = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = PolicyInfo.ChassisNumber
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@EngineNumber", SqlDbType.VarChar, 30)
        param23.Direction = ParameterDirection.Input
        If PolicyInfo.EngineNumber = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = PolicyInfo.EngineNumber
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@EnginePower", SqlDbType.Int)
        param24.Direction = ParameterDirection.Input
        If PolicyInfo.EnginePower = 0 Then
            param24.Value = 0
        Else
            param24.Value = PolicyInfo.EnginePower
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@ProductionYear", SqlDbType.Int)
        param25.Direction = ParameterDirection.Input
        If PolicyInfo.ProductionYear = 0 Then
            param25.Value = 0
        Else
            param25.Value = PolicyInfo.ProductionYear
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@Capacity", SqlDbType.Int)
        param26.Direction = ParameterDirection.Input
        If PolicyInfo.Capacity = 0 Then
            param26.Value = 0
        Else
            param26.Value = PolicyInfo.Capacity
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@CarType", SqlDbType.VarChar, 25)
        param27.Direction = ParameterDirection.Input
        If PolicyInfo.CarType = "" Then
            param27.Value = System.DBNull.Value
        Else
            param27.Value = PolicyInfo.CarType
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@UsingStyle", SqlDbType.VarChar, 15)
        param28.Direction = ParameterDirection.Input
        If PolicyInfo.UsingStyle = "" Then
            param28.Value = System.DBNull.Value
        Else
            param28.Value = PolicyInfo.UsingStyle
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@TariffCode", SqlDbType.VarChar, 5)
        param29.Direction = ParameterDirection.Input
        If PolicyInfo.TariffCode = "" Then
            param29.Value = System.DBNull.Value
        Else
            param29.Value = PolicyInfo.TariffCode
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@ArrangeDate", SqlDbType.Date)
        param30.Direction = ParameterDirection.Input
        If PolicyInfo.ArrangeDate Is Nothing Or PolicyInfo.ArrangeDate = "00:00:00" Then
            param30.Value = System.DBNull.Value
        Else
            param30.Value = PolicyInfo.ArrangeDate
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@StartDate", SqlDbType.DateTime)
        param31.Direction = ParameterDirection.Input
        If PolicyInfo.StartDate Is Nothing Or PolicyInfo.StartDate = "00:00:00" Then
            param31.Value = System.DBNull.Value
        Else
            param31.Value = PolicyInfo.StartDate
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@EndDate", SqlDbType.Date)
        param32.Direction = ParameterDirection.Input
        If PolicyInfo.EndDate Is Nothing Or PolicyInfo.EndDate = "00:00:00" Then
            param32.Value = System.DBNull.Value
        Else
            param32.Value = PolicyInfo.EndDate
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@Material", SqlDbType.Decimal)
        param33.Direction = ParameterDirection.Input
        If PolicyInfo.Material = 0 Then
            param33.Value = 0
        Else
            param33.Value = PolicyInfo.Material
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@Corporal", SqlDbType.Decimal)
        param34.Direction = ParameterDirection.Input
        If PolicyInfo.Corporal = 0 Then
            param34.Value = 0
        Else
            param34.Value = PolicyInfo.Corporal
        End If
        komut.Parameters.Add(param34)

        Dim param35 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
        param35.Direction = ParameterDirection.Input
        If PolicyInfo.CurrencyCode = "" Then
            param35.Value = System.DBNull.Value
        Else
            param35.Value = PolicyInfo.CurrencyCode
        End If
        komut.Parameters.Add(param35)

        Dim param36 As New SqlParameter("@PublicValue", SqlDbType.Decimal)
        param36.Direction = ParameterDirection.Input
        If PolicyInfo.PublicValue = 0 Then
            param36.Value = 0
        Else
            param36.Value = PolicyInfo.PublicValue
        End If
        komut.Parameters.Add(param36)

        Dim param37 As New SqlParameter("@AuthorizedDrivers", SqlDbType.VarChar, 1)
        param37.Direction = ParameterDirection.Input
        If PolicyInfo.AuthorizedDrivers = "" Then
            param37.Value = System.DBNull.Value
        Else
            param37.Value = PolicyInfo.AuthorizedDrivers
        End If
        komut.Parameters.Add(param37)

        Dim param38 As New SqlParameter("@CountryCode1", SqlDbType.VarChar, 3)
        param38.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode1 = "" Then
            param38.Value = System.DBNull.Value
        Else
            param38.Value = PolicyInfo.CountryCode1
        End If
        komut.Parameters.Add(param38)

        Dim param39 As New SqlParameter("@IdentityCode1", SqlDbType.VarChar, 2)
        param39.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode1 = "" Then
            param39.Value = System.DBNull.Value
        Else
            param39.Value = PolicyInfo.IdentityCode1
        End If
        komut.Parameters.Add(param39)

        Dim param40 As New SqlParameter("@IdentityNo1", SqlDbType.VarChar, 15)
        param40.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo1 = "" Then
            param40.Value = System.DBNull.Value
        Else
            param40.Value = PolicyInfo.IdentityNo1
        End If
        komut.Parameters.Add(param40)

        Dim param41 As New SqlParameter("@Name1", SqlDbType.VarChar, 50)
        param41.Direction = ParameterDirection.Input
        If PolicyInfo.Name1 = "" Then
            param41.Value = System.DBNull.Value
        Else
            param41.Value = PolicyInfo.Name1
        End If
        komut.Parameters.Add(param41)

        Dim param42 As New SqlParameter("@Surname1", SqlDbType.VarChar, 30)
        param42.Direction = ParameterDirection.Input
        If PolicyInfo.Surname1 = "" Then
            param42.Value = System.DBNull.Value
        Else
            param42.Value = PolicyInfo.Surname1
        End If
        komut.Parameters.Add(param42)

        Dim param43 As New SqlParameter("@BirthDate1", SqlDbType.Date)
        param43.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.BirthDate1 = "00:00:00" Then
            param43.Value = System.DBNull.Value
        Else
            param43.Value = PolicyInfo.BirthDate1
        End If
        komut.Parameters.Add(param43)

        Dim param44 As New SqlParameter("@DriverLicenceNo1", SqlDbType.VarChar, 15)
        param44.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo1 = "" Then
            param44.Value = System.DBNull.Value
        Else
            param44.Value = PolicyInfo.DriverLicenceNo1
        End If
        komut.Parameters.Add(param44)

        Dim param45 As New SqlParameter("@DriverLicenceGivenDate1", SqlDbType.Date)
        param45.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate1 Is Nothing Or PolicyInfo.DriverLicenceGivenDate1 = "00:00:00" Then
            param45.Value = System.DBNull.Value
        Else
            param45.Value = PolicyInfo.DriverLicenceGivenDate1
        End If
        komut.Parameters.Add(param45)

        Dim param46 As New SqlParameter("@DriverLicenceType1", SqlDbType.VarChar, 1)
        param46.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType1 = "" Then
            param46.Value = System.DBNull.Value
        Else
            param46.Value = PolicyInfo.DriverLicenceType1
        End If
        komut.Parameters.Add(param46)

        Dim param47 As New SqlParameter("@CountryCode2", SqlDbType.VarChar, 3)
        param47.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode2 = "" Then
            param47.Value = System.DBNull.Value
        Else
            param47.Value = PolicyInfo.CountryCode2
        End If
        komut.Parameters.Add(param47)

        Dim param48 As New SqlParameter("@IdentityCode2", SqlDbType.VarChar, 2)
        param48.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode2 = "" Then
            param48.Value = System.DBNull.Value
        Else
            param48.Value = PolicyInfo.IdentityCode2
        End If
        komut.Parameters.Add(param48)

        Dim param49 As New SqlParameter("@IdentityNo2", SqlDbType.VarChar, 15)
        param49.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo2 = "" Then
            param49.Value = System.DBNull.Value
        Else
            param49.Value = PolicyInfo.IdentityNo2
        End If
        komut.Parameters.Add(param49)

        Dim param50 As New SqlParameter("@Name2", SqlDbType.VarChar, 50)
        param50.Direction = ParameterDirection.Input
        If PolicyInfo.Name2 = "" Then
            param50.Value = System.DBNull.Value
        Else
            param50.Value = PolicyInfo.Name2
        End If
        komut.Parameters.Add(param50)

        Dim param51 As New SqlParameter("@Surname2", SqlDbType.VarChar, 30)
        param51.Direction = ParameterDirection.Input
        If PolicyInfo.Surname2 = "" Then
            param51.Value = System.DBNull.Value
        Else
            param51.Value = PolicyInfo.Surname2
        End If
        komut.Parameters.Add(param51)

        Dim param52 As New SqlParameter("@BirthDate2", SqlDbType.Date)
        param52.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.BirthDate2 = "00:00:00" Then
            param52.Value = System.DBNull.Value
        Else
            param52.Value = PolicyInfo.BirthDate2
        End If
        komut.Parameters.Add(param52)

        Dim param53 As New SqlParameter("@DriverLicenceNo2", SqlDbType.VarChar, 15)
        param53.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo2 = "" Then
            param53.Value = System.DBNull.Value
        Else
            param53.Value = PolicyInfo.DriverLicenceNo2
        End If
        komut.Parameters.Add(param53)

        Dim param54 As New SqlParameter("@DriverLicenceGivenDate2", SqlDbType.Date)
        param54.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate2 Is Nothing Or PolicyInfo.DriverLicenceGivenDate2 = "00:00:00" Then
            param54.Value = System.DBNull.Value
        Else
            param54.Value = PolicyInfo.DriverLicenceGivenDate2
        End If
        komut.Parameters.Add(param54)

        Dim param55 As New SqlParameter("@DriverLicenceType2", SqlDbType.VarChar, 1)
        param55.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType2 = "" Then
            param55.Value = System.DBNull.Value
        Else
            param55.Value = PolicyInfo.DriverLicenceType2
        End If
        komut.Parameters.Add(param55)

        Dim param56 As New SqlParameter("@CountryCode3", SqlDbType.VarChar, 3)
        param56.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode3 = "" Then
            param56.Value = System.DBNull.Value
        Else
            param56.Value = PolicyInfo.CountryCode3
        End If
        komut.Parameters.Add(param56)

        Dim param57 As New SqlParameter("@IdentityCode3", SqlDbType.VarChar, 2)
        param57.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode3 = "" Then
            param57.Value = System.DBNull.Value
        Else
            param57.Value = PolicyInfo.IdentityCode3
        End If
        komut.Parameters.Add(param57)

        Dim param58 As New SqlParameter("@IdentityNo3", SqlDbType.VarChar, 15)
        param58.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo3 = "" Then
            param58.Value = System.DBNull.Value
        Else
            param58.Value = PolicyInfo.IdentityNo3
        End If
        komut.Parameters.Add(param58)

        Dim param59 As New SqlParameter("@Name3", SqlDbType.VarChar, 50)
        param59.Direction = ParameterDirection.Input
        If PolicyInfo.Name3 = "" Then
            param59.Value = System.DBNull.Value
        Else
            param59.Value = PolicyInfo.Name3
        End If
        komut.Parameters.Add(param59)

        Dim param60 As New SqlParameter("@Surname3", SqlDbType.VarChar, 30)
        param60.Direction = ParameterDirection.Input
        If PolicyInfo.Surname3 = "" Then
            param60.Value = System.DBNull.Value
        Else
            param60.Value = PolicyInfo.Surname3
        End If
        komut.Parameters.Add(param60)

        Dim param61 As New SqlParameter("@BirthDate3", SqlDbType.Date)
        param61.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.BirthDate3 = "00:00:00" Then
            param61.Value = System.DBNull.Value
        Else
            param61.Value = PolicyInfo.BirthDate3
        End If
        komut.Parameters.Add(param61)

        Dim param62 As New SqlParameter("@DriverLicenceNo3", SqlDbType.VarChar, 15)
        param62.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo3 = "" Then
            param62.Value = System.DBNull.Value
        Else
            param62.Value = PolicyInfo.DriverLicenceNo3
        End If
        komut.Parameters.Add(param62)

        Dim param63 As New SqlParameter("@DriverLicenceGivenDate3", SqlDbType.Date)
        param63.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate3 Is Nothing Or PolicyInfo.DriverLicenceGivenDate3 = "00:00:00" Then
            param63.Value = System.DBNull.Value
        Else
            param63.Value = PolicyInfo.DriverLicenceGivenDate3
        End If
        komut.Parameters.Add(param63)

        Dim param64 As New SqlParameter("@DriverLicenceType3", SqlDbType.VarChar, 1)
        param64.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType3 = "" Then
            param64.Value = System.DBNull.Value
        Else
            param64.Value = PolicyInfo.DriverLicenceType3
        End If
        komut.Parameters.Add(param64)

        Dim param65 As New SqlParameter("@CountryCode4", SqlDbType.VarChar, 3)
        param65.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode4 = "" Then
            param65.Value = System.DBNull.Value
        Else
            param65.Value = PolicyInfo.CountryCode4
        End If
        komut.Parameters.Add(param65)

        Dim param66 As New SqlParameter("@IdentityCode4", SqlDbType.VarChar, 2)
        param66.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode4 = "" Then
            param66.Value = System.DBNull.Value
        Else
            param66.Value = PolicyInfo.IdentityCode4
        End If
        komut.Parameters.Add(param66)

        Dim param67 As New SqlParameter("@IdentityNo4", SqlDbType.VarChar, 15)
        param67.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo4 = "" Then
            param67.Value = System.DBNull.Value
        Else
            param67.Value = PolicyInfo.IdentityNo4
        End If
        komut.Parameters.Add(param67)

        Dim param68 As New SqlParameter("@Name4", SqlDbType.VarChar, 50)
        param68.Direction = ParameterDirection.Input
        If PolicyInfo.Name4 = "" Then
            param68.Value = System.DBNull.Value
        Else
            param68.Value = PolicyInfo.Name4
        End If
        komut.Parameters.Add(param68)

        Dim param69 As New SqlParameter("@Surname4", SqlDbType.VarChar, 30)
        param69.Direction = ParameterDirection.Input
        If PolicyInfo.Surname4 = "" Then
            param69.Value = System.DBNull.Value
        Else
            param69.Value = PolicyInfo.Surname4
        End If
        komut.Parameters.Add(param69)

        Dim param70 As New SqlParameter("@BirthDate4", SqlDbType.Date)
        param70.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.BirthDate4 = "00:00:00" Then
            param70.Value = System.DBNull.Value
        Else
            param70.Value = PolicyInfo.BirthDate4
        End If
        komut.Parameters.Add(param70)

        Dim param71 As New SqlParameter("@DriverLicenceNo4", SqlDbType.VarChar, 15)
        param71.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo4 = "" Then
            param71.Value = System.DBNull.Value
        Else
            param71.Value = PolicyInfo.DriverLicenceNo4
        End If
        komut.Parameters.Add(param71)

        Dim param72 As New SqlParameter("@DriverLicenceGivenDate4", SqlDbType.Date)
        param72.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate4 Is Nothing Or PolicyInfo.DriverLicenceGivenDate4 = "00:00:00" Then
            param72.Value = System.DBNull.Value
        Else
            param72.Value = PolicyInfo.DriverLicenceGivenDate4
        End If
        komut.Parameters.Add(param72)

        Dim param73 As New SqlParameter("@DriverLicenceType4", SqlDbType.VarChar, 1)
        param73.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType4 = "" Then
            param73.Value = System.DBNull.Value
        Else
            param73.Value = PolicyInfo.DriverLicenceType4
        End If
        komut.Parameters.Add(param73)

        Dim param74 As New SqlParameter("@CountryCode5", SqlDbType.VarChar, 3)
        param74.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode5 = "" Then
            param74.Value = System.DBNull.Value
        Else
            param74.Value = PolicyInfo.CountryCode5
        End If
        komut.Parameters.Add(param74)

        Dim param75 As New SqlParameter("@IdentityCode5", SqlDbType.VarChar, 2)
        param75.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode5 = "" Then
            param75.Value = System.DBNull.Value
        Else
            param75.Value = PolicyInfo.IdentityCode5
        End If
        komut.Parameters.Add(param75)

        Dim param76 As New SqlParameter("@IdentityNo5", SqlDbType.VarChar, 15)
        param76.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo5 = "" Then
            param76.Value = System.DBNull.Value
        Else
            param76.Value = PolicyInfo.IdentityNo5
        End If
        komut.Parameters.Add(param76)

        Dim param77 As New SqlParameter("@Name5", SqlDbType.VarChar, 50)
        param77.Direction = ParameterDirection.Input
        If PolicyInfo.Name5 = "" Then
            param77.Value = System.DBNull.Value
        Else
            param77.Value = PolicyInfo.Name5
        End If
        komut.Parameters.Add(param77)

        Dim param78 As New SqlParameter("@Surname5", SqlDbType.VarChar, 30)
        param78.Direction = ParameterDirection.Input
        If PolicyInfo.Surname5 = "" Then
            param78.Value = System.DBNull.Value
        Else
            param78.Value = PolicyInfo.Surname5
        End If
        komut.Parameters.Add(param78)

        Dim param79 As New SqlParameter("@BirthDate5", SqlDbType.Date)
        param79.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.BirthDate5 = "00:00:00" Then
            param79.Value = System.DBNull.Value
        Else
            param79.Value = PolicyInfo.BirthDate5
        End If
        komut.Parameters.Add(param79)

        Dim param80 As New SqlParameter("@DriverLicenceNo5", SqlDbType.VarChar, 15)
        param80.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo5 = "" Then
            param80.Value = System.DBNull.Value
        Else
            param80.Value = PolicyInfo.DriverLicenceNo5
        End If
        komut.Parameters.Add(param80)

        Dim param81 As New SqlParameter("@DriverLicenceGivenDate5", SqlDbType.Date)
        param81.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate5 Is Nothing Or PolicyInfo.DriverLicenceGivenDate5 = "00:00:00" Then
            param81.Value = System.DBNull.Value
        Else
            param81.Value = PolicyInfo.DriverLicenceGivenDate5
        End If
        komut.Parameters.Add(param81)

        Dim param82 As New SqlParameter("@DriverLicenceType5", SqlDbType.VarChar, 1)
        param82.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType5 = "" Then
            param82.Value = System.DBNull.Value
        Else
            param82.Value = PolicyInfo.DriverLicenceType5
        End If
        komut.Parameters.Add(param82)

        Dim param83 As New SqlParameter("@CountryCode6", SqlDbType.VarChar, 3)
        param83.Direction = ParameterDirection.Input
        If PolicyInfo.CountryCode6 = "" Then
            param83.Value = System.DBNull.Value
        Else
            param83.Value = PolicyInfo.CountryCode6
        End If
        komut.Parameters.Add(param83)

        Dim param84 As New SqlParameter("@IdentityCode6", SqlDbType.VarChar, 2)
        param84.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityCode6 = "" Then
            param84.Value = System.DBNull.Value
        Else
            param84.Value = PolicyInfo.IdentityCode6
        End If
        komut.Parameters.Add(param84)

        Dim param85 As New SqlParameter("@IdentityNo6", SqlDbType.VarChar, 15)
        param85.Direction = ParameterDirection.Input
        If PolicyInfo.IdentityNo6 = "" Then
            param85.Value = System.DBNull.Value
        Else
            param85.Value = PolicyInfo.IdentityNo6
        End If
        komut.Parameters.Add(param85)

        Dim param86 As New SqlParameter("@Name6", SqlDbType.VarChar, 50)
        param86.Direction = ParameterDirection.Input
        If PolicyInfo.Name6 = "" Then
            param86.Value = System.DBNull.Value
        Else
            param86.Value = PolicyInfo.Name6
        End If
        komut.Parameters.Add(param86)

        Dim param87 As New SqlParameter("@Surname6", SqlDbType.VarChar, 30)
        param87.Direction = ParameterDirection.Input
        If PolicyInfo.Surname6 = "" Then
            param87.Value = System.DBNull.Value
        Else
            param87.Value = PolicyInfo.Surname6
        End If
        komut.Parameters.Add(param87)

        Dim param88 As New SqlParameter("@BirthDate6", SqlDbType.Date)
        param88.Direction = ParameterDirection.Input
        If PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.BirthDate6 = "00:00:00" Then
            param88.Value = System.DBNull.Value
        Else
            param88.Value = PolicyInfo.BirthDate6
        End If
        komut.Parameters.Add(param88)

        Dim param89 As New SqlParameter("@DriverLicenceNo6", SqlDbType.VarChar, 15)
        param89.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceNo6 = "" Then
            param89.Value = System.DBNull.Value
        Else
            param89.Value = PolicyInfo.DriverLicenceNo6
        End If
        komut.Parameters.Add(param89)

        Dim param90 As New SqlParameter("@DriverLicenceGivenDate6", SqlDbType.Date)
        param90.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceGivenDate6 Is Nothing Or PolicyInfo.DriverLicenceGivenDate6 = "00:00:00" Then
            param90.Value = System.DBNull.Value
        Else
            param90.Value = PolicyInfo.DriverLicenceGivenDate6
        End If
        komut.Parameters.Add(param90)

        Dim param91 As New SqlParameter("@DriverLicenceType6", SqlDbType.VarChar, 1)
        param91.Direction = ParameterDirection.Input
        If PolicyInfo.DriverLicenceType6 = "" Then
            param91.Value = System.DBNull.Value
        Else
            param91.Value = PolicyInfo.DriverLicenceType6
        End If
        komut.Parameters.Add(param91)

        Dim param92 As New SqlParameter("@InsurancePremium", SqlDbType.Decimal)
        param92.Direction = ParameterDirection.Input
        If PolicyInfo.InsurancePremium = 0 Then
            param92.Value = 0
        Else
            param92.Value = PolicyInfo.InsurancePremium
        End If
        komut.Parameters.Add(param92)

        Dim param93 As New SqlParameter("@AssistantFees", SqlDbType.Decimal)
        param93.Direction = ParameterDirection.Input
        If PolicyInfo.AssistantFees = 0 Then
            param93.Value = 0
        Else
            param93.Value = PolicyInfo.AssistantFees
        End If
        komut.Parameters.Add(param93)

        Dim param94 As New SqlParameter("@OtherFees", SqlDbType.Decimal)
        param94.Direction = ParameterDirection.Input
        If PolicyInfo.OtherFees = 0 Then
            param94.Value = 0
        Else
            param94.Value = PolicyInfo.OtherFees
        End If
        komut.Parameters.Add(param94)

        Dim param95 As New SqlParameter("@BasePriceValue", SqlDbType.Decimal)
        param95.Direction = ParameterDirection.Input
        If PolicyInfo.BasePriceValue = 0 Then
            param95.Value = 0
        Else
            param95.Value = PolicyInfo.BasePriceValue
        End If
        komut.Parameters.Add(param95)

        Dim param96 As New SqlParameter("@CCRateValue", SqlDbType.Decimal)
        param96.Direction = ParameterDirection.Input
        If PolicyInfo.CCRateValue = 0 Then
            param96.Value = 0
        Else
            param96.Value = PolicyInfo.CCRateValue
        End If
        komut.Parameters.Add(param96)

        Dim param97 As New SqlParameter("@DamageRateValue", SqlDbType.Decimal)
        param97.Direction = ParameterDirection.Input
        If PolicyInfo.DamageRateValue = 0 Then
            param97.Value = 0
        Else
            param97.Value = PolicyInfo.DamageRateValue
        End If
        komut.Parameters.Add(param97)

        Dim param98 As New SqlParameter("@AgeRateValue", SqlDbType.Decimal)
        param98.Direction = ParameterDirection.Input
        If PolicyInfo.AgeRateValue = 0 Then
            param98.Value = 0
        Else
            param98.Value = PolicyInfo.AgeRateValue
        End If
        komut.Parameters.Add(param98)

        Dim param99 As New SqlParameter("@DamagelessRateValue", SqlDbType.Decimal)
        param99.Direction = ParameterDirection.Input
        If PolicyInfo.DamagelessRateValue = 0 Then
            param99.Value = 0
        Else
            param99.Value = PolicyInfo.DamagelessRateValue
        End If
        komut.Parameters.Add(param99)

        Dim param100 As New SqlParameter("@Color", SqlDbType.VarChar)
        param100.Direction = ParameterDirection.Input
        If PolicyInfo.Color = "" Then
            param100.Value = System.DBNull.Value
        Else
            param100.Value = PolicyInfo.Color
        End If
        komut.Parameters.Add(param100)

        Dim param101 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param101.Direction = ParameterDirection.Input
        If PolicyInfo.ProductType = "" Then
            param101.Value = System.DBNull.Value
        Else
            param101.Value = PolicyInfo.ProductType
        End If
        komut.Parameters.Add(param101)

        Dim param102 As New SqlParameter("@FuelType", SqlDbType.Int)
        param102.Direction = ParameterDirection.Input
        If PolicyInfo.FuelType = 0 Then
            param102.Value = 0
        Else
            param102.Value = PolicyInfo.FuelType
        End If
        komut.Parameters.Add(param102)

        Dim param103 As New SqlParameter("@SteeringSide", SqlDbType.VarChar)
        param103.Direction = ParameterDirection.Input
        If PolicyInfo.SteeringSide = "" Then
            param103.Value = System.DBNull.Value
        Else
            param103.Value = PolicyInfo.SteeringSide
        End If
        komut.Parameters.Add(param103)

        Dim param104 As New SqlParameter("@AnyDriverRateValue", SqlDbType.Decimal)
        param104.Direction = ParameterDirection.Input
        If PolicyInfo.AnyDriverRateValue = 0 Then
            param104.Value = 0
        Else
            param104.Value = PolicyInfo.AnyDriverRateValue
        End If
        komut.Parameters.Add(param104)

        Dim param105 As New SqlParameter("@PolicyPremium", SqlDbType.Decimal)
        param105.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyPremium = 0 Then
            param105.Value = 0
        Else
            param105.Value = PolicyInfo.PolicyPremium
        End If
        komut.Parameters.Add(param105)

        Dim param106 As New SqlParameter("@PolicyPremiumTL", SqlDbType.Decimal)
        param106.Direction = ParameterDirection.Input
        If PolicyInfo.PolicyPremiumTL = 0 Then
            param106.Value = 0
        Else
            param106.Value = PolicyInfo.PolicyPremiumTL
        End If
        komut.Parameters.Add(param106)

        Dim param107 As New SqlParameter("@InsurancePremiumTL", SqlDbType.Decimal)
        param107.Direction = ParameterDirection.Input
        If PolicyInfo.InsurancePremiumTL = 0 Then
            param107.Value = 0
        Else
            param107.Value = PolicyInfo.InsurancePremiumTL
        End If
        komut.Parameters.Add(param107)

        Dim param108 As New SqlParameter("@PublicValueTL", SqlDbType.Decimal)
        param108.Direction = ParameterDirection.Input
        If PolicyInfo.PublicValueTL = 0 Then
            param108.Value = 0
        Else
            param108.Value = PolicyInfo.PublicValueTL
        End If
        komut.Parameters.Add(param108)

        Dim param109 As New SqlParameter("@DamageRate", SqlDbType.Int)
        param109.Direction = ParameterDirection.Input
        If PolicyInfo.DamageRate = 0 Then
            param109.Value = 0
        Else
            param109.Value = PolicyInfo.DamageRate
        End If
        komut.Parameters.Add(param109)

        Dim param110 As New SqlParameter("@DamagelessRate", SqlDbType.Int)
        param110.Direction = ParameterDirection.Input
        If PolicyInfo.DamagelessRate = 0 Then
            param110.Value = 0
        Else
            param110.Value = PolicyInfo.DamagelessRate
        End If
        komut.Parameters.Add(param110)

        Dim param111 As New SqlParameter("@AnyDriverRate", SqlDbType.Int)
        param111.Direction = ParameterDirection.Input
        If PolicyInfo.AnyDriverRate = 0 Then
            param111.Value = 0
        Else
            param111.Value = PolicyInfo.AnyDriverRate
        End If
        komut.Parameters.Add(param111)

        Dim param112 As New SqlParameter("@AgeRate", SqlDbType.Int)
        param112.Direction = ParameterDirection.Input
        If PolicyInfo.AgeRate = 0 Then
            param112.Value = 0
        Else
            param112.Value = PolicyInfo.AgeRate
        End If
        komut.Parameters.Add(param112)

        Dim param113 As New SqlParameter("@CCRate", SqlDbType.Int)
        param113.Direction = ParameterDirection.Input
        If PolicyInfo.CCRate = 0 Then
            param113.Value = 0
        Else
            param113.Value = PolicyInfo.CCRate
        End If
        komut.Parameters.Add(param113)

        Dim param114 As New SqlParameter("@SBMCode", SqlDbType.VarChar)
        param114.Direction = ParameterDirection.Input
        If PolicyInfo.SBMCode = "" Then
            param114.Value = System.DBNull.Value
        Else
            param114.Value = PolicyInfo.SBMCode
        End If
        komut.Parameters.Add(param114)


        Dim param115 As New SqlParameter("@Creditor", SqlDbType.Int)
        param115.Direction = ParameterDirection.Input
        If PolicyInfo.Creditor = 0 Then
            param115.Value = 0
        Else
            param115.Value = PolicyInfo.Creditor
        End If
        komut.Parameters.Add(param115)

        Dim param116 As New SqlParameter("@FirstBeneficiary", SqlDbType.VarChar)
        param116.Direction = ParameterDirection.Input
        If PolicyInfo.FirstBeneficiary = "" Then
            param116.Value = System.DBNull.Value
        Else
            param116.Value = PolicyInfo.FirstBeneficiary
        End If
        komut.Parameters.Add(param116)


        Dim param117 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
        param117.Direction = ParameterDirection.Input
        If PolicyInfo.ExchangeRate = 0 Then
            param117.Value = 0
        Else
            param117.Value = PolicyInfo.ExchangeRate
        End If
        komut.Parameters.Add(param117)

        Dim param118 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar)
        param118.Direction = ParameterDirection.Input
        If PolicyInfo.AgencyRegisterCode = "" Then
            param118.Value = System.DBNull.Value
        Else
            param118.Value = PolicyInfo.AgencyRegisterCode
        End If
        komut.Parameters.Add(param118)

        Dim param119 As New SqlParameter("@TPNo", SqlDbType.VarChar)
        param119.Direction = ParameterDirection.Input
        If PolicyInfo.TPNo = "" Then
            param119.Value = System.DBNull.Value
        Else
            param119.Value = PolicyInfo.TPNo
        End If
        komut.Parameters.Add(param119)

        Dim param120 As New SqlParameter("@BorderCode", SqlDbType.VarChar, 5)
        param120.Direction = ParameterDirection.Input
        If PolicyInfo.BorderCode = "" Then
            param120.Value = System.DBNull.Value
        Else
            param120.Value = PolicyInfo.BorderCode
        End If
        komut.Parameters.Add(param120)


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


    


    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and ZeylCode=@ZeylCode " + _
        " and ZeylNo=@ZeylNo " + _
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

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ZeylCode
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = ZeylNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)

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



    'TOPLAM POLİÇE SAYISI---------------------------------------
    Public Function toplampolicesayisi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from PolicyInfo"
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


    'TOPLAM POLİÇE SAYISI---------------------------------------
    Public Function toplampolicesayisi_sirketicin(ByVal sirketpkey As String) As Integer

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        sirket = sirket_erisim.bultek(sirketpkey)


        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from PolicyInfo where FirmCode=@FirmCode"

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

        If neyegore = "firmapolicedagilim" Then
            sqlstr = "select COUNT(*) as sayi,firmcode" + _
            " from PolicyInfo group by firmcode order by firmcode"

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


        If neyegore = "zeylpolicedagilim" Then

            Dim aciklama As String
            Dim zeylkodpkey As String
            Dim zeylcode As New CLASSZEYLCODE
            Dim zeylcode_erisim As New CLASSZEYLCODE_ERISIM

            sqlstr = "select COUNT(*) as sayi,ZeylCode.pkey" + _
            " from PolicyInfo,ZeylCode where ZeylCode.kod=PolicyInfo.ZeylCode" + _
            " group by ZeylCode.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("pkey") Is System.DBNull.Value Then
                            zeylkodpkey = veri.Item("pkey")
                            zeylcode = zeylcode_erisim.bultek(zeylkodpkey)
                            donecekgrafikbilgi.seriad = zeylcode.aciklama
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If


        If neyegore = "urunpolicedagilim" Then

            Dim aciklama As String
            Dim urunkodpkey As String
            Dim urunkod As New CLASSURUNKOD
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM


            sqlstr = "select COUNT(*) as sayi,Urunkod.pkey" + _
            " from PolicyInfo,urunkod where urunkod.kod=PolicyInfo.ProductCode" + _
            " group by urunkod.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        urunkodpkey = veri.Item("pkey")
                        donecekgrafikbilgi.seriad = urunkod_erisim.bultek(urunkodpkey).aciklama
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using
        End If



        If neyegore = "zeylpolicedagilim_teksirket" Then

            Dim aciklama As String
            Dim zeylkodpkey As String
            Dim zeylcode As New CLASSZEYLCODE
            Dim zeylcode_erisim As New CLASSZEYLCODE_ERISIM

            Dim sirket As New CLASSSIRKET
            sirket = sirket_erisim.bultek(Current.Session("kullanici_aktifsirket"))


            sqlstr = "select COUNT(*) as sayi,ZeylCode.pkey" + _
            " from PolicyInfo,ZeylCode where PolicyInfo.FirmCode=@FirmCode and " + _
            " ZeylCode.kod=PolicyInfo.ZeylCode" + _
            " group by ZeylCode.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = sirket.sirketkod
            komut.Parameters.Add(param1)

            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("pkey") Is System.DBNull.Value Then
                            zeylkodpkey = veri.Item("pkey")
                            zeylcode = zeylcode_erisim.bultek(zeylkodpkey)
                            donecekgrafikbilgi.seriad = zeylcode.aciklama
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If


        If neyegore = "urunpolicedagilim_teksirket" Then

            Dim aciklama As String
            Dim urunkodpkey As String
            Dim urunkod As New CLASSURUNKOD
            Dim urunkod_erisim As New CLASSURUNKOD_ERISIM

            Dim sirket As New CLASSSIRKET
            sirket = sirket_erisim.bultek(Current.Session("kullanici_aktifsirket"))

            sqlstr = "select COUNT(*) as sayi,Urunkod.pkey" + _
            " from PolicyInfo,urunkod where PolicyInfo.FirmCode=@FirmCode and " + _
            "urunkod.kod=PolicyInfo.ProductCode" + _
            " group by urunkod.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = sirket.sirketkod
            komut.Parameters.Add(param1)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        urunkodpkey = veri.Item("pkey")
                        donecekgrafikbilgi.seriad = urunkod_erisim.bultek(urunkodpkey).aciklama
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using
        End If


        If neyegore = "policetarihdagilim" Then

            Dim tarih As String

            sqlstr = "select COUNT(*) as sayi,CAST(tarih as DATE) as tarih" + _
            " from logservis where " + _
            "servisad=@servisad and " + _
            "resultcode=@resultcode and " + _
            "tarih>=@tarih" + _
            " group by CAST(tarih AS DATE) order by tarih"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@servisad", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "LoadPolicyInformation"
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@resultcode", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            param2.Value = 1
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tarih", SqlDbType.DateTime)
            param3.Direction = ParameterDirection.Input
            param3.Value = DateTime.Now.AddDays(-6)
            komut.Parameters.Add(param3)


            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("tarih") Is System.DBNull.Value Then
                            tarih = veri.Item("tarih")
                            donecekgrafikbilgi.seriad = tarih
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If



        If neyegore = "hasartarihdagilim" Then

            Dim tarih As String

            sqlstr = "select COUNT(*) as sayi,CAST(tarih as DATE) as tarih" + _
            " from logservis where " + _
            "servisad=@servisad and " + _
            "resultcode=@resultcode and " + _
            "tarih>=@tarih" + _
            " group by CAST(tarih AS DATE) order by tarih"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@servisad", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "LoadDamageInformation"
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@resultcode", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            param2.Value = 1
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tarih", SqlDbType.DateTime)
            param3.Direction = ParameterDirection.Input
            param3.Value = DateTime.Now.AddDays(-6)
            komut.Parameters.Add(param3)


            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("tarih") Is System.DBNull.Value Then
                            tarih = veri.Item("tarih")
                            donecekgrafikbilgi.seriad = tarih
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If




        If neyegore = "firmapolicedagilim_sirketkodlu" Then

            Dim sirket As New CLASSSIRKET

            sqlstr = "select COUNT(*) as sayi,firmcode" + _
            " from PolicyInfo group by firmcode order by firmcode"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("firmcode") Is System.DBNull.Value Then
                        firmcode = veri.Item("firmcode")
                        sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
                        donecekgrafikbilgi.seriad = Mid(sirket.sirketad, 1, 9)
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


        Dim PolicyInfo2_Erisim As New PolicyInfo2_Erisim

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14 As String

        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String
        Dim sqlteklestirdevam As String
        Dim koldugme As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Bilgiler</th>" + _
        "<th>Tarife</th>" + _
        "<th>Ürün</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Başlangıç</th>" + _
        "<th>Bitiş</th>" + _
        "<th>Tecdit</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Plaka</th>" + _
        "<th>Kasko Bedeli</th>" + _
        "<th>Para Birimi</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Başlangıç", GetType(String))
        table.Columns.Add("Bitiş", GetType(String))
        table.Columns.Add("Tecdit", GetType(String))
        table.Columns.Add("Kapsam", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        table.Columns.Add("Kimlik", GetType(String))
        table.Columns.Add("Plaka", GetType(String))
        table.Columns.Add("Kasko Bedeli", GetType(String))
        table.Columns.Add("Para Birimi", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(14)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Başlangıç", fbaslik))
        pdftable.AddCell(New Phrase("Bitiş", fbaslik))
        pdftable.AddCell(New Phrase("Tecdit", fbaslik))
        pdftable.AddCell(New Phrase("Kapsam", fbaslik))
        pdftable.AddCell(New Phrase("Ad Soyad", fbaslik))
        pdftable.AddCell(New Phrase("Kimlik", fbaslik))
        pdftable.AddCell(New Phrase("Plaka", fbaslik))
        pdftable.AddCell(New Phrase("Kasko Bedeli", fbaslik))
        pdftable.AddCell(New Phrase("Para Birimi", fbaslik))

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

        'para birimi
        If HttpContext.Current.Session("parabirimi") <> "0" Then
            sqldevam = sqldevam + " and CurrencyCode=@CurrencyCode"
        End If

        'policeno
        If HttpContext.Current.Session("policeno") <> "" Then
            sqldevam = sqldevam + " and PolicyNumber=@PolicyNumber"
        End If

        'kimlikno
        If HttpContext.Current.Session("kimlikno") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerIdentityNo=@PolicyOwnerIdentityNo"
        End If


        Dim kiralikmi As String = "Hayır"
        Dim kiralikplaka_ek As String
        Dim sql_kiralikaracdevam As String

        'plakano
        If HttpContext.Current.Session("plakano") <> "" Then

            Dim plakano As String = HttpContext.Current.Session("plakano")
            'eğer başı z ile başlıyor ise
            If Mid(plakano, 1, 1) = "Z" Then
                kiralikmi = "Evet"
                kiralikplaka_ek = Mid(plakano, 2, Len(plakano)) + "Z"
                sql_kiralikaracdevam = " or DriverPlateNumber=@DriverPlateNumber2"
            End If
            'eğer sonu z ile bitiyor ise
            If Mid(plakano, Len(plakano), 1) = "Z" Then
                kiralikmi = "Evet"
                kiralikplaka_ek = "Z" + Mid(plakano, 1, Len(plakano) - 1)
                sql_kiralikaracdevam = " or DriverPlateNumber=@DriverPlateNumber2"
            End If

            If kiralikmi = "Hayır" Then
                sqldevam = sqldevam + " and PlateNumber=@PlateNumber"
            End If
            If kiralikmi = "Evet" Then
                sqldevam = sqldevam + " and (PlateNumber=@PlateNumber or PlateNumber=@PlateNumber2)"
            End If

        End If

        'ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerName LIKE '%'+@ad+'%'"
        End If

        'soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerName LIKE '%'+@soyad+'%'"
        End If

        'tarife
        If HttpContext.Current.Session("tarife") <> "0" Then
            sqldevam = sqldevam + " and TariffCode=@TariffCode"
        End If

        'gun
        If HttpContext.Current.Session("gun") <> "" Then
            sqldevam = sqldevam + " and DATEDIFF(day,StartDate,EndDate)=" + HttpContext.Current.Session("gun")
        End If

        'zeylcode
        If HttpContext.Current.Session("zeylcode") = "P veya T" Then
            sqldevam = sqldevam + " and (ZeylCode='P' or ZeylCode='T')"
        End If

        If HttpContext.Current.Session("zeylcode") <> "0" And _
        HttpContext.Current.Session("zeylcode") <> "P veya T" Then
            sqldevam = sqldevam + " and ZeylCode=@ZeylCode"
        End If

        sqlstr = "select * from PolicyInfo where " + _
        "(Convert(DATE,StartDate)>=@baslangic and Convert(DATE,StartDate)<=@bitis)" + _
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

        'para birimi seçilmişse
        If HttpContext.Current.Session("parabirimi") <> "0" Then
            komut.Parameters.Add("@CurrencyCode", SqlDbType.VarChar)
            komut.Parameters("@CurrencyCode").Value = HttpContext.Current.Session("parabirimi")
        End If

        'police no seçilmişse
        If HttpContext.Current.Session("policeno") <> "" Then
            komut.Parameters.Add("@PolicyNumber", SqlDbType.VarChar)
            komut.Parameters("@PolicyNumber").Value = HttpContext.Current.Session("policeno")
        End If

        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlikno") <> "" Then
            komut.Parameters.Add("@PolicyOwnerIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@PolicyOwnerIdentityNo").Value = HttpContext.Current.Session("kimlikno")
        End If

        'plaka no seçilmişse
        If HttpContext.Current.Session("plakano") <> "" Then
            komut.Parameters.Add("@PlateNumber", SqlDbType.VarChar)
            komut.Parameters("@PlateNumber").Value = HttpContext.Current.Session("plakano")

            If kiralikmi = "Evet" Then
                komut.Parameters.Add("@PlateNumber2", SqlDbType.VarChar)
                komut.Parameters("@PlateNumber2").Value = kiralikplaka_ek
            End If
        End If

        'ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@ad", SqlDbType.VarChar)
            komut.Parameters("@ad").Value = HttpContext.Current.Session("ad")
        End If

        'soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@soyad", SqlDbType.VarChar)
            komut.Parameters("@soyad").Value = HttpContext.Current.Session("soyad")
        End If

        'tarife seçilmiş ise
        If HttpContext.Current.Session("tarife") <> "0" Then
            komut.Parameters.Add("@TariffCode", SqlDbType.VarChar)
            komut.Parameters("@TariffCode").Value = HttpContext.Current.Session("tarife")
        End If

        'zeylcode seçilmiş ise
        If HttpContext.Current.Session("zeylcode") <> "0" And _
        HttpContext.Current.Session("zeylcode") <> "P veya T" Then
            komut.Parameters.Add("@ZeylCode", SqlDbType.VarChar)
            komut.Parameters("@ZeylCode").Value = HttpContext.Current.Session("zeylcode")
        End If

        girdi = "0"

        'primary key tanımlar ----
        Dim ProductCode, FirmCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String
        '-------------------------------------------

        Dim ArrangeDate As String
        Dim StartDate, EndDate As String
        Dim AuthorizedDrivers, AuthorizedDrivers_aciklama As String
        Dim PolicyOwnerName, PolicyOwnerIdentityNo, PlateNumber As String
        Dim PublicValue, CurrencyCode As String
        Dim PolicyOwnerSurname As String

        Dim TariffCode As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        Dim renk As String

        Dim link As String
        Dim dugme As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"


                    'PRIMARY KEY DOLDUR 
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = CStr(veri.Item("FirmCode"))
                    Else
                        FirmCode = ""
                    End If
                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = CStr(veri.Item("ProductCode"))
                    Else
                        ProductCode = ""
                    End If
                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = CStr(veri.Item("AgencyCode"))
                    Else
                        AgencyCode = ""
                    End If
                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = CStr(veri.Item("PolicyNumber"))
                    Else
                        PolicyNumber = ""
                    End If
                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = CStr(veri.Item("TecditNumber"))
                    Else
                        TecditNumber = ""
                    End If
                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        ZeylCode = CStr(veri.Item("ZeylCode"))
                    Else
                        ZeylCode = ""
                    End If
                    If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                        ZeylNo = CStr(veri.Item("ZeylNo"))
                    Else
                        ZeylNo = ""
                    End If
                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = CStr(veri.Item("ProductType"))
                    Else
                        ProductType = ""
                    End If
                    '----------------------------------------------------------

                    'renk bul -------------- 
                    renk = renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

                    'dügme ------------------------------------
                    link = "policedetay.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "ZeylCode=" + Trim(ZeylCode) + "&" + _
                    "ZeylNo=" + Trim(ZeylNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    'link = HttpContext.Current.Server.UrlEncode(link)

                    dugme = "<span class='button'>Bilgiler</span>"

                    koldugme = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + _
                    dugme + "</a></td>"


                    If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                        TariffCode = CStr(veri.Item("TariffCode"))
                        kol1 = "<td>" + renklendir(TariffCode, renk) + "</td>"
                        saf1 = TariffCode
                    Else
                        kol1 = "<td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + renklendir(ProductCode, renk) + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_Erisim.bultek_sirketkodagore(FirmCode)
                        kol3 = "<td>" + renklendir(sirket.sirketad, renk) + "</td>"
                        saf3 = sirket.sirketad
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol4 = "<td>" + renklendir(AgencyCode, renk) + "</td>"
                        saf4 = AgencyCode
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol5 = "<td>" + renklendir(PolicyNumber, renk) + "</td>"
                        saf5 = PolicyNumber
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If


                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        StartDate = veri.Item("StartDate")
                        kol6 = "<td>" + StartDate + "</td>"
                        saf6 = StartDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        EndDate = veri.Item("EndDate")
                        kol7 = "<td>" + EndDate + "</td>"
                        saf7 = EndDate
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                        kol8 = "<td>" + TecditNumber + "</td>"
                        saf8 = TecditNumber
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If


                    If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                        AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                        If AuthorizedDrivers = "A" Then
                            AuthorizedDrivers_aciklama = "Herhangi Kişi"
                        End If
                        If AuthorizedDrivers = "N" Then
                            AuthorizedDrivers_aciklama = "İsme Göre"
                        End If
                        kol9 = "<td>" + AuthorizedDrivers_aciklama + "</td>"
                        saf9 = AuthorizedDrivers_aciklama
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If


                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                    Else
                        PolicyOwnerSurname = ""
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        PolicyOwnerName = veri.Item("PolicyOwnerName")
                        kol10 = "<td>" + PolicyOwnerName + " " + PolicyOwnerSurname + "</td>"
                        saf10 = PolicyOwnerName + " " + PolicyOwnerSurname
                    Else
                        kol10 = "<td>-</td>"
                        saf10 = "-"
                    End If


                    If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                        PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                        kol11 = "<td>" + PolicyOwnerIdentityNo + "</td>"
                        saf11 = PolicyOwnerIdentityNo
                    Else
                        kol11 = "<td>-</td>"
                        saf11 = "-"
                    End If


                    If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                        PlateNumber = veri.Item("PlateNumber")
                        kol12 = "<td>" + PlateNumber + "</td>"
                        saf12 = PlateNumber
                    Else
                        kol12 = "<td>-</td>"
                        saf12 = "-"
                    End If


                    If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                        PublicValue = veri.Item("PublicValue")
                        kol13 = "<td>" + PublicValue + "</td>"
                        saf13 = PublicValue
                    Else
                        kol13 = "<td>-</td>"
                        saf13 = "-"
                    End If


                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        CurrencyCode = veri.Item("CurrencyCode")
                        kol14 = "<td>" + CurrencyCode + "</td></tr>"
                        saf14 = CurrencyCode
                    Else
                        kol14 = "<td>-</td></tr>"
                        saf14 = "-"
                    End If

                    'buradasin()
                    'son zeyil ise göster
                    Dim sonzeyilmi As String
                    sonzeyilmi = PolicyInfo2_Erisim.sonzeyilmi_kontrol(FirmCode, ProductCode, AgencyCode, _
                    PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

                    If ZeylCode = "P" Or ZeylCode = "T" Or sonzeyilmi = "Evet" Or renk = "green" Or renk = "blue" Then

                        satir = satir + koldugme + kol1 + kol2 + kol3 + kol4 + kol5 + _
                        kol6 + kol7 + kol8 + kol9 + kol10 + _
                        kol11 + kol12 + kol13 + kol14

                        table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10, _
                        saf11, saf12, saf13, saf14)

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
                        pdftable.AddCell(New Phrase(saf11, fdata))
                        pdftable.AddCell(New Phrase(saf12, fdata))
                        pdftable.AddCell(New Phrase(saf13, fdata))
                        pdftable.AddCell(New Phrase(saf14, fdata))

                        recordcount = recordcount + 1

                    End If

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function



    '--- HASARIN POLİÇESİNİ BUL -------------------------------------------------------
    Function policedoldur_ilgilihasar(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As List(Of PolicyInfo)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)


        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and (ZeylCode='P' or ZeylCode='p' or ZeylCode='T' or ZeylCode='t')" + _
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

        Dim param6 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ProductType
        komut.Parameters.Add(param6)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If


                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If


                PolicyInfolar.Add(New PolicyInfo(donecekPolicyInfo.FirmCode, _
                donecekPolicyInfo.ProductCode, donecekPolicyInfo.AgencyCode, donecekPolicyInfo.PolicyNumber, _
                donecekPolicyInfo.TecditNumber, donecekPolicyInfo.ZeylCode, donecekPolicyInfo.ZeylNo, _
                donecekPolicyInfo.PolicyType, donecekPolicyInfo.PolicyOwnerCountryCode, _
                donecekPolicyInfo.PolicyOwnerIdentityCode, donecekPolicyInfo.PolicyOwnerIdentityNo, _
                donecekPolicyInfo.PolicyOwnerName, donecekPolicyInfo.PolicyOwnerSurname, _
                donecekPolicyInfo.PolicyOwnerBirthDate, donecekPolicyInfo.AddressLine1, _
                donecekPolicyInfo.AddressLine2, donecekPolicyInfo.AddressLine3, _
                donecekPolicyInfo.PlateCountryCode, donecekPolicyInfo.PlateNumber, _
                donecekPolicyInfo.Brand, donecekPolicyInfo.Model, _
                donecekPolicyInfo.ChassisNumber, donecekPolicyInfo.EngineNumber, _
                donecekPolicyInfo.EnginePower, donecekPolicyInfo.ProductionYear, _
                donecekPolicyInfo.Capacity, donecekPolicyInfo.CarType, _
                donecekPolicyInfo.UsingStyle, donecekPolicyInfo.TariffCode, _
                donecekPolicyInfo.ArrangeDate, donecekPolicyInfo.StartDate, _
                donecekPolicyInfo.EndDate, donecekPolicyInfo.Material, _
                donecekPolicyInfo.Corporal, donecekPolicyInfo.CurrencyCode, _
                donecekPolicyInfo.PublicValue, donecekPolicyInfo.AuthorizedDrivers, _
                donecekPolicyInfo.CountryCode1, donecekPolicyInfo.IdentityCode1, _
                donecekPolicyInfo.IdentityNo1, donecekPolicyInfo.Name1, _
                donecekPolicyInfo.Surname1, donecekPolicyInfo.BirthDate1, _
                donecekPolicyInfo.DriverLicenceNo1, donecekPolicyInfo.DriverLicenceGivenDate1, _
                donecekPolicyInfo.DriverLicenceType1, donecekPolicyInfo.CountryCode2, _
                donecekPolicyInfo.IdentityCode2, donecekPolicyInfo.IdentityNo2, _
                donecekPolicyInfo.Name2, donecekPolicyInfo.Surname2, donecekPolicyInfo.BirthDate2, _
                donecekPolicyInfo.DriverLicenceNo2, donecekPolicyInfo.DriverLicenceGivenDate2, _
                donecekPolicyInfo.DriverLicenceType2, donecekPolicyInfo.CountryCode3, _
                donecekPolicyInfo.IdentityCode3, donecekPolicyInfo.IdentityNo3, _
                donecekPolicyInfo.Name3, donecekPolicyInfo.Surname3, donecekPolicyInfo.BirthDate3, _
                donecekPolicyInfo.DriverLicenceNo3, donecekPolicyInfo.DriverLicenceGivenDate3, _
                donecekPolicyInfo.DriverLicenceType3, donecekPolicyInfo.CountryCode4, _
                donecekPolicyInfo.IdentityCode4, donecekPolicyInfo.IdentityNo4, _
                donecekPolicyInfo.Name4, donecekPolicyInfo.Surname4, _
                donecekPolicyInfo.BirthDate4, donecekPolicyInfo.DriverLicenceNo4, _
                donecekPolicyInfo.DriverLicenceGivenDate4, donecekPolicyInfo.DriverLicenceType4, _
                donecekPolicyInfo.CountryCode5, donecekPolicyInfo.IdentityCode5, _
                donecekPolicyInfo.IdentityNo5, donecekPolicyInfo.Name5, _
                donecekPolicyInfo.Surname5, donecekPolicyInfo.BirthDate5, _
                donecekPolicyInfo.DriverLicenceNo5, donecekPolicyInfo.DriverLicenceGivenDate5, _
                donecekPolicyInfo.DriverLicenceType5, donecekPolicyInfo.CountryCode6, _
                donecekPolicyInfo.IdentityCode6, donecekPolicyInfo.IdentityNo6, _
                donecekPolicyInfo.Name6, donecekPolicyInfo.Surname6, _
                donecekPolicyInfo.BirthDate6, donecekPolicyInfo.DriverLicenceNo6, _
                donecekPolicyInfo.DriverLicenceGivenDate6, donecekPolicyInfo.DriverLicenceType6, _
                donecekPolicyInfo.InsurancePremium, donecekPolicyInfo.AssistantFees, _
                donecekPolicyInfo.OtherFees, _
                donecekPolicyInfo.BasePriceValue, donecekPolicyInfo.CCRateValue, _
                donecekPolicyInfo.DamageRateValue, donecekPolicyInfo.AgeRateValue, _
                donecekPolicyInfo.DamagelessRateValue, donecekPolicyInfo.Color, _
                donecekPolicyInfo.ProductType, donecekPolicyInfo.FuelType, _
                donecekPolicyInfo.SteeringSide, donecekPolicyInfo.AnyDriverRateValue, _
                donecekPolicyInfo.PolicyPremium, donecekPolicyInfo.PolicyPremiumTL, _
                donecekPolicyInfo.InsurancePremiumTL, donecekPolicyInfo.PublicValueTL, _
                donecekPolicyInfo.DamageRate, donecekPolicyInfo.DamagelessRate, _
                donecekPolicyInfo.AnyDriverRate, donecekPolicyInfo.AgeRate, donecekPolicyInfo.CCRate, _
                donecekPolicyInfo.SBMCode, donecekPolicyInfo.Creditor, _
                donecekPolicyInfo.FirstBeneficiary, donecekPolicyInfo.ExchangeRate, _
                donecekPolicyInfo.AgencyRegisterCode,donecekPolicyInfo.TPNO, _
                donecekPolicyInfo.BorderCode))

            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return PolicyInfolar

    End Function



    '--- HASARIN POLİÇESİNİ BUL -------------------------------------------------------
    Function zeyildoldur_ilgilipolice(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal ProductType As String) As List(Of PolicyInfo)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and ProductType=@ProductType " + _
        " order by TecditNumber,ZeylNo"

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

        Dim param5 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = ProductType
        komut.Parameters.Add(param5)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If


                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If


                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If


                PolicyInfolar.Add(New PolicyInfo(donecekPolicyInfo.FirmCode, _
                donecekPolicyInfo.ProductCode, donecekPolicyInfo.AgencyCode, donecekPolicyInfo.PolicyNumber, _
                donecekPolicyInfo.TecditNumber, donecekPolicyInfo.ZeylCode, donecekPolicyInfo.ZeylNo, _
                donecekPolicyInfo.PolicyType, donecekPolicyInfo.PolicyOwnerCountryCode, _
                donecekPolicyInfo.PolicyOwnerIdentityCode, donecekPolicyInfo.PolicyOwnerIdentityNo, _
                donecekPolicyInfo.PolicyOwnerName, donecekPolicyInfo.PolicyOwnerSurname, _
                donecekPolicyInfo.PolicyOwnerBirthDate, donecekPolicyInfo.AddressLine1, _
                donecekPolicyInfo.AddressLine2, donecekPolicyInfo.AddressLine3, _
                donecekPolicyInfo.PlateCountryCode, donecekPolicyInfo.PlateNumber, _
                donecekPolicyInfo.Brand, donecekPolicyInfo.Model, _
                donecekPolicyInfo.ChassisNumber, donecekPolicyInfo.EngineNumber, _
                donecekPolicyInfo.EnginePower, donecekPolicyInfo.ProductionYear, _
                donecekPolicyInfo.Capacity, donecekPolicyInfo.CarType, _
                donecekPolicyInfo.UsingStyle, donecekPolicyInfo.TariffCode, _
                donecekPolicyInfo.ArrangeDate, donecekPolicyInfo.StartDate, _
                donecekPolicyInfo.EndDate, donecekPolicyInfo.Material, _
                donecekPolicyInfo.Corporal, donecekPolicyInfo.CurrencyCode, _
                donecekPolicyInfo.PublicValue, donecekPolicyInfo.AuthorizedDrivers, _
                donecekPolicyInfo.CountryCode1, donecekPolicyInfo.IdentityCode1, _
                donecekPolicyInfo.IdentityNo1, donecekPolicyInfo.Name1, _
                donecekPolicyInfo.Surname1, donecekPolicyInfo.BirthDate1, _
                donecekPolicyInfo.DriverLicenceNo1, donecekPolicyInfo.DriverLicenceGivenDate1, _
                donecekPolicyInfo.DriverLicenceType1, donecekPolicyInfo.CountryCode2, _
                donecekPolicyInfo.IdentityCode2, donecekPolicyInfo.IdentityNo2, _
                donecekPolicyInfo.Name2, donecekPolicyInfo.Surname2, donecekPolicyInfo.BirthDate2, _
                donecekPolicyInfo.DriverLicenceNo2, donecekPolicyInfo.DriverLicenceGivenDate2, _
                donecekPolicyInfo.DriverLicenceType2, donecekPolicyInfo.CountryCode3, _
                donecekPolicyInfo.IdentityCode3, donecekPolicyInfo.IdentityNo3, _
                donecekPolicyInfo.Name3, donecekPolicyInfo.Surname3, donecekPolicyInfo.BirthDate3, _
                donecekPolicyInfo.DriverLicenceNo3, donecekPolicyInfo.DriverLicenceGivenDate3, _
                donecekPolicyInfo.DriverLicenceType3, donecekPolicyInfo.CountryCode4, _
                donecekPolicyInfo.IdentityCode4, donecekPolicyInfo.IdentityNo4, _
                donecekPolicyInfo.Name4, donecekPolicyInfo.Surname4, _
                donecekPolicyInfo.BirthDate4, donecekPolicyInfo.DriverLicenceNo4, _
                donecekPolicyInfo.DriverLicenceGivenDate4, donecekPolicyInfo.DriverLicenceType4, _
                donecekPolicyInfo.CountryCode5, donecekPolicyInfo.IdentityCode5, _
                donecekPolicyInfo.IdentityNo5, donecekPolicyInfo.Name5, _
                donecekPolicyInfo.Surname5, donecekPolicyInfo.BirthDate5, _
                donecekPolicyInfo.DriverLicenceNo5, donecekPolicyInfo.DriverLicenceGivenDate5, _
                donecekPolicyInfo.DriverLicenceType5, donecekPolicyInfo.CountryCode6, _
                donecekPolicyInfo.IdentityCode6, donecekPolicyInfo.IdentityNo6, _
                donecekPolicyInfo.Name6, donecekPolicyInfo.Surname6, _
                donecekPolicyInfo.BirthDate6, donecekPolicyInfo.DriverLicenceNo6, _
                donecekPolicyInfo.DriverLicenceGivenDate6, donecekPolicyInfo.DriverLicenceType6, _
                donecekPolicyInfo.InsurancePremium, donecekPolicyInfo.AssistantFees, _
                donecekPolicyInfo.OtherFees, _
                donecekPolicyInfo.BasePriceValue, donecekPolicyInfo.CCRateValue, _
                donecekPolicyInfo.DamageRateValue, donecekPolicyInfo.AgeRateValue, _
                donecekPolicyInfo.DamagelessRateValue, donecekPolicyInfo.Color, _
                donecekPolicyInfo.ProductType, donecekPolicyInfo.FuelType, _
                donecekPolicyInfo.SteeringSide, donecekPolicyInfo.AnyDriverRateValue, _
                donecekPolicyInfo.PolicyPremium, donecekPolicyInfo.PolicyPremiumTL, _
                donecekPolicyInfo.InsurancePremiumTL, donecekPolicyInfo.PublicValueTL, _
                donecekPolicyInfo.DamageRate, donecekPolicyInfo.DamagelessRate, _
                donecekPolicyInfo.AnyDriverRate, donecekPolicyInfo.AgeRate, donecekPolicyInfo.CCRate, _
                donecekPolicyInfo.SBMCode, _
                donecekPolicyInfo.Creditor, donecekPolicyInfo.FirstBeneficiary, _
                donecekPolicyInfo.ExchangeRate,donecekPolicyInfo.AgencyRegisterCode, donecekPolicyInfo.TPNo, _
                donecekPolicyInfo.BorderCode))

            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return PolicyInfolar

    End Function



    Function zeyildoldur_ilgilipolice_tersten(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal ProductType As String) As List(Of PolicyInfo)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and ProductType=@ProductType " + _
        " order by TecditNumber,ZeylNo,ZeylCode desc"

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

        Dim param5 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = ProductType
        komut.Parameters.Add(param5)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If


                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If


                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If


                PolicyInfolar.Add(New PolicyInfo(donecekPolicyInfo.FirmCode, _
                donecekPolicyInfo.ProductCode, donecekPolicyInfo.AgencyCode, donecekPolicyInfo.PolicyNumber, _
                donecekPolicyInfo.TecditNumber, donecekPolicyInfo.ZeylCode, donecekPolicyInfo.ZeylNo, _
                donecekPolicyInfo.PolicyType, donecekPolicyInfo.PolicyOwnerCountryCode, _
                donecekPolicyInfo.PolicyOwnerIdentityCode, donecekPolicyInfo.PolicyOwnerIdentityNo, _
                donecekPolicyInfo.PolicyOwnerName, donecekPolicyInfo.PolicyOwnerSurname, _
                donecekPolicyInfo.PolicyOwnerBirthDate, donecekPolicyInfo.AddressLine1, _
                donecekPolicyInfo.AddressLine2, donecekPolicyInfo.AddressLine3, _
                donecekPolicyInfo.PlateCountryCode, donecekPolicyInfo.PlateNumber, _
                donecekPolicyInfo.Brand, donecekPolicyInfo.Model, _
                donecekPolicyInfo.ChassisNumber, donecekPolicyInfo.EngineNumber, _
                donecekPolicyInfo.EnginePower, donecekPolicyInfo.ProductionYear, _
                donecekPolicyInfo.Capacity, donecekPolicyInfo.CarType, _
                donecekPolicyInfo.UsingStyle, donecekPolicyInfo.TariffCode, _
                donecekPolicyInfo.ArrangeDate, donecekPolicyInfo.StartDate, _
                donecekPolicyInfo.EndDate, donecekPolicyInfo.Material, _
                donecekPolicyInfo.Corporal, donecekPolicyInfo.CurrencyCode, _
                donecekPolicyInfo.PublicValue, donecekPolicyInfo.AuthorizedDrivers, _
                donecekPolicyInfo.CountryCode1, donecekPolicyInfo.IdentityCode1, _
                donecekPolicyInfo.IdentityNo1, donecekPolicyInfo.Name1, _
                donecekPolicyInfo.Surname1, donecekPolicyInfo.BirthDate1, _
                donecekPolicyInfo.DriverLicenceNo1, donecekPolicyInfo.DriverLicenceGivenDate1, _
                donecekPolicyInfo.DriverLicenceType1, donecekPolicyInfo.CountryCode2, _
                donecekPolicyInfo.IdentityCode2, donecekPolicyInfo.IdentityNo2, _
                donecekPolicyInfo.Name2, donecekPolicyInfo.Surname2, donecekPolicyInfo.BirthDate2, _
                donecekPolicyInfo.DriverLicenceNo2, donecekPolicyInfo.DriverLicenceGivenDate2, _
                donecekPolicyInfo.DriverLicenceType2, donecekPolicyInfo.CountryCode3, _
                donecekPolicyInfo.IdentityCode3, donecekPolicyInfo.IdentityNo3, _
                donecekPolicyInfo.Name3, donecekPolicyInfo.Surname3, donecekPolicyInfo.BirthDate3, _
                donecekPolicyInfo.DriverLicenceNo3, donecekPolicyInfo.DriverLicenceGivenDate3, _
                donecekPolicyInfo.DriverLicenceType3, donecekPolicyInfo.CountryCode4, _
                donecekPolicyInfo.IdentityCode4, donecekPolicyInfo.IdentityNo4, _
                donecekPolicyInfo.Name4, donecekPolicyInfo.Surname4, _
                donecekPolicyInfo.BirthDate4, donecekPolicyInfo.DriverLicenceNo4, _
                donecekPolicyInfo.DriverLicenceGivenDate4, donecekPolicyInfo.DriverLicenceType4, _
                donecekPolicyInfo.CountryCode5, donecekPolicyInfo.IdentityCode5, _
                donecekPolicyInfo.IdentityNo5, donecekPolicyInfo.Name5, _
                donecekPolicyInfo.Surname5, donecekPolicyInfo.BirthDate5, _
                donecekPolicyInfo.DriverLicenceNo5, donecekPolicyInfo.DriverLicenceGivenDate5, _
                donecekPolicyInfo.DriverLicenceType5, donecekPolicyInfo.CountryCode6, _
                donecekPolicyInfo.IdentityCode6, donecekPolicyInfo.IdentityNo6, _
                donecekPolicyInfo.Name6, donecekPolicyInfo.Surname6, _
                donecekPolicyInfo.BirthDate6, donecekPolicyInfo.DriverLicenceNo6, _
                donecekPolicyInfo.DriverLicenceGivenDate6, donecekPolicyInfo.DriverLicenceType6, _
                donecekPolicyInfo.InsurancePremium, donecekPolicyInfo.AssistantFees, _
                donecekPolicyInfo.OtherFees, _
                donecekPolicyInfo.BasePriceValue, donecekPolicyInfo.CCRateValue, _
                donecekPolicyInfo.DamageRateValue, donecekPolicyInfo.AgeRateValue, _
                donecekPolicyInfo.DamagelessRateValue, donecekPolicyInfo.Color, _
                donecekPolicyInfo.ProductType, donecekPolicyInfo.FuelType, _
                donecekPolicyInfo.SteeringSide, donecekPolicyInfo.AnyDriverRateValue, _
                donecekPolicyInfo.PolicyPremium, donecekPolicyInfo.PolicyPremiumTL, _
                donecekPolicyInfo.InsurancePremiumTL, donecekPolicyInfo.PublicValueTL, _
                donecekPolicyInfo.DamageRate, donecekPolicyInfo.DamagelessRate, _
                donecekPolicyInfo.AnyDriverRate, donecekPolicyInfo.AgeRate, donecekPolicyInfo.CCRate, _
                donecekPolicyInfo.SBMCode, _
                donecekPolicyInfo.Creditor, donecekPolicyInfo.FirstBeneficiary, _
                donecekPolicyInfo.ExchangeRate, donecekPolicyInfo.AgencyRegisterCode, donecekPolicyInfo.TPNo, _
                donecekPolicyInfo.BorderCode))

            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return PolicyInfolar

    End Function





    Function zeyildoldur_ilgilipolice_tecditli(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As List(Of PolicyInfo)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)


        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and ProductType=@ProductType " + _
        "order by ZeylNo"


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
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If

                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If


                PolicyInfolar.Add(New PolicyInfo(donecekPolicyInfo.FirmCode, _
                donecekPolicyInfo.ProductCode, donecekPolicyInfo.AgencyCode, donecekPolicyInfo.PolicyNumber, _
                donecekPolicyInfo.TecditNumber, donecekPolicyInfo.ZeylCode, donecekPolicyInfo.ZeylNo, _
                donecekPolicyInfo.PolicyType, donecekPolicyInfo.PolicyOwnerCountryCode, _
                donecekPolicyInfo.PolicyOwnerIdentityCode, donecekPolicyInfo.PolicyOwnerIdentityNo, _
                donecekPolicyInfo.PolicyOwnerName, donecekPolicyInfo.PolicyOwnerSurname, _
                donecekPolicyInfo.PolicyOwnerBirthDate, donecekPolicyInfo.AddressLine1, _
                donecekPolicyInfo.AddressLine2, donecekPolicyInfo.AddressLine3, _
                donecekPolicyInfo.PlateCountryCode, donecekPolicyInfo.PlateNumber, _
                donecekPolicyInfo.Brand, donecekPolicyInfo.Model, _
                donecekPolicyInfo.ChassisNumber, donecekPolicyInfo.EngineNumber, _
                donecekPolicyInfo.EnginePower, donecekPolicyInfo.ProductionYear, _
                donecekPolicyInfo.Capacity, donecekPolicyInfo.CarType, _
                donecekPolicyInfo.UsingStyle, donecekPolicyInfo.TariffCode, _
                donecekPolicyInfo.ArrangeDate, donecekPolicyInfo.StartDate, _
                donecekPolicyInfo.EndDate, donecekPolicyInfo.Material, _
                donecekPolicyInfo.Corporal, donecekPolicyInfo.CurrencyCode, _
                donecekPolicyInfo.PublicValue, donecekPolicyInfo.AuthorizedDrivers, _
                donecekPolicyInfo.CountryCode1, donecekPolicyInfo.IdentityCode1, _
                donecekPolicyInfo.IdentityNo1, donecekPolicyInfo.Name1, _
                donecekPolicyInfo.Surname1, donecekPolicyInfo.BirthDate1, _
                donecekPolicyInfo.DriverLicenceNo1, donecekPolicyInfo.DriverLicenceGivenDate1, _
                donecekPolicyInfo.DriverLicenceType1, donecekPolicyInfo.CountryCode2, _
                donecekPolicyInfo.IdentityCode2, donecekPolicyInfo.IdentityNo2, _
                donecekPolicyInfo.Name2, donecekPolicyInfo.Surname2, donecekPolicyInfo.BirthDate2, _
                donecekPolicyInfo.DriverLicenceNo2, donecekPolicyInfo.DriverLicenceGivenDate2, _
                donecekPolicyInfo.DriverLicenceType2, donecekPolicyInfo.CountryCode3, _
                donecekPolicyInfo.IdentityCode3, donecekPolicyInfo.IdentityNo3, _
                donecekPolicyInfo.Name3, donecekPolicyInfo.Surname3, donecekPolicyInfo.BirthDate3, _
                donecekPolicyInfo.DriverLicenceNo3, donecekPolicyInfo.DriverLicenceGivenDate3, _
                donecekPolicyInfo.DriverLicenceType3, donecekPolicyInfo.CountryCode4, _
                donecekPolicyInfo.IdentityCode4, donecekPolicyInfo.IdentityNo4, _
                donecekPolicyInfo.Name4, donecekPolicyInfo.Surname4, _
                donecekPolicyInfo.BirthDate4, donecekPolicyInfo.DriverLicenceNo4, _
                donecekPolicyInfo.DriverLicenceGivenDate4, donecekPolicyInfo.DriverLicenceType4, _
                donecekPolicyInfo.CountryCode5, donecekPolicyInfo.IdentityCode5, _
                donecekPolicyInfo.IdentityNo5, donecekPolicyInfo.Name5, _
                donecekPolicyInfo.Surname5, donecekPolicyInfo.BirthDate5, _
                donecekPolicyInfo.DriverLicenceNo5, donecekPolicyInfo.DriverLicenceGivenDate5, _
                donecekPolicyInfo.DriverLicenceType5, donecekPolicyInfo.CountryCode6, _
                donecekPolicyInfo.IdentityCode6, donecekPolicyInfo.IdentityNo6, _
                donecekPolicyInfo.Name6, donecekPolicyInfo.Surname6, _
                donecekPolicyInfo.BirthDate6, donecekPolicyInfo.DriverLicenceNo6, _
                donecekPolicyInfo.DriverLicenceGivenDate6, donecekPolicyInfo.DriverLicenceType6, _
                donecekPolicyInfo.InsurancePremium, donecekPolicyInfo.AssistantFees, _
                donecekPolicyInfo.OtherFees, _
                donecekPolicyInfo.BasePriceValue, donecekPolicyInfo.CCRateValue, _
                donecekPolicyInfo.DamageRateValue, donecekPolicyInfo.AgeRateValue, _
                donecekPolicyInfo.DamagelessRateValue, donecekPolicyInfo.Color, _
                donecekPolicyInfo.ProductType, donecekPolicyInfo.FuelType, _
                donecekPolicyInfo.SteeringSide, donecekPolicyInfo.AnyDriverRateValue, _
                donecekPolicyInfo.PolicyPremium, donecekPolicyInfo.PolicyPremiumTL, _
                donecekPolicyInfo.InsurancePremiumTL, donecekPolicyInfo.PublicValueTL, _
                donecekPolicyInfo.DamageRate, donecekPolicyInfo.DamagelessRate, _
                donecekPolicyInfo.AnyDriverRate, donecekPolicyInfo.AgeRate, donecekPolicyInfo.CCRate, _
                donecekPolicyInfo.SBMCode, _
                donecekPolicyInfo.Creditor, donecekPolicyInfo.FirstBeneficiary, _
                donecekPolicyInfo.ExchangeRate, donecekPolicyInfo.AgencyRegisterCode, _
                donecekPolicyInfo.TPNo, donecekPolicyInfo.BorderCode))


            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return PolicyInfolar

    End Function



    '--- POLİÇELERİ BUL -------------------------------------------------------
    Function bultek(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As PolicyInfo


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)


        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and ZeylCode=@ZeylCode " + _
        " and ZeylNo=@ZeylNo" + _
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

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ZeylCode
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = ZeylNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                Else
                    donecekPolicyInfo.AddressLine1 = ""
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                Else
                    donecekPolicyInfo.AddressLine2 = ""
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                Else
                    donecekPolicyInfo.AddressLine3 = ""
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If

                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If


            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekPolicyInfo

    End Function


    '--- POLİÇELERİ BUL -------------------------------------------------------
    Function bultek_qrkodgore(ByVal SBMCode As String) As PolicyInfo

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where SBMCode=@SBMCode"  
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@SBMCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = SBMCode
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If

                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If


            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekPolicyInfo

    End Function




    '--- POLİÇELE SİL -------------------------------------------------------
    Function sil(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and ZeylCode=@ZeylCode " + _
        " and ZeylNo=@ZeylNo" + _
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

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ZeylCode
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = ZeylNo
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


    Public Function hasarinpoliceleri_tablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String


        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16 As String

        Dim basliklar, tabloson As String

        Dim hasarinpoliceleri As New List(Of PolicyInfo)

        hasarinpoliceleri = policedoldur_ilgilihasar(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_3'>" + _
        "<thead>" + _
        "<th>Tarife</th>" + _
        "<th>Ürün</th>" + _
        "<th>Ürün Çeşidi</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Başlangıç</th>" + _
        "<th>Bitiş</th>" + _
        "<th>Tecdit</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Doğum Tarihi</th>" + _
        "<th>Plaka</th>" + _
        "<th>Kasko Bedeli</th>" + _
        "<th>Para Birimi</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In hasarinpoliceleri


            kol1 = "<tr><td>" + CStr(itempolice.TariffCode) + "</td>"
            kol2 = "<td>" + CStr(itempolice.ProductCode) + "</td>"
            kol3 = "<td>" + CStr(itempolice.ProductType) + "</td>"
            kol4 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(itempolice.FirmCode)).sirketad + "</td>"
            kol5 = "<td>" + CStr(itempolice.AgencyCode) + "</td>"
            kol6 = "<td>" + CStr(itempolice.PolicyNumber) + "</td>"
            kol7 = "<td>" + CStr(itempolice.StartDate) + "</td>"
            kol8 = "<td>" + CStr(itempolice.EndDate) + "</td>"
            kol9 = "<td>" + CStr(itempolice.TecditNumber) + "</td>"

            If itempolice.AuthorizedDrivers = "A" Then
                kol10 = "<td>" + "Herhangi Kişi" + "</td>"
            End If
            If itempolice.AuthorizedDrivers = "N" Then
                kol10 = "<td>" + "İsme Göre" + "</td>"

            End If

            kol11 = "<td>" + CStr(itempolice.PolicyOwnerName) + " " + CStr(itempolice.PolicyOwnerSurname) + "</td>"
            kol12 = "<td>" + CStr(itempolice.PolicyOwnerIdentityNo) + "</td>"
            kol13 = "<td>" + CStr(itempolice.PolicyOwnerBirthDate) + "</td>"
            kol14 = "<td>" + CStr(itempolice.PlateNumber) + "</td>"
            kol15 = "<td>" + CStr(itempolice.PublicValue) + "</td>"
            kol16 = "<td>" + CStr(itempolice.CurrencyCode) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + _
            kol9 + kol10 + kol11 + kol12 + kol13 + kol14 + kol15 + kol16

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    Public Function hasarinpoliceleri_tablo_sirketicin(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String


        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String

        Dim basliklar, tabloson As String

        Dim hasarinpoliceleri As New List(Of PolicyInfo)

        hasarinpoliceleri = policedoldur_ilgilihasar(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Tarife</th>" + _
        "<th>Ürün</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Başlangıç</th>" + _
        "<th>Bitiş</th>" + _
        "<th>Tecdit</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In hasarinpoliceleri


            kol1 = "<tr><td>" + CStr(itempolice.TariffCode) + "</td>"
            kol2 = "<td>" + CStr(itempolice.ProductCode) + "</td>"
            kol3 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(itempolice.FirmCode)).sirketad + "</td>"
            kol4 = "<td>" + CStr(itempolice.AgencyCode) + "</td>"
            kol5 = "<td>" + CStr(itempolice.PolicyNumber) + "</td>"
            kol6 = "<td>" + CStr(itempolice.StartDate) + "</td>"
            kol7 = "<td>" + CStr(itempolice.EndDate) + "</td>"
            kol8 = "<td>" + CStr(itempolice.TecditNumber) + "</td>"

            If itempolice.AuthorizedDrivers = "A" Then
                kol9 = "<td>" + "Herhangi Kişi" + "</td>"
            End If
            If itempolice.AuthorizedDrivers = "N" Then
                kol9 = "<td>" + "İsme Göre" + "</td>"

            End If

            kol10 = "<td>" + CStr(itempolice.PolicyOwnerName) + " " + CStr(itempolice.PolicyOwnerSurname) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + _
            kol9 + kol10

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function

    'hasarın tüm poliçelerini bulur ve o poliçelerdeki tüm araçları listeler.
    Public Function policearacbilgi_tablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String


        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String

        Dim basliklar, tabloson As String
        Dim hasarinpoliceleri As New List(Of PolicyInfo)

        hasarinpoliceleri = policedoldur_ilgilihasar(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<th>Plaka Ülke Kodu</th>" + _
        "<th>Plaka</th>" + _
        "<th>Marka</th>" + _
        "<th>Model</th>" + _
        "<th>Chassis Numarası</th>" + _
        "<th>Motor Numarası</th>" + _
        "<th>Motor Gücü (CC)</th>" + _
        "<th>İmal Yılı</th>" + _
        "<th>Araç Tipi</th>" + _
        "<th>Kapasitesi</th>" + _
        "<th>Kullanım Tarzı</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In hasarinpoliceleri

            kol1 = "<tr><td>" + CStr(itempolice.PlateCountryCode) + "</td>"
            kol2 = "<td>" + CStr(itempolice.PlateNumber) + "</td>"
            kol3 = "<td>" + CStr(itempolice.Brand) + "</td>"
            kol4 = "<td>" + CStr(itempolice.Model) + "</td>"
            kol5 = "<td>" + CStr(itempolice.ChassisNumber) + "</td>"
            kol6 = "<td>" + CStr(itempolice.EngineNumber) + "</td>"
            kol7 = "<td>" + CStr(itempolice.EnginePower) + "</td>"
            kol8 = "<td>" + CStr(itempolice.ProductionYear) + "</td>"
            kol9 = "<td>" + CStr(itempolice.CarType) + "</td>"
            kol10 = "<td>" + CStr(itempolice.Capacity) + "</td>"
            kol11 = "<td>" + CStr(itempolice.UsingStyle) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + kol11

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    'hasarın tüm poliçelerini bulur ve o poliçelerdeki tüm araçları listeler.
    Public Function policearacbilgi_tablo_sirketicin(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ProductType As String) As String


        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String

        Dim basliklar, tabloson As String
        Dim hasarinpoliceleri As New List(Of PolicyInfo)

        hasarinpoliceleri = policedoldur_ilgilihasar(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Plaka</th>" + _
        "<th>Marka</th>" + _
        "<th>Model</th>" + _
        "<th>Motor Gücü (CC)</th>" + _
        "<th>İmal Yılı</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In hasarinpoliceleri

            kol1 = "<tr><td>" + CStr(itempolice.PlateNumber) + "</td>"
            kol2 = "<td>" + CStr(itempolice.Brand) + "</td>"
            kol3 = "<td>" + CStr(itempolice.Model) + "</td>"
            kol4 = "<td>" + CStr(itempolice.EnginePower) + "</td>"
            kol5 = "<td>" + CStr(itempolice.ProductionYear) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    Public Function tekpolice_aracbilgitablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim fueltype_erisim As New CLASSFUELTYPE_ERISIM


        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16 As String

        Dim basliklar, tabloson As String
        Dim policeler As New List(Of PolicyInfo)

        policeler = zeyildoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<th>Zeyil Kodu</th>" + _
        "<th>Zeyil No</th>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Plaka Ülke Kodu</th>" + _
        "<th>Plaka</th>" + _
        "<th>Marka</th>" + _
        "<th>Model</th>" + _
        "<th>Chassis Numarası</th>" + _
        "<th>Motor Numarası</th>" + _
        "<th>Motor Gücü (CC)</th>" + _
        "<th>İmal Yılı</th>" + _
        "<th>Araç Tipi</th>" + _
        "<th>Kapasitesi</th>" + _
        "<th>Kullanım Tarzı</th>" + _
        "<th>Yakıt Türü</th>" + _
        "<th>Direksiyon Yönü</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In policeler

            kol1 = "<tr><td>" + CStr(itempolice.ZeylCode) + "</td>"
            kol2 = "<td>" + CStr(itempolice.ZeylNo) + "</td>"
            kol3 = "<td>" + CStr(itempolice.StartDate) + "</td>"
            kol4 = "<td>" + CStr(itempolice.PlateCountryCode) + "</td>"
            kol5 = "<td>" + CStr(itempolice.PlateNumber) + "</td>"
            kol6 = "<td>" + CStr(itempolice.Brand) + "</td>"
            kol7 = "<td>" + CStr(itempolice.Model) + "</td>"
            kol8 = "<td>" + CStr(itempolice.ChassisNumber) + "</td>"
            kol9 = "<td>" + CStr(itempolice.EngineNumber) + "</td>"
            kol10 = "<td>" + CStr(itempolice.EnginePower) + "</td>"
            kol11 = "<td>" + CStr(itempolice.ProductionYear) + "</td>"
            kol12 = "<td>" + CStr(itempolice.CarType) + "</td>"
            kol13 = "<td>" + CStr(itempolice.Capacity) + "</td>"
            kol14 = "<td>" + CStr(itempolice.UsingStyle) + "</td>"
            kol15 = "<td>" + CStr(fueltype_erisim.bultek(itempolice.FuelType).FuelTypeName) + "</td>"
            kol16 = "<td>" + CStr(itempolice.SteeringSide) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + _
            kol12 + kol13 + kol14 + kol15 + kol16

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    Public Function tekpolice_aracbilgitablo_sirketicin(ByVal FirmCode As String, ByVal ProductCode As String, _
   ByVal AgencyCode As String, ByVal PolicyNumber As String, _
   ByVal TecditNumber As String, ByVal ZeylCode As String, _
   ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8 As String

        Dim basliklar, tabloson As String
        Dim policeler As New List(Of PolicyInfo)

        policeler = zeyildoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Zeyil Kodu</th>" + _
        "<th>Zeyil No</th>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Plaka</th>" + _
        "<th>Marka</th>" + _
        "<th>Model</th>" + _
        "<th>Motor Gücü (CC)</th>" + _
        "<th>İmal Yılı</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In policeler

            kol1 = "<tr><td>" + CStr(itempolice.ZeylCode) + "</td>"
            kol2 = "<td>" + CStr(itempolice.ZeylNo) + "</td>"
            kol3 = "<td>" + CStr(itempolice.StartDate) + "</td>"
            kol4 = "<td>" + CStr(itempolice.PlateNumber) + "</td>"
            kol5 = "<td>" + CStr(itempolice.Brand) + "</td>"
            kol6 = "<td>" + CStr(itempolice.Model) + "</td>"
            kol7 = "<td>" + CStr(itempolice.EnginePower) + "</td>"
            kol8 = "<td>" + CStr(itempolice.ProductionYear) + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8

        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function



    Public Function tekpolice_tablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim policetip_Erisim As New CLASSPOLICETIP_ERISIM


        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16, kol17, kol18, kol19, kol20 As String
        Dim kol21, kol22, kol23, kol24 As String

        Dim ajaxlinkdigerkisiler As String
        Dim basliklar, tabloson As String

        Dim police As New PolicyInfo


        Dim javascript_erisim As New CLASSJAVASCRIPT

        police = bultek(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)




        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Tarife</th>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Ürün Çeşidi</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe Numarası</th>" + _
        "<th>Tecdit Numarası</th>" + _
        "<th>Zeyil Kodu</th>" + _
        "<th>Zeyil No</th>" + _
        "<th>Poliçe Tipi</th>" + _
        "<th>Tanzim Tarihi</th>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Bitiş Tarihi</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Ülke Kodu</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Kimlik Türü</th>" + _
        "<th>Doğum Tarihi</th>" + _
        "<th>Adres 1</th>" + _
        "<th>Adres 2</th>" + _
        "<th>Adres 3</th>" + _
        "<th>Acente Kayıt Kodu</th>" + _
        "<th>TP No</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        kol1 = "<tr><td>" + CStr(police.TariffCode) + "</td>"
        kol2 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(police.FirmCode)).sirketad + "</td>"
        kol3 = "<td>" + CStr(police.ProductCode) + "</td>"
        kol4 = "<td>" + CStr(police.ProductType) + "</td>"
        kol5 = "<td>" + CStr(police.AgencyCode) + "</td>"
        kol6 = "<td>" + CStr(police.PolicyNumber) + "</td>"
        kol7 = "<td>" + CStr(police.TecditNumber) + "</td>"
        kol8 = "<td>" + CStr(police.ZeylCode) + "</td>"
        kol9 = "<td>" + CStr(police.ZeylNo) + "</td>"
        kol10 = "<td>" + policetip_Erisim.bultek(police.PolicyType).policetipad + "</td>"
        kol11 = "<td>" + CStr(police.ArrangeDate) + "</td>"
        kol12 = "<td>" + CStr(police.StartDate) + "</td>"
        kol13 = "<td>" + CStr(police.EndDate) + "</td>"


        If police.AuthorizedDrivers = "A" Then
            kol14 = "<td>" + "Herhangi Kişi (Any Driver)" + "</td>"
        End If

        If police.AuthorizedDrivers = "N" Then
            ajaxlinkdigerkisiler = "tekpolice_digerkisilertablo(" + _
            "'" + CStr(FirmCode) + "'," + _
            "'" + CStr(ProductCode) + "'," + _
            "'" + CStr(AgencyCode) + "'," + _
            "'" + CStr(PolicyNumber) + " '," + _
            "'" + CStr(TecditNumber) + "'," + _
            "'" + CStr(ZeylCode) + "'," + _
            "'" + CStr(ZeylNo) + "'," + _
            "'" + CStr(ProductType) + "')"

            kol14 = "<td>" + "İsme Göre (Name Driver)" + "<br/>" + _
            "<span id=" + Chr(34) + "digerkisilerbutton" + Chr(34) + _
            " onclick=" + Chr(34) + ajaxlinkdigerkisiler + Chr(34) + _
            javascript_erisim.editbuttonyaratozel("#", "Göster") + _
            "</td>"
        End If

        kol15 = "<td>" + CStr(police.PolicyOwnerName) + " " + CStr(police.PolicyOwnerSurname) + "</td>"
        kol16 = "<td>" + CStr(police.PolicyOwnerCountryCode) + "</td>"
        kol17 = "<td>" + CStr(police.PolicyOwnerIdentityNo) + "</td>"
        kol18 = "<td>" + CStr(police.PolicyOwnerIdentityCode) + "</td>"
        kol19 = "<td>" + CStr(police.PolicyOwnerBirthDate) + "</td>"
        kol20 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol21 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol22 = "<td>" + CStr(police.AddressLine3) + "</td>"
        kol23 = "<td>" + CStr(police.AgencyRegisterCode) + "</td>"
        kol24 = "<td>" + CStr(police.TPNo) + "</td></tr>"



        satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + _
        kol9 + kol10 + kol11 + kol12 + kol13 + kol14 + kol15 + kol16 + kol17 + kol18 + _
        kol19 + kol20 + kol21 + kol22 + kol23 + kol24


        donecek = basliklar + satir + tabloson

        '--------------------------------------
        Dim validatelink As String
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)
        Dim validatestr As String = ""
        validatelink = site.path + "validate.aspx?sbmcode=" + CStr(police.SBMCode)
        validatestr = "<div class=" + Chr(34) + "note note-success" + Chr(34) + ">" + _
        "<p>" + javascript_erisim.buttonyaratozel("green", "fa fa-barcode", validatelink, "Validasyon") + "</p>" + _
        "<p>" + CStr(police.SBMCode) + "</p>" + _
        "</div>"
        '----------------------------------------


        Return donecek + validatestr

    End Function



    Public Function tekpolice_tablo_sirketicin(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
        kullanicirol = kullanicirol_erisim.bultek(HttpContext.Current.Session("kullanici_rolpkey"))

        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String

        Dim ajaxlinkdigerkisiler As String
        Dim basliklar, tabloson As String

        Dim PolicyOwnerName_kisa As String
        Dim PolicyOwnerSurname_kisa As String

        Dim police As New PolicyInfo

        Dim jvstring As String
        jvstring = "<script>" + _
        "$(document).ready(function() {" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"

        police = bultek(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Tarife</th>" + _
        "<th>Ürün</th>" + _
        "<th>Ürün Çeşidi</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Başlangıç</th>" + _
        "<th>Bitiş</th>" + _
        "<th>Tecdit</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Adres1</th>" + _
        "<th>Adres2</th>" + _
        "<th>Adres3</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        kol1 = "<tr><td>" + CStr(police.TariffCode) + "</td>"
        kol2 = "<td>" + CStr(police.ProductCode) + "</td>"
        kol3 = "<td>" + CStr(police.ProductType) + "</td>"
        kol4 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(police.FirmCode)).sirketad + "</td>"
        kol5 = "<td>" + CStr(police.AgencyCode) + "</td>"
        kol6 = "<td>" + CStr(police.PolicyNumber) + "</td>"
        kol7 = "<td>" + CStr(police.StartDate) + "</td>"
        kol8 = "<td>" + CStr(police.EndDate) + "</td>"
        kol9 = "<td>" + CStr(police.TecditNumber) + "</td>"

        If police.AuthorizedDrivers = "A" Then
            kol10 = "<td>" + "Herhangi Kişi (Any Driver)" + "</td>"
        End If

        If police.AuthorizedDrivers = "N" Then
            ajaxlinkdigerkisiler = "tekpolice_digerkisilertablo(" + _
            "'" + CStr(FirmCode) + "'," + _
            "'" + CStr(ProductCode) + "'," + _
            "'" + CStr(AgencyCode) + "'," + _
            "'" + CStr(PolicyNumber) + " '," + _
            "'" + CStr(TecditNumber) + "'," + _
            "'" + CStr(ZeylCode) + "'," + _
            "'" + CStr(ZeylNo) + "'," + _
            "'" + CStr(ProductType) + "')"

            kol10 = "<td>" + "İsme Göre (Name Driver)" + "<br/>" + _
            "<span id=" + Chr(34) + "digerkisilerbutton" + Chr(34) + _
            " onclick=" + Chr(34) + ajaxlinkdigerkisiler + Chr(34) + _
            " class='button'>Göster</span>" + _
            "</td>"
        End If

        'şirketler sadece poliçe sahibinin adının ve soyadının baş harflerini görebilirler.
        If Len(police.PolicyOwnerName) > 1 Then
            PolicyOwnerName_kisa = Mid(police.PolicyOwnerName, 1, 1) + "."
        End If
        If Len(police.PolicyOwnerSurname) > 1 Then
            PolicyOwnerSurname_kisa = Mid(police.PolicyOwnerSurname, 1, 1) + "."
        End If

        'şirket kullanıcısı şriket yöneticisi ve acente kullanıcısı ise sadece baş harfleri göster
        If kullanicirol.tumsirketyetki = "Hayır" Then
            kol11 = "<td>" + PolicyOwnerName_kisa + " " + PolicyOwnerSurname_kisa + "</td>"
        Else
            kol11 = "<td>" + CStr(police.PolicyOwnerName) + " " + CStr(police.PolicyOwnerSurname) + "</td>"
        End If

        kol12 = "<td>" + police.AddressLine1 + "</td>"
        kol13 = "<td>" + police.AddressLine2 + "</td>"
        kol14 = "<td>" + police.AddressLine3 + "</td></tr>"


        satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + _
        kol9 + kol10 + kol11 + kol12 + kol13 + kol14


        donecek = basliklar + satir + tabloson + jvstring
        Return donecek

    End Function


    'tek police diğer kişiler tablosu
    Function tekpolice_digerkisilertablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String


        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
        kullanicirol = kullanicirol_erisim.bultek(HttpContext.Current.Session("kullanici_rolpkey"))

        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1_1, kol2_1, kol3_1, kol4_1, kol5_1, kol6_1, kol7_1 As String
        Dim kol1_2, kol2_2, kol3_2, kol4_2, kol5_2, kol6_2, kol7_2 As String
        Dim kol1_3, kol2_3, kol3_3, kol4_3, kol5_3, kol6_3, kol7_3 As String
        Dim kol1_4, kol2_4, kol3_4, kol4_4, kol5_4, kol6_4, kol7_4 As String
        Dim kol1_5, kol2_5, kol3_5, kol4_5, kol5_5, kol6_5, kol7_5 As String
        Dim kol1_6, kol2_6, kol3_6, kol4_6, kol5_6, kol6_6, kol7_6 As String

        Dim Name1_kisa, Surname1_kisa As String
        Dim Name2_kisa, Surname2_kisa As String
        Dim Name3_kisa, Surname3_kisa As String
        Dim Name4_kisa, Surname4_kisa As String
        Dim Name5_kisa, Surname5_kisa As String
        Dim Name6_kisa, Surname6_kisa As String


        Dim basliklar, tabloson As String
        Dim police As New PolicyInfo

        police = bultek(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover'>" + _
        "<thead>" + _
        "<th>No</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Doğum Tarihi</th>" + _
        "<th>Adres 1</th>" + _
        "<th>Adres 2</th>" + _
        "<th>Adres 3</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"



        'şirketler sadece poliçe sahibinin adının ve soyadının baş harflerini görebilirler.
        If Len(police.Name1) > 1 Then
            Name1_kisa = Mid(police.Name1, 1, 1) + "."
        End If
        If Len(police.Surname1) > 1 Then
            Surname1_kisa = Mid(police.Surname1, 1, 1) + "."
        End If

        If Len(police.Name2) > 1 Then
            Name2_kisa = Mid(police.Name2, 1, 1) + "."
        End If
        If Len(police.Surname2) > 1 Then
            Surname2_kisa = Mid(police.Surname2, 1, 1) + "."
        End If

        If Len(police.Name3) > 3 Then
            Name3_kisa = Mid(police.Name3, 3, 3) + "."
        End If
        If Len(police.Surname3) > 3 Then
            Surname3_kisa = Mid(police.Surname3, 3, 3) + "."
        End If

        If Len(police.Name4) > 4 Then
            Name4_kisa = Mid(police.Name4, 4, 4) + "."
        End If
        If Len(police.Surname4) > 4 Then
            Surname4_kisa = Mid(police.Surname4, 4, 4) + "."
        End If

        If Len(police.Name5) > 5 Then
            Name5_kisa = Mid(police.Name5, 5, 5) + "."
        End If
        If Len(police.Surname5) > 5 Then
            Surname5_kisa = Mid(police.Surname5, 5, 5) + "."
        End If

        If Len(police.Name6) > 6 Then
            Name6_kisa = Mid(police.Name6, 6, 6) + "."
        End If
        If Len(police.Surname6) > 6 Then
            Surname6_kisa = Mid(police.Surname6, 6, 6) + "."
        End If
    

        kol1_1 = "<tr>" + "<td>" + "1" + "</td>"
        'şirket kullanıcısı şriket yöneticisi ve acente kullanıcısı ise sadece baş harfleri göster
        If kullanicirol.tumsirketyetki = "Hayır" Then
            kol2_1 = "<td>" + Name1_kisa + " " + Surname1_kisa + "</td>"
        Else
            kol2_1 = "<td>" + CStr(police.Name1) + " " + CStr(police.Surname1) + "</td>"
        End If
        kol3_1 = "<td>" + CStr(police.IdentityNo1) + "</td>"
        kol4_1 = "<td>" + CStr(police.BirthDate1) + "</td>"
        kol5_1 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol6_1 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol7_1 = "<td>" + CStr(police.AddressLine3) + "</td></tr>"


        kol1_2 = "<tr>" + "<td>" + "2" + "</td>"
        'şirket kullanıcısı şriket yöneticisi ve acente kullanıcısı ise sadece baş harfleri göster
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "5" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "4" Then
            kol2_2 = "<td>" + Name2_kisa + " " + Surname2_kisa + "</td>"
        Else
            kol2_2 = "<td>" + CStr(police.Name2) + " " + CStr(police.Surname2) + "</td>"
        End If
        kol3_2 = "<td>" + CStr(police.IdentityNo2) + "</td>"
        kol4_2 = "<td>" + CStr(police.BirthDate2) + "</td>"
        kol5_2 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol6_2 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol7_2 = "<td>" + CStr(police.AddressLine3) + "</td></tr>"


        kol1_3 = "<tr>" + "<td>" + "3" + "</td>"
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "5" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "4" Then
            kol2_3 = "<td>" + Name3_kisa + " " + Surname3_kisa + "</td>"
        Else
            kol2_3 = "<td>" + CStr(police.Name3) + " " + CStr(police.Surname3) + "</td>"
        End If
        kol3_3 = "<td>" + CStr(police.IdentityNo3) + "</td>"
        kol4_3 = "<td>" + CStr(police.BirthDate3) + "</td>"
        kol5_3 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol6_3 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol7_3 = "<td>" + CStr(police.AddressLine3) + "</td></tr>"


        kol1_4 = "<tr>" + "<td>" + "4" + "</td>"
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "5" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "4" Then
            kol2_4 = "<td>" + Name4_kisa + " " + Surname4_kisa + "</td>"
        Else
            kol2_4 = "<td>" + CStr(police.Name4) + " " + CStr(police.Surname4) + "</td>"
        End If
        kol3_4 = "<td>" + CStr(police.IdentityNo4) + "</td>"
        kol4_4 = "<td>" + CStr(police.BirthDate4) + "</td>"
        kol5_4 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol6_4 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol7_4 = "<td>" + CStr(police.AddressLine3) + "</td></tr>"


        kol1_5 = "<tr>" + "<td>" + "5" + "</td>"
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "5" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "4" Then
            kol2_5 = "<td>" + Name5_kisa + " " + Surname5_kisa + "</td>"
        Else
            kol2_5 = "<td>" + CStr(police.Name5) + " " + CStr(police.Surname5) + "</td>"
        End If
        kol3_5 = "<td>" + CStr(police.IdentityNo5) + "</td>"
        kol4_5 = "<td>" + CStr(police.BirthDate5) + "</td>"
        kol5_5 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol6_5 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol7_5 = "<td>" + CStr(police.AddressLine3) + "</td></tr>"


        kol1_6 = "<tr>" + "<td>" + "6" + "</td>"
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "5" Or _
        HttpContext.Current.Session("kullanici_rolpkey") = "4" Then
            kol2_6 = "<td>" + Name6_kisa + " " + Surname6_kisa + "</td>"
        Else
            kol2_6 = "<td>" + CStr(police.Name6) + " " + CStr(police.Surname6) + "</td>"
        End If
        kol3_6 = "<td>" + CStr(police.IdentityNo6) + "</td>"
        kol4_6 = "<td>" + CStr(police.BirthDate6) + "</td>"
        kol5_6 = "<td>" + CStr(police.AddressLine1) + "</td>"
        kol6_6 = "<td>" + CStr(police.AddressLine2) + "</td>"
        kol7_6 = "<td>" + CStr(police.AddressLine3) + "</td></tr>"


        satir = satir + _
        kol1_1 + kol2_1 + kol3_1 + kol4_1 + kol5_1 + kol6_1 + kol7_1 + _
        kol1_2 + kol2_2 + kol3_2 + kol4_2 + kol5_2 + kol6_2 + kol7_2 + _
        kol1_3 + kol2_3 + kol3_3 + kol4_3 + kol5_3 + kol6_3 + kol7_3 + _
        kol1_4 + kol2_4 + kol3_4 + kol4_4 + kol5_4 + kol6_4 + kol7_4 + _
        kol1_5 + kol2_5 + kol3_5 + kol4_5 + kol5_5 + kol6_5 + kol7_5 + _
        kol1_6 + kol2_6 + kol3_6 + kol4_6 + kol5_6 + kol6_6 + kol7_6

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function


    Public Function tekpolice_zeyiltablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal ProductType As String) As String

        Dim PolicyType_aciklama As String
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16, kol17 As String

        Dim ajaxlinkdigerkisiler As String
        Dim basliklar, tabloson As String

        Dim policeler As New List(Of PolicyInfo)

        Dim jvstring As String
        jvstring = "<script>" + _
        "$(document).ready(function() {" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"


        policeler = zeyildoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_7'>" + _
        "<thead>" + _
        "<th>Tecdit No</th>" + _
        "<th>Zeyl Kodu</th>" + _
        "<th>Zeyl No</th>" + _
        "<th>Tanzim Tarihi</th>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Bitiş Tarihi</th>" + _
        "<th>Plaka</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Ülke Kodu</th>" + _
        "<th>Kimlik Türü</th>" + _
        "<th>Kimlik No</th>" + _
        "<th>Adres 1</th>" + _
        "<th>Adres 2</th>" + _
        "<th>Adres 3</th>" + _
        "<th>Poliçe Tipi</th>" + _
        "<th>Authorized Drivers</th>" + _
        "<th>Agency Register Code</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In policeler

            kol1 = "<tr><td>" + CStr(itempolice.TecditNumber) + "</td>"
            kol2 = "<td>" + CStr(itempolice.ZeylCode) + "</td>"
            kol3 = "<td>" + CStr(itempolice.ZeylNo) + "</td>"
            kol4 = "<td>" + CStr(itempolice.ArrangeDate) + "</td>"
            kol5 = "<td>" + CStr(itempolice.StartDate) + "</td>"
            kol6 = "<td>" + CStr(itempolice.EndDate) + "</td>"
            kol7 = "<td>" + CStr(itempolice.PlateNumber) + "</td>"

            kol8 = "<td>" + CStr(itempolice.PolicyOwnerName) + " " + CStr(itempolice.PolicyOwnerSurname) + "</td>"
            kol9 = "<td>" + CStr(itempolice.PolicyOwnerCountryCode) + "</td>"
            kol10 = "<td>" + CStr(itempolice.PolicyOwnerIdentityCode) + "</td>"
            kol11 = "<td>" + CStr(itempolice.PolicyOwnerIdentityNo) + "</td>"
            kol12 = "<td>" + CStr(itempolice.AddressLine1) + "</td>"
            kol13 = "<td>" + CStr(itempolice.AddressLine2) + "</td>"
            kol14 = "<td>" + CStr(itempolice.AddressLine3) + "</td>"

            If itempolice.PolicyType = 1 Then
                PolicyType_aciklama = "Normal Poliçe"
            End If
            If itempolice.PolicyType = 2 Then
                PolicyType_aciklama = "İhale"
            End If
            If itempolice.PolicyType = 3 Then
                PolicyType_aciklama = "Sınır Kapısı"
            End If
            kol15 = "<td>" + PolicyType_aciklama + "</td>"

            kol16 = "<td>" + itempolice.AuthorizedDrivers + "</td>"
            kol17 = "<td>" + itempolice.AgencyRegisterCode + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15 + kol16 + kol17

        Next

        donecek = basliklar + satir + tabloson + jvstring
        Return donecek

    End Function


    Public Function tekpolice_zeyiltablo_sirketicin(ByVal FirmCode As String, _
    ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal ProductType As String) As String

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
        kullanicirol = kullanicirol_erisim.bultek(HttpContext.Current.Session("kullanici_rolpkey"))

        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String

        Dim ajaxlinkdigerkisiler As String
        Dim basliklar, tabloson As String

        Dim PolicyOwnerName_kisa As String
        Dim PolicyOwnerSurname_kisa As String

        Dim policeler As New List(Of PolicyInfo)

        Dim jvstring As String
        jvstring = "<script>" + _
        "$(document).ready(function() {" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"

        policeler = zeyildoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<th>Zeyl Kodu</th>" + _
        "<th>Zeyl No</th>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Bitiş Tarihi</th>" + _
        "<th>Ad Soyad</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In policeler

            kol1 = "<tr><td>" + CStr(itempolice.ZeylCode) + "</td>"
            kol2 = "<td>" + CStr(itempolice.ZeylNo) + "</td>"
            kol3 = "<td>" + CStr(itempolice.StartDate) + "</td>"
            kol4 = "<td>" + CStr(itempolice.EndDate) + "</td>"

            'şirketler sadece poliçe sahibinin adının ve soyadının baş harflerini görebilirler.
            If Len(itempolice.PolicyOwnerName) > 1 Then
                PolicyOwnerName_kisa = Mid(itempolice.PolicyOwnerName, 1, 1) + "."
            End If
            If Len(itempolice.PolicyOwnerSurname) > 1 Then
                PolicyOwnerSurname_kisa = Mid(itempolice.PolicyOwnerSurname, 1, 1) + "."
            End If

            'şirket kullanıcısı şriket yöneticisi ve acente kullanıcısı ise sadece baş harfleri göster
            If kullanicirol.tumsirketyetki = "Hayır" Then
                kol5 = "<td>" + PolicyOwnerName_kisa + " " + PolicyOwnerSurname_kisa + "</td></tr>"
            Else
                kol5 = "<td>" + CStr(itempolice.PolicyOwnerName) + " " + CStr(itempolice.PolicyOwnerSurname) + "</td></tr>"
            End If

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5

        Next

        donecek = basliklar + satir + tabloson + jvstring
        Return donecek

    End Function

    Public Function tekpolice_primtablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16, kol17, kol18, kol19, kol20 As String

        Dim ajaxlinkdigerkisiler As String
        Dim basliklar, tabloson As String

        Dim policeler As New List(Of PolicyInfo)


        Dim jvstring As String
        jvstring = "<script>" + _
        "$(document).ready(function() {" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"


        policeler = zeyildoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, ProductType)

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_3'>" + _
        "<thead>" + _
        "<th>Base Price Value</th>" + _
        "<th>Public Value</th>" + _
        "<th>Public Value TL</th>" + _
        "<th>Any Driver Rate</th>" + _
        "<th>Any Driver Rate Value</th>" + _
        "<th>Age Rate </th>" + _
        "<th>Age Rate Value</th>" + _
        "<th>CC Rate </th>" + _
        "<th>CC Rate Value</th>" + _
        "<th>Damage Rate</th>" + _
        "<th>Damage Rate Value</th>" + _
        "<th>Damageless Rate</th>" + _
        "<th>Damageless Rate Value</th>" + _
        "<th>Exchange Rate </th>" + _
        "<th>Insuarence Premium</th>" + _
        "<th>Insuarence Premium TL</th>" + _
        "<th>Assistant Fees</th>" + _
        "<th>Other Fees</th>" + _
        "<th>Policy Premium</th>" + _
        "<th>Policy Premium TL</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itempolice As PolicyInfo In policeler

            kol1 = "<tr><td>" + Format(itempolice.BasePriceValue, "0.00") + "</td>"
            kol2 = "<td>" + Format(itempolice.PublicValue, "0.00") + "</td>"
            kol3 = "<td>" + Format(itempolice.PublicValueTL, "0.00") + "</td>"
            kol4 = "<td>" + Format(itempolice.AnyDriverRate, "0.00") + "</td>"
            kol5 = "<td>" + Format(itempolice.AnyDriverRateValue, "0.00") + "</td>"
            kol6 = "<td>" + Format(itempolice.AgeRate, "0.00") + "</td>"
            kol7 = "<td>" + Format(itempolice.AgeRateValue, "0.00") + "</td>"
            kol8 = "<td>" + Format(itempolice.CCRate, "0.00") + "</td>"
            kol9 = "<td>" + Format(itempolice.CCRateValue, "0.00") + "</td>"
            kol10 = "<td>" + Format(itempolice.DamageRate, "0.00") + "</td>"
            kol11 = "<td>" + Format(itempolice.DamageRateValue, "0.00") + "</td>"
            kol12 = "<td>" + CStr(itempolice.DamagelessRate) + "</td>"
            kol13 = "<td>" + Format(itempolice.DamagelessRateValue, "0.00") + "</td>"
            kol14 = "<td>" + Format(itempolice.ExchangeRate, "0.0000") + "</td>"
            kol15 = "<td>" + Format(itempolice.InsurancePremium, "0.00") + "</td>"
            kol16 = "<td>" + Format(itempolice.InsurancePremiumTL, "0.00") + "</td>"
            kol17 = "<td>" + Format(itempolice.AssistantFees, "0.00") + "</td>"
            kol18 = "<td>" + Format(itempolice.OtherFees, "0.00") + "</td>"
            kol19 = "<td>" + Format(itempolice.PolicyPremium, "0.00") + "</td>"
            kol20 = "<td>" + Format(itempolice.PolicyPremiumTL, "0.00") + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12 + _
            kol13 + kol14 + kol15 + kol16 + kol17 + kol18 + kol19 + kol20

        Next

        donecek = basliklar + satir + tabloson + jvstring
        Return donecek

    End Function


    '---------------------------------listele şirket için--------------------------------------
    Public Function listele_sirketicin() As CLASSRAPOR

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
        kullanicirol = kullanicirol_erisim.bultek(HttpContext.Current.Session("kullanici_rolpkey"))

        Dim PolicyInfo2_Erisim As New PolicyInfo2_Erisim

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14 As String

        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String
        Dim sqlteklestirdevam As String

        Dim koldugme As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Bilgiler</th>" + _
        "<th>Tarife</th>" + _
        "<th>Ürün</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Başlangıç</th>" + _
        "<th>Bitiş</th>" + _
        "<th>Tecdit</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Başlangıç", GetType(String))
        table.Columns.Add("Bitiş", GetType(String))
        table.Columns.Add("Tecdit", GetType(String))
        table.Columns.Add("Kapsam", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(10)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Başlangıç", fbaslik))
        pdftable.AddCell(New Phrase("Bitiş", fbaslik))
        pdftable.AddCell(New Phrase("Tecdit", fbaslik))
        pdftable.AddCell(New Phrase("Kapsam", fbaslik))
        pdftable.AddCell(New Phrase("Ad Soyad", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        sqlteklestirdevam = " and (ZeylCode='P' or ZeylCode='T')"
        sqlteklestirdevam = ""


        'kimlikno
        If HttpContext.Current.Session("kimlik") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerIdentityNo=@PolicyOwnerIdentityNo"
        End If

        'plakano
        If HttpContext.Current.Session("plaka") <> "" Then
            sqldevam = sqldevam + " and PlateNumber=@PlateNumber"
        End If

        'ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerName=@ad"
        End If

        'soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerSurname=@soyad"
        End If

        Dim biryiloncesi As Date
        biryiloncesi = Date.Now.AddDays(-365)

        '"Convert(DATE,StartDate)<=@simdikitarih and Convert(DATE,EndDate)>=@simdikitarih " + _

        sqlstr = "select * from PolicyInfo where 1=1 " + _
        sqldevam + sqlteklestirdevam

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@simdikitarih", SqlDbType.DateTime)
        komut.Parameters("@simdikitarih").Value = Date.Now


        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlik") <> "" Then
            komut.Parameters.Add("@PolicyOwnerIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@PolicyOwnerIdentityNo").Value = HttpContext.Current.Session("kimlik")
        End If

        'plaka no seçilmişse
        If HttpContext.Current.Session("plaka") <> "" Then
            komut.Parameters.Add("@PlateNumber", SqlDbType.VarChar)
            komut.Parameters("@PlateNumber").Value = HttpContext.Current.Session("plaka")
        End If

        'ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@ad", SqlDbType.VarChar)
            komut.Parameters("@ad").Value = HttpContext.Current.Session("ad")
        End If

        'soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@soyad", SqlDbType.VarChar)
            komut.Parameters("@soyad").Value = HttpContext.Current.Session("soyad")
        End If

        girdi = "0"

        'primary key tanımlar ----
        Dim ProductCode, FirmCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String
        '-------------------------------------------------------------------------------------

        Dim ArrangeDate As String
        Dim StartDate, EndDate As String
        Dim AuthorizedDrivers, AuthorizedDrivers_aciklama As String
        Dim PolicyOwnerIdentityNo, PlateNumber As String
        Dim PublicValue, CurrencyCode As String

        Dim PolicyOwnerName As String
        Dim PolicyOwnerSurname As String

        Dim PolicyOwnerName_kisa As String
        Dim PolicyOwnerSurname_kisa As String

        Dim TariffCode As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        Dim link As String
        Dim dugme As String
        Dim renk As String
        Dim gosterilecekmi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    gosterilecekmi = "Hayır"

                    'PRIMARY KEY DOLDUR 
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = CStr(veri.Item("FirmCode"))
                    Else
                        FirmCode = ""
                    End If
                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = CStr(veri.Item("ProductCode"))
                    Else
                        ProductCode = ""
                    End If
                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = CStr(veri.Item("AgencyCode"))
                    Else
                        AgencyCode = ""
                    End If
                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = CStr(veri.Item("PolicyNumber"))
                    Else
                        PolicyNumber = ""
                    End If
                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = CStr(veri.Item("TecditNumber"))
                    Else
                        TecditNumber = ""
                    End If
                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        ZeylCode = CStr(veri.Item("ZeylCode"))
                    Else
                        ZeylCode = ""
                    End If
                    If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                        ZeylNo = CStr(veri.Item("ZeylNo"))
                    Else
                        ZeylNo = ""
                    End If
                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = CStr(veri.Item("ProductType"))
                    Else
                        ProductType = ""
                    End If
                    '----------------------------------------------------------

                    renk = renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

                    'dügme ------------------------------------
                    link = "policedetaysirket.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "ZeylCode=" + Trim(ZeylCode) + "&" + _
                    "ZeylNo=" + Trim(ZeylNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    dugme = "<span class='button'>Bilgiler</span>"

                    koldugme = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + _
                    dugme + "</a></td>"


                    If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                        TariffCode = CStr(veri.Item("TariffCode"))
                        kol1 = "<td>" + renklendir(TariffCode, renk) + "</td>"
                        saf1 = TariffCode
                    Else
                        kol1 = "<td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + renklendir(ProductCode, renk) + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_Erisim.bultek_sirketkodagore(FirmCode)
                        kol3 = "<td>" + renklendir(sirket.sirketad, renk) + "</td>"
                        saf3 = sirket.sirketad
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol4 = "<td>" + renklendir(AgencyCode, renk) + "</td>"
                        saf4 = AgencyCode
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol5 = "<td>" + renklendir(PolicyNumber, renk) + "</td>"
                        saf5 = PolicyNumber
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        StartDate = veri.Item("StartDate")
                        kol6 = "<td>" + StartDate + "</td>"
                        saf6 = StartDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        EndDate = veri.Item("EndDate")
                        kol7 = "<td>" + EndDate + "</td>"
                        saf7 = EndDate
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                        kol8 = "<td>" + TecditNumber + "</td>"
                        saf8 = TecditNumber
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If


                    If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                        AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                        If AuthorizedDrivers = "A" Then
                            AuthorizedDrivers_aciklama = "Herhangi Kişi"
                        End If
                        If AuthorizedDrivers = "N" Then
                            AuthorizedDrivers_aciklama = "İsme Göre"
                        End If
                        kol9 = "<td>" + AuthorizedDrivers_aciklama + "</td>"
                        saf9 = AuthorizedDrivers_aciklama
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If

                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                    Else
                        PolicyOwnerSurname = ""
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        PolicyOwnerName = veri.Item("PolicyOwnerName")    
                    Else
                        PolicyOwnerName = ""
                    End If

                    'şirketler sadece poliçe sahibinin adının ve soyadının baş harflerini görebilirler.
                    If Len(PolicyOwnerName) > 1 Then
                        PolicyOwnerName_kisa = Mid(PolicyOwnerName, 1, 1) + "."
                    End If
                    If Len(PolicyOwnerSurname) > 1 Then
                        PolicyOwnerSurname_kisa = Mid(PolicyOwnerSurname, 1, 1) + "."
                    End If


                    'şirket kullanıcısı şriket yöneticisi ve acente kullanıcısı ise sadece baş harfleri göster
                    If kullanicirol.tumsirketyetki = "Hayır" Then
                        kol10 = "<td>" + PolicyOwnerName_kisa + " " + PolicyOwnerSurname_kisa + "</td>"
                        saf10 = PolicyOwnerName_kisa + " " + PolicyOwnerSurname_kisa
                    Else
                        kol10 = "<td>" + PolicyOwnerName + " " + PolicyOwnerSurname + "</td>"
                        saf10 = PolicyOwnerName + " " + PolicyOwnerSurname
                    End If

                    'şirket kullanıcısı ve merkez şirket yöneticisi ise sadece yesil ve mavileri göster
                    If (renk = "green" Or renk = "blue" Or renk = "red") And _
                    (HttpContext.Current.Session("kullanici_rolpkey") = "3" Or HttpContext.Current.Session("kullanici_rolpkey") = "5") Then
                        gosterilecekmi = "Evet"
                    End If

                    'acente kullanıcısı ise sadece yesilleri göster
                    If renk = "green" And HttpContext.Current.Session("kullanici_rolpkey") = "4" Then
                        gosterilecekmi = "Evet"
                    End If

                    'birlik personeli ise sadece yeşilleri, mavileri
                    If (renk = "green" Or renk = "blue" Or renk = "red") And (HttpContext.Current.Session("kullanici_rolpkey") = "7") Then
                        gosterilecekmi = "Evet"
                    End If

                    'birlik personeli ve garanti fonu personeli ise örnek 'gülay kazma' yeşil mavi ve siyahlari göster ve polis kullanıcı ise
                    If (renk = "green" Or renk = "blue" Or renk = "black" Or renk = "red") And _
                    HttpContext.Current.Session("kullanici_pkey") = "81" And (HttpContext.Current.Session("kullanici_rolpkey") = "7") Then
                        gosterilecekmi = "Evet"
                    End If

                    'polis ise sadece yeşilleri, mavileri
                    If (renk = "green" Or renk = "blue" Or renk = "red") And (HttpContext.Current.Session("kullanici_rolpkey") = "9") Then
                        gosterilecekmi = "Evet"
                    End If

                    'eğer aktifse
                    If gosterilecekmi = "Evet" Then

                        satir = satir + koldugme + kol1 + kol2 + kol3 + kol4 + kol5 + _
                        kol6 + kol7 + kol8 + kol9 + kol10

                        table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10)

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

                    End If

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

        sqlstr = "select * from PolicyInfo where " + _
        "PolicyOwnerCountryCode=@kod " + _
        "or PlateCountryCode=@kod " + _
        "or CountryCode1=@kod " + _
        "or CountryCode2=@kod " + _
        "or CountryCode3=@kod " + _
        "or CountryCode4=@kod " + _
        "or CountryCode5=@kod " + _
        "or CountryCode6=@kod "

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
        Return varmi

    End Function

    Function zeylkodvarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where ZeylCode=@ZeylCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
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


    Function urunkodvarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where ProductCode=@ProductCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
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



    Function currencycodevarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where CurrencyCode=@CurrencyCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
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

    Function policytypevarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where PolicyType=@PolicyType"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@PolicyType", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
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


    'tanımlamalardan kimlik tür silmeye çalışırken bu fonksiyon ile kontrol yapılır.
    Function kimlikturvarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where " + _
        "PolicyOwnerIdentityCode=@kod " + _
        "or IdentityCode1=@kod " + _
        "or IdentityCode2=@kod " + _
        "or IdentityCode3=@kod " + _
        "or IdentityCode4=@kod " + _
        "or IdentityCode5=@kod " + _
        "or IdentityCode6=@kod "

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        Return varmi

    End Function



    '--- POLİÇEDE KAÇ ADET İPTAL ZEYİLİ VAR -------------------------------------------------------
    Function policede_iptalzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ProductType As String) As Integer

        Dim cnt As Integer = 0

        Dim policeninzeyilleri As New List(Of PolicyInfo)

        policeninzeyilleri = zeyildoldur_ilgilipolice_tecditli(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, TecditNumber, ProductType)

        For Each itemzeyil As PolicyInfo In policeninzeyilleri
            If itemzeyil.ZeylCode = "X" Or itemzeyil.ZeylCode = "x" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function


    '--- POLİÇEDE KAÇ ADET Y ZEYİLİ VAR -------------------------------------------------------
    Function policede_yzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ProductType As String) As Integer

        Dim cnt As Integer = 0
        Dim policeninzeyilleri As New List(Of PolicyInfo)

        policeninzeyilleri = zeyildoldur_ilgilipolice_tecditli(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, TecditNumber, ProductType)

        For Each itemzeyil As PolicyInfo In policeninzeyilleri
            If itemzeyil.ZeylCode = "Y" Or itemzeyil.ZeylCode = "y" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function


    '--- POLİÇEDE KAÇ ADET P ZEYİLİ VAR -------------------------------------------------------
    Function policede_pzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ProductType As String) As Integer

        Dim cnt As Integer = 0
        Dim policeninzeyilleri As New List(Of PolicyInfo)

        policeninzeyilleri = zeyildoldur_ilgilipolice_tecditli(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, TecditNumber, ProductType)

        For Each itemzeyil As PolicyInfo In policeninzeyilleri
            If itemzeyil.ZeylCode = "P" Or itemzeyil.ZeylCode = "p" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function



    '--- POLİÇEDE KAÇ ADET T ZEYİLİ VAR -------------------------------------------------------
    Function policede_tzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ProductType As String) As Integer

        Dim cnt As Integer = 0
        Dim policeninzeyilleri As New List(Of PolicyInfo)

        policeninzeyilleri = zeyildoldur_ilgilipolice_tecditli(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, TecditNumber, ProductType)

        For Each itemzeyil As PolicyInfo In policeninzeyilleri
            If itemzeyil.ZeylCode = "T" Or itemzeyil.ZeylCode = "t" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function



    Function zeyilnumarasi_aynimi(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim aynivarmi = "Hayır"

        Dim policeninzeyilleri As New List(Of PolicyInfo)
        policeninzeyilleri = zeyildoldur_ilgilipolice_tecditli(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, TecditNumber, ProductType)

        For Each itemzeyil As PolicyInfo In policeninzeyilleri
            If itemzeyil.ZeylNo = ZeylNo Then
                aynivarmi = "Evet"
                Exit For
            End If
        Next

        Return aynivarmi

    End Function


    Public Function renkbul(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal Zeylcode As String, ByVal ZeylNo As String, _
    ByVal ProductType As String) As String

        Dim StartDate, EndDate As Date
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim

        Dim i As Integer = 1
        Dim zeyilsayisi As Integer
        Dim donecekrenk As String = "black"
        Dim simdikitarih As Date
        simdikitarih = Date.Now

        Dim zeyiller As New List(Of PolicyInfo)

        Dim police As New PolicyInfo
        police = bultek(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
        TecditNumber, Zeylcode, ZeylNo, ProductType)

        Try
            StartDate = police.StartDate
            EndDate = police.EndDate
        Catch ex As Exception
            StartDate = Date.Now
            EndDate = Date.Now
        End Try

        'eğer tarihler kapsıyor sa
        If simdikitarih.Date >= StartDate.Date And simdikitarih.Date <= EndDate.Date Then
            donecekrenk = "green"
            zeyiller = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, PolicyNumber, ProductType)
            zeyilsayisi = zeyiller.Count
            For Each zeyilitem In zeyiller
                'en son zeyili iptal mi
                If i = zeyilsayisi Then
                    If zeyilitem.ZeylCode = "x" Or zeyilitem.ZeylCode = "X" Then
                        donecekrenk = "red"
                    End If
                End If
                i = i + 1
            Next

            'eğer iptal edilmemiş ise canlıdır
            If donecekrenk <> "red" Then
                donecekrenk = "green"
            End If
        End If


        'eğer ileriki bir tarihli poliçe ise
        If police.StartDate > simdikitarih And donecekrenk <> "red" Then
            donecekrenk = "blue"
        End If

        Return donecekrenk

    End Function


    Function renklendir(ByVal p_deger, ByVal p_renk) As String

        Dim donecek As String
        donecek = "<span style=color:" + p_renk + ";'>" + CStr(p_deger) + "</span>"
        Return donecek

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listelesilmeicin() As CLASSRAPOR


        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14 As String

        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String
        Dim sqlteklestirdevam As String
        Dim koldugme As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Bilgiler</th>" + _
        "<th>Tarife</th>" + _
        "<th>Ürün</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Başlangıç</th>" + _
        "<th>Bitiş</th>" + _
        "<th>Tecdit</th>" + _
        "<th>Kapsam</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kimlik</th>" + _
        "<th>Plaka</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife", GetType(String))
        table.Columns.Add("Ürün", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Poliçe", GetType(String))
        table.Columns.Add("Başlangıç", GetType(String))
        table.Columns.Add("Bitiş", GetType(String))
        table.Columns.Add("Tecdit", GetType(String))
        table.Columns.Add("Kapsam", GetType(String))
        table.Columns.Add("Ad Soyad", GetType(String))
        table.Columns.Add("Kimlik", GetType(String))
        table.Columns.Add("Plaka", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(12)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Başlangıç", fbaslik))
        pdftable.AddCell(New Phrase("Bitiş", fbaslik))
        pdftable.AddCell(New Phrase("Tecdit", fbaslik))
        pdftable.AddCell(New Phrase("Kapsam", fbaslik))
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

        'para birimi
        If HttpContext.Current.Session("parabirimi") <> "0" Then
            sqldevam = sqldevam + " and CurrencyCode=@CurrencyCode"
        End If

        'policeno
        If HttpContext.Current.Session("policeno") <> "" Then
            sqldevam = sqldevam + " and PolicyNumber=@PolicyNumber"
        End If

        'kimlikno
        If HttpContext.Current.Session("kimlikno") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerIdentityNo=@PolicyOwnerIdentityNo"
        End If

        'plakano
        If HttpContext.Current.Session("plakano") <> "" Then
            sqldevam = sqldevam + " and PlateNumber=@PlateNumber"
        End If

        'ad
        If HttpContext.Current.Session("ad") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerName LIKE '%'+@ad+'%'"
        End If

        'soyad
        If HttpContext.Current.Session("soyad") <> "" Then
            sqldevam = sqldevam + " and PolicyOwnerName LIKE '%'+@soyad+'%'"
        End If

        'tarife
        If HttpContext.Current.Session("tarife") <> "0" Then
            sqldevam = sqldevam + " and TariffCode=@TariffCode"
        End If

        'gun
        If HttpContext.Current.Session("gun") <> "" Then
            sqldevam = sqldevam + " and DATEDIFF(day,StartDate,EndDate)=" + HttpContext.Current.Session("gun")
        End If

        'zeylcode
        If HttpContext.Current.Session("zeylcode") = "P veya T" Then
            sqldevam = sqldevam + " and (ZeylCode='P' or ZeylCode='T')"
        End If

        If HttpContext.Current.Session("zeylcode") <> "0" And _
        HttpContext.Current.Session("zeylcode") <> "P veya T" Then
            sqldevam = sqldevam + " and ZeylCode=@ZeylCode"
        End If

        sqlstr = "select * from PolicyInfo where " + _
        "(Convert(DATE,StartDate)>=@baslangic and Convert(DATE,StartDate)<=@bitis)" + _
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

        'para birimi seçilmişse
        If HttpContext.Current.Session("parabirimi") <> "0" Then
            komut.Parameters.Add("@CurrencyCode", SqlDbType.VarChar)
            komut.Parameters("@CurrencyCode").Value = HttpContext.Current.Session("parabirimi")
        End If

        'police no seçilmişse
        If HttpContext.Current.Session("policeno") <> "" Then
            komut.Parameters.Add("@PolicyNumber", SqlDbType.VarChar)
            komut.Parameters("@PolicyNumber").Value = HttpContext.Current.Session("policeno")
        End If

        'kimlik no seçilmişse
        If HttpContext.Current.Session("kimlikno") <> "" Then
            komut.Parameters.Add("@PolicyOwnerIdentityNo", SqlDbType.VarChar)
            komut.Parameters("@PolicyOwnerIdentityNo").Value = HttpContext.Current.Session("kimlikno")
        End If

        'plaka no seçilmişse
        If HttpContext.Current.Session("plakano") <> "" Then
            komut.Parameters.Add("@PlateNumber", SqlDbType.VarChar)
            komut.Parameters("@PlateNumber").Value = HttpContext.Current.Session("plakano")
        End If

        'ad seçilmiş ise
        If HttpContext.Current.Session("ad") <> "" Then
            komut.Parameters.Add("@ad", SqlDbType.VarChar)
            komut.Parameters("@ad").Value = HttpContext.Current.Session("ad")
        End If

        'soyad seçilmiş ise
        If HttpContext.Current.Session("soyad") <> "" Then
            komut.Parameters.Add("@soyad", SqlDbType.VarChar)
            komut.Parameters("@soyad").Value = HttpContext.Current.Session("soyad")
        End If

        'tarife seçilmiş ise
        If HttpContext.Current.Session("tarife") <> "0" Then
            komut.Parameters.Add("@TariffCode", SqlDbType.VarChar)
            komut.Parameters("@TariffCode").Value = HttpContext.Current.Session("tarife")
        End If

        'zeylcode seçilmiş ise
        If HttpContext.Current.Session("zeylcode") <> "0" And _
        HttpContext.Current.Session("zeylcode") <> "P veya T" Then
            komut.Parameters.Add("@ZeylCode", SqlDbType.VarChar)
            komut.Parameters("@ZeylCode").Value = HttpContext.Current.Session("zeylcode")
        End If

        girdi = "0"

        'primary key tanımlar ----
        Dim ProductCode, FirmCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String
        '-------------------------------------------

        Dim ArrangeDate As String
        Dim StartDate, EndDate As String
        Dim AuthorizedDrivers, AuthorizedDrivers_aciklama As String
        Dim PolicyOwnerName, PolicyOwnerIdentityNo, PlateNumber As String
        Dim PublicValue, CurrencyCode As String
        Dim PolicyOwnerSurname As String

        Dim TariffCode As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        Dim renk As String

        Dim link As String
        Dim dugme As String
        Dim linksil, dugmesil As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"


                    'PRIMARY KEY DOLDUR 
                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = CStr(veri.Item("FirmCode"))
                    Else
                        FirmCode = ""
                    End If
                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = CStr(veri.Item("ProductCode"))
                    Else
                        ProductCode = ""
                    End If
                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = CStr(veri.Item("AgencyCode"))
                    Else
                        AgencyCode = ""
                    End If
                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = CStr(veri.Item("PolicyNumber"))
                    Else
                        PolicyNumber = ""
                    End If
                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = CStr(veri.Item("TecditNumber"))
                    Else
                        TecditNumber = ""
                    End If
                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        ZeylCode = CStr(veri.Item("ZeylCode"))
                    Else
                        ZeylCode = ""
                    End If
                    If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                        ZeylNo = CStr(veri.Item("ZeylNo"))
                    Else
                        ZeylNo = ""
                    End If
                    If Not veri.Item("ProductType") Is System.DBNull.Value Then
                        ProductType = CStr(veri.Item("ProductType"))
                    Else
                        ProductType = ""
                    End If
                    '----------------------------------------------------------

                    'renk bul -------------- 
                    renk = renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

                    'dügme ------------------------------------
                    link = "policedetay.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "ZeylCode=" + Trim(ZeylCode) + "&" + _
                    "ZeylNo=" + Trim(ZeylNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    'link = HttpContext.Current.Server.UrlEncode(link)

                    dugme = "<span class='button'>Bilgiler</span>"

                    koldugme = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + _
                    dugme + "</a></td>"


                    If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                        TariffCode = CStr(veri.Item("TariffCode"))
                        kol1 = "<td>" + renklendir(TariffCode, renk) + "</td>"
                        saf1 = TariffCode
                    Else
                        kol1 = "<td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + renklendir(ProductCode, renk) + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_Erisim.bultek_sirketkodagore(FirmCode)
                        kol3 = "<td>" + renklendir(sirket.sirketad, renk) + "</td>"
                        saf3 = sirket.sirketad
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol4 = "<td>" + renklendir(AgencyCode, renk) + "</td>"
                        saf4 = AgencyCode
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol5 = "<td>" + renklendir(PolicyNumber, renk) + "</td>"
                        saf5 = PolicyNumber
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If


                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        StartDate = veri.Item("StartDate")
                        kol6 = "<td>" + StartDate + "</td>"
                        saf6 = StartDate
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        EndDate = veri.Item("EndDate")
                        kol7 = "<td>" + EndDate + "</td>"
                        saf7 = EndDate
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                        kol8 = "<td>" + TecditNumber + "</td>"
                        saf8 = TecditNumber
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If


                    If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                        AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                        If AuthorizedDrivers = "A" Then
                            AuthorizedDrivers_aciklama = "Herhangi Kişi"
                        End If
                        If AuthorizedDrivers = "N" Then
                            AuthorizedDrivers_aciklama = "İsme Göre"
                        End If
                        kol9 = "<td>" + AuthorizedDrivers_aciklama + "</td>"
                        saf9 = AuthorizedDrivers_aciklama
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If


                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                    Else
                        PolicyOwnerSurname = ""
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        PolicyOwnerName = veri.Item("PolicyOwnerName")
                        kol10 = "<td>" + PolicyOwnerName + " " + PolicyOwnerSurname + "</td>"
                        saf10 = PolicyOwnerName + " " + PolicyOwnerSurname
                    Else
                        kol10 = "<td>-</td>"
                        saf10 = "-"
                    End If


                    If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                        PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                        kol11 = "<td>" + PolicyOwnerIdentityNo + "</td>"
                        saf11 = PolicyOwnerIdentityNo
                    Else
                        kol11 = "<td>-</td>"
                        saf11 = "-"
                    End If


                    If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                        PlateNumber = veri.Item("PlateNumber")
                        kol12 = "<td>" + PlateNumber + "</td>"
                        saf12 = PlateNumber
                    Else
                        kol12 = "<td>-</td>"
                        saf12 = "-"
                    End If

                    'SİLME KOLONU ---------------------------------------------------------------
                    linksil = "policesilyap.aspx?" + _
                    "FirmCode=" + Trim(FirmCode) + "&" + _
                    "ProductCode=" + Trim(ProductCode) + "&" + _
                    "AgencyCode=" + Trim(AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(TecditNumber) + "&" + _
                    "ZeylCode=" + Trim(ZeylCode) + "&" + _
                    "ZeylNo=" + Trim(ZeylNo) + "&" + _
                    "ProductType=" + Trim(ProductType)

                    dugmesil = "<button class='btn btn-sm red filter-cancel'>" + _
                    "<i class='fa fa-times'></i> Sil</button>"

                    kol13 = "<td><span class='iframeyenikayit' href=" + linksil + ">" + _
                    dugmesil + "</a></td></tr>"


                    satir = satir + koldugme + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + _
                    kol11 + kol12 + kol13


                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10, _
                    saf11, saf12)

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
                    pdftable.AddCell(New Phrase(saf11, fdata))
                    pdftable.AddCell(New Phrase(saf12, fdata))

                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function



    Public Function xmlolustur(ByVal PolicyInfo As PolicyInfo) As String

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim donecekxml As String = ""

        donecekxml = "<root>" + _
        "<PolicyInfo FirmCode=" + Chr(34) + CStr(PolicyInfo.FirmCode) + Chr(34) + " " + _
        "ProductCode=" + Chr(34) + CStr(PolicyInfo.ProductCode) + Chr(34) + " " + _
        "AgencyCode=" + Chr(34) + CStr(PolicyInfo.AgencyCode) + Chr(34) + " " + _
        "PolicyNumber=" + Chr(34) + CStr(PolicyInfo.PolicyNumber) + Chr(34) + " " + _
        "TecditNumber=" + Chr(34) + CStr(PolicyInfo.TecditNumber) + Chr(34) + " " + _
        "ZeylCode=" + Chr(34) + CStr(PolicyInfo.ZeylCode) + Chr(34) + " " + _
        "ZeylNo=" + Chr(34) + CStr(PolicyInfo.ZeylNo) + Chr(34) + " " + _
        "PolicyOwnerCountryCode=" + Chr(34) + CStr(PolicyInfo.PolicyOwnerCountryCode) + Chr(34) + " " + _
        "PolicyOwnerIdentityCode=" + Chr(34) + CStr(PolicyInfo.PolicyOwnerIdentityCode) + Chr(34) + " " + _
        "PolicyOwnerIdentityNo=" + Chr(34) + CStr(PolicyInfo.PolicyOwnerIdentityNo) + Chr(34) + " " + _
        "PolicyOwnerName=" + Chr(34) + CStr(PolicyInfo.PolicyOwnerName) + Chr(34) + " " + _
        "PolicyOwnerSurname=" + Chr(34) + CStr(PolicyInfo.PolicyOwnerSurname) + Chr(34) + " " + _
        "PolicyOwnerBirthDate=" + Chr(34) + CStr(PolicyInfo.PolicyOwnerBirthDate) + Chr(34) + " " + _
        "AddressLine1=" + Chr(34) + CStr(PolicyInfo.AddressLine1) + Chr(34) + " " + _
        "AddressLine2=" + Chr(34) + CStr(PolicyInfo.AddressLine2) + Chr(34) + " " + _
        "AddressLine3=" + Chr(34) + CStr(PolicyInfo.AddressLine3) + Chr(34) + " " + _
        "PlateCountryCode=" + Chr(34) + CStr(PolicyInfo.PlateCountryCode) + Chr(34) + " " + _
        "PlateNumber=" + Chr(34) + CStr(PolicyInfo.PlateNumber) + Chr(34) + " " + _
        "Brand=" + Chr(34) + CStr(PolicyInfo.Brand) + Chr(34) + " " + _
        "Model=" + Chr(34) + CStr(PolicyInfo.Model) + Chr(34) + " " + _
        "ChassisNumber=" + Chr(34) + CStr(PolicyInfo.ChassisNumber) + Chr(34) + " " + _
        "EngineNumber=" + Chr(34) + CStr(PolicyInfo.EngineNumber) + Chr(34) + " " + _
        "EnginePower=" + Chr(34) + CStr(PolicyInfo.EnginePower) + Chr(34) + " " + _
        "ProductionYear=" + Chr(34) + CStr(PolicyInfo.ProductionYear) + Chr(34) + " " + _
        "Capacity=" + Chr(34) + CStr(PolicyInfo.Capacity) + Chr(34) + " " + _
        "CarType=" + Chr(34) + CStr(PolicyInfo.CarType) + Chr(34) + " " + _
        "UsingStyle=" + Chr(34) + CStr(PolicyInfo.UsingStyle) + Chr(34) + " " + _
        "TariffCode=" + Chr(34) + CStr(PolicyInfo.TariffCode) + Chr(34) + " " + _
        "ArrangeDate=" + Chr(34) + CStr(PolicyInfo.ArrangeDate) + Chr(34) + " " + _
        "StartDate=" + Chr(34) + CStr(PolicyInfo.StartDate) + Chr(34) + " " + _
        "EndDate=" + Chr(34) + CStr(PolicyInfo.EndDate) + Chr(34) + " " + _
        "Material=" + Chr(34) + CStr(PolicyInfo.Material) + Chr(34) + " " + _
        "Corporal=" + Chr(34) + CStr(PolicyInfo.Corporal) + Chr(34) + " " + _
        "CurrencyCode=" + Chr(34) + CStr(PolicyInfo.CurrencyCode) + Chr(34) + " " + _
        "PublicValue=" + Chr(34) + CStr(PolicyInfo.PublicValue) + Chr(34) + " " + _
        "AuthorizedDrivers=" + Chr(34) + CStr(PolicyInfo.AuthorizedDrivers) + Chr(34) + " " + _
        "CountryCode1=" + Chr(34) + CStr(PolicyInfo.CountryCode1) + Chr(34) + " " + _
        "IdentityCode1=" + Chr(34) + CStr(PolicyInfo.IdentityCode1) + Chr(34) + " " + _
        "IdentityNo1=" + Chr(34) + CStr(PolicyInfo.IdentityNo1) + Chr(34) + " " + _
        "Name1=" + Chr(34) + CStr(PolicyInfo.Name1) + Chr(34) + " " + _
        "Surname1=" + Chr(34) + CStr(PolicyInfo.Surname1) + Chr(34) + " " + _
        "BirthDate1=" + Chr(34) + CStr(PolicyInfo.BirthDate1) + Chr(34) + " " + _
        "DriverLicenceNo1=" + Chr(34) + CStr(PolicyInfo.DriverLicenceNo1) + Chr(34) + " " + _
        "DriverLicenceGivenDate1=" + Chr(34) + CStr(PolicyInfo.DriverLicenceGivenDate1) + Chr(34) + " " + _
        "DriverLicenceType1=" + Chr(34) + CStr(PolicyInfo.DriverLicenceType1) + Chr(34) + " " + _
        "CountryCode2=" + Chr(34) + CStr(PolicyInfo.CountryCode2) + Chr(34) + " " + _
        "IdentityCode2=" + Chr(34) + CStr(PolicyInfo.IdentityCode2) + Chr(34) + " " + _
        "IdentityNo2=" + Chr(34) + CStr(PolicyInfo.IdentityNo2) + Chr(34) + " " + _
        "Name2=" + Chr(34) + CStr(PolicyInfo.Name2) + Chr(34) + " " + _
        "Surname2=" + Chr(34) + CStr(PolicyInfo.Surname2) + Chr(34) + " " + _
        "BirthDate2=" + Chr(34) + CStr(PolicyInfo.BirthDate2) + Chr(34) + " " + _
        "DriverLicenceNo2=" + Chr(34) + CStr(PolicyInfo.DriverLicenceNo2) + Chr(34) + " " + _
        "DriverLicenceGivenDate2=" + Chr(34) + CStr(PolicyInfo.DriverLicenceGivenDate2) + Chr(34) + " " + _
        "DriverLicenceType2=" + Chr(34) + CStr(PolicyInfo.DriverLicenceType2) + Chr(34) + " " + _
        "CountryCode3=" + Chr(34) + CStr(PolicyInfo.CountryCode3) + Chr(34) + " " + _
        "IdentityCode3=" + Chr(34) + CStr(PolicyInfo.IdentityCode3) + Chr(34) + " " + _
        "IdentityNo3=" + Chr(34) + CStr(PolicyInfo.IdentityNo3) + Chr(34) + " " + _
        "Name3=" + Chr(34) + CStr(PolicyInfo.Name3) + Chr(34) + " " + _
        "Surname3=" + Chr(34) + CStr(PolicyInfo.Surname3) + Chr(34) + " " + _
        "BirthDate3=" + Chr(34) + CStr(PolicyInfo.BirthDate3) + Chr(34) + " " + _
        "DriverLicenceNo3=" + Chr(34) + CStr(PolicyInfo.DriverLicenceNo3) + Chr(34) + " " + _
        "DriverLicenceGivenDate3=" + Chr(34) + CStr(PolicyInfo.DriverLicenceGivenDate3) + Chr(34) + " " + _
        "DriverLicenceType3=" + Chr(34) + CStr(PolicyInfo.DriverLicenceType3) + Chr(34) + " " + _
        "CountryCode4=" + Chr(34) + CStr(PolicyInfo.CountryCode4) + Chr(34) + " " + _
        "IdentityCode4=" + Chr(34) + CStr(PolicyInfo.IdentityCode4) + Chr(34) + " " + _
        "IdentityNo4=" + Chr(34) + CStr(PolicyInfo.IdentityNo4) + Chr(34) + " " + _
        "Name4=" + Chr(34) + CStr(PolicyInfo.Name4) + Chr(34) + " " + _
        "Surname4=" + Chr(34) + CStr(PolicyInfo.Surname4) + Chr(34) + " " + _
        "BirthDate4=" + Chr(34) + CStr(PolicyInfo.BirthDate4) + Chr(34) + " " + _
        "DriverLicenceNo4=" + Chr(34) + CStr(PolicyInfo.DriverLicenceNo4) + Chr(34) + " " + _
        "DriverLicenceGivenDate4=" + Chr(34) + CStr(PolicyInfo.DriverLicenceGivenDate4) + Chr(34) + " " + _
        "DriverLicenceType4=" + Chr(34) + CStr(PolicyInfo.DriverLicenceType4) + Chr(34) + " " + _
        "CountryCode5=" + Chr(34) + CStr(PolicyInfo.CountryCode5) + Chr(34) + " " + _
        "IdentityCode5=" + Chr(34) + CStr(PolicyInfo.IdentityCode5) + Chr(34) + " " + _
        "IdentityNo5=" + Chr(34) + CStr(PolicyInfo.IdentityNo5) + Chr(34) + " " + _
        "Name5=" + Chr(34) + CStr(PolicyInfo.Name5) + Chr(34) + " " + _
        "Surname5=" + Chr(34) + CStr(PolicyInfo.Surname5) + Chr(34) + " " + _
        "BirthDate5=" + Chr(34) + CStr(PolicyInfo.BirthDate5) + Chr(34) + " " + _
        "DriverLicenceNo5=" + Chr(34) + CStr(PolicyInfo.DriverLicenceNo5) + Chr(34) + " " + _
        "DriverLicenceGivenDate5=" + Chr(34) + CStr(PolicyInfo.DriverLicenceGivenDate5) + Chr(34) + " " + _
        "DriverLicenceType5=" + Chr(34) + CStr(PolicyInfo.DriverLicenceType5) + Chr(34) + " " + _
        "CountryCode6=" + Chr(34) + CStr(PolicyInfo.CountryCode6) + Chr(34) + " " + _
        "IdentityCode6=" + Chr(34) + CStr(PolicyInfo.IdentityCode6) + Chr(34) + " " + _
        "IdentityNo6=" + Chr(34) + CStr(PolicyInfo.IdentityNo6) + Chr(34) + " " + _
        "Name6=" + Chr(34) + CStr(PolicyInfo.Name6) + Chr(34) + " " + _
        "Surname6=" + Chr(34) + CStr(PolicyInfo.Surname6) + Chr(34) + " " + _
        "BirthDate6=" + Chr(34) + CStr(PolicyInfo.BirthDate6) + Chr(34) + " " + _
        "DriverLicenceNo6=" + Chr(34) + CStr(PolicyInfo.DriverLicenceNo6) + Chr(34) + " " + _
        "DriverLicenceGivenDate6=" + Chr(34) + CStr(PolicyInfo.DriverLicenceGivenDate6) + Chr(34) + " " + _
        "DriverLicenceType6=" + Chr(34) + CStr(PolicyInfo.DriverLicenceType6) + Chr(34) + " " + _
        "InsurancePremium=" + Chr(34) + CStr(PolicyInfo.InsurancePremium) + Chr(34) + " " + _
        "AssistantFees=" + Chr(34) + CStr(PolicyInfo.AssistantFees) + Chr(34) + " " + _
        "OtherFees=" + Chr(34) + CStr(PolicyInfo.OtherFees) + Chr(34) + " " + _
        "BasePriceValue=" + Chr(34) + CStr(PolicyInfo.BasePriceValue) + Chr(34) + " " + _
        "CCRateValue=" + Chr(34) + CStr(PolicyInfo.CCRateValue) + Chr(34) + " " + _
        "DamageRateValue=" + Chr(34) + CStr(PolicyInfo.DamageRateValue) + Chr(34) + " " + _
        "AgeRateValue=" + Chr(34) + CStr(PolicyInfo.AgeRateValue) + Chr(34) + " " + _
        "DamagelessRateValue=" + Chr(34) + CStr(PolicyInfo.DamagelessRateValue) + Chr(34) + " " + _
        "PolicyType=" + Chr(34) + CStr(PolicyInfo.PolicyType) + Chr(34) + " " + _
        "ProductType=" + Chr(34) + CStr(PolicyInfo.ProductType) + Chr(34) + " " + _
        "FuelType = " + Chr(34) + CStr(PolicyInfo.FuelType) + Chr(34) + " " + _
        "SteeringSide = " + Chr(34) + CStr(PolicyInfo.SteeringSide) + Chr(34) + " " + _
        "AnyDriverRateValue = " + Chr(34) + CStr(PolicyInfo.AnyDriverRateValue) + Chr(34) + " " + _
        "PolicyPremium = " + Chr(34) + CStr(PolicyInfo.PolicyPremium) + Chr(34) + " " + _
        "PolicyPremiumTL = " + Chr(34) + CStr(PolicyInfo.PolicyPremiumTL) + Chr(34) + " " + _
        "InsurancePremiumTL = " + Chr(34) + CStr(PolicyInfo.InsurancePremiumTL) + Chr(34) + " " + _
        "PublicValueTL = " + Chr(34) + CStr(PolicyInfo.PublicValueTL) + Chr(34) + " " + _
        "DamageRate = " + Chr(34) + CStr(PolicyInfo.DamageRate) + Chr(34) + " " + _
        "DamagelessRate = " + Chr(34) + CStr(PolicyInfo.DamagelessRate) + Chr(34) + " " + _
        "AnyDriverRate = " + Chr(34) + CStr(PolicyInfo.AnyDriverRate) + Chr(34) + " " + _
        "AgeRate = " + Chr(34) + CStr(PolicyInfo.AgeRate) + Chr(34) + " " + _
        "CCRate = " + Chr(34) + CStr(PolicyInfo.CCRate) + Chr(34) + " " + _
        "SBMCode = " + Chr(34) + CStr(PolicyInfo.SBMCode) + Chr(34) + " " + _
        "Creditor = " + Chr(34) + CStr(PolicyInfo.Creditor) + Chr(34) + " " + _
        "FirstBeneficiary = " + Chr(34) + CStr(PolicyInfo.FirstBeneficiary) + Chr(34) + " " + _
        "ExchangeRate = " + Chr(34) + CStr(PolicyInfo.ExchangeRate) + Chr(34) + " " + _
        "AgencyRegisterCode = " + Chr(34) + CStr(PolicyInfo.AgencyRegisterCode) + Chr(34) + " " + _
        "TPNo = " + Chr(34) + CStr(PolicyInfo.TPNo) + Chr(34) + " " + _
        "></PolicyInfo></root>"

        Return donecekxml

    End Function



    '--- ŞİRKETİN KAÇ POLİÇESİ VAR -------------------------------------------------------
    Function policeadet_sirketin(ByVal FirmCode As String) As Integer

        Dim sqlstr As String
        Dim kacadet As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from PolicyInfo where FirmCode=@FirmCode"
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


End Class
