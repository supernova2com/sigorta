Public Class CLASSSINIRKAPIBAZFIYAT


    Private pkey_v As Integer
    Private baslangictarih_v As DateTime
    Private kayittarih_v As DateTime
    Private kayitno_v As Integer



    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal baslangictarih As DateTime, _
    ByVal kayittarih As DateTime, ByVal kayitno As Integer)


        Me.pkey = pkey
        Me.baslangictarih = baslangictarih
        Me.kayittarih = kayittarih
        Me.kayitno = kayitno


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property



    Public Property baslangictarih() As Nullable(Of DateTime)
        Get
            Return baslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            baslangictarih_v = value
        End Set
    End Property


    Public Property kayittarih() As Nullable(Of DateTime)
        Get
            Return kayittarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kayittarih_v = value
        End Set
    End Property


    Public Property kayitno() As Integer
        Get
            Return kayitno_v
        End Get
        Set(ByVal value As Integer)
            kayitno_v = value
        End Set
    End Property




End Class
