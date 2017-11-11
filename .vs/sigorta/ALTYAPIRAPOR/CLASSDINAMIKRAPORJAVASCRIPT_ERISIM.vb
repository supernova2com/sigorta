Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSDINAMIKRAPORJAVASCRIPT_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dinamikraporjavascript As New CLASSDINAMIKRAPORJAVASCRIPT
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dinamikraporjavascript As CLASSDINAMIKRAPORJAVASCRIPT) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into dinamikraporjavascript values (@pkey," + _
        "@raporpkey,@jv)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dinamikraporjavascript.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = dinamikraporjavascript.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@jv", SqlDbType.Text)
        param3.Direction = ParameterDirection.Input
        If dinamikraporjavascript.jv = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dinamikraporjavascript.jv
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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from dinamikraporjavascript"
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
    Function Duzenle(ByVal dinamikraporjavascript As CLASSDINAMIKRAPORJAVASCRIPT) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update dinamikraporjavascript set " + _
        "raporpkey=@raporpkey," + _
        "jv=@jv" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dinamikraporjavascript.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dinamikraporjavascript.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = dinamikraporjavascript.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@jv", SqlDbType.Text)
        param3.Direction = ParameterDirection.Input
        If dinamikraporjavascript.jv = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dinamikraporjavascript.jv
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
    Function bultek(ByVal pkey As String) As CLASSDINAMIKRAPORJAVASCRIPT

        Dim komut As New SqlCommand
        Dim donecekdinamikraporjavascript As New CLASSDINAMIKRAPORJAVASCRIPT()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporjavascript where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("jv") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.jv = veri.Item("jv")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdinamikraporjavascript

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from dinamikraporjavascript where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSDINAMIKRAPORJAVASCRIPT)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikraporjavascript As New CLASSDINAMIKRAPORJAVASCRIPT
        Dim dinamikraporjavascriptler As New List(Of CLASSDINAMIKRAPORJAVASCRIPT)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikraporjavascript"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("jv") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.jv = veri.Item("jv")
                End If


                dinamikraporjavascriptler.Add(New CLASSDINAMIKRAPORJAVASCRIPT(donecekdinamikraporjavascript.pkey, _
                donecekdinamikraporjavascript.raporpkey, donecekdinamikraporjavascript.jv))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporjavascriptler

    End Function


    Public Function doldurilgili(ByVal raporpkey As Integer) As List(Of CLASSDINAMIKRAPORJAVASCRIPT)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekdinamikraporjavascript As New CLASSDINAMIKRAPORJAVASCRIPT
        Dim dinamikraporjavascriptler As New List(Of CLASSDINAMIKRAPORJAVASCRIPT)
        komut.Connection = db_baglanti
        sqlstr = "select * from dinamikraporjavascript where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("jv") Is System.DBNull.Value Then
                    donecekdinamikraporjavascript.jv = veri.Item("jv")
                End If


                dinamikraporjavascriptler.Add(New CLASSDINAMIKRAPORJAVASCRIPT(donecekdinamikraporjavascript.pkey, _
                donecekdinamikraporjavascript.raporpkey, donecekdinamikraporjavascript.jv))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return dinamikraporjavascriptler

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
        "<th>Script</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from dinamikraporjavascript where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey, jv As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        Dim ajaxlinksil, dugmesil As String

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
                        "&dinamikraporjavascriptop=duzenle" + _
                        "&dinamikraporjavascriptpkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If


                    dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                    kol2 = "<td>" + dinamikrapor.raporad + "</td>"

                    If Not veri.Item("jv") Is System.DBNull.Value Then
                        jv = veri.Item("jv")
                        kol3 = "<td>" + jv + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "dinamikraporjavascriptsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='dinamikraporjavascriptsilbutton' onclick='" + ajaxlinksil + _
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
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function


    Public Function javascriptdosyayarartvegom(ByVal raporpkey As Integer) As CLADBOPRESULT


        Dim result As New CLADBOPRESULT

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)


        Dim jsic As String
        Dim jsler As New List(Of CLASSDINAMIKRAPORJAVASCRIPT)
        jsler = doldurilgili(raporpkey)
        For Each Item As CLASSDINAMIKRAPORJAVASCRIPT In jsler
            jsic = jsic + Item.jv
        Next

        Dim dosyaad, commentenbas As String
        Dim dugmeyukari, dugmeasagi As String
        dugmeyukari = ""
        dugmeasagi = ""

        Dim d As DateTime

        Dim dosyaic As String
        Dim strpath As String
        Dim enson As String
        Dim buyukbosluk As String


        buyukbosluk = System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine
        enson = System.Environment.NewLine + "});//document.ready"


        dosyaic = "/* -------------" + dinamikrapor.raporad + "------------" + System.Environment.NewLine + _
        "@AUTHOR: SUPERNOVA TİCARET VE YAZILIM " + System.Environment.NewLine + _
        "@Bu dosya yazılım tarafından " + d.Now.ToString + " tarihinde otomatik olarak oluşturuldu. */" + _
        buyukbosluk + _
        "$(document).ready(function() {" + buyukbosluk + System.Environment.NewLine + _
        "$('#raporolusturbutton').click(function(e) {" + System.Environment.NewLine + _
        jsic + System.Environment.NewLine + _
        "});" + System.Environment.NewLine + _
        "//---------------------" + System.Environment.NewLine + _
        buyukbosluk + _
        "}); //document.ready"


        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)
        Dim path As String
        dosyaad = "cg_" + CStr(raporpkey) + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".js"
        path = site.path + "otojs/" + dosyaad

        '---------------DOSYAYA YAZ ----------------------------------------------
        strpath = HttpContext.Current.Server.MapPath("/") + "\otojs\" + dosyaad
        Dim fp As New StreamWriter(strpath, False, System.Text.Encoding.UTF8)

        Try
            'File.CreateText(strpath)
            fp.WriteLine(dosyaic)
            fp.Close()
            fp.Dispose()
            result.durum = path
            result.etkilenen = 1
            result.hatastr = ""

        Catch err As Exception
            result.durum = "Kaydedilemedi"
            result.etkilenen = 0
            result.hatastr = err.Message
        Finally
            fp.Close()
            fp.Dispose()
        End Try



        Return result

    End Function


 
End Class


