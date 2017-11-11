Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Security

Public Class CLASSILCE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim ilce As New CLASSILCE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal ilce As CLASSILCE) As CLADBOPRESULT

        Dim eklenenpkey As Integer
        etkilenen = 0
        Dim varmi1, varmi2 As String
        varmi1 = ciftkayitkontrol("ilcead", Trim(ilce.ilcead))
        varmi2 = ciftkayitkontrol("ilcekod", Trim(ilce.ilcekod))

        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçe adıyla halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçe koduyla halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into ilce values (@pkey," + _
        "@ilcead,@ilcekod)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        eklenenpkey = pkeybul()
        param1.Value = eklenenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ilcead", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        If ilce.ilcead = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ilce.ilcead
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ilcekod", SqlDbType.Char)
        param3.Direction = ParameterDirection.Input
        If ilce.ilcekod = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ilce.ilcekod
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


        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from ilce"
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
    Function Duzenle(ByVal ilce As CLASSILCE) As CLADBOPRESULT

        etkilenen = 0

        Dim varmi1, varmi2 As String
        varmi1 = ciftkayitkontrol_duzenleme("ilcead", Trim(ilce.ilcead), ilce.pkey)
        varmi2 = ciftkayitkontrol_duzenleme("ilcekod", Trim(ilce.ilcekod), ilce.pkey)

        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçe adıyla halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçe koduyla halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update ilce set " + _
        "ilcead=@ilcead," + _
        "ilcekod=@ilcekod" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ilce.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ilcead", SqlDbType.NVarChar)
        param2.Direction = ParameterDirection.Input
        If ilce.ilcead = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ilce.ilcead
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ilcekod", SqlDbType.Char)
        param3.Direction = ParameterDirection.Input
        If ilce.ilcekod = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ilce.ilcekod
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
    Function bultek(ByVal pkey As String) As CLASSILCE

        Dim komut As New SqlCommand
        Dim donecekilce As New CLASSILCE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ilce where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekilce.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcead") Is System.DBNull.Value Then
                    donecekilce.ilcead = veri.Item("ilcead")
                End If

                If Not veri.Item("ilcekod") Is System.DBNull.Value Then
                    donecekilce.ilcekod = veri.Item("ilcekod")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekilce

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        Dim varmi_ilce As String = bucak_erisim.ilcevarmi(pkey)

        If varmi_ilce = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ilçenin altında bucaklar tanımlandığından bu ilçeyi silemezsiniz"
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from ilce where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSILCE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekilce As New CLASSILCE
        Dim ilceler As New List(Of CLASSILCE)
        komut.Connection = db_baglanti
        sqlstr = "select * from ilce order by pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekilce.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcead") Is System.DBNull.Value Then
                    donecekilce.ilcead = veri.Item("ilcead")
                End If

                If Not veri.Item("ilcekod") Is System.DBNull.Value Then
                    donecekilce.ilcekod = veri.Item("ilcekod")
                End If

                ilceler.Add(New CLASSILCE(donecekilce.pkey, _
                donecekilce.ilcead, donecekilce.ilcekod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ilceler

    End Function


    Public Function doldur_sadeceistedigim(ByVal pkey As Integer) As List(Of CLASSILCE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekilce As New CLASSILCE
        Dim ilceler As New List(Of CLASSILCE)
        komut.Connection = db_baglanti
        sqlstr = "select * from ilce where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekilce.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ilcead") Is System.DBNull.Value Then
                    donecekilce.ilcead = veri.Item("ilcead")
                End If

                If Not veri.Item("ilcekod") Is System.DBNull.Value Then
                    donecekilce.ilcekod = veri.Item("ilcekod")
                End If

                ilceler.Add(New CLASSILCE(donecekilce.pkey, _
                donecekilce.ilcead, donecekilce.ilcekod))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ilceler

    End Function


    Public Function doldur_ilgilibelediyeninbaglioldugu(ByVal belediyepkey As Integer) As List(Of CLASSILCE)

        Dim ilceler As New List(Of CLASSILCE)
        Dim bucaklar As New List(Of CLASSBUCAK)
        Dim bucak_erisim As New CLASSBUCAK_ERISIM

        bucaklar = bucak_erisim.doldurilgilibelediyenin(belediyepkey)
        For Each itembucak As CLASSBUCAK In bucaklar
            Dim ilce As New CLASSILCE
            ilce = bultek(itembucak.ilcepkey)
            If ilceler.Contains(ilce) = False Then
                ilceler.Add(ilce)
            End If
        Next

        Return ilceler

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
        "<th>İlçe Adı</th>" + _
        "<th>İlçe Kodu</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from ilce"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, ilcead, ilcekod As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "ilce.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("ilcead") Is System.DBNull.Value Then
                        ilcead = veri.Item("ilcead")
                        kol2 = "<td>" + ilcead + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("ilcekod") Is System.DBNull.Value Then
                        ilcekod = veri.Item("ilcekod")
                        kol3 = "<td>" + ilcekod + "</td></tr>"
                    Else
                        kol3 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
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
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ilce where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.NVarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
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


    Function ciftkayitkontrol_duzenleme(ByVal tablecol As String, ByVal kriter As String, _
    ByVal pkey As Integer) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ilce where " + tablecol + "=@kriter and pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.NVarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = pkey
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


    Function dataxmlolustur(ByVal ilce As CLASSILCE)

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

        kolonlar = vb_erisim.bultumkolonlar(site.sistemveritabaniad, "ilce")

        For Each Item As CLASSVERITABANIKOLONDETAY In kolonlar

            pInfo = ilce.GetType().GetProperty(Item.column_name)
            deger = pInfo.GetValue(ilce, Nothing)

            ic = ic + "<" + Item.column_name + ">" + SecurityElement.Escape(CStr(deger)) + _
            "</" + Item.column_name + ">"

        Next

        donecek = enbas + ic + enson
        Return donecek

    End Function


End Class
