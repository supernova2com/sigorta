Public Class CLASSARACCINS

    Private pkey_v As Integer
    Private cinsad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal cinsad As String)


        Me.pkey = pkey
        Me.cinsad = cinsad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property cinsad() As String
        Get
            Return cinsad_v
        End Get
        Set(ByVal value As String)
            cinsad_v = value
        End Set
    End Property

End Class
