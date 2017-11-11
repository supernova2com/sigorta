Public Class CLASSPLAKADIS

    Private pkey_v As Integer
    Private plaka_v As String
    Private eklenmetarih_v As DateTime
    Private kullanicipkey_v As Integer
    Private dogrucc_v As Integer
    Private arackayitcc_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal plaka As String, ByVal eklenmetarih As DateTime, _
    ByVal kullanicipkey As Integer, ByVal dogrucc As Integer, ByVal arackayitcc As Integer)


        Me.pkey = pkey
        Me.plaka = plaka
        Me.eklenmetarih = eklenmetarih
        Me.kullanicipkey = kullanicipkey
        Me.dogrucc = dogrucc
        Me.arackayitcc = arackayitcc

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


    Public Property eklenmetarih() As Nullable(Of DateTime)
        Get
            Return eklenmetarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            eklenmetarih_v = value
        End Set
    End Property


    Public Property kullanicipkey() As Integer
        Get
            Return kullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kullanicipkey_v = value
        End Set
    End Property


    Public Property dogrucc() As Integer
        Get
            Return dogrucc_v
        End Get
        Set(ByVal value As Integer)
            dogrucc_v = value
        End Set
    End Property

    Public Property arackayitcc() As Integer
        Get
            Return arackayitcc_v
        End Get
        Set(ByVal value As Integer)
            arackayitcc_v = value
        End Set
    End Property



End Class
