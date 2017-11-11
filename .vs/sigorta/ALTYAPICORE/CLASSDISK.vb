Public Class CLASSDISK

    Private surucu_v As String
    Private kapasite_v As Decimal
    Private kullanilan_v As Decimal
    Private kalan_v As Decimal
    Private diskad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal surucu As String, ByVal kapasite As Decimal, ByVal kullanilan As Decimal, _
    ByVal kalan As Decimal, ByVal diskad As String)


        Me.surucu = surucu
        Me.kapasite = kapasite
        Me.kullanilan = kullanilan
        Me.kalan = kalan
        Me.diskad = diskad


    End Sub

    Public Property surucu() As String
        Get
            Return surucu_v
        End Get
        Set(ByVal value As String)
            surucu_v = value
        End Set
    End Property


    Public Property kapasite() As Decimal
        Get
            Return kapasite_v
        End Get
        Set(ByVal value As Decimal)
            kapasite_v = value
        End Set
    End Property


    Public Property kullanilan() As Decimal
        Get
            Return kullanilan_v
        End Get
        Set(ByVal value As Decimal)
            kullanilan_v = value
        End Set
    End Property


    Public Property kalan() As Decimal
        Get
            Return kalan_v
        End Get
        Set(ByVal value As Decimal)
            kalan_v = value
        End Set
    End Property


    Public Property diskad() As String
        Get
            Return diskad_v
        End Get
        Set(ByVal value As String)
            diskad_v = value
        End Set
    End Property



End Class
