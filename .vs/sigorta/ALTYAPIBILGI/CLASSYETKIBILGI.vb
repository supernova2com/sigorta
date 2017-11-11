Public Class CLASSYETKIBILGI


    Private pkey_v As Integer
    Private kullanicirolpkey_v As Integer
    Private tmodulpkey_v As Integer
    Private insertyetki_v As String
    Private updateyetki_v As String
    Private deleteyetki_v As String
    Private readyetki_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal kullanicirolpkey As Integer, ByVal tmodulpkey As Integer, _
    ByVal insertyetki As String, ByVal updateyetki As String, ByVal deleteyetki As String, _
    ByVal readyetki As String)


        Me.pkey = pkey
        Me.kullanicirolpkey = kullanicirolpkey
        Me.tmodulpkey = tmodulpkey
        Me.insertyetki = insertyetki
        Me.updateyetki = updateyetki
        Me.deleteyetki = deleteyetki
        Me.readyetki = readyetki

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property kullanicirolpkey() As Integer
        Get
            Return kullanicirolpkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicirolpkey_v = value
        End Set
    End Property


    Public Property tmodulpkey() As Integer
        Get
            Return tmodulpkey_v
        End Get
        Set(ByVal value As Integer)
            tmodulpkey_v = value
        End Set
    End Property


    Public Property insertyetki() As String
        Get
            Return insertyetki_v
        End Get
        Set(ByVal value As String)
            insertyetki_v = value
        End Set
    End Property


    Public Property updateyetki() As String
        Get
            Return updateyetki_v
        End Get
        Set(ByVal value As String)
            updateyetki_v = value
        End Set
    End Property


    Public Property deleteyetki() As String
        Get
            Return deleteyetki_v
        End Get
        Set(ByVal value As String)
            deleteyetki_v = value
        End Set
    End Property


    Public Property readyetki() As String
        Get
            Return readyetki_v
        End Get
        Set(ByVal value As String)
            readyetki_v = value
        End Set
    End Property


End Class
