Public Class CLASSPERTARAC

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private araccinspkey_v As Integer
    Private aracmarkapkey_v As Integer
    Private aracmodelpkey_v As Integer
    Private plaka_v As String
    Private sasino_v As String
    Private motorno_v As String
    Private koltuksayi_v As Integer
    Private motorgucu_v As Integer
    Private imalyil_v As Integer
    Private kazatarih_v As DateTime
    Private odenenhasar_v As Decimal
    Private piyasadeger_v As Decimal
    Private ilanbaslangictarih_v As DateTime
    Private ilanbitistarih_v As DateTime
    Private currencycodepkey_v As Integer
    Private kayittarih_v As DateTime
    Private guncellemetarih_v As DateTime
    Private kullanicipkey_v As Integer
    Private hemensatisfiyat_v As Decimal


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal araccinspkey As Integer, _
    ByVal aracmarkapkey As Integer, ByVal aracmodelpkey As Integer, ByVal plaka As String, _
    ByVal sasino As String, ByVal motorno As String, ByVal koltuksayi As Integer, _
    ByVal motorgucu As Integer, ByVal imalyil As Integer, ByVal kazatarih As DateTime, _
    ByVal odenenhasar As Decimal, ByVal piyasadeger As Decimal, ByVal ilanbaslangictarih As DateTime, _
    ByVal ilanbitistarih As DateTime, ByVal currencycodepkey As Integer, ByVal kayittarih As DateTime, _
    ByVal guncellemetarih As DateTime, ByVal kullanicipkey As Integer, ByVal hemensatisfiyat As Decimal)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.araccinspkey = araccinspkey
        Me.aracmarkapkey = aracmarkapkey
        Me.aracmodelpkey = aracmodelpkey
        Me.plaka = plaka
        Me.sasino = sasino
        Me.motorno = motorno
        Me.koltuksayi = koltuksayi
        Me.motorgucu = motorgucu
        Me.imalyil = imalyil
        Me.kazatarih = kazatarih
        Me.odenenhasar = odenenhasar
        Me.piyasadeger = piyasadeger
        Me.ilanbaslangictarih = ilanbaslangictarih
        Me.ilanbitistarih = ilanbitistarih
        Me.currencycodepkey = currencycodepkey
        Me.kayittarih = kayittarih
        Me.guncellemetarih = guncellemetarih
        Me.kullanicipkey = kullanicipkey
        Me.hemensatisfiyat = hemensatisfiyat

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


    Public Property araccinspkey() As Integer
        Get
            Return araccinspkey_v
        End Get
        Set(ByVal value As Integer)
            araccinspkey_v = value
        End Set
    End Property


    Public Property aracmarkapkey() As Integer
        Get
            Return aracmarkapkey_v
        End Get
        Set(ByVal value As Integer)
            aracmarkapkey_v = value
        End Set
    End Property


    Public Property aracmodelpkey() As Integer
        Get
            Return aracmodelpkey_v
        End Get
        Set(ByVal value As Integer)
            aracmodelpkey_v = value
        End Set
    End Property


    Public Property plaka() As String
        Get
            Return plaka_v
        End Get
        Set(ByVal value As String)
            plaka_v = value
        End Set
    End Property


    Public Property sasino() As String
        Get
            Return sasino_v
        End Get
        Set(ByVal value As String)
            sasino_v = value
        End Set
    End Property


    Public Property motorno() As String
        Get
            Return motorno_v
        End Get
        Set(ByVal value As String)
            motorno_v = value
        End Set
    End Property


    Public Property koltuksayi() As Integer
        Get
            Return koltuksayi_v
        End Get
        Set(ByVal value As Integer)
            koltuksayi_v = value
        End Set
    End Property


    Public Property motorgucu() As Integer
        Get
            Return motorgucu_v
        End Get
        Set(ByVal value As Integer)
            motorgucu_v = value
        End Set
    End Property


    Public Property imalyil() As Integer
        Get
            Return imalyil_v
        End Get
        Set(ByVal value As Integer)
            imalyil_v = value
        End Set
    End Property


    Public Property kazatarih() As Nullable(Of DateTime)
        Get
            Return kazatarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kazatarih_v = value
        End Set
    End Property


    Public Property odenenhasar() As Decimal
        Get
            Return odenenhasar_v
        End Get
        Set(ByVal value As Decimal)
            odenenhasar_v = value
        End Set
    End Property


    Public Property piyasadeger() As Decimal
        Get
            Return piyasadeger_v
        End Get
        Set(ByVal value As Decimal)
            piyasadeger_v = value
        End Set
    End Property


    Public Property ilanbaslangictarih() As Nullable(Of DateTime)
        Get
            Return ilanbaslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            ilanbaslangictarih_v = value
        End Set
    End Property


    Public Property ilanbitistarih() As Nullable(Of DateTime)
        Get
            Return ilanbitistarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            ilanbitistarih_v = value
        End Set
    End Property


    Public Property currencycodepkey() As Integer
        Get
            Return currencycodepkey_v
        End Get
        Set(ByVal value As Integer)
            currencycodepkey_v = value
        End Set
    End Property


    Public Property kayittarih() As Nullable(Of DateTime)
        Get
            Return kayittarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kayittarih_v = value
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


    Public Property kullanicipkey() As Integer
        Get
            Return kullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicipkey_v = value
        End Set
    End Property


    Public Property hemensatisfiyat() As Decimal
        Get
            Return hemensatisfiyat_v
        End Get
        Set(ByVal value As Decimal)
            hemensatisfiyat_v = value
        End Set
    End Property



End Class
