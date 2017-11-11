Public Class CLASSSINIRKAPIIP

    Private pkey_v As Integer
    Private sinirkapipkey_v As Integer
    Private cidr_v As Integer
    Private ip_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sinirkapipkey As Integer, ByVal cidr As Integer, _
    ByVal ip As String)


        Me.pkey = pkey
        Me.sinirkapipkey = sinirkapipkey
        Me.cidr = cidr
        Me.ip = ip

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sinirkapipkey() As Integer
        Get
            Return sinirkapipkey_v
        End Get
        Set(ByVal value As Integer)
            sinirkapipkey_v = value
        End Set
    End Property


    Public Property cidr() As Integer
        Get
            Return cidr_v
        End Get
        Set(ByVal value As Integer)
            cidr_v = value
        End Set
    End Property


    Public Property ip() As String
        Get
            Return ip_v
        End Get
        Set(ByVal value As String)
            ip_v = value
        End Set
    End Property




End Class
