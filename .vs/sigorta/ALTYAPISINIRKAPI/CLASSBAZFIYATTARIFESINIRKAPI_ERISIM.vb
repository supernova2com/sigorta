Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO

Public Class CLASSBAZFIYATTARIFESINIRKAPI_ERISIM


    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim bazfiyattarifesinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal bazfiyattarifesinirkapi As CLASSBAZFIYATTARIFESINIRKAPI) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into bazfiyattarifesinirkapi values (@pkey," + _
        "@bazfiyatpkey,@sinirkapiaractippkey,@ucgun,@biray," + _
        "@ucay,@altiay,@onikiay)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.bazfiyatpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = bazfiyattarifesinirkapi.bazfiyatpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.sinirkapiaractippkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = bazfiyattarifesinirkapi.sinirkapiaractippkey
        End If
        komut.Parameters.Add(param3)
        Dim param4 As New SqlParameter("@ucgun", SqlDbType.Float)
        param4.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.ucgun = 0 Then
            param4.Value = 0
        Else
            param4.Value = bazfiyattarifesinirkapi.ucgun
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@biray", SqlDbType.Float)
        param5.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.biray = 0 Then
            param5.Value = 0
        Else
            param5.Value = bazfiyattarifesinirkapi.biray
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ucay", SqlDbType.Float)
        param6.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.ucay = 0 Then
            param6.Value = 0
        Else
            param6.Value = bazfiyattarifesinirkapi.ucay
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@altiay", SqlDbType.Float)
        param7.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.altiay = 0 Then
            param7.Value = 0
        Else
            param7.Value = bazfiyattarifesinirkapi.altiay
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@onikiay", SqlDbType.Float)
        param8.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.onikiay = 0 Then
            param8.Value = 0
        Else
            param8.Value = bazfiyattarifesinirkapi.onikiay
        End If
        komut.Parameters.Add(param8)


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
        sqlstr = "select max(pkey) from bazfiyattarifesinirkapi"
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
    Function Duzenle(ByVal bazfiyattarifesinirkapi As CLASSBAZFIYATTARIFESINIRKAPI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update bazfiyattarifesinirkapi set " + _
        "bazfiyatpkey=@bazfiyatpkey," + _
        "sinirkapiaractippkey=@sinirkapiaractippkey," + _
        "ucgun=@ucgun," + _
        "biray=@biray," + _
        "ucay=@ucay," + _
        "altiay=@altiay," + _
        "onikiay=@onikiay" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyattarifesinirkapi.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.bazfiyatpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = bazfiyattarifesinirkapi.bazfiyatpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.sinirkapiaractippkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = bazfiyattarifesinirkapi.sinirkapiaractippkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ucgun", SqlDbType.Float)
        param4.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.ucgun = 0 Then
            param4.Value = 0
        Else
            param4.Value = bazfiyattarifesinirkapi.ucgun
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@biray", SqlDbType.Float)
        param5.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.biray = 0 Then
            param5.Value = 0
        Else
            param5.Value = bazfiyattarifesinirkapi.biray
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ucay", SqlDbType.Float)
        param6.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.ucay = 0 Then
            param6.Value = 0
        Else
            param6.Value = bazfiyattarifesinirkapi.ucay
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@altiay", SqlDbType.Float)
        param7.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.altiay = 0 Then
            param7.Value = 0
        Else
            param7.Value = bazfiyattarifesinirkapi.altiay
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@onikiay", SqlDbType.Float)
        param8.Direction = ParameterDirection.Input
        If bazfiyattarifesinirkapi.onikiay = 0 Then
            param8.Value = 0
        Else
            param8.Value = bazfiyattarifesinirkapi.onikiay
        End If
        komut.Parameters.Add(param8)


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
    Function bultek(ByVal pkey As String) As CLASSBAZFIYATTARIFESINIRKAPI

        Dim komut As New SqlCommand
        Dim donecekbazfiyattarifesinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyattarifesinirkapi where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatpkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.bazfiyatpkey = veri.Item("bazfiyatpkey")
                End If

                If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                End If

                If Not veri.Item("ucgun") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.ucgun = veri.Item("ucgun")
                End If

                If Not veri.Item("biray") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.biray = veri.Item("biray")
                End If

                If Not veri.Item("ucay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.ucay = veri.Item("ucay")
                End If

                If Not veri.Item("altiay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.altiay = veri.Item("altiay")
                End If

                If Not veri.Item("onikiay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.onikiay = veri.Item("onikiay")
                End If



            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyattarifesinirkapi

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bul_ilgili(ByVal bazfiyatpkey As String, _
    ByVal sinirkapiaractippkey As String) As CLASSBAZFIYATTARIFESINIRKAPI

        Dim komut As New SqlCommand
        Dim donecekbazfiyattarifesinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyattarifesinirkapi where bazfiyatpkey=@bazfiyatpkey and " + _
        "sinirkapiaractippkey=@sinirkapiaractippkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = sinirkapiaractippkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatpkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.bazfiyatpkey = veri.Item("bazfiyatpkey")
                End If

                If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                End If

                If Not veri.Item("ucgun") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.ucgun = veri.Item("ucgun")
                End If

                If Not veri.Item("biray") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.biray = veri.Item("biray")
                End If

                If Not veri.Item("ucay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.ucay = veri.Item("ucay")
                End If

                If Not veri.Item("altiay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.altiay = veri.Item("altiay")
                End If

                If Not veri.Item("onikiay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.onikiay = veri.Item("onikiay")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyattarifesinirkapi

    End Function



    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from bazfiyattarifesinirkapi where pkey=@pkey"
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
    Public Function ilgilisil(ByVal bazfiyatpkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        komut = New SqlCommand(sqlstr, db_baglanti)

        sqlstr = "delete from bazfiyattarifesinirkapi where bazfiyatpkey=@bazfiyatpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
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


    '---------------------------------sil bazfiyat tümü----------------------------------------
    Public Function sil_bazfiyatpkeyegore(ByVal bazfiyatpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        komut = New SqlCommand(sqlstr, db_baglanti)

        sqlstr = "delete from bazfiyattarifesinirkapi where bazfiyatpkey=@bazfiyatpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
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
    Public Function doldur(ByVal bazfiyatpkey As String) As List(Of CLASSBAZFIYATTARIFESINIRKAPI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbazfiyattarifesinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI
        Dim bazfiyattarifesinirkapiler As New List(Of CLASSBAZFIYATTARIFESINIRKAPI)
        komut.Connection = db_baglanti
        sqlstr = "select * from bazfiyattarifesinirkapi where bazfiyatpkey=@bazfiyatpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatpkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.bazfiyatpkey = veri.Item("bazfiyatpkey")
                End If

                If Not veri.Item("sinirkapiaractippkey") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.sinirkapiaractippkey = veri.Item("sinirkapiaractippkey")
                End If

                If Not veri.Item("ucgun") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.ucgun = veri.Item("ucgun")
                End If

                If Not veri.Item("biray") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.biray = veri.Item("biray")
                End If

                If Not veri.Item("ucay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.ucay = veri.Item("ucay")
                End If

                If Not veri.Item("altiay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.altiay = veri.Item("altiay")
                End If

                If Not veri.Item("onikiay") Is System.DBNull.Value Then
                    donecekbazfiyattarifesinirkapi.onikiay = veri.Item("onikiay")
                End If



                bazfiyattarifesinirkapiler.Add(New CLASSBAZFIYATTARIFESINIRKAPI(donecekbazfiyattarifesinirkapi.pkey, _
                donecekbazfiyattarifesinirkapi.bazfiyatpkey, donecekbazfiyattarifesinirkapi.sinirkapiaractippkey, _
                donecekbazfiyattarifesinirkapi.ucgun, donecekbazfiyattarifesinirkapi.biray, _
                donecekbazfiyattarifesinirkapi.ucay, donecekbazfiyattarifesinirkapi.altiay, _
                donecekbazfiyattarifesinirkapi.onikiay))



            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bazfiyattarifesinirkapiler

    End Function



    Public Function inputlariolustur(ByVal bazfiyatpkey As String, _
    ByVal op As String) As String

        Dim tekinput As String
        Dim teksatir As String = ""
        Dim oid As String
        Dim donecek As String = ""
        Dim basliklar, tabloson As String
        Dim valuestr As String = ""
        Dim classstr As String

        basliklar = "<table id=sonuctable class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th id='bb1'>Araç Tarife Kodu</th>" + _
        "<th id='bb2'>3 Gün</th>" + _
        "<th id='bb3'>1 Ay</th>" + _
        "<th id='bb4'>3 Ay</th>" + _
        "<th id='bb5'>6 Ay</th>" + _
        "<th id='bb6'>12 Ay</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM
        Dim sinirkapiaractipler As New List(Of CLASSSINIRKAPIARACTIP)
        sinirkapiaractipler = sinirkapiaractip_erisim.doldur

        Dim a As Integer = 1

        For Each itemsinirkapiaractip As CLASSSINIRKAPIARACTIP In sinirkapiaractipler
            teksatir = teksatir + "<tr><td>" + itemsinirkapiaractip.sinirkapiaractipad + "</td>"

            bazfiyattarifesinirkapi = bul_ilgili(bazfiyatpkey, itemsinirkapiaractip.pkey)

            For i = 1 To 5

                If op = "duzenle" Then
                    valuestr = ""

                    If i = 1 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarifesinirkapi.ucgun) + Chr(34) + " "
                    End If
                    If i = 2 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarifesinirkapi.biray) + Chr(34) + " "
                    End If
                    If i = 3 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarifesinirkapi.ucay) + Chr(34) + " "
                    End If
                    If i = 4 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarifesinirkapi.altiay) + Chr(34) + " "
                    End If
                    If i = 5 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarifesinirkapi.onikiay) + Chr(34) + " "
                    End If

                End If


                oid = CStr(itemsinirkapiaractip.pkey) + "_" + CStr(i)
                tekinput = "<input type=" + Chr(34) + "text" + Chr(34) + _
                " id=" + Chr(34) + "A" + oid + Chr(34) + _
                " name=" + Chr(34) + "A" + oid + Chr(34) + _
                 valuestr + " class=" + Chr(34) + "textboxkucuk" + Chr(34) + "></input>"

                teksatir = teksatir + "<td id='" + "zz" + CStr(a) + "-" + CStr(i) + "'>" + tekinput + "</td>"

                a = a + 1
            Next
            teksatir = teksatir + "</tr>"
        Next

        donecek = basliklar + teksatir + tabloson

        Return donecek

    End Function


    Public Function temizle(ByVal bazfiyattarifesinirkapi As CLASSBAZFIYATTARIFESINIRKAPI) As CLASSBAZFIYATTARIFESINIRKAPI

        bazfiyattarifesinirkapi.pkey = 0
        bazfiyattarifesinirkapi.bazfiyatpkey = 0
        bazfiyattarifesinirkapi.sinirkapiaractippkey = 0
        bazfiyattarifesinirkapi.ucgun = 0
        bazfiyattarifesinirkapi.biray = 0
        bazfiyattarifesinirkapi.ucay = 0
        bazfiyattarifesinirkapi.altiay = 0
        bazfiyattarifesinirkapi.onikiay = 0


        Return bazfiyattarifesinirkapi

    End Function


End Class
