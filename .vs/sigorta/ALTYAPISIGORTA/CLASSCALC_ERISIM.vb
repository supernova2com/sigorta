Imports System.Data.SqlClient

Public Class CLASSCALC_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim hesap As New CLASSHESAP
    Dim resultset As New CLADBOPRESULT


    Public Function zeyilsayibul(ByVal FirmCode As String, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date, ByVal ZeylCode As String) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from PolicyInfo where FirmCode=@FirmCode and " + _
        "StartDate>=@baslangictarih and StartDate<=@bitistarih and ZeylCode=@ZeylCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = baslangictarih
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        param3.Value = bitistarih
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = ZeylCode
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function hasarsayibul(ByVal FirmCode As String, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date, ByVal DamageStatusCode As String) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where FirmCode=@FirmCode and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih and DamageStatusCode=@DamageStatusCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = baslangictarih
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        param3.Value = bitistarih
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = DamageStatusCode
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function muallaksayi(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "TariffCode=@TariffCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "DamageStatusCode=@DamageStatusCode and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = TariffCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = CurrencyCode
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = "MU"
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        param6.Value = baslangictarih
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param7.Direction = ParameterDirection.Input
        param7.Value = bitistarih
        komut.Parameters.Add(param7)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function



    Public Function muallaksayisirketsiz(ByVal ProductCode As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where " + _
        "ProductCode=@ProductCode and " + _
        "TariffCode=@TariffCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "DamageStatusCode=@DamageStatusCode and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = ProductCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = TariffCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = CurrencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = "MU"
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        param5.Value = baslangictarih
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        param6.Value = bitistarih
        komut.Parameters.Add(param6)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function muallakmiktar(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select sum(PaidMaterialAmountTL+PaidCorporalAmountTL) from DamageInfo where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "TariffCode=@TariffCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "DamageStatusCode=@DamageStatusCode and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = TariffCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = CurrencyCode
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = "MU"
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        param6.Value = baslangictarih
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param7.Direction = ParameterDirection.Input
        param7.Value = bitistarih
        komut.Parameters.Add(param7)


        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function

    Public Function muallakmiktarsirketsiz(ByVal ProductCode As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select sum(PaidMaterialAmountTL+PaidCorporalAmountTL) from DamageInfo where " + _
        "ProductCode=@ProductCode and " + _
        "TariffCode=@TariffCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "DamageInfo.DamageStatusCode=@DamageStatusCode and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = ProductCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = TariffCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = CurrencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = "MU"
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        param5.Value = baslangictarih
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        param6.Value = bitistarih
        komut.Parameters.Add(param6)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function odenenhasarsayi(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from DamageInfo where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "TariffCode=@TariffCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "(DamageStatusCode='KP' or DamageStatusCode='OD') and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = TariffCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = CurrencyCode
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        param5.Value = baslangictarih
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        param6.Value = bitistarih
        komut.Parameters.Add(param6)


        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function



    Public Function odenenhasarsayisirketsiz(ByVal ProductCode As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where " + _
        "ProductCode=@ProductCode and " + _
        "TariffCode=@TariffCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "(DamageStatusCode='KP' or DamageStatusCode='OD') and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = ProductCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = TariffCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = CurrencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        param4.Value = baslangictarih
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        param5.Value = bitistarih
        komut.Parameters.Add(param5)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function odenenhasarmiktar(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal CurrencyCode As String, ByVal TariffCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(PaidMaterialAmountTL+PaidCorporalAmountTL) from DamageInfo where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "TariffCode=@TariffCode and " + _
        "(DamageStatusCode='KP' or DamageStatusCode='OD') and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = TariffCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = CurrencyCode
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        param5.Value = baslangictarih
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param6.Direction = ParameterDirection.Input
        param6.Value = bitistarih
        komut.Parameters.Add(param6)


        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function



    Public Function odenenhasarmiktarsirketsiz(ByVal ProductCode As String, _
    ByVal CurrencyCode As String, ByVal TariffCode As String, _
    ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(PaidMaterialAmountTL+PaidCorporalAmountTL) from DamageInfo where " + _
        "ProductCode=@ProductCode and " + _
        "CurrencyCode=@CurrencyCode and " + _
        "TariffCode=@TariffCode and " + _
        "(DamageStatusCode='KP' or DamageStatusCode='OD') and " + _
        "AccidentDate>=@baslangictarih and AccidentDate<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = ProductCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = TariffCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = CurrencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        param4.Value = baslangictarih
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        param5.Value = bitistarih
        komut.Parameters.Add(param5)


        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    'GENEL TOPLAM BUL ---------------
    Public Function geneltoplammuallaksayi(ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from DamageInfo where " + _
        "AccidentDate>=@baslangictarih and " + _
        "AccidentDate<=@bitistarih and DamageStatusCode=@DamageStatusCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = baslangictarih
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = bitistarih
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = "MU"
        komut.Parameters.Add(param3)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function geneltoplammuallakmiktar(ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(PaidMaterialAmountTL+PaidCorporalAmountTL) from DamageInfo where " + _
        "AccidentDate>=@baslangictarih and " + _
        "AccidentDate<=@bitistarih and DamageStatusCode=@DamageStatusCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = baslangictarih
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = bitistarih
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@DamageStatusCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = "MU"
        komut.Parameters.Add(param3)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function geneltoplamodenenhasarsayi(ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from DamageInfo where " + _
        "AccidentDate>=@baslangictarih and " + _
        "AccidentDate<=@bitistarih and (DamageStatusCode='KP' or DamageStatusCode='OD')"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = baslangictarih
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = bitistarih
        komut.Parameters.Add(param2)


        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function



    Public Function geneltoplamodenenhasarmiktar(ByVal baslangictarih As Date, ByVal bitistarih As Date) As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(PaidMaterialAmountTL+PaidCorporalAmountTL) from DamageInfo where " + _
        "AccidentDate>=@baslangictarih and " + _
        "AccidentDate<=@bitistarih and (DamageStatusCode='KP' or DamageStatusCode='OD')"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = baslangictarih
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = bitistarih
        komut.Parameters.Add(param2)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = 0
        Else
            donecek = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function




End Class
