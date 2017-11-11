Public Class CLASSACENTE

    Private pkey_v As Integer
    Private acentead_v As String
    Private sicilno_v As String
    Private aktifmi_v As String
    Private merkezmi_v As String
    Private yetkiadsoyad_v As String
    Private yetkikimlikno_v As String
    Private yetkiceptel_v As String
    Private yetkiemail_v As String
    Private tel_v As String
    Private fax_v As String
    Private ekleyenkullanicipkey_v As Integer
    Private eklenmetarih_v As DateTime
    Private guncelleyenkullanicipkey_v As Integer
    Private guncellenmetarih_v As DateTime
    Private acentetippkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal acentead As String, ByVal sicilno As String, _
    ByVal aktifmi As String, ByVal merkezmi As String, ByVal yetkiadsoyad As String, _
    ByVal yetkikimlikno As String, ByVal yetkiceptel As String, ByVal yetkiemail As String, _
    ByVal tel As String, ByVal fax As String, ByVal ekleyenkullanicipkey As Integer, _
    ByVal eklenmetarih As DateTime, ByVal guncelleyenkullanicipkey As Integer, ByVal guncellenmetarih As DateTime, _
    ByVal acentetippkey As Integer)


        Me.pkey = pkey
        Me.acentead = acentead
        Me.sicilno = sicilno
        Me.aktifmi = aktifmi
        Me.merkezmi = merkezmi
        Me.yetkiadsoyad = yetkiadsoyad
        Me.yetkikimlikno = yetkikimlikno
        Me.yetkiceptel = yetkiceptel
        Me.yetkiemail = yetkiemail
        Me.tel = tel
        Me.fax = fax
        Me.ekleyenkullanicipkey = ekleyenkullanicipkey
        Me.eklenmetarih = eklenmetarih
        Me.guncelleyenkullanicipkey = guncelleyenkullanicipkey
        Me.guncellenmetarih = guncellenmetarih
        Me.acentetippkey = acentetippkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property acentead() As String
        Get
            Return acentead_v
        End Get
        Set(ByVal value As String)
            acentead_v = value
        End Set
    End Property


    Public Property sicilno() As String
        Get
            Return sicilno_v
        End Get
        Set(ByVal value As String)
            sicilno_v = value
        End Set
    End Property


    Public Property aktifmi() As String
        Get
            Return aktifmi_v
        End Get
        Set(ByVal value As String)
            aktifmi_v = value
        End Set
    End Property


    Public Property merkezmi() As String
        Get
            Return merkezmi_v
        End Get
        Set(ByVal value As String)
            merkezmi_v = value
        End Set
    End Property


    Public Property yetkiadsoyad() As String
        Get
            Return yetkiadsoyad_v
        End Get
        Set(ByVal value As String)
            yetkiadsoyad_v = value
        End Set
    End Property


    Public Property yetkikimlikno() As String
        Get
            Return yetkikimlikno_v
        End Get
        Set(ByVal value As String)
            yetkikimlikno_v = value
        End Set
    End Property


    Public Property yetkiceptel() As String
        Get
            Return yetkiceptel_v
        End Get
        Set(ByVal value As String)
            yetkiceptel_v = value
        End Set
    End Property


    Public Property yetkiemail() As String
        Get
            Return yetkiemail_v
        End Get
        Set(ByVal value As String)
            yetkiemail_v = value
        End Set
    End Property


    Public Property tel() As String
        Get
            Return tel_v
        End Get
        Set(ByVal value As String)
            tel_v = value
        End Set
    End Property


    Public Property fax() As String
        Get
            Return fax_v
        End Get
        Set(ByVal value As String)
            fax_v = value
        End Set
    End Property


    Public Property ekleyenkullanicipkey() As Integer
        Get
            Return ekleyenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            ekleyenkullanicipkey_v = value
        End Set
    End Property


    Public Property eklenmetarih() As Nullable(Of DateTime)
        Get
            Return eklenmetarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            eklenmetarih_v = value
        End Set
    End Property


    Public Property guncelleyenkullanicipkey() As Integer
        Get
            Return guncelleyenkullanicipkey_v
        End Get
        Set(ByVal value As Integer)
            guncelleyenkullanicipkey_v = value
        End Set
    End Property


    Public Property guncellenmetarih() As Nullable(Of DateTime)
        Get
            Return guncellenmetarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            guncellenmetarih_v = value
        End Set
    End Property


    Public Property acentetippkey() As Integer
        Get
            Return acentetippkey_v
        End Get
        Set(ByVal value As Integer)
            acentetippkey_v = value
        End Set
    End Property


End Class
