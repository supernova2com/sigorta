<Serializable()> _
Public Class CLASSTAKVIM
    Inherits CLASSGENERIC


    Private tip_v As String
    Private id_v As Integer
    Private start_v As String
    Private end_v As String
    Private title_v As String
    Private pkey_v As Integer
    Private backgroundColor_v As String
    Private allDay_v As Boolean
    Private editable_v As Boolean


    Public Sub New()

    End Sub

    Public Sub New(ByVal tip As String, ByVal id As Integer, ByVal start As String, _
    ByVal [end] As String, ByVal title As String, ByVal pkey As Integer, _
    ByVal backgroundColor As String, ByVal allDay As Boolean, ByVal editable As Boolean)

        Me.tip_v = tip
        Me.id = id
        Me.start = start
        Me.end = [end]
        Me.title = title
        Me.pkey = pkey
        Me.backgroundColor = backgroundColor
        Me.allDay = allDay
        Me.editable = editable

    End Sub


    Public Property tip() As String
        Get
            Return tip_v
        End Get
        Set(ByVal value As String)
            tip_v = value
        End Set
    End Property

    Public Property id() As Integer
        Get
            Return id_v
        End Get
        Set(ByVal value As Integer)
            id_v = value
        End Set
    End Property

    Public Property start() As String
        Get
            Return start_v
        End Get
        Set(ByVal value As String)
            start_v = value
        End Set
    End Property

    Public Property [end]() As String
        Get
            Return end_v
        End Get
        Set(ByVal value As String)
            end_v = value
        End Set
    End Property


    Public Property title() As String
        Get
            Return title_v
        End Get
        Set(ByVal value As String)
            title_v = value
        End Set
    End Property

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property

    Public Property backgroundColor() As String
        Get
            Return backgroundColor_v
        End Get
        Set(ByVal value As String)
            backgroundColor_v = value
        End Set
    End Property

    Public Property allDay() As Boolean
        Get
            Return allDay_v
        End Get
        Set(ByVal value As Boolean)
            allDay_v = value
        End Set
    End Property

    Public Property editable() As Boolean
        Get
            Return editable_v
        End Get
        Set(ByVal value As Boolean)
            editable_v = value
        End Set
    End Property




End Class
