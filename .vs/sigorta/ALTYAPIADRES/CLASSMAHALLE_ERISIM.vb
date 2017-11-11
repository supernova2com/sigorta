﻿Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Security

Public Class CLASSMAHALLE_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim mahalle As New CLASSMAHALLE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal mahalle As CLASSMAHALLE) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(mahalle.belediyepkey, mahalle.mahallead)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu belediyenin altında halihazırda bu mahalle vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into mahalle values (@pkey," + _
            "@belediyepkey,@mahallead,@tip,@muhtarivarmi,@postakod)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            eklenenpkey = pkeybul()
            param1.Value = eklenenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@belediyepkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If mahalle.belediyepkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = mahalle.belediyepkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@mahallead", SqlDbType.NVarChar)
            param3.Direction = ParameterDirection.Input
            If mahalle.mahallead = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = mahalle.mahallead
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If mahalle.tip = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = mahalle.tip
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@muhtarivarmi", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If mahalle.muhtarivarmi = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = mahalle.muhtarivarmi
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@postakod", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If mahalle.postakod = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = mahalle.postakod
            End If
            komut.Parameters.Add(param6)


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
                resultset.etkilenen = eklenenpkey
            End If
            db_baglanti.Close()
            db_baglanti.Dispose()

        End If
        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from mahalle"
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
    Function Duzenle(ByVal mahalle As CLASSMAHALLE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(mahalle.belediyepkey, mahalle.mahallead, mahalle.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu belediyenin altında halihazırda bu mahalle vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            komut.Connection = db_baglanti
            sqlstr = "update mahalle set " + _
            "belediyepkey=@belediyepkey," + _
            "mahallead=@mahallead," + _
            "tip=@tip," + _
            "muhtarivarmi=@muhtarivarmi," + _
            "postakod=@postakod" + _
            " where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = mahalle.pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@belediyepkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If mahalle.belediyepkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = mahalle.belediyepkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@mahallead", SqlDbType.NVarChar)
            param3.Direction = ParameterDirection.Input
            If mahalle.mahallead = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = mahalle.mahallead
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If mahalle.tip = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = mahalle.tip
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@muhtarivarmi", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If mahalle.muhtarivarmi = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = mahalle.muhtarivarmi
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@postakod", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If mahalle.postakod = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = mahalle.postakod
            End If
            komut.Parameters.Add(param6)


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

        End If


        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSMAHALLE

        Dim komut As New SqlCommand
        Dim donecekmahalle As New CLASSMAHALLE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from mahalle where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If

                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekmahalle

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim sokak_erisim As New CLASSSOKAK_ERISIM
        Dim varmi_sokak As String = sokak_erisim.mahallevarmi(pkey)

        If varmi_sokak = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu mahallenin altında sokaklar tanımlandığından bu mahalleyi silemezsiniz"
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from mahalle where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSMAHALLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmahalle As New CLASSMAHALLE
        Dim mahalleler As New List(Of CLASSMAHALLE)
        komut.Connection = db_baglanti
        sqlstr = "select * from mahalle order by mahallead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If

                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If


                mahalleler.Add(New CLASSMAHALLE(donecekmahalle.pkey, _
                donecekmahalle.belediyepkey, donecekmahalle.mahallead, donecekmahalle.tip, _
                donecekmahalle.muhtarivarmi, donecekmahalle.postakod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return mahalleler

    End Function


    Public Function doldur_sadeceistedigim(ByVal pkey As Integer) As List(Of CLASSMAHALLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmahalle As New CLASSMAHALLE
        Dim mahalleler As New List(Of CLASSMAHALLE)
        komut.Connection = db_baglanti
        sqlstr = "select * from mahalle where pkey=@pkey order by mahallead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If

                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If


                mahalleler.Add(New CLASSMAHALLE(donecekmahalle.pkey, _
                donecekmahalle.belediyepkey, donecekmahalle.mahallead, donecekmahalle.tip, _
                donecekmahalle.muhtarivarmi, donecekmahalle.postakod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return mahalleler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal belediyepkey As Integer) As List(Of CLASSMAHALLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmahalle As New CLASSMAHALLE
        Dim mahalleler As New List(Of CLASSMAHALLE)
        komut.Connection = db_baglanti
        sqlstr = "select * from mahalle where belediyepkey=@belediyepkey order by mahallead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = belediyepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If

                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If


                mahalleler.Add(New CLASSMAHALLE(donecekmahalle.pkey, _
                donecekmahalle.belediyepkey, donecekmahalle.mahallead, donecekmahalle.tip, _
                donecekmahalle.muhtarivarmi, donecekmahalle.postakod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return mahalleler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili_tipegore(ByVal tip As String) As List(Of CLASSMAHALLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmahalle As New CLASSMAHALLE
        Dim mahalleler As New List(Of CLASSMAHALLE)
        komut.Connection = db_baglanti
        sqlstr = "select * from mahalle where tip=@tip order by mahallead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tip", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tip
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If

                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If

                mahalleler.Add(New CLASSMAHALLE(donecekmahalle.pkey, _
                donecekmahalle.belediyepkey, donecekmahalle.mahallead, donecekmahalle.tip, _
                donecekmahalle.muhtarivarmi, donecekmahalle.postakod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return mahalleler

    End Function


    Public Function doldurmuhtarlik_tumu() As List(Of CLASSMAHALLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmahalle As New CLASSMAHALLE
        Dim mahalleler As New List(Of CLASSMAHALLE)
        komut.Connection = db_baglanti
        sqlstr = "select * from mahalle where muhtarivarmi=@muhtarivarmi order by mahallead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@muhtarivarmi", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Evet"
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If

                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If


                mahalleler.Add(New CLASSMAHALLE(donecekmahalle.pkey, _
                donecekmahalle.belediyepkey, donecekmahalle.mahallead, donecekmahalle.tip, _
                donecekmahalle.muhtarivarmi, donecekmahalle.postakod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return mahalleler

    End Function

    Public Function doldurmuhtarlik_ilgilibelediye(ByVal belediyepkey As Integer) As List(Of CLASSMAHALLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmahalle As New CLASSMAHALLE
        Dim mahalleler As New List(Of CLASSMAHALLE)
        komut.Connection = db_baglanti
        sqlstr = "select * from mahalle where belediyepkey=@belediyepkey and muhtarivarmi=@muhtarivarmi order by mahallead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = belediyepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@muhtarivarmi", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Evet"
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmahalle.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                    donecekmahalle.belediyepkey = veri.Item("belediyepkey")
                End If

                If Not veri.Item("mahallead") Is System.DBNull.Value Then
                    donecekmahalle.mahallead = veri.Item("mahallead")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmahalle.tip = veri.Item("tip")
                End If

                If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                    donecekmahalle.muhtarivarmi = veri.Item("muhtarivarmi")
                End If


                If Not veri.Item("postakod") Is System.DBNull.Value Then
                    donecekmahalle.postakod = veri.Item("postakod")
                End If

                mahalleler.Add(New CLASSMAHALLE(donecekmahalle.pkey, _
                donecekmahalle.belediyepkey, donecekmahalle.mahallead, donecekmahalle.tip, _
                donecekmahalle.muhtarivarmi, donecekmahalle.postakod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return mahalleler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>İlçe</th>" + _
        "<th>Bucak</th>" + _
        "<th>Belediye</th>" + _
        "<th>Mahalle Adı</th>" + _
        "<th>Tipi</th>" + _
        "<th>Muhtarlığı Var mı?</th>" + _
        "<th>Posta Kodu</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from mahalle order by mahallead"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "ilgilibelediyenin" Then
            sqlstr = "select * from mahalle where belediyepkey=@belediyepkey order by mahallead"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("belediyepkey")
            komut.Parameters.Add(param1)

        End If


        If HttpContext.Current.Session("ltip") = "ilgilibelediyenin_tip" Then
            sqlstr = "select * from mahalle where belediyepkey=@belediyepkey and tip=@tip order by mahallead"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("belediyepkey")
            komut.Parameters.Add(param1)


            Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("tip")
            komut.Parameters.Add(param2)

        End If



        girdi = "0"
        Dim link As String
        Dim pkey, belediyepkey, mahallead, tip, muhtarivarmi As String
        Dim postakod As String

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM
        Dim bucak As New CLASSBUCAK
        Dim bucak_Erisim As New CLASSBUCAK_ERISIM
        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "mahalle.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("belediyepkey") Is System.DBNull.Value Then
                        belediyepkey = veri.Item("belediyepkey")
                    Else
                        belediyepkey = 0
                    End If

                    belediye = belediye_erisim.bultek(belediyepkey)
                    bucak = bucak_Erisim.bultek(belediye.bucakpkey)
                    ilce = ilce_erisim.bultek(bucak.ilcepkey)


                    kol2 = "<td>" + ilce.ilcead + "</td>"
                    kol3 = "<td>" + bucak.bucakad + "</td>"
                    kol4 = "<td>" + belediye.belediyead + "</td>"


                    If Not veri.Item("mahallead") Is System.DBNull.Value Then
                        mahallead = veri.Item("mahallead")
                        kol5 = "<td>" + mahallead + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol6 = "<td>" + tip + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("muhtarivarmi") Is System.DBNull.Value Then
                        muhtarivarmi = veri.Item("muhtarivarmi")
                        kol7 = "<td>" + muhtarivarmi + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("postakod") Is System.DBNull.Value Then
                        postakod = veri.Item("postakod")
                        kol8 = "<td>" + postakod + "</td></tr>"
                    Else
                        kol8 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal belediyepkey As Integer, ByVal mahallead As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from mahalle where belediyepkey=@belediyepkey and mahallead=@mahallead"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = belediyepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@mahallead", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = mahallead
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol_duzenle(ByVal belediyepkey As Integer, ByVal mahallead As String, _
    ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from mahalle where belediyepkey=@belediyepkey and mahallead=@mahallead" + _
        " and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = belediyepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@mahallead", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = mahallead
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@pkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = pkey
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function



    Public Function toplammahallesayisi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from mahalle"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            toplam = 0
        Else
            toplam = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return toplam

    End Function

    Function belediyevarmi(ByVal belediyepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from mahalle where belediyepkey=@belediyepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@belediyepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = belediyepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function dataxmlolustur(ByVal mahalle As CLASSMAHALLE)

        Dim pInfo As System.Reflection.PropertyInfo
        Dim deger
        Dim donecek, enbas, ic, enson As String
        enbas = "<root>"
        enson = "</root>"

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim tablokolonlari As New CLASSVERITABANI
        Dim vb_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
        Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)

        kolonlar = vb_erisim.bultumkolonlar(site.sistemveritabaniad, "mahalle")

        For Each Item As CLASSVERITABANIKOLONDETAY In kolonlar

            pInfo = mahalle.GetType().GetProperty(Item.column_name)
            deger = pInfo.GetValue(mahalle, Nothing)

            ic = ic + "<" + Item.column_name + ">" + SecurityElement.Escape(CStr(deger)) +
            "</" + Item.column_name + ">"

        Next

        donecek = enbas + ic + enson
        Return donecek

    End Function



    Public Function mahallebelediyeninmi(ByVal site As CLASSSITE, ByVal belediyepkey As String, ByVal mahallepkey As String) As String

        Dim kackayit As Integer
        Dim donecek As String = "Hayır"
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "belediyepkey", "=", belediyepkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "=", mahallepkey, ""))

        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "mahalle", "count(*)", fieldopvalues)
        If kackayit > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function

End Class


