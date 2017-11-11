Public Class CLASSSIRKETIPBAG

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private ipadres_v As String
    Private cidrnotation_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal ipadres As String, _
                   ByVal cidrnotation As Integer)

        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.ipadres = ipadres
        Me.cidrnotation = cidrnotation

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


    Public Property ipadres() As String
        Get
            Return ipadres_v
        End Get
        Set(ByVal value As String)
            ipadres_v = value
        End Set
    End Property

    Public Property cidrnotation() As Integer
        Get
            Return cidrnotation_v
        End Get
        Set(ByVal value As Integer)
            cidrnotation_v = value
        End Set
    End Property


End Class
