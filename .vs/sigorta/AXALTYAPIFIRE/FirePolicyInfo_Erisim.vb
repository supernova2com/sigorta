Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class FirePolicyInfo_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim FirePolicyInfo As New FirePolicyInfo
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal FirePolicyInfo As FirePolicyInfo) As CLADBOPRESULT

        etkilenen = 0
        Dim eklenenpkey As Integer

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into FirePolicyInfo values (@pkey," +
            "@FirmCode,@ProductCode,@AgencyCode,@PolicyNumber," +
            "@TecditNumber,@ZeylCode,@ZeyilNo,@PolicyType," +
            "@ArrangeDate,@StartDate,@EndDate,@PolicyOwnerCountryCode," +
            "@PolicyOwnerIdentityCode,@PolicyOwnerIdentityNo,@PolicyOwnerName,@PolicyOwnerSurname," +
            "@InsuredTitle,@RiskAddress_ilcekod,@RiskAddress_bucakkod,@RiskAddress_belediyekod," +
            "@RiskAddress_mahallekod,@RiskAddress_sokakkod,@FirstBeneficiary,@Creditor," +
            "@RiskType,@StructureStyle,@OfficeBlock,@Activity," +
            "@AgencyRegisterCode,@TPNo,@Building,@Contents," +
            "@EartQuake,@FloodFlooding,@InternalWater,@Storm," +
            "@Theft,@LandVehicles,@AirCraft,@MaritimeVehicles," +
            "@Smoke,@SpaceShift,@GLKHH,@MaliciousTerror," +
            "@OtherGuarentees,@Latitude,@Longitude,@BuildingValue," +
            "@ContentsValue,@CurrencyCode,@ExchangeRate,@FirePremium," +
            "@SupplementaryGuaranteePremium,@EarthquakePremium,@OtherFees,@TotalPremium," +
            "@FirePremiumTL,@SupplementaryGuaranteePremiumTL,@EarthquakePremiumTL,@OtherFeesTL," +
            "@TotalPremiumTL,@PolicyPremiumTL,@Color,@FSBMCode)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
            param2.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirmCode = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = FirePolicyInfo.FirmCode
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
            param3.Direction = ParameterDirection.Input
            If FirePolicyInfo.ProductCode = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = FirePolicyInfo.ProductCode
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
            param4.Direction = ParameterDirection.Input
            If FirePolicyInfo.AgencyCode = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = FirePolicyInfo.AgencyCode
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
            param5.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyNumber = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = FirePolicyInfo.PolicyNumber
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
            param6.Direction = ParameterDirection.Input
            If FirePolicyInfo.TecditNumber = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = FirePolicyInfo.TecditNumber
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@ZeylCode", SqlDbType.VarChar, 1)
            param7.Direction = ParameterDirection.Input
            If FirePolicyInfo.ZeylCode = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = FirePolicyInfo.ZeylCode
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@ZeyilNo", SqlDbType.VarChar, 15)
            param8.Direction = ParameterDirection.Input
            If FirePolicyInfo.ZeyilNo = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = FirePolicyInfo.ZeyilNo
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@PolicyType", SqlDbType.Int)
            param9.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyType = 0 Then
                param9.Value = 0
            Else
                param9.Value = FirePolicyInfo.PolicyType
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@ArrangeDate", SqlDbType.DateTime)
            param10.Direction = ParameterDirection.Input
            If FirePolicyInfo.ArrangeDate Is Nothing Or FirePolicyInfo.ArrangeDate = "00:00:00" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = FirePolicyInfo.ArrangeDate
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@StartDate", SqlDbType.DateTime)
            param11.Direction = ParameterDirection.Input
            If FirePolicyInfo.StartDate Is Nothing Or FirePolicyInfo.StartDate = "00:00:00" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = FirePolicyInfo.StartDate
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@EndDate", SqlDbType.DateTime)
            param12.Direction = ParameterDirection.Input
            If FirePolicyInfo.EndDate Is Nothing Or FirePolicyInfo.EndDate = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = FirePolicyInfo.EndDate
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@PolicyOwnerCountryCode", SqlDbType.VarChar, 3)
            param13.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerCountryCode = "" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = FirePolicyInfo.PolicyOwnerCountryCode
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@PolicyOwnerIdentityCode", SqlDbType.VarChar, 2)
            param14.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerIdentityCode = "" Then
                param14.Value = System.DBNull.Value
            Else
                param14.Value = FirePolicyInfo.PolicyOwnerIdentityCode
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@PolicyOwnerIdentityNo", SqlDbType.VarChar, 15)
            param15.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerIdentityNo = "" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = FirePolicyInfo.PolicyOwnerIdentityNo
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@PolicyOwnerName", SqlDbType.VarChar, 50)
            param16.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerName = "" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = FirePolicyInfo.PolicyOwnerName
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@PolicyOwnerSurname", SqlDbType.VarChar, 30)
            param17.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerSurname = "" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = FirePolicyInfo.PolicyOwnerSurname
            End If
            komut.Parameters.Add(param17)

            Dim param18 As New SqlParameter("@InsuredTitle", SqlDbType.Int)
            param18.Direction = ParameterDirection.Input
            If FirePolicyInfo.InsuredTitle = 0 Then
                param18.Value = 0
            Else
                param18.Value = FirePolicyInfo.InsuredTitle
            End If
            komut.Parameters.Add(param18)

            Dim param19 As New SqlParameter("@RiskAddress_ilcekod", SqlDbType.Int)
            param19.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_ilcekod = 0 Then
                param19.Value = 0
            Else
                param19.Value = FirePolicyInfo.RiskAddress_ilcekod
            End If
            komut.Parameters.Add(param19)

            Dim param20 As New SqlParameter("@RiskAddress_bucakkod", SqlDbType.Int)
            param20.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_bucakkod = 0 Then
                param20.Value = 0
            Else
                param20.Value = FirePolicyInfo.RiskAddress_bucakkod
            End If
            komut.Parameters.Add(param20)

            Dim param21 As New SqlParameter("@RiskAddress_belediyekod", SqlDbType.Int)
            param21.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_belediyekod = 0 Then
                param21.Value = 0
            Else
                param21.Value = FirePolicyInfo.RiskAddress_belediyekod
            End If
            komut.Parameters.Add(param21)

            Dim param22 As New SqlParameter("@RiskAddress_mahallekod", SqlDbType.Int)
            param22.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_mahallekod = 0 Then
                param22.Value = 0
            Else
                param22.Value = FirePolicyInfo.RiskAddress_mahallekod
            End If
            komut.Parameters.Add(param22)

            Dim param23 As New SqlParameter("@RiskAddress_sokakkod", SqlDbType.Int)
            param23.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_sokakkod = 0 Then
                param23.Value = 0
            Else
                param23.Value = FirePolicyInfo.RiskAddress_sokakkod
            End If
            komut.Parameters.Add(param23)

            Dim param24 As New SqlParameter("@FirstBeneficiary", SqlDbType.VarChar, 15)
            param24.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirstBeneficiary = "" Then
                param24.Value = System.DBNull.Value
            Else
                param24.Value = FirePolicyInfo.FirstBeneficiary
            End If
            komut.Parameters.Add(param24)

            Dim param25 As New SqlParameter("@Creditor", SqlDbType.Bit)
            param25.Direction = ParameterDirection.Input
            If FirePolicyInfo.Creditor = 0 Then
                param25.Value = 0
            Else
                param25.Value = FirePolicyInfo.Creditor
            End If
            komut.Parameters.Add(param25)

            Dim param26 As New SqlParameter("@RiskType", SqlDbType.Int)
            param26.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskType = 0 Then
                param26.Value = 0
            Else
                param26.Value = FirePolicyInfo.RiskType
            End If
            komut.Parameters.Add(param26)

            Dim param27 As New SqlParameter("@StructureStyle", SqlDbType.Int)
            param27.Direction = ParameterDirection.Input
            If FirePolicyInfo.StructureStyle = 0 Then
                param27.Value = 0
            Else
                param27.Value = FirePolicyInfo.StructureStyle
            End If
            komut.Parameters.Add(param27)

            Dim param28 As New SqlParameter("@OfficeBlock", SqlDbType.Int)
            param28.Direction = ParameterDirection.Input
            If FirePolicyInfo.OfficeBlock = 0 Then
                param28.Value = 0
            Else
                param28.Value = FirePolicyInfo.OfficeBlock
            End If
            komut.Parameters.Add(param28)

            Dim param29 As New SqlParameter("@Activity", SqlDbType.VarChar, 50)
            param29.Direction = ParameterDirection.Input
            If FirePolicyInfo.Activity = "" Then
                param29.Value = System.DBNull.Value
            Else
                param29.Value = FirePolicyInfo.Activity
            End If
            komut.Parameters.Add(param29)

            Dim param30 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar, 20)
            param30.Direction = ParameterDirection.Input
            If FirePolicyInfo.AgencyRegisterCode = "" Then
                param30.Value = System.DBNull.Value
            Else
                param30.Value = FirePolicyInfo.AgencyRegisterCode
            End If
            komut.Parameters.Add(param30)

            Dim param31 As New SqlParameter("@TPNo", SqlDbType.VarChar, 20)
            param31.Direction = ParameterDirection.Input
            If FirePolicyInfo.TPNo = "" Then
                param31.Value = System.DBNull.Value
            Else
                param31.Value = FirePolicyInfo.TPNo
            End If
            komut.Parameters.Add(param31)

            Dim param32 As New SqlParameter("@Building", SqlDbType.Bit)
            param32.Direction = ParameterDirection.Input
            If FirePolicyInfo.Building = 0 Then
                param32.Value = 0
            Else
                param32.Value = FirePolicyInfo.Building
            End If
            komut.Parameters.Add(param32)

            Dim param33 As New SqlParameter("@Contents", SqlDbType.Bit)
            param33.Direction = ParameterDirection.Input
            If FirePolicyInfo.Contents = 0 Then
                param33.Value = 0
            Else
                param33.Value = FirePolicyInfo.Contents
            End If
            komut.Parameters.Add(param33)

            Dim param34 As New SqlParameter("@EartQuake", SqlDbType.Bit)
            param34.Direction = ParameterDirection.Input
            If FirePolicyInfo.EartQuake = 0 Then
                param34.Value = 0
            Else
                param34.Value = FirePolicyInfo.EartQuake
            End If
            komut.Parameters.Add(param34)

            Dim param35 As New SqlParameter("@FloodFlooding", SqlDbType.Bit)
            param35.Direction = ParameterDirection.Input
            If FirePolicyInfo.FloodFlooding = 0 Then
                param35.Value = 0
            Else
                param35.Value = FirePolicyInfo.FloodFlooding
            End If
            komut.Parameters.Add(param35)

            Dim param36 As New SqlParameter("@InternalWater", SqlDbType.Bit)
            param36.Direction = ParameterDirection.Input
            If FirePolicyInfo.InternalWater = 0 Then
                param36.Value = 0
            Else
                param36.Value = FirePolicyInfo.InternalWater
            End If
            komut.Parameters.Add(param36)

            Dim param37 As New SqlParameter("@Storm", SqlDbType.Bit)
            param37.Direction = ParameterDirection.Input
            If FirePolicyInfo.Storm = 0 Then
                param37.Value = 0
            Else
                param37.Value = FirePolicyInfo.Storm
            End If
            komut.Parameters.Add(param37)

            Dim param38 As New SqlParameter("@Theft", SqlDbType.Bit)
            param38.Direction = ParameterDirection.Input
            If FirePolicyInfo.Theft = 0 Then
                param38.Value = 0
            Else
                param38.Value = FirePolicyInfo.Theft
            End If
            komut.Parameters.Add(param38)

            Dim param39 As New SqlParameter("@LandVehicles", SqlDbType.Bit)
            param39.Direction = ParameterDirection.Input
            If FirePolicyInfo.LandVehicles = 0 Then
                param39.Value = 0
            Else
                param39.Value = FirePolicyInfo.LandVehicles
            End If
            komut.Parameters.Add(param39)

            Dim param40 As New SqlParameter("@AirCraft", SqlDbType.Bit)
            param40.Direction = ParameterDirection.Input
            If FirePolicyInfo.AirCraft = 0 Then
                param40.Value = 0
            Else
                param40.Value = FirePolicyInfo.AirCraft
            End If
            komut.Parameters.Add(param40)

            Dim param41 As New SqlParameter("@MaritimeVehicles", SqlDbType.Bit)
            param41.Direction = ParameterDirection.Input
            If FirePolicyInfo.MaritimeVehicles = 0 Then
                param41.Value = 0
            Else
                param41.Value = FirePolicyInfo.MaritimeVehicles
            End If
            komut.Parameters.Add(param41)

            Dim param42 As New SqlParameter("@Smoke", SqlDbType.Bit)
            param42.Direction = ParameterDirection.Input
            If FirePolicyInfo.Smoke = 0 Then
                param42.Value = 0
            Else
                param42.Value = FirePolicyInfo.Smoke
            End If
            komut.Parameters.Add(param42)

            Dim param43 As New SqlParameter("@SpaceShift", SqlDbType.Bit)
            param43.Direction = ParameterDirection.Input
            If FirePolicyInfo.SpaceShift = 0 Then
                param43.Value = 0
            Else
                param43.Value = FirePolicyInfo.SpaceShift
            End If
            komut.Parameters.Add(param43)

            Dim param44 As New SqlParameter("@GLKHH", SqlDbType.Bit)
            param44.Direction = ParameterDirection.Input
            If FirePolicyInfo.GLKHH = 0 Then
                param44.Value = 0
            Else
                param44.Value = FirePolicyInfo.GLKHH
            End If
            komut.Parameters.Add(param44)

            Dim param45 As New SqlParameter("@MaliciousTerror", SqlDbType.Bit)
            param45.Direction = ParameterDirection.Input
            If FirePolicyInfo.MaliciousTerror = 0 Then
                param45.Value = 0
            Else
                param45.Value = FirePolicyInfo.MaliciousTerror
            End If
            komut.Parameters.Add(param45)

            Dim param46 As New SqlParameter("@OtherGuarentees", SqlDbType.Bit)
            param46.Direction = ParameterDirection.Input
            If FirePolicyInfo.OtherGuarentees = 0 Then
                param46.Value = 0
            Else
                param46.Value = FirePolicyInfo.OtherGuarentees
            End If
            komut.Parameters.Add(param46)

            Dim param47 As New SqlParameter("@Latitude", SqlDbType.Decimal)
            param47.Direction = ParameterDirection.Input
            If FirePolicyInfo.Latitude = 0 Then
                param47.Value = 0
            Else
                param47.Value = FirePolicyInfo.Latitude
            End If
            komut.Parameters.Add(param47)

            Dim param48 As New SqlParameter("@Longitude", SqlDbType.Decimal)
            param48.Direction = ParameterDirection.Input
            If FirePolicyInfo.Longitude = 0 Then
                param48.Value = 0
            Else
                param48.Value = FirePolicyInfo.Longitude
            End If
            komut.Parameters.Add(param48)

            Dim param49 As New SqlParameter("@BuildingValue", SqlDbType.Decimal)
            param49.Direction = ParameterDirection.Input
            If FirePolicyInfo.BuildingValue = 0 Then
                param49.Value = 0
            Else
                param49.Value = FirePolicyInfo.BuildingValue
            End If
            komut.Parameters.Add(param49)

            Dim param50 As New SqlParameter("@ContentsValue", SqlDbType.Decimal)
            param50.Direction = ParameterDirection.Input
            If FirePolicyInfo.ContentsValue = 0 Then
                param50.Value = 0
            Else
                param50.Value = FirePolicyInfo.ContentsValue
            End If
            komut.Parameters.Add(param50)

            Dim param51 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
            param51.Direction = ParameterDirection.Input
            If FirePolicyInfo.CurrencyCode = "" Then
                param51.Value = System.DBNull.Value
            Else
                param51.Value = FirePolicyInfo.CurrencyCode
            End If
            komut.Parameters.Add(param51)

            Dim param52 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
            param52.Direction = ParameterDirection.Input
            If FirePolicyInfo.ExchangeRate = 0 Then
                param52.Value = 0
            Else
                param52.Value = FirePolicyInfo.ExchangeRate
            End If
            komut.Parameters.Add(param52)

            Dim param53 As New SqlParameter("@FirePremium", SqlDbType.Decimal)
            param53.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirePremium = 0 Then
                param53.Value = 0
            Else
                param53.Value = FirePolicyInfo.FirePremium
            End If
            komut.Parameters.Add(param53)

            Dim param54 As New SqlParameter("@SupplementaryGuaranteePremium", SqlDbType.Decimal)
            param54.Direction = ParameterDirection.Input
            If FirePolicyInfo.SupplementaryGuaranteePremium = 0 Then
                param54.Value = 0
            Else
                param54.Value = FirePolicyInfo.SupplementaryGuaranteePremium
            End If
            komut.Parameters.Add(param54)

            Dim param55 As New SqlParameter("@EarthquakePremium", SqlDbType.Decimal)
            param55.Direction = ParameterDirection.Input
            If FirePolicyInfo.EarthquakePremium = 0 Then
                param55.Value = 0
            Else
                param55.Value = FirePolicyInfo.EarthquakePremium
            End If
            komut.Parameters.Add(param55)

            Dim param56 As New SqlParameter("@OtherFees", SqlDbType.Decimal)
            param56.Direction = ParameterDirection.Input
            If FirePolicyInfo.OtherFees = 0 Then
                param56.Value = 0
            Else
                param56.Value = FirePolicyInfo.OtherFees
            End If
            komut.Parameters.Add(param56)

            Dim param57 As New SqlParameter("@TotalPremium", SqlDbType.Decimal)
            param57.Direction = ParameterDirection.Input
            If FirePolicyInfo.TotalPremium = 0 Then
                param57.Value = 0
            Else
                param57.Value = FirePolicyInfo.TotalPremium
            End If
            komut.Parameters.Add(param57)

            Dim param58 As New SqlParameter("@FirePremiumTL", SqlDbType.Decimal)
            param58.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirePremiumTL = 0 Then
                param58.Value = 0
            Else
                param58.Value = FirePolicyInfo.FirePremiumTL
            End If
            komut.Parameters.Add(param58)

            Dim param59 As New SqlParameter("@SupplementaryGuaranteePremiumTL", SqlDbType.Decimal)
            param59.Direction = ParameterDirection.Input
            If FirePolicyInfo.SupplementaryGuaranteePremiumTL = 0 Then
                param59.Value = 0
            Else
                param59.Value = FirePolicyInfo.SupplementaryGuaranteePremiumTL
            End If
            komut.Parameters.Add(param59)

            Dim param60 As New SqlParameter("@EarthquakePremiumTL", SqlDbType.Decimal)
            param60.Direction = ParameterDirection.Input
            If FirePolicyInfo.EarthquakePremiumTL = 0 Then
                param60.Value = 0
            Else
                param60.Value = FirePolicyInfo.EarthquakePremiumTL
            End If
            komut.Parameters.Add(param60)

            Dim param61 As New SqlParameter("@OtherFeesTL", SqlDbType.Decimal)
            param61.Direction = ParameterDirection.Input
            If FirePolicyInfo.OtherFeesTL = 0 Then
                param61.Value = 0
            Else
                param61.Value = FirePolicyInfo.OtherFeesTL
            End If
            komut.Parameters.Add(param61)

            Dim param62 As New SqlParameter("@TotalPremiumTL", SqlDbType.Decimal)
            param62.Direction = ParameterDirection.Input
            If FirePolicyInfo.TotalPremiumTL = 0 Then
                param62.Value = 0
            Else
                param62.Value = FirePolicyInfo.TotalPremiumTL
            End If
            komut.Parameters.Add(param62)

            Dim param63 As New SqlParameter("@PolicyPremiumTL", SqlDbType.Decimal)
            param63.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyPremiumTL = 0 Then
                param63.Value = 0
            Else
                param63.Value = FirePolicyInfo.PolicyPremiumTL
            End If
            komut.Parameters.Add(param63)

            Dim param64 As New SqlParameter("@Color", SqlDbType.VarChar, 10)
            param64.Direction = ParameterDirection.Input
            If FirePolicyInfo.Color = "" Then
                param64.Value = System.DBNull.Value
            Else
                param64.Value = FirePolicyInfo.Color
            End If
            komut.Parameters.Add(param64)

            Dim param65 As New SqlParameter("@FSBMCode", SqlDbType.VarChar, 100)
            param65.Direction = ParameterDirection.Input
            If FirePolicyInfo.FSBMCode = "" Then
                param65.Value = System.DBNull.Value
            Else
                param65.Value = FirePolicyInfo.FSBMCode
            End If
            komut.Parameters.Add(param65)

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
                resultset.etkilenen = eklenenpkey
            End If
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()

        End Using

        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "select max(pkey) from FirePolicyInfo"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim maxkayit1 = komut.ExecuteScalar()
            If maxkayit1 Is System.DBNull.Value Then
                pkey = 1
            Else
                pkey = maxkayit1 + 1
            End If
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using

        Return pkey

    End Function

    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal FirePolicyInfo As FirePolicyInfo) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            komut.Connection = db_baglanti
            sqlstr = "update FirePolicyInfo set " +
            "FirmCode=@FirmCode," +
            "ProductCode=@ProductCode," +
            "AgencyCode=@AgencyCode," +
            "PolicyNumber=@PolicyNumber," +
            "TecditNumber=@TecditNumber," +
            "ZeylCode=@ZeylCode," +
            "ZeyilNo=@ZeyilNo," +
            "PolicyType=@PolicyType," +
            "ArrangeDate=@ArrangeDate," +
            "StartDate=@StartDate," +
            "EndDate=@EndDate," +
            "PolicyOwnerCountryCode=@PolicyOwnerCountryCode," +
            "PolicyOwnerIdentityCode=@PolicyOwnerIdentityCode," +
            "PolicyOwnerIdentityNo=@PolicyOwnerIdentityNo," +
            "PolicyOwnerName=@PolicyOwnerName," +
            "PolicyOwnerSurname=@PolicyOwnerSurname," +
            "InsuredTitle=@InsuredTitle," +
            "RiskAddress_ilcekod=@RiskAddress_ilcekod," +
            "RiskAddress_bucakkod=@RiskAddress_bucakkod," +
            "RiskAddress_belediyekod=@RiskAddress_belediyekod," +
            "RiskAddress_mahallekod=@RiskAddress_mahallekod," +
            "RiskAddress_sokakkod=@RiskAddress_sokakkod," +
            "FirstBeneficiary=@FirstBeneficiary," +
            "Creditor=@Creditor," +
            "RiskType=@RiskType," +
            "StructureStyle=@StructureStyle," +
            "OfficeBlock=@OfficeBlock," +
            "Activity=@Activity," +
            "AgencyRegisterCode=@AgencyRegisterCode," +
            "TPNo=@TPNo," +
            "Building=@Building," +
            "Contents=@Contents," +
            "EartQuake=@EartQuake," +
            "FloodFlooding=@FloodFlooding," +
            "InternalWater=@InternalWater," +
            "Storm=@Storm," +
            "Theft=@Theft," +
            "LandVehicles=@LandVehicles," +
            "AirCraft=@AirCraft," +
            "MaritimeVehicles=@MaritimeVehicles," +
            "Smoke=@Smoke," +
            "SpaceShift=@SpaceShift," +
            "GLKHH=@GLKHH," +
            "MaliciousTerror=@MaliciousTerror," +
            "OtherGuarentees=@OtherGuarentees," +
            "Latitude=@Latitude," +
            "Longitude=@Longitude," +
            "BuildingValue=@BuildingValue," +
            "ContentsValue=@ContentsValue," +
            "CurrencyCode=@CurrencyCode," +
            "ExchangeRate=@ExchangeRate," +
            "FirePremium=@FirePremium," +
            "SupplementaryGuaranteePremium=@SupplementaryGuaranteePremium," +
            "EarthquakePremium=@EarthquakePremium," +
            "OtherFees=@OtherFees," +
            "TotalPremium=@TotalPremium," +
            "FirePremiumTL=@FirePremiumTL," +
            "SupplementaryGuaranteePremiumTL=@SupplementaryGuaranteePremiumTL," +
            "EarthquakePremiumTL=@EarthquakePremiumTL," +
            "OtherFeesTL=@OtherFeesTL," +
            "TotalPremiumTL=@TotalPremiumTL," +
            "PolicyPremiumTL=@PolicyPremiumTL," +
            "Color=@Color," +
            "FSBMCode=@FSBMCode" +
            " where pkey=@pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = FirePolicyInfo.pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
            param2.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirmCode = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = FirePolicyInfo.FirmCode
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
            param3.Direction = ParameterDirection.Input
            If FirePolicyInfo.ProductCode = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = FirePolicyInfo.ProductCode
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
            param4.Direction = ParameterDirection.Input
            If FirePolicyInfo.AgencyCode = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = FirePolicyInfo.AgencyCode
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
            param5.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyNumber = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = FirePolicyInfo.PolicyNumber
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
            param6.Direction = ParameterDirection.Input
            If FirePolicyInfo.TecditNumber = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = FirePolicyInfo.TecditNumber
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@ZeylCode", SqlDbType.VarChar, 1)
            param7.Direction = ParameterDirection.Input
            If FirePolicyInfo.ZeylCode = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = FirePolicyInfo.ZeylCode
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@ZeyilNo", SqlDbType.VarChar, 15)
            param8.Direction = ParameterDirection.Input
            If FirePolicyInfo.ZeyilNo = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = FirePolicyInfo.ZeyilNo
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@PolicyType", SqlDbType.Int)
            param9.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyType = 0 Then
                param9.Value = 0
            Else
                param9.Value = FirePolicyInfo.PolicyType
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@ArrangeDate", SqlDbType.DateTime)
            param10.Direction = ParameterDirection.Input
            If FirePolicyInfo.ArrangeDate Is Nothing Or FirePolicyInfo.ArrangeDate = "00:00:00" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = FirePolicyInfo.ArrangeDate
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@StartDate", SqlDbType.DateTime)
            param11.Direction = ParameterDirection.Input
            If FirePolicyInfo.StartDate Is Nothing Or FirePolicyInfo.StartDate = "00:00:00" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = FirePolicyInfo.StartDate
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@EndDate", SqlDbType.DateTime)
            param12.Direction = ParameterDirection.Input
            If FirePolicyInfo.EndDate Is Nothing Or FirePolicyInfo.EndDate = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = FirePolicyInfo.EndDate
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@PolicyOwnerCountryCode", SqlDbType.VarChar, 3)
            param13.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerCountryCode = "" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = FirePolicyInfo.PolicyOwnerCountryCode
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@PolicyOwnerIdentityCode", SqlDbType.VarChar, 2)
            param14.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerIdentityCode = "" Then
                param14.Value = System.DBNull.Value
            Else
                param14.Value = FirePolicyInfo.PolicyOwnerIdentityCode
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@PolicyOwnerIdentityNo", SqlDbType.VarChar, 15)
            param15.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerIdentityNo = "" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = FirePolicyInfo.PolicyOwnerIdentityNo
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@PolicyOwnerName", SqlDbType.VarChar, 50)
            param16.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerName = "" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = FirePolicyInfo.PolicyOwnerName
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@PolicyOwnerSurname", SqlDbType.VarChar, 30)
            param17.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyOwnerSurname = "" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = FirePolicyInfo.PolicyOwnerSurname
            End If
            komut.Parameters.Add(param17)

            Dim param18 As New SqlParameter("@InsuredTitle", SqlDbType.Int)
            param18.Direction = ParameterDirection.Input
            If FirePolicyInfo.InsuredTitle = 0 Then
                param18.Value = 0
            Else
                param18.Value = FirePolicyInfo.InsuredTitle
            End If
            komut.Parameters.Add(param18)

            Dim param19 As New SqlParameter("@RiskAddress_ilcekod", SqlDbType.Int)
            param19.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_ilcekod = 0 Then
                param19.Value = 0
            Else
                param19.Value = FirePolicyInfo.RiskAddress_ilcekod
            End If
            komut.Parameters.Add(param19)

            Dim param20 As New SqlParameter("@RiskAddress_bucakkod", SqlDbType.Int)
            param20.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_bucakkod = 0 Then
                param20.Value = 0
            Else
                param20.Value = FirePolicyInfo.RiskAddress_bucakkod
            End If
            komut.Parameters.Add(param20)

            Dim param21 As New SqlParameter("@RiskAddress_belediyekod", SqlDbType.Int)
            param21.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_belediyekod = 0 Then
                param21.Value = 0
            Else
                param21.Value = FirePolicyInfo.RiskAddress_belediyekod
            End If
            komut.Parameters.Add(param21)

            Dim param22 As New SqlParameter("@RiskAddress_mahallekod", SqlDbType.Int)
            param22.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_mahallekod = 0 Then
                param22.Value = 0
            Else
                param22.Value = FirePolicyInfo.RiskAddress_mahallekod
            End If
            komut.Parameters.Add(param22)

            Dim param23 As New SqlParameter("@RiskAddress_sokakkod", SqlDbType.Int)
            param23.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskAddress_sokakkod = 0 Then
                param23.Value = 0
            Else
                param23.Value = FirePolicyInfo.RiskAddress_sokakkod
            End If
            komut.Parameters.Add(param23)

            Dim param24 As New SqlParameter("@FirstBeneficiary", SqlDbType.VarChar, 15)
            param24.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirstBeneficiary = "" Then
                param24.Value = System.DBNull.Value
            Else
                param24.Value = FirePolicyInfo.FirstBeneficiary
            End If
            komut.Parameters.Add(param24)

            Dim param25 As New SqlParameter("@Creditor", SqlDbType.Bit)
            param25.Direction = ParameterDirection.Input
            If FirePolicyInfo.Creditor = 0 Then
                param25.Value = 0
            Else
                param25.Value = FirePolicyInfo.Creditor
            End If
            komut.Parameters.Add(param25)

            Dim param26 As New SqlParameter("@RiskType", SqlDbType.Int)
            param26.Direction = ParameterDirection.Input
            If FirePolicyInfo.RiskType = 0 Then
                param26.Value = 0
            Else
                param26.Value = FirePolicyInfo.RiskType
            End If
            komut.Parameters.Add(param26)

            Dim param27 As New SqlParameter("@StructureStyle", SqlDbType.Int)
            param27.Direction = ParameterDirection.Input
            If FirePolicyInfo.StructureStyle = 0 Then
                param27.Value = 0
            Else
                param27.Value = FirePolicyInfo.StructureStyle
            End If
            komut.Parameters.Add(param27)

            Dim param28 As New SqlParameter("@OfficeBlock", SqlDbType.Int)
            param28.Direction = ParameterDirection.Input
            If FirePolicyInfo.OfficeBlock = 0 Then
                param28.Value = 0
            Else
                param28.Value = FirePolicyInfo.OfficeBlock
            End If
            komut.Parameters.Add(param28)

            Dim param29 As New SqlParameter("@Activity", SqlDbType.VarChar, 50)
            param29.Direction = ParameterDirection.Input
            If FirePolicyInfo.Activity = "" Then
                param29.Value = System.DBNull.Value
            Else
                param29.Value = FirePolicyInfo.Activity
            End If
            komut.Parameters.Add(param29)

            Dim param30 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar, 20)
            param30.Direction = ParameterDirection.Input
            If FirePolicyInfo.AgencyRegisterCode = "" Then
                param30.Value = System.DBNull.Value
            Else
                param30.Value = FirePolicyInfo.AgencyRegisterCode
            End If
            komut.Parameters.Add(param30)

            Dim param31 As New SqlParameter("@TPNo", SqlDbType.VarChar, 20)
            param31.Direction = ParameterDirection.Input
            If FirePolicyInfo.TPNo = "" Then
                param31.Value = System.DBNull.Value
            Else
                param31.Value = FirePolicyInfo.TPNo
            End If
            komut.Parameters.Add(param31)

            Dim param32 As New SqlParameter("@Building", SqlDbType.Bit)
            param32.Direction = ParameterDirection.Input
            If FirePolicyInfo.Building = 0 Then
                param32.Value = 0
            Else
                param32.Value = FirePolicyInfo.Building
            End If
            komut.Parameters.Add(param32)

            Dim param33 As New SqlParameter("@Contents", SqlDbType.Bit)
            param33.Direction = ParameterDirection.Input
            If FirePolicyInfo.Contents = 0 Then
                param33.Value = 0
            Else
                param33.Value = FirePolicyInfo.Contents
            End If
            komut.Parameters.Add(param33)

            Dim param34 As New SqlParameter("@EartQuake", SqlDbType.Bit)
            param34.Direction = ParameterDirection.Input
            If FirePolicyInfo.EartQuake = 0 Then
                param34.Value = 0
            Else
                param34.Value = FirePolicyInfo.EartQuake
            End If
            komut.Parameters.Add(param34)

            Dim param35 As New SqlParameter("@FloodFlooding", SqlDbType.Bit)
            param35.Direction = ParameterDirection.Input
            If FirePolicyInfo.FloodFlooding = 0 Then
                param35.Value = 0
            Else
                param35.Value = FirePolicyInfo.FloodFlooding
            End If
            komut.Parameters.Add(param35)

            Dim param36 As New SqlParameter("@InternalWater", SqlDbType.Bit)
            param36.Direction = ParameterDirection.Input
            If FirePolicyInfo.InternalWater = 0 Then
                param36.Value = 0
            Else
                param36.Value = FirePolicyInfo.InternalWater
            End If
            komut.Parameters.Add(param36)

            Dim param37 As New SqlParameter("@Storm", SqlDbType.Bit)
            param37.Direction = ParameterDirection.Input
            If FirePolicyInfo.Storm = 0 Then
                param37.Value = 0
            Else
                param37.Value = FirePolicyInfo.Storm
            End If
            komut.Parameters.Add(param37)

            Dim param38 As New SqlParameter("@Theft", SqlDbType.Bit)
            param38.Direction = ParameterDirection.Input
            If FirePolicyInfo.Theft = 0 Then
                param38.Value = 0
            Else
                param38.Value = FirePolicyInfo.Theft
            End If
            komut.Parameters.Add(param38)

            Dim param39 As New SqlParameter("@LandVehicles", SqlDbType.Bit)
            param39.Direction = ParameterDirection.Input
            If FirePolicyInfo.LandVehicles = 0 Then
                param39.Value = 0
            Else
                param39.Value = FirePolicyInfo.LandVehicles
            End If
            komut.Parameters.Add(param39)

            Dim param40 As New SqlParameter("@AirCraft", SqlDbType.Bit)
            param40.Direction = ParameterDirection.Input
            If FirePolicyInfo.AirCraft = 0 Then
                param40.Value = 0
            Else
                param40.Value = FirePolicyInfo.AirCraft
            End If
            komut.Parameters.Add(param40)

            Dim param41 As New SqlParameter("@MaritimeVehicles", SqlDbType.Bit)
            param41.Direction = ParameterDirection.Input
            If FirePolicyInfo.MaritimeVehicles = 0 Then
                param41.Value = 0
            Else
                param41.Value = FirePolicyInfo.MaritimeVehicles
            End If
            komut.Parameters.Add(param41)

            Dim param42 As New SqlParameter("@Smoke", SqlDbType.Bit)
            param42.Direction = ParameterDirection.Input
            If FirePolicyInfo.Smoke = 0 Then
                param42.Value = 0
            Else
                param42.Value = FirePolicyInfo.Smoke
            End If
            komut.Parameters.Add(param42)

            Dim param43 As New SqlParameter("@SpaceShift", SqlDbType.Bit)
            param43.Direction = ParameterDirection.Input
            If FirePolicyInfo.SpaceShift = 0 Then
                param43.Value = 0
            Else
                param43.Value = FirePolicyInfo.SpaceShift
            End If
            komut.Parameters.Add(param43)

            Dim param44 As New SqlParameter("@GLKHH", SqlDbType.Bit)
            param44.Direction = ParameterDirection.Input
            If FirePolicyInfo.GLKHH = 0 Then
                param44.Value = 0
            Else
                param44.Value = FirePolicyInfo.GLKHH
            End If
            komut.Parameters.Add(param44)

            Dim param45 As New SqlParameter("@MaliciousTerror", SqlDbType.Bit)
            param45.Direction = ParameterDirection.Input
            If FirePolicyInfo.MaliciousTerror = 0 Then
                param45.Value = 0
            Else
                param45.Value = FirePolicyInfo.MaliciousTerror
            End If
            komut.Parameters.Add(param45)

            Dim param46 As New SqlParameter("@OtherGuarentees", SqlDbType.Bit)
            param46.Direction = ParameterDirection.Input
            If FirePolicyInfo.OtherGuarentees = 0 Then
                param46.Value = 0
            Else
                param46.Value = FirePolicyInfo.OtherGuarentees
            End If
            komut.Parameters.Add(param46)

            Dim param47 As New SqlParameter("@Latitude", SqlDbType.Decimal)
            param47.Direction = ParameterDirection.Input
            If FirePolicyInfo.Latitude = 0 Then
                param47.Value = 0
            Else
                param47.Value = FirePolicyInfo.Latitude
            End If
            komut.Parameters.Add(param47)

            Dim param48 As New SqlParameter("@Longitude", SqlDbType.Decimal)
            param48.Direction = ParameterDirection.Input
            If FirePolicyInfo.Longitude = 0 Then
                param48.Value = 0
            Else
                param48.Value = FirePolicyInfo.Longitude
            End If
            komut.Parameters.Add(param48)

            Dim param49 As New SqlParameter("@BuildingValue", SqlDbType.Decimal)
            param49.Direction = ParameterDirection.Input
            If FirePolicyInfo.BuildingValue = 0 Then
                param49.Value = 0
            Else
                param49.Value = FirePolicyInfo.BuildingValue
            End If
            komut.Parameters.Add(param49)

            Dim param50 As New SqlParameter("@ContentsValue", SqlDbType.Decimal)
            param50.Direction = ParameterDirection.Input
            If FirePolicyInfo.ContentsValue = 0 Then
                param50.Value = 0
            Else
                param50.Value = FirePolicyInfo.ContentsValue
            End If
            komut.Parameters.Add(param50)

            Dim param51 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
            param51.Direction = ParameterDirection.Input
            If FirePolicyInfo.CurrencyCode = "" Then
                param51.Value = System.DBNull.Value
            Else
                param51.Value = FirePolicyInfo.CurrencyCode
            End If
            komut.Parameters.Add(param51)

            Dim param52 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
            param52.Direction = ParameterDirection.Input
            If FirePolicyInfo.ExchangeRate = 0 Then
                param52.Value = 0
            Else
                param52.Value = FirePolicyInfo.ExchangeRate
            End If
            komut.Parameters.Add(param52)

            Dim param53 As New SqlParameter("@FirePremium", SqlDbType.Decimal)
            param53.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirePremium = 0 Then
                param53.Value = 0
            Else
                param53.Value = FirePolicyInfo.FirePremium
            End If
            komut.Parameters.Add(param53)

            Dim param54 As New SqlParameter("@SupplementaryGuaranteePremium", SqlDbType.Decimal)
            param54.Direction = ParameterDirection.Input
            If FirePolicyInfo.SupplementaryGuaranteePremium = 0 Then
                param54.Value = 0
            Else
                param54.Value = FirePolicyInfo.SupplementaryGuaranteePremium
            End If
            komut.Parameters.Add(param54)

            Dim param55 As New SqlParameter("@EarthquakePremium", SqlDbType.Decimal)
            param55.Direction = ParameterDirection.Input
            If FirePolicyInfo.EarthquakePremium = 0 Then
                param55.Value = 0
            Else
                param55.Value = FirePolicyInfo.EarthquakePremium
            End If
            komut.Parameters.Add(param55)

            Dim param56 As New SqlParameter("@OtherFees", SqlDbType.Decimal)
            param56.Direction = ParameterDirection.Input
            If FirePolicyInfo.OtherFees = 0 Then
                param56.Value = 0
            Else
                param56.Value = FirePolicyInfo.OtherFees
            End If
            komut.Parameters.Add(param56)

            Dim param57 As New SqlParameter("@TotalPremium", SqlDbType.Decimal)
            param57.Direction = ParameterDirection.Input
            If FirePolicyInfo.TotalPremium = 0 Then
                param57.Value = 0
            Else
                param57.Value = FirePolicyInfo.TotalPremium
            End If
            komut.Parameters.Add(param57)

            Dim param58 As New SqlParameter("@FirePremiumTL", SqlDbType.Decimal)
            param58.Direction = ParameterDirection.Input
            If FirePolicyInfo.FirePremiumTL = 0 Then
                param58.Value = 0
            Else
                param58.Value = FirePolicyInfo.FirePremiumTL
            End If
            komut.Parameters.Add(param58)

            Dim param59 As New SqlParameter("@SupplementaryGuaranteePremiumTL", SqlDbType.Decimal)
            param59.Direction = ParameterDirection.Input
            If FirePolicyInfo.SupplementaryGuaranteePremiumTL = 0 Then
                param59.Value = 0
            Else
                param59.Value = FirePolicyInfo.SupplementaryGuaranteePremiumTL
            End If
            komut.Parameters.Add(param59)

            Dim param60 As New SqlParameter("@EarthquakePremiumTL", SqlDbType.Decimal)
            param60.Direction = ParameterDirection.Input
            If FirePolicyInfo.EarthquakePremiumTL = 0 Then
                param60.Value = 0
            Else
                param60.Value = FirePolicyInfo.EarthquakePremiumTL
            End If
            komut.Parameters.Add(param60)

            Dim param61 As New SqlParameter("@OtherFeesTL", SqlDbType.Decimal)
            param61.Direction = ParameterDirection.Input
            If FirePolicyInfo.OtherFeesTL = 0 Then
                param61.Value = 0
            Else
                param61.Value = FirePolicyInfo.OtherFeesTL
            End If
            komut.Parameters.Add(param61)

            Dim param62 As New SqlParameter("@TotalPremiumTL", SqlDbType.Decimal)
            param62.Direction = ParameterDirection.Input
            If FirePolicyInfo.TotalPremiumTL = 0 Then
                param62.Value = 0
            Else
                param62.Value = FirePolicyInfo.TotalPremiumTL
            End If
            komut.Parameters.Add(param62)

            Dim param63 As New SqlParameter("@PolicyPremiumTL", SqlDbType.Decimal)
            param63.Direction = ParameterDirection.Input
            If FirePolicyInfo.PolicyPremiumTL = 0 Then
                param63.Value = 0
            Else
                param63.Value = FirePolicyInfo.PolicyPremiumTL
            End If
            komut.Parameters.Add(param63)

            Dim param64 As New SqlParameter("@Color", SqlDbType.VarChar, 10)
            param64.Direction = ParameterDirection.Input
            If FirePolicyInfo.Color = "" Then
                param64.Value = System.DBNull.Value
            Else
                param64.Value = FirePolicyInfo.Color
            End If
            komut.Parameters.Add(param64)

            Dim param65 As New SqlParameter("@FSBMCode", SqlDbType.VarChar, 100)
            param65.Direction = ParameterDirection.Input
            If FirePolicyInfo.FSBMCode = "" Then
                param65.Value = System.DBNull.Value
            Else
                param65.Value = FirePolicyInfo.FSBMCode
            End If
            komut.Parameters.Add(param65)


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
        End Using
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As FirePolicyInfo

        Dim komut As New SqlCommand
        Dim donecekFirePolicyInfo As New FirePolicyInfo()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "select * from FirePolicyInfo where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkey
            komut.Parameters.Add(param1)


            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirmCode = veri.Item("FirmCode")
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ProductCode = veri.Item("ProductCode")
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AgencyCode = veri.Item("AgencyCode")
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TecditNumber = veri.Item("TecditNumber")
                    End If

                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ZeylCode = veri.Item("ZeylCode")
                    End If

                    If Not veri.Item("ZeyilNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ZeyilNo = veri.Item("ZeyilNo")
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyType = veri.Item("PolicyType")
                    End If

                    If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                    End If

                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.StartDate = veri.Item("StartDate")
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EndDate = veri.Item("EndDate")
                    End If

                    If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                    End If

                    If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                    End If

                    If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                    End If

                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                    End If

                    If Not veri.Item("InsuredTitle") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.InsuredTitle = veri.Item("InsuredTitle")
                    End If

                    If Not veri.Item("RiskAddress_ilcekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_ilcekod = veri.Item("RiskAddress_ilcekod")
                    End If

                    If Not veri.Item("RiskAddress_bucakkod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_bucakkod = veri.Item("RiskAddress_bucakkod")
                    End If

                    If Not veri.Item("RiskAddress_belediyekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_belediyekod = veri.Item("RiskAddress_belediyekod")
                    End If

                    If Not veri.Item("RiskAddress_mahallekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_mahallekod = veri.Item("RiskAddress_mahallekod")
                    End If

                    If Not veri.Item("RiskAddress_sokakkod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_sokakkod = veri.Item("RiskAddress_sokakkod")
                    End If

                    If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                    End If

                    If Not veri.Item("Creditor") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Creditor = veri.Item("Creditor")
                    End If

                    If Not veri.Item("RiskType") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskType = veri.Item("RiskType")
                    End If

                    If Not veri.Item("StructureStyle") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.StructureStyle = veri.Item("StructureStyle")
                    End If

                    If Not veri.Item("OfficeBlock") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OfficeBlock = veri.Item("OfficeBlock")
                    End If

                    If Not veri.Item("Activity") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Activity = veri.Item("Activity")
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TPNo = veri.Item("TPNo")
                    End If

                    If Not veri.Item("Building") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Building = veri.Item("Building")
                    End If

                    If Not veri.Item("Contents") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Contents = veri.Item("Contents")
                    End If

                    If Not veri.Item("EartQuake") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EartQuake = veri.Item("EartQuake")
                    End If

                    If Not veri.Item("FloodFlooding") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FloodFlooding = veri.Item("FloodFlooding")
                    End If

                    If Not veri.Item("InternalWater") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.InternalWater = veri.Item("InternalWater")
                    End If

                    If Not veri.Item("Storm") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Storm = veri.Item("Storm")
                    End If

                    If Not veri.Item("Theft") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Theft = veri.Item("Theft")
                    End If

                    If Not veri.Item("LandVehicles") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.LandVehicles = veri.Item("LandVehicles")
                    End If

                    If Not veri.Item("AirCraft") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AirCraft = veri.Item("AirCraft")
                    End If

                    If Not veri.Item("MaritimeVehicles") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.MaritimeVehicles = veri.Item("MaritimeVehicles")
                    End If

                    If Not veri.Item("Smoke") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Smoke = veri.Item("Smoke")
                    End If

                    If Not veri.Item("SpaceShift") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SpaceShift = veri.Item("SpaceShift")
                    End If

                    If Not veri.Item("GLKHH") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.GLKHH = veri.Item("GLKHH")
                    End If

                    If Not veri.Item("MaliciousTerror") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.MaliciousTerror = veri.Item("MaliciousTerror")
                    End If

                    If Not veri.Item("OtherGuarentees") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherGuarentees = veri.Item("OtherGuarentees")
                    End If

                    If Not veri.Item("Latitude") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Latitude = veri.Item("Latitude")
                    End If

                    If Not veri.Item("Longitude") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Longitude = veri.Item("Longitude")
                    End If

                    If Not veri.Item("BuildingValue") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.BuildingValue = veri.Item("BuildingValue")
                    End If

                    If Not veri.Item("ContentsValue") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ContentsValue = veri.Item("ContentsValue")
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                    End If

                    If Not veri.Item("FirePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirePremium = veri.Item("FirePremium")
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SupplementaryGuaranteePremium = veri.Item("SupplementaryGuaranteePremium")
                    End If

                    If Not veri.Item("EarthquakePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EarthquakePremium = veri.Item("EarthquakePremium")
                    End If

                    If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherFees = veri.Item("OtherFees")
                    End If

                    If Not veri.Item("TotalPremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TotalPremium = veri.Item("TotalPremium")
                    End If

                    If Not veri.Item("FirePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirePremiumTL = veri.Item("FirePremiumTL")
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL = veri.Item("SupplementaryGuaranteePremiumTL")
                    End If

                    If Not veri.Item("EarthquakePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EarthquakePremiumTL = veri.Item("EarthquakePremiumTL")
                    End If

                    If Not veri.Item("OtherFeesTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherFeesTL = veri.Item("OtherFeesTL")
                    End If

                    If Not veri.Item("TotalPremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TotalPremiumTL = veri.Item("TotalPremiumTL")
                    End If

                    If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                    End If

                    If Not veri.Item("Color") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Color = veri.Item("Color")
                    End If

                    If Not veri.Item("FSBMCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FSBMCode = veri.Item("FSBMCode")
                    End If


                End While
            End Using
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using
        Return donecekFirePolicyInfo

    End Function

    '---------------------------------bultek-----------------------------------------
    Function bultek_pk(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String,
    ByVal TecditNumber As String, ByVal ZeyilCode As String,
    ByVal ZeyilNo As String, ByVal PolicyType As String) As FirePolicyInfo

        Dim komut As New SqlCommand
        Dim donecekFirePolicyInfo As New FirePolicyInfo()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "select * from FirePolicyInfo where " +
            "FirmCode=@FirmCode and " +
            "ProductCode=@ProductCode and " +
            "AgencyCode=@AgencyCode and " +
            "PolicyNumber=@PolicyNumber and " +
            "ZeyilNo=@ZeyilNo and " +
            "PolicyType=@PolicyType"

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

            Dim param5 As New SqlParameter("@ZeyilNo", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            param5.Value = ZeyilNo
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@PolicyType", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            param6.Value = PolicyType
            komut.Parameters.Add(param6)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirmCode = veri.Item("FirmCode")
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ProductCode = veri.Item("ProductCode")
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AgencyCode = veri.Item("AgencyCode")
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TecditNumber = veri.Item("TecditNumber")
                    End If

                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ZeylCode = veri.Item("ZeylCode")
                    End If

                    If Not veri.Item("ZeyilNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ZeyilNo = veri.Item("ZeyilNo")
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyType = veri.Item("PolicyType")
                    End If

                    If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                    End If

                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.StartDate = veri.Item("StartDate")
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EndDate = veri.Item("EndDate")
                    End If

                    If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                    End If

                    If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                    End If

                    If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                    End If

                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                    End If

                    If Not veri.Item("InsuredTitle") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.InsuredTitle = veri.Item("InsuredTitle")
                    End If

                    If Not veri.Item("RiskAddress_ilcekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_ilcekod = veri.Item("RiskAddress_ilcekod")
                    End If

                    If Not veri.Item("RiskAddress_bucakkod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_bucakkod = veri.Item("RiskAddress_bucakkod")
                    End If

                    If Not veri.Item("RiskAddress_belediyekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_belediyekod = veri.Item("RiskAddress_belediyekod")
                    End If

                    If Not veri.Item("RiskAddress_mahallekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_mahallekod = veri.Item("RiskAddress_mahallekod")
                    End If

                    If Not veri.Item("RiskAddress_sokakkod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_sokakkod = veri.Item("RiskAddress_sokakkod")
                    End If

                    If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                    End If

                    If Not veri.Item("Creditor") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Creditor = veri.Item("Creditor")
                    End If

                    If Not veri.Item("RiskType") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskType = veri.Item("RiskType")
                    End If

                    If Not veri.Item("StructureStyle") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.StructureStyle = veri.Item("StructureStyle")
                    End If

                    If Not veri.Item("OfficeBlock") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OfficeBlock = veri.Item("OfficeBlock")
                    End If

                    If Not veri.Item("Activity") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Activity = veri.Item("Activity")
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TPNo = veri.Item("TPNo")
                    End If

                    If Not veri.Item("Building") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Building = veri.Item("Building")
                    End If

                    If Not veri.Item("Contents") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Contents = veri.Item("Contents")
                    End If

                    If Not veri.Item("EartQuake") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EartQuake = veri.Item("EartQuake")
                    End If

                    If Not veri.Item("FloodFlooding") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FloodFlooding = veri.Item("FloodFlooding")
                    End If

                    If Not veri.Item("InternalWater") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.InternalWater = veri.Item("InternalWater")
                    End If

                    If Not veri.Item("Storm") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Storm = veri.Item("Storm")
                    End If

                    If Not veri.Item("Theft") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Theft = veri.Item("Theft")
                    End If

                    If Not veri.Item("LandVehicles") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.LandVehicles = veri.Item("LandVehicles")
                    End If

                    If Not veri.Item("AirCraft") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AirCraft = veri.Item("AirCraft")
                    End If

                    If Not veri.Item("MaritimeVehicles") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.MaritimeVehicles = veri.Item("MaritimeVehicles")
                    End If

                    If Not veri.Item("Smoke") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Smoke = veri.Item("Smoke")
                    End If

                    If Not veri.Item("SpaceShift") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SpaceShift = veri.Item("SpaceShift")
                    End If

                    If Not veri.Item("GLKHH") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.GLKHH = veri.Item("GLKHH")
                    End If

                    If Not veri.Item("MaliciousTerror") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.MaliciousTerror = veri.Item("MaliciousTerror")
                    End If

                    If Not veri.Item("OtherGuarentees") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherGuarentees = veri.Item("OtherGuarentees")
                    End If

                    If Not veri.Item("Latitude") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Latitude = veri.Item("Latitude")
                    End If

                    If Not veri.Item("Longitude") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Longitude = veri.Item("Longitude")
                    End If

                    If Not veri.Item("BuildingValue") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.BuildingValue = veri.Item("BuildingValue")
                    End If

                    If Not veri.Item("ContentsValue") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ContentsValue = veri.Item("ContentsValue")
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                    End If

                    If Not veri.Item("FirePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirePremium = veri.Item("FirePremium")
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SupplementaryGuaranteePremium = veri.Item("SupplementaryGuaranteePremium")
                    End If

                    If Not veri.Item("EarthquakePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EarthquakePremium = veri.Item("EarthquakePremium")
                    End If

                    If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherFees = veri.Item("OtherFees")
                    End If

                    If Not veri.Item("TotalPremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TotalPremium = veri.Item("TotalPremium")
                    End If

                    If Not veri.Item("FirePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirePremiumTL = veri.Item("FirePremiumTL")
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL = veri.Item("SupplementaryGuaranteePremiumTL")
                    End If

                    If Not veri.Item("EarthquakePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EarthquakePremiumTL = veri.Item("EarthquakePremiumTL")
                    End If

                    If Not veri.Item("OtherFeesTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherFeesTL = veri.Item("OtherFeesTL")
                    End If

                    If Not veri.Item("TotalPremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TotalPremiumTL = veri.Item("TotalPremiumTL")
                    End If

                    If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                    End If

                    If Not veri.Item("Color") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Color = veri.Item("Color")
                    End If

                    If Not veri.Item("FSBMCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FSBMCode = veri.Item("FSBMCode")
                    End If


                End While
            End Using
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using
        Return donecekFirePolicyInfo

    End Function


    Function zeyildoldur_ilgilipolice_tecditli(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String,
    ByVal TecditNumber As String, ByVal PolicyType As String) As List(Of FirePolicyInfo)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekFirePolicyInfo As New FirePolicyInfo
        Dim firePolicyInfolar As New List(Of FirePolicyInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from FirePolicyInfo where" +
        " FirmCode=@FirmCode" +
        " and ProductCode=@ProductCode " +
        " and AgencyCode=@AgencyCode " +
        " and PolicyNumber=@PolicyNumber " +
        " and TecditNumber=@TecditNumber " +
        " and PolicyType=@PolicyType " +
        "order by ZeyilNo"

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

        Dim param6 As New SqlParameter("@PolicyType", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = PolicyType
        komut.Parameters.Add(param6)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeyilNo") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ZeyilNo = veri.Item("ZeyilNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.StartDate = veri.Item("StartDate")
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EndDate = veri.Item("EndDate")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("InsuredTitle") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.InsuredTitle = veri.Item("InsuredTitle")
                End If

                If Not veri.Item("RiskAddress_ilcekod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_ilcekod = veri.Item("RiskAddress_ilcekod")
                End If

                If Not veri.Item("RiskAddress_bucakkod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_bucakkod = veri.Item("RiskAddress_bucakkod")
                End If

                If Not veri.Item("RiskAddress_belediyekod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_belediyekod = veri.Item("RiskAddress_belediyekod")
                End If

                If Not veri.Item("RiskAddress_mahallekod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_mahallekod = veri.Item("RiskAddress_mahallekod")
                End If

                If Not veri.Item("RiskAddress_sokakkod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_sokakkod = veri.Item("RiskAddress_sokakkod")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("RiskType") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskType = veri.Item("RiskType")
                End If

                If Not veri.Item("StructureStyle") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.StructureStyle = veri.Item("StructureStyle")
                End If

                If Not veri.Item("OfficeBlock") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OfficeBlock = veri.Item("OfficeBlock")
                End If

                If Not veri.Item("Activity") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Activity = veri.Item("Activity")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("Building") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Building = veri.Item("Building")
                End If

                If Not veri.Item("Contents") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Contents = veri.Item("Contents")
                End If

                If Not veri.Item("EartQuake") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EartQuake = veri.Item("EartQuake")
                End If

                If Not veri.Item("FloodFlooding") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FloodFlooding = veri.Item("FloodFlooding")
                End If

                If Not veri.Item("InternalWater") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.InternalWater = veri.Item("InternalWater")
                End If

                If Not veri.Item("Storm") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Storm = veri.Item("Storm")
                End If

                If Not veri.Item("Theft") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Theft = veri.Item("Theft")
                End If

                If Not veri.Item("LandVehicles") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.LandVehicles = veri.Item("LandVehicles")
                End If

                If Not veri.Item("AirCraft") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.AirCraft = veri.Item("AirCraft")
                End If

                If Not veri.Item("MaritimeVehicles") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.MaritimeVehicles = veri.Item("MaritimeVehicles")
                End If

                If Not veri.Item("Smoke") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Smoke = veri.Item("Smoke")
                End If

                If Not veri.Item("SpaceShift") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.SpaceShift = veri.Item("SpaceShift")
                End If

                If Not veri.Item("GLKHH") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.GLKHH = veri.Item("GLKHH")
                End If

                If Not veri.Item("MaliciousTerror") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.MaliciousTerror = veri.Item("MaliciousTerror")
                End If

                If Not veri.Item("OtherGuarentees") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OtherGuarentees = veri.Item("OtherGuarentees")
                End If

                If Not veri.Item("Latitude") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Latitude = veri.Item("Latitude")
                End If

                If Not veri.Item("Longitude") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Longitude = veri.Item("Longitude")
                End If

                If Not veri.Item("BuildingValue") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.BuildingValue = veri.Item("BuildingValue")
                End If

                If Not veri.Item("ContentsValue") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ContentsValue = veri.Item("ContentsValue")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("FirePremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirePremium = veri.Item("FirePremium")
                End If

                If Not veri.Item("SupplementaryGuaranteePremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.SupplementaryGuaranteePremium = veri.Item("SupplementaryGuaranteePremium")
                End If

                If Not veri.Item("EarthquakePremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EarthquakePremium = veri.Item("EarthquakePremium")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OtherFees = veri.Item("OtherFees")
                End If

                If Not veri.Item("TotalPremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TotalPremium = veri.Item("TotalPremium")
                End If

                If Not veri.Item("FirePremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirePremiumTL = veri.Item("FirePremiumTL")
                End If

                If Not veri.Item("SupplementaryGuaranteePremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL = veri.Item("SupplementaryGuaranteePremiumTL")
                End If

                If Not veri.Item("EarthquakePremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EarthquakePremiumTL = veri.Item("EarthquakePremiumTL")
                End If

                If Not veri.Item("OtherFeesTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OtherFeesTL = veri.Item("OtherFeesTL")
                End If

                If Not veri.Item("TotalPremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TotalPremiumTL = veri.Item("TotalPremiumTL")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("FSBMCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FSBMCode = veri.Item("FSBMCode")
                End If


                firePolicyInfolar.Add(New FirePolicyInfo(donecekFirePolicyInfo.pkey,
                donecekFirePolicyInfo.FirmCode, donecekFirePolicyInfo.ProductCode, donecekFirePolicyInfo.AgencyCode, donecekFirePolicyInfo.PolicyNumber,
                donecekFirePolicyInfo.TecditNumber, donecekFirePolicyInfo.ZeylCode, donecekFirePolicyInfo.ZeyilNo, donecekFirePolicyInfo.PolicyType,
                donecekFirePolicyInfo.ArrangeDate, donecekFirePolicyInfo.StartDate, donecekFirePolicyInfo.EndDate, donecekFirePolicyInfo.PolicyOwnerCountryCode,
                donecekFirePolicyInfo.PolicyOwnerIdentityCode, donecekFirePolicyInfo.PolicyOwnerIdentityNo, donecekFirePolicyInfo.PolicyOwnerName, donecekFirePolicyInfo.PolicyOwnerSurname,
                donecekFirePolicyInfo.InsuredTitle, donecekFirePolicyInfo.RiskAddress_ilcekod, donecekFirePolicyInfo.RiskAddress_bucakkod, donecekFirePolicyInfo.RiskAddress_belediyekod,
                donecekFirePolicyInfo.RiskAddress_mahallekod, donecekFirePolicyInfo.RiskAddress_sokakkod, donecekFirePolicyInfo.FirstBeneficiary, donecekFirePolicyInfo.Creditor,
                donecekFirePolicyInfo.RiskType, donecekFirePolicyInfo.StructureStyle, donecekFirePolicyInfo.OfficeBlock, donecekFirePolicyInfo.Activity,
                donecekFirePolicyInfo.AgencyRegisterCode, donecekFirePolicyInfo.TPNo, donecekFirePolicyInfo.Building, donecekFirePolicyInfo.Contents,
                donecekFirePolicyInfo.EartQuake, donecekFirePolicyInfo.FloodFlooding, donecekFirePolicyInfo.InternalWater, donecekFirePolicyInfo.Storm,
                donecekFirePolicyInfo.Theft, donecekFirePolicyInfo.LandVehicles, donecekFirePolicyInfo.AirCraft, donecekFirePolicyInfo.MaritimeVehicles,
                donecekFirePolicyInfo.Smoke, donecekFirePolicyInfo.SpaceShift, donecekFirePolicyInfo.GLKHH, donecekFirePolicyInfo.MaliciousTerror,
                donecekFirePolicyInfo.OtherGuarentees, donecekFirePolicyInfo.Latitude, donecekFirePolicyInfo.Longitude, donecekFirePolicyInfo.BuildingValue,
                donecekFirePolicyInfo.ContentsValue, donecekFirePolicyInfo.CurrencyCode, donecekFirePolicyInfo.ExchangeRate, donecekFirePolicyInfo.FirePremium,
                donecekFirePolicyInfo.SupplementaryGuaranteePremium, donecekFirePolicyInfo.EarthquakePremium, donecekFirePolicyInfo.OtherFees, donecekFirePolicyInfo.TotalPremium,
                donecekFirePolicyInfo.FirePremiumTL, donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL, donecekFirePolicyInfo.EarthquakePremiumTL, donecekFirePolicyInfo.OtherFeesTL,
                donecekFirePolicyInfo.TotalPremiumTL, donecekFirePolicyInfo.PolicyPremiumTL, donecekFirePolicyInfo.Color, donecekFirePolicyInfo.FSBMCode))

            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return firePolicyInfolar

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from FirePolicyInfo where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkey
            komut.Parameters.Add(param1)

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
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using

        Return resultset

    End Function




    '---------------------------------doldur-----------------------------------------
    Public Function policedoldur_ilgilihasar(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String,
    ByVal TecditNumber As String, ByVal PolicyType As String) As List(Of FirePolicyInfo)

        Dim donecekFirePolicyInfo As New FirePolicyInfo
        Dim FirePolicyInfoler As New List(Of FirePolicyInfo)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()

            komut.Connection = db_baglanti
            sqlstr = "select * from FirePolicyInfo where " +
            "FirmCode=@FirmCode and " +
            "ProductCode=@ProductCode and " +
            "AgencyCode=@AgencyCode and " +
            "PolicyNumber=@PolicyNumber and " +
            "TecditNumber=@TecditNumber and " +
            "PolicyType=@PolicyType "

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

            Dim param6 As New SqlParameter("@PolicyType", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            param6.Value = PolicyType
            komut.Parameters.Add(param6)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirmCode = veri.Item("FirmCode")
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ProductCode = veri.Item("ProductCode")
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AgencyCode = veri.Item("AgencyCode")
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TecditNumber = veri.Item("TecditNumber")
                    End If

                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ZeylCode = veri.Item("ZeylCode")
                    End If

                    If Not veri.Item("ZeyilNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ZeyilNo = veri.Item("ZeyilNo")
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyType = veri.Item("PolicyType")
                    End If

                    If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                    End If

                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.StartDate = veri.Item("StartDate")
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EndDate = veri.Item("EndDate")
                    End If

                    If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                    End If

                    If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                    End If

                    If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                    End If

                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                    End If

                    If Not veri.Item("InsuredTitle") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.InsuredTitle = veri.Item("InsuredTitle")
                    End If

                    If Not veri.Item("RiskAddress_ilcekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_ilcekod = veri.Item("RiskAddress_ilcekod")
                    End If

                    If Not veri.Item("RiskAddress_bucakkod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_bucakkod = veri.Item("RiskAddress_bucakkod")
                    End If

                    If Not veri.Item("RiskAddress_belediyekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_belediyekod = veri.Item("RiskAddress_belediyekod")
                    End If

                    If Not veri.Item("RiskAddress_mahallekod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_mahallekod = veri.Item("RiskAddress_mahallekod")
                    End If

                    If Not veri.Item("RiskAddress_sokakkod") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskAddress_sokakkod = veri.Item("RiskAddress_sokakkod")
                    End If

                    If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                    End If

                    If Not veri.Item("Creditor") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Creditor = veri.Item("Creditor")
                    End If

                    If Not veri.Item("RiskType") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.RiskType = veri.Item("RiskType")
                    End If

                    If Not veri.Item("StructureStyle") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.StructureStyle = veri.Item("StructureStyle")
                    End If

                    If Not veri.Item("OfficeBlock") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OfficeBlock = veri.Item("OfficeBlock")
                    End If

                    If Not veri.Item("Activity") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Activity = veri.Item("Activity")
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TPNo = veri.Item("TPNo")
                    End If

                    If Not veri.Item("Building") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Building = veri.Item("Building")
                    End If

                    If Not veri.Item("Contents") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Contents = veri.Item("Contents")
                    End If

                    If Not veri.Item("EartQuake") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EartQuake = veri.Item("EartQuake")
                    End If

                    If Not veri.Item("FloodFlooding") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FloodFlooding = veri.Item("FloodFlooding")
                    End If

                    If Not veri.Item("InternalWater") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.InternalWater = veri.Item("InternalWater")
                    End If

                    If Not veri.Item("Storm") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Storm = veri.Item("Storm")
                    End If

                    If Not veri.Item("Theft") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Theft = veri.Item("Theft")
                    End If

                    If Not veri.Item("LandVehicles") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.LandVehicles = veri.Item("LandVehicles")
                    End If

                    If Not veri.Item("AirCraft") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.AirCraft = veri.Item("AirCraft")
                    End If

                    If Not veri.Item("MaritimeVehicles") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.MaritimeVehicles = veri.Item("MaritimeVehicles")
                    End If

                    If Not veri.Item("Smoke") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Smoke = veri.Item("Smoke")
                    End If

                    If Not veri.Item("SpaceShift") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SpaceShift = veri.Item("SpaceShift")
                    End If

                    If Not veri.Item("GLKHH") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.GLKHH = veri.Item("GLKHH")
                    End If

                    If Not veri.Item("MaliciousTerror") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.MaliciousTerror = veri.Item("MaliciousTerror")
                    End If

                    If Not veri.Item("OtherGuarentees") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherGuarentees = veri.Item("OtherGuarentees")
                    End If

                    If Not veri.Item("Latitude") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Latitude = veri.Item("Latitude")
                    End If

                    If Not veri.Item("Longitude") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Longitude = veri.Item("Longitude")
                    End If

                    If Not veri.Item("BuildingValue") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.BuildingValue = veri.Item("BuildingValue")
                    End If

                    If Not veri.Item("ContentsValue") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ContentsValue = veri.Item("ContentsValue")
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                    End If

                    If Not veri.Item("FirePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirePremium = veri.Item("FirePremium")
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SupplementaryGuaranteePremium = veri.Item("SupplementaryGuaranteePremium")
                    End If

                    If Not veri.Item("EarthquakePremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EarthquakePremium = veri.Item("EarthquakePremium")
                    End If

                    If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherFees = veri.Item("OtherFees")
                    End If

                    If Not veri.Item("TotalPremium") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TotalPremium = veri.Item("TotalPremium")
                    End If

                    If Not veri.Item("FirePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FirePremiumTL = veri.Item("FirePremiumTL")
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL = veri.Item("SupplementaryGuaranteePremiumTL")
                    End If

                    If Not veri.Item("EarthquakePremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.EarthquakePremiumTL = veri.Item("EarthquakePremiumTL")
                    End If

                    If Not veri.Item("OtherFeesTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.OtherFeesTL = veri.Item("OtherFeesTL")
                    End If

                    If Not veri.Item("TotalPremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.TotalPremiumTL = veri.Item("TotalPremiumTL")
                    End If

                    If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                    End If

                    If Not veri.Item("Color") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.Color = veri.Item("Color")
                    End If

                    If Not veri.Item("FSBMCode") Is System.DBNull.Value Then
                        donecekFirePolicyInfo.FSBMCode = veri.Item("FSBMCode")
                    End If


                    FirePolicyInfoler.Add(New FirePolicyInfo(donecekFirePolicyInfo.pkey,
                    donecekFirePolicyInfo.FirmCode, donecekFirePolicyInfo.ProductCode, donecekFirePolicyInfo.AgencyCode, donecekFirePolicyInfo.PolicyNumber,
                    donecekFirePolicyInfo.TecditNumber, donecekFirePolicyInfo.ZeylCode, donecekFirePolicyInfo.ZeyilNo, donecekFirePolicyInfo.PolicyType,
                    donecekFirePolicyInfo.ArrangeDate, donecekFirePolicyInfo.StartDate, donecekFirePolicyInfo.EndDate, donecekFirePolicyInfo.PolicyOwnerCountryCode,
                    donecekFirePolicyInfo.PolicyOwnerIdentityCode, donecekFirePolicyInfo.PolicyOwnerIdentityNo, donecekFirePolicyInfo.PolicyOwnerName, donecekFirePolicyInfo.PolicyOwnerSurname,
                    donecekFirePolicyInfo.InsuredTitle, donecekFirePolicyInfo.RiskAddress_ilcekod, donecekFirePolicyInfo.RiskAddress_bucakkod, donecekFirePolicyInfo.RiskAddress_belediyekod,
                    donecekFirePolicyInfo.RiskAddress_mahallekod, donecekFirePolicyInfo.RiskAddress_sokakkod, donecekFirePolicyInfo.FirstBeneficiary, donecekFirePolicyInfo.Creditor,
                    donecekFirePolicyInfo.RiskType, donecekFirePolicyInfo.StructureStyle, donecekFirePolicyInfo.OfficeBlock, donecekFirePolicyInfo.Activity,
                    donecekFirePolicyInfo.AgencyRegisterCode, donecekFirePolicyInfo.TPNo, donecekFirePolicyInfo.Building, donecekFirePolicyInfo.Contents,
                    donecekFirePolicyInfo.EartQuake, donecekFirePolicyInfo.FloodFlooding, donecekFirePolicyInfo.InternalWater, donecekFirePolicyInfo.Storm,
                    donecekFirePolicyInfo.Theft, donecekFirePolicyInfo.LandVehicles, donecekFirePolicyInfo.AirCraft, donecekFirePolicyInfo.MaritimeVehicles,
                    donecekFirePolicyInfo.Smoke, donecekFirePolicyInfo.SpaceShift, donecekFirePolicyInfo.GLKHH, donecekFirePolicyInfo.MaliciousTerror,
                    donecekFirePolicyInfo.OtherGuarentees, donecekFirePolicyInfo.Latitude, donecekFirePolicyInfo.Longitude, donecekFirePolicyInfo.BuildingValue,
                    donecekFirePolicyInfo.ContentsValue, donecekFirePolicyInfo.CurrencyCode, donecekFirePolicyInfo.ExchangeRate, donecekFirePolicyInfo.FirePremium,
                    donecekFirePolicyInfo.SupplementaryGuaranteePremium, donecekFirePolicyInfo.EarthquakePremium, donecekFirePolicyInfo.OtherFees, donecekFirePolicyInfo.TotalPremium,
                    donecekFirePolicyInfo.FirePremiumTL, donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL, donecekFirePolicyInfo.EarthquakePremiumTL, donecekFirePolicyInfo.OtherFeesTL,
                    donecekFirePolicyInfo.TotalPremiumTL, donecekFirePolicyInfo.PolicyPremiumTL, donecekFirePolicyInfo.Color, donecekFirePolicyInfo.FSBMCode))

                End While
            End Using

            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using

        Return FirePolicyInfoler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20, kol21, kol22, kol23, kol24, kol25, kol26, kol27, kol28, kol29, kol30, kol31, kol32, kol33, kol34, kol35, kol36, kol37, kol38, kol39, kol40, kol41, kol42, kol43, kol44, kol45, kol46, kol47, kol48, kol49, kol50, kol51, kol52, kol53, kol54, kol55, kol56, kol57, kol58, kol59, kol60, kol61, kol62, kol63, kol64, kol65 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" +
        "<thead>" +
        "<tr>" +
        "<th>pkey</th>" +
        "<th>FirmCode</th>" +
        "<th>ProductCode</th>" +
        "<th>AgencyCode</th>" +
        "<th>PolicyNumber</th>" +
        "<th>TecditNumber</th>" +
        "<th>ZeylCode</th>" +
        "<th>ZeyilNo</th>" +
        "<th>PolicyType</th>" +
        "<th>ArrangeDate</th>" +
        "<th>StartDate</th>" +
        "<th>EndDate</th>" +
        "<th>PolicyOwnerCountryCode</th>" +
        "<th>PolicyOwnerIdentityCode</th>" +
        "<th>PolicyOwnerIdentityNo</th>" +
        "<th>PolicyOwnerName</th>" +
        "<th>PolicyOwnerSurname</th>" +
        "<th>InsuredTitle</th>" +
        "<th>RiskAddress_ilcekod</th>" +
        "<th>RiskAddress_bucakkod</th>" +
        "<th>RiskAddress_belediyekod</th>" +
        "<th>RiskAddress_mahallekod</th>" +
        "<th>RiskAddress_sokakkod</th>" +
        "<th>FirstBeneficiary</th>" +
        "<th>Creditor</th>" +
        "<th>RiskType</th>" +
        "<th>StructureStyle</th>" +
        "<th>OfficeBlock</th>" +
        "<th>Activity</th>" +
        "<th>AgencyRegisterCode</th>" +
        "<th>TPNo</th>" +
        "<th>Building</th>" +
        "<th>Contents</th>" +
        "<th>EartQuake</th>" +
        "<th>FloodFlooding</th>" +
        "<th>InternalWater</th>" +
        "<th>Storm</th>" +
        "<th>Theft</th>" +
        "<th>LandVehicles</th>" +
        "<th>AirCraft</th>" +
        "<th>MaritimeVehicles</th>" +
        "<th>Smoke</th>" +
        "<th>SpaceShift</th>" +
        "<th>GLKHH</th>" +
        "<th>MaliciousTerror</th>" +
        "<th>OtherGuarentees</th>" +
        "<th>Latitude</th>" +
        "<th>Longitude</th>" +
        "<th>BuildingValue</th>" +
        "<th>ContentsValue</th>" +
        "<th>CurrencyCode</th>" +
        "<th>ExchangeRate</th>" +
        "<th>FirePremium</th>" +
        "<th>SupplementaryGuaranteePremium</th>" +
        "<th>EarthquakePremium</th>" +
        "<th>OtherFees</th>" +
        "<th>TotalPremium</th>" +
        "<th>FirePremiumTL</th>" +
        "<th>SupplementaryGuaranteePremiumTL</th>" +
        "<th>EarthquakePremiumTL</th>" +
        "<th>OtherFeesTL</th>" +
        "<th>TotalPremiumTL</th>" +
        "<th>PolicyPremiumTL</th>" +
        "<th>Color</th>" +
        "<th>FSBMCode</th>" +
        "</tr>" +
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from FirePolicyInfo"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If
        If HttpContext.Current.Session("ltip") = "adsoyad" Then
            sqlstr = "select * from FirePolicyInfo where adsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeyilNo, PolicyType, ArrangeDate, StartDate, EndDate, PolicyOwnerCountryCode, PolicyOwnerIdentityCode, PolicyOwnerIdentityNo, PolicyOwnerName, PolicyOwnerSurname, InsuredTitle, RiskAddress_ilcekod, RiskAddress_bucakkod, RiskAddress_belediyekod, RiskAddress_mahallekod, RiskAddress_sokakkod, FirstBeneficiary, Creditor, RiskType, StructureStyle, OfficeBlock, Activity, AgencyRegisterCode, TPNo, Building, Contents, EartQuake, FloodFlooding, InternalWater, Storm, Theft, LandVehicles, AirCraft, MaritimeVehicles, Smoke, SpaceShift, GLKHH, MaliciousTerror, OtherGuarentees, Latitude, Longitude, BuildingValue, ContentsValue, CurrencyCode, ExchangeRate, FirePremium, SupplementaryGuaranteePremium, EarthquakePremium, OtherFees, TotalPremium, FirePremiumTL, SupplementaryGuaranteePremiumTL, EarthquakePremiumTL, OtherFeesTL, TotalPremiumTL, PolicyPremiumTL, Color, FSBMCode As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "FirePolicyInfo.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        kol2 = "<td>" + FirmCode + "</td>"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol3 = "<td>" + ProductCode + "</td>"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol4 = "<td>" + AgencyCode + "</td>"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol5 = "<td>" + PolicyNumber + "</td>"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                        kol6 = "<td>" + TecditNumber + "</td>"
                    End If

                    If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                        ZeylCode = veri.Item("ZeylCode")
                        kol7 = "<td>" + ZeylCode + "</td>"
                    End If

                    If Not veri.Item("ZeyilNo") Is System.DBNull.Value Then
                        ZeyilNo = veri.Item("ZeyilNo")
                        kol8 = "<td>" + ZeyilNo + "</td>"
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        PolicyType = veri.Item("PolicyType")
                        kol9 = "<td>" + PolicyType + "</td>"
                    End If

                    If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                        ArrangeDate = veri.Item("ArrangeDate")
                        kol10 = "<td>" + ArrangeDate + "</td>"
                    End If

                    If Not veri.Item("StartDate") Is System.DBNull.Value Then
                        StartDate = veri.Item("StartDate")
                        kol11 = "<td>" + StartDate + "</td>"
                    End If

                    If Not veri.Item("EndDate") Is System.DBNull.Value Then
                        EndDate = veri.Item("EndDate")
                        kol12 = "<td>" + EndDate + "</td>"
                    End If

                    If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                        PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                        kol13 = "<td>" + PolicyOwnerCountryCode + "</td>"
                    End If

                    If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                        PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                        kol14 = "<td>" + PolicyOwnerIdentityCode + "</td>"
                    End If

                    If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                        PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                        kol15 = "<td>" + PolicyOwnerIdentityNo + "</td>"
                    End If

                    If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                        PolicyOwnerName = veri.Item("PolicyOwnerName")
                        kol16 = "<td>" + PolicyOwnerName + "</td>"
                    End If

                    If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                        PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                        kol17 = "<td>" + PolicyOwnerSurname + "</td>"
                    End If

                    If Not veri.Item("InsuredTitle") Is System.DBNull.Value Then
                        InsuredTitle = veri.Item("InsuredTitle")
                        kol18 = "<td>" + InsuredTitle + "</td>"
                    End If

                    If Not veri.Item("RiskAddress_ilcekod") Is System.DBNull.Value Then
                        RiskAddress_ilcekod = veri.Item("RiskAddress_ilcekod")
                        kol19 = "<td>" + RiskAddress_ilcekod + "</td>"
                    End If

                    If Not veri.Item("RiskAddress_bucakkod") Is System.DBNull.Value Then
                        RiskAddress_bucakkod = veri.Item("RiskAddress_bucakkod")
                        kol20 = "<td>" + RiskAddress_bucakkod + "</td>"
                    End If

                    If Not veri.Item("RiskAddress_belediyekod") Is System.DBNull.Value Then
                        RiskAddress_belediyekod = veri.Item("RiskAddress_belediyekod")
                        kol21 = "<td>" + RiskAddress_belediyekod + "</td>"
                    End If

                    If Not veri.Item("RiskAddress_mahallekod") Is System.DBNull.Value Then
                        RiskAddress_mahallekod = veri.Item("RiskAddress_mahallekod")
                        kol22 = "<td>" + RiskAddress_mahallekod + "</td>"
                    End If

                    If Not veri.Item("RiskAddress_sokakkod") Is System.DBNull.Value Then
                        RiskAddress_sokakkod = veri.Item("RiskAddress_sokakkod")
                        kol23 = "<td>" + RiskAddress_sokakkod + "</td>"
                    End If

                    If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                        FirstBeneficiary = veri.Item("FirstBeneficiary")
                        kol24 = "<td>" + FirstBeneficiary + "</td>"
                    End If

                    If Not veri.Item("Creditor") Is System.DBNull.Value Then
                        Creditor = veri.Item("Creditor")
                        kol25 = "<td>" + Creditor + "</td>"
                    End If

                    If Not veri.Item("RiskType") Is System.DBNull.Value Then
                        RiskType = veri.Item("RiskType")
                        kol26 = "<td>" + RiskType + "</td>"
                    End If

                    If Not veri.Item("StructureStyle") Is System.DBNull.Value Then
                        StructureStyle = veri.Item("StructureStyle")
                        kol27 = "<td>" + StructureStyle + "</td>"
                    End If

                    If Not veri.Item("OfficeBlock") Is System.DBNull.Value Then
                        OfficeBlock = veri.Item("OfficeBlock")
                        kol28 = "<td>" + OfficeBlock + "</td>"
                    End If

                    If Not veri.Item("Activity") Is System.DBNull.Value Then
                        Activity = veri.Item("Activity")
                        kol29 = "<td>" + Activity + "</td>"
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                        kol30 = "<td>" + AgencyRegisterCode + "</td>"
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        TPNo = veri.Item("TPNo")
                        kol31 = "<td>" + TPNo + "</td>"
                    End If

                    If Not veri.Item("Building") Is System.DBNull.Value Then
                        Building = veri.Item("Building")
                        kol32 = "<td>" + Building + "</td>"
                    End If

                    If Not veri.Item("Contents") Is System.DBNull.Value Then
                        Contents = veri.Item("Contents")
                        kol33 = "<td>" + Contents + "</td>"
                    End If

                    If Not veri.Item("EartQuake") Is System.DBNull.Value Then
                        EartQuake = veri.Item("EartQuake")
                        kol34 = "<td>" + EartQuake + "</td>"
                    End If

                    If Not veri.Item("FloodFlooding") Is System.DBNull.Value Then
                        FloodFlooding = veri.Item("FloodFlooding")
                        kol35 = "<td>" + FloodFlooding + "</td>"
                    End If

                    If Not veri.Item("InternalWater") Is System.DBNull.Value Then
                        InternalWater = veri.Item("InternalWater")
                        kol36 = "<td>" + InternalWater + "</td>"
                    End If

                    If Not veri.Item("Storm") Is System.DBNull.Value Then
                        Storm = veri.Item("Storm")
                        kol37 = "<td>" + Storm + "</td>"
                    End If

                    If Not veri.Item("Theft") Is System.DBNull.Value Then
                        Theft = veri.Item("Theft")
                        kol38 = "<td>" + Theft + "</td>"
                    End If

                    If Not veri.Item("LandVehicles") Is System.DBNull.Value Then
                        LandVehicles = veri.Item("LandVehicles")
                        kol39 = "<td>" + LandVehicles + "</td>"
                    End If

                    If Not veri.Item("AirCraft") Is System.DBNull.Value Then
                        AirCraft = veri.Item("AirCraft")
                        kol40 = "<td>" + AirCraft + "</td>"
                    End If

                    If Not veri.Item("MaritimeVehicles") Is System.DBNull.Value Then
                        MaritimeVehicles = veri.Item("MaritimeVehicles")
                        kol41 = "<td>" + MaritimeVehicles + "</td>"
                    End If

                    If Not veri.Item("Smoke") Is System.DBNull.Value Then
                        Smoke = veri.Item("Smoke")
                        kol42 = "<td>" + Smoke + "</td>"
                    End If

                    If Not veri.Item("SpaceShift") Is System.DBNull.Value Then
                        SpaceShift = veri.Item("SpaceShift")
                        kol43 = "<td>" + SpaceShift + "</td>"
                    End If

                    If Not veri.Item("GLKHH") Is System.DBNull.Value Then
                        GLKHH = veri.Item("GLKHH")
                        kol44 = "<td>" + GLKHH + "</td>"
                    End If

                    If Not veri.Item("MaliciousTerror") Is System.DBNull.Value Then
                        MaliciousTerror = veri.Item("MaliciousTerror")
                        kol45 = "<td>" + MaliciousTerror + "</td>"
                    End If

                    If Not veri.Item("OtherGuarentees") Is System.DBNull.Value Then
                        OtherGuarentees = veri.Item("OtherGuarentees")
                        kol46 = "<td>" + OtherGuarentees + "</td>"
                    End If

                    If Not veri.Item("Latitude") Is System.DBNull.Value Then
                        Latitude = veri.Item("Latitude")
                        kol47 = "<td>" + Latitude + "</td>"
                    End If

                    If Not veri.Item("Longitude") Is System.DBNull.Value Then
                        Longitude = veri.Item("Longitude")
                        kol48 = "<td>" + Longitude + "</td>"
                    End If

                    If Not veri.Item("BuildingValue") Is System.DBNull.Value Then
                        BuildingValue = veri.Item("BuildingValue")
                        kol49 = "<td>" + BuildingValue + "</td>"
                    End If

                    If Not veri.Item("ContentsValue") Is System.DBNull.Value Then
                        ContentsValue = veri.Item("ContentsValue")
                        kol50 = "<td>" + ContentsValue + "</td>"
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        CurrencyCode = veri.Item("CurrencyCode")
                        kol51 = "<td>" + CurrencyCode + "</td>"
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        ExchangeRate = veri.Item("ExchangeRate")
                        kol52 = "<td>" + ExchangeRate + "</td>"
                    End If

                    If Not veri.Item("FirePremium") Is System.DBNull.Value Then
                        FirePremium = veri.Item("FirePremium")
                        kol53 = "<td>" + FirePremium + "</td>"
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremium") Is System.DBNull.Value Then
                        SupplementaryGuaranteePremium = veri.Item("SupplementaryGuaranteePremium")
                        kol54 = "<td>" + SupplementaryGuaranteePremium + "</td>"
                    End If

                    If Not veri.Item("EarthquakePremium") Is System.DBNull.Value Then
                        EarthquakePremium = veri.Item("EarthquakePremium")
                        kol55 = "<td>" + EarthquakePremium + "</td>"
                    End If

                    If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                        OtherFees = veri.Item("OtherFees")
                        kol56 = "<td>" + OtherFees + "</td>"
                    End If

                    If Not veri.Item("TotalPremium") Is System.DBNull.Value Then
                        TotalPremium = veri.Item("TotalPremium")
                        kol57 = "<td>" + TotalPremium + "</td>"
                    End If

                    If Not veri.Item("FirePremiumTL") Is System.DBNull.Value Then
                        FirePremiumTL = veri.Item("FirePremiumTL")
                        kol58 = "<td>" + FirePremiumTL + "</td>"
                    End If

                    If Not veri.Item("SupplementaryGuaranteePremiumTL") Is System.DBNull.Value Then
                        SupplementaryGuaranteePremiumTL = veri.Item("SupplementaryGuaranteePremiumTL")
                        kol59 = "<td>" + SupplementaryGuaranteePremiumTL + "</td>"
                    End If

                    If Not veri.Item("EarthquakePremiumTL") Is System.DBNull.Value Then
                        EarthquakePremiumTL = veri.Item("EarthquakePremiumTL")
                        kol60 = "<td>" + EarthquakePremiumTL + "</td>"
                    End If

                    If Not veri.Item("OtherFeesTL") Is System.DBNull.Value Then
                        OtherFeesTL = veri.Item("OtherFeesTL")
                        kol61 = "<td>" + OtherFeesTL + "</td>"
                    End If

                    If Not veri.Item("TotalPremiumTL") Is System.DBNull.Value Then
                        TotalPremiumTL = veri.Item("TotalPremiumTL")
                        kol62 = "<td>" + TotalPremiumTL + "</td>"
                    End If

                    If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                        PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                        kol63 = "<td>" + PolicyPremiumTL + "</td>"
                    End If

                    If Not veri.Item("Color") Is System.DBNull.Value Then
                        Color = veri.Item("Color")
                        kol64 = "<td>" + Color + "</td>"
                    End If

                    If Not veri.Item("FSBMCode") Is System.DBNull.Value Then
                        FSBMCode = veri.Item("FSBMCode")
                        kol65 = "<td>" + FSBMCode + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + kol9 + kol10 +
                   kol11 + kol12 + kol13 + kol14 + kol15 + kol16 + kol17 + kol18 + kol19 + kol20 +
                   kol21 + kol22 + kol23 + kol24 + kol25 + kol26 + kol27 + kol28 + kol29 + kol30 +
                   kol31 + kol32 + kol33 + kol34 + kol35 + kol36 + kol37 + kol38 + kol39 + kol40 +
                   kol41 + kol42 + kol43 + kol44 + kol45 + kol46 + kol47 + kol48 + kol49 + kol50 +
                   kol51 + kol52 + kol53 + kol54 + kol55 + kol56 + kol57 + kol58 + kol59 + kol60 +
                   kol61 + kol62 + kol63 + kol64 + kol65

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
        db_baglanti.Dispose()
        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function


    Public Function ciftkayitkontrol(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String,
    ByVal TecditNumber As String, ByVal ZeylCode As String,
    ByVal ZeyilNo As String, ByVal PolicyType As String) As Integer


        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim kackayit As Integer = 0
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", FirmCode, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", ProductCode, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AgencyCode", "=", AgencyCode, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyNumber", "=", PolicyNumber, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TecditNumber", "=", TecditNumber, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeylCode", "=", ZeylCode, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeyilNo", "=", ZeyilNo, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", PolicyType, " "))

        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "FirePolicyInfo", "count(*)", fieldopvalues)
        Return kackayit

    End Function


    Public Function policeadet_sirketin(ByVal FirmCode As String)


        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim kackayit As Integer = 0
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", FirmCode, " "))
        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "FirePolicyInfo", "count(*)", fieldopvalues)
        Return kackayit

    End Function


    Public Function sonzeyilbul(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String,
    ByVal PolicyNumber As String, ByVal TecditNumber As String, ByVal PolicyType As String) As FirePolicyInfo

        Dim kacadet As Integer
        Dim sonzeyil As New FirePolicyInfo
        Dim zeyiller As New List(Of FirePolicyInfo)

        zeyiller = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, PolicyNumber, PolicyType)
        kacadet = zeyiller.Count

        Dim i As Integer = 1
        For Each zeyilitem In zeyiller
            If i = kacadet Then
                sonzeyil = zeyilitem
            End If
            i = i + 1
        Next

        Return sonzeyil

    End Function


    Function zeyilnumarasi_aynimi(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String,
    ByVal ZeyilNo As String, ByVal PolicyType As String) As String

        Dim aynivarmi = "Hayır"

        Dim policeninzeyilleri As New List(Of FirePolicyInfo)
        policeninzeyilleri = zeyildoldur_ilgilipolice_tecditli(FirmCode, ProductCode, AgencyCode,
        PolicyNumber, TecditNumber, PolicyType)

        For Each itemzeyil As FirePolicyInfo In policeninzeyilleri
            If itemzeyil.ZeyilNo = ZeyilNo Then
                aynivarmi = "Evet"
                Exit For
            End If
        Next

        Return aynivarmi

    End Function


    Function zeyildoldur_ilgilipolice(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal PolicyType As String) As List(Of FirePolicyInfo)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekFirePolicyInfo As New FirePolicyInfo
        Dim FirePolicyInfolar As New List(Of FirePolicyInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from FirePolicyInfo where" +
        " FirmCode=@FirmCode" +
        " and ProductCode=@ProductCode " +
        " and AgencyCode=@AgencyCode " +
        " and PolicyNumber=@PolicyNumber " +
        " and PolicyType=@PolicyType " +
        " order by TecditNumber,ZeyilNo"

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

        Dim param5 As New SqlParameter("@PolicyType", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = PolicyType
        komut.Parameters.Add(param5)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeyilNo") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ZeyilNo = veri.Item("ZeyilNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.StartDate = veri.Item("StartDate")
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EndDate = veri.Item("EndDate")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("InsuredTitle") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.InsuredTitle = veri.Item("InsuredTitle")
                End If

                If Not veri.Item("RiskAddress_ilcekod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_ilcekod = veri.Item("RiskAddress_ilcekod")
                End If

                If Not veri.Item("RiskAddress_bucakkod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_bucakkod = veri.Item("RiskAddress_bucakkod")
                End If

                If Not veri.Item("RiskAddress_belediyekod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_belediyekod = veri.Item("RiskAddress_belediyekod")
                End If

                If Not veri.Item("RiskAddress_mahallekod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_mahallekod = veri.Item("RiskAddress_mahallekod")
                End If

                If Not veri.Item("RiskAddress_sokakkod") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskAddress_sokakkod = veri.Item("RiskAddress_sokakkod")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("RiskType") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.RiskType = veri.Item("RiskType")
                End If

                If Not veri.Item("StructureStyle") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.StructureStyle = veri.Item("StructureStyle")
                End If

                If Not veri.Item("OfficeBlock") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OfficeBlock = veri.Item("OfficeBlock")
                End If

                If Not veri.Item("Activity") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Activity = veri.Item("Activity")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("Building") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Building = veri.Item("Building")
                End If

                If Not veri.Item("Contents") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Contents = veri.Item("Contents")
                End If

                If Not veri.Item("EartQuake") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EartQuake = veri.Item("EartQuake")
                End If

                If Not veri.Item("FloodFlooding") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FloodFlooding = veri.Item("FloodFlooding")
                End If

                If Not veri.Item("InternalWater") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.InternalWater = veri.Item("InternalWater")
                End If

                If Not veri.Item("Storm") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Storm = veri.Item("Storm")
                End If

                If Not veri.Item("Theft") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Theft = veri.Item("Theft")
                End If

                If Not veri.Item("LandVehicles") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.LandVehicles = veri.Item("LandVehicles")
                End If

                If Not veri.Item("AirCraft") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.AirCraft = veri.Item("AirCraft")
                End If

                If Not veri.Item("MaritimeVehicles") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.MaritimeVehicles = veri.Item("MaritimeVehicles")
                End If

                If Not veri.Item("Smoke") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Smoke = veri.Item("Smoke")
                End If

                If Not veri.Item("SpaceShift") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.SpaceShift = veri.Item("SpaceShift")
                End If

                If Not veri.Item("GLKHH") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.GLKHH = veri.Item("GLKHH")
                End If

                If Not veri.Item("MaliciousTerror") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.MaliciousTerror = veri.Item("MaliciousTerror")
                End If

                If Not veri.Item("OtherGuarentees") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OtherGuarentees = veri.Item("OtherGuarentees")
                End If

                If Not veri.Item("Latitude") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Latitude = veri.Item("Latitude")
                End If

                If Not veri.Item("Longitude") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Longitude = veri.Item("Longitude")
                End If

                If Not veri.Item("BuildingValue") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.BuildingValue = veri.Item("BuildingValue")
                End If

                If Not veri.Item("ContentsValue") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ContentsValue = veri.Item("ContentsValue")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("FirePremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirePremium = veri.Item("FirePremium")
                End If

                If Not veri.Item("SupplementaryGuaranteePremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.SupplementaryGuaranteePremium = veri.Item("SupplementaryGuaranteePremium")
                End If

                If Not veri.Item("EarthquakePremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EarthquakePremium = veri.Item("EarthquakePremium")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OtherFees = veri.Item("OtherFees")
                End If

                If Not veri.Item("TotalPremium") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TotalPremium = veri.Item("TotalPremium")
                End If

                If Not veri.Item("FirePremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FirePremiumTL = veri.Item("FirePremiumTL")
                End If

                If Not veri.Item("SupplementaryGuaranteePremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL = veri.Item("SupplementaryGuaranteePremiumTL")
                End If

                If Not veri.Item("EarthquakePremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.EarthquakePremiumTL = veri.Item("EarthquakePremiumTL")
                End If

                If Not veri.Item("OtherFeesTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.OtherFeesTL = veri.Item("OtherFeesTL")
                End If

                If Not veri.Item("TotalPremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.TotalPremiumTL = veri.Item("TotalPremiumTL")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("FSBMCode") Is System.DBNull.Value Then
                    donecekFirePolicyInfo.FSBMCode = veri.Item("FSBMCode")
                End If

                FirePolicyInfolar.Add(New FirePolicyInfo(donecekFirePolicyInfo.pkey,
                 donecekFirePolicyInfo.FirmCode, donecekFirePolicyInfo.ProductCode, donecekFirePolicyInfo.AgencyCode, donecekFirePolicyInfo.PolicyNumber,
                 donecekFirePolicyInfo.TecditNumber, donecekFirePolicyInfo.ZeylCode, donecekFirePolicyInfo.ZeyilNo, donecekFirePolicyInfo.PolicyType,
                 donecekFirePolicyInfo.ArrangeDate, donecekFirePolicyInfo.StartDate, donecekFirePolicyInfo.EndDate, donecekFirePolicyInfo.PolicyOwnerCountryCode,
                 donecekFirePolicyInfo.PolicyOwnerIdentityCode, donecekFirePolicyInfo.PolicyOwnerIdentityNo, donecekFirePolicyInfo.PolicyOwnerName, donecekFirePolicyInfo.PolicyOwnerSurname,
                 donecekFirePolicyInfo.InsuredTitle, donecekFirePolicyInfo.RiskAddress_ilcekod, donecekFirePolicyInfo.RiskAddress_bucakkod, donecekFirePolicyInfo.RiskAddress_belediyekod,
                 donecekFirePolicyInfo.RiskAddress_mahallekod, donecekFirePolicyInfo.RiskAddress_sokakkod, donecekFirePolicyInfo.FirstBeneficiary, donecekFirePolicyInfo.Creditor,
                 donecekFirePolicyInfo.RiskType, donecekFirePolicyInfo.StructureStyle, donecekFirePolicyInfo.OfficeBlock, donecekFirePolicyInfo.Activity,
                 donecekFirePolicyInfo.AgencyRegisterCode, donecekFirePolicyInfo.TPNo, donecekFirePolicyInfo.Building, donecekFirePolicyInfo.Contents,
                 donecekFirePolicyInfo.EartQuake, donecekFirePolicyInfo.FloodFlooding, donecekFirePolicyInfo.InternalWater, donecekFirePolicyInfo.Storm,
                 donecekFirePolicyInfo.Theft, donecekFirePolicyInfo.LandVehicles, donecekFirePolicyInfo.AirCraft, donecekFirePolicyInfo.MaritimeVehicles,
                 donecekFirePolicyInfo.Smoke, donecekFirePolicyInfo.SpaceShift, donecekFirePolicyInfo.GLKHH, donecekFirePolicyInfo.MaliciousTerror,
                 donecekFirePolicyInfo.OtherGuarentees, donecekFirePolicyInfo.Latitude, donecekFirePolicyInfo.Longitude, donecekFirePolicyInfo.BuildingValue,
                 donecekFirePolicyInfo.ContentsValue, donecekFirePolicyInfo.CurrencyCode, donecekFirePolicyInfo.ExchangeRate, donecekFirePolicyInfo.FirePremium,
                 donecekFirePolicyInfo.SupplementaryGuaranteePremium, donecekFirePolicyInfo.EarthquakePremium, donecekFirePolicyInfo.OtherFees, donecekFirePolicyInfo.TotalPremium,
                 donecekFirePolicyInfo.FirePremiumTL, donecekFirePolicyInfo.SupplementaryGuaranteePremiumTL, donecekFirePolicyInfo.EarthquakePremiumTL, donecekFirePolicyInfo.OtherFeesTL,
                 donecekFirePolicyInfo.TotalPremiumTL, donecekFirePolicyInfo.PolicyPremiumTL, donecekFirePolicyInfo.Color, donecekFirePolicyInfo.FSBMCode))

            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return FirePolicyInfolar

    End Function


    Function policede_iptalzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String,
    ByVal PolicyType As String) As Integer

        Dim cnt As Integer = 0
        Dim firepoliceninzeyilleri As New List(Of FirePolicyInfo)

        firepoliceninzeyilleri = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode,
        PolicyNumber, PolicyType)

        For Each itemzeyil As FirePolicyInfo In firepoliceninzeyilleri
            If itemzeyil.ZeylCode = "X" Or itemzeyil.ZeylCode = "x" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function


    Function policede_yzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String,
    ByVal PolicyType As String) As Integer

        Dim cnt As Integer = 0
        Dim firepoliceninzeyilleri As New List(Of FirePolicyInfo)

        firepoliceninzeyilleri = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode,
        PolicyNumber, PolicyType)

        For Each itemzeyil As FirePolicyInfo In firepoliceninzeyilleri
            If itemzeyil.ZeylCode = "Y" Or itemzeyil.ZeylCode = "y" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function

    Function policede_pzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String,
    ByVal PolicyType As String) As Integer

        Dim cnt As Integer = 0
        Dim firepoliceninzeyilleri As New List(Of FirePolicyInfo)

        firepoliceninzeyilleri = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode,
        PolicyNumber, PolicyType)

        For Each itemzeyil As FirePolicyInfo In firepoliceninzeyilleri
            If itemzeyil.ZeylCode = "P" Or itemzeyil.ZeylCode = "p" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function


    Function policede_tzeyilikacadet(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String,
    ByVal PolicyType As String) As Integer

        Dim cnt As Integer = 0
        Dim firepoliceninzeyilleri As New List(Of FirePolicyInfo)

        firepoliceninzeyilleri = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode,
        PolicyNumber, PolicyType)

        For Each itemzeyil As FirePolicyInfo In firepoliceninzeyilleri
            If itemzeyil.ZeylCode = "T" Or itemzeyil.ZeylCode = "t" Then
                cnt = cnt + 1
            End If
        Next

        Return cnt

    End Function


    Public Function renkbul(ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String,
    ByVal TecditNumber As String, ByVal Zeylcode As String, ByVal ZeyilNo As String,
    ByVal PolicyType As String) As String

        Dim StartDate, EndDate As Date

        Dim i As Integer = 1
        Dim zeyilsayisi As Integer
        Dim donecekrenk As String = "black"
        Dim simdikitarih As Date
        simdikitarih = Date.Now

        Dim zeyiller As New List(Of FirePolicyInfo)

        Dim firepolice As New FirePolicyInfo
        firepolice = bultek_pk(FirmCode, ProductCode, AgencyCode, PolicyNumber,
        TecditNumber, Zeylcode, ZeyilNo, PolicyType)

        Try
            StartDate = firepolice.StartDate
            EndDate = firepolice.EndDate
        Catch ex As Exception
            StartDate = Date.Now
            EndDate = Date.Now
        End Try

        'eğer tarihler kapsıyor sa
        If simdikitarih.Date >= StartDate.Date And simdikitarih.Date <= EndDate.Date Then
            donecekrenk = "green"
            zeyiller = zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, PolicyNumber, PolicyType)
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
        If firepolice.StartDate > simdikitarih And donecekrenk <> "red" Then
            donecekrenk = "blue"
        End If

        Return donecekrenk

    End Function


    Public Function fsbmcodebul(ByVal firePolicy As FirePolicyInfo) As String

        Dim kacadet As Integer
        kacadet = policeadet_sirketin(firePolicy.FirmCode)

        Dim kacadetstr As String = ""
        kacadetstr = CStr(kacadet)

        Dim donecek As String
        donecek = "YP" + firePolicy.FirmCode + firePolicy.ProductCode + CStr(firePolicy.PolicyType) +
        firePolicy.AgencyCode + firePolicy.PolicyNumber + firePolicy.TecditNumber +
        firePolicy.ZeylCode + firePolicy.ZeyilNo + kacadetstr

        Return donecek

    End Function


End Class
