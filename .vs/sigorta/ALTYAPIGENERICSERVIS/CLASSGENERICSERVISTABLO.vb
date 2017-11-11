Public Class CLASSGENERICSERVISTABLO

    Private pkey_v As Integer
    Private genericservispkey_v As Integer
    Private tabload_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal genericservispkey As Integer, ByVal tabload As String)


        Me.pkey = pkey
        Me.genericservispkey = genericservispkey
        Me.tabload = tabload

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property genericservispkey() As Integer
        Get
            Return genericservispkey_v
        End Get
        Set(ByVal value As Integer)
            genericservispkey_v = value
        End Set
    End Property


    Public Property tabload() As String
        Get
            Return tabload_v
        End Get
        Set(ByVal value As String)
            tabload_v = value
        End Set
    End Property



End Class
