Public Class CLASSTEMA

    Private pkey_v As Integer
    Private temaad_v As String
    Private kimin_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal temaad As String, ByVal kimin As String)

        Me.pkey = pkey
        Me.temaad = temaad
        Me.kimin = kimin

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property temaad() As String
        Get
            Return temaad_v
        End Get
        Set(ByVal value As String)
            temaad_v = value
        End Set
    End Property


    Public Property kimin() As String
        Get
            Return kimin_v
        End Get
        Set(ByVal value As String)
            kimin_v = value
        End Set
    End Property


End Class
