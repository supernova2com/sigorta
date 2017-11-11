Public Class CLASSARACMARKA

    Private pkey_v As Integer
    Private araccinspkey_v As Integer
    Private markaad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal araccinspkey As Integer, ByVal markaad As String)

        Me.pkey = pkey
        Me.araccinspkey = araccinspkey
        Me.markaad = markaad

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


    Public Property markaad() As String
        Get
            Return markaad_v
        End Get
        Set(ByVal value As String)
            markaad_v = value
        End Set
    End Property

End Class
