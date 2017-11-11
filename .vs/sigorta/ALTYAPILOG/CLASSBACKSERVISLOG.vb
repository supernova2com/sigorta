Public Class CLASSBACKSERVISLOG

    Private pkey_v As Integer
    Private soncalistarih_v As DateTime
    Private dinamikkullanicibagpkey_v As Integer
    Private remindersettingpkey_v As Integer
    Private ne_v As String
    Private calismasure_v As Decimal
    Private bitistarih_v As DateTime
    Private yontem_v As String
    Private emaildurum_v As String
    Private emailhatatxt_v As String
    Private emailetkilenen_v As Integer
    Private gonderilenkullanicipkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal soncalistarih As DateTime, ByVal dinamikkullanicibagpkey As Integer, _
    ByVal remindersettingpkey As Integer, ByVal ne As String, ByVal calismasure As Decimal, _
    ByVal bitistarih As DateTime, ByVal yontem As String, ByVal emaildurum As String, _
    ByVal emailhatatxt As String, ByVal emailetkilenen As Integer, ByVal gonderilenkullanicipkey As Integer)


        Me.pkey = pkey
        Me.soncalistarih = soncalistarih
        Me.dinamikkullanicibagpkey = dinamikkullanicibagpkey
        Me.remindersettingpkey = remindersettingpkey
        Me.ne = ne
        Me.calismasure = calismasure
        Me.bitistarih = bitistarih
        Me.yontem = yontem
        Me.emaildurum = emaildurum
        Me.emailhatatxt = emailhatatxt
        Me.emailetkilenen = emailetkilenen
        Me.gonderilenkullanicipkey = gonderilenkullanicipkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property soncalistarih() As Nullable(Of DateTime)
        Get
            Return soncalistarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            soncalistarih_v = value
        End Set
    End Property


    Public Property dinamikkullanicibagpkey() As Integer
        Get
            Return dinamikkullanicibagpkey_v
        End Get
        Set(ByVal value As Integer)
            dinamikkullanicibagpkey_v = value
        End Set
    End Property


    Public Property remindersettingpkey() As Integer
        Get
            Return remindersettingpkey_v
        End Get
        Set(ByVal value As Integer)
            remindersettingpkey_v = value
        End Set
    End Property


    Public Property ne() As String
        Get
            Return ne_v
        End Get
        Set(ByVal value As String)
            ne_v = value
        End Set
    End Property


    Public Property calismasure() As Decimal
        Get
            Return calismasure_v
        End Get
        Set(ByVal value As Decimal)
            calismasure_v = value
        End Set
    End Property


    Public Property bitistarih() As Nullable(Of DateTime)
        Get
            Return bitistarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            bitistarih_v = value
        End Set
    End Property


    Public Property yontem() As String
        Get
            Return yontem_v
        End Get
        Set(ByVal value As String)
            yontem_v = value
        End Set
    End Property


    Public Property emaildurum() As String
        Get
            Return emaildurum_v
        End Get
        Set(ByVal value As String)
            emaildurum_v = value
        End Set
    End Property


    Public Property emailhatatxt() As String
        Get
            Return emailhatatxt_v
        End Get
        Set(ByVal value As String)
            emailhatatxt_v = value
        End Set
    End Property


    Public Property emailetkilenen() As Integer
        Get
            Return emailetkilenen_v
        End Get
        Set(ByVal value As Integer)
            emailetkilenen_v = value
        End Set
    End Property


    Public Property gonderilenkullanicipkey() As Integer
        Get
            Return gonderilenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            gonderilenkullanicipkey_v = value
        End Set
    End Property


End Class
