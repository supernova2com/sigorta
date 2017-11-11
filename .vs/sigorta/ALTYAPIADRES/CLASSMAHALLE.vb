Public Class CLASSMAHALLE

    Private pkey_v As Integer
    Private belediyepkey_v As Integer
    Private mahallead_v As String
    Private tip_v As String
    Private muhtarivarmi_v As String
    Private postakod_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal belediyepkey As Integer, ByVal mahallead As String, _
    ByVal tip As String, ByVal muhtarivarmi As String, ByVal postakod As String)


        Me.pkey = pkey
        Me.belediyepkey = belediyepkey
        Me.mahallead = mahallead
        Me.tip = tip
        Me.muhtarivarmi = muhtarivarmi
        Me.postakod = postakod

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property belediyepkey() As Integer
        Get
            Return belediyepkey_v
        End Get
        Set(ByVal value As Integer)
            belediyepkey_v = value
        End Set
    End Property


    Public Property mahallead() As String
        Get
            Return mahallead_v
        End Get
        Set(ByVal value As String)
            mahallead_v = value
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


    Public Property muhtarivarmi() As String
        Get
            Return muhtarivarmi_v
        End Get
        Set(ByVal value As String)
            muhtarivarmi_v = value
        End Set
    End Property

    Public Property postakod() As String
        Get
            Return postakod_v
        End Get
        Set(ByVal value As String)
            postakod_v = value
        End Set
    End Property


End Class
