Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSARACMARKA_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aracmarka As New CLASSARACMARKA
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal aracmarka As CLASSARACMARKA) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(aracmarka.araccinspkey, aracmarka.markaad)

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
            sqlstr = "insert into aracmarka values (@pkey," + _
            "@araccinspkey,@markaad)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@araccinspkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If aracmarka.araccinspkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = aracmarka.araccinspkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@markaad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If aracmarka.markaad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = aracmarka.markaad
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
        sqlstr = "select max(pkey) from aracmarka"
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
    Function Duzenle(ByVal aracmarka As CLASSARACMARKA) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update aracmarka set " + _
        "araccinspkey=@araccinspkey," + _
        "markaad=@markaad" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aracmarka.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If aracmarka.araccinspkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = aracmarka.araccinspkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@markaad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If aracmarka.markaad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = aracmarka.markaad
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
    Function bultek(ByVal pkey As String) As CLASSARACMARKA

        Dim komut As New SqlCommand
        Dim donecekaracmarka As New CLASSARACMARKA()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aracmarka where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaracmarka.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekaracmarka.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("markaad") Is System.DBNull.Value Then
                    donecekaracmarka.markaad = veri.Item("markaad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekaracmarka

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM


        Dim varmi_aracmodelde As String = aracmodel_erisim.aracmarkavarmi(pkey)
        Dim varmi_pertarac As String = pertarac_erisim.aracmarkavarmi(pkey)

        If varmi_aracmodelde = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araç markasını kullanan araç modelleri var.  " + _
            "Bu sebepten bu araç markasını silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_pertarac = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araç markasını kullanan pert araç kayıtları var.  " + _
            "Bu sebepten bu araç markasını silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from aracmarka where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSARACMARKA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaracmarka As New CLASSARACMARKA
        Dim aracmarkaler As New List(Of CLASSARACMARKA)
        komut.Connection = db_baglanti
        sqlstr = "select * from aracmarka"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaracmarka.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekaracmarka.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("markaad") Is System.DBNull.Value Then
                    donecekaracmarka.markaad = veri.Item("markaad")
                End If


                aracmarkaler.Add(New CLASSARACMARKA(donecekaracmarka.pkey, _
                donecekaracmarka.araccinspkey, donecekaracmarka.markaad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aracmarkaler

    End Function


    Public Function doldur_araccinsgore(ByVal araccinspkey As Integer) As List(Of CLASSARACMARKA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaracmarka As New CLASSARACMARKA
        Dim aracmarkaler As New List(Of CLASSARACMARKA)
        komut.Connection = db_baglanti
        sqlstr = "select * from aracmarka where araccinspkey=@araccinspkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = araccinspkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaracmarka.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekaracmarka.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("markaad") Is System.DBNull.Value Then
                    donecekaracmarka.markaad = veri.Item("markaad")
                End If


                aracmarkaler.Add(New CLASSARACMARKA(donecekaracmarka.pkey, _
                donecekaracmarka.araccinspkey, donecekaracmarka.markaad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aracmarkaler

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
        "<th>Araç Cinsi</th>" + _
        "<th>Markası</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from aracmarka order by markaad"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, araccinspkey, markaad As String

        Dim araccins As New CLASSARACCINS
        Dim araccins_erisim As New CLASSARACCINS_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "aracmarka.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                        araccinspkey = veri.Item("araccinspkey")
                        araccins = araccins_erisim.bultek(araccinspkey)
                        kol2 = "<td>" + araccins.cinsad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("markaad") Is System.DBNull.Value Then
                        markaad = veri.Item("markaad")
                        kol3 = "<td>" + markaad + "</td></tr>"
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
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal araccinspkey As String, ByVal markaad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aracmarka where araccinspkey=@araccinspkey and markaad=@markaad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = araccinspkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@markaad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = markaad
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function araccinsvarmi(ByVal araccinspkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aracmarka where araccinspkey=@araccinspkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = araccinspkey
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

End Class


