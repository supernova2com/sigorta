Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSSINIRKAPI_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sinirkapi As New CLASSSINIRKAPI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sinirkapi As CLASSSINIRKAPI) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi1, varmi2 As String
        varmi1 = ciftkayitkontrol("sinirkapiad", sinirkapi.sinirkapiad)
        varmi2 = ciftkayitkontrol("sinirkapikod", sinirkapi.sinirkapikod)


        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu isimde sınır kapısı veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kodda sınır kapısı veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into sinirkapi values (@pkey," + _
        "@sinirkapiad,@sinirkapikod,@ipdikkat)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If sinirkapi.sinirkapiad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = sinirkapi.sinirkapiad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sinirkapikod", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If sinirkapi.sinirkapikod = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sinirkapi.sinirkapikod
        End If
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@ipdikkat", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sinirkapi.ipdikkat = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sinirkapi.ipdikkat
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
        sqlstr = "select max(pkey) from sinirkapi"
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
    Function Duzenle(ByVal sinirkapi As CLASSSINIRKAPI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sinirkapi set " + _
        "sinirkapiad=@sinirkapiad," + _
        "sinirkapikod=@sinirkapikod," + _
        "ipdikkat=@ipdikkat" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapi.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapiad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If sinirkapi.sinirkapiad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = sinirkapi.sinirkapiad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sinirkapikod", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If sinirkapi.sinirkapikod = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = sinirkapi.sinirkapikod
        End If
        komut.Parameters.Add(param3)


        Dim param4 As New SqlParameter("@ipdikkat", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sinirkapi.ipdikkat = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sinirkapi.ipdikkat
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
    Function bultek(ByVal pkey As String) As CLASSSINIRKAPI

        Dim komut As New SqlCommand
        Dim doneceksinirkapi As New CLASSsinirkapi()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapi where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapiad") Is System.DBNull.Value Then
                    doneceksinirkapi.sinirkapiad = veri.Item("sinirkapiad")
                End If

                If Not veri.Item("sinirkapikod") Is System.DBNull.Value Then
                    doneceksinirkapi.sinirkapikod = veri.Item("sinirkapikod")
                End If


                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksinirkapi.ipdikkat = veri.Item("ipdikkat")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksinirkapi

    End Function


    Function bultek_kapikodgore(ByVal sinirkapikod As String) As CLASSSINIRKAPI

        Dim komut As New SqlCommand
        Dim doneceksinirkapi As New CLASSSINIRKAPI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapi where sinirkapikod=@sinirkapikod"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sinirkapikod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapikod
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapiad") Is System.DBNull.Value Then
                    doneceksinirkapi.sinirkapiad = veri.Item("sinirkapiad")
                End If

                If Not veri.Item("sinirkapikod") Is System.DBNull.Value Then
                    doneceksinirkapi.sinirkapikod = veri.Item("sinirkapikod")
                End If


                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksinirkapi.ipdikkat = veri.Item("ipdikkat")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksinirkapi

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim varmi_ip As String
        Dim sinirkapiip_erisim As New CLASSSINIRKAPIIP_ERISIM
        varmi_ip = sinirkapiip_erisim.varmisinirkapi(pkey)

        If varmi_ip = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu sınır kapısı altında ip adresleri tanımlanmış. Bu sınır kapısını silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from sinirkapi where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSINIRKAPI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksinirkapi As New CLASSsinirkapi
        Dim sinirkapiler As New List(Of CLASSsinirkapi)
        komut.Connection = db_baglanti
        sqlstr = "select * from sinirkapi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapi.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapiad") Is System.DBNull.Value Then
                    doneceksinirkapi.sinirkapiad = veri.Item("sinirkapiad")
                End If

                If Not veri.Item("sinirkapikod") Is System.DBNull.Value Then
                    doneceksinirkapi.sinirkapikod = veri.Item("sinirkapikod")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksinirkapi.ipdikkat = veri.Item("ipdikkat")
                End If

                sinirkapiler.Add(New CLASSSINIRKAPI(doneceksinirkapi.pkey, _
                doneceksinirkapi.sinirkapiad, doneceksinirkapi.sinirkapikod, _
                doneceksinirkapi.ipdikkat))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sinirkapiler

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

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>IP Adresleri</th>" + _
        "<th>Sınır Kapı Adı</th>" + _
        "<th>Sınır Kapı Kodu</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from sinirkapi"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sinirkapiad, sinirkapikod As String
        Dim linkip As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "sinirkapi.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    linkip = "sinirkapiippopup.aspx?pkey=" + CStr(pkey) + "&op=yenikayit"
                    kol2 = "<td>" + javascript.yetkibuttonyaratozel(linkip, "IP Adresleri") + "</td>"

                    If Not veri.Item("sinirkapiad") Is System.DBNull.Value Then
                        sinirkapiad = veri.Item("sinirkapiad")
                        kol3 = "<td>" + sinirkapiad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("sinirkapikod") Is System.DBNull.Value Then
                        sinirkapikod = veri.Item("sinirkapikod")
                        kol4 = "<td>" + sinirkapikod + "</td></tr>"
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
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapi where " + tablecol + "=@kriter"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
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



    Public Function bordercodebul(ByVal AgencyRegisterCode As String)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim sinirkapikod As String = ""

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapi,sinirkapiip where " + _
        "sinirkapi.pkey=sinirkapiip.sinirkapipkey and " + _
        "sinirkapiip.ip=@AgencyRegisterCode"
       
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = AgencyRegisterCode
        komut.Parameters.Add(param1)

     
        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("sinirkapikod") Is System.DBNull.Value Then
                    sinirkapikod = veri.Item("sinirkapikod")
                Else
                    sinirkapikod = ""
                End If

                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return sinirkapikod




    End Function



    Function varmikapikod(ByVal AgencyRegisterCode As String) As String

        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim fieldopvalue As New CLASSFIELDOPERATORVALUE

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim varmi As Integer
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ip", "=", AgencyRegisterCode, " "))
        varmi = genericislem_erisim.countgeneric(site.sistemveritabaniad, "sinirkapiip", "count(*)", fieldopvalues)

        If varmi > 0 Then
            Return "Evet"
        Else
            Return "Hayır"
        End If


    End Function


    Public Function inputlariolustur(ByVal hangi As Integer) As String

        Dim donecek As String
        donecek = ""
        Dim herinputbas, herinputson, herinputorta As String
        Dim kapilar As New List(Of CLASSSINIRKAPI)
        kapilar = doldur()

        herinputbas = ""
        herinputorta = ""
        herinputson = ""


        herinputson = "</div>" + Environment.NewLine + " </div> " + Environment.NewLine

        For Each itemkapi As CLASSSINIRKAPI In kapilar

            herinputbas = "<div class=" + Chr(34) + "form-group" + Chr(34) + ">" + Environment.NewLine + _
            "<label class=" + Chr(34) + "col-md-3 control-label" + Chr(34) + ">" + itemkapi.sinirkapiad + ":</label>" + Environment.NewLine + _
            "<div class=" + Chr(34) + "col-md-4" + Chr(34) + ">"

            herinputorta = "<input name=" + Chr(34) + CStr(hangi) + "CheckBox" + CStr(itemkapi.pkey) + Chr(34) + _
            " id=" + Chr(34) + CStr(hangi) + "CheckBox" + CStr(itemkapi.pkey) + Chr(34) + Environment.NewLine + _
            " type=" + Chr(34) + "checkbox" + Chr(34) + _
            " value=" + Chr(34) + CStr(itemkapi.pkey) + Chr(34) + _
            "checked class=" + Chr(34) + "make-switch switch-large" + Chr(34) + _
            "data-label-icon=" + Chr(34) + "fa fa-fullscreen" + Chr(34) + _
            "data-on-label=" + Chr(34) + "<i class='fa fa-check'></i>" + Chr(34) + _
            "data-off-label=" + Chr(34) + "<i class='fa fa-times'></i>" + Chr(34) + ">" + "<br/>"

            donecek = donecek + herinputbas + herinputorta + herinputson
        Next

        Return donecek

    End Function

End Class
