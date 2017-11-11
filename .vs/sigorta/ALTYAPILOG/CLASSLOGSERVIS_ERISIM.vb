Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSLOGSERVIS_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim logservis As New CLASSLOGSERVIS
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal logservis As CLASSLOGSERVIS) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into logservis values (@pkey," + _
        "@tarih,@sirketpkey,@servisad,@resultcode," + _
        "@errorinfocode,@errorinfomessage,@insertedcnt,@updatedcnt," + _
        "@p_FirmCode,@p_ProductCode,@p_AgencyCode,@p_PolicyNumber," + _
        "@p_TecditNumber,@p_ZeylCode,@p_ZeylNo,@p_ProductType,@d_FirmCode," + _
        "@d_ProductCode,@d_AgencyCode,@d_PolicyNumber,@d_TecditNumber," + _
        "@d_FileNo,@d_RequestNo,@d_ProductType,@gonderilenxml,@wskullaniciad," + _
        "@wssifre,@suphelimi,@suphelikod,@suphelimesaj,@getdamagelog,@hesaplog,@ipadres)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If logservis.tarih Is Nothing Or logservis.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = logservis.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If logservis.sirketpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = logservis.sirketpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@servisad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If logservis.servisad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = logservis.servisad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@resultcode", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If logservis.resultcode = 0 Then
            param5.Value = 0
        Else
            param5.Value = logservis.resultcode
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@errorinfocode", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If logservis.errorinfocode = 0 Then
            param6.Value = 0
        Else
            param6.Value = logservis.errorinfocode
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@errorinfomessage", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If logservis.errorinfomessage = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = logservis.errorinfomessage
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@insertedcnt", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If logservis.insertedcnt = 0 Then
            param8.Value = 0
        Else
            param8.Value = logservis.insertedcnt
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@updatedcnt", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If logservis.updatedcnt = 0 Then
            param9.Value = 0
        Else
            param9.Value = logservis.updatedcnt
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@p_FirmCode", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If logservis.p_FirmCode = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = logservis.p_FirmCode
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@p_ProductCode", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If logservis.p_ProductCode = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = logservis.p_ProductCode
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@p_AgencyCode", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If logservis.p_AgencyCode = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = logservis.p_AgencyCode
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@p_PolicyNumber", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If logservis.p_PolicyNumber = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = logservis.p_PolicyNumber
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@p_TecditNumber", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If logservis.p_TecditNumber = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = logservis.p_TecditNumber
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@p_ZeylCode", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If logservis.p_ZeylCode = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = logservis.p_ZeylCode
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@p_ZeylNo", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If logservis.p_ZeylNo = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = logservis.p_ZeylNo
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@p_ProductType", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If logservis.p_ProductType = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = logservis.p_ProductType
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@d_FirmCode", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If logservis.d_FirmCode = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = logservis.d_FirmCode
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@d_ProductCode", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If logservis.d_ProductCode = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = logservis.d_ProductCode
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@d_AgencyCode", SqlDbType.VarChar)
        param20.Direction = ParameterDirection.Input
        If logservis.d_AgencyCode = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = logservis.d_AgencyCode
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@d_PolicyNumber", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If logservis.d_PolicyNumber = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = logservis.d_PolicyNumber
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@d_TecditNumber", SqlDbType.VarChar)
        param22.Direction = ParameterDirection.Input
        If logservis.d_TecditNumber = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = logservis.d_TecditNumber
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@d_FileNo", SqlDbType.VarChar)
        param23.Direction = ParameterDirection.Input
        If logservis.d_FileNo = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = logservis.d_FileNo
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@d_RequestNo", SqlDbType.VarChar)
        param24.Direction = ParameterDirection.Input
        If logservis.d_RequestNo = "" Then
            param24.Value = System.DBNull.Value
        Else
            param24.Value = logservis.d_RequestNo
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@d_ProductType", SqlDbType.VarChar)
        param25.Direction = ParameterDirection.Input
        If logservis.d_ProductType = "" Then
            param25.Value = System.DBNull.Value
        Else
            param25.Value = logservis.d_ProductType
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@gonderilenxml", SqlDbType.Text)
        param26.Direction = ParameterDirection.Input
        If logservis.gonderilenxml = "" Then
            param26.Value = System.DBNull.Value
        Else
            param26.Value = logservis.gonderilenxml
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@wskullaniciad", SqlDbType.VarChar)
        param27.Direction = ParameterDirection.Input
        If logservis.wskullaniciad = "" Then
            param27.Value = System.DBNull.Value
        Else
            param27.Value = logservis.wskullaniciad
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@wssifre", SqlDbType.VarChar)
        param28.Direction = ParameterDirection.Input
        If logservis.wssifre = "" Then
            param28.Value = System.DBNull.Value
        Else
            param28.Value = logservis.wssifre
        End If
        komut.Parameters.Add(param28)


        Dim param29 As New SqlParameter("@suphelimi", SqlDbType.VarChar)
        param29.Direction = ParameterDirection.Input
        If logservis.suphelimi = "" Then
            param29.Value = System.DBNull.Value
        Else
            param29.Value = logservis.suphelimi
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@suphelikod", SqlDbType.Int)
        param30.Direction = ParameterDirection.Input
        If logservis.suphelikod = 0 Then
            param30.Value = 0
        Else
            param30.Value = logservis.suphelikod
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@suphelimesaj", SqlDbType.VarChar)
        param31.Direction = ParameterDirection.Input
        If logservis.suphelimesaj = "" Then
            param31.Value = System.DBNull.Value
        Else
            param31.Value = logservis.suphelimesaj
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@getdamagelog", SqlDbType.Text)
        param32.Direction = ParameterDirection.Input
        If logservis.getdamagelog = "" Then
            param32.Value = System.DBNull.Value
        Else
            param32.Value = logservis.getdamagelog
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@hesaplog", SqlDbType.Text)
        param33.Direction = ParameterDirection.Input
        If logservis.hesaplog = "" Then
            param33.Value = System.DBNull.Value
        Else
            param33.Value = logservis.hesaplog
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@ipadres", SqlDbType.VarChar)
        param34.Direction = ParameterDirection.Input
        If logservis.ipadres = "" Then
            param34.Value = System.DBNull.Value
        Else
            param34.Value = logservis.ipadres
        End If
        komut.Parameters.Add(param34)

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
        sqlstr = "select max(pkey) from logservis"
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
    Function Duzenle(ByVal logservis As CLASSLOGSERVIS) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update logservis set " + _
        "tarih=@tarih," + _
        "sirketpkey=@sirketpkey," + _
        "servisad=@servisad," + _
        "resultcode=@resultcode," + _
        "errorinfocode=@errorinfocode," + _
        "errorinfomessage=@errorinfomessage," + _
        "insertedcnt=@insertedcnt," + _
        "updatedcnt=@updatedcnt," + _
        "p_FirmCode=@p_FirmCode," + _
        "p_ProductCode=@p_ProductCode," + _
        "p_AgencyCode=@p_AgencyCode," + _
        "p_PolicyNumber=@p_PolicyNumber," + _
        "p_TecditNumber=@p_TecditNumber," + _
        "p_ZeylCode=@p_ZeylCode," + _
        "p_ZeylNo=@p_ZeylNo," + _
        "p_ProductType=@p_ProductType," + _
        "d_FirmCode=@d_FirmCode," + _
        "d_ProductCode=@d_ProductCode," + _
        "d_AgencyCode=@d_AgencyCode," + _
        "d_PolicyNumber=@d_PolicyNumber," + _
        "d_TecditNumber=@d_TecditNumber," + _
        "d_FileNo=@d_FileNo," + _
        "d_RequestNo=@d_RequestNo," + _
        "d_ProductType=@d_ProductType," + _
        "gonderilenxml=@gonderilenxml," + _
        "wskullaniciad=@wskullaniciad," + _
        "wssifre=@wssifre," + _
        "suphelimi=@suphelimi," + _
        "suphelikod=@suphelikod," + _
        "suphelimesaj=@suphelimesaj," + _
        "getdamagelog=@getdamagelog," + _
        "hesaplog=@hesaplog," + _
        "ipadres=@ipadres" + _
        " where pkey=@pkey"


        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = logservis.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If logservis.tarih Is Nothing Or logservis.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = logservis.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If logservis.sirketpkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = logservis.sirketpkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@servisad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If logservis.servisad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = logservis.servisad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@resultcode", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If logservis.resultcode = 0 Then
            param5.Value = 0
        Else
            param5.Value = logservis.resultcode
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@errorinfocode", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If logservis.errorinfocode = 0 Then
            param6.Value = 0
        Else
            param6.Value = logservis.errorinfocode
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@errorinfomessage", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If logservis.errorinfomessage = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = logservis.errorinfomessage
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@insertedcnt", SqlDbType.Int)
        param8.Direction = ParameterDirection.Input
        If logservis.insertedcnt = 0 Then
            param8.Value = 0
        Else
            param8.Value = logservis.insertedcnt
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@updatedcnt", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If logservis.updatedcnt = 0 Then
            param9.Value = 0
        Else
            param9.Value = logservis.updatedcnt
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@p_FirmCode", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If logservis.p_FirmCode = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = logservis.p_FirmCode
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@p_ProductCode", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If logservis.p_ProductCode = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = logservis.p_ProductCode
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@p_AgencyCode", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If logservis.p_AgencyCode = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = logservis.p_AgencyCode
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@p_PolicyNumber", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If logservis.p_PolicyNumber = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = logservis.p_PolicyNumber
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@p_TecditNumber", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If logservis.p_TecditNumber = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = logservis.p_TecditNumber
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@p_ZeylCode", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If logservis.p_ZeylCode = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = logservis.p_ZeylCode
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@p_ZeylNo", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If logservis.p_ZeylNo = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = logservis.p_ZeylNo
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@p_ProductType", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If logservis.p_ProductType = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = logservis.p_ProductType
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@d_FirmCode", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If logservis.d_FirmCode = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = logservis.d_FirmCode
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@d_ProductCode", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If logservis.d_ProductCode = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = logservis.d_ProductCode
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@d_AgencyCode", SqlDbType.VarChar)
        param20.Direction = ParameterDirection.Input
        If logservis.d_AgencyCode = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = logservis.d_AgencyCode
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@d_PolicyNumber", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If logservis.d_PolicyNumber = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = logservis.d_PolicyNumber
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@d_TecditNumber", SqlDbType.VarChar)
        param22.Direction = ParameterDirection.Input
        If logservis.d_TecditNumber = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = logservis.d_TecditNumber
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@d_FileNo", SqlDbType.VarChar)
        param23.Direction = ParameterDirection.Input
        If logservis.d_FileNo = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = logservis.d_FileNo
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@d_RequestNo", SqlDbType.VarChar)
        param24.Direction = ParameterDirection.Input
        If logservis.d_RequestNo = "" Then
            param24.Value = System.DBNull.Value
        Else
            param24.Value = logservis.d_RequestNo
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@d_ProductType", SqlDbType.VarChar)
        param25.Direction = ParameterDirection.Input
        If logservis.d_ProductType = "" Then
            param25.Value = System.DBNull.Value
        Else
            param25.Value = logservis.d_ProductType
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@gonderilenxml", SqlDbType.Text)
        param26.Direction = ParameterDirection.Input
        If logservis.gonderilenxml = "" Then
            param26.Value = System.DBNull.Value
        Else
            param26.Value = logservis.gonderilenxml
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@wskullaniciad", SqlDbType.VarChar)
        param27.Direction = ParameterDirection.Input
        If logservis.wskullaniciad = "" Then
            param27.Value = System.DBNull.Value
        Else
            param27.Value = logservis.wskullaniciad
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@wssifre", SqlDbType.VarChar)
        param28.Direction = ParameterDirection.Input
        If logservis.wssifre = "" Then
            param28.Value = System.DBNull.Value
        Else
            param28.Value = logservis.wssifre
        End If
        komut.Parameters.Add(param28)


        Dim param29 As New SqlParameter("@suphelimi", SqlDbType.VarChar)
        param29.Direction = ParameterDirection.Input
        If logservis.suphelimi = "" Then
            param29.Value = System.DBNull.Value
        Else
            param29.Value = logservis.suphelimi
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@suphelikod", SqlDbType.Int)
        param30.Direction = ParameterDirection.Input
        If logservis.suphelikod = 0 Then
            param30.Value = 0
        Else
            param30.Value = logservis.suphelikod
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@suphelimesaj", SqlDbType.VarChar)
        param31.Direction = ParameterDirection.Input
        If logservis.suphelimesaj = "" Then
            param31.Value = System.DBNull.Value
        Else
            param31.Value = logservis.suphelimesaj
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@getdamagelog", SqlDbType.Text)
        param32.Direction = ParameterDirection.Input
        If logservis.getdamagelog = "" Then
            param32.Value = System.DBNull.Value
        Else
            param32.Value = logservis.getdamagelog
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@hesaplog", SqlDbType.Text)
        param33.Direction = ParameterDirection.Input
        If logservis.hesaplog = "" Then
            param33.Value = System.DBNull.Value
        Else
            param33.Value = logservis.hesaplog
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@ipadres", SqlDbType.VarChar)
        param34.Direction = ParameterDirection.Input
        If logservis.ipadres = "" Then
            param34.Value = System.DBNull.Value
        Else
            param34.Value = logservis.ipadres
        End If
        komut.Parameters.Add(param34)


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
    Function bultek(ByVal pkey As String) As CLASSLOGSERVIS

        Dim komut As New SqlCommand
        Dim doneceklogservis As New CLASSLOGSERVIS()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from logservis where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceklogservis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    doneceklogservis.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceklogservis.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("servisad") Is System.DBNull.Value Then
                    doneceklogservis.servisad = veri.Item("servisad")
                End If

                If Not veri.Item("resultcode") Is System.DBNull.Value Then
                    doneceklogservis.resultcode = veri.Item("resultcode")
                End If

                If Not veri.Item("errorinfocode") Is System.DBNull.Value Then
                    doneceklogservis.errorinfocode = veri.Item("errorinfocode")
                End If

                If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                    doneceklogservis.errorinfomessage = veri.Item("errorinfomessage")
                End If

                If Not veri.Item("insertedcnt") Is System.DBNull.Value Then
                    doneceklogservis.insertedcnt = veri.Item("insertedcnt")
                End If

                If Not veri.Item("updatedcnt") Is System.DBNull.Value Then
                    doneceklogservis.updatedcnt = veri.Item("updatedcnt")
                End If

                If Not veri.Item("p_FirmCode") Is System.DBNull.Value Then
                    doneceklogservis.p_FirmCode = veri.Item("p_FirmCode")
                End If

                If Not veri.Item("p_ProductCode") Is System.DBNull.Value Then
                    doneceklogservis.p_ProductCode = veri.Item("p_ProductCode")
                End If

                If Not veri.Item("p_AgencyCode") Is System.DBNull.Value Then
                    doneceklogservis.p_AgencyCode = veri.Item("p_AgencyCode")
                End If

                If Not veri.Item("p_PolicyNumber") Is System.DBNull.Value Then
                    doneceklogservis.p_PolicyNumber = veri.Item("p_PolicyNumber")
                End If

                If Not veri.Item("p_TecditNumber") Is System.DBNull.Value Then
                    doneceklogservis.p_TecditNumber = veri.Item("p_TecditNumber")
                End If

                If Not veri.Item("p_ZeylCode") Is System.DBNull.Value Then
                    doneceklogservis.p_ZeylCode = veri.Item("p_ZeylCode")
                End If

                If Not veri.Item("p_ZeylNo") Is System.DBNull.Value Then
                    doneceklogservis.p_ZeylNo = veri.Item("p_ZeylNo")
                End If

                If Not veri.Item("p_ProductType") Is System.DBNull.Value Then
                    doneceklogservis.p_ProductType = veri.Item("p_ProductType")
                End If

                If Not veri.Item("d_FirmCode") Is System.DBNull.Value Then
                    doneceklogservis.d_FirmCode = veri.Item("d_FirmCode")
                End If

                If Not veri.Item("d_ProductCode") Is System.DBNull.Value Then
                    doneceklogservis.d_ProductCode = veri.Item("d_ProductCode")
                End If

                If Not veri.Item("d_AgencyCode") Is System.DBNull.Value Then
                    doneceklogservis.d_AgencyCode = veri.Item("d_AgencyCode")
                End If

                If Not veri.Item("d_PolicyNumber") Is System.DBNull.Value Then
                    doneceklogservis.d_PolicyNumber = veri.Item("d_PolicyNumber")
                End If

                If Not veri.Item("d_TecditNumber") Is System.DBNull.Value Then
                    doneceklogservis.d_TecditNumber = veri.Item("d_TecditNumber")
                End If

                If Not veri.Item("d_FileNo") Is System.DBNull.Value Then
                    doneceklogservis.d_FileNo = veri.Item("d_FileNo")
                End If

                If Not veri.Item("d_RequestNo") Is System.DBNull.Value Then
                    doneceklogservis.d_RequestNo = veri.Item("d_RequestNo")
                End If

                If Not veri.Item("d_ProductType") Is System.DBNull.Value Then
                    doneceklogservis.d_ProductType = veri.Item("d_ProductType")
                End If

                If Not veri.Item("gonderilenxml") Is System.DBNull.Value Then
                    doneceklogservis.gonderilenxml = veri.Item("gonderilenxml")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceklogservis.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceklogservis.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("suphelimi") Is System.DBNull.Value Then
                    doneceklogservis.suphelimi = veri.Item("suphelimi")
                End If

                If Not veri.Item("suphelikod") Is System.DBNull.Value Then
                    doneceklogservis.suphelikod = veri.Item("suphelikod")
                End If

                If Not veri.Item("suphelimesaj") Is System.DBNull.Value Then
                    doneceklogservis.suphelimesaj = veri.Item("suphelimesaj")
                End If

                If Not veri.Item("getdamagelog") Is System.DBNull.Value Then
                    doneceklogservis.getdamagelog = veri.Item("getdamagelog")
                End If

                If Not veri.Item("hesaplog") Is System.DBNull.Value Then
                    doneceklogservis.hesaplog = veri.Item("hesaplog")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    doneceklogservis.ipadres = veri.Item("ipadres")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return doneceklogservis

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSLOGSERVIS)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim doneceklogservis As New CLASSLOGSERVIS
        Dim logservisler As New List(Of CLASSLOGSERVIS)
        komut.Connection = db_baglanti
        sqlstr = "select * from logservis"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    doneceklogservis.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    doneceklogservis.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    doneceklogservis.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("servisad") Is System.DBNull.Value Then
                    doneceklogservis.servisad = veri.Item("servisad")
                End If

                If Not veri.Item("resultcode") Is System.DBNull.Value Then
                    doneceklogservis.resultcode = veri.Item("resultcode")
                End If

                If Not veri.Item("errorinfocode") Is System.DBNull.Value Then
                    doneceklogservis.errorinfocode = veri.Item("errorinfocode")
                End If

                If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                    doneceklogservis.errorinfomessage = veri.Item("errorinfomessage")
                End If

                If Not veri.Item("insertedcnt") Is System.DBNull.Value Then
                    doneceklogservis.insertedcnt = veri.Item("insertedcnt")
                End If

                If Not veri.Item("updatedcnt") Is System.DBNull.Value Then
                    doneceklogservis.updatedcnt = veri.Item("updatedcnt")
                End If

                If Not veri.Item("p_FirmCode") Is System.DBNull.Value Then
                    doneceklogservis.p_FirmCode = veri.Item("p_FirmCode")
                End If

                If Not veri.Item("p_ProductCode") Is System.DBNull.Value Then
                    doneceklogservis.p_ProductCode = veri.Item("p_ProductCode")
                End If

                If Not veri.Item("p_AgencyCode") Is System.DBNull.Value Then
                    doneceklogservis.p_AgencyCode = veri.Item("p_AgencyCode")
                End If

                If Not veri.Item("p_PolicyNumber") Is System.DBNull.Value Then
                    doneceklogservis.p_PolicyNumber = veri.Item("p_PolicyNumber")
                End If

                If Not veri.Item("p_TecditNumber") Is System.DBNull.Value Then
                    doneceklogservis.p_TecditNumber = veri.Item("p_TecditNumber")
                End If

                If Not veri.Item("p_ZeylCode") Is System.DBNull.Value Then
                    doneceklogservis.p_ZeylCode = veri.Item("p_ZeylCode")
                End If

                If Not veri.Item("p_ZeylNo") Is System.DBNull.Value Then
                    doneceklogservis.p_ZeylNo = veri.Item("p_ZeylNo")
                End If


                If Not veri.Item("p_ProductType") Is System.DBNull.Value Then
                    doneceklogservis.p_ProductType = veri.Item("p_ProductType")
                End If


                If Not veri.Item("d_FirmCode") Is System.DBNull.Value Then
                    doneceklogservis.d_FirmCode = veri.Item("d_FirmCode")
                End If

                If Not veri.Item("d_ProductCode") Is System.DBNull.Value Then
                    doneceklogservis.d_ProductCode = veri.Item("d_ProductCode")
                End If

                If Not veri.Item("d_AgencyCode") Is System.DBNull.Value Then
                    doneceklogservis.d_AgencyCode = veri.Item("d_AgencyCode")
                End If

                If Not veri.Item("d_PolicyNumber") Is System.DBNull.Value Then
                    doneceklogservis.d_PolicyNumber = veri.Item("d_PolicyNumber")
                End If

                If Not veri.Item("d_TecditNumber") Is System.DBNull.Value Then
                    doneceklogservis.d_TecditNumber = veri.Item("d_TecditNumber")
                End If

                If Not veri.Item("d_FileNo") Is System.DBNull.Value Then
                    doneceklogservis.d_FileNo = veri.Item("d_FileNo")
                End If

                If Not veri.Item("d_RequestNo") Is System.DBNull.Value Then
                    doneceklogservis.d_RequestNo = veri.Item("d_RequestNo")
                End If

                If Not veri.Item("d_ProductType") Is System.DBNull.Value Then
                    doneceklogservis.d_ProductType = veri.Item("d_ProductType")
                End If

                If Not veri.Item("gonderilenxml") Is System.DBNull.Value Then
                    doneceklogservis.gonderilenxml = veri.Item("gonderilenxml")
                End If

                If Not veri.Item("wskullaniciad") Is System.DBNull.Value Then
                    doneceklogservis.wskullaniciad = veri.Item("wskullaniciad")
                End If

                If Not veri.Item("wssifre") Is System.DBNull.Value Then
                    doneceklogservis.wssifre = veri.Item("wssifre")
                End If

                If Not veri.Item("suphelimi") Is System.DBNull.Value Then
                    doneceklogservis.suphelimi = veri.Item("suphelimi")
                End If

                If Not veri.Item("suphelikod") Is System.DBNull.Value Then
                    doneceklogservis.suphelikod = veri.Item("suphelikod")
                End If

                If Not veri.Item("suphelimesaj") Is System.DBNull.Value Then
                    doneceklogservis.suphelimesaj = veri.Item("suphelimesaj")
                End If

                If Not veri.Item("getdamagelog") Is System.DBNull.Value Then
                    doneceklogservis.getdamagelog = veri.Item("getdamagelog")
                End If

                If Not veri.Item("hesaplog") Is System.DBNull.Value Then
                    doneceklogservis.hesaplog = veri.Item("hesaplog")
                End If

                If Not veri.Item("ipadres") Is System.DBNull.Value Then
                    doneceklogservis.ipadres = veri.Item("ipadres")
                End If

                logservisler.Add(New CLASSLOGSERVIS(doneceklogservis.pkey, _
                doneceklogservis.tarih, doneceklogservis.sirketpkey, doneceklogservis.servisad, _
                doneceklogservis.resultcode, doneceklogservis.errorinfocode, _
                doneceklogservis.errorinfomessage, doneceklogservis.insertedcnt, _
                doneceklogservis.updatedcnt, doneceklogservis.p_FirmCode, _
                doneceklogservis.p_ProductCode, doneceklogservis.p_AgencyCode, _
                doneceklogservis.p_PolicyNumber, doneceklogservis.p_TecditNumber, _
                doneceklogservis.p_ZeylCode, doneceklogservis.p_ZeylNo, doneceklogservis.p_ProductType, _
                doneceklogservis.d_FirmCode, doneceklogservis.d_ProductCode, doneceklogservis.d_AgencyCode, _
                doneceklogservis.d_PolicyNumber, doneceklogservis.d_TecditNumber, _
                doneceklogservis.d_FileNo, doneceklogservis.d_RequestNo, doneceklogservis.d_ProductType, _
                doneceklogservis.gonderilenxml, doneceklogservis.wskullaniciad, _
                doneceklogservis.wssifre, doneceklogservis.suphelimi, _
                doneceklogservis.suphelikod, doneceklogservis.suphelimesaj, _
                doneceklogservis.getdamagelog, doneceklogservis.hesaplog, doneceklogservis.ipadres))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return logservisler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarih</th>" + _
        "<th>Şirket</th>" + _
        "<th>Çağırılan Servis</th>" + _
        "<th>Sonuç</th>" + _
        "<th>Poliçe Bilgisi</th>" + _
        "<th>Hasar Bilgisi</th>" + _
        "<th>Kaydedilen Kayıt Sayısı</th>" + _
        "<th>Güncellenen Kayıt Sayısı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"


        'WORD EXCEL İÇİN---------------------------------------------------
        Table.Columns.Add("Tarih", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Çağırılan Servis", GetType(String))
        table.Columns.Add("Sonuç", GetType(String))
        table.Columns.Add("Poliçe Bilgisi", GetType(String))
        table.Columns.Add("Hasar Bilgisi", GetType(String))
        table.Columns.Add("Kaydedilen Kayıt Sayısı", GetType(String))
        table.Columns.Add("Güncellenen Kayıt Sayısı", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(8)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarih", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Çağırılan Servis", fbaslik))
        pdftable.AddCell(New Phrase("Sonuç", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe Bilgisi", fbaslik))
        pdftable.AddCell(New Phrase("Hasar Bilgisi", fbaslik))
        pdftable.AddCell(New Phrase("Kaydedilen Kayıt Sayısı", fbaslik))
        pdftable.AddCell(New Phrase("Güncelenen Kayıt Sayısı", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET


        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            sqldevam = sqldevam + " and sirketpkey=@sirketpkey"
        End If

        'servis ad seçilmişse
        If HttpContext.Current.Session("servisad") <> "0" Then
            sqldevam = sqldevam + " and servisad=@servisad"
        End If

        'sonuç seçilmişse
        If HttpContext.Current.Session("resultcode") <> "Tümü" Then
            sqldevam = sqldevam + " and resultcode=@resultcode"
        End If

        'gönderilen xml yazılmış ise
        If HttpContext.Current.Session("gonderilenxml") <> "" Then
            sqldevam = sqldevam + " and gonderilenxml LIKE '%'+@gonderilenxml+'%'"
        End If

        'errorinfocode yazılmış ise
        If HttpContext.Current.Session("errorinfocode") <> "" Then
            sqldevam = sqldevam + " and errorinfocode=@errorinfocode"
        End If

        sqlstr = "select * from logservis where " + _
        "(tarih>=@baslangic and tarih<=@bitis)" + _
        sqldevam + " order by tarih desc"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = HttpContext.Current.Session("bitis")

        If HttpContext.Current.Session("sirket") <> "0" Then
            komut.Parameters.Add("@sirketpkey", SqlDbType.Int)
            komut.Parameters("@sirketpkey").Value = HttpContext.Current.Session("sirket")
        End If

        If HttpContext.Current.Session("servisad") <> "0" Then
            komut.Parameters.Add("@servisad", SqlDbType.VarChar)
            komut.Parameters("@servisad").Value = HttpContext.Current.Session("servisad")
        End If

        If HttpContext.Current.Session("resultcode") <> "Tümü" Then
            komut.Parameters.Add("@resultcode", SqlDbType.VarChar)
            komut.Parameters("@resultcode").Value = HttpContext.Current.Session("resultcode")
        End If

        If HttpContext.Current.Session("gonderilenxml") <> "" Then
            komut.Parameters.Add("@gonderilenxml", SqlDbType.VarChar)
            komut.Parameters("@gonderilenxml").Value = HttpContext.Current.Session("gonderilenxml")
        End If

        If HttpContext.Current.Session("errorinfocode") <> "" Then
            komut.Parameters.Add("@errorinfocode", SqlDbType.Int)
            komut.Parameters("@errorinfocode").Value = HttpContext.Current.Session("errorinfocode")
        End If


        girdi = "0"
        Dim pkey, tarih, sirketpkey, servisad, resultcode As String
        Dim errorinfocode, errorinfomessage, insertedcnt, updatedcnt As String
        Dim p_FirmCode, p_ProductCode, p_AgencyCode, p_PolicyNumber, p_ProductType As String
        Dim p_TecditNumber, p_ZeylCode, p_ZeylNo, d_FirmCode, d_ProductCode, d_ProductType As String
        Dim d_AgencyCode, d_PolicyNumber, d_TecditNumber, d_FileNo, d_RequestNo As String
        Dim policelink, hasarlink As String
        Dim policedugme, hasardugme As String
        Dim sonucyazi As String
        Dim suphelimi, suphelikod, suphelimesaj As String
        Dim supheyazi As String
        Dim servisdetaylink As String
        Dim servisdetaydugme As String
        Dim ipadres As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("ipadres") Is System.DBNull.Value Then
                        ipadres = veri.Item("ipadres")
                    Else
                        ipadres = ""
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = veri.Item("pkey")
                    Else
                        pkey = 0
                    End If

                    servisdetaylink = "servislogdetay.aspx?" + "pkey=" + CStr(pkey)

                    servisdetaydugme = "<a class='iframeyenikayit' href='" + servisdetaylink + "'>" + _
                    "<span class='button'>Detaylar</span>" + _
                    "</a>"

                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol1 = "<tr><td>" + tarih + "<br/>" + ipadres + "<br/>" + servisdetaydugme + "</td>"
                        saf1 = tarih
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                        saf2 = sirket.sirketad
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("servisad") Is System.DBNull.Value Then
                        servisad = veri.Item("servisad")
                        kol3 = "<td>" + servisad + "</td>"
                        saf3 = servisad
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If


                    'SONUÇ
                    If Not veri.Item("resultcode") Is System.DBNull.Value Then
                        resultcode = veri.Item("resultcode")
                    Else
                        resultcode = "-"
                    End If

                    If Not veri.Item("errorinfocode") Is System.DBNull.Value Then
                        errorinfocode = veri.Item("errorinfocode")
                    Else
                        errorinfocode = "-"
                    End If

                    If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                        errorinfomessage = veri.Item("errorinfomessage")
                    Else
                        errorinfomessage = "-"
                    End If

                    sonucyazi = "Sonuç Kodu:" + CStr(resultcode) + "<br/>" + _
                    "Hata Kodu:" + CStr(errorinfocode) + "<br/>" + _
                    "Mesaj:" + CStr(errorinfomessage)
                    kol4 = "<td>" + sonucyazi + "</td>"
                    saf4 = CStr(resultcode) + "," + CStr(errorinfomessage) + "," + errorinfomessage

                    'POLİÇE BİLGİLERİ
                    If Not veri.Item("p_FirmCode") Is System.DBNull.Value Then
                        p_FirmCode = veri.Item("p_FirmCode")
                    Else
                        p_FirmCode = "-"
                    End If

                    If Not veri.Item("p_ProductCode") Is System.DBNull.Value Then
                        p_ProductCode = veri.Item("p_ProductCode")
                    Else
                        p_ProductCode = "-"
                    End If

                    If Not veri.Item("p_AgencyCode") Is System.DBNull.Value Then
                        p_AgencyCode = veri.Item("p_AgencyCode")
                    Else
                        p_AgencyCode = "-"
                    End If

                    If Not veri.Item("p_PolicyNumber") Is System.DBNull.Value Then
                        p_PolicyNumber = veri.Item("p_PolicyNumber")
                    Else
                        p_PolicyNumber = "-"
                    End If

                    If Not veri.Item("p_TecditNumber") Is System.DBNull.Value Then
                        p_TecditNumber = veri.Item("p_TecditNumber")
                    Else
                        p_TecditNumber = "-"
                    End If

                    If Not veri.Item("p_ZeylCode") Is System.DBNull.Value Then
                        p_ZeylCode = veri.Item("p_ZeylCode")
                    Else
                        p_ZeylCode = "-"
                    End If

                    If Not veri.Item("p_ZeylNo") Is System.DBNull.Value Then
                        p_ZeylNo = veri.Item("p_ZeylNo")
                    Else
                        p_ZeylNo = "-"
                    End If

                    If Not veri.Item("p_ProductType") Is System.DBNull.Value Then
                        p_ProductType = veri.Item("p_ProductType")
                    Else
                        p_ProductType = "-"
                    End If

                    policelink = "policedetay.aspx?" + _
                    "FirmCode=" + Trim(p_FirmCode) + "&" + _
                    "ProductCode=" + Trim(p_ProductCode) + "&" + _
                    "AgencyCode=" + Trim(p_AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(p_PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(p_TecditNumber) + "&" + _
                    "ZeylCode=" + Trim(p_ZeylCode) + "&" + _
                    "ZeylNo=" + Trim(p_ZeylNo) + "&" + _
                    "ProductType=" + Trim(p_ProductType)


                    If resultcode = 1 And servisad = "LoadPolicyInformation" Then
                        policedugme = "<a class='iframeyenikayit' href='" + policelink + "'>" + _
                        "<span class='button'>Poliçe Bilgileri</span>" + _
                        "</a>"
                    Else
                        policedugme = "-"
                    End If
                    kol5 = "<td>" + policedugme + "</td>"
                    saf5 = p_FirmCode + "," + p_ProductCode + "," + _
                    p_AgencyCode + "," + p_PolicyNumber + "," + _
                    p_TecditNumber + "," + p_ZeylCode + "," + p_ZeylNo
                    '--------------------------------------------------------------------

                    'HASAR BİLGİLERİ
                    If Not veri.Item("d_FirmCode") Is System.DBNull.Value Then
                        d_FirmCode = veri.Item("d_FirmCode")
                    Else
                        d_FirmCode = "-"
                    End If

                    If Not veri.Item("d_ProductCode") Is System.DBNull.Value Then
                        d_ProductCode = veri.Item("d_ProductCode")
                    Else
                        d_ProductCode = "-"
                    End If

                    If Not veri.Item("d_AgencyCode") Is System.DBNull.Value Then
                        d_AgencyCode = veri.Item("d_AgencyCode")
                    Else
                        d_AgencyCode = "-"
                    End If

                    If Not veri.Item("d_PolicyNumber") Is System.DBNull.Value Then
                        d_PolicyNumber = veri.Item("d_PolicyNumber")
                    Else
                        d_PolicyNumber = "-"
                    End If

                    If Not veri.Item("d_TecditNumber") Is System.DBNull.Value Then
                        d_TecditNumber = veri.Item("d_TecditNumber")
                    Else
                        d_TecditNumber = "-"
                    End If

                    If Not veri.Item("d_FileNo") Is System.DBNull.Value Then
                        d_FileNo = veri.Item("d_FileNo")
                    Else
                        d_FileNo = "-"
                    End If

                    If Not veri.Item("d_RequestNo") Is System.DBNull.Value Then
                        d_RequestNo = veri.Item("d_RequestNo")
                    Else
                        d_RequestNo = "-"
                    End If

                    If Not veri.Item("d_ProductType") Is System.DBNull.Value Then
                        d_ProductType = veri.Item("d_ProductType")
                    Else
                        d_ProductType = "-"
                    End If

                    hasarlink = "hasardetay.aspx?" + _
                    "FirmCode=" + Trim(d_FirmCode) + "&" + _
                    "ProductCode=" + Trim(d_ProductCode) + "&" + _
                    "AgencyCode=" + Trim(d_AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(d_PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(d_TecditNumber) + "&" + _
                    "FileNo=" + Trim(d_FileNo) + "&" + _
                    "RequestNo=" + Trim(d_RequestNo) + "&" + _
                    "ProductType=" + Trim(d_ProductType)

                    If resultcode = 1 And servisad = "LoadDamageInformation" Then
                        hasardugme = "<a class='iframeyenikayit' href='" + hasarlink + "'>" + _
                        "<span class='button'>Hasar Bilgileri</span>" + _
                        "</a>"
                    Else
                        hasardugme = "-"
                    End If
                    kol6 = "<td>" + hasardugme + "</td>"
                    saf6 = "-"
                    '-----------------------------------------------------------------


                    'SAYILAR----------------------------------------------------------
                    If Not veri.Item("insertedcnt") Is System.DBNull.Value Then
                        insertedcnt = veri.Item("insertedcnt")
                        kol7 = "<td>" + insertedcnt + "</td>"
                        saf7 = insertedcnt
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("updatedcnt") Is System.DBNull.Value Then
                        updatedcnt = veri.Item("updatedcnt")
                        kol8 = "<td>" + updatedcnt + "</td></tr>"
                        saf8 = updatedcnt
                    Else
                        kol8 = "<td>-</td></tr>"
                        saf8 = "-"
                    End If


                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8

                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
      
                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
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


    '---------------------------------listele--------------------------------------
    Public Function listele_ilgilipolice(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String


        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16, kol17, kol18, kol19, kol20, kol21, kol22, kol23 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_6'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarih</th>" + _
        "<th>Şirket</th>" + _
        "<th>Çağırılan Servis</th>" + _
        "<th>Sonuç</th>" + _
        "<th>Kaydedilen Kayıt Sayısı</th>" + _
        "<th>Güncellenen Kayıt Sayısı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET


        sqldevam = "where " + _
        "p_FirmCode=@FirmCode and " + _
        "p_ProductCode=@ProductCode and " + _
        "p_AgencyCode = @AgencyCode and " + _
        "p_PolicyNumber =@PolicyNumber and " + _
        "p_TecditNumber = @TecditNumber and " + _
        "p_ZeylCode = @ZeylCode and " + _
        "p_ZeylNo = @ZeylNo and " + _
        "p_ProductType = @ProductType"


        sqlstr = "select * from logservis " + sqldevam

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

        Dim param6 As New SqlParameter("@ZeylCode", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = ZeylCode
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@ZeylNo", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = ZeylNo
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@ProductType", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = ProductType
        komut.Parameters.Add(param8)


        girdi = "0"
        Dim pkey, tarih, sirketpkey, servisad, resultcode As String
        Dim errorinfocode, errorinfomessage, insertedcnt, updatedcnt As String
        Dim p_FirmCode, p_ProductCode, p_AgencyCode, p_PolicyNumber As String
        Dim p_TecditNumber, p_ZeylCode, p_ZeylNo, d_FirmCode, d_ProductCode As String
        Dim d_AgencyCode, d_PolicyNumber, d_TecditNumber, d_FileNo, d_RequestNo As String
        Dim policelink, hasarlink As String
        Dim policedugme, hasardugme As String
        Dim sonucyazi As String
        Dim suphelimi, suphelikod, suphelimesaj As String
        Dim supheyazi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol1 = "<td>" + tarih + "</td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("servisad") Is System.DBNull.Value Then
                        servisad = veri.Item("servisad")
                        kol3 = "<td>" + servisad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    'SONUÇ
                    If Not veri.Item("resultcode") Is System.DBNull.Value Then
                        resultcode = veri.Item("resultcode")
                    Else
                        resultcode = "-"
                    End If

                    If Not veri.Item("errorinfocode") Is System.DBNull.Value Then
                        errorinfocode = veri.Item("errorinfocode")
                    Else
                        errorinfocode = "-"
                    End If

                    If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                        errorinfomessage = veri.Item("errorinfomessage")
                    Else
                        errorinfomessage = "-"
                    End If

                    sonucyazi = "Sonuç Kodu:" + CStr(resultcode) + "<br/>" + _
                    "Hata Kodu:" + CStr(errorinfocode) + "<br/>" + _
                    "Mesaj:" + CStr(errorinfomessage)
                    kol4 = "<td>" + sonucyazi + "</td>"


                    'SAYILAR
                    If Not veri.Item("insertedcnt") Is System.DBNull.Value Then
                        insertedcnt = veri.Item("insertedcnt")
                        kol5 = "<td>" + insertedcnt + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("updatedcnt") Is System.DBNull.Value Then
                        updatedcnt = veri.Item("updatedcnt")
                        kol6 = "<td>" + updatedcnt + "</td></tr>"
                    Else
                        kol6 = "<td>-</td></tr>"
                    End If



                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6

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


    '---------------------------------listele--------------------------------------
    Public Function listele_ilgilihasar(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String) As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16, kol17, kol18, kol19, kol20, kol21, kol22, kol23 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_9'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarih</th>" + _
        "<th>Şirket</th>" + _
        "<th>Çağırılan Servis</th>" + _
        "<th>Sonuç</th>" + _
        "<th>Kaydedilen Kayıt Sayısı</th>" + _
        "<th>Güncellenen Kayıt Sayısı</th>" + _
        "<th>Şüphe Bilgileri</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET


        sqldevam = "where " + _
        "d_FirmCode=@FirmCode and " + _
        "d_ProductCode=@ProductCode and " + _
        "d_AgencyCode = @AgencyCode and " + _
        "d_PolicyNumber =@PolicyNumber and " + _
        "d_TecditNumber = @TecditNumber and " + _
        "d_FileNo = @FileNo and " + _
        "d_RequestNo = @RequestNo and " + _
        "d_ProductType = @ProductType"

        sqlstr = "select * from logservis " + sqldevam

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

        girdi = "0"
        Dim pkey, tarih, sirketpkey, servisad, resultcode As String
        Dim errorinfocode, errorinfomessage, insertedcnt, updatedcnt As String
        Dim p_FirmCode, p_ProductCode, p_AgencyCode, p_PolicyNumber As String
        Dim p_TecditNumber, p_ZeylCode, p_ZeylNo, p_ProductType As String
        Dim d_FirmCode, d_ProductCode, d_ProductType As String
        Dim d_AgencyCode, d_PolicyNumber, d_TecditNumber, d_FileNo, d_RequestNo As String
        Dim policelink, hasarlink As String
        Dim policedugme, hasardugme As String
        Dim sonucyazi As String
        Dim suphelimi, suphelikod, suphelimesaj As String
        Dim supheyazi As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol1 = "<td>" + tarih + "</td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("servisad") Is System.DBNull.Value Then
                        servisad = veri.Item("servisad")
                        kol3 = "<td>" + servisad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    'SONUÇ
                    If Not veri.Item("resultcode") Is System.DBNull.Value Then
                        resultcode = veri.Item("resultcode")
                    Else
                        resultcode = "-"
                    End If

                    If Not veri.Item("errorinfocode") Is System.DBNull.Value Then
                        errorinfocode = veri.Item("errorinfocode")
                    Else
                        errorinfocode = "-"
                    End If

                    If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                        errorinfomessage = veri.Item("errorinfomessage")
                    Else
                        errorinfomessage = "-"
                    End If

                    sonucyazi = "Sonuç Kodu:" + CStr(resultcode) + "<br/>" + _
                    "Hata Kodu:" + CStr(errorinfocode) + "<br/>" + _
                    "Mesaj:" + CStr(errorinfomessage)
                    kol4 = "<td>" + sonucyazi + "</td>"


                    'SAYILAR
                    If Not veri.Item("insertedcnt") Is System.DBNull.Value Then
                        insertedcnt = veri.Item("insertedcnt")
                        kol5 = "<td>" + insertedcnt + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("updatedcnt") Is System.DBNull.Value Then
                        updatedcnt = veri.Item("updatedcnt")
                        kol6 = "<td>" + updatedcnt + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If


                    'ŞÜPHE BİLGİLERİ 
                    If Not veri.Item("suphelimi") Is System.DBNull.Value Then
                        suphelimi = veri.Item("suphelimi")
                    Else
                        suphelimi = ""
                    End If

                    If Not veri.Item("suphelikod") Is System.DBNull.Value Then
                        suphelikod = veri.Item("suphelikod")
                    Else
                        suphelikod = 0
                    End If

                    If Not veri.Item("suphelimesaj") Is System.DBNull.Value Then
                        suphelimesaj = veri.Item("suphelimesaj")
                    Else
                        suphelimesaj = ""
                    End If

                    supheyazi = "Şüpheli mi:" + suphelimi + "<br/>" + _
                    "Şüphe Kodu:" + CStr(suphelikod) + "<br/>" + _
                    "Şüphe Mesajı:" + suphelimesaj

                    kol7 = "<td>" + supheyazi + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7

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



    Public Function sonpoliceyuklemetarihinibul(ByVal sirketpkey As Integer) As DateTime

        Dim tarih As DateTime

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select tarih=MAX(tarih) from logservis group by" + _
        " insertedcnt,updatedcnt,servisad,sirketpkey " + _
        "having sirketpkey=@sirketpkey and servisad=@servisad and insertedcnt=@insertedcnt"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@servisad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "LoadPolicyInformation"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@insertedcnt", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = 1
        komut.Parameters.Add(param3)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    tarih = veri.Item("tarih")
                Else
                    tarih = ""
                End If

            End While
        End Using

        db_baglanti.Close()

        Return tarih

    End Function


    Public Function sonhasaryuklemetarihinibul(ByVal sirketpkey As Integer) As DateTime

        Dim tarih As DateTime

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select tarih=MAX(tarih) from logservis group by" + _
        " insertedcnt,updatedcnt,servisad,sirketpkey " + _
        "having sirketpkey=@sirketpkey and servisad=@servisad and insertedcnt=@insertedcnt"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@servisad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "LoadDamageInformation"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@insertedcnt", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = 1
        komut.Parameters.Add(param3)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    tarih = veri.Item("tarih")
                Else
                    tarih = ""
                End If

            End While
        End Using

        db_baglanti.Close()

        Return tarih

    End Function


    Public Function doldurtakvim(ByVal baslangictarih As Date, _
    ByVal bitistarih As Date) As List(Of CLASSTAKVIM)


        Dim kullanici_aktifsirket As String = HttpContext.Current.Session("kullanici_aktifsirket")

        Dim sqlstr As String
        Dim sayi As Integer

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim donecektakvim As New CLASSTAKVIM
        Dim donecektakvimler As New List(Of CLASSTAKVIM)

        Dim takvimler As New List(Of CLASSTAKVIM)
        Dim i As Integer = 1

        Dim eklenenpolice As Integer
        Dim guncellenenpolice As Integer

        Dim eklenenhasar As Integer
        Dim guncellenenhasar As Integer

        Dim eklenemeyenpolice As Integer
        Dim eklenemeyenhasar As Integer

        Dim CurrD As DateTime = baslangictarih

        While (CurrD <= bitistarih)

            eklenemeyenpolice = 0
            eklenemeyenhasar = 0
            eklenenpolice = 0
            guncellenenpolice = 0
            eklenenhasar = 0
            guncellenenhasar = 0

            eklenenpolice = kayitsayisibul(CurrD, kullanici_aktifsirket, "LoadPolicyInformation", 1, "eklenen")
            guncellenenpolice = kayitsayisibul(CurrD, kullanici_aktifsirket, "LoadPolicyInformation", 1, "guncellenen")

            eklenenhasar = kayitsayisibul(CurrD, kullanici_aktifsirket, "LoadDamageInformation", 1, "eklenen")
            guncellenenhasar = kayitsayisibul(CurrD, kullanici_aktifsirket, "LoadDamageInformation", 1, "guncellenen")

            eklenemeyenpolice = kayitsayisibul(CurrD, kullanici_aktifsirket, "LoadPolicyInformation", 0, "eklenemeyen")
            eklenemeyenhasar = kayitsayisibul(CurrD, kullanici_aktifsirket, "LoadDamageInformation", 0, "eklenemeyen")

            '---EKLENEN POLİÇELER ----------------------------------------------------------------
            If eklenenpolice > 0 Then

                donecektakvim.backgroundColor = "#008000"
                donecektakvim.title = "Eklenen Poliçe:" + CStr(eklenenpolice)

                donecektakvim.start = Format(CurrD, "yyyy-MM-dd")
                donecektakvim.end = Format(CurrD, "yyyy-MM-dd")

                donecektakvim.tip = "eklenenpolice"
                donecektakvim.id = i

                donecektakvim.allDay = False
                donecektakvim.editable = False

                donecektakvimler.Add(New CLASSTAKVIM(donecektakvim.tip, donecektakvim.id, _
                donecektakvim.start, donecektakvim.end, donecektakvim.title, _
                donecektakvim.pkey, donecektakvim.backgroundColor, donecektakvim.allDay, _
                donecektakvim.editable))

            End If
            If guncellenenpolice > 0 Then
                donecektakvim.backgroundColor = "#45a240"
                donecektakvim.title = "Güncellenen Poliçe:" + CStr(guncellenenpolice)


                donecektakvim.start = Format(CurrD, "yyyy-MM-dd")
                donecektakvim.end = Format(CurrD, "yyyy-MM-dd")

                donecektakvim.tip = "guncellenenpolice"
                donecektakvim.id = i

                donecektakvim.allDay = False
                donecektakvim.editable = False

                donecektakvimler.Add(New CLASSTAKVIM(donecektakvim.tip, donecektakvim.id, _
                donecektakvim.start, donecektakvim.end, donecektakvim.title, _
                donecektakvim.pkey, donecektakvim.backgroundColor, donecektakvim.allDay, _
                donecektakvim.editable))

            End If

            '---EKLENEN HASARLAR ----------------------------------------------------------------
            If eklenenhasar > 0 Then
                donecektakvim.backgroundColor = "#fe011b"
                donecektakvim.title = "Eklenen Hasar:" + CStr(eklenenhasar)

                donecektakvim.start = Format(CurrD, "yyyy-MM-dd")
                donecektakvim.end = Format(CurrD, "yyyy-MM-dd")

                donecektakvim.tip = "eklenenhasar"
                donecektakvim.id = i

                donecektakvim.allDay = False
                donecektakvim.editable = False

                donecektakvimler.Add(New CLASSTAKVIM(donecektakvim.tip, donecektakvim.id, _
                donecektakvim.start, donecektakvim.end, donecektakvim.title, _
                donecektakvim.pkey, donecektakvim.backgroundColor, donecektakvim.allDay, _
                donecektakvim.editable))

            End If
            If guncellenenhasar > 0 Then
                donecektakvim.backgroundColor = "#821418"
                donecektakvim.title = "Güncellenen Hasar:" + CStr(guncellenenhasar)


                donecektakvim.start = Format(CurrD, "yyyy-MM-dd")
                donecektakvim.end = Format(CurrD, "yyyy-MM-dd")

                donecektakvim.tip = "guncellenenhasar"
                donecektakvim.id = i

                donecektakvim.allDay = False
                donecektakvim.editable = False

                donecektakvimler.Add(New CLASSTAKVIM(donecektakvim.tip, donecektakvim.id, _
                donecektakvim.start, donecektakvim.end, donecektakvim.title, _
                donecektakvim.pkey, donecektakvim.backgroundColor, donecektakvim.allDay, _
                donecektakvim.editable))

            End If

            '---EKLENEMEYEN POLİÇE VE HASARLAR ----------------------------------------------------------------
            If eklenemeyenpolice > 0 Then
                donecektakvim.backgroundColor = "#f68c06"
                donecektakvim.title = "Eklenemeyen Poliçe:" + CStr(eklenemeyenpolice)


                donecektakvim.start = Format(CurrD, "yyyy-MM-dd")
                donecektakvim.end = Format(CurrD, "yyyy-MM-dd")

                donecektakvim.tip = "eklenemeyenpolice"
                donecektakvim.id = i

                donecektakvim.allDay = False
                donecektakvim.editable = False

                donecektakvimler.Add(New CLASSTAKVIM(donecektakvim.tip, donecektakvim.id, _
                donecektakvim.start, donecektakvim.end, donecektakvim.title, _
                donecektakvim.pkey, donecektakvim.backgroundColor, donecektakvim.allDay, _
                donecektakvim.editable))

            End If


            If eklenemeyenhasar > 0 Then
                donecektakvim.backgroundColor = "#ff7f50"
                donecektakvim.title = "Eklenemeyen Hasar:" + CStr(eklenemeyenhasar)


                donecektakvim.start = Format(CurrD, "yyyy-MM-dd")
                donecektakvim.end = Format(CurrD, "yyyy-MM-dd")

                donecektakvim.tip = "eklenemeyenhasar"
                donecektakvim.id = i

                donecektakvim.allDay = False
                donecektakvim.editable = False

                donecektakvimler.Add(New CLASSTAKVIM(donecektakvim.tip, donecektakvim.id, _
                donecektakvim.start, donecektakvim.end, donecektakvim.title, _
                donecektakvim.pkey, donecektakvim.backgroundColor, donecektakvim.allDay, _
                donecektakvim.editable))

            End If


            CurrD = CurrD.AddDays(1)

        End While

        Return donecektakvimler


    End Function



    '- KAYIT SAYILARINI BULMAK İÇİN FONKSİYON 
    ' insertmiupdatemi -> inserted 
    ' insertmiupdatemi-> updated 

    'resultcode -> 1
    'resultcode -> 0

    'hangisi-> eklenen
    'hangisi-> guncellenen
    'hangisi-> eklenemeyen

    Public Function kayitsayisibul(ByVal tarih As Date, _
    ByVal sirketpkey As String, ByVal servisad As String, _
    ByVal resultcode As String, ByVal hangisi As String) As Integer

        Dim sqldevam As String = ""
        If hangisi = "eklenen" Then
            sqldevam = " and insertedcnt=1 "
        End If

        If hangisi = "guncellenen" Then
            sqldevam = " and updatedcnt=1 "
        End If

        If hangisi = "eklenemeyen" Then
            sqldevam = ""
        End If

        Dim sqlstr As String
        Dim kayitsayisi As Integer

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "SELECT count(*) from logservis WHERE " + _
        " sirketpkey=@sirketpkey " + _
        " and Convert(DATE,tarih)=@tarih " + _
        "and servisad=@servisad " + _
        sqldevam + _
        "and resultcode=@resultcode "

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@tarih", SqlDbType.Date)
        komut.Parameters("@tarih").Value = tarih

        komut.Parameters.Add("@servisad", SqlDbType.VarChar)
        komut.Parameters("@servisad").Value = servisad

        komut.Parameters.Add("@sirketpkey", SqlDbType.Int)
        komut.Parameters("@sirketpkey").Value = sirketpkey

        komut.Parameters.Add("@resultcode", SqlDbType.Int)
        komut.Parameters("@resultcode").Value = resultcode

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitsayisi = 0
        Else
            kayitsayisi = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitsayisi


    End Function




    '---------------------------------listele--------------------------------------
    Public Function listeletakvimicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14, kol15 As String
        Dim kol16, kol17, kol18, kol19, kol20, kol21, kol22, kol23 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Yüklenme Tarihi</th>" + _
        "<th>Yükleyen Şirket</th>" + _
        "<th>Çağırılan Servis</th>" + _
        "<th>Poliçe Bilgisi</th>" + _
        "<th>Hasar Bilgisi</th>" + _
        "<th>Hata Mesajı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        '"<th>Kaydedilen Kayıt Sayısı</th>" + _
        '"<th>Güncellenen Kayıt Sayısı</th>" + _

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET


        'ne  eklenen police
        If HttpContext.Current.Session("tip") = "eklenenpolice" Then
            sqldevam = sqldevam + " and servisad='LoadPolicyInformation' and insertedcnt=1 and resultcode=1"
        End If

        'ne  guncellenen police
        If HttpContext.Current.Session("tip") = "guncellenenpolice" Then
            sqldevam = sqldevam + " and servisad='LoadPolicyInformation' and updatedcnt=1 and resultcode=1"
        End If

        'ne  eklenen hasar
        If HttpContext.Current.Session("tip") = "eklenenhasar" Then
            sqldevam = sqldevam + " and servisad='LoadDamageInformation' and insertedcnt=1 and resultcode=1"
        End If

        'ne guncellenen hasar
        If HttpContext.Current.Session("tip") = "guncellenenhasar" Then
            sqldevam = sqldevam + " and servisad='LoadDamageInformation' and updatedcnt=1 and resultcode=1"
        End If


        'ne eklenemeyen poliçe
        If HttpContext.Current.Session("tip") = "eklenemeyenpolice" Then
            sqldevam = sqldevam + " and servisad='LoadPolicyInformation' and resultcode=0"
        End If

        'ne eklenemeyen hasar
        If HttpContext.Current.Session("tip") = "eklenemeyenhasar" Then
            sqldevam = sqldevam + " and servisad='LoadDamageInformation' and resultcode=0"
        End If


        '------------------------------------------------------------------------------
        'sirket secilmişse
        If HttpContext.Current.Session("kullanici_aktifsirket") <> "" Then
            sqldevam = sqldevam + " and sirketpkey=@kullanici_aktifsirket "
        End If


        sqlstr = "select * from logservis where " + _
        "Convert(DATE,tarih)=@tarih" + _
        sqldevam

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@tarih", SqlDbType.DateTime)
        komut.Parameters("@tarih").Value = HttpContext.Current.Session("tarih")

        If HttpContext.Current.Session("kullanici_aktifsirket") <> "" Then
            komut.Parameters.Add("@kullanici_aktifsirket", SqlDbType.VarChar)
            komut.Parameters("@kullanici_aktifsirket").Value = HttpContext.Current.Session("kullanici_aktifsirket")
        End If


        girdi = "0"
        Dim pkey, tarih, sirketpkey, servisad, resultcode As String
        Dim errorinfocode, errorinfomessage, insertedcnt, updatedcnt As String
        Dim p_FirmCode, p_ProductCode, p_AgencyCode, p_PolicyNumber As String
        Dim p_TecditNumber, p_ZeylCode, p_ZeylNo, p_ProductType As String
        Dim d_FirmCode, d_ProductCode As String
        Dim d_AgencyCode, d_PolicyNumber, d_TecditNumber, d_FileNo, d_RequestNo As String
        Dim d_ProductType As String
        Dim policelink, hasarlink As String
        Dim policedugme, hasardugme As String
        Dim sonucyazi As String
        Dim suphelimi, suphelikod, suphelimesaj As String
        Dim supheyazi As String
        Dim servisdetaylink As String
        Dim servisdetaydugme As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"


                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = veri.Item("pkey")
                    Else
                        pkey = 0
                    End If

                    servisdetaylink = "servislogdetay.aspx?" + "pkey=" + CStr(pkey)

                    servisdetaydugme = "<a class='iframeyenikayit' href='" + servisdetaylink + "'>" + _
                    "<span class='button'>Detaylar</span>" + _
                    "</a>"

                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol1 = "<tr><td>" + tarih + "<br/>" + "</td>"
                    Else
                        kol1 = "<tr><td>-</td>"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("servisad") Is System.DBNull.Value Then
                        servisad = veri.Item("servisad")
                        kol3 = "<td>" + servisad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If


                    'SONUÇ
                    If Not veri.Item("resultcode") Is System.DBNull.Value Then
                        resultcode = veri.Item("resultcode")
                    Else
                        resultcode = "-"
                    End If

                    If Not veri.Item("errorinfocode") Is System.DBNull.Value Then
                        errorinfocode = veri.Item("errorinfocode")
                    Else
                        errorinfocode = "-"
                    End If

                    If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                        errorinfomessage = veri.Item("errorinfomessage")
                    Else
                        errorinfomessage = "-"
                    End If

                    sonucyazi = "Sonuç Kodu:" + CStr(resultcode) + "<br/>" + _
                    "Hata Kodu:" + CStr(errorinfocode) + "<br/>" + _
                    "Mesaj:" + CStr(errorinfomessage)
                    kol4 = "<td>" + sonucyazi + "</td>"



                    'POLİÇE BİLGİLERİ
                    If Not veri.Item("p_FirmCode") Is System.DBNull.Value Then
                        p_FirmCode = veri.Item("p_FirmCode")
                    Else
                        p_FirmCode = "-"
                    End If

                    If Not veri.Item("p_ProductCode") Is System.DBNull.Value Then
                        p_ProductCode = veri.Item("p_ProductCode")
                    Else
                        p_ProductCode = "-"
                    End If

                    If Not veri.Item("p_AgencyCode") Is System.DBNull.Value Then
                        p_AgencyCode = veri.Item("p_AgencyCode")
                    Else
                        p_AgencyCode = "-"
                    End If

                    If Not veri.Item("p_PolicyNumber") Is System.DBNull.Value Then
                        p_PolicyNumber = veri.Item("p_PolicyNumber")
                    Else
                        p_PolicyNumber = "-"
                    End If

                    If Not veri.Item("p_TecditNumber") Is System.DBNull.Value Then
                        p_TecditNumber = veri.Item("p_TecditNumber")
                    Else
                        p_TecditNumber = "-"
                    End If

                    If Not veri.Item("p_ZeylCode") Is System.DBNull.Value Then
                        p_ZeylCode = veri.Item("p_ZeylCode")
                    Else
                        p_ZeylCode = "-"
                    End If

                    If Not veri.Item("p_ZeylNo") Is System.DBNull.Value Then
                        p_ZeylNo = veri.Item("p_ZeylNo")
                    Else
                        p_ZeylNo = "-"
                    End If

                    If Not veri.Item("p_ProductType") Is System.DBNull.Value Then
                        p_ProductType = veri.Item("p_ProductType")
                    Else
                        p_ProductType = "-"
                    End If

                    policelink = "policedetaysirket.aspx?" + _
                    "FirmCode=" + Trim(p_FirmCode) + "&" + _
                    "ProductCode=" + Trim(p_ProductCode) + "&" + _
                    "AgencyCode=" + Trim(p_AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(p_PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(p_TecditNumber) + "&" + _
                    "ZeylCode=" + Trim(p_ZeylCode) + "&" + _
                    "ZeylNo=" + Trim(p_ZeylNo) + "&" + _
                    "ProductType=" + Trim(p_ProductType)

                    If resultcode = 1 And servisad = "LoadPolicyInformation" Then
                        policedugme = "<a class='iframeyenikayit' href='" + policelink + "'>" + _
                        "<span class='button'>Poliçe Bilgileri</span>" + _
                        "</a>"
                    Else
                        policedugme = "-"
                    End If
                    kol5 = "<td>" + policedugme + "</td>"
                    '--------------------------------------------------------------------

                    'HASAR BİLGİLERİ
                    If Not veri.Item("d_FirmCode") Is System.DBNull.Value Then
                        d_FirmCode = veri.Item("d_FirmCode")
                    Else
                        d_FirmCode = "-"
                    End If

                    If Not veri.Item("d_ProductCode") Is System.DBNull.Value Then
                        d_ProductCode = veri.Item("d_ProductCode")
                    Else
                        d_ProductCode = "-"
                    End If

                    If Not veri.Item("d_AgencyCode") Is System.DBNull.Value Then
                        d_AgencyCode = veri.Item("d_AgencyCode")
                    Else
                        d_AgencyCode = "-"
                    End If

                    If Not veri.Item("d_PolicyNumber") Is System.DBNull.Value Then
                        d_PolicyNumber = veri.Item("d_PolicyNumber")
                    Else
                        d_PolicyNumber = "-"
                    End If

                    If Not veri.Item("d_TecditNumber") Is System.DBNull.Value Then
                        d_TecditNumber = veri.Item("d_TecditNumber")
                    Else
                        d_TecditNumber = "-"
                    End If

                    If Not veri.Item("d_FileNo") Is System.DBNull.Value Then
                        d_FileNo = veri.Item("d_FileNo")
                    Else
                        d_FileNo = "-"
                    End If

                    If Not veri.Item("d_RequestNo") Is System.DBNull.Value Then
                        d_RequestNo = veri.Item("d_RequestNo")
                    Else
                        d_RequestNo = "-"
                    End If

                    If Not veri.Item("d_ProductType") Is System.DBNull.Value Then
                        d_ProductType = veri.Item("d_ProductType")
                    Else
                        d_ProductType = "-"
                    End If

                    hasarlink = "hasardetaysirket.aspx?" + _
                    "FirmCode=" + Trim(d_FirmCode) + "&" + _
                    "ProductCode=" + Trim(d_ProductCode) + "&" + _
                    "AgencyCode=" + Trim(d_AgencyCode) + "&" + _
                    "PolicyNumber=" + Trim(d_PolicyNumber) + "&" + _
                    "TecditNumber=" + Trim(d_TecditNumber) + "&" + _
                    "FileNo=" + Trim(d_FileNo) + "&" + _
                    "RequestNo=" + Trim(d_RequestNo) + "&" + _
                    "ProductType=" + Trim(d_ProductType)

                    If resultcode = 1 And servisad = "LoadDamageInformation" Then
                        hasardugme = "<a class='iframeyenikayit' href='" + hasarlink + "'>" + _
                        "<span class='button'>Hasar Bilgileri</span>" + _
                        "</a>"
                    Else
                        hasardugme = "-"
                    End If
                    kol6 = "<td>" + hasardugme + "</td>"
                    '-----------------------------------------------------------------

                    'SAYILAR
                    If Not veri.Item("insertedcnt") Is System.DBNull.Value Then
                        insertedcnt = veri.Item("insertedcnt")
                        kol7 = "<td>" + insertedcnt + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("updatedcnt") Is System.DBNull.Value Then
                        updatedcnt = veri.Item("updatedcnt")
                        kol8 = "<td>" + updatedcnt + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("errorinfomessage") Is System.DBNull.Value Then
                        errorinfomessage = veri.Item("errorinfomessage")
                        kol9 = "<td>" + errorinfomessage + "</td></tr>"
                    Else
                        kol9 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol5 + _
                    kol6 + kol9

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


    '--- LOGLARI SİL ŞİRKETİN TÜMÜ -------------------------------------------------------
    Function sil_sirketin(ByVal sirketpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from logservis where sirketpkey=@sirketpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        '3000 saniye 50 dakika
        komut.CommandTimeout = 3000


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


    Public Function birdakikaicerisindekiislemsayisinibul(ByVal sirketpkey As Integer) As Integer

        Dim sqlstr As String
        Dim sayi As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from logservis where sirketpkey=@sirketpkey  and " + _
        " tarih>=@baslangictarih and tarih<=@bitistarih "

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = DateTime.Now.AddMinutes(-1)
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@bitistarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        param3.Value = DateTime.Now
        komut.Parameters.Add(param3)

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


    Public Function kotakontrol(ByVal sirketpkey As Integer) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_erisim.bultek(sirketpkey)
        Dim kota As Integer
        Dim cagirimsayi As Integer

        kota = sirket.maksservistalepdakika
        cagirimsayi = birdakikaicerisindekiislemsayisinibul(sirketpkey)

        If cagirimsayi > kota Then
            result.durum = "Evet"
            result.etkilenen = 8
            result.hatastr = "1 dakika içerisinde maksimum servis çağırım hakkınız " + CStr(kota) + "." + _
            "Siz bu kotayı aşarak toplam " + CStr(cagirimsayi) + " adet servis çağırdınız. Bu sebepten 1 dakikanın geçmesini bekleyiniz."
        Else
            result.durum = "Hayır"
            result.etkilenen = cagirimsayi
            result.hatastr = ""
        End If


        Return result

    End Function


    Public Function kactaneihaletipindepolicegirmis(ByVal ihalesinir As CLASSIHALESINIR, _
    ByVal sirketpkey As Integer) As Integer

        Dim sqlstr As String
        Dim sayi As Integer = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from logservis where sirketpkey=@sirketpkey  and " + _
        "CAST(tarih AS DATE)>=@baslangictarih and CAST(tarih AS DATE)<=@bitistarih and ResultCode=@ResultCode and " + _
        "servisad=@servisad and insertedcnt=@insertedcnt"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirketpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = ihalesinir.baslangictarih
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        param3.Value = ihalesinir.bitistarih
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ResultCode", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = 1
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@servisad", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = "LoadPolicyInformation"
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@insertedcnt", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        param6.Value = 1
        komut.Parameters.Add(param6)

        Dim p_FirmCode, p_ProductCode, p_AgencyCode, p_PolicyNumber As String
        Dim p_TecditNumber, p_ZeylCode, p_ZeylNo, p_ProductType As String
        Dim policyinfo As New PolicyInfo
        Dim policyinfo_erisim As New PolicyInfo_Erisim

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                If Not veri.Item("p_FirmCode") Is System.DBNull.Value Then
                    p_FirmCode = veri.Item("p_FirmCode")
                End If

                If Not veri.Item("p_ProductCode") Is System.DBNull.Value Then
                    p_ProductCode = veri.Item("p_ProductCode")
                End If

                If Not veri.Item("p_AgencyCode") Is System.DBNull.Value Then
                    p_AgencyCode = veri.Item("p_AgencyCode")
                End If

                If Not veri.Item("p_PolicyNumber") Is System.DBNull.Value Then
                    p_PolicyNumber = veri.Item("p_PolicyNumber")
                End If

                If Not veri.Item("p_TecditNumber") Is System.DBNull.Value Then
                    p_TecditNumber = veri.Item("p_TecditNumber")
                End If

                If Not veri.Item("p_ZeylCode") Is System.DBNull.Value Then
                    p_ZeylCode = veri.Item("p_ZeylCode")
                End If

                If Not veri.Item("p_ZeylNo") Is System.DBNull.Value Then
                    p_ZeylNo = veri.Item("p_ZeylNo")
                End If

                If Not veri.Item("p_ProductType") Is System.DBNull.Value Then
                    p_ProductType = veri.Item("p_ProductType")
                End If

                policyinfo = policyinfo_erisim.bultek(p_FirmCode, p_ProductCode, p_AgencyCode, _
                p_PolicyNumber, p_TecditNumber, p_ZeylCode, p_ZeylNo, p_ProductType)

                'sınır kapısı ise
                If policyinfo.PolicyType = 2 Then
                    sayi = sayi + 1
                End If

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return sayi

    End Function


    Public Function ihalekontrol(ByVal sirketpkey As Integer) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim ihalesinir As New CLASSIHALESINIR
        Dim ihalesinir_erisim As New CLASSIHALESINIR_ERISIM
        ihalesinir = ihalesinir_erisim.kotabul(sirketpkey)

        'herhangi bir tanımlama yapılmamış ise
        If ihalesinir.pkey = 0 Then
            result.durum = "Evet"
            result.etkilenen = 1
            result.hatastr = "İhale tipi poliçe yükleyemezsiniz. Kota Tanımı Bulunamadı."
            Return result
        End If

        Dim kota As Integer
        Dim yuklenensayi As Integer

        kota = ihalesinir.maksadet

        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        yuklenensayi = logservis_erisim.kactaneihaletipindepolicegirmis(ihalesinir, sirketpkey)

        'kotayı geçti
        If yuklenensayi > kota Then
            result.durum = "Evet"
            result.etkilenen = 1
            result.hatastr = CStr(ihalesinir.baslangictarih) + " ile " + CStr(ihalesinir.bitistarih) + _
            " tarihleri arasında en fazla " + CStr(ihalesinir.maksadet) + " adet ihale tipinde poliçe girebilirsiniz." + _
            "Siz toplam " + CStr(yuklenensayi) + " kadar giriş yaptınız"
            Return result
        End If

        result.durum = "Hayır"
        result.etkilenen = 0
        result.hatastr = ""
        Return result

    End Function

End Class

