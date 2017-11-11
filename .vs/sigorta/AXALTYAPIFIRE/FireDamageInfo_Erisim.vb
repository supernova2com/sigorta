Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FireDamageInfo_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim FireDamageInfo As New FireDamageInfo
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal FireDamageInfo As FireDamageInfo) As CLADBOPRESULT

        etkilenen = 0
        Dim eklenenpkey As Integer

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into FireDamageInfo values (@pkey," +
            "@firepolicyinfopkey,@FirmCode,@ProductCode,@AgencyCode," +
            "@PolicyNumber,@TecditNumber,@FileNumber,@RequestNumber," +
            "@PolicyType,@DamageDate,@NoticeDate,@FileClosingDate," +
            "@DamageStatusCode,@ClaimOwnerCountryCode,@ClaimOwnerIdentityCode,@ClaimOwnerIdentityNo," +
            "@ClaimOwnerName,@ClaimOwnerSurname,@CurrencyCode,@ExchangeRate," +
            "@AgencyRegisterCode,@TPNo,@BuildingPaid,@ContentsPaid," +
            "@EarthquakePaid,@FloodFloodingPaid,@InternalWaterPaid,@StormPaid," +
            "@TheftPaid,@LandVehiclesPaid,@AirCraftPaid,@MaritimeVehiclesPaid," +
            "@SmokePaid,@SpaceShiftPaid,@GLKHHPaid,@MaliciousTerrorPaid," +
            "@OtherGuaranteesPaid,@BuildingPending,@ContentsPending,@EarthquakePending," +
            "@FloodFloodingPending,@InternalWaterPending,@StormPending,@TheftPending," +
            "@LandVehiclesPending,@AirCraftPending,@MaritmeVehiclesPending,@SmokePending," +
            "@SpaceShiftPending,@GLKHHPending,@MaliciousTerrorPending,@OtherGuaranteesPending," +
            "@PendingTotalAmount,@PendingTotalAmountTL,@PaidTotalAmount,@PaidTotalAmountTL," +
            "@RustyAmount,@FDSBMCode)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            eklenenpkey = pkeybul()
            param1.Value = eklenenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@firepolicyinfopkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If FireDamageInfo.firepolicyinfopkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = FireDamageInfo.firepolicyinfopkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
            param3.Direction = ParameterDirection.Input
            If FireDamageInfo.FirmCode = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = FireDamageInfo.FirmCode
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
            param4.Direction = ParameterDirection.Input
            If FireDamageInfo.ProductCode = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = FireDamageInfo.ProductCode
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
            param5.Direction = ParameterDirection.Input
            If FireDamageInfo.AgencyCode = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = FireDamageInfo.AgencyCode
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
            param6.Direction = ParameterDirection.Input
            If FireDamageInfo.PolicyNumber = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = FireDamageInfo.PolicyNumber
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
            param7.Direction = ParameterDirection.Input
            If FireDamageInfo.TecditNumber = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = FireDamageInfo.TecditNumber
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@FileNumber", SqlDbType.VarChar, 15)
            param8.Direction = ParameterDirection.Input
            If FireDamageInfo.FileNumber = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = FireDamageInfo.FileNumber
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@RequestNumber", SqlDbType.VarChar, 2)
            param9.Direction = ParameterDirection.Input
            If FireDamageInfo.RequestNumber = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = FireDamageInfo.RequestNumber
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@PolicyType", SqlDbType.Int)
            param10.Direction = ParameterDirection.Input
            If FireDamageInfo.PolicyType = 0 Then
                param10.Value = 0
            Else
                param10.Value = FireDamageInfo.PolicyType
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@DamageDate", SqlDbType.DateTime)
            param11.Direction = ParameterDirection.Input
            If FireDamageInfo.DamageDate Is Nothing Or FireDamageInfo.DamageDate = "00:00:00" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = FireDamageInfo.DamageDate
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@NoticeDate", SqlDbType.DateTime)
            param12.Direction = ParameterDirection.Input
            If FireDamageInfo.NoticeDate Is Nothing Or FireDamageInfo.NoticeDate = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = FireDamageInfo.NoticeDate
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@FileClosingDate", SqlDbType.DateTime)
            param13.Direction = ParameterDirection.Input
            If FireDamageInfo.FileClosingDate Is Nothing Or FireDamageInfo.FileClosingDate = "00:00:00" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = FireDamageInfo.FileClosingDate
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar, 10)
            param14.Direction = ParameterDirection.Input
            If FireDamageInfo.DamageStatusCode = "" Then
                param14.Value = System.DBNull.Value
            Else
                param14.Value = FireDamageInfo.DamageStatusCode
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@ClaimOwnerCountryCode", SqlDbType.VarChar, 3)
            param15.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerCountryCode = "" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = FireDamageInfo.ClaimOwnerCountryCode
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@ClaimOwnerIdentityCode", SqlDbType.VarChar, 2)
            param16.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerIdentityCode = "" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = FireDamageInfo.ClaimOwnerIdentityCode
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@ClaimOwnerIdentityNo", SqlDbType.VarChar, 15)
            param17.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerIdentityNo = "" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = FireDamageInfo.ClaimOwnerIdentityNo
            End If
            komut.Parameters.Add(param17)

            Dim param18 As New SqlParameter("@ClaimOwnerName", SqlDbType.VarChar, 50)
            param18.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerName = "" Then
                param18.Value = System.DBNull.Value
            Else
                param18.Value = FireDamageInfo.ClaimOwnerName
            End If
            komut.Parameters.Add(param18)

            Dim param19 As New SqlParameter("@ClaimOwnerSurname", SqlDbType.VarChar, 50)
            param19.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerSurname = "" Then
                param19.Value = System.DBNull.Value
            Else
                param19.Value = FireDamageInfo.ClaimOwnerSurname
            End If
            komut.Parameters.Add(param19)

            Dim param20 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
            param20.Direction = ParameterDirection.Input
            If FireDamageInfo.CurrencyCode = "" Then
                param20.Value = System.DBNull.Value
            Else
                param20.Value = FireDamageInfo.CurrencyCode
            End If
            komut.Parameters.Add(param20)

            Dim param21 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
            param21.Direction = ParameterDirection.Input
            If FireDamageInfo.ExchangeRate = 0 Then
                param21.Value = 0
            Else
                param21.Value = FireDamageInfo.ExchangeRate
            End If
            komut.Parameters.Add(param21)

            Dim param22 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar, 20)
            param22.Direction = ParameterDirection.Input
            If FireDamageInfo.AgencyRegisterCode = "" Then
                param22.Value = System.DBNull.Value
            Else
                param22.Value = FireDamageInfo.AgencyRegisterCode
            End If
            komut.Parameters.Add(param22)

            Dim param23 As New SqlParameter("@TPNo", SqlDbType.VarChar, 20)
            param23.Direction = ParameterDirection.Input
            If FireDamageInfo.TPNo = "" Then
                param23.Value = System.DBNull.Value
            Else
                param23.Value = FireDamageInfo.TPNo
            End If
            komut.Parameters.Add(param23)

            Dim param24 As New SqlParameter("@BuildingPaid", SqlDbType.Decimal)
            param24.Direction = ParameterDirection.Input
            If FireDamageInfo.BuildingPaid = 0 Then
                param24.Value = 0
            Else
                param24.Value = FireDamageInfo.BuildingPaid
            End If
            komut.Parameters.Add(param24)

            Dim param25 As New SqlParameter("@ContentsPaid", SqlDbType.Decimal)
            param25.Direction = ParameterDirection.Input
            If FireDamageInfo.ContentsPaid = 0 Then
                param25.Value = 0
            Else
                param25.Value = FireDamageInfo.ContentsPaid
            End If
            komut.Parameters.Add(param25)

            Dim param26 As New SqlParameter("@EarthquakePaid", SqlDbType.Decimal)
            param26.Direction = ParameterDirection.Input
            If FireDamageInfo.EarthquakePaid = 0 Then
                param26.Value = 0
            Else
                param26.Value = FireDamageInfo.EarthquakePaid
            End If
            komut.Parameters.Add(param26)

            Dim param27 As New SqlParameter("@FloodFloodingPaid", SqlDbType.Decimal)
            param27.Direction = ParameterDirection.Input
            If FireDamageInfo.FloodFloodingPaid = 0 Then
                param27.Value = 0
            Else
                param27.Value = FireDamageInfo.FloodFloodingPaid
            End If
            komut.Parameters.Add(param27)

            Dim param28 As New SqlParameter("@InternalWaterPaid", SqlDbType.Decimal)
            param28.Direction = ParameterDirection.Input
            If FireDamageInfo.InternalWaterPaid = 0 Then
                param28.Value = 0
            Else
                param28.Value = FireDamageInfo.InternalWaterPaid
            End If
            komut.Parameters.Add(param28)

            Dim param29 As New SqlParameter("@StormPaid", SqlDbType.Decimal)
            param29.Direction = ParameterDirection.Input
            If FireDamageInfo.StormPaid = 0 Then
                param29.Value = 0
            Else
                param29.Value = FireDamageInfo.StormPaid
            End If
            komut.Parameters.Add(param29)

            Dim param30 As New SqlParameter("@TheftPaid", SqlDbType.Decimal)
            param30.Direction = ParameterDirection.Input
            If FireDamageInfo.TheftPaid = 0 Then
                param30.Value = 0
            Else
                param30.Value = FireDamageInfo.TheftPaid
            End If
            komut.Parameters.Add(param30)

            Dim param31 As New SqlParameter("@LandVehiclesPaid", SqlDbType.Decimal)
            param31.Direction = ParameterDirection.Input
            If FireDamageInfo.LandVehiclesPaid = 0 Then
                param31.Value = 0
            Else
                param31.Value = FireDamageInfo.LandVehiclesPaid
            End If
            komut.Parameters.Add(param31)

            Dim param32 As New SqlParameter("@AirCraftPaid", SqlDbType.Decimal)
            param32.Direction = ParameterDirection.Input
            If FireDamageInfo.AirCraftPaid = 0 Then
                param32.Value = 0
            Else
                param32.Value = FireDamageInfo.AirCraftPaid
            End If
            komut.Parameters.Add(param32)

            Dim param33 As New SqlParameter("@MaritimeVehiclesPaid", SqlDbType.Decimal)
            param33.Direction = ParameterDirection.Input
            If FireDamageInfo.MaritimeVehiclesPaid = 0 Then
                param33.Value = 0
            Else
                param33.Value = FireDamageInfo.MaritimeVehiclesPaid
            End If
            komut.Parameters.Add(param33)

            Dim param34 As New SqlParameter("@SmokePaid", SqlDbType.Decimal)
            param34.Direction = ParameterDirection.Input
            If FireDamageInfo.SmokePaid = 0 Then
                param34.Value = 0
            Else
                param34.Value = FireDamageInfo.SmokePaid
            End If
            komut.Parameters.Add(param34)

            Dim param35 As New SqlParameter("@SpaceShiftPaid", SqlDbType.Decimal)
            param35.Direction = ParameterDirection.Input
            If FireDamageInfo.SpaceShiftPaid = 0 Then
                param35.Value = 0
            Else
                param35.Value = FireDamageInfo.SpaceShiftPaid
            End If
            komut.Parameters.Add(param35)

            Dim param36 As New SqlParameter("@GLKHHPaid", SqlDbType.Decimal)
            param36.Direction = ParameterDirection.Input
            If FireDamageInfo.GLKHHPaid = 0 Then
                param36.Value = 0
            Else
                param36.Value = FireDamageInfo.GLKHHPaid
            End If
            komut.Parameters.Add(param36)

            Dim param37 As New SqlParameter("@MaliciousTerrorPaid", SqlDbType.Decimal)
            param37.Direction = ParameterDirection.Input
            If FireDamageInfo.MaliciousTerrorPaid = 0 Then
                param37.Value = 0
            Else
                param37.Value = FireDamageInfo.MaliciousTerrorPaid
            End If
            komut.Parameters.Add(param37)

            Dim param38 As New SqlParameter("@OtherGuaranteesPaid", SqlDbType.Decimal)
            param38.Direction = ParameterDirection.Input
            If FireDamageInfo.OtherGuaranteesPaid = 0 Then
                param38.Value = 0
            Else
                param38.Value = FireDamageInfo.OtherGuaranteesPaid
            End If
            komut.Parameters.Add(param38)

            Dim param39 As New SqlParameter("@BuildingPending", SqlDbType.Decimal)
            param39.Direction = ParameterDirection.Input
            If FireDamageInfo.BuildingPending = 0 Then
                param39.Value = 0
            Else
                param39.Value = FireDamageInfo.BuildingPending
            End If
            komut.Parameters.Add(param39)

            Dim param40 As New SqlParameter("@ContentsPending", SqlDbType.Decimal)
            param40.Direction = ParameterDirection.Input
            If FireDamageInfo.ContentsPending = 0 Then
                param40.Value = 0
            Else
                param40.Value = FireDamageInfo.ContentsPending
            End If
            komut.Parameters.Add(param40)

            Dim param41 As New SqlParameter("@EarthquakePending", SqlDbType.Decimal)
            param41.Direction = ParameterDirection.Input
            If FireDamageInfo.EarthquakePending = 0 Then
                param41.Value = 0
            Else
                param41.Value = FireDamageInfo.EarthquakePending
            End If
            komut.Parameters.Add(param41)

            Dim param42 As New SqlParameter("@FloodFloodingPending", SqlDbType.Decimal)
            param42.Direction = ParameterDirection.Input
            If FireDamageInfo.FloodFloodingPending = 0 Then
                param42.Value = 0
            Else
                param42.Value = FireDamageInfo.FloodFloodingPending
            End If
            komut.Parameters.Add(param42)

            Dim param43 As New SqlParameter("@InternalWaterPending", SqlDbType.Decimal)
            param43.Direction = ParameterDirection.Input
            If FireDamageInfo.InternalWaterPending = 0 Then
                param43.Value = 0
            Else
                param43.Value = FireDamageInfo.InternalWaterPending
            End If
            komut.Parameters.Add(param43)

            Dim param44 As New SqlParameter("@StormPending", SqlDbType.Decimal)
            param44.Direction = ParameterDirection.Input
            If FireDamageInfo.StormPending = 0 Then
                param44.Value = 0
            Else
                param44.Value = FireDamageInfo.StormPending
            End If
            komut.Parameters.Add(param44)

            Dim param45 As New SqlParameter("@TheftPending", SqlDbType.Decimal)
            param45.Direction = ParameterDirection.Input
            If FireDamageInfo.TheftPending = 0 Then
                param45.Value = 0
            Else
                param45.Value = FireDamageInfo.TheftPending
            End If
            komut.Parameters.Add(param45)

            Dim param46 As New SqlParameter("@LandVehiclesPending", SqlDbType.Decimal)
            param46.Direction = ParameterDirection.Input
            If FireDamageInfo.LandVehiclesPending = 0 Then
                param46.Value = 0
            Else
                param46.Value = FireDamageInfo.LandVehiclesPending
            End If
            komut.Parameters.Add(param46)

            Dim param47 As New SqlParameter("@AirCraftPending", SqlDbType.Decimal)
            param47.Direction = ParameterDirection.Input
            If FireDamageInfo.AirCraftPending = 0 Then
                param47.Value = 0
            Else
                param47.Value = FireDamageInfo.AirCraftPending
            End If
            komut.Parameters.Add(param47)

            Dim param48 As New SqlParameter("@MaritmeVehiclesPending", SqlDbType.Decimal)
            param48.Direction = ParameterDirection.Input
            If FireDamageInfo.MaritmeVehiclesPending = 0 Then
                param48.Value = 0
            Else
                param48.Value = FireDamageInfo.MaritmeVehiclesPending
            End If
            komut.Parameters.Add(param48)

            Dim param49 As New SqlParameter("@SmokePending", SqlDbType.Decimal)
            param49.Direction = ParameterDirection.Input
            If FireDamageInfo.SmokePending = 0 Then
                param49.Value = 0
            Else
                param49.Value = FireDamageInfo.SmokePending
            End If
            komut.Parameters.Add(param49)

            Dim param50 As New SqlParameter("@SpaceShiftPending", SqlDbType.Decimal)
            param50.Direction = ParameterDirection.Input
            If FireDamageInfo.SpaceShiftPending = 0 Then
                param50.Value = 0
            Else
                param50.Value = FireDamageInfo.SpaceShiftPending
            End If
            komut.Parameters.Add(param50)

            Dim param51 As New SqlParameter("@GLKHHPending", SqlDbType.Decimal)
            param51.Direction = ParameterDirection.Input
            If FireDamageInfo.GLKHHPending = 0 Then
                param51.Value = 0
            Else
                param51.Value = FireDamageInfo.GLKHHPending
            End If
            komut.Parameters.Add(param51)

            Dim param52 As New SqlParameter("@MaliciousTerrorPending", SqlDbType.Decimal)
            param52.Direction = ParameterDirection.Input
            If FireDamageInfo.MaliciousTerrorPending = 0 Then
                param52.Value = 0
            Else
                param52.Value = FireDamageInfo.MaliciousTerrorPending
            End If
            komut.Parameters.Add(param52)

            Dim param53 As New SqlParameter("@OtherGuaranteesPending", SqlDbType.Decimal)
            param53.Direction = ParameterDirection.Input
            If FireDamageInfo.OtherGuaranteesPending = 0 Then
                param53.Value = 0
            Else
                param53.Value = FireDamageInfo.OtherGuaranteesPending
            End If
            komut.Parameters.Add(param53)

            Dim param54 As New SqlParameter("@PendingTotalAmount", SqlDbType.Decimal)
            param54.Direction = ParameterDirection.Input
            If FireDamageInfo.PendingTotalAmount = 0 Then
                param54.Value = 0
            Else
                param54.Value = FireDamageInfo.PendingTotalAmount
            End If
            komut.Parameters.Add(param54)

            Dim param55 As New SqlParameter("@PendingTotalAmountTL", SqlDbType.Decimal)
            param55.Direction = ParameterDirection.Input
            If FireDamageInfo.PendingTotalAmountTL = 0 Then
                param55.Value = 0
            Else
                param55.Value = FireDamageInfo.PendingTotalAmountTL
            End If
            komut.Parameters.Add(param55)

            Dim param56 As New SqlParameter("@PaidTotalAmount", SqlDbType.Decimal)
            param56.Direction = ParameterDirection.Input
            If FireDamageInfo.PaidTotalAmount = 0 Then
                param56.Value = 0
            Else
                param56.Value = FireDamageInfo.PaidTotalAmount
            End If
            komut.Parameters.Add(param56)

            Dim param57 As New SqlParameter("@PaidTotalAmountTL", SqlDbType.Decimal)
            param57.Direction = ParameterDirection.Input
            If FireDamageInfo.PaidTotalAmountTL = 0 Then
                param57.Value = 0
            Else
                param57.Value = FireDamageInfo.PaidTotalAmountTL
            End If
            komut.Parameters.Add(param57)

            Dim param58 As New SqlParameter("@RustyAmount", SqlDbType.Decimal)
            param58.Direction = ParameterDirection.Input
            If FireDamageInfo.RustyAmount = 0 Then
                param58.Value = 0
            Else
                param58.Value = FireDamageInfo.RustyAmount
            End If
            komut.Parameters.Add(param58)

            Dim param59 As New SqlParameter("@FDSBMCode", SqlDbType.VarChar, 100)
            param59.Direction = ParameterDirection.Input
            If FireDamageInfo.FDSBMCode = "" Then
                param59.Value = System.DBNull.Value
            Else
                param59.Value = FireDamageInfo.FDSBMCode
            End If
            komut.Parameters.Add(param59)

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
            sqlstr = "select max(pkey) from FireDamageInfo"
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
    Function Duzenle(ByVal FireDamageInfo As FireDamageInfo) As CLADBOPRESULT

        Dim varmi As Integer = 0
        etkilenen = 0
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", FireDamageInfo.pkey, " And "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "FireDamageInfo", "count(*)", fieldopvalues)
        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıtlıdır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            komut.Connection = db_baglanti
            sqlstr = "update FireDamageInfo set " +
            "firepolicyinfopkey=@firepolicyinfopkey," +
            "FirmCode=@FirmCode," +
            "ProductCode=@ProductCode," +
            "AgencyCode=@AgencyCode," +
            "PolicyNumber=@PolicyNumber," +
            "TecditNumber=@TecditNumber," +
            "FileNumber=@FileNumber," +
            "RequestNumber=@RequestNumber," +
            "PolicyType=@PolicyType," +
            "DamageDate=@DamageDate," +
            "NoticeDate=@NoticeDate," +
            "FileClosingDate=@FileClosingDate," +
            "DamageStatusCode=@DamageStatusCode," +
            "ClaimOwnerCountryCode=@ClaimOwnerCountryCode," +
            "ClaimOwnerIdentityCode=@ClaimOwnerIdentityCode," +
            "ClaimOwnerIdentityNo=@ClaimOwnerIdentityNo," +
            "ClaimOwnerName=@ClaimOwnerName," +
            "ClaimOwnerSurname=@ClaimOwnerSurname," +
            "CurrencyCode=@CurrencyCode," +
            "ExchangeRate=@ExchangeRate," +
            "AgencyRegisterCode=@AgencyRegisterCode," +
            "TPNo=@TPNo," +
            "BuildingPaid=@BuildingPaid," +
            "ContentsPaid=@ContentsPaid," +
            "EarthquakePaid=@EarthquakePaid," +
            "FloodFloodingPaid=@FloodFloodingPaid," +
            "InternalWaterPaid=@InternalWaterPaid," +
            "StormPaid=@StormPaid," +
            "TheftPaid=@TheftPaid," +
            "LandVehiclesPaid=@LandVehiclesPaid," +
            "AirCraftPaid=@AirCraftPaid," +
            "MaritimeVehiclesPaid=@MaritimeVehiclesPaid," +
            "SmokePaid=@SmokePaid," +
            "SpaceShiftPaid=@SpaceShiftPaid," +
            "GLKHHPaid=@GLKHHPaid," +
            "MaliciousTerrorPaid=@MaliciousTerrorPaid," +
            "OtherGuaranteesPaid=@OtherGuaranteesPaid," +
            "BuildingPending=@BuildingPending," +
            "ContentsPending=@ContentsPending," +
            "EarthquakePending=@EarthquakePending," +
            "FloodFloodingPending=@FloodFloodingPending," +
            "InternalWaterPending=@InternalWaterPending," +
            "StormPending=@StormPending," +
            "TheftPending=@TheftPending," +
            "LandVehiclesPending=@LandVehiclesPending," +
            "AirCraftPending=@AirCraftPending," +
            "MaritmeVehiclesPending=@MaritmeVehiclesPending," +
            "SmokePending=@SmokePending," +
            "SpaceShiftPending=@SpaceShiftPending," +
            "GLKHHPending=@GLKHHPending," +
            "MaliciousTerrorPending=@MaliciousTerrorPending," +
            "OtherGuaranteesPending=@OtherGuaranteesPending," +
            "PendingTotalAmount=@PendingTotalAmount," +
            "PendingTotalAmountTL=@PendingTotalAmountTL," +
            "PaidTotalAmount=@PaidTotalAmount," +
            "PaidTotalAmountTL=@PaidTotalAmountTL," +
            "RustyAmount=@RustyAmount," +
            "FDSBMCode=@FDSBMCode" +
            " where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = FireDamageInfo.pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@firepolicyinfopkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If FireDamageInfo.firepolicyinfopkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = FireDamageInfo.firepolicyinfopkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
            param3.Direction = ParameterDirection.Input
            If FireDamageInfo.FirmCode = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = FireDamageInfo.FirmCode
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
            param4.Direction = ParameterDirection.Input
            If FireDamageInfo.ProductCode = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = FireDamageInfo.ProductCode
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
            param5.Direction = ParameterDirection.Input
            If FireDamageInfo.AgencyCode = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = FireDamageInfo.AgencyCode
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
            param6.Direction = ParameterDirection.Input
            If FireDamageInfo.PolicyNumber = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = FireDamageInfo.PolicyNumber
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
            param7.Direction = ParameterDirection.Input
            If FireDamageInfo.TecditNumber = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = FireDamageInfo.TecditNumber
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@FileNumber", SqlDbType.VarChar, 15)
            param8.Direction = ParameterDirection.Input
            If FireDamageInfo.FileNumber = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = FireDamageInfo.FileNumber
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@RequestNumber", SqlDbType.VarChar, 2)
            param9.Direction = ParameterDirection.Input
            If FireDamageInfo.RequestNumber = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = FireDamageInfo.RequestNumber
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@PolicyType", SqlDbType.Int)
            param10.Direction = ParameterDirection.Input
            If FireDamageInfo.PolicyType = 0 Then
                param10.Value = 0
            Else
                param10.Value = FireDamageInfo.PolicyType
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@DamageDate", SqlDbType.DateTime)
            param11.Direction = ParameterDirection.Input
            If FireDamageInfo.DamageDate Is Nothing Or FireDamageInfo.DamageDate = "00:00:00" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = FireDamageInfo.DamageDate
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@NoticeDate", SqlDbType.DateTime)
            param12.Direction = ParameterDirection.Input
            If FireDamageInfo.NoticeDate Is Nothing Or FireDamageInfo.NoticeDate = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = FireDamageInfo.NoticeDate
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@FileClosingDate", SqlDbType.DateTime)
            param13.Direction = ParameterDirection.Input
            If FireDamageInfo.FileClosingDate Is Nothing Or FireDamageInfo.FileClosingDate = "00:00:00" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = FireDamageInfo.FileClosingDate
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar, 10)
            param14.Direction = ParameterDirection.Input
            If FireDamageInfo.DamageStatusCode = "" Then
                param14.Value = System.DBNull.Value
            Else
                param14.Value = FireDamageInfo.DamageStatusCode
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@ClaimOwnerCountryCode", SqlDbType.VarChar, 3)
            param15.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerCountryCode = "" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = FireDamageInfo.ClaimOwnerCountryCode
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@ClaimOwnerIdentityCode", SqlDbType.VarChar, 2)
            param16.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerIdentityCode = "" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = FireDamageInfo.ClaimOwnerIdentityCode
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@ClaimOwnerIdentityNo", SqlDbType.VarChar, 15)
            param17.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerIdentityNo = "" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = FireDamageInfo.ClaimOwnerIdentityNo
            End If
            komut.Parameters.Add(param17)

            Dim param18 As New SqlParameter("@ClaimOwnerName", SqlDbType.VarChar, 50)
            param18.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerName = "" Then
                param18.Value = System.DBNull.Value
            Else
                param18.Value = FireDamageInfo.ClaimOwnerName
            End If
            komut.Parameters.Add(param18)

            Dim param19 As New SqlParameter("@ClaimOwnerSurname", SqlDbType.VarChar, 50)
            param19.Direction = ParameterDirection.Input
            If FireDamageInfo.ClaimOwnerSurname = "" Then
                param19.Value = System.DBNull.Value
            Else
                param19.Value = FireDamageInfo.ClaimOwnerSurname
            End If
            komut.Parameters.Add(param19)

            Dim param20 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
            param20.Direction = ParameterDirection.Input
            If FireDamageInfo.CurrencyCode = "" Then
                param20.Value = System.DBNull.Value
            Else
                param20.Value = FireDamageInfo.CurrencyCode
            End If
            komut.Parameters.Add(param20)

            Dim param21 As New SqlParameter("@ExchangeRate", SqlDbType.Decimal)
            param21.Direction = ParameterDirection.Input
            If FireDamageInfo.ExchangeRate = 0 Then
                param21.Value = 0
            Else
                param21.Value = FireDamageInfo.ExchangeRate
            End If
            komut.Parameters.Add(param21)

            Dim param22 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar, 20)
            param22.Direction = ParameterDirection.Input
            If FireDamageInfo.AgencyRegisterCode = "" Then
                param22.Value = System.DBNull.Value
            Else
                param22.Value = FireDamageInfo.AgencyRegisterCode
            End If
            komut.Parameters.Add(param22)

            Dim param23 As New SqlParameter("@TPNo", SqlDbType.VarChar, 20)
            param23.Direction = ParameterDirection.Input
            If FireDamageInfo.TPNo = "" Then
                param23.Value = System.DBNull.Value
            Else
                param23.Value = FireDamageInfo.TPNo
            End If
            komut.Parameters.Add(param23)

            Dim param24 As New SqlParameter("@BuildingPaid", SqlDbType.Decimal)
            param24.Direction = ParameterDirection.Input
            If FireDamageInfo.BuildingPaid = 0 Then
                param24.Value = 0
            Else
                param24.Value = FireDamageInfo.BuildingPaid
            End If
            komut.Parameters.Add(param24)

            Dim param25 As New SqlParameter("@ContentsPaid", SqlDbType.Decimal)
            param25.Direction = ParameterDirection.Input
            If FireDamageInfo.ContentsPaid = 0 Then
                param25.Value = 0
            Else
                param25.Value = FireDamageInfo.ContentsPaid
            End If
            komut.Parameters.Add(param25)

            Dim param26 As New SqlParameter("@EarthquakePaid", SqlDbType.Decimal)
            param26.Direction = ParameterDirection.Input
            If FireDamageInfo.EarthquakePaid = 0 Then
                param26.Value = 0
            Else
                param26.Value = FireDamageInfo.EarthquakePaid
            End If
            komut.Parameters.Add(param26)

            Dim param27 As New SqlParameter("@FloodFloodingPaid", SqlDbType.Decimal)
            param27.Direction = ParameterDirection.Input
            If FireDamageInfo.FloodFloodingPaid = 0 Then
                param27.Value = 0
            Else
                param27.Value = FireDamageInfo.FloodFloodingPaid
            End If
            komut.Parameters.Add(param27)

            Dim param28 As New SqlParameter("@InternalWaterPaid", SqlDbType.Decimal)
            param28.Direction = ParameterDirection.Input
            If FireDamageInfo.InternalWaterPaid = 0 Then
                param28.Value = 0
            Else
                param28.Value = FireDamageInfo.InternalWaterPaid
            End If
            komut.Parameters.Add(param28)

            Dim param29 As New SqlParameter("@StormPaid", SqlDbType.Decimal)
            param29.Direction = ParameterDirection.Input
            If FireDamageInfo.StormPaid = 0 Then
                param29.Value = 0
            Else
                param29.Value = FireDamageInfo.StormPaid
            End If
            komut.Parameters.Add(param29)

            Dim param30 As New SqlParameter("@TheftPaid", SqlDbType.Decimal)
            param30.Direction = ParameterDirection.Input
            If FireDamageInfo.TheftPaid = 0 Then
                param30.Value = 0
            Else
                param30.Value = FireDamageInfo.TheftPaid
            End If
            komut.Parameters.Add(param30)

            Dim param31 As New SqlParameter("@LandVehiclesPaid", SqlDbType.Decimal)
            param31.Direction = ParameterDirection.Input
            If FireDamageInfo.LandVehiclesPaid = 0 Then
                param31.Value = 0
            Else
                param31.Value = FireDamageInfo.LandVehiclesPaid
            End If
            komut.Parameters.Add(param31)

            Dim param32 As New SqlParameter("@AirCraftPaid", SqlDbType.Decimal)
            param32.Direction = ParameterDirection.Input
            If FireDamageInfo.AirCraftPaid = 0 Then
                param32.Value = 0
            Else
                param32.Value = FireDamageInfo.AirCraftPaid
            End If
            komut.Parameters.Add(param32)

            Dim param33 As New SqlParameter("@MaritimeVehiclesPaid", SqlDbType.Decimal)
            param33.Direction = ParameterDirection.Input
            If FireDamageInfo.MaritimeVehiclesPaid = 0 Then
                param33.Value = 0
            Else
                param33.Value = FireDamageInfo.MaritimeVehiclesPaid
            End If
            komut.Parameters.Add(param33)

            Dim param34 As New SqlParameter("@SmokePaid", SqlDbType.Decimal)
            param34.Direction = ParameterDirection.Input
            If FireDamageInfo.SmokePaid = 0 Then
                param34.Value = 0
            Else
                param34.Value = FireDamageInfo.SmokePaid
            End If
            komut.Parameters.Add(param34)

            Dim param35 As New SqlParameter("@SpaceShiftPaid", SqlDbType.Decimal)
            param35.Direction = ParameterDirection.Input
            If FireDamageInfo.SpaceShiftPaid = 0 Then
                param35.Value = 0
            Else
                param35.Value = FireDamageInfo.SpaceShiftPaid
            End If
            komut.Parameters.Add(param35)

            Dim param36 As New SqlParameter("@GLKHHPaid", SqlDbType.Decimal)
            param36.Direction = ParameterDirection.Input
            If FireDamageInfo.GLKHHPaid = 0 Then
                param36.Value = 0
            Else
                param36.Value = FireDamageInfo.GLKHHPaid
            End If
            komut.Parameters.Add(param36)

            Dim param37 As New SqlParameter("@MaliciousTerrorPaid", SqlDbType.Decimal)
            param37.Direction = ParameterDirection.Input
            If FireDamageInfo.MaliciousTerrorPaid = 0 Then
                param37.Value = 0
            Else
                param37.Value = FireDamageInfo.MaliciousTerrorPaid
            End If
            komut.Parameters.Add(param37)

            Dim param38 As New SqlParameter("@OtherGuaranteesPaid", SqlDbType.Decimal)
            param38.Direction = ParameterDirection.Input
            If FireDamageInfo.OtherGuaranteesPaid = 0 Then
                param38.Value = 0
            Else
                param38.Value = FireDamageInfo.OtherGuaranteesPaid
            End If
            komut.Parameters.Add(param38)

            Dim param39 As New SqlParameter("@BuildingPending", SqlDbType.Decimal)
            param39.Direction = ParameterDirection.Input
            If FireDamageInfo.BuildingPending = 0 Then
                param39.Value = 0
            Else
                param39.Value = FireDamageInfo.BuildingPending
            End If
            komut.Parameters.Add(param39)

            Dim param40 As New SqlParameter("@ContentsPending", SqlDbType.Decimal)
            param40.Direction = ParameterDirection.Input
            If FireDamageInfo.ContentsPending = 0 Then
                param40.Value = 0
            Else
                param40.Value = FireDamageInfo.ContentsPending
            End If
            komut.Parameters.Add(param40)

            Dim param41 As New SqlParameter("@EarthquakePending", SqlDbType.Decimal)
            param41.Direction = ParameterDirection.Input
            If FireDamageInfo.EarthquakePending = 0 Then
                param41.Value = 0
            Else
                param41.Value = FireDamageInfo.EarthquakePending
            End If
            komut.Parameters.Add(param41)

            Dim param42 As New SqlParameter("@FloodFloodingPending", SqlDbType.Decimal)
            param42.Direction = ParameterDirection.Input
            If FireDamageInfo.FloodFloodingPending = 0 Then
                param42.Value = 0
            Else
                param42.Value = FireDamageInfo.FloodFloodingPending
            End If
            komut.Parameters.Add(param42)

            Dim param43 As New SqlParameter("@InternalWaterPending", SqlDbType.Decimal)
            param43.Direction = ParameterDirection.Input
            If FireDamageInfo.InternalWaterPending = 0 Then
                param43.Value = 0
            Else
                param43.Value = FireDamageInfo.InternalWaterPending
            End If
            komut.Parameters.Add(param43)

            Dim param44 As New SqlParameter("@StormPending", SqlDbType.Decimal)
            param44.Direction = ParameterDirection.Input
            If FireDamageInfo.StormPending = 0 Then
                param44.Value = 0
            Else
                param44.Value = FireDamageInfo.StormPending
            End If
            komut.Parameters.Add(param44)

            Dim param45 As New SqlParameter("@TheftPending", SqlDbType.Decimal)
            param45.Direction = ParameterDirection.Input
            If FireDamageInfo.TheftPending = 0 Then
                param45.Value = 0
            Else
                param45.Value = FireDamageInfo.TheftPending
            End If
            komut.Parameters.Add(param45)

            Dim param46 As New SqlParameter("@LandVehiclesPending", SqlDbType.Decimal)
            param46.Direction = ParameterDirection.Input
            If FireDamageInfo.LandVehiclesPending = 0 Then
                param46.Value = 0
            Else
                param46.Value = FireDamageInfo.LandVehiclesPending
            End If
            komut.Parameters.Add(param46)

            Dim param47 As New SqlParameter("@AirCraftPending", SqlDbType.Decimal)
            param47.Direction = ParameterDirection.Input
            If FireDamageInfo.AirCraftPending = 0 Then
                param47.Value = 0
            Else
                param47.Value = FireDamageInfo.AirCraftPending
            End If
            komut.Parameters.Add(param47)

            Dim param48 As New SqlParameter("@MaritmeVehiclesPending", SqlDbType.Decimal)
            param48.Direction = ParameterDirection.Input
            If FireDamageInfo.MaritmeVehiclesPending = 0 Then
                param48.Value = 0
            Else
                param48.Value = FireDamageInfo.MaritmeVehiclesPending
            End If
            komut.Parameters.Add(param48)

            Dim param49 As New SqlParameter("@SmokePending", SqlDbType.Decimal)
            param49.Direction = ParameterDirection.Input
            If FireDamageInfo.SmokePending = 0 Then
                param49.Value = 0
            Else
                param49.Value = FireDamageInfo.SmokePending
            End If
            komut.Parameters.Add(param49)

            Dim param50 As New SqlParameter("@SpaceShiftPending", SqlDbType.Decimal)
            param50.Direction = ParameterDirection.Input
            If FireDamageInfo.SpaceShiftPending = 0 Then
                param50.Value = 0
            Else
                param50.Value = FireDamageInfo.SpaceShiftPending
            End If
            komut.Parameters.Add(param50)

            Dim param51 As New SqlParameter("@GLKHHPending", SqlDbType.Decimal)
            param51.Direction = ParameterDirection.Input
            If FireDamageInfo.GLKHHPending = 0 Then
                param51.Value = 0
            Else
                param51.Value = FireDamageInfo.GLKHHPending
            End If
            komut.Parameters.Add(param51)

            Dim param52 As New SqlParameter("@MaliciousTerrorPending", SqlDbType.Decimal)
            param52.Direction = ParameterDirection.Input
            If FireDamageInfo.MaliciousTerrorPending = 0 Then
                param52.Value = 0
            Else
                param52.Value = FireDamageInfo.MaliciousTerrorPending
            End If
            komut.Parameters.Add(param52)

            Dim param53 As New SqlParameter("@OtherGuaranteesPending", SqlDbType.Decimal)
            param53.Direction = ParameterDirection.Input
            If FireDamageInfo.OtherGuaranteesPending = 0 Then
                param53.Value = 0
            Else
                param53.Value = FireDamageInfo.OtherGuaranteesPending
            End If
            komut.Parameters.Add(param53)

            Dim param54 As New SqlParameter("@PendingTotalAmount", SqlDbType.Decimal)
            param54.Direction = ParameterDirection.Input
            If FireDamageInfo.PendingTotalAmount = 0 Then
                param54.Value = 0
            Else
                param54.Value = FireDamageInfo.PendingTotalAmount
            End If
            komut.Parameters.Add(param54)

            Dim param55 As New SqlParameter("@PendingTotalAmountTL", SqlDbType.Decimal)
            param55.Direction = ParameterDirection.Input
            If FireDamageInfo.PendingTotalAmountTL = 0 Then
                param55.Value = 0
            Else
                param55.Value = FireDamageInfo.PendingTotalAmountTL
            End If
            komut.Parameters.Add(param55)

            Dim param56 As New SqlParameter("@PaidTotalAmount", SqlDbType.Decimal)
            param56.Direction = ParameterDirection.Input
            If FireDamageInfo.PaidTotalAmount = 0 Then
                param56.Value = 0
            Else
                param56.Value = FireDamageInfo.PaidTotalAmount
            End If
            komut.Parameters.Add(param56)

            Dim param57 As New SqlParameter("@PaidTotalAmountTL", SqlDbType.Decimal)
            param57.Direction = ParameterDirection.Input
            If FireDamageInfo.PaidTotalAmountTL = 0 Then
                param57.Value = 0
            Else
                param57.Value = FireDamageInfo.PaidTotalAmountTL
            End If
            komut.Parameters.Add(param57)

            Dim param58 As New SqlParameter("@RustyAmount", SqlDbType.Decimal)
            param58.Direction = ParameterDirection.Input
            If FireDamageInfo.RustyAmount = 0 Then
                param58.Value = 0
            Else
                param58.Value = FireDamageInfo.RustyAmount
            End If
            komut.Parameters.Add(param58)

            Dim param59 As New SqlParameter("@FDSBMCode", SqlDbType.VarChar, 100)
            param59.Direction = ParameterDirection.Input
            If FireDamageInfo.FDSBMCode = "" Then
                param59.Value = System.DBNull.Value
            Else
                param59.Value = FireDamageInfo.FDSBMCode
            End If
            komut.Parameters.Add(param59)


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
    Function bultek(ByVal pkey As String) As FireDamageInfo

        Dim komut As New SqlCommand
        Dim donecekFireDamageInfo As New FireDamageInfo()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "select * from FireDamageInfo where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkey
            komut.Parameters.Add(param1)


            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekFireDamageInfo.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("firepolicyinfopkey") Is System.DBNull.Value Then
                        donecekFireDamageInfo.firepolicyinfopkey = veri.Item("firepolicyinfopkey")
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FirmCode = veri.Item("FirmCode")
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ProductCode = veri.Item("ProductCode")
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AgencyCode = veri.Item("AgencyCode")
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PolicyNumber = veri.Item("PolicyNumber")
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TecditNumber = veri.Item("TecditNumber")
                    End If

                    If Not veri.Item("FileNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FileNumber = veri.Item("FileNumber")
                    End If

                    If Not veri.Item("RequestNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.RequestNumber = veri.Item("RequestNumber")
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PolicyType = veri.Item("PolicyType")
                    End If

                    If Not veri.Item("DamageDate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.DamageDate = veri.Item("DamageDate")
                    End If

                    If Not veri.Item("NoticeDate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.NoticeDate = veri.Item("NoticeDate")
                    End If

                    If Not veri.Item("FileClosingDate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FileClosingDate = veri.Item("FileClosingDate")
                    End If

                    If Not veri.Item("DamageStatusCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.DamageStatusCode = veri.Item("DamageStatusCode")
                    End If

                    If Not veri.Item("ClaimOwnerCountryCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerCountryCode = veri.Item("ClaimOwnerCountryCode")
                    End If

                    If Not veri.Item("ClaimOwnerIdentityCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerIdentityCode = veri.Item("ClaimOwnerIdentityCode")
                    End If

                    If Not veri.Item("ClaimOwnerIdentityNo") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerIdentityNo = veri.Item("ClaimOwnerIdentityNo")
                    End If

                    If Not veri.Item("ClaimOwnerName") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerName = veri.Item("ClaimOwnerName")
                    End If

                    If Not veri.Item("ClaimOwnerSurname") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerSurname = veri.Item("ClaimOwnerSurname")
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.CurrencyCode = veri.Item("CurrencyCode")
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ExchangeRate = veri.Item("ExchangeRate")
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TPNo = veri.Item("TPNo")
                    End If

                    If Not veri.Item("BuildingPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.BuildingPaid = veri.Item("BuildingPaid")
                    End If

                    If Not veri.Item("ContentsPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ContentsPaid = veri.Item("ContentsPaid")
                    End If

                    If Not veri.Item("EarthquakePaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.EarthquakePaid = veri.Item("EarthquakePaid")
                    End If

                    If Not veri.Item("FloodFloodingPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FloodFloodingPaid = veri.Item("FloodFloodingPaid")
                    End If

                    If Not veri.Item("InternalWaterPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.InternalWaterPaid = veri.Item("InternalWaterPaid")
                    End If

                    If Not veri.Item("StormPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.StormPaid = veri.Item("StormPaid")
                    End If

                    If Not veri.Item("TheftPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TheftPaid = veri.Item("TheftPaid")
                    End If

                    If Not veri.Item("LandVehiclesPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.LandVehiclesPaid = veri.Item("LandVehiclesPaid")
                    End If

                    If Not veri.Item("AirCraftPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AirCraftPaid = veri.Item("AirCraftPaid")
                    End If

                    If Not veri.Item("MaritimeVehiclesPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaritimeVehiclesPaid = veri.Item("MaritimeVehiclesPaid")
                    End If

                    If Not veri.Item("SmokePaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SmokePaid = veri.Item("SmokePaid")
                    End If

                    If Not veri.Item("SpaceShiftPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SpaceShiftPaid = veri.Item("SpaceShiftPaid")
                    End If

                    If Not veri.Item("GLKHHPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.GLKHHPaid = veri.Item("GLKHHPaid")
                    End If

                    If Not veri.Item("MaliciousTerrorPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaliciousTerrorPaid = veri.Item("MaliciousTerrorPaid")
                    End If

                    If Not veri.Item("OtherGuaranteesPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.OtherGuaranteesPaid = veri.Item("OtherGuaranteesPaid")
                    End If

                    If Not veri.Item("BuildingPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.BuildingPending = veri.Item("BuildingPending")
                    End If

                    If Not veri.Item("ContentsPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ContentsPending = veri.Item("ContentsPending")
                    End If

                    If Not veri.Item("EarthquakePending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.EarthquakePending = veri.Item("EarthquakePending")
                    End If

                    If Not veri.Item("FloodFloodingPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FloodFloodingPending = veri.Item("FloodFloodingPending")
                    End If

                    If Not veri.Item("InternalWaterPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.InternalWaterPending = veri.Item("InternalWaterPending")
                    End If

                    If Not veri.Item("StormPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.StormPending = veri.Item("StormPending")
                    End If

                    If Not veri.Item("TheftPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TheftPending = veri.Item("TheftPending")
                    End If

                    If Not veri.Item("LandVehiclesPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.LandVehiclesPending = veri.Item("LandVehiclesPending")
                    End If

                    If Not veri.Item("AirCraftPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AirCraftPending = veri.Item("AirCraftPending")
                    End If

                    If Not veri.Item("MaritmeVehiclesPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaritmeVehiclesPending = veri.Item("MaritmeVehiclesPending")
                    End If

                    If Not veri.Item("SmokePending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SmokePending = veri.Item("SmokePending")
                    End If

                    If Not veri.Item("SpaceShiftPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SpaceShiftPending = veri.Item("SpaceShiftPending")
                    End If

                    If Not veri.Item("GLKHHPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.GLKHHPending = veri.Item("GLKHHPending")
                    End If

                    If Not veri.Item("MaliciousTerrorPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaliciousTerrorPending = veri.Item("MaliciousTerrorPending")
                    End If

                    If Not veri.Item("OtherGuaranteesPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.OtherGuaranteesPending = veri.Item("OtherGuaranteesPending")
                    End If

                    If Not veri.Item("PendingTotalAmount") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PendingTotalAmount = veri.Item("PendingTotalAmount")
                    End If

                    If Not veri.Item("PendingTotalAmountTL") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PendingTotalAmountTL = veri.Item("PendingTotalAmountTL")
                    End If

                    If Not veri.Item("PaidTotalAmount") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PaidTotalAmount = veri.Item("PaidTotalAmount")
                    End If

                    If Not veri.Item("PaidTotalAmountTL") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PaidTotalAmountTL = veri.Item("PaidTotalAmountTL")
                    End If

                    If Not veri.Item("RustyAmount") Is System.DBNull.Value Then
                        donecekFireDamageInfo.RustyAmount = veri.Item("RustyAmount")
                    End If

                    If Not veri.Item("FDSBMCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FDSBMCode = veri.Item("FDSBMCode")
                    End If


                End While
            End Using
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using
        Return donecekFireDamageInfo

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from FireDamageInfo where pkey=@pkey"
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
    Public Function doldur() As List(Of FireDamageInfo)

        Dim donecekFireDamageInfo As New FireDamageInfo
        Dim FireDamageInfoler As New List(Of FireDamageInfo)
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            komut.Connection = db_baglanti
            sqlstr = "select * from FireDamageInfo"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekFireDamageInfo.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("firepolicyinfopkey") Is System.DBNull.Value Then
                        donecekFireDamageInfo.firepolicyinfopkey = veri.Item("firepolicyinfopkey")
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FirmCode = veri.Item("FirmCode")
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ProductCode = veri.Item("ProductCode")
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AgencyCode = veri.Item("AgencyCode")
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PolicyNumber = veri.Item("PolicyNumber")
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TecditNumber = veri.Item("TecditNumber")
                    End If

                    If Not veri.Item("FileNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FileNumber = veri.Item("FileNumber")
                    End If

                    If Not veri.Item("RequestNumber") Is System.DBNull.Value Then
                        donecekFireDamageInfo.RequestNumber = veri.Item("RequestNumber")
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PolicyType = veri.Item("PolicyType")
                    End If

                    If Not veri.Item("DamageDate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.DamageDate = veri.Item("DamageDate")
                    End If

                    If Not veri.Item("NoticeDate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.NoticeDate = veri.Item("NoticeDate")
                    End If

                    If Not veri.Item("FileClosingDate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FileClosingDate = veri.Item("FileClosingDate")
                    End If

                    If Not veri.Item("DamageStatusCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.DamageStatusCode = veri.Item("DamageStatusCode")
                    End If

                    If Not veri.Item("ClaimOwnerCountryCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerCountryCode = veri.Item("ClaimOwnerCountryCode")
                    End If

                    If Not veri.Item("ClaimOwnerIdentityCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerIdentityCode = veri.Item("ClaimOwnerIdentityCode")
                    End If

                    If Not veri.Item("ClaimOwnerIdentityNo") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerIdentityNo = veri.Item("ClaimOwnerIdentityNo")
                    End If

                    If Not veri.Item("ClaimOwnerName") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerName = veri.Item("ClaimOwnerName")
                    End If

                    If Not veri.Item("ClaimOwnerSurname") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ClaimOwnerSurname = veri.Item("ClaimOwnerSurname")
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.CurrencyCode = veri.Item("CurrencyCode")
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ExchangeRate = veri.Item("ExchangeRate")
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TPNo = veri.Item("TPNo")
                    End If

                    If Not veri.Item("BuildingPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.BuildingPaid = veri.Item("BuildingPaid")
                    End If

                    If Not veri.Item("ContentsPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ContentsPaid = veri.Item("ContentsPaid")
                    End If

                    If Not veri.Item("EarthquakePaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.EarthquakePaid = veri.Item("EarthquakePaid")
                    End If

                    If Not veri.Item("FloodFloodingPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FloodFloodingPaid = veri.Item("FloodFloodingPaid")
                    End If

                    If Not veri.Item("InternalWaterPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.InternalWaterPaid = veri.Item("InternalWaterPaid")
                    End If

                    If Not veri.Item("StormPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.StormPaid = veri.Item("StormPaid")
                    End If

                    If Not veri.Item("TheftPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TheftPaid = veri.Item("TheftPaid")
                    End If

                    If Not veri.Item("LandVehiclesPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.LandVehiclesPaid = veri.Item("LandVehiclesPaid")
                    End If

                    If Not veri.Item("AirCraftPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AirCraftPaid = veri.Item("AirCraftPaid")
                    End If

                    If Not veri.Item("MaritimeVehiclesPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaritimeVehiclesPaid = veri.Item("MaritimeVehiclesPaid")
                    End If

                    If Not veri.Item("SmokePaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SmokePaid = veri.Item("SmokePaid")
                    End If

                    If Not veri.Item("SpaceShiftPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SpaceShiftPaid = veri.Item("SpaceShiftPaid")
                    End If

                    If Not veri.Item("GLKHHPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.GLKHHPaid = veri.Item("GLKHHPaid")
                    End If

                    If Not veri.Item("MaliciousTerrorPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaliciousTerrorPaid = veri.Item("MaliciousTerrorPaid")
                    End If

                    If Not veri.Item("OtherGuaranteesPaid") Is System.DBNull.Value Then
                        donecekFireDamageInfo.OtherGuaranteesPaid = veri.Item("OtherGuaranteesPaid")
                    End If

                    If Not veri.Item("BuildingPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.BuildingPending = veri.Item("BuildingPending")
                    End If

                    If Not veri.Item("ContentsPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.ContentsPending = veri.Item("ContentsPending")
                    End If

                    If Not veri.Item("EarthquakePending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.EarthquakePending = veri.Item("EarthquakePending")
                    End If

                    If Not veri.Item("FloodFloodingPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FloodFloodingPending = veri.Item("FloodFloodingPending")
                    End If

                    If Not veri.Item("InternalWaterPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.InternalWaterPending = veri.Item("InternalWaterPending")
                    End If

                    If Not veri.Item("StormPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.StormPending = veri.Item("StormPending")
                    End If

                    If Not veri.Item("TheftPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.TheftPending = veri.Item("TheftPending")
                    End If

                    If Not veri.Item("LandVehiclesPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.LandVehiclesPending = veri.Item("LandVehiclesPending")
                    End If

                    If Not veri.Item("AirCraftPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.AirCraftPending = veri.Item("AirCraftPending")
                    End If

                    If Not veri.Item("MaritmeVehiclesPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaritmeVehiclesPending = veri.Item("MaritmeVehiclesPending")
                    End If

                    If Not veri.Item("SmokePending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SmokePending = veri.Item("SmokePending")
                    End If

                    If Not veri.Item("SpaceShiftPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.SpaceShiftPending = veri.Item("SpaceShiftPending")
                    End If

                    If Not veri.Item("GLKHHPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.GLKHHPending = veri.Item("GLKHHPending")
                    End If

                    If Not veri.Item("MaliciousTerrorPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.MaliciousTerrorPending = veri.Item("MaliciousTerrorPending")
                    End If

                    If Not veri.Item("OtherGuaranteesPending") Is System.DBNull.Value Then
                        donecekFireDamageInfo.OtherGuaranteesPending = veri.Item("OtherGuaranteesPending")
                    End If

                    If Not veri.Item("PendingTotalAmount") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PendingTotalAmount = veri.Item("PendingTotalAmount")
                    End If

                    If Not veri.Item("PendingTotalAmountTL") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PendingTotalAmountTL = veri.Item("PendingTotalAmountTL")
                    End If

                    If Not veri.Item("PaidTotalAmount") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PaidTotalAmount = veri.Item("PaidTotalAmount")
                    End If

                    If Not veri.Item("PaidTotalAmountTL") Is System.DBNull.Value Then
                        donecekFireDamageInfo.PaidTotalAmountTL = veri.Item("PaidTotalAmountTL")
                    End If

                    If Not veri.Item("RustyAmount") Is System.DBNull.Value Then
                        donecekFireDamageInfo.RustyAmount = veri.Item("RustyAmount")
                    End If

                    If Not veri.Item("FDSBMCode") Is System.DBNull.Value Then
                        donecekFireDamageInfo.FDSBMCode = veri.Item("FDSBMCode")
                    End If


                    FireDamageInfoler.Add(New FireDamageInfo(donecekFireDamageInfo.pkey,
                    donecekFireDamageInfo.firepolicyinfopkey, donecekFireDamageInfo.FirmCode, donecekFireDamageInfo.ProductCode, donecekFireDamageInfo.AgencyCode,
                    donecekFireDamageInfo.PolicyNumber, donecekFireDamageInfo.TecditNumber, donecekFireDamageInfo.FileNumber, donecekFireDamageInfo.RequestNumber,
                    donecekFireDamageInfo.PolicyType, donecekFireDamageInfo.DamageDate, donecekFireDamageInfo.NoticeDate, donecekFireDamageInfo.FileClosingDate,
                    donecekFireDamageInfo.DamageStatusCode, donecekFireDamageInfo.ClaimOwnerCountryCode, donecekFireDamageInfo.ClaimOwnerIdentityCode, donecekFireDamageInfo.ClaimOwnerIdentityNo,
                    donecekFireDamageInfo.ClaimOwnerName, donecekFireDamageInfo.ClaimOwnerSurname, donecekFireDamageInfo.CurrencyCode, donecekFireDamageInfo.ExchangeRate,
                    donecekFireDamageInfo.AgencyRegisterCode, donecekFireDamageInfo.TPNo, donecekFireDamageInfo.BuildingPaid, donecekFireDamageInfo.ContentsPaid,
                    donecekFireDamageInfo.EarthquakePaid, donecekFireDamageInfo.FloodFloodingPaid, donecekFireDamageInfo.InternalWaterPaid, donecekFireDamageInfo.StormPaid,
                    donecekFireDamageInfo.TheftPaid, donecekFireDamageInfo.LandVehiclesPaid, donecekFireDamageInfo.AirCraftPaid, donecekFireDamageInfo.MaritimeVehiclesPaid,
                    donecekFireDamageInfo.SmokePaid, donecekFireDamageInfo.SpaceShiftPaid, donecekFireDamageInfo.GLKHHPaid, donecekFireDamageInfo.MaliciousTerrorPaid,
                    donecekFireDamageInfo.OtherGuaranteesPaid, donecekFireDamageInfo.BuildingPending, donecekFireDamageInfo.ContentsPending, donecekFireDamageInfo.EarthquakePending,
                    donecekFireDamageInfo.FloodFloodingPending, donecekFireDamageInfo.InternalWaterPending, donecekFireDamageInfo.StormPending, donecekFireDamageInfo.TheftPending,
                    donecekFireDamageInfo.LandVehiclesPending, donecekFireDamageInfo.AirCraftPending, donecekFireDamageInfo.MaritmeVehiclesPending, donecekFireDamageInfo.SmokePending,
                    donecekFireDamageInfo.SpaceShiftPending, donecekFireDamageInfo.GLKHHPending, donecekFireDamageInfo.MaliciousTerrorPending, donecekFireDamageInfo.OtherGuaranteesPending,
                    donecekFireDamageInfo.PendingTotalAmount, donecekFireDamageInfo.PendingTotalAmountTL, donecekFireDamageInfo.PaidTotalAmount, donecekFireDamageInfo.PaidTotalAmountTL,
                    donecekFireDamageInfo.RustyAmount, donecekFireDamageInfo.FDSBMCode))

                End While
            End Using

            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using
        Return FireDamageInfoler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20 As String
        Dim kol21, kol22, kol23, kol24, kol25, kol26, kol27, kol28, kol29, kol30 As String
        Dim kol31, kol32, kol33, kol34, kol35, kol36, kol37, kol38, kol39, kol40 As String
        Dim kol41, kol42, kol43, kol44, kol45, kol46, kol47, kol48, kol49, kol50 As String
        Dim kol51, kol52, kol53, kol54, kol55, kol56, kol57, kol58, kol59 As String
        Dim tabloson As String
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
        "<th>firepolicyinfopkey</th>" +
        "<th>FirmCode</th>" +
        "<th>ProductCode</th>" +
        "<th>AgencyCode</th>" +
        "<th>PolicyNumber</th>" +
        "<th>TecditNumber</th>" +
        "<th>FileNumber</th>" +
        "<th>RequestNumber</th>" +
        "<th>PolicyType</th>" +
        "<th>DamageDate</th>" +
        "<th>NoticeDate</th>" +
        "<th>FileClosingDate</th>" +
        "<th>DamageStatusCode</th>" +
        "<th>ClaimOwnerCountryCode</th>" +
        "<th>ClaimOwnerIdentityCode</th>" +
        "<th>ClaimOwnerIdentityNo</th>" +
        "<th>ClaimOwnerName</th>" +
        "<th>ClaimOwnerSurname</th>" +
        "<th>CurrencyCode</th>" +
        "<th>ExchangeRate</th>" +
        "<th>AgencyRegisterCode</th>" +
        "<th>TPNo</th>" +
        "<th>BuildingPaid</th>" +
        "<th>ContentsPaid</th>" +
        "<th>EarthquakePaid</th>" +
        "<th>FloodFloodingPaid</th>" +
        "<th>InternalWaterPaid</th>" +
        "<th>StormPaid</th>" +
        "<th>TheftPaid</th>" +
        "<th>LandVehiclesPaid</th>" +
        "<th>AirCraftPaid</th>" +
        "<th>MaritimeVehiclesPaid</th>" +
        "<th>SmokePaid</th>" +
        "<th>SpaceShiftPaid</th>" +
        "<th>GLKHHPaid</th>" +
        "<th>MaliciousTerrorPaid</th>" +
        "<th>OtherGuaranteesPaid</th>" +
        "<th>BuildingPending</th>" +
        "<th>ContentsPending</th>" +
        "<th>EarthquakePending</th>" +
        "<th>FloodFloodingPending</th>" +
        "<th>InternalWaterPending</th>" +
        "<th>StormPending</th>" +
        "<th>TheftPending</th>" +
        "<th>LandVehiclesPending</th>" +
        "<th>AirCraftPending</th>" +
        "<th>MaritmeVehiclesPending</th>" +
        "<th>SmokePending</th>" +
        "<th>SpaceShiftPending</th>" +
        "<th>GLKHHPending</th>" +
        "<th>MaliciousTerrorPending</th>" +
        "<th>OtherGuaranteesPending</th>" +
        "<th>PendingTotalAmount</th>" +
        "<th>PendingTotalAmountTL</th>" +
        "<th>PaidTotalAmount</th>" +
        "<th>PaidTotalAmountTL</th>" +
        "<th>RustyAmount</th>" +
        "<th>FDSBMCode</th>" +
        "</tr>" +
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from FireDamageInfo"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If
        If HttpContext.Current.Session("ltip") = "adsoyad" Then
            sqlstr = "select * from FireDamageInfo where adsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, firepolicyinfopkey, FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNumber, RequestNumber, PolicyType, DamageDate, NoticeDate, FileClosingDate, DamageStatusCode, ClaimOwnerCountryCode, ClaimOwnerIdentityCode, ClaimOwnerIdentityNo, ClaimOwnerName, ClaimOwnerSurname, CurrencyCode, ExchangeRate, AgencyRegisterCode, TPNo, BuildingPaid, ContentsPaid, EarthquakePaid, FloodFloodingPaid, InternalWaterPaid, StormPaid, TheftPaid, LandVehiclesPaid, AirCraftPaid, MaritimeVehiclesPaid, SmokePaid, SpaceShiftPaid, GLKHHPaid, MaliciousTerrorPaid, OtherGuaranteesPaid, BuildingPending, ContentsPending, EarthquakePending, FloodFloodingPending, InternalWaterPending, StormPending, TheftPending, LandVehiclesPending, AirCraftPending, MaritmeVehiclesPending, SmokePending, SpaceShiftPending, GLKHHPending, MaliciousTerrorPending, OtherGuaranteesPending, PendingTotalAmount, PendingTotalAmountTL, PaidTotalAmount, PaidTotalAmountTL, RustyAmount, FDSBMCode As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "FireDamageInfo.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("firepolicyinfopkey") Is System.DBNull.Value Then
                        firepolicyinfopkey = veri.Item("firepolicyinfopkey")
                        kol2 = "<td>" + firepolicyinfopkey + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        kol3 = "<td>" + FirmCode + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol4 = "<td>" + ProductCode + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol5 = "<td>" + AgencyCode + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol6 = "<td>" + PolicyNumber + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                        TecditNumber = veri.Item("TecditNumber")
                        kol7 = "<td>" + TecditNumber + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("FileNumber") Is System.DBNull.Value Then
                        FileNumber = veri.Item("FileNumber")
                        kol8 = "<td>" + FileNumber + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("RequestNumber") Is System.DBNull.Value Then
                        RequestNumber = veri.Item("RequestNumber")
                        kol9 = "<td>" + RequestNumber + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                        PolicyType = veri.Item("PolicyType")
                        kol10 = "<td>" + PolicyType + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If

                    If Not veri.Item("DamageDate") Is System.DBNull.Value Then
                        DamageDate = veri.Item("DamageDate")
                        kol11 = "<td>" + DamageDate + "</td>"
                    Else
                        kol11 = "<td>-</td>"
                    End If

                    If Not veri.Item("NoticeDate") Is System.DBNull.Value Then
                        NoticeDate = veri.Item("NoticeDate")
                        kol12 = "<td>" + NoticeDate + "</td>"
                    Else
                        kol12 = "<td>-</td>"
                    End If

                    If Not veri.Item("FileClosingDate") Is System.DBNull.Value Then
                        FileClosingDate = veri.Item("FileClosingDate")
                        kol13 = "<td>" + FileClosingDate + "</td>"
                    Else
                        kol13 = "<td>-</td>"
                    End If

                    If Not veri.Item("DamageStatusCode") Is System.DBNull.Value Then
                        DamageStatusCode = veri.Item("DamageStatusCode")
                        kol14 = "<td>" + DamageStatusCode + "</td>"
                    Else
                        kol14 = "<td>-</td>"
                    End If

                    If Not veri.Item("ClaimOwnerCountryCode") Is System.DBNull.Value Then
                        ClaimOwnerCountryCode = veri.Item("ClaimOwnerCountryCode")
                        kol15 = "<td>" + ClaimOwnerCountryCode + "</td>"
                    Else
                        kol15 = "<td>-</td>"
                    End If

                    If Not veri.Item("ClaimOwnerIdentityCode") Is System.DBNull.Value Then
                        ClaimOwnerIdentityCode = veri.Item("ClaimOwnerIdentityCode")
                        kol16 = "<td>" + ClaimOwnerIdentityCode + "</td>"
                    Else
                        kol16 = "<td>-</td>"
                    End If

                    If Not veri.Item("ClaimOwnerIdentityNo") Is System.DBNull.Value Then
                        ClaimOwnerIdentityNo = veri.Item("ClaimOwnerIdentityNo")
                        kol17 = "<td>" + ClaimOwnerIdentityNo + "</td>"
                    Else
                        kol17 = "<td>-</td>"
                    End If

                    If Not veri.Item("ClaimOwnerName") Is System.DBNull.Value Then
                        ClaimOwnerName = veri.Item("ClaimOwnerName")
                        kol18 = "<td>" + ClaimOwnerName + "</td>"
                    Else
                        kol18 = "<td>-</td>"
                    End If

                    If Not veri.Item("ClaimOwnerSurname") Is System.DBNull.Value Then
                        ClaimOwnerSurname = veri.Item("ClaimOwnerSurname")
                        kol19 = "<td>" + ClaimOwnerSurname + "</td>"
                    Else
                        kol19 = "<td>-</td>"
                    End If

                    If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                        CurrencyCode = veri.Item("CurrencyCode")
                        kol20 = "<td>" + CurrencyCode + "</td>"
                    Else
                        kol20 = "<td>-</td>"
                    End If

                    If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                        ExchangeRate = veri.Item("ExchangeRate")
                        kol21 = "<td>" + ExchangeRate + "</td>"
                    Else
                        kol21 = "<td>-</td>"
                    End If

                    If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                        AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                        kol22 = "<td>" + AgencyRegisterCode + "</td>"
                    Else
                        kol22 = "<td>-</td>"
                    End If

                    If Not veri.Item("TPNo") Is System.DBNull.Value Then
                        TPNo = veri.Item("TPNo")
                        kol23 = "<td>" + TPNo + "</td>"
                    Else
                        kol23 = "<td>-</td>"
                    End If

                    If Not veri.Item("BuildingPaid") Is System.DBNull.Value Then
                        BuildingPaid = veri.Item("BuildingPaid")
                        kol24 = "<td>" + BuildingPaid + "</td>"
                    Else
                        kol24 = "<td>-</td>"
                    End If

                    If Not veri.Item("ContentsPaid") Is System.DBNull.Value Then
                        ContentsPaid = veri.Item("ContentsPaid")
                        kol25 = "<td>" + ContentsPaid + "</td>"
                    Else
                        kol25 = "<td>-</td>"
                    End If

                    If Not veri.Item("EarthquakePaid") Is System.DBNull.Value Then
                        EarthquakePaid = veri.Item("EarthquakePaid")
                        kol26 = "<td>" + EarthquakePaid + "</td>"
                    Else
                        kol26 = "<td>-</td>"
                    End If

                    If Not veri.Item("FloodFloodingPaid") Is System.DBNull.Value Then
                        FloodFloodingPaid = veri.Item("FloodFloodingPaid")
                        kol27 = "<td>" + FloodFloodingPaid + "</td>"
                    Else
                        kol27 = "<td>-</td>"
                    End If

                    If Not veri.Item("InternalWaterPaid") Is System.DBNull.Value Then
                        InternalWaterPaid = veri.Item("InternalWaterPaid")
                        kol28 = "<td>" + InternalWaterPaid + "</td>"
                    Else
                        kol28 = "<td>-</td>"
                    End If

                    If Not veri.Item("StormPaid") Is System.DBNull.Value Then
                        StormPaid = veri.Item("StormPaid")
                        kol29 = "<td>" + StormPaid + "</td>"
                    Else
                        kol29 = "<td>-</td>"
                    End If

                    If Not veri.Item("TheftPaid") Is System.DBNull.Value Then
                        TheftPaid = veri.Item("TheftPaid")
                        kol30 = "<td>" + TheftPaid + "</td>"
                    Else
                        kol30 = "<td>-</td>"
                    End If

                    If Not veri.Item("LandVehiclesPaid") Is System.DBNull.Value Then
                        LandVehiclesPaid = veri.Item("LandVehiclesPaid")
                        kol31 = "<td>" + LandVehiclesPaid + "</td>"
                    Else
                        kol31 = "<td>-</td>"
                    End If

                    If Not veri.Item("AirCraftPaid") Is System.DBNull.Value Then
                        AirCraftPaid = veri.Item("AirCraftPaid")
                        kol32 = "<td>" + AirCraftPaid + "</td>"
                    Else
                        kol32 = "<td>-</td>"
                    End If

                    If Not veri.Item("MaritimeVehiclesPaid") Is System.DBNull.Value Then
                        MaritimeVehiclesPaid = veri.Item("MaritimeVehiclesPaid")
                        kol33 = "<td>" + MaritimeVehiclesPaid + "</td>"
                    Else
                        kol33 = "<td>-</td>"
                    End If

                    If Not veri.Item("SmokePaid") Is System.DBNull.Value Then
                        SmokePaid = veri.Item("SmokePaid")
                        kol34 = "<td>" + SmokePaid + "</td>"
                    Else
                        kol34 = "<td>-</td>"
                    End If

                    If Not veri.Item("SpaceShiftPaid") Is System.DBNull.Value Then
                        SpaceShiftPaid = veri.Item("SpaceShiftPaid")
                        kol35 = "<td>" + SpaceShiftPaid + "</td>"
                    Else
                        kol35 = "<td>-</td>"
                    End If

                    If Not veri.Item("GLKHHPaid") Is System.DBNull.Value Then
                        GLKHHPaid = veri.Item("GLKHHPaid")
                        kol36 = "<td>" + GLKHHPaid + "</td>"
                    Else
                        kol36 = "<td>-</td>"
                    End If

                    If Not veri.Item("MaliciousTerrorPaid") Is System.DBNull.Value Then
                        MaliciousTerrorPaid = veri.Item("MaliciousTerrorPaid")
                        kol37 = "<td>" + MaliciousTerrorPaid + "</td>"
                    Else
                        kol37 = "<td>-</td>"
                    End If

                    If Not veri.Item("OtherGuaranteesPaid") Is System.DBNull.Value Then
                        OtherGuaranteesPaid = veri.Item("OtherGuaranteesPaid")
                        kol38 = "<td>" + OtherGuaranteesPaid + "</td>"
                    Else
                        kol38 = "<td>-</td>"
                    End If

                    If Not veri.Item("BuildingPending") Is System.DBNull.Value Then
                        BuildingPending = veri.Item("BuildingPending")
                        kol39 = "<td>" + BuildingPending + "</td>"
                    Else
                        kol39 = "<td>-</td>"
                    End If

                    If Not veri.Item("ContentsPending") Is System.DBNull.Value Then
                        ContentsPending = veri.Item("ContentsPending")
                        kol40 = "<td>" + ContentsPending + "</td>"
                    Else
                        kol40 = "<td>-</td>"
                    End If

                    If Not veri.Item("EarthquakePending") Is System.DBNull.Value Then
                        EarthquakePending = veri.Item("EarthquakePending")
                        kol41 = "<td>" + EarthquakePending + "</td>"
                    Else
                        kol41 = "<td>-</td>"
                    End If

                    If Not veri.Item("FloodFloodingPending") Is System.DBNull.Value Then
                        FloodFloodingPending = veri.Item("FloodFloodingPending")
                        kol42 = "<td>" + FloodFloodingPending + "</td>"
                    Else
                        kol42 = "<td>-</td>"
                    End If

                    If Not veri.Item("InternalWaterPending") Is System.DBNull.Value Then
                        InternalWaterPending = veri.Item("InternalWaterPending")
                        kol43 = "<td>" + InternalWaterPending + "</td>"
                    Else
                        kol43 = "<td>-</td>"
                    End If

                    If Not veri.Item("StormPending") Is System.DBNull.Value Then
                        StormPending = veri.Item("StormPending")
                        kol44 = "<td>" + StormPending + "</td>"
                    Else
                        kol44 = "<td>-</td>"
                    End If

                    If Not veri.Item("TheftPending") Is System.DBNull.Value Then
                        TheftPending = veri.Item("TheftPending")
                        kol45 = "<td>" + TheftPending + "</td>"
                    Else
                        kol45 = "<td>-</td>"
                    End If

                    If Not veri.Item("LandVehiclesPending") Is System.DBNull.Value Then
                        LandVehiclesPending = veri.Item("LandVehiclesPending")
                        kol46 = "<td>" + LandVehiclesPending + "</td>"
                    Else
                        kol46 = "<td>-</td>"
                    End If

                    If Not veri.Item("AirCraftPending") Is System.DBNull.Value Then
                        AirCraftPending = veri.Item("AirCraftPending")
                        kol47 = "<td>" + AirCraftPending + "</td>"
                    Else
                        kol47 = "<td>-</td>"
                    End If

                    If Not veri.Item("MaritmeVehiclesPending") Is System.DBNull.Value Then
                        MaritmeVehiclesPending = veri.Item("MaritmeVehiclesPending")
                        kol48 = "<td>" + MaritmeVehiclesPending + "</td>"
                    Else
                        kol48 = "<td>-</td>"
                    End If

                    If Not veri.Item("SmokePending") Is System.DBNull.Value Then
                        SmokePending = veri.Item("SmokePending")
                        kol49 = "<td>" + SmokePending + "</td>"
                    Else
                        kol49 = "<td>-</td>"
                    End If

                    If Not veri.Item("SpaceShiftPending") Is System.DBNull.Value Then
                        SpaceShiftPending = veri.Item("SpaceShiftPending")
                        kol50 = "<td>" + SpaceShiftPending + "</td>"
                    Else
                        kol50 = "<td>-</td>"
                    End If

                    If Not veri.Item("GLKHHPending") Is System.DBNull.Value Then
                        GLKHHPending = veri.Item("GLKHHPending")
                        kol51 = "<td>" + GLKHHPending + "</td>"
                    Else
                        kol51 = "<td>-</td>"
                    End If

                    If Not veri.Item("MaliciousTerrorPending") Is System.DBNull.Value Then
                        MaliciousTerrorPending = veri.Item("MaliciousTerrorPending")
                        kol52 = "<td>" + MaliciousTerrorPending + "</td>"
                    Else
                        kol52 = "<td>-</td>"
                    End If

                    If Not veri.Item("OtherGuaranteesPending") Is System.DBNull.Value Then
                        OtherGuaranteesPending = veri.Item("OtherGuaranteesPending")
                        kol53 = "<td>" + OtherGuaranteesPending + "</td>"
                    Else
                        kol53 = "<td>-</td>"
                    End If

                    If Not veri.Item("PendingTotalAmount") Is System.DBNull.Value Then
                        PendingTotalAmount = veri.Item("PendingTotalAmount")
                        kol54 = "<td>" + PendingTotalAmount + "</td>"
                    Else
                        kol54 = "<td>-</td>"
                    End If

                    If Not veri.Item("PendingTotalAmountTL") Is System.DBNull.Value Then
                        PendingTotalAmountTL = veri.Item("PendingTotalAmountTL")
                        kol55 = "<td>" + PendingTotalAmountTL + "</td>"
                    Else
                        kol55 = "<td>-</td>"
                    End If

                    If Not veri.Item("PaidTotalAmount") Is System.DBNull.Value Then
                        PaidTotalAmount = veri.Item("PaidTotalAmount")
                        kol56 = "<td>" + PaidTotalAmount + "</td>"
                    Else
                        kol56 = "<td>-</td>"
                    End If

                    If Not veri.Item("PaidTotalAmountTL") Is System.DBNull.Value Then
                        PaidTotalAmountTL = veri.Item("PaidTotalAmountTL")
                        kol57 = "<td>" + PaidTotalAmountTL + "</td>"
                    Else
                        kol57 = "<td>-</td>"
                    End If

                    If Not veri.Item("RustyAmount") Is System.DBNull.Value Then
                        RustyAmount = veri.Item("RustyAmount")
                        kol58 = "<td>" + RustyAmount + "</td>"
                    Else
                        kol58 = "<td>-</td>"
                    End If

                    If Not veri.Item("FDSBMCode") Is System.DBNull.Value Then
                        FDSBMCode = veri.Item("FDSBMCode")
                        kol59 = "<td>" + FDSBMCode + "</td></tr>"
                    Else
                        kol59 = "<td>-</td>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12 + kol13 + kol14 + kol15 + kol16 + kol17 + kol18 + kol19 + kol20 + kol21 + kol22 + kol23 + kol24 + kol25 + kol26 + kol27 + kol28 + kol29 + kol30 + kol31 + kol32 + kol33 + kol34 + kol35 + kol36 + kol37 + kol38 + kol39 + kol40 + kol41 + kol42 + kol43 + kol44 + kol45 + kol46 + kol47 + kol48 + kol49 + kol50 + kol51 + kol52 + kol53 + kol54 + kol55 + kol56 + kol57 + kol58 + kol59
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
    ByVal PolicyType As String, ByVal FileNumber As String,
    ByVal RequestNo As String) As Integer


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
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", PolicyType, " "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FileNumber", "=", FileNumber, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "RequestNo", "=", RequestNo, " "))

        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "FireDamageInfo", "count(*)", fieldopvalues)
        Return kackayit

    End Function





End Class