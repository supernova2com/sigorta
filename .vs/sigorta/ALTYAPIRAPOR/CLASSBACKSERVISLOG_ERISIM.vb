Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data


Public Class CLASSBACKSERVISLOG_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim backservislog As New CLASSBACKSERVISLOG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal backservislog As CLASSBACKSERVISLOG) As CLADBOPRESULT

        etkilenen = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into backservislog values (@pkey," + _
        "@soncalistarih,@dinamikkullanicibagpkey,@zamanlamapkey,@ne)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        sqlstr = "insert into backservislog values (@pkey," + _
        "@soncalistarih,@dinamikkullanicibagpkey,@remindersettingpkey,@ne," + _
        "@calismasure,@bitistarih,@yontem,@emaildurum," + _
        "@emailhatatxt,@emailetkilenen,@gonderilenkullanicipkey)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@soncalistarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If backservislog.soncalistarih Is Nothing Or backservislog.soncalistarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = backservislog.soncalistarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dinamikkullanicibagpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If backservislog.dinamikkullanicibagpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = backservislog.dinamikkullanicibagpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If backservislog.remindersettingpkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = backservislog.remindersettingpkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ne", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If backservislog.ne = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = backservislog.ne
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@calismasure", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If backservislog.calismasure = 0 Then
            param6.Value = 0
        Else
            param6.Value = backservislog.calismasure
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@bitistarih", SqlDbType.DateTime)
        param7.Direction = ParameterDirection.Input
        If backservislog.bitistarih Is Nothing Or backservislog.bitistarih = "00:00:00" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = backservislog.bitistarih
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@yontem", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If backservislog.yontem = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = backservislog.yontem
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@emaildurum", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If backservislog.emaildurum = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = backservislog.emaildurum
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@emailhatatxt", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If backservislog.emailhatatxt = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = backservislog.emailhatatxt
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@emailetkilenen", SqlDbType.Int)
        param11.Direction = ParameterDirection.Input
        If backservislog.emailetkilenen = 0 Then
            param11.Value = 0
        Else
            param11.Value = backservislog.emailetkilenen
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@gonderilenkullanicipkey", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        If backservislog.gonderilenkullanicipkey = 0 Then
            param12.Value = 0
        Else
            param12.Value = backservislog.gonderilenkullanicipkey
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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from backservislog"
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
    Function Duzenle(ByVal backservislog As CLASSBACKSERVISLOG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update backservislog set " + _
        "soncalistarih=@soncalistarih," + _
        "dinamikkullanicibagpkey=@dinamikkullanicibagpkey," + _
        "remindersettingpkey=@remindersettingpkey," + _
        "ne=@ne," + _
        "calismasure=@calismasure," + _
        "bitistarih=@bitistarih," + _
        "yontem=@yontem," + _
        "emaildurum=@emaildurum," + _
        "emailhatatxt=@emailhatatxt," + _
        "emailetkilenen=@emailetkilenen," + _
        "gonderilenkullanicipkey=@gonderilenkullanicipkey" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = backservislog.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@soncalistarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If backservislog.soncalistarih Is Nothing Or backservislog.soncalistarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = backservislog.soncalistarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dinamikkullanicibagpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If backservislog.dinamikkullanicibagpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = backservislog.dinamikkullanicibagpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If backservislog.remindersettingpkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = backservislog.remindersettingpkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ne", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If backservislog.ne = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = backservislog.ne
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@calismasure", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If backservislog.calismasure = 0 Then
            param6.Value = 0
        Else
            param6.Value = backservislog.calismasure
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@bitistarih", SqlDbType.DateTime)
        param7.Direction = ParameterDirection.Input
        If backservislog.bitistarih Is Nothing Or backservislog.bitistarih = "00:00:00" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = backservislog.bitistarih
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@yontem", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If backservislog.yontem = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = backservislog.yontem
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@emaildurum", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If backservislog.emaildurum = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = backservislog.emaildurum
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@emailhatatxt", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If backservislog.emailhatatxt = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = backservislog.emailhatatxt
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@emailetkilenen", SqlDbType.Int)
        param11.Direction = ParameterDirection.Input
        If backservislog.emailetkilenen = 0 Then
            param11.Value = 0
        Else
            param11.Value = backservislog.emailetkilenen
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@gonderilenkullanicipkey", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        If backservislog.gonderilenkullanicipkey = 0 Then
            param12.Value = 0
        Else
            param12.Value = backservislog.gonderilenkullanicipkey
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
    Function bultek(ByVal pkey As String) As CLASSBACKSERVISLOG

        Dim komut As New SqlCommand
        Dim donecekbackservislog As New CLASSBACKSERVISLOG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from backservislog where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbackservislog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("soncalistarih") Is System.DBNull.Value Then
                    donecekbackservislog.soncalistarih = veri.Item("soncalistarih")
                End If

                If Not veri.Item("dinamikkullanicibagpkey") Is System.DBNull.Value Then
                    donecekbackservislog.dinamikkullanicibagpkey = veri.Item("dinamikkullanicibagpkey")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekbackservislog.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                If Not veri.Item("ne") Is System.DBNull.Value Then
                    donecekbackservislog.ne = veri.Item("ne")
                End If

                If Not veri.Item("calismasure") Is System.DBNull.Value Then
                    donecekbackservislog.calismasure = veri.Item("calismasure")
                End If

                If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                    donecekbackservislog.bitistarih = veri.Item("bitistarih")
                End If

                If Not veri.Item("yontem") Is System.DBNull.Value Then
                    donecekbackservislog.yontem = veri.Item("yontem")
                End If

                If Not veri.Item("emaildurum") Is System.DBNull.Value Then
                    donecekbackservislog.emaildurum = veri.Item("emaildurum")
                End If

                If Not veri.Item("emailhatatxt") Is System.DBNull.Value Then
                    donecekbackservislog.emailhatatxt = veri.Item("emailhatatxt")
                End If

                If Not veri.Item("emailetkilenen") Is System.DBNull.Value Then
                    donecekbackservislog.emailetkilenen = veri.Item("emailetkilenen")
                End If

                If Not veri.Item("gonderilenkullanicipkey") Is System.DBNull.Value Then
                    donecekbackservislog.gonderilenkullanicipkey = veri.Item("gonderilenkullanicipkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbackservislog

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bul_dinamikkullanicibagpkeyegore(ByVal dinamikkullanicibagpkey As String) As CLASSBACKSERVISLOG

        Dim komut As New SqlCommand
        Dim donecekbackservislog As New CLASSBACKSERVISLOG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from backservislog where dinamikkullanicibagpkey=@dinamikkullanicibagpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@dinamikkullanicibagpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dinamikkullanicibagpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbackservislog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("soncalistarih") Is System.DBNull.Value Then
                    donecekbackservislog.soncalistarih = veri.Item("soncalistarih")
                End If

                If Not veri.Item("dinamikkullanicibagpkey") Is System.DBNull.Value Then
                    donecekbackservislog.dinamikkullanicibagpkey = veri.Item("dinamikkullanicibagpkey")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekbackservislog.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                If Not veri.Item("ne") Is System.DBNull.Value Then
                    donecekbackservislog.ne = veri.Item("ne")
                End If

                If Not veri.Item("calismasure") Is System.DBNull.Value Then
                    donecekbackservislog.calismasure = veri.Item("calismasure")
                End If

                If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                    donecekbackservislog.bitistarih = veri.Item("bitistarih")
                End If

                If Not veri.Item("yontem") Is System.DBNull.Value Then
                    donecekbackservislog.yontem = veri.Item("yontem")
                End If

                If Not veri.Item("emaildurum") Is System.DBNull.Value Then
                    donecekbackservislog.emaildurum = veri.Item("emaildurum")
                End If

                If Not veri.Item("emailhatatxt") Is System.DBNull.Value Then
                    donecekbackservislog.emailhatatxt = veri.Item("emailhatatxt")
                End If

                If Not veri.Item("emailetkilenen") Is System.DBNull.Value Then
                    donecekbackservislog.emailetkilenen = veri.Item("emailetkilenen")
                End If

                If Not veri.Item("gonderilenkullanicipkey") Is System.DBNull.Value Then
                    donecekbackservislog.gonderilenkullanicipkey = veri.Item("gonderilenkullanicipkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbackservislog

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from backservislog where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSBACKSERVISLOG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbackservislog As New CLASSBACKSERVISLOG
        Dim backservislogler As New List(Of CLASSBACKSERVISLOG)
        komut.Connection = db_baglanti
        sqlstr = "select * from backservislog"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbackservislog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("soncalistarih") Is System.DBNull.Value Then
                    donecekbackservislog.soncalistarih = veri.Item("soncalistarih")
                End If

                If Not veri.Item("dinamikkullanicibagpkey") Is System.DBNull.Value Then
                    donecekbackservislog.dinamikkullanicibagpkey = veri.Item("dinamikkullanicibagpkey")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekbackservislog.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                If Not veri.Item("ne") Is System.DBNull.Value Then
                    donecekbackservislog.ne = veri.Item("ne")
                End If

                If Not veri.Item("calismasure") Is System.DBNull.Value Then
                    donecekbackservislog.calismasure = veri.Item("calismasure")
                End If

                If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                    donecekbackservislog.bitistarih = veri.Item("bitistarih")
                End If

                If Not veri.Item("yontem") Is System.DBNull.Value Then
                    donecekbackservislog.yontem = veri.Item("yontem")
                End If

                If Not veri.Item("emaildurum") Is System.DBNull.Value Then
                    donecekbackservislog.emaildurum = veri.Item("emaildurum")
                End If

                If Not veri.Item("emailhatatxt") Is System.DBNull.Value Then
                    donecekbackservislog.emailhatatxt = veri.Item("emailhatatxt")
                End If

                If Not veri.Item("emailetkilenen") Is System.DBNull.Value Then
                    donecekbackservislog.emailetkilenen = veri.Item("emailetkilenen")
                End If

                If Not veri.Item("gonderilenkullanicipkey") Is System.DBNull.Value Then
                    donecekbackservislog.gonderilenkullanicipkey = veri.Item("gonderilenkullanicipkey")
                End If


                backservislogler.Add(New CLASSBACKSERVISLOG(donecekbackservislog.pkey, _
                donecekbackservislog.soncalistarih, donecekbackservislog.dinamikkullanicibagpkey, _
                donecekbackservislog.remindersettingpkey, donecekbackservislog.ne, _
                donecekbackservislog.calismasure, donecekbackservislog.bitistarih, _
                donecekbackservislog.yontem, donecekbackservislog.emaildurum, _
                donecekbackservislog.emailhatatxt, donecekbackservislog.emailetkilenen, _
                donecekbackservislog.gonderilenkullanicipkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return backservislogler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
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
        "<th>Çalışma Başlangıç ve Bitiş Tarihi</th>" + _
        "<th>Rapor Adı</th>" + _
        "<th>Reminder Setting Adı</th>" + _
        "<th>Çalışma Süresi</th>" + _
        "<th>Kullanıcı Adı</th>" + _
        "<th>E-Posta Durumu</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from backservislog order by soncalistarih desc"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, soncalistarih, dinamikkullanicibagpkey, ne As String
        Dim emaildurum, emailhatatxt, emailetkilenen, gonderilenkullanicipkey As String
        Dim calismasure, emailstr, bitistarih As String
        Dim ajaxlinksil, dugmesil As String


        Dim emailgonderilenkullanici As New CLASSKULLANICI
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_Erisim As New CLASSDINAMIKRAPOR_ERISIM

        Dim dinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
        Dim dinamikraporzamanlama_Erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM

        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
        Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG

        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
        Dim remindersetting As New CLASSREMINDERSETTING

        Dim remindersettingpkey As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "backservislog.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("soncalistarih") Is System.DBNull.Value Then
                        soncalistarih = veri.Item("soncalistarih")
                    Else
                        soncalistarih = "-"
                    End If

                    If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                        bitistarih = veri.Item("bitistarih")
                    Else
                        bitistarih = "-"
                    End If
                    kol2 = "<tr><td>" + soncalistarih + "/" + bitistarih + "</td>"


                    If Not veri.Item("dinamikkullanicibagpkey") Is System.DBNull.Value Then
                        dinamikkullanicibagpkey = veri.Item("dinamikkullanicibagpkey")
                        dinamikkullanicibag = dinamikkullanicibag_erisim.bultek(dinamikkullanicibagpkey)
                        dinamikrapor = dinamikrapor_Erisim.bultek(dinamikkullanicibag.raporpkey)
                        kullanici = kullanici_erisim.bultek(dinamikkullanicibag.kullanicipkey)
                    End If

                    If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                        remindersettingpkey = veri.Item("remindersettingpkey")
                        remindersetting = remindersetting_erisim.bultek(remindersettingpkey)
                    End If

                    kol3 = "<td>" + dinamikrapor.raporad + "</td>"
                    kol4 = "<td>" + remindersetting.reminder_name + "</td>"


                    If Not veri.Item("calismasure") Is System.DBNull.Value Then
                        calismasure = veri.Item("calismasure")
                        kol5 = "<td>" + calismasure + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    kol6 = "<td>" + kullanici.adsoyad + "</td>"

                    If Not veri.Item("ne") Is System.DBNull.Value Then
                        ne = veri.Item("ne")
                        kol7 = "<td>" + ne + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If


                    'E-MAIL BİLGİLERİ ------------------------------------
                    If Not veri.Item("emaildurum") Is System.DBNull.Value Then
                        emaildurum = veri.Item("emaildurum")
                    Else
                        emaildurum = "-"
                    End If

                    If Not veri.Item("emailhatatxt") Is System.DBNull.Value Then
                        emailhatatxt = veri.Item("emailhatatxt")
                    Else
                        emailhatatxt = "-"
                    End If

                    If Not veri.Item("emailetkilenen") Is System.DBNull.Value Then
                        emailetkilenen = veri.Item("emailetkilenen")
                    Else
                        emailetkilenen = "-"
                    End If
                    If Not veri.Item("gonderilenkullanicipkey") Is System.DBNull.Value Then
                        gonderilenkullanicipkey = veri.Item("gonderilenkullanicipkey")
                        emailgonderilenkullanici = kullanici_erisim.bultek(gonderilenkullanicipkey)
                    End If
                    emailstr = "<b>E-Mail Gönderildi mi?<b> " + emaildurum + "<br/>" + _
                    "<b>E-Mail Hata:<b> " + emailhatatxt + "<br/>" + _
                    "<b>E-Mail Etkilenen:<b> " + emailetkilenen + "<br/>" + _
                    "<b>Gönderilen Kullanıcı:?<b> " + emailgonderilenkullanici.adsoyad + "<br/>" + _
                    kol8 = "<td>" + emailstr + "</td></tr>"


                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "backservislogsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='ozelraporsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol9 = "<td>" + dugmesil + "</td></tr>"


                    satir = satir + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function

    Public Function raporla() As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        Dim email As New CLASSEMAIL
        Dim email_erisim As New CLASSEMAIL_ERISIM
        Dim emailayar As New CLASSEMAILAYAR
        Dim emailayar_Erisim As New CLASSEMAILAYAR_ERISIM
        emailayar = emailayar_Erisim.bul(1)

        Dim rapor_erisim As New CLASSRAPOR_ERISIM
        Dim rapor As New CLASSRAPOR
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim backservislog As New CLASSBACKSERVISLOG
        Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
        Dim dinamikkullanicibaglar As New List(Of CLASSDINAMIKKULLANICIBAG)
        Dim dinamikkullanicibag_Erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM

        Dim dinamikraporzamanlamalar As New List(Of CLASSDINAMIKRAPORZAMANLAMA)
        Dim dinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
        Dim saatinterval As Integer
        Dim soncalismatarih As DateTime
        Dim ktarih As DateTime
        Dim bitistarih As DateTime
        Dim baslangictarih As DateTime
        Dim calismasure As TimeSpan


        Dim remindersetting As New CLASSREMINDERSETTING
        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM

        Dim dinamikraporlar As New List(Of CLASSDINAMIKRAPOR)
        dinamikraporlar = dinamikrapor_erisim.doldur

        For Each item As CLASSDINAMIKRAPOR In dinamikraporlar
            dinamikraporzamanlamalar = dinamikraporzamanlama_erisim.dolduriligili(item.pkey)
            For Each itemzamanlama As CLASSDINAMIKRAPORZAMANLAMA In dinamikraporzamanlamalar

                remindersetting = remindersetting_erisim.bultek(itemzamanlama.remindersettingpkey)
                'EĞER ZAMANLAMADA BU RAPOR GERÇEKTEN ÇALIŞTIRILMALIYSA
                If remindersetting_erisim.dogrulama(remindersetting) = "Evet" Then
                    dinamikkullanicibaglar = dinamikkullanicibag_Erisim.doldurilgili(item.pkey)
                    For Each itemdkullanicibag As CLASSDINAMIKKULLANICIBAG In dinamikkullanicibaglar
                        dinamikkullanicibag = dinamikkullanicibag_Erisim.bultek(itemdkullanicibag.pkey)
                        'e-posta gönder
                        If dinamikkullanicibag.otogonder = "Evet" And dinamikkullanicibag.epostagitsinmi = "Evet" Then

                            baslangictarih = DateTime.Now

                            dinamikrapor = dinamikrapor_erisim.bultek(itemdkullanicibag.raporpkey)
                            dinamikraporzamanlama = dinamikraporzamanlama_erisim.bultek(dinamikkullanicibag.zamanlamapkey)
                            backservislog = bul_dinamikkullanicibagpkeyegore(dinamikkullanicibag.pkey)
                            kullanici = kullanici_erisim.bultek(itemdkullanicibag.kullanicipkey)
                            baslangictarih = DateTime.Now

                            backservislog.soncalistarih = baslangictarih
                            backservislog.remindersettingpkey = remindersetting.pkey
                            backservislog.ne = dinamikrapor.raporad
                            backservislog.dinamikkullanicibagpkey = dinamikkullanicibag.pkey

                            rapor = dinamikrapor_erisim.raporolustur(itemdkullanicibag.raporpkey)

                            'E-MAIL GÖNDER-------------------------
                            Dim attachmentfile_path As String
                            If dinamikkullanicibag.entegredosyagitsinmi = "Evet" Then
                                attachmentfile_path = rapor_erisim.yazdirpdf("email", rapor)
                                email.attachmentfile = attachmentfile_path
                            End If

                            email.body = rapor.veri
                            email.kimden = emailayar.username
                            email.kime = kullanici.eposta
                            email.subject = rapor.baslik
                            result = email_erisim.gonder(email)

                            If dinamikkullanicibag.entegredosyagitsinmi = "Evet" Then
                                dosyayisil(attachmentfile_path)
                            End If
                            '----------------------------------------

                            'LOGLA ----------------------------------
                            bitistarih = DateTime.Now

                            calismasure = baslangictarih.Subtract(DateTime.Now)
                            backservislog.calismasure = calismasure.Seconds

                            backservislog.bitistarih = bitistarih
                            backservislog.yontem = "Servis"
                            backservislog.emaildurum = result.durum
                            backservislog.emailhatatxt = result.hatastr
                            backservislog.emailetkilenen = result.etkilenen
                            backservislog.gonderilenkullanicipkey = itemdkullanicibag.kullanicipkey
                            Ekle(backservislog)
                            '----------------------------------------

                        End If

                    Next 'kullanıcı bağları içinde dolaşıyor

                End If

            Next 'zamanlamalar içinde dolaşıyor

        Next 'dinamik raporların içinde dolaşıyor


        Return result

    End Function


    Public Function dosyayisil(ByVal path As String)

        Dim FileToDelete As String

        FileToDelete = path

        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If

    End Function


End Class

