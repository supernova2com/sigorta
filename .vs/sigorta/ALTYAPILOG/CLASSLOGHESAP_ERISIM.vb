Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSLOGHESAP_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim loghesap As New CLASSLOGHESAP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal loghesap As CLASSLOGHESAP) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into loghesap values (@pkey," + _
        "@tarih,@FirmCode,@ProductCode,@AgencyCode," + _
        "@PolicyNumber,@TecditNumber,@ZeylCode,@ZeylNo," + _
        "@s_InsuarencePremium,@s_BasePriceValue,@s_CCRateValue,@s_DamageRateValue," + _
        "@s_AgeRateValue,@s_DamagelessRateValue,@hesaplog,@tuzukccoran," + _
        "@tuzukyasoran,@sonuckodu,@hatakodu,@hatamsg," + _
        "@s_AnyDriver,@g_AuthorizedDrivers,@g_CurrencyCode,@g_InsurancePremium," + _
        "@g_AssistantFees,@g_OtherFees,@g_BasePriceValue,@g_CCRateValue," + _
        "@g_DamageRateValue,@g_AgeRateValue,@g_DamagelessRateValue,@ArrangeDate," + _
        "@hasarsorgulog,@ProductType)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If loghesap.tarih Is Nothing Or loghesap.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = loghesap.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If loghesap.FirmCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = loghesap.FirmCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If loghesap.ProductCode = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = loghesap.ProductCode
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If loghesap.AgencyCode = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = loghesap.AgencyCode
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If loghesap.PolicyNumber = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = loghesap.PolicyNumber
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If loghesap.TecditNumber = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = loghesap.TecditNumber
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If loghesap.ZeylCode = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = loghesap.ZeylCode
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If loghesap.ZeylNo = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = loghesap.ZeylNo
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@s_InsuarencePremium", SqlDbType.Decimal)
        param10.Direction = ParameterDirection.Input
        If loghesap.s_InsuarencePremium = 0 Then
            param10.Value = 0
        Else
            param10.Value = loghesap.s_InsuarencePremium
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@s_BasePriceValue", SqlDbType.Decimal)
        param11.Direction = ParameterDirection.Input
        If loghesap.s_BasePriceValue = 0 Then
            param11.Value = 0
        Else
            param11.Value = loghesap.s_BasePriceValue
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@s_CCRateValue", SqlDbType.Decimal)
        param12.Direction = ParameterDirection.Input
        If loghesap.s_CCRateValue = 0 Then
            param12.Value = 0
        Else
            param12.Value = loghesap.s_CCRateValue
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@s_DamageRateValue", SqlDbType.Decimal)
        param13.Direction = ParameterDirection.Input
        If loghesap.s_DamageRateValue = 0 Then
            param13.Value = 0
        Else
            param13.Value = loghesap.s_DamageRateValue
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@s_AgeRateValue", SqlDbType.Decimal)
        param14.Direction = ParameterDirection.Input
        If loghesap.s_AgeRateValue = 0 Then
            param14.Value = 0
        Else
            param14.Value = loghesap.s_AgeRateValue
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@s_DamagelessRateValue", SqlDbType.Decimal)
        param15.Direction = ParameterDirection.Input
        If loghesap.s_DamagelessRateValue = 0 Then
            param15.Value = 0
        Else
            param15.Value = loghesap.s_DamagelessRateValue
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@hesaplog", SqlDbType.Text)
        param16.Direction = ParameterDirection.Input
        If loghesap.hesaplog = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = loghesap.hesaplog
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@tuzukccoran", SqlDbType.Decimal)
        param17.Direction = ParameterDirection.Input
        If loghesap.tuzukccoran = 0 Then
            param17.Value = 0
        Else
            param17.Value = loghesap.tuzukccoran
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@tuzukyasoran", SqlDbType.Decimal)
        param18.Direction = ParameterDirection.Input
        If loghesap.tuzukyasoran = 0 Then
            param18.Value = 0
        Else
            param18.Value = loghesap.tuzukyasoran
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@sonuckodu", SqlDbType.Int)
        param19.Direction = ParameterDirection.Input
        If loghesap.sonuckodu = 0 Then
            param19.Value = 0
        Else
            param19.Value = loghesap.sonuckodu
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@hatakodu", SqlDbType.Int)
        param20.Direction = ParameterDirection.Input
        If loghesap.hatakodu = 0 Then
            param20.Value = 0
        Else
            param20.Value = loghesap.hatakodu
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@hatamsg", SqlDbType.Text)
        param21.Direction = ParameterDirection.Input
        If loghesap.hatamsg = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = loghesap.hatamsg
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@s_AnyDriver", SqlDbType.Decimal)
        param22.Direction = ParameterDirection.Input
        If loghesap.s_AnyDriver = 0 Then
            param22.Value = 0
        Else
            param22.Value = loghesap.s_AnyDriver
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@g_AuthorizedDrivers", SqlDbType.VarChar)
        param23.Direction = ParameterDirection.Input
        If loghesap.g_AuthorizedDrivers = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = loghesap.g_AuthorizedDrivers
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@g_CurrencyCode", SqlDbType.VarChar)
        param24.Direction = ParameterDirection.Input
        If loghesap.g_CurrencyCode = "" Then
            param24.Value = System.DBNull.Value
        Else
            param24.Value = loghesap.g_CurrencyCode
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@g_InsurancePremium", SqlDbType.Decimal)
        param25.Direction = ParameterDirection.Input
        If loghesap.g_InsurancePremium = 0 Then
            param25.Value = 0
        Else
            param25.Value = loghesap.g_InsurancePremium
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@g_AssistantFees", SqlDbType.Decimal)
        param26.Direction = ParameterDirection.Input
        If loghesap.g_AssistantFees = 0 Then
            param26.Value = 0
        Else
            param26.Value = loghesap.g_AssistantFees
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@g_OtherFees", SqlDbType.Decimal)
        param27.Direction = ParameterDirection.Input
        If loghesap.g_OtherFees = 0 Then
            param27.Value = 0
        Else
            param27.Value = loghesap.g_OtherFees
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@g_BasePriceValue", SqlDbType.Decimal)
        param28.Direction = ParameterDirection.Input
        If loghesap.g_BasePriceValue = 0 Then
            param28.Value = 0
        Else
            param28.Value = loghesap.g_BasePriceValue
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@g_CCRateValue", SqlDbType.Decimal)
        param29.Direction = ParameterDirection.Input
        If loghesap.g_CCRateValue = 0 Then
            param29.Value = 0
        Else
            param29.Value = loghesap.g_CCRateValue
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@g_DamageRateValue", SqlDbType.Decimal)
        param30.Direction = ParameterDirection.Input
        If loghesap.g_DamageRateValue = 0 Then
            param30.Value = 0
        Else
            param30.Value = loghesap.g_DamageRateValue
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@g_AgeRateValue", SqlDbType.Decimal)
        param31.Direction = ParameterDirection.Input
        If loghesap.g_AgeRateValue = 0 Then
            param31.Value = 0
        Else
            param31.Value = loghesap.g_AgeRateValue
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@g_DamagelessRateValue", SqlDbType.Decimal)
        param32.Direction = ParameterDirection.Input
        If loghesap.g_DamagelessRateValue = 0 Then
            param32.Value = 0
        Else
            param32.Value = loghesap.g_DamagelessRateValue
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@ArrangeDate", SqlDbType.Date)
        param33.Direction = ParameterDirection.Input
        If loghesap.ArrangeDate Is Nothing Or loghesap.ArrangeDate = "00:00:00" Then
            param33.Value = System.DBNull.Value
        Else
            param33.Value = loghesap.ArrangeDate
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@hasarsorgulog", SqlDbType.Text)
        param34.Direction = ParameterDirection.Input
        If loghesap.hasarsorgulog = "" Then
            param34.Value = System.DBNull.Value
        Else
            param34.Value = loghesap.hasarsorgulog
        End If
        komut.Parameters.Add(param34)


        Dim param35 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param35.Direction = ParameterDirection.Input
        If loghesap.ProductType = "" Then
            param35.Value = System.DBNull.Value
        Else
            param35.Value = loghesap.ProductType
        End If
        komut.Parameters.Add(param35)

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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from loghesap"
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
        Return pkey

    End Function

    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal loghesap As CLASSLOGHESAP) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update loghesap set " + _
        "tarih=@tarih," + _
        "FirmCode=@FirmCode," + _
        "ProductCode=@ProductCode," + _
        "AgencyCode=@AgencyCode," + _
        "PolicyNumber=@PolicyNumber," + _
        "TecditNumber=@TecditNumber," + _
        "ZeylCode=@ZeylCode," + _
        "ZeylNo=@ZeylNo," + _
        "s_InsuarencePremium=@s_InsuarencePremium," + _
        "s_BasePriceValue=@s_BasePriceValue," + _
        "s_CCRateValue=@s_CCRateValue," + _
        "s_DamageRateValue=@s_DamageRateValue," + _
        "s_AgeRateValue=@s_AgeRateValue," + _
        "s_DamagelessRateValue=@s_DamagelessRateValue," + _
        "hesaplog=@hesaplog," + _
        "tuzukccoran=@tuzukccoran," + _
        "tuzukyasoran=@tuzukyasoran," + _
        "sonuckodu=@sonuckodu," + _
        "hatakodu=@hatakodu," + _
        "hatamsg=@hatamsg," + _
        "s_AnyDriver=@s_AnyDriver," + _
        "g_AuthorizedDrivers=@g_AuthorizedDrivers," + _
        "g_CurrencyCode=@g_CurrencyCode," + _
        "g_InsurancePremium=@g_InsurancePremium," + _
        "g_AssistantFees=@g_AssistantFees," + _
        "g_OtherFees=@g_OtherFees," + _
        "g_BasePriceValue=@g_BasePriceValue," + _
        "g_CCRateValue=@g_CCRateValue," + _
        "g_DamagelessRateValue=@g_DamagelessRateValue," + _
        "ArrangeDate=@ArrangeDate," + _
        "hasarsorgulog=@hasarsorgulog," + _
        "ProductType=@ProductType" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = loghesap.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If loghesap.tarih Is Nothing Or loghesap.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = loghesap.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If loghesap.FirmCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = loghesap.FirmCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If loghesap.ProductCode = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = loghesap.ProductCode
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If loghesap.AgencyCode = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = loghesap.AgencyCode
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If loghesap.PolicyNumber = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = loghesap.PolicyNumber
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If loghesap.TecditNumber = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = loghesap.TecditNumber
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If loghesap.ZeylCode = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = loghesap.ZeylCode
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If loghesap.ZeylNo = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = loghesap.ZeylNo
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@s_InsuarencePremium", SqlDbType.Decimal)
        param10.Direction = ParameterDirection.Input
        If loghesap.s_InsuarencePremium = 0 Then
            param10.Value = 0
        Else
            param10.Value = loghesap.s_InsuarencePremium
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@s_BasePriceValue", SqlDbType.Decimal)
        param11.Direction = ParameterDirection.Input
        If loghesap.s_BasePriceValue = 0 Then
            param11.Value = 0
        Else
            param11.Value = loghesap.s_BasePriceValue
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@s_CCRateValue", SqlDbType.Decimal)
        param12.Direction = ParameterDirection.Input
        If loghesap.s_CCRateValue = 0 Then
            param12.Value = 0
        Else
            param12.Value = loghesap.s_CCRateValue
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@s_DamageRateValue", SqlDbType.Decimal)
        param13.Direction = ParameterDirection.Input
        If loghesap.s_DamageRateValue = 0 Then
            param13.Value = 0
        Else
            param13.Value = loghesap.s_DamageRateValue
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@s_AgeRateValue", SqlDbType.Decimal)
        param14.Direction = ParameterDirection.Input
        If loghesap.s_AgeRateValue = 0 Then
            param14.Value = 0
        Else
            param14.Value = loghesap.s_AgeRateValue
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@s_DamagelessRateValue", SqlDbType.Decimal)
        param15.Direction = ParameterDirection.Input
        If loghesap.s_DamagelessRateValue = 0 Then
            param15.Value = 0
        Else
            param15.Value = loghesap.s_DamagelessRateValue
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@hesaplog", SqlDbType.Text)
        param16.Direction = ParameterDirection.Input
        If loghesap.hesaplog = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = loghesap.hesaplog
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@tuzukccoran", SqlDbType.Decimal)
        param17.Direction = ParameterDirection.Input
        If loghesap.tuzukccoran = 0 Then
            param17.Value = 0
        Else
            param17.Value = loghesap.tuzukccoran
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@tuzukyasoran", SqlDbType.Decimal)
        param18.Direction = ParameterDirection.Input
        If loghesap.tuzukyasoran = 0 Then
            param18.Value = 0
        Else
            param18.Value = loghesap.tuzukyasoran
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@sonuckodu", SqlDbType.Int)
        param19.Direction = ParameterDirection.Input
        If loghesap.sonuckodu = 0 Then
            param19.Value = 0
        Else
            param19.Value = loghesap.sonuckodu
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@hatakodu", SqlDbType.Int)
        param20.Direction = ParameterDirection.Input
        If loghesap.hatakodu = 0 Then
            param20.Value = 0
        Else
            param20.Value = loghesap.hatakodu
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@hatamsg", SqlDbType.Text)
        param21.Direction = ParameterDirection.Input
        If loghesap.hatamsg = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = loghesap.hatamsg
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@s_AnyDriver", SqlDbType.Decimal)
        param22.Direction = ParameterDirection.Input
        If loghesap.s_AnyDriver = 0 Then
            param22.Value = 0
        Else
            param22.Value = loghesap.s_AnyDriver
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@g_AuthorizedDrivers", SqlDbType.VarChar)
        param23.Direction = ParameterDirection.Input
        If loghesap.g_AuthorizedDrivers = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = loghesap.g_AuthorizedDrivers
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@g_CurrencyCode", SqlDbType.VarChar)
        param24.Direction = ParameterDirection.Input
        If loghesap.g_CurrencyCode = "" Then
            param24.Value = System.DBNull.Value
        Else
            param24.Value = loghesap.g_CurrencyCode
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@g_InsurancePremium", SqlDbType.Decimal)
        param25.Direction = ParameterDirection.Input
        If loghesap.g_InsurancePremium = 0 Then
            param25.Value = 0
        Else
            param25.Value = loghesap.g_InsurancePremium
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@g_AssistantFees", SqlDbType.Decimal)
        param26.Direction = ParameterDirection.Input
        If loghesap.g_AssistantFees = 0 Then
            param26.Value = 0
        Else
            param26.Value = loghesap.g_AssistantFees
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@g_OtherFees", SqlDbType.Decimal)
        param27.Direction = ParameterDirection.Input
        If loghesap.g_OtherFees = 0 Then
            param27.Value = 0
        Else
            param27.Value = loghesap.g_OtherFees
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@g_BasePriceValue", SqlDbType.Decimal)
        param28.Direction = ParameterDirection.Input
        If loghesap.g_BasePriceValue = 0 Then
            param28.Value = 0
        Else
            param28.Value = loghesap.g_BasePriceValue
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@g_CCRateValue", SqlDbType.Decimal)
        param29.Direction = ParameterDirection.Input
        If loghesap.g_CCRateValue = 0 Then
            param29.Value = 0
        Else
            param29.Value = loghesap.g_CCRateValue
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@g_DamageRateValue", SqlDbType.Decimal)
        param30.Direction = ParameterDirection.Input
        If loghesap.g_DamageRateValue = 0 Then
            param30.Value = 0
        Else
            param30.Value = loghesap.g_DamageRateValue
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@g_AgeRateValue", SqlDbType.Decimal)
        param31.Direction = ParameterDirection.Input
        If loghesap.g_AgeRateValue = 0 Then
            param31.Value = 0
        Else
            param31.Value = loghesap.g_AgeRateValue
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@g_DamagelessRateValue", SqlDbType.Decimal)
        param32.Direction = ParameterDirection.Input
        If loghesap.g_DamagelessRateValue = 0 Then
            param32.Value = 0
        Else
            param32.Value = loghesap.g_DamagelessRateValue
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@ArrangeDate", SqlDbType.Date)
        param33.Direction = ParameterDirection.Input
        If loghesap.ArrangeDate Is Nothing Or loghesap.ArrangeDate = "00:00:00" Then
            param33.Value = System.DBNull.Value
        Else
            param33.Value = loghesap.ArrangeDate
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@hasarsorgulog", SqlDbType.Text)
        param34.Direction = ParameterDirection.Input
        If loghesap.hasarsorgulog = "" Then
            param34.Value = System.DBNull.Value
        Else
            param34.Value = loghesap.hasarsorgulog
        End If
        komut.Parameters.Add(param34)

        Dim param35 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param35.Direction = ParameterDirection.Input
        If loghesap.ProductType = "" Then
            param35.Value = System.DBNull.Value
        Else
            param35.Value = loghesap.ProductType
        End If
        komut.Parameters.Add(param35)


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


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSLOGHESAP

        Dim komut As New SqlCommand
        Dim donecekloghesap As New CLASSLOGHESAP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from loghesap where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekloghesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekloghesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekloghesap.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekloghesap.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekloghesap.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekloghesap.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekloghesap.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekloghesap.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekloghesap.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("s_InsuarencePremium") Is System.DBNull.Value Then
                    donecekloghesap.s_InsuarencePremium = veri.Item("s_InsuarencePremium")
                End If

                If Not veri.Item("s_BasePriceValue") Is System.DBNull.Value Then
                    donecekloghesap.s_BasePriceValue = veri.Item("s_BasePriceValue")
                End If

                If Not veri.Item("s_CCRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_CCRateValue = veri.Item("s_CCRateValue")
                End If

                If Not veri.Item("s_DamageRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_DamageRateValue = veri.Item("s_DamageRateValue")
                End If

                If Not veri.Item("s_AgeRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_AgeRateValue = veri.Item("s_AgeRateValue")
                End If

                If Not veri.Item("s_DamagelessRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_DamagelessRateValue = veri.Item("s_DamagelessRateValue")
                End If

                If Not veri.Item("hesaplog") Is System.DBNull.Value Then
                    donecekloghesap.hesaplog = veri.Item("hesaplog")
                End If

                If Not veri.Item("tuzukccoran") Is System.DBNull.Value Then
                    donecekloghesap.tuzukccoran = veri.Item("tuzukccoran")
                End If

                If Not veri.Item("tuzukyasoran") Is System.DBNull.Value Then
                    donecekloghesap.tuzukyasoran = veri.Item("tuzukyasoran")
                End If

                If Not veri.Item("sonuckodu") Is System.DBNull.Value Then
                    donecekloghesap.sonuckodu = veri.Item("sonuckodu")
                End If

                If Not veri.Item("hatakodu") Is System.DBNull.Value Then
                    donecekloghesap.hatakodu = veri.Item("hatakodu")
                End If

                If Not veri.Item("hatamsg") Is System.DBNull.Value Then
                    donecekloghesap.hatamsg = veri.Item("hatamsg")
                End If

                If Not veri.Item("s_AnyDriver") Is System.DBNull.Value Then
                    donecekloghesap.s_AnyDriver = veri.Item("s_AnyDriver")
                End If

                If Not veri.Item("g_AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekloghesap.g_AuthorizedDrivers = veri.Item("g_AuthorizedDrivers")
                End If

                If Not veri.Item("g_CurrencyCode") Is System.DBNull.Value Then
                    donecekloghesap.g_CurrencyCode = veri.Item("g_CurrencyCode")
                End If

                If Not veri.Item("g_InsurancePremium") Is System.DBNull.Value Then
                    donecekloghesap.g_InsurancePremium = veri.Item("g_InsurancePremium")
                End If

                If Not veri.Item("g_AssistantFees") Is System.DBNull.Value Then
                    donecekloghesap.g_AssistantFees = veri.Item("g_AssistantFees")
                End If

                If Not veri.Item("g_OtherFees") Is System.DBNull.Value Then
                    donecekloghesap.g_OtherFees = veri.Item("g_OtherFees")
                End If

                If Not veri.Item("g_BasePriceValue") Is System.DBNull.Value Then
                    donecekloghesap.g_BasePriceValue = veri.Item("g_BasePriceValue")
                End If

                If Not veri.Item("g_CCRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_CCRateValue = veri.Item("g_CCRateValue")
                End If

                If Not veri.Item("g_DamageRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_DamageRateValue = veri.Item("g_DamageRateValue")
                End If

                If Not veri.Item("g_AgeRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_AgeRateValue = veri.Item("g_AgeRateValue")
                End If

                If Not veri.Item("g_DamagelessRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_DamagelessRateValue = veri.Item("g_DamagelessRateValue")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekloghesap.ArrangeDate = veri.Item("ArrangeDate")
                End If

                If Not veri.Item("hasarsorgulog") Is System.DBNull.Value Then
                    donecekloghesap.hasarsorgulog = veri.Item("hasarsorgulog")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekloghesap.ProductType = veri.Item("ProductType")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekloghesap

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from loghesap where pkey=@pkey"
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
        db_baglanti.Close()
        db_baglanti.Dispose()
    
        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal ZeylCode As String, ByVal ZeylNo As String, ByVal ProductType As String) As List(Of CLASSLOGHESAP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekloghesap As New CLASSLOGHESAP
        Dim loghesapler As New List(Of CLASSLOGHESAP)
        komut.Connection = db_baglanti

        sqlstr = "select * from PolicyInfo where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and ZeylCode=@ZeylCode " + _
        " and ZeylNo=@ZeylNo"

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

        Dim param5 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = ZeylCode
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ZeylNo
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = ProductType
        komut.Parameters.Add(param7)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekloghesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekloghesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekloghesap.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekloghesap.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekloghesap.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekloghesap.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekloghesap.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekloghesap.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekloghesap.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("s_InsuarencePremium") Is System.DBNull.Value Then
                    donecekloghesap.s_InsuarencePremium = veri.Item("s_InsuarencePremium")
                End If

                If Not veri.Item("s_BasePriceValue") Is System.DBNull.Value Then
                    donecekloghesap.s_BasePriceValue = veri.Item("s_BasePriceValue")
                End If

                If Not veri.Item("s_CCRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_CCRateValue = veri.Item("s_CCRateValue")
                End If

                If Not veri.Item("s_DamageRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_DamageRateValue = veri.Item("s_DamageRateValue")
                End If

                If Not veri.Item("s_AgeRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_AgeRateValue = veri.Item("s_AgeRateValue")
                End If

                If Not veri.Item("s_DamagelessRateValue") Is System.DBNull.Value Then
                    donecekloghesap.s_DamagelessRateValue = veri.Item("s_DamagelessRateValue")
                End If

                If Not veri.Item("hesaplog") Is System.DBNull.Value Then
                    donecekloghesap.hesaplog = veri.Item("hesaplog")
                End If

                If Not veri.Item("tuzukccoran") Is System.DBNull.Value Then
                    donecekloghesap.tuzukccoran = veri.Item("tuzukccoran")
                End If

                If Not veri.Item("tuzukyasoran") Is System.DBNull.Value Then
                    donecekloghesap.tuzukyasoran = veri.Item("tuzukyasoran")
                End If

                If Not veri.Item("sonuckodu") Is System.DBNull.Value Then
                    donecekloghesap.sonuckodu = veri.Item("sonuckodu")
                End If

                If Not veri.Item("hatakodu") Is System.DBNull.Value Then
                    donecekloghesap.hatakodu = veri.Item("hatakodu")
                End If

                If Not veri.Item("hatamsg") Is System.DBNull.Value Then
                    donecekloghesap.hatamsg = veri.Item("hatamsg")
                End If

                If Not veri.Item("s_AnyDriver") Is System.DBNull.Value Then
                    donecekloghesap.s_AnyDriver = veri.Item("s_AnyDriver")
                End If

                If Not veri.Item("g_AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekloghesap.g_AuthorizedDrivers = veri.Item("g_AuthorizedDrivers")
                End If

                If Not veri.Item("g_CurrencyCode") Is System.DBNull.Value Then
                    donecekloghesap.g_CurrencyCode = veri.Item("g_CurrencyCode")
                End If

                If Not veri.Item("g_InsurancePremium") Is System.DBNull.Value Then
                    donecekloghesap.g_InsurancePremium = veri.Item("g_InsurancePremium")
                End If

                If Not veri.Item("g_AssistantFees") Is System.DBNull.Value Then
                    donecekloghesap.g_AssistantFees = veri.Item("g_AssistantFees")
                End If

                If Not veri.Item("g_OtherFees") Is System.DBNull.Value Then
                    donecekloghesap.g_OtherFees = veri.Item("g_OtherFees")
                End If

                If Not veri.Item("g_BasePriceValue") Is System.DBNull.Value Then
                    donecekloghesap.g_BasePriceValue = veri.Item("g_BasePriceValue")
                End If

                If Not veri.Item("g_CCRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_CCRateValue = veri.Item("g_CCRateValue")
                End If

                If Not veri.Item("g_DamageRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_DamageRateValue = veri.Item("g_DamageRateValue")
                End If

                If Not veri.Item("g_AgeRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_AgeRateValue = veri.Item("g_AgeRateValue")
                End If

                If Not veri.Item("g_DamagelessRateValue") Is System.DBNull.Value Then
                    donecekloghesap.g_DamagelessRateValue = veri.Item("g_DamagelessRateValue")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekloghesap.ArrangeDate = veri.Item("ArrangeDate")
                End If

                If Not veri.Item("hasarsorgulog") Is System.DBNull.Value Then
                    donecekloghesap.hasarsorgulog = veri.Item("hasarsorgulog")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekloghesap.ProductType = veri.Item("ProductType")
                End If

                loghesapler.Add(New CLASSLOGHESAP(donecekloghesap.pkey, _
                donecekloghesap.tarih, donecekloghesap.FirmCode, donecekloghesap.ProductCode, _
                donecekloghesap.AgencyCode, donecekloghesap.PolicyNumber, donecekloghesap.TecditNumber, _
                donecekloghesap.ZeylCode, donecekloghesap.ZeylNo, _
                donecekloghesap.s_InsuarencePremium, donecekloghesap.s_BasePriceValue, _
                donecekloghesap.s_CCRateValue, donecekloghesap.s_DamageRateValue, _
                donecekloghesap.s_AgeRateValue, donecekloghesap.s_DamagelessRateValue, _
                donecekloghesap.hesaplog, donecekloghesap.tuzukccoran, donecekloghesap.tuzukyasoran, _
                donecekloghesap.sonuckodu, donecekloghesap.hatakodu, donecekloghesap.hatamsg, _
                donecekloghesap.s_AnyDriver, donecekloghesap.g_AuthorizedDrivers, donecekloghesap.g_CurrencyCode, _
                donecekloghesap.g_InsurancePremium, donecekloghesap.g_AssistantFees, _
                donecekloghesap.g_OtherFees, donecekloghesap.g_BasePriceValue, _
                donecekloghesap.g_CCRateValue, donecekloghesap.g_DamageRateValue, _
                donecekloghesap.g_AgeRateValue, donecekloghesap.g_DamagelessRateValue, _
                donecekloghesap.ArrangeDate, donecekloghesap.hasarsorgulog, _
                donecekloghesap.ProductType))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return loghesapler

    End Function

End Class


