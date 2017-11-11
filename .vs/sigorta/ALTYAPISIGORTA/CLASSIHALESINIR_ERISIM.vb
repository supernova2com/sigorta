Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSIHALESINIR_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim ihalesinir As New CLASSIHALESINIR
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal ihalesinir As CLASSIHALESINIR) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
   
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into ihalesinir values (@pkey," + _
        "@sirketpkey,@baslangictarih,@bitistarih,@maksadet)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        eklenenpkey = pkeybul()
        param1.Value = eklenenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If ihalesinir.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = ihalesinir.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        If ihalesinir.baslangictarih Is Nothing Or ihalesinir.baslangictarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ihalesinir.baslangictarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        If ihalesinir.bitistarih Is Nothing Or ihalesinir.bitistarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = ihalesinir.bitistarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@maksadet", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If ihalesinir.maksadet = 0 Then
            param5.Value = 0
        Else
            param5.Value = ihalesinir.maksadet
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
            resultset.etkilenen = eklenenpkey
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
        sqlstr = "select max(pkey) from ihalesinir"
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
    Function Duzenle(ByVal ihalesinir As CLASSIHALESINIR) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update ihalesinir set " + _
        "sirketpkey=@sirketpkey," + _
        "baslangictarih=@baslangictarih," + _
        "bitistarih=@bitistarih," + _
        "maksadet=@maksadet" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ihalesinir.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If ihalesinir.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = ihalesinir.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        If ihalesinir.baslangictarih Is Nothing Or ihalesinir.baslangictarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ihalesinir.baslangictarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        If ihalesinir.bitistarih Is Nothing Or ihalesinir.bitistarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = ihalesinir.bitistarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@maksadet", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If ihalesinir.maksadet = 0 Then
            param5.Value = 0
        Else
            param5.Value = ihalesinir.maksadet
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
    Function bultek(ByVal pkey As String) As CLASSIHALESINIR

        Dim komut As New SqlCommand
        Dim donecekihalesinir As New CLASSIHALESINIR()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ihalesinir where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekihalesinir.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekihalesinir.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekihalesinir.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                    donecekihalesinir.bitistarih = veri.Item("bitistarih")
                End If

                If Not veri.Item("maksadet") Is System.DBNull.Value Then
                    donecekihalesinir.maksadet = veri.Item("maksadet")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekihalesinir

    End Function


    Function doldur_sirkeypkeyegore(ByVal sirketpkey As String) As List(Of CLASSIHALESINIR)

        Dim komut As New SqlCommand

        Dim donecekihalesinir As New CLASSIHALESINIR
        Dim ihalesinirlar As New List(Of CLASSIHALESINIR)
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ihalesinir where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekihalesinir.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekihalesinir.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekihalesinir.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                    donecekihalesinir.bitistarih = veri.Item("bitistarih")
                End If

                If Not veri.Item("maksadet") Is System.DBNull.Value Then
                    donecekihalesinir.maksadet = veri.Item("maksadet")
                End If


                ihalesinirlar.Add(New CLASSIHALESINIR(donecekihalesinir.pkey, _
                donecekihalesinir.sirketpkey, donecekihalesinir.baslangictarih, donecekihalesinir.bitistarih, _
                donecekihalesinir.maksadet))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ihalesinirlar

    End Function


    Function kotabul(ByVal sirketpkey As String) As CLASSIHALESINIR

        Dim simdikitarih As Date
        simdikitarih = Date.Today

        Dim kacadet As Integer
        Dim sirketinkotalari As New List(Of CLASSIHALESINIR)
        sirketinkotalari = doldur_sirkeypkeyegore(sirketpkey)
        kacadet = sirketinkotalari.Count
        Dim ihalesinir As New CLASSIHALESINIR

        If kacadet <= 0 Then
            Return ihalesinir
        End If

        If kacadet > 0 Then
            For Each Item As CLASSIHALESINIR In sirketinkotalari
                If Item.baslangictarih <= simdikitarih And Item.bitistarih >= simdikitarih Then
                    Return Item
                End If
            Next
        End If

        Return ihalesinir

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from ihalesinir where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSIHALESINIR)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekihalesinir As New CLASSIHALESINIR
        Dim ihalesinirler As New List(Of CLASSIHALESINIR)
        komut.Connection = db_baglanti
        sqlstr = "select * from ihalesinir"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekihalesinir.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekihalesinir.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekihalesinir.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                    donecekihalesinir.bitistarih = veri.Item("bitistarih")
                End If

                If Not veri.Item("maksadet") Is System.DBNull.Value Then
                    donecekihalesinir.maksadet = veri.Item("maksadet")
                End If


                ihalesinirler.Add(New CLASSIHALESINIR(donecekihalesinir.pkey, _
                donecekihalesinir.sirketpkey, donecekihalesinir.baslangictarih, donecekihalesinir.bitistarih, _
                donecekihalesinir.maksadet))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ihalesinirler

    End Function

   
    '---------------------------------listele--------------------------------------
    Public Function listele() As String


        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
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
        "<th>Şirket</th>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Bitiş Tarihi</th>" + _
        "<th>Maks Adet</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from ihalesinir"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, baslangictarih, bitistarih, maksadet As String
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "ihalesinir.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                        baslangictarih = veri.Item("baslangictarih")
                        kol3 = "<td>" + baslangictarih + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("bitistarih") Is System.DBNull.Value Then
                        bitistarih = veri.Item("bitistarih")
                        kol4 = "<td>" + bitistarih + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("maksadet") Is System.DBNull.Value Then
                        maksadet = veri.Item("maksadet")
                        kol5 = "<td>" + maksadet + "</td></tr>"
                    Else
                        kol5 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        komut.Dispose()
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

        sqlstr = "select * from ihalesinir where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.Int)
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

