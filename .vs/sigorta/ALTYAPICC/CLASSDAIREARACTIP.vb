Public Class CLASSDAIREARACTIP

    Private pkey_v As Integer
    Private dairearactipad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal dairearactipad As String)


        Me.pkey = pkey
        Me.dairearactipad = dairearactipad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property dairearactipad() As String
        Get
            Return dairearactipad_v
        End Get
        Set(ByVal value As String)
            dairearactipad_v = value
        End Set
    End Property


End Class
