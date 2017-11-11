Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web

Public Class CLASSTEKRESIM_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tekresim As New CLASSTEKRESIM
    Dim resultset As New CLADBOPRESULT

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tekresim As CLASSTEKRESIM) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        Dim ekkodvarmi As String
        varmi = ciftkayitkontrol("baslik", tekresim.baslik)

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
            sqlstr = "insert into tekresim values (@pkey," + _
            "@baslik,@dosyaad,@galeripkey,@resim_yukseklik," + _
            "@resim_genislik,@orjinalboyut,@ekkod)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@baslik", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If tekresim.baslik = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = tekresim.baslik
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@dosyaad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If tekresim.dosyaad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = tekresim.dosyaad
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@galeripkey", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If tekresim.galeripkey = 0 Then
                param4.Value = 0
            Else
                param4.Value = tekresim.galeripkey
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@resim_yukseklik", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If tekresim.resim_yukseklik = 0 Then
                param5.Value = 0
            Else
                param5.Value = tekresim.resim_yukseklik
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@resim_genislik", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If tekresim.resim_genislik = 0 Then
                param6.Value = 0
            Else
                param6.Value = tekresim.resim_genislik
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@orjinalboyut", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If tekresim.orjinalboyut = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = tekresim.orjinalboyut
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@ekkod", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If tekresim.ekkod = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = tekresim.ekkod
            End If
            komut.Parameters.Add(param8)

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
        sqlstr = "select max(pkey) from tekresim"
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
    Function Duzenle(ByVal tekresim As CLASSTEKRESIM) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update tekresim set " + _
        "baslik=@baslik," + _
        "dosyaad=@dosyaad," + _
        "galeripkey=@galeripkey," + _
        "resim_yukseklik=@resim_yukseklik," + _
        "resim_genislik=@resim_genislik," + _
        "orjinalboyut=@orjinalboyut," + _
        "ekkod=@ekkod" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tekresim.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslik", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If tekresim.baslik = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = tekresim.baslik
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dosyaad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If tekresim.dosyaad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = tekresim.dosyaad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@galeripkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If tekresim.galeripkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = tekresim.galeripkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@resim_yukseklik", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If tekresim.resim_yukseklik = 0 Then
            param5.Value = 0
        Else
            param5.Value = tekresim.resim_yukseklik
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@resim_genislik", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If tekresim.resim_genislik = 0 Then
            param6.Value = 0
        Else
            param6.Value = tekresim.resim_genislik
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@orjinalboyut", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If tekresim.orjinalboyut = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = tekresim.orjinalboyut
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ekkod", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If tekresim.ekkod = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = tekresim.ekkod
        End If
        komut.Parameters.Add(param8)


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
    Public Function doldur() As List(Of CLASSTEKRESIM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektekresim As New CLASStekresim
        Dim tekresimler As New List(Of CLASStekresim)
        komut.Connection = db_baglanti
        sqlstr = "select * from tekresim"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektekresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecektekresim.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecektekresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("galeripkey") Is System.DBNull.Value Then
                    donecektekresim.galeripkey = veri.Item("galeripkey")
                End If

                If Not veri.Item("resim_yukseklik") Is System.DBNull.Value Then
                    donecektekresim.resim_yukseklik = veri.Item("resim_yukseklik")
                End If

                If Not veri.Item("resim_genislik") Is System.DBNull.Value Then
                    donecektekresim.resim_genislik = veri.Item("resim_genislik")
                End If

                If Not veri.Item("orjinalboyut") Is System.DBNull.Value Then
                    donecektekresim.orjinalboyut = veri.Item("orjinalboyut")
                End If

                If Not veri.Item("ekkod") Is System.DBNull.Value Then
                    donecektekresim.ekkod = veri.Item("ekkod")
                End If


                tekresimler.Add(New CLASSTEKRESIM(donecektekresim.pkey, _
                donecektekresim.baslik, donecektekresim.dosyaad, donecektekresim.galeripkey, _
                donecektekresim.resim_yukseklik, donecektekresim.resim_genislik, _
                donecektekresim.orjinalboyut, donecektekresim.ekkod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tekresimler

    End Function


    Public Function doldurgaleriyegore(ByVal galeripkey As String) As List(Of CLASSTEKRESIM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektekresim As New CLASSTEKRESIM
        Dim tekresimler As New List(Of CLASSTEKRESIM)
        komut.Connection = db_baglanti
        sqlstr = "select * from tekresim where galeripkey=" + galeripkey
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektekresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecektekresim.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecektekresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("galeripkey") Is System.DBNull.Value Then
                    donecektekresim.galeripkey = veri.Item("galeripkey")
                End If

                If Not veri.Item("resim_yukseklik") Is System.DBNull.Value Then
                    donecektekresim.resim_yukseklik = veri.Item("resim_yukseklik")
                End If

                If Not veri.Item("resim_genislik") Is System.DBNull.Value Then
                    donecektekresim.resim_genislik = veri.Item("resim_genislik")
                End If

                If Not veri.Item("orjinalboyut") Is System.DBNull.Value Then
                    donecektekresim.orjinalboyut = veri.Item("orjinalboyut")
                End If

                If Not veri.Item("ekkod") Is System.DBNull.Value Then
                    donecektekresim.ekkod = veri.Item("ekkod")
                End If

                tekresimler.Add(New CLASSTEKRESIM(donecektekresim.pkey, donecektekresim.baslik, _
                donecektekresim.dosyaad, donecektekresim.galeripkey, donecektekresim.resim_yukseklik, _
                donecektekresim.resim_genislik, donecektekresim.orjinalboyut, _
                donecektekresim.ekkod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tekresimler

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSTEKRESIM

        Dim komut As New SqlCommand
        Dim donecektekresim As New CLASStekresim()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tekresim where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektekresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecektekresim.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecektekresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("galeripkey") Is System.DBNull.Value Then
                    donecektekresim.galeripkey = veri.Item("galeripkey")
                End If

                If Not veri.Item("resim_yukseklik") Is System.DBNull.Value Then
                    donecektekresim.resim_yukseklik = veri.Item("resim_yukseklik")
                End If

                If Not veri.Item("resim_genislik") Is System.DBNull.Value Then
                    donecektekresim.resim_genislik = veri.Item("resim_genislik")
                End If

                If Not veri.Item("orjinalboyut") Is System.DBNull.Value Then
                    donecektekresim.orjinalboyut = veri.Item("orjinalboyut")
                End If

                If Not veri.Item("ekkod") Is System.DBNull.Value Then
                    donecektekresim.ekkod = veri.Item("ekkod")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektekresim

    End Function



    '---------------------------------bultek-----------------------------------------
    Function bulekkodagore(ByVal ekkod As String) As CLASSTEKRESIM

        Dim komut As New SqlCommand
        Dim donecektekresim As New CLASSTEKRESIM()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tekresim where ekkod=@ekkod"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@ekkod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = ekkod
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektekresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecektekresim.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecektekresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("galeripkey") Is System.DBNull.Value Then
                    donecektekresim.galeripkey = veri.Item("galeripkey")
                End If

                If Not veri.Item("resim_yukseklik") Is System.DBNull.Value Then
                    donecektekresim.resim_yukseklik = veri.Item("resim_yukseklik")
                End If

                If Not veri.Item("resim_genislik") Is System.DBNull.Value Then
                    donecektekresim.resim_genislik = veri.Item("resim_genislik")
                End If

                If Not veri.Item("orjinalboyut") Is System.DBNull.Value Then
                    donecektekresim.orjinalboyut = veri.Item("orjinalboyut")
                End If

                If Not veri.Item("ekkod") Is System.DBNull.Value Then
                    donecektekresim.ekkod = veri.Item("ekkod")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektekresim

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim varmi As String
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        varmi = kullanici_erisim.resimvarmi(pkey)


        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu resim tanımlanmış bir kullanıcının resmi olarak kullanılıyor. " + _
            "Bu sebepten bu resmi silemezsiniz."
            resultset.etkilenen = 0
        End If


        If varmi = "Hayır" Then


            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "delete from tekresim where pkey=@pkey"
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


    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9 As String
        Dim tabloson As String
        Dim jvstring As String
        Dim donecek As String

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
            "<tr>" + _
                "<th>Anahtar</th>" + _
                "<th>Resim Başlığı</th>" + _
                "<th>Galeri Adı</th>" + _
                "<th>Dosya Adı</th>" + _
                "<th>Resim Yüksekliği</th>" + _
                "<th>Resim Genişliği</th>" + _
                "<th>Resim</th>" + _
                "<th>Orjinal Boyutta mı Gösterilecek ?</th>" + _
                "<th>Ek Kod</th>" + _
            "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim sqlstr, istring As String
        Dim girdi As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand

        '--- ARAMA İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
   
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then

            sqlstr = "select * from tekresim"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        If HttpContext.Current.Session("ltip") = "ara" Then

            sqlstr = "select * from tekresim where baslik LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

        End If

        If HttpContext.Current.Session("ltip") = "galeriyegore" Then

            sqlstr = "select * from tekresim where galeripkey=@galeripkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@galeripkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"

        Dim link As String
        Dim pkey, baslik, dosyaad, orjinalboyut As String
        Dim resim_yukseklik, resim_genislik As String
        Dim imgsrc As String
        Dim galeripkey, ekkod As String

        Dim galeri As New CLASSGALERIANA
        Dim galeri_erisim As New CLASSGALERIANA_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "resim.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("baslik") Is System.DBNull.Value Then
                        baslik = CStr(veri.Item("baslik"))
                        kol2 = "<td>" + baslik + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If


                    If Not veri.Item("galeripkey") Is System.DBNull.Value Then
                        galeripkey = CStr(veri.Item("galeripkey"))
                        galeri = galeri_erisim.bultek(galeripkey)
                        kol3 = "<td>" + galeri.galeriadi + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                        dosyaad = CStr(veri.Item("dosyaad"))
                        kol4 = "<td>" + dosyaad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("resim_yukseklik") Is System.DBNull.Value Then
                        resim_yukseklik = CStr(veri.Item("resim_yukseklik"))
                        kol5 = "<td>" + resim_yukseklik + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("resim_genislik") Is System.DBNull.Value Then
                        resim_genislik = CStr(veri.Item("resim_genislik"))
                        kol6 = "<td>" + resim_genislik + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    imgsrc = site.path + dosyaad
                    kol7 = "<td>" + "<a href=" + imgsrc + " target=_blank><img width=60px height=60px src=" + imgsrc + ">" + _
                    "</img></a></td>"

                    If Not veri.Item("orjinalboyut") Is System.DBNull.Value Then
                        orjinalboyut = CStr(veri.Item("orjinalboyut"))
                        kol8 = "<td>" + orjinalboyut + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("ekkod") Is System.DBNull.Value Then
                        ekkod = CStr(veri.Item("ekkod"))
                        kol9 = "<td>" + ekkod + "</td></tr>"
                    Else
                        kol9 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + _
                    kol4 + kol5 + kol6 + kol7 + kol8 + kol9

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return donecek

    End Function


    Function ara(ByVal kriter As String) As List(Of CLASSTEKRESIM)

        Dim istring As String
        Dim db_baglanti As SqlConnection
        Dim komut As SqlCommand
        Dim tektekresim As New CLASSTEKRESIM
        Dim tekresimler As New List(Of CLASSTEKRESIM)
        Dim x As System.DBNull

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tekresim where baslik LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    tektekresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("galeripkey") Is System.DBNull.Value Then
                    tektekresim.galeripkey = veri.Item("galeripkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    tektekresim.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    tektekresim.dosyaad = CStr(veri.Item("dosyaad"))
                End If

                If Not veri.Item("resim_yukseklik") Is System.DBNull.Value Then
                    tektekresim.resim_yukseklik = veri.Item("resim_yukseklik")
                End If

                If Not veri.Item("resim_genislik") Is System.DBNull.Value Then
                    tektekresim.resim_genislik = veri.Item("resim_genislik")
                End If

                If Not veri.Item("orjinalboyut") Is System.DBNull.Value Then
                    tektekresim.orjinalboyut = veri.Item("orjinalboyut")
                End If

                If Not veri.Item("ekkod") Is System.DBNull.Value Then
                    tektekresim.ekkod = veri.Item("ekkod")
                End If


            End While
        End Using

        tekresimler.Add(New CLASSTEKRESIM(tektekresim.pkey, tektekresim.baslik, _
        tektekresim.dosyaad, tektekresim.galeripkey, tektekresim.resim_yukseklik, _
        tektekresim.resim_genislik, tektekresim.orjinalboyut, tekresim.ekkod))

        db_baglanti.Close()
        Return tekresimler

    End Function



    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tekresim where " + tablecol + "=@kriter"

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


    Function galerivarmi(ByVal galeripkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tekresim where galeripkey=@galeripkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@galeripkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = galeripkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function loginresimolustur(ByVal resimpkey As String) As String

        Dim donecek As String
        donecek = ""
        Dim imgsrc As String

        Dim tekresim As New CLASSTEKRESIM
        Dim tekresim_Erisim As New CLASSTEKRESIM_ERISIM
        tekresim = tekresim_Erisim.bultek(resimpkey)

        imgsrc = tekresim.dosyaad

        donecek = "<img src='" + imgsrc + "'" + _
        " width = " + "'" + "29" + "px" + "'" + _
        " height=" + "'" + "29" + "px" + "'" + "/>"

        Return donecek

    End Function


    Function ekrankilitresimolustur(ByVal resimpkey As String) As String

        Dim donecek As String
        donecek = ""
        Dim imgsrc As String

        Dim tekresim As New CLASSTEKRESIM
        Dim tekresim_Erisim As New CLASSTEKRESIM_ERISIM
        tekresim = tekresim_Erisim.bultek(resimpkey)

        imgsrc = tekresim.dosyaad

        donecek = "<img class='page-lock-img' src='" + imgsrc + "'" + _
        " width = " + "'" + "200" + "px" + "'" + _
        " height=" + "'" + "200" + "px" + "'" + "/>"

        Return donecek

    End Function


End Class
