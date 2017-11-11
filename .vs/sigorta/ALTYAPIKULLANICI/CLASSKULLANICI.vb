Public Class CLASSKULLANICI

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private acentepkey_v As Integer
    Private kullanicigruppkey_v As Integer
    Private personelpkey_v As Integer
    Private rolpkey_v As Integer
    Private resimpkey_v As Integer
    Private aktifmi_v As String
    Private adsoyad_v As String
    Private kullaniciad_v As String
    Private kullanicisifre_v As String
    Private eposta_v As String
    Private emailgonderilsinmi_v As String
    Private ekleyenkullanicipkey_v As Integer
    Private guncelleyenkullanicipkey_v As Integer
    Private eklemetarih_v As DateTime
    Private guncellemetarih_v As DateTime


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal acentepkey As Integer, _
    ByVal kullanicigruppkey As Integer, ByVal personelpkey As Integer, ByVal rolpkey As Integer, _
    ByVal resimpkey As Integer, ByVal aktifmi As String, ByVal adsoyad As String, _
    ByVal kullaniciad As String, ByVal kullanicisifre As String, ByVal eposta As String, _
    ByVal emailgonderilsinmi As String, ByVal ekleyenkullanicipkey As Integer, _
    ByVal guncelleyenkullanicipkey As Integer, ByVal eklemetarih As DateTime, ByVal guncellemetarih As DateTime)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.acentepkey = acentepkey
        Me.kullanicigruppkey = kullanicigruppkey
        Me.personelpkey = personelpkey
        Me.rolpkey = rolpkey
        Me.resimpkey = resimpkey
        Me.aktifmi = aktifmi
        Me.adsoyad = adsoyad
        Me.kullaniciad = kullaniciad
        Me.kullanicisifre = kullanicisifre
        Me.eposta = eposta
        Me.emailgonderilsinmi = emailgonderilsinmi
        Me.ekleyenkullanicipkey = ekleyenkullanicipkey
        Me.guncelleyenkullanicipkey = guncelleyenkullanicipkey
        Me.eklemetarih = eklemetarih
        Me.guncellemetarih = guncellemetarih

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


    Public Property acentepkey() As Integer
        Get
            Return acentepkey_v
        End Get
        Set(ByVal value As Integer)
            acentepkey_v = value
        End Set
    End Property


    Public Property kullanicigruppkey() As Integer
        Get
            Return kullanicigruppkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicigruppkey_v = value
        End Set
    End Property


    Public Property personelpkey() As Integer
        Get
            Return personelpkey_v
        End Get
        Set(ByVal value As Integer)
            personelpkey_v = value
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


    Public Property resimpkey() As Integer
        Get
            Return resimpkey_v
        End Get
        Set(ByVal value As Integer)
            resimpkey_v = value
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


    Public Property adsoyad() As String
        Get
            Return adsoyad_v
        End Get
        Set(ByVal value As String)
            adsoyad_v = value
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


    Public Property eposta() As String
        Get
            Return eposta_v
        End Get
        Set(ByVal value As String)
            eposta_v = value
        End Set
    End Property


    Public Property emailgonderilsinmi() As String
        Get
            Return emailgonderilsinmi_v
        End Get
        Set(ByVal value As String)
            emailgonderilsinmi_v = value
        End Set
    End Property


    Public Property ekleyenkullanicipkey() As Integer
        Get
            Return ekleyenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            ekleyenkullanicipkey_v = value
        End Set
    End Property


    Public Property guncelleyenkullanicipkey() As Integer
        Get
            Return guncelleyenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            guncelleyenkullanicipkey_v = value
        End Set
    End Property


    Public Property eklemetarih() As Nullable(Of DateTime)
        Get
            Return eklemetarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            eklemetarih_v = value
        End Set
    End Property


    Public Property guncellemetarih() As Nullable(Of DateTime)
        Get
            Return guncellemetarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            guncellemetarih_v = value
        End Set
    End Property


End Class
