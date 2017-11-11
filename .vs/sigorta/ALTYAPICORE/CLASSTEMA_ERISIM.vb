Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSTEMA_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tema As New CLASSTEMA
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tema As CLASSTEMA) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("temaad", tema.temaad)

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
            sqlstr = "insert into tema values (@pkey," + _
            "@temaad,@kimin)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@temaad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If tema.temaad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = tema.temaad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@kimin", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If tema.kimin = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = tema.kimin
            End If
            komut.Parameters.Add(param3)

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
        sqlstr = "select max(pkey) from tema"
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
    Function Duzenle(ByVal tema As CLASSTEMA) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update tema set " + _
        "temaad=@temaad," + _
        "kimin=@kimin" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tema.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@temaad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If tema.temaad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = tema.temaad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kimin", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If tema.kimin = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = tema.kimin
        End If
        komut.Parameters.Add(param3)


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
    Function bultek(ByVal pkey As String) As CLASSTEMA

        Dim komut As New SqlCommand
        Dim donecektema As New CLASSTEMA()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tema where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektema.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("temaad") Is System.DBNull.Value Then
                    donecektema.temaad = veri.Item("temaad")
                End If

                If Not veri.Item("kimin") Is System.DBNull.Value Then
                    donecektema.kimin = veri.Item("kimin")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektema

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "delete from tema where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSTEMA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektema As New CLASSTEMA
        Dim temaler As New List(Of CLASSTEMA)
        komut.Connection = db_baglanti
        sqlstr = "select * from tema"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektema.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("temaad") Is System.DBNull.Value Then
                    donecektema.temaad = veri.Item("temaad")
                End If

                If Not veri.Item("kimin") Is System.DBNull.Value Then
                    donecektema.kimin = veri.Item("kimin")
                End If


                temaler.Add(New CLASSTEMA(donecektema.pkey, _
                donecektema.temaad, donecektema.kimin))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return temaler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_kimingore(ByVal kimin As String) As List(Of CLASSTEMA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektema As New CLASSTEMA
        Dim temaler As New List(Of CLASSTEMA)
        komut.Connection = db_baglanti
        sqlstr = "select * from tema where kimin='" + kimin + "'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektema.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("temaad") Is System.DBNull.Value Then
                    donecektema.temaad = veri.Item("temaad")
                End If

                If Not veri.Item("kimin") Is System.DBNull.Value Then
                    donecektema.kimin = veri.Item("kimin")
                End If


                temaler.Add(New CLASSTEMA(donecektema.pkey, _
                donecektema.temaad, donecektema.kimin))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return temaler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal kriter As String) As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        'jvstring = "<script type='text/javascript'>" + _
        '"$(document).ready(function() {" + _
        '"$('#datatable').dataTable();" + _
        '"});" + _
        '"</script>"


        basliklar = "<table id=datatable class='display'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>pkey</th>" + _
        "<th>temaad</th>" + _
        "<th>kimin</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        sqlstr = "select * from tema"
        komut = New SqlCommand(sqlstr, db_baglanti)

        girdi = "0"
        Dim link As String
        Dim pkey, temaad, kimin As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "tema.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("temaad") Is System.DBNull.Value Then
                        temaad = veri.Item("temaad")
                        kol2 = "<td>" + temaad + "</td>"
                    End If

                    If Not veri.Item("kimin") Is System.DBNull.Value Then
                        kimin = veri.Item("kimin")
                        kol3 = "<td>" + kimin + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try



        db_baglanti.Close()

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

        sqlstr = "select * from tema where " + tablecol + "=@kriter"

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

End Class

