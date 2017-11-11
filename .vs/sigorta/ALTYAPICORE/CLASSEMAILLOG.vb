Public Class CLASSEMAILLOG

    Private pkey_v As Integer
    Private gondermetarih_v As DateTime
    Private kime_v As String
    Private kimden_v As String
    Private subject_v As String
    Private body_v As String
    Private sonuc_v As String
    Private hatatxt_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal gondermetarih As DateTime, ByVal kime As String, _
    ByVal kimden As String, ByVal subject As String, ByVal body As String, _
    ByVal sonuc As String, ByVal hatatxt As String)


        Me.pkey = pkey
        Me.gondermetarih = gondermetarih
        Me.kime = kime
        Me.kimden = kimden
        Me.subject = subject
        Me.body = body
        Me.sonuc = sonuc
        Me.hatatxt = hatatxt

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property gondermetarih() As Nullable(Of DateTime)
        Get
            Return gondermetarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            gondermetarih_v = value
        End Set
    End Property


    Public Property kime() As String
        Get
            Return kime_v
        End Get
        Set(ByVal value As String)
            kime_v = value
        End Set
    End Property


    Public Property kimden() As String
        Get
            Return kimden_v
        End Get
        Set(ByVal value As String)
            kimden_v = value
        End Set
    End Property


    Public Property subject() As String
        Get
            Return subject_v
        End Get
        Set(ByVal value As String)
            subject_v = value
        End Set
    End Property


    Public Property body() As String
        Get
            Return body_v
        End Get
        Set(ByVal value As String)
            body_v = value
        End Set
    End Property


    Public Property sonuc() As String
        Get
            Return sonuc_v
        End Get
        Set(ByVal value As String)
            sonuc_v = value
        End Set
    End Property


    Public Property hatatxt() As String
        Get
            Return hatatxt_v
        End Get
        Set(ByVal value As String)
            hatatxt_v = value
        End Set
    End Property

End Class
