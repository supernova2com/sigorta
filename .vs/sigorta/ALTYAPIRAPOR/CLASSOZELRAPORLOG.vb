Public Class CLASSOZELRAPORLOG

    Private pkey_v As Integer
    Private tarih_v As DateTime
    Private raporad_v As String
    Private yontem_v As String
    Private fizikseldosyaadexcel_v As String
    Private fizikseldosyaadword_v As String
    Private fizikseldosyaadpdf_v As String
    Private manuelraporpkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tarih As DateTime, ByVal raporad As String, _
    ByVal yontem As String, ByVal fizikseldosyaadexcel As String, ByVal fizikseldosyaadword As String, _
    ByVal fizikseldosyaadpdf As String, ByVal manuelraporpkey As Integer)


        Me.pkey = pkey
        Me.tarih = tarih
        Me.raporad = raporad
        Me.yontem = yontem
        Me.fizikseldosyaadexcel = fizikseldosyaadexcel
        Me.fizikseldosyaadword = fizikseldosyaadword
        Me.fizikseldosyaadpdf = fizikseldosyaadpdf
        Me.manuelraporpkey = manuelraporpkey

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


    Public Property raporad() As String
        Get
            Return raporad_v
        End Get
        Set(ByVal value As String)
            raporad_v = value
        End Set
    End Property


    Public Property yontem() As String
        Get
            Return yontem_v
        End Get
        Set(ByVal value As String)
            yontem_v = value
        End Set
    End Property


    Public Property fizikseldosyaadexcel() As String
        Get
            Return fizikseldosyaadexcel_v
        End Get
        Set(ByVal value As String)
            fizikseldosyaadexcel_v = value
        End Set
    End Property


    Public Property fizikseldosyaadword() As String
        Get
            Return fizikseldosyaadword_v
        End Get
        Set(ByVal value As String)
            fizikseldosyaadword_v = value
        End Set
    End Property


    Public Property fizikseldosyaadpdf() As String
        Get
            Return fizikseldosyaadpdf_v
        End Get
        Set(ByVal value As String)
            fizikseldosyaadpdf_v = value
        End Set
    End Property


    Public Property manuelraporpkey() As Integer
        Get
            Return manuelraporpkey_v
        End Get
        Set(ByVal value As Integer)
            manuelraporpkey_v = value
        End Set
    End Property



End Class
