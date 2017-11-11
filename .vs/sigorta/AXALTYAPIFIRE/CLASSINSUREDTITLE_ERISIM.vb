Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSINSUREDTITLE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim insuredtitle As New CLASSINSUREDTITLE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal insuredtitle As CLASSINSUREDTITLE) As CLADBOPRESULT

        etkilenen = 0
        Dim eklenenpkey As Integer
        Dim varmi1, varmi2 As Integer
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "kod", "=", insuredtitle.kod, " "))
        varmi1 = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "insuredtitle", "count(*)", fieldopvalues)
        If varmi1 > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıtlıdır. Bu kod halihazırda veritabanında kayıtlıdır"
            resultset.etkilenen = 0
            Return resultset
        End If

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "aciklama", "=", insuredtitle.aciklama, " "))
        varmi2 = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "insuredtitle", "count(*)", fieldopvalues)
        If varmi2 > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıtlıdır. Bu açıklama halihazırda veritabanında kayıtlıdır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into insuredtitle values (@pkey," +
            "@kod,@aciklama)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            eklenenpkey = pkeybul()
            param1.Value = eklenenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@kod", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If insuredtitle.kod = 0 Then
                param2.Value = 0
            Else
                param2.Value = insuredtitle.kod
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar, 254)
            param3.Direction = ParameterDirection.Input
            If insuredtitle.aciklama = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = insuredtitle.aciklama
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
                resultset.etkilenen = eklenenpkey
            End If
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()

        End Using

        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "select max(pkey) from insuredtitle"
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
        End Using

        Return pkey

    End Function

    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal insuredtitle As CLASSINSUREDTITLE) As CLADBOPRESULT

        Dim varmi As Integer = 0
        Dim varmi2 As Integer = 0
        etkilenen = 0
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", insuredtitle.pkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "kod", "=", insuredtitle.kod, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "insuredtitle", "count(*)", fieldopvalues)
        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kod halihazırda veritanında kayıtlıdır."
            resultset.etkilenen = 0
            Return resultset
        End If

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", insuredtitle.pkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "aciklama", "=", insuredtitle.aciklama, " "))
        varmi2 = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "insuredtitle", "count(*)", fieldopvalues)
        If varmi2 > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ad halihazırda veritanında kayıtlıdır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            komut.Connection = db_baglanti
            sqlstr = "update insuredtitle set " +
            "kod=@kod," +
            "aciklama=@aciklama" +
            " where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = insuredtitle.pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@kod", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If insuredtitle.kod = 0 Then
                param2.Value = 0
            Else
                param2.Value = insuredtitle.kod
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar, 254)
            param3.Direction = ParameterDirection.Input
            If insuredtitle.aciklama = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = insuredtitle.aciklama
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
        End Using
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSINSUREDTITLE

        Dim komut As New SqlCommand
        Dim donecekinsuredtitle As New CLASSINSUREDTITLE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "select * from insuredtitle where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkey
            komut.Parameters.Add(param1)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekinsuredtitle.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("kod") Is System.DBNull.Value Then
                        donecekinsuredtitle.kod = veri.Item("kod")
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        donecekinsuredtitle.aciklama = veri.Item("aciklama")
                    End If


                End While
            End Using
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using
        Return donecekinsuredtitle

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from insuredtitle where pkey=@pkey"
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
            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using

        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSINSUREDTITLE)

        Dim donecekinsuredtitle As New CLASSINSUREDTITLE
        Dim insuredtitleler As New List(Of CLASSINSUREDTITLE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()
            komut.Connection = db_baglanti
            sqlstr = "select * from insuredtitle"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekinsuredtitle.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("kod") Is System.DBNull.Value Then
                        donecekinsuredtitle.kod = veri.Item("kod")
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        donecekinsuredtitle.aciklama = veri.Item("aciklama")
                    End If


                    insuredtitleler.Add(New CLASSINSUREDTITLE(donecekinsuredtitle.pkey,
                    donecekinsuredtitle.kod, donecekinsuredtitle.aciklama))

                End While
            End Using

            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Using
        Return insuredtitleler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" +
        "<thead>" +
        "<tr>" +
        "<th>Anahtar</th>" +
        "<th>Kod</th>" +
        "<th>Açıklama</th>" +
        "</tr>" +
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from insuredtitle"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, kod, aciklama As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "insuredtitle.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><a href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("kod") Is System.DBNull.Value Then
                        kod = veri.Item("kod")
                        kol2 = "<td>" + kod + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol3 = "<td>" + aciklama + "</td></tr>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        komut.Dispose()
        db_baglanti.Dispose()
        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function



    Public Function kodvarmi(ByVal kod As Integer) As String

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim donecek As String = "Hayır"
        Dim varmi As Integer = 0

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "kod", "=", kod, ""))
        varmi = genericislem_erisim.countgeneric(site.sistemveritabaniad, "insuredtitle", "count(*)", fieldopvalues)

        If varmi > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function


End Class