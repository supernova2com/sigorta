Public Class CLASSSINIRKAPITAKVIM

    Private pkey_v As Integer
    Private sinirkapipkey_v As Integer
    Private gbaslangic_v As DateTime
    Private gbitis_v As DateTime
    Private gerceksirket1pkey_v As Integer
    Private gorevlisirket1pkey_v As Integer

    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sinirkapipkey As Integer, ByVal gbaslangic As DateTime, _
    ByVal gbitis As DateTime, ByVal gerceksirket1pkey As Integer, ByVal gorevlisirket1pkey As Integer)


        Me.pkey = pkey
        Me.sinirkapipkey = sinirkapipkey
        Me.gbaslangic = gbaslangic
        Me.gbitis = gbitis
        Me.gerceksirket1pkey = gerceksirket1pkey
        Me.gorevlisirket1pkey = gorevlisirket1pkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sinirkapipkey() As Integer
        Get
            Return sinirkapipkey_v
        End Get
        Set(ByVal value As Integer)
            sinirkapipkey_v = value
        End Set
    End Property


    Public Property gbaslangic() As Nullable(Of DateTime)
        Get
            Return gbaslangic_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            gbaslangic_v = value
        End Set
    End Property


    Public Property gbitis() As Nullable(Of DateTime)
        Get
            Return gbitis_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            gbitis_v = value
        End Set
    End Property


    Public Property gerceksirket1pkey() As Integer
        Get
            Return gerceksirket1pkey_v
        End Get
        Set(ByVal value As Integer)
            gerceksirket1pkey_v = value
        End Set
    End Property


    Public Property gorevlisirket1pkey() As Integer
        Get
            Return gorevlisirket1pkey_v
        End Get
        Set(ByVal value As Integer)
            gorevlisirket1pkey_v = value
        End Set
    End Property


    
End Class
