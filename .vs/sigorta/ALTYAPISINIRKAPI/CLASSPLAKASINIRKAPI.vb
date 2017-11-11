Public Class CLASSPLAKASINIRKAPI

    Private pkey_v As Integer
    Private plaka_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal plaka As String)


        Me.pkey = pkey
        Me.plaka = plaka

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property plaka() As String
        Get
            Return plaka_v
        End Get
        Set(ByVal value As String)
            plaka_v = value
        End Set
    End Property




End Class
