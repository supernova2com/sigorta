Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Security

Public Class CLASSBUCAK_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim bucak As New CLASSBUCAK
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal bucak As CLASSBUCAK) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(bucak.ilcepkey, Trim(bucak.bucakad))

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçenin altında halihazırda bu bucağın kaydı vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into bucak values (@pkey," + _
            "@ilcepkey,@bucakad)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            eklenenpkey = pkeybul()
            param1.Value = eklenenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ilcepkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If bucak.ilcepkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = bucak.ilcepkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@bucakad", SqlDbType.NVarChar)
            param3.Direction = ParameterDirection.Input
            If bucak.bucakad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = bucak.bucakad
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
                resultset.etkilenen = eklenenpkey
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
        sqlstr = "select max(pkey) from bucak"
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
    Function Duzenle(ByVal bucak As CLASSBUCAK) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(bucak.ilcepkey, Trim(bucak.bucakad), bucak.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçenin altında halihazırda bu bucağın kaydı vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            komut.Connection = db_baglanti
            sqlstr = "update bucak set " + _
            "ilcepkey=@ilcepkey," + _
            "bucakad=@bucakad" + _
            " where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = bucak.pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ilcepkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If bucak.ilcepkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = bucak.ilcepkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@bucakad", SqlDbType.NVarChar)
            param3.Direction = ParameterDirection.Input
            If bucak.bucakad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = bucak.bucakad
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

        End If


        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSBUCAK

        Dim komut As New SqlCommand
        Dim donecekbucak As New CLASSBUCAK()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bucak where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbucak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcepkey") Is System.DBNull.Value Then
                    donecekbucak.ilcepkey = veri.Item("ilcepkey")
                End If

                If Not veri.Item("bucakad") Is System.DBNull.Value Then
                    donecekbucak.bucakad = veri.Item("bucakad")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbucak

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        Dim varmi_belediye As String = belediye_erisim.bucakvarmi(pkey)

        If varmi_belediye = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu bucağın altında belediyeler tanımlandığından bu bucağı silemezsiniz"
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from bucak where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSBUCAK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbucak As New CLASSBUCAK
        Dim bucakler As New List(Of CLASSBUCAK)
        komut.Connection = db_baglanti
        sqlstr = "select * from bucak order by bucakad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbucak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcepkey") Is System.DBNull.Value Then
                    donecekbucak.ilcepkey = veri.Item("ilcepkey")
                End If

                If Not veri.Item("bucakad") Is System.DBNull.Value Then
                    donecekbucak.bucakad = veri.Item("bucakad")
                End If

                bucakler.Add(New CLASSBUCAK(donecekbucak.pkey, _
                donecekbucak.ilcepkey, donecekbucak.bucakad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bucakler

    End Function


    Public Function doldur_sadeceistedigim(ByVal pkey As Integer) As List(Of CLASSBUCAK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbucak As New CLASSBUCAK
        Dim bucakler As New List(Of CLASSBUCAK)
        komut.Connection = db_baglanti
        sqlstr = "select * from bucak where pkey=@pkey order by bucakad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbucak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcepkey") Is System.DBNull.Value Then
                    donecekbucak.ilcepkey = veri.Item("ilcepkey")
                End If

                If Not veri.Item("bucakad") Is System.DBNull.Value Then
                    donecekbucak.bucakad = veri.Item("bucakad")
                End If

                bucakler.Add(New CLASSBUCAK(donecekbucak.pkey, _
                donecekbucak.ilcepkey, donecekbucak.bucakad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bucakler

    End Function

    Public Function doldurilgili(ByVal ilcepkey As Integer) As List(Of CLASSBUCAK)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbucak As New CLASSBUCAK
        Dim bucakler As New List(Of CLASSBUCAK)
        komut.Connection = db_baglanti

        sqlstr = "select * from bucak where ilcepkey=@ilcepkey order by bucakad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@ilcepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ilcepkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbucak.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcepkey") Is System.DBNull.Value Then
                    donecekbucak.ilcepkey = veri.Item("ilcepkey")
                End If

                If Not veri.Item("bucakad") Is System.DBNull.Value Then
                    donecekbucak.bucakad = veri.Item("bucakad")
                End If

                bucakler.Add(New CLASSBUCAK(donecekbucak.pkey, _
                donecekbucak.ilcepkey, donecekbucak.bucakad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bucakler

    End Function


    Public Function doldurilgilibelediyenin(ByVal belediyepkey As Integer) As List(Of CLASSBUCAK)

        Dim donecekbucak As New CLASSBUCAK
        Dim bucaklar As New List(Of CLASSBUCAK)

        Dim belediyeler As New List(Of CLASSBELEDIYE)
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        Dim belediye As New CLASSBELEDIYE
        belediye = belediye_erisim.bultek(belediyepkey)

        belediyeler = belediye_erisim.doldurilgili(belediye.bucakpkey)
        For Each itembelediye As CLASSBELEDIYE In belediyeler

            Dim bucak As New CLASSBUCAK
            bucak = bultek(itembelediye.bucakpkey)
            If bucaklar.Contains(bucak) = False Then
                bucaklar.Add(bucak)
            End If

        Next

        Return bucaklar

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
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
        "<th>İlçesi</th>" + _
        "<th>Bucak Adı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from bucak"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "ilgiliilcenin" Then
            sqlstr = "select * from bucak where ilcepkey=@ilcepkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@ilcepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("ilcepkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, ilcepkey, bucakad As String

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "bucak.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("ilcepkey") Is System.DBNull.Value Then
                        ilcepkey = veri.Item("ilcepkey")
                        ilce = ilce_erisim.bultek(ilcepkey)
                        kol2 = "<td>" + ilce.ilcead + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("bucakad") Is System.DBNull.Value Then
                        bucakad = veri.Item("bucakad")
                        kol3 = "<td>" + bucakad + "</td></tr>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
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
    Function ciftkayitkontrol(ByVal ilcepkey As Integer, ByVal bucakad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bucak where ilcepkey=@ilcepkey and bucakad=@bucakad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ilcepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ilcepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bucakad", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = bucakad
        komut.Parameters.Add(param2)

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


    '--- ÇİFT KAYIT KONTROL DÜZENLEME İÇİN -------------------------------------------------------
    Function ciftkayitkontrol_duzenle(ByVal ilcepkey As Integer, ByVal bucakad As String, ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bucak where ilcepkey=@ilcepkey and bucakad=@bucakad and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ilcepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ilcepkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bucakad", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = bucakad
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@pkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = pkey
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


    Function ilcevarmi(ByVal ilcepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bucak where ilcepkey=@ilcepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@ilcepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ilcepkey
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


    Function dataxmlolustur(ByVal bucak As CLASSBUCAK)

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

        kolonlar = vb_erisim.bultumkolonlar(site.sistemveritabaniad, "bucak")

        For Each Item As CLASSVERITABANIKOLONDETAY In kolonlar

            pInfo = bucak.GetType().GetProperty(Item.column_name)
            deger = pInfo.GetValue(bucak, Nothing)

            ic = ic + "<" + Item.column_name + ">" + SecurityElement.Escape(CStr(deger)) + _
            "</" + Item.column_name + ">"

        Next

        donecek = enbas + ic + enson
        Return donecek

    End Function

    Public Function bucakilceninmi(ByVal site As CLASSSITE, ByVal ilcepkey As String, ByVal bucakpkey As String) As String

        Dim kackayit As Integer
        Dim donecek As String = "Hayır"
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ilcepkey", "=", ilcepkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "=", bucakpkey, ""))

        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "bucak", "count(*)", fieldopvalues)
        If kackayit > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function
End Class

