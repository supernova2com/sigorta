Public Class CLASSTARIFEDAIREBAG

    Private pkey_v As Integer
    Private aractarifepkey_v As Integer
    Private dairearactippkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal aractarifepkey As Integer, ByVal dairearactippkey As Integer)


        Me.pkey = pkey
        Me.aractarifepkey = aractarifepkey
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


    Public Property aractarifepkey() As Integer
        Get
            Return aractarifepkey_v
        End Get
        Set(ByVal value As Integer)
            aractarifepkey_v = value
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
