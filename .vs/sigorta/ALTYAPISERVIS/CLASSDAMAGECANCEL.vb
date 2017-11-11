Public Class CLASSDAMAGECANCEL

    Private pkey_v As Integer
    Private FirmCode_v As String
    Private ProductCode_v As String
    Private AgencyCode_v As String
    Private PolicyNumber_v As String
    Private TecditNumber_v As String
    Private FileNo_v As String
    Private RequestNo_v As String
    Private ProductType_v As String

    Private iptaltur_v As String
    Private iptaltarih_v As Date
    Private iptalkullanicipkey_v As Integer
    Private kayittarih_v As DateTime

    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, ByVal TecditNumber As String, _
    ByVal FileNo As String, ByVal RequestNo As String, ByVal ProductType As String, _
    ByVal iptaltur As String, ByVal iptaltarih As Date, ByVal iptalkullanicipkey As Integer, _
    ByVal kayittarih As DateTime)


        Me.pkey = pkey
        Me.FirmCode = FirmCode
        Me.ProductCode = ProductCode
        Me.AgencyCode = AgencyCode
        Me.PolicyNumber = PolicyNumber
        Me.TecditNumber = TecditNumber
        Me.FileNo = FileNo
        Me.RequestNo = RequestNo
        Me.ProductType = ProductType
        Me.iptaltur = iptaltur
        Me.iptaltarih = iptaltarih
        Me.iptalkullanicipkey = iptalkullanicipkey
        Me.kayittarih = kayittarih

    End Sub


    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property FirmCode() As String
        Get
            Return FirmCode_v
        End Get
        Set(ByVal value As String)
            FirmCode_v = value
        End Set
    End Property


    Public Property ProductCode() As String
        Get
            Return ProductCode_v
        End Get
        Set(ByVal value As String)
            ProductCode_v = value
        End Set
    End Property


    Public Property AgencyCode() As String
        Get
            Return AgencyCode_v
        End Get
        Set(ByVal value As String)
            AgencyCode_v = value
        End Set
    End Property


    Public Property PolicyNumber() As String
        Get
            Return PolicyNumber_v
        End Get
        Set(ByVal value As String)
            PolicyNumber_v = value
        End Set
    End Property


    Public Property TecditNumber() As String
        Get
            Return TecditNumber_v
        End Get
        Set(ByVal value As String)
            TecditNumber_v = value
        End Set
    End Property


    Public Property FileNo() As String
        Get
            Return FileNo_v
        End Get
        Set(ByVal value As String)
            FileNo_v = value
        End Set
    End Property


    Public Property RequestNo() As String
        Get
            Return RequestNo_v
        End Get
        Set(ByVal value As String)
            RequestNo_v = value
        End Set
    End Property

    Public Property ProductType() As String
        Get
            Return ProductType_v
        End Get
        Set(ByVal value As String)
            ProductType_v = value
        End Set
    End Property


    Public Property iptaltur() As String
        Get
            Return iptaltur_v
        End Get
        Set(ByVal value As String)
            iptaltur_v = value
        End Set
    End Property


    Public Property iptaltarih() As Nullable(Of Date)
        Get
            Return iptaltarih_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            iptaltarih_v = value
        End Set
    End Property


    Public Property iptalkullanicipkey() As Integer
        Get
            Return iptalkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            iptalkullanicipkey_v = value
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


End Class
