Public Class CLASSBAZFIYATTARIFESINIRKAPI

    Private pkey_v As Integer
    Private bazfiyatpkey_v As Integer
    Private sinirkapiaractippkey_v As Integer
    Private ucgun_v As Double
    Private biray_v As Double
    Private ucay_v As Double
    Private altiay_v As Double
    Private onikiay_v As Double


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal bazfiyatpkey As Integer, ByVal sinirkapiaractippkey As Integer, _
    ByVal ucgun As Double, ByVal biray As Double, ByVal ucay As Double, _
    ByVal altiay As Double, ByVal onikiay As Double)


        Me.pkey = pkey
        Me.bazfiyatpkey = bazfiyatpkey
        Me.sinirkapiaractippkey = sinirkapiaractippkey
        Me.ucgun = ucgun
        Me.biray = biray
        Me.ucay = ucay
        Me.altiay = altiay
        Me.onikiay = onikiay

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property bazfiyatpkey() As Integer
        Get
            Return bazfiyatpkey_v
        End Get
        Set(ByVal value As Integer)
            bazfiyatpkey_v = value
        End Set
    End Property


    Public Property sinirkapiaractippkey() As Integer
        Get
            Return sinirkapiaractippkey_v
        End Get
        Set(ByVal value As Integer)
            sinirkapiaractippkey_v = value
        End Set
    End Property


    Public Property ucgun() As Double
        Get
            Return ucgun_v
        End Get
        Set(ByVal value As Double)
            ucgun_v = value
        End Set
    End Property


    Public Property biray() As Double
        Get
            Return biray_v
        End Get
        Set(ByVal value As Double)
            biray_v = value
        End Set
    End Property


    Public Property ucay() As Double
        Get
            Return ucay_v
        End Get
        Set(ByVal value As Double)
            ucay_v = value
        End Set
    End Property


    Public Property altiay() As Double
        Get
            Return altiay_v
        End Get
        Set(ByVal value As Double)
            altiay_v = value
        End Set
    End Property


    Public Property onikiay() As Double
        Get
            Return onikiay_v
        End Get
        Set(ByVal value As Double)
            onikiay_v = value
        End Set
    End Property





End Class
