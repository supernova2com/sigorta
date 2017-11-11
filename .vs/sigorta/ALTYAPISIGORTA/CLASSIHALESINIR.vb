Public Class CLASSIHALESINIR

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private baslangictarih_v As Date
    Private bitistarih_v As Date
    Private maksadet_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal baslangictarih As Date, _
    ByVal bitistarih As Date, ByVal maksadet As Integer)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.baslangictarih = baslangictarih
        Me.bitistarih = bitistarih
        Me.maksadet = maksadet

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sirketpkey() As Integer
        Get
            Return sirketpkey_v
        End Get
        Set(ByVal value As Integer)
            sirketpkey_v = value
        End Set
    End Property


    Public Property baslangictarih() As Nullable(Of Date)
        Get
            Return baslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            baslangictarih_v = value
        End Set
    End Property


    Public Property bitistarih() As Nullable(Of Date)
        Get
            Return bitistarih_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            bitistarih_v = value
        End Set
    End Property


    Public Property maksadet() As Integer
        Get
            Return maksadet_v
        End Get
        Set(ByVal value As Integer)
            maksadet_v = value
        End Set
    End Property

End Class
