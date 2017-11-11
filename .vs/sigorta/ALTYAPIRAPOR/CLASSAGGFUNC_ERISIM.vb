Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSAGGFUNC_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim aggfunc As New CLASSAGGFUNC
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal aggfunc As CLASSAGGFUNC) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(aggfunc.raporpkey, aggfunc.fonksiyonad, aggfunc.ktablopkey, aggfunc.fieldad)


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

            sqlstr = "insert into aggfunc values (@pkey," + _
            "@raporpkey,@fonksiyonad,@sayialias,@ktablopkey," + _
            "@fieldad,@fonksiyontip,@fonksiyonsql,@kolonbaslik)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If aggfunc.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = aggfunc.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@fonksiyonad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If aggfunc.fonksiyonad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = aggfunc.fonksiyonad
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@sayialias", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If aggfunc.sayialias = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = aggfunc.sayialias
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@ktablopkey", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If aggfunc.ktablopkey = 0 Then
                param5.Value = 0
            Else
                param5.Value = aggfunc.ktablopkey
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@fieldad", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If aggfunc.fieldad = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = aggfunc.fieldad
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@fonksiyontip", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If aggfunc.fonksiyontip = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = aggfunc.fonksiyontip
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@fonksiyonsql", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If aggfunc.fonksiyonsql = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = aggfunc.fonksiyonsql
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@kolonbaslik", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If aggfunc.kolonbaslik = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = aggfunc.kolonbaslik
            End If
            komut.Parameters.Add(param9)

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
        sqlstr = "select max(pkey) from aggfunc"
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
    Function Duzenle(ByVal aggfunc As CLASSAGGFUNC) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update aggfunc set " + _
        "raporpkey=@raporpkey," + _
        "fonksiyonad=@fonksiyonad," + _
        "sayialias=@sayialias," + _
        "ktablopkey=@ktablopkey," + _
        "fieldad=@fieldad," + _
        "fonksiyontip=@fonksiyontip," + _
        "fonksiyonsql=@fonksiyonsql," + _
        "kolonbaslik=@kolonbaslik" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aggfunc.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If aggfunc.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = aggfunc.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@fonksiyonad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If aggfunc.fonksiyonad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = aggfunc.fonksiyonad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sayialias", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If aggfunc.sayialias = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = aggfunc.sayialias
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ktablopkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If aggfunc.ktablopkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = aggfunc.ktablopkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If aggfunc.fieldad = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = aggfunc.fieldad
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@fonksiyontip", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If aggfunc.fonksiyontip = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = aggfunc.fonksiyontip
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@fonksiyonsql", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If aggfunc.fonksiyonsql = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = aggfunc.fonksiyonsql
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@kolonbaslik", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If aggfunc.kolonbaslik = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = aggfunc.kolonbaslik
        End If
        komut.Parameters.Add(param9)

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
    Function bultek(ByVal pkey As String) As CLASSAGGFUNC

        Dim komut As New SqlCommand
        Dim donecekaggfunc As New CLASSAGGFUNC()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aggfunc where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaggfunc.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekaggfunc.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fonksiyonad") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyonad = veri.Item("fonksiyonad")
                End If

                If Not veri.Item("sayialias") Is System.DBNull.Value Then
                    donecekaggfunc.sayialias = veri.Item("sayialias")
                End If

                If Not veri.Item("ktablopkey") Is System.DBNull.Value Then
                    donecekaggfunc.ktablopkey = veri.Item("ktablopkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekaggfunc.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("fonksiyontip") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyontip = veri.Item("fonksiyontip")
                End If

                If Not veri.Item("fonksiyonsql") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyonsql = veri.Item("fonksiyonsql")
                End If

                If Not veri.Item("kolonbaslik") Is System.DBNull.Value Then
                    donecekaggfunc.kolonbaslik = veri.Item("kolonbaslik")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekaggfunc

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim aggfunc As New CLASSAGGFUNC
        aggfunc = bultek(pkey)

        Dim varmi As String
        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM

        varmi = dinamikraporgrafik_erisim.kolonsayivarmi(aggfunc.raporpkey, aggfunc.sayialias)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıt grafik tarafından kullanılmaktadır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from aggfunc where pkey=@pkey"
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
        sqlstr = "delete from aggfunc where raporpkey=@raporpkey"
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
    Public Function doldur() As List(Of CLASSAGGFUNC)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaggfunc As New CLASSAGGFUNC
        Dim aggfuncler As New List(Of CLASSAGGFUNC)
        komut.Connection = db_baglanti
        sqlstr = "select * from aggfunc"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaggfunc.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekaggfunc.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fonksiyonad") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyonad = veri.Item("fonksiyonad")
                End If

                If Not veri.Item("sayialias") Is System.DBNull.Value Then
                    donecekaggfunc.sayialias = veri.Item("sayialias")
                End If

                If Not veri.Item("ktablopkey") Is System.DBNull.Value Then
                    donecekaggfunc.ktablopkey = veri.Item("ktablopkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekaggfunc.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("fonksiyontip") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyontip = veri.Item("fonksiyontip")
                End If

                If Not veri.Item("fonksiyonsql") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyonsql = veri.Item("fonksiyonsql")
                End If

                If Not veri.Item("kolonbaslik") Is System.DBNull.Value Then
                    donecekaggfunc.kolonbaslik = veri.Item("kolonbaslik")
                End If

                aggfuncler.Add(New CLASSAGGFUNC(donecekaggfunc.pkey, _
                donecekaggfunc.raporpkey, donecekaggfunc.fonksiyonad, donecekaggfunc.sayialias, _
                donecekaggfunc.ktablopkey, donecekaggfunc.fieldad, _
                donecekaggfunc.fonksiyontip, donecekaggfunc.fonksiyonsql, _
                donecekaggfunc.kolonbaslik))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aggfuncler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As String) As List(Of CLASSAGGFUNC)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekaggfunc As New CLASSAGGFUNC
        Dim aggfuncler As New List(Of CLASSAGGFUNC)
        komut.Connection = db_baglanti
        sqlstr = "select * from aggfunc where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekaggfunc.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekaggfunc.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fonksiyonad") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyonad = veri.Item("fonksiyonad")
                End If

                If Not veri.Item("sayialias") Is System.DBNull.Value Then
                    donecekaggfunc.sayialias = veri.Item("sayialias")
                End If

                If Not veri.Item("ktablopkey") Is System.DBNull.Value Then
                    donecekaggfunc.ktablopkey = veri.Item("ktablopkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekaggfunc.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("fonksiyontip") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyontip = veri.Item("fonksiyontip")
                End If

                If Not veri.Item("fonksiyonsql") Is System.DBNull.Value Then
                    donecekaggfunc.fonksiyonsql = veri.Item("fonksiyonsql")
                End If

                If Not veri.Item("kolonbaslik") Is System.DBNull.Value Then
                    donecekaggfunc.kolonbaslik = veri.Item("kolonbaslik")
                End If

                aggfuncler.Add(New CLASSAGGFUNC(donecekaggfunc.pkey, _
                donecekaggfunc.raporpkey, donecekaggfunc.fonksiyonad, donecekaggfunc.sayialias, _
                donecekaggfunc.ktablopkey, donecekaggfunc.fieldad, donecekaggfunc.fonksiyontip, _
                donecekaggfunc.fonksiyonsql, donecekaggfunc.kolonbaslik))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return aggfuncler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10 As String
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
        "<th>Fonksiyon</th>" + _
        "<th>Tablo İsmi</th>" + _
        "<th>Alan İsmi</th>" + _
        "<th>Sql Alias</th>" + _
        "<th>Fonksiyon Tipi</th>" + _
        "<th>SQL</th>" + _
        "<th>Kolon Başlığı</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from aggfunc where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey, fonksiyonad, sayialias, ktablopkey, fieldad As String
        Dim ajaxlinksil, dugmesil As String
        Dim fonksiyontip, fonksiyonsql As String
        Dim kolonbaslik As String

        Dim kullanilacaktablo As New CLASSKULLANILACAKTABLO
        Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM


        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

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
                        "&aggfuncop=duzenle" + _
                        "&aggfuncpkey=" + CStr(pkey)

                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    End If

                    If Not veri.Item("fonksiyonad") Is System.DBNull.Value Then
                        fonksiyonad = veri.Item("fonksiyonad")
                        kol3 = "<td>" + fonksiyonad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("ktablopkey") Is System.DBNull.Value Then
                        ktablopkey = veri.Item("ktablopkey")
                        kullanilacaktablo = kullanilacaktablo_erisim.bultek(ktablopkey)
                        kol4 = "<td>" + kullanilacaktablo.tabload + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldad") Is System.DBNull.Value Then
                        fieldad = veri.Item("fieldad")
                        kol5 = "<td>" + fieldad + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If


                    If Not veri.Item("sayialias") Is System.DBNull.Value Then
                        sayialias = veri.Item("sayialias")
                        kol6 = "<td>" + sayialias + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If


                    If Not veri.Item("fonksiyontip") Is System.DBNull.Value Then
                        fonksiyontip = veri.Item("fonksiyontip")
                        kol7 = "<td>" + fonksiyontip + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If


                    If Not veri.Item("fonksiyonsql") Is System.DBNull.Value Then
                        fonksiyonsql = veri.Item("fonksiyonsql")
                        kol8 = "<td>" + fonksiyonsql + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("kolonbaslik") Is System.DBNull.Value Then
                        kolonbaslik = veri.Item("kolonbaslik")
                        kol9 = "<td>" + kolonbaslik + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "aggfuncsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='aggfuncsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol10 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10

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
    Function ciftkayitkontrol(ByVal raporpkey As String, ByVal fonksiyonad As String, _
    ByVal ktablopkey As String, ByVal fieldad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aggfunc where " + _
        "raporpkey=@raporpkey and fonksiyonad=@fonksiyonad and " + _
        "ktablopkey=@ktablopkey and fieldad=@fieldad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@fonksiyonad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = fonksiyonad
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ktablopkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = ktablopkey
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = fieldad
        komut.Parameters.Add(param4)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function kullanilacaktablovarmi(ByVal raporpkey As Integer, ByVal ktablopkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from aggfunc where raporpkey=@raporpkey and ktablopkey=@ktablopkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ktablopkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = ktablopkey
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


