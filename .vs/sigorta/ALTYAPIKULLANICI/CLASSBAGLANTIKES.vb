Public Class CLASSBAGLANTIKES

    Private pkey_v As Integer
    Private kesilenkullanicipkey_v As Integer
    Private kesenkullanicipkey_v As Integer
    Private kesmebaslangictarih_v As DateTime
    Private kesmebitistarih_v As DateTime


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal kesilenkullanicipkey As Integer, ByVal kesenkullanicipkey As Integer, _
    ByVal kesmebaslangictarih As DateTime, ByVal kesmebitistarih As DateTime)


        Me.pkey = pkey
        Me.kesilenkullanicipkey = kesilenkullanicipkey
        Me.kesenkullanicipkey = kesenkullanicipkey
        Me.kesmebaslangictarih = kesmebaslangictarih
        Me.kesmebitistarih = kesmebitistarih

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property kesilenkullanicipkey() As Integer
        Get
            Return kesilenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kesilenkullanicipkey_v = value
        End Set
    End Property


    Public Property kesenkullanicipkey() As Integer
        Get
            Return kesenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            kesenkullanicipkey_v = value
        End Set
    End Property


    Public Property kesmebaslangictarih() As Nullable(Of DateTime)
        Get
            Return kesmebaslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kesmebaslangictarih_v = value
        End Set
    End Property


    Public Property kesmebitistarih() As Nullable(Of DateTime)
        Get
            Return kesmebitistarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kesmebitistarih_v = value
        End Set
    End Property


End Class
