Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSREMINDERSETTING_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim remindersetting As New CLASSREMINDERSETTING
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal remindersetting As CLASSREMINDERSETTING) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("reminder_name", remindersetting.reminder_name)

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
            sqlstr = "insert into remindersetting values (@pkey," + _
            "@reminder_name,@reminder_schedule_minute,@reminder_schedule_hour,@reminder_schedule_day_of_month," + _
            "@reminder_schedule_month,@reminder_schedule_weekday,@reminder_schedule_end_date,@reminder_status," + _
            "@reminder_date_added,@ayinsongunucalissinmi)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@reminder_name", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If remindersetting.reminder_name = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = remindersetting.reminder_name
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@reminder_schedule_minute", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If remindersetting.reminder_schedule_minute = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = remindersetting.reminder_schedule_minute
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@reminder_schedule_hour", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If remindersetting.reminder_schedule_hour = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = remindersetting.reminder_schedule_hour
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@reminder_schedule_day_of_month", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If remindersetting.reminder_schedule_day_of_month = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = remindersetting.reminder_schedule_day_of_month
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@reminder_schedule_month", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If remindersetting.reminder_schedule_month = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = remindersetting.reminder_schedule_month
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@reminder_schedule_weekday", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If remindersetting.reminder_schedule_weekday = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = remindersetting.reminder_schedule_weekday
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@reminder_schedule_end_date", SqlDbType.DateTime)
            param8.Direction = ParameterDirection.Input
            If remindersetting.reminder_schedule_end_date Is Nothing Or remindersetting.reminder_schedule_end_date = "00:00:00" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = remindersetting.reminder_schedule_end_date
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@reminder_status", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If remindersetting.reminder_status = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = remindersetting.reminder_status
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@reminder_date_added", SqlDbType.DateTime)
            param10.Direction = ParameterDirection.Input
            If remindersetting.reminder_date_added Is Nothing Or remindersetting.reminder_date_added = "00:00:00" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = remindersetting.reminder_date_added
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@ayinsongunucalissinmi", SqlDbType.VarChar)
            param11.Direction = ParameterDirection.Input
            If remindersetting.ayinsongunucalissinmi = "" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = remindersetting.ayinsongunucalissinmi
            End If
            komut.Parameters.Add(param11)

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
        sqlstr = "select max(pkey) from remindersetting"
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
    Function Duzenle(ByVal remindersetting As CLASSREMINDERSETTING) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update remindersetting set " + _
        "reminder_name=@reminder_name," + _
        "reminder_schedule_minute=@reminder_schedule_minute," + _
        "reminder_schedule_hour=@reminder_schedule_hour," + _
        "reminder_schedule_day_of_month=@reminder_schedule_day_of_month," + _
        "reminder_schedule_month=@reminder_schedule_month," + _
        "reminder_schedule_weekday=@reminder_schedule_weekday," + _
        "reminder_schedule_end_date=@reminder_schedule_end_date," + _
        "reminder_status=@reminder_status," + _
        "reminder_date_added=@reminder_date_added," + _
        "ayinsongunucalissinmi=@ayinsongunucalissinmi" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = remindersetting.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@reminder_name", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If remindersetting.reminder_name = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = remindersetting.reminder_name
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@reminder_schedule_minute", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If remindersetting.reminder_schedule_minute = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = remindersetting.reminder_schedule_minute
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@reminder_schedule_hour", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If remindersetting.reminder_schedule_hour = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = remindersetting.reminder_schedule_hour
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@reminder_schedule_day_of_month", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If remindersetting.reminder_schedule_day_of_month = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = remindersetting.reminder_schedule_day_of_month
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@reminder_schedule_month", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If remindersetting.reminder_schedule_month = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = remindersetting.reminder_schedule_month
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@reminder_schedule_weekday", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If remindersetting.reminder_schedule_weekday = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = remindersetting.reminder_schedule_weekday
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@reminder_schedule_end_date", SqlDbType.DateTime)
        param8.Direction = ParameterDirection.Input
        If remindersetting.reminder_schedule_end_date Is Nothing Or remindersetting.reminder_schedule_end_date = "00:00:00" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = remindersetting.reminder_schedule_end_date
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@reminder_status", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If remindersetting.reminder_status = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = remindersetting.reminder_status
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@reminder_date_added", SqlDbType.DateTime)
        param10.Direction = ParameterDirection.Input
        If remindersetting.reminder_date_added Is Nothing Or remindersetting.reminder_date_added = "00:00:00" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = remindersetting.reminder_date_added
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@ayinsongunucalissinmi", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If remindersetting.ayinsongunucalissinmi = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = remindersetting.ayinsongunucalissinmi
        End If
        komut.Parameters.Add(param11)


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
    Function bultek(ByVal pkey As String) As CLASSREMINDERSETTING

        Dim komut As New SqlCommand
        Dim donecekremindersetting As New CLASSREMINDERSETTING()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from remindersetting where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekremindersetting.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("reminder_name") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_name = veri.Item("reminder_name")
                End If

                If Not veri.Item("reminder_schedule_minute") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_minute = veri.Item("reminder_schedule_minute")
                End If

                If Not veri.Item("reminder_schedule_hour") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_hour = veri.Item("reminder_schedule_hour")
                End If

                If Not veri.Item("reminder_schedule_day_of_month") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_day_of_month = veri.Item("reminder_schedule_day_of_month")
                End If

                If Not veri.Item("reminder_schedule_month") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_month = veri.Item("reminder_schedule_month")
                End If

                If Not veri.Item("reminder_schedule_weekday") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_weekday = veri.Item("reminder_schedule_weekday")
                End If

                If Not veri.Item("reminder_schedule_end_date") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_end_date = veri.Item("reminder_schedule_end_date")
                End If

                If Not veri.Item("reminder_status") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_status = veri.Item("reminder_status")
                End If

                If Not veri.Item("reminder_date_added") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_date_added = veri.Item("reminder_date_added")
                End If

                If Not veri.Item("ayinsongunucalissinmi") Is System.DBNull.Value Then
                    donecekremindersetting.ayinsongunucalissinmi = veri.Item("ayinsongunucalissinmi")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekremindersetting

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM

        Dim varmi As String
        Dim varmi2 As String

        varmi = manuelrapor_erisim.zamanlamavarmi(pkey)
        varmi2 = dinamikraporzamanlama_erisim.remindersettingvarmi(pkey)


        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu zamanlama ayarını kullanan manuel raporlar var."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu zamanlama ayarını kullanan dinamik raporlar var."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from remindersetting where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSREMINDERSETTING)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekremindersetting As New CLASSREMINDERSETTING
        Dim remindersettingler As New List(Of CLASSREMINDERSETTING)
        komut.Connection = db_baglanti
        sqlstr = "select * from remindersetting"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekremindersetting.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("reminder_name") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_name = veri.Item("reminder_name")
                End If

                If Not veri.Item("reminder_schedule_minute") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_minute = veri.Item("reminder_schedule_minute")
                End If

                If Not veri.Item("reminder_schedule_hour") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_hour = veri.Item("reminder_schedule_hour")
                End If

                If Not veri.Item("reminder_schedule_day_of_month") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_day_of_month = veri.Item("reminder_schedule_day_of_month")
                End If

                If Not veri.Item("reminder_schedule_month") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_month = veri.Item("reminder_schedule_month")
                End If

                If Not veri.Item("reminder_schedule_weekday") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_weekday = veri.Item("reminder_schedule_weekday")
                End If

                If Not veri.Item("reminder_schedule_end_date") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_schedule_end_date = veri.Item("reminder_schedule_end_date")
                End If

                If Not veri.Item("reminder_status") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_status = veri.Item("reminder_status")
                End If

                If Not veri.Item("reminder_date_added") Is System.DBNull.Value Then
                    donecekremindersetting.reminder_date_added = veri.Item("reminder_date_added")
                End If

                If Not veri.Item("ayinsongunucalissinmi") Is System.DBNull.Value Then
                    donecekremindersetting.ayinsongunucalissinmi = veri.Item("ayinsongunucalissinmi")
                End If


                remindersettingler.Add(New CLASSREMINDERSETTING(donecekremindersetting.pkey, _
                donecekremindersetting.reminder_name, donecekremindersetting.reminder_schedule_minute, donecekremindersetting.reminder_schedule_hour, donecekremindersetting.reminder_schedule_day_of_month, _
                donecekremindersetting.reminder_schedule_month, donecekremindersetting.reminder_schedule_weekday, donecekremindersetting.reminder_schedule_end_date, donecekremindersetting.reminder_status, _
                donecekremindersetting.reminder_date_added, donecekremindersetting.ayinsongunucalissinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return remindersettingler

    End Function

  

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11 As String
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
        "<th>Adı</th>" + _
        "<th>Dakika</th>" + _
        "<th>Saat</th>" + _
        "<th>Ayın Hangi Günleri</th>" + _
        "<th>Yılın Hangi Ayları</th>" + _
        "<th>Haftanın Hangi Günleri</th>" + _
        "<th>Bitiş Tarihi</th>" + _
        "<th>Durumu</th>" + _
        "<th>Eklenme Tarihi</th>" + _
        "<th>Ayın Son Günü Çalışsın mı?</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from remindersetting"
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)

        girdi = "0"
        Dim link As String
        Dim pkey, reminder_name, reminder_schedule_minute, reminder_schedule_hour As String
        Dim reminder_schedule_day_of_month, reminder_schedule_month, reminder_schedule_weekday As String
        Dim reminder_schedule_end_date, reminder_status, reminder_date_added, ayinsongunucalissinmi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "remindersetting.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    Else
                        kol1 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_name") Is System.DBNull.Value Then
                        reminder_name = veri.Item("reminder_name")
                        kol2 = "<td>" + reminder_name + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_schedule_minute") Is System.DBNull.Value Then
                        reminder_schedule_minute = veri.Item("reminder_schedule_minute")
                        kol3 = "<td>" + reminder_schedule_minute + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_schedule_hour") Is System.DBNull.Value Then
                        reminder_schedule_hour = veri.Item("reminder_schedule_hour")
                        kol4 = "<td>" + reminder_schedule_hour + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_schedule_day_of_month") Is System.DBNull.Value Then
                        reminder_schedule_day_of_month = veri.Item("reminder_schedule_day_of_month")
                        kol5 = "<td>" + reminder_schedule_day_of_month + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_schedule_month") Is System.DBNull.Value Then
                        reminder_schedule_month = veri.Item("reminder_schedule_month")
                        kol6 = "<td>" + reminder_schedule_month + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_schedule_weekday") Is System.DBNull.Value Then
                        reminder_schedule_weekday = veri.Item("reminder_schedule_weekday")
                        kol7 = "<td>" + reminder_schedule_weekday + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_schedule_end_date") Is System.DBNull.Value Then
                        reminder_schedule_end_date = veri.Item("reminder_schedule_end_date")
                        kol8 = "<td>" + reminder_schedule_end_date + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_status") Is System.DBNull.Value Then
                        reminder_status = veri.Item("reminder_status")
                        kol9 = "<td>" + reminder_status + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    If Not veri.Item("reminder_date_added") Is System.DBNull.Value Then
                        reminder_date_added = veri.Item("reminder_date_added")
                        kol10 = "<td>" + reminder_date_added + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If

                    If Not veri.Item("ayinsongunucalissinmi") Is System.DBNull.Value Then
                        ayinsongunucalissinmi = veri.Item("ayinsongunucalissinmi")
                        kol11 = "<td>" + ayinsongunucalissinmi + "</td></tr>"
                    Else
                        kol11 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11

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

        sqlstr = "select * from remindersetting where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
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


    'BU FONKSİYON EVET YADA HAYIR GÖNDERECEK KOŞULLARIN SAĞLANMA DURUMUNA GÖRE
    Public Function dogrulama(ByVal remindersetting As CLASSREMINDERSETTING) As String

        Dim donecek As String = "Hayır"

        Dim dakikastr, saatstr, ayinhangigunustr, yilinhangiayistr, haftaninhangigunustr As String
        Dim enddatekosul As String
        Dim dakikakosul, saatkosul, ayinhangigunukosul, yilinhangiayikosul, haftaninhangigunukosul As String
        Dim ayinsongunukosul As String

        enddatekosul = "Hayır"
        dakikakosul = "Hayır"
        saatkosul = "Hayır"
        ayinhangigunukosul = "Hayır"
        yilinhangiayikosul = "Hayır"
        haftaninhangigunukosul = "Hayır"
        ayinsongunukosul = "Hayır"


        dakikastr = remindersetting.reminder_schedule_minute
        saatstr = remindersetting.reminder_schedule_hour
        ayinhangigunustr = remindersetting.reminder_schedule_day_of_month
        yilinhangiayistr = remindersetting.reminder_schedule_month
        haftaninhangigunustr = remindersetting.reminder_schedule_weekday

        'VERİTANINDAKİ DEĞERLERİN ARRAY Lİ HALİ
        Dim dakikalar As String() = dakikastr.Split((New Char() {","c}))
        Dim saatler As String() = saatstr.Split(New Char() {","c})
        Dim ayinhangigunleri As String() = ayinhangigunustr.Split(New Char() {","c})
        Dim yilinhangiaylari As String() = yilinhangiayistr.Split(New Char() {","c})
        Dim haftaninhangigunleri As String() = haftaninhangigunustr.Split(New Char() {","c})


        'VERİTABANINDAKİ DEĞERLERİ INTEGER ARRAY INE ÇEVİRMEK İÇİN GEREKLİ TANIMLAMALAR
        Dim i As Integer = 0
        Dim dakikalarinteger(dakikalar.Count - 1) As Integer
        Dim saatlerinteger(saatler.Count - 1) As Integer
        Dim ayinhangigunleriinteger(ayinhangigunleri.Count - 1) As Integer
        Dim yilinhangiaylariinteger(yilinhangiaylari.Count - 1) As Integer
        Dim haftaninhangigunleriinteger(haftaninhangigunleri.Count - 1) As Integer


        'END DATE KONTROLÜ YAP 
        If remindersetting.reminder_schedule_end_date <> "00:00:00" Then
            If remindersetting.reminder_schedule_end_date < DateTime.Now Then
                Return "Hayır"
            End If
        End If


        'AKTIF KONTROLÜ YAP 
        If remindersetting.reminder_status = "Hayır" Then
            Return "Hayır"
        End If

        'DAKİKAKALARI INTEGER A ÇEVİRDİN
        For Each itemdakika As String In dakikalar
            If itemdakika <> "*" Then
                dakikalarinteger(i) = CInt(itemdakika)
            End If
            i = i + 1
        Next
        i = 0
        'SAATLERİ INTEGER A ÇEVİRDİN
        For Each itemsaat As String In saatler
            If itemsaat <> "*" Then
                saatlerinteger(i) = CInt(itemsaat)
            End If
            i = i + 1
        Next
        i = 0
        'AYIN HANGİ GÜNLERİ INTEGER A ÇEVİRDİN
        For Each itemayinhangigunleri As String In ayinhangigunleri
            If itemayinhangigunleri <> "*" Then
                ayinhangigunleriinteger(i) = CInt(itemayinhangigunleri)
            End If
            i = i + 1
        Next
        i = 0
        'YILIN HANGİ AYLARI INTEGER A ÇEVİRDİN
        For Each itemyilinhangiaylari As String In yilinhangiaylari
            If itemyilinhangiaylari <> "*" Then
                yilinhangiaylariinteger(i) = CInt(itemyilinhangiaylari)
            End If

            i = i + 1
        Next
        i = 0
        'HAFTANIN HANGİ GÜNLERİ INTEGER A ÇEVİRDİN
        For Each itemhaftaninhangigunleri As String In haftaninhangigunleri
            If itemhaftaninhangigunleri <> "*" Then
                haftaninhangigunleriinteger(i) = CInt(itemhaftaninhangigunleri)
            End If
            i = i + 1
        Next

        Dim simdi As DateTime
        simdi = DateTime.Now
        Dim simdiay As Integer
        Dim simdisaat As Integer
        Dim simdidakika As Integer
        Dim simdikiayinhangigunu As Integer
        Dim simdikiyilinhangiayi As Integer
        Dim simdikihafataninhangigunu As Integer

        simdiay = simdi.Month
        simdisaat = simdi.Hour
        simdidakika = simdi.Minute
        simdikiayinhangigunu = simdi.Day
        simdikiyilinhangiayi = simdi.Month
        simdikihafataninhangigunu = simdi.DayOfWeek


        '--KONTROL ET DEĞERLERİ -----------------------------
        'dakika kosulu string olanlar
        i = 0
        For Each dakikatek As String In dakikalar
            If dakikatek = "*" Then
                dakikakosul = "Evet"
            End If
            If dakikalarinteger(i) = simdidakika Then
                dakikakosul = "Evet"
            End If
            i = i + 1
        Next

        'saat kosulu string olanlar
        i = 0
        For Each saattek As String In saatler
            If saattek = "*" Then
                saatkosul = "Evet"
            End If
            If saatlerinteger(i) = simdisaat Then
                saatkosul = "Evet"
            End If
            i = i + 1
        Next

        'ayinhangigunleri kosulu string olanlar
        i = 0
        For Each ayinhangigunleritek As String In ayinhangigunleri
            If ayinhangigunleritek = "*" Then
                ayinhangigunukosul = "Evet"
            End If
            If ayinhangigunleriinteger(i) = simdikiayinhangigunu Then
                ayinhangigunukosul = "Evet"
            End If
            i = i + 1
        Next

        'yilinhangiaylari kosulu string olanlar
        i = 0
        For Each yilinhangiaylaritek As String In yilinhangiaylari
            If yilinhangiaylaritek = "*" Then
                yilinhangiayikosul = "Evet"
            End If
            If yilinhangiaylariinteger(i) = simdikiyilinhangiayi Then
                yilinhangiayikosul = "Evet"
            End If
            i = i + 1
        Next

        'haftaninhangigunleri kosulu string olanlar
        i = 0
        For Each haftaninhangigunleritek As String In haftaninhangigunleri
            If haftaninhangigunleritek = "*" Then
                haftaninhangigunukosul = "Evet"
            End If
            If haftaninhangigunleriinteger(i) = simdikihafataninhangigunu Then
                haftaninhangigunukosul = "Evet"
            End If
            i = i + 1
        Next


        'en son tüm kosullar saglıyorsa "Evet" döndür.
        If dakikakosul = "Evet" And saatkosul = "Evet" And ayinhangigunukosul = "Evet" _
        And yilinhangiayikosul = "Evet" And haftaninhangigunukosul = "Evet" Then
            donecek = "Evet"
        Else
            donecek = "Hayır"
        End If

        'üstteki tüm koşulları sağlıyorsa
        If donecek = "Evet" Then
            've ayin son günüde çalışaması isteniyorsa
            If remindersetting.ayinsongunucalissinmi = "Evet" Then
                Dim original As Date = Date.Now ' The date you want to get the last day of the month for
                Dim lastOfMonth As Date = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1)
                'ayın son günü ise
                If original.Date = lastOfMonth.Date Then
                    donecek = "Evet"
                End If
            End If
        End If


        Return donecek

    End Function


End Class


