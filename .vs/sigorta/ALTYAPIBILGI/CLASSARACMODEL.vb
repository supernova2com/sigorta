Public Class CLASSARACMODEL

    Private pkey_v As Integer
    Private araccinspkey_v As Integer
    Private aracmarkapkey_v As Integer
    Private modelad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal araccinspkey As Integer, ByVal aracmarkapkey As Integer, _
    ByVal modelad As String)


        Me.pkey = pkey
        Me.araccinspkey = araccinspkey
        Me.aracmarkapkey = aracmarkapkey
        Me.modelad = modelad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property araccinspkey() As Integer
        Get
            Return araccinspkey_v
        End Get
        Set(ByVal value As Integer)
            araccinspkey_v = value
        End Set
    End Property


    Public Property aracmarkapkey() As Integer
        Get
            Return aracmarkapkey_v
        End Get
        Set(ByVal value As Integer)
            aracmarkapkey_v = value
        End Set
    End Property


    Public Property modelad() As String
        Get
            Return modelad_v
        End Get
        Set(ByVal value As String)
            modelad_v = value
        End Set
    End Property

End Class
