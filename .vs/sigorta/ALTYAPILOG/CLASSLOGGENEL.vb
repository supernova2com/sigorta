Public Class CLASSLOGGENEL

    Private pkey_v As Integer
    Private tarih_v As DateTime
    Private kullanicipkey_v As Integer
    Private op_v As String
    Private tablo_v As String
    Private islem_v As String
    Private aramaneyegore_v As String
    Private aramakriter_v As String
    Private refpkey_v As Integer
    Private yanlissifrereset_v As String
    Private dkullaniciad_v As String
    Private dsifre_v As String
    Private ortam_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tarih As DateTime, ByVal kullanicipkey As Integer, _
    ByVal op As String, ByVal tablo As String, ByVal islem As String, _
    ByVal aramaneyegore As String, ByVal aramakriter As String, ByVal refpkey As Integer, _
    ByVal yanlissifrereset As String, ByVal dkullaniciad As String, ByVal dsifre As String, _
    ByVal ortam As String)


        Me.pkey = pkey
        Me.tarih = tarih
        Me.kullanicipkey = kullanicipkey
        Me.op = op
        Me.tablo = tablo
        Me.islem = islem
        Me.aramaneyegore = aramaneyegore
        Me.aramakriter = aramakriter
        Me.refpkey = refpkey
        Me.yanlissifrereset = yanlissifrereset
        Me.dkullaniciad = dkullaniciad
        Me.dsifre = dsifre
        Me.ortam = ortam

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
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


    Public Property kullanicipkey() As Integer
        Get
            Return kullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicipkey_v = value
        End Set
    End Property


    Public Property op() As String
        Get
            Return op_v
        End Get
        Set(ByVal value As String)
            op_v = value
        End Set
    End Property


    Public Property tablo() As String
        Get
            Return tablo_v
        End Get
        Set(ByVal value As String)
            tablo_v = value
        End Set
    End Property


    Public Property islem() As String
        Get
            Return islem_v
        End Get
        Set(ByVal value As String)
            islem_v = value
        End Set
    End Property


    Public Property aramaneyegore() As String
        Get
            Return aramaneyegore_v
        End Get
        Set(ByVal value As String)
            aramaneyegore_v = value
        End Set
    End Property


    Public Property aramakriter() As String
        Get
            Return aramakriter_v
        End Get
        Set(ByVal value As String)
            aramakriter_v = value
        End Set
    End Property


    Public Property refpkey() As Integer
        Get
            Return refpkey_v
        End Get
        Set(ByVal value As Integer)
            refpkey_v = value
        End Set
    End Property


    Public Property yanlissifrereset() As String
        Get
            Return yanlissifrereset_v
        End Get
        Set(ByVal value As String)
            yanlissifrereset_v = value
        End Set
    End Property


    Public Property dkullaniciad() As String
        Get
            Return dkullaniciad_v
        End Get
        Set(ByVal value As String)
            dkullaniciad_v = value
        End Set
    End Property


    Public Property dsifre() As String
        Get
            Return dsifre_v
        End Get
        Set(ByVal value As String)
            dsifre_v = value
        End Set
    End Property


    Public Property ortam() As String
        Get
            Return ortam_v
        End Get
        Set(ByVal value As String)
            ortam_v = value
        End Set
    End Property



End Class
