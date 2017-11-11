Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("change")> _
Public Class change

    Private changeText_v As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal changeText As String)

        Me.changeText = changeText

    End Sub


    <XmlAttribute("changeText")> _
    Public Property changeText() As String
        Get
            Return changeText_v
        End Get
        Set(ByVal value As String)
            changeText_v = value
        End Set
    End Property

End Class
