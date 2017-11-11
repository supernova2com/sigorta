Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Net


Public Class CLASSSIRKETIPBAG_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sirketipbag As New CLASSSIRKETIPBAG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sirketipbag As CLASSSIRKETIPBAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String

        varmi = ciftkayitkontrol(sirketipbag.sirketpkey, sirketipbag.ipadres)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ip adresi zaten halihazırda bu şirkete atanmış."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into sirketipbag values (@pkey," + _
            "@sirketpkey,@ipadres,@cidrnotation)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If sirketipbag.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = sirketipbag.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@ipadres", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If sirketipbag.ipadres = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = sirketipbag.ipadres
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@cidrnotation", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If sirketipbag.cidrnotation = 0 Then
                param4.Value = 0
            Else
                param4.Value = sirketipbag.cidrnotation
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
        sqlstr = "select max(pkey) from sirketipbag"
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
    Function Duzenle(ByVal sirketipbag As CLASSSIRKETIPBAG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sirketipbag set " + _
        "sirketpkey=@sirketpkey," + _
        "ipadres=@ipadres," + _
        "cidrnotation=@cidrnotation" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketipbag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sirketipbag.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sirketipbag.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ipadres", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If sirketipbag.ipadres = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sirketipbag.ipadres
        End If
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@cidrnotation", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If sirketipbag.cidrnotation = 0 Then
            param4.Value = 0
        Else
            param4.Value = sirketipbag.cidrnotation
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
    Function bultek(ByVal pkey As String) As CLASSSIRKETIPBAG

        Dim komut As New SqlCommand
        Dim doneceksirketipbag As New CLASSSIRKETIPBAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketipbag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketipbag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    doneceksirketipbag.ipadres = veri.Item("ipadres")
                End If

                If Not veri.Item("cidrnotation") Is System.DBNull.Value Then
                    doneceksirketipbag.cidrnotation = veri.Item("cidrnotation")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksirketipbag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from sirketipbag where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSIRKETIPBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketipbag As New CLASSSIRKETIPBAG
        Dim sirketipbagler As New List(Of CLASSSIRKETIPBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from sirketipbag"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketipbag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    doneceksirketipbag.ipadres = veri.Item("ipadres")
                End If

                If Not veri.Item("cidrnotation") Is System.DBNull.Value Then
                    doneceksirketipbag.cidrnotation = veri.Item("cidrnotation")
                End If


                sirketipbagler.Add(New CLASSSIRKETIPBAG(doneceksirketipbag.pkey, _
                doneceksirketipbag.sirketpkey, doneceksirketipbag.ipadres, _
                doneceksirketipbag.cidrnotation))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketipbagler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_ilgilisirket(ByVal sirketpkey As String) As List(Of CLASSSIRKETIPBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketipbag As New CLASSSIRKETIPBAG
        Dim sirketipbagler As New List(Of CLASSSIRKETIPBAG)
        komut.Connection = db_baglanti

        sqlstr = "select * from sirketipbag where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketipbag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketipbag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    doneceksirketipbag.ipadres = veri.Item("ipadres")
                End If

                If Not veri.Item("cidrnotation") Is System.DBNull.Value Then
                    doneceksirketipbag.cidrnotation = veri.Item("cidrnotation")
                End If


                sirketipbagler.Add(New CLASSSIRKETIPBAG(doneceksirketipbag.pkey, _
                doneceksirketipbag.sirketpkey, doneceksirketipbag.ipadres, _
                doneceksirketipbag.cidrnotation))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketipbagler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal neyegore As String, _
    ByVal p_pkey As String) As String


        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5,kol6, kol7 As String
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
        "<th>Subnet Mask</th>" + _
        "<th>IP Aralığı</th>" + _
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

            sqlstr = "select * from sirketipbag where sirketpkey=@sirketpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = p_pkey
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, ipadres, cidrnotation As String
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim ht As New Hashtable

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
                    "&sirketipbagop=duzenle" + "&sirketipbagpkey=" + CStr(pkey)
                    kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    sirketpkey = veri.Item("sirketpkey")
                    sirket = sirket_erisim.bultek(sirketpkey)
                    kol2 = "<td>" + sirket.sirketad + "</td>"
                Else
                    kol2 = "<td>-</td>"
                End If


                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    ipadres = veri.Item("ipadres")
                Else
                    ipadres = "-"
                End If
                If Not veri.Item("cidrnotation") Is System.DBNull.Value Then
                    cidrnotation = veri.Item("cidrnotation")
                Else
                    cidrnotation = "-"
                End If

                kol3 = "<td>" + ipadres + "/" + cidrnotation + "</td>"


                ht = ip_erisim.balangicbitisvemaskbul(cidrnotation, IPAddress.Parse(ipadres))

                kol4 = "<td>" + ht(3) + "</td>"
                kol5 = "<td>" + "Başlangıç IP:" + "<b>" + ht(1) + "</b><br/>" + _
                "Bitiş IP:" + "<b>" + ht(2) + "</b></td>"


                ajaxlinksil = "sirketipbagsil(" + CStr(pkey) + ")"
                dugmesil = "<span id='ipsilbutton' onclick='" + ajaxlinksil + _
                "' class='button'>Sil</span>"

                kol6 = "<td>" + dugmesil + "</td></tr>"

                satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
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
    Function ciftkayitkontrol(ByVal sirketpkey As String, ByVal ipadres As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketipbag where sirketpkey=@sirketpkey" + _
        " and ipadres=@ipadres"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ipadres", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ipadres
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

        sqlstr = "select * from sirketipbag where sirketpkey=@sirketpkey"

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

