Public Class CLASSWEBUYE

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private uyetip_v As Integer
    Private adsoyad_v As String
    Private adres_v As String
    Private telefon_v As String
    Private eposta_v As String
    Private kullaniciad_v As String
    Private kullanicisifre_v As String
    Private aktifmi_v As String
    Private uyebaslangictarih_v As DateTime
    Private uyebitistarih_v As DateTime
    Private rolpkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal uyetip As Integer, _
    ByVal adsoyad As String, ByVal adres As String, ByVal telefon As String, _
    ByVal eposta As String, ByVal kullaniciad As String, ByVal kullanicisifre As String, _
    ByVal aktifmi As String, ByVal uyebaslangictarih As DateTime, ByVal uyebitistarih As DateTime, _
    ByVal rolpkey As Integer)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.uyetip = uyetip
        Me.adsoyad = adsoyad
        Me.adres = adres
        Me.telefon = telefon
        Me.eposta = eposta
        Me.kullaniciad = kullaniciad
        Me.kullanicisifre = kullanicisifre
        Me.aktifmi = aktifmi
        Me.uyebaslangictarih = uyebaslangictarih
        Me.uyebitistarih = uyebitistarih
        Me.rolpkey = rolpkey


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
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


    Public Property uyetip() As Integer
        Get
            Return uyetip_v
        End Get
        Set(ByVal value As Integer)
            uyetip_v = value
        End Set
    End Property


    Public Property adsoyad() As String
        Get
            Return adsoyad_v
        End Get
        Set(ByVal value As String)
            adsoyad_v = value
        End Set
    End Property


    Public Property adres() As String
        Get
            Return adres_v
        End Get
        Set(ByVal value As String)
            adres_v = value
        End Set
    End Property


    Public Property telefon() As String
        Get
            Return telefon_v
        End Get
        Set(ByVal value As String)
            telefon_v = value
        End Set
    End Property


    Public Property eposta() As String
        Get
            Return eposta_v
        End Get
        Set(ByVal value As String)
            eposta_v = value
        End Set
    End Property


    Public Property kullaniciad() As String
        Get
            Return kullaniciad_v
        End Get
        Set(ByVal value As String)
            kullaniciad_v = value
        End Set
    End Property


    Public Property kullanicisifre() As String
        Get
            Return kullanicisifre_v
        End Get
        Set(ByVal value As String)
            kullanicisifre_v = value
        End Set
    End Property


    Public Property aktifmi() As String
        Get
            Return aktifmi_v
        End Get
        Set(ByVal value As String)
            aktifmi_v = value
        End Set
    End Property


    Public Property uyebaslangictarih() As Nullable(Of DateTime)
        Get
            Return uyebaslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            uyebaslangictarih_v = value
        End Set
    End Property


    Public Property uyebitistarih() As Nullable(Of DateTime)
        Get
            Return uyebitistarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            uyebitistarih_v = value
        End Set
    End Property


    Public Property rolpkey() As Integer
        Get
            Return rolpkey_v
        End Get
        Set(ByVal value As Integer)
            rolpkey_v = value
        End Set
    End Property


End Class
