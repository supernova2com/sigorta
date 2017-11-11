Public Class CLASSTEKLIF

    Private pkey_v As Integer
    Private uyepkey_v As Integer
    Private pertaracpkey_v As Integer
    Private tutar_v As Decimal
    Private tutarcurrencypkey_v As Integer
    Private tekliftarih_v As DateTime
    Private okunmusmu_v As String
    Private sirketpkey_v As Integer
    Private tip_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal uyepkey As Integer, ByVal pertaracpkey As Integer, _
    ByVal tutar As Decimal, ByVal tutarcurrencypkey As Integer, ByVal tekliftarih As DateTime, _
    ByVal okunmusmu As String, ByVal sirketpkey As Integer, ByVal tip As String)

        Me.pkey = pkey
        Me.uyepkey = uyepkey
        Me.pertaracpkey = pertaracpkey
        Me.tutar = tutar
        Me.tutarcurrencypkey = tutarcurrencypkey
        Me.tekliftarih = tekliftarih
        Me.okunmusmu = okunmusmu
        Me.sirketpkey = sirketpkey
        Me.tip = tip

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property uyepkey() As Integer
        Get
            Return uyepkey_v
        End Get
        Set(ByVal value As Integer)
            uyepkey_v = value
        End Set
    End Property


    Public Property pertaracpkey() As Integer
        Get
            Return pertaracpkey_v
        End Get
        Set(ByVal value As Integer)
            pertaracpkey_v = value
        End Set
    End Property


    Public Property tutar() As Decimal
        Get
            Return tutar_v
        End Get
        Set(ByVal value As Decimal)
            tutar_v = value
        End Set
    End Property


    Public Property tutarcurrencypkey() As Integer
        Get
            Return tutarcurrencypkey_v
        End Get
        Set(ByVal value As Integer)
            tutarcurrencypkey_v = value
        End Set
    End Property


    Public Property tekliftarih() As Nullable(Of DateTime)
        Get
            Return tekliftarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            tekliftarih_v = value
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

    Public Property sirketpkey() As Integer
        Get
            Return sirketpkey_v
        End Get
        Set(ByVal value As Integer)
            sirketpkey_v = value
        End Set
    End Property


    Public Property tip() As String
        Get
            Return tip_v
        End Get
        Set(ByVal value As String)
            tip_v = value
        End Set
    End Property


End Class
