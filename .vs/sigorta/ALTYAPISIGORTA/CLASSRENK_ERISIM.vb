Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSRENK_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim renk As New CLASSRENK
    Dim resultset As New CLADBOPRESULT

    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal renk As CLASSRENK) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi As Integer

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "renkkod", "=", renk.renkkod, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "renk", "count(*)", fieldopvalues)
        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu renk kodu halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "renkad", "=", renk.renkad, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "renk", "count(*)", fieldopvalues)
        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu renk adı halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into renk values (@pkey," + _
        "@renkkod,@renkad,@renkhex)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@renkkod", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If renk.renkkod = 0 Then
            param2.Value = 0
        Else
            param2.Value = renk.renkkod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@renkad", SqlDbType.VarChar, 254)
        param3.Direction = ParameterDirection.Input
        If renk.renkad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = renk.renkad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@renkhex", SqlDbType.VarChar, 100)
        param4.Direction = ParameterDirection.Input
        If renk.renkhex = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = renk.renkhex
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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from renk"
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
    Function Duzenle(ByVal renk As CLASSRENK) As CLADBOPRESULT

        Dim varmi As Integer

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "renkkod", "=", renk.renkkod, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", renk.pkey, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "renk", "count(*)", fieldopvalues)
        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu renk kodu halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "renkad", "=", renk.renkad, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", renk.pkey, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "renk", "count(*)", fieldopvalues)
        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu renk adı halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update renk set " + _
        "renkkod=@renkkod," + _
        "renkad=@renkad," + _
        "renkhex=@renkhex" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = renk.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@renkkod", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If renk.renkkod = 0 Then
            param2.Value = 0
        Else
            param2.Value = renk.renkkod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@renkad", SqlDbType.VarChar, 254)
        param3.Direction = ParameterDirection.Input
        If renk.renkad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = renk.renkad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@renkhex", SqlDbType.VarChar, 100)
        param4.Direction = ParameterDirection.Input
        If renk.renkhex = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = renk.renkhex
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
    Function bultek(ByVal pkey As String) As CLASSRENK

        Dim komut As New SqlCommand
        Dim donecekrenk As New CLASSRENK()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from renk where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekrenk.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("renkkod") Is System.DBNull.Value Then
                    donecekrenk.renkkod = veri.Item("renkkod")
                End If

                If Not veri.Item("renkad") Is System.DBNull.Value Then
                    donecekrenk.renkad = veri.Item("renkad")
                End If

                If Not veri.Item("renkhex") Is System.DBNull.Value Then
                    donecekrenk.renkhex = veri.Item("renkhex")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekrenk

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from renk where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSRENK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekrenk As New CLASSRENK
        Dim renkler As New List(Of CLASSRENK)
        komut.Connection = db_baglanti
        sqlstr = "select * from renk"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekrenk.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("renkkod") Is System.DBNull.Value Then
                    donecekrenk.renkkod = veri.Item("renkkod")
                End If

                If Not veri.Item("renkad") Is System.DBNull.Value Then
                    donecekrenk.renkad = veri.Item("renkad")
                End If

                If Not veri.Item("renkhex") Is System.DBNull.Value Then
                    donecekrenk.renkhex = veri.Item("renkhex")
                End If

                renkler.Add(New CLASSRENK(donecekrenk.pkey, _
                donecekrenk.renkkod, donecekrenk.renkad, donecekrenk.renkhex))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return renkler

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
        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Renk Kodu</th>" + _
        "<th>Renk Adı</th>" + _
        "<th>Renk</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from renk"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, renkkod, renkad, renkhex As String
        Dim s As String = "<div style=" + Chr(34) + "width:50px;height:50px;display:block;border-style:solid;border-color:black;"

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "renk.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("renkkod") Is System.DBNull.Value Then
                        renkkod = veri.Item("renkkod")
                        kol2 = "<td>" + renkkod + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("renkad") Is System.DBNull.Value Then
                        renkad = veri.Item("renkad")
                        kol3 = "<td>" + renkad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("renkhex") Is System.DBNull.Value Then
                        renkhex = veri.Item("renkhex")
                        kol4 = "<td>" + s + "background-color:#" + renkhex + ";" + Chr(34) + "></div>" + "</td></tr>"
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
        db_baglanti.Dispose()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

   
End Class

