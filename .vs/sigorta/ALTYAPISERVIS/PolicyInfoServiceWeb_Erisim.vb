Imports System.Data.SqlClient
Imports System.Globalization.CultureInfo
Imports System.Globalization

Public Class PolicyInfoServiceWeb_Erisim


    Dim istring As String
    Dim sqlstr As String
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand



    Public Function TotalPolicyNumber(ByVal wskullaniciad As String, _
    ByVal wssifre As String) As String

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        Dim servisad As String = "TotalPolicyNumber"
        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'Yetkili mi?
        Dim yetkiresult As New CLADBOPRESULT
        yetkiresult = sirket_erisim.yetkilimi2(wskullaniciad, wssifre)
        If yetkiresult.durum = "Yetkisiz" Then

            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr

        End If

        'Yetkili ise hesapla ve logla
        Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM

        Dim policeadeti As Integer = 0
        fieldopvalues.Clear()
        policeadeti = genericislem_erisim.countgeneric(veritabaniad, "PolicyInfo", "count(*)", fieldopvalues)

        donecek = "<root ResultCode=" + Chr(34) + "1" + Chr(34) + ">" + _
        "<TotalPolicyCountResult TotalPolicyCount=" + _
        Chr(34) + CStr(policeadeti) + Chr(34) + _
        "></TotalPolicyCountResult>" + _
        "</root>"

        'logla
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
        1, 0, "-", 0, _
        0, "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))


        Return donecek

    End Function


    Public Function TotalPolicyNumberDate(ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal startdate_p As String, ByVal enddate_p As String) As String

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        Dim servisad As String = "TotalPolicyNumberDate"
        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'Yetkili mi?
        Dim yetkiresult As New CLADBOPRESULT
        yetkiresult = sirket_erisim.yetkilimi2(wskullaniciad, wssifre)
        If yetkiresult.durum = "Yetkisiz" Then

            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr

        End If


        'Tarihler doğru gönderilmiş mi ?
        Dim StartDate, EndDate As Date

        Try
            StartDate = startdate_p
        Catch
            root.ResultCode = 0
            ErrorInfo.Code = 10
            ErrorInfo.Message = "StartDate yyyy-MM-dd formatında olmalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr
        End Try

        Try
            EndDate = enddate_p
        Catch
            root.ResultCode = 0
            ErrorInfo.Code = 20
            ErrorInfo.Message = "EndDate yyyy-MM-dd formatında olmalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr

        End Try


        'Tarihlerde doğru ise hesapla ve logla
        Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM

        'TOPLAM POLİÇE ADETİ
        Dim policeadeti As Integer = 0
        fieldopvalues.Clear()

        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", ">=", StartDate, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", "<=", EndDate, ""))
        policeadeti = genericislem_erisim.countgeneric(veritabaniad, "PolicyInfo", "count(*)", fieldopvalues)

        donecek = "<root ResultCode=" + Chr(34) + "1" + Chr(34) + ">" + _
        "<TotalPolicyCountResult TotalPolicyCount=" + _
        Chr(34) + CStr(policeadeti) + Chr(34) + _
        "></TotalPolicyCountResult>" + _
        "</root>"

        'logla
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
        1, 0, "-", 0, _
        0, "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        Return donecek

    End Function




    Public Function TodayPolicyNumber(ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal ArrangeDate_p As String) As String

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        Dim servisad As String = "TodayPolicyNumber"
        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'Yetkili mi?
        Dim yetkiresult As New CLADBOPRESULT
        yetkiresult = sirket_erisim.yetkilimi2(wskullaniciad, wssifre)
        If yetkiresult.durum = "Yetkisiz" Then

            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr

        End If


        'Tarihler doğru gönderilmiş mi ?
        Dim ArrangeDate As Date

        Try
            ArrangeDate = ArrangeDate_p
        Catch
            root.ResultCode = 0
            ErrorInfo.Code = 10
            ErrorInfo.Message = "ArrangeDate yyyy-MM-dd formatında olmalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            root.resultstr = "<root ResultCode=" + Chr(34) + CStr(root.ResultCode) + Chr(34) + ">" + _
            "<ErrorInfo Code=" + Chr(34) + CStr(root.ErrorInfo.Code) + Chr(34) + _
            " Message=" + Chr(34) + CStr(root.ErrorInfo.Message) + Chr(34) + "/>" + _
            "</root>"

            Return root.resultstr
        End Try


        'Tarihlerde doğru ise hesapla ve logla
        Dim ArrangeDateb As DateTime
        Dim ArrangeDates As DateTime
        ArrangeDateb = New DateTime(ArrangeDate.Year, ArrangeDate.Month, ArrangeDate.Day, 0, 0, 0)
        ArrangeDates = New DateTime(ArrangeDate.Year, ArrangeDate.Month, ArrangeDate.Day, 23, 59, 59)

        Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
        Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM

        'TOPLAM POLİÇE ADETİ
        Dim policeadeti As Integer = 0
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ArrangeDate", ">=", ArrangeDateb, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ArrangeDate", "<=", ArrangeDates, " "))
        policeadeti = genericislem_erisim.countgeneric(veritabaniad, "PolicyInfo", "count(*)", fieldopvalues)

        donecek = "<root ResultCode=" + Chr(34) + "1" + Chr(34) + ">" + _
        "<TotalPolicyCountResult TotalPolicyCount=" + _
        Chr(34) + CStr(policeadeti) + Chr(34) + _
        "></TotalPolicyCountResult>" + _
        "</root>"

        'logla
        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
        1, 0, "-", 0, _
        0, "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "0", _
        "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        Return donecek

    End Function

    Public Function PolicySearch(ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal PlateNumber_p As String, _
    ByVal IdentityNo_p As String) As List(Of PolicyInfo)


        Dim bulunanpoliceler As New List(Of PolicyInfo)
        bulunanpoliceler.Clear()

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        Dim servisad As String = "PolicySearch"
        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'Yetkili mi?
        Dim yetkiresult As New CLADBOPRESULT
        yetkiresult = sirket_erisim.yetkilimi2(wskullaniciad, wssifre)
        If yetkiresult.durum = "Yetkisiz" Then

            root.ResultCode = 0
            ErrorInfo.Code = yetkiresult.etkilenen
            ErrorInfo.Message = yetkiresult.hatastr
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return bulunanpoliceler

        End If


        If PlateNumber_p = "" Then

            root.ResultCode = 0
            ErrorInfo.Code = 10
            ErrorInfo.Message = "Plaka boş olmamalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return bulunanpoliceler

        End If


        If IdentityNo_p = "" Then

            root.ResultCode = 0
            ErrorInfo.Code = 20
            ErrorInfo.Message = "Kimlik boş olmamalıdır."
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad, _
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0, _
            0, "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "0", _
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

            Return bulunanpoliceler

        End If

        bulunanpoliceler = doldur_canlipoliceler(PlateNumber_p, IdentityNo_p)
        Return bulunanpoliceler

    End Function




    Function doldur_canlipoliceler(ByVal PlateNumber_p As String, ByVal IdentityNo_p As String) As List(Of PolicyInfo)

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim renk As String = ""


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfo As New PolicyInfo
        Dim PolicyInfolar As New List(Of PolicyInfo)

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where" + _
        " PlateNumber=@PlateNumber " + _
        " and (PolicyOwnerIdentityNo=@PolicyOwnerIdentityNo " + _
        " or IdentityNo1=@IdentityNo1 " + _
        " or IdentityNo2=@IdentityNo2 " + _
        " or IdentityNo3=@IdentityNo3 " + _
        " or IdentityNo4=@IdentityNo4 " + _
        " or IdentityNo5=@IdentityNo5 " + _
        " or IdentityNo6=@IdentityNo6 ) " + _
        " and (ZeylCode='P' or ZeylCode='p' or ZeylCode='T' or ZeylCode='t')" + _
        " order by StartDate"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlateNumber_p
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@PolicyOwnerIdentityNo", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = IdentityNo_p
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@IdentityNo1", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = IdentityNo_p
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@IdentityNo2", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = IdentityNo_p
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@IdentityNo3", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = IdentityNo_p
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@IdentityNo4", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        param6.Value = IdentityNo_p
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@IdentityNo5", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        param7.Value = IdentityNo_p
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@IdentityNo6", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        param8.Value = IdentityNo_p
        komut.Parameters.Add(param8)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("PolicyType") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyType = veri.Item("PolicyType")
                End If

                If Not veri.Item("PolicyOwnerCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerCountryCode = veri.Item("PolicyOwnerCountryCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerIdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerName = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerSurname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerBirthDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyOwnerBirthDate = veri.Item("PolicyOwnerBirthDate")
                Else
                    donecekPolicyInfo.PolicyOwnerBirthDate = "00:00:00"
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfo.AddressLine3 = veri.Item("AddressLine3")
                End If

                If Not veri.Item("PlateCountryCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateCountryCode = veri.Item("PlateCountryCode")
                End If

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("Brand") Is System.DBNull.Value Then
                    donecekPolicyInfo.Brand = veri.Item("Brand")
                Else
                    donecekPolicyInfo.Brand = "-"
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekPolicyInfo.Model = veri.Item("Model")
                Else
                    donecekPolicyInfo.Model = "-"
                End If

                If Not veri.Item("ChassisNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.ChassisNumber = veri.Item("ChassisNumber")
                Else
                    donecekPolicyInfo.ChassisNumber = "-"
                End If

                If Not veri.Item("EngineNumber") Is System.DBNull.Value Then
                    donecekPolicyInfo.EngineNumber = veri.Item("EngineNumber")
                Else
                    donecekPolicyInfo.EngineNumber = ""
                End If

                If Not veri.Item("EnginePower") Is System.DBNull.Value Then
                    donecekPolicyInfo.EnginePower = veri.Item("EnginePower")
                Else
                    donecekPolicyInfo.EnginePower = 0
                End If

                If Not veri.Item("ProductionYear") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductionYear = veri.Item("ProductionYear")
                Else
                    donecekPolicyInfo.ProductionYear = 0
                End If

                If Not veri.Item("Capacity") Is System.DBNull.Value Then
                    donecekPolicyInfo.Capacity = veri.Item("Capacity")
                Else
                    donecekPolicyInfo.Capacity = 0
                End If

                If Not veri.Item("CarType") Is System.DBNull.Value Then
                    donecekPolicyInfo.CarType = veri.Item("CarType")
                Else
                    donecekPolicyInfo.CarType = "-"
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                Else
                    donecekPolicyInfo.UsingStyle = "-"
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("UsingStyle") Is System.DBNull.Value Then
                    donecekPolicyInfo.UsingStyle = veri.Item("UsingStyle")
                End If

                If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.TariffCode = veri.Item("TariffCode")
                End If

                If Not veri.Item("ArrangeDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ArrangeDate = veri.Item("ArrangeDate")
                Else
                    donecekPolicyInfo.ArrangeDate = "00:00:00"
                End If

                If Not veri.Item("StartDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.StartDate = veri.Item("StartDate")
                Else
                    donecekPolicyInfo.StartDate = "00:00:00"
                End If

                If Not veri.Item("EndDate") Is System.DBNull.Value Then
                    donecekPolicyInfo.EndDate = veri.Item("EndDate")
                Else
                    donecekPolicyInfo.EndDate = "00:00:00"
                End If

                If Not veri.Item("Material") Is System.DBNull.Value Then
                    donecekPolicyInfo.Material = veri.Item("Material")
                End If

                If Not veri.Item("Corporal") Is System.DBNull.Value Then
                    donecekPolicyInfo.Corporal = veri.Item("Corporal")
                End If

                If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.CurrencyCode = veri.Item("CurrencyCode")
                End If

                If Not veri.Item("PublicValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValue = veri.Item("PublicValue")
                End If

                If Not veri.Item("AuthorizedDrivers") Is System.DBNull.Value Then
                    donecekPolicyInfo.AuthorizedDrivers = veri.Item("AuthorizedDrivers")
                End If

                If Not veri.Item("CountryCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode1 = veri.Item("CountryCode1")
                End If

                If Not veri.Item("IdentityCode1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode1 = veri.Item("IdentityCode1")
                End If

                If Not veri.Item("IdentityNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo1 = veri.Item("IdentityNo1")
                End If

                If Not veri.Item("Name1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name1 = veri.Item("Name1")
                End If

                If Not veri.Item("Surname1") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname1 = veri.Item("Surname1")
                End If

                If Not veri.Item("BirthDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate1 = veri.Item("BirthDate1")
                Else
                    donecekPolicyInfo.BirthDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo1 = veri.Item("DriverLicenceNo1")
                End If

                If Not veri.Item("DriverLicenceGivenDate1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate1 = veri.Item("DriverLicenceGivenDate1")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate1 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType1") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType1 = veri.Item("DriverLicenceType1")
                End If

                If Not veri.Item("CountryCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode2 = veri.Item("CountryCode2")
                End If

                If Not veri.Item("IdentityCode2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode2 = veri.Item("IdentityCode2")
                End If

                If Not veri.Item("IdentityNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo2 = veri.Item("IdentityNo2")
                End If

                If Not veri.Item("Name2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name2 = veri.Item("Name2")
                End If

                If Not veri.Item("Surname2") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname2 = veri.Item("Surname2")
                End If

                If Not veri.Item("BirthDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate2 = veri.Item("BirthDate2")
                Else
                    donecekPolicyInfo.BirthDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo2 = veri.Item("DriverLicenceNo2")
                End If

                If Not veri.Item("DriverLicenceGivenDate2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate2 = veri.Item("DriverLicenceGivenDate2")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate2 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType2") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType2 = veri.Item("DriverLicenceType2")
                End If

                If Not veri.Item("CountryCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode3 = veri.Item("CountryCode3")
                End If

                If Not veri.Item("IdentityCode3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode3 = veri.Item("IdentityCode3")
                End If

                If Not veri.Item("IdentityNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo3 = veri.Item("IdentityNo3")
                End If

                If Not veri.Item("Name3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name3 = veri.Item("Name3")
                End If

                If Not veri.Item("Surname3") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname3 = veri.Item("Surname3")
                End If

                If Not veri.Item("BirthDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate3 = veri.Item("BirthDate3")
                Else
                    donecekPolicyInfo.BirthDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo3 = veri.Item("DriverLicenceNo3")
                End If

                If Not veri.Item("DriverLicenceGivenDate3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate3 = veri.Item("DriverLicenceGivenDate3")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate3 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType3") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType3 = veri.Item("DriverLicenceType3")
                End If

                If Not veri.Item("CountryCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode4 = veri.Item("CountryCode4")
                End If

                If Not veri.Item("IdentityCode4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode4 = veri.Item("IdentityCode4")
                End If

                If Not veri.Item("IdentityNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo4 = veri.Item("IdentityNo4")
                End If

                If Not veri.Item("Name4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name4 = veri.Item("Name4")
                End If

                If Not veri.Item("Surname4") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname4 = veri.Item("Surname4")
                End If

                If Not veri.Item("BirthDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate4 = veri.Item("BirthDate4")
                Else
                    donecekPolicyInfo.BirthDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo4 = veri.Item("DriverLicenceNo4")
                End If

                If Not veri.Item("DriverLicenceGivenDate4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate4 = veri.Item("DriverLicenceGivenDate4")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate4 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType4") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType4 = veri.Item("DriverLicenceType4")
                End If

                If Not veri.Item("CountryCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode5 = veri.Item("CountryCode5")
                End If

                If Not veri.Item("IdentityCode5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode5 = veri.Item("IdentityCode5")
                End If

                If Not veri.Item("IdentityNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo5 = veri.Item("IdentityNo5")
                End If

                If Not veri.Item("Name5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name5 = veri.Item("Name5")
                End If

                If Not veri.Item("Surname5") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname5 = veri.Item("Surname5")
                End If

                If Not veri.Item("BirthDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate5 = veri.Item("BirthDate5")
                Else
                    donecekPolicyInfo.BirthDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo5 = veri.Item("DriverLicenceNo5")
                End If

                If Not veri.Item("DriverLicenceGivenDate5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate5 = veri.Item("DriverLicenceGivenDate5")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate5 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType5") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType5 = veri.Item("DriverLicenceType5")
                End If

                If Not veri.Item("CountryCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.CountryCode6 = veri.Item("CountryCode6")
                End If

                If Not veri.Item("IdentityCode6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityCode6 = veri.Item("IdentityCode6")
                End If

                If Not veri.Item("IdentityNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.IdentityNo6 = veri.Item("IdentityNo6")
                End If

                If Not veri.Item("Name6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Name6 = veri.Item("Name6")
                End If

                If Not veri.Item("Surname6") Is System.DBNull.Value Then
                    donecekPolicyInfo.Surname6 = veri.Item("Surname6")
                End If

                If Not veri.Item("BirthDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.BirthDate6 = veri.Item("BirthDate6")
                Else
                    donecekPolicyInfo.BirthDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceNo6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceNo6 = veri.Item("DriverLicenceNo6")
                End If

                If Not veri.Item("DriverLicenceGivenDate6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceGivenDate6 = veri.Item("DriverLicenceGivenDate6")
                Else
                    donecekPolicyInfo.DriverLicenceGivenDate6 = "00:00:00"
                End If

                If Not veri.Item("DriverLicenceType6") Is System.DBNull.Value Then
                    donecekPolicyInfo.DriverLicenceType6 = veri.Item("DriverLicenceType6")
                End If

                If Not veri.Item("InsurancePremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremium = veri.Item("InsurancePremium")
                End If

                If Not veri.Item("AssistantFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.AssistantFees = veri.Item("AssistantFees")
                End If

                If Not veri.Item("OtherFees") Is System.DBNull.Value Then
                    donecekPolicyInfo.OtherFees = veri.Item("OtherFees")
                End If


                If Not veri.Item("BasePriceValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.BasePriceValue = veri.Item("BasePriceValue")
                End If

                If Not veri.Item("CCRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRateValue = veri.Item("CCRateValue")
                End If

                If Not veri.Item("DamageRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRateValue = veri.Item("DamageRateValue")
                End If

                If Not veri.Item("AgeRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRateValue = veri.Item("AgeRateValue")
                End If

                If Not veri.Item("DamagelessRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRateValue = veri.Item("DamagelessRateValue")
                End If

                If Not veri.Item("Color") Is System.DBNull.Value Then
                    donecekPolicyInfo.Color = veri.Item("Color")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    donecekPolicyInfo.ProductType = veri.Item("ProductType")
                End If

                If Not veri.Item("FuelType") Is System.DBNull.Value Then
                    donecekPolicyInfo.FuelType = veri.Item("FuelType")
                End If

                If Not veri.Item("SteeringSide") Is System.DBNull.Value Then
                    donecekPolicyInfo.SteeringSide = veri.Item("SteeringSide")
                End If

                If Not veri.Item("AnyDriverRateValue") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRateValue = veri.Item("AnyDriverRateValue")
                End If

                If Not veri.Item("PolicyPremium") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremium = veri.Item("PolicyPremium")
                End If

                If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                End If

                If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                End If

                If Not veri.Item("PublicValueTL") Is System.DBNull.Value Then
                    donecekPolicyInfo.PublicValueTL = veri.Item("PublicValueTL")
                End If

                If Not veri.Item("DamageRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamageRate = veri.Item("DamageRate")
                End If

                If Not veri.Item("DamagelessRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.DamagelessRate = veri.Item("DamagelessRate")
                End If

                If Not veri.Item("AnyDriverRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AnyDriverRate = veri.Item("AnyDriverRate")
                End If

                If Not veri.Item("AgeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgeRate = veri.Item("AgeRate")
                End If

                If Not veri.Item("CCRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.CCRate = veri.Item("CCRate")
                End If

                If Not veri.Item("SBMCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.SBMCode = veri.Item("SBMCode")
                End If

                If Not veri.Item("Creditor") Is System.DBNull.Value Then
                    donecekPolicyInfo.Creditor = veri.Item("Creditor")
                End If

                If Not veri.Item("FirstBeneficiary") Is System.DBNull.Value Then
                    donecekPolicyInfo.FirstBeneficiary = veri.Item("FirstBeneficiary")
                End If

                If Not veri.Item("ExchangeRate") Is System.DBNull.Value Then
                    donecekPolicyInfo.ExchangeRate = veri.Item("ExchangeRate")
                End If

                If Not veri.Item("AgencyRegisterCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.AgencyRegisterCode = veri.Item("AgencyRegisterCode")
                End If

                If Not veri.Item("TPNo") Is System.DBNull.Value Then
                    donecekPolicyInfo.TPNo = veri.Item("TPNo")
                End If

                If Not veri.Item("BorderCode") Is System.DBNull.Value Then
                    donecekPolicyInfo.BorderCode = veri.Item("BorderCode")
                Else
                    donecekPolicyInfo.BorderCode = ""
                End If

                renk = PolicyInfo_erisim.renkbul(donecekPolicyInfo.FirmCode, donecekPolicyInfo.ProductCode, _
                donecekPolicyInfo.AgencyCode, donecekPolicyInfo.PolicyNumber, _
                donecekPolicyInfo.TecditNumber, donecekPolicyInfo.ZeylCode, _
                donecekPolicyInfo.ZeylNo, donecekPolicyInfo.ProductType)

                If renk = "green" Then

                    PolicyInfolar.Add(New PolicyInfo(donecekPolicyInfo.FirmCode, _
                    donecekPolicyInfo.ProductCode, donecekPolicyInfo.AgencyCode, donecekPolicyInfo.PolicyNumber, _
                    donecekPolicyInfo.TecditNumber, donecekPolicyInfo.ZeylCode, donecekPolicyInfo.ZeylNo, _
                    donecekPolicyInfo.PolicyType, donecekPolicyInfo.PolicyOwnerCountryCode, _
                    donecekPolicyInfo.PolicyOwnerIdentityCode, donecekPolicyInfo.PolicyOwnerIdentityNo, _
                    donecekPolicyInfo.PolicyOwnerName, donecekPolicyInfo.PolicyOwnerSurname, _
                    donecekPolicyInfo.PolicyOwnerBirthDate, donecekPolicyInfo.AddressLine1, _
                    donecekPolicyInfo.AddressLine2, donecekPolicyInfo.AddressLine3, _
                    donecekPolicyInfo.PlateCountryCode, donecekPolicyInfo.PlateNumber, _
                    donecekPolicyInfo.Brand, donecekPolicyInfo.Model, _
                    donecekPolicyInfo.ChassisNumber, donecekPolicyInfo.EngineNumber, _
                    donecekPolicyInfo.EnginePower, donecekPolicyInfo.ProductionYear, _
                    donecekPolicyInfo.Capacity, donecekPolicyInfo.CarType, _
                    donecekPolicyInfo.UsingStyle, donecekPolicyInfo.TariffCode, _
                    donecekPolicyInfo.ArrangeDate, donecekPolicyInfo.StartDate, _
                    donecekPolicyInfo.EndDate, donecekPolicyInfo.Material, _
                    donecekPolicyInfo.Corporal, donecekPolicyInfo.CurrencyCode, _
                    donecekPolicyInfo.PublicValue, donecekPolicyInfo.AuthorizedDrivers, _
                    donecekPolicyInfo.CountryCode1, donecekPolicyInfo.IdentityCode1, _
                    donecekPolicyInfo.IdentityNo1, donecekPolicyInfo.Name1, _
                    donecekPolicyInfo.Surname1, donecekPolicyInfo.BirthDate1, _
                    donecekPolicyInfo.DriverLicenceNo1, donecekPolicyInfo.DriverLicenceGivenDate1, _
                    donecekPolicyInfo.DriverLicenceType1, donecekPolicyInfo.CountryCode2, _
                    donecekPolicyInfo.IdentityCode2, donecekPolicyInfo.IdentityNo2, _
                    donecekPolicyInfo.Name2, donecekPolicyInfo.Surname2, donecekPolicyInfo.BirthDate2, _
                    donecekPolicyInfo.DriverLicenceNo2, donecekPolicyInfo.DriverLicenceGivenDate2, _
                    donecekPolicyInfo.DriverLicenceType2, donecekPolicyInfo.CountryCode3, _
                    donecekPolicyInfo.IdentityCode3, donecekPolicyInfo.IdentityNo3, _
                    donecekPolicyInfo.Name3, donecekPolicyInfo.Surname3, donecekPolicyInfo.BirthDate3, _
                    donecekPolicyInfo.DriverLicenceNo3, donecekPolicyInfo.DriverLicenceGivenDate3, _
                    donecekPolicyInfo.DriverLicenceType3, donecekPolicyInfo.CountryCode4, _
                    donecekPolicyInfo.IdentityCode4, donecekPolicyInfo.IdentityNo4, _
                    donecekPolicyInfo.Name4, donecekPolicyInfo.Surname4, _
                    donecekPolicyInfo.BirthDate4, donecekPolicyInfo.DriverLicenceNo4, _
                    donecekPolicyInfo.DriverLicenceGivenDate4, donecekPolicyInfo.DriverLicenceType4, _
                    donecekPolicyInfo.CountryCode5, donecekPolicyInfo.IdentityCode5, _
                    donecekPolicyInfo.IdentityNo5, donecekPolicyInfo.Name5, _
                    donecekPolicyInfo.Surname5, donecekPolicyInfo.BirthDate5, _
                    donecekPolicyInfo.DriverLicenceNo5, donecekPolicyInfo.DriverLicenceGivenDate5, _
                    donecekPolicyInfo.DriverLicenceType5, donecekPolicyInfo.CountryCode6, _
                    donecekPolicyInfo.IdentityCode6, donecekPolicyInfo.IdentityNo6, _
                    donecekPolicyInfo.Name6, donecekPolicyInfo.Surname6, _
                    donecekPolicyInfo.BirthDate6, donecekPolicyInfo.DriverLicenceNo6, _
                    donecekPolicyInfo.DriverLicenceGivenDate6, donecekPolicyInfo.DriverLicenceType6, _
                    donecekPolicyInfo.InsurancePremium, donecekPolicyInfo.AssistantFees, _
                    donecekPolicyInfo.OtherFees, _
                    donecekPolicyInfo.BasePriceValue, donecekPolicyInfo.CCRateValue, _
                    donecekPolicyInfo.DamageRateValue, donecekPolicyInfo.AgeRateValue, _
                    donecekPolicyInfo.DamagelessRateValue, donecekPolicyInfo.Color, _
                    donecekPolicyInfo.ProductType, donecekPolicyInfo.FuelType, _
                    donecekPolicyInfo.SteeringSide, donecekPolicyInfo.AnyDriverRateValue, _
                    donecekPolicyInfo.PolicyPremium, donecekPolicyInfo.PolicyPremiumTL, _
                    donecekPolicyInfo.InsurancePremiumTL, donecekPolicyInfo.PublicValueTL, _
                    donecekPolicyInfo.DamageRate, donecekPolicyInfo.DamagelessRate, _
                    donecekPolicyInfo.AnyDriverRate, donecekPolicyInfo.AgeRate, donecekPolicyInfo.CCRate, _
                    donecekPolicyInfo.SBMCode, donecekPolicyInfo.Creditor, _
                    donecekPolicyInfo.FirstBeneficiary, donecekPolicyInfo.ExchangeRate, _
                    donecekPolicyInfo.AgencyRegisterCode, donecekPolicyInfo.TPNo, _
                    donecekPolicyInfo.BorderCode))

                End If

            End While

        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return PolicyInfolar

    End Function






End Class
