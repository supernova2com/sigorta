Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Security

Public Class CLASSSOKAK_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sokak As New CLASSSOKAK
    Dim resultset As New CLADBOPRESULT


    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sokak As CLASSSOKAK) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(sokak.mahallepkey, Trim(sokak.sokakad))

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu mahallenin altında halihazırda bu sokak kaydı veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If



        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into sokak values (@pkey," + _
        "@mahallepkey,@sokakad,@sokaktur)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        eklenenpkey = pkeybul()
        param1.Value = eklenenpkey
        'param1.Value = sokak.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@mahallepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sokak.mahallepkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sokak.mahallepkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sokakad", SqlDbType.NVarChar)
        param3.Direction = ParameterDirection.Input
        If sokak.sokakad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sokak.sokakad
        End If
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@sokaktur", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sokak.sokaktur = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sokak.sokaktur
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
            resultset.etkilenen = eklenenpkey
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
        sqlstr = "select max(pkey) from sokak"
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
    Function Duzenle(ByVal sokak As CLASSSOKAK) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi As Integer
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "mahallepkey", "=", sokak.mahallepkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "sokakad", "=", Trim(sokak.sokakad), " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "<>", sokak.pkey, " "))
        varmi = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "sokak", "count(*)", fieldopvalues)

        If varmi > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu mahallenin altında halihazırda bu sokak kaydı veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sokak set " + _
        "mahallepkey=@mahallepkey," + _
        "sokakad=@sokakad," + _
        "sokaktur=@sokaktur" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sokak.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@mahallepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sokak.mahallepkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sokak.mahallepkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sokakad", SqlDbType.NVarChar)
        param3.Direction = ParameterDirection.Input
        If sokak.sokakad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sokak.sokakad
        End If
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@sokaktur", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sokak.sokaktur = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sokak.sokaktur
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
    Function bultek(ByVal pkey As String) As CLASSSOKAK

        Dim komut As New SqlCommand
        Dim doneceksokak As New CLASSSOKAK()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sokak where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksokak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("mahallepkey") Is System.DBNull.Value Then
                    doneceksokak.mahallepkey = veri.Item("mahallepkey")
                End If

                If Not veri.Item("sokakad") Is System.DBNull.Value Then
                    doneceksokak.sokakad = veri.Item("sokakad")
                End If

                If Not veri.Item("sokaktur") Is System.DBNull.Value Then
                    doneceksokak.sokaktur = veri.Item("sokaktur")
                End If



            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksokak

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from sokak where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSOKAK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksokak As New CLASSSOKAK
        Dim sokakler As New List(Of CLASSSOKAK)
        komut.Connection = db_baglanti
        sqlstr = "select * from sokak order by sokakad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksokak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("mahallepkey") Is System.DBNull.Value Then
                    doneceksokak.mahallepkey = veri.Item("mahallepkey")
                End If

                If Not veri.Item("sokakad") Is System.DBNull.Value Then
                    doneceksokak.sokakad = veri.Item("sokakad")
                End If

                If Not veri.Item("sokaktur") Is System.DBNull.Value Then
                    doneceksokak.sokaktur = veri.Item("sokaktur")
                End If


                sokakler.Add(New CLASSSOKAK(doneceksokak.pkey, _
                doneceksokak.mahallepkey, doneceksokak.sokakad, doneceksokak.sokaktur))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sokakler

    End Function


    Public Function doldurilgili(ByVal mahallepkey As Integer) As List(Of CLASSSOKAK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksokak As New CLASSSOKAK
        Dim sokakler As New List(Of CLASSSOKAK)
        komut.Connection = db_baglanti
        sqlstr = "select * from sokak where mahallepkey=@mahallepkey order by sokakad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@mahallepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = mahallepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksokak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("mahallepkey") Is System.DBNull.Value Then
                    doneceksokak.mahallepkey = veri.Item("mahallepkey")
                End If

                If Not veri.Item("sokakad") Is System.DBNull.Value Then
                    doneceksokak.sokakad = veri.Item("sokakad")
                End If

                If Not veri.Item("sokaktur") Is System.DBNull.Value Then
                    doneceksokak.sokaktur = veri.Item("sokaktur")
                End If


                sokakler.Add(New CLASSSOKAK(doneceksokak.pkey, _
                doneceksokak.mahallepkey, doneceksokak.sokakad, doneceksokak.sokaktur))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sokakler

    End Function


    Public Function doldurilgili_sokaktur(ByVal mahallepkey As Integer, ByVal sokaktur As String) As List(Of CLASSSOKAK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksokak As New CLASSSOKAK
        Dim sokakler As New List(Of CLASSSOKAK)
        komut.Connection = db_baglanti
        sqlstr = "select * from sokak where mahallepkey=@mahallepkey and sokaktur=@sokaktur order by sokakad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@mahallepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = mahallepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sokaktur", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = sokaktur
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksokak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("mahallepkey") Is System.DBNull.Value Then
                    doneceksokak.mahallepkey = veri.Item("mahallepkey")
                End If

                If Not veri.Item("sokakad") Is System.DBNull.Value Then
                    doneceksokak.sokakad = veri.Item("sokakad")
                End If

                If Not veri.Item("sokaktur") Is System.DBNull.Value Then
                    doneceksokak.sokaktur = veri.Item("sokaktur")
                End If

                sokakler.Add(New CLASSSOKAK(doneceksokak.pkey, _
                doneceksokak.mahallepkey, doneceksokak.sokakad, doneceksokak.sokaktur))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sokakler

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

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>İlçe</th>" + _
        "<th>Bucak</th>" + _
        "<th>Belediye</th>" + _
        "<th>Mahalle</th>" + _
        "<th>Sokak Adı</th>" + _
        "<th>Sokak Türü</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from sokak order by sokakad"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        If HttpContext.Current.Session("ltip") = "ilgilimahallenin" Then
            sqlstr = "select * from sokak where mahallepkey=@mahallepkey order by sokakad"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@mahallepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("mahallepkey")
            komut.Parameters.Add(param1)

        End If



        If HttpContext.Current.Session("ltip") = "ilgilimahalleninvesokaktur" Then

            sqlstr = "select * from sokak where mahallepkey=@mahallepkey and sokaktur=@sokaktur order by sokakad"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@mahallepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("mahallepkey")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sokaktur", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("sokaktur")
            komut.Parameters.Add(param2)

        End If


        girdi = "0"
        Dim link As String
        Dim pkey, mahallepkey, sokakad, sokaktur As String

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM
        Dim bucak As New CLASSBUCAK
        Dim bucak_Erisim As New CLASSBUCAK_ERISIM
        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "sokak.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("mahallepkey") Is System.DBNull.Value Then
                        mahallepkey = veri.Item("mahallepkey")
                    Else
                        mahallepkey = 0
                    End If

                    mahalle = mahalle_erisim.bultek(mahallepkey)
                    belediye = belediye_erisim.bultek(mahalle.belediyepkey)
                    bucak = bucak_Erisim.bultek(belediye.bucakpkey)
                    ilce = ilce_erisim.bultek(bucak.ilcepkey)


                    kol2 = "<td>" + ilce.ilcead + "</td>"
                    kol3 = "<td>" + bucak.bucakad + "</td>"
                    kol4 = "<td>" + belediye.belediyead + "</td>"
                    kol5 = "<td>" + mahalle.mahallead + "</td>"


                    If Not veri.Item("sokakad") Is System.DBNull.Value Then
                        sokakad = veri.Item("sokakad")
                        kol6 = "<td>" + sokakad + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("sokaktur") Is System.DBNull.Value Then
                        sokaktur = veri.Item("sokaktur")
                        kol7 = "<td>" + sokaktur + "</td></tr>"
                    Else
                        kol7 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal mahallepkey As Integer, ByVal sokakad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sokak where mahallepkey=@mahallepkey and sokakad=@sokakad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@mahallepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = mahallepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sokakad", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = sokakad
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function mahallevarmi(ByVal mahallepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sokak where mahallepkey=@mahallepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@mahallepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = mahallepkey
        komut.Parameters.Add(param1)

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


    Public Function toplamsokaksayisi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from sokak"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            toplam = 0
        Else
            toplam = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return toplam

    End Function

    Function dataxmlolustur(ByVal sokak As CLASSSOKAK)

        Dim pInfo As System.Reflection.PropertyInfo
        Dim deger
        Dim donecek, enbas, ic, enson As String
        enbas = "<root>"
        enson = "</root>"

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim tablokolonlari As New CLASSVERITABANI
        Dim vb_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
        Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)

        kolonlar = vb_erisim.bultumkolonlar(site.sistemveritabaniad, "sokak")

        For Each Item As CLASSVERITABANIKOLONDETAY In kolonlar

            pInfo = sokak.GetType().GetProperty(Item.column_name)
            deger = pInfo.GetValue(sokak, Nothing)

            ic = ic + "<" + Item.column_name + ">" + SecurityElement.Escape(CStr(deger)) +
            "</" + Item.column_name + ">"

        Next

        donecek = enbas + ic + enson
        Return donecek

    End Function


    Public Function sokakmahalleninmi(ByVal site As CLASSSITE, ByVal mahallepkey As String, ByVal sokakpkey As String) As String

        Dim kackayit As Integer
        Dim donecek As String = "Hayır"
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "mahallepkey", "=", mahallepkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "=", sokakpkey, ""))

        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "sokak", "count(*)", fieldopvalues)
        If kackayit > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function

End Class


