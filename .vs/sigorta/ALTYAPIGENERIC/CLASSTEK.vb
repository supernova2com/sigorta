Public Class CLASSTEK

    Private ad_v As String


    Public Sub New()

    End Sub
    Public Sub New(ByVal ad As String)

        Me.ad = ad


    End Sub

    Public Property ad() As String
        Get
            Return ad_v
        End Get
        Set(ByVal value As String)
            ad_v = value
        End Set
    End Property


End Class
