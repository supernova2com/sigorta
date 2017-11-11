Public Class CLASSMENU

    Private pkey_v As Integer
    Private baslik_v As String
    Private babaid_v As Integer
    Private sira_v As Integer
    Private tip_v As String
    Private anamenupkey_v As Integer
    Private iconclass_v As String
    Private anaclass_v As String
    Private idismi_v As String
    Private ekhtml_v As String
    Private link_v As String
    Private hakkolon_v As String
    Private baslikmi_v As String
    Private neredeacilsin_v As String
    Private modulpkey_v As Integer
    Private herzamangozuksunmu_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal baslik As String, ByVal babaid As Integer, _
    ByVal sira As Integer, ByVal tip As String, ByVal anamenupkey As Integer, _
    ByVal iconclass As String, ByVal anaclass As String, ByVal idismi As String, _
    ByVal ekhtml As String, ByVal link As String, ByVal hakkolon As String, _
    ByVal baslikmi As String, ByVal neredeacilsin As String, _
    ByVal modulpkey As Integer, ByVal herzamangozuksunmu As String)

        Me.pkey = pkey
        Me.baslik = baslik
        Me.babaid = babaid
        Me.sira = sira
        Me.tip = tip
        Me.anamenupkey = anamenupkey
        Me.iconclass = iconclass
        Me.anaclass = anaclass
        Me.idismi = idismi
        Me.ekhtml = ekhtml
        Me.link = link
        Me.hakkolon = hakkolon
        Me.baslikmi = baslikmi
        Me.neredeacilsin = neredeacilsin
        Me.modulpkey = modulpkey
        Me.herzamangozuksunmu = herzamangozuksunmu

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property baslik() As String
        Get
            Return baslik_v
        End Get
        Set(ByVal value As String)
            baslik_v = value
        End Set
    End Property


    Public Property babaid() As Integer
        Get
            Return babaid_v
        End Get
        Set(ByVal value As Integer)
            babaid_v = value
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


    Public Property tip() As String
        Get
            Return tip_v
        End Get
        Set(ByVal value As String)
            tip_v = value
        End Set
    End Property


    Public Property anamenupkey() As Integer
        Get
            Return anamenupkey_v
        End Get
        Set(ByVal value As Integer)
            anamenupkey_v = value
        End Set
    End Property


    Public Property iconclass() As String
        Get
            Return iconclass_v
        End Get
        Set(ByVal value As String)
            iconclass_v = value
        End Set
    End Property


    Public Property anaclass() As String
        Get
            Return anaclass_v
        End Get
        Set(ByVal value As String)
            anaclass_v = value
        End Set
    End Property


    Public Property idismi() As String
        Get
            Return idismi_v
        End Get
        Set(ByVal value As String)
            idismi_v = value
        End Set
    End Property


    Public Property ekhtml() As String
        Get
            Return ekhtml_v
        End Get
        Set(ByVal value As String)
            ekhtml_v = value
        End Set
    End Property


    Public Property link() As String
        Get
            Return link_v
        End Get
        Set(ByVal value As String)
            link_v = value
        End Set
    End Property


    Public Property hakkolon() As String
        Get
            Return hakkolon_v
        End Get
        Set(ByVal value As String)
            hakkolon_v = value
        End Set
    End Property


    Public Property baslikmi() As String
        Get
            Return baslikmi_v
        End Get
        Set(ByVal value As String)
            baslikmi_v = value
        End Set
    End Property


    Public Property neredeacilsin() As String
        Get
            Return neredeacilsin_v
        End Get
        Set(ByVal value As String)
            neredeacilsin_v = value
        End Set
    End Property


    Public Property modulpkey() As Integer
        Get
            Return modulpkey_v
        End Get
        Set(ByVal value As Integer)
            modulpkey_v = value
        End Set
    End Property

    Public Property herzamangozuksunmu() As String
        Get
            Return herzamangozuksunmu_v
        End Get
        Set(ByVal value As String)
            herzamangozuksunmu_v = value
        End Set
    End Property


End Class
