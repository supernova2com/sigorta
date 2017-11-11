Public Class CLASSILCE


    Private pkey_v As Integer
    Private ilcead_v As String
    Private ilcekod_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ilcead As String, ByVal ilcekod As String)

        Me.pkey = pkey
        Me.ilcead = ilcead
        Me.ilcekod = ilcekod

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ilcead() As String
        Get
            Return ilcead_v
        End Get
        Set(ByVal value As String)
            ilcead_v = value
        End Set
    End Property

    Public Property ilcekod() As String
        Get
            Return ilcekod_v
        End Get
        Set(ByVal value As String)
            ilcekod_v = value
        End Set
    End Property



End Class
