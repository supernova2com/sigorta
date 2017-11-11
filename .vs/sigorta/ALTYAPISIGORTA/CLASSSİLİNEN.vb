Public Class CLASSSİLİNEN

    Private pkey_v As Integer
    Private ne_v As String
    Private xmlstr_v As String
    Private tarih_v As DateTime
    Private kimpkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ne As String, ByVal xmlstr As String, _
    ByVal tarih As DateTime, ByVal kimpkey As Integer)


        Me.pkey = pkey
        Me.ne = ne
        Me.xmlstr = xmlstr
        Me.tarih = tarih
        Me.kimpkey = kimpkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ne() As String
        Get
            Return ne_v
        End Get
        Set(ByVal value As String)
            ne_v = value
        End Set
    End Property


    Public Property xmlstr() As String
        Get
            Return xmlstr_v
        End Get
        Set(ByVal value As String)
            xmlstr_v = value
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


    Public Property kimpkey() As Integer
        Get
            Return kimpkey_v
        End Get
        Set(ByVal value As Integer)
            kimpkey_v = value
        End Set
    End Property


End Class
