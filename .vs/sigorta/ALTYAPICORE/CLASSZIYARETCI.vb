Public Class CLASSZIYARETCI

    Private pkey_v As Integer
    Private ipadres_v As String
    Private tarih_v As DateTime


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ipadres As String, ByVal tarih As DateTime)


        Me.pkey = pkey
        Me.ipadres = ipadres
        Me.tarih = tarih

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ipadres() As String
        Get
            Return ipadres_v
        End Get
        Set(ByVal value As String)
            ipadres_v = value
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

End Class
