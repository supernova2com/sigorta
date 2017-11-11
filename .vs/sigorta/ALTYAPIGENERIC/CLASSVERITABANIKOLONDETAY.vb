Public Class CLASSVERITABANIKOLONDETAY


    Private column_name_v As String
    Private data_type_v As String
    Private maxlen_v As String

    Public Sub New()

    End Sub
    Public Sub New(ByVal column_name As String, ByVal data_type As String, ByVal maxlen As String)

        Me.column_name = column_name
        Me.data_type = data_type
        Me.maxlen = maxlen

    End Sub

    Public Property column_name() As String
        Get
            Return column_name_v
        End Get
        Set(ByVal value As String)
            column_name_v = value
        End Set
    End Property

    Public Property data_type() As String
        Get
            Return data_type_v
        End Get
        Set(ByVal value As String)
            data_type_v = value
        End Set
    End Property

    Public Property maxlen() As String
        Get
            Return maxlen_v
        End Get
        Set(ByVal value As String)
            maxlen_v = value
        End Set
    End Property



End Class
