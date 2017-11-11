Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.Collections.Generic
Imports System.Web.HttpContext.Current
Imports System.Data.SqlClient


Public Class CLASSSQLVERITABANIKOLONDETAY_ERISIM



    Public Function bulkolondetay(ByVal veritabaniad As String, ByVal tabload As String, _
    ByVal columnname As String) As CLASSVERITABANIKOLONDETAY

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader

        Dim donecekkolondetay As New CLASSVERITABANIKOLONDETAY


        sqlstr = "SELECT COLUMN_NAME,*  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tabload + _
        "' AND TABLE_CATALOG='" + veritabaniad + "' and COLUMN_NAME='" + columnname + "'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("COLUMN_NAME") Is System.DBNull.Value Then
                donecekkolondetay.column_name = veri.Item("COLUMN_NAME")
            End If

            If Not veri.Item("DATA_TYPE") Is System.DBNull.Value Then
                donecekkolondetay.data_type = veri.Item("DATA_TYPE")
            End If

            If Not veri.Item("CHARACTER_MAXIMUM_LENGTH") Is System.DBNull.Value Then
                donecekkolondetay.maxlen = veri.Item("CHARACTER_MAXIMUM_LENGTH")
            End If


        End While

        db_baglanti.Close()

        Return donecekkolondetay

    End Function

    Public Function bultumkolonlar(ByVal veritabaniad As String, ByVal tabload As String) As List(Of CLASSVERITABANIKOLONDETAY)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader

        Dim donecekkolondetay As New CLASSVERITABANIKOLONDETAY
        Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)

        sqlstr = "SELECT COLUMN_NAME,*  FROM " + veritabaniad + "." + _
        "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tabload + _
        "' AND TABLE_CATALOG='" + veritabaniad + "' order by ORDINAL_POSITION"

        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("COLUMN_NAME") Is System.DBNull.Value Then
                donecekkolondetay.column_name = veri.Item("COLUMN_NAME")
            End If

            If Not veri.Item("DATA_TYPE") Is System.DBNull.Value Then
                donecekkolondetay.data_type = veri.Item("DATA_TYPE")
            End If

            If Not veri.Item("CHARACTER_MAXIMUM_LENGTH") Is System.DBNull.Value Then
                donecekkolondetay.maxlen = veri.Item("CHARACTER_MAXIMUM_LENGTH")
            End If

            kolonlar.Add(New CLASSVERITABANIKOLONDETAY(donecekkolondetay.column_name, donecekkolondetay.data_type, _
            donecekkolondetay.maxlen))

        End While

        db_baglanti.Close()

        Return kolonlar

    End Function


    Public Function bulprimarykolonlar(ByVal veritabaniad As String, ByVal tabload As String) As List(Of CLASSVERITABANIKOLONDETAY)

        Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
        Dim primary_kolonname As String
        primary_kolonname = sqlveritabani_erisim.primarykeyadbul(veritabaniad, tabload)

        Dim donecekkolondetay As New CLASSVERITABANIKOLONDETAY
        Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)

        Dim sqlstr As String
        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader


        sqlstr = "SELECT COLUMN_NAME,*  FROM " + veritabaniad + "." + "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tabload + _
        "' AND TABLE_CATALOG='" + veritabaniad + "'" + " and COLUMN_NAME='" + primary_kolonname + "'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("COLUMN_NAME") Is System.DBNull.Value Then
                donecekkolondetay.column_name = veri.Item("COLUMN_NAME")
            End If

            If Not veri.Item("DATA_TYPE") Is System.DBNull.Value Then
                donecekkolondetay.data_type = veri.Item("DATA_TYPE")
            End If

            If Not veri.Item("CHARACTER_MAXIMUM_LENGTH") Is System.DBNull.Value Then
                donecekkolondetay.maxlen = veri.Item("CHARACTER_MAXIMUM_LENGTH")
            End If

            kolonlar.Add(New CLASSVERITABANIKOLONDETAY(donecekkolondetay.column_name, donecekkolondetay.data_type, _
            donecekkolondetay.maxlen))


        End While

        db_baglanti.Close()

        Return kolonlar

    End Function


End Class
