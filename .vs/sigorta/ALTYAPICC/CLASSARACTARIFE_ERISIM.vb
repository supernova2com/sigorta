Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSARACTARIFE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal aractarife As CLASSARACTARIFE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("tarifekod", aractarife.tarifekod)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tarife koduyla ilgili halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into aractarife values (@pkey," + _
            "@tarifekod,@tarifead)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@tarifekod", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If aractarife.tarifekod = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = UCase(aractarife.tarifekod)
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tarifead", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If aractarife.tarifead = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = aractarife.tarifead
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
        sqlstr = "select max(pkey) from aractarife"
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
    Function Duzenle(ByVal aractarife As CLASSARACTARIFE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update aractarife set " + _
        "tarifekod=@tarifekod," + _
        "tarifead=@tarifead" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aractarife.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarifekod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If aractarife.tarifekod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = UCase(aractarife.tarifekod)
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tarifead", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If aractarife.tarifead = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = aractarife.tarifead
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
    Function bultek(ByVal pkey As String) As CLASSARACTARIFE

        Dim komut As New SqlCommand
        Dim donecekaractarife As New CLASSARACTARIFE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aractarife where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaractarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarifekod") Is System.DBNull.Value Then
                    donecekaractarife.tarifekod = veri.Item("tarifekod")
                End If

                If Not veri.Item("tarifead") Is System.DBNull.Value Then
                    donecekaractarife.tarifead = veri.Item("tarifead")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekaractarife

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultarifekodagore(ByVal tarifekod As String) As CLASSARACTARIFE

        Dim komut As New SqlCommand
        Dim donecekaractarife As New CLASSARACTARIFE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aractarife where tarifekod=@tarifekod"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tarifekod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tarifekod
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaractarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarifekod") Is System.DBNull.Value Then
                    donecekaractarife.tarifekod = veri.Item("tarifekod")
                End If

                If Not veri.Item("tarifead") Is System.DBNull.Value Then
                    donecekaractarife.tarifead = veri.Item("tarifead")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekaractarife

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim tarifedaire_erisim As New CLASSTARIFEDAIREBAG_ERISIM
        Dim tarifesinirkapibag_erisim As New CLASSTARIFESINIRKAPIBAG_ERISIM

        Dim varmi1, varmi2 As String

        varmi1 = tarifedaire_erisim.tarifevarmi(pkey)
        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tarife kodu araç kayıt dairesi eşleşmesinde kullanılıyor."
            resultset.etkilenen = 0
            Return resultset
        End If

        varmi2 = tarifesinirkapibag_erisim.varmitarife(pkey)
        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu tarife kodu sınır kapısı araç tipi eşleşmesinde kullanılıyor."
            resultset.etkilenen = 0
            Return resultset
        End If



        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from aractarife where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSARACTARIFE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaractarife As New CLASSARACTARIFE
        Dim aractarifeler As New List(Of CLASSARACTARIFE)
        komut.Connection = db_baglanti
        sqlstr = "select * from aractarife"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaractarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarifekod") Is System.DBNull.Value Then
                    donecekaractarife.tarifekod = veri.Item("tarifekod")
                End If

                If Not veri.Item("tarifead") Is System.DBNull.Value Then
                    donecekaractarife.tarifead = veri.Item("tarifead")
                End If


                aractarifeler.Add(New CLASSARACTARIFE(donecekaractarife.pkey, _
                donecekaractarife.tarifekod, donecekaractarife.tarifead))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aractarifeler

    End Function

    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSARACTARIFE)

        Dim sqls, istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaractarife As New CLASSARACTARIFE
        Dim aractarifeler As New List(Of CLASSARACTARIFE)
        komut.Connection = db_baglanti

        sqlstr = "select * from aractarife where " + tablecol + " LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaractarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarifekod") Is System.DBNull.Value Then
                    donecekaractarife.tarifekod = veri.Item("tarifekod")
                End If

                If Not veri.Item("tarifead") Is System.DBNull.Value Then
                    donecekaractarife.tarifead = veri.Item("tarifead")
                End If


                aractarifeler.Add(New CLASSARACTARIFE(donecekaractarife.pkey, _
                donecekaractarife.tarifekod, donecekaractarife.tarifead))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aractarifeler

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
        "<th>Tarife Kodu</th>" + _
        "<th>Tarife Adı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from aractarife"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "tarifekod" Then
            sqlstr = "select * from aractarife where tarifekod LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If


        If HttpContext.Current.Session("ltip") = "tarifead" Then
            sqlstr = "select * from aractarife where tarifead LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, tarifekod, tarifead As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "aractarifepopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("tarifekod") Is System.DBNull.Value Then
                        tarifekod = veri.Item("tarifekod")
                        kol2 = "<td>" + tarifekod + "</td>"
                    End If

                    If Not veri.Item("tarifead") Is System.DBNull.Value Then
                        tarifead = veri.Item("tarifead")
                        kol3 = "<td>" + tarifead + "</td></tr>"
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

        sqlstr = "select * from aractarife where " + tablecol + "=@kriter"

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


    Function kodvarmi(ByVal tarifekod As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aractarife where tarifekod=@tarifekod"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tarifekod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tarifekod
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


