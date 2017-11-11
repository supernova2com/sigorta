Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO

Public Class CLASSSIRKETFATURABAG_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sirketfaturabag As New CLASSSIRKETFATURABAG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sirketfaturabag As CLASSSIRKETFATURABAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String

        varmi = ciftkayitkontrol(sirketfaturabag.sirketpkey, sirketfaturabag.eposta)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu e-posta adresi zaten halihazırda bu şirkete atanmış."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into sirketfaturabag values (@pkey," + _
            "@sirketpkey,@eposta)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If sirketfaturabag.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = sirketfaturabag.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@eposta", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If sirketfaturabag.eposta = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = sirketfaturabag.eposta
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

        End If
        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from sirketfaturabag"
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
    Function Duzenle(ByVal sirketfaturabag As CLASSSIRKETFATURABAG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sirketfaturabag set " + _
        "sirketpkey=@sirketpkey," + _
        "eposta=@eposta" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketfaturabag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sirketfaturabag.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sirketfaturabag.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If sirketfaturabag.eposta = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sirketfaturabag.eposta
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
    Function bultek(ByVal pkey As String) As CLASSSIRKETFATURABAG

        Dim komut As New SqlCommand
        Dim doneceksirketfaturabag As New CLASSSIRKETFATURABAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketfaturabag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketfaturabag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketfaturabag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirketfaturabag.eposta = veri.Item("eposta")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksirketfaturabag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from sirketfaturabag where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSIRKETFATURABAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketfaturabag As New CLASSSIRKETFATURABAG
        Dim sirketfaturabagler As New List(Of CLASSSIRKETFATURABAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from sirketfaturabag"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketfaturabag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketfaturabag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirketfaturabag.eposta = veri.Item("eposta")
                End If


                sirketfaturabagler.Add(New CLASSSIRKETFATURABAG(doneceksirketfaturabag.pkey, _
                doneceksirketfaturabag.sirketpkey, doneceksirketfaturabag.eposta))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketfaturabagler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_ilgilisirket(ByVal sirketpkey As String) As List(Of CLASSSIRKETFATURABAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketfaturabag As New CLASSSIRKETFATURABAG
        Dim sirketfaturabagler As New List(Of CLASSSIRKETFATURABAG)
        komut.Connection = db_baglanti

        sqlstr = "select * from sirketfaturabag where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketfaturabag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketfaturabag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirketfaturabag.eposta = veri.Item("eposta")
                End If


                sirketfaturabagler.Add(New CLASSSIRKETFATURABAG(doneceksirketfaturabag.pkey, _
                doneceksirketfaturabag.sirketpkey, doneceksirketfaturabag.eposta))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketfaturabagler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal neyegore As String, _
    ByVal p_pkey As String) As String


        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim veri As SqlDataReader
        Dim jvstring As String
        Dim donecek As String
        Dim ajaxlinksil, dugmesil As String

        donecek = ""

        jvstring = "<script type='text/javascript'>" + _
        "$(document).ready(function() {" + _
          "$('.button').button();" + _
        "});" + _
        "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Şirket</th>" + _
        "<th>IP Adresi</th>" + _
        "<th>İşlem</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        If neyegore = "sirket" Then

            sqlstr = "select * from sirketfaturabag where sirketpkey=@sirketpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = p_pkey
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, eposta As String
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Try
            veri = komut.ExecuteReader
            While veri.Read()

                girdi = "1"

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    pkey = CStr(veri.Item("pkey"))
                    link = "sirketgirispopup.aspx?pkey=" + CStr(sirketpkey) + "&op=duzenle" + _
                    "&sirketfaturabagop=duzenle" + "&sirketfaturabagpkey=" + CStr(pkey)

                    kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    sirketpkey = veri.Item("sirketpkey")
                    sirket = sirket_erisim.bultek(sirketpkey)
                    kol2 = "<td>" + sirket.sirketad + "</td>"
                Else
                    kol2 = "<td>-</td>"
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    eposta = veri.Item("eposta")
                    kol3 = "<td>" + eposta + "</td>"
                Else
                    kol3 = "<td>-</td>"
                End If

                ajaxlinksil = "sirketfaturabagsil(" + CStr(pkey) + ")"
                dugmesil = "<span id='ipsilbutton' onclick='" + ajaxlinksil + _
                "' class='button'>Sil</span>"

                kol4 = "<td>" + dugmesil + "</td></tr>"

                satir = satir + kol1 + kol2 + kol3 + kol4
            End While
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal sirketpkey As String, ByVal eposta As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketfaturabag where sirketpkey=@sirketpkey" + _
        " and eposta=@eposta"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = eposta
        komut.Parameters.Add(param2)


        veri = komut.ExecuteReader
        While veri.Read()
            varmi = "Evet"
        End While
        db_baglanti.Close()
        Return varmi

    End Function


    Function sirketvarmi(ByVal sirketpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketfaturabag where sirketpkey=@sirketpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        veri = komut.ExecuteReader
        While veri.Read()
            varmi = "Evet"
        End While
        db_baglanti.Close()
        Return varmi

    End Function


End Class
