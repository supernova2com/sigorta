Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("changeLog")> _
Public Class changeLog

    Private change_v As change

    Public Sub New()

    End Sub

    Public Sub New(ByVal change As change)

        Me.change = change

    End Sub


    Public Property change() As change
        Get
            Return change_v
        End Get
        Set(ByVal value As change)
            change_v = value
        End Set
    End Property

End Class
