Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSTABLOBAG_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim tablobag As New CLASStablobag
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal tablobag As CLASSTABLOBAG) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(tablobag.tabload1, tablobag.tablofield1, _
        tablobag.tabload2, tablobag.tablofield2)

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
            sqlstr = "insert into tablobag values (@pkey," + _
            "@tabload1,@tablofield1,@tabload2,@tablofield2)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@tabload1", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If tablobag.tabload1 = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = tablobag.tabload1
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tablofield1", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If tablobag.tablofield1 = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = tablobag.tablofield1
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@tabload2", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If tablobag.tabload2 = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = tablobag.tabload2
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@tablofield2", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If tablobag.tablofield2 = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = tablobag.tablofield2
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
        sqlstr = "select max(pkey) from tablobag"
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
    Function Duzenle(ByVal tablobag As CLASSTABLOBAG) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update tablobag set " + _
        "tabload1=@tabload1," + _
        "tablofield1=@tablofield1," + _
        "tabload2=@tabload2," + _
        "tablofield2=@tablofield2" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tablobag.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tabload1", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If tablobag.tabload1 = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = tablobag.tabload1
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tablofield1", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If tablobag.tablofield1 = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = tablobag.tablofield1
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tabload2", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If tablobag.tabload2 = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = tablobag.tabload2
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tablofield2", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If tablobag.tablofield2 = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = tablobag.tablofield2
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
    Function bultek(ByVal pkey As String) As CLASStablobag

        Dim komut As New SqlCommand
        Dim donecektablobag As New CLASStablobag()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tablobag where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektablobag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tabload1") Is System.DBNull.Value Then
                    donecektablobag.tabload1 = veri.Item("tabload1")
                End If

                If Not veri.Item("tablofield1") Is System.DBNull.Value Then
                    donecektablobag.tablofield1 = veri.Item("tablofield1")
                End If

                If Not veri.Item("tabload2") Is System.DBNull.Value Then
                    donecektablobag.tabload2 = veri.Item("tabload2")
                End If

                If Not veri.Item("tablofield2") Is System.DBNull.Value Then
                    donecektablobag.tablofield2 = veri.Item("tablofield2")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecektablobag

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from tablobag where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASStablobag)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecektablobag As New CLASStablobag
        Dim tablobagler As New List(Of CLASStablobag)
        komut.Connection = db_baglanti
        sqlstr = "select * from tablobag"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecektablobag.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tabload1") Is System.DBNull.Value Then
                    donecektablobag.tabload1 = veri.Item("tabload1")
                End If

                If Not veri.Item("tablofield1") Is System.DBNull.Value Then
                    donecektablobag.tablofield1 = veri.Item("tablofield1")
                End If

                If Not veri.Item("tabload2") Is System.DBNull.Value Then
                    donecektablobag.tabload2 = veri.Item("tabload2")
                End If

                If Not veri.Item("tablofield2") Is System.DBNull.Value Then
                    donecektablobag.tablofield2 = veri.Item("tablofield2")
                End If


                tablobagler.Add(New CLASSTABLOBAG(donecektablobag.pkey, _
                donecektablobag.tabload1, donecektablobag.tablofield1, _
                donecektablobag.tabload2, donecektablobag.tablofield2))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return tablobagler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        jvstring = "<script type='text/javascript'>" + _
              "$(document).ready(function() {" + _
                  "$('.button').button();" + _
              "});" + _
        "</script>"

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Ana Tablo Adı</th>" + _
        "<th>Ana Tablo Kolonu</th>" + _
        "<th>Detay Tablo</th>" + _
        "<th>Detay Tablo Kolonu</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from tablobag"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, tabload1, tablofield1, tabload2, tablofield2 As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "tablobag.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("tabload1") Is System.DBNull.Value Then
                        tabload1 = veri.Item("tabload1")
                        kol2 = "<td>" + tabload1 + "</td>"
                    End If

                    If Not veri.Item("tablofield1") Is System.DBNull.Value Then
                        tablofield1 = veri.Item("tablofield1")
                        kol3 = "<td>" + tablofield1 + "</td>"
                    End If

                    If Not veri.Item("tabload2") Is System.DBNull.Value Then
                        tabload2 = veri.Item("tabload2")
                        kol4 = "<td>" + tabload2 + "</td>"
                    End If

                    If Not veri.Item("tablofield2") Is System.DBNull.Value Then
                        tablofield2 = veri.Item("tablofield2")
                        kol5 = "<td>" + tablofield2 + "</td></tr>"
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

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tabload1 As String, ByVal tablofield1 As String, _
                              ByVal tabload2 As String, ByVal tablofield2 As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tablobag where tabload1=@tabload1 and " + _
        "tablofield1=@tablofield1 and tabload2=@tabload2 and tablofield2=@tablofield2"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload1", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload1
        komut.Parameters.Add(param1)


        Dim param2 As New SqlParameter("@tablofield1", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tablofield1
        komut.Parameters.Add(param2)


        Dim param3 As New SqlParameter("@tabload2", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = tabload2
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@tablofield2", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = tablofield2
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


    Function tabloiliskilimi(ByVal tabload1 As String, ByVal tabload2 As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tablobag where (tabload1=@tabload1 and tabload2=@tabload2) or " + _
        "(tabload1=@tabload2 and tabload2=@tabload1)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload1", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tabload1
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tabload2", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tabload2
        komut.Parameters.Add(param2)

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


    Function bagsqlolustur(ByVal p_tabload1 As String, ByVal p_tabload2 As String) As String

        Dim bagsql As String = ""

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from tablobag where (tabload1=@tabload1 and tabload2=@tabload2)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tabload1", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = p_tabload1
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tabload2", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = p_tabload2
        komut.Parameters.Add(param2)

        Dim tabload1, tablofield1, tabload2, tablofield2 As String

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("tabload1") Is System.DBNull.Value Then
                    tabload1 = veri.Item("tabload1")
                Else
                    tabload1 = ""
                End If
                If Not veri.Item("tablofield1") Is System.DBNull.Value Then
                    tablofield1 = veri.Item("tablofield1")
                Else
                    tablofield1 = ""
                End If

                If Not veri.Item("tabload2") Is System.DBNull.Value Then
                    tabload2 = veri.Item("tabload2")
                Else
                    tabload2 = ""
                End If

                If Not veri.Item("tablofield2") Is System.DBNull.Value Then
                    tablofield2 = veri.Item("tablofield2")
                Else
                    tablofield2 = 0
                End If

                bagsql = bagsql + tabload1 + "." + tablofield1 + "=" + tabload2 + "." + tablofield2 + " and "

            End While
        End Using

        If Len(bagsql) > 4 Then
            bagsql = Mid(bagsql, 1, Len(bagsql) - 4)
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return bagsql

    End Function



    'FOREIGN KEY BAĞLAR---------------------------------------------- 
    Public Function foreignkeybagsqlolustur(ByVal tablolar As List(Of CLASSTEK)) As String

        Dim ktablo1, ktablo2 As String
        Dim sqlforeigndevam As String
        Dim kullanılacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
        Dim varmi As String
        Dim tablobaglar As New List(Of CLASSTABLOBAG)
        Dim tablobag_erisim As New CLASSTABLOBAG_ERISIM
        tablobaglar = tablobag_erisim.doldur()

        For Each itemtablo1 As CLASSTEK In tablolar
            ktablo1 = itemtablo1.ad
            For Each itemtablo2 As CLASSTEK In tablolar
                ktablo2 = itemtablo2.ad
                'BAĞLAR
                If ktablo1 <> ktablo2 Then
                    sqlforeigndevam = sqlforeigndevam + bagsqlolustur(ktablo1, ktablo2)
                End If
            Next
        Next

        Return sqlforeigndevam


    End Function

End Class
