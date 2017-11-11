Public Class PolicyInfo

    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private TecditNumber_v As String
    Private ZeylCode_v As String
    Private ZeylNo_v As String
    Private PolicyType_v As Integer
    Private PolicyOwnerCountryCode_v As String
    Private PolicyOwnerIdentityCode_v As String
    Private PolicyOwnerIdentityNo_v As String
    Private PolicyOwnerName_v As String
    Private PolicyOwnerSurname_v As String
    Private PolicyOwnerBirthDate_v As Nullable(Of Date)
    Private AddressLine1_v As String
    Private AddressLine2_v As String
    Private AddressLine3_v As String
    Private PlateCountryCode_v As String
    Private PlateNumber_v As String
    Private Brand_v As String
    Private Model_v As String
    Private ChassisNumber_v As String
    Private EngineNumber_v As String
    Private EnginePower_v As Integer
    Private ProductionYear_v As Integer
    Private Capacity_v As Integer
    Private CarType_v As String
    Private UsingStyle_v As String
    Private TariffCode_v As String
    Private ArrangeDate_v As Nullable(Of Date)
    Private StartDate_v As Nullable(Of DateTime)
    Private EndDate_v As Nullable(Of Date)
    Private Material_v As Decimal
    Private Corporal_v As Decimal
    Private CurrencyCode_v As String
    Private PublicValue_v As Decimal
    Private AuthorizedDrivers_v As String
    Private CountryCode1_v As String
    Private IdentityCode1_v As String
    Private IdentityNo1_v As String
    Private Name1_v As String
    Private Surname1_v As String
    Private BirthDate1_v As Nullable(Of Date)
    Private DriverLicenceNo1_v As String
    Private DriverLicenceGivenDate1_v As Nullable(Of Date)
    Private DriverLicenceType1_v As String
    Private CountryCode2_v As String
    Private IdentityCode2_v As String
    Private IdentityNo2_v As String
    Private Name2_v As String
    Private Surname2_v As String
    Private BirthDate2_v As Nullable(Of Date)
    Private DriverLicenceNo2_v As String
    Private DriverLicenceGivenDate2_v As Nullable(Of Date)
    Private DriverLicenceType2_v As String
    Private CountryCode3_v As String
    Private IdentityCode3_v As String
    Private IdentityNo3_v As String
    Private Name3_v As String
    Private Surname3_v As String
    Private BirthDate3_v As Nullable(Of Date)
    Private DriverLicenceNo3_v As String
    Private DriverLicenceGivenDate3_v As Nullable(Of Date)
    Private DriverLicenceType3_v As String
    Private CountryCode4_v As String
    Private IdentityCode4_v As String
    Private IdentityNo4_v As String
    Private Name4_v As String
    Private Surname4_v As String
    Private BirthDate4_v As Nullable(Of Date)
    Private DriverLicenceNo4_v As String
    Private DriverLicenceGivenDate4_v As Nullable(Of Date)
    Private DriverLicenceType4_v As String
    Private CountryCode5_v As String
    Private IdentityCode5_v As String
    Private IdentityNo5_v As String
    Private Name5_v As String
    Private Surname5_v As String
    Private BirthDate5_v As Nullable(Of Date)
    Private DriverLicenceNo5_v As String
    Private DriverLicenceGivenDate5_v As Nullable(Of Date)
    Private DriverLicenceType5_v As String
    Private CountryCode6_v As String
    Private IdentityCode6_v As String
    Private IdentityNo6_v As String
    Private Name6_v As String
    Private Surname6_v As String
    Private BirthDate6_v As Nullable(Of Date)
    Private DriverLicenceNo6_v As String
    Private DriverLicenceGivenDate6_v As Nullable(Of Date)
    Private DriverLicenceType6_v As String
    Private InsurancePremium_v As Decimal
    Private AssistantFees_v As Decimal
    Private OtherFees_v As Decimal
    Private BasePriceValue_v As Decimal
    Private CCRateValue_v As Decimal
    Private DamageRateValue_v As Decimal
    Private AgeRateValue_v As Decimal
    Private DamagelessRateValue_v As Decimal
    Private Color_v As String

    Private ProductType_v As String
    Private FuelType_v As Integer
    Private SteeringSide_v As String
    Private AnyDriverRateValue_v As Decimal
    Private PolicyPremium_v As Decimal
    Private PolicyPremiumTL_v As Decimal
    Private InsurancePremiumTL_v As Decimal
    Private PublicValueTL_v As Decimal
    Private DamageRate_v As Integer
    Private DamagelessRate_v As Integer
    Private AnyDriverRate_v As Integer
    Private AgeRate_v As Integer
    Private CCRate_v As Integer
    Private SBMCode_v As String

    Private Creditor_v As Integer
    Private FirstBeneficiary_v As String
    Private ExchangeRate_v As Decimal

    Private AgencyRegisterCode_v As String
    Private TPNo_v As String

    Private BorderCode_v As String





    Public Sub New()
    End Sub

    Public Sub New(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal PolicyType As Integer, ByVal PolicyOwnerCountryCode As String, _
    ByVal PolicyOwnerIdentityCode As String, ByVal PolicyOwnerIdentityNo As String, ByVal PolicyOwnerName As String, _
    ByVal PolicyOwnerSurname As String, ByVal PolicyOwnerBirthDate As Date, ByVal AddressLine1 As String, _
    ByVal AddressLine2 As String, ByVal AddressLine3 As String, ByVal PlateCountryCode As String, _
    ByVal PlateNumber As String, ByVal Brand As String, ByVal Model As String, _
    ByVal ChassisNumber As String, ByVal EngineNumber As String, ByVal EnginePower As Integer, _
    ByVal ProductionYear As Integer, ByVal Capacity As Integer, ByVal CarType As String, _
    ByVal UsingStyle As String, ByVal TariffCode As String, ByVal ArrangeDate As Date, _
    ByVal StartDate As DateTime, ByVal EndDate As Date, ByVal Material As Decimal, _
    ByVal Corporal As Decimal, ByVal CurrencyCode As String, ByVal PublicValue As Decimal, _
    ByVal AuthorizedDrivers As String, ByVal CountryCode1 As String, ByVal IdentityCode1 As String, _
    ByVal IdentityNo1 As String, ByVal Name1 As String, ByVal Surname1 As String, _
    ByVal BirthDate1 As Date, ByVal DriverLicenceNo1 As String, ByVal DriverLicenceGivenDate1 As Date, _
    ByVal DriverLicenceType1 As String, ByVal CountryCode2 As String, ByVal IdentityCode2 As String, _
    ByVal IdentityNo2 As String, ByVal Name2 As String, ByVal Surname2 As String, _
    ByVal BirthDate2 As Date, ByVal DriverLicenceNo2 As String, ByVal DriverLicenceGivenDate2 As Date, _
    ByVal DriverLicenceType2 As String, ByVal CountryCode3 As String, ByVal IdentityCode3 As String, _
    ByVal IdentityNo3 As String, ByVal Name3 As String, ByVal Surname3 As String, _
    ByVal BirthDate3 As Date, ByVal DriverLicenceNo3 As String, ByVal DriverLicenceGivenDate3 As Date, _
    ByVal DriverLicenceType3 As String, ByVal CountryCode4 As String, ByVal IdentityCode4 As String, _
    ByVal IdentityNo4 As String, ByVal Name4 As String, ByVal Surname4 As String, _
    ByVal BirthDate4 As Date, ByVal DriverLicenceNo4 As String, ByVal DriverLicenceGivenDate4 As Date, _
    ByVal DriverLicenceType4 As String, ByVal CountryCode5 As String, ByVal IdentityCode5 As String, _
    ByVal IdentityNo5 As String, ByVal Name5 As String, ByVal Surname5 As String, _
    ByVal BirthDate5 As Date, ByVal DriverLicenceNo5 As String, ByVal DriverLicenceGivenDate5 As Date, _
    ByVal DriverLicenceType5 As String, ByVal CountryCode6 As String, ByVal IdentityCode6 As String, _
    ByVal IdentityNo6 As String, ByVal Name6 As String, ByVal Surname6 As String, _
    ByVal BirthDate6 As Date, ByVal DriverLicenceNo6 As String, ByVal DriverLicenceGivenDate6 As Date, _
    ByVal DriverLicenceType6 As String, ByVal InsurancePremium As Decimal, ByVal AssistantFees As Decimal, _
    ByVal OtherFees As Decimal, ByVal BasePriceValue As Decimal, _
    ByVal CCRateValue As Decimal, ByVal DamageRateValue As Decimal, ByVal AgeRateValue As Decimal, _
    ByVal DamagelessRateValue As Decimal, ByVal Color As String, _
    ByVal ProductType As String, ByVal FuelType As Integer, ByVal SteeringSide As String, _
    ByVal AnyDriverRateValue As Decimal, ByVal PolicyPremium As Decimal, _
    ByVal PolicyPremiumTL As Decimal, ByVal InsurancePremiumTL As Decimal, _
    ByVal PublicValueTL As Decimal, ByVal DamageRate As Integer, ByVal DamagelessRate As Integer, _
    ByVal AnyDriverRate As Integer, ByVal AgeRate As Integer, ByVal CCRate As Integer, _
    ByVal SBMCode As String, ByVal Creditor As Integer, ByVal FirstBeneficiary As String, _
    ByVal ExchangeRate As Decimal, ByVal AgencyRegisterCode As String, ByVal TPNo As String, _
    ByVal BorderCode As String)


        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.TecditNumber = TecditNumber
        Me.ZeylCode = ZeylCode
        Me.ZeylNo = ZeylNo
        Me.PolicyType = PolicyType
        Me.PolicyOwnerCountryCode = PolicyOwnerCountryCode
        Me.PolicyOwnerIdentityCode = PolicyOwnerIdentityCode
        Me.PolicyOwnerIdentityNo = PolicyOwnerIdentityNo
        Me.PolicyOwnerName = PolicyOwnerName
        Me.PolicyOwnerSurname = PolicyOwnerSurname
        Me.PolicyOwnerBirthDate = PolicyOwnerBirthDate
        Me.AddressLine1 = AddressLine1
        Me.AddressLine2 = AddressLine2
        Me.AddressLine3 = AddressLine3
        Me.PlateCountryCode = PlateCountryCode
        Me.PlateNumber = PlateNumber
        Me.Brand = Brand
        Me.Model = Model
        Me.ChassisNumber = ChassisNumber
        Me.EngineNumber = EngineNumber
        Me.EnginePower = EnginePower
        Me.ProductionYear = ProductionYear
        Me.Capacity = Capacity
        Me.CarType = CarType
        Me.UsingStyle = UsingStyle
        Me.TariffCode = TariffCode
        Me.ArrangeDate = ArrangeDate
        Me.StartDate = StartDate
        Me.EndDate = EndDate
        Me.Material = Material
        Me.Corporal = Corporal
        Me.CurrencyCode = CurrencyCode
        Me.PublicValue = PublicValue
        Me.AuthorizedDrivers = AuthorizedDrivers
        Me.CountryCode1 = CountryCode1
        Me.IdentityCode1 = IdentityCode1
        Me.IdentityNo1 = IdentityNo1
        Me.Name1 = Name1
        Me.Surname1 = Surname1
        Me.BirthDate1 = BirthDate1
        Me.DriverLicenceNo1 = DriverLicenceNo1
        Me.DriverLicenceGivenDate1 = DriverLicenceGivenDate1
        Me.DriverLicenceType1 = DriverLicenceType1
        Me.CountryCode2 = CountryCode2
        Me.IdentityCode2 = IdentityCode2
        Me.IdentityNo2 = IdentityNo2
        Me.Name2 = Name2
        Me.Surname2 = Surname2
        Me.BirthDate2 = BirthDate2
        Me.DriverLicenceNo2 = DriverLicenceNo2
        Me.DriverLicenceGivenDate2 = DriverLicenceGivenDate2
        Me.DriverLicenceType2 = DriverLicenceType2
        Me.CountryCode3 = CountryCode3
        Me.IdentityCode3 = IdentityCode3
        Me.IdentityNo3 = IdentityNo3
        Me.Name3 = Name3
        Me.Surname3 = Surname3
        Me.BirthDate3 = BirthDate3
        Me.DriverLicenceNo3 = DriverLicenceNo3
        Me.DriverLicenceGivenDate3 = DriverLicenceGivenDate3
        Me.DriverLicenceType3 = DriverLicenceType3
        Me.CountryCode4 = CountryCode4
        Me.IdentityCode4 = IdentityCode4
        Me.IdentityNo4 = IdentityNo4
        Me.Name4 = Name4
        Me.Surname4 = Surname4
        Me.BirthDate4 = BirthDate4
        Me.DriverLicenceNo4 = DriverLicenceNo4
        Me.DriverLicenceGivenDate4 = DriverLicenceGivenDate4
        Me.DriverLicenceType4 = DriverLicenceType4
        Me.CountryCode5 = CountryCode5
        Me.IdentityCode5 = IdentityCode5
        Me.IdentityNo5 = IdentityNo5
        Me.Name5 = Name5
        Me.Surname5 = Surname5
        Me.BirthDate5 = BirthDate5
        Me.DriverLicenceNo5 = DriverLicenceNo5
        Me.DriverLicenceGivenDate5 = DriverLicenceGivenDate5
        Me.DriverLicenceType5 = DriverLicenceType5
        Me.CountryCode6 = CountryCode6
        Me.IdentityCode6 = IdentityCode6
        Me.IdentityNo6 = IdentityNo6
        Me.Name6 = Name6
        Me.Surname6 = Surname6
        Me.BirthDate6 = BirthDate6
        Me.DriverLicenceNo6 = DriverLicenceNo6
        Me.DriverLicenceGivenDate6 = DriverLicenceGivenDate6
        Me.DriverLicenceType6 = DriverLicenceType6
        Me.InsurancePremium = InsurancePremium
        Me.AssistantFees = AssistantFees
        Me.OtherFees = OtherFees
        Me.BasePriceValue = BasePriceValue
        Me.CCRateValue = CCRateValue
        Me.DamageRateValue = DamageRateValue
        Me.AgeRateValue = AgeRateValue
        Me.DamagelessRateValue = DamagelessRateValue
        Me.Color_v = Color
        Me.ProductType = ProductType
        Me.FuelType = FuelType
        Me.SteeringSide = SteeringSide
        Me.AnyDriverRateValue = AnyDriverRateValue
        Me.PolicyPremium = PolicyPremium
        Me.PolicyPremiumTL = PolicyPremiumTL
        Me.InsurancePremiumTL = InsurancePremiumTL
        Me.PublicValueTL = PublicValueTL
        Me.DamageRate = DamageRate
        Me.DamagelessRate = DamagelessRate
        Me.AnyDriverRate = AnyDriverRate
        Me.AgeRate = AgeRate
        Me.CCRate = CCRate
        Me.SBMCode = SBMCode

        Me.Creditor = Creditor
        Me.FirstBeneficiary = FirstBeneficiary
        Me.ExchangeRate = ExchangeRate

        Me.AgencyRegisterCode = AgencyRegisterCode
        Me.TPNo = TPNo

        Me.BorderCode = BorderCode

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


    Public Property AgencyCode() As String
        Get
            Return AgencyCode_v
        End Get
        Set(ByVal value As String)
            AgencyCode_v = value
        End Set
    End Property


    Public Property PolicyNumber() As String
        Get
            Return PolicyNumber_v
        End Get
        Set(ByVal value As String)
            PolicyNumber_v = value
        End Set
    End Property


    Public Property TecditNumber() As String
        Get
            Return TecditNumber_v
        End Get
        Set(ByVal value As String)
            TecditNumber_v = value
        End Set
    End Property


    Public Property ZeylCode() As String
        Get
            Return ZeylCode_v
        End Get
        Set(ByVal value As String)
            ZeylCode_v = value
        End Set
    End Property


    Public Property ZeylNo() As String
        Get
            Return ZeylNo_v
        End Get
        Set(ByVal value As String)
            ZeylNo_v = value
        End Set
    End Property


    Public Property PolicyType() As Integer
        Get
            Return PolicyType_v
        End Get
        Set(ByVal value As Integer)
            PolicyType_v = value
        End Set
    End Property


    Public Property PolicyOwnerCountryCode() As String
        Get
            Return PolicyOwnerCountryCode_v
        End Get
        Set(ByVal value As String)
            PolicyOwnerCountryCode_v = value
        End Set
    End Property


    Public Property PolicyOwnerIdentityCode() As String
        Get
            Return PolicyOwnerIdentityCode_v
        End Get
        Set(ByVal value As String)
            PolicyOwnerIdentityCode_v = value
        End Set
    End Property


    Public Property PolicyOwnerIdentityNo() As String
        Get
            Return PolicyOwnerIdentityNo_v
        End Get
        Set(ByVal value As String)
            PolicyOwnerIdentityNo_v = value
        End Set
    End Property


    Public Property PolicyOwnerName() As String
        Get
            Return PolicyOwnerName_v
        End Get
        Set(ByVal value As String)
            PolicyOwnerName_v = value
        End Set
    End Property


    Public Property PolicyOwnerSurname() As String
        Get
            Return PolicyOwnerSurname_v
        End Get
        Set(ByVal value As String)
            PolicyOwnerSurname_v = value
        End Set
    End Property


    Public Property PolicyOwnerBirthDate() As Nullable(Of Date)
        Get
            Return PolicyOwnerBirthDate_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            PolicyOwnerBirthDate_v = value
        End Set
    End Property


    Public Property AddressLine1() As String
        Get
            Return AddressLine1_v
        End Get
        Set(ByVal value As String)
            AddressLine1_v = value
        End Set
    End Property


    Public Property AddressLine2() As String
        Get
            Return AddressLine2_v
        End Get
        Set(ByVal value As String)
            AddressLine2_v = value
        End Set
    End Property


    Public Property AddressLine3() As String
        Get
            Return AddressLine3_v
        End Get
        Set(ByVal value As String)
            AddressLine3_v = value
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


    Public Property PlateNumber() As String
        Get
            Return PlateNumber_v
        End Get
        Set(ByVal value As String)
            PlateNumber_v = value
        End Set
    End Property


    Public Property Brand() As String
        Get
            Return Brand_v
        End Get
        Set(ByVal value As String)
            Brand_v = value
        End Set
    End Property


    Public Property Model() As String
        Get
            Return Model_v
        End Get
        Set(ByVal value As String)
            Model_v = value
        End Set
    End Property


    Public Property ChassisNumber() As String
        Get
            Return ChassisNumber_v
        End Get
        Set(ByVal value As String)
            ChassisNumber_v = value
        End Set
    End Property


    Public Property EngineNumber() As String
        Get
            Return EngineNumber_v
        End Get
        Set(ByVal value As String)
            EngineNumber_v = value
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


    Public Property ProductionYear() As Integer
        Get
            Return ProductionYear_v
        End Get
        Set(ByVal value As Integer)
            ProductionYear_v = value
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


    Public Property UsingStyle() As String
        Get
            Return UsingStyle_v
        End Get
        Set(ByVal value As String)
            UsingStyle_v = value
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


    Public Property ArrangeDate() As Nullable(Of Date)
        Get
            Return ArrangeDate_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            ArrangeDate_v = value
        End Set
    End Property


    Public Property StartDate() As Nullable(Of DateTime)
        Get
            Return StartDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            StartDate_v = value
        End Set
    End Property


    Public Property EndDate() As Nullable(Of Date)
        Get
            Return EndDate_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            EndDate_v = value
        End Set
    End Property


    Public Property Material() As Decimal
        Get
            Return Material_v
        End Get
        Set(ByVal value As Decimal)
            Material_v = value
        End Set
    End Property


    Public Property Corporal() As Decimal
        Get
            Return Corporal_v
        End Get
        Set(ByVal value As Decimal)
            Corporal_v = value
        End Set
    End Property


    Public Property CurrencyCode() As String
        Get
            Return CurrencyCode_v
        End Get
        Set(ByVal value As String)
            CurrencyCode_v = value
        End Set
    End Property


    Public Property PublicValue() As Decimal
        Get
            Return PublicValue_v
        End Get
        Set(ByVal value As Decimal)
            PublicValue_v = value
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


    Public Property CountryCode1() As String
        Get
            Return CountryCode1_v
        End Get
        Set(ByVal value As String)
            CountryCode1_v = value
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


    Public Property IdentityNo1() As String
        Get
            Return IdentityNo1_v
        End Get
        Set(ByVal value As String)
            IdentityNo1_v = value
        End Set
    End Property


    Public Property Name1() As String
        Get
            Return Name1_v
        End Get
        Set(ByVal value As String)
            Name1_v = value
        End Set
    End Property


    Public Property Surname1() As String
        Get
            Return Surname1_v
        End Get
        Set(ByVal value As String)
            Surname1_v = value
        End Set
    End Property


    Public Property BirthDate1() As Nullable(Of Date)
        Get
            Return BirthDate1_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            BirthDate1_v = value
        End Set
    End Property


    Public Property DriverLicenceNo1() As String
        Get
            Return DriverLicenceNo1_v
        End Get
        Set(ByVal value As String)
            DriverLicenceNo1_v = value
        End Set
    End Property


    Public Property DriverLicenceGivenDate1() As Nullable(Of Date)
        Get
            Return DriverLicenceGivenDate1_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            DriverLicenceGivenDate1_v = value
        End Set
    End Property


    Public Property DriverLicenceType1() As String
        Get
            Return DriverLicenceType1_v
        End Get
        Set(ByVal value As String)
            DriverLicenceType1_v = value
        End Set
    End Property


    Public Property CountryCode2() As String
        Get
            Return CountryCode2_v
        End Get
        Set(ByVal value As String)
            CountryCode2_v = value
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


    Public Property IdentityNo2() As String
        Get
            Return IdentityNo2_v
        End Get
        Set(ByVal value As String)
            IdentityNo2_v = value
        End Set
    End Property


    Public Property Name2() As String
        Get
            Return Name2_v
        End Get
        Set(ByVal value As String)
            Name2_v = value
        End Set
    End Property


    Public Property Surname2() As String
        Get
            Return Surname2_v
        End Get
        Set(ByVal value As String)
            Surname2_v = value
        End Set
    End Property


    Public Property BirthDate2() As Nullable(Of Date)
        Get
            Return BirthDate2_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            BirthDate2_v = value
        End Set
    End Property


    Public Property DriverLicenceNo2() As String
        Get
            Return DriverLicenceNo2_v
        End Get
        Set(ByVal value As String)
            DriverLicenceNo2_v = value
        End Set
    End Property


    Public Property DriverLicenceGivenDate2() As Nullable(Of Date)
        Get
            Return DriverLicenceGivenDate2_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            DriverLicenceGivenDate2_v = value
        End Set
    End Property


    Public Property DriverLicenceType2() As String
        Get
            Return DriverLicenceType2_v
        End Get
        Set(ByVal value As String)
            DriverLicenceType2_v = value
        End Set
    End Property


    Public Property CountryCode3() As String
        Get
            Return CountryCode3_v
        End Get
        Set(ByVal value As String)
            CountryCode3_v = value
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


    Public Property IdentityNo3() As String
        Get
            Return IdentityNo3_v
        End Get
        Set(ByVal value As String)
            IdentityNo3_v = value
        End Set
    End Property


    Public Property Name3() As String
        Get
            Return Name3_v
        End Get
        Set(ByVal value As String)
            Name3_v = value
        End Set
    End Property


    Public Property Surname3() As String
        Get
            Return Surname3_v
        End Get
        Set(ByVal value As String)
            Surname3_v = value
        End Set
    End Property


    Public Property BirthDate3() As Nullable(Of Date)
        Get
            Return BirthDate3_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            BirthDate3_v = value
        End Set
    End Property


    Public Property DriverLicenceNo3() As String
        Get
            Return DriverLicenceNo3_v
        End Get
        Set(ByVal value As String)
            DriverLicenceNo3_v = value
        End Set
    End Property


    Public Property DriverLicenceGivenDate3() As Nullable(Of Date)
        Get
            Return DriverLicenceGivenDate3_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            DriverLicenceGivenDate3_v = value
        End Set
    End Property


    Public Property DriverLicenceType3() As String
        Get
            Return DriverLicenceType3_v
        End Get
        Set(ByVal value As String)
            DriverLicenceType3_v = value
        End Set
    End Property


    Public Property CountryCode4() As String
        Get
            Return CountryCode4_v
        End Get
        Set(ByVal value As String)
            CountryCode4_v = value
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


    Public Property IdentityNo4() As String
        Get
            Return IdentityNo4_v
        End Get
        Set(ByVal value As String)
            IdentityNo4_v = value
        End Set
    End Property


    Public Property Name4() As String
        Get
            Return Name4_v
        End Get
        Set(ByVal value As String)
            Name4_v = value
        End Set
    End Property


    Public Property Surname4() As String
        Get
            Return Surname4_v
        End Get
        Set(ByVal value As String)
            Surname4_v = value
        End Set
    End Property


    Public Property BirthDate4() As Nullable(Of Date)
        Get
            Return BirthDate4_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            BirthDate4_v = value
        End Set
    End Property


    Public Property DriverLicenceNo4() As String
        Get
            Return DriverLicenceNo4_v
        End Get
        Set(ByVal value As String)
            DriverLicenceNo4_v = value
        End Set
    End Property


    Public Property DriverLicenceGivenDate4() As Nullable(Of Date)
        Get
            Return DriverLicenceGivenDate4_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            DriverLicenceGivenDate4_v = value
        End Set
    End Property


    Public Property DriverLicenceType4() As String
        Get
            Return DriverLicenceType4_v
        End Get
        Set(ByVal value As String)
            DriverLicenceType4_v = value
        End Set
    End Property


    Public Property CountryCode5() As String
        Get
            Return CountryCode5_v
        End Get
        Set(ByVal value As String)
            CountryCode5_v = value
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


    Public Property IdentityNo5() As String
        Get
            Return IdentityNo5_v
        End Get
        Set(ByVal value As String)
            IdentityNo5_v = value
        End Set
    End Property


    Public Property Name5() As String
        Get
            Return Name5_v
        End Get
        Set(ByVal value As String)
            Name5_v = value
        End Set
    End Property


    Public Property Surname5() As String
        Get
            Return Surname5_v
        End Get
        Set(ByVal value As String)
            Surname5_v = value
        End Set
    End Property


    Public Property BirthDate5() As Nullable(Of Date)
        Get
            Return BirthDate5_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            BirthDate5_v = value
        End Set
    End Property


    Public Property DriverLicenceNo5() As String
        Get
            Return DriverLicenceNo5_v
        End Get
        Set(ByVal value As String)
            DriverLicenceNo5_v = value
        End Set
    End Property


    Public Property DriverLicenceGivenDate5() As Nullable(Of Date)
        Get
            Return DriverLicenceGivenDate5_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            DriverLicenceGivenDate5_v = value
        End Set
    End Property


    Public Property DriverLicenceType5() As String
        Get
            Return DriverLicenceType5_v
        End Get
        Set(ByVal value As String)
            DriverLicenceType5_v = value
        End Set
    End Property


    Public Property CountryCode6() As String
        Get
            Return CountryCode6_v
        End Get
        Set(ByVal value As String)
            CountryCode6_v = value
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


    Public Property IdentityNo6() As String
        Get
            Return IdentityNo6_v
        End Get
        Set(ByVal value As String)
            IdentityNo6_v = value
        End Set
    End Property


    Public Property Name6() As String
        Get
            Return Name6_v
        End Get
        Set(ByVal value As String)
            Name6_v = value
        End Set
    End Property


    Public Property Surname6() As String
        Get
            Return Surname6_v
        End Get
        Set(ByVal value As String)
            Surname6_v = value
        End Set
    End Property


    Public Property BirthDate6() As Nullable(Of Date)
        Get
            Return BirthDate6_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            BirthDate6_v = value
        End Set
    End Property


    Public Property DriverLicenceNo6() As String
        Get
            Return DriverLicenceNo6_v
        End Get
        Set(ByVal value As String)
            DriverLicenceNo6_v = value
        End Set
    End Property


    Public Property DriverLicenceGivenDate6() As Nullable(Of Date)
        Get
            Return DriverLicenceGivenDate6_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            DriverLicenceGivenDate6_v = value
        End Set
    End Property


    Public Property DriverLicenceType6() As String
        Get
            Return DriverLicenceType6_v
        End Get
        Set(ByVal value As String)
            DriverLicenceType6_v = value
        End Set
    End Property


    Public Property InsurancePremium() As Decimal
        Get
            Return InsurancePremium_v
        End Get
        Set(ByVal value As Decimal)
            InsurancePremium_v = value
        End Set
    End Property


    Public Property AssistantFees() As Decimal
        Get
            Return AssistantFees_v
        End Get
        Set(ByVal value As Decimal)
            AssistantFees_v = value
        End Set
    End Property


    Public Property OtherFees() As Decimal
        Get
            Return OtherFees_v
        End Get
        Set(ByVal value As Decimal)
            OtherFees_v = value
        End Set
    End Property



    Public Property BasePriceValue() As Decimal
        Get
            Return BasePriceValue_v
        End Get
        Set(ByVal value As Decimal)
            BasePriceValue_v = value
        End Set
    End Property


    Public Property CCRateValue() As Decimal
        Get
            Return CCRateValue_v
        End Get
        Set(ByVal value As Decimal)
            CCRateValue_v = value
        End Set
    End Property


    Public Property DamageRateValue() As Decimal
        Get
            Return DamageRateValue_v
        End Get
        Set(ByVal value As Decimal)
            DamageRateValue_v = value
        End Set
    End Property


    Public Property AgeRateValue() As Decimal
        Get
            Return AgeRateValue_v
        End Get
        Set(ByVal value As Decimal)
            AgeRateValue_v = value
        End Set
    End Property


    Public Property DamagelessRateValue() As Decimal
        Get
            Return DamagelessRateValue_v
        End Get
        Set(ByVal value As Decimal)
            DamagelessRateValue_v = value
        End Set
    End Property


    Public Property Color() As String
        Get
            Return Color_v
        End Get
        Set(ByVal value As String)
            Color_v = value
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


    Public Property AnyDriverRateValue() As Decimal
        Get
            Return AnyDriverRateValue_v
        End Get
        Set(ByVal value As Decimal)
            AnyDriverRateValue_v = value
        End Set
    End Property


    Public Property PolicyPremium() As Decimal
        Get
            Return PolicyPremium_v
        End Get
        Set(ByVal value As Decimal)
            PolicyPremium_v = value
        End Set
    End Property


    Public Property PolicyPremiumTL() As Decimal
        Get
            Return PolicyPremiumTL_v
        End Get
        Set(ByVal value As Decimal)
            PolicyPremiumTL_v = value
        End Set
    End Property


    Public Property InsurancePremiumTL() As Decimal
        Get
            Return InsurancePremiumTL_v
        End Get
        Set(ByVal value As Decimal)
            InsurancePremiumTL_v = value
        End Set
    End Property


    Public Property PublicValueTL() As Decimal
        Get
            Return PublicValueTL_v
        End Get
        Set(ByVal value As Decimal)
            PublicValueTL_v = value
        End Set
    End Property


    Public Property DamageRate() As Integer
        Get
            Return DamageRate_v
        End Get
        Set(ByVal value As Integer)
            DamageRate_v = value
        End Set
    End Property


    Public Property DamagelessRate() As Integer
        Get
            Return DamagelessRate_v
        End Get
        Set(ByVal value As Integer)
            DamagelessRate_v = value
        End Set
    End Property


    Public Property AnyDriverRate() As Integer
        Get
            Return AnyDriverRate_v
        End Get
        Set(ByVal value As Integer)
            AnyDriverRate_v = value
        End Set
    End Property


    Public Property AgeRate() As Integer
        Get
            Return AgeRate_v
        End Get
        Set(ByVal value As Integer)
            AgeRate_v = value
        End Set
    End Property


    Public Property CCRate() As Integer
        Get
            Return CCRate_v
        End Get
        Set(ByVal value As Integer)
            CCRate_v = value
        End Set
    End Property

    Public Property SBMCode() As String
        Get
            Return SBMCode_v
        End Get
        Set(ByVal value As String)
            SBMCode_v = value
        End Set
    End Property


    Public Property Creditor() As Integer
        Get
            Return Creditor_v
        End Get
        Set(ByVal value As Integer)
            Creditor_v = value
        End Set
    End Property


    Public Property FirstBeneficiary() As String
        Get
            Return FirstBeneficiary_v
        End Get
        Set(ByVal value As String)
            FirstBeneficiary_v = value
        End Set
    End Property


    Public Property ExchangeRate() As Decimal
        Get
            Return ExchangeRate_v
        End Get
        Set(ByVal value As Decimal)
            ExchangeRate_v = value
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


    Public Property BorderCode() As String
        Get
            Return BorderCode_v
        End Get
        Set(ByVal value As String)
            BorderCode_v = value
        End Set
    End Property



End Class
