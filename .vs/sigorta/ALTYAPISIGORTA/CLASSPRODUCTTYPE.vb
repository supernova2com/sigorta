Public Class CLASSPRODUCTTYPE

    Private pkey_v As Integer
    Private urunkodpkey_v As Integer
    Private ProductTypeCode_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal urunkodpkey As Integer, ByVal ProductTypeCode As String)


        Me.pkey = pkey
        Me.urunkodpkey = urunkodpkey
        Me.ProductTypeCode = ProductTypeCode

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property urunkodpkey() As Integer
        Get
            Return urunkodpkey_v
        End Get
        Set(ByVal value As Integer)
            urunkodpkey_v = value
        End Set
    End Property


    Public Property ProductTypeCode() As String
        Get
            Return ProductTypeCode_v
        End Get
        Set(ByVal value As String)
            ProductTypeCode_v = value
        End Set
    End Property


End Class
