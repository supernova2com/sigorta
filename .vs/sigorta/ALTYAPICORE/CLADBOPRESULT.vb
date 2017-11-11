Public Class CLADBOPRESULT

    Private etkilenen_v As Integer
    Private durum_v As String
    Private hatastr_v As String

    Public Sub New()

    End Sub


    Public Sub New(ByVal etkilenen As Integer, ByVal durum As String, _
                   ByVal hatastr As String)

        Me.etkilenen = etkilenen
        Me.durum = durum
        Me.hatastr = hatastr

    End Sub

    Public Property etkilenen() As Integer
        Get
            Return etkilenen_v
        End Get
        Set(ByVal value As Integer)
            etkilenen_v = value
        End Set
    End Property


    Public Property durum() As String
        Get
            Return durum_v
        End Get
        Set(ByVal value As String)
            durum_v = value
        End Set
    End Property

    Public Property hatastr() As String
        Get
            Return hatastr_v
        End Get
        Set(ByVal value As String)
            hatastr_v = value
        End Set
    End Property

End Class
