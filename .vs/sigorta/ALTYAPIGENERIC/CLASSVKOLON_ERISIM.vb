Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSVKOLON_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim vkolon As New CLASSVKOLON
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal vkolon As CLASSVKOLON) As CLADBOPRESULT

        etkilenen = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into vkolon values (@pkey," + _
        "@tabload,@kolonad,@kolonaciklama)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If vkolon.tabload = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = vkolon.tabload
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kolonad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If vkolon.kolonad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = vkolon.kolonad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kolonaciklama", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If vkolon.kolonaciklama = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = vkolon.kolonaciklama
        End If
        komut.Parameters.Add(param4)

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
        sqlstr = "select max(pkey) from vkolon"
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
    Function Duzenle(ByVal vkolon As CLASSVKOLON) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update vkolon set " + _
        "tabload=@tabload," + _
        "kolonad=@kolonad," + _
        "kolonaciklama=@kolonaciklama" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = vkolon.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If vkolon.tabload = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = vkolon.tabload
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kolonad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If vkolon.kolonad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = vkolon.kolonad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kolonaciklama", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If vkolon.kolonaciklama = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = vkolon.kolonaciklama
        End If
        komut.Parameters.Add(param4)


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
    Function bultek(ByVal pkey As String) As CLASSVKOLON

        Dim komut As New SqlCommand
        Dim donecekvkolon As New CLASSVKOLON()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from vkolon where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekvkolon.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekvkolon.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("kolonad") Is System.DBNull.Value Then
                    donecekvkolon.kolonad = veri.Item("kolonad")
                End If

                If Not veri.Item("kolonaciklama") Is System.DBNull.Value Then
                    donecekvkolon.kolonaciklama = veri.Item("kolonaciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekvkolon

    End Function


    '--------------------------bul tabloaad'a göre-----------------------------------------
    Function bultablovekolonadagore(ByVal tabload As String, _
    ByVal kolonad As String) As CLASSVKOLON

        Dim komut As New SqlCommand
        Dim donecekvkolon As New CLASSVKOLON
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from vkolon where tabload=@tabload and kolonad=@kolonad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kolonad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kolonad
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekvkolon.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekvkolon.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("kolonad") Is System.DBNull.Value Then
                    donecekvkolon.kolonad = veri.Item("kolonad")
                End If

                If Not veri.Item("kolonaciklama") Is System.DBNull.Value Then
                    donecekvkolon.kolonaciklama = veri.Item("kolonaciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekvkolon

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from vkolon where pkey=@pkey"
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


    '---------------------------------sil-----------------------------------------
    Public Function ilgilitablosil(ByVal tabload As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from vkolon where tabload=@tabload"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload
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
    Public Function doldur() As List(Of CLASSVKOLON)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekvkolon As New CLASSVKOLON
        Dim vkolonler As New List(Of CLASSVKOLON)
        komut.Connection = db_baglanti
        sqlstr = "select * from vkolon"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekvkolon.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekvkolon.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("kolonad") Is System.DBNull.Value Then
                    donecekvkolon.kolonad = veri.Item("kolonad")
                End If

                If Not veri.Item("kolonaciklama") Is System.DBNull.Value Then
                    donecekvkolon.kolonaciklama = veri.Item("kolonaciklama")
                End If


                vkolonler.Add(New CLASSVKOLON(donecekvkolon.pkey, _
                donecekvkolon.tabload, donecekvkolon.kolonad, donecekvkolon.kolonaciklama))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return vkolonler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
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
        "<th>Tablo Adı</th>" + _
        "<th>Kolon Adı</th>" + _
        "<th>Kolon Açıklaması</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "tabloyagore" Then
            sqlstr = "select * from vkolon where tabload=@tabload "
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@tabload", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("tabload")
            komut.Parameters.Add(param1)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, tabload, kolonad, kolonaciklama As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    tabload = ""
                    If Not veri.Item("tabload") Is System.DBNull.Value Then
                        tabload = veri.Item("tabload")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "vkolongirispopup.aspx?tabload=" + CStr(tabload) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("tabload") Is System.DBNull.Value Then
                        tabload = veri.Item("tabload")
                        kol2 = "<td>" + tabload + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kolonad") Is System.DBNull.Value Then
                        kolonad = veri.Item("kolonad")
                        kol3 = "<td>" + kolonad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("kolonaciklama") Is System.DBNull.Value Then
                        kolonaciklama = veri.Item("kolonaciklama")
                        kol4 = "<td>" + kolonaciklama + "</td></tr>"
                    Else
                        kol4 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4
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



    Public Function inputlariolustur(ByVal tabload As String) As String

        Dim tekinput As String
        Dim teksatir As String = ""
        Dim oid As String
        Dim donecek As String = ""
        Dim basliklar, tabloson As String
        Dim valuestr As String = ""
        Dim classstr As String

        classstr = " class=" + Chr(34) + "textboxuzun" + Chr(34) + " AutoComplete=" + Chr(34) + "Off" + Chr(34)

        basliklar = "<table id=sonuctable class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th id='bb1'>Kolon Adı</th>" + _
        "<th id='bb2'>Kolon Açıklama</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim vkolon As New CLASSVKOLON
        Dim kolonlar As New List(Of CLASSVERITABANI)
        Dim sqlveritabanierisim_erisim As New CLASSSQLVERITABANI_ERISIM

        kolonlar = sqlveritabanierisim_erisim.bulkolonadlari(site.sistemveritabaniad, tabload)

        Dim a As Integer = 1

        For Each itemkolon As CLASSVERITABANI In kolonlar
            teksatir = teksatir + "<tr><td>" + itemkolon.ilgiliad + "</td>"

            vkolon = bultablovekolonadagore(tabload, itemkolon.ilgiliad)

            For i = 1 To 1


                valuestr = ""

                If i = 1 Then
                    valuestr = " value=" + Chr(34) + CStr(vkolon.kolonaciklama) + Chr(34) + " "
                End If

                oid = CStr(itemkolon.ilgiliad) + "_" + CStr(i)
                tekinput = "<input type=" + Chr(34) + "text" + Chr(34) + _
                " id=" + Chr(34) + "A" + oid + Chr(34) + _
                " name=" + Chr(34) + "A" + oid + Chr(34) + _
                classstr + valuestr + "></input>"

                teksatir = teksatir + "<td id='" + "zz" + CStr(a) + "-" + CStr(i) + "'>" + tekinput + "</td>"

            Next
            teksatir = teksatir + "</tr>"
        Next

        donecek = basliklar + teksatir + tabloson

        Return donecek

    End Function


    Public Function temizle(ByVal vkolon As CLASSVKOLON) As CLASSVKOLON

        vkolon.pkey = 0
        vkolon.tabload = ""
        vkolon.kolonad = ""
        vkolon.kolonaciklama = ""
        Return vkolon

    End Function


End Class


