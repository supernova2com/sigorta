Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data

Public Class CLASSTUZUKARACTIP_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tuzukaractip As New CLASSTUZUKARACTIP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tuzukaractip As CLASSTUZUKARACTIP) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String

        varmi = ciftkayitkontrol(tuzukaractip.tuzukaractipad)
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
        sqlstr = "insert into tuzukaractip values (@pkey," + _
        "@tuzukaractipad)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tuzukaractipad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If tuzukaractip.tuzukaractipad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = tuzukaractip.tuzukaractipad
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
        sqlstr = "select max(pkey) from tuzukaractip"
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
    Function Duzenle(ByVal tuzukaractip As CLASSTUZUKARACTIP) As CLADBOPRESULT


        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(tuzukaractip.tuzukaractipad, tuzukaractip.pkey)

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
        sqlstr = "update tuzukaractip set " + _
        "tuzukaractipad=@tuzukaractipad" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractip.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tuzukaractipad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If tuzukaractip.tuzukaractipad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = tuzukaractip.tuzukaractipad
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
    Function bultek(ByVal pkey As String) As CLASSTUZUKARACTIP

        Dim komut As New SqlCommand
        Dim donecektuzukaractip As New CLASSTUZUKARACTIP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukaractip where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukaractip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractipad") Is System.DBNull.Value Then
                    donecektuzukaractip.tuzukaractipad = veri.Item("tuzukaractipad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektuzukaractip

    End Function

    Function bultek_adagore(ByVal tuzukaractipad As String) As CLASSTUZUKARACTIP

        Dim komut As New SqlCommand
        Dim donecektuzukaractip As New CLASSTUZUKARACTIP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukaractip where tuzukaractipad=@tuzukaractipad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tuzukaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractipad
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukaractip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractipad") Is System.DBNull.Value Then
                    donecektuzukaractip.tuzukaractipad = veri.Item("tuzukaractipad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektuzukaractip

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        Dim varmi As String
        Dim tuzukdairearactipbag_erisim As New CLASSTUZUKDAIREARACTIPBAG_ERISIM
        Dim cc_erisim As New CLASSCC_ERISIM

        varmi = tuzukdairearactipbag_erisim.varmituzukaractip(pkey)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araç tipi eşleştirilmiş. Bu kaydı silemezsiniz. "
            resultset.etkilenen = 0
            Return resultset
        End If

        varmi = cc_erisim.varmituzukaractip(pkey)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araç tipi için CC Zam oranı tanımlanmış. Bu sebepten bu kaydı silemezsiniz. "
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from tuzukaractip where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSTUZUKARACTIP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektuzukaractip As New CLASSTUZUKARACTIP
        Dim tuzukaractipler As New List(Of CLASSTUZUKARACTIP)
        komut.Connection = db_baglanti
        sqlstr = "select * from tuzukaractip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektuzukaractip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractipad") Is System.DBNull.Value Then
                    donecektuzukaractip.tuzukaractipad = veri.Item("tuzukaractipad")
                End If


                tuzukaractipler.Add(New CLASSTUZUKARACTIP(donecektuzukaractip.pkey, _
                donecektuzukaractip.tuzukaractipad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tuzukaractipler

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
        "<th>Tüzükte Geçen Araç Tip Adı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from tuzukaractip"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, tuzukaractipad As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "tuzukaractip.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("tuzukaractipad") Is System.DBNull.Value Then
                        tuzukaractipad = veri.Item("tuzukaractipad")
                        kol2 = "<td>" + tuzukaractipad + "</td></tr>"
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
    Function ciftkayitkontrol(ByVal tuzukaractipad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukaractip where tuzukaractipad=@tuzukaractipad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractipad
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function ciftkayitkontrol_duzenle(ByVal tuzukaractipad As String, ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukaractip where tuzukaractipad=@tuzukaractipad and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractipad
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = pkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function varmiaractip(ByVal tuzukaractipad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tuzukaractip where tuzukaractipad=@tuzukaractipad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractipad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractipad
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
