Public Class CLASSDROPDOWNLIST

    Private pkey_v As Integer
    Private ad_v As String
    Private tabload_v As String
    Private degerkolon_v As String
    Private yazikolon_v As String
    Private sqlstropsiyonel_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ad As String, ByVal tabload As String, _
    ByVal degerkolon As String, ByVal yazikolon As String, ByVal sqlstropsiyonel As String)


        Me.pkey = pkey
        Me.ad = ad
        Me.tabload = tabload
        Me.degerkolon = degerkolon
        Me.yazikolon = yazikolon
        Me.sqlstropsiyonel = sqlstropsiyonel

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ad() As String
        Get
            Return ad_v
        End Get
        Set(ByVal value As String)
            ad_v = value
        End Set
    End Property


    Public Property tabload() As String
        Get
            Return tabload_v
        End Get
        Set(ByVal value As String)
            tabload_v = value
        End Set
    End Property


    Public Property degerkolon() As String
        Get
            Return degerkolon_v
        End Get
        Set(ByVal value As String)
            degerkolon_v = value
        End Set
    End Property


    Public Property yazikolon() As String
        Get
            Return yazikolon_v
        End Get
        Set(ByVal value As String)
            yazikolon_v = value
        End Set
    End Property


    Public Property sqlstropsiyonel() As String
        Get
            Return sqlstropsiyonel_v
        End Get
        Set(ByVal value As String)
            sqlstropsiyonel_v = value
        End Set
    End Property

End Class
