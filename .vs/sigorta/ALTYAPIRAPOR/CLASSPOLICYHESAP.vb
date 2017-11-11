Public Class CLASSPOLICYHESAP

    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private ProductType_v As String
    Private hPolicyPremium_v As Decimal
    Private hInsurancePremium_v As Decimal
    Private TariffCode_v As String
    Private CurrencyCode_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal FirmCode As String, ByVal ProductCode As String, ByVal AgencyCode As String, _
    ByVal PolicyNumber As String, ByVal ProductType As String, ByVal hPolicyPremium As Decimal, _
    ByVal hInsurancePremium As Decimal, ByVal TariffCode As String, ByVal CurrencyCode As String)


        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.ProductType = ProductType
        Me.hPolicyPremium = hPolicyPremium
        Me.hInsurancePremium = hInsurancePremium
        Me.TariffCode = TariffCode
        Me.CurrencyCode = CurrencyCode

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


    Public Property ProductType() As String
        Get
            Return ProductType_v
        End Get
        Set(ByVal value As String)
            ProductType_v = value
        End Set
    End Property


    Public Property hPolicyPremium() As Decimal
        Get
            Return hPolicyPremium_v
        End Get
        Set(ByVal value As Decimal)
            hPolicyPremium_v = value
        End Set
    End Property


    Public Property hInsurancePremium() As Decimal
        Get
            Return hInsurancePremium_v
        End Get
        Set(ByVal value As Decimal)
            hInsurancePremium_v = value
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



End Class
