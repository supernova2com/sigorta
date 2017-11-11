Public Class CLASSGRAFIKBILGIDECIMAL


    Private seriad_v As String
    Private sayi_v As Decimal


    Public Sub New()
    End Sub

    Public Sub New(ByVal seriad As String, ByVal sayi As Decimal)

        Me.seriad = seriad
        Me.sayi = sayi

    End Sub

    Public Property sayi() As Decimal
        Get
            Return sayi_v
        End Get
        Set(ByVal value As Decimal)
            sayi_v = value
        End Set
    End Property


    Public Property seriad() As String
        Get
            Return seriad_v
        End Get
        Set(ByVal value As String)
            seriad_v = value
        End Set
    End Property



End Class
