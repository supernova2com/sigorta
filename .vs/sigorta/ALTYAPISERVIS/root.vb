Imports System.Xml
Imports System.Xml.Serialization

<XmlRoot("root")> _
Public Class root

    Private ResultCode_v As Integer
    Private ErrorInfo_v As ErrorInfo
    Private PolicyLoadResult_v As PolicyLoadResult
    Private DamageLoadResult_v As DamageLoadResult
    Private changeLog_v As changeLog
    Private Damages_v As List(Of Damage)
    Private PolicyInfo_v As PolicyInfoPolis
    Private CarAddressInfo_v As CarAddressInfo
    Private hesapsonuc_v As hesapsonuc
    Private varmi_v As Boolean
    Private informationtag_v As String
    Private GetDamageResultStr_v As String
    Private resultstr_v As String

    Public Sub New()

    End Sub


    Public Sub New(ByVal ResultCode As Integer, ByVal ErrorInfo As ErrorInfo, ByVal informationtag As String)

        Me.ResultCode = ResultCode
        Me.ErrorInfo = ErrorInfo
        Me.informationtag = informationtag

    End Sub

    Public Sub New(ByVal ResultCode As Integer, ByVal ErrorInfo As ErrorInfo)

        Me.ResultCode = ResultCode
        Me.ErrorInfo = ErrorInfo

    End Sub

    Public Sub New(ByVal ResultCode As Integer, ByVal PolicyLoadResult As PolicyLoadResult, ByVal hesapsonuc As hesapsonuc)

        Me.ResultCode = ResultCode
        Me.PolicyLoadResult = PolicyLoadResult
        Me.hesapsonuc = hesapsonuc


    End Sub

    Public Sub New(ByVal ResultCode As Integer, ByVal DamageLoadResult As DamageLoadResult)

        Me.ResultCode = ResultCode
        Me.DamageLoadResult = DamageLoadResult

    End Sub

    Public Sub New(ByVal ResultCode As Integer, ByVal DamageLoadResult As DamageLoadResult, ByVal GetDamageResultStr As String)

        Me.ResultCode = ResultCode
        Me.DamageLoadResult = DamageLoadResult
        Me.GetDamageResultStr = GetDamageResultStr

    End Sub

    Public Sub New(ByVal changeLog As changeLog)

        Me.changeLog_v = changeLog

    End Sub


    Public Sub New(ByVal ResultCode As Integer, ByVal Damages As List(Of Damage))

        Me.ResultCode = ResultCode
        Me.Damages = Damages

    End Sub

    Public Sub New(ByVal ResultCode As Integer, ByVal PolicyInfoPolis As PolicyInfoPolis)

        Me.ResultCode = ResultCode
        Me.PolicyInfo = PolicyInfoPolis

    End Sub

    Public Sub New(ByVal ResultCode As Integer, ByVal varmi As Boolean)

        Me.varmi = varmi

    End Sub

    <XmlAttribute("ResultCode")> _
    Public Property ResultCode() As Integer
        Get
            Return ResultCode_v
        End Get
        Set(ByVal value As Integer)
            ResultCode_v = value
        End Set
    End Property


    Public Property ErrorInfo() As ErrorInfo
        Get
            Return ErrorInfo_v
        End Get
        Set(ByVal value As ErrorInfo)
            ErrorInfo_v = value
        End Set
    End Property


    Public Property PolicyLoadResult() As PolicyLoadResult
        Get
            Return PolicyLoadResult_v
        End Get
        Set(ByVal value As PolicyLoadResult)
            PolicyLoadResult_v = value
        End Set
    End Property


    Public Property DamageLoadResult() As DamageLoadResult
        Get
            Return DamageLoadResult_v
        End Get
        Set(ByVal value As DamageLoadResult)
            DamageLoadResult_v = value
        End Set
    End Property


    Public Property changeLog() As changeLog
        Get
            Return changeLog_v
        End Get
        Set(ByVal value As changeLog)
            changeLog_v = value
        End Set
    End Property


    Public Property Damages() As List(Of Damage)
        Get
            Return Damages_v
        End Get
        Set(ByVal value As List(Of Damage))
            Damages_v = value
        End Set
    End Property


    Public Property PolicyInfo() As PolicyInfoPolis
        Get
            Return PolicyInfo_v
        End Get
        Set(ByVal value As PolicyInfoPolis)
            PolicyInfo_v = value
        End Set
    End Property


    Public Property CarAddressInfo() As CarAddressInfo
        Get
            Return CarAddressInfo_v
        End Get
        Set(ByVal value As CarAddressInfo)
            CarAddressInfo_v = value
        End Set
    End Property


    Public Property hesapsonuc() As hesapsonuc
        Get
            Return hesapsonuc_v
        End Get
        Set(ByVal value As hesapsonuc)
            hesapsonuc_v = value
        End Set
    End Property


    Public Property varmi() As Boolean
        Get
            Return varmi_v
        End Get
        Set(ByVal value As Boolean)
            varmi_v = value
        End Set
    End Property


    Public Property informationtag() As String
        Get
            Return informationtag_v
        End Get
        Set(ByVal value As String)
            informationtag_v = value
        End Set
    End Property


    Public Property GetDamageResultStr() As String
        Get
            Return GetDamageResultStr_v
        End Get
        Set(ByVal value As String)
            GetDamageResultStr_v = value
        End Set
    End Property


    Public Property resultstr() As String
        Get
            Return resultstr_v
        End Get
        Set(ByVal value As String)
            resultstr_v = value
        End Set
    End Property


End Class
