
Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSTARIFESINIRKAPIBAG_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tarifesinirkapibag As New CLASSTARIFESINIRKAPIBAG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tarifesinirkapibag As CLASSTARIFESINIRKAPIBAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(tarifesinirkapibag.aractarifepkey, tarifesinirkapibag.sinirkapiaractippkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu eşleşme halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into tarifesinirkapibag values (@pkey," + _
            "@aractarifepkey,@sinirkapiaractippkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If tarifesinirkapibag.aractarifepkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = tarifesinirkapibag.aractarifepkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If tarifesinirkapibag.sinirkapiaractippkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = tarifesinirkapibag.sinirkapiaractippkey
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
        sqlstr = "select max(pkey) from tarifesinirkapibag"
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
    Function Duzenle(ByVal tarifesinirkapibag As CLASSTARIFESINIRKAPIBAG) As CLADBOPRESULT

        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(tarifesinirkapibag.aractarifepkey, tarifesinirkapibag.sinirkapiaractippkey, _
        tarifesinirkapibag.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu eşleşme halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update tarifesinirkapibag set " + _
        "aractarifepkey=@aractarifepkey," + _
        "sinirkapiaractippkey=@sinirkapiaractippkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tarifesinirkapibag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If tarifesinirkapibag.aractarifepkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = tarifesinirkapibag.aractarifepkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If tarifesinirkapibag.sinirkapiaractippkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = tarifesinirkapibag.sinirkapiaractippkey
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
    Function bultek(ByVal pkey As String) As CLASSTARIFESINIRKAPIBAG

        Dim komut As New SqlCommand
        Dim donecektarifesinirkapibag As New CLASSTARIFESINIRKAPIBAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tarifesinirkapibag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.aractarifepkey = veri.Item("aractarifepkey")
                End If

                If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektarifesinirkapibag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from tarifesinirkapibag where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSTARIFESINIRKAPIBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektarifesinirkapibag As New CLASSTARIFESINIRKAPIBAG
        Dim tarifesinirkapibagler As New List(Of CLASSTARIFESINIRKAPIBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from tarifesinirkapibag"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.aractarifepkey = veri.Item("aractarifepkey")
                End If

                If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                End If


                tarifesinirkapibagler.Add(New CLASSTARIFESINIRKAPIBAG(donecektarifesinirkapibag.pkey, _
                donecektarifesinirkapibag.aractarifepkey, donecektarifesinirkapibag.sinirkapiaractippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tarifesinirkapibagler

    End Function


    Public Function doldur_ilgili(ByVal aractarifepkey As Integer) As List(Of CLASSTARIFESINIRKAPIBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektarifesinirkapibag As New CLASSTARIFESINIRKAPIBAG
        Dim tarifesinirkapibagler As New List(Of CLASSTARIFESINIRKAPIBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from tarifesinirkapibag where aractarifepkey=@aractarifepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("aractarifepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aractarifepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.aractarifepkey = veri.Item("aractarifepkey")
                End If

                If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                    donecektarifesinirkapibag.sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                End If


                tarifesinirkapibagler.Add(New CLASSTARIFESINIRKAPIBAG(donecektarifesinirkapibag.pkey, _
                donecektarifesinirkapibag.aractarifepkey, donecektarifesinirkapibag.sinirkapiaractippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tarifesinirkapibagler

    End Function


    Public Function gonderebilecegi_cartype(ByVal aractarifepkey As Integer) As String

        Dim donecek As String = ""
        Dim tarifesinirkapibaglar As New List(Of CLASSTARIFESINIRKAPIBAG)
        tarifesinirkapibaglar = doldur_ilgili(aractarifepkey)

        Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
        Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM

        For Each Item As CLASSTARIFESINIRKAPIBAG In tarifesinirkapibaglar
            sinirkapiaractip = sinirkapiaractip_erisim.bultek(Item.sinirkapiaractippkey)
            donecek = donecek + sinirkapiaractip.sinirkapiaractipad + ","
        Next

        Return donecek

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
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
        "<th>Tarife</th>" + _
        "<th>Araç Tipi (Sınır Kapısı)</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from tarifesinirkapibag"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, aractarifepkey, sinirkapiaractippkey As String

        Dim aractarife As New CLASSARACTARIFE
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

        Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
        Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "tarifesinirkapibag.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                        aractarifepkey = veri.Item("aractarifepkey")
                        aractarife = aractarife_erisim.bultek(aractarifepkey)
                        kol2 = "<td>" + aractarife.tarifekod + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                        sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                        sinirkapiaractip = sinirkapiaractip_erisim.bultek(sinirkapiaractippkey)
                        kol3 = "<td>" + sinirkapiaractip.sinirkapiaractipad + "</td></tr>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
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
    Function ciftkayitkontrol(ByVal aractarifepkey As Integer, ByVal sinirkapiaractippkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tarifesinirkapibag where " + _
        "aractarifepkey=@aractarifepkey and sinirkapiaractippkey=@sinirkapiaractippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aractarifepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = sinirkapiaractippkey
        komut.Parameters.Add(param2)

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


    '--- ÇİFT KAYIT KONTROL DÜZENLE -------------------------------------------------------
    Function ciftkayitkontrol_duzenle(ByVal aractarifepkey As Integer, ByVal sinirkapiaractippkey As Integer, _
    ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tarifesinirkapibag where " + _
        "aractarifepkey=@aractarifepkey and sinirkapiaractippkey=@sinirkapiaractippkey and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aractarifepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = sinirkapiaractippkey
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

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        Return varmi

    End Function


    Function varmitarife(ByVal aractarifepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tarifesinirkapibag where aractarifepkey=@aractarifepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aractarifepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function varmisinirkapiaractip(ByVal sinirkapiaractippkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tarifesinirkapibag where sinirkapiaractippkey=@sinirkapiaractippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapiaractippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function







End Class
