Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSGENERICSERVISOUTPUT_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim genericservisoutput As New CLASSGENERICSERVISOUTPUT
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal genericservisoutput As CLASSGENERICSERVISOUTPUT) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(genericservisoutput.outputparamname, genericservisoutput.genericservispkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu parametre halihazırda tanımlanmış."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into genericservisoutput values (@pkey," + _
            "@genericservispkey,@outputparamname)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@genericservispkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If genericservisoutput.genericservispkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = genericservisoutput.genericservispkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@outputparamname", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If genericservisoutput.outputparamname = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = genericservisoutput.outputparamname
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
        sqlstr = "select max(pkey) from genericservisoutput"
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
    Function Duzenle(ByVal genericservisoutput As CLASSGENERICSERVISOUTPUT) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update genericservisoutput set " + _
        "genericservispkey=@genericservispkey," + _
        "outputparamname=@outputparamname" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservisoutput.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If genericservisoutput.genericservispkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = genericservisoutput.genericservispkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@outputparamname", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If genericservisoutput.outputparamname = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = genericservisoutput.outputparamname
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
    Function bultek(ByVal pkey As String) As CLASSGENERICSERVISOUTPUT

        Dim komut As New SqlCommand
        Dim donecekgenericservisoutput As New CLASSGENERICSERVISOUTPUT()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericservisoutput where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericservisoutput.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                    donecekgenericservisoutput.genericservispkey = veri.Item("genericservispkey")
                End If

                If Not veri.Item("outputparamname") Is System.DBNull.Value Then
                    donecekgenericservisoutput.outputparamname = veri.Item("outputparamname")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekgenericservisoutput

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from genericservisoutput where pkey=@pkey"
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
    Public Function sililgili(ByVal genericservispkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from genericservisoutput where genericservispkey=@genericservispkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservispkey
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
    Public Function doldur() As List(Of CLASSGENERICSERVISOUTPUT)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgenericservisoutput As New CLASSGENERICSERVISOUTPUT
        Dim genericservisoutputler As New List(Of CLASSGENERICSERVISOUTPUT)
        komut.Connection = db_baglanti
        sqlstr = "select * from genericservisoutput"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericservisoutput.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                    donecekgenericservisoutput.genericservispkey = veri.Item("genericservispkey")
                End If

                If Not veri.Item("outputparamname") Is System.DBNull.Value Then
                    donecekgenericservisoutput.outputparamname = veri.Item("outputparamname")
                End If


                genericservisoutputler.Add(New CLASSGENERICSERVISOUTPUT(donecekgenericservisoutput.pkey, _
                donecekgenericservisoutput.genericservispkey, donecekgenericservisoutput.outputparamname))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return genericservisoutputler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal genericservispkey As String) As List(Of CLASSGENERICSERVISOUTPUT)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgenericservisoutput As New CLASSGENERICSERVISOUTPUT
        Dim genericservisoutputler As New List(Of CLASSGENERICSERVISOUTPUT)
        komut.Connection = db_baglanti
        sqlstr = "select * from genericservisoutput where genericservispkey=@genericservispkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservispkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgenericservisoutput.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                    donecekgenericservisoutput.genericservispkey = veri.Item("genericservispkey")
                End If

                If Not veri.Item("outputparamname") Is System.DBNull.Value Then
                    donecekgenericservisoutput.outputparamname = veri.Item("outputparamname")
                End If


                genericservisoutputler.Add(New CLASSGENERICSERVISOUTPUT(donecekgenericservisoutput.pkey, _
                donecekgenericservisoutput.genericservispkey, donecekgenericservisoutput.outputparamname))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return genericservisoutputler

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

        jvstring = "<script type='text/javascript'>" + _
              "$(document).ready(function() {" + _
                  "$('.button').button();" + _
              "});" + _
              "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Servis Adı</th>" + _
        "<th>Output Parametre</th>" + _
        "<th>İşlem</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from genericservisoutput where genericservispkey=@genericservispkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("genericservispkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, genericservispkey, outputparamname As String

        Dim genericservis As New CLASSGENERICSERVIS
        Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM
        Dim ajaxlinksil, dugmesil As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                        genericservispkey = veri.Item("genericservispkey")
                    End If


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "genericservisgirispopup.aspx?pkey=" + CStr(genericservispkey) + _
                        "&op=duzenle" + _
                        "&genericservisoutputop=duzenle" + _
                        "&genericservisoutputpkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("genericservispkey") Is System.DBNull.Value Then
                        genericservispkey = veri.Item("genericservispkey")
                        genericservis = genericservis_erisim.bultek(genericservispkey)
                        kol2 = "<td>" + genericservis.ad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("outputparamname") Is System.DBNull.Value Then
                        outputparamname = veri.Item("outputparamname")
                        kol3 = "<td>" + outputparamname + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "genericservisoutputsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='genericservisoutputsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol4 = "<td>" + dugmesil + "</td></tr>"

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
    Function ciftkayitkontrol(ByVal outputparamname As String, ByVal genericservispkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericservisoutput where outputparamname=@outputparamname and " + _
        "genericservispkey=@genericservispkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@outputparamname", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = outputparamname
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = genericservispkey
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function



    Function genericservisvarmi(ByVal genericservispkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from genericservisoutput where genericservispkey=@genericservispkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@genericservispkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = genericservispkey
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


