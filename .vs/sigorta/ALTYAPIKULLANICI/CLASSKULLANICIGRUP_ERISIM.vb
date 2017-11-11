Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSKULLANICIGRUP_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kullanicigrup As New CLASSKULLANICIGRUP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kullanicigrup As CLASSKULLANICIGRUP) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("grupad", kullanicigrup.grupad)

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

            sqlstr = "insert into kullanicigrup values (@pkey," + _
            "@grupad,@grupsirkettarafindasecilebilsinmi)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@grupad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If kullanicigrup.grupad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = kullanicigrup.grupad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@grupsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If kullanicigrup.grupsirkettarafindasecilebilsinmi = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = kullanicigrup.grupsirkettarafindasecilebilsinmi
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
        sqlstr = "select max(pkey) from kullanicigrup"
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
    Function Duzenle(ByVal kullanicigrup As CLASSKULLANICIGRUP) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kullanicigrup set " + _
        "grupad=@grupad," + _
        "grupsirkettarafindasecilebilsinmi=@grupsirkettarafindasecilebilsinmi" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicigrup.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@grupad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If kullanicigrup.grupad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = kullanicigrup.grupad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@grupsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kullanicigrup.grupsirkettarafindasecilebilsinmi = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kullanicigrup.grupsirkettarafindasecilebilsinmi
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
    Function bultek(ByVal pkey As String) As CLASSKULLANICIGRUP

        Dim komut As New SqlCommand
        Dim donecekkullanicigrup As New CLASSKULLANICIGRUP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanicigrup where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicigrup.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("grupad") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupad = veri.Item("grupad")
                End If

                If Not veri.Item("grupsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupsirkettarafindasecilebilsinmi = veri.Item("grupsirkettarafindasecilebilsinmi")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekkullanicigrup

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim varmi As String
        varmi = kullanici_erisim.kullanicigrupvarmi(pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kullanıcı grubunda tanımlı " + _
            "kullanıcılar olduğundan bu kullanıcı grubunu silemezsiniz."
            resultset.etkilenen = 0
        End If


        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "delete from kullanicigrup where pkey=@pkey"
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

        End If

        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSKULLANICIGRUP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicigrup As New CLASSKULLANICIGRUP
        Dim kullanicigrupler As New List(Of CLASSKULLANICIGRUP)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicigrup"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicigrup.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("grupad") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupad = veri.Item("grupad")
                End If


                If Not veri.Item("grupsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupsirkettarafindasecilebilsinmi = veri.Item("grupsirkettarafindasecilebilsinmi")
                End If

                kullanicigrupler.Add(New CLASSKULLANICIGRUP(donecekkullanicigrup.pkey, _
                donecekkullanicigrup.grupad, donecekkullanicigrup.grupsirkettarafindasecilebilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullanicigrupler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_sirkettaraficin() As List(Of CLASSKULLANICIGRUP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicigrup As New CLASSKULLANICIGRUP
        Dim kullanicigrupler As New List(Of CLASSKULLANICIGRUP)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicigrup where " + _
        "grupsirkettarafindasecilebilsinmi=@grupsirkettarafindasecilebilsinmi"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@grupsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Evet"
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicigrup.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("grupad") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupad = veri.Item("grupad")
                End If

                If Not veri.Item("grupsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupsirkettarafindasecilebilsinmi = veri.Item("grupsirkettarafindasecilebilsinmi")
                End If

                kullanicigrupler.Add(New CLASSKULLANICIGRUP(donecekkullanicigrup.pkey, _
                donecekkullanicigrup.grupad, donecekkullanicigrup.grupsirkettarafindasecilebilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullanicigrupler

    End Function

    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSKULLANICIGRUP)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicigrup As New CLASSKULLANICIGRUP
        Dim kullanicigrupler As New List(Of CLASSKULLANICIGRUP)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicigrup where " + tablecol + " LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicigrup.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("grupad") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupad = veri.Item("grupad")
                End If

                If Not veri.Item("grupsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicigrup.grupsirkettarafindasecilebilsinmi = veri.Item("grupsirkettarafindasecilebilsinmi")
                End If

                kullanicigrupler.Add(New CLASSKULLANICIGRUP(donecekkullanicigrup.pkey, _
                donecekkullanicigrup.grupad, donecekkullanicigrup.grupsirkettarafindasecilebilsinmi))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullanicigrupler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
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
        "<th>Grup Adı</th>" + _
        "<th>Şirket Tarafında Seçilebilecek mi?</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then

            sqlstr = "select * from kullanicigrup"
            komut = New SqlCommand(sqlstr, db_baglanti)

        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, grupad, grupsirkettarafindasecilebilsinmi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "kullanicigrup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("grupad") Is System.DBNull.Value Then
                        grupad = veri.Item("grupad")
                        kol2 = "<td>" + grupad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("grupsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                        grupsirkettarafindasecilebilsinmi = veri.Item("grupsirkettarafindasecilebilsinmi")
                        kol3 = "<td>" + grupsirkettarafindasecilebilsinmi + "</td></tr>"
                    Else
                        kol3 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3

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
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanicigrup where " + tablecol + "=@kriter"

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

