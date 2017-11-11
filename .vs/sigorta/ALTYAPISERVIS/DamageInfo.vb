Public Class DamageInfo

    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private TecditNumber_v As String
    Private FileNo_v As String
    Private RequestNo_v As String
    Private DriverPlateCountryCode_v As String
    Private DriverPlateNumber_v As String
    Private AccidentDate_v As Nullable(Of Date)
    Private AccidentLocation_v As String
    Private InformingDate_v As Nullable(Of DateTime)
    Private DriverCountryCode_v As String
    Private DriverIdentityCode_v As String
    Private DriverIdentityNo_v As String
    Private DriverName_v As String
    Private DriverSurname_v As String
    Private ClaimantCountryCode_v As String
    Private ClaimantIdentityCode_v As String
    Private ClaimantIdentityNo_v As String
    Private ClaimantName_v As String
    Private ClaimantSurname_v As String
    Private AppealDate_v As Nullable(Of Date)
    Private ClaimantPlateCountryCode_v As String
    Private ClaimantPlateNumber_v As String
    Private DamageReason_v As String
    Private DamageStatusCode_v As String
    Private EstimatedMaterialDamage_v As Decimal
    Private PaidMaterialDamage_v As Decimal
    Private CloseDate_v As Nullable(Of Date)
    Private EstimatedCorporalDamage_v As Decimal
    Private PaidCorporalDamage_v As Decimal
    Private TotalLost_v As String
    Private TariffCode_v As String
    Private CurrencyCode_v As String
    Private EstimatedMaterialAmountTL_v As Decimal
    Private PaidMaterialAmountTL_v As Decimal
    Private EstimatedCorporalAmountTL_v As Decimal
    Private PaidCorporalAmountTL_v As Decimal
    Private ProductType_v As String
    Private SBMCode_v As String
    Private ExchangeRate_v As Decimal
    Private AgencyRegisterCode_v As String
    Private TPNo_v As String
    Private PolicyType_v As Integer




    Public Sub New()
    End Sub

    Public Sub New(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal DriverPlateCountryCode As String, ByVal DriverPlateNumber As String, _
    ByVal AccidentDate As Date, ByVal AccidentLocation As String, ByVal InformingDate As DateTime, _
    ByVal DriverCountryCode As String, ByVal DriverIdentityCode As String, ByVal DriverIdentityNo As String, _
    ByVal DriverName As String, ByVal DriverSurname As String, ByVal ClaimantCountryCode As String, _
    ByVal ClaimantIdentityCode As String, ByVal ClaimantIdentityNo As String, ByVal ClaimantName As String, _
    ByVal ClaimantSurname As String, ByVal AppealDate As Date, ByVal ClaimantPlateCountryCode As String, _
    ByVal ClaimantPlateNumber As String, ByVal DamageReason As String, _
    ByVal DamageStatusCode As String, ByVal EstimatedMaterialDamage As Decimal, ByVal PaidMaterialDamage As Decimal, ByVal CloseDate As Date, _
    ByVal EstimatedCorporalDamage As Decimal, ByVal PaidCorporalDamage As Decimal, ByVal TotalLost As String, _
    ByVal TariffCode As String, ByVal CurrencyCode As String, ByVal EstimatedMaterialAmountTL As Decimal, _
    ByVal PaidMaterialAmountTL As Decimal, ByVal EstimatedCorporalAmountTL As Decimal, ByVal PaidCorporalAmountTL As Decimal, _
    ByVal ProductType As String, ByVal SBMCode As String, ByVal ExchangeRate As Decimal, _
    ByVal AgencyRegisterCode As String, ByVal TPNo As String, ByVal PolicyType As Integer)

        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.TecditNumber = TecditNumber
        Me.FileNo = FileNo
        Me.RequestNo = RequestNo
        Me.DriverPlateCountryCode = DriverPlateCountryCode
        Me.DriverPlateNumber = DriverPlateNumber
        Me.AccidentDate = AccidentDate
        Me.AccidentLocation = AccidentLocation
        Me.InformingDate = InformingDate
        Me.DriverCountryCode = DriverCountryCode
        Me.DriverIdentityCode = DriverIdentityCode
        Me.DriverIdentityNo = DriverIdentityNo
        Me.DriverName = DriverName
        Me.DriverSurname = DriverSurname
        Me.ClaimantCountryCode = ClaimantCountryCode
        Me.ClaimantIdentityCode = ClaimantIdentityCode
        Me.ClaimantIdentityNo = ClaimantIdentityNo
        Me.ClaimantName = ClaimantName
        Me.ClaimantSurname = ClaimantSurname
        Me.AppealDate = AppealDate
        Me.ClaimantPlateCountryCode = ClaimantPlateCountryCode
        Me.ClaimantPlateNumber = ClaimantPlateNumber
        Me.DamageReason = DamageReason
        Me.DamageStatusCode = DamageStatusCode
        Me.EstimatedMaterialDamage = EstimatedMaterialDamage
        Me.PaidMaterialDamage = PaidMaterialDamage
        Me.CloseDate = CloseDate
        Me.EstimatedCorporalDamage = EstimatedCorporalDamage
        Me.PaidCorporalDamage = PaidCorporalDamage
        Me.TotalLost = TotalLost
        Me.TariffCode = TariffCode
        Me.CurrencyCode = CurrencyCode
        Me.EstimatedMaterialAmountTL = EstimatedMaterialAmountTL
        Me.PaidMaterialAmountTL = PaidMaterialAmountTL
        Me.EstimatedCorporalAmountTL = EstimatedCorporalAmountTL
        Me.PaidCorporalAmountTL = PaidCorporalAmountTL
        Me.ProductType = ProductType
        Me.SBMCode = SBMCode
        Me.ExchangeRate = ExchangeRate
        Me.AgencyRegisterCode = AgencyRegisterCode
        Me.TPNo = TPNo
        Me.PolicyType = PolicyType


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


    Public Property FileNo() As String
        Get
            Return FileNo_v
        End Get
        Set(ByVal value As String)
            FileNo_v = value
        End Set
    End Property


    Public Property RequestNo() As String
        Get
            Return RequestNo_v
        End Get
        Set(ByVal value As String)
            RequestNo_v = value
        End Set
    End Property


    Public Property DriverPlateCountryCode() As String
        Get
            Return DriverPlateCountryCode_v
        End Get
        Set(ByVal value As String)
            DriverPlateCountryCode_v = value
        End Set
    End Property


    Public Property DriverPlateNumber() As String
        Get
            Return DriverPlateNumber_v
        End Get
        Set(ByVal value As String)
            DriverPlateNumber_v = value
        End Set
    End Property


    Public Property AccidentDate() As Nullable(Of Date)
        Get
            Return AccidentDate_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            AccidentDate_v = value
        End Set
    End Property


    Public Property AccidentLocation() As String
        Get
            Return AccidentLocation_v
        End Get
        Set(ByVal value As String)
            AccidentLocation_v = value
        End Set
    End Property


    Public Property InformingDate() As Nullable(Of DateTime)
        Get
            Return InformingDate_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            InformingDate_v = value
        End Set
    End Property


    Public Property DriverCountryCode() As String
        Get
            Return DriverCountryCode_v
        End Get
        Set(ByVal value As String)
            DriverCountryCode_v = value
        End Set
    End Property


    Public Property DriverIdentityCode() As String
        Get
            Return DriverIdentityCode_v
        End Get
        Set(ByVal value As String)
            DriverIdentityCode_v = value
        End Set
    End Property


    Public Property DriverIdentityNo() As String
        Get
            Return DriverIdentityNo_v
        End Get
        Set(ByVal value As String)
            DriverIdentityNo_v = value
        End Set
    End Property


    Public Property DriverName() As String
        Get
            Return DriverName_v
        End Get
        Set(ByVal value As String)
            DriverName_v = value
        End Set
    End Property


    Public Property DriverSurname() As String
        Get
            Return DriverSurname_v
        End Get
        Set(ByVal value As String)
            DriverSurname_v = value
        End Set
    End Property


    Public Property ClaimantCountryCode() As String
        Get
            Return ClaimantCountryCode_v
        End Get
        Set(ByVal value As String)
            ClaimantCountryCode_v = value
        End Set
    End Property


    Public Property ClaimantIdentityCode() As String
        Get
            Return ClaimantIdentityCode_v
        End Get
        Set(ByVal value As String)
            ClaimantIdentityCode_v = value
        End Set
    End Property


    Public Property ClaimantIdentityNo() As String
        Get
            Return ClaimantIdentityNo_v
        End Get
        Set(ByVal value As String)
            ClaimantIdentityNo_v = value
        End Set
    End Property


    Public Property ClaimantName() As String
        Get
            Return ClaimantName_v
        End Get
        Set(ByVal value As String)
            ClaimantName_v = value
        End Set
    End Property


    Public Property ClaimantSurname() As String
        Get
            Return ClaimantSurname_v
        End Get
        Set(ByVal value As String)
            ClaimantSurname_v = value
        End Set
    End Property


    Public Property AppealDate() As Nullable(Of Date)
        Get
            Return AppealDate_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            AppealDate_v = value
        End Set
    End Property


    Public Property ClaimantPlateCountryCode() As String
        Get
            Return ClaimantPlateCountryCode_v
        End Get
        Set(ByVal value As String)
            ClaimantPlateCountryCode_v = value
        End Set
    End Property


    Public Property ClaimantPlateNumber() As String
        Get
            Return ClaimantPlateNumber_v
        End Get
        Set(ByVal value As String)
            ClaimantPlateNumber_v = value
        End Set
    End Property


    Public Property DamageReason() As String
        Get
            Return DamageReason_v
        End Get
        Set(ByVal value As String)
            DamageReason_v = value
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


    Public Property EstimatedMaterialDamage() As Decimal
        Get
            Return EstimatedMaterialDamage_v
        End Get
        Set(ByVal value As Decimal)
            EstimatedMaterialDamage_v = value
        End Set
    End Property


    Public Property PaidMaterialDamage() As Decimal
        Get
            Return PaidMaterialDamage_v
        End Get
        Set(ByVal value As Decimal)
            PaidMaterialDamage_v = value
        End Set
    End Property


    Public Property CloseDate() As Nullable(Of Date)
        Get
            Return CloseDate_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            CloseDate_v = value
        End Set
    End Property


    Public Property EstimatedCorporalDamage() As Decimal
        Get
            Return EstimatedCorporalDamage_v
        End Get
        Set(ByVal value As Decimal)
            EstimatedCorporalDamage_v = value
        End Set
    End Property


    Public Property PaidCorporalDamage() As Decimal
        Get
            Return PaidCorporalDamage_v
        End Get
        Set(ByVal value As Decimal)
            PaidCorporalDamage_v = value
        End Set
    End Property


    Public Property TotalLost() As String
        Get
            Return TotalLost_v
        End Get
        Set(ByVal value As String)
            TotalLost_v = value
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


    Public Property CurrencyCode() As String
        Get
            Return CurrencyCode_v
        End Get
        Set(ByVal value As String)
            CurrencyCode_v = value
        End Set
    End Property


    Public Property EstimatedMaterialAmountTL() As Decimal
        Get
            Return EstimatedMaterialAmountTL_v
        End Get
        Set(ByVal value As Decimal)
            EstimatedMaterialAmountTL_v = value
        End Set
    End Property


    Public Property PaidMaterialAmountTL() As Decimal
        Get
            Return PaidMaterialAmountTL_v
        End Get
        Set(ByVal value As Decimal)
            PaidMaterialAmountTL_v = value
        End Set
    End Property


    Public Property EstimatedCorporalAmountTL() As Decimal
        Get
            Return EstimatedCorporalAmountTL_v
        End Get
        Set(ByVal value As Decimal)
            EstimatedCorporalAmountTL_v = value
        End Set
    End Property


    Public Property PaidCorporalAmountTL() As Decimal
        Get
            Return PaidCorporalAmountTL_v
        End Get
        Set(ByVal value As Decimal)
            PaidCorporalAmountTL_v = value
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


    Public Property SBMCode() As String
        Get
            Return SBMCode_v
        End Get
        Set(ByVal value As String)
            SBMCode_v = value
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


    Public Property PolicyType() As Integer
        Get
            Return PolicyType_v
        End Get
        Set(ByVal value As Integer)
            PolicyType_v = value
        End Set
    End Property


End Class
