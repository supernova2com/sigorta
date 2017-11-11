Public Class CLASSGALERIANA


    Private pkey_v As Integer
    Private galeriadi_v As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal galeriadi As String)

        Me.pkey = pkey
        Me.galeriadi = galeriadi

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property galeriadi() As String
        Get
            Return galeriadi_v
        End Get
        Set(ByVal value As String)
            galeriadi_v = value
        End Set
    End Property



End Class
