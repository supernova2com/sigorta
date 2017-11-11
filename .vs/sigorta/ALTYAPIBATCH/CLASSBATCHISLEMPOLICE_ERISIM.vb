Imports System.Data.SqlClient

Public Class CLASSBATCHISLEMPOLICE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull


    '--- POLİÇE SİL ŞİRKETİN TÜMÜ -------------------------------------------------------
    Function sil_sirketin(ByVal FirmCode As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from PolicyInfo where FirmCode=@FirmCode"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
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


    Function renklerisifirladatabase() As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update PolicyInfo set " + _
        "Color=@Color"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@Color", SqlDbType.VarChar, 10)
        param1.Direction = ParameterDirection.Input
        param1.Value = System.DBNull.Value
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

    Function eskipoliceleri_siyahyap() As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update PolicyInfo set " + _
        "Color=@Color where EndDate<@EndDate"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@Color", SqlDbType.VarChar, 10)
        param1.Direction = ParameterDirection.Input
        param1.Value = System.DBNull.Value
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@EndDate", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = DateTime.Now
        komut.Parameters.Add(param2)

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


    Function renkleriguncelle() As String

        Dim islemlog As String
        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim sifirlaresult As New CLADBOPRESULT
        Dim eskisiyahyapresult As New CLADBOPRESULT
        Dim tekguncelleresult As New CLADBOPRESULT
        Dim guncellenenadet As Integer = 0


        'önce renkleri sıfırla null'a
        sifirlaresult = renklerisifirladatabase()

        'eski poliçeleri siyah yap
        eskisiyahyapresult = eskipoliceleri_siyahyap()

        Dim renk As String
        Dim istring As String
        Dim sqlstr As String
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select FirmCode,ProductCode,AgencyCode," + _
        "PolicyNumber,TecditNumber,ZeylCode, ZeylNo, ProductType" + _
        " from PolicyInfo where Color is null"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    ProductType = veri.Item("ProductType")
                End If

                renk = PolicyInfo_erisim.renkbul(FirmCode, ProductCode, AgencyCode, _
                PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

                tekguncelleresult = guncelledatabase(FirmCode, ProductCode, AgencyCode, _
                PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType, renk)

                If tekguncelleresult.durum = "Kaydedildi" Then
                    guncellenenadet = guncellenenadet + 1
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        islemlog = "Renk Sıfırlama: " + sifirlaresult.durum + " " + sifirlaresult.hatastr + "<br/>" + _
        "Eski Poliçeleri Siyaha Çevir: " + eskisiyahyapresult.durum + eskisiyahyapresult.hatastr + "<br/>" + _
        "Rengi Güncellenen Poliçe Adeti: " + CStr(guncellenenadet)

        Return islemlog

    End Function



    '-----------------------------------Düzenle------------------------------------
    Function guncelledatabase(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal Zeylcode As String, ByVal ZeylNo As String, _
    ByVal ProductType As String, ByVal Color As String) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update PolicyInfo set " + _
        "Color=@Color" + _
        " where " + _
        "FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "AgencyCode=@AgencyCode and " + _
        "PolicyNumber=@PolicyNumber and " + _
        "TecditNumber=@TecditNumber and " + _
        "ZeylCode=@ZeylCode and " + _
        "ZeylNo=@ZeylNo and " + _
        "ProductType=@ProductType and " + _
        "(ZeylCode='P' or ZeylCode='T')"

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


        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar, 15)
        param8.Direction = ParameterDirection.Input
        If ProductType = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = ProductType
        End If
        komut.Parameters.Add(param8)


        Dim param9 As New SqlParameter("@Color", SqlDbType.VarChar, 10)
        param9.Direction = ParameterDirection.Input
        If Color = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = Color
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


    Public Function rengiguncellemeyensayi() As Decimal

        Dim donecek As Decimal
        Dim sqlstr As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*)" + _
        " from PolicyInfo where (ZeylCode=@ZeylCode1 or ZeylCode=@ZeylCode2) and Color is null"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ZeylCode1", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "P"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ZeylCode2", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "T"
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
