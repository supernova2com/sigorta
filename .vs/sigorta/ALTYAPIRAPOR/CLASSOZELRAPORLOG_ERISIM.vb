Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSOZELRAPORLOG_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim ozelraporlog As New CLASSOZELRAPORLOG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull
    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal ozelraporlog As CLASSOZELRAPORLOG) As CLADBOPRESULT

        resultset.durum = "Kayıt yapılamadı."
        resultset.hatastr = "Bu kaydın aynisi halihazırda veritabanında vardır."
        resultset.etkilenen = 0
    
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into ozelraporlog values (@pkey," + _
        "@tarih,@raporad,@yontem,@fizikseldosyaadexcel," + _
        "@fizikseldosyaadword,@fizikseldosyaadpdf,@manuelraporpkey)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If ozelraporlog.tarih Is Nothing Or ozelraporlog.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ozelraporlog.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@raporad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If ozelraporlog.raporad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ozelraporlog.raporad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yontem", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If ozelraporlog.yontem = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = ozelraporlog.yontem
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@fizikseldosyaadexcel", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If ozelraporlog.fizikseldosyaadexcel = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = ozelraporlog.fizikseldosyaadexcel
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@fizikseldosyaadword", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If ozelraporlog.fizikseldosyaadword = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = ozelraporlog.fizikseldosyaadword
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@fizikseldosyaadpdf", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If ozelraporlog.fizikseldosyaadpdf = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = ozelraporlog.fizikseldosyaadpdf
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@manuelraporpkey", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If ozelraporlog.manuelraporpkey = 0 Then
            param8.Value = 0
        Else
            param8.Value = ozelraporlog.manuelraporpkey
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
        sqlstr = "select max(pkey) from ozelraporlog"
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


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSOZELRAPORLOG

        Dim komut As New SqlCommand
        Dim donecekozelraporlog As New CLASSozelraporlog()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ozelraporlog where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekozelraporlog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekozelraporlog.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("raporad") Is System.DBNull.Value Then
                    donecekozelraporlog.raporad = veri.Item("raporad")
                End If

                If Not veri.Item("yontem") Is System.DBNull.Value Then
                    donecekozelraporlog.yontem = veri.Item("yontem")
                End If

                If Not veri.Item("fizikseldosyaadexcel") Is System.DBNull.Value Then
                    donecekozelraporlog.fizikseldosyaadexcel = veri.Item("fizikseldosyaadexcel")
                End If

                If Not veri.Item("fizikseldosyaadword") Is System.DBNull.Value Then
                    donecekozelraporlog.fizikseldosyaadword = veri.Item("fizikseldosyaadword")
                End If

                If Not veri.Item("fizikseldosyaadpdf") Is System.DBNull.Value Then
                    donecekozelraporlog.fizikseldosyaadpdf = veri.Item("fizikseldosyaadpdf")
                End If

                If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                    donecekozelraporlog.manuelraporpkey = veri.Item("manuelraporpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekozelraporlog

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
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
        "<th>Tarih</th>" + _
        "<th>Rapor Adı</th>" + _
        "<th>Yöntem</th>" + _
        "<th>İndir Excel</th>" + _
        "<th>İndir Word</th>" + _
        "<th>İndir Pdf</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        sqlstr = "select * from ozelraporlog order by pkey desc"

        komut = New SqlCommand(sqlstr, db_baglanti)
        girdi = "0"
        Dim link As String
        Dim pkey, tarih, raporad, yontem, fizikseldosyaadexcel, fizikseldosyaadword, fizikseldosyaadpdf As String
        Dim manuelraporpkey As String
        Dim ajaxlinksil, dugmesil As String

        Dim manuelrapor As New CLASSMANUELRAPOR
        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol2 = "<td>" + tarih + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("manuelraporpkey") Is System.DBNull.Value Then
                        manuelraporpkey = veri.Item("manuelraporpkey")
                        manuelrapor = manuelrapor_erisim.bultek(manuelraporpkey)
                    End If

                    If Not veri.Item("raporad") Is System.DBNull.Value Then
                        raporad = veri.Item("raporad") + " -- " + manuelrapor.ad
                        kol3 = "<td>" + raporad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("yontem") Is System.DBNull.Value Then
                        yontem = veri.Item("yontem")
                        kol4 = "<td>" + yontem + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    'EXCEL İNDİR
                    If Not veri.Item("fizikseldosyaadexcel") Is System.DBNull.Value Then
                        fizikseldosyaadexcel = veri.Item("fizikseldosyaadexcel")
                        link = "otorapor/" + fizikseldosyaadexcel
                        kol5 = "<td><a href='" + link + "'>" + "<img src='images/excel-icon.jpg'></img>" + "</a></td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    'WORD İNDİR
                    If Not veri.Item("fizikseldosyaadword") Is System.DBNull.Value Then
                        fizikseldosyaadword = veri.Item("fizikseldosyaadword")
                        link = "otorapor/" + fizikseldosyaadword
                        kol6 = "<td><a href='" + link + "'>" + "<img src='images/word-icon.jpg'></img>" + "</a></td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    'PDF İNDİR
                    If Not veri.Item("fizikseldosyaadpdf") Is System.DBNull.Value Then
                        fizikseldosyaadpdf = veri.Item("fizikseldosyaadpdf")
                        link = fizikseldosyaadpdf
                        kol7 = "<td><a target='_blank' href='" + link + "'>" + "<img src='images/pdf-icon.jpg'></img>" + "</a></td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "ozelraporlogsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='ozelraporsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol8 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim ozelraporlog As New CLASSOZELRAPORLOG
        ozelraporlog = bultek(pkey)

        Dim path_excel As String
        Dim path_word As String
        Dim path_pdf As String

        path_excel = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + ozelraporlog.fizikseldosyaadexcel
        path_word = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + ozelraporlog.fizikseldosyaadword
        path_pdf = HttpContext.Current.Request.PhysicalApplicationPath + ozelraporlog.fizikseldosyaadpdf

        If System.IO.File.Exists(path_excel) = True Then
            System.IO.File.Delete(path_excel)
        End If
        If System.IO.File.Exists(path_word) = True Then
            System.IO.File.Delete(path_word)
        End If
        If System.IO.File.Exists(path_pdf) = True Then
            System.IO.File.Delete(path_pdf)
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from ozelraporlog where pkey=@pkey"
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


   

  
End Class








