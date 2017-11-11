Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data


Public Class CLASSSINIRKAPIARACTIP_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sinirkapiaractip As CLASSSINIRKAPIARACTIP) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String

        varmi = ciftkayitkontrol(sinirkapiaractip.sinirkapiaractipad)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu adda kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into sinirkapiaractip values (@pkey," + _
        "@sinirkapiaractipad)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiaractipad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If sinirkapiaractip.sinirkapiaractipad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = sinirkapiaractip.sinirkapiaractipad
        End If
        komut.Parameters.Add(param2)

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
        sqlstr = "select max(pkey) from sinirkapiaractip"
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
    Function Duzenle(ByVal sinirkapiaractip As CLASSSINIRKAPIARACTIP) As CLADBOPRESULT


        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(sinirkapiaractip.sinirkapiaractipad, sinirkapiaractip.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu adda kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If


        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sinirkapiaractip set " + _
        "sinirkapiaractipad=@sinirkapiaractipad" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapiaractip.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiaractipad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If sinirkapiaractip.sinirkapiaractipad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = sinirkapiaractip.sinirkapiaractipad
        End If
        komut.Parameters.Add(param2)

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
    Function bultek(ByVal pkey As String) As CLASSSINIRKAPIARACTIP

        Dim komut As New SqlCommand
        Dim doneceksinirkapiaractip As New CLASSSINIRKAPIARACTIP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiaractip where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapiaractip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapiaractipad") Is System.DBNull.Value Then
                    doneceksinirkapiaractip.sinirkapiaractipad = veri.Item("sinirkapiaractipad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksinirkapiaractip

    End Function

    Function bultek_adagore(ByVal sinirkapiaractipad As String) As CLASSSINIRKAPIARACTIP

        Dim komut As New SqlCommand
        Dim doneceksinirkapiaractip As New CLASSSINIRKAPIARACTIP
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiaractip where sinirkapiaractipad=@sinirkapiaractipad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sinirkapiaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapiaractipad
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapiaractip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapiaractipad") Is System.DBNull.Value Then
                    doneceksinirkapiaractip.sinirkapiaractipad = veri.Item("sinirkapiaractipad")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksinirkapiaractip

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        Dim tarifesinirkapi_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM
        Dim varmi As String

        varmi = tarifesinirkapi_erisim.varmisinirkapiaractip(pkey)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araç tipi tarife kodu ile eşleşmiş. Bu araç tipini silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from sinirkapiaractip where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSINIRKAPIARACTIP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksinirkapiaractip As New CLASSSINIRKAPIARACTIP
        Dim sinirkapiaractipler As New List(Of CLASSSINIRKAPIARACTIP)
        komut.Connection = db_baglanti
        sqlstr = "select * from sinirkapiaractip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapiaractip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapiaractipad") Is System.DBNull.Value Then
                    doneceksinirkapiaractip.sinirkapiaractipad = veri.Item("sinirkapiaractipad")
                End If


                sinirkapiaractipler.Add(New CLASSSINIRKAPIARACTIP(doneceksinirkapiaractip.pkey, _
                doneceksinirkapiaractip.sinirkapiaractipad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sinirkapiaractipler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2 As String
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
        "<th>Düzenle</th>" + _
        "<th>Araç Tip Adı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from sinirkapiaractip"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sinirkapiaractipad As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "sinirkapiaractip.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("sinirkapiaractipad") Is System.DBNull.Value Then
                        sinirkapiaractipad = veri.Item("sinirkapiaractipad")
                        kol2 = "<td>" + sinirkapiaractipad + "</td></tr>"
                    Else
                        kol2 = "<td>-</td></tr>"
                    End If


                    satir = satir + kol1 + kol2
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
    Function ciftkayitkontrol(ByVal sinirkapiaractipad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiaractip where sinirkapiaractipad=@sinirkapiaractipad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapiaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapiaractipad
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


    Function ciftkayitkontrol_duzenle(ByVal sinirkapiaractipad As String, ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiaractip where sinirkapiaractipad=@sinirkapiaractipad and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapiaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapiaractipad
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = pkey
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


End Class


