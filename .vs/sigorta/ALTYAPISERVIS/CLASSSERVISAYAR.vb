Public Class CLASSSERVISAYAR

    Private pkey_v As Integer
    Private bazfiyatdikkat_v As String
    Private ipdikkat_v As String
    Private tarifekodkontrol_v As String
    Private sinirkapitakvimkontrol_v As String
    Private sonzeyilbitistarihkontrol_v As String
    Private eksurucukontrol_v As String
    Private duzenlemebitiskontrol_v As String
    Private plakasinirkapikontrol_v As String
    Private plakakiralikarackontrol_v As String
    Private plakaticariarackontrol_v As String
    Private plakakktckontrol_v As String
    Private plakarumkontrol_v As String
    Private rzeyilkontrol_v As String
    Private damagekimlikkontrol_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal bazfiyatdikkat As String, ByVal ipdikkat As String, _
    ByVal tarifekodkontrol As String, ByVal sinirkapitakvimkontrol As String, ByVal sonzeyilbitistarihkontrol As String, _
    ByVal eksurucukontrol As String, ByVal duzenlemebitiskontrol As String, ByVal plakasinirkapikontrol As String, _
    ByVal plakakiralikarackontrol As String, ByVal plakaticariarackontrol As String, ByVal plakakktckontrol As String, _
    ByVal plakarumkontrol As String, ByVal rzeyilkontrol As String, ByVal damagekimlikkontrol As String)


        Me.pkey = pkey
        Me.bazfiyatdikkat = bazfiyatdikkat
        Me.ipdikkat = ipdikkat
        Me.tarifekodkontrol = tarifekodkontrol
        Me.sinirkapitakvimkontrol = sinirkapitakvimkontrol
        Me.sonzeyilbitistarihkontrol = sonzeyilbitistarihkontrol
        Me.eksurucukontrol = eksurucukontrol
        Me.duzenlemebitiskontrol = duzenlemebitiskontrol
        Me.plakasinirkapikontrol = plakasinirkapikontrol
        Me.plakakiralikarackontrol = plakakiralikarackontrol
        Me.plakaticariarackontrol = plakaticariarackontrol
        Me.plakakktckontrol = plakakktckontrol
        Me.plakarumkontrol = plakarumkontrol
        Me.rzeyilkontrol = rzeyilkontrol
        Me.damagekimlikkontrol = damagekimlikkontrol

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property bazfiyatdikkat() As String
        Get
            Return bazfiyatdikkat_v
        End Get
        Set(ByVal value As String)
            bazfiyatdikkat_v = value
        End Set
    End Property


    Public Property ipdikkat() As String
        Get
            Return ipdikkat_v
        End Get
        Set(ByVal value As String)
            ipdikkat_v = value
        End Set
    End Property


    Public Property tarifekodkontrol() As String
        Get
            Return tarifekodkontrol_v
        End Get
        Set(ByVal value As String)
            tarifekodkontrol_v = value
        End Set
    End Property


    Public Property sinirkapitakvimkontrol() As String
        Get
            Return sinirkapitakvimkontrol_v
        End Get
        Set(ByVal value As String)
            sinirkapitakvimkontrol_v = value
        End Set
    End Property


    Public Property sonzeyilbitistarihkontrol() As String
        Get
            Return sonzeyilbitistarihkontrol_v
        End Get
        Set(ByVal value As String)
            sonzeyilbitistarihkontrol_v = value
        End Set
    End Property


    Public Property eksurucukontrol() As String
        Get
            Return eksurucukontrol_v
        End Get
        Set(ByVal value As String)
            eksurucukontrol_v = value
        End Set
    End Property


    Public Property duzenlemebitiskontrol() As String
        Get
            Return duzenlemebitiskontrol_v
        End Get
        Set(ByVal value As String)
            duzenlemebitiskontrol_v = value
        End Set
    End Property


    Public Property plakasinirkapikontrol() As String
        Get
            Return plakasinirkapikontrol_v
        End Get
        Set(ByVal value As String)
            plakasinirkapikontrol_v = value
        End Set
    End Property


    Public Property plakakiralikarackontrol() As String
        Get
            Return plakakiralikarackontrol_v
        End Get
        Set(ByVal value As String)
            plakakiralikarackontrol_v = value
        End Set
    End Property


    Public Property plakaticariarackontrol() As String
        Get
            Return plakaticariarackontrol_v
        End Get
        Set(ByVal value As String)
            plakaticariarackontrol_v = value
        End Set
    End Property


    Public Property plakakktckontrol() As String
        Get
            Return plakakktckontrol_v
        End Get
        Set(ByVal value As String)
            plakakktckontrol_v = value
        End Set
    End Property


    Public Property plakarumkontrol() As String
        Get
            Return plakarumkontrol_v
        End Get
        Set(ByVal value As String)
            plakarumkontrol_v = value
        End Set
    End Property


    Public Property rzeyilkontrol() As String
        Get
            Return rzeyilkontrol_v
        End Get
        Set(ByVal value As String)
            rzeyilkontrol_v = value
        End Set
    End Property


    Public Property damagekimlikkontrol() As String
        Get
            Return damagekimlikkontrol_v
        End Get
        Set(ByVal value As String)
            damagekimlikkontrol_v = value
        End Set
    End Property





End Class
