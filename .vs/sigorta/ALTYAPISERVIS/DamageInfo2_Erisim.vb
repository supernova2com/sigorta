Imports System.Data.SqlClient
Imports System.Data

Public Class DamageInfo2_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim x As System.DBNull
    Dim resultset As New CLADBOPRESULT



    '--- HASARLARI SİL ŞİRKETİN TÜMÜ -------------------------------------------------------
    Function sil_sirketin(ByVal FirmCode As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from DamageInfo where FirmCode=@FirmCode"

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


    '-----------------------------------Düzenle------------------------------------
    Function duzenleozel(ByVal DamageInfo As DamageInfo) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update DamageInfo set " + _
        "PolicyType=@PolicyType " + _
        " where FirmCode=@FirmCode and " + _
        "ProductCode=@ProductCode and " + _
        "AgencyCode=@AgencyCode and " + _
        "PolicyNumber=@PolicyNumber and " + _
        "TecditNumber=@TecditNumber and " + _
        "FileNo=@FileNo and " + _
        "RequestNo=@RequestNo and " + _
        "ProductType=@ProductType"

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

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If DamageInfo.ProductType = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = DamageInfo.ProductType
        End If
        komut.Parameters.Add(param8)


        Dim param9 As New SqlParameter("@PolicyType", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If DamageInfo.PolicyType = 0 Then
            param9.Value = 0
        Else
            param9.Value = DamageInfo.PolicyType
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

    Public Function guncelle()

        Dim damageinfo_erisim As New DamageInfo_Erisim
        Dim policyinfo_erisim As New PolicyInfo_Erisim
        Dim hasarinpoliceleri As New List(Of PolicyInfo)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType " + _
        "from DamageInfo"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType As String

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

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

                hasarinpoliceleri = policyinfo_erisim.policedoldur_ilgilihasar(FirmCode, _
                ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

                If hasarinpoliceleri.Count > 0 Then
                    Dim damageinfo As New DamageInfo
                    damageinfo = damageinfo_erisim.bultek(FirmCode, ProductCode, FileNo, RequestNo, ProductType)
                    For Each policeitem As PolicyInfo In hasarinpoliceleri
                        damageinfo.PolicyType = policeitem.PolicyType
                        Exit For
                    Next
                    Duzenleozel(damageinfo)
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return varmi

    End Function



End Class
