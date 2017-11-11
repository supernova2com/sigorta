Imports System.Data.SqlClient

Public Class CLASSKIMLIKPLAKAPOLICEHASAR_ERISIM


    Dim istring As String


    Public Function kimlikte_hasaryadapolicevarmi(ByVal kimlikno As String, ByVal CountryCode As String) As String

        Dim damageinfo_erisim As New DamageInfo_Erisim
        Dim kimliktepolicehasar_erisim As New CLASSKIMLIKPLAKAPOLICEHASAR_ERISIM

        Dim donecekvarmi As String
        Dim policedevarmi As String = "Hayır"
        Dim hasardavarmi As String = "Hayır"

        policedevarmi = kimlikte_policevarmi_birayoncesi(kimlikno, CountryCode)
        hasardavarmi = kimlikte_hasarvarmi(kimlikno, CountryCode)

        'eğer poliçesi yoksa ve hasarıda yoksa Hayır
        If policedevarmi = "Hayır" And hasardavarmi = "Hayır" Then
            donecekvarmi = "Hayır"
        Else
            donecekvarmi = "Evet"
        End If

        Return donecekvarmi

    End Function



    'Öncelikle kimlik ile ilgili fonksiyonlar
    Public Function kimlikte_policevarmi_birayoncesi(ByVal kimlikno As String, ByVal CountryCode As String) As String

        Dim birayoncesi As DateTime
        birayoncesi = DateTime.Now.AddMonths(-1)

        Dim donecek As String
        Dim sqlstr As String
        Dim adet As Integer

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kesilmiskimlikgirilecekmi As String = "0"
        Dim kesilmiskimlik As String = ""
        Dim sqldevam1 As String = ""
        Dim sqldevam2 As String = ""


        If CountryCode = "601" Then
            If Len(kimlikno) = 10 Then
                kesilmiskimlik = Mid(kimlikno, 5, 6)
                sqldevam1 = " or (PolicyOwnerIdentityNo like '%" + kesilmiskimlik + "' or " + _
                 "IdentityNo1 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo2 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo3 like '%" + kesilmiskimlik + "'or " + _
                "IdentityNo4 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo5 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo6 like '%" + kesilmiskimlik + "')"
            End If
        End If

        If CountryCode = "601" Then
            If Len(kimlikno) = 10 Then
                kesilmiskimlikgirilecekmi = "1"
                kesilmiskimlik = Mid(kimlikno, 5, 6)
                sqldevam2 = " or (PolicyOwnerIdentityNo=@kesilmiskimlikno or " + _
                 "IdentityNo1=@kesilmiskimlikno or " + _
                "IdentityNo2=@kesilmiskimlikno or " + _
                "IdentityNo3=@kesilmiskimlikno or " + _
                "IdentityNo4=@kesilmiskimlikno or " + _
                "IdentityNo5=@kesilmiskimlikno or " + _
                "IdentityNo6=@kesilmiskimlikno) "
            End If
        End If

        sqlstr = "select count(*)" + _
        " from PolicyInfo where (PolicyOwnerIdentityNo=@kimlikno or " + _
        "IdentityNo1=@kimlikno or " + _
        "IdentityNo2=@kimlikno or " + _
        "IdentityNo3=@kimlikno or " + _
        "IdentityNo4=@kimlikno or " + _
        "IdentityNo5=@kimlikno or " + _
        "IdentityNo6=@kimlikno) " + _
        sqldevam1 + _
        sqldevam2 + _
        " and " + _
        "ArrangeDate<=@ArrangeDate"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kimlikno
        komut.Parameters.Add(param1)

        If kesilmiskimlikgirilecekmi = "1" Then
            Dim param2 As New SqlParameter("@kesilmiskimlikno", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = kesilmiskimlik
            komut.Parameters.Add(param2)
        End If

        Dim param3 As New SqlParameter("@ArrangeDate", SqlDbType.Date)
        param3.Direction = ParameterDirection.Input
        param3.Value = birayoncesi
        komut.Parameters.Add(param3)

        Dim maxkayit1 = komut.ExecuteScalar()
        If Not maxkayit1 Is System.DBNull.Value Then
            adet = maxkayit1
        End If

        If adet > 0 Then
            donecek = "Evet"
        Else
            donecek = "Hayır"
        End If

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function



    Public Function kimlikte_hasarvarmi(ByVal kimlikno As String, ByVal CountryCode As String) As String

        Dim donecek As String
        Dim sqlstr As String
        Dim adet As Integer

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kesilmiskimlikgirilecekmi As String = "0"
        Dim kesilmiskimlik As String = ""
        Dim sqldevam1, sqldevam2 As String
        sqldevam1 = ""
        sqldevam2 = ""

        If CountryCode = "601" Then
            If Len(kimlikno) = 10 Then
                kesilmiskimlikgirilecekmi = "1"
                kesilmiskimlik = Mid(kimlikno, 5, 6)
                sqldevam2 = " or DriverIdentityNo=@kesilmiskimlikno"
            End If
        End If

        sqlstr = "select count(*)" + _
        " from DamageInfo where DriverIdentityNo=@kimlikno" + sqldevam1 + sqldevam2



        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kimlikno
        komut.Parameters.Add(param1)

        If kesilmiskimlikgirilecekmi = "1" Then
            Dim param2 As New SqlParameter("@kesilmiskimlikno", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = kesilmiskimlik
            komut.Parameters.Add(param2)
        End If


        Dim maxkayit1 = komut.ExecuteScalar()
        If Not maxkayit1 Is System.DBNull.Value Then
            adet = maxkayit1
        End If

        If adet > 0 Then
            donecek = "Evet"
        Else
            donecek = "Hayır"
        End If

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function



    Public Function kimlikte_yillaragorepolicesayisinagore_maxindirimhakki(ByVal kimlikno As String, _
    ByVal identitycountrycode As String) As Integer

        Dim PolicyInfo2_Erisim As New PolicyInfo2_Erisim

        Dim katsayi As Integer = 0
        Dim maxindirimhak As Integer = 0
        Dim araliklar As New List(Of CLASSARALIK)
        Dim araliksayi As Integer = 0
        Dim damageinfoservice_erisim As New DamageInfoService_Erisim
        araliklar = damageinfoservice_erisim.araliklaribul()
        araliksayi = araliklar.Count

        For Each Item As CLASSARALIK In araliklar
            If PolicyInfo2_Erisim.kimligegore_aralik_icerisindeki_policesayisi(Item.baslangic, Item.bitis, kimlikno, identitycountrycode) > 0 Then
                katsayi = katsayi + 1
            End If
        Next

        maxindirimhak = katsayi * 10
        If maxindirimhak > 40 Then
            maxindirimhak = 40
        End If

        Return maxindirimhak

    End Function



    Public Function kimlikte_sistemkayittarihegore_maxindirimhakki(ByVal identitycountrycode As String, ByVal kimlikno As String) As Integer

        Dim simdikiyil As Integer = DateTime.Now.Year
        Dim maxindirimhak As Integer = 0
        Dim yil As Integer
        Dim sqlstr As String

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim sqldevam1, sqldevam2 As String
        Dim kesilmiskimlikgirilecekmi As String = "0"
        Dim kesilmiskimlik As String = ""

        If identitycountrycode = "601" Then
            If Len(kimlikno) = 10 Then
                kesilmiskimlik = Mid(kimlikno, 5, 6)
                sqldevam1 = " or (PolicyOwnerIdentityNo like '%" + kesilmiskimlik + "' or " + _
                 "IdentityNo1 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo2 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo3 like '%" + kesilmiskimlik + "'or " + _
                "IdentityNo4 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo5 like '%" + kesilmiskimlik + "' or " + _
                "IdentityNo6 like '%" + kesilmiskimlik + "')"
            End If
        End If

        If identitycountrycode = "601" Then
            If Len(kimlikno) = 10 Then
                kesilmiskimlikgirilecekmi = "1"
                kesilmiskimlik = Mid(kimlikno, 5, 6)
                sqldevam2 = " or (PolicyOwnerIdentityNo=@kesilmiskimlikno or " + _
                 "IdentityNo1=@kesilmiskimlikno or " + _
                "IdentityNo2=@kesilmiskimlikno or " + _
                "IdentityNo3=@kesilmiskimlikno or " + _
                "IdentityNo4=@kesilmiskimlikno or " + _
                "IdentityNo5=@kesilmiskimlikno or " + _
                "IdentityNo6=@kesilmiskimlikno) "
            End If
        End If




        sqlstr = "select DATEPART(year,StartDate) as yil" + _
        " from PolicyInfo where PolicyOwnerIdentityNo=@kimlikno or " + _
        "IdentityNo1=@kimlikno or " + _
        "IdentityNo2=@kimlikno or " + _
        "IdentityNo3=@kimlikno or " + _
        "IdentityNo4=@kimlikno or " + _
        "IdentityNo5=@kimlikno or " + _
        "IdentityNo6=@kimlikno " + _
        sqldevam1 + _
        sqldevam2 + _
        "order by StartDate"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kimlikno
        komut.Parameters.Add(param1)


        Dim param2 As New SqlParameter("@kesilmiskimlikno", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kesilmiskimlik
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    yil = veri.Item("yil")
                Else
                    yil = 0
                End If
                Exit While

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        If yil = 0 Then
            maxindirimhak = 0
            Return maxindirimhak
        End If

        If (simdikiyil - yil) < 0 Then
            maxindirimhak = 0
            Return maxindirimhak
        End If

        If yil > 0 Then
            maxindirimhak = (simdikiyil - yil) * 10
            Return maxindirimhak
        End If

    End Function






    'Plaka ile ilgili fonksiyonlar
    Public Function plakada_policevarmi(ByVal PlateNumber As String) As String

        Dim donecek As String
        donecek = "Hayır"

        If PlateNumber = "" Or PlateNumber Is Nothing Then
            donecek = "Hayır"
            Return donecek
        End If

        Dim istring As String
        Dim sqlstr As String
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from PolicyInfo where PlateNumber=@PlateNumber"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlateNumber
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            donecek = "Hayır"
        Else
            donecek = "Evet"
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function


    Public Function plakada_sistemkayittarihegore_maxindirimhakki(ByVal PlateNumber As String) As Integer

        Dim simdikiyil As Integer = DateTime.Now.Year
        Dim maxindirimhak As Integer = 0
        Dim yil As Integer
        Dim sqlstr As String

        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim kiralikmi As String
        Dim kiralikplaka_ek, sql_kiralikaracdevam As String
        kiralikmi = "Hayır"
        'Kiralık araçlar için
        If Len(PlateNumber) > 1 Then
            'eğer başı Z ile başlıyor ise
            If Mid(PlateNumber, 1, 1) = "Z" Then
                kiralikplaka_ek = Mid(PlateNumber, 2, Len(PlateNumber)) + "Z"
                sql_kiralikaracdevam = " or PlateNumber=@PlateNumber2"
                kiralikmi = "Evet"
            End If
            'eğer sonu z ile bitiyor ise
            If Mid(PlateNumber, Len(PlateNumber), 1) = "Z" Then
                kiralikplaka_ek = "Z" + Mid(PlateNumber, 1, Len(PlateNumber) - 1)
                sql_kiralikaracdevam = " or PlateNumber=@PlateNumber2"
                kiralikmi = "Evet"
            End If
        End If

        sqlstr = "select DATEPART(year,StartDate) as yil from PolicyInfo where PlateNumber=@PlateNumber " + _
        sql_kiralikaracdevam + " " + _
        " order by StartDate"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlateNumber
        komut.Parameters.Add(param1)

        If kiralikmi = "Evet" Then
            Dim param2 As New SqlParameter("@PlateNumber2", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = kiralikplaka_ek
            komut.Parameters.Add(param2)
        End If

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("yil") Is System.DBNull.Value Then
                    yil = veri.Item("yil")
                Else
                    yil = 0
                End If
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        If yil = 0 Then
            maxindirimhak = 0
            Return maxindirimhak
        End If

        If (simdikiyil - yil) < 0 Then
            maxindirimhak = 0
            Return maxindirimhak
        End If

        If yil > 0 Then
            maxindirimhak = (simdikiyil - yil) * 10
            Return maxindirimhak
        End If

    End Function


    Function plakada_canlipolicevarmi(ByVal plaka As String, ByVal p_ProductCode As String, _
    ByVal p_FirmCode As String) As Integer

        Dim donecek As Integer = 0

        If plaka = "" Or plaka Is Nothing Then
            donecek = 0
            Return donecek
        End If

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim

        Dim renk As String
        Dim istring As String
        Dim sqlstr As String
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select FirmCode,ProductCode,AgencyCode," + _
        "PolicyNumber,TecditNumber,ZeylCode, ZeylNo, ProductType" + _
        " from PolicyInfo where PlateNumber=@PlateNumber and " + _
        "ProductCode=@ProductCode and FirmCode<>@FirmCode"

        komut = New SqlCommand(sqlstr, db_baglanti)

        '600/60=10 dakika
        komut.CommandTimeout = 600

        Dim param1 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = plaka
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = p_ProductCode
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = p_FirmCode
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("FirmCode") Is System.DBNull.Value Then
                    FirmCode = veri.Item("FirmCode")
                End If

                If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                    ProductCode = veri.Item("ProductCode")
                End If

                If Not veri.Item("AgencyCode") Is System.DBNull.Value Then
                    AgencyCode = veri.Item("AgencyCode")
                End If

                If Not veri.Item("PolicyNumber") Is System.DBNull.Value Then
                    PolicyNumber = veri.Item("PolicyNumber")
                End If

                If Not veri.Item("TecditNumber") Is System.DBNull.Value Then
                    TecditNumber = veri.Item("TecditNumber")
                End If

                If Not veri.Item("ZeylCode") Is System.DBNull.Value Then
                    ZeylCode = veri.Item("ZeylCode")
                End If

                If Not veri.Item("ZeylNo") Is System.DBNull.Value Then
                    ZeylNo = veri.Item("ZeylNo")
                End If

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    ProductType = veri.Item("ProductType")
                End If

                renk = PolicyInfo_erisim.renkbul(FirmCode, ProductCode, AgencyCode, _
                PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

                If renk = "green" Then
                    donecek = 1
                    Exit While
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecek

    End Function








End Class
