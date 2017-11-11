Public Class CLASSTUZUKARACTIP

    Private pkey_v As Integer
    Private tuzukaractipad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tuzukaractipad As String)


        Me.pkey = pkey
        Me.tuzukaractipad = tuzukaractipad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property tuzukaractipad() As String
        Get
            Return tuzukaractipad_v
        End Get
        Set(ByVal value As String)
            tuzukaractipad_v = value
        End Set
    End Property

End Class
