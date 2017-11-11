Public Class CLASSSIRALAMAFIELD

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private fieldad_v As String
    Private sirano_v As Integer
    Private ordertype_v As Integer
    Private siralamatabload_v As String
    Private kullanilacaktablopkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal fieldad As String, _
    ByVal sirano As Integer, ByVal ordertype As Integer, ByVal siralamatabload As String, _
    ByVal kullanilacaktablopkey As Integer)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.fieldad = fieldad
        Me.sirano = sirano
        Me.ordertype = ordertype
        Me.siralamatabload = siralamatabload
        Me.kullanilacaktablopkey = kullanilacaktablopkey

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


    Public Property sirano() As Integer
        Get
            Return sirano_v
        End Get
        Set(ByVal value As Integer)
            sirano_v = value
        End Set
    End Property


    Public Property ordertype() As Integer
        Get
            Return ordertype_v
        End Get
        Set(ByVal value As Integer)
            ordertype_v = value
        End Set
    End Property


    Public Property siralamatabload() As String
        Get
            Return siralamatabload_v
        End Get
        Set(ByVal value As String)
            siralamatabload_v = value
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




End Class
