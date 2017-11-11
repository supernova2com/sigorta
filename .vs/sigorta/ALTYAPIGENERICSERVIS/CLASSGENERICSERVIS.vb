Public Class CLASSGENERICSERVIS

    Private pkey_v As Integer
    Private sqlstrrun_v As String
    Private tip_v As String
    Private ad_v As String
    Private aciklama_v As String



    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sqlstrrun As String, ByVal tip As String, _
    ByVal ad As String, ByVal aciklama As String)

        Me.pkey = pkey
        Me.sqlstrrun = sqlstrrun
        Me.tip = tip
        Me.ad = ad
        Me.aciklama = aciklama

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sqlstrrun() As String
        Get
            Return sqlstrrun_v
        End Get
        Set(ByVal value As String)
            sqlstrrun_v = value
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


    Public Property ad() As String
        Get
            Return ad_v
        End Get
        Set(ByVal value As String)
            ad_v = value
        End Set
    End Property


    Public Property aciklama() As String
        Get
            Return aciklama_v
        End Get
        Set(ByVal value As String)
            aciklama_v = value
        End Set
    End Property


End Class
