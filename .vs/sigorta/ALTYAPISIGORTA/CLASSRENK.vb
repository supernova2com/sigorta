Public Class CLASSRENK

    Private pkey_v As Integer
    Private renkkod_v As Integer
    Private renkad_v As String
    Private renkhex_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal renkkod As Integer, ByVal renkad As String, _
    ByVal renkhex As String)


        Me.pkey = pkey
        Me.renkkod = renkkod
        Me.renkad = renkad
        Me.renkhex = renkhex

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property renkkod() As Integer
        Get
            Return renkkod_v
        End Get
        Set(ByVal value As Integer)
            renkkod_v = value
        End Set
    End Property


    Public Property renkad() As String
        Get
            Return renkad_v
        End Get
        Set(ByVal value As String)
            renkad_v = value
        End Set
    End Property


    Public Property renkhex() As String
        Get
            Return renkhex_v
        End Get
        Set(ByVal value As String)
            renkhex_v = value
        End Set
    End Property

End Class
