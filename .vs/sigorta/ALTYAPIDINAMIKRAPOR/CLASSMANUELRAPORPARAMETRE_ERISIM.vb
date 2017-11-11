Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSMANUELRAPORPARAMETRE_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim manuelraporparametre As New CLASSMANUELRAPORPARAMETRE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal manuelraporparametre As CLASSMANUELRAPORPARAMETRE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(manuelraporparametre.sad, manuelraporparametre.manuelraporpkey)

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
            sqlstr = "insert into manuelraporparametre values (@pkey," + _
            "@manuelraporpkey,@sad,@sdeger)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If manuelraporparametre.manuelraporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = manuelraporparametre.manuelraporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@sad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If manuelraporparametre.sad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = manuelraporparametre.sad
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@sdeger", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If manuelraporparametre.sdeger = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = manuelraporparametre.sdeger
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
        sqlstr = "select max(pkey) from manuelraporparametre"
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
    Function Duzenle(ByVal manuelraporparametre As CLASSMANUELRAPORPARAMETRE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update manuelraporparametre set " + _
        "manuelraporpkey=@manuelraporpkey," + _
        "sad=@sad," + _
        "sdeger=@sdeger" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporparametre.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If manuelraporparametre.manuelraporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = manuelraporparametre.manuelraporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If manuelraporparametre.sad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = manuelraporparametre.sad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sdeger", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If manuelraporparametre.sdeger = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = manuelraporparametre.sdeger
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
    Function bultek(ByVal pkey As String) As CLASSMANUELRAPORPARAMETRE

        Dim komut As New SqlCommand
        Dim donecekmanuelraporparametre As New CLASSMANUELRAPORPARAMETRE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporparametre where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.manuelraporpkey = veri.Item("manuelraporpkey")
                End If

                If Not veri.Item("sad") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.sad = veri.Item("sad")
                End If

                If Not veri.Item("sdeger") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.sdeger = veri.Item("sdeger")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekmanuelraporparametre

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from manuelraporparametre where pkey=@pkey"
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
    Public Function sililgili(ByVal manuelraporpkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from manuelraporparametre where manuelraporpkey=@manuelraporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporpkey
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
    Public Function doldur() As List(Of CLASSMANUELRAPORPARAMETRE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmanuelraporparametre As New CLASSMANUELRAPORPARAMETRE
        Dim manuelraporparametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
        komut.Connection = db_baglanti
        sqlstr = "select * from manuelraporparametre"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.manuelraporpkey = veri.Item("manuelraporpkey")
                End If

                If Not veri.Item("sad") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.sad = veri.Item("sad")
                End If

                If Not veri.Item("sdeger") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.sdeger = veri.Item("sdeger")
                End If


                manuelraporparametreler.Add(New CLASSMANUELRAPORPARAMETRE(donecekmanuelraporparametre.pkey, _
                donecekmanuelraporparametre.manuelraporpkey, donecekmanuelraporparametre.sad, donecekmanuelraporparametre.sdeger))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return manuelraporparametreler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal manuelraporpkey As Integer) As List(Of CLASSMANUELRAPORPARAMETRE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmanuelraporparametre As New CLASSMANUELRAPORPARAMETRE
        Dim manuelraporparametreler As New List(Of CLASSMANUELRAPORPARAMETRE)
        komut.Connection = db_baglanti
        sqlstr = "select * from manuelraporparametre where manuelraporpkey=@manuelraporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.manuelraporpkey = veri.Item("manuelraporpkey")
                End If

                If Not veri.Item("sad") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.sad = veri.Item("sad")
                End If

                If Not veri.Item("sdeger") Is System.DBNull.Value Then
                    donecekmanuelraporparametre.sdeger = veri.Item("sdeger")
                End If


                manuelraporparametreler.Add(New CLASSMANUELRAPORPARAMETRE(donecekmanuelraporparametre.pkey, _
                donecekmanuelraporparametre.manuelraporpkey, donecekmanuelraporparametre.sad, donecekmanuelraporparametre.sdeger))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return manuelraporparametreler

    End Function

 
    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim tabloson, pager As String
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
        "<th>Parametre Ad</th>" + _
        "<th>Parametre Değer</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from  manuelraporparametre where manuelraporpkey=@manuelraporpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("manuelraporpkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, manuelraporpkey, sad, sdeger As String

        Dim manuelrapor As New CLASSMANUELRAPOR
        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                        manuelraporpkey = veri.Item("manuelraporpkey")
                    End If


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        link = "manuelraporpopup.aspx?pkey=" + CStr(manuelraporpkey) + _
                        "&op=duzenle" + _
                        "&manuelraporparametreop=duzenle" + _
                        "&manuelraporparametrepkey=" + CStr(pkey)

                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"

                    End If

                    If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                        manuelraporpkey = veri.Item("manuelraporpkey")
                        manuelrapor = manuelrapor_erisim.bultek(manuelraporpkey)
                        kol2 = "<td>" + manuelrapor.ad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("sad") Is System.DBNull.Value Then
                        sad = veri.Item("sad")
                        kol3 = "<td>" + sad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("sdeger") Is System.DBNull.Value Then
                        sdeger = veri.Item("sdeger")
                        kol4 = "<td>" + sdeger + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "manuelraporparametresil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='manuelraporparametresilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol5 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5

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
    Function ciftkayitkontrol(ByVal sad As String, ByVal manuelraporpkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporparametre where sad=@sad" + _
        " and manuelraporpkey=@manuelraporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sad
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = manuelraporpkey
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function raporvarmi(ByVal manuelraporpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from manuelraporparametre where manuelraporpkey=@manuelraporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = manuelraporpkey
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


