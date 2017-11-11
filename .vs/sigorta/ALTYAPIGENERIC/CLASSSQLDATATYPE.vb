Imports System.Data.SqlClient


Public Class CLASSSQLDATATYPE

    Private sqltype_v As SqlDbType
    Private ilgiliad_v As String
    Private donenvisualbasictype_v As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal sqltype As SqlDbType, _
    ByVal ilgiliad As String, ByVal donenvisualbasictype As String)

        Me.sqltype = sqltype
        Me.ilgiliad = ilgiliad
        Me.donenvisualbasictype = donenvisualbasictype

    End Sub

    Public Property sqltype() As SqlDbType
        Get
            Return sqltype_v
        End Get
        Set(ByVal value As SqlDbType)
            sqltype_v = value
        End Set
    End Property

    Public Property ilgiliad() As String
        Get
            Return ilgiliad_v
        End Get
        Set(ByVal value As String)
            ilgiliad_v = value
        End Set
    End Property

    Public Property donenvisualbasictype() As String
        Get
            Return donenvisualbasictype_v
        End Get
        Set(ByVal value As String)
            donenvisualbasictype_v = value
        End Set
    End Property

End Class
