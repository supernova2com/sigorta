Public Class FirePolicyInfo

    Private pkey_v As Integer
    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private TecditNumber_v As String
    Private ZeylCode_v As String
    Private ZeyilNo_v As String
    Private PolicyType_v As Integer
    Private ArrangeDate_v As Nullable(Of DateTime)
    Private StartDate_v As Nullable(Of DateTime)
    Private EndDate_v As Nullable(Of DateTime)
    Private PolicyOwnerCountryCode_v As String
    Private PolicyOwnerIdentityCode_v As String
    Private PolicyOwnerIdentityNo_v As String
    Private PolicyOwnerName_v As String
    Private PolicyOwnerSurname_v As String
    Private InsuredTitle_v As Integer
    Private RiskAddress_ilcekod_v As Integer
    Private RiskAddress_bucakkod_v As Integer
    Private RiskAddress_belediyekod_v As Integer
    Private RiskAddress_mahallekod_v As Integer
    Private RiskAddress_sokakkod_v As Integer
    Private FirstBeneficiary_v As String
    Private Creditor_v As Boolean
    Private RiskType_v As Boolean
    Private StructureStyle_v As Integer
    Private OfficeBlock_v As Integer
    Private Activity_v As String
    Private AgencyRegisterCode_v As String
    Private TPNo_v As String
    Private Building_v As Boolean
    Private Contents_v As Boolean
    Private EartQuake_v As Boolean
    Private FloodFlooding_v As Boolean
    Private InternalWater_v As Boolean
    Private Storm_v As Boolean
    Private Theft_v As Boolean
    Private LandVehicles_v As Boolean
    Private AirCraft_v As Boolean
    Private MaritimeVehicles_v As Boolean
    Private Smoke_v As Boolean
    Private SpaceShift_v As Boolean
    Private GLKHH_v As Boolean
    Private MaliciousTerror_v As Boolean
    Private OtherGuarentees_v As Boolean
    Private Latitude_v As Decimal
    Private Longitude_v As Decimal
    Private BuildingValue_v As Decimal
    Private ContentsValue_v As Decimal
    Private CurrencyCode_v As String
    Private ExchangeRate_v As Decimal
    Private FirePremium_v As Decimal
    Private SupplementaryGuaranteePremium_v As Decimal
    Private EarthquakePremium_v As Decimal
    Private OtherFees_v As Decimal
    Private TotalPremium_v As Decimal
    Private FirePremiumTL_v As Decimal
    Private SupplementaryGuaranteePremiumTL_v As Decimal
    Private EarthquakePremiumTL_v As Decimal
    Private OtherFeesTL_v As Decimal
    Private TotalPremiumTL_v As Decimal
    Private PolicyPremiumTL_v As Decimal
    Private Color_v As String
    Private FSBMCode_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal FirmCode As String, ByVal ProductCode As String,
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String,
    ByVal ZeylCode As String, ByVal ZeyilNo As String, ByVal PolicyType As Integer,
    ByVal ArrangeDate As DateTime, ByVal StartDate As DateTime, ByVal EndDate As DateTime,
    ByVal PolicyOwnerCountryCode As String, ByVal PolicyOwnerIdentityCode As String, ByVal PolicyOwnerIdentityNo As String,
    ByVal PolicyOwnerName As String, ByVal PolicyOwnerSurname As String, ByVal InsuredTitle As Integer,
    ByVal RiskAddress_ilcekod As Integer, ByVal RiskAddress_bucakkod As Integer, ByVal RiskAddress_belediyekod As Integer,
    ByVal RiskAddress_mahallekod As Integer, ByVal RiskAddress_sokakkod As Integer, ByVal FirstBeneficiary As String,
    ByVal Creditor As Boolean, ByVal RiskType As Boolean, ByVal StructureStyle As Integer,
    ByVal OfficeBlock As Integer, ByVal Activity As String, ByVal AgencyRegisterCode As String,
    ByVal TPNo As String, ByVal Building As Boolean, ByVal Contents As Boolean,
    ByVal EartQuake As Boolean, ByVal FloodFlooding As Boolean, ByVal InternalWater As Boolean,
    ByVal Storm As Boolean, ByVal Theft As Boolean, ByVal LandVehicles As Boolean,
    ByVal AirCraft As Boolean, ByVal MaritimeVehicles As Boolean, ByVal Smoke As Boolean,
    ByVal SpaceShift As Boolean, ByVal GLKHH As Boolean, ByVal MaliciousTerror As Boolean,
    ByVal OtherGuarentees As Boolean, ByVal Latitude As Decimal, ByVal Longitude As Decimal,
    ByVal BuildingValue As Decimal, ByVal ContentsValue As Decimal, ByVal CurrencyCode As String,
    ByVal ExchangeRate As Decimal, ByVal FirePremium As Decimal, ByVal SupplementaryGuaranteePremium As Decimal,
    ByVal EarthquakePremium As Decimal, ByVal OtherFees As Decimal, ByVal TotalPremium As Decimal,
    ByVal FirePremiumTL As Decimal, ByVal SupplementaryGuaranteePremiumTL As Decimal, ByVal EarthquakePremiumTL As Decimal,
    ByVal OtherFeesTL As Decimal, ByVal TotalPremiumTL As Decimal, ByVal PolicyPremiumTL As Decimal,
    ByVal Color As String, ByVal FSBMCode As String)

        Me.pkey = pkey
        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.TecditNumber = TecditNumber
        Me.ZeylCode = ZeylCode
        Me.ZeyilNo = ZeyilNo
        Me.PolicyType = PolicyType
        Me.ArrangeDate = ArrangeDate
        Me.StartDate = StartDate
        Me.EndDate = EndDate
        Me.PolicyOwnerCountryCode = PolicyOwnerCountryCode
        Me.PolicyOwnerIdentityCode = PolicyOwnerIdentityCode
        Me.PolicyOwnerIdentityNo = PolicyOwnerIdentityNo
        Me.PolicyOwnerName = PolicyOwnerName
        Me.PolicyOwnerSurname = PolicyOwnerSurname
        Me.InsuredTitle = InsuredTitle
        Me.RiskAddress_ilcekod = RiskAddress_ilcekod
        Me.RiskAddress_bucakkod = RiskAddress_bucakkod
        Me.RiskAddress_belediyekod = RiskAddress_belediyekod
        Me.RiskAddress_mahallekod = RiskAddress_mahallekod
        Me.RiskAddress_sokakkod = RiskAddress_sokakkod
        Me.FirstBeneficiary = FirstBeneficiary
        Me.Creditor = Creditor
        Me.RiskType = RiskType
        Me.StructureStyle = StructureStyle
        Me.OfficeBlock = OfficeBlock
        Me.Activity = Activity
        Me.AgencyRegisterCode = AgencyRegisterCode
        Me.TPNo = TPNo
        Me.Building = Building
        Me.Contents = Contents
        Me.EartQuake = EartQuake
        Me.FloodFlooding = FloodFlooding
        Me.InternalWater = InternalWater
        Me.Storm = Storm
        Me.Theft = Theft
        Me.LandVehicles = LandVehicles
        Me.AirCraft = AirCraft
        Me.MaritimeVehicles = MaritimeVehicles
        Me.Smoke = Smoke
        Me.SpaceShift = SpaceShift
        Me.GLKHH = GLKHH
        Me.MaliciousTerror = MaliciousTerror
        Me.OtherGuarentees = OtherGuarentees
        Me.Latitude = Latitude
        Me.Longitude = Longitude
        Me.BuildingValue = BuildingValue
        Me.ContentsValue = ContentsValue
        Me.CurrencyCode = CurrencyCode
        Me.ExchangeRate = ExchangeRate
        Me.FirePremium = FirePremium
        Me.SupplementaryGuaranteePremium = SupplementaryGuaranteePremium
        Me.EarthquakePremium = EarthquakePremium
        Me.OtherFees = OtherFees
        Me.TotalPremium = TotalPremium
        Me.FirePremiumTL = FirePremiumTL
        Me.SupplementaryGuaranteePremiumTL = SupplementaryGuaranteePremiumTL
        Me.EarthquakePremiumTL = EarthquakePremiumTL
        Me.OtherFeesTL = OtherFeesTL
        Me.TotalPremiumTL = TotalPremiumTL
        Me.PolicyPremiumTL = PolicyPremiumTL
        Me.Color = Color
        Me.FSBMCode = FSBMCode

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


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


    Public Property ZeyilNo() As String
        Get
            Return ZeyilNo_v
        End Get
        Set(ByVal value As String)
            ZeyilNo_v = value
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


    Public Property ArrangeDate() As Nullable(Of DateTime)
        Get
            Return ArrangeDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
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


    Public Property EndDate() As Nullable(Of DateTime)
        Get
            Return EndDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            EndDate_v = value
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


    Public Property InsuredTitle() As Integer
        Get
            Return InsuredTitle_v
        End Get
        Set(ByVal value As Integer)
            InsuredTitle_v = value
        End Set
    End Property


    Public Property RiskAddress_ilcekod() As Integer
        Get
            Return RiskAddress_ilcekod_v
        End Get
        Set(ByVal value As Integer)
            RiskAddress_ilcekod_v = value
        End Set
    End Property


    Public Property RiskAddress_bucakkod() As Integer
        Get
            Return RiskAddress_bucakkod_v
        End Get
        Set(ByVal value As Integer)
            RiskAddress_bucakkod_v = value
        End Set
    End Property


    Public Property RiskAddress_belediyekod() As Integer
        Get
            Return RiskAddress_belediyekod_v
        End Get
        Set(ByVal value As Integer)
            RiskAddress_belediyekod_v = value
        End Set
    End Property


    Public Property RiskAddress_mahallekod() As Integer
        Get
            Return RiskAddress_mahallekod_v
        End Get
        Set(ByVal value As Integer)
            RiskAddress_mahallekod_v = value
        End Set
    End Property


    Public Property RiskAddress_sokakkod() As Integer
        Get
            Return RiskAddress_sokakkod_v
        End Get
        Set(ByVal value As Integer)
            RiskAddress_sokakkod_v = value
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


    Public Property Creditor() As Boolean
        Get
            Return Creditor_v
        End Get
        Set(ByVal value As Boolean)
            Creditor_v = value
        End Set
    End Property


    Public Property RiskType() As Boolean
        Get
            Return RiskType_v
        End Get
        Set(ByVal value As Boolean)
            RiskType_v = value
        End Set
    End Property


    Public Property StructureStyle() As Integer
        Get
            Return StructureStyle_v
        End Get
        Set(ByVal value As Integer)
            StructureStyle_v = value
        End Set
    End Property


    Public Property OfficeBlock() As Integer
        Get
            Return OfficeBlock_v
        End Get
        Set(ByVal value As Integer)
            OfficeBlock_v = value
        End Set
    End Property


    Public Property Activity() As String
        Get
            Return Activity_v
        End Get
        Set(ByVal value As String)
            Activity_v = value
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


    Public Property Building() As Boolean
        Get
            Return Building_v
        End Get
        Set(ByVal value As Boolean)
            Building_v = value
        End Set
    End Property


    Public Property Contents() As Boolean
        Get
            Return Contents_v
        End Get
        Set(ByVal value As Boolean)
            Contents_v = value
        End Set
    End Property


    Public Property EartQuake() As Boolean
        Get
            Return EartQuake_v
        End Get
        Set(ByVal value As Boolean)
            EartQuake_v = value
        End Set
    End Property


    Public Property FloodFlooding() As Boolean
        Get
            Return FloodFlooding_v
        End Get
        Set(ByVal value As Boolean)
            FloodFlooding_v = value
        End Set
    End Property


    Public Property InternalWater() As Boolean
        Get
            Return InternalWater_v
        End Get
        Set(ByVal value As Boolean)
            InternalWater_v = value
        End Set
    End Property


    Public Property Storm() As Boolean
        Get
            Return Storm_v
        End Get
        Set(ByVal value As Boolean)
            Storm_v = value
        End Set
    End Property


    Public Property Theft() As Boolean
        Get
            Return Theft_v
        End Get
        Set(ByVal value As Boolean)
            Theft_v = value
        End Set
    End Property


    Public Property LandVehicles() As Boolean
        Get
            Return LandVehicles_v
        End Get
        Set(ByVal value As Boolean)
            LandVehicles_v = value
        End Set
    End Property


    Public Property AirCraft() As Boolean
        Get
            Return AirCraft_v
        End Get
        Set(ByVal value As Boolean)
            AirCraft_v = value
        End Set
    End Property


    Public Property MaritimeVehicles() As Boolean
        Get
            Return MaritimeVehicles_v
        End Get
        Set(ByVal value As Boolean)
            MaritimeVehicles_v = value
        End Set
    End Property


    Public Property Smoke() As Boolean
        Get
            Return Smoke_v
        End Get
        Set(ByVal value As Boolean)
            Smoke_v = value
        End Set
    End Property


    Public Property SpaceShift() As Boolean
        Get
            Return SpaceShift_v
        End Get
        Set(ByVal value As Boolean)
            SpaceShift_v = value
        End Set
    End Property


    Public Property GLKHH() As Boolean
        Get
            Return GLKHH_v
        End Get
        Set(ByVal value As Boolean)
            GLKHH_v = value
        End Set
    End Property


    Public Property MaliciousTerror() As Boolean
        Get
            Return MaliciousTerror_v
        End Get
        Set(ByVal value As Boolean)
            MaliciousTerror_v = value
        End Set
    End Property


    Public Property OtherGuarentees() As Boolean
        Get
            Return OtherGuarentees_v
        End Get
        Set(ByVal value As Boolean)
            OtherGuarentees_v = value
        End Set
    End Property


    Public Property Latitude() As Decimal
        Get
            Return Latitude_v
        End Get
        Set(ByVal value As Decimal)
            Latitude_v = value
        End Set
    End Property


    Public Property Longitude() As Decimal
        Get
            Return Longitude_v
        End Get
        Set(ByVal value As Decimal)
            Longitude_v = value
        End Set
    End Property


    Public Property BuildingValue() As Decimal
        Get
            Return BuildingValue_v
        End Get
        Set(ByVal value As Decimal)
            BuildingValue_v = value
        End Set
    End Property


    Public Property ContentsValue() As Decimal
        Get
            Return ContentsValue_v
        End Get
        Set(ByVal value As Decimal)
            ContentsValue_v = value
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


    Public Property ExchangeRate() As Decimal
        Get
            Return ExchangeRate_v
        End Get
        Set(ByVal value As Decimal)
            ExchangeRate_v = value
        End Set
    End Property


    Public Property FirePremium() As Decimal
        Get
            Return FirePremium_v
        End Get
        Set(ByVal value As Decimal)
            FirePremium_v = value
        End Set
    End Property


    Public Property SupplementaryGuaranteePremium() As Decimal
        Get
            Return SupplementaryGuaranteePremium_v
        End Get
        Set(ByVal value As Decimal)
            SupplementaryGuaranteePremium_v = value
        End Set
    End Property


    Public Property EarthquakePremium() As Decimal
        Get
            Return EarthquakePremium_v
        End Get
        Set(ByVal value As Decimal)
            EarthquakePremium_v = value
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


    Public Property TotalPremium() As Decimal
        Get
            Return TotalPremium_v
        End Get
        Set(ByVal value As Decimal)
            TotalPremium_v = value
        End Set
    End Property


    Public Property FirePremiumTL() As Decimal
        Get
            Return FirePremiumTL_v
        End Get
        Set(ByVal value As Decimal)
            FirePremiumTL_v = value
        End Set
    End Property


    Public Property SupplementaryGuaranteePremiumTL() As Decimal
        Get
            Return SupplementaryGuaranteePremiumTL_v
        End Get
        Set(ByVal value As Decimal)
            SupplementaryGuaranteePremiumTL_v = value
        End Set
    End Property


    Public Property EarthquakePremiumTL() As Decimal
        Get
            Return EarthquakePremiumTL_v
        End Get
        Set(ByVal value As Decimal)
            EarthquakePremiumTL_v = value
        End Set
    End Property


    Public Property OtherFeesTL() As Decimal
        Get
            Return OtherFeesTL_v
        End Get
        Set(ByVal value As Decimal)
            OtherFeesTL_v = value
        End Set
    End Property


    Public Property TotalPremiumTL() As Decimal
        Get
            Return TotalPremiumTL_v
        End Get
        Set(ByVal value As Decimal)
            TotalPremiumTL_v = value
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


    Public Property Color() As String
        Get
            Return Color_v
        End Get
        Set(ByVal value As String)
            Color_v = value
        End Set
    End Property


    Public Property FSBMCode() As String
        Get
            Return FSBMCode_v
        End Get
        Set(ByVal value As String)
            FSBMCode_v = value
        End Set
    End Property



End Class
