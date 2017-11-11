Public Class CLASSEMAILAYAR


    Private pkey_v As Integer
    Private username_v As String
    Private password_v As String
    Private portnumber_v As Integer
    Private sslvarmi_v As String
    Private oncelik_v As String
    Private pickupdirectorylocation_v As String
    Private hostname_v As String
    Private usedefaultcredentials_v As String
    Private deliverymethod_v As String
    Private udckullan_v As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal username As String, _
    ByVal password As String, ByVal portnumber As Integer, ByVal sslvarmi As String, _
    ByVal oncelik As String, ByVal pickupdirectorylocation As String, _
    ByVal hostname As String, ByVal usedefaultcredentials As String, _
    ByVal deliverymethod As String, ByVal udckullan As String)

        Me.pkey = pkey
        Me.username = username
        Me.password = password
        Me.sslvarmi = sslvarmi
        Me.oncelik = oncelik
        Me.pickupdirectorylocation = pickupdirectorylocation
        Me.hostname = hostname
        Me.usedefaultcredentials = usedefaultcredentials
        Me.deliverymethod = deliverymethod
        Me.udckullan = udckullan

    End Sub


    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property

    Public Property username() As String
        Get
            Return username_v
        End Get
        Set(ByVal value As String)
            username_v = value
        End Set
    End Property


    Public Property password() As String
        Get
            Return password_v
        End Get
        Set(ByVal value As String)
            password_v = value
        End Set
    End Property

    Public Property portnumber() As Integer
        Get
            Return portnumber_v
        End Get
        Set(ByVal value As Integer)
            portnumber_v = value
        End Set
    End Property

    Public Property sslvarmi() As String
        Get
            Return sslvarmi_v
        End Get
        Set(ByVal value As String)
            sslvarmi_v = value
        End Set
    End Property

    Public Property oncelik() As String
        Get
            Return oncelik_v
        End Get
        Set(ByVal value As String)
            oncelik_v = value
        End Set
    End Property

    Public Property pickupdirectorylocation() As String
        Get
            Return pickupdirectorylocation_v
        End Get
        Set(ByVal value As String)
            pickupdirectorylocation_v = value
        End Set
    End Property

    Public Property hostname() As String
        Get
            Return hostname_v
        End Get
        Set(ByVal value As String)
            hostname_v = value
        End Set
    End Property


    Public Property usedefaultcredentials() As String
        Get
            Return usedefaultcredentials_v
        End Get
        Set(ByVal value As String)
            usedefaultcredentials_v = value
        End Set
    End Property

    Public Property deliverymethod() As String
        Get
            Return deliverymethod_v
        End Get
        Set(ByVal value As String)
            deliverymethod_v = value
        End Set
    End Property

    Public Property udckullan() As String
        Get
            Return udckullan_v
        End Get
        Set(ByVal value As String)
            udckullan_v = value
        End Set
    End Property


End Class
