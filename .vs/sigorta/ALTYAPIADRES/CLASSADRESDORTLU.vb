Public Class CLASSADRESDORTLU


    Private ilcepkey_v As Integer
    Private bucakpkey_v As Integer
    Private belediyepkey_v As Integer
    Private mahallepkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal ilcepkey As Integer, ByVal bucakpkey As Integer, ByVal belediyepkey As Integer, _
    ByVal mahallepkey As Integer)

        Me.ilcepkey = ilcepkey
        Me.bucakpkey = bucakpkey
        Me.belediyepkey = belediyepkey
        Me.mahallepkey = mahallepkey


    End Sub

    Public Property ilcepkey() As Integer
        Get
            Return ilcepkey_v
        End Get
        Set(ByVal value As Integer)
            ilcepkey_v = value
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


    Public Property belediyepkey() As Integer
        Get
            Return belediyepkey_v
        End Get
        Set(ByVal value As Integer)
            belediyepkey_v = value
        End Set
    End Property


    Public Property mahallepkey() As Integer
        Get
            Return mahallepkey_v
        End Get
        Set(ByVal value As Integer)
            mahallepkey_v = value
        End Set
    End Property





End Class
