Public Class CLASSAGE


    Private pkey_v As Integer
    Private baslangicage_v As Integer
    Private bitisage_v As Integer
    Private agerate_v As Decimal


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal baslangicage As Integer, ByVal bitisage As Integer, _
    ByVal agerate As Decimal)


        Me.pkey = pkey
        Me.baslangicage = baslangicage
        Me.bitisage = bitisage
        Me.agerate = agerate

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property baslangicage() As Integer
        Get
            Return baslangicage_v
        End Get
        Set(ByVal value As Integer)
            baslangicage_v = value
        End Set
    End Property


    Public Property bitisage() As Integer
        Get
            Return bitisage_v
        End Get
        Set(ByVal value As Integer)
            bitisage_v = value
        End Set
    End Property


    Public Property agerate() As Decimal
        Get
            Return agerate_v
        End Get
        Set(ByVal value As Decimal)
            agerate_v = value
        End Set
    End Property


End Class
