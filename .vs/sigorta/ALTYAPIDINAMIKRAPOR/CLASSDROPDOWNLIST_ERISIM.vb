Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSDROPDOWNLIST_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dropdownlist As New CLASSDROPDOWNLIST
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dropdownlist As CLASSDROPDOWNLIST) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(dropdownlist.tabload,dropdownlist.degerkolon,dropdownlist.yazikolon)

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
            sqlstr = "insert into dropdownlist values (@pkey," + _
            "@ad,@tabload,@degerkolon,@yazikolon," + _
            "@sqlstropsiyonel)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If dropdownlist.ad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = dropdownlist.ad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tabload", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If dropdownlist.tabload = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = dropdownlist.tabload
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@degerkolon", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If dropdownlist.degerkolon = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = dropdownlist.degerkolon
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@yazikolon", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If dropdownlist.yazikolon = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = dropdownlist.yazikolon
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@sqlstropsiyonel", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If dropdownlist.sqlstropsiyonel = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = dropdownlist.sqlstropsiyonel
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
        sqlstr = "select max(pkey) from dropdownlist"
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
    Function Duzenle(ByVal dropdownlist As CLASSDROPDOWNLIST) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update dropdownlist set " + _
        "ad=@ad," + _
        "tabload=@tabload," + _
        "degerkolon=@degerkolon," + _
        "yazikolon=@yazikolon," + _
        "sqlstropsiyonel=@sqlstropsiyonel" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dropdownlist.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If dropdownlist.ad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = dropdownlist.ad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If dropdownlist.tabload = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dropdownlist.tabload
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@degerkolon", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If dropdownlist.degerkolon = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dropdownlist.degerkolon
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@yazikolon", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If dropdownlist.yazikolon = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = dropdownlist.yazikolon
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@sqlstropsiyonel", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If dropdownlist.sqlstropsiyonel = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = dropdownlist.sqlstropsiyonel
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
    Function bultek(ByVal pkey As String) As CLASSDROPDOWNLIST

        Dim komut As New SqlCommand
        Dim donecekdropdownlist As New CLASSdropdownlist()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dropdownlist where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdropdownlist.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekdropdownlist.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekdropdownlist.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("degerkolon") Is System.DBNull.Value Then
                    donecekdropdownlist.degerkolon = veri.Item("degerkolon")
                End If

                If Not veri.Item("yazikolon") Is System.DBNull.Value Then
                    donecekdropdownlist.yazikolon = veri.Item("yazikolon")
                End If

                If Not veri.Item("sqlstropsiyonel") Is System.DBNull.Value Then
                    donecekdropdownlist.sqlstropsiyonel = veri.Item("sqlstropsiyonel")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdropdownlist

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM

        Dim varmi As String = kosulfield_erisim.dropdownlistpkeyvarmi(pkey)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu liste dinamik raporların birinde koşul arabirimi olarak " + _
            "kullanılıyor. Bu sebepten bu listeyi silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dropdownlist where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSDROPDOWNLIST)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdropdownlist As New CLASSdropdownlist
        Dim dropdownlistler As New List(Of CLASSdropdownlist)
        komut.Connection = db_baglanti
        sqlstr = "select * from dropdownlist"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdropdownlist.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekdropdownlist.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekdropdownlist.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("degerkolon") Is System.DBNull.Value Then
                    donecekdropdownlist.degerkolon = veri.Item("degerkolon")
                End If

                If Not veri.Item("yazikolon") Is System.DBNull.Value Then
                    donecekdropdownlist.yazikolon = veri.Item("yazikolon")
                End If

                If Not veri.Item("sqlstropsiyonel") Is System.DBNull.Value Then
                    donecekdropdownlist.sqlstropsiyonel = veri.Item("sqlstropsiyonel")
                End If


                dropdownlistler.Add(New CLASSdropdownlist(donecekdropdownlist.pkey, _
                donecekdropdownlist.ad, donecekdropdownlist.tabload, donecekdropdownlist.degerkolon, donecekdropdownlist.yazikolon, _
                donecekdropdownlist.sqlstropsiyonel))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dropdownlistler

    End Function



    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As String) As List(Of CLASSDROPDOWNLIST)

        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        Dim kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
        kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdropdownlist As New CLASSDROPDOWNLIST
        Dim dropdownlistler As New List(Of CLASSDROPDOWNLIST)
        komut.Connection = db_baglanti
        sqlstr = "select * from dropdownlist"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdropdownlist.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ad") Is System.DBNull.Value Then
                    donecekdropdownlist.ad = veri.Item("ad")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekdropdownlist.tabload = veri.Item("tabload")
                End If

                If Not veri.Item("degerkolon") Is System.DBNull.Value Then
                    donecekdropdownlist.degerkolon = veri.Item("degerkolon")
                End If

                If Not veri.Item("yazikolon") Is System.DBNull.Value Then
                    donecekdropdownlist.yazikolon = veri.Item("yazikolon")
                End If

                If Not veri.Item("sqlstropsiyonel") Is System.DBNull.Value Then
                    donecekdropdownlist.sqlstropsiyonel = veri.Item("sqlstropsiyonel")
                End If

                For Each itemkullanilacaktablo As CLASSKULLANILACAKTABLO In kullanilacaktablolar
                    If itemkullanilacaktablo.tabload = donecekdropdownlist.tabload Then
                        dropdownlistler.Add(New CLASSDROPDOWNLIST(donecekdropdownlist.pkey, _
                        donecekdropdownlist.ad, donecekdropdownlist.tabload, _
                        donecekdropdownlist.degerkolon, donecekdropdownlist.yazikolon, _
                        donecekdropdownlist.sqlstropsiyonel))
                    End If
                Next
                
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dropdownlistler

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
        "<th>Ad</th>" + _
        "<th>Tablo Adı</th>" + _
        "<th>Değer Kolonu</th>" + _
        "<th>Yazı Kolonu</th>" + _
        "<th>Veri Çekme SQL 'i</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from dropdownlist"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, ad, tabload, degerkolon, yazikolon, sqlstropsiyonel As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "dropdownlist.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("ad") Is System.DBNull.Value Then
                        ad = veri.Item("ad")
                        kol2 = "<td>" + ad + "</td>"
                    End If

                    If Not veri.Item("tabload") Is System.DBNull.Value Then
                        tabload = veri.Item("tabload")
                        kol3 = "<td>" + tabload + "</td>"
                    End If

                    If Not veri.Item("degerkolon") Is System.DBNull.Value Then
                        degerkolon = veri.Item("degerkolon")
                        kol4 = "<td>" + degerkolon + "</td>"
                    End If

                    If Not veri.Item("yazikolon") Is System.DBNull.Value Then
                        yazikolon = veri.Item("yazikolon")
                        kol5 = "<td>" + yazikolon + "</td>"
                    End If

                    If Not veri.Item("sqlstropsiyonel") Is System.DBNull.Value Then
                        sqlstropsiyonel = veri.Item("sqlstropsiyonel")
                        kol6 = "<td>" + sqlstropsiyonel + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tabload As String, ByVal degerkolon As String, _
    ByVal yazikolon As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dropdownlist where tabload=@tabload and " + _
        "degerkolon=@degerkolon and yazikolon=@yazikolon"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@degerkolon", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = degerkolon
        komut.Parameters.Add(param2)


        Dim param3 As New SqlParameter("@yazikolon", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = yazikolon
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Public Function sqlcalisiyormu(ByVal sqlstring As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = sqlstring
        komut = New SqlCommand(sqlstr, db_baglanti)
        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    result.durum = "Kaydedildi"
                    result.etkilenen = 1
                    result.hatastr = ""
                End While
            End Using
        Catch ex As Exception
            result.durum = "Kaydedilmedi"
            result.etkilenen = 0
            result.hatastr = ex.Message
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return result

    End Function


    Public Function otosqlolustur(ByVal deger As String, _
    ByVal yazi As String, ByVal tabload As String) As String

        Dim donecek As String = ""
        donecek = "select " + yazi + "," + deger + " from " + tabload
        Return donecek

    End Function


    Public Function optionolustur(ByVal pkey As String) As String


        Dim degerkolon, yazikolon As String
        Dim donecek As String = ""
        Dim dropdownlist As New CLASSDROPDOWNLIST
        dropdownlist = bultek(pkey)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        If dropdownlist.sqlstropsiyonel = "" Then
            sqlstr = "select * from " + dropdownlist.tabload
        Else
            sqlstr = dropdownlist.sqlstropsiyonel
        End If


        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item(dropdownlist.degerkolon) Is System.DBNull.Value Then
                    degerkolon = veri.Item(dropdownlist.degerkolon)
                End If

                If Not veri.Item(dropdownlist.yazikolon) Is System.DBNull.Value Then
                    yazikolon = veri.Item(dropdownlist.yazikolon)
                End If

                donecek = donecek + _
                "<option value=" + Chr(34) + degerkolon + Chr(34) + ">" + yazikolon + "</option>"

            End While
        End Using


        db_baglanti.Close()
        db_baglanti.Dispose()


        Return donecek


    End Function


End Class

