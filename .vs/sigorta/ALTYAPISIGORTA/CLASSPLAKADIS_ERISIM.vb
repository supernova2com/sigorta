Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data


Public Class CLASSPLAKADIS_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim plakadis As New CLASSPLAKADIS
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal plakadis As CLASSPLAKADIS) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(plakadis.plaka)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu plaka halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into plakadis values (@pkey," + _
        "@plaka,@eklenmetarih,@kullanicipkey,@dogrucc,@arackayitcc)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        eklenenpkey = pkeybul()
        param1.Value = eklenenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@plaka", SqlDbType.VarChar, 30)
        param2.Direction = ParameterDirection.Input
        If plakadis.plaka = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = plakadis.plaka
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@eklenmetarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If plakadis.eklenmetarih Is Nothing Or plakadis.eklenmetarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = plakadis.eklenmetarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If plakadis.kullanicipkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = plakadis.kullanicipkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@dogrucc", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If plakadis.dogrucc = 0 Then
            param5.Value = 0
        Else
            param5.Value = plakadis.dogrucc
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@arackayitcc", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If plakadis.arackayitcc = 0 Then
            param6.Value = 0
        Else
            param6.Value = plakadis.arackayitcc
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

        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from plakadis"
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
    Function Duzenle(ByVal plakadis As CLASSPLAKADIS) As CLADBOPRESULT

        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(plakadis.plaka, plakadis.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu plaka halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update plakadis set " + _
        "plaka=@plaka," + _
        "eklenmetarih=@eklenmetarih," + _
        "kullanicipkey=@kullanicipkey," + _
        "dogrucc=@dogrucc," + _
        "arackayitcc=@arackayitcc" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = plakadis.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@plaka", SqlDbType.VarChar, 30)
        param2.Direction = ParameterDirection.Input
        If plakadis.plaka = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = plakadis.plaka
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@eklenmetarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If plakadis.eklenmetarih Is Nothing Or plakadis.eklenmetarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = plakadis.eklenmetarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If plakadis.kullanicipkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = plakadis.kullanicipkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@dogrucc", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If plakadis.dogrucc = 0 Then
            param5.Value = 0
        Else
            param5.Value = plakadis.dogrucc
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@arackayitcc", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If plakadis.arackayitcc = 0 Then
            param6.Value = 0
        Else
            param6.Value = plakadis.arackayitcc
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
    Function bultek(ByVal pkey As String) As CLASSPLAKADIS

        Dim komut As New SqlCommand
        Dim donecekplakadis As New CLASSPLAKADIS()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from plakadis where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakadis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakadis.plaka = veri.Item("plaka")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekplakadis.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekplakadis.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("dogrucc") Is System.DBNull.Value Then
                    donecekplakadis.dogrucc = veri.Item("dogrucc")
                End If

                If Not veri.Item("arackayitcc") Is System.DBNull.Value Then
                    donecekplakadis.arackayitcc = veri.Item("arackayitcc")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekplakadis

    End Function


    Function bultek_plakayagore(ByVal plaka As String) As CLASSPLAKADIS

        Dim komut As New SqlCommand
        Dim donecekplakadis As New CLASSPLAKADIS()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from plakadis where plaka=@plaka"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = plaka
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakadis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakadis.plaka = veri.Item("plaka")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekplakadis.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekplakadis.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("dogrucc") Is System.DBNull.Value Then
                    donecekplakadis.dogrucc = veri.Item("dogrucc")
                End If

                If Not veri.Item("arackayitcc") Is System.DBNull.Value Then
                    donecekplakadis.arackayitcc = veri.Item("arackayitcc")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekplakadis

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from plakadis where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSPLAKADIS)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekplakadis As New CLASSPLAKADIS
        Dim plakadisler As New List(Of CLASSPLAKADIS)
        komut.Connection = db_baglanti
        sqlstr = "select * from plakadis"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakadis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakadis.plaka = veri.Item("plaka")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekplakadis.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekplakadis.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("dogrucc") Is System.DBNull.Value Then
                    donecekplakadis.dogrucc = veri.Item("dogrucc")
                End If

                If Not veri.Item("arackayitcc") Is System.DBNull.Value Then
                    donecekplakadis.arackayitcc = veri.Item("arackayitcc")
                End If


                plakadisler.Add(New CLASSPLAKADIS(donecekplakadis.pkey, donecekplakadis.plaka, _
                donecekplakadis.eklenmetarih, donecekplakadis.kullanicipkey, _
                donecekplakadis.dogrucc, donecekplakadis.arackayitcc))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return plakadisler

    End Function



    Public Function doldur_plakayagore(ByVal plaka As String) As List(Of CLASSPLAKADIS)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekplakadis As New CLASSPLAKADIS
        Dim plakadisler As New List(Of CLASSPLAKADIS)
        komut.Connection = db_baglanti
        sqlstr = "select * from plakadis where plaka LIKE @plaka+'%'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = plaka
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakadis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakadis.plaka = veri.Item("plaka")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekplakadis.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekplakadis.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("dogrucc") Is System.DBNull.Value Then
                    donecekplakadis.dogrucc = veri.Item("dogrucc")
                End If

                If Not veri.Item("arackayitcc") Is System.DBNull.Value Then
                    donecekplakadis.arackayitcc = veri.Item("arackayitcc")
                End If


                plakadisler.Add(New CLASSPLAKADIS(donecekplakadis.pkey, donecekplakadis.plaka, _
                donecekplakadis.eklenmetarih, donecekplakadis.kullanicipkey, _
                donecekplakadis.dogrucc, donecekplakadis.arackayitcc))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return plakadisler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
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
        "<th>Plaka</th>" + _
        "<th>Eklenme Tarihi</th>" + _
        "<th>Ekleyen Kullanıcı</th>" + _
        "<th>Doğru CC Değeri</th>" + _
        "<th>Araç Kayıt CC Değeri</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from plakadis"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "ARAMA" Then
            sqlstr = "select * from plakadis where plaka LIKE '%'+@plaka+'%' order by plaka"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("plaka")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, plaka, eklenmetarih, kullanicipkey, dogrucc, arackayitcc As String

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "plakadis.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("plaka") Is System.DBNull.Value Then
                        plaka = veri.Item("plaka")
                        kol2 = "<td>" + plaka + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                        eklenmetarih = veri.Item("eklenmetarih")
                        kol3 = "<td>" + eklenmetarih + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                        kol4 = "<td>" + kullanici.adsoyad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("dogrucc") Is System.DBNull.Value Then
                        dogrucc = veri.Item("dogrucc")
                        kol5 = "<td>" + dogrucc + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("arackayitcc") Is System.DBNull.Value Then
                        arackayitcc = veri.Item("arackayitcc")
                        kol6 = "<td>" + arackayitcc + "</td></tr>"
                    Else
                        kol6 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6

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
    Function ciftkayitkontrol(ByVal plaka As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from plakadis where plaka=@plaka"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = plaka
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function ciftkayitkontrol_duzenle(ByVal plaka As String, ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from plakadis where plaka=@plaka and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = plaka
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkey", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = pkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function

End Class



