Public Class CLASSPOLICETIP

    Private pkey_v As Integer
    Private kod_v As Integer
    Private policetipad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal kod As Integer, ByVal policetipad As String)


        Me.pkey = pkey
        Me.kod = kod
        Me.policetipad = policetipad

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


    Public Property policetipad() As String
        Get
            Return policetipad_v
        End Get
        Set(ByVal value As String)
            policetipad_v = value
        End Set
    End Property


End Class
