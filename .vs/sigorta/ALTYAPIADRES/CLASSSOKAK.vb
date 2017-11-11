Public Class CLASSSOKAK

    Private pkey_v As Integer
    Private mahallepkey_v As Integer
    Private sokakad_v As String
    Private sokaktur_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal mahallepkey As Integer, ByVal sokakad As String, _
    ByVal sokaktur As String)


        Me.pkey = pkey
        Me.mahallepkey = mahallepkey
        Me.sokakad = sokakad
        Me.sokaktur = sokaktur

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property mahallepkey() As Integer
        Get
            Return mahallepkey_v
        End Get
        Set(ByVal value As Integer)
            mahallepkey_v = value
        End Set
    End Property


    Public Property sokakad() As String
        Get
            Return sokakad_v
        End Get
        Set(ByVal value As String)
            sokakad_v = value
        End Set
    End Property


    Public Property sokaktur() As String
        Get
            Return sokaktur_v
        End Get
        Set(ByVal value As String)
            sokaktur_v = value
        End Set
    End Property




End Class
