Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSTMODUL_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tmodul As New CLASSTMODUL
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tmodul As CLASSTMODUL) As CLADBOPRESULT

        etkilenen = 0

        Dim varmitablo As String
        Dim varmiad As String
        varmiad = ciftkayitkontrol("ad", tmodul.ad)
        varmitablo = ciftkayitkontrol("tabload",tmodul.tabload)

        If varmiad = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu isimde modul kaydı halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmiad = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tablo için modul kaydedilmiş."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into tmodul values (@pkey," + _
        "@ad,@tabload,@aciklama)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If tmodul.ad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = tmodul.ad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tabload", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If tmodul.tabload = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = tmodul.tabload
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@aciklama", SqlDbType.Text)
            param4.Direction = ParameterDirection.Input
            If tmodul.aciklama = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = tmodul.aciklama
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
        sqlstr = "select max(pkey) from tmodul"
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
    Function Duzenle(ByVal tmodul As CLASSTMODUL) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update tmodul set " + _
        "ad=@ad," + _
        "tabload=@tabload," + _
        "aciklama=@aciklama" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tmodul.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If tmodul.ad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = tmodul.ad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If tmodul.tabload = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = tmodul.tabload
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@aciklama", SqlDbType.Text)
        param4.Direction = ParameterDirection.Input
        If tmodul.aciklama = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = tmodul.aciklama
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
    Function bultek(ByVal pkey As String) As CLASSTMODUL

        Dim komut As New SqlCommand
        Dim donecektmodul As New CLASSTMODUL()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tmodul where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektmodul.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecektmodul.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecektmodul.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecektmodul.aciklama = veri.Item("aciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektmodul

    End Function


    Function bultabloadagore(ByVal tabload As String) As CLASSTMODUL

        Dim komut As New SqlCommand
        Dim donecektmodul As New CLASSTMODUL()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tmodul where tabload=@tabload"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektmodul.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecektmodul.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecektmodul.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecektmodul.aciklama = veri.Item("aciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektmodul

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from tmodul where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSTMODUL)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektmodul As New CLASSTMODUL
        Dim tmoduller As New List(Of CLASSTMODUL)
        komut.Connection = db_baglanti
        sqlstr = "select * from tmodul"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektmodul.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecektmodul.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecektmodul.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecektmodul.aciklama = veri.Item("aciklama")
                End If


                tmoduller.Add(New CLASSTMODUL(donecektmodul.pkey, _
                donecektmodul.ad, donecektmodul.tabload, donecektmodul.aciklama))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tmoduller

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_bilgicin() As List(Of CLASSTMODUL)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektmodul As New CLASSTMODUL
        Dim tmoduller As New List(Of CLASSTMODUL)
        komut.Connection = db_baglanti
        sqlstr = "select * from tmodul where pkey>=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = 25
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektmodul.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecektmodul.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecektmodul.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecektmodul.aciklama = veri.Item("aciklama")
                End If


                tmoduller.Add(New CLASSTMODUL(donecektmodul.pkey, _
                donecektmodul.ad, donecektmodul.tabload, donecektmodul.aciklama))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tmoduller

    End Function

   
    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
        Dim tabloson, pager As String
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
        "<th>Ad</th>" + _
        "<th>Tablo Adı</th>" + _
        "<th>Açıklama</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from tmodul"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, ad, tabload, aciklama As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "tmodul.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("ad") Is System.DBNull.Value Then
                        ad = veri.Item("ad")
                        kol2 = "<td>" + ad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("tabload") Is System.DBNull.Value Then
                        tabload = veri.Item("tabload")
                        kol3 = "<td>" + tabload + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol4 = "<td>" + aciklama + "</td></tr>"
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

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tmodul where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function
End Class


