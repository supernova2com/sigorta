Public Class CLASSDINAMIKRAPOR

    Private pkey_v As Integer
    Private raporad_v As String
    Private aciklama_v As String
    Private raportip_v As String
    Private sqlstr_v As String
    Private arabirimolsunmu_v As String
    Private toplamlargosterilsinmi_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporad As String, ByVal aciklama As String, _
    ByVal raportip As String, ByVal sqlstr As String, ByVal arabirimolsunmu As String, _
    ByVal toplamlargosterilsinmi As String)


        Me.pkey = pkey
        Me.raporad = raporad
        Me.aciklama = aciklama
        Me.raportip = raportip
        Me.sqlstr = sqlstr
        Me.arabirimolsunmu = arabirimolsunmu
        Me.toplamlargosterilsinmi = toplamlargosterilsinmi


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property raporad() As String
        Get
            Return raporad_v
        End Get
        Set(ByVal value As String)
            raporad_v = value
        End Set
    End Property


    Public Property aciklama() As String
        Get
            Return aciklama_v
        End Get
        Set(ByVal value As String)
            aciklama_v = value
        End Set
    End Property


    Public Property raportip() As String
        Get
            Return raportip_v
        End Get
        Set(ByVal value As String)
            raportip_v = value
        End Set
    End Property


    Public Property sqlstr() As String
        Get
            Return sqlstr_v
        End Get
        Set(ByVal value As String)
            sqlstr_v = value
        End Set
    End Property


    Public Property arabirimolsunmu() As String
        Get
            Return arabirimolsunmu_v
        End Get
        Set(ByVal value As String)
            arabirimolsunmu_v = value
        End Set
    End Property


    Public Property toplamlargosterilsinmi() As String
        Get
            Return toplamlargosterilsinmi_v
        End Get
        Set(ByVal value As String)
            toplamlargosterilsinmi_v = value
        End Set
    End Property

End Class
