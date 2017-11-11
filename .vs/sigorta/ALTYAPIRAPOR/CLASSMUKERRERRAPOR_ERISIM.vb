Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports HttpContext.Current
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSMUKERRERRAPOR_ERISIM

    Function mukerrerplakabul(ByVal firmcode As String) As String

        Dim plaka_erisim As New CLASSPLAKA_ERISIM

        Dim donecekplakastr As String

        'TÜM PLAKALARI SİL 
        plaka_erisim.siltumu()

        'DROP TEMPORARY TABLE 
        droptemptable()

        'FİLL THE TABLE 
        filltemptable(firmcode)

        'MUKERRER BUL
        donecekplakastr = t1duplicate(firmcode)

        Return donecekplakastr

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function droptemptable()

        Dim istring As String
        Dim sqlstr As String
        Dim etkilenen As Integer
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "drop table t1"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Try
            komut.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

    End Function


    Public Function filltemptable(ByVal firmcode As String)

        Dim sqldevam As String

        Dim istring As String
        Dim sqlstr As String
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = " select FirmCode,ProductCode,AgencyCode," + _
        " PolicyNumber, TecditNumber, ZeylCode, ZeylNo, PlateNumber " + _
        " into t1 from PolicyInfo " + _
        " where EndDate>=@EndDate and (ZeylCode='P' or ZeylCode='T') " + _
        " group by FirmCode,ProductCode,AgencyCode,PolicyNumber,TecditNumber,ZeylCode,ZeylNo,PlateNumber"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@EndDate", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = DateTime.Now
        komut.Parameters.Add(param1)

        Try
            komut.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

    End Function


    Function t1duplicate(ByVal p_FirmCode As String) As String

        Dim policyinfo_erisim As New PolicyInfo_Erisim
        Dim plaka_erisim As New CLASSPLAKA_ERISIM

        Dim istring As String
        Dim sqlstr As String
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand
        Dim str As String = ""

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from t1"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim PlateNumber As String
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String

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

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    FirmCode = veri.Item("FirmCode")
                End If


                If p_FirmCode = "Tümü" Then
                    'eğer bu plakanın mevcut firmada aktif poliçesi var ise
                    If policyinfo_erisim.renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
                    TecditNumber, ZeylCode, ZeylNo, ProductType) = "green" Then
                        've başka bir firmadada aktif poliçe var ise
                        If baskafirmcodevarmi(PlateNumber, FirmCode) = "green" Then
                            str = str + PlateNumber + " , "
                            Dim plaka As New CLASSPLAKA
                            plaka.PlateNumber = PlateNumber
                            plaka.sirketkod = FirmCode
                            plaka_erisim.Ekle(plaka)
                        End If
                    End If
                End If

                If p_FirmCode <> "Tümü" Then
                    'eğer bu plakanın mevcut firmada aktif poliçesi var ise
                    If policyinfo_erisim.renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
                    TecditNumber, ZeylCode, ZeylNo, ProductType) = "green" Then
                        've başka bir firmadada aktif poliçe var ise
                        If baskafirmcodevarmi(PlateNumber, p_FirmCode) = "green" Then
                            str = str + PlateNumber + " , "
                            Dim plaka As New CLASSPLAKA
                            plaka.PlateNumber = PlateNumber
                            plaka.sirketkod = FirmCode
                            plaka_erisim.Ekle(plaka)
                        End If
                    End If
                End If



            End While
        End Using


        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return str


    End Function


    Function baskafirmcodevarmi(ByVal p_PlateNumber As String, ByVal p_FirmCode As String) As String

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim

        Dim renk As String
        Dim istring As String
        Dim sqlstr As String
        Dim etkilenen As Integer
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select FirmCode,ProductCode,AgencyCode,PolicyNumber,TecditNumber,ZeylCode, ZeylNo, ProductType" + _
        " from t1 where PlateNumber=@PlateNumber and FirmCode<>@FirmCode"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = p_PlateNumber
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = p_FirmCode
        komut.Parameters.Add(param2)

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

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    ProductType = veri.Item("ProductType")
                End If

                renk = PolicyInfo_erisim.renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, _
                ZeylCode, ZeylNo, ProductType)

                Exit While

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return renk

    End Function


End Class
