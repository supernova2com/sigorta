Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSCURRENCYCODE_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim CurrencyCode As New CLASSCURRENCYCODE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal CurrencyCode As CLASSCURRENCYCODE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("kod", CurrencyCode.kod)


        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu koda ait kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        varmi = ciftkayitkontrol("aciklama", CurrencyCode.aciklama)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu açıklamaya ait kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If


        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into CurrencyCode values (@pkey," + _
            "@kod,@aciklama)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@kod", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If CurrencyCode.kod = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = CurrencyCode.kod
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If CurrencyCode.aciklama = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = CurrencyCode.aciklama
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
        sqlstr = "select max(pkey) from CurrencyCode"
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
    Function Duzenle(ByVal CurrencyCode As CLASSCURRENCYCODE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update CurrencyCode set " + _
        "kod=@kod," + _
        "aciklama=@aciklama" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = CurrencyCode.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If CurrencyCode.kod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = CurrencyCode.kod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If CurrencyCode.aciklama = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = CurrencyCode.aciklama
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
    Function bultek(ByVal pkey As String) As CLASSCURRENCYCODE

        Dim komut As New SqlCommand
        Dim donecekCurrencyCode As New CLASSCURRENCYCODE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from CurrencyCode where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekCurrencyCode.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kod") Is System.DBNull.Value Then
                    donecekCurrencyCode.kod = veri.Item("kod")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekCurrencyCode.aciklama = veri.Item("aciklama")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekCurrencyCode

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim silinecek_currencycode As New CLASSCURRENCYCODE

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim PolicyInfo_erisim As New PolicyInfo_Erisim

        silinecek_currencycode = bultek(pkey)

        Dim varmi As String = PolicyInfo_erisim.currencycodevarmi(silinecek_currencycode.kod)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodu kullanan poliçeler var. "
            resultset.etkilenen = 0
            Return resultset
        End If


        Dim oya_erisim As New CLASSOYA_ERISIM
        Dim oys_erisim As New CLASSOYS_ERISIM
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
        Dim teklif_erisim As New CLASSTEKLIF_ERISIM


        Dim varmi_oya As String = oya_erisim.currencycodevarmi(pkey)
        Dim varmi_oys As String = oys_erisim.currencycodevarmi(pkey)
        Dim varmi_pertarac As String = pertarac_erisim.currencycodevarmi(pkey)
        Dim varmi_teklif As String = teklif_erisim.currencycodevarmi(pkey)


        If varmi_oya = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodu kullanan OYA kaydı var.  " + _
            "Bu sebepten bu para birimini silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        If varmi_oys = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodu kullanan OYS kaydı var.  " + _
            "Bu sebepten bu para birimini silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        If varmi_pertarac = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodu kullanan Pert Araç kaydı var.  " + _
            "Bu sebepten bu para birimini silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        If varmi_teklif = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodu kullanan pert araç teklif kaydı var.  " + _
            "Bu sebepten bu para birimini silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If



        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from CurrencyCode where pkey=@pkey"
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

        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSCURRENCYCODE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekCurrencyCode As New CLASSCURRENCYCODE
        Dim CurrencyCodeler As New List(Of CLASSCURRENCYCODE)
        komut.Connection = db_baglanti
        sqlstr = "select * from CurrencyCode"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekCurrencyCode.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kod") Is System.DBNull.Value Then
                    donecekCurrencyCode.kod = veri.Item("kod")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekCurrencyCode.aciklama = veri.Item("aciklama")
                End If


                CurrencyCodeler.Add(New CLASSCURRENCYCODE(donecekCurrencyCode.pkey, _
                donecekCurrencyCode.kod, donecekCurrencyCode.aciklama))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return CurrencyCodeler

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
            sqlstr = "select * from currencycode"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, kod, aciklama As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "currencycode.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
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

        sqlstr = "select * from CurrencyCode where " + tablecol + "=@kriter"

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


    Function currencycodevarmi(ByVal kod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from CurrencyCode where kod=@kod"

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
