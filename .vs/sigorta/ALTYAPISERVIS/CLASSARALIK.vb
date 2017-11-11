Public Class CLASSARALIK

    Private baslangic_v As Date
    Private bitis_v As Date


    Public Sub New()
    End Sub

    Public Sub New(ByVal baslangic As Date, ByVal bitis As Date)

        Me.baslangic = baslangic
        Me.bitis = bitis

    End Sub

    Public Property baslangic() As Date
        Get
            Return baslangic_v
        End Get
        Set(ByVal value As Date)
            baslangic_v = value
        End Set
    End Property


    Public Property bitis() As Date
        Get
            Return bitis_v
        End Get
        Set(ByVal value As Date)
            bitis_v = value
        End Set
    End Property


End Class
