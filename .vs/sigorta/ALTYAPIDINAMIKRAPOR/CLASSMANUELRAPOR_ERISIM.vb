Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSMANUELRAPOR_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim manuelrapor As New CLASSMANUELRAPOR
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal manuelrapor As CLASSMANUELRAPOR) As CLADBOPRESULT

        Dim kaydedilenpkey As Integer

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("ad", manuelrapor.ad)

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

            sqlstr = "insert into manuelrapor values (@pkey," + _
            "@ad,@aciklama,@aktifmi,@remindersettingpkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            kaydedilenpkey = pkeybul()
            param1.Value = kaydedilenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If manuelrapor.ad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = manuelrapor.ad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aciklama", SqlDbType.Text)
            param3.Direction = ParameterDirection.Input
            If manuelrapor.aciklama = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = manuelrapor.aciklama
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If manuelrapor.aktifmi = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = manuelrapor.aktifmi
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If manuelrapor.remindersettingpkey = 0 Then
                param5.Value = 0
            Else
                param5.Value = manuelrapor.remindersettingpkey
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
        sqlstr = "select max(pkey) from manuelrapor"
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
    Function Duzenle(ByVal manuelrapor As CLASSMANUELRAPOR) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update manuelrapor set " + _
        "ad=@ad," + _
        "aciklama=@aciklama," + _
        "aktifmi=@aktifmi," + _
        "remindersettingpkey=@remindersettingpkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelrapor.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If manuelrapor.ad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = manuelrapor.ad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aciklama", SqlDbType.Text)
        param3.Direction = ParameterDirection.Input
        If manuelrapor.aciklama = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = manuelrapor.aciklama
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If manuelrapor.aktifmi = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = manuelrapor.aktifmi
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If manuelrapor.remindersettingpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = manuelrapor.remindersettingpkey
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
    Function bultek(ByVal pkey As String) As CLASSMANUELRAPOR

        Dim komut As New SqlCommand
        Dim donecekmanuelrapor As New CLASSMANUELRAPOR()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelrapor where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelrapor.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekmanuelrapor.ad = veri.Item("ad")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekmanuelrapor.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekmanuelrapor.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekmanuelrapor.remindersettingpkey = veri.Item("remindersettingpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekmanuelrapor

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim manuelraporparamatre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM
        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

        Dim varmi_parametre As String = manuelraporparamatre_erisim.raporvarmi(pkey)
        Dim varmi_kullanici As String = manuelraporkullanici_erisim.raporvarmi(pkey)

        If varmi_parametre = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında parametreler tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_kullanici = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında kullanıcılar tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from manuelrapor where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSMANUELRAPOR)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmanuelrapor As New CLASSMANUELRAPOR
        Dim manuelraporler As New List(Of CLASSMANUELRAPOR)
        komut.Connection = db_baglanti
        sqlstr = "select * from manuelrapor"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelrapor.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekmanuelrapor.ad = veri.Item("ad")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekmanuelrapor.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekmanuelrapor.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                    donecekmanuelrapor.remindersettingpkey = veri.Item("remindersettingpkey")
                End If

                manuelraporler.Add(New CLASSMANUELRAPOR(donecekmanuelrapor.pkey, _
                donecekmanuelrapor.ad, donecekmanuelrapor.aciklama, donecekmanuelrapor.aktifmi, donecekmanuelrapor.remindersettingpkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return manuelraporler

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
        "<th>Ad</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Aktif mi?</th>" + _
        "<th>Zamanlama</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from manuelrapor"
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, ad, aciklama, aktifmi, remindersettingpkey As String

        Dim remindersetting As New CLASSREMINDERSETTING
        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM

        Dim kullanilacakbas As String
        Dim kullanilacakson As String
        Dim aktifbas, aktifson, pasifbas, pasifson As String
        aktifbas = "<span style='font-weight:bold;color:green;'>"
        aktifson = "</span>"
        pasifbas = "<span style='font-weight:bold;color:red;'>"
        pasifson = "</span>"

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                    End If
                    If aktifmi = "Evet" Then
                        kullanilacakbas = aktifbas
                        kullanilacakson = aktifson

                    Else
                        kullanilacakbas = pasifbas
                        kullanilacakson = pasifson
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "manuelraporpopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("ad") Is System.DBNull.Value Then
                        ad = veri.Item("ad")
                        kol2 = "<td>" + kullanilacakbas + ad + kullanilacakson + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol3 = "<td>" + kullanilacakbas + aciklama + kullanilacakson + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        kol4 = "<td>" + kullanilacakbas + aktifmi + kullanilacakson + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("remindersettingpkey") Is System.DBNull.Value Then
                        remindersettingpkey = veri.Item("remindersettingpkey")
                        remindersetting = remindersetting_erisim.bultek(remindersettingpkey)
                        kol5 = "<td>" + kullanilacakbas + remindersetting.reminder_name + kullanilacakson + "</td></tr>"
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

        sqlstr = "select * from manuelrapor where " + tablecol + "=@kriter"

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

    Public Function calistir()

        Dim result As New CLADBOPRESULT

        Dim fizikseldosyaadexcel As String = "-"
        Dim fizikseldosyaadword As String = "-"
        Dim fizikseldosyaadpdf As String = "-"

        Dim donecek As String
        Dim rapor As New CLASSRAPOR
        Dim ozelrapor_erisim As New CLASSOZELRAPOR_ERISIM
        Dim rapor_erisim As New CLASSRAPOR_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim ozelraporlog As New CLASSOZELRAPORLOG
        Dim ozelraporlog_erisim As New CLASSOZELRAPORLOG_ERISIM

        Dim manuelraporkullanicilar As New List(Of CLASSMANUELRAPORKULLANICI)
        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

        Dim manuelraporparametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
        Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM

        Dim remindersetting As New CLASSREMINDERSETTING
        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
        Dim manuelraporlar As New List(Of CLASSMANUELRAPOR)
        manuelraporlar = manuelrapor_erisim.doldur

        For Each item As CLASSMANUELRAPOR In manuelraporlar

            remindersetting = remindersetting_erisim.bultek(item.remindersettingpkey)

            'EĞER ZAMANLAMADA BU RAPOR GERÇEKTEN ÇALIŞTIRILMALIYSA
            If remindersetting_erisim.dogrulama(remindersetting) = "Evet" Then

                If item.aktifmi = "Evet" Then

                    'RAPORU ÇALIŞTIR-------------------------------
                    manuelraporparametreler = manuelraporparametre_erisim.doldurilgili(item.pkey)
                    For Each itemparametre As CLASSMANUELRAPORPARAMETRE In manuelraporparametreler
                        HttpContext.Current.Session(itemparametre.sad) = itemparametre.sdeger
                    Next
                    rapor = ozelrapor_erisim.temelrapor

                    Try
                        fizikseldosyaadexcel = rapor_erisim.yazdirexcel("servis", rapor)
                        fizikseldosyaadword = rapor_erisim.yazdirword("servis", rapor)
                        fizikseldosyaadpdf = rapor_erisim.yazdirpdf("servis", rapor)
                    Catch ex As Exception
                    End Try

                    'RAPORU LOGLA-------------------------------
                    ozelraporlog.tarih = DateTime.Now
                    ozelraporlog.raporad = item.ad
                    ozelraporlog.yontem = "servis"
                    ozelraporlog.fizikseldosyaadexcel = fizikseldosyaadexcel
                    ozelraporlog.fizikseldosyaadword = fizikseldosyaadword
                    ozelraporlog.fizikseldosyaadpdf = fizikseldosyaadpdf
                    ozelraporlog.manuelraporpkey = item.pkey
                    ozelraporlog_erisim.Ekle(ozelraporlog)


                    'E-POSTA GÖNDER-------------------------------
                    manuelraporkullanicilar = manuelraporkullanici_erisim.doldurilgili(item.pkey)
                    For Each itemkullanici As CLASSMANUELRAPORKULLANICI In manuelraporkullanicilar

                        Dim attachmentfile_path As String
                        Dim email_erisim As New CLASSEMAIL_ERISIM
                        Dim emailayar As New CLASSEMAILAYAR
                        Dim emailayar_Erisim As New CLASSEMAILAYAR_ERISIM
                        emailayar = emailayar_Erisim.bul(1)
                        Dim email As New CLASSEMAIL

                        email.body = "Değerli Üyemiz," + "<br/><br/>"
                        email.kimden = emailayar.username
                        kullanici = kullanici_erisim.bultek(itemkullanici.kullanicipkey)
                        email.kime = kullanici.eposta
                        email.subject = item.ad
                        email.body = item.aciklama

                        If itemkullanici.epostaexcel = "Evet" Then
                            attachmentfile_path = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + fizikseldosyaadexcel
                            email.attachmentfile = attachmentfile_path
                            result = email_erisim.gonder(email)
                        End If
                        If itemkullanici.epostaword = "Evet" Then
                            attachmentfile_path = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + fizikseldosyaadword
                            email.attachmentfile = attachmentfile_path
                            result = email_erisim.gonder(email)
                        End If
                        If itemkullanici.epostapdf = "Evet" Then
                            attachmentfile_path = HttpContext.Current.Request.PhysicalApplicationPath + fizikseldosyaadpdf
                            email.attachmentfile = attachmentfile_path
                            result = email_erisim.gonder(email)
                        End If
                    Next

                End If 'aktif rapor

            End If 'reminder

        Next

    End Function


    Public Function testcalistir(ByVal manuelraporpkey As Integer) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        Dim fizikseldosyaadexcel As String = "-"
        Dim fizikseldosyaadword As String = "-"
        Dim fizikseldosyaadpdf As String = "-"


        Dim donecek As String
        Dim rapor As New CLASSRAPOR
        Dim ozelrapor_erisim As New CLASSOZELRAPOR_ERISIM
        Dim rapor_erisim As New CLASSRAPOR_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim ozelraporlog As New CLASSOZELRAPORLOG
        Dim ozelraporlog_erisim As New CLASSOZELRAPORLOG_ERISIM

        Dim manuelraporkullanicilar As New List(Of CLASSMANUELRAPORKULLANICI)
        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

        Dim manuelraporparametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
        Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM

        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
        Dim manuelrapor As New CLASSMANUELRAPOR
        manuelrapor = manuelrapor_erisim.bultek(manuelraporpkey)


        'RAPORU ÇALIŞTIR-------------------------------
        manuelraporparametreler = manuelraporparametre_erisim.doldurilgili(manuelraporpkey)
        For Each itemparametre As CLASSMANUELRAPORPARAMETRE In manuelraporparametreler
            HttpContext.Current.Session(itemparametre.sad) = itemparametre.sdeger
        Next

        Try
            rapor = ozelrapor_erisim.temelrapor
        Catch ex As Exception
            result.durum = "Kaydedilmedi"
            result.hatastr = ex.Message
            result.etkilenen = 0
            Return result
        End Try

        Try
            fizikseldosyaadexcel = rapor_erisim.yazdirexcel("servis", rapor)
            fizikseldosyaadword = rapor_erisim.yazdirword("servis", rapor)
            fizikseldosyaadpdf = rapor_erisim.yazdirpdf("servis", rapor)
        Catch ex As Exception
            result.durum = "Kaydedilmedi"
            result.hatastr = ex.Message
            result.etkilenen = 0
            Return result
        End Try

        'RAPORU LOGLA-------------------------------
        ozelraporlog.tarih = DateTime.Now
        ozelraporlog.raporad = manuelrapor.ad
        ozelraporlog.yontem = "test"
        ozelraporlog.fizikseldosyaadexcel = fizikseldosyaadexcel
        ozelraporlog.fizikseldosyaadword = fizikseldosyaadword
        ozelraporlog.fizikseldosyaadpdf = fizikseldosyaadpdf
        ozelraporlog.manuelraporpkey = manuelraporpkey
        ozelraporlog_erisim.Ekle(ozelraporlog)

        'E-POSTA GÖNDER-------------------------------
        manuelraporkullanicilar = manuelraporkullanici_erisim.doldurilgili(manuelraporpkey)
        For Each itemkullanici As CLASSMANUELRAPORKULLANICI In manuelraporkullanicilar

            Dim attachmentfile_path As String
            Dim email_erisim As New CLASSEMAIL_ERISIM
            Dim emailayar As New CLASSEMAILAYAR
            Dim emailayar_Erisim As New CLASSEMAILAYAR_ERISIM
            emailayar = emailayar_Erisim.bul(1)
            Dim email As New CLASSEMAIL

            email.body = "Değerli Üyemiz," + "<br/><br/>"
            email.kimden = emailayar.username
            kullanici = kullanici_erisim.bultek(itemkullanici.kullanicipkey)
            email.kime = kullanici.eposta
            email.subject = manuelrapor.ad
            email.body = manuelrapor.aciklama

            If itemkullanici.epostaexcel = "Evet" Then
                attachmentfile_path = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + fizikseldosyaadexcel
                email.attachmentfile = attachmentfile_path
                result = email_erisim.gonder(email)
            End If
            If itemkullanici.epostaword = "Evet" Then
                attachmentfile_path = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + fizikseldosyaadword
                email.attachmentfile = attachmentfile_path
                result = email_erisim.gonder(email)
            End If
            If itemkullanici.epostapdf = "Evet" Then
                attachmentfile_path = HttpContext.Current.Request.PhysicalApplicationPath + fizikseldosyaadpdf
                email.attachmentfile = attachmentfile_path
                result = email_erisim.gonder(email)
            End If
        Next

        result.durum = "Kaydedildi"
        result.hatastr = ""
        result.etkilenen = 1

        Return result

    End Function



    Public Function kopyasiniolustur(ByVal manuelraporpkey As Integer) As String

        Dim eklenenmanuelraporpkey As Integer
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM

        Dim donecek As String
        Dim result As New CLADBOPRESULT
        Dim omanuelrapor As New CLASSMANUELRAPOR
        omanuelrapor = bultek(manuelraporpkey)
        omanuelrapor.ad = "-Kopyası- " + omanuelrapor.ad

        result = Ekle(omanuelrapor)
        If result.durum = "Kaydedildi" Then
            eklenenmanuelraporpkey = result.etkilenen
            donecek = "Rapor temel bilgisi kaydedildi."
        End If


        Dim e_parametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
        Dim e_kullanicilar As New List(Of CLASSMANUELRAPORKULLANICI)

        Dim manuelraporparametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
        Dim manuelraporkullanicilar As New List(Of CLASSMANUELRAPORKULLANICI)
       
        Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM
        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

     
        manuelraporparametreler = manuelraporparametre_erisim.doldurilgili(manuelraporpkey)
        manuelraporkullanicilar = manuelraporkullanici_erisim.doldurilgili(manuelraporpkey)

        For Each Item As CLASSMANUELRAPORPARAMETRE In manuelraporparametreler
            Item.manuelraporpkey = eklenenmanuelraporpkey
            result = manuelraporparametre_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.sad + " Parametreler eklendi." + "<br/>"
            End If
        Next

        For Each Item As CLASSMANUELRAPORKULLANICI In manuelraporkullanicilar
            Item.manuelraporpkey = eklenenmanuelraporpkey
            result = manuelraporkullanici_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + CStr(Item.kullanicipkey) + " Kullanıcılar eklendi." + "<br/>"
            End If
        Next

        Return donecek


    End Function


    Function zamanlamavarmi(ByVal remindersettingpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelrapor where remindersettingpkey=@remindersettingpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@remindersettingpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = remindersettingpkey
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


