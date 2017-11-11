Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSDINAMIKRAPORGRAFIK_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dinamikraporgrafik As New CLASSDINAMIKRAPORGRAFIK
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dinamikraporgrafik As CLASSDINAMIKRAPORGRAFIK) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("grafikbaslik", dinamikraporgrafik.grafikbaslik)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into dinamikraporgrafik values (@pkey," + _
            "@raporpkey,@grafikbaslik,@grafiktip,@genislik," + _
            "@yukseklik,@kolonseriad,@kolonsayi,@labelgosterilsinmi," + _
            "@labelarkaplanrengi,@labelseffaflik,@legendgosterilsinmi)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If dinamikraporgrafik.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = dinamikraporgrafik.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@grafikbaslik", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If dinamikraporgrafik.grafikbaslik = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = dinamikraporgrafik.grafikbaslik
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@grafiktip", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If dinamikraporgrafik.grafiktip = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = dinamikraporgrafik.grafiktip
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@genislik", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If dinamikraporgrafik.genislik = 0 Then
                param5.Value = 0
            Else
                param5.Value = dinamikraporgrafik.genislik
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@yukseklik", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If dinamikraporgrafik.yukseklik = 0 Then
                param6.Value = 0
            Else
                param6.Value = dinamikraporgrafik.yukseklik
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@kolonseriad", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If dinamikraporgrafik.kolonseriad = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = dinamikraporgrafik.kolonseriad
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@kolonsayi", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If dinamikraporgrafik.kolonsayi = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = dinamikraporgrafik.kolonsayi
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@labelgosterilsinmi", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If dinamikraporgrafik.labelgosterilsinmi = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = dinamikraporgrafik.labelgosterilsinmi
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@labelarkaplanrengi", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If dinamikraporgrafik.labelarkaplanrengi = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = dinamikraporgrafik.labelarkaplanrengi
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@labelseffaflik", SqlDbType.Decimal)
            param11.Direction = ParameterDirection.Input
            If dinamikraporgrafik.labelseffaflik = 0 Then
                param11.Value = 0
            Else
                param11.Value = dinamikraporgrafik.labelseffaflik
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@legendgosterilsinmi", SqlDbType.VarChar)
            param12.Direction = ParameterDirection.Input
            If dinamikraporgrafik.legendgosterilsinmi = "" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = dinamikraporgrafik.legendgosterilsinmi
            End If
            komut.Parameters.Add(param12)

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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from dinamikraporgrafik"
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
    Function Duzenle(ByVal dinamikraporgrafik As CLASSDINAMIKRAPORGRAFIK) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update dinamikraporgrafik set " + _
        "raporpkey=@raporpkey," + _
        "grafikbaslik=@grafikbaslik," + _
        "grafiktip=@grafiktip," + _
        "genislik=@genislik," + _
        "yukseklik=@yukseklik," + _
        "kolonseriad=@kolonseriad," + _
        "kolonsayi=@kolonsayi," + _
        "labelgosterilsinmi=@labelgosterilsinmi," + _
        "labelarkaplanrengi=@labelarkaplanrengi," + _
        "labelseffaflik=@labelseffaflik," + _
        "legendgosterilsinmi=@legendgosterilsinmi" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dinamikraporgrafik.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dinamikraporgrafik.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = dinamikraporgrafik.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@grafikbaslik", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If dinamikraporgrafik.grafikbaslik = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dinamikraporgrafik.grafikbaslik
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@grafiktip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dinamikraporgrafik.grafiktip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dinamikraporgrafik.grafiktip
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@genislik", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If dinamikraporgrafik.genislik = 0 Then
            param5.Value = 0
        Else
            param5.Value = dinamikraporgrafik.genislik
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@yukseklik", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If dinamikraporgrafik.yukseklik = 0 Then
            param6.Value = 0
        Else
            param6.Value = dinamikraporgrafik.yukseklik
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@kolonseriad", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If dinamikraporgrafik.kolonseriad = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = dinamikraporgrafik.kolonseriad
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@kolonsayi", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If dinamikraporgrafik.kolonsayi = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = dinamikraporgrafik.kolonsayi
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@labelgosterilsinmi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If dinamikraporgrafik.labelgosterilsinmi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = dinamikraporgrafik.labelgosterilsinmi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@labelarkaplanrengi", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If dinamikraporgrafik.labelarkaplanrengi = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = dinamikraporgrafik.labelarkaplanrengi
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@labelseffaflik", SqlDbType.Decimal)
        param11.Direction = ParameterDirection.Input
        If dinamikraporgrafik.labelseffaflik = 0 Then
            param11.Value = 0
        Else
            param11.Value = dinamikraporgrafik.labelseffaflik
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@legendgosterilsinmi", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If dinamikraporgrafik.legendgosterilsinmi = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = dinamikraporgrafik.legendgosterilsinmi
        End If
        komut.Parameters.Add(param12)


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


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSDINAMIKRAPORGRAFIK

        Dim komut As New SqlCommand
        Dim donecekdinamikraporgrafik As New CLASSdinamikraporgrafik()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporgrafik where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("grafikbaslik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.grafikbaslik = veri.Item("grafikbaslik")
                End If

                If Not veri.Item("grafiktip") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.grafiktip = veri.Item("grafiktip")
                End If

                If Not veri.Item("genislik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.genislik = veri.Item("genislik")
                End If

                If Not veri.Item("yukseklik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.yukseklik = veri.Item("yukseklik")
                End If

                If Not veri.Item("kolonseriad") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.kolonseriad = veri.Item("kolonseriad")
                End If

                If Not veri.Item("kolonsayi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.kolonsayi = veri.Item("kolonsayi")
                End If

                If Not veri.Item("labelgosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelgosterilsinmi = veri.Item("labelgosterilsinmi")
                End If

                If Not veri.Item("labelarkaplanrengi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelarkaplanrengi = veri.Item("labelarkaplanrengi")
                End If

                If Not veri.Item("labelseffaflik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelseffaflik = veri.Item("labelseffaflik")
                End If

                If Not veri.Item("legendgosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.legendgosterilsinmi = veri.Item("legendgosterilsinmi")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdinamikraporgrafik

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikraporgrafik where pkey=@pkey"
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


    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikraporgrafik where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
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
    Public Function doldur() As List(Of CLASSDINAMIKRAPORGRAFIK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikraporgrafik As New CLASSdinamikraporgrafik
        Dim dinamikraporgrafikler As New List(Of CLASSdinamikraporgrafik)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikraporgrafik"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("grafikbaslik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.grafikbaslik = veri.Item("grafikbaslik")
                End If

                If Not veri.Item("grafiktip") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.grafiktip = veri.Item("grafiktip")
                End If

                If Not veri.Item("genislik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.genislik = veri.Item("genislik")
                End If

                If Not veri.Item("yukseklik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.yukseklik = veri.Item("yukseklik")
                End If

                If Not veri.Item("kolonseriad") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.kolonseriad = veri.Item("kolonseriad")
                End If

                If Not veri.Item("kolonsayi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.kolonsayi = veri.Item("kolonsayi")
                End If

                If Not veri.Item("labelgosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelgosterilsinmi = veri.Item("labelgosterilsinmi")
                End If

                If Not veri.Item("labelarkaplanrengi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelarkaplanrengi = veri.Item("labelarkaplanrengi")
                End If

                If Not veri.Item("labelseffaflik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelseffaflik = veri.Item("labelseffaflik")
                End If

                If Not veri.Item("legendgosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.legendgosterilsinmi = veri.Item("legendgosterilsinmi")
                End If


                dinamikraporgrafikler.Add(New CLASSdinamikraporgrafik(donecekdinamikraporgrafik.pkey, _
                donecekdinamikraporgrafik.raporpkey, donecekdinamikraporgrafik.grafikbaslik, donecekdinamikraporgrafik.grafiktip, donecekdinamikraporgrafik.genislik, _
                donecekdinamikraporgrafik.yukseklik, donecekdinamikraporgrafik.kolonseriad, donecekdinamikraporgrafik.kolonsayi, donecekdinamikraporgrafik.labelgosterilsinmi, _
                donecekdinamikraporgrafik.labelarkaplanrengi, donecekdinamikraporgrafik.labelseffaflik, donecekdinamikraporgrafik.legendgosterilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporgrafikler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As Integer) As List(Of CLASSDINAMIKRAPORGRAFIK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim donecekdinamikraporgrafik As New CLASSDINAMIKRAPORGRAFIK
        Dim dinamikraporgrafikler As New List(Of CLASSDINAMIKRAPORGRAFIK)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikraporgrafik where raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("grafikbaslik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.grafikbaslik = veri.Item("grafikbaslik")
                End If

                If Not veri.Item("grafiktip") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.grafiktip = veri.Item("grafiktip")
                End If

                If Not veri.Item("genislik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.genislik = veri.Item("genislik")
                End If

                If Not veri.Item("yukseklik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.yukseklik = veri.Item("yukseklik")
                End If

                If Not veri.Item("kolonseriad") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.kolonseriad = veri.Item("kolonseriad")
                End If

                If Not veri.Item("kolonsayi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.kolonsayi = veri.Item("kolonsayi")
                End If

                If Not veri.Item("labelgosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelgosterilsinmi = veri.Item("labelgosterilsinmi")
                End If

                If Not veri.Item("labelarkaplanrengi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelarkaplanrengi = veri.Item("labelarkaplanrengi")
                End If

                If Not veri.Item("labelseffaflik") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.labelseffaflik = veri.Item("labelseffaflik")
                End If

                If Not veri.Item("legendgosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikraporgrafik.legendgosterilsinmi = veri.Item("legendgosterilsinmi")
                End If

                dinamikraporgrafikler.Add(New CLASSDINAMIKRAPORGRAFIK(donecekdinamikraporgrafik.pkey, _
                donecekdinamikraporgrafik.raporpkey, donecekdinamikraporgrafik.grafikbaslik, donecekdinamikraporgrafik.grafiktip, donecekdinamikraporgrafik.genislik, _
                donecekdinamikraporgrafik.yukseklik, donecekdinamikraporgrafik.kolonseriad, donecekdinamikraporgrafik.kolonsayi, donecekdinamikraporgrafik.labelgosterilsinmi, _
                donecekdinamikraporgrafik.labelarkaplanrengi, donecekdinamikraporgrafik.labelseffaflik, donecekdinamikraporgrafik.legendgosterilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return dinamikraporgrafikler


    End Function


   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        jvstring = "<script type='text/javascript'>" + _
            "$(document).ready(function() {" + _
                "$('.button').button();" + _
            "});" + _
            "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Rapor</th>" + _
        "<th>Grafik Başlığı</th>" + _
        "<th>Grafik Tipi</th>" + _
        "<th>Yazı Kolunu</th>" + _
        "<th>Değer Kolonu</th>" + _
        "<th>Label Bilgileri</th>" + _
        "<th>Legend Bilgileri</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from dinamikraporgrafik where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey, grafikbaslik, grafiktip, kolonseriad, kolonsayi As String
        Dim labelgosterilsinmi, labelarkaplanrengi, labelseffaflik, legendgosterilsinmi As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        Dim ajaxlinksil, dugmesil As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                    End If


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "dinamikraporpopup.aspx?pkey=" + CStr(raporpkey) + _
                        "&op=duzenle" + _
                        "&dinamikraporgrafikop=duzenle" + _
                        "&dinamikraporgrafikpkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                    kol2 = "<td>" + dinamikrapor.raporad + "</td>"


                    If Not veri.Item("grafikbaslik") Is System.DBNull.Value Then
                        grafikbaslik = veri.Item("grafikbaslik")
                        kol3 = "<td>" + grafikbaslik + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("grafiktip") Is System.DBNull.Value Then
                        grafiktip = veri.Item("grafiktip")
                        kol4 = "<td>" + grafiktip + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("kolonseriad") Is System.DBNull.Value Then
                        kolonseriad = veri.Item("kolonseriad")
                        kol5 = "<td>" + kolonseriad + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("kolonsayi") Is System.DBNull.Value Then
                        kolonsayi = veri.Item("kolonsayi")
                        kol6 = "<td>" + kolonsayi + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("labelgosterilsinmi") Is System.DBNull.Value Then
                        labelgosterilsinmi = veri.Item("labelgosterilsinmi")
                    Else
                        labelgosterilsinmi = "-"
                    End If
                    If Not veri.Item("labelarkaplanrengi") Is System.DBNull.Value Then
                        labelarkaplanrengi = veri.Item("labelarkaplanrengi")
                    Else
                        labelarkaplanrengi = "-"
                    End If
                    If Not veri.Item("labelseffaflik") Is System.DBNull.Value Then
                        labelseffaflik = veri.Item("labelseffaflik")
                    Else
                        labelseffaflik = "-"
                    End If

                    kol7 = "<td>" + "Label Gösterilecek mi? " + "<b>" + labelgosterilsinmi + "</b><br/>" + _
                    "Label Arkaplan Rengi: " + "<b>" + _
                    "<div style='display:block;width:80px;height:20px;background-color:" + "#" + labelarkaplanrengi + ";'></div>" + _
                    "</b>" + _
                    "Label Şeffafılık: " + "<b>" + labelseffaflik + "</b><br/>" + _
                    "</td>"

                    If Not veri.Item("legendgosterilsinmi") Is System.DBNull.Value Then
                        legendgosterilsinmi = veri.Item("legendgosterilsinmi")
                        kol8 = "<td>" + "Legend Gösterilecek mi?" + "<b>" + legendgosterilsinmi + "</b></td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "dinamikraporgrafiksil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='dinamikraporgrafiksilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol9 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporgrafik where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function

    Public Shared Function grafikdatagonder(ByVal raporpkey As String) As List(Of CLASSGRAFIKBILGI)

        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
        Dim dinamikraporgrafikler As New List(Of CLASSDINAMIKRAPORGRAFIK)
        dinamikraporgrafikler = dinamikraporgrafik_erisim.doldurilgili(raporpkey)

        Dim donecekgrafikbilgi As New List(Of CLASSGRAFIKBILGI)

        For Each item As CLASSDINAMIKRAPORGRAFIK In dinamikraporgrafikler
            donecekgrafikbilgi = dinamikraporgrafik_erisim.grafikdataolustur(raporpkey, item.pkey)
        Next

        Return donecekgrafikbilgi

    End Function

    Public Function grafikdataolustur(ByVal raporpkey As Integer, _
    ByVal dinamikraporgrafikpkey As Integer) As List(Of CLASSGRAFIKBILGI)

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikraporgrafik As New CLASSDINAMIKRAPORGRAFIK

        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim generic_erisim As New CLASSGENERIC_ERISIM


        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
        dinamikraporgrafik = bultek(dinamikraporgrafikpkey)


        Dim komut As New SqlCommand
        Dim donecekgrafikbilgi As New CLASSGRAFIKBILGI
        Dim donecekgrafikbilgiler As New List(Of CLASSGRAFIKBILGI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = dinamikrapor_erisim.sqlolustur(raporpkey)
        komut = New SqlCommand(sqlstr, db_baglanti)


        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim kosullar As New List(Of CLASSKOSULFIELD)
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)

        Dim z As Integer = 1
        Dim degisken As String
        Dim deger As String

        'PARAMETRELERİ GÖM ---------------------------------------------------------------
        For Each itemkosul As CLASSKOSULFIELD In kosullar

            degisken = itemkosul.fieldad + CStr(z)
            komut.Parameters.Add(degisken, generic_erisim.sqldbtypebul(itemkosul.fieldtype).sqltype)

            If dinamikrapor.arabirimolsunmu = "Hayır" And itemkosul.runtime = "Hayır" Then
                komut.Parameters(degisken).Value = itemkosul.deger
            End If

            If dinamikrapor.arabirimolsunmu = "Evet" And itemkosul.runtime = "Evet" Then
                deger = HttpContext.Current.Session("ss" + CStr(itemkosul.pkey))
                If deger Is Nothing Then
                    deger = itemkosul.deger
                End If
                komut.Parameters(degisken).Value = deger
            End If

            If dinamikrapor.arabirimolsunmu = "Evet" And itemkosul.runtime = "Hayır" Then
                komut.Parameters(degisken).Value = itemkosul.deger
            End If

            If itemkosul.runtime = "Hayır" And itemkosul.sezonad <> "" Then
                komut.Parameters(degisken).Value = HttpContext.Current.Session(itemkosul.sezonad)
            End If

            z = z + 1
        Next

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item(dinamikraporgrafik.kolonseriad) Is System.DBNull.Value Then
                    donecekgrafikbilgi.seriad = veri.Item(dinamikraporgrafik.kolonseriad)
                End If

                If Not veri.Item(dinamikraporgrafik.kolonsayi) Is System.DBNull.Value Then
                    donecekgrafikbilgi.sayi = veri.Item(dinamikraporgrafik.kolonsayi)
                End If

                donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                donecekgrafikbilgi.sayi))

            End While
        End Using

        Return donecekgrafikbilgiler

    End Function


    Function kolonsayivarmi(ByVal raporpkey As Integer, ByVal kolonsayi As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporgrafik where raporpkey=@raporpkey and kolonsayi=@kolonsayi"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kolonsayi", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kolonsayi
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function kolonseriadvarmi(ByVal raporpkey As Integer, ByVal kolonseriad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporgrafik where raporpkey=@raporpkey and kolonseriad=@kolonseriad"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kolonseriad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kolonseriad
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function



    Public Function kacgrafikvar_ilgiliraporda(ByVal raporpkey As String) As Integer

        Dim varmidonecek As String
        Dim sqlstr As String
        Dim kayitsayisi As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from dinamikraporgrafik where raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitsayisi = 0
        Else
            kayitsayisi = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        Return kayitsayisi


    End Function

End Class



