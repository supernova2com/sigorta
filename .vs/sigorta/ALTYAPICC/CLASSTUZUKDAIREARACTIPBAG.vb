Public Class CLASSTUZUKDAIREARACTIPBAG

    Private pkey_v As Integer
    Private tuzukaractippkey_v As Integer
    Private dairearactippkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tuzukaractippkey As Integer, ByVal dairearactippkey As Integer)


        Me.pkey = pkey
        Me.tuzukaractippkey = tuzukaractippkey
        Me.dairearactippkey = dairearactippkey

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


    Public Property dairearactippkey() As Integer
        Get
            Return dairearactippkey_v
        End Get
        Set(ByVal value As Integer)
            dairearactippkey_v = value
        End Set
    End Property


End Class
