Public Class CLASSAGGFUNC

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private fonksiyonad_v As String
    Private sayialias_v As String
    Private ktablopkey_v As Integer
    Private fieldad_v As String
    Private fonksiyontip_v As String
    Private fonksiyonsql_v As String
    Private kolonbaslik_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal fonksiyonad As String, _
    ByVal sayialias As String, ByVal ktablopkey As Integer, ByVal fieldad As String, _
    ByVal fonksiyontip As String, ByVal fonksiyonsql As String, _
    ByVal kolonbaslik As String)

        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.fonksiyonad = fonksiyonad
        Me.sayialias = sayialias
        Me.ktablopkey = ktablopkey
        Me.fieldad = fieldad
        Me.fonksiyontip = fonksiyontip
        Me.fonksiyonsql = fonksiyonsql
        Me.kolonbaslik = kolonbaslik

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


    Public Property fonksiyonad() As String
        Get
            Return fonksiyonad_v
        End Get
        Set(ByVal value As String)
            fonksiyonad_v = value
        End Set
    End Property


    Public Property sayialias() As String
        Get
            Return sayialias_v
        End Get
        Set(ByVal value As String)
            sayialias_v = value
        End Set
    End Property


    Public Property ktablopkey() As Integer
        Get
            Return ktablopkey_v
        End Get
        Set(ByVal value As Integer)
            ktablopkey_v = value
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


    Public Property fonksiyontip() As String
        Get
            Return fonksiyontip_v
        End Get
        Set(ByVal value As String)
            fonksiyontip_v = value
        End Set
    End Property


    Public Property fonksiyonsql() As String
        Get
            Return fonksiyonsql_v
        End Get
        Set(ByVal value As String)
            fonksiyonsql_v = value
        End Set
    End Property


    Public Property kolonbaslik() As String
        Get
            Return kolonbaslik_v
        End Get
        Set(ByVal value As String)
            kolonbaslik_v = value
        End Set
    End Property


End Class
