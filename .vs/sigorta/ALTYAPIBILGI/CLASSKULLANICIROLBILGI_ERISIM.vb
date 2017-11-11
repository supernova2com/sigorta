Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO

Public Class CLASSKULLANICIROLBILGI_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kullanicirolbilgi As CLASSKULLANICIROLBILGI) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("pkey", kullanicirolbilgi.pkey)

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
            sqlstr = "insert into kullanicirolbilgi values (@pkey," + _
            "@rolad,@yonsayfa,@anamenupkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@rolad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If kullanicirolbilgi.rolad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = kullanicirolbilgi.rolad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@yonsayfa", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If kullanicirolbilgi.yonsayfa = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = kullanicirolbilgi.yonsayfa
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@anamenupkey", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If kullanicirolbilgi.anamenupkey = 0 Then
                param4.Value = 0
            Else
                param4.Value = kullanicirolbilgi.anamenupkey
            End If
            komut.Parameters.Add(param4)

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
        sqlstr = "select max(pkey) from kullanicirolbilgi"
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
    Function Duzenle(ByVal kullanicirolbilgi As CLASSKULLANICIROLBILGI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kullanicirolbilgi set " + _
        "rolad=@rolad," + _
        "yonsayfa=@yonsayfa," + _
        "anamenupkey=@anamenupkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirolbilgi.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@rolad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If kullanicirolbilgi.rolad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = kullanicirolbilgi.rolad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@yonsayfa", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kullanicirolbilgi.yonsayfa = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kullanicirolbilgi.yonsayfa
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If kullanicirolbilgi.anamenupkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = kullanicirolbilgi.anamenupkey
        End If
        komut.Parameters.Add(param4)


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
    Function bultek(ByVal pkey As String) As CLASSKULLANICIROLBILGI

        Dim komut As New SqlCommand
        Dim donecekkullanicirolbilgi As New CLASSkullanicirolbilgi()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanicirolbilgi where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("rolad") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.rolad = veri.Item("rolad")
                End If

                If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.yonsayfa = veri.Item("yonsayfa")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.anamenupkey = veri.Item("anamenupkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkullanicirolbilgi

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kullanicirolbilgi where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSKULLANICIROLBILGI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicirolbilgi As New CLASSkullanicirolbilgi
        Dim kullanicirolbilgiler As New List(Of CLASSkullanicirolbilgi)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicirolbilgi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("rolad") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.rolad = veri.Item("rolad")
                End If

                If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.yonsayfa = veri.Item("yonsayfa")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekkullanicirolbilgi.anamenupkey = veri.Item("anamenupkey")
                End If


                kullanicirolbilgiler.Add(New CLASSkullanicirolbilgi(donecekkullanicirolbilgi.pkey, _
                donecekkullanicirolbilgi.rolad, donecekkullanicirolbilgi.yonsayfa, donecekkullanicirolbilgi.anamenupkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullanicirolbilgiler

    End Function

    
    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
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
        "<th>Rol Adı</th>" + _
        "<th>Yönlendirileceği Sayfa</th>" + _
        "<th>Menusü</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from kullanicirolbilgi"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim linkyetki As String
        Dim pkey, rolad, yonsayfa, anamenupkey As String
        Dim anamenu As New CLASSANAMENU
        Dim anamunu_erisim As New CLASSANAMENU_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        link = "kullanicirolbilgi.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        linkyetki = "yetkigirispopupbilgi.aspx?kullanicirolpkey=" + CStr(pkey)

                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "<br/><br/>" + _
                        javascript.yetkibuttonyarat(linkyetki) + "</td>"

                    End If

                    If Not veri.Item("rolad") Is System.DBNull.Value Then
                        rolad = veri.Item("rolad")
                        kol2 = "<td>" + rolad + "</td>"
                    End If

                    If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                        yonsayfa = veri.Item("yonsayfa")
                        kol3 = "<td>" + yonsayfa + "</td>"
                    End If

                    If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                        anamenupkey = veri.Item("anamenupkey")
                        anamenu = anamunu_erisim.bultek(anamenupkey)
                        kol4 = "<td>" + anamenu.ad + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4
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

        sqlstr = "select * from kullanicirolbilgi where " + tablecol + "=@kriter"

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

End Class
