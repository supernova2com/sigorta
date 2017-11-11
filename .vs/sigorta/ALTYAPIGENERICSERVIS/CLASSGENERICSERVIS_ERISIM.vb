Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Net
Imports System.Xml
Imports System.Security
Imports System.Globalization.CultureInfo
Imports System.Globalization


Public Class CLASSGENERICSERVIS_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim genericservis As New CLASSGENERICSERVIS
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal genericservis As CLASSGENERICSERVIS) As CLADBOPRESULT

        Dim kaydedilenpkey As Integer
        etkilenen = 0
   
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into genericservis values (@pkey," + _
        "@sqlstrrun,@tip,@ad,@aciklama)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        kaydedilenpkey = pkeybul()
        param1.Value = kaydedilenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sqlstrrun", SqlDbType.Text)
        param2.Direction = ParameterDirection.Input
        If genericservis.sqlstrrun = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = genericservis.sqlstrrun
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tip", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If genericservis.tip = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = genericservis.tip
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If genericservis.ad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = genericservis.ad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@aciklama", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If genericservis.aciklama = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = genericservis.aciklama
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
        sqlstr = "select max(pkey) from genericservis"
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
    Function Duzenle(ByVal genericservis As CLASSGENERICSERVIS) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update genericservis set " + _
        "sqlstrrun=@sqlstrrun," + _
        "tip=@tip," + _
        "ad=@ad," + _
        "aciklama=@aciklama" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservis.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sqlstrrun", SqlDbType.Text)
        param2.Direction = ParameterDirection.Input
        If genericservis.sqlstrrun = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = genericservis.sqlstrrun
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tip", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If genericservis.tip = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = genericservis.tip
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If genericservis.ad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = genericservis.ad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@aciklama", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If genericservis.aciklama = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = genericservis.aciklama
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
    Function bultek(ByVal pkey As String) As CLASSGENERICSERVIS

        Dim komut As New SqlCommand
        Dim donecekgenericservis As New CLASSGENERICSERVIS()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericservis where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericservis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sqlstrrun") Is System.DBNull.Value Then
                    donecekgenericservis.sqlstrrun = veri.Item("sqlstrrun")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekgenericservis.tip = veri.Item("tip")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekgenericservis.ad = veri.Item("ad")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekgenericservis.aciklama = veri.Item("aciklama")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekgenericservis

    End Function

    '---------------------------------sil-----------------------------------------

    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim genericservistablo_erisim As New CLASSGENERICSERVISTABLO_ERISIM
        Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
        Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
        Dim genericserviskullanici_erisim As New CLASSGENERICSERVISKULLANICI_ERISIM

        Dim varmi_tablo As String
        Dim varmi_input As String
        Dim varmi_output As String
        Dim varmi_kullanici As String

        varmi_tablo = genericservistablo_erisim.genericservisvarmi(pkey)
        varmi_input = genericservisinput_erisim.genericservisvarmi(pkey)
        varmi_output = genericservisoutput_erisim.genericservisvarmi(pkey)
        varmi_kullanici = genericserviskullanici_erisim.genericservisvarmi(pkey)

        If varmi_tablo = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu servisin altında tablolar tanımlanmış. " + _
            "Bu sebepten bu servisi silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_input = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu servisin altında input parametreleri tanımlanmış. " + _
            "Bu sebepten bu servisi silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_output = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu servisin altında output parametreleri tanımlanmış. " + _
            "Bu sebepten bu servisi silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_kullanici = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu servisin altında kullanıcılar tanımlanmış. " + _
            "Bu sebepten bu servisi silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from genericservis where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSGENERICSERVIS)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgenericservis As New CLASSGENERICSERVIS
        Dim genericservisler As New List(Of CLASSGENERICSERVIS)
        komut.Connection = db_baglanti
        sqlstr = "select * from genericservis"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericservis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sqlstrrun") Is System.DBNull.Value Then
                    donecekgenericservis.sqlstrrun = veri.Item("sqlstrrun")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekgenericservis.tip = veri.Item("tip")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekgenericservis.ad = veri.Item("ad")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekgenericservis.aciklama = veri.Item("aciklama")
                End If


                genericservisler.Add(New CLASSGENERICSERVIS(donecekgenericservis.pkey, _
                donecekgenericservis.sqlstrrun, donecekgenericservis.tip, _
                donecekgenericservis.ad, donecekgenericservis.aciklama))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return genericservisler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String


        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
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
        "<th>Servis Kodu</th>" + _
        "<th>Ad</th>" + _
        "<th>SQL</th>" + _
        "<th>Tip</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from genericservis"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, tip, ad As String
        Dim sqlstrrun As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "genericservisgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = veri.Item("pkey")
                        kol2 = "<td>" + CStr(pkey) + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If


                    If Not veri.Item("ad") Is System.DBNull.Value Then
                        ad = veri.Item("ad")
                        kol3 = "<td>" + ad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("sqlstrrun") Is System.DBNull.Value Then
                        sqlstrrun = veri.Item("sqlstrrun")
                        kol4 = "<td>" + sqlstrrun + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol5 = "<td>" + tip + "</td></tr>"
                    Else
                        kol5 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5
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



    Public Function yetkilimi(ByVal wskullaniciad As String, _
    ByVal wssifre As String) As CLADBOPRESULT

        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()

        Dim result As New CLADBOPRESULT
        Dim sirket As New CLASSSIRKET
        Dim ipyetkilimi As String = "Hayır"

        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        If sirket.pkey = 0 Then
            result.durum = "Yetkisiz"
            result.hatastr = "Kullanıcı adı yada şifre hatalı"
            result.etkilenen = 1
            Return result
        End If

        If sirket.pkey <> 0 Then
            If sirket.aktifmi = "Hayır" Then
                result.durum = "Yetkisiz"
                result.hatastr = "Kurum aktif değil"
                result.etkilenen = 2
                Return result
            End If
        End If

        If sirket.pkey <> 0 Then
            If sirket.aktifmi = "Evet" Then
                If servisayar.ipdikkat = "Hayır" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                    Return result
                End If
                If sirket.ipdikkat = "Hayır" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                    Return result
                End If
            End If
        End If


        'ip adres kontrol et
        If sirket.ipdikkat = "Evet" Then
            If sirket.pkey <> 0 Then
                Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
                Dim ipadresleri As New List(Of CLASSSIRKETIPBAG)
                ipadresleri = sirketipbag_erisim.doldur_ilgilisirket(sirket.pkey)
                For Each Item As CLASSSIRKETIPBAG In ipadresleri
                    If ip_erisim.range(Item.cidrnotation, IPAddress.Parse(Item.ipadres), IPAddress.Parse(ipadres)) = "Evet" Then
                        ipyetkilimi = "Evet"
                    End If
                Next
                If ipyetkilimi = "Evet" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                End If
                If ipyetkilimi = "Hayır" Then
                    result.durum = "Yetkisiz"
                    result.hatastr = "Bu IP adresi ile web servisine bağlanmaya yetkiniz yoktur."
                    result.etkilenen = 2
                End If
            End If 'sirket.ipdikkat

            Return result

        End If 'kullanıcı adi sifre dogru!

    End Function



    'ÇALIŞTIR --------------
    Public Function calistir(ByVal wskullaniciad As String, ByVal wssifre As String, _
    ByVal servicecode As String, ByVal xmlparams As String) As String


        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci

        Dim donecek As String
        Dim generic_erisim As New CLASSGENERIC_ERISIM

        'IP ADRESİ KULLANICI ADI VE ŞİFRE KONTROL
        Dim result As New CLADBOPRESULT
        result = yetkilimi(wskullaniciad, wssifre)
        If result.durum = "Yetkisiz" Then
            donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
            " ErrorMessage=" + Chr(34) + result.hatastr + Chr(34) + _
            " ErrorCode=" + Chr(34) + CStr(result.etkilenen) + Chr(34) + "/>"
            Return donecek
        End If

        'SERVİS KODU KONTROL
        If IsNumeric(servicecode) = False Then
            donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
            " ErrorMessage=" + Chr(34) + "Servis kodu rakam olmalıdır" + Chr(34) + _
            " ErrorCode=" + Chr(34) + "3" + Chr(34) + "/>"
            Return donecek
        End If
        Dim genericservis As New CLASSGENERICSERVIS
        genericservis = bultek(servicecode)
        If genericservis.pkey = 0 Then
            donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
            " ErrorMessage=" + Chr(34) + "Servis Kodu Geçersiz. Bu kodla bir servis tanımlanmamış." + Chr(34) + _
            " ErrorCode=" + Chr(34) + "3" + Chr(34) + "/>"
            Return donecek
        End If


        'XML DOĞRU MU KONTROL 
        Dim XmlDoc As XmlDocument = New XmlDocument
        Try
            XmlDoc.Load(New StringReader(xmlparams))
        Catch ex As Exception
            donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
           " ErrorMessage=" + Chr(34) + "GÖNDERDİĞİNİZ XML HATALI Detay: " + ex.Message + Chr(34) + _
           " ErrorCode=" + Chr(34) + "4" + Chr(34) + "/>"
            Return donecek
        End Try

        'INPUT PARAMETRE KONTROL 
        Dim ht As New Hashtable
        Dim htvalue As New Hashtable
        Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
        Dim inputparametreler As New List(Of CLASSGENERICSERVISINPUT)
        Dim kactaneinput As Integer
        Dim uyusan_count As Integer = 0
        Dim toplam_count As Integer = 0
        inputparametreler = genericservisinput_erisim.doldurilgili(servicecode)
        kactaneinput = inputparametreler.Count
        If kactaneinput > 0 Then
            For Each Element As XmlElement In XmlDoc.SelectNodes("//*")
                For Each Attribute As XmlAttribute In Element.Attributes
                    For Each inputparam As CLASSGENERICSERVISINPUT In inputparametreler
                        If Attribute.Name = inputparam.paramad Then
                            uyusan_count = uyusan_count + 1
                            ht.Add(inputparam.pkey, Attribute.Name)
                            htvalue.Add(inputparam.pkey, Attribute.Value)
                        End If
                    Next
                    toplam_count = toplam_count + 1
                Next
            Next
        End If

        If kactaneinput <> toplam_count Or kactaneinput <> uyusan_count Then
            Dim uyusmayanlar As String = ""
            'uyuşmayanlari bul
            For Each inputparam As CLASSGENERICSERVISINPUT In inputparametreler
                If ht.ContainsKey(inputparam.pkey) = False Then
                    uyusmayanlar = uyusmayanlar + inputparam.paramad + ","
                End If
            Next
            Dim msg As String
            msg = "Bu servis " + CStr(kactaneinput) + " input parametresi istiyor. Siz toplam " + _
            CStr(toplam_count) + " parametre gönderdiniz ve bu parametreler içinde uyuşan " + _
            CStr(uyusan_count) + " adet parametre vardır. Uyuşmayanlar: " + uyusmayanlar
            donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
            " ErrorMessage=" + Chr(34) + msg + Chr(34) + _
            " ErrorCode=" + Chr(34) + "5" + Chr(34) + "/>"
            Return donecek
        End If

        Dim outputparametreler As New List(Of CLASSGENERICSERVISOUTPUT)
        Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
        outputparametreler = genericservisoutput_erisim.doldurilgili(genericservis.pkey)

        Dim tekelement As String
        Dim enbas, enson As String
        Dim icbas, icson As String

        enbas = "<root>"
        enson = "</root>"
        icbas = "<dataelement>"
        icson = "</dataelement>"

        Dim veritabanikolondetay As New CLASSVERITABANIKOLONDETAY
        Dim sqlvertabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = genericservis.sqlstrrun
        komut = New SqlCommand(sqlstr, db_baglanti)


        Dim deger
        Dim validationresult As New CLADBOPRESULT

        For Each inputparam As CLASSGENERICSERVISINPUT In inputparametreler
            Dim ad As String
            ad = "@" + inputparam.paramad
            komut.Parameters.Add(ad, generic_erisim.sqldbtypebul(inputparam.datatype))
            deger = bul_xmldeger(htvalue, inputparam.pkey)
            validationresult = validate_deger(deger, inputparam.pkey)
            If validationresult.durum = "Hayır" Then
                donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
                " ErrorMessage=" + Chr(34) + "GÖNDERDİĞİNİZ DEĞERLAR HATALI Detay: " + _
                validationresult.hatastr + Chr(34) + _
                " ErrorCode=" + Chr(34) + "6" + Chr(34) + "/>"
                db_baglanti.Close()
                db_baglanti.Dispose()
                Return donecek
            End If
            If validationresult.durum = "Evet" Then
                If inputparam.datatype <> "date" And inputparam.datatype <> "datetime" Then
                    komut.Parameters(ad).Value = deger
                Else
                    komut.Parameters(ad).Value = DateTime.Parse(deger)
                End If
            End If
        Next

        'LİSTELEME --------------------------------------------------------
        If genericservis.tip = "listeleme" Then
            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()
                        For Each itemoutput As CLASSGENERICSERVISOUTPUT In outputparametreler
                            If Not veri.Item(itemoutput.outputparamname) Is System.DBNull.Value Then
                                donecek = donecek + "<" + itemoutput.outputparamname + ">" + _
                                SecurityElement.Escape(veri.Item(itemoutput.outputparamname)) + _
                                "</" + itemoutput.outputparamname + ">"
                            End If
                        Next
                        tekelement = tekelement + icbas + donecek + icson
                        donecek = ""
                    End While
                End Using

            Catch ex As Exception
                donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
                " ErrorMessage=" + Chr(34) + "SQL DÜZGÜN ÇALIŞTIRILAMADI: " + ex.Message + Chr(34) + _
                " ErrorCode=" + Chr(34) + "7" + Chr(34) + "/>"
                Return donecek
            Finally
                db_baglanti.Close()
                db_baglanti.Dispose()
            End Try

            donecek = enbas + tekelement + enson
            Return donecek

        End If

        'INSERT UPDATE DELETE ------------------------------------------------
        If genericservis.tip = "insert" Or genericservis.tip = "update" Or genericservis.tip = "delete" Then
            Try
                komut.ExecuteNonQuery()
                donecek = "<root EffectedRowCount=" + Chr(34) + "1" + Chr(34) + "/>"
                Return donecek
            Catch ex As Exception
                donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
               " ErrorMessage=" + Chr(34) + "SQL DÜZGÜN ÇALIŞTIRILAMADI: " + ex.Message + Chr(34) + _
               " ErrorCode=" + Chr(34) + "7" + Chr(34) + "/>"
                Return donecek
            Finally
                db_baglanti.Close()
                db_baglanti.Dispose()
            End Try
        End If


        'RAKAM DÖDÜRME
        If genericservis.tip = "rakamdondurme" Then
            Dim donecekrakam
            Try
                donecekrakam = komut.ExecuteScalar()
                donecek = "<root Value=" + Chr(34) + CStr(donecekrakam) + Chr(34) + "/>"
                Return donecek
            Catch ex As Exception
                donecek = "<root ResultCode=" + Chr(34) + "0" + Chr(34) + _
               " ErrorMessage=" + Chr(34) + "SQL DÜZGÜN ÇALIŞTIRILAMADI: " + ex.Message + Chr(34) + _
               " ErrorCode=" + Chr(34) + "7" + Chr(34) + "/>"
                Return donecek
            Finally
                db_baglanti.Close()
                db_baglanti.Dispose()
            End Try
        End If






        db_baglanti.Close()
        db_baglanti.Dispose()

    End Function



    Function bul_xmldeger(ByVal htvalue As Hashtable, ByVal inputparampkey As String) As String

        Dim donecek As String
        Dim Item As DictionaryEntry
        For Each Item In htvalue

            If Item.Key = inputparampkey Then
                donecek = Item.Value
            End If
        Next

        Return donecek

    End Function


    Function validate_deger(ByVal deger As String, ByVal inputparampkey As String) As CLADBOPRESULT

        Dim d As Date
        Dim result As New CLADBOPRESULT
        result.durum = "Evet"
        result.etkilenen = 1
        result.hatastr = ""


        Dim dogrumu As String = "Evet"
        Dim keyvaluepair As New CLASSKEYVALUEPAIR

        Dim hatastr As String
        Dim datatype As String
        Dim genericservisinput As New CLASSGENERICSERVISINPUT
        Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM

        genericservisinput = genericservisinput_erisim.bultek(inputparampkey)
        datatype = genericservisinput.datatype


        If datatype = "bit" Then
            If deger <> "0" And deger <> "1" Then
                result.durum = "Hayır"
                result.etkilenen = 0
                result.hatastr = "Bit veri tipine sadece 0 yada 1 değerleri gönderebilirsiniz. Parametre Adı: " + genericservisinput.paramad
            End If
        End If


        If datatype = "numeric" Or datatype = "int" Or datatype = "float" Or _
        datatype = "double" Or datatype = "decimal" Or datatype = "real" Then
            If IsNumeric(deger) = False Then
                result.durum = "Hayır"
                result.etkilenen = 0
                result.hatastr = "Rakamsal değer olması gereken parametreye rakamsal olmayan bir değer girdiniz. Parametre Adı: " + genericservisinput.paramad
            End If
        End If


        If datatype = "datetime" Or datatype = "date" Then

            Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
            Dim ci As CultureInfo = New CultureInfo("de-DE")
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture = ci
            Dim baslangictarih, kayittarih As Date

            Try
                d = deger
            Catch
                result.durum = "Hayır"
                result.etkilenen = 0
                result.hatastr = "Gönderdiğiniz tarih hatalı Format:dd/MM/yyyy olmalıdır. Parametre Adı: " + genericservisinput.paramad
            End Try

        End If

        Return result

    End Function

End Class


