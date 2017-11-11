Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("Damage")> _
Public Class Damage

    Private Hangisi_v As String
    Private Policy_v As String
    Private CCRate_v As Integer
    Private AgeRate_v As Integer
    Private AnyDriverRate_v As Integer
    Private TotalDamageCount_v As Integer
    Private TotalDamageCost_v As Decimal
    Private DamageRate_v As Integer
    Private DamagelessRate_v As Integer

    Public Sub New()

    End Sub

    Public Sub New(ByVal Hangisi As String, ByVal Policy As String, _
    ByVal CCRate_v As Integer, ByVal AgeRate_v As Integer, _
    ByVal AnyDriverRate_v As Integer, ByVal TotalDamageCount As Integer, _
    ByVal TotalDamageCost As Decimal, ByVal DamageRate As Integer, _
    ByVal DamagelessRate As Integer)

        Me.Hangisi = Hangisi
        Me.Policy = Policy
        Me.CCRate = CCRate
        Me.AgeRate = AgeRate
        Me.AnyDriverRate = AnyDriverRate
        Me.TotalDamageCount = TotalDamageCount
        Me.TotalDamageCost = TotalDamageCost
        Me.DamageRate = DamageRate
        Me.DamagelessRate = DamagelessRate

    End Sub



    <XmlAttribute("Hangisi")> _
    Public Property Hangisi() As String
        Get
            Return Hangisi_v
        End Get
        Set(ByVal value As String)
            Hangisi_v = value
        End Set
    End Property

    <XmlAttribute("Policy")> _
    Public Property Policy() As String
        Get
            Return Policy_v
        End Get
        Set(ByVal value As String)
            Policy_v = value
        End Set
    End Property


    <XmlAttribute("CCRate")> _
    Public Property CCRate() As Integer
        Get
            Return CCRate_v
        End Get
        Set(ByVal value As Integer)
            CCRate_v = value
        End Set
    End Property



    <XmlAttribute("AgeRate")> _
    Public Property AgeRate() As Integer
        Get
            Return AgeRate_v
        End Get
        Set(ByVal value As Integer)
            AgeRate_v = value
        End Set
    End Property


    <XmlAttribute("AnyDriverRate")> _
    Public Property AnyDriverRate() As Integer
        Get
            Return AnyDriverRate_v
        End Get
        Set(ByVal value As Integer)
            AnyDriverRate_v = value
        End Set
    End Property


    <XmlAttribute("TotalDamageCount")> _
    Public Property TotalDamageCount() As Integer
        Get
            Return TotalDamageCount_v
        End Get
        Set(ByVal value As Integer)
            TotalDamageCount_v = value
        End Set
    End Property


    <XmlAttribute("TotalDamageCost")> _
    Public Property TotalDamageCost() As Decimal
        Get
            Return TotalDamageCost_v
        End Get
        Set(ByVal value As Decimal)
            TotalDamageCost_v = value
        End Set
    End Property


    <XmlAttribute("DamageRate")> _
    Public Property DamageRate() As Integer
        Get
            Return DamageRate_v
        End Get
        Set(ByVal value As Integer)
            DamageRate_v = value
        End Set
    End Property


    <XmlAttribute("DamagelessRate")> _
    Public Property DamagelessRate() As Integer
        Get
            Return DamagelessRate_v
        End Get
        Set(ByVal value As Integer)
            DamagelessRate_v = value
        End Set
    End Property

End Class
