Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSZIYARETCİ_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim ziyaretci As New CLASSZIYARETCI
    Dim resultset As New CLADBOPRESULT

    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE


    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal ziyaretci As CLASSZIYARETCI) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into ziyaretci values (@pkey," + _
        "@ipadres,@tarih)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ipadres", SqlDbType.VarChar, 15)
        param2.Direction = ParameterDirection.Input
        If ziyaretci.ipadres = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ziyaretci.ipadres
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If ziyaretci.tarih Is Nothing Or ziyaretci.tarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ziyaretci.tarih
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
        sqlstr = "select max(pkey) from ziyaretci"
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
    Function Duzenle(ByVal ziyaretci As CLASSZIYARETCI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update ziyaretci set " + _
        "ipadres=@ipadres," + _
        "tarih=@tarih" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ziyaretci.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ipadres", SqlDbType.VarChar, 15)
        param2.Direction = ParameterDirection.Input
        If ziyaretci.ipadres = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = ziyaretci.ipadres
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If ziyaretci.tarih Is Nothing Or ziyaretci.tarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ziyaretci.tarih
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
    Function bultek(ByVal pkey As String) As CLASSZIYARETCI

        Dim komut As New SqlCommand
        Dim donecekziyaretci As New CLASSZIYARETCI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ziyaretci where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekziyaretci.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    donecekziyaretci.ipadres = veri.Item("ipadres")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekziyaretci.tarih = veri.Item("tarih")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekziyaretci

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from ziyaretci where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSZIYARETCI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekziyaretci As New CLASSZIYARETCI
        Dim ziyaretciler As New List(Of CLASSZIYARETCI)
        komut.Connection = db_baglanti
        sqlstr = "select * from ziyaretci"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekziyaretci.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    donecekziyaretci.ipadres = veri.Item("ipadres")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekziyaretci.tarih = veri.Item("tarih")
                End If

                ziyaretciler.Add(New CLASSZIYARETCI(donecekziyaretci.pkey, _
                donecekziyaretci.ipadres, donecekziyaretci.tarih))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ziyaretciler

    End Function


    Public Function toplamziyaretcisayisi() As Integer

        Dim adet As Integer
        fieldopvalues.Clear()
        adet = genericislem_erisim.countgeneric(Current.Session("veritabaniad"), "ziyaretci", "count(*)", fieldopvalues)
        Return adet

    End Function


    Public Function bugunkuziyaretcisayisi() As Integer


        Dim sqlstr As String
        Dim sayi As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from ziyaretci where CAST(tarih AS DATE)=@tarih"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param1.Direction = ParameterDirection.Input
        param1.Value = Date.Now.ToShortDateString
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            sayi = 0
        Else
            sayi = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sayi



    End Function



End Class




