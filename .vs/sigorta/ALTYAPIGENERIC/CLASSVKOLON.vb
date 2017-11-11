Public Class CLASSVKOLON

    Private pkey_v As Integer
    Private tabload_v As String
    Private kolonad_v As String
    Private kolonaciklama_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tabload As String, ByVal kolonad As String, _
    ByVal kolonaciklama As String)


        Me.pkey = pkey
        Me.tabload = tabload
        Me.kolonad = kolonad
        Me.kolonaciklama = kolonaciklama

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


    Public Property kolonad() As String
        Get
            Return kolonad_v
        End Get
        Set(ByVal value As String)
            kolonad_v = value
        End Set
    End Property


    Public Property kolonaciklama() As String
        Get
            Return kolonaciklama_v
        End Get
        Set(ByVal value As String)
            kolonaciklama_v = value
        End Set
    End Property


End Class
