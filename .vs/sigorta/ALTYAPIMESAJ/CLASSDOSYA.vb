Public Class CLASSDOSYA


    Private pkey_v As Integer
    Private gonderenpkey_v As Integer
    Private alanpkey_v As Integer
    Private msgkonu_v As String
    Private gondermetarih_v As DateTime
    Private okunmusmu_v As String
    Private gonderensilmismi_v As String
    Private alansilmismi_v As String
    Private contype_v As String
    Private filesize_v As Integer
    Private fileg_v As Byte()
    Private filename_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal gonderenpkey As Integer, ByVal alanpkey As Integer, _
    ByVal msgkonu As String, ByVal gondermetarih As DateTime, ByVal okunmusmu As String, _
    ByVal gonderensilmismi As String, ByVal alansilmismi As String, ByVal contype As String, _
    ByVal filesize As Integer, ByVal fileg As Byte(), ByVal filename As String)


        Me.pkey = pkey
        Me.gonderenpkey = gonderenpkey
        Me.alanpkey = alanpkey
        Me.msgkonu = msgkonu
        Me.gondermetarih = gondermetarih
        Me.okunmusmu = okunmusmu
        Me.gonderensilmismi = gonderensilmismi
        Me.alansilmismi = alansilmismi
        Me.contype = contype
        Me.filesize = filesize
        Me.fileg = fileg
        Me.filename = filename

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


    Public Property contype() As String
        Get
            Return contype_v
        End Get
        Set(ByVal value As String)
            contype_v = value
        End Set
    End Property


    Public Property filesize() As Integer
        Get
            Return filesize_v
        End Get
        Set(ByVal value As Integer)
            filesize_v = value
        End Set
    End Property


    Public Property fileg() As Byte()
        Get
            Return fileg_v
        End Get
        Set(ByVal value As Byte())
            fileg_v = value
        End Set
    End Property

    Public Property filename() As String
        Get
            Return filename_v
        End Get
        Set(ByVal value As String)
            filename_v = value
        End Set
    End Property


End Class
