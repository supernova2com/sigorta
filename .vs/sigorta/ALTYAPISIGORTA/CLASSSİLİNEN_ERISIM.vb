Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSSİLİNEN_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim silinen As New CLASSSİLİNEN
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal silinen As CLASSSİLİNEN) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into silinen values (@pkey," + _
        "@ne,@xmlstr,@tarih,@kimpkey)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ne", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If silinen.ne = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = silinen.ne
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@xmlstr", SqlDbType.Text)
        param3.Direction = ParameterDirection.Input
        If silinen.xmlstr = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = silinen.xmlstr
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If silinen.tarih Is Nothing Or silinen.tarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = silinen.tarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@kimpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If silinen.kimpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = silinen.kimpkey
        End If
        komut.Parameters.Add(param5)

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
        sqlstr = "select max(pkey) from silinen"
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
    Function Duzenle(ByVal silinen As CLASSSİLİNEN) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update silinen set " + _
        "ne=@ne," + _
        "xmlstr=@xmlstr," + _
        "tarih=@tarih," + _
        "kimpkey=@kimpkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = silinen.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ne", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If silinen.ne = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = silinen.ne
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@xmlstr", SqlDbType.Text)
        param3.Direction = ParameterDirection.Input
        If silinen.xmlstr = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = silinen.xmlstr
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If silinen.tarih Is Nothing Or silinen.tarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = silinen.tarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@kimpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If silinen.kimpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = silinen.kimpkey
        End If
        komut.Parameters.Add(param5)


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
    Function bultek(ByVal pkey As String) As CLASSSİLİNEN

        Dim komut As New SqlCommand
        Dim doneceksilinen As New CLASSsilinen()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from silinen where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksilinen.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ne") Is System.DBNull.Value Then
                    doneceksilinen.ne = veri.Item("ne")
                End If

                If Not veri.Item("xmlstr") Is System.DBNull.Value Then
                    doneceksilinen.xmlstr = veri.Item("xmlstr")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    doneceksilinen.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("kimpkey") Is System.DBNull.Value Then
                    doneceksilinen.kimpkey = veri.Item("kimpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksilinen

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from silinen where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSİLİNEN)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksilinen As New CLASSsilinen
        Dim silinenler As New List(Of CLASSsilinen)
        komut.Connection = db_baglanti
        sqlstr = "select * from silinen"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksilinen.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ne") Is System.DBNull.Value Then
                    doneceksilinen.ne = veri.Item("ne")
                End If

                If Not veri.Item("xmlstr") Is System.DBNull.Value Then
                    doneceksilinen.xmlstr = veri.Item("xmlstr")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    doneceksilinen.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("kimpkey") Is System.DBNull.Value Then
                    doneceksilinen.kimpkey = veri.Item("kimpkey")
                End If


                silinenler.Add(New CLASSSİLİNEN(doneceksilinen.pkey, _
                doneceksilinen.ne, doneceksilinen.xmlstr, doneceksilinen.tarih, doneceksilinen.kimpkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return silinenler

    End Function

   
    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal kriter As String) As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        jvstring = "<script type='text/javascript'>" + _
        "$(document).ready(function() {" + _
        "$('#sonuctable').tablesorter({widthFixed: true, widgets: ['zebra']})     .tablesorterPager({container: $('#pager')});" + _
        "$('#pager').css('top','0px');" + _
        "$('#pager').css('position','static');" + _
        "});" + _
        "</script>"

        basliklar = "<table id=sonuctable class=tablesorter>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>pkey</th>" + _
        "<th>ne</th>" + _
        "<th>xmlstr</th>" + _
        "<th>tarih</th>" + _
        "<th>kimpkey</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If kriter = "" Then
            sqlstr = "select * from silinen"
        End If
        If kriter <> "" Then
            sqlstr = "select * from silinen where veritabaniad like '%" + kriter + "%'"
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, ne, xmlstr, tarih, kimpkey As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "silinen.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("ne") Is System.DBNull.Value Then
                        ne = veri.item("ne")
                        kol2 = "<td>" + ne + "</td>"
                    End If

                    If Not veri.Item("xmlstr") Is System.DBNull.Value Then
                        xmlstr = veri.item("xmlstr")
                        kol3 = "<td>" + xmlstr + "</td>"
                    End If

                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.item("tarih")
                        kol4 = "<td>" + tarih + "</td>"
                    End If

                    If Not veri.Item("kimpkey") Is System.DBNull.Value Then
                        kimpkey = veri.item("kimpkey")
                        kol5 = "<td>" + kimpkey + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function


End Class
