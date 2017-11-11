Public Class CLASSMSG


    Private pkey_v As Integer
    Private gonderenpkey_v As Integer
    Private alanpkey_v As Integer
    Private msgmetin_v As String
    Private msgkonu_v As String
    Private gondermetarih_v As DateTime
    Private okunmusmu_v As String
    Private gonderensilmismi_v As String
    Private alansilmismi_v As String



    Public Sub New()

    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal gonderenpkey As Integer, _
                   ByVal alanpkey As Integer, ByVal msgmetin As String, _
                   ByVal msgkonu As String, ByVal gondermetarih As String, _
                   ByVal okunmusmu As String, ByVal gonderensilmismi As String, _
                   ByVal alansilmismi As String)

        Me.pkey = pkey
        Me.gonderenpkey = gonderenpkey
        Me.alanpkey = alanpkey
        Me.msgmetin = msgmetin
        Me.msgkonu = msgkonu
        Me.gondermetarih = gondermetarih
        Me.okunmusmu = okunmusmu
        Me.gonderensilmismi = gonderensilmismi
        Me.alansilmismi = alansilmismi

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property

    Public Property gonderenpkey() As Integer
        Get
            Return gonderenpkey_v
        End Get
        Set(ByVal value As Integer)
            gonderenpkey_v = value
        End Set
    End Property

    Public Property alanpkey() As Integer
        Get
            Return alanpkey_v
        End Get
        Set(ByVal value As Integer)
            alanpkey_v = value
        End Set
    End Property

    Public Property msgmetin() As String
        Get
            Return msgmetin_v
        End Get
        Set(ByVal value As String)
            msgmetin_v = value
        End Set
    End Property


    Public Property msgkonu() As String
        Get
            Return msgkonu_v
        End Get
        Set(ByVal value As String)
            msgkonu_v = value
        End Set
    End Property

    Public Property gondermetarih() As DateTime
        Get
            Return gondermetarih_v
        End Get
        Set(ByVal value As DateTime)
            gondermetarih_v = value
        End Set
    End Property

    Public Property okunmusmu() As String
        Get
            Return okunmusmu_v
        End Get
        Set(ByVal value As String)
            okunmusmu_v = value
        End Set
    End Property

    Public Property gonderensilmismi() As String
        Get
            Return gonderensilmismi_v
        End Get
        Set(ByVal value As String)
            gonderensilmismi_v = value
        End Set
    End Property

    Public Property alansilmismi() As String
        Get
            Return alansilmismi_v
        End Get
        Set(ByVal value As String)
            alansilmismi_v = value
        End Set
    End Property


End Class

