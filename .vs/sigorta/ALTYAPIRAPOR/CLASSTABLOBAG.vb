Public Class CLASSTABLOBAG

    Private pkey_v As Integer
    Private tabload1_v As String
    Private tablofield1_v As String
    Private tabload2_v As String
    Private tablofield2_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tabload1 As String, ByVal tablofield1 As String, _
    ByVal tabload2 As String, ByVal tablofield2 As String)


        Me.pkey = pkey
        Me.tabload1 = tabload1
        Me.tablofield1 = tablofield1
        Me.tabload2 = tabload2
        Me.tablofield2 = tablofield2

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property tabload1() As String
        Get
            Return tabload1_v
        End Get
        Set(ByVal value As String)
            tabload1_v = value
        End Set
    End Property


    Public Property tablofield1() As String
        Get
            Return tablofield1_v
        End Get
        Set(ByVal value As String)
            tablofield1_v = value
        End Set
    End Property


    Public Property tabload2() As String
        Get
            Return tabload2_v
        End Get
        Set(ByVal value As String)
            tabload2_v = value
        End Set
    End Property


    Public Property tablofield2() As String
        Get
            Return tablofield2_v
        End Get
        Set(ByVal value As String)
            tablofield2_v = value
        End Set
    End Property


End Class
