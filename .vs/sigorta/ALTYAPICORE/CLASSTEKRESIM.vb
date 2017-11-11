Public Class CLASSTEKRESIM

    Private pkey_v As Integer
    Private baslik_v As String
    Private dosyaad_v As String
    Private galeripkey_v As Integer
    Private resim_yukseklik_v As Integer
    Private resim_genislik_v As Integer
    Private orjinalboyut_v As String
    Private ekkod_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal baslik As String, ByVal dosyaad As String, _
    ByVal galeripkey As Integer, ByVal resim_yukseklik As Integer, ByVal resim_genislik As Integer, _
    ByVal orjinalboyut As String, ByVal ekkod As String)


        Me.pkey = pkey
        Me.baslik = baslik
        Me.dosyaad = dosyaad
        Me.galeripkey = galeripkey
        Me.resim_yukseklik = resim_yukseklik
        Me.resim_genislik = resim_genislik
        Me.orjinalboyut = orjinalboyut
        Me.ekkod = ekkod


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property baslik() As String
        Get
            Return baslik_v
        End Get
        Set(ByVal value As String)
            baslik_v = value
        End Set
    End Property


    Public Property dosyaad() As String
        Get
            Return dosyaad_v
        End Get
        Set(ByVal value As String)
            dosyaad_v = value
        End Set
    End Property


    Public Property galeripkey() As Integer
        Get
            Return galeripkey_v
        End Get
        Set(ByVal value As Integer)
            galeripkey_v = value
        End Set
    End Property


    Public Property resim_yukseklik() As Integer
        Get
            Return resim_yukseklik_v
        End Get
        Set(ByVal value As Integer)
            resim_yukseklik_v = value
        End Set
    End Property


    Public Property resim_genislik() As Integer
        Get
            Return resim_genislik_v
        End Get
        Set(ByVal value As Integer)
            resim_genislik_v = value
        End Set
    End Property


    Public Property orjinalboyut() As String
        Get
            Return orjinalboyut_v
        End Get
        Set(ByVal value As String)
            orjinalboyut_v = value
        End Set
    End Property

    Public Property ekkod() As String
        Get
            Return ekkod_v
        End Get
        Set(ByVal value As String)
            ekkod_v = value
        End Set
    End Property


End Class
