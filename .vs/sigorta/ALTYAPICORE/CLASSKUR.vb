Public Class CLASSKUR

    Private pkey_v As Integer
    Private pkod_v As String
    Private paciklama_v As String
    Private alis_v As Decimal
    Private satis_v As Decimal
    Private kurtarih_v As DateTime


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal pkod As String, ByVal paciklama As String, _
    ByVal alis As Decimal, ByVal satis As Decimal, ByVal kurtarih As DateTime)


        Me.pkey = pkey
        Me.pkod = pkod
        Me.paciklama = paciklama
        Me.alis = alis
        Me.satis = satis
        Me.kurtarih = kurtarih

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property pkod() As String
        Get
            Return pkod_v
        End Get
        Set(ByVal value As String)
            pkod_v = value
        End Set
    End Property


    Public Property paciklama() As String
        Get
            Return paciklama_v
        End Get
        Set(ByVal value As String)
            paciklama_v = value
        End Set
    End Property


    Public Property alis() As Decimal
        Get
            Return alis_v
        End Get
        Set(ByVal value As Decimal)
            alis_v = value
        End Set
    End Property


    Public Property satis() As Decimal
        Get
            Return satis_v
        End Get
        Set(ByVal value As Decimal)
            satis_v = value
        End Set
    End Property


    Public Property kurtarih() As Nullable(Of DateTime)
        Get
            Return kurtarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kurtarih_v = value
        End Set
    End Property

End Class
