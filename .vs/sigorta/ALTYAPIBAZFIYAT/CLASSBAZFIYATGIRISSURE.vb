Public Class CLASSBAZFIYATGIRISSURE

    Private pkey_v As Integer
    Private girisbaslangic_v As Date
    Private girisbitis_v As Date
    Private gecerlilikbaslangic_v As Date
    Private gecerlilikbitis_v As Date
    Private policetip_v As Integer
    Private kayitno_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal girisbaslangic As Date, ByVal girisbitis As Date, _
    ByVal gecerlilikbaslangic As Date, ByVal gecerlilikbitis As Date, ByVal policetip As Integer, _
    ByVal kayitno As Integer)


        Me.pkey = pkey
        Me.girisbaslangic = girisbaslangic
        Me.girisbitis = girisbitis
        Me.gecerlilikbaslangic = gecerlilikbaslangic
        Me.gecerlilikbitis = gecerlilikbitis
        Me.policetip = policetip
        Me.kayitno = kayitno

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property girisbaslangic() As Nullable(Of Date)
        Get
            Return girisbaslangic_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            girisbaslangic_v = value
        End Set
    End Property


    Public Property girisbitis() As Nullable(Of Date)
        Get
            Return girisbitis_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            girisbitis_v = value
        End Set
    End Property


    Public Property gecerlilikbaslangic() As Nullable(Of Date)
        Get
            Return gecerlilikbaslangic_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            gecerlilikbaslangic_v = value
        End Set
    End Property


    Public Property gecerlilikbitis() As Nullable(Of Date)
        Get
            Return gecerlilikbitis_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            gecerlilikbitis_v = value
        End Set
    End Property


    Public Property policetip() As Integer
        Get
            Return policetip_v
        End Get
        Set(ByVal value As Integer)
            policetip_v = value
        End Set
    End Property


    Public Property kayitno() As Integer
        Get
            Return kayitno_v
        End Get
        Set(ByVal value As Integer)
            kayitno_v = value
        End Set
    End Property

End Class
