Imports System.Xml
Imports System.Xml.Serialization


<XmlRoot("DamageLoadResult")> _
Public Class DamageLoadResult

    Private InsertedDamageCount_v As Integer
    Private UpdatedDamageCount_v As Integer
    Private SBMCode_v As String
    

    Public Sub New()
    End Sub

    Public Sub New(ByVal InsertedDamageCount As Integer, ByVal UpdatedDamageCount As Integer, _
    ByVal SBMCode As String)

        Me.InsertedDamageCount = InsertedDamageCount
        Me.UpdatedDamageCount = UpdatedDamageCount
        Me.SBMCode = SBMCode
    
    End Sub

    <XmlAttribute("InsertedDamageCount")> _
    Public Property InsertedDamageCount() As Integer
        Get
            Return InsertedDamageCount_v
        End Get
        Set(ByVal value As Integer)
            InsertedDamageCount_v = value
        End Set
    End Property


    <XmlAttribute("UpdatedDamageCount")> _
    Public Property UpdatedDamageCount() As Integer
        Get
            Return UpdatedDamageCount_v
        End Get
        Set(ByVal value As Integer)
            UpdatedDamageCount_v = value
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


