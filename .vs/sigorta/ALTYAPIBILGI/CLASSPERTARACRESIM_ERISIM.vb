Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSPERTARACRESIM_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim pertaracresim As New CLASSPERTARACRESIM
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal pertaracresim As CLASSPERTARACRESIM) As CLADBOPRESULT

        etkilenen = 0
     
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into pertaracresim values (@pkey," + _
        "@pertaracpkey,@dosyaad,@anaresim)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If pertaracresim.pertaracpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = pertaracresim.pertaracpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dosyaad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If pertaracresim.dosyaad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = pertaracresim.dosyaad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@anaresim", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If pertaracresim.anaresim = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = pertaracresim.anaresim
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
        sqlstr = "select max(pkey) from pertaracresim"
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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function aracinkacresmivar(ByVal pertaracpkey As String) As Integer

        Dim sqlstr As String
        Dim kacresim As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from pertaracresim where pertaracpkey=@pertaracpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracpkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kacresim = 0
        Else
            kacresim = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kacresim

    End Function

    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal pertaracresim As CLASSPERTARACRESIM) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update pertaracresim set " + _
        "pertaracpkey=@pertaracpkey," + _
        "dosyaad=@dosyaad," + _
        "anaresim=@anaresim" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracresim.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If pertaracresim.pertaracpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = pertaracresim.pertaracpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dosyaad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If pertaracresim.dosyaad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = pertaracresim.dosyaad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@anaresim", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If pertaracresim.anaresim = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = pertaracresim.anaresim
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
    Function bultek(ByVal pkey As String) As CLASSPERTARACRESIM

        Dim komut As New SqlCommand
        Dim donecekpertaracresim As New CLASSPERTARACRESIM()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertaracresim where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pertaracpkey = veri.Item("pertaracpkey")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecekpertaracresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("anaresim") Is System.DBNull.Value Then
                    donecekpertaracresim.anaresim = veri.Item("anaresim")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekpertaracresim

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bulanaresim(ByVal pertaracpkey As String) As CLASSPERTARACRESIM

        Dim komut As New SqlCommand
        Dim donecekpertaracresim As New CLASSPERTARACRESIM()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertaracresim where pertaracpkey=@pertaracpkey and anaresim=@anaresim"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@anaresim", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Evet"
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pertaracpkey = veri.Item("pertaracpkey")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecekpertaracresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("anaresim") Is System.DBNull.Value Then
                    donecekpertaracresim.anaresim = veri.Item("anaresim")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekpertaracresim

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim filename As String
        Dim pertaracresim As New CLASSPERTARACRESIM
        pertaracresim = bultek(pkey)
        filename = pertaracresim.dosyaad

        Dim FileToDelete As String

        FileToDelete = HttpContext.Current.Server.MapPath("~/" + "pertaracresim/" + filename)
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from pertaracresim where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSPERTARACRESIM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekpertaracresim As New CLASSPERTARACRESIM
        Dim pertaracresimler As New List(Of CLASSPERTARACRESIM)
        komut.Connection = db_baglanti
        sqlstr = "select * from pertaracresim"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pertaracpkey = veri.Item("pertaracpkey")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecekpertaracresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("anaresim") Is System.DBNull.Value Then
                    donecekpertaracresim.anaresim = veri.Item("anaresim")
                End If

                pertaracresimler.Add(New CLASSPERTARACRESIM(donecekpertaracresim.pkey, _
                donecekpertaracresim.pertaracpkey, donecekpertaracresim.dosyaad, donecekpertaracresim.anaresim))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return pertaracresimler

    End Function



    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal pertaracpkey As String) As List(Of CLASSPERTARACRESIM)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekpertaracresim As New CLASSPERTARACRESIM
        Dim pertaracresimler As New List(Of CLASSPERTARACRESIM)
        komut.Connection = db_baglanti
        sqlstr = "select * from pertaracresim where pertaracpkey=@pertaracpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                    donecekpertaracresim.pertaracpkey = veri.Item("pertaracpkey")
                End If

                If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                    donecekpertaracresim.dosyaad = veri.Item("dosyaad")
                End If

                If Not veri.Item("anaresim") Is System.DBNull.Value Then
                    donecekpertaracresim.anaresim = veri.Item("anaresim")
                End If

                pertaracresimler.Add(New CLASSPERTARACRESIM(donecekpertaracresim.pkey, _
                donecekpertaracresim.pertaracpkey, donecekpertaracresim.dosyaad, donecekpertaracresim.anaresim))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return pertaracresimler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal p_pkey As String) As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7 As String
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

        basliklar = "<table style='margin: 0 auto;' class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Pert Araç Bilgisi</th>" + _
        "<th>Dosya Adı</th>" + _
        "<th>Resim</th>" + _
        "<th>Ana Resim</th>" + _
        "<th>Ana Resim</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        sqlstr = "select * from pertaracresim where pertaracpkey=@pertaracpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = p_pkey
        komut.Parameters.Add(param1)

        girdi = "0"
        Dim link As String
        Dim pkey, pertaracpkey, dosyaad, anaresim As String
        Dim anaresimjpg As String

        Dim pertarac As New CLASSPERTARAC
        Dim pertarac_erisim As New CLASSPERTARAC_ERISIM

        Dim araccins As New CLASSARACCINS
        Dim araccins_erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim aracbilgiyazi As String
        Dim ajaxlinksil, dugmesil As String
        Dim ajaxlinkanaresim, dugmeanaresim As String
        Dim reshtml As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "pertaracresim.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("pertaracpkey") Is System.DBNull.Value Then
                        pertaracpkey = veri.Item("pertaracpkey")
                        pertarac = pertarac_erisim.bultek(pertaracpkey)
                        araccins = araccins_erisim.bultek(pertarac.araccinspkey)
                        aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
                        aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
                        aracbilgiyazi = "<b>" + pertarac.plaka + "</b><br/>" + _
                        araccins.cinsad + "<br/>" + _
                        CStr(pertarac.imalyil) + " " + aracmarka.markaad + "<br/>" + _
                        aracmodel.modelad
                        kol2 = "<td>" + aracbilgiyazi + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("dosyaad") Is System.DBNull.Value Then
                        dosyaad = veri.Item("dosyaad")
                        kol3 = "<td>" + dosyaad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    reshtml = "<img style=" + Chr(34) + "width:150px;height:150px;" + Chr(34) + _
                    " src=" + Chr(34) + "pertaracresim/" + dosyaad + Chr(34) + "></img>"
                    kol4 = "<td>" + reshtml + "</td>"

                    If Not veri.Item("anaresim") Is System.DBNull.Value Then
                        anaresim = veri.Item("anaresim")
                        If anaresim = "Evet" Then
                            anaresimjpg = "<img style=" + Chr(34) + "width:50px;height:50px;" + Chr(34) + _
                            " src=" + Chr(34) + "images/green_check.png" + Chr(34) + "</img>" + "<br/>"
                        Else
                            anaresimjpg = ""

                        End If
                        kol5 = "<td>" + anaresimjpg + anaresim + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    '--ANARESİM DÜĞMESİ ------
                    ajaxlinkanaresim = "pertaracresimanaresim(" + CStr(pkey) + ")"
                    dugmeanaresim = "<span id='pertaracresimanaresimbutton' onclick='" + ajaxlinkanaresim + _
                    "' class='button'>Ana Resim Yap</span>"
                    kol6 = "<td>" + dugmeanaresim + "</td>"


                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "pertaracresimsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='pertaracresimsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol7 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
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

    Public Function tumresimlerinianaresimyapma(ByVal pertaracpkey As String) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update pertaracresim set " + _
        "anaresim=@anaresim" + _
        " where pertaracpkey=@pertaracpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@anaresim", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Hayır"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = pertaracpkey
        komut.Parameters.Add(param2)


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

    Public Function ilgiliyianaresimyapma(ByVal pkey As String) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update pertaracresim set " + _
        "anaresim=@anaresim" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@anaresim", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Evet"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = pkey
        komut.Parameters.Add(param2)


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

    Public Function anaresimyap(ByVal pertaracpkey As String, ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        result = tumresimlerinianaresimyapma(pertaracpkey)

        If result.durum = "Kaydedildi" Then
            result = ilgiliyianaresimyapma(pkey)
        End If

        Return result

    End Function

    Public Function bxslideryap(ByVal pertaracpkey As String) As String

        Dim bas1, son1, bas2, son2 As String
        Dim donecek, bir, iki As String
        Dim ilgilipertaraclar As New List(Of CLASSPERTARACRESIM)
        ilgilipertaraclar = doldurilgili(pertaracpkey)


        bas1 = "<ul class=" + Chr(34) + "bxslider" + Chr(34) + ">"
        son1 = "</ul>"
        bas2 = "<div id=" + Chr(34) + "bx-pager" + Chr(34) + ">"
        son2 = "</div>"

        Dim i As Integer = 0

        For Each Item As CLASSPERTARACRESIM In ilgilipertaraclar
            bir = bir + "<li><img src=" + Chr(34) + "pertaracresim/" + Item.dosyaad + Chr(34) + "></li>"
            iki = iki + "<a data-slide-index=" + Chr(34) + CStr(i) + Chr(34) + " href=" + Chr(34) + Chr(34) + _
            "><img style=" + Chr(34) + "width:60px;height:60px;" + Chr(34) + _
            " src=" + Chr(34) + "pertaracresim/" + Item.dosyaad + Chr(34) + "/></a>"
            i = i + 1
        Next

        donecek = bas1 + bir + son1 + bas2 + iki + son2
        Return donecek


    End Function


    Function pertaracvarmi(ByVal pertaracpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertaracresim where pertaracpkey=@pertaracpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@pertaracpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertaracpkey
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