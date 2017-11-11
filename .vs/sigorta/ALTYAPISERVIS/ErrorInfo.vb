Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("ErrorInfo")> _
Public Class ErrorInfo

    Private Code_v As Integer
    Private Message_v As String


    Public Sub New()

    End Sub

    Public Sub New(ByVal Code As Integer, ByVal Message As String)

        Me.Code = Code
        Me.Message = Message

    End Sub


    <XmlAttribute("Code")> _
    Public Property Code() As Integer
        Get
            Return Code_v
        End Get
        Set(ByVal value As Integer)
            Code_v = value
        End Set
    End Property


    <XmlAttribute("Message")> _
    Public Property Message() As String
        Get
            Return Message_v
        End Get
        Set(ByVal value As String)
            Message_v = value
        End Set
    End Property


End Class
