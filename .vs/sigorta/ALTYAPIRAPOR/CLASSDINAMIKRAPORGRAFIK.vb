Public Class CLASSDINAMIKRAPORGRAFIK

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private grafikbaslik_v As String
    Private grafiktip_v As String
    Private genislik_v As Integer
    Private yukseklik_v As Integer
    Private kolonseriad_v As String
    Private kolonsayi_v As String
    Private labelgosterilsinmi_v As String
    Private labelarkaplanrengi_v As String
    Private labelseffaflik_v As Decimal
    Private legendgosterilsinmi_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal grafikbaslik As String, _
    ByVal grafiktip As String, ByVal genislik As Integer, ByVal yukseklik As Integer, _
    ByVal kolonseriad As String, ByVal kolonsayi As String, ByVal labelgosterilsinmi As String, _
    ByVal labelarkaplanrengi As String, ByVal labelseffaflik As Decimal, ByVal legendgosterilsinmi As String)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.grafikbaslik = grafikbaslik
        Me.grafiktip = grafiktip
        Me.genislik = genislik
        Me.yukseklik = yukseklik
        Me.kolonseriad = kolonseriad
        Me.kolonsayi = kolonsayi
        Me.labelgosterilsinmi = labelgosterilsinmi
        Me.labelarkaplanrengi = labelarkaplanrengi
        Me.labelseffaflik = labelseffaflik
        Me.legendgosterilsinmi = legendgosterilsinmi

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


    Public Property grafikbaslik() As String
        Get
            Return grafikbaslik_v
        End Get
        Set(ByVal value As String)
            grafikbaslik_v = value
        End Set
    End Property


    Public Property grafiktip() As String
        Get
            Return grafiktip_v
        End Get
        Set(ByVal value As String)
            grafiktip_v = value
        End Set
    End Property


    Public Property genislik() As Integer
        Get
            Return genislik_v
        End Get
        Set(ByVal value As Integer)
            genislik_v = value
        End Set
    End Property


    Public Property yukseklik() As Integer
        Get
            Return yukseklik_v
        End Get
        Set(ByVal value As Integer)
            yukseklik_v = value
        End Set
    End Property


    Public Property kolonseriad() As String
        Get
            Return kolonseriad_v
        End Get
        Set(ByVal value As String)
            kolonseriad_v = value
        End Set
    End Property


    Public Property kolonsayi() As String
        Get
            Return kolonsayi_v
        End Get
        Set(ByVal value As String)
            kolonsayi_v = value
        End Set
    End Property


    Public Property labelgosterilsinmi() As String
        Get
            Return labelgosterilsinmi_v
        End Get
        Set(ByVal value As String)
            labelgosterilsinmi_v = value
        End Set
    End Property


    Public Property labelarkaplanrengi() As String
        Get
            Return labelarkaplanrengi_v
        End Get
        Set(ByVal value As String)
            labelarkaplanrengi_v = value
        End Set
    End Property


    Public Property labelseffaflik() As Decimal
        Get
            Return labelseffaflik_v
        End Get
        Set(ByVal value As Decimal)
            labelseffaflik_v = value
        End Set
    End Property


    Public Property legendgosterilsinmi() As String
        Get
            Return legendgosterilsinmi_v
        End Get
        Set(ByVal value As String)
            legendgosterilsinmi_v = value
        End Set
    End Property



End Class
