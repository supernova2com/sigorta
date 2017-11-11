Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Globalization.CultureInfo
Imports System.Globalization

Public Class CLASSDINAMIKRAPOR_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dinamikrapor As New CLASSDINAMIKRAPOR
    Dim resultset As New CLADBOPRESULT

    Dim dinamikraporlog_erisim As New CLASSDINAMIKRAPORLOG_ERISIM
    Dim dinamikraporlog As New CLASSDINAMIKRAPORLOG


    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dinamikrapor As CLASSDINAMIKRAPOR) As CLADBOPRESULT

        Dim kaydedilenpkey As Integer

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("raporad", dinamikrapor.raporad)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu rapor ismiyle ayni rapor halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into dinamikrapor values (@pkey," + _
            "@raporad,@aciklama,@raportip,@sqlstr,@arabirimolsunmu," + _
            "@toplamlargosterilsinmi)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            kaydedilenpkey = pkeybul()
            param1.Value = kaydedilenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If dinamikrapor.raporad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = dinamikrapor.raporad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If dinamikrapor.aciklama = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = dinamikrapor.aciklama
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@raportip", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If dinamikrapor.raportip = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = dinamikrapor.raportip
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@sqlstr", SqlDbType.Text)
            param5.Direction = ParameterDirection.Input
            If dinamikrapor.sqlstr = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = dinamikrapor.sqlstr
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@arabirimolsunmu", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If dinamikrapor.arabirimolsunmu = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = dinamikrapor.arabirimolsunmu
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@toplamlargosterilsinmi", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If dinamikrapor.toplamlargosterilsinmi = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = dinamikrapor.toplamlargosterilsinmi
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
        sqlstr = "select max(pkey) from dinamikrapor"
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
    Function Duzenle(ByVal dinamikrapor As CLASSDINAMIKRAPOR) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update dinamikrapor set " + _
        "raporad=@raporad," + _
        "aciklama=@aciklama," + _
        "raportip=@raportip," + _
        "sqlstr=@sqlstr," + _
        "arabirimolsunmu=@arabirimolsunmu," + _
        "toplamlargosterilsinmi=@toplamlargosterilsinmi" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dinamikrapor.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If dinamikrapor.raporad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = dinamikrapor.raporad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aciklama", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If dinamikrapor.aciklama = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dinamikrapor.aciklama
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@raportip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dinamikrapor.raportip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dinamikrapor.raportip
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@sqlstr", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If dinamikrapor.sqlstr = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = dinamikrapor.sqlstr
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@arabirimolsunmu", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If dinamikrapor.arabirimolsunmu = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = dinamikrapor.arabirimolsunmu
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@toplamlargosterilsinmi", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If dinamikrapor.toplamlargosterilsinmi = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = dinamikrapor.toplamlargosterilsinmi
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
    Function bultek(ByVal pkey As String) As CLASSDINAMIKRAPOR

        Dim komut As New SqlCommand
        Dim donecekdinamikrapor As New CLASSDINAMIKRAPOR()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikrapor where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikrapor.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporad") Is System.DBNull.Value Then
                    donecekdinamikrapor.raporad = veri.Item("raporad")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekdinamikrapor.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("raportip") Is System.DBNull.Value Then
                    donecekdinamikrapor.raportip = veri.Item("raportip")
                End If

                If Not veri.Item("sqlstr") Is System.DBNull.Value Then
                    donecekdinamikrapor.sqlstr = veri.Item("sqlstr")
                End If

                If Not veri.Item("arabirimolsunmu") Is System.DBNull.Value Then
                    donecekdinamikrapor.arabirimolsunmu = veri.Item("arabirimolsunmu")
                End If

                If Not veri.Item("toplamlargosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikrapor.toplamlargosterilsinmi = veri.Item("toplamlargosterilsinmi")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdinamikrapor

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM

        Dim varmi_kullanilacaktablo As String = kullanilacaktablo_erisim.raporvarmi(pkey)
        Dim varmi_gosterilecekfield As String = gosterilecekfield_erisim.raporvarmi(pkey)
        Dim varmi_kosulfield As String = kosulfield_erisim.raporvarmi(pkey)
        Dim varmi_siralamafield As String = siralamafield_erisim.raporvarmi(pkey)
        Dim varmi_dinamikkullanicibag As String = dinamikkullanicibag_erisim.raporvarmi(pkey)

        If varmi_kullanilacaktablo = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında kullanılacak tablolar tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_gosterilecekfield = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında gösterilecek alanlar tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_kosulfield = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında koşullar tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_siralamafield = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında sıralama alanları tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_dinamikkullanicibag = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporun altında yetkili kullanıcılar tanımlanmış. " + _
            "Bu sebepten bu raporu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikrapor where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSDINAMIKRAPOR)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikraporler As New List(Of CLASSDINAMIKRAPOR)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikrapor"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikrapor.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporad") Is System.DBNull.Value Then
                    donecekdinamikrapor.raporad = veri.Item("raporad")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekdinamikrapor.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("raportip") Is System.DBNull.Value Then
                    donecekdinamikrapor.raportip = veri.Item("raportip")
                End If

                If Not veri.Item("sqlstr") Is System.DBNull.Value Then
                    donecekdinamikrapor.sqlstr = veri.Item("sqlstr")
                End If

                If Not veri.Item("arabirimolsunmu") Is System.DBNull.Value Then
                    donecekdinamikrapor.arabirimolsunmu = veri.Item("arabirimolsunmu")
                End If

                If Not veri.Item("toplamlargosterilsinmi") Is System.DBNull.Value Then
                    donecekdinamikrapor.toplamlargosterilsinmi = veri.Item("toplamlargosterilsinmi")
                End If

                dinamikraporler.Add(New CLASSDINAMIKRAPOR(donecekdinamikrapor.pkey, _
                donecekdinamikrapor.raporad, donecekdinamikrapor.aciklama, _
                donecekdinamikrapor.raportip, donecekdinamikrapor.sqlstr, _
                donecekdinamikrapor.arabirimolsunmu, donecekdinamikrapor.toplamlargosterilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporler

    End Function



    '---------------------------------doldur-----------------------------------------
    Public Function dolduryetkili(ByVal kullanicipkey) As List(Of CLASSDINAMIKRAPOR)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim dinamikraporkullanicibag As New CLASSDINAMIKKULLANICIBAG
        Dim donecekdinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikraporler As New List(Of CLASSDINAMIKRAPOR)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikkullanicibag where kullanicipkey=@kullanicipkey "
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    dinamikraporkullanicibag.raporpkey = veri.Item("raporpkey")
                End If

                donecekdinamikrapor = bultek(dinamikraporkullanicibag.raporpkey)

                dinamikraporler.Add(New CLASSDINAMIKRAPOR(donecekdinamikrapor.pkey, _
                donecekdinamikrapor.raporad, donecekdinamikrapor.aciklama, _
                donecekdinamikrapor.raportip, donecekdinamikrapor.sqlstr, _
                donecekdinamikrapor.arabirimolsunmu, donecekdinamikrapor.toplamlargosterilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporler

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
        "<th>Rapor Adı</th>" + _
        "<th>Rapor Açıklaması</th>" + _
        "<th>Rapor Tipi</th>" + _
        "<th>Arabirim Olacak mı?</th>" + _
        "<th>Toplamlar Gösterilecek mi?</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from dinamikrapor"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporad, aciklama, raportip, arabirimolsunmu As String
        Dim toplamlargosterilsinmi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "dinamikraporpopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("raporad") Is System.DBNull.Value Then
                        raporad = veri.Item("raporad")
                        kol2 = "<td>" + raporad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol3 = "<td>" + aciklama + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("raportip") Is System.DBNull.Value Then
                        raportip = veri.Item("raportip")
                        kol4 = "<td>" + raportip + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("arabirimolsunmu") Is System.DBNull.Value Then
                        arabirimolsunmu = veri.Item("arabirimolsunmu")
                        kol5 = "<td>" + arabirimolsunmu + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("toplamlargosterilsinmi") Is System.DBNull.Value Then
                        toplamlargosterilsinmi = veri.Item("toplamlargosterilsinmi")
                        kol6 = "<td>" + toplamlargosterilsinmi + "</td></tr>"
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
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikrapor where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
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



    Public Function sqlolustur(ByVal raporpkey As Integer) As String

        Dim sqlstring As String
        Dim dinamikrapor As New CLASSDINAMIKRAPOR

        dinamikrapor = bultek(raporpkey)

        If dinamikrapor.raportip = "Standart" Then

            'GÖSTERİLECEK FIELD LER -------------------------------------
            Dim gosterilecekfieldstr As String
            Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
            Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
            gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)
            For Each gosterilecekfielditem As CLASSGOSTERILECEKfield In gosterilecekfieldler
                gosterilecekfieldstr = gosterilecekfieldstr + _
                " " + gosterilecekfielditem.ekkelime + " " + _
                gosterilecekfielditem.gosterilecektabload + "." + _
                gosterilecekfielditem.fieldad + " as " + gosterilecekfielditem.sqlalias + ","
            Next
            If Len(gosterilecekfieldstr) > 0 Then
                gosterilecekfieldstr = Mid(gosterilecekfieldstr, 1, Len(gosterilecekfieldstr) - 1)
            End If

            'KULLANILACAK TABLOLAR ---------------------------------------
            Dim tablostr As String
            Dim kullanılacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
            Dim kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
            kullanilacaktablolar = kullanılacaktablo_erisim.doldurilgili(raporpkey)
            For Each tabloitem As CLASSKULLANILACAKTABLO In kullanilacaktablolar
                tablostr = tablostr + tabloitem.tabload + ","
            Next
            If Len(tablostr) > 0 Then
                tablostr = Mid(tablostr, 1, Len(tablostr) - 1)
            End If

            'KOŞULLAR------------------------------------------------------
            Dim kosulstr As String
            kosulstr = kosulstrolustur(raporpkey)

            'SIRALAMA SQL OLUŞTUR ---------------------------------------------------
            Dim siralamastr As String
            Dim siralamatipsql As String
            Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
            Dim siralamalar As New List(Of CLASSSIRALAMAFIELD)
            siralamalar = siralamafield_erisim.doldurilgili(raporpkey)
            If siralamalar.Count > 0 Then
                For Each siralamaitem As CLASSSIRALAMAFIELD In siralamalar

                    If siralamaitem.ordertype = 1 Then
                        siralamatipsql = " asc "
                    End If
                    If siralamaitem.ordertype = 2 Then
                        siralamatipsql = " desc "
                    End If
                    siralamastr = siralamastr + siralamaitem.fieldad + " " + siralamatipsql + ","
                Next
            End If
            If Len(siralamastr) > 0 Then
                siralamastr = " order by " + Mid(siralamastr, 1, Len(siralamastr) - 1)
            End If

            'GRUP SQL OLUŞTUR ---------------------------------------------------
            Dim grupstrdevam As String
            Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
            Dim igosterilecekfield As New CLASSGOSTERILECEKfield

            Dim grupfieldler As New List(Of CLASSGRUPFIELD)
            grupfieldler = grupfield_erisim.doldurilgili(raporpkey)
            If grupfieldler.Count > 0 Then
                For Each itemgrupfield As CLASSGRUPFIELD In grupfieldler
                    igosterilecekfield = gosterilecekfield_erisim.bultek(itemgrupfield.gosterilecekfieldpkeybag)
                    grupstrdevam = grupstrdevam + igosterilecekfield.sqlalias + ","
                Next
            End If
            If Len(grupstrdevam) > 0 Then
                grupstrdevam = " group by " + Mid(grupstrdevam, 1, Len(grupstrdevam) - 1)
            End If


            'AGGREGATE FUNC OLUSTUR-------------------------------------------------
            Dim aggstrdevam As String
            Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
            Dim aggfunclar As New List(Of CLASSAGGFUNC)
            Dim ikullanilacaktablo As New CLASSKULLANILACAKTABLO

            aggfunclar = aggfunc_erisim.doldurilgili(raporpkey)
            If aggfunclar.Count > 0 Then
                For Each itemaggfunc As CLASSAGGFUNC In aggfunclar
                    ikullanilacaktablo = kullanılacaktablo_erisim.bultek(itemaggfunc.ktablopkey)
                    If itemaggfunc.fonksiyontip = "Sistem" Then
                        aggstrdevam = aggstrdevam + itemaggfunc.fonksiyonad + "(" + _
                        ikullanilacaktablo.tabload + "." + itemaggfunc.fieldad + ") as " + itemaggfunc.sayialias + ","
                    End If
                    If itemaggfunc.fonksiyontip = "Manuel" Then
                        aggstrdevam = aggstrdevam + itemaggfunc.fonksiyonsql + " as " + itemaggfunc.sayialias + ","
                    End If
                Next
            End If
            If Len(aggstrdevam) > 0 Then
                aggstrdevam = Mid(aggstrdevam, 1, Len(aggstrdevam) - 1)
            End If

            'ANA SQL İ OLUŞTUR -------------------------------------------------------------------
            Dim aggstr As String
            'aggregate str olustur
            If gosterilecekfieldstr <> "" And aggstrdevam <> "" Then
                aggstr = aggstrdevam + ","
            End If
            If gosterilecekfieldstr = "" Then
                aggstr = aggstrdevam
            End If

            sqlstring = "select " + aggstr + gosterilecekfieldstr + _
            " from " + tablostr + _
            kosulstr + grupstrdevam + siralamastr

            Return sqlstring

        End If

        If dinamikrapor.raportip = "Manuel" Then
            sqlstring = dinamikrapor.sqlstr
            Return sqlstring
        End If


    End Function


    Function kosulstrolustur(ByVal raporpkey As String) As String

        'FOREIGN KEY BAĞLAR---------------------------------------------- 
        Dim sqlforeigndevam As String
        Dim kullanılacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        Dim varmi As String
        Dim tablobaglar As New List(Of CLASSTABLOBAG)
        Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
        tablobaglar = tablobag_erisim.doldur()

        For Each tablobag As CLASSTABLOBAG In tablobaglar
            varmi = kullanılacaktablo_erisim.varmibag(raporpkey, tablobag.tabload1, tablobag.tabload2)
            If varmi = "var" Then
                sqlforeigndevam = sqlforeigndevam + _
                tablobag.tabload1 + "." + tablobag.tablofield1 + "=" + _
                tablobag.tabload2 + "." + tablobag.tablofield2 + " and "
            End If
        Next
        If Len(sqlforeigndevam) > 4 Then
            sqlforeigndevam = Mid(sqlforeigndevam, 1, Len(sqlforeigndevam) - 4)
        End If
        'FOREIGN KEY BAĞLAR ---------------------------------------------

        Dim toplamanagrupsayisi As Integer
        Dim toplamkosulsayisi As Integer

        Dim gcount As Integer = 0
        Dim grupmantikop
        Dim ic As String = ""
        Dim tekic As String = ""
        Dim z As Integer = 1
        Dim donecek As String
        Dim bagmantikopsql As String
        Dim kosulstr As String = ""
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim kosullar As New List(Of CLASSKOSULFIELD)
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)
        toplamkosulsayisi = kosullar.Count

        Dim kosulanagruplar As Integer()
        kosulanagruplar = kosulfield_erisim.doldurkosulgruplari(raporpkey)
        toplamanagrupsayisi = kosulanagruplar.Count

        For Each Item As Integer In kosulanagruplar

            If Item <> 0 Then
                ic = ""

                For Each kosulitem As CLASSKOSULFIELD In kosullar


                    If Item = kosulitem.kosulgrupno Then

                        If kosulitem.bagmantikop <> "0" Then
                            bagmantikopsql = kosulitem.bagmantikop
                        Else
                            bagmantikopsql = ""
                        End If
                        If kosulitem.kosulop <> " like " Then
                            ic = ic + kosulitem.kosultabload + "." + kosulitem.fieldad + _
                            kosulitem.kosulop + "@" + kosulitem.fieldad + CStr(z) + " " + _
                            bagmantikopsql + " "

                            tekic = kosulitem.kosultabload + "." + kosulitem.fieldad + _
                            kosulitem.kosulop + "@" + kosulitem.fieldad + CStr(z) + " " + _
                            bagmantikopsql + " "

                        End If
                        If kosulitem.kosulop = " like " Then
                            ic = ic + kosulitem.kosultabload + "." + kosulitem.fieldad + _
                            kosulitem.kosulop + "'%'+" + "@" + kosulitem.fieldad + CStr(z) + "+'%' " + _
                            bagmantikopsql + " "

                            tekic = kosulitem.kosultabload + "." + kosulitem.fieldad + _
                            kosulitem.kosulop + "'%'+" + "@" + kosulitem.fieldad + CStr(z) + "+'%' " + _
                            bagmantikopsql + " "

                        End If
                        If (kosulitem.fieldtype = "date" Or kosulitem.fieldtype = "datetime") And kosulitem.kosulop = "=" Then

                            If tekic <> "" Then
                                ic = Replace(ic, tekic, "")
                            End If

                            ic = ic + "Convert(DATE," + kosulitem.kosultabload + "." + kosulitem.fieldad + ")" + _
                            kosulitem.kosulop + "@" + kosulitem.fieldad + CStr(z) + " " + _
                            bagmantikopsql + " "


                        End If

                        If kosulitem.grupmantikop <> "0" Then
                            grupmantikop = " " + kosulitem.grupmantikop + " "
                        End If

                        z = z + 1

                    End If

                Next 'ic kosullar

                gcount = gcount + 1

                If gcount < toplamanagrupsayisi Then
                    kosulstr = kosulstr + "(" + ic + ")" + grupmantikop
                End If
                If gcount = toplamanagrupsayisi Then
                    kosulstr = kosulstr + "(" + ic + ")"
                End If
            End If 'item 0 değil

        Next 'kosul ana gruplar

        If Len(kosulstr) > 0 And Len(sqlforeigndevam) > 0 Then
            kosulstr = " where " + kosulstr + " and " + sqlforeigndevam
        End If
        If Len(kosulstr) > 0 And Len(sqlforeigndevam) <= 0 Then
            kosulstr = " where " + kosulstr
        End If
        If Len(kosulstr) <= 0 And Len(sqlforeigndevam) > 0 Then
            kosulstr = " where " + sqlforeigndevam
        End If
        If Len(kosulstr) <= 0 And Len(sqlforeigndevam) <= 0 Then
            kosulstr = ""
        End If


        Return kosulstr

    End Function


    Function raporolustur(ByVal raporpkey As Integer) As CLASSRAPOR

        Dim clog As String
        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci

        Dim toplamyazi As String
        Dim toplamlarsatir As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        dinamikrapor = bultek(raporpkey)

        Dim rapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim generic_erisim As New CLASSGENERIC_ERISIM

        Dim donecek As String
        Dim calistirilacaksql As String

        calistirilacaksql = sqlolustur(raporpkey)

        'LOGLAMAK İÇİN --------------------------------
        dinamikraporlog.raporpkey = raporpkey
        dinamikraporlog.ctarih = DateTime.Now
        dinamikraporlog.csql = calistirilacaksql



        'BAĞLAN ---------------------------------------------------------------------
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        komut = New SqlCommand(calistirilacaksql, db_baglanti)

        '600/60=10 dakika
        komut.CommandTimeout = 600


        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim kosullar As New List(Of CLASSKOSULFIELD)
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)

        Dim z As Integer = 1
        Dim degisken As String
        Dim deger As String
        'PARAMETRELERİ GÖM ---------------------------------------------------------------
        For Each itemkosul As CLASSKOSULFIELD In kosullar

            degisken = itemkosul.fieldad + CStr(z)
            komut.Parameters.Add(degisken, generic_erisim.sqldbtypebul(itemkosul.fieldtype).sqltype)

            If dinamikrapor.arabirimolsunmu = "Hayır" And itemkosul.runtime = "Hayır" Then
                komut.Parameters(degisken).Value = itemkosul.deger
                clog = clog + itemkosul.arabirimlabel + " = " + CStr(itemkosul.deger) + "<br/>"
            End If

            If dinamikrapor.arabirimolsunmu = "Evet" And itemkosul.runtime = "Evet" Then
                deger = HttpContext.Current.Session("ss" + CStr(itemkosul.pkey))
                If deger Is Nothing Then
                    deger = itemkosul.deger
                End If
                komut.Parameters(degisken).Value = deger
                clog = clog + itemkosul.arabirimlabel + " = " + CStr(deger) + "<br/>"
            End If

            If dinamikrapor.arabirimolsunmu = "Evet" And itemkosul.runtime = "Hayır" Then
                komut.Parameters(degisken).Value = itemkosul.deger
                clog = clog + itemkosul.arabirimlabel + " = " + CStr(itemkosul.deger) + "<br/>"
            End If

            If itemkosul.runtime = "Hayır" And itemkosul.sezonad <> "" Then
                komut.Parameters(degisken).Value = HttpContext.Current.Session(itemkosul.sezonad)
                clog = clog + itemkosul.arabirimlabel + " = " + HttpContext.Current.Session(itemkosul.sezonad) + "<br/>"
            End If

            z = z + 1

        Next

        Dim raporkackolon As Integer
        Dim girdi As String = 0

        Dim i As Integer = 0

        'TÜM GÖSTERİLECEK FIELD LERİ OLUŞTUR ---------------------------------------------
        Dim tumgosterilecekler As New List(Of CLASSTUMFIELDALIAS)
        Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)

        Dim aggfuncler As New List(Of CLASSAGGFUNC)
        Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
        aggfuncler = aggfunc_erisim.doldurilgili(raporpkey)

        For Each Item As CLASSGOSTERILECEKfield In gosterilecekfieldler
            tumgosterilecekler.Add(New CLASSTUMFIELDALIAS(Item.sqlalias, Item.raporalias))
        Next
        For Each Item As CLASSAGGFUNC In aggfuncler
            tumgosterilecekler.Add(New CLASSTUMFIELDALIAS(Item.sayialias, Item.kolonbaslik))
        Next

        raporkackolon = tumgosterilecekler.Count
        Dim kol(raporkackolon - 1) As String
        Dim saf(raporkackolon - 1) As String
        Dim toplam(raporkackolon - 1) As Decimal
        Dim toplamstr(raporkackolon - 1) As String

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(tumgosterilecekler.Count)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)

        Dim tabloson As String = "</tbody></table>"
        Dim jvstring As String
        Dim baslikic As String
        Dim baslikstr As String

        For Each itemt As CLASSTUMFIELDALIAS In tumgosterilecekler
            baslikic = baslikic + "<th>" + itemt.raporbaslik + "</th>"
            table.Columns.Add(itemt.raporbaslik, GetType(String))
            pdftable.AddCell(New Phrase(itemt.raporbaslik, fbaslik))
        Next

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        baslikstr = "<table class='table table-striped table-bordered table-hover' id='sample_r'>" + _
        "<thead>" + _
        "<tr>" + _
        baslikic + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        'VERİYİ OLUŞTUR --------------------------------------
        Dim satir As String = ""
        Dim d As String
        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    rapor.calisiyormu = "Evet"

                    girdi = "1"
                    For Each itemt As CLASSTUMFIELDALIAS In tumgosterilecekler
                        '---null değilse
                        If Not veri.Item(itemt.aliaz) Is System.DBNull.Value Then
                            d = veri.Item(itemt.aliaz)
                            If i = 0 Then
                                kol(i) = CStr(kol(i)) + "<tr><td>" + d + "</td>"
                                saf(i) = d
                            End If
                            If i > 0 Then
                                kol(i) = CStr(kol(i)) + "<td>" + d + "</td>"
                                saf(i) = d
                            End If
                        Else
                            If i = 0 Then
                                kol(i) = "<tr><td>-</td>"
                                saf(i) = "-"
                            End If
                            If i > 0 Then
                                kol(i) = "<td>-</td>"
                                saf(i) = "-"
                            End If
                        End If 'veri.item

                        Try
                            toplam(i) = toplam(i) + CDbl(veri.Item(itemt.aliaz))
                            toplamstr(i) = Format(toplam(i), "0.00")
                        Catch ex As Exception
                            toplam(i) = 0
                            toplamstr(i) = "-"
                        End Try

                        pdftable.AddCell(New Phrase(saf(i), fdata))
                        i = i + 1
                    Next

                    'html output icin 
                    For a = 0 To tumgosterilecekler.Count - 1
                        satir = satir + kol(a)
                        kol(a) = ""
                    Next

                    table.Rows.Add(saf)

                    i = 0
                    recordcount = recordcount + 1

                End While
            End Using

            If dinamikrapor.toplamlargosterilsinmi = "Evet" Then
                'TOPLAMLAR SATIR WORD VE EXCELLER İÇİN
                Dim R As DataRow = table.NewRow
                For a = 0 To tumgosterilecekler.Count - 1
                    R(a) = toplamstr(a)
                Next
                table.Rows.Add(R)
                'TOPLAMLAR SATIR PDF İÇİN
                For a = 0 To tumgosterilecekler.Count - 1
                    pdftable.AddCell(New Phrase(Format(toplam(a), "0.00"), fdata))
                Next
                'TOPLAMLAR SATIR HTML İÇİN
                For a = 0 To tumgosterilecekler.Count - 1
                    If a = 0 Then
                        toplamlarsatir = toplamlarsatir + "<tr><td>" + Format(toplam(a), "0.00") + "</td>"
                    End If
                    If a > 0 Then
                        toplamlarsatir = toplamlarsatir + "<td>" + Format(toplam(a), "0.00") + "</td>"
                    End If
                Next
            End If

            toplamyazi = "Toplam bulunan kayıt sayısı: " + CStr(recordcount)

        Catch ex As Exception
            rapor.kacadet = 0
            rapor.tablo = Nothing
            rapor.pdftablo = Nothing
            rapor.veri = ex.Message
            rapor.calisiyormu = "Hayır"
            rapor.hatatxt = ex.Message
            Return rapor
        Finally
            db_baglanti.Close()
            db_baglanti.Dispose()
        End Try

        rapor.calisiyormu = "Evet"

        If recordcount > 0 Then
            rapor.baslik = dinamikrapor.raporad
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = baslikstr + satir + toplamlarsatir + tabloson + toplamyazi + jvstring
        End If

        'LOGLA
        dinamikraporlog.clog = clog
        dinamikraporlog_erisim.Ekle(dinamikraporlog)


        Return rapor

    End Function


    Public Function arabirimolustur(ByVal raporpkey As String) As String

        Dim donecek As String = ""

        Dim dropdownlist_erisim As New CLASSDROPDOWNLIST_ERISIM
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim kosullar As New List(Of CLASSKOSULFIELD)
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)

        If kosullar.Count > 0 Then
            For Each kosulitem As CLASSKOSULFIELD In kosullar

                If kosulitem.runtime = "Evet" Then

                    If kosulitem.arabirimtip = "TextBox" Then
                        donecek = donecek + _
                        "<div class='row'>" + _
                            "<div class='col-md-12'>" + _
                                "<h5>" + kosulitem.arabirimlabel + "</h5>" + _
                                "<p>" + _
                                "<input type=" + Chr(34) + "text" + Chr(34) + " class=" + Chr(34) + "form-control" + Chr(34) + _
                                " name=" + Chr(34) + "ss" + CStr(kosulitem.pkey) + Chr(34) + _
                                " id=" + Chr(34) + "ss" + CStr(kosulitem.pkey) + Chr(34) + _
                                " value=" + Chr(34) + CStr(kosulitem.deger) + Chr(34) + "></input>" + _
                                "</p>" + _
                            "</div>" + _
                        "</div>"
                    End If 'tip=textbox


                    If kosulitem.arabirimtip = "DropDownList" Then
                        donecek = donecek + _
                        "<div class='row'>" + _
                            "<div class='col-md-12'>" + _
                                "<h5>" + kosulitem.arabirimlabel + "</h5>" + _
                                "<p>" + _
                                "<select  class=" + Chr(34) + "form-control" + Chr(34) + _
                                " name=" + Chr(34) + "ss" + CStr(kosulitem.pkey) + Chr(34) + _
                                " id=" + Chr(34) + "ss" + CStr(kosulitem.pkey) + Chr(34) + ">" + _
                                dropdownlist_erisim.optionolustur(kosulitem.dropdownlistpkey) + _
                                "</select>" + _
                                "</p>" + _
                            "</div>" + _
                        "</div>"
                    End If 'tip=DropDownList


                End If 'runtime=evet

            Next
        End If

        Return donecek

    End Function


    Public Function validateinput(ByVal datatype As String, ByVal deger As String) As CLADBOPRESULT

        Dim d As DateTime
        Dim result As New CLADBOPRESULT

        result.durum = "Kaydedildi"
        result.etkilenen = 0
        result.hatastr = ""

        'numeric ler için kontrol
        If datatype = "bit" Or datatype = "numeric" Or datatype = "int" Or datatype = "decimal" Or _
        datatype = "float" Or datatype = "double" Or datatype = "real" Then
            If IsNumeric(deger) = False Then
                result.durum = "Kaydedilmedi"
                result.etkilenen = 0
                result.hatastr = "Girilen değer rakamsal olmalıdır."
            End If
            If IsNumeric(deger) = True Then
                'If CInt(deger) = 0 Then
                'result.durum = "Kaydedilmedi"
                'result.etkilenen = 0
                'result.hatastr = "Rakamsal alanların değeri 0 olamaz."
                'End If
            End If
        End If

        'date ve datetime kontrolü
        If datatype = "date" Or datatype = "datetime" Then
            Try
                d = deger
            Catch ex As Exception
                result.durum = "Kaydedilmedi"
                result.etkilenen = 0
                result.hatastr = "Tarih değerini düzgün giriniz."
            End Try
        End If

        Return result

    End Function


    Public Function mantiksaltest(ByVal raporpkey As Integer) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        dinamikrapor = bultek(raporpkey)
        Dim kosulfieldler As New List(Of CLASSKOSULFIELD)
        Dim kosul_erisim As New CLASSKOSULFIELD_ERISIM

        kosulfieldler = kosul_erisim.doldur_ilgili(raporpkey)

        result.durum = "Kaydedildi"
        result.etkilenen = 1
        result.hatastr = ""

        If dinamikrapor.arabirimolsunmu = "Hayır" Then
            For Each Item As CLASSKOSULFIELD In kosulfieldler
                If Item.runtime = "Evet" Then
                    result.durum = "Kaydedilmedi"
                    result.etkilenen = 0
                    result.hatastr = "Bu rapor için arabirim formu oluşturulmamasına rağmen runtimeda " + _
                    "çalışan koşul alanları tanımlanmış. Runtime da çalışan koşul alanlarını 'Hayır' olarak " + _
                    "kaydederek lütfen raporu tekrar çalıştırmayı deneyin."
                    Return result
                End If
            Next
        End If

        Return result

    End Function


    Public Function otoduzelt(ByVal raporpkey As Integer) As String

        Dim donecek As String = ""
        Dim result As New CLADBOPRESULT
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM

        Dim kosullar As New List(Of CLASSKOSULFIELD)
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)


        For Each Item As CLASSKOSULFIELD In kosullar
            'ayni grup numarasına sahip maksimum sira numarasına sahip koşulların sonundaki mantik operatörleri sıfırlandı.
            If kosulfield_erisim.maksimumsiranumarasinasahipmi_ilgiligrupta(Item) = "Evet" Then
                Item.bagmantikop = 0
                result = kosulfield_erisim.Duzenle(Item)
                If result.durum = "Kaydedildi" Then
                    donecek = donecek + CStr(Item.pkey) + " anahtarlı koşul değiştirildi. (İç Kontrol)" + "<br/>"
                End If
            End If
            'o raporun içindeki maksimum sira numarasına sahip kosul bag ve grup mantık operatorleri sıfırlandı.
            If kosulfield_erisim.maksimumsirano(Item.raporpkey) = Item.sira Then
                Item.bagmantikop = 0
                Item.grupmantikop = 0
                result = kosulfield_erisim.Duzenle(Item)
                If result.durum = "Kaydedildi" Then
                    donecek = donecek + CStr(Item.pkey) + " anahtarlı koşul değiştirildi. (Maks Kontrol)" + "<br/>"
                End If
            End If
        Next

        Return donecek

    End Function


    Public Function kopyasiniolustur(ByVal raporpkey As Integer) As String

        Dim eklenenraporpkey As Integer
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM

        Dim donecek As String
        Dim result As New CLADBOPRESULT
        Dim odinamikrapor As New CLASSDINAMIKRAPOR
        odinamikrapor = bultek(raporpkey)
        odinamikrapor.raporad = "-Kopyası- " + odinamikrapor.raporad

        result = Ekle(odinamikrapor)
        If result.durum = "Kaydedildi" Then
            eklenenraporpkey = result.etkilenen
            donecek = "Rapor temel bilgisi kaydedildi."
        End If


        Dim e_kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
        Dim e_gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
        Dim e_dinamikraporzamanlama As New List(Of CLASSDINAMIKRAPORZAMANLAMA)

        Dim kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
        Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
        Dim kosulfieldler As New List(Of CLASSKOSULFIELD)
        Dim siralamafieldler As New List(Of CLASSSIRALAMAFIELD)
        Dim grupfieldler As New List(Of CLASSGRUPFIELD)
        Dim aggfunclar As New List(Of CLASSAGGFUNC)
        Dim dinamikraporzamanlamalar As New List(Of CLASSDINAMIKRAPORZAMANLAMA)
        Dim dinamikkullanicibaglar As New List(Of CLASSDINAMIKKULLANICIBAG)

        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM

        kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)
        gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)
        kosulfieldler = kosulfield_erisim.doldur_ilgili(raporpkey)
        siralamafieldler = siralamafield_erisim.doldurilgili(raporpkey)
        grupfieldler = grupfield_erisim.doldurilgili(raporpkey)
        aggfunclar = aggfunc_erisim.doldurilgili(raporpkey)
        dinamikraporzamanlamalar = dinamikraporzamanlama_erisim.dolduriligili(raporpkey)
        dinamikkullanicibaglar = dinamikkullanicibag_erisim.doldurilgili(raporpkey)

        For Each Item As CLASSKULLANILACAKTABLO In kullanilacaktablolar
            Item.raporpkey = eklenenraporpkey
            result = kullanilacaktablo_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.tabload + " Kullanılacak tablo eklendi." + "<br/>"
            End If
        Next

        e_kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(eklenenraporpkey)
        For Each Item As CLASSGOSTERILECEKfield In gosterilecekfieldler
            Item.raporpkey = eklenenraporpkey
            For Each itemkullanilacaktablo As CLASSKULLANILACAKTABLO In e_kullanilacaktablolar
                If itemkullanilacaktablo.tabload = Item.gosterilecektabload Then
                    Item.kullanilacaktablopkey = itemkullanilacaktablo.pkey
                End If
            Next
            result = gosterilecekfield_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.fieldad + " Gösterilecek field eklendi." + "<br/>"
            End If
        Next

        For Each Item As CLASSKOSULFIELD In kosulfieldler
            Item.raporpkey = eklenenraporpkey
            For Each itemkullanilacaktablo In e_kullanilacaktablolar
                If itemkullanilacaktablo.tabload = Item.kosultabload Then
                    Item.kullanilacaktablopkey = itemkullanilacaktablo.pkey
                End If
            Next
            result = kosulfield_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.fieldad + " Koşul field eklendi." + "<br/>"
            End If
        Next

        For Each Item As CLASSSIRALAMAFIELD In siralamafieldler
            Item.raporpkey = eklenenraporpkey
            For Each itemkullanilacaktablo In e_kullanilacaktablolar
                If itemkullanilacaktablo.tabload = Item.siralamatabload Then
                    Item.kullanilacaktablopkey = itemkullanilacaktablo.pkey
                End If
            Next
            result = siralamafield_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.siralamatabload + " Sıralama tablo eklendi." + "<br/>"
            End If
        Next

        e_gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(eklenenraporpkey)
        For Each Item As CLASSGRUPFIELD In grupfieldler
            Item.raporpkey = eklenenraporpkey
            For Each itemkullanilacaktablo In e_kullanilacaktablolar
                If itemkullanilacaktablo.tabload = Item.gruptabload Then
                    Item.gruptablopkey = itemkullanilacaktablo.pkey
                End If
            Next
            For Each itemgosterilecekfield In e_gosterilecekfieldler
                If itemgosterilecekfield.gosterilecektabload = Item.gruptabload Then
                    Item.gosterilecekfieldpkeybag = itemgosterilecekfield.pkey
                End If
            Next
            result = grupfield_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.gruptabload + " Grup tablo eklendi." + "<br/>"
            End If
        Next

        For Each Item As CLASSAGGFUNC In aggfunclar
            Item.raporpkey = eklenenraporpkey
            For Each itemkullanilacaktablo In e_kullanilacaktablolar
                If itemkullanilacaktablo.tabload = kullanilacaktablo_erisim.bultek(Item.ktablopkey).tabload Then
                    Item.ktablopkey = itemkullanilacaktablo.pkey
                End If
            Next
            result = aggfunc_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.fieldad + " Aggfunc field eklendi." + "<br/>"
            End If
        Next

        For Each Item As CLASSDINAMIKRAPORZAMANLAMA In dinamikraporzamanlamalar
            Item.raporpkey = eklenenraporpkey
            result = dinamikraporzamanlama_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                donecek = donecek + Item.zamanlamaad + " Zamanlama eklendi." + "<br/>"
            End If
        Next

        e_dinamikraporzamanlama = dinamikraporzamanlama_erisim.dolduriligili(eklenenraporpkey)
        For Each Item As CLASSDINAMIKKULLANICIBAG In dinamikkullanicibaglar
            Item.raporpkey = eklenenraporpkey
            For Each itemdinamikraporzamanlama In e_dinamikraporzamanlama
                If dinamikraporzamanlama_erisim.bultek(Item.zamanlamapkey).remindersettingpkey = dinamikraporzamanlama_erisim.bultek(itemdinamikraporzamanlama.pkey).remindersettingpkey Then
                    Item.zamanlamapkey = itemdinamikraporzamanlama.pkey
                End If
            Next
            result = dinamikkullanicibag_erisim.Ekle(Item)
            If result.durum = "Kaydedildi" Then
                kullanici = kullanici_Erisim.bultek(Item.kullanicipkey)
                donecek = donecek + kullanici.adsoyad + " Kullanıcı eklendi." + "<br/>"
            End If
        Next

        Return donecek

    End Function


    Public Function tabloilisiklimi(ByVal raporpkey As Integer, _
   ByVal eklenmekistenentablo As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        result.hatastr = ""
        result.durum = "Hayır"
        result.etkilenen = 0

        Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM

        Dim kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
        kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)
        Dim girdi As Integer
        girdi = 0

        If kullanilacaktablolar.Count < 1 Then
            result.hatastr = ""
            result.durum = "Evet"
            result.etkilenen = 0
        End If

        If kullanilacaktablolar.Count >= 1 Then
            For Each itemtablo In kullanilacaktablolar
                If tablobag_erisim.tabloiliskilimi(itemtablo.tabload, eklenmekistenentablo) = "Evet" Then
                    girdi = 1
                End If
                If tablobag_erisim.tabloiliskilimi(itemtablo.tabload, eklenmekistenentablo) = "Hayır" Then
                    result.hatastr = result.hatastr + itemtablo.tabload + " ve " + _
                    eklenmekistenentablo + " tabloları birbirleriyle ilişikli değildir"
                End If
            Next

            If girdi = 1 Then
                result.hatastr = ""
                result.durum = "Evet"
                result.etkilenen = 0
            End If
        End If


        Return result

    End Function


End Class

