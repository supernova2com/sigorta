Public Class CLASSDINAMIKRAPORJAVASCRIPT

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private jv_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal jv As String)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.jv = jv

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


    Public Property jv() As String
        Get
            Return jv_v
        End Get
        Set(ByVal value As String)
            jv_v = value
        End Set
    End Property

End Class
