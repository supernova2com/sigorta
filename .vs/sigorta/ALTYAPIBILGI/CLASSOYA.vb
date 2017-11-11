Public Class CLASSOYA

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private acentepkey_v As Integer
    Private borcmiktar_v As Decimal
    Private currencycodepkey_v As Integer
    Private sure_v As String
    Private acentedurumpkey_v As Integer
    Private kayittarih_v As DateTime
    Private guncellemetarih_v As DateTime
    Private kullanicipkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal acentepkey As Integer, _
    ByVal borcmiktar As Decimal, ByVal currencycodepkey As Integer, ByVal sure As String, _
    ByVal acentedurumpkey As Integer, ByVal kayittarih As DateTime, ByVal guncellemetarih As DateTime, _
    ByVal kullanicipkey As Integer)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.acentepkey = acentepkey
        Me.borcmiktar = borcmiktar
        Me.currencycodepkey = currencycodepkey
        Me.sure = sure
        Me.acentedurumpkey = acentedurumpkey
        Me.kayittarih = kayittarih
        Me.guncellemetarih = guncellemetarih
        Me.kullanicipkey = kullanicipkey

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


    Public Property borcmiktar() As Decimal
        Get
            Return borcmiktar_v
        End Get
        Set(ByVal value As Decimal)
            borcmiktar_v = value
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


    Public Property sure() As String
        Get
            Return sure_v
        End Get
        Set(ByVal value As String)
            sure_v = value
        End Set
    End Property


    Public Property acentedurumpkey() As Integer
        Get
            Return acentedurumpkey_v
        End Get
        Set(ByVal value As Integer)
            acentedurumpkey_v = value
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

End Class
