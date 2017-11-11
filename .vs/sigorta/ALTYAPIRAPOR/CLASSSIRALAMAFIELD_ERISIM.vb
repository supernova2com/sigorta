Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSSIRALAMAFIELD_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim siralamafield As New CLASSSIRALAMAFIELD
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal siralamafield As CLASSSIRALAMAFIELD) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(siralamafield.raporpkey, siralamafield.siralamatabload, siralamafield.fieldad)

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

            sqlstr = "insert into siralamafield values (@pkey," + _
            "@raporpkey,@fieldad,@sirano,@ordertype," + _
            "@siralamatabload,@kullanilacaktablopkey)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If siralamafield.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = siralamafield.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If siralamafield.fieldad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = siralamafield.fieldad
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@sirano", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If siralamafield.sirano = 0 Then
                param4.Value = 0
            Else
                param4.Value = siralamafield.sirano
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@ordertype", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If siralamafield.ordertype = 0 Then
                param5.Value = 0
            Else
                param5.Value = siralamafield.ordertype
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@siralamatabload", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If siralamafield.siralamatabload = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = siralamafield.siralamatabload
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
            param7.Direction = ParameterDirection.Input
            If siralamafield.kullanilacaktablopkey = 0 Then
                param7.Value = 0
            Else
                param7.Value = siralamafield.kullanilacaktablopkey
            End If
            komut.Parameters.Add(param7)

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
        sqlstr = "select max(pkey) from siralamafield"
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
    Function Duzenle(ByVal siralamafield As CLASSSIRALAMAFIELD) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update siralamafield set " + _
        "raporpkey=@raporpkey," + _
        "fieldad=@fieldad," + _
        "sirano=@sirano," + _
        "ordertype=@ordertype," + _
        "siralamatabload=@siralamatabload," + _
        "kullanilacaktablopkey=@kullanilacaktablopkey" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = siralamafield.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If siralamafield.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = siralamafield.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If siralamafield.fieldad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = siralamafield.fieldad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sirano", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If siralamafield.sirano = 0 Then
            param4.Value = 0
        Else
            param4.Value = siralamafield.sirano
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ordertype", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If siralamafield.ordertype = 0 Then
            param5.Value = 0
        Else
            param5.Value = siralamafield.ordertype
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@siralamatabload", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If siralamafield.siralamatabload = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = siralamafield.siralamatabload
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If siralamafield.kullanilacaktablopkey = 0 Then
            param7.Value = 0
        Else
            param7.Value = siralamafield.kullanilacaktablopkey
        End If
        komut.Parameters.Add(param7)

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
    Function bultek(ByVal pkey As String) As CLASSSIRALAMAFIELD

        Dim komut As New SqlCommand
        Dim doneceksiralamafield As New CLASSSIRALAMAFIELD()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from siralamafield where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksiralamafield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    doneceksiralamafield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    doneceksiralamafield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sirano") Is System.DBNull.Value Then
                    doneceksiralamafield.sirano = veri.Item("sirano")
                End If

                If Not veri.Item("ordertype") Is System.DBNull.Value Then
                    doneceksiralamafield.ordertype = veri.Item("ordertype")
                End If

                If Not veri.Item("siralamatabload") Is System.DBNull.Value Then
                    doneceksiralamafield.siralamatabload = veri.Item("siralamatabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    doneceksiralamafield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksiralamafield

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from siralamafield where pkey=@pkey"
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


    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from siralamafield where raporpkey=@raporpkey"
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
    Public Function doldur() As List(Of CLASSSIRALAMAFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksiralamafield As New CLASSSIRALAMAFIELD
        Dim siralamafieldler As New List(Of CLASSSIRALAMAFIELD)
        komut.Connection = db_baglanti
        sqlstr = "select * from siralamafield"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksiralamafield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    doneceksiralamafield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    doneceksiralamafield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sirano") Is System.DBNull.Value Then
                    doneceksiralamafield.sirano = veri.Item("sirano")
                End If

                If Not veri.Item("ordertype") Is System.DBNull.Value Then
                    doneceksiralamafield.ordertype = veri.Item("ordertype")
                End If

                If Not veri.Item("siralamatabload") Is System.DBNull.Value Then
                    doneceksiralamafield.siralamatabload = veri.Item("siralamatabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    doneceksiralamafield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If


                siralamafieldler.Add(New CLASSSIRALAMAFIELD(doneceksiralamafield.pkey, _
                doneceksiralamafield.raporpkey, doneceksiralamafield.fieldad, _
                doneceksiralamafield.sirano, _
                doneceksiralamafield.ordertype, doneceksiralamafield.siralamatabload, _
                doneceksiralamafield.kullanilacaktablopkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return siralamafieldler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As String) As List(Of CLASSSIRALAMAFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksiralamafield As New CLASSSIRALAMAFIELD
        Dim siralamafieldler As New List(Of CLASSSIRALAMAFIELD)
        komut.Connection = db_baglanti

        sqlstr = "select * from siralamafield where raporpkey=@raporpkey order by sirano"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksiralamafield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    doneceksiralamafield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    doneceksiralamafield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sirano") Is System.DBNull.Value Then
                    doneceksiralamafield.sirano = veri.Item("sirano")
                End If

                If Not veri.Item("ordertype") Is System.DBNull.Value Then
                    doneceksiralamafield.ordertype = veri.Item("ordertype")
                End If

                If Not veri.Item("siralamatabload") Is System.DBNull.Value Then
                    doneceksiralamafield.siralamatabload = veri.Item("siralamatabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    doneceksiralamafield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                siralamafieldler.Add(New CLASSSIRALAMAFIELD(doneceksiralamafield.pkey, _
                doneceksiralamafield.raporpkey, doneceksiralamafield.fieldad, _
                doneceksiralamafield.sirano, doneceksiralamafield.ordertype, _
                doneceksiralamafield.siralamatabload, doneceksiralamafield.kullanilacaktablopkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return siralamafieldler

    End Function

  
    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
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
        "<th>Rapor</th>" + _
        "<th>Tablo Adı</th>" + _
        "<th>Alan Adı</th>" + _
        "<th>Sıralama İçin Sıra No</th>" + _
        "<th>Tipi</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from siralamafield where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim pkey, raporpkey, fieldad, sirano, ordertype As String
        Dim ajaxlinksil, dugmesil As String
        Dim siralamatabload As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim link As String

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
                        "&siralamafieldop=duzenle" + _
                        "&siralamafieldpkey=" + CStr(pkey)

                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"

                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("siralamatabload") Is System.DBNull.Value Then
                        siralamatabload = veri.Item("siralamatabload")
                        kol3 = "<td>" + siralamatabload + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldad") Is System.DBNull.Value Then
                        fieldad = veri.Item("fieldad")
                        kol4 = "<td>" + fieldad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("sirano") Is System.DBNull.Value Then
                        sirano = veri.Item("sirano")
                        kol5 = "<td>" + CStr(sirano) + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("ordertype") Is System.DBNull.Value Then
                        ordertype = veri.Item("ordertype")
                        kol6 = "<td>" + ordertype + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "siralamafieldsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='siralamafieldsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol7 = "<td>" + dugmesil + "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
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
    Function ciftkayitkontrol(ByVal raporpkey As Integer, ByVal siralamatabload As String, _
                              ByVal fieldad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from siralamafield where raporpkey=@raporpkey and " + _
        "siralamatabload=@siralamatabload and fieldad=@fieldad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@siralamatabload", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = siralamatabload
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

        sqlstr = "select * from siralamafield where raporpkey=@raporpkey"

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

        sqlstr = "select * from siralamafield where raporpkey=@raporpkey and " + _
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

End Class


