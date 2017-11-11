Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSERRORLOG_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim errorlog As New CLASSERRORLOG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal errorlog As CLASSERRORLOG) As CLADBOPRESULT

        etkilenen = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into errorlog values (@pkey," + _
        "@kullanicipkey,@tarih,@exp_msg,@exp_source," + _
        "@exp_stacktrace,@exp_url,@okunmusmu,@emailgonderilmismi)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If errorlog.kullanicipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = errorlog.kullanicipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If errorlog.tarih Is Nothing Or errorlog.tarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = errorlog.tarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@exp_msg", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If errorlog.exp_msg = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = errorlog.exp_msg
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@exp_source", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If errorlog.exp_source = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = errorlog.exp_source
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@exp_stacktrace", SqlDbType.Text)
        param6.Direction = ParameterDirection.Input
        If errorlog.exp_stacktrace = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = errorlog.exp_stacktrace
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@exp_url", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If errorlog.exp_url = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = errorlog.exp_url
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If errorlog.okunmusmu = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = errorlog.okunmusmu
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@emailgonderilmismi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If errorlog.emailgonderilmismi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = errorlog.emailgonderilmismi
        End If
        komut.Parameters.Add(param9)

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
        sqlstr = "select max(pkey) from errorlog"
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
    Function Duzenle(ByVal errorlog As CLASSERRORLOG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update errorlog set " + _
        "kullanicipkey=@kullanicipkey," + _
        "tarih=@tarih," + _
        "exp_msg=@exp_msg," + _
        "exp_source=@exp_source," + _
        "exp_stacktrace=@exp_stacktrace," + _
        "exp_url=@exp_url," + _
        "okunmusmu=@okunmusmu," + _
        "emailgonderilmismi=@emailgonderilmismi" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = errorlog.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If errorlog.kullanicipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = errorlog.kullanicipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If errorlog.tarih Is Nothing Or errorlog.tarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = errorlog.tarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@exp_msg", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If errorlog.exp_msg = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = errorlog.exp_msg
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@exp_source", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If errorlog.exp_source = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = errorlog.exp_source
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@exp_stacktrace", SqlDbType.Text)
        param6.Direction = ParameterDirection.Input
        If errorlog.exp_stacktrace = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = errorlog.exp_stacktrace
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@exp_url", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If errorlog.exp_url = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = errorlog.exp_url
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If errorlog.okunmusmu = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = errorlog.okunmusmu
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@emailgonderilmismi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If errorlog.emailgonderilmismi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = errorlog.emailgonderilmismi
        End If
        komut.Parameters.Add(param9)


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
    Function bultek(ByVal pkey As String) As CLASSERRORLOG

        Dim komut As New SqlCommand
        Dim donecekerrorlog As New CLASSERRORLOG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from errorlog where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekerrorlog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekerrorlog.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekerrorlog.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("exp_msg") Is System.DBNull.Value Then
                    donecekerrorlog.exp_msg = veri.Item("exp_msg")
                End If

                If Not veri.Item("exp_source") Is System.DBNull.Value Then
                    donecekerrorlog.exp_source = veri.Item("exp_source")
                End If

                If Not veri.Item("exp_stacktrace") Is System.DBNull.Value Then
                    donecekerrorlog.exp_stacktrace = veri.Item("exp_stacktrace")
                End If

                If Not veri.Item("exp_url") Is System.DBNull.Value Then
                    donecekerrorlog.exp_url = veri.Item("exp_url")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekerrorlog.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("emailgonderilmismi") Is System.DBNull.Value Then
                    donecekerrorlog.emailgonderilmismi = veri.Item("emailgonderilmismi")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekerrorlog

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from errorlog where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSERRORLOG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekerrorlog As New CLASSERRORLOG
        Dim errorlogler As New List(Of CLASSERRORLOG)
        komut.Connection = db_baglanti
        sqlstr = "select * from errorlog"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekerrorlog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekerrorlog.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekerrorlog.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("exp_msg") Is System.DBNull.Value Then
                    donecekerrorlog.exp_msg = veri.Item("exp_msg")
                End If

                If Not veri.Item("exp_source") Is System.DBNull.Value Then
                    donecekerrorlog.exp_source = veri.Item("exp_source")
                End If

                If Not veri.Item("exp_stacktrace") Is System.DBNull.Value Then
                    donecekerrorlog.exp_stacktrace = veri.Item("exp_stacktrace")
                End If

                If Not veri.Item("exp_url") Is System.DBNull.Value Then
                    donecekerrorlog.exp_url = veri.Item("exp_url")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekerrorlog.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("emailgonderilmismi") Is System.DBNull.Value Then
                    donecekerrorlog.emailgonderilmismi = veri.Item("emailgonderilmismi")
                End If


                errorlogler.Add(New CLASSERRORLOG(donecekerrorlog.pkey, _
                donecekerrorlog.kullanicipkey, donecekerrorlog.tarih, donecekerrorlog.exp_msg, donecekerrorlog.exp_source, _
                donecekerrorlog.exp_stacktrace, donecekerrorlog.exp_url, donecekerrorlog.okunmusmu, donecekerrorlog.emailgonderilmismi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return errorlogler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurokunmamislar() As List(Of CLASSERRORLOG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekerrorlog As New CLASSERRORLOG
        Dim errorlogler As New List(Of CLASSERRORLOG)
        komut.Connection = db_baglanti
        sqlstr = "select * from errorlog where okunmusmu=@okunmusmu"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Hayır"
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekerrorlog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekerrorlog.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekerrorlog.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("exp_msg") Is System.DBNull.Value Then
                    donecekerrorlog.exp_msg = veri.Item("exp_msg")
                End If

                If Not veri.Item("exp_source") Is System.DBNull.Value Then
                    donecekerrorlog.exp_source = veri.Item("exp_source")
                End If

                If Not veri.Item("exp_stacktrace") Is System.DBNull.Value Then
                    donecekerrorlog.exp_stacktrace = veri.Item("exp_stacktrace")
                End If

                If Not veri.Item("exp_url") Is System.DBNull.Value Then
                    donecekerrorlog.exp_url = veri.Item("exp_url")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekerrorlog.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("emailgonderilmismi") Is System.DBNull.Value Then
                    donecekerrorlog.emailgonderilmismi = veri.Item("emailgonderilmismi")
                End If


                errorlogler.Add(New CLASSERRORLOG(donecekerrorlog.pkey, _
                donecekerrorlog.kullanicipkey, donecekerrorlog.tarih, donecekerrorlog.exp_msg, donecekerrorlog.exp_source, _
                donecekerrorlog.exp_stacktrace, donecekerrorlog.exp_url, donecekerrorlog.okunmusmu, donecekerrorlog.emailgonderilmismi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return errorlogler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR


        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12 As String

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
        "<th>Kullanıcı</th>" + _
        "<th>Tarih</th>" + _
        "<th>Mesaj</th>" + _
        "<th>Kaynak</th>" + _
        "<th>Stack Trace</th>" + _
        "<th>URL</th>" + _
        "<th>Okunmuş mu?</th>" + _
        "<th>E-Posta Gönderilmiş mi?</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Anahtar", GetType(String))
        table.Columns.Add("Kullanıcı", GetType(String))
        table.Columns.Add("Tarih", GetType(String))
        table.Columns.Add("Mesaj", GetType(String))
        table.Columns.Add("Kaynak", GetType(String))
        table.Columns.Add("Stack Trace", GetType(String))
        table.Columns.Add("URL", GetType(String))
        table.Columns.Add("Okunmuş mu?", GetType(String))
        table.Columns.Add("E-Posta Gönderilmiş mi?", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(9)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Anahtar", fbaslik))
        pdftable.AddCell(New Phrase("Kullanıcı", fbaslik))
        pdftable.AddCell(New Phrase("Tarih", fbaslik))
        pdftable.AddCell(New Phrase("Mesaj", fbaslik))
        pdftable.AddCell(New Phrase("Kaynak", fbaslik))
        pdftable.AddCell(New Phrase("Stack Trace", fbaslik))
        pdftable.AddCell(New Phrase("URL", fbaslik))
        pdftable.AddCell(New Phrase("Okunmuş mu?", fbaslik))
        pdftable.AddCell(New Phrase("E-Posta Gönderilmiş mi?", fbaslik))



        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""

        'kullanici secilmisse
        If HttpContext.Current.Session("kullanici") <> "0" Then
            sqldevam = sqldevam + " and kullanicipkey=@kullanicipkey"
        End If


        sqlstr = "select * from errorlog where " + _
         "(Convert(DATE,tarih)>=@baslangic and Convert(DATE,tarih)<=@bitis)" + _
         sqldevam + " order by tarih desc"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = HttpContext.Current.Session("bitis")


        If HttpContext.Current.Session("kullanici") <> "0" Then
            komut.Parameters.Add("@kullanicipkey", SqlDbType.Int)
            komut.Parameters("@kullanicipkey").Value = HttpContext.Current.Session("kullanici")
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, kullanicipkey, tarih, exp_msg, exp_source As String
        Dim exp_stacktrace, exp_url, okunmusmu, emailgonderilmismi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                        saf1 = CStr(pkey)
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If


                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                    Else
                        kullanicipkey = "0"
                    End If
                    If kullanicipkey <> "0" Then
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                        kol2 = "<td>" + kullanici.adsoyad + "</td>"
                        saf2 = kullanici.adsoyad
                    Else
                        kol2 = "<td>" + "-" + "</td>"
                        saf2 = "-"
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol3 = "<td>" + tarih + "</td>"
                        saf3 = tarih
                    Else
                        kol3 = "<td>" + "-" + "</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("exp_msg") Is System.DBNull.Value Then
                        exp_msg = veri.Item("exp_msg")
                        kol4 = "<td>" + exp_msg + "</td>"
                        saf4 = exp_msg
                    Else
                        kol4 = "<td>" + "-" + "</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("exp_source") Is System.DBNull.Value Then
                        exp_source = veri.Item("exp_source")
                        kol5 = "<td>" + exp_source + "</td>"
                        saf5 = exp_source
                    Else
                        kol5 = "<td>" + "-" + "</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("exp_stacktrace") Is System.DBNull.Value Then
                        exp_stacktrace = veri.Item("exp_stacktrace")
                        kol6 = "<td>" + exp_stacktrace + "</td>"
                        saf6 = exp_stacktrace
                    Else
                        kol6 = "<td>" + "-" + "</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("exp_url") Is System.DBNull.Value Then
                        exp_url = veri.Item("exp_url")
                        kol7 = "<td>" + exp_url + "</td>"
                        saf7 = exp_url
                    Else
                        kol7 = "<td>" + "-" + "</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                        okunmusmu = veri.Item("okunmusmu")
                        kol8 = "<td>" + okunmusmu + "</td>"
                        saf8 = okunmusmu
                    Else
                        kol8 = "<td>" + "-" + "</td>"
                        saf8 = "-"
                    End If

                    If Not veri.Item("emailgonderilmismi") Is System.DBNull.Value Then
                        emailgonderilmismi = veri.Item("emailgonderilmismi")
                        kol9 = "<td>" + emailgonderilmismi + "</td></tr>"
                        saf9 = emailgonderilmismi
                    Else
                        kol9 = "<td>" + "-" + "</td></tr>"
                        saf9 = "-"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + kol9


                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
                    pdftable.AddCell(New Phrase(saf9, fdata))

                    recordcount = recordcount + 1


                End While

            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function




    '---------------------------------listele--------------------------------------
    Public Function listeleislemicin() As String

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12 As String

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
        "<th>Tarih</th>" + _
        "<th>İşlem</th>" + _
        "<th>Mesaj</th>" + _
        "<th>Source</th>" + _
        "<th>URL</th>" + _
        "<th>Okunmuş mu?</th>" + _
        "<th>E-Posta Gönderilmiş mi?</th>" + _
        "</tr>" + _
        "</thead>"


        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""

        'kullanici secilmisse
        If HttpContext.Current.Session("kullanici") <> "0" Then
            sqldevam = sqldevam + " and kullanicipkey=@kullanicipkey"
        End If


        sqlstr = "select * from errorlog where " + _
         "(Convert(DATE,tarih)>=@baslangic and Convert(DATE,tarih)<=@bitis)" + _
         sqldevam + " order by tarih desc"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = HttpContext.Current.Session("bitis")


        If HttpContext.Current.Session("kullanici") <> "0" Then
            komut.Parameters.Add("@kullanicipkey", SqlDbType.Int)
            komut.Parameters("@kullanicipkey").Value = HttpContext.Current.Session("kullanici")
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, kullanicipkey, tarih, exp_msg, exp_source As String
        Dim exp_stacktrace, exp_url, okunmusmu, emailgonderilmismi As String

        Dim dugmesil, dugmeokunduyap, dugmeokunmadiyap, dugmeeposta As String
        Dim ajaxlinksil, ajaxlinkokunduyap, ajaxlinkokunmadiyap, ajaxlinkepostayap As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol1 = "<tr><td>" + tarih + "</td>"
                    Else
                        kol1 = "<tr><td>" + "-" + "</td>"
                    End If


                    'AJAX OKUNDU YAP
                    ajaxlinkokunduyap = "okunduyap(" + CStr(pkey) + ")"
                    dugmeokunduyap = "<span id='okundubutton" + CStr(pkey) + "' onclick='" + ajaxlinkokunduyap + "' class='button'>Okundu</span>"
                    'AJAX OKUNMADI YAP
                    ajaxlinkokunmadiyap = "okunmadiyap(" + CStr(pkey) + ")"
                    dugmeokunmadiyap = "<span id='okunmadibutton" + CStr(pkey) + "' onclick='" + ajaxlinkokunmadiyap + "' class='button'>Okunmadı</span>"
                    'AJAX LINK SİL------
                    ajaxlinksil = "sil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='silbutton" + CStr(pkey) + "' onclick='" + ajaxlinksil + "' class='button'>Sil</span>"
                    'AJAX LINK EPOSTA------
                    ajaxlinkepostayap = "eposta(" + CStr(pkey) + ")"
                    dugmeeposta = "<span id='epostabutton" + CStr(pkey) + "' onclick='" + ajaxlinkepostayap + "' class='button'>E-Posta Gönder</span>"

                    kol2 = "<td>" + dugmeokunduyap + dugmeokunmadiyap + dugmesil + dugmeeposta + "</td>"


                    If Not veri.Item("exp_msg") Is System.DBNull.Value Then
                        exp_msg = veri.Item("exp_msg")
                        kol3 = "<td>" + exp_msg + "</td>"
                    Else
                        kol3 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("exp_source") Is System.DBNull.Value Then
                        exp_source = veri.Item("exp_source")
                        kol4 = "<td>" + exp_source + "</td>"
                    Else
                        kol4 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("exp_url") Is System.DBNull.Value Then
                        exp_url = veri.Item("exp_url")
                        kol5 = "<td>" + exp_url + "</td>"
                    Else
                        kol5 = "<td>" + "-" + "</td>"
                    End If


                    If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                        okunmusmu = veri.Item("okunmusmu")
                        kol6 = "<td>" + okunmusmu + "</td>"
                    Else
                        kol6 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("emailgonderilmismi") Is System.DBNull.Value Then
                        emailgonderilmismi = veri.Item("emailgonderilmismi")
                        kol7 = "<td>" + emailgonderilmismi + "</td></tr>"
                    Else
                        kol7 = "<td>" + "-" + "</td></tr>"
                    End If


                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7

                    recordcount = recordcount + 1

                End While

            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return donecek

    End Function


    Public Function okunmamiserrorsayisi() As Integer

        Dim sqlstr As String
        Dim kactane As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from errorlog where okunmusmu=@okunmusmu"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Hayır"
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kactane = 0
        Else
            kactane = maxkayit1
        End If

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kactane

    End Function


    Function erroronizle() As String

        Dim okunmamislar As New List(Of CLASSERRORLOG)
        okunmamislar = doldurokunmamislar()

        Dim donecek As String = ""

        For Each Item As CLASSERRORLOG In okunmamislar

            donecek = donecek + "<li>" + _
            "<a  href=" + Chr(34) + "logerror.aspx" + Chr(34) + ">" + _
            "<span class=" + Chr(34) + "task" + Chr(34) + ">" + _
            "<span class=" + Chr(34) + "desc" + Chr(34) + ">" + _
            Item.exp_url + " - " + Item.exp_msg + _
            "</span>" + _
            "</span>" + _
            "</a>" + _
            "</li>"

        Next
        Return donecek

    End Function

End Class


