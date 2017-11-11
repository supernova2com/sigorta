Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSBAZFIYATTARIFEY_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim bazfiyattarife As New CLASSBAZFIYATTARIFEY
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal bazfiyattarife As CLASSBAZFIYATTARIFEY) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into bazfiyattarifey values (@pkey," + _
        "@bazfiyatpkey,@aractarifepkey,@trafikmiktar,@mintrafikmiktar," + _
        "@kaskooran,@minkaskomiktar,@ftoran,@minftmiktar," + _
        "@cooran,@cominmiktar,@pertkaskooran,@minpertkaskomiktar)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If bazfiyattarife.bazfiyatpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = bazfiyattarife.bazfiyatpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If bazfiyattarife.aractarifepkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = bazfiyattarife.aractarifepkey
        End If
        komut.Parameters.Add(param3)
        Dim param4 As New SqlParameter("@trafikmiktar", SqlDbType.Float)
        param4.Direction = ParameterDirection.Input
        If bazfiyattarife.trafikmiktar = 0 Then
            param4.Value = 0
        Else
            param4.Value = bazfiyattarife.trafikmiktar
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@mintrafikmiktar", SqlDbType.Float)
        param5.Direction = ParameterDirection.Input
        If bazfiyattarife.mintrafikmiktar = 0 Then
            param5.Value = 0
        Else
            param5.Value = bazfiyattarife.mintrafikmiktar
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@kaskooran", SqlDbType.Float)
        param6.Direction = ParameterDirection.Input
        If bazfiyattarife.kaskooran = 0 Then
            param6.Value = 0
        Else
            param6.Value = bazfiyattarife.kaskooran
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@minkaskomiktar", SqlDbType.Float)
        param7.Direction = ParameterDirection.Input
        If bazfiyattarife.minkaskomiktar = 0 Then
            param7.Value = 0
        Else
            param7.Value = bazfiyattarife.minkaskomiktar
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ftoran", SqlDbType.Float)
        param8.Direction = ParameterDirection.Input
        If bazfiyattarife.ftoran = 0 Then
            param8.Value = 0
        Else
            param8.Value = bazfiyattarife.ftoran
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@minftmiktar", SqlDbType.Float)
        param9.Direction = ParameterDirection.Input
        If bazfiyattarife.minftmiktar = 0 Then
            param9.Value = 0
        Else
            param9.Value = bazfiyattarife.minftmiktar
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@cooran", SqlDbType.Float)
        param10.Direction = ParameterDirection.Input
        If bazfiyattarife.cooran = 0 Then
            param10.Value = 0
        Else
            param10.Value = bazfiyattarife.cooran
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@cominmiktar", SqlDbType.Float)
        param11.Direction = ParameterDirection.Input
        If bazfiyattarife.cominmiktar = 0 Then
            param11.Value = 0
        Else
            param11.Value = bazfiyattarife.cominmiktar
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@pertkaskooran", SqlDbType.Float)
        param12.Direction = ParameterDirection.Input
        If bazfiyattarife.pertkaskooran = 0 Then
            param12.Value = 0
        Else
            param12.Value = bazfiyattarife.pertkaskooran
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@minpertkaskomiktar", SqlDbType.Float)
        param13.Direction = ParameterDirection.Input
        If bazfiyattarife.minpertkaskomiktar = 0 Then
            param13.Value = 0
        Else
            param13.Value = bazfiyattarife.minpertkaskomiktar
        End If
        komut.Parameters.Add(param13)
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
        sqlstr = "select max(pkey) from bazfiyattarifey"
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
    Function Duzenle(ByVal bazfiyattarife As CLASSBAZFIYATTARIFEY) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update bazfiyattarifey set " + _
        "bazfiyatpkey=@bazfiyatpkey," + _
        "aractarifepkey=@aractarifepkey," + _
        "trafikmiktar=@trafikmiktar," + _
        "mintrafikmiktar=@mintrafikmiktar," + _
        "kaskooran=@kaskooran," + _
        "minkaskomiktar=@minkaskomiktar," + _
        "ftoran=@ftoran," + _
        "minftmiktar=@minftmiktar," + _
        "cooran=@cooran," + _
        "cominmiktar=@cominmiktar," + _
        "pertkaskooran=@pertkaskooran," + _
        "minpertkaskomiktar=@minpertkaskomiktar" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyattarife.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If bazfiyattarife.bazfiyatpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = bazfiyattarife.bazfiyatpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If bazfiyattarife.aractarifepkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = bazfiyattarife.aractarifepkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@trafikmiktar", SqlDbType.Float)
        param4.Direction = ParameterDirection.Input
        If bazfiyattarife.trafikmiktar = 0 Then
            param4.Value = 0
        Else
            param4.Value = bazfiyattarife.trafikmiktar
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@mintrafikmiktar", SqlDbType.Float)
        param5.Direction = ParameterDirection.Input
        If bazfiyattarife.mintrafikmiktar = 0 Then
            param5.Value = 0
        Else
            param5.Value = bazfiyattarife.mintrafikmiktar
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@kaskooran", SqlDbType.Float)
        param6.Direction = ParameterDirection.Input
        If bazfiyattarife.kaskooran = 0 Then
            param6.Value = 0
        Else
            param6.Value = bazfiyattarife.kaskooran
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@minkaskomiktar", SqlDbType.Float)
        param7.Direction = ParameterDirection.Input
        If bazfiyattarife.minkaskomiktar = 0 Then
            param7.Value = 0
        Else
            param7.Value = bazfiyattarife.minkaskomiktar
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ftoran", SqlDbType.Float)
        param8.Direction = ParameterDirection.Input
        If bazfiyattarife.ftoran = 0 Then
            param8.Value = 0
        Else
            param8.Value = bazfiyattarife.ftoran
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@minftmiktar", SqlDbType.Float)
        param9.Direction = ParameterDirection.Input
        If bazfiyattarife.minftmiktar = 0 Then
            param9.Value = 0
        Else
            param9.Value = bazfiyattarife.minftmiktar
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@cooran", SqlDbType.Float)
        param10.Direction = ParameterDirection.Input
        If bazfiyattarife.cooran = 0 Then
            param10.Value = 0
        Else
            param10.Value = bazfiyattarife.cooran
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@cominmiktar", SqlDbType.Float)
        param11.Direction = ParameterDirection.Input
        If bazfiyattarife.cominmiktar = 0 Then
            param11.Value = 0
        Else
            param11.Value = bazfiyattarife.cominmiktar
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@pertkaskooran", SqlDbType.Float)
        param12.Direction = ParameterDirection.Input
        If bazfiyattarife.pertkaskooran = 0 Then
            param12.Value = 0
        Else
            param12.Value = bazfiyattarife.pertkaskooran
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@minpertkaskomiktar", SqlDbType.Float)
        param13.Direction = ParameterDirection.Input
        If bazfiyattarife.minpertkaskomiktar = 0 Then
            param13.Value = 0
        Else
            param13.Value = bazfiyattarife.minpertkaskomiktar
        End If
        komut.Parameters.Add(param13)


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
    Function bultek(ByVal pkey As String) As CLASSBAZFIYATTARIFEY

        Dim komut As New SqlCommand
        Dim donecekbazfiyattarife As New CLASSBAZFIYATTARIFEY()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyattarifey where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatpkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.bazfiyatpkey = veri.Item("bazfiyatpkey")
                End If

                If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.aractarifepkey = veri.Item("aractarifepkey")
                End If

                If Not veri.Item("trafikmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.trafikmiktar = veri.Item("trafikmiktar")
                End If

                If Not veri.Item("mintrafikmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.mintrafikmiktar = veri.Item("mintrafikmiktar")
                End If

                If Not veri.Item("kaskooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.kaskooran = veri.Item("kaskooran")
                End If

                If Not veri.Item("minkaskomiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minkaskomiktar = veri.Item("minkaskomiktar")
                End If

                If Not veri.Item("ftoran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.ftoran = veri.Item("ftoran")
                End If

                If Not veri.Item("minftmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minftmiktar = veri.Item("minftmiktar")
                End If

                If Not veri.Item("cooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.cooran = veri.Item("cooran")
                End If

                If Not veri.Item("cominmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.cominmiktar = veri.Item("cominmiktar")
                End If

                If Not veri.Item("pertkaskooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.pertkaskooran = veri.Item("pertkaskooran")
                End If

                If Not veri.Item("minpertkaskomiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minpertkaskomiktar = veri.Item("minpertkaskomiktar")
                End If



            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyattarife

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bul_ilgili(ByVal bazfiyatpkey As String, _
    ByVal aractarifepkey As String) As CLASSBAZFIYATTARIFEY

        Dim komut As New SqlCommand
        Dim donecekbazfiyattarife As New CLASSBAZFIYATTARIFEY()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from bazfiyattarifey where bazfiyatpkey=@bazfiyatpkey and " + _
        "aractarifepkey=@aractarifepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@aractarifepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = aractarifepkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatpkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.bazfiyatpkey = veri.Item("bazfiyatpkey")
                End If

                If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.aractarifepkey = veri.Item("aractarifepkey")
                End If

                If Not veri.Item("trafikmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.trafikmiktar = veri.Item("trafikmiktar")
                End If

                If Not veri.Item("mintrafikmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.mintrafikmiktar = veri.Item("mintrafikmiktar")
                End If

                If Not veri.Item("kaskooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.kaskooran = veri.Item("kaskooran")
                End If

                If Not veri.Item("minkaskomiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minkaskomiktar = veri.Item("minkaskomiktar")
                End If

                If Not veri.Item("ftoran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.ftoran = veri.Item("ftoran")
                End If

                If Not veri.Item("minftmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minftmiktar = veri.Item("minftmiktar")
                End If

                If Not veri.Item("cooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.cooran = veri.Item("cooran")
                End If

                If Not veri.Item("cominmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.cominmiktar = veri.Item("cominmiktar")
                End If

                If Not veri.Item("pertkaskooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.pertkaskooran = veri.Item("pertkaskooran")
                End If

                If Not veri.Item("minpertkaskomiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minpertkaskomiktar = veri.Item("minpertkaskomiktar")
                End If



            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekbazfiyattarife

    End Function



    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from bazfiyattarifey where pkey=@pkey"
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


    '---------------------------------sil-----------------------------------------
    Public Function ilgilisil(ByVal bazfiyatpkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        komut = New SqlCommand(sqlstr, db_baglanti)

        sqlstr = "delete from bazfiyattarifey where bazfiyatpkey=@bazfiyatpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
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


    '---------------------------------sil bazfiyat tümü----------------------------------------
    Public Function sil_bazfiyatpkeyegore(ByVal bazfiyatpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        komut = New SqlCommand(sqlstr, db_baglanti)

        sqlstr = "delete from bazfiyattarifey where bazfiyatpkey=@bazfiyatpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
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
    Public Function doldur(ByVal bazfiyatpkey As String) As List(Of CLASSBAZFIYATTARIFEY)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekbazfiyattarife As New CLASSBAZFIYATTARIFEY
        Dim bazfiyattarifeler As New List(Of CLASSBAZFIYATTARIFEY)
        komut.Connection = db_baglanti
        sqlstr = "select * from bazfiyattarifey where bazfiyatpkey=@bazfiyatpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@bazfiyatpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = bazfiyatpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatpkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.bazfiyatpkey = veri.Item("bazfiyatpkey")
                End If

                If Not veri.Item("aractarifepkey") Is System.DBNull.Value Then
                    donecekbazfiyattarife.aractarifepkey = veri.Item("aractarifepkey")
                End If

                If Not veri.Item("trafikmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.trafikmiktar = veri.Item("trafikmiktar")
                End If

                If Not veri.Item("mintrafikmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.mintrafikmiktar = veri.Item("mintrafikmiktar")
                End If

                If Not veri.Item("kaskooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.kaskooran = veri.Item("kaskooran")
                End If

                If Not veri.Item("minkaskomiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minkaskomiktar = veri.Item("minkaskomiktar")
                End If

                If Not veri.Item("ftoran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.ftoran = veri.Item("ftoran")
                End If

                If Not veri.Item("minftmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minftmiktar = veri.Item("minftmiktar")
                End If

                If Not veri.Item("cooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.cooran = veri.Item("cooran")
                End If

                If Not veri.Item("cominmiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.cominmiktar = veri.Item("cominmiktar")
                End If

                If Not veri.Item("pertkaskooran") Is System.DBNull.Value Then
                    donecekbazfiyattarife.pertkaskooran = veri.Item("pertkaskooran")
                End If

                If Not veri.Item("minpertkaskomiktar") Is System.DBNull.Value Then
                    donecekbazfiyattarife.minpertkaskomiktar = veri.Item("minpertkaskomiktar")
                End If


                bazfiyattarifeler.Add(New CLASSBAZFIYATTARIFEY(donecekbazfiyattarife.pkey, _
                donecekbazfiyattarife.bazfiyatpkey, donecekbazfiyattarife.aractarifepkey, _
                donecekbazfiyattarife.trafikmiktar, donecekbazfiyattarife.mintrafikmiktar, _
                donecekbazfiyattarife.kaskooran, donecekbazfiyattarife.minkaskomiktar, _
                donecekbazfiyattarife.ftoran, donecekbazfiyattarife.minftmiktar, _
                donecekbazfiyattarife.cooran, donecekbazfiyattarife.cominmiktar, _
                donecekbazfiyattarife.pertkaskooran, donecekbazfiyattarife.minpertkaskomiktar))



            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return bazfiyattarifeler

    End Function



    Public Function inputlariolustur(ByVal bazfiyatpkey As String, _
    ByVal op As String) As String

        Dim tekinput As String
        Dim teksatir As String = ""
        Dim oid As String
        Dim donecek As String = ""
        Dim basliklar, tabloson As String
        Dim valuestr As String = ""
        Dim classstr As String

        basliklar = "<table id=sonuctable class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th bgcolor='#ebebeb' align='center' colspan='1'></th>" + _
        "<th bgcolor='#ebebeb' align='center' colspan='2'>3. Şahıs Zorunlu Trafik</th>" + _
        "<th bgcolor='#ebebeb' align='center' colspan='2'>Kasko</th>" + _
        "<th bgcolor='#ebebeb' align='center' colspan='6'>Kısmi Kasko</th>" + _
        "</tr>" + _
        "<tr>" + _
        "<th id='bb1'>Araç Tarife Kodu</th>" + _
        "<th id='bb2'>Trafik <br/> Miktar</th>" + _
        "<th id='bb3'>Asgari Trafik Miktar</th>" + _
        "<th id='bb4'>Kasko <br/> Oran </th>" + _
        "<th id='bb5'>Asgari Kasko Miktar </th>" + _
        "<th id='bb6'>Yanma ve Çalınma <br/> Oran</th>" + _
        "<th id='bb7'>Asgari <br/> Yanma ve Çalınma Miktar</th>" + _
        "<th id='bb8'>Çarpışma Oran</th>" + _
        "<th id='bb9'>Asgari Çarpışma Miktar</th>" + _
        "<th id='bb10'>Pert-Kasko Oran</th>" + _
        "<th id='bb11'>Asgari Pert-Kasko Miktar</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        Dim aractarifeler As New List(Of CLASSARACTARIFE)
        aractarifeler = aractarife_erisim.doldur

        '" data-durum=" + Chr(34) + "disableolacak" + Chr(34) + _ vardı çıkardın
        Dim a As Integer = 1

        For Each itemaractarife As CLASSARACTARIFE In aractarifeler
            teksatir = teksatir + "<tr><td>" + itemaractarife.tarifekod + " (" + itemaractarife.tarifead + ")" + "</td>"

            bazfiyattarife = bul_ilgili(bazfiyatpkey, itemaractarife.pkey)

            For i = 1 To 10

                If op = "duzenle" Then
                    valuestr = ""

                    If i = 1 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.trafikmiktar) + Chr(34) + " "
                    End If
                    If i = 2 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.mintrafikmiktar) + Chr(34) + " "
                    End If
                    If i = 3 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.kaskooran) + Chr(34) + " "
                    End If
                    If i = 4 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.minkaskomiktar) + Chr(34) + " "
                    End If
                    If i = 5 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.ftoran) + Chr(34) + " "
                    End If
                    If i = 6 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.minftmiktar) + Chr(34) + " "
                    End If
                    If i = 7 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.cooran) + Chr(34) + " "
                    End If
                    If i = 8 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.cominmiktar) + Chr(34) + " "
                    End If
                    If i = 9 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.pertkaskooran) + Chr(34) + " "
                    End If
                    If i = 10 Then
                        valuestr = " value=" + Chr(34) + CStr(bazfiyattarife.minpertkaskomiktar) + Chr(34) + " "
                    End If
                End If

                If i = 3 Or i = 5 Or i = 7 Or i = 9 Or i = 11 Then
                    classstr = " class=" + Chr(34) + "computergenerated" + Chr(34)
                Else
                    classstr = " class=" + Chr(34) + "computergeneratedn" + Chr(34)
                End If

                oid = CStr(itemaractarife.pkey) + "_" + CStr(i)
                tekinput = "<input type=" + Chr(34) + "text" + Chr(34) + _
                " id=" + Chr(34) + "A" + oid + Chr(34) + _
                " name=" + Chr(34) + "A" + oid + Chr(34) + _
                classstr + valuestr + "></input>"

                teksatir = teksatir + "<td id='" + "zz" + CStr(a) + "-" + CStr(i) + "'>" + tekinput + "</td>"

                a = a + 1
            Next
            teksatir = teksatir + "</tr>"
        Next

        donecek = basliklar + teksatir + tabloson

        Return donecek

    End Function


    Public Function temizle(ByVal bazfiyattarife As CLASSBAZFIYATTARIFEY) As CLASSBAZFIYATTARIFEY

        bazfiyattarife.pkey = 0
        bazfiyattarife.bazfiyatpkey = 0
        bazfiyattarife.aractarifepkey = 0
        bazfiyattarife.trafikmiktar = 0
        bazfiyattarife.mintrafikmiktar = 0
        bazfiyattarife.kaskooran = 0
        bazfiyattarife.minkaskomiktar = 0
        bazfiyattarife.ftoran = 0
        bazfiyattarife.minftmiktar = 0
        bazfiyattarife.cooran = 0
        bazfiyattarife.cominmiktar = 0
        bazfiyattarife.pertkaskooran = 0
        bazfiyattarife.minpertkaskomiktar = 0

        Return bazfiyattarife

    End Function

End Class


