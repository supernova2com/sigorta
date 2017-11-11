Public Class CLASSARACTARIFE

    Private pkey_v As Integer
    Private tarifekod_v As String
    Private tarifead_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tarifekod As String, ByVal tarifead As String)


        Me.pkey = pkey
        Me.tarifekod = tarifekod
        Me.tarifead = tarifead

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property tarifekod() As String
        Get
            Return tarifekod_v
        End Get
        Set(ByVal value As String)
            tarifekod_v = value
        End Set
    End Property


    Public Property tarifead() As String
        Get
            Return tarifead_v
        End Get
        Set(ByVal value As String)
            tarifead_v = value
        End Set
    End Property



End Class
