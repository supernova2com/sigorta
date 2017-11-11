Public Class CLASSFIELDOPERATORVALUE


    Private basx_v As String
    Private field_v As String
    Private opx_v As String
    Private value_v As String
    Private sonx_v As String

    Public Sub New()

    End Sub
    Public Sub New(ByVal basx As String, ByVal field As String, ByVal opx As String, _
    ByVal value As String, ByVal sonx As String)

        Me.basx = basx
        Me.field = field
        Me.opx = opx
        Me.value = value
        Me.sonx = sonx

    End Sub


    Public Property basx() As String
        Get
            Return basx_v
        End Get
        Set(ByVal value As String)
            basx_v = value
        End Set
    End Property

    Public Property field() As String
        Get
            Return field_v
        End Get
        Set(ByVal value As String)
            field_v = value
        End Set
    End Property


    Public Property opx() As String
        Get
            Return opx_v
        End Get
        Set(ByVal value As String)
            opx_v = value
        End Set
    End Property


    Public Property value() As String
        Get
            Return value_v
        End Get
        Set(ByVal value As String)
            value_v = value
        End Set
    End Property


    Public Property sonx() As String
        Get
            Return sonx_v
        End Get
        Set(ByVal value As String)
            sonx_v = value
        End Set
    End Property

End Class
