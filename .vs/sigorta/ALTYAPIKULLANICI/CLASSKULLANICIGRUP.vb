Public Class CLASSKULLANICIGRUP

    Private pkey_v As Integer
    Private grupad_v As String
    Private grupsirkettarafindasecilebilsinmi_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal grupad As String, ByVal grupsirkettarafindasecilebilsinmi As String)

        Me.pkey = pkey
        Me.grupad = grupad
        Me.grupsirkettarafindasecilebilsinmi = grupsirkettarafindasecilebilsinmi

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property grupad() As String
        Get
            Return grupad_v
        End Get
        Set(ByVal value As String)
            grupad_v = value
        End Set
    End Property


    Public Property grupsirkettarafindasecilebilsinmi() As String
        Get
            Return grupsirkettarafindasecilebilsinmi_v
        End Get
        Set(ByVal value As String)
            grupsirkettarafindasecilebilsinmi_v = value
        End Set
    End Property

End Class
