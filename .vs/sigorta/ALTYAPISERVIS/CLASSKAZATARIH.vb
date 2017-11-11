Public Class CLASSKAZATARIH


    Private kazatarih_v As Date


    Public Sub New()
    End Sub

    Public Sub New(ByVal kazatarih As Date)

        Me.kazatarih = kazatarih

    End Sub

    Public Property kazatarih() As Date
        Get
            Return kazatarih_v
        End Get
        Set(ByVal value As Date)
            kazatarih_v = value
        End Set
    End Property


End Class
