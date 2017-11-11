Public Class CLASSVERITABANI

    Private ilgiliad_v As String
 

    Public Sub New()

    End Sub

    Public Sub New(ByVal ilgiliad As String)
        Me.ilgiliad = ilgiliad
    End Sub

    Public Property ilgiliad() As String
        Get
            Return ilgiliad_v
        End Get
        Set(ByVal value As String)
            ilgiliad_v = value
        End Set
    End Property
End Class
