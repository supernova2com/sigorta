Public Class CLATARIH


    Private baslangic_v As DateTime
    Private bitis_v As DateTime


    Public Sub New()

    End Sub

    Public Sub New(ByVal baslangic As DateTime, ByVal bitis As DateTime)
        Me.baslangic = baslangic
        Me.bitis = bitis 
    End Sub


    Public Property baslangic() As DateTime
        Get
            Return baslangic_v
        End Get
        Set(ByVal value As DateTime)
            baslangic_v = value
        End Set
    End Property

    Public Property bitis() As DateTime
        Get
            Return bitis_v
        End Get
        Set(ByVal value As DateTime)
            bitis_v = value
        End Set
    End Property

End Class
