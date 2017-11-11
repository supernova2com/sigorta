Imports System.Data.SqlClient

Public Class CLASSPOLICYHESAP_ERISIM



    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim PolicyHesap As New CLASSPOLICYHESAP
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal PolicyHesap As CLASSPOLICYHESAP) As CLADBOPRESULT

        etkilenen = 0
   
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into PolicyHesap values (@FirmCode," + _
        "@ProductCode,@AgencyCode,@PolicyNumber,@ProductType," + _
        "@hPolicyPremium,@hInsurancePremium,@TariffCode,@CurrencyCode)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar, 3)
        param1.Direction = ParameterDirection.Input
        If PolicyHesap.FirmCode = "" Then
            param1.Value = System.DBNull.Value
        Else
            param1.Value = PolicyHesap.FirmCode
        End If
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductCode", SqlDbType.VarChar, 2)
        param2.Direction = ParameterDirection.Input
        If PolicyHesap.ProductCode = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = PolicyHesap.ProductCode
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@AgencyCode", SqlDbType.VarChar, 10)
        param3.Direction = ParameterDirection.Input
        If PolicyHesap.AgencyCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = PolicyHesap.AgencyCode
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20)
        param4.Direction = ParameterDirection.Input
        If PolicyHesap.PolicyNumber = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = PolicyHesap.PolicyNumber
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ProductType", SqlDbType.VarChar, 2)
        param5.Direction = ParameterDirection.Input
        If PolicyHesap.ProductType = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = PolicyHesap.ProductType
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@hPolicyPremium", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If PolicyHesap.hPolicyPremium = 0 Then
            param6.Value = 0
        Else
            param6.Value = PolicyHesap.hPolicyPremium
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@hInsurancePremium", SqlDbType.Decimal)
        param7.Direction = ParameterDirection.Input
        If PolicyHesap.hInsurancePremium = 0 Then
            param7.Value = 0
        Else
            param7.Value = PolicyHesap.hInsurancePremium
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@TariffCode", SqlDbType.VarChar, 5)
        param8.Direction = ParameterDirection.Input
        If PolicyHesap.TariffCode = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = PolicyHesap.TariffCode
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar, 3)
        param9.Direction = ParameterDirection.Input
        If PolicyHesap.CurrencyCode = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = PolicyHesap.CurrencyCode
        End If
        komut.Parameters.Add(param9)


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


    Public Function siltumu() As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "truncate table PolicyHesap"
        komut = New SqlCommand(sqlstr, db_baglanti)

        '600/60=10 dakika
        komut.CommandTimeout = 600

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

    Function hesaplaveekle(ByVal StartDate As Date, ByVal EndDate As Date)


        '1.ADIM TÜM TABLOYU SİL
        siltumu()


        '2. ADIM HESAPLA
        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim

        Dim istring As String
        Dim sqlstr As String
        Dim db_baglanti As SqlConnection
        Dim komut As New SqlCommand
        Dim FirmCode, ProductCode, AgencyCode, PolicyNumber, ProductType As String

        Dim hPolicyPremium As Decimal
        Dim hInsurancePremium As Decimal

        Dim zeyiller As New List(Of PolicyInfo)
        Dim ilkpyadatzeyili As New PolicyInfo

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select FirmCode,ProductCode,AgencyCode, " + _
        "PolicyNumber, ProductType " + _
        " from PolicyInfo where StartDate>=@baslangictarih and StartDate<=@bitistarih " + _
        " group by FirmCode,ProductCode,AgencyCode,PolicyNumber,ProductType"

        komut = New SqlCommand(sqlstr, db_baglanti)


        '600/60=10 dakika
        komut.CommandTimeout = 600

        Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = StartDate
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param2.Direction = ParameterDirection.Input
        param2.Value = EndDate
        komut.Parameters.Add(param2)


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

                If Not veri.Item("ProductType") Is System.DBNull.Value Then
                    ProductType = veri.Item("ProductType")
                End If

                hPolicyPremium = 0
                hInsurancePremium = 0

                zeyiller = PolicyInfo_erisim.zeyildoldur_ilgilipolice(FirmCode, ProductCode, AgencyCode, PolicyNumber, ProductType)
                ilkpyadatzeyili = PolicyInfo2_erisim.ilkpyadatzeyilibul(FirmCode, ProductCode, AgencyCode, PolicyNumber, ProductType)

                Dim PolicyHesap As New CLASSPOLICYHESAP

                'eğer ilk p yada t var ise
                If ilkpyadatzeyili.FirmCode <> "" Then

                    PolicyHesap.TariffCode = ilkpyadatzeyili.TariffCode
                    PolicyHesap.CurrencyCode = ilkpyadatzeyili.CurrencyCode

                    'eğer ilk p yada t zeyilinin start date in içinde ise
                    If ilkpyadatzeyili.StartDate >= StartDate Then
                        For Each itemzeyil As PolicyInfo In zeyiller
                            If itemzeyil.ZeylCode = "P" Then
                                hPolicyPremium = hPolicyPremium + itemzeyil.PolicyPremium
                                hInsurancePremium = hInsurancePremium + itemzeyil.InsurancePremium
                            End If
                            If itemzeyil.ZeylCode = "T" Then
                                hPolicyPremium = hPolicyPremium + itemzeyil.PolicyPremium
                                hInsurancePremium = hInsurancePremium + itemzeyil.InsurancePremium
                            End If
                            If itemzeyil.ZeylCode = "V" Then
                                hPolicyPremium = hPolicyPremium + itemzeyil.PolicyPremium
                                hInsurancePremium = hInsurancePremium + itemzeyil.InsurancePremium
                            End If
                            If itemzeyil.ZeylCode = "R" Then
                                hPolicyPremium = hPolicyPremium - itemzeyil.PolicyPremium
                                hInsurancePremium = hInsurancePremium - itemzeyil.InsurancePremium
                            End If
                            If itemzeyil.ZeylCode = "X" Then
                                hPolicyPremium = hPolicyPremium - itemzeyil.PolicyPremium
                                hInsurancePremium = hInsurancePremium - itemzeyil.InsurancePremium
                            End If
                        Next

                        '3. ADIM VERİTABANINA YAZ!
                        PolicyHesap.FirmCode = FirmCode
                        PolicyHesap.ProductCode = ProductCode
                        PolicyHesap.AgencyCode = AgencyCode
                        PolicyHesap.PolicyNumber = PolicyNumber
                        PolicyHesap.ProductType = ProductType

                        PolicyHesap.hPolicyPremium = hPolicyPremium
                        PolicyHesap.hInsurancePremium = hInsurancePremium
                        Ekle(PolicyHesap)


                    End If
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

    
    End Function

End Class
