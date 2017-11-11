Imports System.Data.SqlClient
Imports System.Data

Public Class CLASSGECICI_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull

    'PLAKADA BOŞLUK OLANLARI BUL
    Function plakadaboslukpolice() As String

        'primary key tanımlar ----
        Dim ProductCode, FirmCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo As String
        Dim PlateNumber As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where " + _
        " PlateNumber like '% %'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader
        While veri.Read()

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

            If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                PlateNumber = CStr(veri.Item("PlateNumber"))
            Else
                PlateNumber = ""
            End If

            plakayiguncellebosluksuz(FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, _
            ZeylCode, ZeylNo, PlateNumber)



        End While

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function



    Function plakayiguncellebosluksuz(ByVal FirmCode As String, _
    ByVal ProductCode As String, _
    ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, _
    ByVal Zeylcode As String, _
    ByVal ZeylNo As String, _
    ByVal PlateNumber As String) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update PolicyInfo set " + _
        "PlateNumber=@PlateNumber where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "AgencyCode=@AgencyCode and " + _
        "PolicyNumber=@PolicyNumber and " + _
        "TecditNumber=@TecditNumber and " + _
        "ZeylCode=@ZeylCode and " + _
        "ZeylNo=@ZeylNo "

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param1.Direction = ParameterDirection.Input
        If FirmCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = FirmCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param2.Direction = ParameterDirection.Input
        If ProductCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ProductCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param3.Direction = ParameterDirection.Input
        If AgencyCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = AgencyCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param4.Direction = ParameterDirection.Input
        If PolicyNumber = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = PolicyNumber
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
        param5.Direction = ParameterDirection.Input
        If TecditNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = TecditNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar, 1)
        param6.Direction = ParameterDirection.Input
        If Zeylcode = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = Zeylcode
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar, 15)
        param7.Direction = ParameterDirection.Input
        If ZeylNo = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = ZeylNo
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@PlateNumber", SqlDbType.VarChar, 15)
        param8.Direction = ParameterDirection.Input
        If PlateNumber = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = Replace(PlateNumber, " ", "")
        End If
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



    Function plakadaboslukhasar() As String

        'primary key tanımlar ----
        Dim ProductCode, FirmCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo As String
        Dim DriverPlateNumber, ClaimantPlateNumber As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageInfo where " + _
        " DriverPlateNumber like '% %' or ClaimantPlateNumber like '% %'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader
        While veri.Read()

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
            If Not veri.Item("FileNo") Is System.DBNull.Value Then
                FileNo = CStr(veri.Item("FileNo"))
            Else
                FileNo = ""
            End If
            If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                RequestNo = CStr(veri.Item("RequestNo"))
            Else
                RequestNo = ""
            End If

            If Not veri.Item("DriverPlateNumber") Is System.DBNull.Value Then
                DriverPlateNumber = CStr(veri.Item("DriverPlateNumber"))
            Else
                DriverPlateNumber = ""
            End If

            If Not veri.Item("ClaimantPlateNumber") Is System.DBNull.Value Then
                ClaimantPlateNumber = CStr(veri.Item("ClaimantPlateNumber"))
            Else
                ClaimantPlateNumber = ""
            End If

            plakayiguncellebosluksuzhasar(FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, _
            FileNo, RequestNo, DriverPlateNumber, ClaimantPlateNumber)


        End While

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function plakayiguncellebosluksuzhasar(ByVal FirmCode As String, _
    ByVal ProductCode As String, _
    ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, _
    ByVal FileNo As String, _
    ByVal RequestNo As String, _
    ByVal DriverPlateNumber As String, _
    ByVal ClaimantPlateNumber As String) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update DamageInfo set " + _
        "DriverPlateNumber=@DriverPlateNumber, " + _
        "ClaimantPlateNumber=@ClaimantPlateNumber " + _
        "where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "AgencyCode=@AgencyCode and " + _
        "PolicyNumber=@PolicyNumber and " + _
        "TecditNumber=@TecditNumber and " + _
        "FileNo=@FileNo and " + _
        "RequestNo=@RequestNo "

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param1.Direction = ParameterDirection.Input
        If FirmCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = FirmCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param2.Direction = ParameterDirection.Input
        If ProductCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ProductCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param3.Direction = ParameterDirection.Input
        If AgencyCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = AgencyCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param4.Direction = ParameterDirection.Input
        If PolicyNumber = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = PolicyNumber
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar, 2)
        param5.Direction = ParameterDirection.Input
        If TecditNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = TecditNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar, 15)
        param6.Direction = ParameterDirection.Input
        If FileNo = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = FileNo
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar, 2)
        param7.Direction = ParameterDirection.Input
        If RequestNo = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = RequestNo
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@DriverPlateNumber", SqlDbType.VarChar, 50)
        param8.Direction = ParameterDirection.Input
        If DriverPlateNumber = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = Replace(DriverPlateNumber, " ", "")
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@ClaimantPlateNumber", SqlDbType.VarChar, 50)
        param9.Direction = ParameterDirection.Input
        If ClaimantPlateNumber = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = Replace(ClaimantPlateNumber, " ", "")
        End If
        komut.Parameters.Add(param9)


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


End Class
