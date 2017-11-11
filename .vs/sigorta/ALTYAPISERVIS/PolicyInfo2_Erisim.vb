Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Globalization.CultureInfo
Imports System.Globalization
Imports System.Text

Public Class PolicyInfo2_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer

    Dim aractarife As New CLASSARACTARIFE
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull
    Dim kimlikplakapolicehasar_erisim As New CLASSKIMLIKPLAKAPOLICEHASAR_ERISIM



    Public Function sonzeyilmi_kontrol(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal TecditNumber As String, ByVal ZeylCode As String, ByVal ZeylNo As String, _
    ByVal ProductType As String) As String

        Dim kacadet As Integer
        Dim sonzeyilmi = "Hayır"

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim zeyiller As New List(Of PolicyInfo)

        zeyiller = PolicyInfo_erisim.zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, ProductType)
        kacadet = zeyiller.Count

        Dim i As Integer = 1

        For Each zeyilitem In zeyiller
            If i = kacadet Then
                If zeyilitem.FirmCode = FirmCode And zeyilitem.ProductCode = ProductCode And _
                zeyilitem.AgencyCode = AgencyCode And zeyilitem.PolicyNumber = PolicyNumber And _
                zeyilitem.TecditNumber = TecditNumber And zeyilitem.ZeylCode = ZeylCode And _
                zeyilitem.ZeylNo = ZeylNo Then
                    sonzeyilmi = "Evet"
                End If
            End If
            i = i + 1
        Next

        Return sonzeyilmi


    End Function

    Public Function sonzeyilbul(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal TecditNumber As String, ByVal ZeylCode As String, ByVal ZeylNo As String, _
    ByVal ProductType As String) As PolicyInfo

        Dim kacadet As Integer
        Dim sonzeyil As New PolicyInfo

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim zeyiller As New List(Of PolicyInfo)

        zeyiller = PolicyInfo_erisim.zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, ProductType)
        kacadet = zeyiller.Count

        Dim i As Integer = 1

        For Each zeyilitem In zeyiller
            If i = kacadet Then
                sonzeyil = zeyilitem
            End If
            i = i + 1
        Next

        Return sonzeyil


    End Function


    Public Function sonpyadatzeyilibul(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal ProductType As String) As PolicyInfo

        Dim kacadet As Integer
        Dim sonpyadatzeyili As New PolicyInfo

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim zeyiller As New List(Of PolicyInfo)

        zeyiller = PolicyInfo_erisim.zeyildoldur_ilgilipolice_tersten(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, ProductType)
        kacadet = zeyiller.Count

        Dim i As Integer = 1

        For Each zeyilitem In zeyiller
            If zeyilitem.ZeylCode = "P" Or zeyilitem.ZeylCode = "T" Then
                sonpyadatzeyili = zeyilitem
                Exit For
            End If
        Next

        Return sonpyadatzeyili

    End Function


    Public Function ilkpyadatzeyilibul(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal ProductType As String) As PolicyInfo

        Dim kacadet As Integer
        Dim sonpyadatzeyili As New PolicyInfo

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim zeyiller As New List(Of PolicyInfo)

        zeyiller = PolicyInfo_erisim.zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, ProductType)
        kacadet = zeyiller.Count

        Dim i As Integer = 1

        For Each zeyilitem In zeyiller
            If zeyilitem.ZeylCode = "P" Or zeyilitem.ZeylCode = "T" Then
                sonpyadatzeyili = zeyilitem
                Exit For
            End If
        Next

        Return sonpyadatzeyili

    End Function

   
   


    '--- İLGİLİ PLAKANIN BAŞKA TARIFFCODE İLE POLİÇESİ VAR MI? ----------------------
    Function ayniplakabaskatariffcodesirketsiz_varmi(ByVal p_TariffCode As String, _
    ByVal p_ProductCode As String, ByVal p_PlateNumber As String, _
    ByVal p_StartDate As Date, ByVal p_PolicyType As Integer, _
    ByVal p_PlateCountryCode As String) As String

        Dim EndDate As DateTime
        Dim renk As String
        Dim PolicyInfo_Erisim As New PolicyInfo_Erisim

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        'primary key tanımlar ----
        Dim ProductCode, FirmCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim veri As SqlDataReader
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from PolicyInfo where " + _
        " TariffCode<>@TariffCode " + _
        "and ProductCode=@ProductCode " + _
        "and PlateNumber=@PlateNumber " + _
        "and PolicyType=@PolicyType " + _
        "and PlateCountryCode=@PlateCountryCode"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = p_TariffCode
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = p_ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = p_PlateNumber
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyType", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = p_PolicyType
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@PlateCountryCode", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        param5.Value = p_PlateCountryCode
        komut.Parameters.Add(param5)

        veri = komut.ExecuteReader
        While veri.Read()

            If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                FirmCode = CStr(veri.Item("FirmCode"))
            Else
                FirmCode = ""
            End If
            If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                ProductCode = CStr(veri.Item("ProductCode"))
            Else
                ProductCode = ""
            End If
            If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                AgencyCode = CStr(veri.Item("AgencyCode"))
            Else
                AgencyCode = ""
            End If
            If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                PolicyNumber = CStr(veri.Item("PolicyNumber"))
            Else
                PolicyNumber = ""
            End If
            If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                TecditNumber = CStr(veri.Item("TecditNumber"))
            Else
                TecditNumber = ""
            End If
            If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                ZeylCode = CStr(veri.Item("ZeylCode"))
            Else
                ZeylCode = ""
            End If
            If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                ZeylNo = CStr(veri.Item("ZeylNo"))
            Else
                ZeylNo = ""
            End If
            If Not veri.Item("ProductType") Is System.DBNull.Value Then
                ProductType = CStr(veri.Item("ProductType"))
            Else
                ProductType = ""
            End If

            If Not veri.Item("EndDate") Is System.DBNull.Value Then
                EndDate = veri.Item("EndDate")
            Else
                EndDate = "00:00:00"
            End If

            'renk bul -------------- 
            renk = PolicyInfo_Erisim.renkbul(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
            TecditNumber, ZeylCode, ZeylNo, ProductType)

            'bu poliçe aktif --------------
            If renk = "green" Then
                If sonzeyilmi_kontrol(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
                   TecditNumber, ZeylCode, ZeylNo, ProductType) = "Evet" Then
                    If p_StartDate < EndDate Then
                        varmi = "Evet"
                        Exit While
                    End If
                End If
            End If

        End While

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function

    'Kimlik -------------------------
    Public Function kimligegore_aralik_icerisindeki_policesayisi(ByVal aralikbaslangic As Date, ByVal aralikbitis As Date, _
    ByVal kimlikno As String, ByVal identitycountrycode As String) As Integer

        Dim kesilmiskimlikno As String
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)

        If identitycountrycode = "601" Then
            If Len(kimlikno) = 10 Then
                kesilmiskimlikno = Mid(kimlikno, 5, 6)
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PolicyOwnerIdentityNo", "=", kesilmiskimlikno, " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo1", "=", kesilmiskimlikno, " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo2", "=", kesilmiskimlikno, " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo3", "=", kesilmiskimlikno, " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo4", "=", kesilmiskimlikno, " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo5", "=", kesilmiskimlikno, " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo6", "=", kesilmiskimlikno, " ) or "))
            End If
        End If

        Dim kacadet As Integer = 0
        Dim genericislem_Erisim As New CLASSGENERICISLEM_ERISIM
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PolicyOwnerIdentityNo", "=", kimlikno, " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo1", "=", kimlikno, " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo2", "=", kimlikno, " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo3", "=", kimlikno, " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo4", "=", kimlikno, " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo5", "=", kimlikno, " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "IdentityNo6", "=", kimlikno, " ) and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "StartDate", ">=", aralikbitis, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", "<=", aralikbaslangic, " ) and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "ZeylCode", "=", "P", "  or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeylCode", "=", "T", ") "))

        kacadet = genericislem_Erisim.countgeneric(site.sistemveritabaniad, "PolicyInfo", "count(*)", fieldopvalues)
        Return kacadet

    End Function


   



    'Plaka--------------------
    Public Function plakayagore_aralik_icerisindeki_policesayisi(ByVal aralikbaslangic As Date, ByVal aralikbitis As Date, _
    ByVal PlateNumber As String, ByVal identitycountrycode As String) As Integer

        Dim kesilmiskimlikno As String
        Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)

        Dim kiralikplaka_ek As String
        'Kiralık araçlar için
        If Len(PlateNumber) > 1 Then
            'eğer başı Z ile başlıyor ise
            If Mid(PlateNumber, 1, 1) = "Z" Then
                kiralikplaka_ek = Mid(PlateNumber, 2, Len(PlateNumber)) + "Z"
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PlateNumber", "=", kiralikplaka_ek, " and "))
            End If
            'eğer sonu Z ile bitiyor ise
            If Mid(PlateNumber, Len(PlateNumber), 1) = "Z" Then
                kiralikplaka_ek = "Z" + Mid(PlateNumber, 1, Len(PlateNumber) - 1)
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PlateNumber", "=", kiralikplaka_ek, " and "))
            End If
        End If

        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PlateNumber", "=", PlateNumber, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "ZeylCode", "=", "P", "  or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeylCode", "=", "T", ") and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "StartDate", ">=", aralikbitis, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", "<=", aralikbaslangic, " )"))

        Dim kacadet As Integer = 0
        Dim genericislem_Erisim As New CLASSGENERICISLEM_ERISIM
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        kacadet = genericislem_Erisim.countgeneric(site.sistemveritabaniad, "PolicyInfo", "count(*)", fieldopvalues)
        Return kacadet

    End Function


    Public Function plakada_yillaragorepolicesayisinagore_maxindirimhakki(ByVal kimlikno As String, _
    ByVal identitycountrycode As String) As Integer

        Dim katsayi As Integer = 0
        Dim maxindirimhak As Integer = 0
        Dim araliklar As New List(Of CLASSARALIK)
        Dim araliksayi As Integer = 0
        Dim damageinfoservice_erisim As New DamageInfoService_Erisim
        araliklar = damageinfoservice_erisim.araliklaribul()
        araliksayi = araliklar.Count

        For Each Item As CLASSARALIK In araliklar
            If plakayagore_aralik_icerisindeki_policesayisi(Item.baslangic, Item.bitis, kimlikno, identitycountrycode) > 0 Then
                katsayi = katsayi + 1
            End If
        Next

        maxindirimhak = katsayi * 10
        If maxindirimhak > 40 Then
            maxindirimhak = 40
        End If

        Return maxindirimhak

    End Function



End Class
