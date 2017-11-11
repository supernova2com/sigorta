Public Class CLASSHESAP


    Private pkey_v As Integer
    Private firmcode_v As String
    Private faturano_v As String
    Private tip_v As String
    Private tarih_v As DateTime
    Private tutar_v As Decimal
    Private aciklama_v As String
    Private ay_v As Integer
    Private yil_v As Integer
    Private eder_v As Decimal
    Private tur_v As String
    Private oran_v As Decimal


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal firmcode As String, ByVal faturano As String, _
    ByVal tip As String, ByVal tarih As DateTime, ByVal tutar As Decimal, _
    ByVal aciklama As String, ByVal ay As Integer, ByVal yil As Integer, _
    ByVal eder As Decimal, ByVal tur As String, ByVal oran As Decimal)

        Me.pkey = pkey
        Me.firmcode = firmcode
        Me.faturano = faturano
        Me.tip = tip
        Me.tarih = tarih
        Me.tutar = tutar
        Me.aciklama = aciklama
        Me.ay = ay
        Me.yil = yil
        Me.eder = eder
        Me.tur = tur
        Me.oran = oran

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property firmcode() As String
        Get
            Return firmcode_v
        End Get
        Set(ByVal value As String)
            firmcode_v = value
        End Set
    End Property


    Public Property faturano() As String
        Get
            Return faturano_v
        End Get
        Set(ByVal value As String)
            faturano_v = value
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


    Public Property tarih() As Nullable(Of DateTime)
        Get
            Return tarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            tarih_v = value
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


    Public Property aciklama() As String
        Get
            Return aciklama_v
        End Get
        Set(ByVal value As String)
            aciklama_v = value
        End Set
    End Property

    Public Property ay() As Integer
        Get
            Return ay_v
        End Get
        Set(ByVal value As Integer)
            ay_v = value
        End Set
    End Property


    Public Property yil() As Integer
        Get
            Return yil_v
        End Get
        Set(ByVal value As Integer)
            yil_v = value
        End Set
    End Property

    Public Property eder() As Decimal
        Get
            Return eder_v
        End Get
        Set(ByVal value As Decimal)
            eder_v = value
        End Set
    End Property


    Public Property tur() As String
        Get
            Return tur_v
        End Get
        Set(ByVal value As String)
            tur_v = value
        End Set
    End Property


    Public Property oran() As Decimal
        Get
            Return oran_v
        End Get
        Set(ByVal value As Decimal)
            oran_v = value
        End Set
    End Property


End Class
