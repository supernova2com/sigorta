Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Globalization.CultureInfo
Imports System.Globalization


Public Class CLASSSINIRKAPITAKVIM_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sinirkapitakvim As New CLASSSINIRKAPITAKVIM
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sinirkapitakvim As CLASSSINIRKAPITAKVIM) As CLADBOPRESULT


        etkilenen = 0
        'Dim varmi1 As String
        'varmi1 = ciftkayitkontrol(sinirkapitakvim.sinirkapipkey, sinirkapitakvim.gbaslangic, _
        'sinirkapitakvim.gbitis, sinirkapitakvim.gerceksirket1pkey)

        'If varmi1 = "Evet" Then
        'resultset.durum = "Kayıt yapılamadı."
        'resultset.hatastr = "Bu kayıt halihazırda veritabanında vardır."
        'resultset.etkilenen = 0
        'Return resultset
        'End If

        Dim eklenenpkey As Integer

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into sinirkapitakvim values (@pkey," + _
        "@sinirkapipkey,@gbaslangic,@gbitis,@gerceksirket1pkey,@gorevlisirket1pkey)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        eklenenpkey = pkeybul()
        param1.Value = eklenenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sinirkapitakvim.sinirkapipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sinirkapitakvim.sinirkapipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@gbaslangic", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If sinirkapitakvim.gbaslangic Is Nothing Or sinirkapitakvim.gbaslangic = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sinirkapitakvim.gbaslangic
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@gbitis", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If sinirkapitakvim.gbitis Is Nothing Or sinirkapitakvim.gbitis = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sinirkapitakvim.gbitis
        End If
        komut.Parameters.Add(param4)


        Dim param5 As New SqlParameter("@gerceksirket1pkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If sinirkapitakvim.gerceksirket1pkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = sinirkapitakvim.gerceksirket1pkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@gorevlisirket1pkey", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If sinirkapitakvim.gorevlisirket1pkey = 0 Then
            param6.Value = 0
        Else
            param6.Value = sinirkapitakvim.gorevlisirket1pkey
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
        sqlstr = "select max(pkey) from sinirkapitakvim"
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
    Function Duzenle(ByVal sinirkapitakvim As CLASSSINIRKAPITAKVIM) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update sinirkapitakvim set " + _
        "sinirkapipkey=@sinirkapipkey," + _
        "gbaslangic=@gbaslangic," + _
        "gbitis=@gbitis," + _
        "gerceksirket1pkey=@gerceksirket1pkey," + _
        "gorevlisirket1pkey=@gorevlisirket1pkey" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapitakvim.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sinirkapitakvim.sinirkapipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sinirkapitakvim.sinirkapipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@gbaslangic", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If sinirkapitakvim.gbaslangic Is Nothing Or sinirkapitakvim.gbaslangic = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sinirkapitakvim.gbaslangic
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@gbitis", SqlDbType.DateTime)
        param4.Direction = ParameterDirection.Input
        If sinirkapitakvim.gbitis Is Nothing Or sinirkapitakvim.gbitis = "00:00:00" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sinirkapitakvim.gbitis
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@gerceksirket1pkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If sinirkapitakvim.gerceksirket1pkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = sinirkapitakvim.gerceksirket1pkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@gorevlisirket1pkey", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If sinirkapitakvim.gorevlisirket1pkey = 0 Then
            param6.Value = 0
        Else
            param6.Value = sinirkapitakvim.gorevlisirket1pkey
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
    Function bultek(ByVal pkey As String) As CLASSSINIRKAPITAKVIM

        Dim komut As New SqlCommand
        Dim doneceksinirkapitakvim As New CLASSSINIRKAPITAKVIM()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapitakvim where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.sinirkapipkey = veri.Item("sinirkapipkey")
                End If

                If Not veri.Item("gbaslangic") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gbaslangic = veri.Item("gbaslangic")
                End If

                If Not veri.Item("gbitis") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gbitis = veri.Item("gbitis")
                End If

                If Not veri.Item("gerceksirket1pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gerceksirket1pkey = veri.Item("gerceksirket1pkey")
                End If

                If Not veri.Item("gorevlisirket1pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gorevlisirket1pkey = veri.Item("gorevlisirket1pkey")
                End If

               
            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksinirkapitakvim

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from sinirkapitakvim where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSINIRKAPITAKVIM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksinirkapitakvim As New CLASSSINIRKAPITAKVIM
        Dim sinirkapitakvimler As New List(Of CLASSSINIRKAPITAKVIM)
        komut.Connection = db_baglanti
        sqlstr = "select * from sinirkapitakvim"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.sinirkapipkey = veri.Item("sinirkapipkey")
                End If

                If Not veri.Item("gbaslangic") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gbaslangic = veri.Item("gbaslangic")
                End If

                If Not veri.Item("gbitis") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gbitis = veri.Item("gbitis")
                End If

                If Not veri.Item("gerceksirket1pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gerceksirket1pkey = veri.Item("gerceksirket1pkey")
                End If

                If Not veri.Item("gorevlisirket1pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gorevlisirket1pkey = veri.Item("gorevlisirket1pkey")
                End If


                sinirkapitakvimler.Add(New CLASSSINIRKAPITAKVIM(doneceksinirkapitakvim.pkey, _
                doneceksinirkapitakvim.sinirkapipkey, doneceksinirkapitakvim.gbaslangic, _
                doneceksinirkapitakvim.gbitis, doneceksinirkapitakvim.gerceksirket1pkey, _
                doneceksinirkapitakvim.gorevlisirket1pkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sinirkapitakvimler

    End Function

   

    Public Function doldur_tarih(ByVal qdate As DateTime) As List(Of CLASSSINIRKAPITAKVIM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksinirkapitakvim As New CLASSSINIRKAPITAKVIM
        Dim sinirkapitakvimler As New List(Of CLASSSINIRKAPITAKVIM)
        komut.Connection = db_baglanti

        sqlstr = "select * from sinirkapitakvim where " + _
        "Convert(DATE,gbaslangic)>=@tarih and Convert(DATE,gbitis)<=@tarih"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param1.Direction = ParameterDirection.Input
        param1.Value = qdate
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.sinirkapipkey = veri.Item("sinirkapipkey")
                End If

                If Not veri.Item("gbaslangic") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gbaslangic = veri.Item("gbaslangic")
                End If

                If Not veri.Item("gbitis") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gbitis = veri.Item("gbitis")
                End If

                If Not veri.Item("gerceksirket1pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gerceksirket1pkey = veri.Item("gerceksirket1pkey")
                End If

                If Not veri.Item("gorevlisirket1pkey") Is System.DBNull.Value Then
                    doneceksinirkapitakvim.gorevlisirket1pkey = veri.Item("gorevlisirket1pkey")
                End If


                sinirkapitakvimler.Add(New CLASSSINIRKAPITAKVIM(doneceksinirkapitakvim.pkey, _
                doneceksinirkapitakvim.sinirkapipkey, doneceksinirkapitakvim.gbaslangic, _
                doneceksinirkapitakvim.gbitis, doneceksinirkapitakvim.gerceksirket1pkey, _
                doneceksinirkapitakvim.gorevlisirket1pkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sinirkapitakvimler

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
        "<th>Sınır Kapısı</th>" + _
        "<th>Başlangıç Tarih ve Saati</th>" + _
        "<th>Bitiş Tarih ve Saati</th>" + _
        "<th>Gerçek Şirket 1</th>" + _
        "<th>Görevli Şirket 1</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from sinirkapitakvim"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "tarih" Then
            sqlstr = "select * from sinirkapitakvim where Convert(DATE,gbaslangic)=@gbaslangic"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@gbaslangic", SqlDbType.Date)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("tarih")
            komut.Parameters.Add(param1)

        End If

        If HttpContext.Current.Session("ltip") = "gerceksirket" Then

            sqlstr = "select * from sinirkapitakvim where " + _
            "gerceksirket1pkey=@gerceksirket1pkey order by gbaslangic"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@gerceksirket1pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("sirketpkey")
            komut.Parameters.Add(param1)

        End If


        If HttpContext.Current.Session("ltip") = "gorevlisirket" Then

            sqlstr = "select * from sinirkapitakvim where " + _
            "gorevlisirket1pkey=@gorevlisirket1pkey order by gbaslangic"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@gorevlisirket1pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("sirketpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sinirkapipkey, gbaslangic, gbitis As String
        Dim sinirkapi As New CLASSSINIRKAPI
        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM

        Dim gerceksirket1pkey, gorevlisirket1pkey As String
        Dim gerceksirket1 As New CLASSSIRKET
        Dim gorevlisirket1 As New CLASSSIRKET
      
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "sinirkapitakvim.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                        sinirkapipkey = veri.Item("sinirkapipkey")
                        sinirkapi = sinirkapi_erisim.bultek(sinirkapipkey)
                        kol2 = "<td>" + sinirkapi.sinirkapiad + " (" + sinirkapi.sinirkapikod + ")" + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("gbaslangic") Is System.DBNull.Value Then
                        gbaslangic = veri.Item("gbaslangic")
                        kol3 = "<td>" + gbaslangic + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("gbitis") Is System.DBNull.Value Then
                        gbitis = veri.Item("gbitis")
                        kol4 = "<td>" + gbitis + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("gerceksirket1pkey") Is System.DBNull.Value Then
                        gerceksirket1pkey = veri.Item("gerceksirket1pkey")
                        gerceksirket1 = sirket_erisim.bultek(gerceksirket1pkey)
                        kol5 = "<td>" + gerceksirket1.sirketad + " (" + gerceksirket1.sirketkod + ")" + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("gorevlisirket1pkey") Is System.DBNull.Value Then
                        gorevlisirket1pkey = veri.Item("gorevlisirket1pkey")
                        gorevlisirket1 = sirket_erisim.bultek(gorevlisirket1pkey)
                        kol6 = "<td>" + gorevlisirket1.sirketad + " (" + gorevlisirket1.sirketkod + ")" + "</td></tr>"
                    Else
                        kol6 = "<td>-</td></tr>"
                    End If

                 

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
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


    Function ciftkayitkontrol(ByVal sinirkapipkey As Integer, ByVal gbaslangic As DateTime, _
    ByVal gbitis As DateTime, ByVal gerceksirket1pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapitakvim where sinirkapipkey=@sinirkapipkey and " + _
        "(gbaslangic=@gbaslangic and gbitis=@gbitis) and " + _
        "gerceksirket1pkey=@gerceksirket1pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapipkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@gbaslangic", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = gbaslangic
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@gbitis", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        param3.Value = gbitis
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@gerceksirket1pkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = gerceksirket1pkey
        komut.Parameters.Add(param4)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Public Function yetkilimi(ByVal PolicyInfo As PolicyInfo, ByVal sinirkapi As CLASSSINIRKAPI) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        Dim ArrangeDate As Date
        ArrangeDate = PolicyInfo.ArrangeDate
        Dim kArrangeDate As New DateTime(ArrangeDate.Year, ArrangeDate.Month, ArrangeDate.Day, "00", "01", "01")

        result.durum = "Evet"
        result.etkilenen = 1
        result.hatastr = ""

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim FirmCode As String
        FirmCode = PolicyInfo.FirmCode
        sirket = sirket_erisim.bultek_sirketkodagore(FirmCode)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapitakvim where sinirkapipkey=@sinirkapipkey and " + _
        "(gbaslangic<=@tarih and gbitis>=@tarih) and " + _
        "gorevlisirket1pkey=@gorevlisirket1pkey "

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapi.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = kArrangeDate
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@gorevlisirket1pkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = sirket.pkey
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        If varmi = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 853
            result.hatastr = CStr(PolicyInfo.ArrangeDate) + " tarihinde '" + sirket.sirketad + _
            "' adlı şirket '" + sinirkapi.sinirkapiad + "' adlı sınır kapısında görevli değildir."
            Return result
        End If

        Return result

    End Function


    Public Function GetAttendantBorderFirms(ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal qdate As String) As String

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim sinirkapi As New CLASSSINIRKAPI
        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM


        Dim girdisayisi As Integer = 0
        Dim damagelist As New List(Of Damage)

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        Dim yetkiresult As New CLADBOPRESULT
        yetkiresult = sirket_erisim.yetkilimi2(wskullaniciad, wssifre)
        If yetkiresult.durum = "Yetkisiz" Then

            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "GetAttendantBorderFirms", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.GetDamageResultStr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.GetDamageResultStr

        End If

        'TARİH DEĞERİ DOGRU MU
        Dim d As DateTime
        Try
            d = qdate
        Catch ex As Exception

            root.ResultCode = 0
            ErrorInfo.Code = 200
            ErrorInfo.Message = "Sorgulama yapmak istediğiniz tarih formatı yanlış. (yyyy-MM-dd) olmalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "GetAttendantBorderFirms", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr

        End Try



        'İŞLEMLERE BAŞLA

        Dim gerceksirket As New CLASSSIRKET
        Dim gorevlisirket As New CLASSSIRKET

        Dim icsirket As String = ""
        Dim sinirkapitakvimler As New List(Of CLASSSINIRKAPITAKVIM)
        sinirkapitakvimler = doldur_tarih(qdate)

        For Each Item As CLASSSINIRKAPITAKVIM In sinirkapitakvimler

            gerceksirket = sirket_erisim.bultek(Item.gerceksirket1pkey)
            gorevlisirket = sirket_erisim.bultek(Item.gorevlisirket1pkey)
            sinirkapi = sinirkapi_erisim.bultek(Item.sinirkapipkey)

            icsirket = icsirket + "<Firm" + _
            " Type=" + Chr(34) + "Gerçek" + Chr(34) + _
            " Code=" + Chr(34) + CStr(gerceksirket.sirketkod) + Chr(34) + _
            " Name=" + Chr(34) + CStr(gerceksirket.sirketad) + Chr(34) + "/>" + _
            " <Firm Type=" + Chr(34) + "Görevli" + Chr(34) + _
            " Code=" + Chr(34) + CStr(gorevlisirket.sirketkod) + Chr(34) + _
            " Name=" + Chr(34) + CStr(gorevlisirket.sirketad) + Chr(34) + _
            " BorderCode=" + Chr(34) + CStr(sinirkapi.sinirkapikod) + Chr(34) + _
            " BorderName=" + Chr(34) + CStr(sinirkapi.sinirkapiad) + Chr(34) + _
            "/>"

        Next

        donecek = "<root ResultCode=" + Chr(34) + "1" + Chr(34) + ">" + _
        "<Firms>" + _
        icsirket + _
        "</Firms>" + _
        "</root>"

        Return donecek

    End Function



    Public Function CheckOnBorder(ByVal wskullaniciad As String, ByVal wssifre As String) As Boolean

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim sinirkapi As New CLASSSINIRKAPI
        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM

        Dim girdisayisi As Integer = 0
        Dim damagelist As New List(Of Damage)

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket.pkey = 0 Then

            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı yada şifre hatalı"
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "CheckOnBorder", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return False

        End If


        'İŞLEMLERE BAŞLA
        Dim varmikapikod As String
        Dim sirketkod As String
        sirketkod = sirket.sirketkod
        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()
        Dim PolicyInfo As New PolicyInfo
        Dim tarih As DateTime
        tarih = DateTime.Now
        PolicyInfo.ArrangeDate = tarih
        PolicyInfo.FirmCode = sirketkod
        PolicyInfo.AgencyRegisterCode = ipadres
        varmikapikod = sinirkapi_erisim.varmikapikod(PolicyInfo.AgencyRegisterCode)
        If varmikapikod = "Hayır" Then

            root.ResultCode = 0
            ErrorInfo.Code = 333
            ErrorInfo.Message = "Bu ip adresi için sınır kapısı tanımlanmamış."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "CheckOnBorder", _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return False
        End If

        Dim BorderCode As String
        BorderCode = sinirkapi_erisim.bordercodebul(PolicyInfo.AgencyRegisterCode)
        sinirkapi = sinirkapi_erisim.bultek_kapikodgore(BorderCode)

        Dim kapidagorevlimi As New CLADBOPRESULT
        kapidagorevlimi = yetkilimi(PolicyInfo, sinirkapi)

        If kapidagorevlimi.durum = "Hayır" Then

            root.ResultCode = 0
            ErrorInfo.Code = kapidagorevlimi.etkilenen
            ErrorInfo.Message = kapidagorevlimi.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "CheckOnBorder", _
            root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "-", wskullaniciad, _
            wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return False
        End If


        If kapidagorevlimi.durum = "Evet" Then

            root.ResultCode = 1
            ErrorInfo.Code = 0
            ErrorInfo.Message = Nothing
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, "CheckOnBorder", _
            root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "-", wskullaniciad, _
            wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return True
        End If

    End Function



End Class


