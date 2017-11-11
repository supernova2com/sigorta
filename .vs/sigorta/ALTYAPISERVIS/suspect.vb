Public Class suspect


    Private suphelimi_v As String
    Private suphelikod_v As Integer
    Private suphelimesaj_v As String


    Public Sub New()
    End Sub


    Public Sub New(ByVal suphelimi As String, _
    ByVal suphelikod As Integer, ByVal suphelimesaj As String)

        Me.suphelimi = suphelimi
        Me.suphelikod = suphelikod
        Me.suphelimesaj = suphelimesaj

    End Sub

    Public Property suphelimi() As String
        Get
            Return suphelimi_v
        End Get
        Set(ByVal value As String)
            suphelimi_v = value
        End Set
    End Property


    Public Property suphelikod() As Integer
        Get
            Return suphelikod_v
        End Get
        Set(ByVal value As Integer)
            suphelikod_v = value
        End Set
    End Property


    Public Property suphelimesaj() As String
        Get
            Return suphelimesaj_v
        End Get
        Set(ByVal value As String)
            suphelimesaj_v = value
        End Set
    End Property

End Class
