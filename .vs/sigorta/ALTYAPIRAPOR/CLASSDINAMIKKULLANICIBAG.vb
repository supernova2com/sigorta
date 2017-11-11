Public Class CLASSDINAMIKKULLANICIBAG

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private kullanicipkey_v As Integer
    Private otogonder_v As String
    Private zamanlamapkey_v As Integer
    Private epostagitsinmi_v As String
    Private entegredosyagitsinmi_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal kullanicipkey As Integer, _
    ByVal otogonder As String, ByVal zamanlamapkey As Integer, ByVal epostagitsinmi As String, _
    ByVal entegredosyagitsinmi As String)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.kullanicipkey = kullanicipkey
        Me.otogonder = otogonder
        Me.zamanlamapkey = zamanlamapkey
        Me.epostagitsinmi = epostagitsinmi
        Me.entegredosyagitsinmi = entegredosyagitsinmi

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property raporpkey() As Integer
        Get
            Return raporpkey_v
        End Get
        Set(ByVal value As Integer)
            raporpkey_v = value
        End Set
    End Property


    Public Property kullanicipkey() As Integer
        Get
            Return kullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicipkey_v = value
        End Set
    End Property


    Public Property otogonder() As String
        Get
            Return otogonder_v
        End Get
        Set(ByVal value As String)
            otogonder_v = value
        End Set
    End Property


    Public Property zamanlamapkey() As Integer
        Get
            Return zamanlamapkey_v
        End Get
        Set(ByVal value As Integer)
            zamanlamapkey_v = value
        End Set
    End Property


    Public Property epostagitsinmi() As String
        Get
            Return epostagitsinmi_v
        End Get
        Set(ByVal value As String)
            epostagitsinmi_v = value
        End Set
    End Property


    Public Property entegredosyagitsinmi() As String
        Get
            Return entegredosyagitsinmi_v
        End Get
        Set(ByVal value As String)
            entegredosyagitsinmi_v = value
        End Set
    End Property


End Class
