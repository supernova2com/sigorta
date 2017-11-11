Public Class CLASSMANUELRAPORPARAMETRE

    Private pkey_v As Integer
    Private manuelraporpkey_v As Integer
    Private sad_v As String
    Private sdeger_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal manuelraporpkey As Integer, ByVal sad As String, _
    ByVal sdeger As String)


        Me.pkey = pkey
        Me.manuelraporpkey = manuelraporpkey
        Me.sad = sad
        Me.sdeger = sdeger

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property manuelraporpkey() As Integer
        Get
            Return manuelraporpkey_v
        End Get
        Set(ByVal value As Integer)
            manuelraporpkey_v = value
        End Set
    End Property


    Public Property sad() As String
        Get
            Return sad_v
        End Get
        Set(ByVal value As String)
            sad_v = value
        End Set
    End Property


    Public Property sdeger() As String
        Get
            Return sdeger_v
        End Get
        Set(ByVal value As String)
            sdeger_v = value
        End Set
    End Property

End Class
