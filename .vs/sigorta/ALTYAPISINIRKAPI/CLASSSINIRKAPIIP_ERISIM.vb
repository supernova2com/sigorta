Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Net



Public Class CLASSSINIRKAPIIP_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sinirkapiip As New CLASSSINIRKAPIIP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sinirkapiip As CLASSSINIRKAPIIP) As CLADBOPRESULT


        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(sinirkapiip.sinirkapipkey,sinirkapiip.cidr,sinirkapiip.ip)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu ip adresi halihazırda bu kapıya tanımlanmış."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into sinirkapiip values (@pkey," + _
        "@sinirkapipkey,@cidr,@ip)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sinirkapiip.sinirkapipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sinirkapiip.sinirkapipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@cidr", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If sinirkapiip.cidr = 0 Then
            param3.Value = 0
        Else
            param3.Value = sinirkapiip.cidr
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sinirkapiip.ip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sinirkapiip.ip
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
        sqlstr = "select max(pkey) from sinirkapiip"
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
    Function Duzenle(ByVal sinirkapiip As CLASSSINIRKAPIIP) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sinirkapiip set " + _
        "sinirkapipkey=@sinirkapipkey," + _
        "cidr=@cidr," + _
        "ip=@ip" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapiip.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If sinirkapiip.sinirkapipkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = sinirkapiip.sinirkapipkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@cidr", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If sinirkapiip.cidr = 0 Then
            param3.Value = 0
        Else
            param3.Value = sinirkapiip.cidr
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sinirkapiip.ip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = sinirkapiip.ip
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
    Function bultek(ByVal pkey As String) As CLASSSINIRKAPIIP

        Dim komut As New SqlCommand
        Dim doneceksinirkapiip As New CLASSSINIRKAPIIP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiip where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapiip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                    doneceksinirkapiip.sinirkapipkey = veri.Item("sinirkapipkey")
                End If

                If Not veri.Item("cidr") Is System.DBNull.Value Then
                    doneceksinirkapiip.cidr = veri.Item("cidr")
                End If

                If Not veri.Item("ip") Is System.DBNull.Value Then
                    doneceksinirkapiip.ip = veri.Item("ip")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksinirkapiip

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from sinirkapiip where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSINIRKAPIIP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksinirkapiip As New CLASSSINIRKAPIIP
        Dim sinirkapiipler As New List(Of CLASSSINIRKAPIIP)
        komut.Connection = db_baglanti
        sqlstr = "select * from sinirkapiip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapiip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                    doneceksinirkapiip.sinirkapipkey = veri.Item("sinirkapipkey")
                End If

                If Not veri.Item("cidr") Is System.DBNull.Value Then
                    doneceksinirkapiip.cidr = veri.Item("cidr")
                End If

                If Not veri.Item("ip") Is System.DBNull.Value Then
                    doneceksinirkapiip.ip = veri.Item("ip")
                End If


                sinirkapiipler.Add(New CLASSSINIRKAPIIP(doneceksinirkapiip.pkey, _
                doneceksinirkapiip.sinirkapipkey, doneceksinirkapiip.cidr, doneceksinirkapiip.ip))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sinirkapiipler

    End Function

    Public Function doldurilgili(ByVal sinirkapipkey As Integer) As List(Of CLASSSINIRKAPIIP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksinirkapiip As New CLASSSINIRKAPIIP
        Dim sinirkapiipler As New List(Of CLASSSINIRKAPIIP)
        komut.Connection = db_baglanti
        sqlstr = "select * from sinirkapiip where sinirkapipkey=@sinirkapipkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapipkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksinirkapiip.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                    doneceksinirkapiip.sinirkapipkey = veri.Item("sinirkapipkey")
                End If

                If Not veri.Item("cidr") Is System.DBNull.Value Then
                    doneceksinirkapiip.cidr = veri.Item("cidr")
                End If

                If Not veri.Item("ip") Is System.DBNull.Value Then
                    doneceksinirkapiip.ip = veri.Item("ip")
                End If


                sinirkapiipler.Add(New CLASSSINIRKAPIIP(doneceksinirkapiip.pkey, _
                doneceksinirkapiip.sinirkapipkey, doneceksinirkapiip.cidr, doneceksinirkapiip.ip))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sinirkapiipler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
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
        "<th>Sınır Kapısı</th>" + _
        "<th>IP Adresi</th>" + _
        "<th>Subnet Mask</th>" + _
        "<th>IP Aralığı</th>" + _
        "<th>İşlem</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from sinirkapiip where sinirkapipkey=@sinirkapipkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@sinirkapipkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("sinirkapipkey")
            komut.Parameters.Add(param1)

        End If
        girdi = "0"
        Dim link As String
        Dim pkey, sinirkapipkey, cidr, ip As String

        Dim sinirkapi As New CLASSSINIRKAPI
        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
        Dim ht As New Hashtable
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim ajaxlinksil, dugmesil As String



        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                        sinirkapipkey = veri.Item("sinirkapipkey")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        link = "sinirkapiippopup.aspx?pkey=" + CStr(sinirkapipkey) + "&op=duzenle" + _
                        "&sinirkapiipop=duzenle" + "&sinirkapiippkey=" + CStr(pkey)

                        kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("sinirkapipkey") Is System.DBNull.Value Then
                        sinirkapipkey = veri.Item("sinirkapipkey")
                        sinirkapi = sinirkapi_erisim.bultek(sinirkapipkey)
                        kol2 = "<td>" + sinirkapi.sinirkapiad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("ip") Is System.DBNull.Value Then
                        ip = veri.Item("ip")
                    Else
                        ip = "-"
                    End If
                    If Not veri.Item("cidr") Is System.DBNull.Value Then
                        cidr = veri.Item("cidr")
                    Else
                        cidr = "-"
                    End If
                    kol3 = "<td>" + ip + "/" + cidr + "</td>"


                    ht = ip_erisim.balangicbitisvemaskbul(cidr, IPAddress.Parse(ip))
                    kol4 = "<td>" + ht(3) + "</td>"
                    kol5 = "<td>" + "Başlangıç IP:" + "<b>" + ht(1) + "</b><br/>" + _
                    "Bitiş IP:" + "<b>" + ht(2) + "</b></td>"


                    ajaxlinksil = "sinirkapiipsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='ipsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol6 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
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

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal sinirkapipkey As Integer, ByVal cidr As String, _
    ByVal ip As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiip where sinirkapipkey=@sinirkapipkey and " + _
        "cidr=@cidr and ip=@ip"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapipkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@cidr", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = cidr
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ip", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = ip
        komut.Parameters.Add(param3)


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


    Function varmisinirkapi(ByVal sinirkapipkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapiip where sinirkapipkey=@sinirkapipkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sinirkapipkey", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sinirkapipkey
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

    Public Function yetkilimi(ByVal sinirkapi As CLASSSINIRKAPI, ByVal kontrolip As String) As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim donecek As String = "Hayır"

        If sinirkapi.ipdikkat = "Hayır" Then
            donecek = "Evet"
            Return donecek
        End If

        If sinirkapi.ipdikkat = "Evet" Then
            Dim ipadresler As New List(Of CLASSSINIRKAPIIP)
            ipadresler = doldurilgili(sinirkapi.pkey)

            For Each item As CLASSSINIRKAPIIP In ipadresler
                If ip_erisim.range(item.cidr, IPAddress.Parse(item.ip), IPAddress.Parse(kontrolip)) = "Evet" Then
                    donecek = "Evet"
                    Return donecek
                End If
            Next
        End If

        Return donecek

    End Function


End Class

