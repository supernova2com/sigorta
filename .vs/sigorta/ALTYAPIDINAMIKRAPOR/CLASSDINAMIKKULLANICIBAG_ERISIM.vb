Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSDINAMIKKULLANICIBAG_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dinamikkullanicibag As CLASSDINAMIKKULLANICIBAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(dinamikkullanicibag.raporpkey, dinamikkullanicibag.kullanicipkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kullanıcı halihazırda bu rapora erişmeye yetkili."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into dinamikkullanicibag values (@pkey," + _
            "@raporpkey,@kullanicipkey,@otogonder,@zamanlamapkey," + _
            "@epostagitsinmi,@entegredosyagitsinmi)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If dinamikkullanicibag.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = dinamikkullanicibag.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If dinamikkullanicibag.kullanicipkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = dinamikkullanicibag.kullanicipkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@otogonder", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If dinamikkullanicibag.otogonder = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = dinamikkullanicibag.otogonder
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@zamanlamapkey", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If dinamikkullanicibag.zamanlamapkey = 0 Then
                param5.Value = 0
            Else
                param5.Value = dinamikkullanicibag.zamanlamapkey
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@epostagitsinmi", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If dinamikkullanicibag.epostagitsinmi = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = dinamikkullanicibag.epostagitsinmi
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@entegredosyagitsinmi", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If dinamikkullanicibag.entegredosyagitsinmi = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = dinamikkullanicibag.entegredosyagitsinmi
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
        sqlstr = "select max(pkey) from dinamikkullanicibag"
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
    Function Duzenle(ByVal dinamikkullanicibag As CLASSDINAMIKKULLANICIBAG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update dinamikkullanicibag set " + _
        "raporpkey=@raporpkey," + _
        "kullanicipkey=@kullanicipkey," + _
        "otogonder=@otogonder," + _
        "zamanlamapkey=@zamanlamapkey," + _
        "epostagitsinmi=@epostagitsinmi," + _
        "entegredosyagitsinmi=@entegredosyagitsinmi" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dinamikkullanicibag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dinamikkullanicibag.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = dinamikkullanicibag.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If dinamikkullanicibag.kullanicipkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = dinamikkullanicibag.kullanicipkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@otogonder", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dinamikkullanicibag.otogonder = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dinamikkullanicibag.otogonder
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@zamanlamapkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If dinamikkullanicibag.zamanlamapkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = dinamikkullanicibag.zamanlamapkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@epostagitsinmi", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If dinamikkullanicibag.epostagitsinmi = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = dinamikkullanicibag.epostagitsinmi
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@entegredosyagitsinmi", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If dinamikkullanicibag.entegredosyagitsinmi = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = dinamikkullanicibag.entegredosyagitsinmi
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
    Function bultek(ByVal pkey As String) As CLASSDINAMIKKULLANICIBAG

        Dim komut As New SqlCommand
        Dim donecekdinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikkullanicibag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("otogonder") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.otogonder = veri.Item("otogonder")
                End If

                If Not veri.Item("zamanlamapkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.zamanlamapkey = veri.Item("zamanlamapkey")
                End If

                If Not veri.Item("epostagitsinmi") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.epostagitsinmi = veri.Item("epostagitsinmi")
                End If

                If Not veri.Item("entegredosyagitsinmi") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.entegredosyagitsinmi = veri.Item("entegredosyagitsinmi")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdinamikkullanicibag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikkullanicibag where pkey=@pkey"
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


    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikkullanicibag where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
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
    Public Function doldur() As List(Of CLASSDINAMIKKULLANICIBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
        Dim dinamikkullanicibagler As New List(Of CLASSDINAMIKKULLANICIBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikkullanicibag"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("otogonder") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.otogonder = veri.Item("otogonder")
                End If

                If Not veri.Item("zamanlamapkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.zamanlamapkey = veri.Item("zamanlamapkey")
                End If

                If Not veri.Item("epostagitsinmi") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.epostagitsinmi = veri.Item("epostagitsinmi")
                End If

                If Not veri.Item("entegredosyagitsinmi") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.entegredosyagitsinmi = veri.Item("entegredosyagitsinmi")
                End If

                dinamikkullanicibagler.Add(New CLASSDINAMIKKULLANICIBAG(donecekdinamikkullanicibag.pkey, _
                donecekdinamikkullanicibag.raporpkey, donecekdinamikkullanicibag.kullanicipkey, _
                donecekdinamikkullanicibag.otogonder, donecekdinamikkullanicibag.zamanlamapkey, _
                donecekdinamikkullanicibag.epostagitsinmi, donecekdinamikkullanicibag.entegredosyagitsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikkullanicibagler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As String) As List(Of CLASSDINAMIKKULLANICIBAG)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
        Dim dinamikkullanicibagler As New List(Of CLASSDINAMIKKULLANICIBAG)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikkullanicibag where raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("otogonder") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.otogonder = veri.Item("otogonder")
                End If

                If Not veri.Item("zamanlamapkey") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.zamanlamapkey = veri.Item("zamanlamapkey")
                End If

                If Not veri.Item("epostagitsinmi") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.epostagitsinmi = veri.Item("epostagitsinmi")
                End If

                If Not veri.Item("entegredosyagitsinmi") Is System.DBNull.Value Then
                    donecekdinamikkullanicibag.entegredosyagitsinmi = veri.Item("entegredosyagitsinmi")
                End If

                dinamikkullanicibagler.Add(New CLASSDINAMIKKULLANICIBAG(donecekdinamikkullanicibag.pkey, _
                donecekdinamikkullanicibag.raporpkey, donecekdinamikkullanicibag.kullanicipkey, _
                donecekdinamikkullanicibag.otogonder, donecekdinamikkullanicibag.zamanlamapkey, _
                donecekdinamikkullanicibag.epostagitsinmi, donecekdinamikkullanicibag.entegredosyagitsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikkullanicibagler

    End Function

  

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8 As String
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
        "<th>Anahtar</th>" + _
        "<th>Rapor</th>" + _
        "<th>Kullanıcı</th>" + _
        "<th>Zamanlama</th>" + _
        "<th>Oto Gönderme Açık mı?</th>" + _
        "<th>Otomatik Gönderme Seçenekleri</th>" + _
        "<th>Çalıştır</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from dinamikkullanicibag where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey, kullanicipkey As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim dinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM

        Dim zamanlamapkey, eposta, otogondermestr, otogonder As String
        Dim ajaxlinksil, dugmesil As String
        Dim ajaxlinkcalistir, dugmecalistir As String
        Dim remindersettingpkey As String

        Dim remindersetting As New CLASSREMINDERSETTING
        Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM


        Dim epostagitsinmi, entegredosyagitsinmi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then

                        pkey = CStr(veri.Item("pkey"))
                        link = "dinamikraporpopup.aspx?pkey=" + CStr(raporpkey) + _
                        "&op=duzenle" + _
                        "&dinamikraporkullanicibagop=duzenle" + _
                        "&dinamikraporkullanicibagpkey=" + CStr(pkey)

                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    End If

                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                        kol3 = "<td>" + kullanici.adsoyad + "</td>"
                    End If


                    If Not veri.Item("zamanlamapkey") Is System.DBNull.Value Then
                        zamanlamapkey = veri.Item("zamanlamapkey")
                        dinamikraporzamanlama = dinamikraporzamanlama_erisim.bultek(zamanlamapkey)
                        kol4 = "<td>" + dinamikraporzamanlama.zamanlamaad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("otogonder") Is System.DBNull.Value Then
                        otogonder = veri.Item("otogonder")
                        kol5 = "<td>" + otogonder + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    '--------------------------------------------------------------
                    If Not veri.Item("epostagitsinmi") Is System.DBNull.Value Then
                        epostagitsinmi = veri.Item("epostagitsinmi")
                    Else
                        epostagitsinmi = "-"
                    End If
                    If Not veri.Item("entegredosyagitsinmi") Is System.DBNull.Value Then
                        entegredosyagitsinmi = veri.Item("entegredosyagitsinmi")
                    Else
                        entegredosyagitsinmi = "-"
                    End If
                    otogondermestr = "<td>" + "<b>E-Posta:</b>" + epostagitsinmi + "<br/>" + _
                    "<b>Entegre Dosya:</b>" + entegredosyagitsinmi + "</td>"
                    kol6 = otogondermestr

                    '-- ÇALIŞTIRMA DÜĞMESİ --
                    ajaxlinkcalistir = "dinamikmanuelcalistir.aspx?raporpkey=" + CStr(raporpkey)
                    dugmecalistir = "<a href='" + ajaxlinkcalistir + "'><span class='button'>Çalıştır</span>" + "</a>"

                    kol7 = "<td>" + dugmecalistir + "</td>"

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "dinamikkullanicibagsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='dinamikkullanicisilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol8 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8

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
    Function ciftkayitkontrol(ByVal raporpkey As String, ByVal kullanicipkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikkullanicibag where" + _
        " raporpkey=@raporpkey and kullanicipkey=@kullanicipkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullanicipkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function



    Function raporvarmi(ByVal raporpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikkullanicibag where raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function



    Function yetkilimi(ByVal raporpkey As String, ByVal kullanicipkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecek As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikkullanicibag where raporpkey=@raporpkey and " + _
        "kullanicipkey=@kullanicipkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullanicipkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                donecek = "Evet"
            End While
        End Using

        db_baglanti.Close()

        Return donecek

    End Function



    Function zamanlamavarmi(ByVal raporpkey As String, ByVal zamanlamapkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikkullanicibag where raporpkey=@raporpkey and " + _
        "zamanlamapkey=@zamanlamapkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@zamanlamapkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = zamanlamapkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function kullanicivarmi(ByVal kullanicipkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikkullanicibag where kullanicipkey=@kullanicipkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
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

