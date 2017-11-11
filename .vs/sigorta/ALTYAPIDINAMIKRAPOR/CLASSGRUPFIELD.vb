Public Class CLASSGRUPFIELD

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private gruptabload_v As String
    Private gruptablopkey_v As Integer
    Private gosterilecekfieldpkeybag_v As Integer
    Private grupsira_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal gruptabload As String, _
    ByVal gruptablopkey As Integer, ByVal gosterilecekfieldpkeybag As Integer, ByVal grupsira As Integer)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.gruptabload = gruptabload
        Me.gruptablopkey = gruptablopkey
        Me.gosterilecekfieldpkeybag = gosterilecekfieldpkeybag
        Me.grupsira = grupsira

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


    Public Property gruptabload() As String
        Get
            Return gruptabload_v
        End Get
        Set(ByVal value As String)
            gruptabload_v = value
        End Set
    End Property


    Public Property gruptablopkey() As Integer
        Get
            Return gruptablopkey_v
        End Get
        Set(ByVal value As Integer)
            gruptablopkey_v = value
        End Set
    End Property


    Public Property gosterilecekfieldpkeybag() As Integer
        Get
            Return gosterilecekfieldpkeybag_v
        End Get
        Set(ByVal value As Integer)
            gosterilecekfieldpkeybag_v = value
        End Set
    End Property


    Public Property grupsira() As Integer
        Get
            Return grupsira_v
        End Get
        Set(ByVal value As Integer)
            grupsira_v = value
        End Set
    End Property




End Class
