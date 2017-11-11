Public Class CLASSVERITABANIALAN


    Private pkey_v As Integer
    Private ad_v As String
    Private veritabaniad_v As String
    Private tabload_v As String
    Private ekstrakolonad_v As String
    Private sqlstatement_v As String
    Private querystrvarmi_v As String
    Private queryparameter1_v As String
    Private queryparameter2_v As String
    Private veristil_v As String


    Public Sub New()

    End Sub
    Public Sub New(ByVal pkey As Integer, ByVal ad As String, _
                   ByVal veritabaniad As String, ByVal tabload As String, _
                   ByVal ekstrakolonad As String, ByVal sqlstatement As String, _
                   ByVal querystrvarmi As String, ByVal queryparameter1 As String, _
                   ByVal queryparameter2 As String, ByVal veristil As String)

        Me.pkey = pkey
        Me.ad = ad
        Me.veritabaniad = veritabaniad
        Me.tabload = tabload
        Me.ekstrakolonad = ekstrakolonad
        Me.sqlstatement = sqlstatement
        Me.querystrvarmi = querystrvarmi
        Me.queryparameter1 = queryparameter1
        Me.queryparameter2 = queryparameter2
        Me.veristil = veristil

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property ad() As String
        Get
            Return ad_v
        End Get
        Set(ByVal value As String)
            ad_v = value
        End Set
    End Property


    Public Property veritabaniad() As String
        Get
            Return veritabaniad_v
        End Get
        Set(ByVal value As String)
            veritabaniad_v = value
        End Set
    End Property


    Public Property tabload() As String
        Get
            Return tabload_v
        End Get
        Set(ByVal value As String)
            tabload_v = value
        End Set
    End Property

    Public Property ekstrakolonad() As String
        Get
            Return ekstrakolonad_v
        End Get
        Set(ByVal value As String)
            ekstrakolonad_v = value
        End Set
    End Property

    Public Property sqlstatement() As String
        Get
            Return sqlstatement_v
        End Get
        Set(ByVal value As String)
            sqlstatement_v = value
        End Set
    End Property

    Public Property querystrvarmi() As String
        Get
            Return querystrvarmi_v
        End Get
        Set(ByVal value As String)
            querystrvarmi_v = value
        End Set
    End Property

    Public Property queryparameter1() As String
        Get
            Return queryparameter1_v
        End Get
        Set(ByVal value As String)
            queryparameter1_v = value
        End Set
    End Property

    Public Property queryparameter2() As String
        Get
            Return queryparameter2_v
        End Get
        Set(ByVal value As String)
            queryparameter2_v = value
        End Set
    End Property

    Public Property veristil() As String
        Get
            Return veristil_v
        End Get
        Set(ByVal value As String)
            veristil_v = value
        End Set
    End Property

  

End Class
