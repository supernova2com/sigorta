Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSYETKIBILGI_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal yetkibilgi As CLASSYETKIBILGI) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(yetkibilgi.kullanicirolpkey, yetkibilgi.tmodulpkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu modül ve kullanıcı rolü için halihazırda yetkibilgilendirme yapılmıştır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into yetkibilgi values (@pkey," + _
            "@kullanicirolpkey,@tmodulpkey,@insertyetki,@updateyetki," + _
            "@deleteyetki,@readyetki)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If yetkibilgi.kullanicirolpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = yetkibilgi.kullanicirolpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tmodulpkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If yetkibilgi.tmodulpkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = yetkibilgi.tmodulpkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@insertyetki", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If yetkibilgi.insertyetki = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = yetkibilgi.insertyetki
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@updateyetki", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If yetkibilgi.updateyetki = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = yetkibilgi.updateyetki
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@deleteyetki", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If yetkibilgi.deleteyetki = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = yetkibilgi.deleteyetki
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@readyetki", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If yetkibilgi.readyetki = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = yetkibilgi.readyetki
            End If
            komut.Parameters.Add(param7)

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
        sqlstr = "select max(pkey) from yetkibilgi"
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
    Function Duzenle(ByVal yetkibilgi As CLASSYETKIBILGI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update yetkibilgi set " + _
        "kullanicirolpkey=@kullanicirolpkey," + _
        "tmodulpkey=@tmodulpkey," + _
        "insertyetki=@insertyetki," + _
        "updateyetki=@updateyetki," + _
        "deleteyetki=@deleteyetki," + _
        "readyetki=@readyetki" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = yetkibilgi.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If yetkibilgi.kullanicirolpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = yetkibilgi.kullanicirolpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tmodulpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If yetkibilgi.tmodulpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = yetkibilgi.tmodulpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@insertyetki", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If yetkibilgi.insertyetki = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = yetkibilgi.insertyetki
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@updateyetki", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If yetkibilgi.updateyetki = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = yetkibilgi.updateyetki
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@deleteyetki", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If yetkibilgi.deleteyetki = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = yetkibilgi.deleteyetki
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@readyetki", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If yetkibilgi.readyetki = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = yetkibilgi.readyetki
        End If
        komut.Parameters.Add(param7)


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
    Function bultek(ByVal pkey As String) As CLASSYETKIBILGI

        Dim komut As New SqlCommand
        Dim donecekyetkibilgi As New CLASSYETKIBILGI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from yetkibilgi where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kullanicirolpkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.kullanicirolpkey = veri.Item("kullanicirolpkey")
                End If

                If Not veri.Item("tmodulpkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.tmodulpkey = veri.Item("tmodulpkey")
                End If

                If Not veri.Item("insertyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.insertyetki = veri.Item("insertyetki")
                End If

                If Not veri.Item("updateyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.updateyetki = veri.Item("updateyetki")
                End If

                If Not veri.Item("deleteyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.deleteyetki = veri.Item("deleteyetki")
                End If

                If Not veri.Item("readyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.readyetki = veri.Item("readyetki")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekyetkibilgi

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bul_ilgili(ByVal kullanicirolpkey As String, ByVal tmodulpkey As String) As CLASSYETKIBILGI

        Dim donecekyetkibilgi As New CLASSYETKIBILGI()

        If IsNumeric(kullanicirolpkey) = False Then
            donecekyetkibilgi.insertyetki = "Hayır"
            donecekyetkibilgi.updateyetki = "Hayır"
            donecekyetkibilgi.deleteyetki = "Hayır"
            donecekyetkibilgi.readyetki = "Hayır"
            Return donecekyetkibilgi
        End If

        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from yetkibilgi where kullanicirolpkey=@kullanicirolpkey and tmodulpkey=@tmodulpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirolpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tmodulpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = tmodulpkey
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kullanicirolpkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.kullanicirolpkey = veri.Item("kullanicirolpkey")
                End If

                If Not veri.Item("tmodulpkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.tmodulpkey = veri.Item("tmodulpkey")
                End If

                If Not veri.Item("insertyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.insertyetki = veri.Item("insertyetki")
                End If

                If Not veri.Item("updateyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.updateyetki = veri.Item("updateyetki")
                End If

                If Not veri.Item("deleteyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.deleteyetki = veri.Item("deleteyetki")
                End If

                If Not veri.Item("readyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.readyetki = veri.Item("readyetki")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekyetkibilgi

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        If Current.Session("silmeyetkibilgi") = "Evet" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from yetkibilgi where pkey=@pkey"
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
        End If

        If Current.Session("silmeyetkibilgi") = "Hayır" Then
            resultset.durum = "Silme yetkibilginiz yoktur."
            resultset.hatastr = "Silme yetkibilginiz yoktur."
            resultset.etkilenen = 0
        End If

        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSYETKIBILGI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekyetkibilgi As New CLASSYETKIBILGI
        Dim yetkibilgiler As New List(Of CLASSYETKIBILGI)
        komut.Connection = db_baglanti
        sqlstr = "select * from yetkibilgi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kullanicirolpkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.kullanicirolpkey = veri.Item("kullanicirolpkey")
                End If

                If Not veri.Item("tmodulpkey") Is System.DBNull.Value Then
                    donecekyetkibilgi.tmodulpkey = veri.Item("tmodulpkey")
                End If

                If Not veri.Item("insertyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.insertyetki = veri.Item("insertyetki")
                End If

                If Not veri.Item("updateyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.updateyetki = veri.Item("updateyetki")
                End If

                If Not veri.Item("deleteyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.deleteyetki = veri.Item("deleteyetki")
                End If

                If Not veri.Item("readyetki") Is System.DBNull.Value Then
                    donecekyetkibilgi.readyetki = veri.Item("readyetki")
                End If


                yetkibilgiler.Add(New CLASSYETKIBILGI(donecekyetkibilgi.pkey, _
                donecekyetkibilgi.kullanicirolpkey, donecekyetkibilgi.tmodulpkey, donecekyetkibilgi.insertyetki, donecekyetkibilgi.updateyetki, _
                donecekyetkibilgi.deleteyetki, donecekyetkibilgi.readyetki))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return yetkibilgiler

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function ilgilisil(ByVal kullanicirolpkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        komut = New SqlCommand(sqlstr, db_baglanti)

        sqlstr = "delete from yetkibilgi where kullanicirolpkey=@kullanicirolpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirolpkey
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

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim tabloson, pager As String
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
        "<th>Kullanıcı Rolü</th>" + _
        "<th>Modül</th>" + _
        "<th>Ekleme</th>" + _
        "<th>Güncelleme</th>" + _
        "<th>Silme</th>" + _
        "<th>Okuma</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from yetkibilgi"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, kullanicirolpkey, tmodulpkey, insertyetki, updateyetki, deleteyetki, readyetki As String

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        Dim tmodul As New CLASSTMODUL
        Dim tmodul_erisim As New CLASSTMODUL_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "yetkibilgi.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("kullanicirolpkey") Is System.DBNull.Value Then
                        kullanicirolpkey = veri.Item("kullanicirolpkey")
                        kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
                        kol2 = "<td>" + kullanicirol.rolad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("tmodulpkey") Is System.DBNull.Value Then
                        tmodulpkey = veri.Item("tmodulpkey")
                        tmodul = tmodul_erisim.bultek(tmodulpkey)
                        kol3 = "<td>" + tmodul.ad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("insertyetki") Is System.DBNull.Value Then
                        insertyetki = veri.Item("insertyetki")
                        kol4 = "<td>" + insertyetki + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("updateyetki") Is System.DBNull.Value Then
                        updateyetki = veri.Item("updateyetki")
                        kol5 = "<td>" + updateyetki + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("deleteyetki") Is System.DBNull.Value Then
                        deleteyetki = veri.Item("deleteyetki")
                        kol6 = "<td>" + deleteyetki + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("readyetki") Is System.DBNull.Value Then
                        readyetki = veri.Item("readyetki")
                        kol7 = "<td>" + readyetki + "</td></tr>"
                    Else
                        kol7 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
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
    Function ciftkayitkontrol(ByVal kullanicirolpkey As String, ByVal tmodulpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from yetkibilgi where kullanicirolpkey=@kullanicirolpkey and " + _
        "tmodulpkey=@tmodulpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirolpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tmodulpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = tmodulpkey
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function




    Public Function inputlariolustur(ByVal kullanicirolpkey As String, _
    ByVal op As String) As String

        Dim tekinput As String
        Dim teksatir As String = ""
        Dim oid As String
        Dim donecek As String = ""
        Dim basliklar, tabloson As String
        Dim valuestr As String = ""

        basliklar = "<table id=sonuctable class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Rol Adı</th>" + _
        "<th>Ekleme</th>" + _
        "<th>Güncelleme</th>" + _
        "<th>Silme</th>" + _
        "<th>Okuma</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim tmodul_erisim As New CLASSTMODUL_ERISIM
        Dim tmoduller As New List(Of CLASSTMODUL)
        tmoduller = tmodul_erisim.doldur_bilgicin


        For Each itemtmodul As CLASSTMODUL In tmoduller
            teksatir = teksatir + "<tr><td>" + itemtmodul.ad + "</td>"

            yetkibilgi = bul_ilgili(kullanicirolpkey, itemtmodul.pkey)

            For i = 1 To 4

                If op = "duzenle" Then
                    valuestr = ""

                    If i = 1 Then
                        If yetkibilgi.insertyetki = "Evet" Then
                            valuestr = " checked"
                        Else
                            valuestr = ""
                        End If
                    End If

                    If i = 2 Then
                        If yetkibilgi.updateyetki = "Evet" Then
                            valuestr = " checked"
                        Else
                            valuestr = ""
                        End If
                    End If

                    If i = 3 Then
                        If yetkibilgi.deleteyetki = "Evet" Then
                            valuestr = " checked"
                        Else
                            valuestr = ""
                        End If
                    End If

                    If i = 4 Then
                        If yetkibilgi.readyetki = "Evet" Then
                            valuestr = " checked"
                        Else
                            valuestr = ""
                        End If
                    End If


                End If

                oid = CStr(itemtmodul.pkey) + "_" + CStr(i)
                tekinput = "<input type=" + Chr(34) + "checkbox" + Chr(34) + _
                " id=" + Chr(34) + "A" + oid + Chr(34) + _
                " name=" + Chr(34) + "A" + oid + Chr(34) + _
                " class=" + Chr(34) + "textboxkucuk" + Chr(34) + valuestr + "></input>"
                teksatir = teksatir + "<td>" + tekinput + "</td>"
            Next
            teksatir = teksatir + "</tr>"
        Next

        donecek = basliklar + teksatir + tabloson

        Return donecek

    End Function


    Public Function temizle(ByVal yetkibilgi As CLASSYETKIBILGI) As CLASSYETKIBILGI

        yetkibilgi.pkey = 0
        yetkibilgi.kullanicirolpkey = 0
        yetkibilgi.tmodulpkey = 0

        yetkibilgi.insertyetki = "Hayır"
        yetkibilgi.updateyetki = "Hayır"
        yetkibilgi.deleteyetki = "Hayır"
        yetkibilgi.readyetki = "Hayır"


        Return yetkibilgi

    End Function


    Function kullanicirolvarmi(ByVal kullanicirolpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from yetkibilgi where kullanicirolpkey=@kullanicirolpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirolpkey
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
