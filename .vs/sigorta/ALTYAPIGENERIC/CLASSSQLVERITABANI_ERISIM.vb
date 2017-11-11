Imports MySql.Data.MySqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.Collections.Generic
Imports System.Web.HttpContext.Current
Imports System.Data.SqlClient


Public Class CLASSSQLVERITABANI_ERISIM

    Public Function doldurveritabaniadları() As List(Of CLASSVERITABANI)

        Dim sqlstr As String
        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim donecekVERITABANI As New CLASSVERITABANI
        Dim VERITABANIler As New List(Of CLASSVERITABANI)

        sqlstr = "Select name FROM master..sysdatabases"
        komut = New SqlCommand(sqlstr, db_baglanti)
        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("name") Is System.DBNull.Value Then
                donecekVERITABANI.ilgiliad = veri.Item("name")
            End If

            VERITABANIler.Add(New CLASSVERITABANI(donecekVERITABANI.ilgiliad))
        End While

        db_baglanti.Close()

        Return VERITABANIler

    End Function



    Public Function doldurtabloadlari(ByVal veritabaniad As String) As List(Of CLASSVERITABANI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim donecekVERITABANI As New CLASSVERITABANI
        Dim VERITABANIler As New List(Of CLASSVERITABANI)

        sqlstr = "select * from " + veritabaniad + ".sys.tables order by name"
        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("name") Is System.DBNull.Value Then
                donecekVERITABANI.ilgiliad = veri.Item("name")
            End If


            VERITABANIler.Add(New CLASSVERITABANI(donecekVERITABANI.ilgiliad))
        End While


        db_baglanti.Close()

        Return VERITABANIler


    End Function



    Public Function bulkolonadlari(ByVal veritabaniad As String, ByVal tabload As String) As List(Of CLASSVERITABANI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim donecekVERITABANI As New CLASSVERITABANI
        Dim VERITABANIler As New List(Of CLASSVERITABANI)


        sqlstr = "SELECT COLUMN_NAME,*  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + tabload + _
        "' AND TABLE_CATALOG='" + veritabaniad + "'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("COLUMN_NAME") Is System.DBNull.Value Then
                donecekVERITABANI.ilgiliad = veri.Item("COLUMN_NAME")
            End If

            VERITABANIler.Add(New CLASSVERITABANI(donecekVERITABANI.ilgiliad))
        End While

        db_baglanti.Close()

        Return VERITABANIler

    End Function


    Public Function bultoplamkolonsayisi(ByVal veritabaniad As String, ByVal tabload As String) As Integer

        Dim toplamkolonsayisi As Integer

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim donecekVERITABANI As New CLASSVERITABANI
        Dim VERITABANIler As New List(Of CLASSVERITABANI)

        sqlstr = "SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS " + _
        "WHERE TABLE_NAME='" + tabload + "' and " + _
        "TABLE_SCHEMA='" + veritabaniad + "' ORDER BY ordinal_position"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            toplamkolonsayisi = 0
        Else
            toplamkolonsayisi = maxkayit1
        End If

        db_baglanti.Close()

        Return toplamkolonsayisi

    End Function


    Public Function primarykeyadbul(ByVal veritabaniad As String, _
    ByVal tabload As String) As String

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sqlserververitabani")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim donecek As String

        sqlstr = "SELECT K.TABLE_NAME, C.CONSTRAINT_TYPE, K.COLUMN_NAME, K.CONSTRAINT_NAME " + _
        "FROM " + veritabaniad + "." + "INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C " + _
        "JOIN " + veritabaniad + "." + "INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K " + _
        "ON C.TABLE_NAME = K.TABLE_NAME " + _
        "AND C.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG " + _
        "AND C.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA " + _
        "AND C.CONSTRAINT_NAME = K.CONSTRAINT_NAME " + _
        "WHERE C.CONSTRAINT_TYPE = 'PRIMARY KEY' " + _
        "AND K.TABLE_NAME='" + tabload + "'"


        komut = New SqlCommand(sqlstr, db_baglanti)

        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("COLUMN_NAME") Is System.DBNull.Value Then
                donecek = veri.Item("COLUMN_NAME")
            End If

        End While

        db_baglanti.Close()

        Return donecek

    End Function

End Class
