Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSGOSTERILECEKfield_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim gosterilecekfield As New CLASSGOSTERILECEKfield
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal gosterilecekfield As CLASSGOSTERILECEKfield) As CLADBOPRESULT


        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(gosterilecekfield.raporpkey, _
        gosterilecekfield.gosterilecektabload, gosterilecekfield.fieldad)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporda bu alan için zaten veritabanında kayıt vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into gosterilecekfield values (@pkey," + _
            "@raporpkey,@fieldad,@sqlalias,@raporalias," + _
            "@raporsira,@gosterilecektabload,@kullanilacaktablopkey,@ekkelime)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If gosterilecekfield.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = gosterilecekfield.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If gosterilecekfield.fieldad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = gosterilecekfield.fieldad
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@sqlalias", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If gosterilecekfield.sqlalias = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = gosterilecekfield.sqlalias
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@raporalias", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If gosterilecekfield.raporalias = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = gosterilecekfield.raporalias
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@raporsira", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If gosterilecekfield.raporsira = 0 Then
                param6.Value = 0
            Else
                param6.Value = gosterilecekfield.raporsira
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@gosterilecektabload", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If gosterilecekfield.gosterilecektabload = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = gosterilecekfield.gosterilecektabload
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
            param8.Direction = ParameterDirection.Input
            If gosterilecekfield.kullanilacaktablopkey = 0 Then
                param8.Value = 0
            Else
                param8.Value = gosterilecekfield.kullanilacaktablopkey
            End If
            komut.Parameters.Add(param8)


            Dim param9 As New SqlParameter("@ekkelime", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If gosterilecekfield.ekkelime = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = gosterilecekfield.ekkelime
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
        sqlstr = "select max(pkey) from gosterilecekfield"
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
    Function Duzenle(ByVal gosterilecekfield As CLASSGOSTERILECEKfield) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update gosterilecekfield set " + _
        "raporpkey=@raporpkey," + _
        "fieldad=@fieldad," + _
        "sqlalias=@sqlalias," + _
        "raporalias=@raporalias," + _
        "raporsira=@raporsira," + _
        "gosterilecektabload=@gosterilecektabload," + _
        "kullanilacaktablopkey=@kullanilacaktablopkey," + _
        "ekkelime=@ekkelime" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = gosterilecekfield.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If gosterilecekfield.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = gosterilecekfield.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If gosterilecekfield.fieldad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = gosterilecekfield.fieldad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sqlalias", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If gosterilecekfield.sqlalias = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = gosterilecekfield.sqlalias
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@raporalias", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If gosterilecekfield.raporalias = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = gosterilecekfield.raporalias
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@raporsira", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If gosterilecekfield.raporsira = 0 Then
            param6.Value = 0
        Else
            param6.Value = gosterilecekfield.raporsira
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@gosterilecektabload", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If gosterilecekfield.gosterilecektabload = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = gosterilecekfield.gosterilecektabload
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If gosterilecekfield.kullanilacaktablopkey = 0 Then
            param8.Value = 0
        Else
            param8.Value = gosterilecekfield.kullanilacaktablopkey
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@ekkelime", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If gosterilecekfield.ekkelime = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = gosterilecekfield.ekkelime
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
    Function bultek(ByVal pkey As String) As CLASSGOSTERILECEKfield

        Dim komut As New SqlCommand
        Dim donecekgosterilecekfield As New CLASSGOSTERILECEKfield()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from gosterilecekfield where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekgosterilecekfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sqlalias") Is System.DBNull.Value Then
                    donecekgosterilecekfield.sqlalias = veri.Item("sqlalias")
                End If

                If Not veri.Item("raporalias") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporalias = veri.Item("raporalias")
                End If

                If Not veri.Item("raporsira") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporsira = veri.Item("raporsira")
                End If

                If Not veri.Item("gosterilecektabload") Is System.DBNull.Value Then
                    donecekgosterilecekfield.gosterilecektabload = veri.Item("gosterilecektabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("ekkelime") Is System.DBNull.Value Then
                    donecekgosterilecekfield.ekkelime = veri.Item("ekkelime")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekgosterilecekfield

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        'bak baklalım bu alan için grupfield tanımlanmış mı
        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        Dim gosterilecekfield As New CLASSGOSTERILECEKfield
        gosterilecekfield = bultek(pkey)

        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM

        Dim varmi1 As String = grupfield_erisim.gosterilecekalanlardavarmi(pkey)
        Dim varmi2 As String = dinamikraporgrafik_erisim.kolonseriadvarmi(gosterilecekfield.raporpkey, gosterilecekfield.sqlalias)


        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu alan gruplamada kullanıldığından silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu alan grafikte kullanıldığından silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from gosterilecekfield where pkey=@pkey"
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

        'bak baklalım bu alan için grupfield tanımlanmış mı
        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from gosterilecekfield where raporpkey=@raporpkey"
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
    Public Function doldur() As List(Of CLASSGOSTERILECEKfield)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgosterilecekfield As New CLASSGOSTERILECEKfield
        Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
        komut.Connection = db_baglanti
        sqlstr = "select * from gosterilecekfield"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekgosterilecekfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sqlalias") Is System.DBNull.Value Then
                    donecekgosterilecekfield.sqlalias = veri.Item("sqlalias")
                End If

                If Not veri.Item("raporalias") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporalias = veri.Item("raporalias")
                End If

                If Not veri.Item("raporsira") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporsira = veri.Item("raporsira")
                End If

                If Not veri.Item("gosterilecektabload") Is System.DBNull.Value Then
                    donecekgosterilecekfield.gosterilecektabload = veri.Item("gosterilecektabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("ekkelime") Is System.DBNull.Value Then
                    donecekgosterilecekfield.ekkelime = veri.Item("ekkelime")
                End If

                gosterilecekfieldler.Add(New CLASSGOSTERILECEKfield(donecekgosterilecekfield.pkey, _
                donecekgosterilecekfield.raporpkey, donecekgosterilecekfield.fieldad, _
                donecekgosterilecekfield.sqlalias, donecekgosterilecekfield.raporalias, _
                donecekgosterilecekfield.raporsira,  donecekgosterilecekfield.gosterilecektabload, _
                donecekgosterilecekfield.kullanilacaktablopkey, donecekgosterilecekfield.ekkelime))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return gosterilecekfieldler

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As Integer) As List(Of CLASSGOSTERILECEKfield)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgosterilecekfield As New CLASSGOSTERILECEKfield
        Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
        komut.Connection = db_baglanti
        sqlstr = "select * from gosterilecekfield where raporpkey=@raporpkey order by raporsira"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekgosterilecekfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sqlalias") Is System.DBNull.Value Then
                    donecekgosterilecekfield.sqlalias = veri.Item("sqlalias")
                End If

                If Not veri.Item("raporalias") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporalias = veri.Item("raporalias")
                End If

                If Not veri.Item("raporsira") Is System.DBNull.Value Then
                    donecekgosterilecekfield.raporsira = veri.Item("raporsira")
                End If

                If Not veri.Item("gosterilecektabload") Is System.DBNull.Value Then
                    donecekgosterilecekfield.gosterilecektabload = veri.Item("gosterilecektabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekgosterilecekfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("ekkelime") Is System.DBNull.Value Then
                    donecekgosterilecekfield.ekkelime = veri.Item("ekkelime")
                Else
                    donecekgosterilecekfield.ekkelime = ""
                End If

                gosterilecekfieldler.Add(New CLASSGOSTERILECEKfield(donecekgosterilecekfield.pkey, _
                donecekgosterilecekfield.raporpkey, donecekgosterilecekfield.fieldad, _
                donecekgosterilecekfield.sqlalias, donecekgosterilecekfield.raporalias, _
                donecekgosterilecekfield.raporsira, donecekgosterilecekfield.gosterilecektabload, _
                donecekgosterilecekfield.kullanilacaktablopkey, donecekgosterilecekfield.ekkelime))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return gosterilecekfieldler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9 As String
        Dim fieldson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim ajaxlinksil, dugmesil As String

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
        "<th>Alan Adı</th>" + _
        "<th>SQL Takma Adı</th>" + _
        "<th>Raporda Gözükmesi Gereken Başlık Adı</th>" + _
        "<th>Raporda Gösterim Sırası</th>" + _
        "<th>Ek Kelime</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        fieldson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from gosterilecekfield where raporpkey=@raporpkey order by raporsira"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim pkey, raporpkey, fieldad, sqlalias, raporalias, raporsira, ekkelime As String
        Dim gosterilecektabload As String
        Dim link As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

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
                        "&gosterilecekalanop=duzenle" + _
                        "&gosterilecekfieldpkey=" + CStr(pkey)

                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    End If

                    If Not veri.Item("gosterilecektabload") Is System.DBNull.Value Then
                        gosterilecektabload = veri.Item("gosterilecektabload")
                        kol3 = "<td>" + gosterilecektabload + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldad") Is System.DBNull.Value Then
                        fieldad = veri.Item("fieldad")
                        kol4 = "<td>" + fieldad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("sqlalias") Is System.DBNull.Value Then
                        sqlalias = veri.Item("sqlalias")
                        kol5 = "<td>" + sqlalias + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("raporalias") Is System.DBNull.Value Then
                        raporalias = veri.Item("raporalias")
                        kol6 = "<td>" + raporalias + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("raporsira") Is System.DBNull.Value Then
                        raporsira = veri.Item("raporsira")
                        kol7 = "<td>" + CStr(raporsira) + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("ekkelime") Is System.DBNull.Value Then
                        ekkelime = veri.Item("ekkelime")
                        kol8 = "<td>" + CStr(ekkelime) + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "gosterilecekfieldsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='gosterilecekfieldsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol9 = "<td>" + dugmesil + "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + _
                    kol4 + kol5 + kol6 + kol7 + kol8 + kol9
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + fieldson + pager + jvstring
        End If

        Return (donecek)

    End Function


    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal raporpkey As Integer, ByVal gosterilecektabloaad As String, _
    ByVal fieldad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from gosterilecekfield where raporpkey=@raporpkey and " + _
        "gosterilecektabload=@gosterilecektabload and fieldad=@fieldad"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@gosterilecektabload", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = gosterilecektabloaad
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = fieldad
        komut.Parameters.Add(param3)


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

        sqlstr = "select * from gosterilecekfield where raporpkey=@raporpkey"

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


    Function kullanilacaktablovarmi(ByVal raporpkey As Integer, ByVal kullanilacaktablopkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from gosterilecekfield where raporpkey=@raporpkey and " + _
        "kullanilacaktablopkey=@kullanilacaktablopkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullanilacaktablopkey
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



    Public Function siralamagoster(ByVal raporpkey As String) As String

        Dim sqlstr As String
        Dim jvstring As String

        jvstring = "<script type='text/javascript'>" + _
                    "$(document).ready(function() {" + _
                        "$('#sortable').sortable({" + _
                            "placeholder:  'ui-state-highlight'," + _
                            "axis:   'y'," + _
                        "});" + _
                    "});" + _
                    "</script>"

        Dim istring As String
        Dim db_baglanti As SqlConnection

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim pkey, anakat, sira As String
        Dim str As String
        Dim strhepsi, strbas, strorta, strson As String
        Dim anakatpkey, raporalias As String


        strbas = "<ul id=sortable>"
        strson = "</ul>"
        strorta = ""


        sqlstr = "select * from gosterilecekfield where" + _
        " raporpkey=" + CStr(raporpkey) + " order by raporsira"
        komut = New SqlCommand(sqlstr, db_baglanti)
        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("pkey") Is System.DBNull.Value Then
                pkey = CStr(veri.Item("pkey"))
            End If

            If Not veri.Item("raporalias") Is System.DBNull.Value Then
                raporalias = veri.Item("raporalias")
            End If

            If Not veri.Item("raporsira") Is System.DBNull.Value Then
                sira = CStr(veri.Item("raporsira"))
            End If

            strorta = strorta + "<li id=" + Chr(34) + CStr(pkey) + Chr(34) + _
            " class=" + Chr(34) + "ui-state-default" + Chr(34) + ">" + raporalias + "</li>"

        End While

        db_baglanti.Close()

        strhepsi = strbas + strorta + strson + jvstring
        Return strhepsi


    End Function


    Public Function siralamayap(ByVal raporpkey As Integer, ByVal degerler As String) As String

        Dim sqlstr As String
        Dim i As String
        Dim x As Integer
        Dim varmi As Integer

        varmi = InStr(degerler, ",", CompareMethod.Text)
        Dim words As String() = degerler.Split(New Char() {","c})

        Dim kactane As String = kactanevar(raporpkey)

        Dim siralar(kactane) As String

        i = 0
        Dim word As String
        For Each word In words
            siralar(i) = word
            i = i + 1
        Next

        Dim istring As String
        Dim db_baglanti As SqlConnection
        Dim db_baglanti2 As SqlConnection

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        db_baglanti2 = New SqlConnection(istring)
        db_baglanti2.Open()

        Dim komut As SqlCommand
        Dim komut2 As SqlCommand
        Dim veri As SqlDataReader
        Dim pkey, baslik, sira As String
        Dim str As String

        sqlstr = "select * from gosterilecekfield where raporpkey=@raporpkey " + _
        " order by raporsira"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        veri = komut.ExecuteReader

        x = 0

        For Each word In words

            sqlstr = "update gosterilecekfield set " + _
            "raporsira=@raporsira" + _
            " where pkey=@pkey"

            komut2 = New SqlCommand(sqlstr, db_baglanti2)

            komut2.Parameters.Add("@raporsira", SqlDbType.Int)
            komut2.Parameters("@raporsira").Value = x

            komut2.Parameters.Add("@pkey", SqlDbType.Int)
            komut2.Parameters("@pkey").Value = word

            komut2.ExecuteNonQuery()
            x = x + 1

        Next

        db_baglanti.Close()
        db_baglanti2.Close()

    End Function



    Private Function kactanevar(ByVal raporpkey As Integer) As Integer

        Dim sqlstr As String
        Dim kactane As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from gosterilecekfield where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kactane = 0
        Else
            kactane = maxkayit1
        End If

        db_baglanti.Close()

        Return kactane

    End Function

End Class


