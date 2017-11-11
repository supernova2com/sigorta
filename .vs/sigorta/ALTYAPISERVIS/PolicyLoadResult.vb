Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("PolicyLoadResult")> _
Public Class PolicyLoadResult


    Private InsertedPolicyCount_v As Integer
    Private UpdatedPolicyCount_v As Integer
    Private SBMCode_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal InsertedPolicyCount As Integer, ByVal UpdatedPolicyCount As Integer, _
    ByVal SBMCode As String)


        Me.InsertedPolicyCount = InsertedPolicyCount
        Me.UpdatedPolicyCount = UpdatedPolicyCount
        Me.SBMCode = SBMCode
      
    End Sub

    <XmlAttribute("InsertedPolicyCount")> _
    Public Property InsertedPolicyCount() As Integer
        Get
            Return InsertedPolicyCount_v
        End Get
        Set(ByVal value As Integer)
            InsertedPolicyCount_v = value
        End Set
    End Property


    <XmlAttribute("UpdatedPolicyCount")> _
    Public Property UpdatedPolicyCount() As Integer
        Get
            Return UpdatedPolicyCount_v
        End Get
        Set(ByVal value As Integer)
            UpdatedPolicyCount_v = value
        End Set
    End Property


    <XmlAttribute("SBMCode")> _
    Public Property SBMCode() As String
        Get
            Return SBMCode_v
        End Get
        Set(ByVal value As String)
            SBMCode_v = value
        End Set
    End Property

  


End Class
