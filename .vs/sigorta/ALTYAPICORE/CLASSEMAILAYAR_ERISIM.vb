Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class CLASSEMAILAYAR_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim site As New CLASSSITE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull

    Public Function ekle(ByVal emailayar As CLASSEMAILAYAR) As CLADBOPRESULT

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand

        sqlstr = "insert into emailayar values (@pkey,@username,@password," + _
        "@portnumber, @sslvarmi,@oncelik,@pickupdirectorylocation,@hostname," + _
        "@usedefaultcredentials,@deliverymethod,@udckullan)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = pkeybul()

        komut.Parameters.Add("@username", SqlDbType.VarChar, 254)
        komut.Parameters("@username").Value = emailayar.username

        komut.Parameters.Add("@password", SqlDbType.VarChar, 254)
        komut.Parameters("@password").Value = emailayar.password

        komut.Parameters.Add("@portnumber", SqlDbType.VarChar, 254)
        komut.Parameters("@portnumber").Value = emailayar.portnumber

        komut.Parameters.Add("@sslvarmi", SqlDbType.VarChar, 254)
        komut.Parameters("@sslvarmi").Value = emailayar.sslvarmi

        komut.Parameters.Add("@oncelik", SqlDbType.VarChar, 254)
        komut.Parameters("@oncelik").Value = emailayar.oncelik

        komut.Parameters.Add("@pickupdirectorylocation", SqlDbType.VarChar, 254)
        komut.Parameters("@pickupdirectorylocation").Value = emailayar.pickupdirectorylocation

        komut.Parameters.Add("@hostname", SqlDbType.VarChar, 254)
        komut.Parameters("@hostname").Value = emailayar.hostname

        komut.Parameters.Add("@usedefaultcredentials", SqlDbType.VarChar, 254)
        komut.Parameters("@usedefaultcredentials").Value = emailayar.usedefaultcredentials

        komut.Parameters.Add("@deliverymethod", SqlDbType.VarChar, 254)
        komut.Parameters("@deliverymethod").Value = emailayar.deliverymethod

        komut.Parameters.Add("@udckullan", SqlDbType.VarChar, 254)
        komut.Parameters("@udckullan").Value = emailayar.udckullan

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



    Public Function doldur() As List(Of CLASSEMAILAYAR)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekemailayar As New CLASSEMAILAYAR
        Dim emailayarlar As New List(Of CLASSEMAILAYAR)

        sqlstr = "select * from emailayar"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekemailayar.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("username") Is System.DBNull.Value Then
                    donecekemailayar.username = veri.Item("username")
                End If

                If Not veri.Item("password") Is System.DBNull.Value Then
                    donecekemailayar.password = veri.Item("password")
                End If

                If Not veri.Item("portnumber") Is System.DBNull.Value Then
                    donecekemailayar.portnumber = veri.Item("portnumber")
                End If

                If Not veri.Item("sslvarmi") Is System.DBNull.Value Then
                    donecekemailayar.sslvarmi = veri.Item("sslvarmi")
                End If

                If Not veri.Item("oncelik") Is System.DBNull.Value Then
                    donecekemailayar.oncelik = veri.Item("oncelik")
                End If

                If Not veri.Item("pickupdirectorylocation") Is System.DBNull.Value Then
                    donecekemailayar.pickupdirectorylocation = veri.Item("pickupdirectorylocation")
                End If

                If Not veri.Item("hostname") Is System.DBNull.Value Then
                    donecekemailayar.hostname = veri.Item("hostname")
                End If

                If Not veri.Item("usedefaultcredentials") Is System.DBNull.Value Then
                    donecekemailayar.usedefaultcredentials = veri.Item("usedefaultcredentials")
                End If

                If Not veri.Item("deliverymethod") Is System.DBNull.Value Then
                    donecekemailayar.deliverymethod = veri.Item("deliverymethod")
                End If

                If Not veri.Item("udckullan") Is System.DBNull.Value Then
                    donecekemailayar.udckullan = veri.Item("udckullan")
                End If

                emailayarlar.Add(New CLASSEMAILAYAR(donecekemailayar.pkey, _
                donecekemailayar.username, donecekemailayar.password, _
                donecekemailayar.portnumber, donecekemailayar.sslvarmi, _
                donecekemailayar.oncelik, donecekemailayar.pickupdirectorylocation, _
                donecekemailayar.hostname, donecekemailayar.usedefaultcredentials, _
                donecekemailayar.deliverymethod, donecekemailayar.udckullan))

            End While
        End Using


        db_baglanti.Close()

        Return emailayarlar

    End Function


    Public Function bul(ByVal pkey As String) As CLASSEMAILAYAR

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekemailayar As New CLASSEMAILAYAR

        sqlstr = "select * from emailayar where pkey=" + pkey
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekemailayar.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("username") Is System.DBNull.Value Then
                    donecekemailayar.username = veri.Item("username")
                End If

                If Not veri.Item("password") Is System.DBNull.Value Then
                    donecekemailayar.password = veri.Item("password")
                End If

                If Not veri.Item("portnumber") Is System.DBNull.Value Then
                    donecekemailayar.portnumber = veri.Item("portnumber")
                End If

                If Not veri.Item("sslvarmi") Is System.DBNull.Value Then
                    donecekemailayar.sslvarmi = veri.Item("sslvarmi")
                End If

                If Not veri.Item("oncelik") Is System.DBNull.Value Then
                    donecekemailayar.oncelik = veri.Item("oncelik")
                End If

                If Not veri.Item("pickupdirectorylocation") Is System.DBNull.Value Then
                    donecekemailayar.pickupdirectorylocation = veri.Item("pickupdirectorylocation")
                End If

                If Not veri.Item("hostname") Is System.DBNull.Value Then
                    donecekemailayar.hostname = veri.Item("hostname")
                End If

                If Not veri.Item("usedefaultcredentials") Is System.DBNull.Value Then
                    donecekemailayar.usedefaultcredentials = veri.Item("usedefaultcredentials")
                End If

                If Not veri.Item("deliverymethod") Is System.DBNull.Value Then
                    donecekemailayar.deliverymethod = veri.Item("deliverymethod")
                End If

                If Not veri.Item("udckullan") Is System.DBNull.Value Then
                    donecekemailayar.udckullan = veri.Item("udckullan")
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekemailayar

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

        sqlstr = "select max(pkey) from emailayar"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            pkey = 1
        Else
            pkey = maxkayit1 + 1
        End If

        db_baglanti.Close()

        Return pkey

    End Function


    Public Function sil(ByVal pkey As String) As CLADBOPRESULT

        Dim istring, sqldel As String


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        Dim db_baglanti As SqlConnection
        db_baglanti = New SqlConnection(istring)
        Dim komut As SqlCommand

        db_baglanti.Open()

        sqldel = "delete from emailayar where pkey=@pkey"
        komut = New SqlCommand(sqldel, db_baglanti)

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


    Public Function guncelle(ByVal emailayar As CLASSEMAILAYAR) As CLADBOPRESULT

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand

        sqlstr = "update emailayar set " + _
        "username=@username, " + _
        "password=@password, " + _
        "portnumber=@portnumber, " + _
        "sslvarmi=@sslvarmi, " + _
        "oncelik=@oncelik, " + _
        "pickupdirectorylocation=@pickupdirectorylocation, " + _
        "hostname=@hostname, " + _
        "usedefaultcredentials=@usedefaultcredentials, " + _
        "deliverymethod=@deliverymethod, " + _
        "udckullan=@udckullan" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@username", SqlDbType.VarChar, 254)
        komut.Parameters("@username").Value = emailayar.username

        komut.Parameters.Add("@password", SqlDbType.VarChar, 254)
        komut.Parameters("@password").Value = emailayar.password

        komut.Parameters.Add("@portnumber", SqlDbType.VarChar, 254)
        komut.Parameters("@portnumber").Value = emailayar.portnumber

        komut.Parameters.Add("@sslvarmi", SqlDbType.VarChar, 254)
        komut.Parameters("@sslvarmi").Value = emailayar.sslvarmi

        komut.Parameters.Add("@oncelik", SqlDbType.VarChar, 254)
        komut.Parameters("@oncelik").Value = emailayar.oncelik

        komut.Parameters.Add("@pickupdirectorylocation", SqlDbType.VarChar, 254)
        komut.Parameters("@pickupdirectorylocation").Value = emailayar.pickupdirectorylocation

        komut.Parameters.Add("@hostname", SqlDbType.VarChar, 254)
        komut.Parameters("@hostname").Value = emailayar.hostname

        komut.Parameters.Add("@usedefaultcredentials", SqlDbType.VarChar, 254)
        komut.Parameters("@usedefaultcredentials").Value = emailayar.usedefaultcredentials

        komut.Parameters.Add("@deliverymethod", SqlDbType.VarChar, 254)
        komut.Parameters("@deliverymethod").Value = emailayar.deliverymethod

        komut.Parameters.Add("@udckullan", SqlDbType.VarChar, 254)
        komut.Parameters("@udckullan").Value = emailayar.udckullan

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = emailayar.pkey


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

    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11 As String
        Dim tabloson As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
            "<thead>" + _
                "<tr>" + _
                    "<th>Anahtar</th>" + _
                    "<th>E-Mail Kullanıcı Adı (Username)</th>" + _
                    "<th>E-Mail Password (Password)</th>" + _
                    "<th>Port Number</th>" + _
                    "<th>SSL Varmı?</th>" + _
                    "<th>Öncelik</th>" + _
                    "<th>Pickup Directory Location</th>" + _
                    "<th>Smtp Server Hostname</th>" + _
                    "<th>Use Default Credentials</th>" + _
                    "<th>Delivery Method</th>" + _
                    "<th>UDC Kullanılıyor mu?</th>" + _
                "</tr>" + _
                "</thead>" + _
            "<tbody>"

        tabloson = "</tbody></table>"


        Dim sqlstr, istring As String
        Dim girdi As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand

        '--- ARAMA İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then

            sqlstr = "select * from emailayar"
            komut = New SqlCommand(sqlstr, db_baglanti)

        End If

        If HttpContext.Current.Session("ltip") = "hostname" Then

            sqlstr = "select * from emailayar where hostname=@kriter"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"

        Dim link, pkey, username As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                    End If

                    link = "emailayar.aspx?pkey=" + CStr(pkey) + "&op=duzenle"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("username") Is System.DBNull.Value Then
                        username = CStr(veri.Item("username"))
                        kol2 = "<td>" + username + "</td>"
                    End If

                    If Not veri.Item("password") Is System.DBNull.Value Then
                        kol3 = "<td>" + veri.Item("password") + "</td>"
                    End If

                    If Not veri.Item("portnumber") Is System.DBNull.Value Then
                        kol4 = "<td>" + CStr(veri.Item("portnumber")) + "</td>"
                    End If

                    If Not veri.Item("sslvarmi") Is System.DBNull.Value Then
                        kol5 = "<td>" + veri.Item("sslvarmi") + "</td>"
                    End If

                    If Not veri.Item("oncelik") Is System.DBNull.Value Then
                        kol6 = "<td>" + veri.Item("oncelik") + "</td>"
                    End If

                    If Not veri.Item("pickupdirectorylocation") Is System.DBNull.Value Then
                        kol7 = "<td>" + veri.Item("pickupdirectorylocation") + "</td>"
                    End If

                    If Not veri.Item("hostname") Is System.DBNull.Value Then
                        kol8 = "<td>" + veri.Item("hostname") + "</td>"
                    End If

                    If Not veri.Item("usedefaultcredentials") Is System.DBNull.Value Then
                        kol9 = "<td>" + veri.Item("usedefaultcredentials") + "</td>"
                    End If

                    If Not veri.Item("deliverymethod") Is System.DBNull.Value Then
                        kol10 = "<td>" + veri.Item("deliverymethod") + "</td>"
                    End If

                    If Not veri.Item("udckullan") Is System.DBNull.Value Then
                        kol11 = "<td>" + veri.Item("udckullan") + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11

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

    Function ara(ByVal kriter As String) As List(Of CLASSEMAILAYAR)

        Dim sqls, istring As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim db_baglanti As SqlConnection
        Dim komut As SqlCommand
        Dim tekemailayar As New CLASSEMAILAYAR
        Dim emailayarlar As New List(Of CLASSEMAILAYAR)
        Dim x As System.DBNull


        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqls = "select * from emailayar where hostname like '%" + kriter + "%'"
        komut = New SqlCommand(sqls, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    tekemailayar.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("username") Is System.DBNull.Value Then
                    tekemailayar.username = veri.Item("username")
                End If

                If Not veri.Item("password") Is System.DBNull.Value Then
                    tekemailayar.password = veri.Item("password")
                End If

                If Not veri.Item("portnumber") Is System.DBNull.Value Then
                    tekemailayar.portnumber = veri.Item("portnumber")
                End If

                If Not veri.Item("sslvarmi") Is System.DBNull.Value Then
                    tekemailayar.sslvarmi = veri.Item("sslvarmi")
                End If

                If Not veri.Item("oncelik") Is System.DBNull.Value Then
                    tekemailayar.oncelik = veri.Item("oncelik")
                End If

                If Not veri.Item("pickupdirectorylocation") Is System.DBNull.Value Then
                    tekemailayar.pickupdirectorylocation = veri.Item("pickupdirectorylocation")
                End If

                If Not veri.Item("hostname") Is System.DBNull.Value Then
                    tekemailayar.hostname = veri.Item("hostname")
                End If

                If Not veri.Item("usedefaultcredentials") Is System.DBNull.Value Then
                    tekemailayar.usedefaultcredentials = veri.Item("usedefaultcredentials")
                End If

                If Not veri.Item("deliverymethod") Is System.DBNull.Value Then
                    tekemailayar.deliverymethod = veri.Item("deliverymethod")
                End If

                If Not veri.Item("udckullan") Is System.DBNull.Value Then
                    tekemailayar.udckullan = veri.Item("udckullan")
                End If

                emailayarlar.Add(New CLASSEMAILAYAR(tekemailayar.pkey, _
                tekemailayar.username, tekemailayar.password, _
                tekemailayar.portnumber, tekemailayar.sslvarmi, _
                tekemailayar.oncelik, tekemailayar.pickupdirectorylocation, _
                tekemailayar.hostname, tekemailayar.usedefaultcredentials, _
                tekemailayar.deliverymethod, tekemailayar.udckullan))

            End While
        End Using


        db_baglanti.Close()

        Return emailayarlar

    End Function


    '--- KAYIT SAYISI -------------------------------------------------------
    Function kayitsayisibul() As Integer

        Dim kayitsayisi As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select max(pkey) from emailayar"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitsayisi = 0
        Else
            kayitsayisi = maxkayit1
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitsayisi

    End Function


End Class
