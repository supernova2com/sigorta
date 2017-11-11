Public Class CLASSKULLANICIROLBILGI
    Private pkey_v As Integer
    Private rolad_v As String
    Private yonsayfa_v As String
    Private anamenupkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal rolad As String, ByVal yonsayfa As String, _
    ByVal anamenupkey As Integer)


        Me.pkey = pkey
        Me.rolad = rolad
        Me.yonsayfa = yonsayfa
        Me.anamenupkey = anamenupkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property rolad() As String
        Get
            Return rolad_v
        End Get
        Set(ByVal value As String)
            rolad_v = value
        End Set
    End Property


    Public Property yonsayfa() As String
        Get
            Return yonsayfa_v
        End Get
        Set(ByVal value As String)
            yonsayfa_v = value
        End Set
    End Property


    Public Property anamenupkey() As Integer
        Get
            Return anamenupkey_v
        End Get
        Set(ByVal value As Integer)
            anamenupkey_v = value
        End Set
    End Property



End Class
