Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSGENERICSERVISKULLANICI_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim genericserviskullanici As New CLASSGENERICSERVISKULLANICI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal genericserviskullanici As CLASSGENERICSERVISKULLANICI) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(genericserviskullanici.sirketpkey, genericserviskullanici.genericservispkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirketin halihazırda bu servise erişimi vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into genericserviskullanici values (@pkey," + _
            "@genericservispkey,@sirketpkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@genericservispkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If genericserviskullanici.genericservispkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = genericserviskullanici.genericservispkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If genericserviskullanici.sirketpkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = genericserviskullanici.sirketpkey
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
        sqlstr = "select max(pkey) from genericserviskullanici"
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
    Function Duzenle(ByVal genericserviskullanici As CLASSGENERICSERVISKULLANICI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update genericserviskullanici set " + _
        "genericservispkey=@genericservispkey," + _
        "sirketpkey=@sirketpkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericserviskullanici.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If genericserviskullanici.genericservispkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = genericserviskullanici.genericservispkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If genericserviskullanici.sirketpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = genericserviskullanici.sirketpkey
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
    Function bultek(ByVal pkey As String) As CLASSGENERICSERVISKULLANICI

        Dim komut As New SqlCommand
        Dim donecekgenericserviskullanici As New CLASSGENERICSERVISKULLANICI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericserviskullanici where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.genericservispkey = veri.Item("genericservispkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.sirketpkey = veri.Item("sirketpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekgenericserviskullanici

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from genericserviskullanici where pkey=@pkey"
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


    Public Function sililgili(ByVal genericservispkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from genericserviskullanici where genericservispkey=@genericservispkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservispkey
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
    Public Function doldur() As List(Of CLASSGENERICSERVISKULLANICI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgenericserviskullanici As New CLASSGENERICSERVISKULLANICI
        Dim genericserviskullaniciler As New List(Of CLASSGENERICSERVISKULLANICI)
        komut.Connection = db_baglanti
        sqlstr = "select * from genericserviskullanici"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.genericservispkey = veri.Item("genericservispkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.sirketpkey = veri.Item("sirketpkey")
                End If


                genericserviskullaniciler.Add(New CLASSGENERICSERVISKULLANICI(donecekgenericserviskullanici.pkey, _
                donecekgenericserviskullanici.genericservispkey, donecekgenericserviskullanici.sirketpkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return genericserviskullaniciler

    End Function


    Public Function doldurilgili(ByVal genericservispkey As String) As List(Of CLASSGENERICSERVISKULLANICI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgenericserviskullanici As New CLASSGENERICSERVISKULLANICI
        Dim genericserviskullaniciler As New List(Of CLASSGENERICSERVISKULLANICI)
        komut.Connection = db_baglanti
        sqlstr = "select * from genericserviskullanici where genericservispkey=@genericservispkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservispkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.genericservispkey = veri.Item("genericservispkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekgenericserviskullanici.sirketpkey = veri.Item("sirketpkey")
                End If


                genericserviskullaniciler.Add(New CLASSGENERICSERVISKULLANICI(donecekgenericserviskullanici.pkey, _
                donecekgenericserviskullanici.genericservispkey, donecekgenericserviskullanici.sirketpkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return genericserviskullaniciler

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

        jvstring = "<script type='text/javascript'>" + _
              "$(document).ready(function() {" + _
                  "$('.button').button();" + _
              "});" + _
              "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Servis Adı</th>" + _
        "<th>Şirket Adı</th>" + _
        "<th>İşlem</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from genericserviskullanici where genericservispkey=@genericservispkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("genericservispkey")
            komut.Parameters.Add(param1)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, genericservispkey, sirketpkey As String

        Dim genericservis As New CLASSGENERICSERVIS
        Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim ajaxlinksil, dugmesil As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                        genericservispkey = veri.Item("genericservispkey")
                    End If


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "genericservisgirispopup.aspx?pkey=" + CStr(genericservispkey) + _
                        "&op=duzenle" + _
                        "&genericserviskullaniciop=duzenle" + _
                        "&genericserviskullanicipkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If


                    If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                        genericservispkey = veri.Item("genericservispkey")
                        genericservis = genericservis_erisim.bultek(genericservispkey)
                        kol2 = "<td>" + genericservis.ad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol3 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "genericserviskullanicisil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='genericserviskullanicisilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol4 = "<td>" + dugmesil + "</td></tr>"


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
    Function ciftkayitkontrol(ByVal sirketpkey As String, ByVal genericservispkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericserviskullanici where sirketpkey=@sirketpkey and genericservispkey=@genericservispkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = genericservispkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function genericservisvarmi(ByVal genericservispkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericserviskullanici where genericservispkey=@genericservispkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservispkey
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


