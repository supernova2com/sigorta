Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSACENTE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim acente As New CLASSacente
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal acente As CLASSACENTE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        Dim kaydedilenpkey As Integer
        varmi = ciftkayitkontrol("acentead", acente.acentead)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu acente isminde halihazırda kayıt vardır."
            resultset.etkilenen = 0
        End If

        varmi = ciftkayitkontrol("sicilno", acente.sicilno)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu acente sicil numarasıyla halihazırda kayıt vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti

            sqlstr = "insert into acente values (@pkey," + _
            "@acentead,@sicilno,@aktifmi,@merkezmi," + _
            "@yetkiadsoyad,@yetkikimlikno,@yetkiceptel,@yetkiemail," + _
            "@tel,@fax,@ekleyenkullanicipkey,@eklenmetarih," + _
            "@guncelleyenkullanicipkey,@guncellenmetarih,@acentetippkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            kaydedilenpkey = pkeybul()
            param1.Value = kaydedilenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@acentead", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If acente.acentead = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = acente.acentead
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@sicilno", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If acente.sicilno = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = acente.sicilno
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If acente.aktifmi = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = acente.aktifmi
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@merkezmi", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If acente.merkezmi = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = acente.merkezmi
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@yetkiadsoyad", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If acente.yetkiadsoyad = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = acente.yetkiadsoyad
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@yetkikimlikno", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If acente.yetkikimlikno = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = acente.yetkikimlikno
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@yetkiceptel", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If acente.yetkiceptel = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = acente.yetkiceptel
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@yetkiemail", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If acente.yetkiemail = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = acente.yetkiemail
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@tel", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If acente.tel = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = acente.tel
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@fax", SqlDbType.VarChar)
            param11.Direction = ParameterDirection.Input
            If acente.fax = "" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = acente.fax
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
            param12.Direction = ParameterDirection.Input
            If acente.ekleyenkullanicipkey = 0 Then
                param12.Value = 0
            Else
                param12.Value = acente.ekleyenkullanicipkey
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@eklenmetarih", SqlDbType.DateTime)
            param13.Direction = ParameterDirection.Input
            If acente.eklenmetarih Is Nothing Or acente.eklenmetarih = "00:00:00" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = acente.eklenmetarih
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@guncelleyenkullanicipkey", SqlDbType.Int)
            param14.Direction = ParameterDirection.Input
            If acente.guncelleyenkullanicipkey = 0 Then
                param14.Value = 0
            Else
                param14.Value = acente.guncelleyenkullanicipkey
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@guncellenmetarih", SqlDbType.DateTime)
            param15.Direction = ParameterDirection.Input
            If acente.guncellenmetarih Is Nothing Or acente.guncellenmetarih = "00:00:00" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = acente.guncellenmetarih
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@acentetippkey", SqlDbType.Int)
            param16.Direction = ParameterDirection.Input
            If acente.acentetippkey = 0 Then
                param16.Value = 0
            Else
                param16.Value = acente.acentetippkey
            End If
            komut.Parameters.Add(param16)


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
                resultset.etkilenen = kaydedilenpkey
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
        sqlstr = "select max(pkey) from acente"
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
    Function Duzenle(ByVal acente As CLASSACENTE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update acente set " + _
        "acentead=@acentead," + _
        "sicilno=@sicilno," + _
        "aktifmi=@aktifmi," + _
        "merkezmi=@merkezmi," + _
        "yetkiadsoyad=@yetkiadsoyad," + _
        "yetkikimlikno=@yetkikimlikno," + _
        "yetkiceptel=@yetkiceptel," + _
        "yetkiemail=@yetkiemail," + _
        "tel=@tel," + _
        "fax=@fax," + _
        "ekleyenkullanicipkey=@ekleyenkullanicipkey," + _
        "eklenmetarih=@eklenmetarih," + _
        "guncelleyenkullanicipkey=@guncelleyenkullanicipkey," + _
        "guncellenmetarih=@guncellenmetarih," + _
        "acentetippkey=@acentetippkey" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acente.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@acentead", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If acente.acentead = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = acente.acentead
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sicilno", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If acente.sicilno = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = acente.sicilno
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If acente.aktifmi = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = acente.aktifmi
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@merkezmi", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If acente.merkezmi = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = acente.merkezmi
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@yetkiadsoyad", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If acente.yetkiadsoyad = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = acente.yetkiadsoyad
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@yetkikimlikno", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If acente.yetkikimlikno = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = acente.yetkikimlikno
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@yetkiceptel", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If acente.yetkiceptel = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = acente.yetkiceptel
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@yetkiemail", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If acente.yetkiemail = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = acente.yetkiemail
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@tel", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If acente.tel = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = acente.tel
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@fax", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If acente.fax = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = acente.fax
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        If acente.ekleyenkullanicipkey = 0 Then
            param12.Value = 0
        Else
            param12.Value = acente.ekleyenkullanicipkey
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@eklenmetarih", SqlDbType.DateTime)
        param13.Direction = ParameterDirection.Input
        If acente.eklenmetarih Is Nothing Or acente.eklenmetarih = "00:00:00" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = acente.eklenmetarih
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@guncelleyenkullanicipkey", SqlDbType.Int)
        param14.Direction = ParameterDirection.Input
        If acente.guncelleyenkullanicipkey = 0 Then
            param14.Value = 0
        Else
            param14.Value = acente.guncelleyenkullanicipkey
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@guncellenmetarih", SqlDbType.DateTime)
        param15.Direction = ParameterDirection.Input
        If acente.guncellenmetarih Is Nothing Or acente.guncellenmetarih = "00:00:00" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = acente.guncellenmetarih
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@acentetippkey", SqlDbType.Int)
        param16.Direction = ParameterDirection.Input
        If acente.acentetippkey = 0 Then
            param16.Value = 0
        Else
            param16.Value = acente.acentetippkey
        End If
        komut.Parameters.Add(param16)

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
    Function bultek(ByVal pkey As String) As CLASSACENTE

        Dim komut As New SqlCommand
        Dim donecekacente As New CLASSACENTE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from acente where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekacente.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("acentead") Is System.DBNull.Value Then
                    donecekacente.acentead = veri.Item("acentead")
                End If

                If Not veri.Item("sicilno") Is System.DBNull.Value Then
                    donecekacente.sicilno = veri.Item("sicilno")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekacente.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                    donecekacente.merkezmi = veri.Item("merkezmi")
                End If

                If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                    donecekacente.yetkiadsoyad = veri.Item("yetkiadsoyad")
                End If

                If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                    donecekacente.yetkikimlikno = veri.Item("yetkikimlikno")
                End If

                If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                    donecekacente.yetkiceptel = veri.Item("yetkiceptel")
                End If

                If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                    donecekacente.yetkiemail = veri.Item("yetkiemail")
                End If

                If Not veri.Item("tel") Is System.DBNull.Value Then
                    donecekacente.tel = veri.Item("tel")
                End If

                If Not veri.Item("fax") Is System.DBNull.Value Then
                    donecekacente.fax = veri.Item("fax")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekacente.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                    donecekacente.guncellenmetarih = veri.Item("guncellenmetarih")
                End If

                If Not veri.Item("acentetippkey") Is System.DBNull.Value Then
                    donecekacente.acentetippkey = veri.Item("acentetippkey")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekacente

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bulsicilnogore(ByVal sicilno As String) As CLASSACENTE

        Dim komut As New SqlCommand
        Dim donecekacente As New CLASSACENTE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from acente where sicilno=@sicilno"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sicilno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sicilno
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekacente.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("acentead") Is System.DBNull.Value Then
                    donecekacente.acentead = veri.Item("acentead")
                End If

                If Not veri.Item("sicilno") Is System.DBNull.Value Then
                    donecekacente.sicilno = veri.Item("sicilno")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekacente.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                    donecekacente.merkezmi = veri.Item("merkezmi")
                End If

                If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                    donecekacente.yetkiadsoyad = veri.Item("yetkiadsoyad")
                End If

                If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                    donecekacente.yetkikimlikno = veri.Item("yetkikimlikno")
                End If

                If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                    donecekacente.yetkiceptel = veri.Item("yetkiceptel")
                End If

                If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                    donecekacente.yetkiemail = veri.Item("yetkiemail")
                End If

                If Not veri.Item("tel") Is System.DBNull.Value Then
                    donecekacente.tel = veri.Item("tel")
                End If

                If Not veri.Item("fax") Is System.DBNull.Value Then
                    donecekacente.fax = veri.Item("fax")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekacente.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                    donecekacente.guncellenmetarih = veri.Item("guncellenmetarih")
                End If

                If Not veri.Item("acentetippkey") Is System.DBNull.Value Then
                    donecekacente.acentetippkey = veri.Item("acentetippkey")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekacente

    End Function



    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
   
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from acente where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSACENTE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekacente As New CLASSACENTE
        Dim acenteler As New List(Of CLASSACENTE)
        komut.Connection = db_baglanti
        sqlstr = "select * from acente"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekacente.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("acentead") Is System.DBNull.Value Then
                    donecekacente.acentead = veri.Item("acentead")
                End If

                If Not veri.Item("sicilno") Is System.DBNull.Value Then
                    donecekacente.sicilno = veri.Item("sicilno")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekacente.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                    donecekacente.merkezmi = veri.Item("merkezmi")
                End If

                If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                    donecekacente.yetkiadsoyad = veri.Item("yetkiadsoyad")
                End If

                If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                    donecekacente.yetkikimlikno = veri.Item("yetkikimlikno")
                End If

                If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                    donecekacente.yetkiceptel = veri.Item("yetkiceptel")
                End If

                If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                    donecekacente.yetkiemail = veri.Item("yetkiemail")
                End If

                If Not veri.Item("tel") Is System.DBNull.Value Then
                    donecekacente.tel = veri.Item("tel")
                End If

                If Not veri.Item("fax") Is System.DBNull.Value Then
                    donecekacente.fax = veri.Item("fax")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekacente.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                    donecekacente.guncellenmetarih = veri.Item("guncellenmetarih")
                End If

                If Not veri.Item("acentetippkey") Is System.DBNull.Value Then
                    donecekacente.acentetippkey = veri.Item("acentetippkey")
                End If

                acenteler.Add(New CLASSACENTE(donecekacente.pkey, _
                donecekacente.acentead, donecekacente.sicilno, donecekacente.aktifmi, donecekacente.merkezmi, _
                donecekacente.yetkiadsoyad, donecekacente.yetkikimlikno, donecekacente.yetkiceptel, donecekacente.yetkiemail, _
                donecekacente.tel, donecekacente.fax, donecekacente.ekleyenkullanicipkey, donecekacente.eklenmetarih, _
                donecekacente.guncelleyenkullanicipkey, donecekacente.guncellenmetarih, donecekacente.acentetippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return acenteler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_merkezolmayanlar() As List(Of CLASSACENTE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekacente As New CLASSACENTE
        Dim acenteler As New List(Of CLASSACENTE)
        komut.Connection = db_baglanti
        sqlstr = "select * from acente where merkezmi=@merkezmi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@merkezmi", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Hayır"
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekacente.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("acentead") Is System.DBNull.Value Then
                    donecekacente.acentead = veri.Item("acentead")
                End If

                If Not veri.Item("sicilno") Is System.DBNull.Value Then
                    donecekacente.sicilno = veri.Item("sicilno")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekacente.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                    donecekacente.merkezmi = veri.Item("merkezmi")
                End If

                If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                    donecekacente.yetkiadsoyad = veri.Item("yetkiadsoyad")
                End If

                If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                    donecekacente.yetkikimlikno = veri.Item("yetkikimlikno")
                End If

                If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                    donecekacente.yetkiceptel = veri.Item("yetkiceptel")
                End If

                If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                    donecekacente.yetkiemail = veri.Item("yetkiemail")
                End If

                If Not veri.Item("tel") Is System.DBNull.Value Then
                    donecekacente.tel = veri.Item("tel")
                End If

                If Not veri.Item("fax") Is System.DBNull.Value Then
                    donecekacente.fax = veri.Item("fax")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekacente.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                    donecekacente.guncellenmetarih = veri.Item("guncellenmetarih")
                End If

                If Not veri.Item("acentetippkey") Is System.DBNull.Value Then
                    donecekacente.acentetippkey = veri.Item("acentetippkey")
                End If

                acenteler.Add(New CLASSACENTE(donecekacente.pkey, _
                donecekacente.acentead, donecekacente.sicilno, donecekacente.aktifmi, donecekacente.merkezmi, _
                donecekacente.yetkiadsoyad, donecekacente.yetkikimlikno, donecekacente.yetkiceptel, donecekacente.yetkiemail, _
                donecekacente.tel, donecekacente.fax, donecekacente.ekleyenkullanicipkey, donecekacente.eklenmetarih, _
                donecekacente.guncelleyenkullanicipkey, donecekacente.guncellenmetarih, donecekacente.acentetippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return acenteler

    End Function


    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSACENTE)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekacente As New CLASSACENTE
        Dim acenteler As New List(Of CLASSACENTE)
        komut.Connection = db_baglanti
        sqlstr = "select * from acente where " + tablecol + " LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekacente.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("acentead") Is System.DBNull.Value Then
                    donecekacente.acentead = veri.Item("acentead")
                End If

                If Not veri.Item("sicilno") Is System.DBNull.Value Then
                    donecekacente.sicilno = veri.Item("sicilno")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekacente.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                    donecekacente.merkezmi = veri.Item("merkezmi")
                End If

                If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                    donecekacente.yetkiadsoyad = veri.Item("yetkiadsoyad")
                End If

                If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                    donecekacente.yetkikimlikno = veri.Item("yetkikimlikno")
                End If

                If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                    donecekacente.yetkiceptel = veri.Item("yetkiceptel")
                End If

                If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                    donecekacente.yetkiemail = veri.Item("yetkiemail")
                End If

                If Not veri.Item("tel") Is System.DBNull.Value Then
                    donecekacente.tel = veri.Item("tel")
                End If

                If Not veri.Item("fax") Is System.DBNull.Value Then
                    donecekacente.fax = veri.Item("fax")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                    donecekacente.eklenmetarih = veri.Item("eklenmetarih")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekacente.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                    donecekacente.guncellenmetarih = veri.Item("guncellenmetarih")
                End If

                If Not veri.Item("acentetippkey") Is System.DBNull.Value Then
                    donecekacente.acentetippkey = veri.Item("acentetippkey")
                End If

                acenteler.Add(New CLASSACENTE(donecekacente.pkey, _
                donecekacente.acentead, donecekacente.sicilno, donecekacente.aktifmi, donecekacente.merkezmi, _
                donecekacente.yetkiadsoyad, donecekacente.yetkikimlikno, donecekacente.yetkiceptel, donecekacente.yetkiemail, _
                donecekacente.tel, donecekacente.fax, donecekacente.ekleyenkullanicipkey, donecekacente.eklenmetarih, _
                donecekacente.guncelleyenkullanicipkey, donecekacente.guncellenmetarih, donecekacente.acentetippkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return acenteler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim tabload As String = "acente"
        Dim tmodul As New CLASSTMODUL
        Dim tmodul_Erisim As New CLASSTMODUL_ERISIM
        Dim yetki As New CLASSYETKI
        Dim yetki_Erisim As New CLASSYETKI_ERISIM
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_Erisim.bul_ilgili(HttpContext.Current.Session("kullanici_rolpkey"), tmodul.pkey)

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9, kol10 As String

        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim ajaxlinkaktif, ajaxlinkpasif As String
        Dim dugmeaktif, dugmepasif As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Seç</th>" + _
        "<th>Anahtar</th>" + _
        "<th>Acenta Adı</th>" + _
        "<th>Sicil No</th>" + _
        "<th>Aktif</th>" + _
        "<th>Çalıştığı Şirketler</th>" + _
        "<th>Merkez mi?</th>" + _
        "<th>Yetkili Bilgileri</th>" + _
        "<th>Ekleme/Güncelleme Bilgileri</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from acente"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "acentead" Then
            sqlstr = "select * from acente where acentead LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "sicilno" Then
            sqlstr = "select * from acente where sicilno LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "AKTİF" Then
            sqlstr = "select * from acente where aktifmi=@aktifmi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@aktifmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Evet"
            komut.Parameters.Add(param1)
        End If


        If HttpContext.Current.Session("ltip") = "PASİF" Then
            sqlstr = "select * from acente where aktifmi=@aktifmi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@aktifmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Hayır"
            komut.Parameters.Add(param1)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, acentead, sicilno, aktifmi As String

        Dim merkezmi, yetkiadsoyad, yetkikimlikno, yetkiceptel As String
        Dim yetkiemail, tel, fax, ekleyenkullanicipkey, eklenmetarih As String
        Dim kullaniciadsoyad As String

        Dim sirketebagliacenteler As New List(Of CLASSSIRKETACENTEBAG)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim acentenincalistigisirketler_str As String = ""

        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim acentetipad, acentetippkey As String
        Dim acentetip As New CLASSACENTETIP
        Dim acentetip_Erisim As New CLASSACENTETIP_ERISIM

        Dim guncelleyenkullanicipkey As String
        Dim guncelleyenkullanici As New CLASSKULLANICI
        Dim guncelleyenkullaniciadsoyad As String
        Dim guncellenmetarih As String

        Dim secinput As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        secinput = "<input type=" + Chr(34) + "checkbox" + Chr(34) + _
                         " id=" + Chr(34) + "A_" + CStr(pkey) + Chr(34) + _
                         " name=" + Chr(34) + "A_" + CStr(pkey) + Chr(34) + _
                         "/>"
                        kol1 = "<tr><td>" + secinput + "</td>"
                    End If


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "acentegirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"

                        '--AKTİF VE PASİF DÜĞMELERİ------
                        ajaxlinkaktif = "aktifyap(" + CStr(pkey) + ")"
                        ajaxlinkpasif = "pasifyap(" + CStr(pkey) + ")"

                        If yetki.updateyetki = "Evet" Then
                            dugmeaktif = "<span id='aktifbutton' onclick='" + ajaxlinkaktif + "' class='button'>Aktif</span>"
                            dugmepasif = "<span id='pasifbutton' onclick='" + ajaxlinkpasif + "' class='button'>Pasif</span>"
                        End If
                        If yetki.updateyetki = "Hayır" Then
                            dugmeaktif = "<span id='aktifbutton' class='button'>Yetkisiz</span>"
                            dugmepasif = "<span id='pasifbutton' class='button'>Yetkisiz</span>"
                        End If

                        kol2 = "<td>" + _
                        "<a class='iframeyenikayit' href=" + link + ">" + "<span class='btn yellow btn-sm'>Düzenle</span>" + "</a>" + _
                        "<br/>" + dugmeaktif + dugmepasif + _
                        "</td>"

                    End If

                    If Not veri.Item("acentetippkey") Is System.DBNull.Value Then
                        acentetippkey = veri.Item("acentetippkey")
                        acentetip = acentetip_Erisim.bultek(acentetippkey)
                    End If

                    If Not veri.Item("acentead") Is System.DBNull.Value Then
                        acentead = veri.Item("acentead")
                        kol3 = "<td>" + acentead + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("sicilno") Is System.DBNull.Value Then
                        sicilno = veri.Item("sicilno")
                        kol4 = "<td>" + sicilno + "<br/>" + _
                        "<strong>" + acentetip.acentetipad + "</stronig>" + _
                        "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        If aktifmi = "Evet" Then
                            kol5 = "<td>" + "<span style='font-weight:bold;color:green;'>" + aktifmi + "</span>" + "</td>"
                        End If
                        If aktifmi = "Hayır" Then
                            kol5 = "<td>" + "<span style='font-weight:bold;color:red;'>" + aktifmi + "</span>" + "</td>"
                        End If

                    Else
                        kol5 = "<td>-</td>"
                    End If

                    acentenincalistigisirketler_str = ""
                    sirketebagliacenteler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(pkey)
                    For Each Item As CLASSSIRKETACENTEBAG In sirketebagliacenteler
                        sirket = sirket_Erisim.bultek(Item.sirketpkey)
                        acentenincalistigisirketler_str = acentenincalistigisirketler_str + sirket.sirketad + "<br/>"
                    Next
                    kol6 = "<td>" + acentenincalistigisirketler_str + "</td>"

                    '------------------------------------------------------
                    If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                        merkezmi = veri.Item("merkezmi")
                        kol7 = "<td>" + merkezmi + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If


                    'YETKİLİ BİLGİLERİ ------------------------------------
                    If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                        yetkiadsoyad = veri.Item("yetkiadsoyad")
                    Else
                        yetkiadsoyad = "-"
                    End If

                    If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                        yetkikimlikno = veri.Item("yetkikimlikno")
                    Else
                        yetkikimlikno = "-"
                    End If

                    If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                        yetkiceptel = veri.Item("yetkiceptel")
                    Else
                        yetkiceptel = "-"
                    End If

                    If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                        yetkiemail = veri.Item("yetkiemail")
                    Else
                        yetkiemail = "-"
                    End If

                    If Not veri.Item("tel") Is System.DBNull.Value Then
                        tel = veri.Item("tel")
                    Else
                        tel = "-"
                    End If

                    If Not veri.Item("fax") Is System.DBNull.Value Then
                        fax = veri.Item("fax")
                    Else
                        fax = "-"
                    End If

                    kol8 = "<td>" + _
                   "<strong>Adı Soyadı:</strong>" + yetkiadsoyad + "<br/>" + _
                   "<strong>Kimlik No:</strong>" + yetkikimlikno + "<br/>" + _
                   "<strong>Cep No:</strong>" + yetkiceptel + "<br/>" + _
                   "<strong>E-Posta Adresi:</strong>" + yetkiemail + "<br/>" + _
                   "<strong>Tel No:</strong>" + tel + "<br/>" + _
                   "<strong>Fax No:</strong>" + fax + _
                   "</td>"


                    'EKLEYEN BİLGİLER --------------------------------------------------
                    If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                        ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                        kullanici = kullanici_erisim.bultek(ekleyenkullanicipkey)
                        kullaniciadsoyad = kullanici.adsoyad
                    End If

                    If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                        eklenmetarih = veri.Item("eklenmetarih")
                    End If

                    If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                        guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                        guncelleyenkullanici = kullanici_erisim.bultek(guncelleyenkullanicipkey)
                        guncelleyenkullaniciadsoyad = guncelleyenkullanici.adsoyad
                    End If

                    If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                        guncellenmetarih = veri.Item("guncellenmetarih")
                    End If

                    kol9 = "<td>" + _
                    "<strong>Ekleyen:</strong>" + kullaniciadsoyad + "<br/>" + _
                    "<strong>Eklenme Tarihi:</strong>" + eklenmetarih + "<br/>" + _
                    "<strong>Güncelleyen:</strong>" + guncelleyenkullaniciadsoyad + "<br/>" + _
                    "<strong>Güncelleme Tarihi:</strong>" + guncellenmetarih + "<br/>" + _
                    "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + _
                    kol4 + kol5 + kol6 + kol7 + kol8 + kol9

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele_sirkettarafiicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim ajaxlinkaktif, ajaxlinkpasif As String
        Dim dugmeaktif, dugmepasif As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Acenta Adı</th>" + _
        "<th>Sicil No</th>" + _
        "<th>Aktif</th>" + _
        "<th>Çalıştığı Şirketler</th>" + _
        "<th>Kullanıcıları</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        sqlstr = "select * from sirketacentebag where sirketpkey=@kullanici_aktifsirket"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@kullanici_aktifsirket", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = HttpContext.Current.Session("kullanici_aktifsirket")
        komut.Parameters.Add(param1)

        girdi = "0"
        Dim pkey, acentead, sicilno, aktifmi As String
        Dim acentepkey, sirketpkey As String


        Dim acentenincalistigisirketler_str As String = ""
        Dim acenteninkullanicilari_str As String = ""


        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        Dim sirketebagliacenteler As New List(Of CLASSSIRKETACENTEBAG)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM

        Dim acenteninkullanicilari As New List(Of CLASSKULLANICI)
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                    End If


                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = CStr(veri.Item("sirketpkey"))
                    End If


                    If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                        acentepkey = CStr(veri.Item("acentepkey"))
                        acente = bultek(acentepkey)
                        kol1 = "<tr><td>" + acente.acentead + "</td>"
                    Else
                        kol1 = "<tr><td>-</td>"
                    End If


                    kol2 = "<td>" + acente.sicilno + "</td>"
                    kol3 = "<td>" + acente.aktifmi + "</td>"

                    '--------------------------------------------
                    acentenincalistigisirketler_str = ""
                    sirketebagliacenteler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(acentepkey)
                    For Each Item As CLASSSIRKETACENTEBAG In sirketebagliacenteler
                        sirket = sirket_Erisim.bultek(Item.sirketpkey)
                        acentenincalistigisirketler_str = acentenincalistigisirketler_str + sirket.sirketad + "<br/>"
                    Next
                    kol4 = "<td>" + acentenincalistigisirketler_str + "</td>"


                    '--------------------------------------------
                    acenteninkullanicilari_str = ""
                    acenteninkullanicilari = kullanici_erisim.doldur_acentepkeyegore(acentepkey)
                    For Each Item As CLASSKULLANICI In acenteninkullanicilari
                        acenteninkullanicilari_str = Item.adsoyad + "<br/>"
                    Next
                    kol5 = "<td>" + acenteninkullanicilari_str + "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listele_sirketadminicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9 As String

        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim ajaxlinkaktif, ajaxlinkpasif As String
        Dim dugmeaktif, dugmepasif As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Acenta Adı</th>" + _
        "<th>Sicil No</th>" + _
        "<th>Aktif</th>" + _
        "<th>Çalıştığı Şirketler</th>" + _
        "<th>Merkez mi?</th>" + _
        "<th>Yetkili Bilgileri</th>" + _
        "<th>Ekleme Bilgileri</th>" + _
        "<th>İşlemler</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi" Then
            sqlstr = "select * from acente where guncelleyenkullanicipkey=@guncelleyenkullanicipkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@guncelleyenkullanicipkey", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kullanici_pkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, acentead, sicilno, aktifmi As String

        Dim merkezmi, yetkiadsoyad, yetkikimlikno, yetkiceptel As String
        Dim yetkiemail, tel, fax, ekleyenkullanicipkey, eklenmetarih As String
        Dim kullaniciadsoyad As String

        Dim sirketebagliacenteler As New List(Of CLASSSIRKETACENTEBAG)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim acentenincalistigisirketler_str As String = ""

        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim guncelleyenkullanicipkey As String
        Dim guncelleyenkullanici As New CLASSKULLANICI
        Dim guncelleyenkullaniciadsoyad As String
        Dim guncellenmetarih As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                    End If

                    If HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi" Then
                        link = "sirketacente.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span  href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("acentead") Is System.DBNull.Value Then
                        acentead = veri.Item("acentead")
                        kol2 = "<td>" + acentead + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("sicilno") Is System.DBNull.Value Then
                        sicilno = veri.Item("sicilno")
                        kol3 = "<td>" + sicilno + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        kol4 = "<td>" + aktifmi + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    acentenincalistigisirketler_str = ""
                    sirketebagliacenteler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(pkey)
                    For Each Item As CLASSSIRKETACENTEBAG In sirketebagliacenteler
                        sirket = sirket_Erisim.bultek(Item.sirketpkey)
                        acentenincalistigisirketler_str = acentenincalistigisirketler_str + sirket.sirketad + "<br/>"
                    Next
                    kol5 = "<td>" + acentenincalistigisirketler_str + "</td>"

                    '------------------------------------------------------
                    If Not veri.Item("merkezmi") Is System.DBNull.Value Then
                        merkezmi = veri.Item("merkezmi")
                        kol6 = "<td>" + merkezmi + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If


                    'YETKİLİ BİLGİLERİ ------------------------------------
                    If Not veri.Item("yetkiadsoyad") Is System.DBNull.Value Then
                        yetkiadsoyad = veri.Item("yetkiadsoyad")
                    Else
                        yetkiadsoyad = "-"
                    End If

                    If Not veri.Item("yetkikimlikno") Is System.DBNull.Value Then
                        yetkikimlikno = veri.Item("yetkikimlikno")
                    Else
                        yetkikimlikno = "-"
                    End If

                    If Not veri.Item("yetkiceptel") Is System.DBNull.Value Then
                        yetkiceptel = veri.Item("yetkiceptel")
                    Else
                        yetkiceptel = "-"
                    End If

                    If Not veri.Item("yetkiemail") Is System.DBNull.Value Then
                        yetkiemail = veri.Item("yetkiemail")
                    Else
                        yetkiemail = "-"
                    End If

                    If Not veri.Item("tel") Is System.DBNull.Value Then
                        tel = veri.Item("tel")
                    Else
                        tel = "-"
                    End If

                    If Not veri.Item("fax") Is System.DBNull.Value Then
                        fax = veri.Item("fax")
                    Else
                        fax = "-"
                    End If

                    kol7 = "<td>" + _
                   "<strong>Adı Soyadı:</strong>" + yetkiadsoyad + "<br/>" + _
                   "<strong>Kimlik No:</strong>" + yetkikimlikno + "<br/>" + _
                   "<strong>Cep No:</strong>" + yetkiceptel + "<br/>" + _
                   "<strong>E-Posta Adresi:</strong>" + yetkiemail + "<br/>" + _
                   "<strong>Tel No:</strong>" + tel + "<br/>" + _
                   "<strong>Fax No:</strong>" + fax + _
                   "</td>"


                    'EKLEYEN BİLGİLER --------------------------------------------------
                    If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                        ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                        kullanici = kullanici_erisim.bultek(ekleyenkullanicipkey)
                        kullaniciadsoyad = kullanici.adsoyad
                    End If

                    If Not veri.Item("eklenmetarih") Is System.DBNull.Value Then
                        eklenmetarih = veri.Item("eklenmetarih")
                    End If

                    If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                        guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                        guncelleyenkullanici = kullanici_erisim.bultek(guncelleyenkullanicipkey)
                        guncelleyenkullaniciadsoyad = guncelleyenkullanici.adsoyad
                    End If

                    If Not veri.Item("guncellenmetarih") Is System.DBNull.Value Then
                        guncellenmetarih = veri.Item("guncellenmetarih")
                    End If


                    kol8 = "<td>" + _
                    "<strong>Ekleyen:</strong>" + kullaniciadsoyad + "<br/>" + _
                    "<strong>Eklenme Tarihi:</strong>" + eklenmetarih + "<br/>" + _
                    "<strong>Güncelleyen:</strong>" + guncelleyenkullaniciadsoyad + "<br/>" + _
                    "<strong>Güncelleme Tarihi:</strong>" + guncellenmetarih + "<br/>" + _
                    "</td>"

                    '--AKTİF VE PASİF DÜĞMELERİ------
                    ajaxlinkaktif = "aktifyapsirkettaraf(" + CStr(pkey) + ")"
                    ajaxlinkpasif = "pasifyapsirkettaraf(" + CStr(pkey) + ")"

                    dugmeaktif = "<span id='aktifbutton' onclick='" + ajaxlinkaktif + "' class='button'>Aktif</span>"
                    dugmepasif = "<span id='aktifbutton' onclick='" + ajaxlinkpasif + "' class='button'>Pasif</span>"

                    If aktifmi = "Evet" Then
                        kol9 = "<td>" + dugmepasif + "</td></tr>"
                    Else
                        kol9 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + _
                    kol4 + kol5 + kol6 + kol7 + kol8 + kol9

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

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

        sqlstr = "select * from acente where " + tablecol + "=@kriter"

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



    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function varmimerkez(ByVal AgencyRegisterCode As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from acente where sicilno=@AgencyRegisterCode and merkezmi=@merkezmi"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@AgencyRegisterCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = AgencyRegisterCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@merkezmi", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Evet"
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


    '----------------------------------TOPLAM ACENTE SAYISI---------------------------------------
    Public Function toplamacentesayisi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from acente"
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


    Public Function belgeolustur(ByVal acentepkeystring As String, ByVal verildigitarih As Date)

        Dim words As String() = acentepkeystring.Split(New Char() {","c})
        Dim acente As New CLASSACENTE
        Dim rapor_erisim As New CLASSRAPOR_ERISIM
        Dim sirketleri As String
        Dim sirketacentebag_Erisim As New CLASSSIRKETACENTEBAG_ERISIM


        Dim yaratilacak_pdfdosyaad As String
        yaratilacak_pdfdosyaad = rapor_erisim.rapordosyaadiolustur("Pdf")


        Dim imageFilePath As String = HttpContext.Current.Server.MapPath(".") + "\belgeresim\acentebelge.png"
        Dim jpg As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imageFilePath)
        jpg.ScaleAbsolute(842, 595)
        jpg.SetAbsolutePosition(0, 0)
        Dim doc As Document = New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)
        doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
        Dim w = PdfWriter.GetInstance(doc, New FileStream(HttpContext.Current.Request.PhysicalApplicationPath + _
                              "\" + yaratilacak_pdfdosyaad, FileMode.Create))
        doc.Open()

        For Each Item As String In words

            sirketleri = sirketacentebag_Erisim.doldur_acenteninbaglioldugusirketler_belgeicin(Item)
            acente = bultek(Item)

            doc.NewPage()

            'RESMİ EKLE---------------------------------------------------
            doc.Add(jpg)

            'YAZIYI EKLE -----------------------------------------------
            Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
            Dim fontsize As Single = 18.0
            Dim p1 As New Paragraph
            Dim p2 As New Paragraph
            Dim p3 As New Paragraph
            Dim p4 As New Paragraph

            Dim cb = w.DirectContent
            Dim col1 As New ColumnText(cb)
            Dim col2 As New ColumnText(cb)
            Dim col3 As New ColumnText(cb)
            Dim col4 As New ColumnText(cb)

            'lowerleftx, lowerlefty, upperleftx, upperlefty
            col1.SetSimpleColumn(450, 120, 1250, 285)
            p1.Add(New Chunk(acente.acentead, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)))
            col1.AddText(p1)
            col1.Go()

            col2.SetSimpleColumn(450, 120, 1250, 260)
            p2.Add(New Chunk(acente.sicilno, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)))
            col2.AddText(p2)
            col2.Go()

            col3.SetSimpleColumn(450, 120, 1250, 235)
            p3.Add(New Chunk(sirketleri, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)))
            col3.AddText(p3)
            col3.Go()

            col4.SetSimpleColumn(180, 45, 1250, 0)
            p4.Add(New Chunk(CStr(verildigitarih), New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)))
            col4.AddText(p4)
            col4.Go()

        Next

        doc.Close()
        HttpContext.Current.Response.Redirect("~/" + yaratilacak_pdfdosyaad)

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listelebelgeicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String
        Dim ajaxlinkaktif, ajaxlinkpasif As String
        Dim dugmeaktif, dugmepasif As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Belge İçin Seç</th>" + _
        "<th>Acenta Adı</th>" + _
        "<th>Sicil No</th>" + _
        "<th>Aktif</th>" + _
        "<th>Çalıştığı Şirketler</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from acente"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "acentead" Then
            sqlstr = "select * from acente where acentead like '%'+@acentead+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@acentead", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("acentead")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, acentead, sicilno, aktifmi As String
        Dim secinput As String

        Dim sirketebagliacenteler As New List(Of CLASSSIRKETACENTEBAG)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim acentenincalistigisirketler_str As String = ""

        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        secinput = "<input type=" + Chr(34) + "checkbox" + Chr(34) + _
                        " id=" + Chr(34) + "A_" + CStr(pkey) + Chr(34) + _
                        " name=" + Chr(34) + "A_" + CStr(pkey) + Chr(34) + _
                        "/>"
                        kol1 = "<tr><td>" + secinput + "</td>"
                    End If

                    If Not veri.Item("acentead") Is System.DBNull.Value Then
                        acentead = veri.Item("acentead")
                        kol2 = "<td>" + acentead + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("sicilno") Is System.DBNull.Value Then
                        sicilno = veri.Item("sicilno")
                        kol3 = "<td>" + sicilno + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        kol4 = "<td>" + aktifmi + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    acentenincalistigisirketler_str = ""
                    sirketebagliacenteler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(pkey)
                    For Each Item As CLASSSIRKETACENTEBAG In sirketebagliacenteler
                        sirket = sirket_Erisim.bultek(Item.sirketpkey)
                        acentenincalistigisirketler_str = acentenincalistigisirketler_str + sirket.sirketad + "<br/>"
                    Next

                    kol5 = "<td>" + acentenincalistigisirketler_str + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function


    Function acentetipvarmi(ByVal acentetippkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from acente where acentetippkey=@acentetippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@acentetippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentetippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Public Function aktifyap(ByVal pkey As String) As CLADBOPRESULT

        'öncelikle bu acentede çalışan tüm kullanıcıları aktif yap
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici_erisim.acentekullanicilarini_aktifpasifyap(pkey, "Evet")

        Dim result As New CLADBOPRESULT
        Dim donecek As String
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        acente = acente_erisim.bultek(pkey)
        acente.aktifmi = "Evet"
        result = acente_erisim.Duzenle(acente)

        Return result

  
    End Function

    Public Function pasifyap(ByVal pkey As String) As CLADBOPRESULT

        'öncelikle bu acentede çalışan tüm kullanıcıları aktif yap
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici_erisim.acentekullanicilarini_aktifpasifyap(pkey, "Hayır")

        Dim result As New CLADBOPRESULT
        Dim donecek As String
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        acente = acente_erisim.bultek(pkey)
        acente.aktifmi = "Hayır"
        result = acente_erisim.Duzenle(acente)

        Return result

    End Function


End Class
