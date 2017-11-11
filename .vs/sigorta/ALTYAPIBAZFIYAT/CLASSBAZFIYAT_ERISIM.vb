Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSBAZFIYAT_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim bazfiyat As New CLASSBAZFIYAT
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal bazfiyat As CLASSBAZFIYAT) As CLADBOPRESULT

        Dim p_pkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(bazfiyat.sirketpkey, bazfiyat.kayitno, bazfiyat.policetip)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirketin bu kayıt numarası ve poliçe tipine" + _
            " göre zaten halihazırda veritabanında kaydı vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into bazfiyat values (@pkey," + _
            "@sirketpkey,@baslangictarih,@kayittarih,@kayitno," + _
            "@policetip)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            p_pkey = pkeybul()
            param1.Value = p_pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If bazfiyat.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = bazfiyat.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
            param3.Direction = ParameterDirection.Input
            If bazfiyat.baslangictarih Is Nothing Or bazfiyat.baslangictarih = "00:00:00" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = bazfiyat.baslangictarih
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
            param4.Direction = ParameterDirection.Input
            If bazfiyat.kayittarih Is Nothing Or bazfiyat.kayittarih = "00:00:00" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = bazfiyat.kayittarih
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@kayitno", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If bazfiyat.kayitno = 0 Then
                param5.Value = 0
            Else
                param5.Value = bazfiyat.kayitno
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@policetip", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If bazfiyat.policetip = 0 Then
                param6.Value = 0
            Else
                param6.Value = bazfiyat.policetip
            End If
            komut.Parameters.Add(param6)

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
                resultset.etkilenen = p_pkey
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
        sqlstr = "select max(pkey) from bazfiyat"
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
    Function Duzenle(ByVal bazfiyat As CLASSBAZFIYAT) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update bazfiyat set " + _
        "sirketpkey=@sirketpkey," + _
        "baslangictarih=@baslangictarih," + _
        "kayittarih=@kayittarih," + _
        "kayitno=@kayitno," + _
        "policetip=@policetip" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyat.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If bazfiyat.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = bazfiyat.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If bazfiyat.baslangictarih Is Nothing Or bazfiyat.baslangictarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = bazfiyat.baslangictarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If bazfiyat.kayittarih Is Nothing Or bazfiyat.kayittarih = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = bazfiyat.kayittarih
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@kayitno", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If bazfiyat.kayitno = 0 Then
            param5.Value = 0
        Else
            param5.Value = bazfiyat.kayitno
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@policetip", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If bazfiyat.policetip = 0 Then
            param6.Value = 0
        Else
            param6.Value = bazfiyat.policetip
        End If
        komut.Parameters.Add(param6)


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
    Function bultek(ByVal pkey As String) As CLASSBAZFIYAT

        Dim komut As New SqlCommand
        Dim donecekbazfiyat As New CLASSBAZFIYAT()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyat where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyat.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekbazfiyat.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekbazfiyat.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekbazfiyat.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekbazfiyat.kayitno = veri.Item("kayitno")
                End If

                If Not veri.Item("policetip") Is System.DBNull.Value Then
                    donecekbazfiyat.policetip = veri.Item("policetip")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyat

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from bazfiyat where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSBAZFIYAT)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbazfiyat As New CLASSBAZFIYAT
        Dim bazfiyatler As New List(Of CLASSBAZFIYAT)
        komut.Connection = db_baglanti
        sqlstr = "select * from bazfiyat"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyat.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekbazfiyat.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekbazfiyat.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekbazfiyat.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekbazfiyat.kayitno = veri.Item("kayitno")
                End If

                If Not veri.Item("policetip") Is System.DBNull.Value Then
                    donecekbazfiyat.policetip = veri.Item("policetip")
                End If


                bazfiyatler.Add(New CLASSBAZFIYAT(donecekbazfiyat.pkey, _
                donecekbazfiyat.sirketpkey, donecekbazfiyat.baslangictarih, donecekbazfiyat.kayittarih, donecekbazfiyat.kayitno, _
                donecekbazfiyat.policetip))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bazfiyatler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
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
        "<th>Kayıt Tarihi</th>" + _
        "<th>Kayıt No</th>" + _
        "<th>Poliçe Tipi</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then

            sqlstr = "select * from bazfiyat"
            komut = New SqlCommand(sqlstr, db_baglanti)

        End If

        If HttpContext.Current.Session("ltip") = "sirketpkey" Then

            sqlstr = "select * from bazfiyat where sirketpkey=@kriter"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

        End If

        If HttpContext.Current.Session("ltip") = "sirkettaraf" Then

            sqlstr = "select * from bazfiyat where sirketpkey=@sirketpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kullanici_aktifsirket")
            komut.Parameters.Add(param1)

        End If


        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, baslangictarih, kayittarih, kayitno As String
        Dim policetip_pkey As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim policetip As New CLASSPOLICETIP
        Dim policetip_erisim As New CLASSPOLICETIP_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        'şirket tarafı için
                        If HttpContext.Current.Session("ltip") = "sirkettaraf" Then
                            link = "sirketbazfiyatgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                            If kayitguncelmi(pkey) = "Evet" Then
                                kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                            Else
                                kol1 = "<tr><td>" + "-" + "</td>"
                            End If
                        Else
                            link = "bazfiyatgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                            kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                        End If

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

                    If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                        kayittarih = veri.Item("kayittarih")
                        kol4 = "<td>" + kayittarih + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("kayitno") Is System.DBNull.Value Then
                        kayitno = veri.Item("kayitno")
                        kol5 = "<td>" + kayitno + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("policetip") Is System.DBNull.Value Then
                        policetip_pkey = veri.Item("policetip")
                        policetip = policetip_erisim.bultek(policetip_pkey)
                        kol6 = "<td>" + policetip.policetipad + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
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
    Function ciftkayitkontrol(ByVal sirketpkey As String, _
    ByVal kayitno As String, _
    ByVal policetip As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyat where sirketpkey=@sirketpkey " + _
        "and kayitno=@kayitno"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kayitno", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kayitno
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@policetip", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = policetip
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function

    '----------------------------KAYIT NUMARASINI BUL---------------------------------------
    Public Function kayitnobul(ByVal sirketpkey As Integer) As Integer

        Dim sqlstr As String
        Dim kayitno As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(kayitno) from bazfiyat where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitno = 1
        Else
            kayitno = maxkayit1 + 1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitno

    End Function


    '----------------------------KAYIT NUMARASINI BUL---------------------------------------
    Public Function ensonkayitnobul(ByVal sirketpkey As Integer, ByVal policetip As String) As Integer

        Dim sqlstr As String
        Dim kayitno As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(kayitno) from bazfiyat where sirketpkey=@sirketpkey and " + _
        "policetip=@policetip"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@policetip", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = policetip
        komut.Parameters.Add(param2)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitno = 0
        Else
            kayitno = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitno

    End Function



    '---------------------------------bultek-----------------------------------------
    Function bulsirketpkeykayitnovepolicetipgore(ByVal sirketpkey As String, _
    ByVal kayitno As String, ByVal policetip As String) As CLASSBAZFIYAT

        Dim komut As New SqlCommand
        Dim donecekbazfiyat As New CLASSBAZFIYAT()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyat where sirketpkey=@sirketpkey " + _
        " and kayitno=@kayitno and policetip=@policetip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kayitno", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kayitno
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@policetip", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = policetip
        komut.Parameters.Add(param3)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyat.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekbazfiyat.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekbazfiyat.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekbazfiyat.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekbazfiyat.kayitno = veri.Item("kayitno")
                End If

                If Not veri.Item("policetip") Is System.DBNull.Value Then
                    donecekbazfiyat.policetip = veri.Item("policetip")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyat

    End Function


    Function doldursirketpkeykayitnovepolicetipgore(ByVal sirketpkey As String, _
    ByVal policetip As String) As List(Of CLASSBAZFIYAT)

        Dim komut As New SqlCommand

        Dim tekbazfiyat As New CLASSBAZFIYAT
        Dim donecekbazfiyatlar As New List(Of CLASSBAZFIYAT)
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyat where sirketpkey=@sirketpkey order by kayitno desc"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@policetip", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = policetip
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    tekbazfiyat.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    tekbazfiyat.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    tekbazfiyat.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    tekbazfiyat.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    tekbazfiyat.kayitno = veri.Item("kayitno")
                End If

                If Not veri.Item("policetip") Is System.DBNull.Value Then
                    tekbazfiyat.policetip = veri.Item("policetip")
                End If

                donecekbazfiyatlar.Add(New CLASSBAZFIYAT(tekbazfiyat.pkey, tekbazfiyat.sirketpkey, _
                tekbazfiyat.baslangictarih, tekbazfiyat.kayittarih, tekbazfiyat.kayitno, _
                tekbazfiyat.policetip))


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekbazfiyatlar

    End Function


    '----------------------------TARİFE ÜCRETİNİ BUL---------------------------------------
    Public Function tarifeucretbul(ByVal productcode As Integer, ByVal sirketpkey As String, _
    ByVal TariffCode As String, ByVal PolicyType As String, ByVal ProductType As String, _
    ByVal StartDate As Date) As Decimal


        Dim tarihicinegirdimi As String
        tarihicinegirdimi = "Hayır"

        Dim aractarife As New CLASSARACTARIFE
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        Dim sirketintumbazfiyatlari As New List(Of CLASSBAZFIYAT)

        Dim bazfiyattarifey As New CLASSBAZFIYATTARIFEY
        Dim bazfiyattarifey_erisim As New CLASSBAZFIYATTARIFEY_ERISIM


        Dim bazfiyat As New CLASSBAZFIYAT
        Dim donecekbazfiyat As Decimal
        Dim ensonkaydedilmiskayitno As Integer

        Dim kullanilacakbazfiyat As New CLASSBAZFIYAT
        sirketintumbazfiyatlari = doldursirketpkeykayitnovepolicetipgore(sirketpkey, PolicyType)

        'demekki bu şirket baz fiyat girmemiş
        If sirketintumbazfiyatlari.Count = 0 Then
            donecekbazfiyat = 0
            Return donecekbazfiyat
        End If

        For Each itembazfiyat As CLASSBAZFIYAT In sirketintumbazfiyatlari
            'yani poliçenin başlangıç tarihi bu bazfiyat içine giriyor
            If itembazfiyat.baslangictarih <= StartDate Then
                kullanilacakbazfiyat = itembazfiyat
                tarihicinegirdimi = "Evet"
                Exit For
            End If
        Next

        'bu tarih için geçerlilik süresi olan hiçbir baz fiyat yok! 
        If tarihicinegirdimi = "Hayır" Then
            ensonkaydedilmiskayitno = ensonkayitnobul(sirketpkey, PolicyType)
            kullanilacakbazfiyat = bulsirketpkeykayitnovepolicetipgore(sirketpkey, ensonkaydedilmiskayitno, PolicyType)
        End If

        aractarife = aractarife_erisim.bultarifekodagore(TariffCode)
        bazfiyattarifey = bazfiyattarifey_erisim.bul_ilgili(kullanilacakbazfiyat.pkey, aractarife.pkey)

        'TRAFİK İSE
        If productcode = 15 Then
            Return bazfiyattarifey.trafikmiktar
        End If

        'eski sisteme bu kodu aktarırken burayı çıkart!
        'KISMİ KASKO İSE
        If productcode = 16 And ProductType = "FT" Then
            Return bazfiyattarifey.ftoran
        End If
        If productcode = 16 And ProductType = "CO" Then
            Return bazfiyattarifey.cooran
        End If
        If productcode = 16 And ProductType = "PK" Then
            Return bazfiyattarifey.pertkaskooran
        End If

        'KASKO İSE
        If productcode = 17 Then
            Return bazfiyattarifey.kaskooran
        End If


    End Function


    Public Function tarifeucretbul_arakontrolicin(ByVal productcode As Integer, ByVal sirketpkey As String, _
   ByVal TariffCode As String, ByVal PolicyType As String, ByVal ProductType As String, _
   ByVal StartDate As Date) As Decimal


        Dim tarihicinegirdimi As String
        tarihicinegirdimi = "Hayır"

        Dim aractarife As New CLASSARACTARIFE
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        Dim sirketintumbazfiyatlari As New List(Of CLASSBAZFIYAT)

        Dim bazfiyattarifey As New CLASSBAZFIYATTARIFEY
        Dim bazfiyattarifey_erisim As New CLASSBAZFIYATTARIFEY_ERISIM


        Dim bazfiyat As New CLASSBAZFIYAT
        Dim donecekbazfiyat As Decimal
        Dim ensonkaydedilmiskayitno As Integer

        Dim kullanilacakbazfiyat As New CLASSBAZFIYAT
        sirketintumbazfiyatlari = doldursirketpkeykayitnovepolicetipgore(sirketpkey, PolicyType)

        'demekki bu şirket baz fiyat girmemiş
        If sirketintumbazfiyatlari.Count = 0 Then
            donecekbazfiyat = 0
            Return donecekbazfiyat
        End If

        For Each itembazfiyat As CLASSBAZFIYAT In sirketintumbazfiyatlari
            'yani poliçenin başlangıç tarihi bu bazfiyat içine giriyor
            If itembazfiyat.baslangictarih <= StartDate Then
                kullanilacakbazfiyat = itembazfiyat
                tarihicinegirdimi = "Evet"
                Exit For
            End If
        Next

        'bu tarih için geçerlilik süresi olan hiçbir baz fiyat yok! 
        If tarihicinegirdimi = "Hayır" Then
            ensonkaydedilmiskayitno = ensonkayitnobul(sirketpkey, PolicyType)
            kullanilacakbazfiyat = bulsirketpkeykayitnovepolicetipgore(sirketpkey, ensonkaydedilmiskayitno, PolicyType)
        End If

        aractarife = aractarife_erisim.bultarifekodagore(TariffCode)
        bazfiyattarifey = bazfiyattarifey_erisim.bul_ilgili(kullanilacakbazfiyat.pkey, aractarife.pkey)

        'TRAFİK İSE
        If productcode = 15 Then
            Return bazfiyattarifey.trafikmiktar
        End If

        'eski sisteme bu kodu aktarırken burayı çıkart!
        'KISMİ KASKO İSE
        If productcode = 16 And ProductType = "FT" Then
            Return bazfiyattarifey.minftmiktar
        End If
        If productcode = 16 And ProductType = "CO" Then
            Return bazfiyattarifey.cominmiktar
        End If
        If productcode = 16 And ProductType = "PK" Then
            Return bazfiyattarifey.minpertkaskomiktar
        End If

        'KASKO İSE
        If productcode = 17 Then
            Return bazfiyattarifey.minkaskomiktar
        End If


    End Function



    Function kayitnovarmi(ByVal kayitno As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyat where kayitno=@kayitno"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kayitno", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kayitno
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function

    Public Function kayitguncelmi(ByVal pkey As String) As String

        Dim admin_ensonkayitno As Integer
        Dim donecek As String
        donecek = "Hayır"

        Dim bazfiyat As New CLASSBAZFIYAT
        Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE_ERISIM

        bazfiyat = bultek(pkey)
        admin_ensonkayitno = bazfiyatgirissure.sonkayitnonedir(bazfiyat.policetip)

        If bazfiyat.kayitno = admin_ensonkayitno Then
            donecek = "Evet"
        End If

        Return donecek

    End Function

End Class


