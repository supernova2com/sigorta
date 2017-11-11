Public Class CLASSGRAFIKBILGI


    Private seriad_v As String
    Private sayi_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal seriad As String, ByVal sayi As Integer)

        Me.seriad = seriad
        Me.sayi = sayi

    End Sub

    Public Property sayi() As Integer
        Get
            Return sayi_v
        End Get
        Set(ByVal value As Integer)
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
