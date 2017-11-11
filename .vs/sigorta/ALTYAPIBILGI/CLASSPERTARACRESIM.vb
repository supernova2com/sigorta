Public Class CLASSPERTARACRESIM

    Private pkey_v As Integer
    Private pertaracpkey_v As Integer
    Private dosyaad_v As String
    Private anaresim_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal pertaracpkey As Integer, ByVal dosyaad As String, _
    ByVal anaresim As String)


        Me.pkey = pkey
        Me.pertaracpkey = pertaracpkey
        Me.dosyaad = dosyaad
        Me.anaresim = anaresim

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property pertaracpkey() As Integer
        Get
            Return pertaracpkey_v
        End Get
        Set(ByVal value As Integer)
            pertaracpkey_v = value
        End Set
    End Property


    Public Property dosyaad() As String
        Get
            Return dosyaad_v
        End Get
        Set(ByVal value As String)
            dosyaad_v = value
        End Set
    End Property


    Public Property anaresim() As String
        Get
            Return anaresim_v
        End Get
        Set(ByVal value As String)
            anaresim_v = value
        End Set
    End Property

End Class
