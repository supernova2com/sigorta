Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSBAZFIYATGIRISSURE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal bazfiyatgirissure As CLASSBAZFIYATGIRISSURE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(bazfiyatgirissure.kayitno, bazfiyatgirissure.policetip)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıt numarası ve poliçe tipinde halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into bazfiyatgirissure values (@pkey," + _
            "@girisbaslangic,@girisbitis,@gecerlilikbaslangic,@gecerlilikbitis," + _
            "@policetip,@kayitno)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@girisbaslangic", SqlDbType.Date)
            param2.Direction = ParameterDirection.Input
            If bazfiyatgirissure.girisbaslangic Is Nothing Or bazfiyatgirissure.girisbaslangic = "00:00:00" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = bazfiyatgirissure.girisbaslangic
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@girisbitis", SqlDbType.Date)
            param3.Direction = ParameterDirection.Input
            If bazfiyatgirissure.girisbitis Is Nothing Or bazfiyatgirissure.girisbitis = "00:00:00" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = bazfiyatgirissure.girisbitis
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@gecerlilikbaslangic", SqlDbType.Date)
            param4.Direction = ParameterDirection.Input
            If bazfiyatgirissure.gecerlilikbaslangic Is Nothing Or bazfiyatgirissure.gecerlilikbaslangic = "00:00:00" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = bazfiyatgirissure.gecerlilikbaslangic
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@gecerlilikbitis", SqlDbType.Date)
            param5.Direction = ParameterDirection.Input
            If bazfiyatgirissure.gecerlilikbitis Is Nothing Or bazfiyatgirissure.gecerlilikbitis = "00:00:00" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = bazfiyatgirissure.gecerlilikbitis
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@policetip", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If bazfiyatgirissure.policetip = 0 Then
                param6.Value = 0
            Else
                param6.Value = bazfiyatgirissure.policetip
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@kayitno", SqlDbType.Int)
            param7.Direction = ParameterDirection.Input
            If bazfiyatgirissure.kayitno = 0 Then
                param7.Value = 0
            Else
                param7.Value = bazfiyatgirissure.kayitno
            End If
            komut.Parameters.Add(param7)

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
        sqlstr = "select max(pkey) from bazfiyatgirissure"
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
    Function Duzenle(ByVal bazfiyatgirissure As CLASSBAZFIYATGIRISSURE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update bazfiyatgirissure set " + _
        "girisbaslangic=@girisbaslangic," + _
        "girisbitis=@girisbitis," + _
        "gecerlilikbaslangic=@gecerlilikbaslangic," + _
        "gecerlilikbitis=@gecerlilikbitis," + _
        "policetip=@policetip," + _
        "kayitno=@kayitno" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatgirissure.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@girisbaslangic", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        If bazfiyatgirissure.girisbaslangic Is Nothing Or bazfiyatgirissure.girisbaslangic = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = bazfiyatgirissure.girisbaslangic
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@girisbitis", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        If bazfiyatgirissure.girisbitis Is Nothing Or bazfiyatgirissure.girisbitis = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = bazfiyatgirissure.girisbitis
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@gecerlilikbaslangic", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        If bazfiyatgirissure.gecerlilikbaslangic Is Nothing Or bazfiyatgirissure.gecerlilikbaslangic = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = bazfiyatgirissure.gecerlilikbaslangic
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@gecerlilikbitis", SqlDbType.Date)
        param5.Direction = ParameterDirection.Input
        If bazfiyatgirissure.gecerlilikbitis Is Nothing Or bazfiyatgirissure.gecerlilikbitis = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = bazfiyatgirissure.gecerlilikbitis
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@policetip", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If bazfiyatgirissure.policetip = 0 Then
            param6.Value = 0
        Else
            param6.Value = bazfiyatgirissure.policetip
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@kayitno", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If bazfiyatgirissure.kayitno = 0 Then
            param7.Value = 0
        Else
            param7.Value = bazfiyatgirissure.kayitno
        End If
        komut.Parameters.Add(param7)


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
    Function bultek(ByVal pkey As String) As CLASSBAZFIYATGIRISSURE

        Dim komut As New SqlCommand
        Dim donecekbazfiyatgirissure As New CLASSBAZFIYATGIRISSURE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyatgirissure where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("girisbaslangic") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.girisbaslangic = veri.Item("girisbaslangic")
                End If

                If Not veri.Item("girisbitis") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.girisbitis = veri.Item("girisbitis")
                End If

                If Not veri.Item("gecerlilikbaslangic") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.gecerlilikbaslangic = veri.Item("gecerlilikbaslangic")
                End If

                If Not veri.Item("gecerlilikbitis") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.gecerlilikbitis = veri.Item("gecerlilikbitis")
                End If

                If Not veri.Item("policetip") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.policetip = veri.Item("policetip")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.kayitno = veri.Item("kayitno")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyatgirissure

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM
        bazfiyatgirissure = bultek(pkey)

        Dim varmi As String
        varmi = bazfiyat_erisim.kayitnovarmi(bazfiyatgirissure.kayitno)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıt için baz fiyat girişi olduğundan bu giriş süresini silemezsiniz."
            resultset.etkilenen = 0
        End If


        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from bazfiyatgirissure where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSBAZFIYATGIRISSURE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
        Dim bazfiyatgirissureler As New List(Of CLASSBAZFIYATGIRISSURE)
        komut.Connection = db_baglanti
        sqlstr = "select * from bazfiyatgirissure"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("girisbaslangic") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.girisbaslangic = veri.Item("girisbaslangic")
                End If

                If Not veri.Item("girisbitis") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.girisbitis = veri.Item("girisbitis")
                End If

                If Not veri.Item("gecerlilikbaslangic") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.gecerlilikbaslangic = veri.Item("gecerlilikbaslangic")
                End If

                If Not veri.Item("gecerlilikbitis") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.gecerlilikbitis = veri.Item("gecerlilikbitis")
                End If

                If Not veri.Item("policetip") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.policetip = veri.Item("policetip")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekbazfiyatgirissure.kayitno = veri.Item("kayitno")
                End If


                bazfiyatgirissureler.Add(New CLASSBAZFIYATGIRISSURE(donecekbazfiyatgirissure.pkey, _
                donecekbazfiyatgirissure.girisbaslangic, donecekbazfiyatgirissure.girisbitis, donecekbazfiyatgirissure.gecerlilikbaslangic, donecekbazfiyatgirissure.gecerlilikbitis, _
                donecekbazfiyatgirissure.policetip, donecekbazfiyatgirissure.kayitno))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bazfiyatgirissureler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
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
        "<th>Giriş Başlangıç Tarihi</th>" + _
        "<th>Giriş Bitiş Tarihi</th>" + _
        "<th>Geçerlilik Başlangıç Tarihi</th>" + _
        "<th>Geçerlilik Bitiş Tarihi</th>" + _
        "<th>Poliçe Tipi</th>" + _
        "<th>Kayıt Numarası</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from bazfiyatgirissure"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, girisbaslangic, girisbitis, gecerlilikbaslangic, gecerlilikbitis, policetip, kayitno As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "bazfiyatgirissure.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("girisbaslangic") Is System.DBNull.Value Then
                        girisbaslangic = veri.Item("girisbaslangic")
                        kol2 = "<td>" + girisbaslangic + "</td>"
                    End If

                    If Not veri.Item("girisbitis") Is System.DBNull.Value Then
                        girisbitis = veri.Item("girisbitis")
                        kol3 = "<td>" + girisbitis + "</td>"
                    End If

                    If Not veri.Item("gecerlilikbaslangic") Is System.DBNull.Value Then
                        gecerlilikbaslangic = veri.Item("gecerlilikbaslangic")
                        kol4 = "<td>" + gecerlilikbaslangic + "</td>"
                    End If

                    If Not veri.Item("gecerlilikbitis") Is System.DBNull.Value Then
                        gecerlilikbitis = veri.Item("gecerlilikbitis")
                        kol5 = "<td>" + gecerlilikbitis + "</td>"
                    End If

                    If Not veri.Item("policetip") Is System.DBNull.Value Then
                        policetip = veri.Item("policetip")
                        kol6 = "<td>" + policetip + "</td>"
                    End If

                    If Not veri.Item("kayitno") Is System.DBNull.Value Then
                        kayitno = veri.Item("kayitno")
                        kol7 = "<td>" + kayitno + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
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
    Function ciftkayitkontrol(ByVal kayitno As Integer, ByVal policetip As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyatgirissure where kayitno=@kayitno and policetip=@policetip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kayitno", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kayitno
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@policetip", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = policetip
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function sonkayitnobul(ByVal policetip As String) As Integer

        Dim sqlstr As String
        Dim sonkayitno As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(kayitno) from bazfiyatgirissure where policetip=@policetip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@policetip", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = policetip
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            sonkayitno = 1
        Else
            sonkayitno = maxkayit1 + 1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return sonkayitno

    End Function


    Public Function sonkayitnonedir(ByVal policetip As String) As Integer

        Dim sqlstr As String
        Dim sonkayitno As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(kayitno) from bazfiyatgirissure where policetip=@policetip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@policetip", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = policetip
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            sonkayitno = 0
        Else
            sonkayitno = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return sonkayitno

    End Function



    Public Function sureyetkilimi() As CLASSBAZFIYATGIRISSURE


        Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
        Dim pkey As String
        Dim girdi As String = "0"
        Dim simdikitarih As Date
        simdikitarih = Date.Now


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyatgirissure where " + _
        "Convert(DATE,girisbaslangic)<=@simdikitarih and Convert(DATE,girisbitis)>=@simdikitarih"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@simdikitarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = simdikitarih
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                girdi = "1"

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    pkey = CStr(veri.Item("pkey"))
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            bazfiyatgirissure = bultek(pkey)
        End If

        Return bazfiyatgirissure


    End Function


End Class


