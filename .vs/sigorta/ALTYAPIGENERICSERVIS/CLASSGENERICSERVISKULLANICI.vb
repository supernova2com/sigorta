Public Class CLASSGENERICSERVISKULLANICI

    Private pkey_v As Integer
    Private genericservispkey_v As Integer
    Private sirketpkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal genericservispkey As Integer, ByVal sirketpkey As Integer)


        Me.pkey = pkey
        Me.genericservispkey = genericservispkey
        Me.sirketpkey = sirketpkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property genericservispkey() As Integer
        Get
            Return genericservispkey_v
        End Get
        Set(ByVal value As Integer)
            genericservispkey_v = value
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



End Class
