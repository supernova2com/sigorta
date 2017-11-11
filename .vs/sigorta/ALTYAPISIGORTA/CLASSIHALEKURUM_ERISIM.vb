Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data

Public Class CLASSIHALEKURUM_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim ihalekurum As New CLASSIHALEKURUM
    Dim resultset As New CLADBOPRESULT

    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal ihalekurum As CLASSIHALEKURUM) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi As Integer
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ihalekurumad", "=", ihalekurum.ihalekurumad, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "ihalekurum", "count(*)", fieldopvalues)

        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kurum halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into ihalekurum values (@pkey," + _
        "@ihalekurumad)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ihalekurumad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If ihalekurum.ihalekurumad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ihalekurum.ihalekurumad
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
        sqlstr = "select max(pkey) from ihalekurum"
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
    Function Duzenle(ByVal ihalekurum As CLASSIHALEKURUM) As CLADBOPRESULT


        Dim varmi As Integer

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ihalekurumad", "=", ihalekurum.ihalekurumad, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", ihalekurum.pkey, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "ihalekurum", "count(*)", fieldopvalues)

        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kurum halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update ihalekurum set " + _
        "ihalekurumad=@ihalekurumad" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ihalekurum.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ihalekurumad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If ihalekurum.ihalekurumad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ihalekurum.ihalekurumad
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
    Function bultek(ByVal pkey As String) As CLASSIHALEKURUM

        Dim komut As New SqlCommand
        Dim donecekihalekurum As New CLASSIHALEKURUM()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ihalekurum where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekihalekurum.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ihalekurumad") Is System.DBNull.Value Then
                    donecekihalekurum.ihalekurumad = veri.Item("ihalekurumad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekihalekurum

    End Function

  

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from ihalekurum where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSIHALEKURUM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekihalekurum As New CLASSIHALEKURUM
        Dim ihalekurumler As New List(Of CLASSIHALEKURUM)
        komut.Connection = db_baglanti
        sqlstr = "select * from ihalekurum"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekihalekurum.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ihalekurumad") Is System.DBNull.Value Then
                    donecekihalekurum.ihalekurumad = veri.Item("ihalekurumad")
                End If


                ihalekurumler.Add(New CLASSIHALEKURUM(donecekihalekurum.pkey, _
                donecekihalekurum.ihalekurumad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ihalekurumler

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
        "<th>Kurum Adı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from ihalekurum"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, ihalekurumad As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "ihalekurum.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("ihalekurumad") Is System.DBNull.Value Then
                        ihalekurumad = veri.Item("ihalekurumad")
                        kol2 = "<td>" + ihalekurumad + "</td></tr>"
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


    Public Function kurumkontrol(ByVal PolicyInfo As PolicyInfo) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim varmi As String = "Hayır"
        Dim ihalekurumlar As New List(Of CLASSIHALEKURUM)

        ihalekurumlar = doldur()

        For Each Item As CLASSIHALEKURUM In ihalekurumlar
            If Item.ihalekurumad = PolicyInfo.PolicyOwnerName Then
                varmi = "Evet"
                Exit For
            End If
        Next

        If varmi = "Hayır" Then
            result.durum = "Evet"
            result.etkilenen = 1
            result.hatastr = "PolicyOwnerName'de göndermiş olduğunuz İhale Kurum adı KKSBM tarafından tanımlanmamış."
            Return result
        End If

        result.durum = "Hayır"
        result.etkilenen = 0
        result.hatastr = ""

        Return result


    End Function


End Class
