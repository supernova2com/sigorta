Public Class CLASSIHALEKURUM

    Private pkey_v As Integer
    Private ihalekurumad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ihalekurumad As String)


        Me.pkey = pkey
        Me.ihalekurumad = ihalekurumad

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ihalekurumad() As String
        Get
            Return ihalekurumad_v
        End Get
        Set(ByVal value As String)
            ihalekurumad_v = value
        End Set
    End Property



End Class
