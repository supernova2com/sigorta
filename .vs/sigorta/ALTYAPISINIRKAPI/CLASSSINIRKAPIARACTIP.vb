Public Class CLASSSINIRKAPIARACTIP

    Private pkey_v As Integer
    Private sinirkapiaractipad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sinirkapiaractipad As String)


        Me.pkey = pkey
        Me.sinirkapiaractipad = sinirkapiaractipad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sinirkapiaractipad() As String
        Get
            Return sinirkapiaractipad_v
        End Get
        Set(ByVal value As String)
            sinirkapiaractipad_v = value
        End Set
    End Property



End Class
