Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSURUNKOD_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim URUNKOD As New CLASSURUNKOD
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal URUNKOD As CLASSURUNKOD) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("kod", URUNKOD.kod)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodlu kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into URUNKOD values (@pkey," + _
            "@kod,@aciklama)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@kod", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If URUNKOD.kod = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = URUNKOD.kod
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If URUNKOD.aciklama = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = URUNKOD.aciklama
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
        sqlstr = "select max(pkey) from URUNKOD"
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
    Function Duzenle(ByVal URUNKOD As CLASSURUNKOD) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update URUNKOD set " + _
        "kod=@kod," + _
        "aciklama=@aciklama" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = URUNKOD.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If URUNKOD.kod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = URUNKOD.kod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If URUNKOD.aciklama = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = URUNKOD.aciklama
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
    Function bultek(ByVal pkey As String) As CLASSURUNKOD

        Dim komut As New SqlCommand
        Dim donecekURUNKOD As New CLASSURUNKOD()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from URUNKOD where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekURUNKOD.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kod") Is System.DBNull.Value Then
                    donecekURUNKOD.kod = veri.Item("kod")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekURUNKOD.aciklama = veri.Item("aciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekURUNKOD

    End Function


    Function bultek_kodagore(ByVal kod As String) As CLASSURUNKOD

        Dim komut As New SqlCommand
        Dim donecekURUNKOD As New CLASSURUNKOD()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from URUNKOD where kod=@kod"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekURUNKOD.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kod") Is System.DBNull.Value Then
                    donecekURUNKOD.kod = veri.Item("kod")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekURUNKOD.aciklama = veri.Item("aciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekURUNKOD

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim policyinfo_erisim As New PolicyInfo_Erisim
        Dim silinecekURUNKOD As New CLASSURUNKOD
        silinecekURUNKOD = bultek(pkey)

        Dim varmi_policede As String = policyinfo_erisim.urunkodvarmi(silinecekURUNKOD.kod)

        If varmi_policede = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ürün kodunu (Product Code) kullanan poliçeler var.  " + _
            "Bu sebepten bu zeyil kaydını silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_policede = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from URUNKOD where pkey=@pkey"
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

        End If


        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSURUNKOD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekURUNKOD As New CLASSURUNKOD
        Dim URUNKODler As New List(Of CLASSURUNKOD)
        komut.Connection = db_baglanti
        sqlstr = "select * from URUNKOD"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekURUNKOD.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kod") Is System.DBNull.Value Then
                    donecekURUNKOD.kod = veri.Item("kod")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekURUNKOD.aciklama = veri.Item("aciklama")
                End If


                URUNKODler.Add(New CLASSURUNKOD(donecekURUNKOD.pkey, _
                donecekURUNKOD.kod, donecekURUNKOD.aciklama))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return URUNKODler

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

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Kod</th>" + _
        "<th>Açıklama</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from URUNKOD order by kod"
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
                        link = "urunkod.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("kod") Is System.DBNull.Value Then
                        kod = veri.Item("kod")
                        kol2 = "<td>" + kod + "</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol3 = "<td>" + aciklama + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
                End While
            End Using
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
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from URUNKOD where " + tablecol + "=@kriter"

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





    Function urunkodvarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from urunkod where kod=@kod"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kod
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


