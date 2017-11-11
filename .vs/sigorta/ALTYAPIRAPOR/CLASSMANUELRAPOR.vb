Public Class CLASSMANUELRAPOR

    Private pkey_v As Integer
    Private ad_v As String
    Private aciklama_v As String
    Private aktifmi_v As String
    Private remindersettingpkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ad As String, ByVal aciklama As String, _
    ByVal aktifmi As String, ByVal remindersettingpkey As Integer)


        Me.pkey = pkey
        Me.ad = ad
        Me.aciklama = aciklama
        Me.aktifmi = aktifmi
        Me.remindersettingpkey = remindersettingpkey

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


    Public Property aciklama() As String
        Get
            Return aciklama_v
        End Get
        Set(ByVal value As String)
            aciklama_v = value
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


    Public Property remindersettingpkey() As Integer
        Get
            Return remindersettingpkey_v
        End Get
        Set(ByVal value As Integer)
            remindersettingpkey_v = value
        End Set
    End Property

End Class
