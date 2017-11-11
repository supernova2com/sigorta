Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf



Public Class CLASSPLAKASINIRKAPI_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim plakasinirkapi As New CLASSPLAKASINIRKAPI
    Dim resultset As New CLADBOPRESULT

    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal plakasinirkapi As CLASSPLAKASINIRKAPI) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi As Integer
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "plaka", "=", plakasinirkapi.plaka, ""))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "plakasinirkapi", "count(*)", fieldopvalues)

        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu plaka sınır kapıları için halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into plakasinirkapi values (@pkey," + _
        "@plaka)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If plakasinirkapi.plaka = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = plakasinirkapi.plaka
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
        sqlstr = "select max(pkey) from plakasinirkapi"
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
    Function Duzenle(ByVal plakasinirkapi As CLASSPLAKASINIRKAPI) As CLADBOPRESULT

        Dim varmi As Integer

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "plaka", "=", plakasinirkapi.plaka, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", plakasinirkapi.pkey, ""))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "plakasinirkapi", "count(*)", fieldopvalues)

        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu plaka sınır kapıları için halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update plakasinirkapi set " + _
        "plaka=@plaka" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = plakasinirkapi.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If plakasinirkapi.plaka = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = plakasinirkapi.plaka
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
    Function bultek(ByVal pkey As String) As CLASSPLAKASINIRKAPI

        Dim komut As New SqlCommand
        Dim donecekplakasinirkapi As New CLASSPLAKASINIRKAPI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from plakasinirkapi where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakasinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakasinirkapi.plaka = veri.Item("plaka")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekplakasinirkapi

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from plakasinirkapi where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSPLAKASINIRKAPI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekplakasinirkapi As New CLASSPLAKASINIRKAPI
        Dim plakasinirkapiler As New List(Of CLASSPLAKASINIRKAPI)
        komut.Connection = db_baglanti
        sqlstr = "select * from plakasinirkapi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakasinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakasinirkapi.plaka = veri.Item("plaka")
                End If

                plakasinirkapiler.Add(New CLASSPLAKASINIRKAPI(donecekplakasinirkapi.pkey, _
                donecekplakasinirkapi.plaka))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return plakasinirkapiler

    End Function


    Public Function doldur_plakayagore(ByVal plaka As String) As List(Of CLASSPLAKASINIRKAPI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekplakasinirkapi As New CLASSPLAKASINIRKAPI
        Dim plakasinirkapiler As New List(Of CLASSPLAKASINIRKAPI)
        komut.Connection = db_baglanti
        sqlstr = "select * from plakasinirkapi where plaka LIKE @plaka+'%'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = plaka
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekplakasinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekplakasinirkapi.plaka = veri.Item("plaka")
                End If

                plakasinirkapiler.Add(New CLASSPLAKASINIRKAPI(donecekplakasinirkapi.pkey, donecekplakasinirkapi.plaka))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return plakasinirkapiler

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
        "<th>Anahtar</th>" + _
        "<th>Plaka</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from plakasinirkapi"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "ARAMA" Then
            sqlstr = "select * from plakasinirkapi where plaka LIKE '%'+@plaka+'%' order by plaka"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@plaka", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("plaka")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, plaka As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "plakasinirkapi.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("plaka") Is System.DBNull.Value Then
                        plaka = veri.Item("plaka")
                        kol2 = "<td>" + plaka + "</td></tr>"
                    Else
                        kol2 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2
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

    Public Function kacadet(ByVal plaka As String) As Integer

        Dim varmi As Integer = 0
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "plaka", "=", plaka, ""))
        varmi = genericislem_erisim.countgeneric(System.Configuration.ConfigurationManager.AppSettings("veritabaniad"), "plakasinirkapi", "count(*)", fieldopvalues)
        Return varmi

    End Function




End Class
