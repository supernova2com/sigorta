Public Class CLASSACENTETIP

    Private pkey_v As Integer
    Private acentetipad_v As String



    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal acentetipad As String)

        Me.pkey = pkey
        Me.acentetipad = acentetipad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property acentetipad() As String
        Get
            Return acentetipad_v
        End Get
        Set(ByVal value As String)
            acentetipad_v = value
        End Set
    End Property


End Class
