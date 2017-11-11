Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSTUZUKDAIREARACTIPBAG_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tuzukdairearactipbag As CLASSTUZUKDAIREARACTIPBAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(tuzukdairearactipbag.tuzukaractippkey, tuzukdairearactipbag.dairearactippkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu eşleşme halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        Dim varmi2 As String = varmidairearactip(tuzukdairearactipbag.dairearactippkey)
        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Araç kayıt dairesindeki bu araç tipi halihazırda tüzükteki başka bir araç tipi ile eşleştirilmiş."
            resultset.etkilenen = 0
            Return resultset
        End If



        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into tuzukdairearactipbag values (@pkey," + _
        "@tuzukaractippkey,@dairearactippkey)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If tuzukdairearactipbag.tuzukaractippkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = tuzukdairearactipbag.tuzukaractippkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If tuzukdairearactipbag.dairearactippkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = tuzukdairearactipbag.dairearactippkey
        End If
        komut.Parameters.Add(param3)

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
        sqlstr = "select max(pkey) from tuzukdairearactipbag"
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
    Function Duzenle(ByVal tuzukdairearactipbag As CLASSTUZUKDAIREARACTIPBAG) As CLADBOPRESULT

        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(tuzukdairearactipbag.tuzukaractippkey, tuzukdairearactipbag.dairearactippkey, _
        tuzukdairearactipbag.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu eşleşme halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update tuzukdairearactipbag set " + _
        "tuzukaractippkey=@tuzukaractippkey," + _
        "dairearactippkey=@dairearactippkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukdairearactipbag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If tuzukdairearactipbag.tuzukaractippkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = tuzukdairearactipbag.tuzukaractippkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If tuzukdairearactipbag.dairearactippkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = tuzukdairearactipbag.dairearactippkey
        End If
        komut.Parameters.Add(param3)

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
    Function bultek(ByVal pkey As String) As CLASSTUZUKDAIREARACTIPBAG

        Dim komut As New SqlCommand
        Dim donecektuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("dairearactippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.dairearactippkey = veri.Item("dairearactippkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektuzukdairearactipbag

    End Function

    Function bultek_ilgili(ByVal dairearactippkey As integer) As CLASSTUZUKDAIREARACTIPBAG

        Dim komut As New SqlCommand
        Dim donecektuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where dairearactippkey=@dairearactippkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dairearactippkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("dairearactippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.dairearactippkey = veri.Item("dairearactippkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektuzukdairearactipbag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from tuzukdairearactipbag where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSTUZUKDAIREARACTIPBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG
        Dim tuzukdairearactipbagler As New List(Of CLASSTUZUKDAIREARACTIPBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from tuzukdairearactipbag"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("dairearactippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.dairearactippkey = veri.Item("dairearactippkey")
                End If

                tuzukdairearactipbagler.Add(New CLASSTUZUKDAIREARACTIPBAG(donecektuzukdairearactipbag.pkey, _
                donecektuzukdairearactipbag.tuzukaractippkey, donecektuzukdairearactipbag.dairearactippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tuzukdairearactipbagler

    End Function



    Public Function doldurilgili(ByVal tuzukaractippkey As Integer) As List(Of CLASSTUZUKDAIREARACTIPBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG
        Dim tuzukdairearactipbagler As New List(Of CLASSTUZUKDAIREARACTIPBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from tuzukdairearactipbag where tuzukaractippkey=@tuzukaractippkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("dairearactippkey") Is System.DBNull.Value Then
                    donecektuzukdairearactipbag.dairearactippkey = veri.Item("dairearactippkey")
                End If

                tuzukdairearactipbagler.Add(New CLASSTUZUKDAIREARACTIPBAG(donecektuzukdairearactipbag.pkey, _
                donecektuzukdairearactipbag.tuzukaractippkey, donecektuzukdairearactipbag.dairearactippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tuzukdairearactipbagler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
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
        "<th>Araç Tipi (Tüzükteki)</th>" + _
        "<th>Araç Tipi (Araç Kayıt Dairesi)</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from tuzukdairearactipbag"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, tuzukaractippkey, dairearactippkey As String

 
        Dim dairearactip As New CLASSDAIREARACTIP
        Dim dairearactip_erisim As New CLASSDAIREARACTIP_ERISIM

        Dim tuzukaractip As New CLASSTUZUKARACTIP
        Dim tuzukaractip_erisim As New CLASSTUZUKARACTIP_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "tuzukdairearactipbag.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                        tuzukaractippkey = veri.Item("tuzukaractippkey")
                        tuzukaractip = tuzukaractip_erisim.bultek(tuzukaractippkey)
                        kol2 = "<td>" + tuzukaractip.tuzukaractipad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("dairearactippkey") Is System.DBNull.Value Then
                        dairearactippkey = veri.Item("dairearactippkey")
                        dairearactip = dairearactip_erisim.bultek(dairearactippkey)
                        kol3 = "<td>" + dairearactip.dairearactipad + "</td></tr>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tuzukaractippkey As Integer, ByVal dairearactippkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where " + _
        "tuzukaractippkey=@tuzukaractippkey and dairearactippkey=@dairearactippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractippkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = dairearactippkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    '--- ÇİFT KAYIT KONTROL DÜZENLE -------------------------------------------------------
    Function ciftkayitkontrol_duzenle(ByVal tuzukaractippkey As Integer, ByVal dairearactippkey As Integer, _
    ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where " + _
        "tuzukaractippkey=@tuzukaractippkey and dairearactippkey=@dairearactippkey and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractippkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = dairearactippkey
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@pkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = pkey
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function varmidairearactip(ByVal dairearactippkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where  dairearactippkey=@dairearactippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dairearactippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        Return varmi

    End Function


    


    Function varmidairearactip(ByVal dairearactippkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where dairearactippkey=@dairearactippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@dairearactippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dairearactippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function

    Function varmituzukaractip(ByVal tuzukaractippkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukdairearactipbag where tuzukaractippkey=@tuzukaractippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function





End Class
