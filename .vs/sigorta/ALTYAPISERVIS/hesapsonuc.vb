Public Class hesapsonuc


    Private sonuckodu_v As Integer
    Private hatakodu_v As Integer
    Private hatamsg_v As String
    Private log_v As String


    Public Sub New()

    End Sub

    Public Sub New(ByVal sonuckodu As Integer, ByVal hatakodu As Integer, _
    ByVal hatamsg As String, ByVal log As String)

        Me.sonuckodu = sonuckodu
        Me.hatakodu = hatakodu
        Me.hatamsg = hatamsg
        Me.log = log

    End Sub



    Public Property sonuckodu() As Integer
        Get
            Return sonuckodu_v
        End Get
        Set(ByVal value As Integer)
            sonuckodu_v = value
        End Set
    End Property


    Public Property hatakodu() As Integer
        Get
            Return hatakodu_v
        End Get
        Set(ByVal value As Integer)
            hatakodu_v = value
        End Set
    End Property


    Public Property hatamsg() As String
        Get
            Return hatamsg_v
        End Get
        Set(ByVal value As String)
            hatamsg_v = value
        End Set
    End Property

    Public Property log() As String
        Get
            Return log_v
        End Get
        Set(ByVal value As String)
            log_v = value
        End Set
    End Property


End Class



