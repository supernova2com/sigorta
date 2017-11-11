Imports icisleri

Public Class CLASSBUCAK
    Implements IEquatable(Of CLASSBUCAK)

    Private pkey_v As Integer
    Private ilcepkey_v As Integer
    Private bucakad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal ilcepkey As Integer, ByVal bucakad As String)

        Me.pkey = pkey
        Me.ilcepkey = ilcepkey
        Me.bucakad = bucakad

    End Sub


    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ilcepkey() As Integer
        Get
            Return ilcepkey_v
        End Get
        Set(ByVal value As Integer)
            ilcepkey_v = value
        End Set
    End Property


    Public Property bucakad() As String
        Get
            Return bucakad_v
        End Get
        Set(ByVal value As String)
            bucakad_v = value
        End Set
    End Property


    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        Dim objAsPart As Part = TryCast(obj, Part)
        If objAsPart Is Nothing Then
            Return False
        Else
            Return Equals(objAsPart)
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return pkey
    End Function


    Public Overloads Function Equals(bucak As CLASSBUCAK) As Boolean _
        Implements IEquatable(Of CLASSBUCAK).Equals
        If bucak Is Nothing Then
            Return False
        End If
        Return (Me.pkey.Equals(bucak.pkey))
    End Function


End Class
