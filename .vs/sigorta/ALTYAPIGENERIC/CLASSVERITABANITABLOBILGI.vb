Public Class CLASSVERITABANITABLOBILGI


    Private COLUMN_NAME_v As String
    Private DATA_TYPE_v As String
    Private CHARACTER_MAXIMUM_LENGTH_v As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal COLUMN_NAME As String, ByVal DATA_TYPE As String, _
                   ByVal CHARACTER_MAXIMUM_LENGTH As String)

        Me.COLUMN_NAME = COLUMN_NAME
        Me.DATA_TYPE = DATA_TYPE
        Me.CHARACTER_MAXIMUM_LENGTH = CHARACTER_MAXIMUM_LENGTH

    End Sub

    Public Property COLUMN_NAME() As String
        Get
            Return COLUMN_NAME_v
        End Get
        Set(ByVal value As String)
            COLUMN_NAME_v = value
        End Set
    End Property

    Public Property DATA_TYPE() As String
        Get
            Return DATA_TYPE_v
        End Get
        Set(ByVal value As String)
            DATA_TYPE_v = value
        End Set
    End Property


    Public Property CHARACTER_MAXIMUM_LENGTH() As String
        Get
            Return CHARACTER_MAXIMUM_LENGTH_v
        End Get
        Set(ByVal value As String)
            CHARACTER_MAXIMUM_LENGTH_v = value
        End Set
    End Property


End Class
