Public Class CLASSXMLHATA
    Inherits CLASSGENERIC

    Private kod_v As Integer
    Private mesaj_v As String

    Public Sub New()

    End Sub


    Public Sub New(ByVal kod As Integer, ByVal mesaj As String, _
                   ByVal hatastr As String)

        Me.kod = kod
        Me.mesaj = mesaj

    End Sub

    Public Property kod() As Integer
        Get
            Return kod_v
        End Get
        Set(ByVal value As Integer)
            kod_v = value
        End Set
    End Property


    Public Property mesaj() As String
        Get
            Return mesaj_v
        End Get
        Set(ByVal value As String)
            mesaj_v = value
        End Set
    End Property

   
End Class

