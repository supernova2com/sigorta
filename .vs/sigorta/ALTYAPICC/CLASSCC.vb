Public Class CLASSCC

    Private pkey_v As Integer
    Private tuzukaractippkey_v As Integer
    Private baslangicc_v As Integer
    Private bitiscc_v As Integer
    Private oran_v As Decimal


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tuzukaractippkey As Integer, ByVal baslangicc As Integer, _
    ByVal bitiscc As Integer, ByVal oran As Decimal)


        Me.pkey = pkey
        Me.tuzukaractippkey = tuzukaractippkey
        Me.baslangicc = baslangicc
        Me.bitiscc = bitiscc
        Me.oran = oran

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property tuzukaractippkey() As Integer
        Get
            Return tuzukaractippkey_v
        End Get
        Set(ByVal value As Integer)
            tuzukaractippkey_v = value
        End Set
    End Property


    Public Property baslangicc() As Integer
        Get
            Return baslangicc_v
        End Get
        Set(ByVal value As Integer)
            baslangicc_v = value
        End Set
    End Property


    Public Property bitiscc() As Integer
        Get
            Return bitiscc_v
        End Get
        Set(ByVal value As Integer)
            bitiscc_v = value
        End Set
    End Property


    Public Property oran() As Decimal
        Get
            Return oran_v
        End Get
        Set(ByVal value As Decimal)
            oran_v = value
        End Set
    End Property


End Class
