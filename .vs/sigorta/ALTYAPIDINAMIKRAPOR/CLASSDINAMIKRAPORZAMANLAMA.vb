Public Class CLASSDINAMIKRAPORZAMANLAMA

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private remindersettingpkey_v As Integer
    Private zamanlamaad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal remindersettingpkey As Integer, _
    ByVal zamanlamaad As String)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.remindersettingpkey = remindersettingpkey
        Me.zamanlamaad = zamanlamaad

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


    Public Property remindersettingpkey() As Integer
        Get
            Return remindersettingpkey_v
        End Get
        Set(ByVal value As Integer)
            remindersettingpkey_v = value
        End Set
    End Property


    Public Property zamanlamaad() As String
        Get
            Return zamanlamaad_v
        End Get
        Set(ByVal value As String)
            zamanlamaad_v = value
        End Set
    End Property


End Class
