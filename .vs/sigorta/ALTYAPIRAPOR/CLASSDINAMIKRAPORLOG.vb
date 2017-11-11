Public Class CLASSDINAMIKRAPORLOG

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private csql_v As String
    Private clog_v As String
    Private ctarih_v As DateTime


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal csql As String, _
    ByVal clog As String, ByVal ctarih As DateTime)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.csql = csql
        Me.clog = clog
        Me.ctarih = ctarih

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


    Public Property csql() As String
        Get
            Return csql_v
        End Get
        Set(ByVal value As String)
            csql_v = value
        End Set
    End Property


    Public Property clog() As String
        Get
            Return clog_v
        End Get
        Set(ByVal value As String)
            clog_v = value
        End Set
    End Property


    Public Property ctarih() As Nullable(Of DateTime)
        Get
            Return ctarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            ctarih_v = value
        End Set
    End Property


End Class
