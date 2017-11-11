Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSBAGLANTIKES_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim baglantikes As New CLASSBAGLANTIKES
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal baglantikes As CLASSBAGLANTIKES) As CLADBOPRESULT

        etkilenen = 0
  
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into baglantikes values (@pkey," + _
        "@kesilenkullanicipkey,@kesenkullanicipkey,@kesmebaslangictarih,@kesmebitistarih)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kesilenkullanicipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If baglantikes.kesilenkullanicipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = baglantikes.kesilenkullanicipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kesenkullanicipkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If baglantikes.kesenkullanicipkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = baglantikes.kesenkullanicipkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kesmebaslangictarih", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If baglantikes.kesmebaslangictarih Is Nothing Or baglantikes.kesmebaslangictarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = baglantikes.kesmebaslangictarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@kesmebitistarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If baglantikes.kesmebitistarih Is Nothing Or baglantikes.kesmebitistarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = baglantikes.kesmebitistarih
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
        sqlstr = "select max(pkey) from baglantikes"
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
    Function Duzenle(ByVal baglantikes As CLASSBAGLANTIKES) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update baglantikes set " + _
        "kesilenkullanicipkey=@kesilenkullanicipkey," + _
        "kesenkullanicipkey=@kesenkullanicipkey," + _
        "kesmebaslangictarih=@kesmebaslangictarih," + _
        "kesmebitistarih=@kesmebitistarih" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = baglantikes.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kesilenkullanicipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If baglantikes.kesilenkullanicipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = baglantikes.kesilenkullanicipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kesenkullanicipkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If baglantikes.kesenkullanicipkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = baglantikes.kesenkullanicipkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kesmebaslangictarih", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If baglantikes.kesmebaslangictarih Is Nothing Or baglantikes.kesmebaslangictarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = baglantikes.kesmebaslangictarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@kesmebitistarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If baglantikes.kesmebitistarih Is Nothing Or baglantikes.kesmebitistarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = baglantikes.kesmebitistarih
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
    Function bultek(ByVal pkey As String) As CLASSBAGLANTIKES

        Dim komut As New SqlCommand
        Dim donecekbaglantikes As New CLASSBAGLANTIKES()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from baglantikes where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbaglantikes.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kesilenkullanicipkey") Is System.DBNull.Value Then
                    donecekbaglantikes.kesilenkullanicipkey = veri.Item("kesilenkullanicipkey")
                End If

                If Not veri.Item("kesenkullanicipkey") Is System.DBNull.Value Then
                    donecekbaglantikes.kesenkullanicipkey = veri.Item("kesenkullanicipkey")
                End If

                If Not veri.Item("kesmebaslangictarih") Is System.DBNull.Value Then
                    donecekbaglantikes.kesmebaslangictarih = veri.Item("kesmebaslangictarih")
                End If

                If Not veri.Item("kesmebitistarih") Is System.DBNull.Value Then
                    donecekbaglantikes.kesmebitistarih = veri.Item("kesmebitistarih")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbaglantikes

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from baglantikes where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSBAGLANTIKES)

        Dim donecekbaglantikes As New CLASSBAGLANTIKES
        Dim baglantikesler As New List(Of CLASSBAGLANTIKES)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "select * from baglantikes"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbaglantikes.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("kesilenkullanicipkey") Is System.DBNull.Value Then
                    donecekbaglantikes.kesilenkullanicipkey = veri.Item("kesilenkullanicipkey")
                End If

                If Not veri.Item("kesenkullanicipkey") Is System.DBNull.Value Then
                    donecekbaglantikes.kesenkullanicipkey = veri.Item("kesenkullanicipkey")
                End If

                If Not veri.Item("kesmebaslangictarih") Is System.DBNull.Value Then
                    donecekbaglantikes.kesmebaslangictarih = veri.Item("kesmebaslangictarih")
                End If

                If Not veri.Item("kesmebitistarih") Is System.DBNull.Value Then
                    donecekbaglantikes.kesmebitistarih = veri.Item("kesmebitistarih")
                End If


                baglantikesler.Add(New CLASSBAGLANTIKES(donecekbaglantikes.pkey, _
                donecekbaglantikes.kesilenkullanicipkey, donecekbaglantikes.kesenkullanicipkey, donecekbaglantikes.kesmebaslangictarih, donecekbaglantikes.kesmebitistarih))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return baglantikesler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
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
        "<th>Bağlantısı Kesilen Kullanıcı</th>" + _
        "<th>Bağlantıyı Kesen Kullanıcı</th>" + _
        "<th>Kesiliş Başlangıç Tarihi</th>" + _
        "<th>Kesiliş Bitiş Tarihi</th>" + _
        "<th>Bağlantı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        sqlstr = "select * from baglantikes where kesmebaslangictarih<=@kesmebaslangictarih " + _
        " and kesmebitistarih>=@kesmebitistarih"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@kesmebaslangictarih", SqlDbType.DateTime)
        param1.Direction = ParameterDirection.Input
        param1.Value = DateTime.Now
        komut.Parameters.Add(param1)

        Dim param2 As New SqlClient.SqlParameter("@kesmebitistarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = DateTime.Now
        komut.Parameters.Add(param2)

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim kesenkullanici As New CLASSKULLANICI
        Dim kesilenkullanici As New CLASSKULLANICI
        Dim ajaxlinkdugmeac, dugmeac As String


        girdi = "0"
        Dim link As String
        Dim pkey, kesilenkullanicipkey, kesenkullanicipkey, kesmebaslangictarih, kesmebitistarih As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("kesilenkullanicipkey") Is System.DBNull.Value Then
                        kesilenkullanicipkey = veri.Item("kesilenkullanicipkey")
                        kesilenkullanici = kullanici_erisim.bultek(kesilenkullanicipkey)
                        kol2 = "<td>" + kesilenkullanici.adsoyad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kesenkullanicipkey") Is System.DBNull.Value Then
                        kesenkullanicipkey = veri.Item("kesenkullanicipkey")
                        kesenkullanici = kullanici_erisim.bultek(kesenkullanicipkey)
                        kol3 = "<td>" + kesenkullanici.adsoyad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("kesmebaslangictarih") Is System.DBNull.Value Then
                        kesmebaslangictarih = veri.Item("kesmebaslangictarih")
                        kol4 = "<td>" + kesmebaslangictarih + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("kesmebitistarih") Is System.DBNull.Value Then
                        kesmebitistarih = veri.Item("kesmebitistarih")
                        kol5 = "<td>" + kesmebitistarih + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If


                    '--BAĞLANTIYI AÇ DÜĞMESİ ------
                    ajaxlinkdugmeac = "baglantikessil(" + CStr(pkey) + ")"
                    dugmeac = "<span id='baglantiacbutton' onclick='" + ajaxlinkdugmeac + _
                    "' class='button'>Bağlantıyı Aç</span>"
                    kol6 = "<td>" + dugmeac + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        Else
            donecek = "Bağlantısı kesilmiş herhangi bir kullanıcı yoktur."
        End If

        Return (donecek)

    End Function



    Public Function baglantisikesilmisi(ByVal kullanicipkey As String) As String


        Dim donecek As String = "Hayır"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "select * from baglantikes where kesilenkullanicipkey=@kesilenkullanicipkey and" + _
        " (kesmebaslangictarih<=@kesmebaslangictarih and kesmebitistarih>=@kesmebitistarih)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@kesilenkullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlClient.SqlParameter("@kesmebaslangictarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = DateTime.Now
        komut.Parameters.Add(param2)

        Dim param3 As New SqlClient.SqlParameter("@kesmebitistarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        param3.Value = DateTime.Now
        komut.Parameters.Add(param3)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                donecek = "Evet"
                Return donecek
            End While
        End Using

        Return donecek

    End Function


End Class


