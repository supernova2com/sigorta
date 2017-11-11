Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSDINAMIKRAPORZAMANLAMA_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dinamikraporzamanlama As CLASSDINAMIKRAPORZAMANLAMA) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(dinamikraporzamanlama.raporpkey, dinamikraporzamanlama.remindersettingpkey)

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
            sqlstr = "insert into dinamikraporzamanlama values (@pkey," + _
            "@raporpkey,@remindersettingpkey,@zamanlamaad)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If dinamikraporzamanlama.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = dinamikraporzamanlama.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If dinamikraporzamanlama.remindersettingpkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = dinamikraporzamanlama.remindersettingpkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@zamanlamaad", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If dinamikraporzamanlama.zamanlamaad = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = dinamikraporzamanlama.zamanlamaad
            End If
            komut.Parameters.Add(param4)

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
        sqlstr = "select max(pkey) from dinamikraporzamanlama"
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
    Function Duzenle(ByVal dinamikraporzamanlama As CLASSDINAMIKRAPORZAMANLAMA) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update dinamikraporzamanlama set " + _
        "raporpkey=@raporpkey," + _
        "remindersettingpkey=@remindersettingpkey," + _
        "zamanlamaad=@zamanlamaad" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dinamikraporzamanlama.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dinamikraporzamanlama.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = dinamikraporzamanlama.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If dinamikraporzamanlama.remindersettingpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = dinamikraporzamanlama.remindersettingpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@zamanlamaad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dinamikraporzamanlama.zamanlamaad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dinamikraporzamanlama.zamanlamaad
        End If
        komut.Parameters.Add(param4)

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
    Function bultek(ByVal pkey As String) As CLASSDINAMIKRAPORZAMANLAMA

        Dim komut As New SqlCommand
        Dim donecekdinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporzamanlama where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                If Not veri.Item("zamanlamaad") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.zamanlamaad = veri.Item("zamanlamaad")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdinamikraporzamanlama

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        'bak baklalım kullanıcı erişimde bu zamanlama tanımlanmış mı 
        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
        dinamikraporzamanlama = bultek(pkey)


        Dim varmi As String = dinamikkullanicibag_erisim.zamanlamavarmi(dinamikraporzamanlama.raporpkey, pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu zamanlama ayarı kullanıcı erişiminde kullanıldığından " + _
            "silemezsiniz."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from dinamikraporzamanlama where pkey=@pkey"
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

        Return resultset

    End Function


    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT

        'bak baklalım kullanıcı erişimde bu zamanlama tanımlanmış mı 
        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        Dim dinamikkullanicibaglar As New List(Of CLASSDINAMIKKULLANICIBAG)
      
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikraporzamanlama where raporpkey=@raporpkey"
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
    Public Function doldur() As List(Of CLASSDINAMIKRAPORZAMANLAMA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
        Dim dinamikraporzamanlamaler As New List(Of CLASSDINAMIKRAPORZAMANLAMA)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikraporzamanlama"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                If Not veri.Item("zamanlamaad") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.zamanlamaad = veri.Item("zamanlamaad")
                End If

                dinamikraporzamanlamaler.Add(New CLASSDINAMIKRAPORZAMANLAMA(donecekdinamikraporzamanlama.pkey, _
                donecekdinamikraporzamanlama.raporpkey, donecekdinamikraporzamanlama.remindersettingpkey, _
                donecekdinamikraporzamanlama.zamanlamaad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporzamanlamaler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function dolduriligili(ByVal raporpkey As String) As List(Of CLASSDINAMIKRAPORZAMANLAMA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
        Dim dinamikraporzamanlamaler As New List(Of CLASSDINAMIKRAPORZAMANLAMA)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikraporzamanlama where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                If Not veri.Item("zamanlamaad") Is System.DBNull.Value Then
                    donecekdinamikraporzamanlama.zamanlamaad = veri.Item("zamanlamaad")
                End If

                dinamikraporzamanlamaler.Add(New CLASSDINAMIKRAPORZAMANLAMA(donecekdinamikraporzamanlama.pkey, _
                donecekdinamikraporzamanlama.raporpkey, donecekdinamikraporzamanlama.remindersettingpkey, _
                donecekdinamikraporzamanlama.zamanlamaad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporzamanlamaler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim tabloson, pager As String
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
        "<th>Zamanlama Adı</th>" + _
        "<th>Zamanlama (Tanımlanmış)</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from dinamikraporzamanlama where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey, remindersettingpkey, dakikainterval As String
        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim ajaxlinksil, dugmesil As String

        Dim remindersetting As New CLASSREMINDERSETTING
        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
        Dim zamanlamaad As String

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
                        "&dinamikraporzamanlamaop=duzenle" + _
                        "&dinamikraporzamanlamapkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("zamanlamaad") Is System.DBNull.Value Then
                        zamanlamaad = veri.Item("zamanlamaad")
                        kol3 = "<td>" + zamanlamaad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                        remindersettingpkey = veri.Item("remindersettingpkey")
                        remindersetting = remindersetting_erisim.bultek(remindersettingpkey)
                        kol4 = "<td>" + remindersetting.reminder_name + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "dinamikraporzamanlamasil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='dinamikraporzamanlamasilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol5 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5
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
    Function ciftkayitkontrol(ByVal raporpkey As String, ByVal remindersettingpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporzamanlama where " + _
        "raporpkey=@raporpkey and remindersettingpkey=@remindersettingpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = remindersettingpkey
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function



    Function remindersettingvarmi(ByVal remindersettingpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporzamanlama where remindersettingpkey=@remindersettingpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = remindersettingpkey
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
