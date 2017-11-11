Public Class CLASSERRORLOG

    Private pkey_v As Integer
    Private kullanicipkey_v As Integer
    Private tarih_v As DateTime
    Private exp_msg_v As String
    Private exp_source_v As String
    Private exp_stacktrace_v As String
    Private exp_url_v As String
    Private okunmusmu_v As String
    Private emailgonderilmismi_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal kullanicipkey As Integer, ByVal tarih As DateTime, _
    ByVal exp_msg As String, ByVal exp_source As String, ByVal exp_stacktrace As String, _
    ByVal exp_url As String, ByVal okunmusmu As String, ByVal emailgonderilmismi As String)


        Me.pkey = pkey
        Me.kullanicipkey = kullanicipkey
        Me.tarih = tarih
        Me.exp_msg = exp_msg
        Me.exp_source = exp_source
        Me.exp_stacktrace = exp_stacktrace
        Me.exp_url = exp_url
        Me.okunmusmu = okunmusmu
        Me.emailgonderilmismi = emailgonderilmismi

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
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


    Public Property tarih() As Nullable(Of DateTime)
        Get
            Return tarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            tarih_v = value
        End Set
    End Property


    Public Property exp_msg() As String
        Get
            Return exp_msg_v
        End Get
        Set(ByVal value As String)
            exp_msg_v = value
        End Set
    End Property


    Public Property exp_source() As String
        Get
            Return exp_source_v
        End Get
        Set(ByVal value As String)
            exp_source_v = value
        End Set
    End Property


    Public Property exp_stacktrace() As String
        Get
            Return exp_stacktrace_v
        End Get
        Set(ByVal value As String)
            exp_stacktrace_v = value
        End Set
    End Property


    Public Property exp_url() As String
        Get
            Return exp_url_v
        End Get
        Set(ByVal value As String)
            exp_url_v = value
        End Set
    End Property


    Public Property okunmusmu() As String
        Get
            Return okunmusmu_v
        End Get
        Set(ByVal value As String)
            okunmusmu_v = value
        End Set
    End Property


    Public Property emailgonderilmismi() As String
        Get
            Return emailgonderilmismi_v
        End Get
        Set(ByVal value As String)
            emailgonderilmismi_v = value
        End Set
    End Property


End Class
