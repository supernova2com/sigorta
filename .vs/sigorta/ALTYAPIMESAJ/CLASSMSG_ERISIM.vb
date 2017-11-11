Imports System.Web.HttpApplicationState
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Data.SqlClient


Public Class CLASSMSG_ERISIM

    Dim dbopresult As New CLADBOPRESULT
    Dim etkilenen As Integer
    Dim sqlstr As String
    Dim istring As String

    Function ekle(ByVal msg As CLASSMSG) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As sqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "insert into msg values (@pkey,@gonderenpkey, " + _
        "@alanpkey,@msgmetin,@msgkonu,@gondermetarih," + _
        "@okunmusmu,@gonderensilmismi,@alansilmismi)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkeybul()

        komut.Parameters.Add("@gonderenpkey", SqlDbType.Int)
        komut.Parameters("@gonderenpkey").Value = msg.gonderenpkey

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = msg.alanpkey

        komut.Parameters.Add("@msgmetin", SqlDbType.Text)
        komut.Parameters("@msgmetin").Value = msg.msgmetin

        komut.Parameters.Add("@msgkonu", SqlDbType.VarChar, 250)
        komut.Parameters("@msgkonu").Value = msg.msgkonu

        komut.Parameters.Add("@gondermetarih", SqlDbType.DateTime)
        komut.Parameters("@gondermetarih").Value = msg.gondermetarih

        komut.Parameters.Add("@okunmusmu", SqlDbType.VarChar, 50)
        komut.Parameters("@okunmusmu").Value = msg.okunmusmu

        komut.Parameters.Add("@gonderensilmismi", SqlDbType.VarChar, 50)
        komut.Parameters("@gonderensilmismi").Value = msg.gonderensilmismi

        komut.Parameters.Add("@alansilmismi", SqlDbType.VarChar, 50)
        komut.Parameters("@alansilmismi").Value = msg.alansilmismi

        Try

            etkilenen = komut.ExecuteNonQuery()

            If etkilenen > 0 Then
                dbopresult.etkilenen = etkilenen
                dbopresult.durum = "Kaydedildi"
                dbopresult.hatastr = ""
            End If

        Catch ex As Exception

            dbopresult.etkilenen = 0
            dbopresult.durum = "Kayıt yapılamadı."
            dbopresult.hatastr = ex.Message

        Finally

            komut.Dispose()

        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return dbopresult

    End Function

    Public Function doldur() As List(Of CLASSMSG)

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim donecekmsg As New CLASSMSG
        Dim msgler As New List(Of CLASSMSG)

        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "select * from msg"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()

            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmsg.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    donecekmsg.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    donecekmsg.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    donecekmsg.msgmetin = veri.Item("msgmetin")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    donecekmsg.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    donecekmsg.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekmsg.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    donecekmsg.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    donecekmsg.alansilmismi = veri.Item("alansilmismi")
                End If

                msgler.Add(New CLASSMSG(donecekmsg.pkey, donecekmsg.gonderenpkey, _
                donecekmsg.alanpkey, donecekmsg.msgmetin, donecekmsg.msgkonu, _
                donecekmsg.gondermetarih, donecekmsg.okunmusmu, _
                donecekmsg.gonderensilmismi, donecekmsg.alansilmismi))

            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return msgler


    End Function


    Public Function doldurbenim(ByVal kimpkey As String) As List(Of CLASSMSG)

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim donecekmsg As New CLASSMSG
        Dim msgler As New List(Of CLASSMSG)

        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "select * from msg where alanpkey=" + kimpkey + " and alansilmismi='Hayır'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()

            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmsg.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    donecekmsg.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    donecekmsg.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    donecekmsg.msgmetin = veri.Item("msgmetin")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    donecekmsg.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    donecekmsg.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekmsg.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    donecekmsg.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    donecekmsg.alansilmismi = veri.Item("alansilmismi")
                End If

                msgler.Add(New CLASSMSG(donecekmsg.pkey, donecekmsg.gonderenpkey, _
                donecekmsg.alanpkey, donecekmsg.msgmetin, donecekmsg.msgkonu, _
                donecekmsg.gondermetarih, donecekmsg.okunmusmu, _
                donecekmsg.gonderensilmismi, donecekmsg.alansilmismi))

            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return msgler


    End Function


    Public Function doldurgonderdiklerim(ByVal kimpkey As String) As List(Of CLASSMSG)

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim donecekmsg As New CLASSMSG
        Dim msgler As New List(Of CLASSMSG)

        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "select * from msg where gonderenpkey=" + kimpkey + _
        " and gonderensilmismi='Hayır'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmsg.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    donecekmsg.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    donecekmsg.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    donecekmsg.msgmetin = veri.Item("msgmetin")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    donecekmsg.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    donecekmsg.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekmsg.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    donecekmsg.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    donecekmsg.alansilmismi = veri.Item("alansilmismi")
                End If

                msgler.Add(New CLASSMSG(donecekmsg.pkey, donecekmsg.gonderenpkey, _
                donecekmsg.alanpkey, donecekmsg.msgmetin, donecekmsg.msgkonu, _
                donecekmsg.gondermetarih, donecekmsg.okunmusmu, _
                donecekmsg.gonderensilmismi, donecekmsg.alansilmismi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return msgler


    End Function



    Public Function bul(ByVal pkey As String) As CLASSMSG

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim donecekmsg As New CLASSMSG
        Dim sqlstr As String

        komut.Connection = db_baglanti
        sqlstr = "select *  from msg where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkey

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmsg.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    donecekmsg.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    donecekmsg.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    donecekmsg.msgmetin = veri.Item("msgmetin")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    donecekmsg.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    donecekmsg.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekmsg.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    donecekmsg.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    donecekmsg.alansilmismi = veri.Item("alansilmismi")
                End If


            End While
        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return donecekmsg


    End Function


    Private Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select max(pkey) from msg"
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


    Public Sub sil(ByVal pkey As String)

        Dim istring As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        Dim db_baglanti As SqlConnection
        db_baglanti = New SqlConnection(istring)
        Dim komut As New SqlCommand
        Dim sqlstr As String

        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "delete from  msg where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkey

        komut.ExecuteNonQuery()

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


    End Sub


    Public Function guncelle(ByVal msg As CLASSMSG) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String

        sqlstr = "update msg set " + _
        "gonderenpkey=@gonderenpkey, " + _
        "alanpkey=@alanpkey, " + _
        "msgmetin=@msgmetin, " + _
        "msgkonu=@msgkonu, " + _
        "gondermetarih=@gondermetarih, " + _
        "okunmusmu=@okunmusmu, " + _
        "gonderensilmismi=@gonderensilmismi, " + _
        "alansilmismi=@alansilmismi " + _
        " where pkey=@pkey"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@gonderenpkey", SqlDbType.Int)
        komut.Parameters("@gonderenpkey").Value = msg.gonderenpkey

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = msg.alanpkey

        komut.Parameters.Add("@msgmetin", SqlDbType.Text)
        komut.Parameters("@msgmetin").Value = msg.msgmetin

        komut.Parameters.Add("@msgkonu", SqlDbType.VarChar, 250)
        komut.Parameters("@msgkonu").Value = msg.msgkonu

        komut.Parameters.Add("@gondermetarih", SqlDbType.DateTime)
        komut.Parameters("@gondermetarih").Value = msg.gondermetarih

        komut.Parameters.Add("@okunmusmu", SqlDbType.VarChar, 50)
        komut.Parameters("@okunmusmu").Value = msg.okunmusmu

        komut.Parameters.Add("@gonderensilmismi", SqlDbType.VarChar, 50)
        komut.Parameters("@gonderensilmismi").Value = msg.gonderensilmismi

        komut.Parameters.Add("@alansilmismi", SqlDbType.VarChar, 50)
        komut.Parameters("@alansilmismi").Value = msg.alansilmismi

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = msg.pkey


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


    Public Function alansilmismiduzenle(ByVal pkey As Integer) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String
        komut.Connection = db_baglanti

        sqlstr = "update msg set " + _
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


    Public Function okunmamismsgsayisi(ByVal kimin As String) As Integer

        Dim sqlstr As String
        Dim kactane As Integer = 0
        Dim komut As SqlCommand

        Try

            Dim istring As String
            Dim db_baglanti As SqlConnection
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()


            sqlstr = "select count(*) from msg where alanpkey=" + kimin + " and okunmusmu='Hayır'"
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
        Catch ex As Exception
        End Try

        Return kactane

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

        sqlstr = "update msg set okunmusmu=@okunmusmu " + _
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


    Public Function listeleilgili(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim javascript As New CLASSJAVASCRIPT

        Dim dugmejscript As String
        'dugmejscript = javascrpt_erisim.dugmeler

        Dim komut As New SqlCommand
        Dim sqlstr As String

        sqlstr = "select * from msg where alanpkey=@alanpkey and alansilmismi='Hayır'" + _
        " order by gondermetarih desc;"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = CInt(kimin)

        Dim classmsg As New CLASSMSG
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI
        Dim gonderenad As String
        Dim girdi As String
        girdi = "0"

        donecek = ""

        Using veri As SqlDataReader = komut.ExecuteReader()

            While veri.Read()

                girdi = "1"

                If Not veri.Item("pkey") Is x.Value Then
                    pkey = veri.Item("pkey")
                    classmsg = bul(pkey)
                    kullanici = kullanici_erisim.bultek(classmsg.gonderenpkey)
                    gonderenad = kullanici.adsoyad
                End If

                donecek = donecek + "<h2>Gönderen:" + gonderenad + "</h2>" + _
                "<span class='button' onclick='msgokunduyap(" + CStr(classmsg.pkey) + ")'>Okudum</span>" + _
                "<span class='button' onclick='alansilmismiduzenle(" + pkey + ")'>Sil</span>" + _
                "<h3>" + classmsg.gondermetarih.ToString + " " + gonderenad + "</h3>" + _
                "<h2>" + classmsg.msgkonu + "</h2>" + _
                "<p>" + classmsg.msgmetin + "</p>" + _
                "Mesaj Okunmuşmu:" + classmsg.okunmusmu + _
                "<hr/>"
            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "0" Then
            donecek = "<h2>Herhangi bir mesajınız yoktur.</h2>"

        End If

        Return (dugmejscript + donecek)

    End Function


    Public Function listelegonderdiklerim(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim sqls As String

        sqls = "select * from msg where gonderenpkey=" + kimin
        komut = New SqlCommand(sqls, db_baglanti)

        Dim classmsg As New CLASSMSG

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI


        Dim gonderenad As String
        Dim girdi As String
        girdi = "0"
        Dim i As Integer = 1

        donecek = ""

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                girdi = "1"

                If Not veri.Item("pkey") Is x.Value Then
                    pkey = veri.Item("pkey")
                    classmsg = bul(pkey)
                    kullanici = kullanici_erisim.bultek(classmsg.gonderenpkey)
                    gonderenad = kullanici.adsoyad
                End If

                donecek = donecek + _
                "<h2>" + CStr(i) + ". " + classmsg.gondermetarih.ToString + " " + gonderenad + "</h2>" + _
                "<h2>" + classmsg.msgkonu + "</h2>" + _
                "<p>" + classmsg.msgmetin + "<br/>"

                i = i + 1

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "0" Then
            donecek = "<h2>Şimdiye kadar göndermiş olduğunuz herhangi bir mesajınız yoktur.</h2>"

        End If

        Return (donecek)


    End Function


    Function ara(ByVal kriter As String) As List(Of CLASSMSG)

        Dim sqls, istring As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim db_baglanti As SqlConnection
        Dim komut As SqlCommand
        Dim tekmsg As New CLASSMSG
        Dim msgler As New List(Of CLASSMSG)
        Dim x As System.DBNull


        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqls = "select * from msg where msgmetin LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqls, db_baglanti)
        komut.Parameters.Add("@kriter", SqlDbType.VarChar, 254)
        komut.Parameters("@kriter").Value = kriter

        Using veri As SqlDataReader = komut.ExecuteReader()

            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    tekmsg.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("gonderenpkey") Is System.DBNull.Value Then
                    tekmsg.gonderenpkey = veri.Item("gonderenpkey")
                End If

                If Not veri.Item("alanpkey") Is System.DBNull.Value Then
                    tekmsg.alanpkey = veri.Item("alanpkey")
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    tekmsg.msgmetin = veri.Item("msgmetin")
                End If

                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    tekmsg.msgkonu = veri.Item("msgkonu")
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    tekmsg.gondermetarih = veri.Item("gondermetarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    tekmsg.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("gonderensilmismi") Is System.DBNull.Value Then
                    tekmsg.gonderensilmismi = veri.Item("gonderensilmismi")
                End If

                If Not veri.Item("alansilmismi") Is System.DBNull.Value Then
                    tekmsg.alansilmismi = veri.Item("alansilmismi")
                End If

                msgler.Add(New CLASSMSG(tekmsg.pkey, tekmsg.gonderenpkey, tekmsg.alanpkey, _
                tekmsg.msgmetin, tekmsg.msgkonu, tekmsg.gondermetarih, _
                tekmsg.okunmusmu, tekmsg.gonderensilmismi, tekmsg.alansilmismi))

            End While
        End Using


        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return msgler

    End Function


    Public Function gelenmesajlarim(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, basliklar, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim satir, tabloson, pager As String
        Dim sqlstr As String
        Dim jvstring As String

        Dim ajaxlinkindir, ajaxlinksil, ajaxlinkokunduyap, ajaxlinkokunmadiyap As String
        Dim boldbas, boldson As String

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
            "<thead>" + _
                "<tr>" + _
                    "<th>Gönderen</th>" + _
                    "<th>Gönderme Tarihi</th>" + _
                    "<th>Konu</th>" + _
                    "<th>İçerik</th>" + _
                    "<th>Okunmuş mu?</th>" + _
                    "<th>Okunmuş Olarak İşaretle</th>" + _
                    "<th>Okunmamış Olarak İşaretle</th>" + _
                    "<th>Sil</th>" + _
                "</tr>" + _
            "</thead>" + _
            "<tbody>"

        tabloson = "</tbody></table>"

        Dim komut As New SqlCommand

        sqlstr = "select * from msg where alanpkey=@alanpkey " + _
        "and alansilmismi='Hayır' order by gondermetarih desc;"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = CInt(kimin)


        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        Dim gonderenad, filename, gonderenpkey As String
        Dim girdi, gondermetarih, okunmusmu, msgkonu, msgmetin As String
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
                    End If
                    If okunmusmu = "Evet" Then
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
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    gondermetarih = veri.Item("gondermetarih")
                    kol2 = "<td>" + boldbas + gondermetarih + boldson + "</td>"
                End If


                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    msgkonu = veri.Item("msgkonu")
                    kol3 = "<td>" + boldbas + msgkonu + boldson + "</td>"
                Else
                    kol3 = "<td>-</td>"
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    msgmetin = veri.Item("msgmetin")
                    kol4 = "<td>" + boldbas + msgmetin + boldson + "</td>"
                Else
                    kol4 = "<td>-</td>"
                End If


                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    okunmusmu = veri.Item("okunmusmu")
                    kol5 = "<td>" + boldbas + okunmusmu + boldson + "</td>"
                Else
                    kol5 = "<td>-</td>"
                End If


                'AJAX OKUNDU YAP
                ajaxlinkokunduyap = "msgokunduyap(" + CStr(pkey) + ")"
                kol6 = "<td><span id='msgokundubutton' onclick='" + ajaxlinkokunduyap + "' class='button'>Okundu</span>" + _
                "</td>"

                'AJAX OKUNDU YAP
                ajaxlinkokunmadiyap = "msgokunmadiyap(" + CStr(pkey) + ")"
                kol7 = "<td><span id='msgokunmadiyapbutton' onclick='" + ajaxlinkokunmadiyap + "' class='button'>Okunmadı</span>" + _
                "</td>"

                'AJAX LINK SİL------
                ajaxlinksil = "msgalansil(" + CStr(pkey) + ")"
                kol8 = "<td><span id='msgsilbutton' onclick='" + ajaxlinksil + "' class='button'>Sil</span>" + _
                "</td></tr>"

                satir = satir + kol1 + kol2 + kol3 + kol4 + _
                kol5 + kol6 + kol7 + kol8
                '---------------

            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "0" Then
            donecek = "<h2>Size gelmiş olan herhangi bir mesaj yoktur.</h2>"
        End If

        If girdi <> "0" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return donecek


    End Function



    Public Function gonderdigimmesajlarim(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, basliklar, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim satir, tabloson, pager As String
        Dim sqlstr As String
        Dim jvstring As String

        Dim ajaxlinkindir, ajaxlinksil, filename, ajaxlinkokunduyap As String

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
            "<thead>" + _
                "<tr>" + _
                    "<th>Gönderilen Kişi</th>" + _
                    "<th>Gönderme Tarihi</th>" + _
                    "<th>Konu</th>" + _
                    "<th>İçerik</th>" + _
                    "<th>Sil</th>" + _
                "</tr>" + _
            "</thead>" + _
            "<tbody>"

        tabloson = "</tbody></table>"

        Dim komut As New SqlCommand

        sqlstr = "select * from msg where gonderenpkey=" + kimin + _
        " and gonderensilmismi='Hayır'"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI
        Dim gonderenad, gonderenpkey, alanpkey As String
        Dim girdi, gondermetarih, msgkonu, msgmetin As String
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
                End If

                If Not veri.Item("gondermetarih") Is System.DBNull.Value Then
                    gondermetarih = veri.Item("gondermetarih")
                    kol2 = "<td>" + gondermetarih + "</td>"
                End If


                If Not veri.Item("msgkonu") Is System.DBNull.Value Then
                    msgkonu = veri.Item("msgkonu")
                    kol3 = "<td>" + msgkonu + "</td>"
                Else
                    kol3 = "<td>-</td>"
                End If

                If Not veri.Item("msgmetin") Is System.DBNull.Value Then
                    msgmetin = veri.Item("msgmetin")
                    kol4 = "<td>" + msgmetin + "</td>"
                Else
                    kol4 = "<td>-</td>"
                End If

                'AJAX LINK SİL------
                ajaxlinksil = "msggonderensil(" + CStr(pkey) + ")"
                kol5 = "<td><span id='msgsilbutton' onclick='" + ajaxlinksil + "' class='button'>Sil</span>" + _
                "</td></tr>"

                satir = satir + kol1 + kol2 + kol3 + kol4 + kol5
                '---------------

            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "0" Then
            donecek = "<h2>Göndermiş olduğunuz herhangi bir mesajınız yoktur.</h2>"
        End If

        If girdi <> "0" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return donecek


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


        sqlstr = "update msg set " + _
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

    Public Function okunmadiyap(ByVal pkey As Integer) As CLADBOPRESULT

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand
        Dim sqlstr As String

        komut.Connection = db_baglanti

        sqlstr = "update msg set okunmusmu=@okunmusmu " + _
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


    'GELEN MESAJLARIMIN DÜĞMELERİNİ GÖSTERİR POP UP DAKİ
    Public Function msggostericerikmobil(ByVal pkey) As String

        Dim donecek As String
        Dim silbutton As String = ""
        Dim okundu_okunmadi_button As String = ""

        Dim msg As New CLASSMSG
        msg = bul(pkey)

        Dim gonderen As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        gonderen = kullanici_erisim.bultek(msg.gonderenpkey)

        If msg.okunmusmu = "Hayır" Then
            okundu_okunmadi_button = "<input onclick='msgoku(" + Chr(34) + CStr(pkey) + Chr(34) + _
            ")' id='okundu_okunmadi_button' type='button' data-icon='star' value='Okudum olarak işaretle'>"
        End If

        If msg.okunmusmu = "Evet" Then
            okundu_okunmadi_button = "<input onclick='msgokunmadi(" + Chr(34) + CStr(pkey) + Chr(34) + _
            ")' id='okundu_okunmadi_button' type='button' data-icon='star' value='Okumadım olarak işaretle'>"
        End If

        silbutton = "<input onclick='msgsilalan(" + Chr(34) + CStr(pkey) + Chr(34) + _
        ")' id='silbutton' type='button' data-icon='delete' value='Sil'>"

        donecek = okundu_okunmadi_button + silbutton

        Return donecek


    End Function



    'GÖNDERDİĞİM MESAJLARIMIN DÜĞMELERİNİ GÖSTERİR POP UP DAKİ
    Public Function msggostericerikgonderdigimmobil(ByVal pkey) As String

        Dim donecek As String
        Dim silbutton As String = ""

        Dim msg As New CLASSMSG
        msg = bul(pkey)

        Dim gonderen As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        gonderen = kullanici_erisim.bultek(msg.gonderenpkey)

        silbutton = "<input onclick='msgsilgonderen(" + Chr(34) + CStr(pkey) + Chr(34) + _
        ")' id='silbutton' type='button' data-icon='delete' value='Sil'>"

        donecek = silbutton

        Return donecek


    End Function


    'MOBİLDE GELEN MESAJLARI LİSTELER
    Public Function gelenmsglistele(ByVal uyepkey As String) As String

        Dim girdi As String = "0"
        Dim okunmusmu As String
        Dim saat As String
        Dim donecek As String
        Dim msglar As New List(Of CLASSMSG)
        msglar = doldurbenim(uyepkey)

        Dim gonderen As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


        For Each msgitem As CLASSMSG In msglar

            girdi = "1"

            gonderen = kullanici_erisim.bultek(msgitem.gonderenpkey)
            saat = CStr(msgitem.gondermetarih.Hour) + ":" + CStr(msgitem.gondermetarih.Minute)

            If msgitem.okunmusmu = "Evet" Then
                okunmusmu = "Okunmuş"
            Else
                okunmusmu = "Okunmamış"
            End If

            donecek = donecek + _
            "<li data-role=" + Chr(34) + "list-divider" + Chr(34) + ">" + _
            msgitem.gondermetarih.ToShortDateString + "<span class=" + Chr(34) + "ui-li-count" + Chr(34) + ">" + okunmusmu + "</span></li>" + _
            "<li data-icon='action'><a onclick='msggoster(" + Chr(34) + CStr(msgitem.pkey) + Chr(34) + ")'>" + _
            "<h3>" + gonderen.adsoyad + "</h3>" + _
            "<p><strong>" + msgitem.msgkonu + "</strong></p>" + _
            "<p>" + msgitem.msgmetin + "</p>" + _
            "<p class=" + Chr(34) + "ui-li-aside" + Chr(34) + "><strong>" + saat + "</strong></p>" + _
            "</a></li>"

        Next

        If girdi = "0" Then
            donecek = "Herhangi bir mesajınız yoktur."
        End If

        Return donecek

    End Function


    'MOBİLDE GÖNDERDİĞİM MESAJLARI LİSTELER
    Public Function gonderdigimmsglistele(ByVal uyepkey As String) As String

        Dim okunmusmu As String
        Dim saat As String
        Dim donecek As String
        Dim msglar As New List(Of CLASSMSG)
        msglar = doldurgonderdiklerim(uyepkey)

        Dim alan As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


        For Each msgitem As CLASSMSG In msglar

            alan = kullanici_erisim.bultek(msgitem.alanpkey)
            saat = CStr(msgitem.gondermetarih.Hour) + ":" + CStr(msgitem.gondermetarih.Minute)

            If msgitem.okunmusmu = "Evet" Then
                okunmusmu = "Okunmuş"
            Else
                okunmusmu = "Okunmamış"
            End If

            donecek = donecek + _
            "<li data-role=" + Chr(34) + "list-divider" + Chr(34) + ">" + _
            msgitem.gondermetarih.ToShortDateString + "<span class=" + Chr(34) + "ui-li-count" + Chr(34) + ">" + okunmusmu + "</span></li>" + _
            "<li data-icon='action'><a onclick='msggostergonderdiklerim(" + Chr(34) + CStr(msgitem.pkey) + Chr(34) + ")'>" + _
            "<h3>" + alan.adsoyad + "</h3>" + _
            "<p><strong>" + msgitem.msgkonu + "</strong></p>" + _
            "<p>" + msgitem.msgmetin + "</p>" + _
            "<p class=" + Chr(34) + "ui-li-aside" + Chr(34) + "><strong>" + saat + "</strong></p>" + _
            "</a></li>"

        Next

        Return donecek

    End Function


    Public Function msgonizle(ByVal kimin As String) As String

        Dim x As System.DBNull
        Dim pkey, donecek, basliklar, istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As New SqlCommand

        sqlstr = "select TOP (10) pkey " + _
        "from msg where alanpkey=@alanpkey " + _
        "and alansilmismi='Hayır' and okunmusmu='Hayır' order by gondermetarih desc;"

        komut.Connection = db_baglanti
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@alanpkey", SqlDbType.Int)
        komut.Parameters("@alanpkey").Value = CInt(kimin)

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kullanici As New CLASSKULLANICI

        Dim resim_erisim As New CLASSTEKRESIM_ERISIM


        Dim bmesaj As New CLASSMSG

        donecek = ""

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is x.Value Then
                    pkey = veri.Item("pkey")
                End If

                bmesaj = bul(pkey)
                kullanici = kullanici_erisim.bultek(bmesaj.gonderenpkey)

                donecek = donecek + _
                "<li>" + _
                "<a href='gelenmesaj.aspx'>" + _
                "<span class='photo'>" + _
                resim_erisim.loginresimolustur(kullanici.resimpkey) + _
                "</span>" + _
                "<span class='subject'>" + _
                "<span class='from'>" + _
                kullanici.adsoyad + _
                "</span>" + _
                "<span class='time'>" + _
                bmesaj.gondermetarih.Hour.ToString + ":" + Format(bmesaj.gondermetarih.Minute, "00") + _
                "</span>" + _
                "</span>" + _
                "<span class='message'>" + _
                bmesaj.msgkonu + _
                "</span>" + _
                "</a>" + _
                "</li>"

            End While

        End Using

        komut.Dispose()

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return donecek

    End Function


End Class

