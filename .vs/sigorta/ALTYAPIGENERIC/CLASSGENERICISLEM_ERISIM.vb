Imports System.Data.SqlClient

Public Class CLASSGENERICISLEM_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim propInfo As System.Reflection.PropertyInfo
    Dim generic_erisim As New CLASSGENERIC_ERISIM

    Dim veritabanikolondetay As New CLASSVERITABANIKOLONDETAY
    Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
    Dim site As New CLASSSITE
    Dim site_erisim As New CLASSSITE_ERISIM


    Public Function countgeneric(ByVal veritabaniad As String, ByVal tabload As String, _
    ByVal funcad As String, _
    ByVal fieldopvalues As List(Of CLASSFIELDOPERATORVALUE)) As Decimal

        Dim kacadet As Decimal
        Dim sqlstr As String
        Dim edlikolonadi As String
        Dim deger
        Dim i As Integer = 1

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        'SQL İ OLUSTURALIM--------------------------------
        Dim sqldevam As String = ""
        For Each item As CLASSFIELDOPERATORVALUE In fieldopvalues
            sqldevam = sqldevam + item.basx + item.field + item.opx + "@" + item.field + CStr(i) + item.sonx
            i = i + 1
        Next

        If Len(sqldevam) > 0 Then
            sqldevam = " where " + sqldevam
        End If
        '----------------------------------------------

        'KOMUT PARAMETRELERİNİ GÖM!
        Dim g1, g2, g3, g4 As Integer

        i = 1
        sqlstr = "select " + funcad + " from " + tabload + sqldevam
        komut = New SqlCommand(sqlstr, db_baglanti)
        komut.CommandTimeout = 600

        For Each item As CLASSFIELDOPERATORVALUE In fieldopvalues

            deger = item.value

            g1 = 0
            g2 = 0
            g3 = 0
            g4 = 0

            edlikolonadi = "@" + item.field + CStr(i)
            veritabanikolondetay = sqlveritabanikolondetay_erisim.bulkolondetay(veritabaniad, tabload, item.field)

            If veritabanikolondetay.data_type = "date" Or veritabanikolondetay.data_type = "datetime" Then
                deger = DateTime.Parse(deger)
                g1 = 1
            End If

            If veritabanikolondetay.data_type = "int" Or veritabanikolondetay.data_type = "numeric" Then
                deger = Integer.Parse(deger)
                g2 = 1
            End If

            If veritabanikolondetay.data_type = "float" Or veritabanikolondetay.data_type = "decimal" Or veritabanikolondetay.data_type = "real" Then
                deger = Decimal.Parse(deger)
                g3 = 1
            End If

            If veritabanikolondetay.data_type = "double" Then
                deger = Double.Parse(deger)
                g4 = 1
            End If

            If g1 = 0 And g2 = 0 And g3 = 0 And g4 = 0 Then
                deger = deger
            End If

            komut.Parameters.Add(edlikolonadi, generic_erisim.sqldbtypebul(veritabanikolondetay.data_type).sqltype, veritabanikolondetay.maxlen)
            komut.Parameters(edlikolonadi).Value = deger

            i = i + 1
        Next
        '----------------------------------------------

        'ÇALIŞTIR -------------------------------------
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kacadet = 0
        Else
            kacadet = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        '----------------------------------------------

        Return kacadet

    End Function


    Public Function countgenericbirdenfazlatablo(ByVal veritabaniad As String, _
    ByVal tablolar As List(Of CLASSTEK), _
    ByVal funcad As String, _
    ByVal fieldopvalues2 As List(Of CLASSFIELDOPERATORVALUE2)) As Decimal

        Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
        Dim kacadet As Decimal
        Dim sqlstr As String
        Dim sqlforeign As String = ""
        Dim edlikolonadi As String
        Dim deger
        Dim i As Integer = 1

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        'TABLO OLUŞTUR-----------------------------------
        Dim sqltablodevam As String = ""
        For Each item As CLASSTEK In tablolar
            sqltablodevam = sqltablodevam + item.ad + ","
        Next

        If Mid(sqltablodevam, Len(sqltablodevam), "1") = "," Then
            sqltablodevam = Mid(sqltablodevam, "1", Len(sqltablodevam) - 1)
        End If

        'SQL İ OLUSTURALIM--------------------------------
        Dim sqldevam As String = ""
        For Each item As CLASSFIELDOPERATORVALUE2 In fieldopvalues2
            sqldevam = sqldevam + item.basx + item.bakilacaktablo + "." + item.field + item.opx + "@" + item.field + CStr(i) + item.sonx
            i = i + 1
        Next

        If Len(sqldevam) > 0 Then
            sqldevam = " where " + sqldevam
        End If

        'FOREIGN KEY BAĞLARINI OLUŞTUR 
        sqlforeign = tablobag_erisim.foreignkeybagsqlolustur(tablolar)
        If Len(sqlforeign) > 1 Then
            sqldevam = sqldevam + " and " + "(" + sqlforeign + ")"
        End If
        '----------------------------------------------

        'KOMUT PARAMETRELERİNİ GÖM!
        Dim g1, g2, g3, g4 As Integer

        i = 1
        sqlstr = "select " + funcad + " from " + sqltablodevam + sqldevam
        komut = New SqlCommand(sqlstr, db_baglanti)
        komut.CommandTimeout = 600

        For Each item As CLASSFIELDOPERATORVALUE2 In fieldopvalues2

            deger = item.value

            g1 = 0
            g2 = 0
            g3 = 0
            g4 = 0

            edlikolonadi = "@" + item.field + CStr(i)
            veritabanikolondetay = sqlveritabanikolondetay_erisim.bulkolondetay(veritabaniad, item.bakilacaktablo, item.field)

            If veritabanikolondetay.data_type = "date" Or veritabanikolondetay.data_type = "datetime" Then
                deger = DateTime.Parse(deger)
                g1 = 1
            End If

            If veritabanikolondetay.data_type = "int" Or veritabanikolondetay.data_type = "numeric" Then
                deger = Integer.Parse(deger)
                g2 = 1
            End If

            If veritabanikolondetay.data_type = "float" Or veritabanikolondetay.data_type = "decimal" Or veritabanikolondetay.data_type = "real" Then
                deger = Decimal.Parse(deger)
                g3 = 1
            End If

            If veritabanikolondetay.data_type = "double" Then
                deger = Double.Parse(deger)
                g4 = 1
            End If

            If g1 = 0 And g2 = 0 And g3 = 0 And g4 = 0 Then
                deger = deger
            End If

            komut.Parameters.Add(edlikolonadi, generic_erisim.sqldbtypebul(veritabanikolondetay.data_type).sqltype, veritabanikolondetay.maxlen)
            komut.Parameters(edlikolonadi).Value = deger

            i = i + 1
        Next
        '----------------------------------------------

        'ÇALIŞTIR -------------------------------------
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kacadet = 0
        Else
            kacadet = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        '----------------------------------------------

        Return kacadet

    End Function



End Class
