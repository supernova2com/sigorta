Imports System.Xml
Imports System.Xml.Serialization

Public Class Info

    Private FirmCode_v As String
    Private ProductCode_v As String
    Private ProductType_v As String
    Private PolicyType_v As String
    Private TariffCode_v As String
    Private AuthorizedDrivers_v As String
    Private EnginePower_v As Integer
    Private Capacity_v As Integer
    Private CarType_v As String
    Private ProductionYear_v As Integer
    Private UsingStyle_v As String
    Private FuelType_v As Integer
    Private SteeringSide_v As String
    Private PlateNumber_v As String
    Private PlateCountryCode_v As String
    Private SIdentityCountryCode_v As String
    Private SIdentityCode_v As String
    Private SIdentityNumber_v As String

    Private IdentityNumber1_v As String
    Private IdentityCountryCode1_v As String
    Private IdentityCode1_v As String
    Private IdentityBirthDate1_v As Nullable(Of Date)
    Private IdentityDriverLicenceNo1_v As String
    Private IdentityDriverLicenceGivenDate1_v As Nullable(Of Date)
    Private IdentityDriverLicenceType1_v As String

    Private IdentityNumber2_v As String
    Private IdentityCountryCode2_v As String
    Private IdentityCode2_v As String
    Private IdentityBirthDate2_v As Nullable(Of Date)
    Private IdentityDriverLicenceNo2_v As String
    Private IdentityDriverLicenceGivenDate2_v As Nullable(Of Date)
    Private IdentityDriverLicenceType2_v As String

    Private IdentityNumber3_v As String
    Private IdentityCountryCode3_v As String
    Private IdentityCode3_v As String
    Private IdentityBirthDate3_v As Nullable(Of Date)
    Private IdentityDriverLicenceNo3_v As String
    Private IdentityDriverLicenceGivenDate3_v As Nullable(Of Date)
    Private IdentityDriverLicenceType3_v As String

    Private IdentityNumber4_v As String
    Private IdentityCountryCode4_v As String
    Private IdentityCode4_v As String
    Private IdentityBirthDate4_v As Nullable(Of Date)
    Private IdentityDriverLicenceNo4_v As String
    Private IdentityDriverLicenceGivenDate4_v As Nullable(Of Date)
    Private IdentityDriverLicenceType4_v As String

    Private IdentityNumber5_v As String
    Private IdentityCountryCode5_v As String
    Private IdentityCode5_v As String
    Private IdentityBirthDate5_v As Nullable(Of Date)
    Private IdentityDriverLicenceNo5_v As String
    Private IdentityDriverLicenceGivenDate5_v As Nullable(Of Date)
    Private IdentityDriverLicenceType5_v As String

    Private IdentityNumber6_v As String
    Private IdentityCountryCode6_v As String
    Private IdentityCode6_v As String
    Private IdentityBirthDate6_v As Nullable(Of Date)
    Private IdentityDriverLicenceNo6_v As String
    Private IdentityDriverLicenceGivenDate6_v As Nullable(Of Date)
    Private IdentityDriverLicenceType6_v As String

    Private AgencyRegisterCode_v As String
    Private TPNo_v As String


    Public Sub New()
    End Sub


    Public Sub New(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal ProductType As String, ByVal PolicyType As String, _
    ByVal TariffCode As String, ByVal AuthorizedDrivers As String, ByVal EnginePower As Integer, _
    ByVal Capacity As Integer, ByVal CarType As String, ByVal ProductionYear As Integer, _
    ByVal UsingStyle As Integer, ByVal FuelType As Integer, ByVal SteeringSide As String, _
    ByVal PlateNumber As String, ByVal PlateCountryCode As String, ByVal SIdentityCountryCode As String, _
    ByVal SIdentityCode As String, ByVal SIdentityNumber As String, _
    ByVal IdentityNumber1 As String, _
    ByVal IdentityCountryCode1 As String, _
    ByVal IdentityCode1 As String, _
    ByVal IdentityBirthDate1 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceNo1 As String, _
    ByVal IdentityDriverLicenceGivenDate1 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceType1_v As String, _
    ByVal IdentityNumber2 As String, _
    ByVal IdentityCountryCode2 As String, _
    ByVal IdentityCode2 As String, _
    ByVal IdentityBirthDate2 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceNo2 As String, _
    ByVal IdentityDriverLicenceGivenDate2 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceType2 As String, _
    ByVal IdentityNumber3 As String, _
    ByVal IdentityCountryCode3 As String, _
    ByVal IdentityCode3 As String, _
    ByVal IdentityBirthDate3 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceNo3 As String, _
    ByVal IdentityDriverLicenceGivenDate3 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceType3 As String, _
    ByVal IdentityNumber4 As String, _
    ByVal IdentityCountryCode4 As String, _
    ByVal IdentityCode4 As String, _
    ByVal IdentityBirthDate4 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceNo4 As String, _
    ByVal IdentityDriverLicenceGivenDate4 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceType4 As String, _
    ByVal IdentityNumber5 As String, _
    ByVal IdentityCountryCode5 As String, _
    ByVal IdentityCode5 As String, _
    ByVal IdentityBirthDate5 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceNo5 As String, _
    ByVal IdentityDriverLicenceGivenDate5 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceType5 As String, _
    ByVal IdentityNumber6 As String, _
    ByVal IdentityCountryCode6 As String, _
    ByVal IdentityCode6 As String, _
    ByVal IdentityBirthDate6 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceNo6 As String, _
    ByVal IdentityDriverLicenceGivenDate6 As Nullable(Of Date), _
    ByVal IdentityDriverLicenceType6 As String, _
    ByVal AgencyRegisterCode As String, _
    ByVal TPNo As String)

        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.ProductType = ProductType
        Me.PolicyType = PolicyType
        Me.TariffCode = TariffCode
        Me.AuthorizedDrivers = AuthorizedDrivers
        Me.EnginePower = EnginePower
        Me.Capacity = Capacity
        Me.CarType = CarType
        Me.ProductionYear = ProductionYear
        Me.UsingStyle = UsingStyle
        Me.FuelType = FuelType
        Me.SteeringSide = SteeringSide
        Me.PlateNumber = PlateNumber
        Me.PlateCountryCode = PlateCountryCode
        Me.SIdentityCountryCode = SIdentityCountryCode
        Me.SIdentityCode = SIdentityCode
        Me.SIdentityNumber = SIdentityNumber

        Me.IdentityNumber1 = IdentityNumber1
        Me.IdentityCountryCode1 = IdentityCountryCode1
        Me.IdentityCode1 = IdentityCode1
        Me.IdentityBirthDate1 = IdentityBirthDate1
        Me.IdentityDriverLicenceNo1 = IdentityDriverLicenceNo1
        Me.IdentityDriverLicenceGivenDate1 = IdentityDriverLicenceGivenDate1
        Me.IdentityDriverLicenceType1 = IdentityDriverLicenceType1

        Me.IdentityNumber2 = IdentityNumber2
        Me.IdentityCountryCode2 = IdentityCountryCode2
        Me.IdentityCode2 = IdentityCode2
        Me.IdentityBirthDate2 = IdentityBirthDate2
        Me.IdentityDriverLicenceNo2 = IdentityDriverLicenceNo2
        Me.IdentityDriverLicenceGivenDate2 = IdentityDriverLicenceGivenDate2
        Me.IdentityDriverLicenceType2 = IdentityDriverLicenceType2

        Me.IdentityNumber3 = IdentityNumber3
        Me.IdentityCountryCode3 = IdentityCountryCode3
        Me.IdentityCode3 = IdentityCode3
        Me.IdentityBirthDate3 = IdentityBirthDate3
        Me.IdentityDriverLicenceNo3 = IdentityDriverLicenceNo3
        Me.IdentityDriverLicenceGivenDate3 = IdentityDriverLicenceGivenDate3
        Me.IdentityDriverLicenceType3 = IdentityDriverLicenceType3

        Me.IdentityNumber4 = IdentityNumber4
        Me.IdentityCountryCode4 = IdentityCountryCode4
        Me.IdentityCode4 = IdentityCode4
        Me.IdentityBirthDate4 = IdentityBirthDate4
        Me.IdentityDriverLicenceNo4 = IdentityDriverLicenceNo4
        Me.IdentityDriverLicenceGivenDate4 = IdentityDriverLicenceGivenDate4
        Me.IdentityDriverLicenceType4 = IdentityDriverLicenceType4

        Me.IdentityNumber5 = IdentityNumber5
        Me.IdentityCountryCode5 = IdentityCountryCode5
        Me.IdentityCode5 = IdentityCode5
        Me.IdentityBirthDate5 = IdentityBirthDate5
        Me.IdentityDriverLicenceNo5 = IdentityDriverLicenceNo5
        Me.IdentityDriverLicenceGivenDate5 = IdentityDriverLicenceGivenDate5
        Me.IdentityDriverLicenceType5 = IdentityDriverLicenceType5

        Me.IdentityNumber6 = IdentityNumber6
        Me.IdentityCountryCode6 = IdentityCountryCode6
        Me.IdentityCode6 = IdentityCode6
        Me.IdentityBirthDate6 = IdentityBirthDate6
        Me.IdentityDriverLicenceNo6 = IdentityDriverLicenceNo6
        Me.IdentityDriverLicenceGivenDate6 = IdentityDriverLicenceGivenDate6
        Me.IdentityDriverLicenceType6 = IdentityDriverLicenceType6

        Me.AgencyRegisterCode = AgencyRegisterCode
        Me.TPNo = TPNo



    End Sub


    Public Property FirmCode() As String
        Get
            Return FirmCode_v
        End Get
        Set(ByVal value As String)
            FirmCode_v = value
        End Set
    End Property


    Public Property ProductCode() As String
        Get
            Return ProductCode_v
        End Get
        Set(ByVal value As String)
            ProductCode_v = value
        End Set
    End Property

    Public Property ProductType() As String
        Get
            Return ProductType_v
        End Get
        Set(ByVal value As String)
            ProductType_v = value
        End Set
    End Property

    Public Property PolicyType() As String
        Get
            Return PolicyType_v
        End Get
        Set(ByVal value As String)
            PolicyType_v = value
        End Set
    End Property

    Public Property TariffCode() As String
        Get
            Return TariffCode_v
        End Get
        Set(ByVal value As String)
            TariffCode_v = value
        End Set
    End Property

    Public Property AuthorizedDrivers() As String
        Get
            Return AuthorizedDrivers_v
        End Get
        Set(ByVal value As String)
            AuthorizedDrivers_v = value
        End Set
    End Property

    Public Property EnginePower() As Integer
        Get
            Return EnginePower_v
        End Get
        Set(ByVal value As Integer)
            EnginePower_v = value
        End Set
    End Property

    Public Property Capacity() As Integer
        Get
            Return Capacity_v
        End Get
        Set(ByVal value As Integer)
            Capacity_v = value
        End Set
    End Property

    Public Property CarType() As String
        Get
            Return CarType_v
        End Get
        Set(ByVal value As String)
            CarType_v = value
        End Set
    End Property

    Public Property ProductionYear() As Integer
        Get
            Return ProductionYear_v
        End Get
        Set(ByVal value As Integer)
            ProductionYear_v = value
        End Set
    End Property


    Public Property UsingStyle() As String
        Get
            Return UsingStyle_v
        End Get
        Set(ByVal value As String)
            UsingStyle_v = value
        End Set
    End Property

    Public Property FuelType() As Integer
        Get
            Return FuelType_v
        End Get
        Set(ByVal value As Integer)
            FuelType_v = value
        End Set
    End Property


    Public Property SteeringSide() As String
        Get
            Return SteeringSide_v
        End Get
        Set(ByVal value As String)
            SteeringSide_v = value
        End Set
    End Property


    Public Property PlateNumber() As String
        Get
            Return PlateNumber_v
        End Get
        Set(ByVal value As String)
            PlateNumber_v = value
        End Set
    End Property

    Public Property PlateCountryCode() As String
        Get
            Return PlateCountryCode_v
        End Get
        Set(ByVal value As String)
            PlateCountryCode_v = value
        End Set
    End Property


    Public Property SIdentityCountryCode() As String
        Get
            Return SIdentityCountryCode_v
        End Get
        Set(ByVal value As String)
            SIdentityCountryCode_v = value
        End Set
    End Property

    Public Property SIdentityCode() As String
        Get
            Return SIdentityCode_v
        End Get
        Set(ByVal value As String)
            SIdentityCode_v = value
        End Set
    End Property

    Public Property SIdentityNumber() As String
        Get
            Return SIdentityNumber_v
        End Get
        Set(ByVal value As String)
            SIdentityNumber_v = value
        End Set
    End Property



    Public Property IdentityNumber1() As String
        Get
            Return IdentityNumber1_v
        End Get
        Set(ByVal value As String)
            IdentityNumber1_v = value
        End Set
    End Property


    Public Property IdentityCountryCode1() As String
        Get
            Return IdentityCountryCode1_v
        End Get
        Set(ByVal value As String)
            IdentityCountryCode1_v = value
        End Set
    End Property


    Public Property IdentityCode1() As String
        Get
            Return IdentityCode1_v
        End Get
        Set(ByVal value As String)
            IdentityCode1_v = value
        End Set
    End Property




    Public Property IdentityBirthDate1() As Nullable(Of Date)
        Get
            Return IdentityBirthDate1_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityBirthDate1_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceNo1() As String
        Get
            Return IdentityDriverLicenceNo1_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceNo1_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceGivenDate1() As Nullable(Of Date)
        Get
            Return IdentityDriverLicenceGivenDate1_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityDriverLicenceGivenDate1_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceType1() As String
        Get
            Return IdentityDriverLicenceType1_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceType1_v = value
        End Set
    End Property







    Public Property IdentityNumber2() As String
        Get
            Return IdentityNumber2_v
        End Get
        Set(ByVal value As String)
            IdentityNumber2_v = value
        End Set
    End Property


    Public Property IdentityCountryCode2() As String
        Get
            Return IdentityCountryCode2_v
        End Get
        Set(ByVal value As String)
            IdentityCountryCode2_v = value
        End Set
    End Property


    Public Property IdentityCode2() As String
        Get
            Return IdentityCode2_v
        End Get
        Set(ByVal value As String)
            IdentityCode2_v = value
        End Set
    End Property




    Public Property IdentityBirthDate2() As Nullable(Of Date)
        Get
            Return IdentityBirthDate2_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityBirthDate2_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceNo2() As String
        Get
            Return IdentityDriverLicenceNo2_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceNo2_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceGivenDate2() As Nullable(Of Date)
        Get
            Return IdentityDriverLicenceGivenDate2_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityDriverLicenceGivenDate2_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceType2() As String
        Get
            Return IdentityDriverLicenceType2_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceType2_v = value
        End Set
    End Property


    Public Property IdentityNumber3() As String
        Get
            Return IdentityNumber3_v
        End Get
        Set(ByVal value As String)
            IdentityNumber3_v = value
        End Set
    End Property


    Public Property IdentityCountryCode3() As String
        Get
            Return IdentityCountryCode3_v
        End Get
        Set(ByVal value As String)
            IdentityCountryCode3_v = value
        End Set
    End Property


    Public Property IdentityCode3() As String
        Get
            Return IdentityCode3_v
        End Get
        Set(ByVal value As String)
            IdentityCode3_v = value
        End Set
    End Property




    Public Property IdentityBirthDate3() As Nullable(Of Date)
        Get
            Return IdentityBirthDate3_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityBirthDate3_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceNo3() As String
        Get
            Return IdentityDriverLicenceNo3_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceNo3_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceGivenDate3() As Nullable(Of Date)
        Get
            Return IdentityDriverLicenceGivenDate3_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityDriverLicenceGivenDate3_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceType3() As String
        Get
            Return IdentityDriverLicenceType3_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceType3_v = value
        End Set
    End Property


    Public Property IdentityNumber4() As String
        Get
            Return IdentityNumber4_v
        End Get
        Set(ByVal value As String)
            IdentityNumber4_v = value
        End Set
    End Property


    Public Property IdentityCountryCode4() As String
        Get
            Return IdentityCountryCode4_v
        End Get
        Set(ByVal value As String)
            IdentityCountryCode4_v = value
        End Set
    End Property


    Public Property IdentityCode4() As String
        Get
            Return IdentityCode4_v
        End Get
        Set(ByVal value As String)
            IdentityCode4_v = value
        End Set
    End Property




    Public Property IdentityBirthDate4() As Nullable(Of Date)
        Get
            Return IdentityBirthDate4_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityBirthDate4_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceNo4() As String
        Get
            Return IdentityDriverLicenceNo4_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceNo4_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceGivenDate4() As Nullable(Of Date)
        Get
            Return IdentityDriverLicenceGivenDate4_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityDriverLicenceGivenDate4_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceType4() As String
        Get
            Return IdentityDriverLicenceType4_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceType4_v = value
        End Set
    End Property


    Public Property IdentityNumber5() As String
        Get
            Return IdentityNumber5_v
        End Get
        Set(ByVal value As String)
            IdentityNumber5_v = value
        End Set
    End Property


    Public Property IdentityCountryCode5() As String
        Get
            Return IdentityCountryCode5_v
        End Get
        Set(ByVal value As String)
            IdentityCountryCode5_v = value
        End Set
    End Property


    Public Property IdentityCode5() As String
        Get
            Return IdentityCode5_v
        End Get
        Set(ByVal value As String)
            IdentityCode5_v = value
        End Set
    End Property


    Public Property IdentityBirthDate5() As Nullable(Of Date)
        Get
            Return IdentityBirthDate5_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityBirthDate5_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceNo5() As String
        Get
            Return IdentityDriverLicenceNo5_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceNo5_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceGivenDate5() As Nullable(Of Date)
        Get
            Return IdentityDriverLicenceGivenDate5_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityDriverLicenceGivenDate5_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceType5() As String
        Get
            Return IdentityDriverLicenceType5_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceType5_v = value
        End Set
    End Property


    Public Property IdentityNumber6() As String
        Get
            Return IdentityNumber6_v
        End Get
        Set(ByVal value As String)
            IdentityNumber6_v = value
        End Set
    End Property


    Public Property IdentityCountryCode6() As String
        Get
            Return IdentityCountryCode6_v
        End Get
        Set(ByVal value As String)
            IdentityCountryCode6_v = value
        End Set
    End Property


    Public Property IdentityCode6() As String
        Get
            Return IdentityCode6_v
        End Get
        Set(ByVal value As String)
            IdentityCode6_v = value
        End Set
    End Property


    Public Property IdentityBirthDate6() As Nullable(Of Date)
        Get
            Return IdentityBirthDate6_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityBirthDate6_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceNo6() As String
        Get
            Return IdentityDriverLicenceNo6_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceNo6_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceGivenDate6() As Nullable(Of Date)
        Get
            Return IdentityDriverLicenceGivenDate6_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            IdentityDriverLicenceGivenDate6_v = value
        End Set
    End Property
    Public Property IdentityDriverLicenceType6() As String
        Get
            Return IdentityDriverLicenceType6_v
        End Get
        Set(ByVal value As String)
            IdentityDriverLicenceType6_v = value
        End Set
    End Property


    Public Property AgencyRegisterCode() As String
        Get
            Return AgencyRegisterCode_v
        End Get
        Set(ByVal value As String)
            AgencyRegisterCode_v = value
        End Set
    End Property

    Public Property TPNo() As String
        Get
            Return TPNo_v
        End Get
        Set(ByVal value As String)
            TPNo_v = value
        End Set
    End Property

End Class
