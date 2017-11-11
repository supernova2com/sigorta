Public Class CLASSPOLICETUR

    Private pkey_v As Integer
    Private ad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ad As String)

        Me.pkey = pkey
        Me.ad = ad

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


End Class
