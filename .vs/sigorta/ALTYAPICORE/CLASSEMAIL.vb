Public Class CLASSEMAIL

    Private kime_v As String
    Private kimden_v As String
    Private subject_v As String
    Private body_v As String
    Private attachmentfile_v As String


    Public Property kime() As String
        Get
            Return kime_v
        End Get
        Set(ByVal value As String)
            kime_v = value
        End Set
    End Property


    Public Property kimden() As String
        Get
            Return kimden_v
        End Get
        Set(ByVal value As String)
            kimden_v = value
        End Set
    End Property

    Public Property subject() As String
        Get
            Return subject_v
        End Get
        Set(ByVal value As String)
            subject_v = value
        End Set
    End Property

    Public Property body() As String
        Get
            Return body_v
        End Get
        Set(ByVal value As String)
            body_v = value
        End Set
    End Property

    Public Property attachmentfile() As String
        Get
            Return attachmentfile_v
        End Get
        Set(ByVal value As String)
            attachmentfile_v = value
        End Set
    End Property


End Class
