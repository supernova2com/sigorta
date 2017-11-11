Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSTEKLIF_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim teklif As New CLASSTEKLIF
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal teklif As CLASSTEKLIF) As CLADBOPRESULT

        etkilenen = 0
        Dim kaydedilenpkey As Integer

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into teklif values (@pkey," + _
        "@uyepkey,@pertaracpkey,@tutar,@tutarcurrencypkey," + _
        "@tekliftarih,@okunmusmu,@sirketpkey,@tip)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        kaydedilenpkey = pkeybul()
        param1.Value = kaydedilenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@uyepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If teklif.uyepkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = teklif.uyepkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If teklif.pertaracpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = teklif.pertaracpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tutar", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If teklif.tutar = 0 Then
            param4.Value = 0
        Else
            param4.Value = teklif.tutar
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tutarcurrencypkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If teklif.tutarcurrencypkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = teklif.tutarcurrencypkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@tekliftarih", SqlDbType.DateTime)
        param6.Direction = ParameterDirection.Input
        If teklif.tekliftarih Is Nothing Or teklif.tekliftarih = "00:00:00" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = teklif.tekliftarih
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If teklif.okunmusmu = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = teklif.okunmusmu
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If teklif.sirketpkey = 0 Then
            param8.Value = 0
        Else
            param8.Value = teklif.sirketpkey
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@tip", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If teklif.tip = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = teklif.tip
        End If
        komut.Parameters.Add(param9)

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
            resultset.etkilenen = kaydedilenpkey
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
        sqlstr = "select max(pkey) from teklif"
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
    Function Duzenle(ByVal teklif As CLASSTEKLIF) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update teklif set " + _
        "uyepkey=@uyepkey," + _
        "pertaracpkey=@pertaracpkey," + _
        "tutar=@tutar," + _
        "tutarcurrencypkey=@tutarcurrencypkey," + _
        "tekliftarih=@tekliftarih," + _
        "okunmusmu=@okunmusmu," + _
        "sirketpkey=@sirketpkey," + _
        "tip=@tip" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = teklif.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@uyepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If teklif.uyepkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = teklif.uyepkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If teklif.pertaracpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = teklif.pertaracpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tutar", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If teklif.tutar = 0 Then
            param4.Value = 0
        Else
            param4.Value = teklif.tutar
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tutarcurrencypkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If teklif.tutarcurrencypkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = teklif.tutarcurrencypkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@tekliftarih", SqlDbType.DateTime)
        param6.Direction = ParameterDirection.Input
        If teklif.tekliftarih Is Nothing Or teklif.tekliftarih = "00:00:00" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = teklif.tekliftarih
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@okunmusmu", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If teklif.okunmusmu = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = teklif.okunmusmu
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If teklif.sirketpkey = 0 Then
            param8.Value = 0
        Else
            param8.Value = teklif.sirketpkey
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@tip", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If teklif.tip = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = teklif.tip
        End If
        komut.Parameters.Add(param9)


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
    Function bultek(ByVal pkey As String) As CLASSTEKLIF

        Dim komut As New SqlCommand
        Dim donecekteklif As New CLASSTEKLIF()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from teklif where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekteklif.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("uyepkey") Is System.DBNull.Value Then
                    donecekteklif.uyepkey = veri.Item("uyepkey")
                End If

                If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                    donecekteklif.pertaracpkey = veri.Item("pertaracpkey")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekteklif.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("tutarcurrencypkey") Is System.DBNull.Value Then
                    donecekteklif.tutarcurrencypkey = veri.Item("tutarcurrencypkey")
                End If

                If Not veri.Item("tekliftarih") Is System.DBNull.Value Then
                    donecekteklif.tekliftarih = veri.Item("tekliftarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekteklif.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekteklif.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekteklif.tip = veri.Item("tip")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekteklif

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from teklif where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSTEKLIF)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekteklif As New CLASSTEKLIF
        Dim teklifler As New List(Of CLASSTEKLIF)
        komut.Connection = db_baglanti
        sqlstr = "select * from teklif"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekteklif.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("uyepkey") Is System.DBNull.Value Then
                    donecekteklif.uyepkey = veri.Item("uyepkey")
                End If

                If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                    donecekteklif.pertaracpkey = veri.Item("pertaracpkey")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekteklif.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("tutarcurrencypkey") Is System.DBNull.Value Then
                    donecekteklif.tutarcurrencypkey = veri.Item("tutarcurrencypkey")
                End If

                If Not veri.Item("tekliftarih") Is System.DBNull.Value Then
                    donecekteklif.tekliftarih = veri.Item("tekliftarih")
                End If

                If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                    donecekteklif.okunmusmu = veri.Item("okunmusmu")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekteklif.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekteklif.tip = veri.Item("tip")
                End If

                teklifler.Add(New CLASSTEKLIF(donecekteklif.pkey, _
                donecekteklif.uyepkey, donecekteklif.pertaracpkey, donecekteklif.tutar, _
                donecekteklif.tutarcurrencypkey, _
                donecekteklif.tekliftarih, donecekteklif.okunmusmu, donecekteklif.sirketpkey, _
                donecekteklif.tip))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return teklifler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele_sirketin() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
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
        "<th>Üye Bilgileri</th>" + _
        "<th>Araç Bilgileri</th>" + _
        "<th>Tutar</th>" + _
        "<th>Teklif Verilme Tarihi</th>" + _
        "<th>Tipi</th>" + _
        "<th>İşlem</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "sirketin" Then
            sqlstr = "select * from teklif where sirketpkey=@sirketpkey order by pertaracpkey,tutar desc"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("webuye_sirketpkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, uyepkey, pertaracpkey, tutarcurrencypkey, tekliftarih, okunmusmu, tip As String
        Dim tutar As Decimal


        Dim pertarac As New CLASSPERTARAC
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
        Dim pertaracbilgi As String

        Dim araccins As New CLASSARACCINS
        Dim araccins_Erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM


        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim webuyebilgi As String

        Dim ajaxlinkokundu, dugmeokundu As String
        Dim ajaxlinkokunmadi, dugmeokunmadi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "teklif.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("uyepkey") Is System.DBNull.Value Then
                        uyepkey = veri.Item("uyepkey")
                        webuye = webuye_erisim.bultek(uyepkey)

                        webuyebilgi = "Ad Soyad:" + "<b>" + webuye.adsoyad + "</b><br/>" + _
                        "Telefon:" + "<b>" + webuye.telefon + "</b><br/>" + _
                        "E-Posta:" + "<b>" + "<a href='mailto:" + webuye.eposta + "'>" + webuye.eposta + "</a>" + "</b>"

                        kol2 = "<td>" + webuyebilgi + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                        pertaracpkey = veri.Item("pertaracpkey")

                        pertarac = pertarac_erisim.bultek(pertaracpkey)
                        araccins = araccins_Erisim.bultek(pertarac.araccinspkey)
                        aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
                        aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
                        pertaracbilgi = _
                        "Plaka:" + "<b>" + pertarac.plaka + "</b><br/>" + _
                        "Cins:" + "<b>" + araccins.cinsad + "</b><br/>" + _
                        "Marka:" + "<b>" + aracmarka.markaad + "</b><br/>" + _
                        "Model" + "<b>" + aracmodel.modelad + "</b><br/>"

                        kol3 = "<td>" + pertaracbilgi + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                    Else
                        tutar = 0
                    End If

                    If Not veri.Item("tutarcurrencypkey") Is System.DBNull.Value Then
                        tutarcurrencypkey = veri.Item("tutarcurrencypkey")
                        currencycode = currencycode_erisim.bultek(tutarcurrencypkey)
                    End If
                    kol4 = "<td>" + Format(tutar, "0.00") + " " + currencycode.kod + "</td>"

                    If Not veri.Item("tekliftarih") Is System.DBNull.Value Then
                        tekliftarih = veri.Item("tekliftarih")
                        kol5 = "<td>" + tekliftarih + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol6 = "<td>" + tip + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    'OKUNDU OKUNMADI düğmesi
                    ajaxlinkokundu = "okunduyap(" + CStr(pkey) + ")"
                    dugmeokundu = "<span id='okundubutton' onclick='" + ajaxlinkokundu + _
                    "' class='button'>Okundu</span>"

                    ajaxlinkokunmadi = "okunmadiyap(" + CStr(pkey) + ")"
                    dugmeokunmadi = "<span id='okumnadibutton' onclick='" + ajaxlinkokunmadi + _
                    "' class='button'>Okunmadı</span>"

                    If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                        okunmusmu = veri.Item("okunmusmu")
                        If okunmusmu = "Evet" Then
                            kol7 = "<td>" + okunmusmu + "<br/>" + dugmeokunmadi + "</td></tr>"
                        End If
                        If okunmusmu = "Hayır" Then
                            kol7 = "<td>" + okunmusmu + "<br/>" + dugmeokundu + "</td></tr>"
                        End If
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
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



    '---------------------------------listele--------------------------------------
    Public Function listele_uyenin() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
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
        "<th>Üye Bilgileri</th>" + _
        "<th>Araç Bilgileri</th>" + _
        "<th>Tutar</th>" + _
        "<th>Teklif Verilme Tarihi</th>" + _
        "<th>Tipi</th>" + _
        "<th>İlgili</th>" + _
        "<th>İlgili Tarafından Okunmuş mu?</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ--------------------------
        If HttpContext.Current.Session("ltip") = "uyenin" Then
            sqlstr = "select * from teklif where uyepkey=@uyepkey order by tekliftarih desc"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@uyepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("webuye_pkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, uyepkey, pertaracpkey, tutarcurrencypkey, tekliftarih, okunmusmu, tip As String
        Dim sirketpkey As String
        Dim tutar As Decimal

        Dim pertarac As New CLASSPERTARAC
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
        Dim pertaracbilgi As String

        Dim araccins As New CLASSARACCINS
        Dim araccins_Erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM

        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim webuyebilgi As String

        Dim webuyesirket As New CLASSWEBUYE

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "teklif.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = CStr(veri.Item("sirketpkey"))
                        webuyesirket = webuye_erisim.bul_sirketpkeyegore(sirketpkey)
                    End If

                    If Not veri.Item("uyepkey") Is System.DBNull.Value Then
                        uyepkey = veri.Item("uyepkey")
                        webuye = webuye_erisim.bultek(uyepkey)
                        webuyebilgi = "Ad Soyad:" + "<b>" + webuye.adsoyad + "</b><br/>" + _
                        "Telefon:" + "<b>" + webuye.telefon + "</b>"
                        kol2 = "<td>" + webuyebilgi + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                        pertaracpkey = veri.Item("pertaracpkey")

                        pertarac = pertarac_erisim.bultek(pertaracpkey)
                        araccins = araccins_Erisim.bultek(pertarac.araccinspkey)
                        aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
                        aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
                        pertaracbilgi = _
                        "Plaka:" + "<b>" + pertarac.plaka + "</b><br/>" + _
                        "Cins:" + "<b>" + araccins.cinsad + "</b><br/>" + _
                        "Marka:" + "<b>" + aracmarka.markaad + "</b><br/>" + _
                        "Model" + "<b>" + aracmodel.modelad + "</b><br/>"

                        kol3 = "<td>" + pertaracbilgi + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                    Else
                        tutar = 0
                    End If

                    If Not veri.Item("tutarcurrencypkey") Is System.DBNull.Value Then
                        tutarcurrencypkey = veri.Item("tutarcurrencypkey")
                        currencycode = currencycode_erisim.bultek(tutarcurrencypkey)
                    End If
                    kol4 = "<td>" + Format(tutar, "0.00") + " " + currencycode.kod + "</td>"

                    If Not veri.Item("tekliftarih") Is System.DBNull.Value Then
                        tekliftarih = veri.Item("tekliftarih")
                        kol5 = "<td>" + tekliftarih + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol6 = "<td>" + tip + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    kol7 = "<td>" + "Ad Soyad:" + "<b>" + webuyesirket.adsoyad + "</b><br/>" + _
                    "Telefon:" + "<b>" + webuyesirket.telefon + "</b><br/>" + _
                    "E-Posta:" + "<b>" + "<a href='mailto:" + webuyesirket.eposta + "'>" + webuyesirket.eposta + "</a>" + "</b><br/>" + _
                    "</td>"
             
                    If Not veri.Item("okunmusmu") Is System.DBNull.Value Then
                        okunmusmu = veri.Item("okunmusmu")
                        kol8 = "<td>" + okunmusmu + "</td></tr>"
                    Else
                        kol8 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8

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



    '---------------------------------listele--------------------------------------
    Public Function listele_puretable() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
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
        "<th>Teklif No</th>" + _
        "<th>Üye Bilgileri</th>" + _
        "<th>Araç Bilgileri</th>" + _
        "<th>Tutar</th>" + _
        "<th>Teklif Verilme Tarihi</th>" + _
        "<th>Tipi</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
 
        If HttpContext.Current.Session("ltip") = "aracin" Then
            sqlstr = "select * from teklif where pertaracpkey=@pertaracpkey order by tutar desc"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("pertaracpkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, uyepkey, pertaracpkey, tutarcurrencypkey, tekliftarih, okunmusmu, tip As String
        Dim tutar As Decimal


        Dim pertarac As New CLASSPERTARAC
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
        Dim pertaracbilgi As String

        Dim araccins As New CLASSARACCINS
        Dim araccins_Erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM


        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim webuyebilgi As String

        Dim ajaxlinkokundu, dugmeokundu As String
        Dim ajaxlinkokunmadi, dugmeokunmadi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "teklif.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("uyepkey") Is System.DBNull.Value Then
                        uyepkey = veri.Item("uyepkey")
                        webuye = webuye_erisim.bultek(uyepkey)
                        webuyebilgi = "Ad Soyad:" + "<b>" + webuye.adsoyad + "</b><br/>" + _
                        "Telefon:" + "<b>" + webuye.telefon + "</b>"
                        kol2 = "<td>" + webuyebilgi + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                        pertaracpkey = veri.Item("pertaracpkey")

                        pertarac = pertarac_erisim.bultek(pertaracpkey)
                        araccins = araccins_Erisim.bultek(pertarac.araccinspkey)
                        aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
                        aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
                        pertaracbilgi = _
                        "Plaka:" + "<b>" + pertarac.plaka + "</b><br/>" + _
                        "Cins:" + "<b>" + araccins.cinsad + "</b><br/>" + _
                        "Marka:" + "<b>" + aracmarka.markaad + "</b><br/>" + _
                        "Model" + "<b>" + aracmodel.modelad + "</b><br/>"

                        kol3 = "<td>" + pertaracbilgi + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                    Else
                        tutar = 0
                    End If

                    If Not veri.Item("tutarcurrencypkey") Is System.DBNull.Value Then
                        tutarcurrencypkey = veri.Item("tutarcurrencypkey")
                        currencycode = currencycode_erisim.bultek(tutarcurrencypkey)
                    End If
                    kol4 = "<td>" + Format(tutar, "0.00") + " " + currencycode.kod + "</td>"

                    If Not veri.Item("tekliftarih") Is System.DBNull.Value Then
                        tekliftarih = veri.Item("tekliftarih")
                        kol5 = "<td>" + tekliftarih + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol6 = "<td>" + tip + "</td></tr>"
                    Else
                        kol6 = "<td>-</td></tr>"
                    End If

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
            donecek = "Herhangi bir teklif kaydı bulunamadı."
        End If

        Return (donecek)

    End Function


    Public Function teklifsayisi_aracbazinda(ByVal pertaracpkey As Integer) As Integer

        Dim sqlstr As String
        Dim adet As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from teklif where pertaracpkey=@pertaracpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracpkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            adet = 0
        Else
            adet = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return adet

    End Function


    Function pertaracvarmi(ByVal pertaracpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from teklif where pertaracpkey=@pertaracpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracpkey
        komut.Parameters.Add(param1)

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


    Function currencycodevarmi(ByVal currencycodepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from teklif where tutarcurrencypkey=@tutarcurrencypkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tutarcurrencypkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = currencycodepkey
        komut.Parameters.Add(param1)

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


End Class

