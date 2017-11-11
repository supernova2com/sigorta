Public Class CLASSMANUELRAPORKULLANICI

    Private pkey_v As Integer
    Private manuelraporpkey_v As Integer
    Private kullanicipkey_v As Integer
    Private epostaexcel_v As String
    Private epostaword_v As String
    Private epostapdf_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal manuelraporpkey As Integer, ByVal kullanicipkey As Integer, _
    ByVal epostaexcel As String, ByVal epostaword As String, ByVal epostapdf As String)


        Me.pkey = pkey
        Me.manuelraporpkey = manuelraporpkey
        Me.kullanicipkey = kullanicipkey
        Me.epostaexcel = epostaexcel
        Me.epostaword = epostaword
        Me.epostapdf = epostapdf

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
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


    Public Property kullanicipkey() As Integer
        Get
            Return kullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicipkey_v = value
        End Set
    End Property


    Public Property epostaexcel() As String
        Get
            Return epostaexcel_v
        End Get
        Set(ByVal value As String)
            epostaexcel_v = value
        End Set
    End Property


    Public Property epostaword() As String
        Get
            Return epostaword_v
        End Get
        Set(ByVal value As String)
            epostaword_v = value
        End Set
    End Property


    Public Property epostapdf() As String
        Get
            Return epostapdf_v
        End Get
        Set(ByVal value As String)
            epostapdf_v = value
        End Set
    End Property

End Class
