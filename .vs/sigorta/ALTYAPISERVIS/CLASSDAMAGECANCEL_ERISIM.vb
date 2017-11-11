Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSDAMAGECANCEL_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim DamageCancel As New CLASSDamageCancel
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal DamageCancel As CLASSDAMAGECANCEL) As CLADBOPRESULT


        Dim varmi As String
        varmi = ciftkayitkontrol(DamageCancel.FirmCode, DamageCancel.ProductCode, DamageCancel.AgencyCode, _
        DamageCancel.PolicyNumber, DamageCancel.TecditNumber, DamageCancel.FileNo, DamageCancel.RequestNo, _
        DamageCancel.ProductType, DamageCancel.iptaltur)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu hasar için seçtiğiniz iptal türünde halihazırda daha " + _
            "önce iptal işlemi yapılmıştır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into DamageCancel values (@pkey," + _
            "@FirmCode,@ProductCode,@AgencyCode,@PolicyNumber," + _
            "@TecditNumber,@FileNo,@RequestNo,@ProductType,@iptaltur," + _
            "@iptaltarih,@iptalkullanicipkey,@kayittarih)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If DamageCancel.FirmCode = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = DamageCancel.FirmCode
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If DamageCancel.ProductCode = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = DamageCancel.ProductCode
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If DamageCancel.AgencyCode = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = DamageCancel.AgencyCode
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If DamageCancel.PolicyNumber = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = DamageCancel.PolicyNumber
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If DamageCancel.TecditNumber = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = DamageCancel.TecditNumber
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@FileNo", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If DamageCancel.FileNo = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = DamageCancel.FileNo
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If DamageCancel.RequestNo = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = DamageCancel.RequestNo
            End If
            komut.Parameters.Add(param8)


            Dim param9 As New SqlParameter("@ProductType", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If DamageCancel.ProductType = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = DamageCancel.ProductType
            End If
            komut.Parameters.Add(param9)


            Dim param10 As New SqlParameter("@iptaltur", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If DamageCancel.iptaltur = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = DamageCancel.iptaltur
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@iptaltarih", SqlDbType.Date)
            param11.Direction = ParameterDirection.Input
            If DamageCancel.iptaltarih Is Nothing Or DamageCancel.iptaltarih = "00:00:00" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = DamageCancel.iptaltarih
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@iptalkullanicipkey", SqlDbType.Int)
            param12.Direction = ParameterDirection.Input
            If DamageCancel.iptalkullanicipkey = 0 Then
                param12.Value = 0
            Else
                param12.Value = DamageCancel.iptalkullanicipkey
            End If
            komut.Parameters.Add(param12)


            Dim param13 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
            param13.Direction = ParameterDirection.Input
            If DamageCancel.kayittarih Is Nothing Or DamageCancel.kayittarih = "00:00:00" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = DamageCancel.kayittarih
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
        sqlstr = "select max(pkey) from DamageCancel"
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
    Function Duzenle(ByVal DamageCancel As CLASSDAMAGECANCEL) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update DamageCancel set " + _
        "FirmCode=@FirmCode," + _
        "ProductCode=@ProductCode," + _
        "AgencyCode=@AgencyCode," + _
        "PolicyNumber=@PolicyNumber," + _
        "TecditNumber=@TecditNumber," + _
        "FileNo=@FileNo," + _
        "RequestNo=@RequestNo," + _
        "ProductType=@ProductType," + _
        "iptaltur=@iptaltur," + _
        "iptaltarih=@iptaltarih," + _
        "iptalkullanicipkey=@iptalkullanicipkey," + _
        "kayittarih=@kayittarih" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = DamageCancel.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If DamageCancel.FirmCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = DamageCancel.FirmCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If DamageCancel.ProductCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = DamageCancel.ProductCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If DamageCancel.AgencyCode = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = DamageCancel.AgencyCode
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If DamageCancel.PolicyNumber = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = DamageCancel.PolicyNumber
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If DamageCancel.TecditNumber = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = DamageCancel.TecditNumber
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If DamageCancel.FileNo = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = DamageCancel.FileNo
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If DamageCancel.RequestNo = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = DamageCancel.RequestNo
        End If
        komut.Parameters.Add(param8)


        Dim param9 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If DamageCancel.ProductType = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = DamageCancel.ProductType
        End If
        komut.Parameters.Add(param9)


        Dim param10 As New SqlParameter("@iptaltur", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If DamageCancel.iptaltur = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = DamageCancel.iptaltur
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@iptaltarih", SqlDbType.Date)
        param11.Direction = ParameterDirection.Input
        If DamageCancel.iptaltarih Is Nothing Or DamageCancel.iptaltarih = "00:00:00" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = DamageCancel.iptaltarih
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@iptalkullanicipkey", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        If DamageCancel.iptalkullanicipkey = 0 Then
            param12.Value = 0
        Else
            param12.Value = DamageCancel.iptalkullanicipkey
        End If
        komut.Parameters.Add(param12)


        Dim param13 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param13.Direction = ParameterDirection.Input
        If DamageCancel.kayittarih Is Nothing Or DamageCancel.kayittarih = "00:00:00" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = DamageCancel.kayittarih
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
    Function bultek(ByVal pkey As String) As CLASSDAMAGECANCEL

        Dim komut As New SqlCommand
        Dim donecekDamageCancel As New CLASSDAMAGECANCEL()

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageCancel where " + _
        " pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekDamageCancel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekDamageCancel.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekDamageCancel.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekDamageCancel.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekDamageCancel.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekDamageCancel.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    donecekDamageCancel.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    donecekDamageCancel.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekDamageCancel.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("iptaltur") Is System.DBNull.Value Then
                    donecekDamageCancel.iptaltur = veri.Item("iptaltur")
                End If

                If Not veri.Item("iptaltarih") Is System.DBNull.Value Then
                    donecekDamageCancel.iptaltarih = veri.Item("iptaltarih")
                End If

                If Not veri.Item("iptalkullanicipkey") Is System.DBNull.Value Then
                    donecekDamageCancel.iptalkullanicipkey = veri.Item("iptalkullanicipkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekDamageCancel.kayittarih = veri.Item("kayittarih")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekDamageCancel

    End Function

    '---------------------------------doldur-----------------------------------------
    Function doldur_ilgilidamage(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String) As List(Of CLASSDAMAGECANCEL)

        Dim komut As New SqlCommand
        Dim donecekDamageCancel As New CLASSDAMAGECANCEL()

        Dim damagecancellar As New List(Of CLASSDAMAGECANCEL)


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageCancel where " + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo" + _
        " and ProductType=@ProductType"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = AgencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = PolicyNumber
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = TecditNumber
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = FileNo
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = RequestNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekDamageCancel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekDamageCancel.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekDamageCancel.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekDamageCancel.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekDamageCancel.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekDamageCancel.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    donecekDamageCancel.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    donecekDamageCancel.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekDamageCancel.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("iptaltur") Is System.DBNull.Value Then
                    donecekDamageCancel.iptaltur = veri.Item("iptaltur")
                End If

                If Not veri.Item("iptaltarih") Is System.DBNull.Value Then
                    donecekDamageCancel.iptaltarih = veri.Item("iptaltarih")
                End If

                If Not veri.Item("iptalkullanicipkey") Is System.DBNull.Value Then
                    donecekDamageCancel.iptalkullanicipkey = veri.Item("iptalkullanicipkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekDamageCancel.kayittarih = veri.Item("kayittarih")
                End If

                damagecancellar.Add(New CLASSDAMAGECANCEL(donecekDamageCancel.pkey, _
                donecekDamageCancel.FirmCode, donecekDamageCancel.ProductCode, _
                donecekDamageCancel.AgencyCode, donecekDamageCancel.PolicyNumber, _
                donecekDamageCancel.TecditNumber, donecekDamageCancel.FileNo, _
                donecekDamageCancel.RequestNo, donecekDamageCancel.ProductType, _
                donecekDamageCancel.iptaltur, donecekDamageCancel.iptaltarih, _
                donecekDamageCancel.iptalkullanicipkey, _
                donecekDamageCancel.kayittarih))

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return damagecancellar

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        'SİLME İŞLEMENİ LOGLA-----------------------------
        Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM
        Dim silinecekdamagecancel As New CLASSDAMAGECANCEL
        silinecekdamagecancel = bultek(pkey)
        Dim silmeneyegore As String
        Dim silmekriter As String
        silmeneyegore = silinecekdamagecancel.iptaltur
        silmekriter = CStr(silinecekdamagecancel.FirmCode) + "-" + _
        CStr(silinecekdamagecancel.ProductCode) + "-" + _
        CStr(silinecekdamagecancel.AgencyCode) + "-" + _
        CStr(silinecekdamagecancel.PolicyNumber) + "-" + _
        CStr(silinecekdamagecancel.TecditNumber) + "-" + _
        CStr(silinecekdamagecancel.FileNo) + "-" + _
        CStr(silinecekdamagecancel.RequestNo) + "-" + _
        CStr(silinecekdamagecancel.ProductType)

        loggenel_erisim.Ekle(New CLASSLOGGENEL(0, DateTime.Now, _
        HttpContext.Current.Session("kullanici_pkey"), "Sil", "DamageCancel", _
        "Hasar İptal Silme", silmeneyegore, silmekriter, 0, "Hayır", "", "", "Web"))


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from DamageCancel where " + _
        " pkey=@pkey"

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
    Public Function doldur() As List(Of CLASSDamageCancel)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekDamageCancel As New CLASSDamageCancel
        Dim DamageCanceller As New List(Of CLASSDamageCancel)
        komut.Connection = db_baglanti
        sqlstr = "select * from DamageCancel"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekDamageCancel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekDamageCancel.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekDamageCancel.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekDamageCancel.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekDamageCancel.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekDamageCancel.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("FileNo") Is System.DBNull.Value Then
                    donecekDamageCancel.FileNo = veri.Item("FileNo")
                End If

                If Not veri.Item("RequestNo") Is System.DBNull.Value Then
                    donecekDamageCancel.RequestNo = veri.Item("RequestNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekDamageCancel.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("iptaltur") Is System.DBNull.Value Then
                    donecekDamageCancel.iptaltur = veri.Item("iptaltur")
                End If

                If Not veri.Item("iptaltarih") Is System.DBNull.Value Then
                    donecekDamageCancel.iptaltarih = veri.Item("iptaltarih")
                End If

                If Not veri.Item("iptalkullanicipkey") Is System.DBNull.Value Then
                    donecekDamageCancel.iptalkullanicipkey = veri.Item("iptalkullanicipkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekDamageCancel.kayittarih = veri.Item("kayittarih")
                End If

                DamageCanceller.Add(New CLASSDAMAGECANCEL(donecekDamageCancel.pkey, _
                donecekDamageCancel.FirmCode, donecekDamageCancel.ProductCode, _
                donecekDamageCancel.AgencyCode, donecekDamageCancel.PolicyNumber, _
                donecekDamageCancel.TecditNumber, donecekDamageCancel.FileNo, _
                donecekDamageCancel.RequestNo, donecekDamageCancel.ProductType, donecekDamageCancel.iptaltur, _
                donecekDamageCancel.iptaltarih, donecekDamageCancel.iptalkullanicipkey, _
                donecekDamageCancel.kayittarih))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return DamageCanceller

    End Function


    '--- BU HASARIN İPTALİ VARMI -------------------------------------------------------
    Function hasariniptalivarmi(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageCancel where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo " + _
        " and ProductType=@ProductType"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = AgencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = PolicyNumber
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = TecditNumber
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = FileNo
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = RequestNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    '--- ÇİFT KAYIT KONTROL  -------------------------------------------------------
    Function ciftkayitkontrol(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String, _
    ByVal iptaltur As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageCancel where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo " + _
        " and ProductType=@ProductType " + _
        " and iptaltur=@iptaltur"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = AgencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = PolicyNumber
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = TecditNumber
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = FileNo
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = RequestNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@iptaltur", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        param9.Value = iptaltur
        komut.Parameters.Add(param9)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    'HASAR İPTAL TABLO
    Public Function hasariptal_tablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String) As String


        Dim jvstring As String

        jvstring = "<script type='text/javascript'>" + _
        "$(document).ready(function() {" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim DamageInfo As New DamageInfo

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim donecek As String
        Dim satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim kol6, kol7, kol8, kol9, kol10 As String

        Dim ajaxlinksil, dugmesil As String


        Dim basliklar, tabloson As String
        Dim hasariniptalleri As New List(Of CLASSDAMAGECANCEL)

        hasariniptalleri = doldur_ilgilidamage(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType)

        basliklar = "<table style='font-size:70%;width:100%' class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>İptal Türü</th>" + _
        "<th>İptal Kayıt Tarihi</th>" + _
        "<th>İptal Tarihi</th>" + _
        "<th>İptali Yapan</th>" + _
        "<th>İşlem</th>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itemhasariptal As CLASSDAMAGECANCEL In hasariniptalleri

            kol1 = "<td>" + sirket_erisim.bultek_sirketkodagore(CStr(itemhasariptal.FirmCode)).sirketad + "</td>"
            kol2 = "<td>" + CStr(itemhasariptal.ProductCode) + "</td>"
            kol3 = "<td>" + CStr(itemhasariptal.AgencyCode) + "</td>"
            kol4 = "<td>" + CStr(itemhasariptal.PolicyNumber) + "</td>"
            kol5 = "<td>" + CStr(itemhasariptal.FileNo) + "</td>"
            kol6 = "<td>" + CStr(itemhasariptal.iptaltur) + "</td>"
            kol7 = "<td>" + CStr(itemhasariptal.kayittarih) + "</td>"
            kol8 = "<td>" + CStr(itemhasariptal.iptaltarih) + "</td>"
            kol9 = "<td>" + kullanici_erisim.bultek(itemhasariptal.iptalkullanicipkey).adsoyad + "</td>"

            ajaxlinksil = "damagecancelsil(" + CStr(itemhasariptal.pkey) + ")"
            dugmesil = "<span id='acentesilbutton' onclick='" + ajaxlinksil + _
            "' class='button'>Sil</span>"

            kol10 = "<td>" + dugmesil + "</td></tr>"

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10

        Next

        donecek = basliklar + satir + tabloson + jvstring
        Return donecek

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11, kol12 As String
        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10, saf11, saf12 As String

        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim sqldevam As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket</th>" + _
        "<th>Ürün</th>" + _
        "<th>Acente</th>" + _
        "<th>Poliçe</th>" + _
        "<th>Dosya No</th>" + _
        "<th>İptal Türü</th>" + _
        "<th>İptal Tarihi</th>" + _
        "<th>İptal Eden Kullanıcı</th>" + _
        "<th>Kayıt Tarihi</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        Table.Columns.Add("Şirket", GetType(String))
        Table.Columns.Add("Ürün", GetType(String))
        Table.Columns.Add("Acente", GetType(String))
        Table.Columns.Add("Poliçe", GetType(String))
        Table.Columns.Add("Dosya No", GetType(String))
        table.Columns.Add("İptal Türü", GetType(String))
        table.Columns.Add("İptal Tarihi", GetType(String))
        table.Columns.Add("İptal Eden Kullanıcı", GetType(String))
        table.Columns.Add("Kayıt Tarihi", GetType(String))

        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(9)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Ürün", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe", fbaslik))
        pdftable.AddCell(New Phrase("Dosya No", fbaslik))
        pdftable.AddCell(New Phrase("İptal Türü", fbaslik))
        pdftable.AddCell(New Phrase("İtal Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("İptal Eden Kullanıcı", fbaslik))
        pdftable.AddCell(New Phrase("Kayıt Tarihi", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        'iptal tarihine göre ise
        If HttpContext.Current.Session("neyegore") = "iptal" Then
            sqldevam = "(Convert(DATE,iptaltarih)>=@iptalbaslangic and Convert(DATE,iptaltarih)<=@iptalbitis)"
        End If

        'kayit tarihine göre ise
        If HttpContext.Current.Session("neyegore") = "kayit" Then
            sqldevam = "(Convert(DATE,kayittarih)>=@kayitbaslangic and Convert(DATE,kayittarih)<=@kayitbitis)"
        End If

        sqlstr = "select * from DamageCancel where " + sqldevam

        komut = New SqlCommand(sqlstr, db_baglanti)

        If HttpContext.Current.Session("neyegore") = "iptal" Then
            komut.Parameters.Add("@iptalbaslangic", SqlDbType.DateTime)
            komut.Parameters("@iptalbaslangic").Value = HttpContext.Current.Session("iptalbaslangic")

            komut.Parameters.Add("@iptalbitis", SqlDbType.DateTime)
            komut.Parameters("@iptalbitis").Value = Current.Session("iptalbitis")
        End If


        If HttpContext.Current.Session("neyegore") = "kayit" Then
            komut.Parameters.Add("@kayitbaslangic", SqlDbType.DateTime)
            komut.Parameters("@kayitbaslangic").Value = HttpContext.Current.Session("kayitbaslangic")

            komut.Parameters.Add("@kayitbitis", SqlDbType.DateTime)
            komut.Parameters("@kayitbitis").Value = Current.Session("kayitbitis")
        End If


        girdi = "0"

        Dim link As String
        Dim pkey, FirmCode, ProductCode, AgencyCode As String
        Dim PolicyNumber, TecditNumber, FileNo, RequestNo, iptaltur As String
        Dim iptaltarih, iptalkullanicipkey, kayittarih As String
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                        FirmCode = veri.Item("FirmCode")
                        sirket = sirket_Erisim.bultek_sirketkodagore(FirmCode)
                        kol1 = "<td>" + sirket.sirketad + "</td>"
                        saf1 = sirket.sirketad
                    Else
                        kol1 = "<td>-</td>"
                    End If

                    If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                        ProductCode = veri.Item("ProductCode")
                        kol2 = "<td>" + ProductCode + "</td>"
                        saf2 = ProductCode
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = ""
                    End If

                    If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                        AgencyCode = veri.Item("AgencyCode")
                        kol3 = "<td>" + AgencyCode + "</td>"
                        saf3 = AgencyCode
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = ""
                    End If

                    If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                        PolicyNumber = veri.Item("PolicyNumber")
                        kol4 = "<td>" + PolicyNumber + "</td>"
                        saf4 = PolicyNumber
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = ""
                    End If


                    If Not veri.Item("FileNo") Is System.DBNull.Value Then
                        FileNo = veri.Item("FileNo")
                        kol5 = "<td>" + FileNo + "</td>"
                        saf5 = FileNo
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = ""
                    End If



                    If Not veri.Item("iptaltur") Is System.DBNull.Value Then
                        iptaltur = veri.Item("iptaltur")
                        kol6 = "<td>" + iptaltur + "</td>"
                        saf6 = iptaltur
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = ""
                    End If


                    If Not veri.Item("iptaltarih") Is System.DBNull.Value Then
                        iptaltarih = veri.Item("iptaltarih")
                        kol7 = "<td>" + iptaltarih + "</td>"
                        saf7 = iptaltarih
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = ""
                    End If

                    If Not veri.Item("iptalkullanicipkey") Is System.DBNull.Value Then
                        iptalkullanicipkey = veri.Item("iptalkullanicipkey")
                        kullanici = kullanici_erisim.bultek(iptalkullanicipkey)
                        kol8 = "<td>" + kullanici.adsoyad + "</td>"
                        saf8 = kullanici.adsoyad
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = ""

                    End If

                    If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                        kayittarih = veri.Item("kayittarih")
                        kol9 = "<td>" + kayittarih + "</td></tr>"
                        saf9 = kayittarih
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = ""
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9

                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
                    pdftable.AddCell(New Phrase(saf9, fdata))

                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function



    '---    HASAR İPTAL EDİLMİŞMİ  -------------------------------------------------------
    Function hasariptaledilmismi(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String, ByVal iptaltur As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from DamageCancel where" + _
        " FirmCode=@FirmCode" + _
        " and ProductCode=@ProductCode " + _
        " and AgencyCode=@AgencyCode " + _
        " and PolicyNumber=@PolicyNumber " + _
        " and TecditNumber=@TecditNumber " + _
        " and FileNo=@FileNo " + _
        " and RequestNo=@RequestNo " + _
        " and ProductType=@ProductType " + _
        " and iptaltur=@iptaltur"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = FirmCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = AgencyCode
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = PolicyNumber
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@TecditNumber", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = TecditNumber
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@FileNo", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = FileNo
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@RequestNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = RequestNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@iptaltur", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        param9.Value = iptaltur
        komut.Parameters.Add(param9)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


End Class