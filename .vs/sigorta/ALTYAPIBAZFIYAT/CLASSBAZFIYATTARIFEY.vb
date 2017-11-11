Public Class CLASSBAZFIYATTARIFEY

    Private pkey_v As Integer
    Private bazfiyatpkey_v As Integer
    Private aractarifepkey_v As Integer
    Private trafikmiktar_v As Double
    Private mintrafikmiktar_v As Double
    Private kaskooran_v As Double
    Private minkaskomiktar_v As Double
    Private ftoran_v As Double
    Private minftmiktar_v As Double
    Private cooran_v As Double
    Private cominmiktar_v As Double
    Private pertkaskooran_v As Double
    Private minpertkaskomiktar_v As Double


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal bazfiyatpkey As Integer, ByVal aractarifepkey As Integer, _
    ByVal trafikmiktar As Double, ByVal mintrafikmiktar As Double, ByVal kaskooran As Double, _
    ByVal minkaskomiktar As Double, ByVal ftoran As Double, ByVal minftmiktar As Double, _
    ByVal cooran As Double, ByVal cominmiktar As Double, ByVal pertkaskooran As Double, _
    ByVal minpertkaskomiktar As Double)


        Me.pkey = pkey
        Me.bazfiyatpkey = bazfiyatpkey
        Me.aractarifepkey = aractarifepkey
        Me.trafikmiktar = trafikmiktar
        Me.mintrafikmiktar = mintrafikmiktar
        Me.kaskooran = kaskooran
        Me.minkaskomiktar = minkaskomiktar
        Me.ftoran = ftoran
        Me.minftmiktar = minftmiktar
        Me.cooran = cooran
        Me.cominmiktar = cominmiktar
        Me.pertkaskooran = pertkaskooran
        Me.minpertkaskomiktar = minpertkaskomiktar

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


    Public Property aractarifepkey() As Integer
        Get
            Return aractarifepkey_v
        End Get
        Set(ByVal value As Integer)
            aractarifepkey_v = value
        End Set
    End Property


    Public Property trafikmiktar() As Double
        Get
            Return trafikmiktar_v
        End Get
        Set(ByVal value As Double)
            trafikmiktar_v = value
        End Set
    End Property


    Public Property mintrafikmiktar() As Double
        Get
            Return mintrafikmiktar_v
        End Get
        Set(ByVal value As Double)
            mintrafikmiktar_v = value
        End Set
    End Property


    Public Property kaskooran() As Double
        Get
            Return kaskooran_v
        End Get
        Set(ByVal value As Double)
            kaskooran_v = value
        End Set
    End Property


    Public Property minkaskomiktar() As Double
        Get
            Return minkaskomiktar_v
        End Get
        Set(ByVal value As Double)
            minkaskomiktar_v = value
        End Set
    End Property


    Public Property ftoran() As Double
        Get
            Return ftoran_v
        End Get
        Set(ByVal value As Double)
            ftoran_v = value
        End Set
    End Property


    Public Property minftmiktar() As Double
        Get
            Return minftmiktar_v
        End Get
        Set(ByVal value As Double)
            minftmiktar_v = value
        End Set
    End Property


    Public Property cooran() As Double
        Get
            Return cooran_v
        End Get
        Set(ByVal value As Double)
            cooran_v = value
        End Set
    End Property


    Public Property cominmiktar() As Double
        Get
            Return cominmiktar_v
        End Get
        Set(ByVal value As Double)
            cominmiktar_v = value
        End Set
    End Property


    Public Property pertkaskooran() As Double
        Get
            Return pertkaskooran_v
        End Get
        Set(ByVal value As Double)
            pertkaskooran_v = value
        End Set
    End Property


    Public Property minpertkaskomiktar() As Double
        Get
            Return minpertkaskomiktar_v
        End Get
        Set(ByVal value As Double)
            minpertkaskomiktar_v = value
        End Set
    End Property




End Class
