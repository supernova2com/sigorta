Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSWEBUYE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim webuye As New CLASSwebuye
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal webuye As CLASSWEBUYE) As CLADBOPRESULT

        Dim kaydedilenpkey As Integer

        etkilenen = 0
        Dim varmi1, varmi2 As String
        varmi1 = ciftkayitkontrol("eposta", webuye.eposta)
        varmi2 = ciftkayitkontrol("kullaniciad", webuye.kullaniciad)

        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu e-posta adresi ile kayıtlı üye halihazırda vardır."
            resultset.etkilenen = 0
        End If

        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kullanıcı adı ile kayıtlı üye halihazırda vardır."
            resultset.etkilenen = 0
        End If


        If varmi1 = "Hayır" And varmi2 = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into webuye values (@pkey," + _
            "@sirketpkey,@uyetip,@adsoyad,@adres," + _
            "@telefon,@eposta,@kullaniciad,@kullanicisifre," + _
            "@aktifmi,@uyebaslangictarih,@uyebitistarih,@rolpkey)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            kaydedilenpkey = pkeybul()
            param1.Value = kaydedilenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If webuye.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = webuye.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@uyetip", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If webuye.uyetip = 0 Then
                param3.Value = 0
            Else
                param3.Value = webuye.uyetip
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@adsoyad", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If webuye.adsoyad = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = webuye.adsoyad
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@adres", SqlDbType.Text)
            param5.Direction = ParameterDirection.Input
            If webuye.adres = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = webuye.adres
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@telefon", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If webuye.telefon = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = webuye.telefon
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@eposta", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If webuye.eposta = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = webuye.eposta
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If webuye.kullaniciad = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = webuye.kullaniciad
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@kullanicisifre", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If webuye.kullanicisifre = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = webuye.kullanicisifre
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If webuye.aktifmi = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = webuye.aktifmi
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@uyebaslangictarih", SqlDbType.DateTime)
            param11.Direction = ParameterDirection.Input
            If webuye.uyebaslangictarih Is Nothing Or webuye.uyebaslangictarih = "00:00:00" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = webuye.uyebaslangictarih
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@uyebitistarih", SqlDbType.DateTime)
            param12.Direction = ParameterDirection.Input
            If webuye.uyebitistarih Is Nothing Or webuye.uyebitistarih = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = webuye.uyebitistarih
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@rolpkey", SqlDbType.Int)
            param13.Direction = ParameterDirection.Input
            If webuye.rolpkey = 0 Then
                param13.Value = 0
            Else
                param13.Value = webuye.rolpkey
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
        sqlstr = "select max(pkey) from webuye"
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
    Function Duzenle(ByVal webuye As CLASSWEBUYE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update webuye set " + _
        "sirketpkey=@sirketpkey," + _
        "uyetip=@uyetip," + _
        "adsoyad=@adsoyad," + _
        "adres=@adres," + _
        "telefon=@telefon," + _
        "eposta=@eposta," + _
        "kullaniciad=@kullaniciad," + _
        "kullanicisifre=@kullanicisifre," + _
        "aktifmi=@aktifmi," + _
        "uyebaslangictarih=@uyebaslangictarih," + _
        "uyebitistarih=@uyebitistarih," + _
        "rolpkey=@rolpkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = webuye.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If webuye.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = webuye.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@uyetip", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If webuye.uyetip = 0 Then
            param3.Value = 0
        Else
            param3.Value = webuye.uyetip
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@adsoyad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If webuye.adsoyad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = webuye.adsoyad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@adres", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If webuye.adres = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = webuye.adres
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@telefon", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If webuye.telefon = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = webuye.telefon
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If webuye.eposta = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = webuye.eposta
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If webuye.kullaniciad = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = webuye.kullaniciad
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@kullanicisifre", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If webuye.kullanicisifre = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = webuye.kullanicisifre
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If webuye.aktifmi = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = webuye.aktifmi
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@uyebaslangictarih", SqlDbType.DateTime)
        param11.Direction = ParameterDirection.Input
        If webuye.uyebaslangictarih Is Nothing Or webuye.uyebaslangictarih = "00:00:00" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = webuye.uyebaslangictarih
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@uyebitistarih", SqlDbType.DateTime)
        param12.Direction = ParameterDirection.Input
        If webuye.uyebitistarih Is Nothing Or webuye.uyebitistarih = "00:00:00" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = webuye.uyebitistarih
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@rolpkey", SqlDbType.Int)
        param13.Direction = ParameterDirection.Input
        If webuye.rolpkey = 0 Then
            param13.Value = 0
        Else
            param13.Value = webuye.rolpkey
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
            resultset.etkilenen = webuye.pkey
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSwebuye

        Dim komut As New SqlCommand
        Dim donecekwebuye As New CLASSwebuye()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from webuye where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekwebuye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekwebuye.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("uyetip") Is System.DBNull.Value Then
                    donecekwebuye.uyetip = veri.Item("uyetip")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekwebuye.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekwebuye.adres = veri.Item("adres")
                End If

                If Not veri.Item("telefon") Is System.DBNull.Value Then
                    donecekwebuye.telefon = veri.Item("telefon")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekwebuye.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekwebuye.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekwebuye.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekwebuye.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebaslangictarih = veri.Item("uyebaslangictarih")
                End If

                If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebitistarih = veri.Item("uyebitistarih")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekwebuye.rolpkey = veri.Item("rolpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekwebuye

    End Function


    '---------------------------------bul sirketpkey e göre-----------------------------------------
    Function bul_sirketpkeyegore(ByVal sirketpkey As String) As CLASSWEBUYE

        Dim komut As New SqlCommand
        Dim donecekwebuye As New CLASSWEBUYE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from webuye where sirketpkey=@sirketpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekwebuye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekwebuye.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("uyetip") Is System.DBNull.Value Then
                    donecekwebuye.uyetip = veri.Item("uyetip")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekwebuye.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekwebuye.adres = veri.Item("adres")
                End If

                If Not veri.Item("telefon") Is System.DBNull.Value Then
                    donecekwebuye.telefon = veri.Item("telefon")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekwebuye.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekwebuye.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekwebuye.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekwebuye.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebaslangictarih = veri.Item("uyebaslangictarih")
                End If

                If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebitistarih = veri.Item("uyebitistarih")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekwebuye.rolpkey = veri.Item("rolpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekwebuye

    End Function


    '---------------------------------bul e-posta adresine göre-----------------------------------------
    Function bultek_epostaadresinegore(ByVal eposta As String) As CLASSWEBUYE

        Dim komut As New SqlCommand
        Dim donecekwebuye As New CLASSWEBUYE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from webuye where eposta=@eposta"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = eposta
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekwebuye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekwebuye.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("uyetip") Is System.DBNull.Value Then
                    donecekwebuye.uyetip = veri.Item("uyetip")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekwebuye.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekwebuye.adres = veri.Item("adres")
                End If

                If Not veri.Item("telefon") Is System.DBNull.Value Then
                    donecekwebuye.telefon = veri.Item("telefon")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekwebuye.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekwebuye.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekwebuye.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekwebuye.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebaslangictarih = veri.Item("uyebaslangictarih")
                End If

                If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebitistarih = veri.Item("uyebitistarih")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekwebuye.rolpkey = veri.Item("rolpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekwebuye

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bulkullaniciadisifregore(ByVal kullaniciad As String, ByVal kullanicisifre As String) As CLASSWEBUYE

        Dim komut As New SqlCommand
        Dim donecekwebuye As New CLASSWEBUYE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from webuye where kullaniciad=@kullaniciad and " + _
        "kullanicisifre=@kullanicisifre"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kullaniciad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullaniciad
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicisifre", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullanicisifre
        komut.Parameters.Add(param2)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekwebuye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekwebuye.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("uyetip") Is System.DBNull.Value Then
                    donecekwebuye.uyetip = veri.Item("uyetip")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekwebuye.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekwebuye.adres = veri.Item("adres")
                End If

                If Not veri.Item("telefon") Is System.DBNull.Value Then
                    donecekwebuye.telefon = veri.Item("telefon")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekwebuye.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekwebuye.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekwebuye.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekwebuye.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebaslangictarih = veri.Item("uyebaslangictarih")
                End If

                If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebitistarih = veri.Item("uyebitistarih")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekwebuye.rolpkey = veri.Item("rolpkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekwebuye

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from webuye where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSwebuye)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekwebuye As New CLASSwebuye
        Dim webuyeler As New List(Of CLASSwebuye)
        komut.Connection = db_baglanti
        sqlstr = "select * from webuye"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekwebuye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekwebuye.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("uyetip") Is System.DBNull.Value Then
                    donecekwebuye.uyetip = veri.Item("uyetip")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekwebuye.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekwebuye.adres = veri.Item("adres")
                End If

                If Not veri.Item("telefon") Is System.DBNull.Value Then
                    donecekwebuye.telefon = veri.Item("telefon")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekwebuye.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekwebuye.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekwebuye.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekwebuye.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebaslangictarih = veri.Item("uyebaslangictarih")
                End If

                If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebitistarih = veri.Item("uyebitistarih")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekwebuye.rolpkey = veri.Item("rolpkey")
                End If


                webuyeler.Add(New CLASSWEBUYE(donecekwebuye.pkey, _
                donecekwebuye.sirketpkey, donecekwebuye.uyetip, donecekwebuye.adsoyad, donecekwebuye.adres, _
                donecekwebuye.telefon, donecekwebuye.eposta, donecekwebuye.kullaniciad, donecekwebuye.kullanicisifre, _
                donecekwebuye.aktifmi, donecekwebuye.uyebaslangictarih, donecekwebuye.uyebitistarih, _
                donecekwebuye.rolpkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return webuyeler

    End Function

    
    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11, kol12 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        jvstring = "<script type='text/javascript'>" + _
        "$(document).ready(function() {" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Şirket</th>" + _
        "<th>Üye Tipi / Rolü</th>" + _
        "<th>Ad Soyad</th>" + _
        "<th>Adres</th>" + _
        "<th>Telefon</th>" + _
        "<th>E-Posta</th>" + _
        "<th>Kullanıcı Adı</th>" + _
        "<th>Kullanıcı Şifre</th>" + _
        "<th>Aktif mi?</th>" + _
        "<th>Üye Başlangıç Tarihi</th>" + _
        "<th>Üye Bitiş Tarihi</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "adsoyad" Then
            sqlstr = "select * from webuye where adsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from webuye order by uyebaslangictarih"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, uyetip, adsoyad, adres, telefon As String
        Dim eposta, kullaniciad, kullanicisifre, aktifmi, uyebaslangictarih, uyebitistarih As String
        Dim uyetipaciklama, rolpkey As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM
        Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI


        Dim ajaxlinkaktif, dugmeaktif As String
        Dim ajaxlinkpasif, dugmepasif As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "webuye.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><a href=" + link + ">" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                    End If

                    If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                        rolpkey = veri.Item("rolpkey")
                        kullanicirolbilgi = kullanicirolbilgi_erisim.bultek(rolpkey)
                    End If

                    If Not veri.Item("uyetip") Is System.DBNull.Value Then
                        uyetip = veri.Item("uyetip")
                        Select uyetip
                            Case "1"
                                uyetipaciklama = "Admin"
                            Case "2"
                                uyetipaciklama = "Şirket Admin"
                            Case "3"
                                uyetipaciklama = "Üye"
                        End Select
                        kol3 = "<td>" + "Üye Tipi<b>" + uyetipaciklama + "</b><br/>" + _
                        "Rolü:<b>" + kullanicirolbilgi.rolad + "</b>" + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                        adsoyad = veri.Item("adsoyad")
                        kol4 = "<td>" + adsoyad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("adres") Is System.DBNull.Value Then
                        adres = veri.Item("adres")
                        kol5 = "<td>" + adres + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("telefon") Is System.DBNull.Value Then
                        telefon = veri.Item("telefon")
                        kol6 = "<td>" + telefon + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("eposta") Is System.DBNull.Value Then
                        eposta = veri.Item("eposta")
                        kol7 = "<td>" + eposta + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                        kullaniciad = veri.Item("kullaniciad")
                        kol8 = "<td>" + kullaniciad + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                        kullanicisifre = veri.Item("kullanicisifre")
                        kol9 = "<td>" + kullanicisifre + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If


                    '--AKTİF DÜĞMESİ ------
                    ajaxlinkaktif = "uyeaktifyap(" + CStr(pkey) + ")"
                    dugmeaktif = "<span id='aktifbutton' onclick='" + ajaxlinkaktif + _
                    "' class='button'>Aktife Çevir</span>"


                    ajaxlinkpasif = "uyepasifyap(" + CStr(pkey) + ")"
                    dugmepasif = "<span id='pasifbutton' onclick='" + ajaxlinkpasif + _
                    "' class='button'>Pasife Çevir</span>"


                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        If aktifmi = "Evet" Then
                            kol10 = "<td>" + aktifmi + "<br/>" + dugmepasif + "</td>"
                        End If
                        If aktifmi = "Hayır" Then
                            kol10 = "<td>" + aktifmi + "<br/>" + dugmeaktif + "</td>"
                        End If
                    End If

                    If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                        uyebaslangictarih = veri.Item("uyebaslangictarih")
                        kol11 = "<td>" + uyebaslangictarih + "</td>"
                    Else
                        kol11 = "<td>-</td>"
                    End If

                    If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                        uyebitistarih = veri.Item("uyebitistarih")
                        kol12 = "<td>" + uyebitistarih + "</td></tr>"
                    Else
                        kol12 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

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

        sqlstr = "select * from webuye where " + tablecol + "=@kriter"

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


    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSWEBUYE)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekwebuye As New CLASSWEBUYE
        Dim webuyeler As New List(Of CLASSWEBUYE)
        komut.Connection = db_baglanti


        If HttpContext.Current.Session("ltip") = "adsoyad" Then

            sqlstr = "select * from webuye where " + tablecol + " LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = kriter
            komut.Parameters.Add(param1)

        End If


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekwebuye.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekwebuye.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("uyetip") Is System.DBNull.Value Then
                    donecekwebuye.uyetip = veri.Item("uyetip")
                End If

                If Not veri.Item("adsoyad") Is System.DBNull.Value Then
                    donecekwebuye.adsoyad = veri.Item("adsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekwebuye.adres = veri.Item("adres")
                End If

                If Not veri.Item("telefon") Is System.DBNull.Value Then
                    donecekwebuye.telefon = veri.Item("telefon")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    donecekwebuye.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("kullaniciad") Is System.DBNull.Value Then
                    donecekwebuye.kullaniciad = veri.Item("kullaniciad")
                End If

                If Not veri.Item("kullanicisifre") Is System.DBNull.Value Then
                    donecekwebuye.kullanicisifre = veri.Item("kullanicisifre")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    donecekwebuye.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("uyebaslangictarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebaslangictarih = veri.Item("uyebaslangictarih")
                End If

                If Not veri.Item("uyebitistarih") Is System.DBNull.Value Then
                    donecekwebuye.uyebitistarih = veri.Item("uyebitistarih")
                End If

                If Not veri.Item("rolpkey") Is System.DBNull.Value Then
                    donecekwebuye.rolpkey = veri.Item("rolpkey")
                End If

                webuyeler.Add(New CLASSWEBUYE(donecekwebuye.pkey, _
                donecekwebuye.sirketpkey, donecekwebuye.uyetip, donecekwebuye.adsoyad, donecekwebuye.adres, _
                donecekwebuye.telefon, donecekwebuye.eposta, donecekwebuye.kullaniciad, donecekwebuye.kullanicisifre, _
                donecekwebuye.aktifmi, donecekwebuye.uyebaslangictarih, donecekwebuye.uyebitistarih, _
                donecekwebuye.rolpkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return webuyeler

    End Function


    Public Function logincontrol(ByVal kullaniciad As String, ByVal kullanicisifre As String) As CLADBOPRESULT

        'BURADA RESULT DA ETKILENEN DONEN PKEY
        Dim result As New CLADBOPRESULT
        Dim webuye As New CLASSWEBUYE
        Dim simdikizaman As New DateTime
        simdikizaman = DateTime.Now

        webuye = bulkullaniciadisifregore(kullaniciad, kullanicisifre)

        If webuye.pkey = 0 Then
            result.durum = "Hayır"
            result.etkilenen = 0
            result.hatastr = "Kullanıcı adı yada şifreniz hatalıdır."
            Return result
        End If

        If webuye.pkey > 0 Then

            If webuye.aktifmi <> "Evet" Then
                result.durum = "Hayır"
                result.etkilenen = 0
                result.hatastr = "Üyeliğiniz aktif değildir."
                Return result
            End If

            If webuye.uyebaslangictarih > simdikizaman Then
                result.durum = "Hayır"
                result.etkilenen = 0
                result.hatastr = "Üyeliğiniz daha başlamadı. Üyelik başlangıç tarihinizi kontrol ediniz."
                Return result
            End If

            If webuye.uyebitistarih < simdikizaman Then
                result.durum = "Hayır"
                result.etkilenen = 0
                result.hatastr = "Üyeliğiniz " + CStr(webuye.uyebitistarih) + " tarihinde sonlanmıştır."
                Return result
            End If

            result.durum = "Evet"
            result.etkilenen = webuye.pkey
            result.hatastr = ""
            Return result

        End If

    End Function


    '----------------------------------TOPLAM OYA SAYISI--------------------------------------
    Public Function toplamsayi(ByVal uyetip As String) As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from webuye where uyetip=@uyetip "
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@uyetip", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = uyetip
        komut.Parameters.Add(param1)

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



    Function sifremigonder(ByVal eposta As String) As CLADBOPRESULT


        Dim webuye As New CLASSWEBUYE
        Dim result As New CLADBOPRESULT

        'öncelikle bu e-posta adresi varmi. 
        Dim varmi As String = "Hayır"
        varmi = ciftkayitkontrol("eposta", eposta)

        If varmi = "Hayır" Then
            result.durum = "Gönderilmedi"
            result.etkilenen = 0
            result.hatastr = "Girdiğiniz e-posta adresiyle tanımlı herhangi bir kullanıcı tanımlanmamış."
        End If

        If varmi = "Evet" Then

            webuye = bultek_epostaadresinegore(eposta)

            Dim body As String = ""
            Dim d As DateTime
            Dim email As New CLASSEMAIL
            Dim email_erisim As New CLASSEMAIL_ERISIM
            Dim emailayar As New CLASSEMAILAYAR
            Dim emailayar_Erisim As New CLASSEMAILAYAR_ERISIM
            emailayar = emailayar_Erisim.bul(1)

            body = "Kuzey Kıbrıs Türk Cumhuriyeti Sigorta ve Reasürans Şirketler Birliği<br/>" + _
            "<br/>" + _
            "Değerli Kullanıcımız" + "<br/>" + _
            "Merhaba " + webuye.adsoyad + "<br/>" + _
            "Şifrenizi unuttunuz ve hatırlatmak için bizden " + CStr(d.Now) + " tarihinde talepte bulundunuz." + "<br/>" + _
            "Unuttuğunuz şifreniz:" + webuye.kullanicisifre + " dir." + "<br/>" + _
            "İyi çalışmalar diler, saygılar sunarız." + "<br/>" + _
            "Kuzey Kıbrıs Türk Cumhuriyeti Sigorta ve Reasürans Şirketler Birliği" + "<br/>"

            email.kimden = emailayar.username
            email.kime = eposta
            email.subject = d.Now.ToString() + " SİGORTA VE REASÜRANS ŞİRKETLER BİRLİĞİ ŞİFRE HATIRLATMA TALEBİ "
            email.body = body

            result = email_erisim.gonder(email)

        End If

        Return result

    End Function

End Class


