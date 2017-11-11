Public Class CLASSSINIRKAPI

    Private pkey_v As Integer
    Private sinirkapiad_v As String
    Private sinirkapikod_v As String
    Private ipdikkat_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sinirkapiad As String, ByVal sinirkapikod As String, _
    ByVal ipdikkat As String)


        Me.pkey = pkey
        Me.sinirkapiad = sinirkapiad
        Me.sinirkapikod = sinirkapikod
        Me.ipdikkat = ipdikkat


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sinirkapiad() As String
        Get
            Return sinirkapiad_v
        End Get
        Set(ByVal value As String)
            sinirkapiad_v = value
        End Set
    End Property


    Public Property sinirkapikod() As String
        Get
            Return sinirkapikod_v
        End Get
        Set(ByVal value As String)
            sinirkapikod_v = value
        End Set
    End Property

    Public Property ipdikkat() As String
        Get
            Return ipdikkat_v
        End Get
        Set(ByVal value As String)
            ipdikkat_v = value
        End Set
    End Property



End Class
