Public Class tekdamage


    Private Policy_v As String
    Private DamageCost_v As Decimal

    Public Sub New()

    End Sub

    Public Sub New(ByVal Policy As String, ByVal DamageCost As Decimal)

        Me.Policy = Policy
        Me.DamageCost = DamageCost

    End Sub


    Public Property Policy() As String
        Get
            Return Policy_v
        End Get
        Set(ByVal value As String)
            Policy_v = value
        End Set
    End Property


    Public Property DamageCost() As Decimal
        Get
            Return DamageCost_v
        End Get
        Set(ByVal value As Decimal)
            DamageCost_v = value
        End Set
    End Property


End Class
