Public Class CLASSBELEDIYE

    Private pkey_v As Integer
    Private bucakpkey_v As Integer
    Private belediyead_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal bucakpkey As Integer, _
    ByVal belediyead As String)


        Me.pkey = pkey
        Me.bucakpkey = bucakpkey
        Me.belediyead = belediyead

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property bucakpkey() As Integer
        Get
            Return bucakpkey_v
        End Get
        Set(ByVal value As Integer)
            bucakpkey_v = value
        End Set
    End Property


    Public Property belediyead() As String
        Get
            Return belediyead_v
        End Get
        Set(ByVal value As String)
            belediyead_v = value
        End Set
    End Property


End Class
