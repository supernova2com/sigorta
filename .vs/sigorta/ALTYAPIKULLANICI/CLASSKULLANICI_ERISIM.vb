Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSKULLANICI_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kullanici As New CLASSKULLANICI
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kullanici As CLASSKULLANICI) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String = "Hayır"


        varmi = ciftkayitkontrol("personelpkey", kullanici.personelpkey)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu personel için zaten daha önce kullanıcı tanımlanmış."
            resultset.etkilenen = 0
        End If

        varmi = ciftkayitkontrol("eposta", kullanici.eposta)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu e-posta adresini kullanan bir kullanıcı daha önce kaydedilmiş."
            resultset.etkilenen = 0
        End If

        varmi = ciftkayitkontrol("kullaniciad", kullanici.kullaniciad)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kullanıcı adı daha önce kullanılmış."
            resultset.etkilenen = 0
        End If


        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti

            sqlstr = "insert into kullanici values (@pkey," + _
            "@sirketpkey,@acentepkey,@kullanicigruppkey,@personelpkey," + _
            "@rolpkey,@resimpkey,@aktifmi,@adsoyad," + _
            "@kullaniciad,@kullanicisifre,@eposta,@emailgonderilsinmi," + _
            "@ekleyenkullanicipkey,@guncelleyenkullanicipkey," + _
            "@eklemetarih,@guncellemetarih)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If kullanici.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = kullanici.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@acentepkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If kullanici.acentepkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = kullanici.acentepkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@kullanicigruppkey", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If kullanici.kullanicigruppkey = 0 Then
                param4.Value = 0
            Else
                param4.Value = kullanici.kullanicigruppkey
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@personelpkey", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If kullanici.personelpkey = 0 Then
                param5.Value = 0
            Else
                param5.Value = kullanici.personelpkey
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@rolpkey", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If kullanici.rolpkey = 0 Then
                param6.Value = 0
            Else
                param6.Value = kullanici.rolpkey
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@resimpkey", SqlDbType.Int)
            param7.Direction = ParameterDirection.Input
            If kullanici.resimpkey = 0 Then
                param7.Value = 0
            Else
                param7.Value = kullanici.resimpkey
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If kullanici.aktifmi = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = kullanici.aktifmi
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@adsoyad", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If kullanici.adsoyad = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = kullanici.adsoyad
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If kullanici.kullaniciad = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = kullanici.kullaniciad
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@kullanicisifre", SqlDbType.VarChar)
            param11.Direction = ParameterDirection.Input
            If kullanici.kullanicisifre = "" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = kullanici.kullanicisifre
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@eposta", SqlDbType.VarChar)
            param12.Direction = ParameterDirection.Input
            If kullanici.eposta = "" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = kullanici.eposta
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@emailgonderilsinmi", SqlDbType.VarChar)
            param13.Direction = ParameterDirection.Input
            If kullanici.emailgonderilsinmi = "" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = kullanici.emailgonderilsinmi
            End If
            komut.Parameters.Add(param13)


            Dim param14 As New SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
            param14.Direction = ParameterDirection.Input
            If kullanici.ekleyenkullanicipkey = 0 Then
                param14.Value = 0
            Else
                param14.Value = kullanici.ekleyenkullanicipkey
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@guncelleyenkullanicipkey", SqlDbType.Int)
            param15.Direction = ParameterDirection.Input
            If kullanici.guncelleyenkullanicipkey = 0 Then
                param15.Value = 0
            Else
                param15.Value = kullanici.guncelleyenkullanicipkey
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@eklemetarih", SqlDbType.DateTime)
            param16.Direction = ParameterDirection.Input
            If kullanici.eklemetarih Is Nothing Or kullanici.eklemetarih = "00:00:00" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = kullanici.eklemetarih
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
            param17.Direction = ParameterDirection.Input
            If kullanici.guncellemetarih Is Nothing Or kullanici.guncellemetarih = "00:00:00" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = kullanici.guncellemetarih
            End If
            komut.Parameters.Add(param17)

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
        sqlstr = "select max(pkey) from kullanici"
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
    Function Duzenle(ByVal kullanici As CLASSKULLANICI) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kullanici set " + _
        "sirketpkey=@sirketpkey," + _
        "acentepkey=@acentepkey," + _
        "kullanicigruppkey=@kullanicigruppkey," + _
        "personelpkey=@personelpkey," + _
        "rolpkey=@rolpkey," + _
        "resimpkey=@resimpkey," + _
        "aktifmi=@aktifmi," + _
        "adsoyad=@adsoyad," + _
        "kullaniciad=@kullaniciad," + _
        "kullanicisifre=@kullanicisifre," + _
        "eposta=@eposta," + _
        "emailgonderilsinmi=@emailgonderilsinmi," + _
        "ekleyenkullanicipkey=@ekleyenkullanicipkey," + _
        "guncelleyenkullanicipkey=@guncelleyenkullanicipkey," + _
        "eklemetarih=@eklemetarih," + _
        "guncellemetarih=@guncellemetarih" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanici.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If kullanici.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = kullanici.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If kullanici.acentepkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = kullanici.acentepkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kullanicigruppkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If kullanici.kullanicigruppkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = kullanici.kullanicigruppkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@personelpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If kullanici.personelpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = kullanici.personelpkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@rolpkey", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If kullanici.rolpkey = 0 Then
            param6.Value = 0
        Else
            param6.Value = kullanici.rolpkey
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@resimpkey", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If kullanici.resimpkey = 0 Then
            param7.Value = 0
        Else
            param7.Value = kullanici.resimpkey
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If kullanici.aktifmi = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = kullanici.aktifmi
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@adsoyad", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If kullanici.adsoyad = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = kullanici.adsoyad
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If kullanici.kullaniciad = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = kullanici.kullaniciad
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@kullanicisifre", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If kullanici.kullanicisifre = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = kullanici.kullanicisifre
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If kullanici.eposta = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = kullanici.eposta
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@emailgonderilsinmi", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If kullanici.emailgonderilsinmi = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = kullanici.emailgonderilsinmi
        End If
        komut.Parameters.Add(param13)


        Dim param14 As New SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
        param14.Direction = ParameterDirection.Input
        If kullanici.ekleyenkullanicipkey = 0 Then
            param14.Value = 0
        Else
            param14.Value = kullanici.ekleyenkullanicipkey
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@guncelleyenkullanicipkey", SqlDbType.Int)
        param15.Direction = ParameterDirection.Input
        If kullanici.guncelleyenkullanicipkey = 0 Then
            param15.Value = 0
        Else
            param15.Value = kullanici.guncelleyenkullanicipkey
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@eklemetarih", SqlDbType.DateTime)
        param16.Direction = ParameterDirection.Input
        If kullanici.eklemetarih Is Nothing Or kullanici.eklemetarih = "00:00:00" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = kullanici.eklemetarih
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
        param17.Direction = ParameterDirection.Input
        If kullanici.guncellemetarih Is Nothing Or kullanici.guncellemetarih = "00:00:00" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = kullanici.guncellemetarih
        End If
        komut.Parameters.Add(param17)
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
    Function bultek(ByVal pkey As String) As CLASSKULLANICI

        Dim komut As New SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkullanici

    End Function


    '---------------------------------bultek eposta adresine göre---------------------------------
    Function bultek_epostaadresinegore(ByVal eposta As String) As CLASSKULLANICI

        Dim komut As New SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where eposta=@eposta"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = eposta
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkullanici

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim varmi1, varmi2 As String

        Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

        varmi1 = dinamikkullanicibag_erisim.kullanicivarmi(pkey)
        varmi2 = manuelraporkullanici_erisim.kullanicivarmi(pkey)


        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kullanıcı dinamik raporlarda tanımlanmış. Bu sebepten bu kullanıcıyı silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kullanıcı manuel raporlarda tanımlanmış. Bu sebepten bu kullanıcıyı silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kullanici where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSKULLANICI)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanici As New CLASSKULLANICI
        Dim kullaniciler As New List(Of CLASSKULLANICI)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanici"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                kullaniciler.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, _
                donecekkullanici.eklemetarih, donecekkullanici.guncellemetarih))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullaniciler

    End Function

    'doldurbenimdisimda ------------------------
    Public Function doldurbenimdisimda() As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        Dim loginolankullanicipkey As String = Current.Session("kullanici_pkey")
        sqlstr = "select * from kullanici where pkey<>@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = loginolankullanicipkey


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If


                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, _
                donecekkullanici.eklemetarih, donecekkullanici.guncellemetarih))

            End While

        End Using

        db_baglanti.Close()
        Return donecekkullanicilar

    End Function


    'doldur şirkete göre ------------------------
    Public Function doldur_sirketpkeyegore(ByVal sirketpkey As String) As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@sirketpkey", SqlDbType.Int)
        komut.Parameters("@sirketpkey").Value = sirketpkey


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While

        End Using


        db_baglanti.Close()

        Return donecekkullanicilar

    End Function



    'doldur şirkete göre ------------------------
    Public Function doldur_sirketpkeyegore_faturagonderilecekler(ByVal sirketpkey As String) As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where sirketpkey=@sirketpkey and " + _
        "faturagonderilsinmi=@faturagonderilsinmi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@sirketpkey", SqlDbType.Int)
        komut.Parameters("@sirketpkey").Value = sirketpkey

        komut.Parameters.Add("@faturagonderilsinmi", SqlDbType.VarChar)
        komut.Parameters("@faturagonderilsinmi").Value = "Evet"


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While

        End Using


        db_baglanti.Close()

        Return donecekkullanicilar


    End Function



    'doldur acenteye göre ------------------------
    Public Function doldur_acentepkeyegore(ByVal acentepkey As String) As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where acentepkey=@acentepkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@acentepkey", SqlDbType.Int)
        komut.Parameters("@acentepkey").Value = acentepkey


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While

        End Using


        db_baglanti.Close()

        Return donecekkullanicilar


    End Function


    'doldur kullanıcı grubuna göre ------------------------
    Public Function doldur_kullanicigruppkeyegore(ByVal kullanicigruppkey As String) As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where kullanicigruppkey=@kullanicigruppkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@kullanicigruppkey", SqlDbType.Int)
        komut.Parameters("@kullanicigruppkey").Value = kullanicigruppkey

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While
        End Using


        db_baglanti.Close()

        Return donecekkullanicilar


    End Function



    'doldur kullanıcı grubuna göre benim disimda ------------------------
    Public Function doldur_kullanicigruppkeyegore_benimdisimda(ByVal kullanicigruppkey As String) As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where kullanicigruppkey=@kullanicigruppkey and " + _
        "pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@kullanicigruppkey", SqlDbType.Int)
        komut.Parameters("@kullanicigruppkey").Value = kullanicigruppkey

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = HttpContext.Current.Session("kullanici_pkey")


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While
        End Using


        db_baglanti.Close()

        Return donecekkullanicilar


    End Function



    'doldur kullanıcı grubuna göre benim disimda fakat mesajlasma için------------------------
    'mesaj gönderebileceklerini doldur sadece kendi sirket
    Public Function doldur_kullanicigruppkeyegore_benimdisimda_mesajicin(ByVal kullanicigruppkey As String) As List(Of CLASSKULLANICI)


        Dim sadecesirketicimsg As String
        Dim sadecesirketicidosyagonderme As String

        Dim loginkullanici As New CLASSKULLANICI
        loginkullanici = bultek(HttpContext.Current.Session("kullanici_pkey"))
        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        kullanicirol = kullanicirol_erisim.bultek(loginkullanici.rolpkey)
        sadecesirketicimsg = kullanicirol.sadecesirketicimesajlasma

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where kullanicigruppkey=@kullanicigruppkey and " + _
        "pkey<>@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@kullanicigruppkey", SqlDbType.Int)
        komut.Parameters("@kullanicigruppkey").Value = kullanicigruppkey

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = HttpContext.Current.Session("kullanici_pkey")


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If


                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If


                If sadecesirketicimsg = "Hayır" Then
                    donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                    donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                    donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                    donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                    donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                    donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                    donecekkullanici.guncellemetarih))
                End If

                If sadecesirketicimsg = "Evet" Then
                    'sadece kendi sirketindeki kullanıcıları doldur..
                    If donecekkullanici.sirketpkey = HttpContext.Current.Session("kullanici_aktifsirket") Then
                        donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                        donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                        donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                        donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                        donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                        donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                        donecekkullanici.guncellemetarih))
                    End If
                End If

            End While
        End Using

        db_baglanti.Close()
        Return donecekkullanicilar

    End Function



    'doldur kullanıcı grubuna göre benim disimda fakat dosya gönderme için------------------------
    'mesaj gönderebileceklerini doldur sadece kendi sirket
    Public Function doldur_benimdisimda_dosyaicin() As List(Of CLASSKULLANICI)


        Dim sadecesirketicidosyagonderme As String

        Dim loginkullanici As New CLASSKULLANICI
        loginkullanici = bultek(HttpContext.Current.Session("kullanici_pkey"))
        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM


        kullanicirol = kullanicirol_erisim.bultek(loginkullanici.rolpkey)
        sadecesirketicidosyagonderme = kullanicirol.sadecesirketicidosyagonderimi

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where pkey<>@pkey order by adsoyad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@pkey", SqlDbType.Int)
        komut.Parameters("@pkey").Value = HttpContext.Current.Session("kullanici_pkey")


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If


                If sadecesirketicidosyagonderme = "Hayır" Then
                    donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                    donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                    donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                    donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                    donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                    donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                    donecekkullanici.guncellemetarih))
                End If

                If sadecesirketicidosyagonderme = "Evet" Then
                    'sadece kendi sirketindeki kullanıcıları doldur..
                    If donecekkullanici.sirketpkey = HttpContext.Current.Session("kullanici_aktifsirket") Then
                        donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                        donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                        donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                        donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                        donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                        donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                        donecekkullanici.guncellemetarih))
                    End If
                End If

            End While
        End Using

        db_baglanti.Close()
        Return donecekkullanicilar

    End Function


    'doldur kullanıcı grubuna göre ------------------------
    Public Function doldur_kullanicirolpkeyegore(ByVal rolpkey As String) As List(Of CLASSKULLANICI)

        Dim sqlstr As String

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecekkullanici As New CLASSKULLANICI
        Dim donecekkullanicilar As New List(Of CLASSKULLANICI)

        sqlstr = "select * from kullanici where rolpkey=@rolpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@rolpkey", SqlDbType.Int)
        komut.Parameters("@rolpkey").Value = rolpkey

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    'donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                donecekkullanicilar.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While
        End Using


        db_baglanti.Close()

        Return donecekkullanicilar


    End Function

    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSKULLANICI)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanici As New CLASSKULLANICI
        Dim kullaniciler As New List(Of CLASSKULLANICI)
        komut.Connection = db_baglanti


        If HttpContext.Current.Session("ltip") = "adsoyad" Then

            sqlstr = "select * from kullanici where " + tablecol + " LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = kriter
            komut.Parameters.Add(param1)

        End If

        If HttpContext.Current.Session("ltip") = "sirkettarafindaadsoyadli" Then

            sqlstr = "select * from kullanici where " + tablecol + " LIKE '%'+@kriter+'%'" + _
            " and ekleyenkullanicipkey=@ekleyenkullanicipkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = kriter
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("kullanici_pkey")
            komut.Parameters.Add(param2)

        End If


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanici.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekkullanici.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekkullanici.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                    donecekkullanici.kullanicigruppkey = veri.Item("kullanicigruppkey")
                End If

                If Not veri.Item("personelpkey") Is System.DBNull.Value Then
                    donecekkullanici.personelpkey = veri.Item("personelpkey")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekkullanici.rolpkey = veri.Item("rolpkey")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    donecekkullanici.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekkullanici.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekkullanici.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekkullanici.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekkullanici.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekkullanici.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                    donecekkullanici.emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                End If

                If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                End If

                If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                    donecekkullanici.guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                End If

                If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                    donecekkullanici.eklemetarih = veri.Item("eklemetarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekkullanici.guncellemetarih = veri.Item("guncellemetarih")
                End If

                kullaniciler.Add(New CLASSKULLANICI(donecekkullanici.pkey, _
                donecekkullanici.sirketpkey, donecekkullanici.acentepkey, donecekkullanici.kullanicigruppkey, donecekkullanici.personelpkey, _
                donecekkullanici.rolpkey, donecekkullanici.resimpkey, donecekkullanici.aktifmi, donecekkullanici.adsoyad, _
                donecekkullanici.kullaniciad, donecekkullanici.kullanicisifre, donecekkullanici.eposta, _
                donecekkullanici.emailgonderilsinmi, donecekkullanici.ekleyenkullanicipkey, _
                donecekkullanici.guncelleyenkullanicipkey, donecekkullanici.eklemetarih, _
                donecekkullanici.guncellemetarih))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullaniciler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14 As String
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
        "<th>Çalıştığı Şirket</th>" + _
        "<th>Çalıştığı Acente</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Kullanıcı Grubu</th>" + _
        "<th>Kullanıcı Rolü</th>" + _
        "<th>Aktif mi?</th>" + _
        "<th>Kullanıcı Adı</th>" + _
        "<th>Kullanıcı Şifresi</th>" + _
        "<th>E-Posta Adresi</th>" + _
        "<th>Mesajlar Ayrıca E-Mail Olarak Gönderilsin mi?</th>" + _
        "<th>Kayıt Bilgileri</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        'sirket tarafında adlı soyadlı arama yaparsa
        If HttpContext.Current.Session("ltip") = "sirkettarafindaadsoyadli" Then
            sqlstr = "select * from kullanici where adsoyad LIKE '%'+@kriter+'%'" + _
            " and ekleyenkullanicipkey=@ekleyenkullanicipkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlClient.SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("kullanici_pkey")
            komut.Parameters.Add(param2)
        End If

        'sadece şirket tarafındaki admin kullanısının yarattığı kullanıcıları göster
        If HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi" Then
            sqlstr = "select * from kullanici where ekleyenkullanicipkey=@ekleyenkullanicipkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@ekleyenkullanicipkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kullanici_pkey")
            komut.Parameters.Add(param1)
        End If


        'admin tarafında tümü
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from kullanici"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        'admin tarafında adlı soyadlı arama yaparsa
        If HttpContext.Current.Session("ltip") = "adsoyad" Then
            sqlstr = "select * from kullanici where adsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If


 

        girdi = "0"
        Dim link As String
        Dim pkey, kullanicigruppkey As String
        Dim rolpkey, resimpkey, aktifmi, adsoyad As String
        Dim emailgonderilsinmi As String

        Dim kullanicigrup As New CLASSKULLANICIGRUP
        Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        Dim resim As New CLASSTEKRESIM
        Dim resim_erisim As New CLASSTEKRESIM_ERISIM

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET

        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acente As New CLASSACENTE

        Dim sirketpkey, acentepkey, eposta As String
        Dim kullaniciad, kullanicisifre As String
        Dim faturagonderilsinmi As String

        Dim kayitbilgistr As String
        Dim ekleyenkullanicipkey, guncelleyenkullanicipkey, eklemetarih, guncellemetarih As String
        Dim ekleyenkullanici As New CLASSKULLANICI
        Dim guncelleyenkullanici As New CLASSKULLANICI

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        'admin tarafı için
                        If HttpContext.Current.Session("ltip") = "TÜMÜ" Or _
                        HttpContext.Current.Session("ltip") = "adsoyad" Then
                            link = "kullanici.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                            kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                        End If

                        'sirket tarafi için
                        If HttpContext.Current.Session("ltip") = "sirkettarafindaadsoyadli" Or HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi" Then
                            link = "sirketkullanici.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                            kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                        End If
                    End If

                    If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                        resimpkey = veri.Item("resimpkey")
                        kol2 = "<td>" + sirket_erisim.logoolustur(resimpkey) + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If


                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol3 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                        acentepkey = veri.Item("acentepkey")
                        acente = acente_erisim.bultek(acentepkey)
                        kol4 = "<td>" + acente.acentead + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If


                    If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                        adsoyad = veri.Item("adsoyad")
                        kol5 = "<td>" + adsoyad + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                        kullanicigruppkey = veri.Item("kullanicigruppkey")
                        kullanicigrup = kullanicigrup_erisim.bultek(kullanicigruppkey)
                        kol6 = "<td>" + kullanicigrup.grupad + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                        rolpkey = veri.Item("rolpkey")
                        kullanicirol = kullanicirol_erisim.bultek(rolpkey)
                        kol7 = "<td>" + kullanicirol.rolad + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If


                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        kol8 = "<td>" + aktifmi + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                        kullaniciad = veri.Item("kullaniciad")
                        kol9 = "<td>" + kullaniciad + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                        kullanicisifre = veri.Item("kullanicisifre")
                        kol10 = "<td>" + kullanicisifre + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If

                    If Not veri.Item("eposta") Is System.DBNull.Value Then
                        eposta = veri.Item("eposta")
                        kol11 = "<td>" + eposta + "</td>"
                    Else
                        kol11 = "<td>-</td>"
                    End If

                    If Not veri.Item("emailgonderilsinmi") Is System.DBNull.Value Then
                        emailgonderilsinmi = veri.Item("emailgonderilsinmi")
                        kol12 = "<td>" + emailgonderilsinmi + "</td>"
                    Else
                        kol12 = "<td>-</td>"
                    End If

                    'KAYIT BİLGİLERİ
                    If Not veri.Item("ekleyenkullanicipkey") Is System.DBNull.Value Then
                        ekleyenkullanicipkey = veri.Item("ekleyenkullanicipkey")
                        ekleyenkullanici = bultek(ekleyenkullanicipkey)
                    End If

                    If Not veri.Item("guncelleyenkullanicipkey") Is System.DBNull.Value Then
                        guncelleyenkullanicipkey = veri.Item("guncelleyenkullanicipkey")
                        guncelleyenkullanici = bultek(guncelleyenkullanicipkey)
                    End If

                    If Not veri.Item("eklemetarih") Is System.DBNull.Value Then
                        eklemetarih = veri.Item("eklemetarih")
                    Else
                        eklemetarih = ""
                    End If

                    If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                        guncellemetarih = veri.Item("guncellemetarih")
                    Else
                        guncellemetarih = ""
                    End If

                    kayitbilgistr = "Ekleyen:" + ekleyenkullanici.adsoyad + "<br/>" + _
                    "Ekleme Tarihi:" + eklemetarih + "<br/>" + _
                    "Güncelleyen:" + guncelleyenkullanici.adsoyad + "<br/>" + _
                    "Güncelleme Tarihi:" + guncellemetarih


                    kol13 = "<td>" + kayitbilgistr + "</td></tr>"

                    satir = satir + kol1 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + _
                    kol12 + kol13

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

        sqlstr = "select * from kullanici where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function kullanicigrupvarmi(ByVal kullanicigruppkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where kullanicigruppkey=@kullanicigruppkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kullanicigruppkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicigruppkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function

    Function personelvarmi(ByVal personelpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where personelpkey=@personelpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@personelpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = personelpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function resimvarmi(ByVal resimpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where resimpkey=@resimpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@resimpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = resimpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using


        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function rolvarmi(ByVal rolpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where rolpkey=@rolpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@rolpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = rolpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using


        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function logincontrol(ByVal kullaniciad As String, _
    ByVal kullanicisifre As String) As CLADBOPRESULT


        Dim sifre_erisim As New CLASSSIFRELEME_ERISIM
        Dim girdi As String = "0"

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET

        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acente As New CLASSACENTE

        Dim result As New CLADBOPRESULT
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanici where kullaniciad=@kullaniciad " + _
        "and kullanicisifre=@kullanicisifre"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullaniciad
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicisifre", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = sifre_erisim.getMD5Hash(kullanicisifre)
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                girdi = "1"

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    kullanici.pkey = veri.Item("pkey")
                    kullanici = kullanici_erisim.bultek(kullanici.pkey)

                    If kullanici.aktifmi = "Evet" Then
                        result.durum = "Evet"
                        result.hatastr = ""
                        result.etkilenen = kullanici.pkey
                    End If


                    sirket = sirket_erisim.bultek(kullanici.sirketpkey)
                    If sirket.aktifmi = "Hayır" Then
                        result.durum = "Hayır"
                        result.hatastr = "Hesabınızın bağlı olduğu şirket aktif olmadığından " + _
                        "hesabınıza girişiniz engellendi. Şirket:" + sirket.sirketad
                        result.etkilenen = 0
                    End If

                    acente = acente_erisim.bultek(kullanici.acentepkey)
                    If acente.aktifmi = "Hayır" Then
                        result.durum = "Hayır"
                        result.hatastr = "Hesabınızın bağlı olduğu acente aktif olmadığından " + _
                        "hesabınıza girişiniz engellendi. Acente:" + acente.acentead
                        result.etkilenen = 0
                    End If


                    If kullanici.aktifmi = "Hayır" Then
                        result.durum = "Hayır"
                        result.hatastr = "Hesabınız aktif değil. Lütfen KKSBM ile temasa geçiniz."
                        result.etkilenen = 0
                    End If

                    kullanici = kullanici_erisim.bultek(kullanici.pkey)
                End If

            End While
        End Using


        If girdi = "0" Then
            result.durum = "Hayır"
            result.hatastr = "Kullanıcı adınız yada şifreniz hatalı."
            result.etkilenen = 0
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return result

    End Function

    'yetkiler
    Function busayfayigormeyeyetkilimi(ByVal sayfaad As String, ByVal kullanicirolpkey As String)

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        If sayfaad = "pano" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.panoyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        '----------------İŞLEMLER--------------------------------------------------
        If sayfaad = "hasariptal" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.islemyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "hasariptalyap" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.islemyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "hasariptalgoster" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.islemyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        If sayfaad = "hasariptalliste" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.iptallistesiyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------ARAMA--------------------------------------------------
        If sayfaad = "policeara" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.aramayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "adminpoliceara" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.adminpolicearayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "adminhasarara" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.adminhasararayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "policeara_parakambiyo" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.parakambiyoaramayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------TANIMLAMALAR--------------------------------------------------
        If sayfaad = "sirket" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "acente" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.acentetanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "personel" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.personeltanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "aractarife" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.aractarifetanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "ulke" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.ulketanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "zeylcode" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.zeylcodetanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "urunkod" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.urunkodtanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "currencycode" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.currencycodetanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "hasardurumkod" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.hasardurumkodtanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "policetip" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.policetiptanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "acentetip" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.acentetiptanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "kimliktur" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.kimlikturtanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------FİYATLAR------------------------------------------
        If sayfaad = "bazfiyat" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.fiyatyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "kur" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.kuryetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "bazfiyatgirissure" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.bazfiyatgirissureyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        '----------------BELGE YÖNETİMİ------------------------------------------
        If sayfaad = "birlikpersonelgirispopup" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.birlikpersoneltanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "birlikpersoneltanim" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.birlikpersoneltanimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "acentebelge" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.belgeyonetimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "teknikpersonelbelge" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.tpbelgeyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "katilimbelge" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.bekbelgeyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        '----------------WEB SERVİS AYAR---------------------------------------
        If sayfaad = "servisayar" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.servisayaryetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        '----------------RESİM--------------------------------------------
        If sayfaad = "resim" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.resimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "galeri" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.resimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------KULLANICI--------------------------------------------
        If sayfaad = "kullanici" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.kullaniciyonetimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "kullanicigrup" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.kullaniciyonetimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "kullanicirol" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.kullaniciyonetimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "kullanicisifreyonetim" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.kullaniciyonetimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirketkullanici" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafkullaniciyaratyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirkettarafozelrapor" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafraporerisim = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

    
        '----------------RAPOR---------------------------------------------
        If sayfaad = "dinamikrapor" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.raporyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "dinamikraporpopup" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.raporyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "dinamikraporgoster" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.tanimlanmisdinamikraporyetki = "Hayır" And kullanicirol.dinamikraporyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "ozelrapor" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.raporyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "tanimlanmisrapor" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.tanimlanmisdinamikraporyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

  

        '---------------FATURALANDIRMA ----------------------------------------
        If sayfaad = "fatura" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.faturalandirmayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "kullanicifatura" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.faturalandirmayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "odemepopup" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.faturalandirmayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "faturarapor" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.faturalandirmayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------MESAJ--------------------------------------------
        If sayfaad = "mesaj" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.mesajyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------DOSYA--------------------------------------------
        If sayfaad = "dosya" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.dosyayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------SİSTEM LOGLAR--------------------------------------------
        If sayfaad = "log" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.logyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "logservis" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.logyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "servislogdetay" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.logyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        '----------------AYAR--------------------------------------------
        If sayfaad = "ayar" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.ayaryetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "tablobag" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.ayaryetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "dropdownlist" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.ayaryetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "tmodul" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.ayaryetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------PROFİL SAYFASI--------------------------------------------
        If sayfaad = "profile" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.profilyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If



        '----------------ŞİRKET TARAFINDA POLİÇE HASAR ARAMA SAYFASI--------------------------------------------
        If sayfaad = "policearasirket" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafaramayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "policedetaysirket" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafaramayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "hasardetaysirket" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafaramayetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirketkullaniciliste" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafkullanicilisteyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirketacenteliste" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafraporerisim = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirkettakvim" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafraporerisim = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirketacente" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirkettarafacenteyaratyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirketbazfiyat" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirketbazfiyatgirisyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If

        If sayfaad = "sirketbazfiyatgirispopup" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.sirketbazfiyatgirisyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If


        '----------------YARDIM--------------------------------------------
        If sayfaad = "yardim" Then
            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            If kullanicirol.yardimyetki = "Hayır" Then
                HttpContext.Current.Response.Redirect("yetkisiz.aspx")
            End If
        End If




    End Function


    Function sifremigonder(ByVal eposta As String, ByVal kullaniciad As String) As CLADBOPRESULT

        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim acente_erisim As New CLASSACENTE_ERISIM

        Dim kullanici As New CLASSKULLANICI
        Dim result As New CLADBOPRESULT

        'öncelikle bu e-posta adresi varmi. 
        Dim varmi As String = "Hayır"
        varmi = varmi_epostakullaniciadsahip(eposta, kullaniciad)

        If varmi = "Hayır" Then
            result.durum = "Gönderilmedi"
            result.etkilenen = 0
            result.hatastr = "Girdiğiniz e-posta adresi ve kullanıcı adı eşleşmiyor."
        End If

        If varmi = "Evet" Then

            Dim yenisifre As String
            kullanici = bultek_epostaadresinegore(eposta)
            yenisifre = sifreleme_erisim.GetRandomPasswordUsingGUID(8)
            kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(yenisifre)
            kullanici_erisim.Duzenle(kullanici)


            Dim body As String = ""
            Dim d As DateTime
            Dim email As New CLASSEMAIL
            Dim email_erisim As New CLASSEMAIL_ERISIM
            Dim emailayar As New CLASSEMAILAYAR
            Dim emailayar_Erisim As New CLASSEMAILAYAR_ERISIM
            emailayar = emailayar_Erisim.bul(1)

            body = "Kuzey Kıbrıs Sigorta Bilgi Merkezi<br/>" + _
            "<br/>" + _
            "Değerli Kullanıcımız" + "<br/>" + _
            "Merhaba " + kullanici.adsoyad + "<br/>" + _
            "Şifrenizi unuttunuz ve hatırlatmak için bizden " + CStr(d.Now) + " tarihinde talepte bulundunuz." + "<br/>" + _
            "Şifreniz güvenliğiniz nedeni ile değiştirilmiştir" + "<br/>" + _
            "Kullanıcı Adınız:" + kullanici.kullaniciad + "" + "<br/>" + _
            "Yeni Şifreniz:" + yenisifre + " dir." + "<br/>" + _
            "Şirket:" + sirket_erisim.bultek(kullanici.sirketpkey).sirketad + "<br/>" + _
            "Acente:" + acente_erisim.bultek(kullanici.acentepkey).acentead + "<br/>" + _
            "İyi çalışmalar diler saygılar sunarız." + "<br/>" + _
            "Kuzey Kıbrıs Sigorta Bilgi Merkezi" + "<br/>"

            email.kimden = emailayar.username
            email.kime = eposta
            email.subject = d.Now.ToString() + "KUZEY KIBRIS SİGORTA BİLGİ MERKEZİ ŞİFRE HATIRLATMA TALEBİ "
            email.body = body

            result = email_erisim.gonder(email)

        End If

        Return result

    End Function


    Public Function sirketinkullanicisqlolustur(ByVal sirketpkey As String) As String

        Dim doneceksql As String = ""
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sirketinkullanicilari As New List(Of CLASSKULLANICI)
        sirketinkullanicilari = kullanici_erisim.doldur_sirketpkeyegore(sirketpkey)
        For Each kullaniciitem As CLASSKULLANICI In sirketinkullanicilari
            doneceksql = doneceksql + " kullanicipkey=" + CStr(kullaniciitem.pkey) + " or "
        Next
        If Len(doneceksql) > 0 Then
            doneceksql = " and (" + Mid(doneceksql, 1, Len(doneceksql) - 4) + ")"
        End If

        Return doneceksql

    End Function

    Public Function acenteninkullanicisqlolustur(ByVal acentepkey As String) As String

        Dim doneceksql As String = ""
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim acenteninkullanicilari As New List(Of CLASSKULLANICI)
        acenteninkullanicilari = kullanici_erisim.doldur_acentepkeyegore(acentepkey)
        For Each kullaniciitem As CLASSKULLANICI In acenteninkullanicilari
            doneceksql = doneceksql + " or kullanicipkey=" + CStr(kullaniciitem.pkey) + " or "
        Next
        If Len(doneceksql) > 0 Then
            doneceksql = " and (" + Mid(doneceksql, 1, Len(doneceksql) - 4) + ")"
        End If

        Return doneceksql

    End Function



    '-----------------------------------Düzenle------------------------------------
    Function acentekullanicilarini_aktifpasifyap(ByVal p_acentepkey As String, _
    ByVal p_neyap As String) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kullanici set " + _
        "aktifmi=@neyap" + _
        " where acentepkey=@acentepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@neyap", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = p_neyap
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If p_acentepkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = p_acentepkey
        End If
        komut.Parameters.Add(param2)

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


    Function sifresinikackereyanlisgirmis(ByVal tarih As DateTime, _
    ByVal kullaniciad As String) As Integer

        Dim pkey As Integer

        Dim result As New CLADBOPRESULT
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from loggenel where Convert(DATE,tarih)=@tarih and " + _
        "dkullaniciad=@dkullaniciad and islem=@islem and yanlissifrereset=@yanlissifrereset"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = tarih
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@dkullaniciad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullaniciad
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@islem", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = "Hatalı Giriş"
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yanlissifrereset", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = "Hayır"
        komut.Parameters.Add(param4)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            pkey = 1
        Else
            pkey = maxkayit1 + 1
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return pkey

    End Function



    '---------------------------------listele--------------------------------------
    Public Function listelekullanici_sirketbazindafatura() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14 As String
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
        "<th>Şirket</th>" + _
        "<th>E-Posta Adresi</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        'şirket tarafındaki ekranlardaki gösterim

        sqlstr = "select * from sirket where tip=@tip" + _
        " order by sirketkod"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@tip", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "ŞİRKET"
        komut.Parameters.Add(param1)


        girdi = "0"
        Dim link As String
        Dim pkey, kullanicigruppkey As String
        Dim rolpkey, resimpkey, aktifmi, adsoyad As String
        Dim sirketad As String

        Dim sirketpkey, acentepkey As String
        Dim epostaadresleri As String
        Dim kullaniciad, kullanicisifre As String

        Dim ekleyenkullanici As New CLASSKULLANICI
        Dim guncelleyenkullanici As New CLASSKULLANICI

        Dim sirketfaturabaglar As New List(Of CLASSSIRKETFATURABAG)
        Dim sirketfaturabag As New CLASSSIRKETFATURABAG
        Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("sirketad") Is System.DBNull.Value Then
                        sirketad = veri.Item("sirketad")
                        kol1 = "<tr><td>" + sirketad + "</td>"
                    Else
                        kol1 = "<tr><td>-</td>"
                    End If

                    epostaadresleri = ""
                    sirketfaturabaglar = sirketfaturabag_erisim.doldur_ilgilisirket(pkey)
                    For Each Item As CLASSSIRKETFATURABAG In sirketfaturabaglar
                        epostaadresleri = epostaadresleri + Item.eposta + "<br/>"
                    Next
                    kol2 = "<td>" + epostaadresleri + "</td></tr>"


                    satir = satir + kol1 + kol2

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
    Public Function listele_sirketbazindaaktifsirketegore() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14 As String
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
        "<th>Çalıştığı Şirket</th>" + _
        "<th>Bağlı Olduğu Acente</th>" + _
        "<th>Grubu</th>" + _
        "<th>Rolü</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Aktif mi?</th>" + _
        "<th>E-Posta Adresi</th>" + _
        "<th>Son Giriş Tarihi</th>" + _
        "<th>Son Poliçe Yükleme Tarihi</th>" + _
        "<th>Son Hasar Yükleme Tarihi</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        'şirket tarafındaki ekranlardaki gösterim

        sqlstr = "select * from kullanici where sirketpkey=@kullanici_aktifsirket"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@kullanici_aktifsirket", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = HttpContext.Current.Session("kullanici_aktifsirket")

        komut.Parameters.Add(param1)

        girdi = "0"
        Dim link As String
        Dim pkey, kullanicigruppkey As String
        Dim rolpkey, resimpkey, aktifmi, adsoyad As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET

        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acente As New CLASSACENTE

        Dim sirketpkey, acentepkey, eposta As String
        Dim kullaniciad, kullanicisifre As String

        Dim ekleyenkullanici As New CLASSKULLANICI
        Dim guncelleyenkullanici As New CLASSKULLANICI

        Dim kullanicigrup As New CLASSKULLANICIGRUP
        Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim songiristarih, sonpoliceyuklemetarih, sonhasaryuklemetarihi As DateTime



        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = veri.Item("pkey")
                    Else
                        pkey = 0
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"
                    Else
                        kol1 = "<tr><td>-</td>"
                    End If


                    If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                        acentepkey = veri.Item("acentepkey")
                        acente = acente_erisim.bultek(acentepkey)
                        kol2 = "<td>" + acente.acentead + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullanicigruppkey") Is System.DBNull.Value Then
                        kullanicigruppkey = veri.Item("kullanicigruppkey")
                        kullanicigrup = kullanicigrup_erisim.bultek(kullanicigruppkey)
                        kol3 = "<td>" + kullanicigrup.grupad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                        rolpkey = veri.Item("rolpkey")
                        kullanicirol = kullanicirol_erisim.bultek(rolpkey)
                        kol4 = "<td>" + kullanicirol.rolad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If


                    If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                        adsoyad = veri.Item("adsoyad")
                        kol5 = "<td>" + adsoyad + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        kol6 = "<td>" + aktifmi + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If


                    If Not veri.Item("eposta") Is System.DBNull.Value Then
                        eposta = veri.Item("eposta")
                        kol7 = "<td>" + eposta + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If


                    'CStr(logservis_erisim.sonpoliceyuklemetarihinibul(sirketpkey))
                    'CStr(logservis_erisim.sonhasaryuklemetarihinibul(sirketpkey))

                    kol8 = "<td>" + CStr(loggenel_erisim.songiristarihibul(pkey)) + "</td>"
                    kol9 = "<td>" + "-" + "</td>"
                    kol10 = "<td>" + "-" + "</td>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10

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

    Public Function aktifsirketsecilmismi()

        Dim secilmismi As String

        If HttpContext.Current.Session("kullanici_mensup") = "DİĞER" Then
            If HttpContext.Current.Session("kullanici_aktifsirket") = Nothing Or HttpContext.Current.Session("kullanici_aktifsirket") = "" Then
                secilmismi = "Hayır"
            Else
                secilmismi = "Evet"
            End If
        End If

        If HttpContext.Current.Session("kullanici_mensup") = "KKSBM" Then
            secilmismi = "Evet"
        End If

        Return secilmismi

    End Function


    Public Function aktifsirketbul()

        Dim kullanici_aktifsirket As String
        kullanici_aktifsirket = HttpContext.Current.Session("kullanici_aktifsirket")
        If kullanici_aktifsirket = Nothing Or kullanici_aktifsirket = "" Then
            Return "0"
        Else
            Return kullanici_aktifsirket
        End If

    End Function


    '--- TEKNİK PERSONEL TANIMLANMIŞ MI -------------------------------------------------------
    Public Function teknikpersoneltanimlanmismi(ByVal tpno As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "SELECT * FROM kullanici,personel where " + _
        "kullanici.personelpkey=personel.pkey and personel.tpno=@tpno"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tpno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tpno
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function dokumanzararlimi(ByVal docname As String) As String

        Dim zararlimi As String = "Hayır"
        Dim zararlilar(9) As String
        zararlilar(0) = ".ini"
        zararlilar(1) = ".exe"
        zararlilar(2) = ".asp"
        zararlilar(3) = ".aspx"
        zararlilar(4) = ".php"
        zararlilar(5) = ".vb"
        zararlilar(6) = ".dll"
        zararlilar(7) = ".pl"
        zararlilar(8) = ".js"
        zararlilar(9) = " "

        For Each Item As String In zararlilar
            If InStr(docname, Item, CompareMethod.Text) > 0 Then
                zararlimi = "Evet"
            End If

        Next

        Return zararlimi

    End Function


    '---------------------------------listele--------------------------------------
    Public Function onlinekullanicilar() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14 As String
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
        "<th>Çalıştığı Şirket</th>" + _
        "<th>Bağlı Olduğu Acente</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Son Giriş Tarihi</th>" + _
        "<th>Son Çıkış Tarihi</th>" + _
        "<th>Bağlantı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        Dim yirmidakika_oncesi As DateTime
        Dim simdi As DateTime
        simdi = Now
        yirmidakika_oncesi = Now.AddMinutes(-20)


        sqlstr = "select kullanicipkey from loggenel where islem=@islem and tarih>=@tarih group by kullanicipkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlClient.SqlParameter("@islem", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Giriş"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlClient.SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = yirmidakika_oncesi
        komut.Parameters.Add(param2)


        girdi = "0"
        Dim link As String
        Dim pkey, kullanicigruppkey As String
        Dim rolpkey, resimpkey, aktifmi, adsoyad As String

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET

        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acente As New CLASSACENTE

        Dim sirketpkey, acentepkey, eposta As String
        Dim kullaniciad, kullanicisifre As String

        Dim ekleyenkullanici As New CLASSKULLANICI
        Dim guncelleyenkullanici As New CLASSKULLANICI

        Dim kullanicigrup As New CLASSKULLANICIGRUP
        Dim kullanicigrup_erisim As New CLASSKULLANICIGRUP_ERISIM

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim songiristarih, soncikistarih, sonpoliceyuklemetarih, sonhasaryuklemetarihi As DateTime
        Dim kullanicipkey As Integer
        Dim ajaxlinksil, dugmesil As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                    Else
                        kullanicipkey = 0
                    End If

                    songiristarih = loggenel_erisim.songiristarihibul(kullanicipkey)
                    soncikistarih = loggenel_erisim.soncikistarihibul(kullanicipkey)


                    'eğer son çıkış tarihi son giriş tarihinden küçükse login durumundadır.
                    If soncikistarih < songiristarih Then

                        kullanici = bultek(kullanicipkey)

                        sirketpkey = kullanici.sirketpkey
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol1 = "<tr><td>" + sirket.sirketad + "</td>"

                        acentepkey = kullanici.acentepkey
                        acente = acente_erisim.bultek(acentepkey)
                        kol2 = "<td>" + acente.acentead + "</td>"

                        kullanicigruppkey = kullanici.kullanicigruppkey
                        kullanicigrup = kullanicigrup_erisim.bultek(kullanicigruppkey)
                        kol3 = "<td>" + kullanicigrup.grupad + "</td>"

                        rolpkey = kullanici.rolpkey
                        kullanicirol = kullanicirol_erisim.bultek(rolpkey)
                        kol4 = "<td>" + kullanicirol.rolad + "</td>"

                        kol5 = "<td>" + kullanici.adsoyad + "</td>"

                        kol6 = "<td>" + kullanici.aktifmi + "</td>"

                        kol7 = "<td>" + kullanici.eposta + "</td>"

                        kol8 = "<td>" + CStr(songiristarih) + "</td>"
                        kol9 = "<td>" + CStr(soncikistarih) + "</td>"

                        '--BAĞLANTIYI KES DÜĞMESİ ------
                        ajaxlinksil = "baglantikes(" + CStr(kullanicipkey) + ")"
                        dugmesil = "<span id='baglantikesbutton' onclick='" + ajaxlinksil + _
                        "' class='button'>Baglantıyı Kes</span>"
                        kol10 = "<td>" + dugmesil + "</td></tr>"

                        satir = satir + kol1 + kol2 + kol5 + _
                         kol8 + kol9 + kol10

                    End If

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        Else
            donecek = "Şu anda online kullanıcı yoktur."
        End If

        Return (donecek)

    End Function



    '--- TEKNİK PERSONEL TANIMLANMIŞ MI -------------------------------------------------------
    Public Function varmi_epostakullaniciadsahip(ByVal eposta As String, _
    ByVal kullaniciad As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "SELECT * FROM kullanici where eposta=@eposta and kullaniciad=@kullaniciad"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = eposta
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullaniciad
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function

End Class