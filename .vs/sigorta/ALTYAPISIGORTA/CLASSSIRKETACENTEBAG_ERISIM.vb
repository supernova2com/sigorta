Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSSIRKETACENTEBAG_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sirketacentebag As New CLASSSIRKETACENTEBAG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sirketacentebag As CLASSSIRKETACENTEBAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(sirketacentebag.sirketpkey, sirketacentebag.acentepkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into sirketacentebag values (@pkey," + _
            "@sirketpkey,@acentepkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If sirketacentebag.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = sirketacentebag.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@acentepkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If sirketacentebag.acentepkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = sirketacentebag.acentepkey
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
        sqlstr = "select max(pkey) from sirketacentebag"
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
    Function Duzenle(ByVal sirketacentebag As CLASSSIRKETACENTEBAG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sirketacentebag set " + _
        "sirketpkey=@sirketpkey," + _
        "acentepkey=@acentepkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketacentebag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sirketacentebag.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sirketacentebag.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If sirketacentebag.acentepkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = sirketacentebag.acentepkey
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
    Function bultek(ByVal pkey As String) As CLASSSIRKETACENTEBAG

        Dim komut As New SqlCommand
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketacentebag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.acentepkey = veri.Item("acentepkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksirketacentebag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from sirketacentebag where pkey=@pkey"
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


    '---------------------sil bir acentenin çalıştığı tüm sirketleri-----------------------------------------
    Public Function silacentenincalistigitumsirketler(ByVal acentepkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from sirketacentebag where acentepkey=@acentepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentepkey
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
    Public Function doldur() As List(Of CLASSSIRKETACENTEBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from sirketacentebag"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.acentepkey = veri.Item("acentepkey")
                End If


                sirketacentebagler.Add(New CLASSSIRKETACENTEBAG(doneceksirketacentebag.pkey, _
                doneceksirketacentebag.sirketpkey, doneceksirketacentebag.acentepkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketacentebagler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_sirketinacenteleri(ByVal sirketpkey As String) As List(Of CLASSSIRKETACENTEBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti

        sqlstr = "select * from sirketacentebag where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.acentepkey = veri.Item("acentepkey")
                End If


                sirketacentebagler.Add(New CLASSSIRKETACENTEBAG(doneceksirketacentebag.pkey, _
                doneceksirketacentebag.sirketpkey, doneceksirketacentebag.acentepkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketacentebagler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_sirketinacentelerionunekledigi(ByVal sirketpkey As String) As List(Of CLASSSIRKETACENTEBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti

        sqlstr = "select * from sirketacentebag where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.acentepkey = veri.Item("acentepkey")
                    acente = acente_erisim.bultek(doneceksirketacentebag.acentepkey)
                End If


                'sadece giriş yapmış kulllanıcının eklediği acenteleri listele
                If acente.guncelleyenkullanicipkey = HttpContext.Current.Session("kullanici_pkey") Then
                    sirketacentebagler.Add(New CLASSSIRKETACENTEBAG(doneceksirketacentebag.pkey, _
                    doneceksirketacentebag.sirketpkey, doneceksirketacentebag.acentepkey))
                End If


            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketacentebagler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_sirketinmerkezacentesi(ByVal sirketpkey As String) As CLASSACENTE

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti

        sqlstr = "select * from sirketacentebag where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.acentepkey = veri.Item("acentepkey")
                    acente = acente_erisim.bultek(doneceksirketacentebag.acentepkey)
                End If

                'sadece 
                If doneceksirketacentebag.sirketpkey = HttpContext.Current.Session("kullanici_aktifsirket") Then
                    If acente.merkezmi = "Evet" Then
                        Return acente
                    End If
                End If

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


    End Function



    '---------------------------------doldur-----------------------------------------
    Public Function doldur_acenteninbaglioldugusirketler(ByVal acentepkey As String) As List(Of CLASSSIRKETACENTEBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti

        sqlstr = "select * from sirketacentebag where acentepkey=@acentepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentepkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.acentepkey = veri.Item("acentepkey")
                End If


                sirketacentebagler.Add(New CLASSSIRKETACENTEBAG(doneceksirketacentebag.pkey, _
                doneceksirketacentebag.sirketpkey, doneceksirketacentebag.acentepkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketacentebagler

    End Function
  
    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal neyegore As String, _
    ByVal p_pkey As String) As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
        Dim tabloson As String
        Dim girdi As String
        Dim veri As SqlDataReader
        Dim jvstring As String
        Dim donecek As String

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
        "<th>Acentesi</th>" + _
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

            sqlstr = "select * from sirketacentebag where sirketpkey=@sirketpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = p_pkey
            komut.Parameters.Add(param1)

        End If

        If neyegore = "acente" Then

            sqlstr = "select * from sirketacentebag where acentepkey=@acentepkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@acentepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = p_pkey
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, acentepkey As String
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim ajaxlinksil, dugmesil As String


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
                    "&sirketacentebagop=duzenle&sirketacentebagpkey=" + CStr(pkey)
                    kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    sirketpkey = veri.Item("sirketpkey")
                    sirket = sirket_erisim.bultek(sirketpkey)
                    kol2 = "<td>" + sirket.sirketad + "</td>"
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    acentepkey = veri.Item("acentepkey")
                    acente = acente_erisim.bultek(acentepkey)
                    kol3 = "<td>" + acente.acentead + "</td>"
                End If

                '--SİL DÜĞMESİ ------
                ajaxlinksil = "sirketacentebagsil(" + CStr(pkey) + ")"
                dugmesil = "<span id='acentesilbutton' onclick='" + ajaxlinksil + _
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
    Function ciftkayitkontrol(ByVal sirketpkey As String, ByVal acentepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketacentebag where sirketpkey=@sirketpkey" + _
        " and acentepkey=@acentepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = acentepkey
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

        sqlstr = "select * from sirketacentebag where sirketpkey=@sirketpkey"

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


    Function acentevarmi(ByVal acentepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirketacentebag where acentepkey=@acentepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentepkey
        komut.Parameters.Add(param1)

        veri = komut.ExecuteReader
        While veri.Read()
            varmi = "Evet"
        End While
        db_baglanti.Close()
        Return varmi

    End Function



    Public Function doldursirketinacenteleri_acentetipinde(ByVal sirketpkey As String) As List(Of CLASSACENTE)

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acenteler As New List(Of CLASSACENTE)

        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirketacentebaglar As New List(Of CLASSSIRKETACENTEBAG)
        sirketacentebaglar = sirketacentebag_erisim.doldur_sirketinacenteleri(sirketpkey)

        For Each item As CLASSSIRKETACENTEBAG In sirketacentebaglar
            acente = acente_erisim.bultek(item.acentepkey)
            acenteler.Add(New CLASSACENTE(acente.pkey, acente.acentead, acente.sicilno, _
            acente.aktifmi, acente.merkezmi, acente.yetkiadsoyad, acente.yetkikimlikno, _
            acente.yetkiceptel, acente.yetkiemail, acente.tel, acente.fax, _
            acente.ekleyenkullanicipkey, acente.eklenmetarih, _
            acente.guncelleyenkullanicipkey, acente.guncellenmetarih, acente.acentetippkey))
        Next

        Return acenteler

    End Function


    Public Function doldursirketinacenteleri_acentetipindeonunekledigi(ByVal sirketpkey As String) As List(Of CLASSACENTE)

        Dim merkezacente As New CLASSACENTE

        Dim aktifsirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acenteler As New List(Of CLASSACENTE)

        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirketacentebaglar As New List(Of CLASSSIRKETACENTEBAG)
        sirketacentebaglar = sirketacentebag_erisim.doldur_sirketinacentelerionunekledigi(sirketpkey)

        For Each item As CLASSSIRKETACENTEBAG In sirketacentebaglar
            acente = acente_erisim.bultek(item.acentepkey)
            acenteler.Add(New CLASSACENTE(acente.pkey, acente.acentead, acente.sicilno, _
            acente.aktifmi, acente.merkezmi, acente.yetkiadsoyad, acente.yetkikimlikno, _
            acente.yetkiceptel, acente.yetkiemail, acente.tel, acente.fax, _
            acente.ekleyenkullanicipkey, acente.eklenmetarih, _
            acente.guncelleyenkullanicipkey, acente.guncellenmetarih, acente.acentetippkey))
        Next


        merkezacente = doldur_sirketinmerkezacentesi(HttpContext.Current.Session("kullanici_aktifsirket"))

        acenteler.Add(merkezacente)


        Return acenteler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_acenteninbaglioldugusirketler_belgeicin(ByVal acentepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim donecek As String
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        sqlstr = "select * from sirketacentebag where acentepkey=@acentepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                sirket = sirket_Erisim.bultek(doneceksirketacentebag.sirketpkey)

                donecek = donecek + sirket.sirketad + vbCrLf

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_acenteninbaglioldugusirketler_sirkettipinde(ByVal acentepkey As String) As List(Of CLASSSIRKET)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirketacentebag As New CLASSSIRKETACENTEBAG
        Dim donecek As String
        Dim sirketacentebagler As New List(Of CLASSSIRKETACENTEBAG)
        komut.Connection = db_baglanti
        Dim doneceksirketler As New List(Of CLASSSIRKET)
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        sqlstr = "select * from sirketacentebag where acentepkey=@acentepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceksirketacentebag.sirketpkey = veri.Item("sirketpkey")
                End If

                sirket = sirket_Erisim.bultek(doneceksirketacentebag.sirketpkey)

                doneceksirketler.Add(New CLASSSIRKET(sirket.pkey, _
                sirket.sirketkod, sirket.sirketad, sirket.yetkilikisiadsoyad, sirket.adres, _
                sirket.ofistelefon, sirket.faks, sirket.eposta, sirket.aktifmi, _
                sirket.resimpkey, sirket.testerisim, sirket.topluyukleme, sirket.wskullaniciad, _
                sirket.wssifre, sirket.ipdikkat, sirket.tip, sirket.GetCarAddressInfo_yetki, _
                sirket.GetDamageInformation_yetki, sirket.GetInfoInsuredPeople_yetki, _
                sirket.LoadDamageInformation_yetki, sirket.LoadPolicyInformation_yetki, sirket.maksservistalepdakika))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return doneceksirketler

    End Function


End Class