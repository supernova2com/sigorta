Public Class CLASSPERSONEL

    Private pkey_v As Integer
    Private personeladsoyad_v As String
    Private kimlikno_v As String
    Private teknikpersonelmi_v As String
    Private tpno_v As String
    Private ceptel_v As String
    Private adres_v As String
    Private bolge_v As String
    Private egitimekatildimi_v As String
    Private egitimno_v As String
    Private onaylanmismi_v As String
    Private verildigitarih_v As Nullable(Of Date)
    Private belgetarih_v As Nullable(Of Date)
    Private islemkullanicipkey_v As Integer
    Private epostap_v As String





    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal personeladsoyad As String, ByVal kimlikno As String, _
    ByVal teknikpersonelmi As String, ByVal tpno As String, ByVal ceptel As String, _
    ByVal adres As String, ByVal bolge As String, ByVal egitimekatildimi As String, _
    ByVal egitimno As String, ByVal onaylanmismi As String, ByVal verildigitarih As Nullable(Of Date), _
    ByVal belgetarih As Nullable(Of Date), ByVal islemkullanicipkey As Integer, _
    ByVal epostap As String)


        Me.pkey = pkey
        Me.personeladsoyad = personeladsoyad
        Me.kimlikno = kimlikno
        Me.teknikpersonelmi = teknikpersonelmi
        Me.tpno = tpno
        Me.ceptel = ceptel
        Me.adres = adres
        Me.bolge = bolge
        Me.egitimekatildimi = egitimekatildimi
        Me.egitimno = egitimno
        Me.onaylanmismi = onaylanmismi
        Me.verildigitarih = verildigitarih
        Me.islemkullanicipkey = islemkullanicipkey
        Me.epostap = epostap




    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property personeladsoyad() As String
        Get
            Return personeladsoyad_v
        End Get
        Set(ByVal value As String)
            personeladsoyad_v = value
        End Set
    End Property


    Public Property kimlikno() As String
        Get
            Return kimlikno_v
        End Get
        Set(ByVal value As String)
            kimlikno_v = value
        End Set
    End Property


    Public Property teknikpersonelmi() As String
        Get
            Return teknikpersonelmi_v
        End Get
        Set(ByVal value As String)
            teknikpersonelmi_v = value
        End Set
    End Property


    Public Property tpno() As String
        Get
            Return tpno_v
        End Get
        Set(ByVal value As String)
            tpno_v = value
        End Set
    End Property


    Public Property ceptel() As String
        Get
            Return ceptel_v
        End Get
        Set(ByVal value As String)
            ceptel_v = value
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


    Public Property bolge() As String
        Get
            Return bolge_v
        End Get
        Set(ByVal value As String)
            bolge_v = value
        End Set
    End Property


    Public Property egitimekatildimi() As String
        Get
            Return egitimekatildimi_v
        End Get
        Set(ByVal value As String)
            egitimekatildimi_v = value
        End Set
    End Property


    Public Property egitimno() As String
        Get
            Return egitimno_v
        End Get
        Set(ByVal value As String)
            egitimno_v = value
        End Set
    End Property


    Public Property onaylanmismi() As String
        Get
            Return onaylanmismi_v
        End Get
        Set(ByVal value As String)
            onaylanmismi_v = value
        End Set
    End Property


    Public Property verildigitarih() As Nullable(Of Date)
        Get
            Return verildigitarih_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            verildigitarih_v = value
        End Set
    End Property

    Public Property belgetarih() As Nullable(Of Date)
        Get
            Return belgetarih_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            belgetarih_v = value
        End Set
    End Property


    Public Property islemkullanicipkey() As Integer
        Get
            Return islemkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            islemkullanicipkey_v = value
        End Set
    End Property


    Public Property epostap() As String
        Get
            Return epostap_v
        End Get
        Set(ByVal value As String)
            epostap_v = value
        End Set
    End Property

End Class
