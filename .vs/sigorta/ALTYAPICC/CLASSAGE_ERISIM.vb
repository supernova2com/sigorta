Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSAGE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim age As New CLASSAGE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal age As CLASSAGE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(age.baslangicage, age.bitisage, age.agerate)

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
            sqlstr = "insert into age values (@pkey," + _
            "@baslangicage,@bitisage,@agerate)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@baslangicage", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If age.baslangicage = 0 Then
                param2.Value = 0
            Else
                param2.Value = age.baslangicage
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@bitisage", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If age.bitisage = 0 Then
                param3.Value = 0
            Else
                param3.Value = age.bitisage
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@agerate", SqlDbType.Decimal)
            param4.Direction = ParameterDirection.Input
            If age.agerate = 0 Then
                param4.Value = 0
            Else
                param4.Value = age.agerate
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
        sqlstr = "select max(pkey) from age"
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
    Function Duzenle(ByVal age As CLASSAGE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update age set " + _
        "baslangicage=@baslangicage," + _
        "bitisage=@bitisage," + _
        "agerate=@agerate" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = age.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangicage", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If age.baslangicage = 0 Then
            param2.Value = 0
        Else
            param2.Value = age.baslangicage
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@bitisage", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If age.bitisage = 0 Then
            param3.Value = 0
        Else
            param3.Value = age.bitisage
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@agerate", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If age.agerate = 0 Then
            param4.Value = 0
        Else
            param4.Value = age.agerate
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
    Function bultek(ByVal pkey As String) As CLASSAGE

        Dim komut As New SqlCommand
        Dim donecekage As New CLASSage()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from age where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekage.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslangicage") Is System.DBNull.Value Then
                    donecekage.baslangicage = veri.Item("baslangicage")
                End If

                If Not veri.Item("bitisage") Is System.DBNull.Value Then
                    donecekage.bitisage = veri.Item("bitisage")
                End If

                If Not veri.Item("agerate") Is System.DBNull.Value Then
                    donecekage.agerate = veri.Item("agerate")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekage

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from age where pkey=@pkey"
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

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSAGE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekage As New CLASSage
        Dim ageler As New List(Of CLASSage)
        komut.Connection = db_baglanti
        sqlstr = "select * from age"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekage.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslangicage") Is System.DBNull.Value Then
                    donecekage.baslangicage = veri.Item("baslangicage")
                End If

                If Not veri.Item("bitisage") Is System.DBNull.Value Then
                    donecekage.bitisage = veri.Item("bitisage")
                End If

                If Not veri.Item("agerate") Is System.DBNull.Value Then
                    donecekage.agerate = veri.Item("agerate")
                End If


                ageler.Add(New CLASSage(donecekage.pkey, _
                donecekage.baslangicage, donecekage.bitisage, donecekage.agerate))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ageler

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
        "<th>Başlangıç Yaşı</th>" + _
        "<th>Bitiş Yaşı</th>" + _
        "<th>Yaş Zammı Oranı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from age"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, baslangicage, bitisage, agerate As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "age.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("baslangicage") Is System.DBNull.Value Then
                        baslangicage = veri.Item("baslangicage")
                        kol2 = "<td>" + baslangicage + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("bitisage") Is System.DBNull.Value Then
                        bitisage = veri.Item("bitisage")
                        kol3 = "<td>" + bitisage + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("agerate") Is System.DBNull.Value Then
                        agerate = veri.Item("agerate")
                        kol4 = "<td>" + agerate + "</td></tr>"
                    Else
                        kol4 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal baslangicage As Integer, ByVal bitisage As Integer, _
    ByVal agerate As Decimal) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from age where baslangicage=@baslangicage and bitisage=@bitisage and " + _
        "agerate=@agerate"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@baslangicage", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = baslangicage
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bitisage", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = bitisage
        komut.Parameters.Add(param2)


        Dim param3 As New SqlParameter("@agerate", SqlDbType.Decimal)
        param3.Direction = ParameterDirection.Input
        param3.Value = agerate
        komut.Parameters.Add(param3)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function

End Class

