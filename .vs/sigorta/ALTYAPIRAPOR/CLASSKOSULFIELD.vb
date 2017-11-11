Public Class CLASSKOSULFIELD

    Private pkey_v As Integer
    Private raporpkey_v As Integer
    Private fieldad_v As String
    Private sira_v As Integer
    Private runtime_v As String
    Private kosulop_v As String
    Private deger_v As String
    Private bagmantikop_v As String
    Private fieldtype_v As String
    Private kosultabload_v As String
    Private kullanilacaktablopkey_v As Integer
    Private arabirimlabel_v As String
    Private arabirimtip_v As String
    Private dropdownlistpkey_v As Integer
    Private kosulgrupno_v As Integer
    Private grupmantikop_v As String
    Private sezonad_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal raporpkey As Integer, ByVal fieldad As String, _
    ByVal sira As Integer, ByVal runtime As String, ByVal kosulop As String, _
    ByVal deger As String, ByVal bagmantikop As String, ByVal fieldtype As String, _
    ByVal kosultabload As String, ByVal kullanilacaktablopkey As Integer, ByVal arabirimlabel As String, _
    ByVal arabirimtip As String, ByVal dropdownlistpkey As Integer, _
    ByVal kosulgrupno As Integer, ByVal grupmantikop As String, ByVal sezonad As String)


        Me.pkey = pkey
        Me.raporpkey = raporpkey
        Me.fieldad = fieldad
        Me.sira = sira
        Me.runtime = runtime
        Me.kosulop = kosulop
        Me.deger = deger
        Me.bagmantikop = bagmantikop
        Me.fieldtype = fieldtype
        Me.kosultabload = kosultabload
        Me.kullanilacaktablopkey = kullanilacaktablopkey
        Me.arabirimlabel = arabirimlabel
        Me.arabirimtip = arabirimtip
        Me.dropdownlistpkey = dropdownlistpkey
        Me.kosulgrupno = kosulgrupno
        Me.grupmantikop = grupmantikop
        Me.sezonad = sezonad


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property raporpkey() As Integer
        Get
            Return raporpkey_v
        End Get
        Set(ByVal value As Integer)
            raporpkey_v = value
        End Set
    End Property


    Public Property fieldad() As String
        Get
            Return fieldad_v
        End Get
        Set(ByVal value As String)
            fieldad_v = value
        End Set
    End Property


    Public Property sira() As Integer
        Get
            Return sira_v
        End Get
        Set(ByVal value As Integer)
            sira_v = value
        End Set
    End Property


    Public Property runtime() As String
        Get
            Return runtime_v
        End Get
        Set(ByVal value As String)
            runtime_v = value
        End Set
    End Property


    Public Property kosulop() As String
        Get
            Return kosulop_v
        End Get
        Set(ByVal value As String)
            kosulop_v = value
        End Set
    End Property


    Public Property deger() As String
        Get
            Return deger_v
        End Get
        Set(ByVal value As String)
            deger_v = value
        End Set
    End Property


    Public Property bagmantikop() As String
        Get
            Return bagmantikop_v
        End Get
        Set(ByVal value As String)
            bagmantikop_v = value
        End Set
    End Property


    Public Property fieldtype() As String
        Get
            Return fieldtype_v
        End Get
        Set(ByVal value As String)
            fieldtype_v = value
        End Set
    End Property


    Public Property kosultabload() As String
        Get
            Return kosultabload_v
        End Get
        Set(ByVal value As String)
            kosultabload_v = value
        End Set
    End Property


    Public Property kullanilacaktablopkey() As Integer
        Get
            Return kullanilacaktablopkey_v
        End Get
        Set(ByVal value As Integer)
            kullanilacaktablopkey_v = value
        End Set
    End Property


    Public Property arabirimlabel() As String
        Get
            Return arabirimlabel_v
        End Get
        Set(ByVal value As String)
            arabirimlabel_v = value
        End Set
    End Property


    Public Property arabirimtip() As String
        Get
            Return arabirimtip_v
        End Get
        Set(ByVal value As String)
            arabirimtip_v = value
        End Set
    End Property


    Public Property dropdownlistpkey() As Integer
        Get
            Return dropdownlistpkey_v
        End Get
        Set(ByVal value As Integer)
            dropdownlistpkey_v = value
        End Set
    End Property


    Public Property kosulgrupno() As Integer
        Get
            Return kosulgrupno_v
        End Get
        Set(ByVal value As Integer)
            kosulgrupno_v = value
        End Set
    End Property


    Public Property grupmantikop() As String
        Get
            Return grupmantikop_v
        End Get
        Set(ByVal value As String)
            grupmantikop_v = value
        End Set
    End Property

    Public Property sezonad() As String
        Get
            Return sezonad_v
        End Get
        Set(ByVal value As String)
            sezonad_v = value
        End Set
    End Property



End Class
