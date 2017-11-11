Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Net



Public Class CLASSSIRKET_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim sirket As New CLASSSIRKET
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal sirket As CLASSSIRKET) As CLADBOPRESULT

        Dim eklenenpkey As Integer

        etkilenen = 0
        Dim varmi As String

        varmi = ciftkayitkontrol("sirketkod", sirket.sirketkod)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirket kodu daha önce başka bir şirkete tanımlanmış."
            resultset.etkilenen = 0
            Return resultset
        End If


        varmi = ciftkayitkontrol("sirketad", sirket.sirketad)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirket isminde kayıt halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        varmi = ciftkayitkontrol("wskullaniciad", sirket.wskullaniciad)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu web servis kullanıcı adını kullanan halihazırda şirket vardır."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into sirket values (@pkey," + _
        "@sirketkod,@sirketad,@yetkilikisiadsoyad,@adres," + _
        "@ofistelefon,@faks,@eposta,@aktifmi," + _
        "@resimpkey,@testerisim,@topluyukleme,@wskullaniciad," + _
        "@wssifre,@ipdikkat,@tip,@GetCarAddressInfo_yetki," + _
        "@GetDamageInformation_yetki,@GetInfoInsuredPeople_yetki," + _
        "@LoadDamageInformation_yetki,@LoadPolicyInformation_yetki,@maksservistalepdakika)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        eklenenpkey = pkeybul()
        param1.Value = eklenenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketkod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If sirket.sirketkod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = sirket.sirketkod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sirketad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If sirket.sirketad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = UCase(sirket.sirketad)
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yetkilikisiadsoyad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sirket.yetkilikisiadsoyad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = UCase(sirket.yetkilikisiadsoyad)
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@adres", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If sirket.adres = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = sirket.adres
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ofistelefon", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If sirket.ofistelefon = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = sirket.ofistelefon
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@faks", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If sirket.faks = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = sirket.faks
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If sirket.eposta = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = sirket.eposta
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If sirket.aktifmi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = sirket.aktifmi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@resimpkey", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If sirket.resimpkey = 0 Then
            param10.Value = 0
        Else
            param10.Value = sirket.resimpkey
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@testerisim", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If sirket.testerisim = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = sirket.testerisim
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@topluyukleme", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If sirket.topluyukleme = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = sirket.topluyukleme
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@wskullaniciad", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If sirket.wskullaniciad = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = sirket.wskullaniciad
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@wssifre", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If sirket.wssifre = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = sirket.wssifre
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@ipdikkat", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If sirket.ipdikkat = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = sirket.ipdikkat
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@tip", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If sirket.tip = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = sirket.tip
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@GetCarAddressInfo_yetki", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If sirket.GetCarAddressInfo_yetki = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = sirket.GetCarAddressInfo_yetki
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@GetDamageInformation_yetki", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If sirket.GetDamageInformation_yetki = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = sirket.GetDamageInformation_yetki
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@GetInfoInsuredPeople_yetki", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If sirket.GetInfoInsuredPeople_yetki = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = sirket.GetInfoInsuredPeople_yetki
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@LoadDamageInformation_yetki", SqlDbType.VarChar)
        param20.Direction = ParameterDirection.Input
        If sirket.LoadDamageInformation_yetki = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = sirket.LoadDamageInformation_yetki
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@LoadPolicyInformation_yetki", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If sirket.LoadPolicyInformation_yetki = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = sirket.LoadPolicyInformation_yetki
        End If
        komut.Parameters.Add(param21)


        Dim param22 As New SqlParameter("@maksservistalepdakika", SqlDbType.Int)
        param22.Direction = ParameterDirection.Input
        If sirket.maksservistalepdakika = 0 Then
            param22.Value = 0
        Else
            param22.Value = sirket.maksservistalepdakika
        End If
        komut.Parameters.Add(param22)

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
            resultset.etkilenen = eklenenpkey
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
        sqlstr = "select max(pkey) from sirket"
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
    Function Duzenle(ByVal sirket As CLASSSIRKET) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sirket set " + _
        "sirketkod=@sirketkod," + _
        "sirketad=@sirketad," + _
        "yetkilikisiadsoyad=@yetkilikisiadsoyad," + _
        "adres=@adres," + _
        "ofistelefon=@ofistelefon," + _
        "faks=@faks," + _
        "eposta=@eposta," + _
        "aktifmi=@aktifmi," + _
        "resimpkey=@resimpkey," + _
        "testerisim=@testerisim," + _
        "topluyukleme=@topluyukleme," + _
        "wskullaniciad=@wskullaniciad," + _
        "wssifre=@wssifre," + _
        "ipdikkat=@ipdikkat," + _
        "tip=@tip," + _
        "GetCarAddressInfo_yetki=@GetCarAddressInfo_yetki," + _
        "GetDamageInformation_yetki=@GetDamageInformation_yetki," + _
        "GetInfoInsuredPeople_yetki=@GetInfoInsuredPeople_yetki," + _
        "LoadDamageInformation_yetki=@LoadDamageInformation_yetki," + _
        "LoadPolicyInformation_yetki=@LoadPolicyInformation_yetki," + _
        "maksservistalepdakika=@maksservistalepdakika" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirket.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketkod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If sirket.sirketkod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = sirket.sirketkod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sirketad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If sirket.sirketad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = UCase(sirket.sirketad)
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yetkilikisiadsoyad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If sirket.yetkilikisiadsoyad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = UCase(sirket.yetkilikisiadsoyad)
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@adres", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If sirket.adres = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = sirket.adres
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ofistelefon", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If sirket.ofistelefon = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = sirket.ofistelefon
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@faks", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If sirket.faks = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = sirket.faks
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@eposta", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If sirket.eposta = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = sirket.eposta
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If sirket.aktifmi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = sirket.aktifmi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@resimpkey", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If sirket.resimpkey = 0 Then
            param10.Value = 0
        Else
            param10.Value = sirket.resimpkey
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@testerisim", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If sirket.testerisim = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = sirket.testerisim
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@topluyukleme", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If sirket.topluyukleme = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = sirket.topluyukleme
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@wskullaniciad", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If sirket.wskullaniciad = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = sirket.wskullaniciad
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@wssifre", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If sirket.wssifre = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = sirket.wssifre
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@ipdikkat", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If sirket.ipdikkat = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = sirket.ipdikkat
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@tip", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If sirket.tip = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = sirket.tip
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@GetCarAddressInfo_yetki", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If sirket.GetCarAddressInfo_yetki = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = sirket.GetCarAddressInfo_yetki
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@GetDamageInformation_yetki", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If sirket.GetDamageInformation_yetki = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = sirket.GetDamageInformation_yetki
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@GetInfoInsuredPeople_yetki", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If sirket.GetInfoInsuredPeople_yetki = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = sirket.GetInfoInsuredPeople_yetki
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@LoadDamageInformation_yetki", SqlDbType.VarChar)
        param20.Direction = ParameterDirection.Input
        If sirket.LoadDamageInformation_yetki = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = sirket.LoadDamageInformation_yetki
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@LoadPolicyInformation_yetki", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If sirket.LoadPolicyInformation_yetki = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = sirket.LoadPolicyInformation_yetki
        End If
        komut.Parameters.Add(param21)


        Dim param22 As New SqlParameter("@maksservistalepdakika", SqlDbType.Int)
        param22.Direction = ParameterDirection.Input
        If sirket.maksservistalepdakika = 0 Then
            param22.Value = 0
        Else
            param22.Value = sirket.maksservistalepdakika
        End If
        komut.Parameters.Add(param22)



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
    Function bultek(ByVal pkey As String) As CLASSSIRKET

        Dim komut As New SqlCommand
        Dim doneceksirket As New CLASSSIRKET()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirket where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If


                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksirket

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek_sirketkodagore(ByVal sirketkod As String) As CLASSSIRKET

        Dim komut As New SqlCommand
        Dim doneceksirket As New CLASSSIRKET()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sirket where sirketkod=@sirketkod"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketkod", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketkod
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If


                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksirket

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
        Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM


        Dim varmi1, varmi2, varmi3 As String

        varmi1 = sirketacentebag_erisim.sirketvarmi(pkey)
        If varmi1 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirketin altında acenteler olduğundan bu şirketi silemezsiniz."
            resultset.etkilenen = 0
        End If

        varmi2 = sirketipbag_erisim.sirketvarmi(pkey)
        If varmi2 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirketin altında ip adresleri tanımlandığından bu şirketi silemezsiniz."
            resultset.etkilenen = 0
        End If

        varmi3 = sirketfaturabag_erisim.sirketvarmi(pkey)
        If varmi3 = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu şirketin altında fatura e-posta adresleri tanımlandığından bu şirketi silemezsiniz."
            resultset.etkilenen = 0
        End If


        If varmi1 = "Hayır" And varmi2 = "Hayır" And varmi3 = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "delete from sirket where pkey=@pkey"
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

        End If


        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSSIRKET)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirket As New CLASSSIRKET
        Dim sirketler As New List(Of CLASSSIRKET)
        komut.Connection = db_baglanti
        sqlstr = "select * from sirket order by sirketad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If

                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If

                sirketler.Add(New CLASSSIRKET(doneceksirket.pkey, _
                doneceksirket.sirketkod, doneceksirket.sirketad, doneceksirket.yetkilikisiadsoyad, _
                doneceksirket.adres, doneceksirket.ofistelefon, doneceksirket.faks, _
                doneceksirket.eposta, doneceksirket.aktifmi, doneceksirket.resimpkey, _
                doneceksirket.testerisim, doneceksirket.topluyukleme, doneceksirket.wskullaniciad, _
                doneceksirket.wssifre, doneceksirket.ipdikkat, doneceksirket.tip, _
                doneceksirket.GetCarAddressInfo_yetki, doneceksirket.GetDamageInformation_yetki, _
                doneceksirket.GetInfoInsuredPeople_yetki, doneceksirket.LoadDamageInformation_yetki, _
                doneceksirket.LoadPolicyInformation_yetki, doneceksirket.maksservistalepdakika))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketler

    End Function


    '---------------------------------doldur aktif seçenek-----------------------------------------
    Public Function dolduraktifsecenek(ByVal aktifsecenek As String) As List(Of CLASSSIRKET)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirket As New CLASSSIRKET
        Dim sirketler As New List(Of CLASSSIRKET)
        komut.Connection = db_baglanti

        If aktifsecenek <> "Tümü" Then
            sqlstr = "select * from sirket where aktifmi=@aktifmi order by sirketkod"
            komut = New SqlCommand(sqlstr, db_baglanti)
            Dim param1 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = aktifsecenek
            komut.Parameters.Add(param1)
        End If

        If aktifsecenek = "Tümü" Then
            sqlstr = "select * from sirket order by sirketkod"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If

                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If

                sirketler.Add(New CLASSSIRKET(doneceksirket.pkey, _
                doneceksirket.sirketkod, doneceksirket.sirketad, doneceksirket.yetkilikisiadsoyad, _
                doneceksirket.adres, doneceksirket.ofistelefon, doneceksirket.faks, _
                doneceksirket.eposta, doneceksirket.aktifmi, doneceksirket.resimpkey, _
                doneceksirket.testerisim, doneceksirket.topluyukleme, doneceksirket.wskullaniciad, _
                doneceksirket.wssifre, doneceksirket.ipdikkat, doneceksirket.tip, _
                doneceksirket.GetCarAddressInfo_yetki, doneceksirket.GetDamageInformation_yetki, _
                doneceksirket.GetInfoInsuredPeople_yetki, doneceksirket.LoadDamageInformation_yetki, _
                doneceksirket.LoadPolicyInformation_yetki,doneceksirket.maksservistalepdakika))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketler

    End Function


    '---------------------------------doldur aktif seçenek-----------------------------------------
    Public Function dolduraktifseceneksadecesirket(ByVal aktifsecenek As String) As List(Of CLASSSIRKET)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirket As New CLASSSIRKET
        Dim sirketler As New List(Of CLASSSIRKET)
        komut.Connection = db_baglanti

        If aktifsecenek <> "Tümü" Then
            sqlstr = "select * from sirket where aktifmi=@aktifmi and tip=@tip order by sirketkod"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@aktifmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = aktifsecenek
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@tip", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = "ŞİRKET"
            komut.Parameters.Add(param2)


        End If

        If aktifsecenek = "Tümü" Then
            sqlstr = "select * from sirket where tip=@tip order by sirketkod"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@tip", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "ŞİRKET"
            komut.Parameters.Add(param1)

        End If


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If

                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If

                sirketler.Add(New CLASSSIRKET(doneceksirket.pkey, _
                doneceksirket.sirketkod, doneceksirket.sirketad, doneceksirket.yetkilikisiadsoyad, _
                doneceksirket.adres, doneceksirket.ofistelefon, doneceksirket.faks, _
                doneceksirket.eposta, doneceksirket.aktifmi, doneceksirket.resimpkey, _
                doneceksirket.testerisim, doneceksirket.topluyukleme, doneceksirket.wskullaniciad, _
                doneceksirket.wssifre, doneceksirket.ipdikkat, doneceksirket.tip, _
                doneceksirket.GetCarAddressInfo_yetki, doneceksirket.GetDamageInformation_yetki, _
                doneceksirket.GetInfoInsuredPeople_yetki, doneceksirket.LoadDamageInformation_yetki, _
                doneceksirket.LoadPolicyInformation_yetki, doneceksirket.maksservistalepdakika))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketler

    End Function

    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSSIRKET)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirket As New CLASSSIRKET
        Dim sirketler As New List(Of CLASSSIRKET)
        komut.Connection = db_baglanti
        sqlstr = "select * from sirket where " + tablecol + " LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If

                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If


                sirketler.Add(New CLASSSIRKET(doneceksirket.pkey, _
                doneceksirket.sirketkod, doneceksirket.sirketad, doneceksirket.yetkilikisiadsoyad, _
                doneceksirket.adres, doneceksirket.ofistelefon, doneceksirket.faks, _
                doneceksirket.eposta, doneceksirket.aktifmi, doneceksirket.resimpkey, _
                doneceksirket.testerisim, doneceksirket.topluyukleme, doneceksirket.wskullaniciad, _
                doneceksirket.wssifre, doneceksirket.ipdikkat, doneceksirket.tip, _
                doneceksirket.GetCarAddressInfo_yetki, doneceksirket.GetDamageInformation_yetki, _
                doneceksirket.GetInfoInsuredPeople_yetki, doneceksirket.LoadDamageInformation_yetki, _
                doneceksirket.LoadPolicyInformation_yetki, doneceksirket.maksservistalepdakika))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sirketler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12 As String
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
        "<th>Düzenle</th>" + _
        "<th>Tip</th>" + _
        "<th>Şirket/Kurum Kodu</th>" + _
        "<th>Şirket/Kurum Adı</th>" + _
        "<th>Yetkili Ad Soyad</th>" + _
        "<th>Adresi</th>" + _
        "<th>Telefonu</th>" + _
        "<th>E-Posta</th>" + _
        "<th>Aktif mi?</th>" + _
        "<th>Bu Şirkete/Kuruma Bağlı Acenteler</th>" + _
        "<th>Yetkiler</th>" + _
        "<th>Dakikada Maks Servis Talebi</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '-----------TÜMÜ --------------------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from sirket"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "pkey" Then
            sqlstr = "select * from sirket where pkey=@kriter"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "yetkilikisiadsoyad" Then

            sqlstr = "select * from sirket where yetkilikisiadsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sirketkod, sirketad, yetkilikisiadsoyad, adres As String
        Dim ofistelefon, eposta, aktifmi As String
        Dim sirketebagliacenteler As New List(Of CLASSSIRKETACENTEBAG)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirketebagliacenteler_str As String = ""
        Dim tip As String
        Dim yetkilerstr As String
        Dim GetCarAddressInfo_yetki As String
        Dim GetDamageInformation_yetki As String
        Dim GetInfoInsuredPeople_yetki As String
        Dim LoadDamageInformation_yetki As String
        Dim LoadPolicyInformation_yetki As String
        Dim maksservistalepdakika As String

        Dim acente As New CLASSACENTE
        Dim acente_Erisim As New CLASSACENTE_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "sirketgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol2 = "<td>" + tip + "</td>"
                    Else
                        kol2 = "<td>" + "-" + "</td>"
                    End If


                    If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                        sirketkod = veri.Item("sirketkod")
                        kol3 = "<td>" + sirketkod + "</td>"
                    Else
                        kol3 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("sirketad") Is System.DBNull.Value Then
                        sirketad = veri.Item("sirketad")
                        kol4 = "<td>" + sirketad + "</td>"
                    Else
                        kol4 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                        yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                        kol5 = "<td>" + yetkilikisiadsoyad + "</td>"
                    Else
                        kol5 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("adres") Is System.DBNull.Value Then
                        adres = veri.Item("adres")
                        kol6 = "<td>" + adres + "</td>"
                    Else
                        kol6 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                        ofistelefon = veri.Item("ofistelefon")
                        kol7 = "<td>" + ofistelefon + "</td>"
                    Else
                        kol7 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("eposta") Is System.DBNull.Value Then
                        eposta = veri.Item("eposta")
                        kol8 = "<td>" + eposta + "</td>"
                    Else
                        kol8 = "<td>" + "-" + "</td>"
                    End If

                    If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                        aktifmi = veri.Item("aktifmi")
                        kol9 = "<td>" + aktifmi + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    sirketebagliacenteler_str = ""
                    sirketebagliacenteler = sirketacentebag_erisim.doldur_sirketinacenteleri(pkey)
                    For Each Item As CLASSSIRKETACENTEBAG In sirketebagliacenteler
                        acente = acente_Erisim.bultek(Item.acentepkey)
                        sirketebagliacenteler_str = sirketebagliacenteler_str + acente.acentead + "<br/>"
                    Next

                    kol10 = "<td>" + sirketebagliacenteler_str + "</td>"


                    'YETKİLER-----------------
                    If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                        GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                    Else
                        GetCarAddressInfo_yetki = "-"
                    End If
                    If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                        GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                    Else
                        GetDamageInformation_yetki = "-"
                    End If
                    If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                        GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                    Else
                        GetInfoInsuredPeople_yetki = "-"
                    End If
                    If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                        LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                    Else
                        LoadDamageInformation_yetki = "-"
                    End If
                    If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                        LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                    Else
                        LoadPolicyInformation_yetki = "-"
                    End If

                    kol11 = "<td>" + _
                    "<strong>GetCarAddressInfo:</strong>" + GetCarAddressInfo_yetki + "<br/>" + _
                    "<strong>GetDamageInformation:</strong>" + GetDamageInformation_yetki + "<br/>" + _
                    "<strong>GetInfoInsuredPeople:</strong>" + GetInfoInsuredPeople_yetki + "<br/>" + _
                    "<strong>LoadDamageInformation:</strong>" + LoadDamageInformation_yetki + "<br/>" + _
                    "<strong>LoadPolicyInformation:</strong>" + LoadPolicyInformation_yetki + "<br/>" + _
                    "</td>"


                    If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                        maksservistalepdakika = veri.Item("maksservistalepdakika")
                        kol12 = "<td>" + maksservistalepdakika + "</td></tr>"
                    Else
                        kol12 = "<td>-</td></tr>"
                    End If


                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
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

        sqlstr = "select * from sirket where " + tablecol + "=@kriter"

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



    '----------------------------------ŞİRKET KODU BUL---------------------------------------
    Public Function sirketkodubul() As String

        Dim donecekkod As String
        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from sirket"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            pkey = 1
        Else
            pkey = maxkayit1 + 1
        End If

        If pkey < 10 Then
            donecekkod = "00" + CStr(pkey)
        End If

        If pkey > 9 And pkey < 99 Then
            donecekkod = "0" + CStr(pkey)
        End If

        If pkey > 99 Then
            donecekkod = CStr(pkey)
        End If

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekkod

    End Function


    Function logoolustur(ByVal resimpkey As String) As String

        Dim donecek As String
        donecek = ""
        Dim imgsrc As String

        Dim tekresim As New CLASSTEKRESIM
        Dim tekresim_Erisim As New CLASSTEKRESIM_ERISIM
        tekresim = tekresim_Erisim.bultek(resimpkey)

        imgsrc = tekresim.dosyaad

        If tekresim.orjinalboyut = "Hayır" Then
            donecek = "<img src=" + Chr(34) + imgsrc + Chr(34) + _
            " width = " + Chr(34) + CStr(tekresim.resim_genislik) + "px" + Chr(34) + _
            " height=" + Chr(34) + CStr(tekresim.resim_yukseklik) + "px" + Chr(34) + " alt=" + Chr(34) + _
            tekresim.baslik + Chr(34) + "/>"
        End If

        If tekresim.orjinalboyut = "Evet" Then
            donecek = "<img src=" + Chr(34) + imgsrc + Chr(34) + _
            " alt=" + Chr(34) + tekresim.baslik + Chr(34) + "/>"
        End If

        Return donecek

    End Function



    '---------------------------------yetkiicin-----------------------------------------
    Function kullaniciadsifredogrumu(ByVal wskullaniciad As String, _
    ByVal wssifre As String) As CLASSSIRKET

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceksirket As New CLASSSIRKET
        Dim sirketler As New List(Of CLASSSIRKET)
        komut.Connection = db_baglanti
        sqlstr = "select * from sirket where wskullaniciad=@wskullaniciad and wssifre=@wssifre"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@wskullaniciad", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = wskullaniciad
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@wssifre", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = wssifre
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceksirket.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                    doneceksirket.sirketkod = veri.Item("sirketkod")
                End If

                If Not veri.Item("sirketad") Is System.DBNull.Value Then
                    doneceksirket.sirketad = veri.Item("sirketad")
                End If

                If Not veri.Item("yetkilikisiadsoyad") Is System.DBNull.Value Then
                    doneceksirket.yetkilikisiadsoyad = veri.Item("yetkilikisiadsoyad")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    doneceksirket.adres = veri.Item("adres")
                End If

                If Not veri.Item("ofistelefon") Is System.DBNull.Value Then
                    doneceksirket.ofistelefon = veri.Item("ofistelefon")
                End If

                If Not veri.Item("faks") Is System.DBNull.Value Then
                    doneceksirket.faks = veri.Item("faks")
                End If

                If Not veri.Item("eposta") Is System.DBNull.Value Then
                    doneceksirket.eposta = veri.Item("eposta")
                End If

                If Not veri.Item("aktifmi") Is System.DBNull.Value Then
                    doneceksirket.aktifmi = veri.Item("aktifmi")
                End If

                If Not veri.Item("resimpkey") Is System.DBNull.Value Then
                    doneceksirket.resimpkey = veri.Item("resimpkey")
                End If

                If Not veri.Item("testerisim") Is System.DBNull.Value Then
                    doneceksirket.testerisim = veri.Item("testerisim")
                End If

                If Not veri.Item("topluyukleme") Is System.DBNull.Value Then
                    doneceksirket.topluyukleme = veri.Item("topluyukleme")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceksirket.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceksirket.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    doneceksirket.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    doneceksirket.tip = veri.Item("tip")
                End If

                If Not veri.Item("GetCarAddressInfo_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetCarAddressInfo_yetki = veri.Item("GetCarAddressInfo_yetki")
                End If

                If Not veri.Item("GetDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetDamageInformation_yetki = veri.Item("GetDamageInformation_yetki")
                End If

                If Not veri.Item("GetInfoInsuredPeople_yetki") Is System.DBNull.Value Then
                    doneceksirket.GetInfoInsuredPeople_yetki = veri.Item("GetInfoInsuredPeople_yetki")
                End If

                If Not veri.Item("LoadDamageInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadDamageInformation_yetki = veri.Item("LoadDamageInformation_yetki")
                End If

                If Not veri.Item("LoadPolicyInformation_yetki") Is System.DBNull.Value Then
                    doneceksirket.LoadPolicyInformation_yetki = veri.Item("LoadPolicyInformation_yetki")
                End If


                If Not veri.Item("maksservistalepdakika") Is System.DBNull.Value Then
                    doneceksirket.maksservistalepdakika = veri.Item("maksservistalepdakika")
                End If


            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceksirket

    End Function

    Public Function ipadresi_yekilimi(ByVal sirketpkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_Erisim As New CLASSSERVİSAYAR_ERISIM
        Dim ipyetkilimi, ipadres As String

        Dim ip_erisim As New CLASSIP_ERISIM
        ipadres = ip_erisim.ipadresibul()

        servisayar = servisayar_Erisim.bultek(1)
        sirket = sirket_erisim.bultek(sirketpkey)

        If sirket.ipdikkat = "Hayır" Then
            result.durum = "Yetkili"
            result.hatastr = ""
            result.etkilenen = "1"
            Return result
        End If

        If sirket.ipdikkat = "Hayır" And servisayar.ipdikkat = "Hayır" Then
            result.durum = "Yetkili"
            result.hatastr = ""
            result.etkilenen = "1"
            Return result
        End If

        If sirket.ipdikkat = "Evet" Then
            If servisayar.ipdikkat = "Evet" Then
                If sirket.pkey <> 0 Then
                    Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
                    Dim ipadresleri As New List(Of CLASSSIRKETIPBAG)
                    ipadresleri = sirketipbag_erisim.doldur_ilgilisirket(sirket.pkey)
                    For Each Item As CLASSSIRKETIPBAG In ipadresleri
                        If ip_erisim.range(Item.cidrnotation, IPAddress.Parse(Item.ipadres), IPAddress.Parse(ipadres)) = "Evet" Then
                            ipyetkilimi = "Evet"
                        End If
                    Next
                    If ipyetkilimi = "Evet" Then
                        result.durum = "Yetkili"
                        result.hatastr = ""
                        result.etkilenen = "1"
                    End If
                    If ipyetkilimi = "Hayır" Then
                        result.durum = "Yetkisiz"
                        result.hatastr = "Bu IP adresi ile web servisine bağlanmaya yetkiniz yoktur."
                        result.etkilenen = "3"
                    End If
                End If 'servisayar.ipdikkat
            End If 'sirket.ipdikkat
        End If

        Return result

    End Function


    Public Function GetDamageInformation_yetkilimi(ByVal sirketpkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        Dim yetkilimi = "Evet"
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_erisim.bultek(sirketpkey)

        If sirket.GetDamageInformation_yetki = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 5
            result.hatastr = "GetDamageInfo servisine erişiminiz yoktur."
        End If

        If sirket.GetDamageInformation_yetki <> "Hayır" Then
            result.durum = "Evet"
            result.etkilenen = 0
            result.hatastr = "GetDamageInfo servisine erişiminiz yoktur."
        End If

        Return result

    End Function



    Public Function yetkilimi(ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal servisad As String) As CLADBOPRESULT

        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)

        Dim ipadres As String
        Dim ip_erisim As New CLASSIP_ERISIM
        ipadres = ip_erisim.ipadresibul()

        Dim result As New CLADBOPRESULT
        Dim sirket As New CLASSSIRKET
        Dim ipyetkilimi As String = "Hayır"

        sirket = kullaniciadsifredogrumu(wskullaniciad, wssifre)

        If sirket.pkey = 0 Then
            result.durum = "Yetkisiz"
            result.hatastr = "Kullanıcı adı yada şifre hatalı"
            result.etkilenen = 1
            Return result
        End If

        If sirket.pkey <> 0 Then
            If sirket.aktifmi = "Hayır" Then
                result.durum = "Yetkisiz"
                result.hatastr = "Şirket aktif değil"
                result.etkilenen = 2
                Return result
            End If
        End If

        If sirket.GetCarAddressInfo_yetki = "Hayır" And servisad = "GetCarAddressInfo" Then
            result.durum = "Yetkisiz"
            result.hatastr = "GetCarAddressInfo servisine erişiminiz yoktur."
            result.etkilenen = 4
            Return result
        End If

        If sirket.GetInfoInsuredPeople_yetki = "Hayır" And servisad = "GetInfoInsuredPeople" Then
            result.durum = "Yetkisiz"
            result.hatastr = "GetInfoInsuredPeople servisine erişiminiz yoktur."
            result.etkilenen = 6
            Return result
        End If
        If sirket.LoadDamageInformation_yetki = "Hayır" And servisad = "LoadDamageInformation" Then
            result.durum = "Yetkisiz"
            result.hatastr = "LoadDamageInformation servisine erişiminiz yoktur."
            result.etkilenen = 7
            Return result
        End If
        If sirket.LoadPolicyInformation_yetki = "Hayır" And servisad = "LoadPolicyInformation" Then
            result.durum = "Yetkisiz"
            result.hatastr = "LoadPolicyInformation servisine erişiminiz yoktur."
            result.etkilenen = 8
            Return result
        End If

        If sirket.GetDamageInformation_yetki = "Hayır" And servisad = "GetDamageInformation" Then
            result.durum = "Yetkisiz"
            result.hatastr = "GetDamageInformation servisine erişiminiz yoktur."
            result.etkilenen = 8
            Return result
        End If


        If sirket.pkey <> 0 Then
            If sirket.aktifmi = "Evet" Then
                If servisayar.ipdikkat = "Hayır" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                    Return result
                End If
                If sirket.ipdikkat = "Hayır" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                    Return result
                End If
            End If
        End If


        'ip adres kontrol et
        If sirket.ipdikkat = "Evet" Then
            If servisayar.ipdikkat = "Evet" Then
                If sirket.pkey <> 0 Then
                    Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
                    Dim ipadresleri As New List(Of CLASSSIRKETIPBAG)
                    ipadresleri = sirketipbag_erisim.doldur_ilgilisirket(sirket.pkey)
                    For Each Item As CLASSSIRKETIPBAG In ipadresleri
                        If ip_erisim.range(Item.cidrnotation, IPAddress.Parse(Item.ipadres), IPAddress.Parse(ip_erisim.ipadresibul)) = "Evet" Then
                            ipyetkilimi = "Evet"
                        End If
                    Next
                    If ipyetkilimi = "Evet" Then
                        result.durum = "Yetkili"
                        result.hatastr = ""
                        result.etkilenen = 1
                    End If
                    If ipyetkilimi = "Hayır" Then
                        result.durum = "Yetkisiz"
                        result.hatastr = "Bu IP adresi ile web servisine bağlanmaya yetkiniz yoktur."
                        result.etkilenen = 3
                    End If
                End If 'servisayar.ipdikkat
            End If 'sirket.ipdikkat

            'sifresi ip adresi her şeyi doğru ise birde maksimum servis talebi kotasını kontrol et. 
            If result.durum = "Yetkili" Then
                Dim kotaresult As New CLADBOPRESULT
                Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
                kotaresult = logservis_erisim.kotakontrol(sirket.pkey)
                'kotayı aşmış
                If kotaresult.durum = "Evet" Then
                    result.durum = "Yetkisiz"
                    result.hatastr = kotaresult.hatastr
                    result.etkilenen = 0
                    Return result
                End If
            End If

            Return result

        End If 'kullanıcı adi sifre dogru!

    End Function


    Public Function yetkilimi2(ByVal wskullaniciad As String, ByVal wssifre As String) As CLADBOPRESULT

        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)

        Dim ipadres As String
        Dim ip_erisim As New CLASSIP_ERISIM
        ipadres = ip_erisim.ipadresibul()

        Dim result As New CLADBOPRESULT
        Dim sirket As New CLASSSIRKET
        Dim ipyetkilimi As String = "Hayır"

        sirket = kullaniciadsifredogrumu(wskullaniciad, wssifre)

        If sirket.pkey = 0 Then
            result.durum = "Yetkisiz"
            result.hatastr = "Kullanıcı adı yada şifre hatalı"
            result.etkilenen = 1
            Return result
        End If

        If sirket.pkey <> 0 Then
            If sirket.aktifmi = "Hayır" Then
                result.durum = "Yetkisiz"
                result.hatastr = "Şirket aktif değil"
                result.etkilenen = 2
                Return result
            End If
        End If


        If sirket.pkey <> 0 Then
            If sirket.aktifmi = "Evet" Then
                If servisayar.ipdikkat = "Hayır" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                    Return result
                End If
                If sirket.ipdikkat = "Hayır" Then
                    result.durum = "Yetkili"
                    result.hatastr = ""
                    result.etkilenen = 1
                    Return result
                End If
            End If
        End If


        'ip adres kontrol et
        If sirket.ipdikkat = "Evet" Then
            If servisayar.ipdikkat = "Evet" Then
                If sirket.pkey <> 0 Then
                    Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
                    Dim ipadresleri As New List(Of CLASSSIRKETIPBAG)
                    ipadresleri = sirketipbag_erisim.doldur_ilgilisirket(sirket.pkey)
                    For Each Item As CLASSSIRKETIPBAG In ipadresleri
                        If ip_erisim.range(Item.cidrnotation, IPAddress.Parse(Item.ipadres), IPAddress.Parse(ip_erisim.ipadresibul)) = "Evet" Then
                            ipyetkilimi = "Evet"
                        End If
                    Next
                    If ipyetkilimi = "Evet" Then
                        result.durum = "Yetkili"
                        result.hatastr = ""
                        result.etkilenen = 1
                    End If
                    If ipyetkilimi = "Hayır" Then
                        result.durum = "Yetkisiz"
                        result.hatastr = "Bu IP adresi ile web servisine bağlanmaya yetkiniz yoktur."
                        result.etkilenen = 3
                    End If
                End If 'servisayar.ipdikkat
            End If 'sirket.ipdikkat

            'sifresi ip adresi her şeyi doğru ise birde maksimum servis talebi kotasını kontrol et. 
            If result.durum = "Yetkili" Then
                Dim kotaresult As New CLADBOPRESULT
                Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
                kotaresult = logservis_erisim.kotakontrol(sirket.pkey)
                'kotayı aşmış
                If kotaresult.durum = "Evet" Then
                    result.durum = "Yetkisiz"
                    result.hatastr = kotaresult.hatastr
                    result.etkilenen = 0
                    Return result
                End If
            End If

            Return result

        End If 'kullanıcı adi sifre dogru!

    End Function


 

    Public Function tumipyetkilimi() As String

        Dim ip_erisim As New CLASSIP_ERISIM
        Dim yetkilimi As String = "Hayır"
        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
        servisayar = servisayar_erisim.bultek(1)

        If servisayar.ipdikkat = "Hayır" Then
            yetkilimi = "Evet"
            Return yetkilimi
        End If

        If servisayar.ipdikkat = "Evet" Then
            Dim baglanilanipadresi
            baglanilanipadresi = ip_erisim.ipadresibul()
            Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
            Dim sirketipbaglar As New List(Of CLASSSIRKETIPBAG)
            sirketipbaglar = sirketipbag_erisim.doldur()
            For Each Item As CLASSSIRKETIPBAG In sirketipbaglar
                If Item.ipadres = baglanilanipadresi Then
                    yetkilimi = "Evet"
                    Return yetkilimi
                End If
            Next
        End If

        Return yetkilimi

    End Function


    Public Function sirketsecmeinputolustur(ByVal acentepkey As String, _
    ByVal op As String) As String

        Dim inputcheck As String = ""
        Dim teksatir As String = ""
        Dim tumsirketler As New List(Of CLASSSIRKET)
        tumsirketler = doldur()
        Dim donecek As String = ""
        Dim kol1 As String
        Dim kol2 As String
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim ilgilisirketler As New List(Of CLASSSIRKETACENTEBAG)

        Dim basliklar, tabloson As String
        Dim valuestr As String = ""
        Dim v_checked As String

        basliklar = "<table id=sonuctable class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Seçiniz</th>" + _
        "<th>Şirket İsmi</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        For Each itemsirket As CLASSSIRKET In tumsirketler

            If op = "duzenle" Then

                ilgilisirketler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(acentepkey)

                For Each itemilgilisirket As CLASSSIRKETACENTEBAG In ilgilisirketler
                    v_checked = ""
                    If itemsirket.pkey = itemilgilisirket.sirketpkey Then
                        v_checked = " checked='true'"
                        Exit For
                    End If
                Next

                kol1 = "<tr><td><input type=" + Chr(34) + "checkbox" + Chr(34) + _
                " name=" + Chr(34) + "A_" + CStr(itemsirket.pkey) + Chr(34) + _
                " class=" + Chr(34) + "sirketcheckbox" + Chr(34) + _
                " value=" + Chr(34) + CStr(itemsirket.pkey) + Chr(34) + v_checked + ">" + "</td>"

                kol2 = "<td>" + itemsirket.sirketad + "</td></tr>"

                teksatir = teksatir + kol1 + kol2


            End If

            If op = "yenikayit" Then

                kol1 = "<tr><td><input type=" + Chr(34) + "checkbox" + Chr(34) + _
                " id=" + Chr(34) + "A_" + CStr(itemsirket.pkey) + Chr(34) + _
                " name=" + Chr(34) + "A_" + CStr(itemsirket.pkey) + Chr(34) + _
                " class=" + Chr(34) + "sirketcheckbox" + Chr(34) + _
                " value=" + Chr(34) + CStr(itemsirket.pkey) + Chr(34) + ">" + "</td>"

                kol2 = "<td>" + itemsirket.sirketad + "</td></tr>"

                teksatir = teksatir + kol1 + kol2

            End If

        Next

        donecek = basliklar + teksatir + tabloson
        Return donecek

    End Function



    Public Function toplamsirketsayisi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from sirket"
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


    Public Function toplamsirketsayisi_tipegore(ByVal tip As String) As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from sirket where tip=@tip"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tip", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tip
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


End Class