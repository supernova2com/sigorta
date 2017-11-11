Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Security

Public Class CLASSBELEDIYE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim belediye As New CLASSBELEDIYE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal belediye As CLASSBELEDIYE) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(belediye.bucakpkey, Trim(belediye.belediyead))

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçe ve bucağın altında halihazırda bu belediye tanımlanmıştır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into belediye values (@pkey," + _
            "@bucakpkey,@belediyead)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            eklenenpkey = pkeybul()
            param1.Value = eklenenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@bucakpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If belediye.bucakpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = belediye.bucakpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@belediyead", SqlDbType.NVarChar)
            param3.Direction = ParameterDirection.Input
            If belediye.belediyead = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = belediye.belediyead
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
        sqlstr = "select max(pkey) from belediye"
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
    Function Duzenle(ByVal belediye As CLASSBELEDIYE) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi As String
        varmi = ciftkayitkontrol_duzenle(belediye.bucakpkey, Trim(belediye.belediyead), belediye.pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçe ve bucağın altında halihazırda bu belediye tanımlanmıştır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            komut.Connection = db_baglanti
            sqlstr = "update belediye set " + _
            "bucakpkey=@bucakpkey," + _
            "belediyead=@belediyead" + _
            " where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = belediye.pkey
            komut.Parameters.Add(param1)


            Dim param2 As New SqlParameter("@bucakpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If belediye.bucakpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = belediye.bucakpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@belediyead", SqlDbType.NVarChar)
            param3.Direction = ParameterDirection.Input
            If belediye.belediyead = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = belediye.belediyead
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
    Function bultek(ByVal pkey As String) As CLASSBELEDIYE

        Dim komut As New SqlCommand
        Dim donecekbelediye As New CLASSBELEDIYE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from belediye where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbelediye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bucakpkey") Is System.DBNull.Value Then
                    donecekbelediye.bucakpkey = veri.Item("bucakpkey")
                End If

                If Not veri.Item("belediyead") Is System.DBNull.Value Then
                    donecekbelediye.belediyead = veri.Item("belediyead")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbelediye

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        Dim varmi_mahalle As String = mahalle_erisim.belediyevarmi(pkey)

        If varmi_mahalle = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu belediyenin altında mahalleler tanımlandığından bu belediyeyi silemezsiniz"
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from belediye where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSBELEDIYE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbelediye As New CLASSBELEDIYE
        Dim belediyeler As New List(Of CLASSBELEDIYE)
        komut.Connection = db_baglanti
        sqlstr = "select * from belediye order by belediyead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbelediye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bucakpkey") Is System.DBNull.Value Then
                    donecekbelediye.bucakpkey = veri.Item("bucakpkey")
                End If

                If Not veri.Item("belediyead") Is System.DBNull.Value Then
                    donecekbelediye.belediyead = veri.Item("belediyead")
                End If


                belediyeler.Add(New CLASSBELEDIYE(donecekbelediye.pkey, _
               donecekbelediye.bucakpkey, donecekbelediye.belediyead))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return belediyeler

    End Function


    Public Function doldur_sadeceistedigim(ByVal pkey As Integer) As List(Of CLASSBELEDIYE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbelediye As New CLASSBELEDIYE
        Dim belediyeler As New List(Of CLASSBELEDIYE)
        komut.Connection = db_baglanti
        sqlstr = "select * from belediye where pkey=@pkey order by belediyead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbelediye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bucakpkey") Is System.DBNull.Value Then
                    donecekbelediye.bucakpkey = veri.Item("bucakpkey")
                End If

                If Not veri.Item("belediyead") Is System.DBNull.Value Then
                    donecekbelediye.belediyead = veri.Item("belediyead")
                End If

                belediyeler.Add(New CLASSBELEDIYE(donecekbelediye.pkey, _
               donecekbelediye.bucakpkey, donecekbelediye.belediyead))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return belediyeler

    End Function


    Public Function doldurilgili(ByVal bucakpkey As Integer) As List(Of CLASSBELEDIYE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbelediye As New CLASSBELEDIYE
        Dim belediyeler As New List(Of CLASSBELEDIYE)
        komut.Connection = db_baglanti

        sqlstr = "select * from belediye where bucakpkey=@bucakpkey order by belediyead"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bucakpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bucakpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbelediye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bucakpkey") Is System.DBNull.Value Then
                    donecekbelediye.bucakpkey = veri.Item("bucakpkey")
                End If

                If Not veri.Item("belediyead") Is System.DBNull.Value Then
                    donecekbelediye.belediyead = veri.Item("belediyead")
                End If

                belediyeler.Add(New CLASSBELEDIYE(donecekbelediye.pkey, _
               donecekbelediye.bucakpkey, donecekbelediye.belediyead))


            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return belediyeler

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4 As String
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
        "<th>Bucağı</th>" + _
        "<th>Belediye Adı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from belediye order by belediyad"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "ilgilibucagin" Then
            sqlstr = "select * from belediye where bucakpkey=@bucakpkey order by belediyead"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@bucakpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("bucakpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, bucakpkey, belediyead As String

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "belediye.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("bucakpkey") Is System.DBNull.Value Then
                        bucakpkey = veri.Item("bucakpkey")
                    Else
                        bucakpkey = 0
                    End If

                    bucak = bucak_erisim.bultek(bucakpkey)
                    ilce = ilce_erisim.bultek(bucak.ilcepkey)

                    kol2 = "<td>" + ilce.ilcead + "</td>"


                    If Not veri.Item("bucakpkey") Is System.DBNull.Value Then
                        bucakpkey = veri.Item("bucakpkey")
                        bucak = bucak_erisim.bultek(bucakpkey)
                        kol3 = "<td>" + bucak.bucakad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("belediyead") Is System.DBNull.Value Then
                        belediyead = veri.Item("belediyead")
                        kol4 = "<td>" + belediyead + "</td></tr>"
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
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function


    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal bucakpkey As Integer, _
    ByVal belediyead As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from belediye where  bucakpkey=@bucakpkey and belediyead=@belediyead"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@bucakpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bucakpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@belediyead", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = belediyead
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function ciftkayitkontrol_duzenle(ByVal bucakpkey As Integer, _
    ByVal belediyead As String, ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from belediye where bucakpkey=@bucakpkey" + _
        " and belediyead=@belediyead and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bucakpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bucakpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@belediyead", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = belediyead
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


    Function bucakvarmi(ByVal bucakpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from belediye where bucakpkey=@bucakpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@bucakpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bucakpkey
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


    Function dataxmlolustur(ByVal belediye As CLASSBELEDIYE)

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

        kolonlar = vb_erisim.bultumkolonlar(site.sistemveritabaniad, "belediye")

        For Each Item As CLASSVERITABANIKOLONDETAY In kolonlar

            pInfo = belediye.GetType().GetProperty(Item.column_name)
            deger = pInfo.GetValue(belediye, Nothing)

            ic = ic + "<" + Item.column_name + ">" + SecurityElement.Escape(CStr(deger)) +
            "</" + Item.column_name + ">"

        Next

        donecek = enbas + ic + enson
        Return donecek

    End Function


    Public Function belediyebucaginmi(ByVal site As CLASSSITE, ByVal bucakpkey As String, ByVal belediyepkey As String) As String

        Dim kackayit As Integer
        Dim donecek As String = "Hayır"
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "bucakpkey", "=", bucakpkey, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "pkey", "=", belediyepkey, ""))

        kackayit = genericislem_erisim.countgeneric(site.sistemveritabaniad, "belediye", "count(*)", fieldopvalues)
        If kackayit > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function

End Class


