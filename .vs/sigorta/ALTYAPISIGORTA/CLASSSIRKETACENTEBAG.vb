Public Class CLASSSIRKETACENTEBAG

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private acentepkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal acentepkey As Integer)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.acentepkey = acentepkey

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


    Public Property acentepkey() As Integer
        Get
            Return acentepkey_v
        End Get
        Set(ByVal value As Integer)
            acentepkey_v = value
        End Set
    End Property


End Class
