Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSHESAP_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim hesap As New CLASSHESAP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal hesap As CLASSHESAP) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String

        If hesap.tutar = 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Üretilen poliçe değeri 0. Bu sebepten faturalandıramıyorum."
            resultset.etkilenen = 0
            Return resultset
        End If

        'SİGORTA BİLGİ MERKEZİNE GELİR FATURASI O AY İÇİN O ŞİRKET İÇİN BİR DEFA KESEBİLİR.
        If hesap.tip = "Gelir" Then
            varmi = ciftkayitkontrol(hesap.faturano, hesap.tip, hesap.tur)
            If varmi = "Evet" Then
                resultset.durum = "Kayıt yapılamadı."
                resultset.hatastr = "Bu fatura numaralı hesap zaten halihazırda veritabanında vardır." + _
                "İlgili ay ve yıl için bu şirket zaten halihazırda faturalandırılmış."
                resultset.etkilenen = 0
                Return resultset
            End If
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into hesap values (@pkey," + _
        "@firmcode,@faturano,@tip,@tarih," + _
        "@tutar,@aciklama,@ay,@yil," + _
        "@eder,@tur,@oran)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If hesap.firmcode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = hesap.firmcode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If hesap.faturano = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = hesap.faturano
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If hesap.tip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = hesap.tip
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If hesap.tarih Is Nothing Or hesap.tarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = hesap.tarih
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@tutar", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If hesap.tutar = 0 Then
            param6.Value = 0
        Else
            param6.Value = hesap.tutar
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@aciklama", SqlDbType.Text)
        param7.Direction = ParameterDirection.Input
        If hesap.aciklama = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = hesap.aciklama
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ay", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If hesap.ay = 0 Then
            param8.Value = 0
        Else
            param8.Value = hesap.ay
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@yil", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If hesap.yil = 0 Then
            param9.Value = 0
        Else
            param9.Value = hesap.yil
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@eder", SqlDbType.Decimal)
        param10.Direction = ParameterDirection.Input
        If hesap.eder = 0 Then
            param10.Value = 0
        Else
            param10.Value = hesap.eder
        End If
        komut.Parameters.Add(param10)


        Dim param11 As New SqlParameter("@tur", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If hesap.tur = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = hesap.tur
        End If
        komut.Parameters.Add(param11)


        Dim param12 As New SqlParameter("@oran", SqlDbType.Decimal)
        param12.Direction = ParameterDirection.Input
        If hesap.oran = 0 Then
            param12.Value = 0
        Else
            param12.Value = hesap.oran
        End If
        komut.Parameters.Add(param12)


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
        sqlstr = "select max(pkey) from hesap"
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
    Function Duzenle(ByVal hesap As CLASSHESAP) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update hesap set " + _
        "firmcode=@firmcode," + _
        "faturano=@faturano," + _
        "tip=@tip," + _
        "tarih=@tarih," + _
        "tutar=@tutar," + _
        "aciklama=@aciklama," + _
        "ay=@ay," + _
        "yil=@yil," + _
        "eder=@eder," + _
        "tur=@tur," + _
        "oran=@oran" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = hesap.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If hesap.firmcode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = hesap.firmcode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If hesap.faturano = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = hesap.faturano
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If hesap.tip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = hesap.tip
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If hesap.tarih Is Nothing Or hesap.tarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = hesap.tarih
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@tutar", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If hesap.tutar = 0 Then
            param6.Value = 0
        Else
            param6.Value = hesap.tutar
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@aciklama", SqlDbType.Text)
        param7.Direction = ParameterDirection.Input
        If hesap.aciklama = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = hesap.aciklama
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ay", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If hesap.ay = 0 Then
            param8.Value = 0
        Else
            param8.Value = hesap.ay
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@yil", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If hesap.yil = 0 Then
            param9.Value = 0
        Else
            param9.Value = hesap.yil
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@eder", SqlDbType.Decimal)
        param10.Direction = ParameterDirection.Input
        If hesap.eder = 0 Then
            param10.Value = 0
        Else
            param10.Value = hesap.eder
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@tur", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If hesap.tur = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = hesap.tur
        End If
        komut.Parameters.Add(param11)


        Dim param12 As New SqlParameter("@oran", SqlDbType.Decimal)
        param12.Direction = ParameterDirection.Input
        If hesap.oran = 0 Then
            param12.Value = 0
        Else
            param12.Value = hesap.oran
        End If
        komut.Parameters.Add(param12)

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
    Function bultek(ByVal pkey As String) As CLASSHESAP

        Dim komut As New SqlCommand
        Dim donecekhesap As New CLASShesap()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekhesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("firmcode") Is System.DBNull.Value Then
                    donecekhesap.firmcode = veri.Item("firmcode")
                End If

                If Not veri.Item("faturano") Is System.DBNull.Value Then
                    donecekhesap.faturano = veri.Item("faturano")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekhesap.tip = veri.Item("tip")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekhesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekhesap.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekhesap.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("ay") Is System.DBNull.Value Then
                    donecekhesap.ay = veri.Item("ay")
                End If

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    donecekhesap.yil = veri.Item("yil")
                End If

                If Not veri.Item("eder") Is System.DBNull.Value Then
                    donecekhesap.eder = veri.Item("eder")
                End If

                If Not veri.Item("tur") Is System.DBNull.Value Then
                    donecekhesap.tur = veri.Item("tur")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekhesap.oran = veri.Item("oran")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekhesap

    End Function


   

    '---------------------------------bultek-----------------------------------------
    Function bulfaturanovetipegore(ByVal faturano As String, ByVal tip As String) As CLASSHESAP

        Dim komut As New SqlCommand
        Dim donecekhesap As New CLASSHESAP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where faturano=@faturano and tip=@tip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = faturano
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tip
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekhesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("firmcode") Is System.DBNull.Value Then
                    donecekhesap.firmcode = veri.Item("firmcode")
                End If

                If Not veri.Item("faturano") Is System.DBNull.Value Then
                    donecekhesap.faturano = veri.Item("faturano")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekhesap.tip = veri.Item("tip")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekhesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekhesap.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekhesap.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("ay") Is System.DBNull.Value Then
                    donecekhesap.ay = veri.Item("ay")
                End If

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    donecekhesap.yil = veri.Item("yil")
                End If

                If Not veri.Item("eder") Is System.DBNull.Value Then
                    donecekhesap.eder = veri.Item("eder")
                End If

                If Not veri.Item("tur") Is System.DBNull.Value Then
                    donecekhesap.tur = veri.Item("tur")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekhesap.oran = veri.Item("oran")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekhesap

    End Function



    '---------------------------------bultek-----------------------------------------
    Function bulcoklu(ByVal firmcode As String, ByVal ay As String, _
    ByVal yil As String, ByVal tip As String, ByVal tur As String) As CLASSHESAP

        Dim komut As New SqlCommand
        Dim donecekhesap As New CLASSHESAP()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where firmcode=@firmcode and ay=@ay and yil=@yil" + _
        " and tip=@tip and tur=@tur"
        komut = New SqlCommand(sqlstr, db_baglanti)


        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ay", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = ay
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@yil", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = yil
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = tip
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tur", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = tur
        komut.Parameters.Add(param5)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekhesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("firmcode") Is System.DBNull.Value Then
                    donecekhesap.firmcode = veri.Item("firmcode")
                End If

                If Not veri.Item("faturano") Is System.DBNull.Value Then
                    donecekhesap.faturano = veri.Item("faturano")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekhesap.tip = veri.Item("tip")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekhesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekhesap.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekhesap.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("ay") Is System.DBNull.Value Then
                    donecekhesap.ay = veri.Item("ay")
                End If

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    donecekhesap.yil = veri.Item("yil")
                End If

                If Not veri.Item("eder") Is System.DBNull.Value Then
                    donecekhesap.eder = veri.Item("eder")
                End If

                If Not veri.Item("tur") Is System.DBNull.Value Then
                    donecekhesap.tur = veri.Item("tur")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekhesap.oran = veri.Item("oran")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekhesap

    End Function



    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from hesap where pkey=@pkey"
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
    Public Function sil_faturanogore(ByVal faturano As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from hesap where faturano=@faturano"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = faturano
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
    Public Function sil_faturanovetipveturegore(ByVal faturano As String, _
    ByVal tip As String, ByVal tur As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from hesap where faturano=@faturano and tip=@tip and tur=@tur"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = faturano
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tip
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tur", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = tur
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


    '---------------------------------sil-----------------------------------------
    Public Function sil_coklu(ByVal firmcode As String, ByVal ay As String, _
    ByVal yil As String, ByVal tip As String, ByVal tur As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from hesap where firmcode=@firmcode and ay=@ay and yil=@yil and tip=@tip and tur=@tur"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ay", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = ay
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@yil", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = yil
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = tip
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tur", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = tur
        komut.Parameters.Add(param5)

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
    Public Function doldur() As List(Of CLASSHESAP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekhesap As New CLASShesap
        Dim hesapler As New List(Of CLASShesap)
        komut.Connection = db_baglanti
        sqlstr = "select * from hesap"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekhesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("firmcode") Is System.DBNull.Value Then
                    donecekhesap.firmcode = veri.Item("firmcode")
                End If

                If Not veri.Item("faturano") Is System.DBNull.Value Then
                    donecekhesap.faturano = veri.Item("faturano")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekhesap.tip = veri.Item("tip")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekhesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekhesap.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekhesap.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("ay") Is System.DBNull.Value Then
                    donecekhesap.ay = veri.Item("ay")
                End If

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    donecekhesap.yil = veri.Item("yil")
                End If

                If Not veri.Item("eder") Is System.DBNull.Value Then
                    donecekhesap.eder = veri.Item("eder")
                End If

                If Not veri.Item("tur") Is System.DBNull.Value Then
                    donecekhesap.tur = veri.Item("tur")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekhesap.oran = veri.Item("oran")
                End If

                hesapler.Add(New CLASSHESAP(donecekhesap.pkey, _
                donecekhesap.firmcode, donecekhesap.faturano, donecekhesap.tip, donecekhesap.tarih, _
                donecekhesap.tutar, donecekhesap.aciklama, donecekhesap.ay, donecekhesap.yil, _
                donecekhesap.eder, donecekhesap.tur, donecekhesap.oran))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return hesapler

    End Function



    Public Function doldur_ilgilisirketin(ByVal firmcode As String) As List(Of CLASSHESAP)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekhesap As New CLASSHESAP
        Dim hesapler As New List(Of CLASSHESAP)
        komut.Connection = db_baglanti
        sqlstr = "select * from hesap where firmcode=@firmcode"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekhesap.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("firmcode") Is System.DBNull.Value Then
                    donecekhesap.firmcode = veri.Item("firmcode")
                End If

                If Not veri.Item("faturano") Is System.DBNull.Value Then
                    donecekhesap.faturano = veri.Item("faturano")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekhesap.tip = veri.Item("tip")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekhesap.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("tutar") Is System.DBNull.Value Then
                    donecekhesap.tutar = veri.Item("tutar")
                End If

                If Not veri.Item("aciklama") Is System.DBNull.Value Then
                    donecekhesap.aciklama = veri.Item("aciklama")
                End If

                If Not veri.Item("ay") Is System.DBNull.Value Then
                    donecekhesap.ay = veri.Item("ay")
                End If

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    donecekhesap.yil = veri.Item("yil")
                End If

                If Not veri.Item("eder") Is System.DBNull.Value Then
                    donecekhesap.eder = veri.Item("eder")
                End If

                If Not veri.Item("tur") Is System.DBNull.Value Then
                    donecekhesap.tur = veri.Item("tur")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekhesap.oran = veri.Item("oran")
                End If

                hesapler.Add(New CLASSHESAP(donecekhesap.pkey, _
                donecekhesap.firmcode, donecekhesap.faturano, donecekhesap.tip, donecekhesap.tarih, _
                donecekhesap.tutar, donecekhesap.aciklama, donecekhesap.ay, donecekhesap.yil, _
                donecekhesap.eder, donecekhesap.tur, donecekhesap.oran))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return hesapler

    End Function


    Public Function doldur_odenmemisler(ByVal firmcode As String) As List(Of CLASSHESAP)

        Dim odenmemishesaplar As New List(Of CLASSHESAP)
        Dim sirketinhesaplari As New List(Of CLASSHESAP)

        sirketinhesaplari = doldur_ilgilisirketin(firmcode)

        For Each Item As CLASSHESAP In sirketinhesaplari
            If Item.tur = "Fatura" Then
                If odenmismi(Item.firmcode, Item.faturano) = "Hayır" Then
                    odenmemishesaplar.Add(New CLASSHESAP(Item.pkey, _
                    Item.firmcode, Item.faturano, Item.tip, Item.tarih, _
                    Item.tutar, Item.aciklama, Item.ay, Item.yil, _
                    Item.eder, Item.tur, Item.oran))
                End If
            End If
        Next

        Return odenmemishesaplar


    End Function


    Public Function doldur_odenmisler(ByVal firmcode As String) As List(Of CLASSHESAP)

        Dim odenmemishesaplar As New List(Of CLASSHESAP)
        Dim sirketinhesaplari As New List(Of CLASSHESAP)

        sirketinhesaplari = doldur_ilgilisirketin(firmcode)

        For Each Item As CLASSHESAP In sirketinhesaplari
            If Item.tur = "Fatura" Then
                If odenmismi(Item.firmcode, Item.faturano) = "Evet" Then
                    odenmemishesaplar.Add(New CLASSHESAP(Item.pkey, _
                    Item.firmcode, Item.faturano, Item.tip, Item.tarih, _
                    Item.tutar, Item.aciklama, Item.ay, Item.yil, _
                    Item.eder, Item.tur, Item.oran))
                End If
            End If
        Next

        Return odenmemishesaplar

    End Function

    Public Function odenmismi(ByVal firmcode As String, ByVal faturano As String)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where firmcode=@firmcode and faturano=@faturano and tip=@tip and tur=@tur"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = faturano
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tip", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = "Gider"
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tur", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = "Ödeme"
        komut.Parameters.Add(param4)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12, kol13 As String
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
        "<th>Firma</th>" + _
        "<th>Tip</th>" + _
        "<th>Tarih</th>" + _
        "<th>Fatura No</th>" + _
        "<th>Poliçe Sayısı</th>" + _
        "<th>Eder</th>" + _
        "<th>Tutar</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Ay/Yıl</th>" + _
        "<th>Tür</th>" + _
        "<th>Gecikme Oranı</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        '-----------TÜMÜ --------------------------------------
        If HttpContext.Current.Session("ltip") = "ekstre" Then
            sqlstr = "select * from hesap where firmcode=@firmcode order by tarih asc"

            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("firmcode")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, faturano, tip, tarih, tutar, aciklama As String
        Dim ay, yil As String
        Dim eder As Decimal
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode As String
        Dim ajaxlinksil, dugmesil As String
        Dim hesapozet As String
        Dim policesayisi As Integer
        Dim tur As String
        Dim oran As Decimal

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "odemegirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        'kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("firmcode") Is System.DBNull.Value Then
                        firmcode = veri.Item("firmcode")
                        sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol3 = "<td>" + tip + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol4 = "<td>" + tarih + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("faturano") Is System.DBNull.Value Then
                        faturano = veri.Item("faturano")
                        kol5 = "<td>" + faturano + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("tur") Is System.DBNull.Value Then
                        tur = veri.Item("tur")
                    End If

                    If tip = "Gelir" And tur = "Fatura" Then
                        If Not veri.Item("eder") Is System.DBNull.Value Then
                            eder = veri.Item("eder")
                        End If
                        If Not veri.Item("tutar") Is System.DBNull.Value Then
                            tutar = veri.Item("tutar")
                        End If
                        policesayisi = tutar / eder
                        kol6 = "<td>" + CStr(policesayisi) + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If tip = "Gelir" Then
                        kol7 = "<td>" + Format(eder, "0.00") + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If



                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                        kol8 = "<td>" + tutar + " TL" + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol9 = "<td>" + aciklama + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    '------ay yil -------------------------------------
                    If Not veri.Item("ay") Is System.DBNull.Value Then
                        ay = veri.Item("ay")
                    Else
                        ay = "-"
                    End If

                    If Not veri.Item("yil") Is System.DBNull.Value Then
                        yil = veri.Item("yil")
                    Else
                        yil = "-"
                    End If

                    kol10 = "<td>" + ay + "/" + yil + "</td>"


                    If Not veri.Item("tur") Is System.DBNull.Value Then
                        tur = veri.Item("tur")
                        kol11 = "<td>" + tur + "</td>"
                    Else
                        kol11 = "<td>-</td>"
                    End If


                    If Not veri.Item("oran") Is System.DBNull.Value Then
                        oran = veri.Item("oran")
                        kol12 = "<td>" + Format(oran, "0.00") + "</td>"
                    Else
                        kol12 = "<td>-</td>"
                    End If


                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "hesapsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='hesapsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol13 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + _
                    kol12 + kol13

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()
        db_baglanti.Dispose()


        Dim firmcodez As String
        firmcodez = HttpContext.Current.Session("firmcode")

        hesapozet = "<br/>" + _
        "<strong>Fatura Borçları Toplamı:</strong>" + Format(gelirbul(firmcodez), "0.00") + " TL" + "<br/>" + _
        "<strong>Toplam Ödemeleri:</strong>" + Format(giderbul(firmcodez), "0.00") + " TL" + "<br/>" + _
        "<strong>Kalan Borcu:</strong>" + Format(bakiyebul(firmcodez), "0.00") + " TL" + "<br/>"


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + hesapozet + jvstring
        End If

        Return (donecek)

    End Function




    Public Function listelesirketicinfatura() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12, kol13 As String
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
        "<th>Firma</th>" + _
        "<th>Tarih</th>" + _
        "<th>Fatura No</th>" + _
        "<th>Poliçe Sayısı</th>" + _
        "<th>Eder</th>" + _
        "<th>Tutar</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Ay/Yıl</th>" + _
        "<th>Yazdır</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        'listeleme--------------------------------------------
        sqlstr = "select * from hesap where firmcode=@firmcode and tur=@tur order by tarih desc"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = HttpContext.Current.Session("firmcode")
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tur", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Fatura"
        komut.Parameters.Add(param2)

        girdi = "0"
        Dim link As String
        Dim pkey, faturano, tip, tarih, tutar, aciklama As String
        Dim ay, yil As String
        Dim eder As Decimal

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode As String
        Dim ajaxlinksil, dugmesil As String
        Dim hesapozet As String
        Dim policesayisi As Integer
        Dim tur As String
        Dim oran As Decimal

        Dim ajaxfaturayazdirlink As String
        Dim faturayazdirdugme As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                    End If

                    If Not veri.Item("firmcode") Is System.DBNull.Value Then
                        firmcode = veri.Item("firmcode")
                        sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                    Else
                        kol1 = "<tr><td>-</td>"
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol2 = "<td>" + tarih + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("faturano") Is System.DBNull.Value Then
                        faturano = veri.Item("faturano")
                        kol3 = "<td>" + faturano + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                    End If

                    If Not veri.Item("tur") Is System.DBNull.Value Then
                        tur = veri.Item("tur")
                    End If

                    If tip = "Gelir" And tur = "Fatura" Then
                        If Not veri.Item("eder") Is System.DBNull.Value Then
                            eder = veri.Item("eder")
                        End If
                        If Not veri.Item("tutar") Is System.DBNull.Value Then
                            tutar = veri.Item("tutar")
                        End If
                        policesayisi = tutar / eder
                        kol4 = "<td>" + CStr(policesayisi) + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If tip = "Gelir" Then
                        kol5 = "<td>" + Format(eder, "0.00") + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If


                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                        kol6 = "<td>" + tutar + " TL" + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol7 = "<td>" + aciklama + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    '------ay yil -------------------------------------
                    If Not veri.Item("ay") Is System.DBNull.Value Then
                        ay = veri.Item("ay")
                    Else
                        ay = "-"
                    End If

                    If Not veri.Item("yil") Is System.DBNull.Value Then
                        yil = veri.Item("yil")
                    Else
                        yil = "-"
                    End If

                    kol8 = "<td>" + ay + "/" + yil + "</td>"

                    '----YAZDIR DÜĞMESİ ----------------------------------------------------
                    ajaxfaturayazdirlink = "faturayazdir.aspx?faturano=" + faturano
                    faturayazdirdugme = "<a href='" + ajaxfaturayazdirlink + "'" + _
                    " target='_blank'><span class='button'>Yazdır</span></a>"
                    kol9 = "<td>" + faturayazdirdugme + "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Dim firmcodez As String
        firmcodez = HttpContext.Current.Session("firmcode")

        hesapozet = "<br/>" + _
        "<strong>Fatura Borçları Toplamı:</strong>" + Format(gelirbul(firmcodez), "0.00") + " TL" + "<br/>" + _
        "<strong>Toplam Ödemeleri:</strong>" + Format(giderbul(firmcodez), "0.00") + " TL" + "<br/>" + _
        "<strong>Kalan Borcu:</strong>" + Format(bakiyebul(firmcodez), "0.00") + " TL" + "<br/>"

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + hesapozet + jvstring
        End If

        Return (donecek)

    End Function


    Public Function listelesirketicinodeme() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12, kol13 As String
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
        "<th>Firma</th>" + _
        "<th>Tarih</th>" + _
        "<th>Fatura No</th>" + _
        "<th>Poliçe Sayısı</th>" + _
        "<th>Eder</th>" + _
        "<th>Tutar</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Ay/Yıl</th>" + _
        "<th>Yazdır</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        'listeleme--------------------------------------------
        sqlstr = "select * from hesap where firmcode=@firmcode and tur=@tur order by tarih desc"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = HttpContext.Current.Session("firmcode")
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tur", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Ödeme"
        komut.Parameters.Add(param2)

        girdi = "0"
        Dim link As String
        Dim pkey, faturano, tip, tarih, tutar, aciklama As String
        Dim ay, yil As String
        Dim eder As Decimal

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode As String
        Dim ajaxlinksil, dugmesil As String
        Dim hesapozet As String
        Dim policesayisi As Integer
        Dim tur As String
        Dim oran As Decimal

        Dim ajaxfaturayazdirlink As String
        Dim faturayazdirdugme As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                    End If

                    If Not veri.Item("firmcode") Is System.DBNull.Value Then
                        firmcode = veri.Item("firmcode")
                        sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                    Else
                        kol1 = "<tr><td>-</td>"
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol2 = "<td>" + tarih + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("faturano") Is System.DBNull.Value Then
                        faturano = veri.Item("faturano")
                        kol3 = "<td>" + faturano + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                    End If

                    If Not veri.Item("tur") Is System.DBNull.Value Then
                        tur = veri.Item("tur")
                    End If

                    If tip = "Gelir" And tur = "Fatura" Then
                        If Not veri.Item("eder") Is System.DBNull.Value Then
                            eder = veri.Item("eder")
                        End If
                        If Not veri.Item("tutar") Is System.DBNull.Value Then
                            tutar = veri.Item("tutar")
                        End If
                        policesayisi = tutar / eder
                        kol4 = "<td>" + CStr(policesayisi) + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If tip = "Gelir" Then
                        kol5 = "<td>" + Format(eder, "0.00") + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If


                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                        kol6 = "<td>" + tutar + " TL" + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol7 = "<td>" + aciklama + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    '------ay yil -------------------------------------
                    If Not veri.Item("ay") Is System.DBNull.Value Then
                        ay = veri.Item("ay")
                    Else
                        ay = "-"
                    End If

                    If Not veri.Item("yil") Is System.DBNull.Value Then
                        yil = veri.Item("yil")
                    Else
                        yil = "-"
                    End If

                    kol8 = "<td>" + ay + "/" + yil + "</td>"

                    '----YAZDIR DÜĞMESİ ----------------------------------------------------
                    ajaxfaturayazdirlink = "faturayazdir.aspx?faturano=" + faturano
                    faturayazdirdugme = "<a href='" + ajaxfaturayazdirlink + "'" + _
                    " target='_blank'><span class='button'>Yazdır</span></a>"
                    kol9 = "<td>" + faturayazdirdugme + "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        Dim firmcodez As String
        firmcodez = HttpContext.Current.Session("firmcode")

        hesapozet = "<br/>" + _
        "<strong>Fatura Borçları Toplamı:</strong>" + Format(gelirbul(firmcodez), "0.00") + " TL" + "<br/>" + _
        "<strong>Toplam Ödemeleri:</strong>" + Format(giderbul(firmcodez), "0.00") + " TL" + "<br/>" + _
        "<strong>Kalan Borcu:</strong>" + Format(bakiyebul(firmcodez), "0.00") + " TL" + "<br/>"

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + hesapozet + jvstring
        End If

        Return (donecek)

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele_odenmemisodenmemis(ByVal hangisi As String) As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12, kol13 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim toplam As Decimal

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
        "<th>Firma</th>" + _
        "<th>Tip</th>" + _
        "<th>Tarih</th>" + _
        "<th>Fatura No</th>" + _
        "<th>Poliçe Sayısı</th>" + _
        "<th>Eder</th>" + _
        "<th>Tutar</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Ay/Yıl</th>" + _
        "<th>Tür</th>" + _
        "<th>Gecikme Oranı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim secilenhesap As New List(Of CLASSHESAP)
        If hangisi = "Ödenmiş" Then
            secilenhesap = doldur_odenmisler(HttpContext.Current.Session("firmcode"))
        End If

        If hangisi = "Ödenmemiş" Then
            secilenhesap = doldur_odenmemisler(HttpContext.Current.Session("firmcode"))
        End If

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        girdi = "0"
        Dim link As String
        Dim pkey, faturano, tip, tarih, tutar, aciklama As String
        Dim ay, yil As String
        Dim eder As Decimal
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode As String
        Dim ajaxlinksil, dugmesil As String
        Dim hesapozet As String
        Dim policesayisi As Integer
        Dim tur As String
        Dim oran As Decimal
        Dim toplamyazi As String = ""


        For Each Item As CLASSHESAP In secilenhesap

            girdi = 1

            pkey = Item.pkey
            link = "odemegirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
            'kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
            kol1 = "<tr><td>" + CStr(pkey) + "</td>"

            firmcode = Item.firmcode
            sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
            kol2 = "<td>" + sirket.sirketad + "</td>"


            tip = Item.tip
            kol3 = "<td>" + tip + "</td>"


            tarih = Item.tarih
            kol4 = "<td>" + tarih + "</td>"


            faturano = Item.faturano
            kol5 = "<td>" + faturano + "</td>"


            tur = Item.tur

            If Item.tip = "Gelir" And Item.tur = "Fatura" Then
                eder = Item.eder
            End If

            tutar = Item.tutar
            toplam = toplam + tutar


            policesayisi = tutar / eder
            kol6 = "<td>" + CStr(policesayisi) + "</td>"


            If Item.tip = "Gelir" Then
                kol7 = "<td>" + Format(eder, "0.00") + "</td>"
            Else
                kol7 = "<td>-</td>"
            End If


            tutar = Item.tutar
            kol8 = "<td>" + tutar + " TL" + "</td>"


            aciklama = Item.aciklama
            kol9 = "<td>" + aciklama + "</td>"


            '------ay yil -------------------------------------

            ay = Item.ay
            yil = Item.yil

            kol10 = "<td>" + ay + "/" + yil + "</td>"

            tur = Item.tur
            kol11 = "<td>" + tur + "</td>"


            oran = Item.oran
            kol12 = "<td>" + Format(oran, "0.00") + "</td>"


            satir = satir + kol1 + kol2 + kol3 + kol4 + _
            kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + _
            kol12

        Next

        toplamyazi = "Toplam:" + Format(toplam, "0.00")
        Dim firmcodez As String
        firmcodez = HttpContext.Current.Session("firmcode")


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + toplamyazi + jvstring
        End If

        Return (donecek)

    End Function


    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal faturano As String, ByVal tip As String, _
    ByVal tur As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where faturano=@faturano and tip=@tip and tur=@tur"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = faturano
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tip
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tur", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = tur
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function



    Function dahaoncefaturalandirilmismi(ByVal firmcode As String, ByVal ay As String, _
    ByVal yil As String, ByVal tip As String, ByVal tur As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where firmcode=@firmcode and ay=@ay " + _
        "and yil=@yil and tip=@tip and tur=@tur"


        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ay", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = ay
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@yil", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = yil
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = tip
        komut.Parameters.Add(param4)


        Dim param5 As New SqlParameter("@tur", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = tur
        komut.Parameters.Add(param5)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function dosyaadiolustur(ByVal faturano As String) As String

        Dim datetimestr As String
        Dim donecek As String
        Dim datetime As DateTime
        datetime = Now.Date
        datetimestr = CStr(datetime)

        donecek = faturano + ".pdf"

        Return donecek

    End Function

    Public Function pdfolustur(ByVal hesaplar As List(Of CLASSHESAP), _
    ByVal yontem As String) As String

        Dim simdikitarih As Date
        simdikitarih = Date.Now

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim hesap As New CLASSHESAP
        Dim hesap_Erisim As New CLASSHESAP_ERISIM


        Dim yaratilanfullpath As String
        Dim yaratilacak_pdfdosyaad As String

        yaratilacak_pdfdosyaad = dosyaadiolustur("Hesap")
        yaratilanfullpath = HttpContext.Current.Request.PhysicalApplicationPath + yaratilacak_pdfdosyaad

        'eger önceden var ise sil
        If File.Exists(yaratilanfullpath) = True Then
            File.Delete(yaratilanfullpath)
        End If

        Dim document As New Document()

        Dim doc As Document = New Document
        PdfWriter.GetInstance(doc, New FileStream(HttpContext.Current.Request.PhysicalApplicationPath + _
                              "\" + yaratilacak_pdfdosyaad, FileMode.CreateNew))
        doc.Open()


        For Each hesapitem As CLASSHESAP In hesaplar

            doc.NewPage()

            hesap = hesap_Erisim.bulfaturanovetipegore(hesapitem.faturano, "Gelir")
            sirket = sirket_erisim.bultek_sirketkodagore(hesap.firmcode)

            'LOGO EKLE 
            Dim imageFilePath As String = HttpContext.Current.Server.MapPath(".") + "\belgeresim\logo-big.png"
            Dim jpg As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imageFilePath)
            jpg.ScaleAbsolute(360, 55)
            jpg.Alignment = Element.ALIGN_CENTER
            'jpg.SetAbsolutePosition(0, 0)
            doc.Add(jpg)


            Dim STF_Arial As iTextSharp.text.pdf.BaseFont
            STF_Arial = iTextSharp.text.pdf.BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", "Cp1254", iTextSharp.text.pdf.BaseFont.EMBEDDED)

            Dim fontsize As Single = 9

            Dim font_normal As iTextSharp.text.Font
            Dim font_bold As iTextSharp.text.Font
            Dim font_boldkirmizi As iTextSharp.text.Font
            Dim font_normalunderline As iTextSharp.text.Font

            font_normal = New iTextSharp.text.Font(STF_Arial, fontsize, iTextSharp.text.Font.NORMAL)
            font_bold = New iTextSharp.text.Font(STF_Arial, fontsize, iTextSharp.text.Font.BOLD)
            font_boldkirmizi = New iTextSharp.text.Font(STF_Arial, fontsize, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED)
            font_normalunderline = New iTextSharp.text.Font(STF_Arial, fontsize, iTextSharp.text.Font.UNDERLINE)

            Dim p1, pno, p2, p3, p4, p5, p6, p7, p8, p9, p10 As New Paragraph
            Dim f1, f2, f3, f4, f5 As New Phrase
         

            'RAPOR TARİHİ -------------------------------------------------
            Dim tarih As Date
            tarih = hesap.tarih
            p1.Alignment = Element.ALIGN_RIGHT
            p1.Add(New Chunk(tarih.ToShortDateString(), font_bold))
            doc.Add(p1)


            'NO------------------------------------------------------------
            Dim nostr1, nostr2 As String
            nostr1 = "No: "
            nostr2 = CStr(hesap.faturano)
            pno.Alignment = Element.ALIGN_LEFT
            pno.Add(New Chunk(nostr1, font_normal))
            pno.Add(New Chunk(nostr2, font_bold))
            doc.Add(pno)
            doc.Add(New Paragraph(System.Environment.NewLine))


            'ŞİRKET ADI --------------------------------------------------------------
            p2.Alignment = Element.ALIGN_LEFT
            p2.Add(New Chunk(CStr(sirket.sirketad), font_normal))
            doc.Add(p2)


            'ŞİRKET ADRESİ ------------------------------------------------------------
            p3.Alignment = Element.ALIGN_LEFT
            p3.Add(New Chunk(CStr(sirket.adres), font_normal))
            doc.Add(p3)

            'ŞİRKET YETKİLİ KİŞİ------------------------------------------------------------
            Dim yetkilistr As String
            yetkilistr = "Sn. " + sirket.yetkilikisiadsoyad
            p4.Alignment = Element.ALIGN_LEFT
            p4.Add(New Chunk(yetkilistr, font_normal))
            doc.Add(p4)
            doc.Add(New Paragraph(System.Environment.NewLine))

            'HESAP PARAGRAF------------------------------------------------------------
            Dim adet As Integer
            Dim hesapparagraf As String
            Dim ayinsongunu As Integer = System.DateTime.DaysInMonth(hesap.yil, hesap.ay)
            Dim baslangictarih As String
            Dim baslangictarih_d As Date
            Dim bitistarih As String

            If hesap.eder > 0 Then
                adet = hesap.tutar / hesap.eder
            Else
                adet = 0
            End If

            baslangictarih = "01." + CStr(hesap.ay) + "." + CStr(hesap.yil)
            baslangictarih_d = CDate(baslangictarih)


            bitistarih = CStr(ayinsongunu) + "." + CStr(hesap.ay) + "." + CStr(hesap.yil)


            Dim p5_1, p5_2, p5_3, p5_4, p5_5, p5_6, p5_7 As String
            p5_1 = baslangictarih
            p5_2 = " ile "
            p5_3 = bitistarih
            p5_4 = " tarihleri arasında Kuzey " + _
            "Kıbrıs Sigorta Bilgi Merkezi kullanım ücretiniz " + System.Environment.NewLine + _
            CStr(adet) + " * " + Format(hesap.eder, "0.00") + " = "
            p5_5 = Format(hesap.tutar, "0.00") + " TL"
            p5_6 = "'dır."

            p5.Alignment = Element.ALIGN_LEFT
            p5.Add(New Chunk(p5_1, font_normalunderline))
            p5.Add(New Chunk(p5_2, font_normal))
            p5.Add(New Chunk(p5_3, font_normalunderline))
            p5.Add(New Chunk(p5_4, font_normal))
            p5.Add(New Chunk(p5_5, font_bold))
            p5.Add(New Chunk(p5_6, font_normal))
            doc.Add(p5)
            doc.Add(New Paragraph(System.Environment.NewLine))


            'HESAP HARAKET TABLOSU -------------------------------------------------------------------------------
            Dim rapor As New CLASSRAPOR
            rapor = pdfhelper(hesap.firmcode, baslangictarih_d.AddMonths(-1))
            doc.Add(rapor.pdftablo)
            doc.Add(New Paragraph(System.Environment.NewLine))
            '-----------------------------------------------------------------------------------------------

            'HESAP PARAGRAF 3-------------------------------------------------------
            Dim hx1, hx2, hx3, hx4 As String
            Dim gx1, gx2, gx3, gx4 As String

            hx1 = "Yukarıda belirtilen kullanım ücretini en geç "
            hx2 = CStr(site.faturaodemesongun) + "/" + CStr(simdikitarih.Month) + "/" + CStr(simdikitarih.Year)
            hx3 = " tarihine kadar, KoopBank Ltd. Lefkoşa Merkez'de Sigorta Bilgi Merkezi" + _
            " adına açılmış olan 10-304-0006084050 (UBAN: CT30120000100000000000374512) numaralı hesaba yatırılmasını" + _
            " ve alınan dekontun bir süreti veya kopyasının Sigorta Bilgi Merkezi'ne gönderilmesini rica ederiz."
            p6.Alignment = Element.ALIGN_LEFT
            p6.Add(New Chunk(hx1, font_normal))
            p6.Add(New Chunk(hx2, font_boldkirmizi))
            p6.Add(New Chunk(hx3, font_normal))
            doc.Add(p6)

            gx1 = "Not:"
            gx2 = " Zamanında ödenmeyen ücretler Sigorta Bilgi Merkezi Tüzüğü'nün 10. Maddesinin 4. fıkrası gereği Kamu Alacaklarının Tahsili Usulü Hakkında Yasa kurallarınca tahsil edilecektir."
            p7.Alignment = Element.ALIGN_LEFT
            p7.Add(New Chunk(gx1, font_bold))
            p7.Add(New Chunk(gx2, font_normal))
            doc.Add(p7)
            doc.Add(New Paragraph(System.Environment.NewLine))


            'AD SOYAD ----------------------------------------------------------------------------
            Dim unvanstr As String
            unvanstr = "Saygılarımla," + System.Environment.NewLine + _
            site.musteriadsoyad + System.Environment.NewLine + _
            "Sigorta Bilgi Merkezi Müdürü"
            p8.Alignment = Element.ALIGN_LEFT
            p8.Add(New Chunk(unvanstr, font_normal))
            doc.Add(p8)
            doc.Add(New Paragraph(System.Environment.NewLine))

            'ADRES------------------------------------------------------------------------
            Dim adresstr As String
            adresstr = site.musteriadres + " - Tel:" + site.musteriofistel + " Fax:" + site.musterifax
            p9.Alignment = Element.ALIGN_CENTER
            p9.Add(New Chunk(adresstr, font_normal))
            doc.Add(p9)

        Next

        doc.Close()
        doc.Dispose()

        If yontem = "ekran" Then
            HttpContext.Current.Response.Redirect("~/" + yaratilacak_pdfdosyaad)
        End If

        If yontem = "email" Then
            Return yaratilanfullpath
        End If

    End Function


    Public Function pdfhelper(ByVal firmcode As String, ByVal baslangictarih As Date) As CLASSRAPOR


        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
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
        "<th>Firma</th>" + _
        "<th>Borç/Ödeme</th>" + _
        "<th>Tarih</th>" + _
        "<th>Fatura No</th>" + _
        "<th>Poliçe Sayısı</th>" + _
        "<th>Eder</th>" + _
        "<th>Tutar</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Ay/Yıl</th>" + _
        "<th>Gecikme Oranı</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Firma", GetType(String))
        table.Columns.Add("Tip", GetType(String))
        table.Columns.Add("Tarih", GetType(String))
        table.Columns.Add("Fatura No", GetType(String))
        table.Columns.Add("Poliçe Sayısı", GetType(String))
        table.Columns.Add("Eder", GetType(String))
        table.Columns.Add("Tutar", GetType(String))
        table.Columns.Add("Açıklama", GetType(String))
        table.Columns.Add("Ay/Yıl", GetType(String))
        table.Columns.Add("Gecikme Oranı", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(10)
        pdftable.TotalWidth = 540.0F
        pdftable.LockedWidth = True

        Dim STF_Arial As iTextSharp.text.pdf.BaseFont
        STF_Arial = iTextSharp.text.pdf.BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", "Cp1254", iTextSharp.text.pdf.BaseFont.EMBEDDED)
        Dim font_normal As iTextSharp.text.Font
        Dim font_bold As iTextSharp.text.Font
        font_normal = New iTextSharp.text.Font(STF_Arial, 8, iTextSharp.text.Font.NORMAL)
        font_bold = New iTextSharp.text.Font(STF_Arial, 8, iTextSharp.text.Font.BOLD)


        pdftable.AddCell(New Phrase("Firma", font_bold))
        pdftable.AddCell(New Phrase("Tip", font_bold))
        pdftable.AddCell(New Phrase("Tarih", font_bold))
        pdftable.AddCell(New Phrase("Fatura No", font_bold))
        pdftable.AddCell(New Phrase("Poliçe Sayısı", font_bold))
        pdftable.AddCell(New Phrase("Eder", font_bold))
        pdftable.AddCell(New Phrase("Tutar", font_bold))
        pdftable.AddCell(New Phrase("Açıklama", font_bold))
        pdftable.AddCell(New Phrase("Ay/Yıl", font_bold))
        pdftable.AddCell(New Phrase("Gecikme Oranı", font_bold))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where firmcode=@firmcode " + _
        "and tarih>=@baslangictarih" + _
        " order by tarih desc"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = baslangictarih
        komut.Parameters.Add(param2)

        girdi = "0"
        Dim link As String
        Dim pkey, faturano, tip, tarih, tutar, aciklama As String
        Dim ay, yil As String
        Dim eder As Decimal
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim hesapozet As String
        Dim policesayisi As Integer
        Dim tip_aciklama As String
        Dim tur As String
        Dim oran As Decimal

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("firmcode") Is System.DBNull.Value Then
                        firmcode = veri.Item("firmcode")
                        sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                        saf1 = sirket.sirketad
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        If tip = "Gelir" Then
                            tip_aciklama = "Borç"
                        Else
                            tip_aciklama = "Ödeme"
                        End If
                        kol2 = "<td>" + tip_aciklama + "</td>"
                        saf2 = tip_aciklama
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol3 = "<td>" + tarih + "</td>"
                        saf3 = tarih
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("faturano") Is System.DBNull.Value Then
                        faturano = veri.Item("faturano")
                        kol4 = "<td>" + faturano + "</td>"
                        saf4 = faturano
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If


                    If Not veri.Item("tur") Is System.DBNull.Value Then
                        tur = veri.Item("tur")
                    End If

                    If tip = "Gelir" And tur = "Fatura" Then
                        If Not veri.Item("eder") Is System.DBNull.Value Then
                            eder = veri.Item("eder")
                        End If
                        If Not veri.Item("tutar") Is System.DBNull.Value Then
                            tutar = veri.Item("tutar")
                        End If
                        policesayisi = tutar / eder
                        kol5 = "<td>" + CStr(policesayisi) + "</td>"
                        saf5 = CStr(policesayisi)
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If tip = "Gelir" Then
                        kol6 = "<td>" + Format(eder, "0.00") + "</td>"
                        saf6 = Format(eder, "0.00")
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("tutar") Is System.DBNull.Value Then
                        tutar = veri.Item("tutar")
                        kol7 = "<td>" + tutar + " TL" + "</td>"
                        saf7 = tutar + " TL"
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("aciklama") Is System.DBNull.Value Then
                        aciklama = veri.Item("aciklama")
                        kol8 = "<td>" + aciklama + "</td>"
                        saf8 = aciklama
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If

                    '------ay yil -------------------------------------
                    If Not veri.Item("ay") Is System.DBNull.Value Then
                        ay = veri.Item("ay")
                    Else
                        ay = "-"
                    End If

                    If Not veri.Item("yil") Is System.DBNull.Value Then
                        yil = veri.Item("yil")
                    Else
                        yil = "-"
                    End If

                    kol9 = "<td>" + ay + "/" + yil + "</td>"
                    saf9 = ay + "/" + yil


                    If Not veri.Item("oran") Is System.DBNull.Value Then
                        oran = veri.Item("oran")
                        kol10 = "<td>" + "%" + Format(oran, "0.00") + "</td></tr>"
                        saf10 = "%" + Format(oran, "0.00")
                    Else
                        kol10 = "<td>-</td></tr>"
                        saf10 = "-"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10

                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10)

                    pdftable.AddCell(New Phrase(saf1, font_normal))
                    pdftable.AddCell(New Phrase(saf2, font_normal))
                    pdftable.AddCell(New Phrase(saf3, font_normal))
                    pdftable.AddCell(New Phrase(saf4, font_normal))
                    pdftable.AddCell(New Phrase(saf5, font_normal))
                    pdftable.AddCell(New Phrase(saf6, font_normal))
                    pdftable.AddCell(New Phrase(saf7, font_normal))
                    pdftable.AddCell(New Phrase(saf8, font_normal))
                    pdftable.AddCell(New Phrase(saf9, font_normal))
                    pdftable.AddCell(New Phrase(saf10, font_normal))

                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        hesapozet = "<br/>" + _
        "<strong>Fatura Borçları Toplamı:</strong>" + Format(gelirbul(firmcode), "0.00") + " TL" + "<br/>" + _
        "<strong>Toplam Ödemeleri:</strong>" + Format(giderbul(firmcode), "0.00") + " TL" + "<br/>" + _
        "<strong>Kalan Borcu:</strong>" + Format(bakiyebul(firmcode), "0.00") + " TL" + "<br/>"

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function

    Public Function emailgonder(ByVal faturano As String) As CLADBOPRESULT

        Dim girdi As String = "Hayır"
        Dim rhatatxt As String
        Dim retkilenen As Integer
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim hesaplar As New List(Of CLASSHESAP)

        Dim result As New CLADBOPRESULT
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim email_erisim As New CLASSEMAIL_ERISIM

        Dim emailayar As New CLASSEMAILAYAR
        Dim emailayar_Erisim As New CLASSEMAILAYAR_ERISIM
        emailayar = emailayar_Erisim.bul(1)

        Dim hesap As New CLASSHESAP
        Dim hesap_Erisim As New CLASSHESAP_ERISIM
        hesap = hesap_Erisim.bulfaturanovetipegore(faturano, "Gelir")

        hesaplar.Add(New CLASSHESAP(hesap.pkey, hesap.firmcode, hesap.faturano, hesap.tip, hesap.tarih, _
        hesap.tutar, hesap.aciklama, hesap.ay, hesap.yil, hesap.eder, hesap.tur, hesap.oran))

        sirket = sirket_erisim.bultek_sirketkodagore(hesap.firmcode)

        Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM
        Dim faturagonderilecekkullanicilar As New List(Of CLASSSIRKETFATURABAG)
        faturagonderilecekkullanicilar = sirketfaturabag_erisim.doldur_ilgilisirket(sirket.pkey)

        For Each gonkullaniciitem As CLASSSIRKETFATURABAG In faturagonderilecekkullanicilar
            girdi = "Evet"
            Dim email As New CLASSEMAIL
            Dim attachmentfile_path As String
            attachmentfile_path = pdfolustur(hesaplar, "email")

            email.body = "Değerli Üyemiz," + "<br/><br/>" + _
            ayyazibul(hesap.ay) + " Ayı KKSMB Kullanım Ücreti bilgileriniz ektedir." + "<br/><br/>" + _
            "Saygılarımızla"

            email.kimden = emailayar.username
            email.kime = gonkullaniciitem.eposta
            email.subject = ayyazibul(hesap.ay) + " Ayı KKSMB Kullanım Ücreti "
            email.attachmentfile = attachmentfile_path
            result = email_erisim.gonder(email)
            If result.durum = "Kaydedildi" Then
                rhatatxt = rhatatxt + " " + email.kime + "<br/>"
                retkilenen = retkilenen + 1
            End If

        Next

        If girdi = "Evet" Then
            result.etkilenen = retkilenen
            result.hatastr = rhatatxt
        End If

        If girdi = "Hayır" Then
            result.etkilenen = 0
            result.durum = "Kaydedilmedi"
            result.hatastr = "Fatura gönderilecek kullanıcı tanımlanmamış"
        End If

        Return result


    End Function



    Public Function gelirbul(ByVal firmcode As String) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gelir"
        komut.Parameters.Add(param2)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function


    Public Function giderbul(ByVal firmcode As String) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gider"
        komut.Parameters.Add(param2)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function


    Public Function bakiyebul(ByVal firmcode As String) As Decimal

        Dim gelir, gider, bakiye As String
        gelir = gelirbul(firmcode)
        gider = giderbul(firmcode)
        bakiye = gelir - gider

        Return bakiye

    End Function



    Public Function gelirbultarihli(ByVal firmcode As String, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip " + _
        "and tarih>=@baslangictarih and tarih<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gelir"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        param3.Value = baslangictarih
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        param4.Value = bitistarih
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function


    Public Function gelirbulayli(ByVal firmcode As String, ByVal ay As Integer) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip and ay=@ay"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gelir"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ay", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = ay
        komut.Parameters.Add(param3)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function


    Public Function gelirbulyilli(ByVal firmcode As String, ByVal yil As Integer) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip and DATEPART(year, tarih)=@yil"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gelir"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@yil", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = yil
        komut.Parameters.Add(param3)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function



    Public Function giderbulyilli(ByVal firmcode As String, ByVal yil As Integer) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip and  " + _
        "yil=@yil"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gider"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@yil", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = yil
        komut.Parameters.Add(param3)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function




    Public Function giderbulayli(ByVal firmcode As String, ByVal ay As Integer) As Decimal

        Dim tutar As Decimal = 0
        Dim faturano As String

        Dim odemeler As New List(Of CLASSHESAP)
        Dim ayinfaturasi As New CLASSHESAP
        Dim faturalar As New List(Of CLASSHESAP)
        faturalar = doldur_ilgilisirketin(firmcode)
        odemeler = doldur_odenmisler(firmcode)


        For Each Item As CLASSHESAP In faturalar
            If Item.ay = ay And Item.tur = "Fatura" Then
                ayinfaturasi = bultek(Item.pkey)
                For Each itemodenmis As CLASSHESAP In odemeler
                    If itemodenmis.faturano = ayinfaturasi.faturano Then
                        tutar = itemodenmis.tutar
                    End If
                Next
            End If
        Next
        Return tutar



    End Function

    Public Function giderbultarihli(ByVal firmcode As String, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip " + _
         "and tarih>=@baslangictarih and tarih<=@bitistarih"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gider"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        param3.Value = baslangictarih
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param4.Direction = ParameterDirection.Input
        param4.Value = bitistarih
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function



    'yeni 
    Public Function gelirbulayli_yilli(ByVal firmcode As String, ByVal ay As Integer, _
    ByVal yil As Integer) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip and ay=@ay and yil=@yil"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gelir"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ay", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = ay
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yil", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = yil
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function


    'yeni 
    Public Function giderbulayli_yilli(ByVal firmcode As String, ByVal ay As Integer, _
    ByVal yil As Integer) As Decimal

        Dim tutar As Decimal
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select sum(tutar) from hesap where firmcode=@firmcode and tip=@tip and ay=@ay and yil=@yil"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Gider"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ay", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = ay
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yil", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = yil
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            tutar = 0
        Else
            tutar = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return tutar

    End Function


    'yeni
    Public Function odemesibul_pkey(ByVal firmcode As String, ByVal faturano As String, _
    ByVal tip As String) As Integer

        Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
        Dim pkey As String
        Dim girdi As String = "0"
        Dim simdikitarih As Date
        simdikitarih = Date.Now

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where firmcode=@firmcode and faturano=@faturano and tip=@tip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@faturano", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = faturano
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tip", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = tip
        komut.Parameters.Add(param3)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                girdi = "1"

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    pkey = CStr(veri.Item("pkey"))
                End If

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            Return pkey
        Else
            Return 0
        End If

    End Function


    Public Function faturanobul(ByVal firmcode As String, _
    ByVal tip As String, ByVal ay As Integer, ByVal yil As Integer) As String

        Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
        Dim faturano As String
        Dim girdi As String = "0"
        Dim simdikitarih As Date
        simdikitarih = Date.Now

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from hesap where firmcode=@firmcode and tip=@tip and ay=@ay and yil=@yil"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@firmcode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = firmcode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = tip
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ay", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = ay
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yil", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = yil
        komut.Parameters.Add(param4)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                girdi = "1"

                If Not veri.Item("faturano") Is System.DBNull.Value Then
                    faturano = CStr(veri.Item("faturano"))
                End If

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            Return faturano
        Else
            Return "0"
        End If

    End Function




    Public Function bakiyebultarihli(ByVal firmcode As String, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date) As Decimal

        Dim gelir, gider, bakiye As String
        gelir = gelirbultarihli(firmcode,baslangictarih,bitistarih)
        gider = giderbultarihli(firmcode,baslangictarih,bitistarih)
        bakiye = gelir - gider

        Return bakiye

    End Function


    Public Function bakiyebulyilli(ByVal firmcode As String, ByVal yil As Integer) As Decimal

        Dim gelir, gider, bakiye As String
        gelir = gelirbulyilli(firmcode, yil)
        gider = giderbulyilli(firmcode, yil)
        bakiye = gelir - gider

        Return bakiye

    End Function


    Public Function ayyazibul(ByVal ay As Integer) As String

        Dim donecek_ayyazi As String

        Select Case ay
            Case 1
                donecek_ayyazi = "Ocak"
            Case 2
                donecek_ayyazi = "Şubat"
            Case 3
                donecek_ayyazi = "Mart"
            Case 4
                donecek_ayyazi = "Nisan"
            Case 5
                donecek_ayyazi = "Mayıs"
            Case 6
                donecek_ayyazi = "Haziran"
            Case 7
                donecek_ayyazi = "Temmuz"
            Case 8
                donecek_ayyazi = "Ağustos"
            Case 9
                donecek_ayyazi = "Eylül"
            Case 10
                donecek_ayyazi = "Ekim"
            Case 11
                donecek_ayyazi = "Kasım"
            Case 12
                donecek_ayyazi = "Aralık"
        End Select

        Return donecek_ayyazi


    End Function



End Class


