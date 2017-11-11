Public Class CLASSDIGERPARAMETRELER

    Private parametreler_v As New List(Of String)

    Public Sub New()

    End Sub

    Public Sub New(ByVal parametreler As List(Of String))
        Me.parametreler_v = parametreler
    End Sub

    Public Property parametreler() As List(Of String)
        Get
            Return parametreler_v
        End Get
        Set(ByVal value As List(Of String))
            parametreler_v = value
        End Set
    End Property

End Class
