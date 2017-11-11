Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSARACMODEL_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aracmodel As New CLASSARACMODEL
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal aracmodel As CLASSARACMODEL) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(aracmodel.araccinspkey, aracmodel.aracmarkapkey, aracmodel.modelad)

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
            sqlstr = "insert into aracmodel values (@pkey," + _
            "@araccinspkey,@aracmarkapkey,@modelad)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@araccinspkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If aracmodel.araccinspkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = aracmodel.araccinspkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If aracmodel.aracmarkapkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = aracmodel.aracmarkapkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@modelad", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If aracmodel.modelad = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = aracmodel.modelad
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
        sqlstr = "select max(pkey) from aracmodel"
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
    Function Duzenle(ByVal aracmodel As CLASSARACMODEL) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update aracmodel set " + _
        "araccinspkey=@araccinspkey," + _
        "aracmarkapkey=@aracmarkapkey," + _
        "modelad=@modelad" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aracmodel.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If aracmodel.araccinspkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = aracmodel.araccinspkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If aracmodel.aracmarkapkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = aracmodel.aracmarkapkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@modelad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If aracmodel.modelad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = aracmodel.modelad
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
    Function bultek(ByVal pkey As String) As CLASSARACMODEL

        Dim komut As New SqlCommand
        Dim donecekaracmodel As New CLASSARACMODEL()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aracmodel where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaracmodel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekaracmodel.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                    donecekaracmodel.aracmarkapkey = veri.Item("aracmarkapkey")
                End If

                If Not veri.Item("modelad") Is System.DBNull.Value Then
                    donecekaracmodel.modelad = veri.Item("modelad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekaracmodel

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
        Dim varmi_pertarac As String = pertarac_erisim.aracmodelvarmi(pkey)

        If varmi_pertarac = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araç modelini kullanan pert araç kayıtları var.  " + _
            "Bu sebepten bu araç modelini silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from aracmodel where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSARACMODEL)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaracmodel As New CLASSARACMODEL
        Dim aracmodeller As New List(Of CLASSARACMODEL)
        komut.Connection = db_baglanti
        sqlstr = "select * from aracmodel"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaracmodel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekaracmodel.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                    donecekaracmodel.aracmarkapkey = veri.Item("aracmarkapkey")
                End If

                If Not veri.Item("modelad") Is System.DBNull.Value Then
                    donecekaracmodel.modelad = veri.Item("modelad")
                End If


                aracmodeller.Add(New CLASSARACMODEL(donecekaracmodel.pkey, _
                donecekaracmodel.araccinspkey, donecekaracmodel.aracmarkapkey, donecekaracmodel.modelad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aracmodeller

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_cinsvemarkayagore(ByVal araccinspkey As Integer, _
    ByVal aracmarkapkey As Integer) As List(Of CLASSARACMODEL)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaracmodel As New CLASSARACMODEL
        Dim aracmodeller As New List(Of CLASSARACMODEL)
        komut.Connection = db_baglanti
        sqlstr = "select * from aracmodel where " + _
        "araccinspkey=@araccinspkey and aracmarkapkey=@aracmarkapkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = araccinspkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = aracmarkapkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaracmodel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekaracmodel.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                    donecekaracmodel.aracmarkapkey = veri.Item("aracmarkapkey")
                End If

                If Not veri.Item("modelad") Is System.DBNull.Value Then
                    donecekaracmodel.modelad = veri.Item("modelad")
                End If


                aracmodeller.Add(New CLASSARACMODEL(donecekaracmodel.pkey, _
                donecekaracmodel.araccinspkey, donecekaracmodel.aracmarkapkey, _
                donecekaracmodel.modelad))


            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aracmodeller

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
        "<th>Araç Cinsi</th>" + _
        "<th>Araç Markası</th>" + _
        "<th>Araç Modeli</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from aracmodel order by modelad"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, araccinspkey, aracmarkapkey, modelad As String

        Dim araccins As New CLASSARACCINS
        Dim araccins_erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "aracmodel.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                        araccinspkey = veri.Item("araccinspkey")
                        araccins = araccins_erisim.bultek(araccinspkey)
                        kol2 = "<td>" + araccins.cinsad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                        aracmarkapkey = veri.Item("aracmarkapkey")
                        aracmarka = aracmarka_erisim.bultek(aracmarkapkey)
                        kol3 = "<td>" + aracmarka.markaad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("modelad") Is System.DBNull.Value Then
                        modelad = veri.Item("modelad")
                        kol4 = "<td>" + modelad + "</td></tr>"
                    Else
                        kol4 = "<td>-</td></tr>"
                    End If

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
    Function ciftkayitkontrol(ByVal araccinspkey As String, ByVal aracmarkapkey As String, _
    ByVal modelad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aracmodel where araccinspkey=@araccinspkey and " + _
        "aracmarkapkey=@aracmarkapkey and " + _
        "modelad=@modelad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = araccinspkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = aracmarkapkey
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@modelad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = modelad
        komut.Parameters.Add(param3)


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

        sqlstr = "select * from aracmodel where araccinspkey=@araccinspkey"

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


    Function aracmarkavarmi(ByVal aracmarkapkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aracmodel where aracmarkapkey=@aracmarkapkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aracmarkapkey
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


