Public Class CLASSARACKAYITDAIRE

    Private PlakaNo_v As String
    Private KatKod_v As Integer
    Private Marka_v As String
    Private Tip_v As String
    Private Model_v As String
    Private MotorGuc_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal PlakaNo As String, ByVal KatKod As Integer, ByVal Marka As String, _
    ByVal Tip As String, ByVal Model As String, ByVal MotorGuc As Integer)


        Me.PlakaNo = PlakaNo
        Me.KatKod = KatKod
        Me.Marka = Marka
        Me.Tip = Tip
        Me.Model = Model
        Me.MotorGuc = MotorGuc

    End Sub

    Public Property PlakaNo() As String
        Get
            Return PlakaNo_v
        End Get
        Set(ByVal value As String)
            PlakaNo_v = value
        End Set
    End Property


    Public Property KatKod() As Integer
        Get
            Return KatKod_v
        End Get
        Set(ByVal value As Integer)
            KatKod_v = value
        End Set
    End Property


    Public Property Marka() As String
        Get
            Return Marka_v
        End Get
        Set(ByVal value As String)
            Marka_v = value
        End Set
    End Property


    Public Property Tip() As String
        Get
            Return Tip_v
        End Get
        Set(ByVal value As String)
            Tip_v = value
        End Set
    End Property


    Public Property Model() As String
        Get
            Return Model_v
        End Get
        Set(ByVal value As String)
            Model_v = value
        End Set
    End Property


    Public Property MotorGuc() As Integer
        Get
            Return MotorGuc_v
        End Get
        Set(ByVal value As Integer)
            MotorGuc_v = value
        End Set
    End Property



End Class
