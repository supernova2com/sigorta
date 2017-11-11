Public Class CLASSVTABLO

    Private pkey_v As Integer
    Private tabload_v As String
    Private aciklama_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tabload As String, ByVal aciklama As String)


        Me.pkey = pkey
        Me.tabload = tabload
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


    Public Property tabload() As String
        Get
            Return tabload_v
        End Get
        Set(ByVal value As String)
            tabload_v = value
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
