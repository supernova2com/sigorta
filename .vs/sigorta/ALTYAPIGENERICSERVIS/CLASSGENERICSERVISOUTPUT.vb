Public Class CLASSGENERICSERVISOUTPUT

    Private pkey_v As Integer
    Private genericservispkey_v As Integer
    Private outputparamname_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal genericservispkey As Integer, ByVal outputparamname As String)


        Me.pkey = pkey
        Me.genericservispkey = genericservispkey
        Me.outputparamname = outputparamname

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property genericservispkey() As Integer
        Get
            Return genericservispkey_v
        End Get
        Set(ByVal value As Integer)
            genericservispkey_v = value
        End Set
    End Property


    Public Property outputparamname() As String
        Get
            Return outputparamname_v
        End Get
        Set(ByVal value As String)
            outputparamname_v = value
        End Set
    End Property


End Class
