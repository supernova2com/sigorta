Public Class CLASSFUELTYPE

    Private pkey_v As Integer
    Private FuelTypeName_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal FuelTypeName As String)


        Me.pkey = pkey
        Me.FuelTypeName = FuelTypeName

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property FuelTypeName() As String
        Get
            Return FuelTypeName_v
        End Get
        Set(ByVal value As String)
            FuelTypeName_v = value
        End Set
    End Property


End Class
