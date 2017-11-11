Public Class CLASSPLAKA

    Private PlateNumber_v As String
    Private sirketkod_v As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal PlateNumber As String, ByVal sirketkod As String)

        Me.PlateNumber = PlateNumber
        Me.sirketkod = sirketkod

    End Sub


    Public Property PlateNumber() As String
        Get
            Return PlateNumber_v
        End Get
        Set(ByVal value As String)
            PlateNumber_v = value
        End Set
    End Property

    Public Property sirketkod() As String
        Get
            Return sirketkod_v
        End Get
        Set(ByVal value As String)
            sirketkod_v = value
        End Set
    End Property


End Class
