Public Class CLASSINSUREDTITLE

    Private pkey_v As Integer
    Private kod_v As Integer
    Private aciklama_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal kod As Integer, ByVal aciklama As String)


        Me.pkey = pkey
        Me.kod = kod
        Me.aciklama = aciklama

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property kod() As Integer
        Get
            Return kod_v
        End Get
        Set(ByVal value As Integer)
            kod_v = value
        End Set
    End Property


    Public Property aciklama() As String
        Get
            Return aciklama_v
        End Get
        Set(ByVal value As String)
            aciklama_v = value
        End Set
    End Property





End Class
