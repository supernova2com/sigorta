Public Class CLASSSIRKETFATURABAG

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private eposta_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal eposta As String)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.eposta = eposta

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sirketpkey() As Integer
        Get
            Return sirketpkey_v
        End Get
        Set(ByVal value As Integer)
            sirketpkey_v = value
        End Set
    End Property


    Public Property eposta() As String
        Get
            Return eposta_v
        End Get
        Set(ByVal value As String)
            eposta_v = value
        End Set
    End Property


End Class
