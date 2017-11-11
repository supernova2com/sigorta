Public Class CLASSSITE
    Private pkey_v As Integer
    Private url_v As String
    Private path_v As String
    Private yer_v As String
    Private temapkey_v As Integer
    Private musteriadsoyad_v As String
    Private musteriofistel_v As String
    Private mustericeptel_v As String
    Private musterifax_v As String
    Private musteriadres_v As String
    Private sistemveritabaniad_v As String
    Private musteriemail_v As String
    Private kullanimbaslangictarih_v As Date
    Private yanlissifrecount_v As Integer
    Private roltabload_v As String
    Private pgkullaniciad_v As String
    Private pgsifre_v As String
    Private captcha_v As String
    Private copyrighttext_v As String
    Private faturaodemesongun_v As Integer
    Private hataeposta_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal url As String, ByVal path As String, _
    ByVal yer As String, ByVal temapkey As Integer, ByVal musteriadsoyad As String, _
    ByVal musteriofistel As String, ByVal mustericeptel As String, ByVal musterifax As String, _
    ByVal musteriadres As String, ByVal sistemveritabaniad As String, ByVal musteriemail As String, _
    ByVal kullanimbaslangictarih As Date, ByVal yanlissifrecount As Integer, ByVal roltabload As String, _
    ByVal pgkullaniciad As String, ByVal pgsifre As String, ByVal captcha As String, _
    ByVal copyrighttext As String, ByVal faturaodemesongun As Integer, _
    ByVal hataeposta As String)


        Me.pkey = pkey
        Me.url = url
        Me.path = path
        Me.yer = yer
        Me.temapkey = temapkey
        Me.musteriadsoyad = musteriadsoyad
        Me.musteriofistel = musteriofistel
        Me.mustericeptel = mustericeptel
        Me.musterifax = musterifax
        Me.musteriadres = musteriadres
        Me.sistemveritabaniad = sistemveritabaniad
        Me.musteriemail = musteriemail
        Me.kullanimbaslangictarih = kullanimbaslangictarih
        Me.yanlissifrecount = yanlissifrecount
        Me.roltabload = roltabload
        Me.pgkullaniciad = pgkullaniciad
        Me.pgsifre = pgsifre
        Me.captcha = captcha
        Me.copyrighttext = copyrighttext
        Me.faturaodemesongun = faturaodemesongun
        Me.hataeposta = hataeposta


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property url() As String
        Get
            Return url_v
        End Get
        Set(ByVal value As String)
            url_v = value
        End Set
    End Property


    Public Property path() As String
        Get
            Return path_v
        End Get
        Set(ByVal value As String)
            path_v = value
        End Set
    End Property


    Public Property yer() As String
        Get
            Return yer_v
        End Get
        Set(ByVal value As String)
            yer_v = value
        End Set
    End Property


    Public Property temapkey() As Integer
        Get
            Return temapkey_v
        End Get
        Set(ByVal value As Integer)
            temapkey_v = value
        End Set
    End Property


    Public Property musteriadsoyad() As String
        Get
            Return musteriadsoyad_v
        End Get
        Set(ByVal value As String)
            musteriadsoyad_v = value
        End Set
    End Property


    Public Property musteriofistel() As String
        Get
            Return musteriofistel_v
        End Get
        Set(ByVal value As String)
            musteriofistel_v = value
        End Set
    End Property


    Public Property mustericeptel() As String
        Get
            Return mustericeptel_v
        End Get
        Set(ByVal value As String)
            mustericeptel_v = value
        End Set
    End Property


    Public Property musterifax() As String
        Get
            Return musterifax_v
        End Get
        Set(ByVal value As String)
            musterifax_v = value
        End Set
    End Property


    Public Property musteriadres() As String
        Get
            Return musteriadres_v
        End Get
        Set(ByVal value As String)
            musteriadres_v = value
        End Set
    End Property


    Public Property sistemveritabaniad() As String
        Get
            Return sistemveritabaniad_v
        End Get
        Set(ByVal value As String)
            sistemveritabaniad_v = value
        End Set
    End Property


    Public Property musteriemail() As String
        Get
            Return musteriemail_v
        End Get
        Set(ByVal value As String)
            musteriemail_v = value
        End Set
    End Property


    Public Property kullanimbaslangictarih() As Nullable(Of Date)
        Get
            Return kullanimbaslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of Date))
            kullanimbaslangictarih_v = value
        End Set
    End Property


    Public Property yanlissifrecount() As Integer
        Get
            Return yanlissifrecount_v
        End Get
        Set(ByVal value As Integer)
            yanlissifrecount_v = value
        End Set
    End Property


    Public Property roltabload() As String
        Get
            Return roltabload_v
        End Get
        Set(ByVal value As String)
            roltabload_v = value
        End Set
    End Property


    Public Property pgkullaniciad() As String
        Get
            Return pgkullaniciad_v
        End Get
        Set(ByVal value As String)
            pgkullaniciad_v = value
        End Set
    End Property


    Public Property pgsifre() As String
        Get
            Return pgsifre_v
        End Get
        Set(ByVal value As String)
            pgsifre_v = value
        End Set
    End Property


    Public Property captcha() As String
        Get
            Return captcha_v
        End Get
        Set(ByVal value As String)
            captcha_v = value
        End Set
    End Property


    Public Property copyrighttext() As String
        Get
            Return copyrighttext_v
        End Get
        Set(ByVal value As String)
            copyrighttext_v = value
        End Set
    End Property


    Public Property faturaodemesongun() As Integer
        Get
            Return faturaodemesongun_v
        End Get
        Set(ByVal value As Integer)
            faturaodemesongun_v = value
        End Set
    End Property


    Public Property hataeposta() As String
        Get
            Return hataeposta_v
        End Get
        Set(ByVal value As String)
            hataeposta_v = value
        End Set
    End Property


End Class
