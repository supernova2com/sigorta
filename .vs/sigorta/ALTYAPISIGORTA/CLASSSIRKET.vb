Public Class CLASSSIRKET

    Private pkey_v As Integer
    Private sirketkod_v As String
    Private sirketad_v As String
    Private yetkilikisiadsoyad_v As String
    Private adres_v As String
    Private ofistelefon_v As String
    Private faks_v As String
    Private eposta_v As String
    Private aktifmi_v As String
    Private resimpkey_v As Integer
    Private testerisim_v As String
    Private topluyukleme_v As String
    Private wskullaniciad_v As String
    Private wssifre_v As String
    Private ipdikkat_v As String
    Private tip_v As String
    Private GetCarAddressInfo_yetki_v As String
    Private GetDamageInformation_yetki_v As String
    Private GetInfoInsuredPeople_yetki_v As String
    Private LoadDamageInformation_yetki_v As String
    Private LoadPolicyInformation_yetki_v As String
    Private maksservistalepdakika_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketkod As String, ByVal sirketad As String, _
    ByVal yetkilikisiadsoyad As String, ByVal adres As String, ByVal ofistelefon As String, _
    ByVal faks As String, ByVal eposta As String, ByVal aktifmi As String, _
    ByVal resimpkey As Integer, ByVal testerisim As String, ByVal topluyukleme As String, _
    ByVal wskullaniciad As String, ByVal wssifre As String, ByVal ipdikkat As String, _
    ByVal tip As String, ByVal GetCarAddressInfo_yetki As String, ByVal GetDamageInformation_yetki As String, _
    ByVal GetInfoInsuredPeople_yetki As String, ByVal LoadDamageInformation_yetki As String, ByVal LoadPolicyInformation_yetki As String, _
    ByVal maksservistalepdakika As Integer)


        Me.pkey = pkey
        Me.sirketkod = sirketkod
        Me.sirketad = sirketad
        Me.yetkilikisiadsoyad = yetkilikisiadsoyad
        Me.adres = adres
        Me.ofistelefon = ofistelefon
        Me.faks = faks
        Me.eposta = eposta
        Me.aktifmi = aktifmi
        Me.resimpkey = resimpkey
        Me.testerisim = testerisim
        Me.topluyukleme = topluyukleme
        Me.wskullaniciad = wskullaniciad
        Me.wssifre = wssifre
        Me.ipdikkat = ipdikkat
        Me.tip = tip
        Me.GetCarAddressInfo_yetki = GetCarAddressInfo_yetki
        Me.GetDamageInformation_yetki = GetDamageInformation_yetki
        Me.GetInfoInsuredPeople_yetki = GetInfoInsuredPeople_yetki
        Me.LoadDamageInformation_yetki = LoadDamageInformation_yetki
        Me.LoadPolicyInformation_yetki = LoadPolicyInformation_yetki
        Me.maksservistalepdakika = maksservistalepdakika

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sirketkod() As String
        Get
            Return sirketkod_v
        End Get
        Set(ByVal value As String)
            sirketkod_v = value
        End Set
    End Property


    Public Property sirketad() As String
        Get
            Return sirketad_v
        End Get
        Set(ByVal value As String)
            sirketad_v = value
        End Set
    End Property


    Public Property yetkilikisiadsoyad() As String
        Get
            Return yetkilikisiadsoyad_v
        End Get
        Set(ByVal value As String)
            yetkilikisiadsoyad_v = value
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


    Public Property ofistelefon() As String
        Get
            Return ofistelefon_v
        End Get
        Set(ByVal value As String)
            ofistelefon_v = value
        End Set
    End Property


    Public Property faks() As String
        Get
            Return faks_v
        End Get
        Set(ByVal value As String)
            faks_v = value
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


    Public Property aktifmi() As String
        Get
            Return aktifmi_v
        End Get
        Set(ByVal value As String)
            aktifmi_v = value
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


    Public Property testerisim() As String
        Get
            Return testerisim_v
        End Get
        Set(ByVal value As String)
            testerisim_v = value
        End Set
    End Property


    Public Property topluyukleme() As String
        Get
            Return topluyukleme_v
        End Get
        Set(ByVal value As String)
            topluyukleme_v = value
        End Set
    End Property


    Public Property wskullaniciad() As String
        Get
            Return wskullaniciad_v
        End Get
        Set(ByVal value As String)
            wskullaniciad_v = value
        End Set
    End Property


    Public Property wssifre() As String
        Get
            Return wssifre_v
        End Get
        Set(ByVal value As String)
            wssifre_v = value
        End Set
    End Property


    Public Property ipdikkat() As String
        Get
            Return ipdikkat_v
        End Get
        Set(ByVal value As String)
            ipdikkat_v = value
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


    Public Property GetCarAddressInfo_yetki() As String
        Get
            Return GetCarAddressInfo_yetki_v
        End Get
        Set(ByVal value As String)
            GetCarAddressInfo_yetki_v = value
        End Set
    End Property


    Public Property GetDamageInformation_yetki() As String
        Get
            Return GetDamageInformation_yetki_v
        End Get
        Set(ByVal value As String)
            GetDamageInformation_yetki_v = value
        End Set
    End Property


    Public Property GetInfoInsuredPeople_yetki() As String
        Get
            Return GetInfoInsuredPeople_yetki_v
        End Get
        Set(ByVal value As String)
            GetInfoInsuredPeople_yetki_v = value
        End Set
    End Property


    Public Property LoadDamageInformation_yetki() As String
        Get
            Return LoadDamageInformation_yetki_v
        End Get
        Set(ByVal value As String)
            LoadDamageInformation_yetki_v = value
        End Set
    End Property


    Public Property LoadPolicyInformation_yetki() As String
        Get
            Return LoadPolicyInformation_yetki_v
        End Get
        Set(ByVal value As String)
            LoadPolicyInformation_yetki_v = value
        End Set
    End Property


    Public Property maksservistalepdakika() As Integer
        Get
            Return maksservistalepdakika_v
        End Get
        Set(ByVal value As Integer)
            maksservistalepdakika_v = value
        End Set
    End Property





End Class
