Public Class CLASSKEYVALUEPAIR

    Private key_v As String
    Private value_v As String

    Public Sub New()

    End Sub
    Public Sub New(ByVal key As String, ByVal value As String)

        Me.key = key
        Me.value = value

    End Sub


    Public Property key() As String
        Get
            Return key_v
        End Get
        Set(ByVal value As String)
            key_v = value
        End Set
    End Property


    Public Property value() As String
        Get
            Return value_v
        End Get
        Set(ByVal value As String)
            value_v = value
        End Set
    End Property

End Class
