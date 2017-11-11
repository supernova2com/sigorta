Imports MySql.Data.MySqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Data.OleDb
Imports System.Text.RegularExpressions



Public Class CLASSGENERIC_ERISIM

    Dim etkilenen As Integer
    Dim istring As String
    Dim resultset As New CLADBOPRESULT
    Dim veritabaniad, tabload, whereclause As String
    Dim tumkolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
    Dim deger
    Dim edlikolonadi As String
    Dim sqldevam As String


    Public Function baglan(ByVal istring As String) As OleDb.OleDbConnection

        Dim db_baglanti As OleDbConnection
        db_baglanti = New OleDbConnection(istring)
        db_baglanti.Open()
        Return db_baglanti

    End Function


    Public Function pkeybul(ByVal digerparametreler As CLASSDIGERPARAMETRELER) As Integer

        Dim pkey As Integer
        Dim istring, sqlstr As String
        veritabaniad = digerparametreler.parametreler(0)
        tabload = digerparametreler.parametreler(1)

        'BAĞLAN ---------------------------------------------------------------------
        istring = istringolustur(veritabaniad)
        Dim db_baglanti As OleDbConnection
        db_baglanti = baglan(istring)
        Dim komut As New OleDbCommand
        sqlstr = "select max(pkey) from " + tabload
        komut = New OleDbCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            pkey = 1
        Else
            pkey = maxkayit1 + 1
        End If

        db_baglanti.Close()

        Return pkey

    End Function


    Public Function sqldbtypebul(ByVal data_type As String) As CLASSSQLDATATYPE

        Dim sqldatatype As New CLASSSQLDATATYPE


        If data_type = "bit" Then
            sqldatatype.sqltype = SqlDbType.Bit
            sqldatatype.ilgiliad = "SqlDbType.Bit"
            sqldatatype.donenvisualbasictype = "boolean"
        End If

        If data_type = "numeric" Then
            sqldatatype.sqltype = SqlDbType.Int
            sqldatatype.ilgiliad = "SqlDbType.Int"
            sqldatatype.donenvisualbasictype = "integer"
        End If

        If data_type = "int" Then
            sqldatatype.sqltype = SqlDbType.Int
            sqldatatype.ilgiliad = "SqlDbType.Int"
            sqldatatype.donenvisualbasictype = "int"
        End If

        If data_type = "float" Then
            sqldatatype.sqltype = SqlDbType.Float
            sqldatatype.ilgiliad = "SqlDbType.Float"
            sqldatatype.donenvisualbasictype = "Double"
        End If

        If data_type = "double" Then
            sqldatatype.sqltype = SqlDbType.Decimal
            sqldatatype.ilgiliad = "SqlDbType.Decimal"
            sqldatatype.donenvisualbasictype = "Double"
        End If

        If data_type = "decimal" Then
            sqldatatype.sqltype = SqlDbType.Decimal
            sqldatatype.ilgiliad = "SqlDbType.Decimal"
            sqldatatype.donenvisualbasictype = "Decimal"
        End If

        If data_type = "real" Then
            sqldatatype.sqltype = SqlDbType.Char
            sqldatatype.ilgiliad = "SqlDbType.Real"
            sqldatatype.donenvisualbasictype = "Double"
        End If

        If data_type = "varchar" Then
            sqldatatype.sqltype = SqlDbType.VarChar
            sqldatatype.ilgiliad = "SqlDbType.VarChar"
            sqldatatype.donenvisualbasictype = "string"
        End If

        If data_type = "nvarchar" Then
            sqldatatype.sqltype = SqlDbType.VarChar
            sqldatatype.ilgiliad = "SqlDbType.NVarChar"
            sqldatatype.donenvisualbasictype = "string"
        End If

        If data_type = "text" Then
            sqldatatype.sqltype = SqlDbType.Text
            sqldatatype.ilgiliad = "SqlDbType.Text"
            sqldatatype.donenvisualbasictype = "string"
        End If

        If data_type = "ntext" Then
            sqldatatype.sqltype = SqlDbType.Text
            sqldatatype.ilgiliad = "SqlDbType.NText"
            sqldatatype.donenvisualbasictype = "string"
        End If

        If data_type = "char" Then
            sqldatatype.sqltype = SqlDbType.Char
            sqldatatype.ilgiliad = "SqlDbType.Char"
            sqldatatype.donenvisualbasictype = "String"
        End If

        If data_type = "datetime" Then
            sqldatatype.sqltype = SqlDbType.DateTime
            sqldatatype.ilgiliad = "SqlDbType.DateTime"
            sqldatatype.donenvisualbasictype = "DateTime"
        End If

        If data_type = "date" Then
            sqldatatype.sqltype = SqlDbType.Date
            sqldatatype.ilgiliad = "SqlDbType.Date"
            sqldatatype.donenvisualbasictype = "Date"
        End If
   
        If data_type = "image" Then
            sqldatatype.sqltype = SqlDbType.Image
            sqldatatype.ilgiliad = "SqlDbType.Image"
            sqldatatype.donenvisualbasictype = "Byte()"
        End If

        Return sqldatatype

    End Function


    Function istringolustur(ByVal veritabaniad As String) As String

        Dim istring As String
        'istring = System.Web.HttpContext.Current.Application("oledb")
        Return istring

    End Function






End Class

