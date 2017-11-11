Public Class CLASSGENERICSERVISINPUT

    Private pkey_v As Integer
    Private genericservispkey_v As Integer
    Private paramad_v As String
    Private datatype_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal genericservispkey As Integer, _
    ByVal paramad As String, ByVal datatype As String)


        Me.pkey = pkey
        Me.genericservispkey = genericservispkey
        Me.paramad = paramad
        Me.datatype = datatype


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


    Public Property paramad() As String
        Get
            Return paramad_v
        End Get
        Set(ByVal value As String)
            paramad_v = value
        End Set
    End Property


    Public Property datatype() As String
        Get
            Return datatype_v
        End Get
        Set(ByVal value As String)
            datatype_v = value
        End Set
    End Property




End Class
