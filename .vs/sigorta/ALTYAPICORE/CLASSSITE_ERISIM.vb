Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data



Public Class CLASSSITE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim site As New CLASSSITE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal site As CLASSSITE) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into site values (@pkey," + _
        "@url,@path,@yer,@temapkey," + _
        "@musteriadsoyad,@musteriofistel,@mustericeptel,@musterifax," + _
        "@musteriadres,@sistemveritabaniad,@musteriemail,@kullanimbaslangictarih," + _
        "@yanlissifrecount,@roltabload,@pgkullaniciad,@pgsifre," + _
        "@captcha,@copyrighttext,@faturaodemesongun,@hataeposta)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@url", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If site.url = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = site.url
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@path", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If site.path = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = site.path
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yer", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If site.yer = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = site.yer
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@temapkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If site.temapkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = site.temapkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@musteriadsoyad", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If site.musteriadsoyad = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = site.musteriadsoyad
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@musteriofistel", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If site.musteriofistel = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = site.musteriofistel
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@mustericeptel", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If site.mustericeptel = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = site.mustericeptel
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@musterifax", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If site.musterifax = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = site.musterifax
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@musteriadres", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If site.musteriadres = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = site.musteriadres
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@sistemveritabaniad", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If site.sistemveritabaniad = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = site.sistemveritabaniad
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@musteriemail", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If site.musteriemail = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = site.musteriemail
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@kullanimbaslangictarih", SqlDbType.Date)
        param13.Direction = ParameterDirection.Input
        If site.kullanimbaslangictarih Is Nothing Or site.kullanimbaslangictarih = "00:00:00" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = site.kullanimbaslangictarih
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@yanlissifrecount", SqlDbType.Int)
        param14.Direction = ParameterDirection.Input
        If site.yanlissifrecount = 0 Then
            param14.Value = 0
        Else
            param14.Value = site.yanlissifrecount
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@roltabload", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If site.roltabload = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = site.roltabload
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@pgkullaniciad", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If site.pgkullaniciad = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = site.pgkullaniciad
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@pgsifre", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If site.pgsifre = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = site.pgsifre
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@captcha", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If site.captcha = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = site.captcha
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@copyrighttext", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If site.copyrighttext = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = site.copyrighttext
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@faturaodemesongun", SqlDbType.Int)
        param20.Direction = ParameterDirection.Input
        If site.faturaodemesongun = 0 Then
            param20.Value = 0
        Else
            param20.Value = site.faturaodemesongun
        End If
        komut.Parameters.Add(param20)


        Dim param21 As New SqlParameter("@hataeposta", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If site.hataeposta = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = site.hataeposta
        End If
        komut.Parameters.Add(param21)


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
        sqlstr = "select max(pkey) from site"
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
    Function Duzenle(ByVal site As CLASSSITE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update site set " + _
        "url=@url," + _
        "path=@path," + _
        "yer=@yer," + _
        "temapkey=@temapkey," + _
        "musteriadsoyad=@musteriadsoyad," + _
        "musteriofistel=@musteriofistel," + _
        "mustericeptel=@mustericeptel," + _
        "musterifax=@musterifax," + _
        "musteriadres=@musteriadres," + _
        "sistemveritabaniad=@sistemveritabaniad," + _
        "musteriemail=@musteriemail," + _
        "kullanimbaslangictarih=@kullanimbaslangictarih," + _
        "yanlissifrecount=@yanlissifrecount," + _
        "roltabload=@roltabload," + _
        "pgkullaniciad=@pgkullaniciad," + _
        "pgsifre=@pgsifre," + _
        "captcha=@captcha," + _
        "copyrighttext=@copyrighttext," + _
        "faturaodemesongun=@faturaodemesongun," + _
        "hataeposta=@hataeposta" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = site.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@url", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If site.url = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = site.url
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@path", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If site.path = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = site.path
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yer", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If site.yer = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = site.yer
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@temapkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If site.temapkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = site.temapkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@musteriadsoyad", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If site.musteriadsoyad = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = site.musteriadsoyad
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@musteriofistel", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If site.musteriofistel = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = site.musteriofistel
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@mustericeptel", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If site.mustericeptel = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = site.mustericeptel
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@musterifax", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If site.musterifax = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = site.musterifax
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@musteriadres", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If site.musteriadres = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = site.musteriadres
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@sistemveritabaniad", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If site.sistemveritabaniad = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = site.sistemveritabaniad
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@musteriemail", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If site.musteriemail = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = site.musteriemail
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@kullanimbaslangictarih", SqlDbType.Date)
        param13.Direction = ParameterDirection.Input
        If site.kullanimbaslangictarih Is Nothing Or site.kullanimbaslangictarih = "00:00:00" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = site.kullanimbaslangictarih
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@yanlissifrecount", SqlDbType.Int)
        param14.Direction = ParameterDirection.Input
        If site.yanlissifrecount = 0 Then
            param14.Value = 0
        Else
            param14.Value = site.yanlissifrecount
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@roltabload", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If site.roltabload = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = site.roltabload
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@pgkullaniciad", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If site.pgkullaniciad = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = site.pgkullaniciad
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@pgsifre", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If site.pgsifre = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = site.pgsifre
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@captcha", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If site.captcha = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = site.captcha
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@copyrighttext", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If site.copyrighttext = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = site.copyrighttext
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@faturaodemesongun", SqlDbType.Int)
        param20.Direction = ParameterDirection.Input
        If site.faturaodemesongun = 0 Then
            param20.Value = 0
        Else
            param20.Value = site.faturaodemesongun
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@hataeposta", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If site.hataeposta = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = site.hataeposta
        End If
        komut.Parameters.Add(param21)


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
    Function bultek(ByVal pkey As String) As CLASSSITE

        Dim komut As New SqlCommand
        Dim doneceksite As New CLASSSITE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from site where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksite.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("url") Is System.DBNull.Value Then
                    doneceksite.url = veri.Item("url")
                End If

                If Not veri.Item("path") Is System.DBNull.Value Then
                    doneceksite.path = veri.Item("path")
                End If

                If Not veri.Item("yer") Is System.DBNull.Value Then
                    doneceksite.yer = veri.Item("yer")
                End If

                If Not veri.Item("temapkey") Is System.DBNull.Value Then
                    doneceksite.temapkey = veri.Item("temapkey")
                End If

                If Not veri.Item("musteriadsoyad") Is System.DBNull.Value Then
                    doneceksite.musteriadsoyad = veri.Item("musteriadsoyad")
                End If

                If Not veri.Item("musteriofistel") Is System.DBNull.Value Then
                    doneceksite.musteriofistel = veri.Item("musteriofistel")
                End If

                If Not veri.Item("mustericeptel") Is System.DBNull.Value Then
                    doneceksite.mustericeptel = veri.Item("mustericeptel")
                End If

                If Not veri.Item("musterifax") Is System.DBNull.Value Then
                    doneceksite.musterifax = veri.Item("musterifax")
                End If

                If Not veri.Item("musteriadres") Is System.DBNull.Value Then
                    doneceksite.musteriadres = veri.Item("musteriadres")
                End If

                If Not veri.Item("sistemveritabaniad") Is System.DBNull.Value Then
                    doneceksite.sistemveritabaniad = veri.Item("sistemveritabaniad")
                End If

                If Not veri.Item("musteriemail") Is System.DBNull.Value Then
                    doneceksite.musteriemail = veri.Item("musteriemail")
                End If

                If Not veri.Item("kullanimbaslangictarih") Is System.DBNull.Value Then
                    doneceksite.kullanimbaslangictarih = veri.Item("kullanimbaslangictarih")
                End If

                If Not veri.Item("yanlissifrecount") Is System.DBNull.Value Then
                    doneceksite.yanlissifrecount = veri.Item("yanlissifrecount")
                End If

                If Not veri.Item("roltabload") Is System.DBNull.Value Then
                    doneceksite.roltabload = veri.Item("roltabload")
                End If

                If Not veri.Item("pgkullaniciad") Is System.DBNull.Value Then
                    doneceksite.pgkullaniciad = veri.Item("pgkullaniciad")
                End If

                If Not veri.Item("pgsifre") Is System.DBNull.Value Then
                    doneceksite.pgsifre = veri.Item("pgsifre")
                End If

                If Not veri.Item("captcha") Is System.DBNull.Value Then
                    doneceksite.captcha = veri.Item("captcha")
                End If

                If Not veri.Item("copyrighttext") Is System.DBNull.Value Then
                    doneceksite.copyrighttext = veri.Item("copyrighttext")
                End If

                If Not veri.Item("faturaodemesongun") Is System.DBNull.Value Then
                    doneceksite.faturaodemesongun = veri.Item("faturaodemesongun")
                End If

                If Not veri.Item("hataeposta") Is System.DBNull.Value Then
                    doneceksite.hataeposta = veri.Item("hataeposta")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksite

    End Function

    
    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSSITE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksite As New CLASSSITE
        Dim siteler As New List(Of CLASSSITE)
        komut.Connection = db_baglanti
        sqlstr = "select * from site"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksite.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("url") Is System.DBNull.Value Then
                    doneceksite.url = veri.Item("url")
                End If

                If Not veri.Item("path") Is System.DBNull.Value Then
                    doneceksite.path = veri.Item("path")
                End If

                If Not veri.Item("yer") Is System.DBNull.Value Then
                    doneceksite.yer = veri.Item("yer")
                End If

                If Not veri.Item("temapkey") Is System.DBNull.Value Then
                    doneceksite.temapkey = veri.Item("temapkey")
                End If

                If Not veri.Item("musteriadsoyad") Is System.DBNull.Value Then
                    doneceksite.musteriadsoyad = veri.Item("musteriadsoyad")
                End If

                If Not veri.Item("musteriofistel") Is System.DBNull.Value Then
                    doneceksite.musteriofistel = veri.Item("musteriofistel")
                End If

                If Not veri.Item("mustericeptel") Is System.DBNull.Value Then
                    doneceksite.mustericeptel = veri.Item("mustericeptel")
                End If

                If Not veri.Item("musterifax") Is System.DBNull.Value Then
                    doneceksite.musterifax = veri.Item("musterifax")
                End If

                If Not veri.Item("musteriadres") Is System.DBNull.Value Then
                    doneceksite.musteriadres = veri.Item("musteriadres")
                End If

                If Not veri.Item("sistemveritabaniad") Is System.DBNull.Value Then
                    doneceksite.sistemveritabaniad = veri.Item("sistemveritabaniad")
                End If

                If Not veri.Item("musteriemail") Is System.DBNull.Value Then
                    doneceksite.musteriemail = veri.Item("musteriemail")
                End If

                If Not veri.Item("kullanimbaslangictarih") Is System.DBNull.Value Then
                    doneceksite.kullanimbaslangictarih = veri.Item("kullanimbaslangictarih")
                End If

                If Not veri.Item("yanlissifrecount") Is System.DBNull.Value Then
                    doneceksite.yanlissifrecount = veri.Item("yanlissifrecount")
                End If

                If Not veri.Item("roltabload") Is System.DBNull.Value Then
                    doneceksite.roltabload = veri.Item("roltabload")
                End If

                If Not veri.Item("pgkullaniciad") Is System.DBNull.Value Then
                    doneceksite.pgkullaniciad = veri.Item("pgkullaniciad")
                End If

                If Not veri.Item("pgsifre") Is System.DBNull.Value Then
                    doneceksite.pgsifre = veri.Item("pgsifre")
                End If

                If Not veri.Item("captcha") Is System.DBNull.Value Then
                    doneceksite.captcha = veri.Item("captcha")
                End If

                If Not veri.Item("copyrighttext") Is System.DBNull.Value Then
                    doneceksite.copyrighttext = veri.Item("copyrighttext")
                End If

                If Not veri.Item("faturaodemesongun") Is System.DBNull.Value Then
                    doneceksite.faturaodemesongun = veri.Item("faturaodemesongun")
                End If

                If Not veri.Item("hataeposta") Is System.DBNull.Value Then
                    doneceksite.hataeposta = veri.Item("hataeposta")
                End If

                siteler.Add(New CLASSSITE(doneceksite.pkey, _
                doneceksite.url, doneceksite.path, doneceksite.yer, doneceksite.temapkey, _
                doneceksite.musteriadsoyad, doneceksite.musteriofistel, doneceksite.mustericeptel, doneceksite.musterifax, _
                doneceksite.musteriadres, doneceksite.sistemveritabaniad, doneceksite.musteriemail, doneceksite.kullanimbaslangictarih, _
                doneceksite.yanlissifrecount, doneceksite.roltabload, doneceksite.pgkullaniciad, doneceksite.pgsifre, _
                doneceksite.captcha, doneceksite.copyrighttext, doneceksite.faturaodemesongun, _
                doneceksite.hataeposta))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return siteler

    End Function

    
    '--- KAYIT SAYISI -------------------------------------------------------
    Function kayitsayisibul() As Integer

        Dim kayitsayisi As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select max(pkey) from site"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitsayisi = 0
        Else
            kayitsayisi = maxkayit1
        End If

        db_baglanti.Close()

        Return kayitsayisi

    End Function


End Class

