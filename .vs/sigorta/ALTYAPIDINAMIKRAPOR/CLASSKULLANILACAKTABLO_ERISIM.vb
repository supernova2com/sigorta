Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSKULLANILACAKTABLO_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kullanilacaktablo As New CLASSKULLANILACAKTABLO
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kullanilacaktablo As CLASSKULLANILACAKTABLO) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(kullanilacaktablo.raporpkey, kullanilacaktablo.tabload)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tablo zaten bu raporda kullanılıyor."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into kullanilacaktablo values (@pkey," + _
            "@raporpkey,@tabload)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If kullanilacaktablo.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = kullanilacaktablo.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tabload", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If kullanilacaktablo.tabload = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = kullanilacaktablo.tabload
            End If
            komut.Parameters.Add(param3)

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
        sqlstr = "select max(pkey) from kullanilacaktablo"
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
    Function Duzenle(ByVal kullanilacaktablo As CLASSKULLANILACAKTABLO) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kullanilacaktablo set " + _
        "raporpkey=@raporpkey," + _
        "tabload=@tabload" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanilacaktablo.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If kullanilacaktablo.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = kullanilacaktablo.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kullanilacaktablo.tabload = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kullanilacaktablo.tabload
        End If
        komut.Parameters.Add(param3)


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
    Function bultek(ByVal pkey As String) As CLASSKULLANILACAKTABLO

        Dim komut As New SqlCommand
        Dim donecekkullanilacaktablo As New CLASSKULLANILACAKTABLO()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanilacaktablo where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.tabload = veri.Item("tabload")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkullanilacaktablo

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bul_tabloadgore(ByVal tabload As String) As CLASSKULLANILACAKTABLO

        Dim komut As New SqlCommand
        Dim donecekkullanilacaktablo As New CLASSKULLANILACAKTABLO()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanilacaktablo where tabload=@tabload"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.tabload = veri.Item("tabload")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkullanilacaktablo

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim silinecek_kullanilacaktablo As New CLASSKULLANILACAKTABLO
        silinecek_kullanilacaktablo = bultek(pkey)


        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
        Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM


        Dim varmi_gosterilecekfield As String = gosterilecekfield_erisim.kullanilacaktablovarmi(silinecek_kullanilacaktablo.raporpkey, pkey)
        Dim varmi_kosulfield As String = kosulfield_erisim.kullanilacaktablovarmi(silinecek_kullanilacaktablo.raporpkey, pkey)
        Dim varmi_siralamafield As String = siralamafield_erisim.kullanilacaktablovarmi(silinecek_kullanilacaktablo.raporpkey, pkey)
        Dim varmi_aggfunc As String = aggfunc_erisim.kullanilacaktablovarmi(silinecek_kullanilacaktablo.raporpkey, pkey)


        If varmi_gosterilecekfield = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tablo gösterilecek alanlarda tanımlanmış. " + _
            "Bu sebepten bu tabloyu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_kosulfield = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tablo rapor koşullarında tanımlanmış. " + _
            "Bu sebepten bu tabloyu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_siralamafield = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tablo sıralama alanlarında tanımlanmış. " + _
            "Bu sebepten bu tabloyu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_aggfunc = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tablo rakamsal fonksiyonda tanımlanmış. " + _
            "Bu sebepten bu tabloyu silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kullanilacaktablo where pkey=@pkey"
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


    '---------------------------------sil-----------------------------------------
    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kullanilacaktablo where raporpkey=@raporpkey"
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
    Public Function doldur() As List(Of CLASSKULLANILACAKTABLO)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanilacaktablo As New CLASSKULLANILACAKTABLO
        Dim kullanilacaktabloler As New List(Of CLASSKULLANILACAKTABLO)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanilacaktablo"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.tabload = veri.Item("tabload")
                End If


                kullanilacaktabloler.Add(New CLASSKULLANILACAKTABLO(donecekkullanilacaktablo.pkey, _
                donecekkullanilacaktablo.raporpkey, donecekkullanilacaktablo.tabload))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullanilacaktabloler

    End Function



    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As String) As List(Of CLASSKULLANILACAKTABLO)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanilacaktablo As New CLASSKULLANILACAKTABLO
        Dim kullanilacaktabloler As New List(Of CLASSKULLANILACAKTABLO)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanilacaktablo where raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("tabload") Is System.DBNull.Value Then
                    donecekkullanilacaktablo.tabload = veri.Item("tabload")
                End If


                kullanilacaktabloler.Add(New CLASSKULLANILACAKTABLO(donecekkullanilacaktablo.pkey, _
                donecekkullanilacaktablo.raporpkey, donecekkullanilacaktablo.tabload))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullanilacaktabloler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        jvstring = "<script type='text/javascript'>" + _
          "$(document).ready(function() {" + _
              "$('.button').button();" + _
          "});" + _
          "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Rapor Adı</th>" + _
        "<th>Tablo Adı</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from kullanilacaktablo where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey, tabload As String
        Dim ajaxlinksil, dugmesil As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "kullanilacaktablo.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    End If

                    If Not veri.Item("tabload") Is System.DBNull.Value Then
                        tabload = veri.Item("tabload")
                        kol3 = "<td>" + tabload + "</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "kullanilacaktablosil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='kullanilacaktablosilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol4 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4

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
    Function ciftkayitkontrol(ByVal raporpkey As String, ByVal tabload As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanilacaktablo where raporpkey=@raporpkey and " + _
        "tabload=@tabload"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tabload", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tabload
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

        sqlstr = "select * from kullanilacaktablo where raporpkey=@raporpkey"

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


    Function varmibag(ByVal raporpkey As String, ByVal tablo1 As String, _
    ByVal tablo2 As String) As String

        Dim varmi As String = "yok"
        Dim birvar, ikivar As String
        birvar = "yok"
        ikivar = "yok"
        Dim kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
        kullanilacaktablolar = doldurilgili(raporpkey)

        For Each Item As CLASSKULLANILACAKTABLO In kullanilacaktablolar
            If Item.tabload = tablo1 Then
                birvar = "var"
            End If
            If Item.tabload = tablo2 Then
                ikivar = "var"
            End If
        Next

        If birvar = "var" And ikivar = "var" Then
            varmi = "var"
        End If

        Return varmi


    End Function

End Class