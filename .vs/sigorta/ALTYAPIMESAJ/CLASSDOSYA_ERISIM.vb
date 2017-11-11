Imports System.Web.HttpApplicationState
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Data.SqlClient


Public Class CLASSDOSYA_ERISIM

    Dim dbopresult As New CLADBOPRESULT
    Dim etkilenen As Integer
    Dim sqlstr As String
    Dim istring As String
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dosya As New CLASSDOSYA
    Dim resultset As New CLADBOPRESULT


    Public Function Ekle(ByVal dosya As CLASSDOSYA) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into dosya values (@pkey," + _
        "@gonderenpkey,@alanpkey,@msgkonu,@gondermetarih," + _
        "@okunmusmu,@gonderensilmismi,@alansilmismi,@contype," + _
        "@filesize,@fileg,@filename)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@gonderenpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dosya.gonderenpkey = 0 Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = dosya.gonderenpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@alanpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If dosya.alanpkey = 0 Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dosya.alanpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@msgkonu", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dosya.msgkonu = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dosya.msgkonu
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@gondermetarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If dosya.gondermetarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = dosya.gondermetarih
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If dosya.okunmusmu = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = dosya.okunmusmu
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@gonderensilmismi", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If dosya.gonderensilmismi = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = dosya.gonderensilmismi
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@alansilmismi", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If dosya.alansilmismi = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = dosya.alansilmismi
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@contype", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If dosya.contype = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = dosya.contype
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@filesize", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If dosya.filesize = 0 Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = dosya.filesize
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@fileg", SqlDbType.Image)
        param11.Direction = ParameterDirection.Input
        param11.Value = dosya.fileg
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@filename", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If dosya.gonderensilmismi = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = dosya.filename
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


    Public Function doldur() As List(Of CLASSDOSYA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdosya As New CLASSDOSYA
        Dim dosyaler As New List(Of CLASSDOSYA)
        komut.Connection = db_baglanti
        sqlstr = "select * from dosya"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdosya.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    donecekdosya.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    donecekdosya.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    donecekdosya.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    donecekdosya.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekdosya.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    donecekdosya.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    donecekdosya.alansilmismi = veri.Item("alansilmismi")
                End If

                If Not veri.Item("contype") Is System.DBNull.Value Then
                    donecekdosya.contype = veri.Item("contype")
                End If

                If Not veri.Item("filesize") Is System.DBNull.Value Then
                    donecekdosya.filesize = veri.Item("filesize")
                End If

                If Not veri.Item("fileg") Is System.DBNull.Value Then
                    donecekdosya.fileg = veri.Item("fileg")
                End If

                If Not veri.Item("filename") Is System.DBNull.Value Then
                    donecekdosya.filename = veri.Item("filename")
                End If


                dosyaler.Add(New CLASSDOSYA(donecekdosya.pkey, _
                donecekdosya.gonderenpkey, donecekdosya.alanpkey, donecekdosya.msgkonu, donecekdosya.gondermetarih, _
                donecekdosya.okunmusmu, donecekdosya.gonderensilmismi, donecekdosya.alansilmismi, donecekdosya.contype, _
                donecekdosya.filesize, donecekdosya.fileg, donecekdosya.filename))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dosyaler

    End Function


    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from dosya"
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


    Function Duzenle(ByVal dosya As CLASSDOSYA) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Web.HttpContext.Current.Application("ymahkeme")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update dosya set " + _
        "gonderenpkey=@gonderenpkey," + _
        "alanpkey=@alanpkey," + _
        "msgkonu=@msgkonu," + _
        "gondermetarih=@gondermetarih," + _
        "okunmusmu=@okunmusmu," + _
        "gonderensilmismi=@gonderensilmismi," + _
        "alansilmismi=@alansilmismi," + _
        "contype=@contype," + _
        "filesize=@filesize," + _
        "fileg=@fileg," + _
        "filename=@filename" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dosya.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@gonderenpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dosya.gonderenpkey = 0 Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = dosya.gonderenpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@alanpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If dosya.alanpkey = 0 Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dosya.alanpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@msgkonu", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dosya.msgkonu = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dosya.msgkonu
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@gondermetarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If dosya.gondermetarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = dosya.gondermetarih
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If dosya.okunmusmu = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = dosya.okunmusmu
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@gonderensilmismi", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If dosya.gonderensilmismi = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = dosya.gonderensilmismi
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@alansilmismi", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If dosya.alansilmismi = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = dosya.alansilmismi
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@contype", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If dosya.contype = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = dosya.contype
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@filesize", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If dosya.filesize = 0 Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = dosya.filesize
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@fileg", SqlDbType.Image)
        param11.Direction = ParameterDirection.Input
        param11.Value = dosya.fileg
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@filename", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If dosya.gonderensilmismi = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = dosya.filename
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



    Public Function alansilmismiduzenle(ByVal pkey As Integer) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String
        komut.Connection = db_baglanti


        sqlstr = "update dosya set " + _
        "okunmusmu=@okunmusmu, " + _
        "alansilmismi=@alansilmismi " + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@okunmusmu", SqlDbType.VarChar, 50)
        komut.Parameters("@okunmusmu").Value = "Evet"

        komut.Parameters.Add("@alansilmismi", SqlDbType.VarChar, 50)
        komut.Parameters("@alansilmismi").Value = "Evet"

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkey


        Try
            etkilenen = komut.ExecuteNonQuery()

            If etkilenen > 0 Then
                dbopresult.etkilenen = etkilenen
                dbopresult.durum = "Kaydedildi"
                dbopresult.hatastr = ""
            End If

        Catch ex As Exception

            dbopresult.etkilenen = 0
            dbopresult.durum = "Kaydedilmedi"
            dbopresult.hatastr = ex.Message

        Finally

            komut.Dispose()

        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return dbopresult

    End Function


    Public Function gonderensilmismiduzenle(ByVal pkey As Integer) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String
        komut.Connection = db_baglanti


        sqlstr = "update dosya set " + _
        "okunmusmu=@okunmusmu, " + _
        "gonderensilmismi=@gonderensilmismi " + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@okunmusmu", SqlDbType.VarChar, 50)
        komut.Parameters("@okunmusmu").Value = "Evet"

        komut.Parameters.Add("@gonderensilmismi", SqlDbType.VarChar, 50)
        komut.Parameters("@gonderensilmismi").Value = "Evet"

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkey


        Try
            etkilenen = komut.ExecuteNonQuery()

            If etkilenen > 0 Then
                dbopresult.etkilenen = etkilenen
                dbopresult.durum = "Kaydedildi"
                dbopresult.hatastr = ""
            End If

        Catch ex As Exception

            dbopresult.etkilenen = 0
            dbopresult.durum = "Kaydedilmedi"
            dbopresult.hatastr = ex.Message

        Finally

            komut.Dispose()

        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return dbopresult

    End Function

    Public Function okunmamisdosyasayisi(ByVal kimin As String) As Integer

        Dim sqlstr As String
        Dim kactane As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from dosya where alanpkey=" + kimin + " and okunmusmu='Hayır'"
        komut = New SqlCommand(sqlstr, db_baglanti)
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


    Public Function dosyalarimyazisi(ByVal kimin As String) As String

        Dim sqlstr As String
        Dim kactane As Integer
        Dim komut As SqlCommand
        Dim donecek As String
        Dim baglanabildimi As String = "Evet"

        Dim istring As String
        Dim db_baglanti As SqlConnection

        Try
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
        Catch ex As Exception
            baglanabildimi = "Hayır"
        End Try

        Try

            sqlstr = "select count(*) from dosya where alanpkey=" + kimin + _
            " and okunmusmu='Hayır' and alansilmismi='Hayır'"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim maxkayit1 = komut.ExecuteScalar()
            If maxkayit1 Is System.DBNull.Value Then
                kactane = 0
            Else
                kactane = maxkayit1
            End If

            If kactane = 0 Then
                donecek = "<span id='Literal2'><a href='dosya.aspx'>Dosyalarım</a></span>"
            End If

            If kactane > 0 Then
                donecek = "<span id='Literal2'><a href='dosya.aspx'><b>Dosyalarım(" + CStr(kactane) + ")</b></a></span>"
            End If

        Catch ex As Exception

        Finally
            If baglanabildimi = "Evet" Then
                komut.Dispose()
                db_baglanti.Close()
                db_baglanti.Dispose()
            End If
        End Try

        Return donecek

    End Function

    Public Function okunduyap(ByVal pkey As Integer) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "update dosya set okunmusmu=@okunmusmu " + _
        " where pkey=@pkey "

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@okunmusmu", SqlDbType.VarChar, 50)
        komut.Parameters("@okunmusmu").Value = "Evet"

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkey


        Try
            etkilenen = komut.ExecuteNonQuery()

            If etkilenen > 0 Then
                dbopresult.etkilenen = etkilenen
                dbopresult.durum = "Kaydedildi"
                dbopresult.hatastr = ""
            End If

        Catch ex As Exception

            dbopresult.etkilenen = 0
            dbopresult.durum = "Kaydedilmedi"
            dbopresult.hatastr = ex.Message

        Finally
            komut.Dispose()

        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return dbopresult

    End Function

    Public Function okunmadiyap(ByVal pkey As Integer) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "update dosya set okunmusmu=@okunmusmu " + _
        " where pkey=@pkey "

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@okunmusmu", SqlDbType.VarChar, 50)
        komut.Parameters("@okunmusmu").Value = "Hayır"

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkey


        Try
            etkilenen = komut.ExecuteNonQuery()

            If etkilenen > 0 Then
                dbopresult.etkilenen = etkilenen
                dbopresult.durum = "Kaydedildi"
                dbopresult.hatastr = ""
            End If

        Catch ex As Exception

            dbopresult.etkilenen = 0
            dbopresult.durum = "Kaydedilmedi"
            dbopresult.hatastr = ex.Message

        Finally
            komut.Dispose()

        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return dbopresult

    End Function


    Public Function gelendosyalarim(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, basliklar, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim satir, tabloson, pager As String
        Dim sqlstr As String

        Dim ajaxlinkindir, ajaxlinksil, ajaxlinkokunduyap, ajaxlinkokunmadiyap As String
        Dim boldbas, boldson As String
        Dim jvstring As String



        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
            "<thead>" + _
                "<tr>" + _
                    "<th>Gönderen</th>" + _
                    "<th>Gönderme Tarihi</th>" + _
                    "<th>Dosya Adı</th>" + _
                    "<th>Konu</th>" + _
                    "<th>Okunmuş mu?</th>" + _
                    "<th>İndir</th>" + _
                    "<th>Okunmuş Olarak İşaretle</th>" + _
                    "<th>Okunmamış Olarak İşaretle</th>" + _
                    "<th>Sil</th>" + _
                "</tr>" + _
            "</thead>" + _
            "<tbody>"

        tabloson = "</tbody></table>"

        Dim komut As New SqlCommand


        sqlstr = "select * from dosya where alanpkey=@alanpkey " + _
        "and alansilmismi='Hayır' order by gondermetarih desc;"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = CInt(kimin)

        Dim classdosya As New CLASSDOSYA

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        Dim gonderenad, filename, gonderenpkey As String
        Dim girdi, gondermetarih, okunmusmu, msgkonu As String
        girdi = "0"

        donecek = ""

        Using veri As SqlDataReader = komut.ExecuteReader()

            While veri.Read()

                girdi = "1"

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    okunmusmu = veri.Item("okunmusmu")
                    If okunmusmu = "Hayır" Then
                        boldbas = "<b><font style='color:green;font-size:13px;'>"
                        boldson = "</font></b>"
                    Else
                        boldbas = ""
                        boldson = ""
                    End If
                End If

                If Not veri.Item("pkey") Is x.Value Then
                    pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is x.Value Then
                    gonderenpkey = veri.Item("gonderenpkey")
                    kullanici = kullanici_erisim.bultek(gonderenpkey)
                    kol1 = "<tr><td>" + boldbas + kullanici.adsoyad + boldson + "</td>"
                Else
                    kol1 = "<tr><td>-</td>"
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    gondermetarih = veri.Item("gondermetarih")
                    kol2 = "<td>" + boldbas + gondermetarih + boldson + "</td>"
                Else
                    kol2 = "<td>-</td>"
                End If

                If Not veri.Item("filename") Is System.DBNull.Value Then
                    filename = veri.Item("filename")
                    kol3 = "<td><a onclick=" + Chr(34) + "dosyayazisi()" + Chr(34) + " target='_blank' href='dosyaindir.aspx?pkey=" + _
                    CStr(pkey) + "'>" + filename + "</a></td>"
                Else
                    kol3 = "<td>-</td>"
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    msgkonu = veri.Item("msgkonu")
                    kol4 = "<td>" + boldbas + msgkonu + boldson + "</td>"
                Else
                    kol4 = "<td>-</td>"
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    okunmusmu = veri.Item("okunmusmu")
                    kol5 = "<td>" + boldbas + okunmusmu + boldson + "</td>"
                Else
                    kol5 = "<td>-</td>"
                End If

                'İNDİRME KOLONU
                kol6 = "<td><a href='dosyaindir.aspx?pkey=" + CStr(pkey) + "'>" + _
                "<span onclick=" + Chr(34) + "dosyayazisi()" + Chr(34) + " class='button'>İndir</span></a>" + "</td>"

                'AJAX OKUNDU YAP
                ajaxlinkokunduyap = "dosyaokunduyap(" + CStr(pkey) + ")"
                kol7 = "<td><span id='dosyaokundubutton' onclick='" + ajaxlinkokunduyap + "' class='button'>Okundu</span>" + _
                "</td>"

                'AJAX OKUNDU YAP
                ajaxlinkokunmadiyap = "dosyaokunmadiyap(" + CStr(pkey) + ")"
                kol8 = "<td><span id='dosyaokunmadiyapbutton' onclick='" + ajaxlinkokunmadiyap + "' class='button'>Okunmadı</span>" + _
                "</td>"

                'AJAX LINK SİL------
                ajaxlinksil = "dosyaalansil(" + CStr(pkey) + ")"
                kol9 = "<td><span id='dosyasilbutton' onclick='" + ajaxlinksil + "' class='button'>Sil</span>" + _
                "</td></tr>"

                satir = satir + kol1 + kol2 + kol3 + kol4 + _
                kol5 + kol6 + kol7 + kol8 + kol9
                '---------------

            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "0" Then
            donecek = "<h2>Size gelmiş olan herhangi bir dosyanız yoktur.</h2>"
        End If

        If girdi <> "0" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return donecek


    End Function



    Public Function gonderdigimdosyalarim(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, basliklar, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim satir, tabloson, pager As String
        Dim sqlstr As String

        Dim ajaxlinkindir, ajaxlinksil, filename, ajaxlinkokunduyap As String
        Dim jvstring As String
        'dugmejscript = javascrpt_erisim.dugmeler

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
            "<thead>" + _
                "<tr>" + _
                    "<th>Gönderilen Kişi</th>" + _
                    "<th>Gönderme Tarihi</th>" + _
                    "<th>Dosya Adı</th>" + _
                    "<th>Konu</th>" + _
                    "<th>İndir</th>" + _
                    "<th>Sil</th>" + _
                "</tr>" + _
            "</thead>" + _
            "<tbody>"

        tabloson = "</tbody></table>"

        Dim komut As New SqlCommand

        sqlstr = "select * from dosya where gonderenpkey=" + kimin + _
        " and gonderensilmismi='Hayır'"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = CInt(kimin)

        Dim classdosya As New CLASSDOSYA
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        Dim gonderenad, gonderenpkey, alanpkey As String
        Dim girdi, gondermetarih, msgkonu As String
        girdi = "0"

        donecek = ""

        Using veri As SqlDataReader = komut.ExecuteReader()

            While veri.Read()

                girdi = "1"

                If Not veri.Item("pkey") Is x.Value Then
                    pkey = veri.Item("pkey")
                End If

                If Not veri.Item("alanpkey") Is x.Value Then
                    alanpkey = veri.Item("alanpkey")
                    kullanici = kullanici_erisim.bultek(alanpkey)
                    kol1 = "<tr><td>" + kullanici.adsoyad + "</td>"
                Else
                    kol1 = "<td>-</td>"
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    gondermetarih = veri.Item("gondermetarih")
                    kol2 = "<td>" + gondermetarih + "</td>"
                Else
                    kol2 = "<td>-</td>"
                End If

                If Not veri.Item("filename") Is System.DBNull.Value Then
                    filename = veri.Item("filename")
                    kol3 = "<td><a target='_blank' href='dosyaindir.aspx?pkey=" + _
                    CStr(pkey) + "'>" + filename + "</a></td>"
                Else
                    kol3 = "<td>-</td>"
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    msgkonu = veri.Item("msgkonu")
                    kol4 = "<td>" + msgkonu + "</td>"
                Else
                    kol4 = "<td>-</td>"
                End If

                'İNDİRME KOLONU
                kol5 = "<td><a href='dosyaindir.aspx?pkey=" + CStr(pkey) + "'>" + _
                "<span id='dosyaindirbutton' class='button'>İndir</span></a>" + "</td>"


                'AJAX LINK SİL------
                ajaxlinksil = "dosyagonderensil(" + CStr(pkey) + ")"
                kol6 = "<td><span id='dosyasilbutton' onclick='" + ajaxlinksil + "' class='button'>Sil</span>" + _
                "</td></tr>"

                satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
                '---------------

            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "0" Then
            donecek = "<h2>Göndermiş olduğunuz herhangi bir dosyanız yoktur.</h2>"
        End If

        If girdi <> "0" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return donecek


    End Function


    Function bultek(ByVal pkey As String) As CLASSDOSYA

        Dim komut As New SqlCommand
        Dim donecekdosya As New CLASSDOSYA()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dosya where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdosya.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    donecekdosya.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    donecekdosya.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    donecekdosya.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    donecekdosya.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekdosya.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    donecekdosya.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    donecekdosya.alansilmismi = veri.Item("alansilmismi")
                End If

                If Not veri.Item("contype") Is System.DBNull.Value Then
                    donecekdosya.contype = veri.Item("contype")
                End If

                If Not veri.Item("filesize") Is System.DBNull.Value Then
                    donecekdosya.filesize = veri.Item("filesize")
                End If

                If Not veri.Item("fileg") Is System.DBNull.Value Then
                    donecekdosya.fileg = veri.Item("fileg")
                End If

                If Not veri.Item("filename") Is System.DBNull.Value Then
                    donecekdosya.filename = veri.Item("filename")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdosya

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        If Current.Session("silmeyetki") = "Evet" Then
            istring = System.Web.HttpContext.Current.Application("ymahkeme")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            komut = New SqlCommand(sqlstr, db_baglanti)

            sqlstr = "delete from dosya where pkey=@pkey"
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

        If Current.Session("silmeyetki") = "Hayır" Then
            resultset.durum = "Silme yetkiniz yoktur."
            resultset.hatastr = "Silme yetkiniz yoktur."
            resultset.etkilenen = 0
        End If

        Return resultset

    End Function



    Public Function dosyaonizle(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, basliklar, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand

        sqlstr = "select TOP (10) pkey " + _
        "from dosya where alanpkey=@alanpkey " + _
        "and alansilmismi='Hayır' and okunmusmu='Hayır' order by gondermetarih desc;"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = CInt(kimin)

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        Dim resim_erisim As New CLASSTEKRESIM_ERISIM

        Dim bdosya As New CLASSDOSYA
        donecek = ""

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is x.Value Then
                    pkey = veri.Item("pkey")
                End If

                bdosya = bultek(pkey)
                kullanici = kullanici_erisim.bultek(bdosya.gonderenpkey)

                donecek = donecek + _
                "<li>" + _
                "<a href='gelendosya.aspx'>" + _
                "<span class='label label-icon label-success'>" + _
                "<i class='fa fa-plus'></i>" + _
                "</span>" + _
                bdosya.filename + _
                "<span class='time'>" + _
                "</span>" + _
                "</a>" + _
                "</li>"

            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()

        'bdosya.gondermetarih.Hour.ToString + ":" + Format(bdosya.gondermetarih.Minute, "00") + _

        Return donecek

    End Function


    Public Function maxkayit() As Integer

        Dim sayi As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select max(pkey) from dosya"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            sayi = 1
        Else
            sayi = maxkayit1
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return sayi

    End Function

    Public Function dosyaadbul(ByVal originalfilename) As String

        Dim donecek As String
        Dim uzanti As String
        Dim noktayer As Integer

        noktayer = InStr(originalfilename, ".", CompareMethod.Text)
        uzanti = Mid(originalfilename, noktayer + 1, Len(originalfilename))
        donecek = "d" + CStr(maxkayit()) + "." + uzanti
        Return donecek

    End Function


End Class

