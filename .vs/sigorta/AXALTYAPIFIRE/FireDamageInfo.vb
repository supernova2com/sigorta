Public Class FireDamageInfo

    Private pkey_v As Integer
    Private firepolicyinfopkey_v As Integer
    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private TecditNumber_v As String
    Private FileNumber_v As String
    Private RequestNumber_v As String
    Private PolicyType_v As Integer
    Private DamageDate_v As DateTime
    Private NoticeDate_v As DateTime
    Private FileClosingDate_v As DateTime
    Private DamageStatusCode_v As String
    Private ClaimOwnerCountryCode_v As String
    Private ClaimOwnerIdentityCode_v As String
    Private ClaimOwnerIdentityNo_v As String
    Private ClaimOwnerName_v As String
    Private ClaimOwnerSurname_v As String
    Private CurrencyCode_v As String
    Private ExchangeRate_v As Decimal
    Private AgencyRegisterCode_v As String
    Private TPNo_v As String
    Private BuildingPaid_v As Decimal
    Private ContentsPaid_v As Decimal
    Private EarthquakePaid_v As Decimal
    Private FloodFloodingPaid_v As Decimal
    Private InternalWaterPaid_v As Decimal
    Private StormPaid_v As Decimal
    Private TheftPaid_v As Decimal
    Private LandVehiclesPaid_v As Decimal
    Private AirCraftPaid_v As Decimal
    Private MaritimeVehiclesPaid_v As Decimal
    Private SmokePaid_v As Decimal
    Private SpaceShiftPaid_v As Decimal
    Private GLKHHPaid_v As Decimal
    Private MaliciousTerrorPaid_v As Decimal
    Private OtherGuaranteesPaid_v As Decimal
    Private BuildingPending_v As Decimal
    Private ContentsPending_v As Decimal
    Private EarthquakePending_v As Decimal
    Private FloodFloodingPending_v As Decimal
    Private InternalWaterPending_v As Decimal
    Private StormPending_v As Decimal
    Private TheftPending_v As Decimal
    Private LandVehiclesPending_v As Decimal
    Private AirCraftPending_v As Decimal
    Private MaritmeVehiclesPending_v As Decimal
    Private SmokePending_v As Decimal
    Private SpaceShiftPending_v As Decimal
    Private GLKHHPending_v As Decimal
    Private MaliciousTerrorPending_v As Decimal
    Private OtherGuaranteesPending_v As Decimal
    Private PendingTotalAmount_v As Decimal
    Private PendingTotalAmountTL_v As Decimal
    Private PaidTotalAmount_v As Decimal
    Private PaidTotalAmountTL_v As Decimal
    Private RustyAmount_v As Decimal
    Private FDSBMCode_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal firepolicyinfopkey As Integer, ByVal FirmCode As String,
    ByVal ProductCode As String, ByVal AgencyCode As String, ByVal PolicyNumber As String,
    ByVal TecditNumber As String, ByVal FileNumber As String, ByVal RequestNumber As String,
    ByVal PolicyType As Integer, ByVal DamageDate As DateTime, ByVal NoticeDate As DateTime,
    ByVal FileClosingDate As DateTime, ByVal DamageStatusCode As String, ByVal ClaimOwnerCountryCode As String,
    ByVal ClaimOwnerIdentityCode As String, ByVal ClaimOwnerIdentityNo As String, ByVal ClaimOwnerName As String,
    ByVal ClaimOwnerSurname As String, ByVal CurrencyCode As String, ByVal ExchangeRate As Decimal,
    ByVal AgencyRegisterCode As String, ByVal TPNo As String, ByVal BuildingPaid As Decimal,
    ByVal ContentsPaid As Decimal, ByVal EarthquakePaid As Decimal, ByVal FloodFloodingPaid As Decimal,
    ByVal InternalWaterPaid As Decimal, ByVal StormPaid As Decimal, ByVal TheftPaid As Decimal,
    ByVal LandVehiclesPaid As Decimal, ByVal AirCraftPaid As Decimal, ByVal MaritimeVehiclesPaid As Decimal,
    ByVal SmokePaid As Decimal, ByVal SpaceShiftPaid As Decimal, ByVal GLKHHPaid As Decimal,
    ByVal MaliciousTerrorPaid As Decimal, ByVal OtherGuaranteesPaid As Decimal, ByVal BuildingPending As Decimal,
    ByVal ContentsPending As Decimal, ByVal EarthquakePending As Decimal, ByVal FloodFloodingPending As Decimal,
    ByVal InternalWaterPending As Decimal, ByVal StormPending As Decimal, ByVal TheftPending As Decimal,
    ByVal LandVehiclesPending As Decimal, ByVal AirCraftPending As Decimal, ByVal MaritmeVehiclesPending As Decimal,
    ByVal SmokePending As Decimal, ByVal SpaceShiftPending As Decimal, ByVal GLKHHPending As Decimal,
    ByVal MaliciousTerrorPending As Decimal, ByVal OtherGuaranteesPending As Decimal, ByVal PendingTotalAmount As Decimal,
    ByVal PendingTotalAmountTL As Decimal, ByVal PaidTotalAmount As Decimal, ByVal PaidTotalAmountTL As Decimal,
    ByVal RustyAmount As Decimal, ByVal FDSBMCode As String)


        Me.pkey = pkey
        Me.firepolicyinfopkey = firepolicyinfopkey
        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.TecditNumber = TecditNumber
        Me.FileNumber = FileNumber
        Me.RequestNumber = RequestNumber
        Me.PolicyType = PolicyType
        Me.DamageDate = DamageDate
        Me.NoticeDate = NoticeDate
        Me.FileClosingDate = FileClosingDate
        Me.DamageStatusCode = DamageStatusCode
        Me.ClaimOwnerCountryCode = ClaimOwnerCountryCode
        Me.ClaimOwnerIdentityCode = ClaimOwnerIdentityCode
        Me.ClaimOwnerIdentityNo = ClaimOwnerIdentityNo
        Me.ClaimOwnerName = ClaimOwnerName
        Me.ClaimOwnerSurname = ClaimOwnerSurname
        Me.CurrencyCode = CurrencyCode
        Me.ExchangeRate = ExchangeRate
        Me.AgencyRegisterCode = AgencyRegisterCode
        Me.TPNo = TPNo
        Me.BuildingPaid = BuildingPaid
        Me.ContentsPaid = ContentsPaid
        Me.EarthquakePaid = EarthquakePaid
        Me.FloodFloodingPaid = FloodFloodingPaid
        Me.InternalWaterPaid = InternalWaterPaid
        Me.StormPaid = StormPaid
        Me.TheftPaid = TheftPaid
        Me.LandVehiclesPaid = LandVehiclesPaid
        Me.AirCraftPaid = AirCraftPaid
        Me.MaritimeVehiclesPaid = MaritimeVehiclesPaid
        Me.SmokePaid = SmokePaid
        Me.SpaceShiftPaid = SpaceShiftPaid
        Me.GLKHHPaid = GLKHHPaid
        Me.MaliciousTerrorPaid = MaliciousTerrorPaid
        Me.OtherGuaranteesPaid = OtherGuaranteesPaid
        Me.BuildingPending = BuildingPending
        Me.ContentsPending = ContentsPending
        Me.EarthquakePending = EarthquakePending
        Me.FloodFloodingPending = FloodFloodingPending
        Me.InternalWaterPending = InternalWaterPending
        Me.StormPending = StormPending
        Me.TheftPending = TheftPending
        Me.LandVehiclesPending = LandVehiclesPending
        Me.AirCraftPending = AirCraftPending
        Me.MaritmeVehiclesPending = MaritmeVehiclesPending
        Me.SmokePending = SmokePending
        Me.SpaceShiftPending = SpaceShiftPending
        Me.GLKHHPending = GLKHHPending
        Me.MaliciousTerrorPending = MaliciousTerrorPending
        Me.OtherGuaranteesPending = OtherGuaranteesPending
        Me.PendingTotalAmount = PendingTotalAmount
        Me.PendingTotalAmountTL = PendingTotalAmountTL
        Me.PaidTotalAmount = PaidTotalAmount
        Me.PaidTotalAmountTL = PaidTotalAmountTL
        Me.RustyAmount = RustyAmount
        Me.FDSBMCode = FDSBMCode

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property firepolicyinfopkey() As Integer
        Get
            Return firepolicyinfopkey_v
        End Get
        Set(ByVal value As Integer)
            firepolicyinfopkey_v = value
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


    Public Property FileNumber() As String
        Get
            Return FileNumber_v
        End Get
        Set(ByVal value As String)
            FileNumber_v = value
        End Set
    End Property


    Public Property RequestNumber() As String
        Get
            Return RequestNumber_v
        End Get
        Set(ByVal value As String)
            RequestNumber_v = value
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


    Public Property DamageDate() As Nullable(Of DateTime)
        Get
            Return DamageDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            DamageDate_v = value
        End Set
    End Property


    Public Property NoticeDate() As Nullable(Of DateTime)
        Get
            Return NoticeDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            NoticeDate_v = value
        End Set
    End Property


    Public Property FileClosingDate() As Nullable(Of DateTime)
        Get
            Return FileClosingDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            FileClosingDate_v = value
        End Set
    End Property


    Public Property DamageStatusCode() As String
        Get
            Return DamageStatusCode_v
        End Get
        Set(ByVal value As String)
            DamageStatusCode_v = value
        End Set
    End Property


    Public Property ClaimOwnerCountryCode() As String
        Get
            Return ClaimOwnerCountryCode_v
        End Get
        Set(ByVal value As String)
            ClaimOwnerCountryCode_v = value
        End Set
    End Property


    Public Property ClaimOwnerIdentityCode() As String
        Get
            Return ClaimOwnerIdentityCode_v
        End Get
        Set(ByVal value As String)
            ClaimOwnerIdentityCode_v = value
        End Set
    End Property


    Public Property ClaimOwnerIdentityNo() As String
        Get
            Return ClaimOwnerIdentityNo_v
        End Get
        Set(ByVal value As String)
            ClaimOwnerIdentityNo_v = value
        End Set
    End Property


    Public Property ClaimOwnerName() As String
        Get
            Return ClaimOwnerName_v
        End Get
        Set(ByVal value As String)
            ClaimOwnerName_v = value
        End Set
    End Property


    Public Property ClaimOwnerSurname() As String
        Get
            Return ClaimOwnerSurname_v
        End Get
        Set(ByVal value As String)
            ClaimOwnerSurname_v = value
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


    Public Property BuildingPaid() As Decimal
        Get
            Return BuildingPaid_v
        End Get
        Set(ByVal value As Decimal)
            BuildingPaid_v = value
        End Set
    End Property


    Public Property ContentsPaid() As Decimal
        Get
            Return ContentsPaid_v
        End Get
        Set(ByVal value As Decimal)
            ContentsPaid_v = value
        End Set
    End Property


    Public Property EarthquakePaid() As Decimal
        Get
            Return EarthquakePaid_v
        End Get
        Set(ByVal value As Decimal)
            EarthquakePaid_v = value
        End Set
    End Property


    Public Property FloodFloodingPaid() As Decimal
        Get
            Return FloodFloodingPaid_v
        End Get
        Set(ByVal value As Decimal)
            FloodFloodingPaid_v = value
        End Set
    End Property


    Public Property InternalWaterPaid() As Decimal
        Get
            Return InternalWaterPaid_v
        End Get
        Set(ByVal value As Decimal)
            InternalWaterPaid_v = value
        End Set
    End Property


    Public Property StormPaid() As Decimal
        Get
            Return StormPaid_v
        End Get
        Set(ByVal value As Decimal)
            StormPaid_v = value
        End Set
    End Property


    Public Property TheftPaid() As Decimal
        Get
            Return TheftPaid_v
        End Get
        Set(ByVal value As Decimal)
            TheftPaid_v = value
        End Set
    End Property


    Public Property LandVehiclesPaid() As Decimal
        Get
            Return LandVehiclesPaid_v
        End Get
        Set(ByVal value As Decimal)
            LandVehiclesPaid_v = value
        End Set
    End Property


    Public Property AirCraftPaid() As Decimal
        Get
            Return AirCraftPaid_v
        End Get
        Set(ByVal value As Decimal)
            AirCraftPaid_v = value
        End Set
    End Property


    Public Property MaritimeVehiclesPaid() As Decimal
        Get
            Return MaritimeVehiclesPaid_v
        End Get
        Set(ByVal value As Decimal)
            MaritimeVehiclesPaid_v = value
        End Set
    End Property


    Public Property SmokePaid() As Decimal
        Get
            Return SmokePaid_v
        End Get
        Set(ByVal value As Decimal)
            SmokePaid_v = value
        End Set
    End Property


    Public Property SpaceShiftPaid() As Decimal
        Get
            Return SpaceShiftPaid_v
        End Get
        Set(ByVal value As Decimal)
            SpaceShiftPaid_v = value
        End Set
    End Property


    Public Property GLKHHPaid() As Decimal
        Get
            Return GLKHHPaid_v
        End Get
        Set(ByVal value As Decimal)
            GLKHHPaid_v = value
        End Set
    End Property


    Public Property MaliciousTerrorPaid() As Decimal
        Get
            Return MaliciousTerrorPaid_v
        End Get
        Set(ByVal value As Decimal)
            MaliciousTerrorPaid_v = value
        End Set
    End Property


    Public Property OtherGuaranteesPaid() As Decimal
        Get
            Return OtherGuaranteesPaid_v
        End Get
        Set(ByVal value As Decimal)
            OtherGuaranteesPaid_v = value
        End Set
    End Property


    Public Property BuildingPending() As Decimal
        Get
            Return BuildingPending_v
        End Get
        Set(ByVal value As Decimal)
            BuildingPending_v = value
        End Set
    End Property


    Public Property ContentsPending() As Decimal
        Get
            Return ContentsPending_v
        End Get
        Set(ByVal value As Decimal)
            ContentsPending_v = value
        End Set
    End Property


    Public Property EarthquakePending() As Decimal
        Get
            Return EarthquakePending_v
        End Get
        Set(ByVal value As Decimal)
            EarthquakePending_v = value
        End Set
    End Property


    Public Property FloodFloodingPending() As Decimal
        Get
            Return FloodFloodingPending_v
        End Get
        Set(ByVal value As Decimal)
            FloodFloodingPending_v = value
        End Set
    End Property


    Public Property InternalWaterPending() As Decimal
        Get
            Return InternalWaterPending_v
        End Get
        Set(ByVal value As Decimal)
            InternalWaterPending_v = value
        End Set
    End Property


    Public Property StormPending() As Decimal
        Get
            Return StormPending_v
        End Get
        Set(ByVal value As Decimal)
            StormPending_v = value
        End Set
    End Property


    Public Property TheftPending() As Decimal
        Get
            Return TheftPending_v
        End Get
        Set(ByVal value As Decimal)
            TheftPending_v = value
        End Set
    End Property


    Public Property LandVehiclesPending() As Decimal
        Get
            Return LandVehiclesPending_v
        End Get
        Set(ByVal value As Decimal)
            LandVehiclesPending_v = value
        End Set
    End Property


    Public Property AirCraftPending() As Decimal
        Get
            Return AirCraftPending_v
        End Get
        Set(ByVal value As Decimal)
            AirCraftPending_v = value
        End Set
    End Property


    Public Property MaritmeVehiclesPending() As Decimal
        Get
            Return MaritmeVehiclesPending_v
        End Get
        Set(ByVal value As Decimal)
            MaritmeVehiclesPending_v = value
        End Set
    End Property


    Public Property SmokePending() As Decimal
        Get
            Return SmokePending_v
        End Get
        Set(ByVal value As Decimal)
            SmokePending_v = value
        End Set
    End Property


    Public Property SpaceShiftPending() As Decimal
        Get
            Return SpaceShiftPending_v
        End Get
        Set(ByVal value As Decimal)
            SpaceShiftPending_v = value
        End Set
    End Property


    Public Property GLKHHPending() As Decimal
        Get
            Return GLKHHPending_v
        End Get
        Set(ByVal value As Decimal)
            GLKHHPending_v = value
        End Set
    End Property


    Public Property MaliciousTerrorPending() As Decimal
        Get
            Return MaliciousTerrorPending_v
        End Get
        Set(ByVal value As Decimal)
            MaliciousTerrorPending_v = value
        End Set
    End Property


    Public Property OtherGuaranteesPending() As Decimal
        Get
            Return OtherGuaranteesPending_v
        End Get
        Set(ByVal value As Decimal)
            OtherGuaranteesPending_v = value
        End Set
    End Property


    Public Property PendingTotalAmount() As Decimal
        Get
            Return PendingTotalAmount_v
        End Get
        Set(ByVal value As Decimal)
            PendingTotalAmount_v = value
        End Set
    End Property


    Public Property PendingTotalAmountTL() As Decimal
        Get
            Return PendingTotalAmountTL_v
        End Get
        Set(ByVal value As Decimal)
            PendingTotalAmountTL_v = value
        End Set
    End Property


    Public Property PaidTotalAmount() As Decimal
        Get
            Return PaidTotalAmount_v
        End Get
        Set(ByVal value As Decimal)
            PaidTotalAmount_v = value
        End Set
    End Property


    Public Property PaidTotalAmountTL() As Decimal
        Get
            Return PaidTotalAmountTL_v
        End Get
        Set(ByVal value As Decimal)
            PaidTotalAmountTL_v = value
        End Set
    End Property


    Public Property RustyAmount() As Decimal
        Get
            Return RustyAmount_v
        End Get
        Set(ByVal value As Decimal)
            RustyAmount_v = value
        End Set
    End Property


    Public Property FDSBMCode() As String
        Get
            Return FDSBMCode_v
        End Get
        Set(ByVal value As String)
            FDSBMCode_v = value
        End Set
    End Property

End Class
