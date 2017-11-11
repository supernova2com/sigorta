Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("CarAddressInfo")> _
Public Class CarAddressInfo


    Private PlateNumber_v As String
    Private Name_v As String
    Private Surname_v As String
    Private Address1_v As String
    Private Address2_v As String
    Private Address3_v As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal PlateNumber As String, ByVal Name As String, _
    ByVal Surname As String, ByVal Address1 As String, _
    ByVal Address2 As String, ByVal Address3 As String)

        Me.PlateNumber = PlateNumber
        Me.Name = Name
        Me.Surname = Surname
        Me.Address1 = Address1
        Me.Address2 = Address2
        Me.Address3 = Address3

    End Sub

    <XmlAttribute("PlateNumber")> _
    Public Property PlateNumber() As String
        Get
            Return PlateNumber_v
        End Get
        Set(ByVal value As String)
            PlateNumber_v = value
        End Set
    End Property


    <XmlAttribute("Name")> _
    Public Property Name() As String
        Get
            Return Name_v
        End Get
        Set(ByVal value As String)
            Name_v = value
        End Set
    End Property

    <XmlAttribute("Surname")> _
    Public Property Surname() As String
        Get
            Return Surname_v
        End Get
        Set(ByVal value As String)
            Surname_v = value
        End Set
    End Property

    <XmlAttribute("Address1")> _
    Public Property Address1() As String
        Get
            Return Address1_v
        End Get
        Set(ByVal value As String)
            Address1_v = value
        End Set
    End Property

    <XmlAttribute("Address2")> _
    Public Property Address2() As String
        Get
            Return Address2_v
        End Get
        Set(ByVal value As String)
            Address2_v = value
        End Set
    End Property


    <XmlAttribute("Address3")> _
    Public Property Address3() As String
        Get
            Return Address3_v
        End Get
        Set(ByVal value As String)
            Address3_v = value
        End Set
    End Property

End Class
