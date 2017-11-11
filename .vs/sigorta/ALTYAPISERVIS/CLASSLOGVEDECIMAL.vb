Public Class CLASSLOGVEDECIMAL

    Private logx_v As String
    Private hasaroran_v As Decimal
    Private hasarsizlikoran_v As Decimal
    Private bakildimi_v As String
    Private simdikiyilhasarvarmi_v As String
    Private oncekiyilhasarvarmi_v As String



    Public Sub New()
    End Sub

    Public Sub New(ByVal logx As String, ByVal hasaroran As Decimal, ByVal hasarsizlikoran As Decimal, _
                   ByVal bakildimi As String, ByVal simdikiyilhasarvarmi As String, ByVal bironcekiyilhasarvarmi As String)

        Me.logx = logx
        Me.hasaroran = hasaroran
        Me.hasarsizlikoran = hasarsizlikoran
        Me.bakildimi = bakildimi
        Me.simdikiyilhasarvarmi = simdikiyilhasarvarmi
        Me.oncekiyilhasarvarmi = oncekiyilhasarvarmi




    End Sub

    Public Property logx() As String
        Get
            Return logx_v
        End Get
        Set(ByVal value As String)
            logx_v = value
        End Set
    End Property


    Public Property hasaroran() As Decimal
        Get
            Return hasaroran_v
        End Get
        Set(ByVal value As Decimal)
            hasaroran_v = value
        End Set
    End Property


    Public Property hasarsizlikoran() As Decimal
        Get
            Return hasarsizlikoran_v
        End Get
        Set(ByVal value As Decimal)
            hasarsizlikoran_v = value
        End Set
    End Property


    Public Property bakildimi() As String
        Get
            Return bakildimi_v
        End Get
        Set(ByVal value As String)
            bakildimi_v = value
        End Set
    End Property


    Public Property simdikiyilhasarvarmi() As String
        Get
            Return simdikiyilhasarvarmi_v
        End Get
        Set(ByVal value As String)
            simdikiyilhasarvarmi_v = value
        End Set
    End Property


    Public Property oncekiyilhasarvarmi() As String
        Get
            Return oncekiyilhasarvarmi_v
        End Get
        Set(ByVal value As String)
            oncekiyilhasarvarmi_v = value
        End Set
    End Property





End Class
