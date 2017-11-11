Public Class CLASSGOSTERILECEKfield

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private fieldad_v As String
    Private sqlalias_v As String
    Private raporalias_v As String
    Private raporsira_v As Integer
    Private gosterilecektabload_v As String
    Private kullanilacaktablopkey_v As Integer
    Private ekkelime_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal fieldad As String, _
    ByVal sqlalias As String, ByVal raporalias As String, ByVal raporsira As Integer, _
    ByVal gosterilecektabload As String, ByVal kullanilacaktablopkey As Integer, _
    ByVal ekkelime As String)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.fieldad = fieldad
        Me.sqlalias = sqlalias
        Me.raporalias = raporalias
        Me.raporsira = raporsira
        Me.gosterilecektabload = gosterilecektabload
        Me.kullanilacaktablopkey = kullanilacaktablopkey
        Me.ekkelime = ekkelime

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property raporpkey() As Integer
        Get
            Return raporpkey_v
        End Get
        Set(ByVal value As Integer)
            raporpkey_v = value
        End Set
    End Property


    Public Property fieldad() As String
        Get
            Return fieldad_v
        End Get
        Set(ByVal value As String)
            fieldad_v = value
        End Set
    End Property


    Public Property sqlalias() As String
        Get
            Return sqlalias_v
        End Get
        Set(ByVal value As String)
            sqlalias_v = value
        End Set
    End Property


    Public Property raporalias() As String
        Get
            Return raporalias_v
        End Get
        Set(ByVal value As String)
            raporalias_v = value
        End Set
    End Property


    Public Property raporsira() As Integer
        Get
            Return raporsira_v
        End Get
        Set(ByVal value As Integer)
            raporsira_v = value
        End Set
    End Property


    Public Property gosterilecektabload() As String
        Get
            Return gosterilecektabload_v
        End Get
        Set(ByVal value As String)
            gosterilecektabload_v = value
        End Set
    End Property


    Public Property kullanilacaktablopkey() As Integer
        Get
            Return kullanilacaktablopkey_v
        End Get
        Set(ByVal value As Integer)
            kullanilacaktablopkey_v = value
        End Set
    End Property


    Public Property ekkelime() As String
        Get
            Return ekkelime_v
        End Get
        Set(ByVal value As String)
            ekkelime_v = value
        End Set
    End Property


End Class
