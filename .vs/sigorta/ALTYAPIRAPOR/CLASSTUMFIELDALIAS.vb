Public Class CLASSTUMFIELDALIAS


    Private raporbaslik_v As String
    Private aliaz_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal aliaz As String, ByVal raporbaslik As String)
        Me.aliaz = aliaz
        Me.raporbaslik = raporbaslik
    End Sub

    Public Property aliaz() As String
        Get
            Return aliaz_v
        End Get
        Set(ByVal value As String)
            aliaz_v = value
        End Set
    End Property


    Public Property raporbaslik() As String
        Get
            Return raporbaslik_v
        End Get
        Set(ByVal value As String)
            raporbaslik_v = value
        End Set
    End Property

End Class
