Public Class CLASSIKIDECIMAL

    Private damagerate_v As Decimal
    Private damagelessrate_v As Decimal


    Public Sub New()
    End Sub

    Public Sub New(ByVal damagerate As Decimal, ByVal damagelessrate As Decimal)

        Me.damagerate = damagerate
        Me.DamagelessRate = DamagelessRate

    End Sub

    Public Property damagerate() As Decimal
        Get
            Return damagerate_v
        End Get
        Set(ByVal value As Decimal)
            damagerate_v = value
        End Set
    End Property


    Public Property damagelessrate() As Decimal
        Get
            Return DamagelessRate_v
        End Get
        Set(ByVal value As Decimal)
            DamagelessRate_v = value
        End Set
    End Property


End Class
