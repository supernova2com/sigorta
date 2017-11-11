Public Class CLASSLOGHESAP

    Private pkey_v As Integer
    Private tarih_v As DateTime
    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private TecditNumber_v As String
    Private ZeylCode_v As String
    Private ZeylNo_v As String
    Private s_InsuarencePremium_v As Decimal
    Private s_BasePriceValue_v As Decimal
    Private s_CCRateValue_v As Decimal
    Private s_DamageRateValue_v As Decimal
    Private s_AgeRateValue_v As Decimal
    Private s_DamagelessRateValue_v As Decimal
    Private hesaplog_v As String
    Private tuzukccoran_v As Decimal
    Private tuzukyasoran_v As Decimal
    Private sonuckodu_v As Integer
    Private hatakodu_v As Integer
    Private hatamsg_v As String
    Private s_AnyDriver_v As Decimal
    Private g_AuthorizedDrivers_v As String
    Private g_CurrencyCode_v As String
    Private g_InsurancePremium_v As Decimal
    Private g_AssistantFees_v As Decimal
    Private g_OtherFees_v As Decimal
    Private g_BasePriceValue_v As Decimal
    Private g_CCRateValue_v As Decimal
    Private g_DamageRateValue_v As Decimal
    Private g_AgeRateValue_v As Decimal
    Private g_DamagelessRateValue_v As Decimal
    Private ArrangeDate_v As Nullable(Of Date)
    Private hasarsorgulog_v As String
    Private ProductType_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tarih As DateTime, ByVal FirmCode As String, _
    ByVal ProductCode As String, ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, ByVal ZeylNo As String, _
    ByVal s_InsuarencePremium As Decimal, ByVal s_BasePriceValue As Decimal, ByVal s_CCRateValue As Decimal, _
    ByVal s_DamageRateValue As Decimal, ByVal s_AgeRateValue As Decimal, ByVal s_DamagelessRateValue As Decimal, _
    ByVal hesaplog As String, ByVal tuzukccoran As Decimal, ByVal tuzukyasoran As Decimal, _
    ByVal sonuckodu As Integer, ByVal hatakodu As Integer, ByVal hatamsg As String, _
    ByVal s_AnyDriver As Decimal, ByVal g_AuthorizedDrivers As String, ByVal g_CurrencyCode As String, _
    ByVal g_InsurancePremium As Decimal, ByVal g_AssistantFees As Decimal, ByVal g_OtherFees As Decimal, _
    ByVal g_BasePriceValue As Decimal, ByVal g_CCRateValue As Decimal, ByVal g_DamageRateValue As Decimal, _
    ByVal g_AgeRateValue As Decimal, ByVal g_DamagelessRateValue As Decimal, _
    ByVal ArrangeDate As Date, ByVal hasarsorgulog As String, ByVal ProductType As String)


        Me.pkey = pkey
        Me.tarih = tarih
        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.TecditNumber = TecditNumber
        Me.ZeylCode = ZeylCode
        Me.ZeylNo = ZeylNo
        Me.s_InsuarencePremium = s_InsuarencePremium
        Me.s_BasePriceValue = s_BasePriceValue
        Me.s_CCRateValue = s_CCRateValue
        Me.s_DamageRateValue = s_DamageRateValue
        Me.s_AgeRateValue = s_AgeRateValue
        Me.s_DamagelessRateValue = s_DamagelessRateValue
        Me.hesaplog = hesaplog
        Me.tuzukccoran = tuzukccoran
        Me.tuzukyasoran = tuzukyasoran
        Me.sonuckodu = sonuckodu
        Me.hatakodu = hatakodu
        Me.hatamsg = hatamsg
        Me.s_AnyDriver = s_AnyDriver
        Me.g_AuthorizedDrivers = g_AuthorizedDrivers
        Me.g_CurrencyCode = g_CurrencyCode
        Me.g_InsurancePremium = g_InsurancePremium
        Me.g_AssistantFees = g_AssistantFees
        Me.g_OtherFees = g_OtherFees
        Me.g_BasePriceValue = g_BasePriceValue
        Me.g_CCRateValue = g_CCRateValue
        Me.g_DamageRateValue = g_DamageRateValue
        Me.g_AgeRateValue = g_AgeRateValue
        Me.g_DamagelessRateValue = g_DamagelessRateValue
        Me.ArrangeDate = ArrangeDate
        Me.hasarsorgulog = hasarsorgulog
        Me.ProductType = ProductType


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property tarih() As Nullable(Of DateTime)
        Get
            Return tarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            tarih_v = value
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


    Public Property ZeylNo() As String
        Get
            Return ZeylNo_v
        End Get
        Set(ByVal value As String)
            ZeylNo_v = value
        End Set
    End Property


    Public Property s_InsuarencePremium() As Decimal
        Get
            Return s_InsuarencePremium_v
        End Get
        Set(ByVal value As Decimal)
            s_InsuarencePremium_v = value
        End Set
    End Property


    Public Property s_BasePriceValue() As Decimal
        Get
            Return s_BasePriceValue_v
        End Get
        Set(ByVal value As Decimal)
            s_BasePriceValue_v = value
        End Set
    End Property


    Public Property s_CCRateValue() As Decimal
        Get
            Return s_CCRateValue_v
        End Get
        Set(ByVal value As Decimal)
            s_CCRateValue_v = value
        End Set
    End Property


    Public Property s_DamageRateValue() As Decimal
        Get
            Return s_DamageRateValue_v
        End Get
        Set(ByVal value As Decimal)
            s_DamageRateValue_v = value
        End Set
    End Property


    Public Property s_AgeRateValue() As Decimal
        Get
            Return s_AgeRateValue_v
        End Get
        Set(ByVal value As Decimal)
            s_AgeRateValue_v = value
        End Set
    End Property


    Public Property s_DamagelessRateValue() As Decimal
        Get
            Return s_DamagelessRateValue_v
        End Get
        Set(ByVal value As Decimal)
            s_DamagelessRateValue_v = value
        End Set
    End Property


    Public Property hesaplog() As String
        Get
            Return hesaplog_v
        End Get
        Set(ByVal value As String)
            hesaplog_v = value
        End Set
    End Property


    Public Property tuzukccoran() As Decimal
        Get
            Return tuzukccoran_v
        End Get
        Set(ByVal value As Decimal)
            tuzukccoran_v = value
        End Set
    End Property


    Public Property tuzukyasoran() As Decimal
        Get
            Return tuzukyasoran_v
        End Get
        Set(ByVal value As Decimal)
            tuzukyasoran_v = value
        End Set
    End Property


    Public Property sonuckodu() As Integer
        Get
            Return sonuckodu_v
        End Get
        Set(ByVal value As Integer)
            sonuckodu_v = value
        End Set
    End Property


    Public Property hatakodu() As Integer
        Get
            Return hatakodu_v
        End Get
        Set(ByVal value As Integer)
            hatakodu_v = value
        End Set
    End Property


    Public Property hatamsg() As String
        Get
            Return hatamsg_v
        End Get
        Set(ByVal value As String)
            hatamsg_v = value
        End Set
    End Property


    Public Property s_AnyDriver() As Decimal
        Get
            Return s_AnyDriver_v
        End Get
        Set(ByVal value As Decimal)
            s_AnyDriver_v = value
        End Set
    End Property


    Public Property g_AuthorizedDrivers() As String
        Get
            Return g_AuthorizedDrivers_v
        End Get
        Set(ByVal value As String)
            g_AuthorizedDrivers_v = value
        End Set
    End Property


    Public Property g_CurrencyCode() As String
        Get
            Return g_CurrencyCode_v
        End Get
        Set(ByVal value As String)
            g_CurrencyCode_v = value
        End Set
    End Property


    Public Property g_InsurancePremium() As Decimal
        Get
            Return g_InsurancePremium_v
        End Get
        Set(ByVal value As Decimal)
            g_InsurancePremium_v = value
        End Set
    End Property


    Public Property g_AssistantFees() As Decimal
        Get
            Return g_AssistantFees_v
        End Get
        Set(ByVal value As Decimal)
            g_AssistantFees_v = value
        End Set
    End Property


    Public Property g_OtherFees() As Decimal
        Get
            Return g_OtherFees_v
        End Get
        Set(ByVal value As Decimal)
            g_OtherFees_v = value
        End Set
    End Property


    Public Property g_BasePriceValue() As Decimal
        Get
            Return g_BasePriceValue_v
        End Get
        Set(ByVal value As Decimal)
            g_BasePriceValue_v = value
        End Set
    End Property


    Public Property g_CCRateValue() As Decimal
        Get
            Return g_CCRateValue_v
        End Get
        Set(ByVal value As Decimal)
            g_CCRateValue_v = value
        End Set
    End Property


    Public Property g_DamageRateValue() As Decimal
        Get
            Return g_DamageRateValue_v
        End Get
        Set(ByVal value As Decimal)
            g_DamageRateValue_v = value
        End Set
    End Property


    Public Property g_AgeRateValue() As Decimal
        Get
            Return g_AgeRateValue_v
        End Get
        Set(ByVal value As Decimal)
            g_AgeRateValue_v = value
        End Set
    End Property


    Public Property g_DamagelessRateValue() As Decimal
        Get
            Return g_DamagelessRateValue_v
        End Get
        Set(ByVal value As Decimal)
            g_DamagelessRateValue_v = value
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

    Public Property hasarsorgulog() As String
        Get
            Return hasarsorgulog_v
        End Get
        Set(ByVal value As String)
            hasarsorgulog_v = value
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





End Class
