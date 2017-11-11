Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSMANUELRAPORKULLANICI_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim manuelraporkullanici As New CLASSMANUELRAPORKULLANICI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal manuelraporkullanici As CLASSMANUELRAPORKULLANICI) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol( manuelraporkullanici.kullanicipkey, manuelraporkullanici.manuelraporpkey)

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
            sqlstr = "insert into manuelraporkullanici values (@pkey," + _
            "@manuelraporpkey,@kullanicipkey,@epostaexcel,@epostaword," + _
            "@epostapdf)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If manuelraporkullanici.manuelraporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = manuelraporkullanici.manuelraporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If manuelraporkullanici.kullanicipkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = manuelraporkullanici.kullanicipkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@epostaexcel", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If manuelraporkullanici.epostaexcel = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = manuelraporkullanici.epostaexcel
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@epostaword", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If manuelraporkullanici.epostaword = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = manuelraporkullanici.epostaword
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@epostapdf", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If manuelraporkullanici.epostapdf = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = manuelraporkullanici.epostapdf
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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from manuelraporkullanici"
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
    Function Duzenle(ByVal manuelraporkullanici As CLASSMANUELRAPORKULLANICI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update manuelraporkullanici set " + _
        "manuelraporpkey=@manuelraporpkey," + _
        "kullanicipkey=@kullanicipkey," + _
        "epostaexcel=@epostaexcel," + _
        "epostaword=@epostaword," + _
        "epostapdf=@epostapdf" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporkullanici.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If manuelraporkullanici.manuelraporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = manuelraporkullanici.manuelraporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If manuelraporkullanici.kullanicipkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = manuelraporkullanici.kullanicipkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@epostaexcel", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If manuelraporkullanici.epostaexcel = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = manuelraporkullanici.epostaexcel
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@epostaword", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If manuelraporkullanici.epostaword = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = manuelraporkullanici.epostaword
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@epostapdf", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If manuelraporkullanici.epostapdf = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = manuelraporkullanici.epostapdf
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
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSMANUELRAPORKULLANICI

        Dim komut As New SqlCommand
        Dim donecekmanuelraporkullanici As New CLASSMANUELRAPORKULLANICI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporkullanici where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.manuelraporpkey = veri.Item("manuelraporpkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("epostaexcel") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostaexcel = veri.Item("epostaexcel")
                End If

                If Not veri.Item("epostaword") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostaword = veri.Item("epostaword")
                End If

                If Not veri.Item("epostapdf") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostapdf = veri.Item("epostapdf")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekmanuelraporkullanici

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from manuelraporkullanici where pkey=@pkey"
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

    '---------------------------------sil-----------------------------------------
    Public Function sililgili(ByVal manuelraporpkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from manuelraporkullanici where manuelraporpkey=@manuelraporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporpkey
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
    Public Function doldur() As List(Of CLASSMANUELRAPORKULLANICI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmanuelraporkullanici As New CLASSMANUELRAPORKULLANICI
        Dim manuelraporkullaniciler As New List(Of CLASSMANUELRAPORKULLANICI)
        komut.Connection = db_baglanti
        sqlstr = "select * from manuelraporkullanici"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.manuelraporpkey = veri.Item("manuelraporpkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("epostaexcel") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostaexcel = veri.Item("epostaexcel")
                End If

                If Not veri.Item("epostaword") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostaword = veri.Item("epostaword")
                End If

                If Not veri.Item("epostapdf") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostapdf = veri.Item("epostapdf")
                End If


                manuelraporkullaniciler.Add(New CLASSMANUELRAPORKULLANICI(donecekmanuelraporkullanici.pkey, _
                donecekmanuelraporkullanici.manuelraporpkey, donecekmanuelraporkullanici.kullanicipkey, donecekmanuelraporkullanici.epostaexcel, donecekmanuelraporkullanici.epostaword, _
                donecekmanuelraporkullanici.epostapdf))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return manuelraporkullaniciler

    End Function


    Public Function doldurilgili(ByVal manuelraporpkey As Integer) As List(Of CLASSMANUELRAPORKULLANICI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmanuelraporkullanici As New CLASSMANUELRAPORKULLANICI
        Dim manuelraporkullaniciler As New List(Of CLASSMANUELRAPORKULLANICI)
        komut.Connection = db_baglanti
        sqlstr = "select * from manuelraporkullanici where manuelraporpkey=@manuelraporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.manuelraporpkey = veri.Item("manuelraporpkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("epostaexcel") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostaexcel = veri.Item("epostaexcel")
                End If

                If Not veri.Item("epostaword") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostaword = veri.Item("epostaword")
                End If

                If Not veri.Item("epostapdf") Is System.DBNull.Value Then
                    donecekmanuelraporkullanici.epostapdf = veri.Item("epostapdf")
                End If


                manuelraporkullaniciler.Add(New CLASSMANUELRAPORKULLANICI(donecekmanuelraporkullanici.pkey, _
                donecekmanuelraporkullanici.manuelraporpkey, donecekmanuelraporkullanici.kullanicipkey, donecekmanuelraporkullanici.epostaexcel, donecekmanuelraporkullanici.epostaword, _
                donecekmanuelraporkullanici.epostapdf))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return manuelraporkullaniciler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim ajaxlinksil, dugmesil As String

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
        "<th>Kullanıcı</th>" + _
        "<th>E-Posta (EXCEL)</th>" + _
        "<th>E-Posta (WORD)</th>" + _
        "<th>E-Posta (PDF)</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from  manuelraporkullanici where manuelraporpkey=@manuelraporpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("manuelraporpkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, manuelraporpkey, kullanicipkey, epostaexcel, epostaword, epostapdf As String

        Dim manuelrapor As New CLASSMANUELRAPOR
        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                        manuelraporpkey = veri.Item("manuelraporpkey")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        link = "manuelraporpopup.aspx?pkey=" + CStr(manuelraporpkey) + _
                        "&op=duzenle" + _
                        "&manuelraporkullaniciop=duzenle" + _
                        "&manuelraporkullanicipkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"

                    End If

                    If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                        manuelraporpkey = veri.Item("manuelraporpkey")
                        manuelrapor = manuelrapor_erisim.bultek(manuelraporpkey)
                        kol2 = "<td>" + manuelrapor.ad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                        kol3 = "<td>" + kullanici.adsoyad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("epostaexcel") Is System.DBNull.Value Then
                        epostaexcel = veri.Item("epostaexcel")
                        kol4 = "<td>" + epostaexcel + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("epostaword") Is System.DBNull.Value Then
                        epostaword = veri.Item("epostaword")
                        kol5 = "<td>" + epostaword + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("epostapdf") Is System.DBNull.Value Then
                        epostapdf = veri.Item("epostapdf")
                        kol6 = "<td>" + epostapdf + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "manuelraporkullanicisil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='manuelraporkullanicisilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol7 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7

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
    Function ciftkayitkontrol(ByVal kullanicipkey As Integer, ByVal manuelraporpkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporkullanici where kullanicipkey=@kullanicipkey" + _
        " and manuelraporpkey=@manuelraporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = manuelraporpkey
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function raporvarmi(ByVal manuelraporpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporkullanici where manuelraporpkey=@manuelraporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function kullanicivarmi(ByVal kullanicipkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporkullanici where kullanicipkey=@kullanicipkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
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


