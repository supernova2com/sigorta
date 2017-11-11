Public Class CLASSLOGSERVIS

    Private pkey_v As Integer
    Private tarih_v As DateTime
    Private sirketpkey_v As Integer
    Private servisad_v As String
    Private resultcode_v As Integer
    Private errorinfocode_v As Integer
    Private errorinfomessage_v As String
    Private insertedcnt_v As Integer
    Private updatedcnt_v As Integer
    Private p_FirmCode_v As String
    Private p_ProductCode_v As String
    Private p_AgencyCode_v As String
    Private p_PolicyNumber_v As String
    Private p_TecditNumber_v As String
    Private p_ZeylCode_v As String
    Private p_ZeylNo_v As String
    Private p_ProductType_v As String
    Private d_FirmCode_v As String
    Private d_ProductCode_v As String
    Private d_AgencyCode_v As String
    Private d_PolicyNumber_v As String
    Private d_TecditNumber_v As String
    Private d_FileNo_v As String
    Private d_RequestNo_v As String
    Private d_ProductType_v As String
    Private gonderilenxml_v As String
    Private wskullaniciad_v As String
    Private wssifre_v As String
    Private suphelimi_v As String
    Private suphelikod_v As Integer
    Private suphelimesaj_v As String
    Private getdamagelog_v As String
    Private hesaplog_v As String
    Private ipadres_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal tarih As DateTime, ByVal sirketpkey As Integer, _
    ByVal servisad As String, ByVal resultcode As Integer, ByVal errorinfocode As Integer, _
    ByVal errorinfomessage As String, ByVal insertedcnt As Integer, ByVal updatedcnt As Integer, _
    ByVal p_FirmCode As String, ByVal p_ProductCode As String, ByVal p_AgencyCode As String, _
    ByVal p_PolicyNumber As String, ByVal p_TecditNumber As String, ByVal p_ZeylCode As String, _
    ByVal p_ZeylNo As String, ByVal p_ProductType As String, ByVal d_FirmCode As String, _
    ByVal d_ProductCode As String, ByVal d_AgencyCode As String, ByVal d_PolicyNumber As String, _
    ByVal d_TecditNumber As String, ByVal d_FileNo As String, ByVal d_RequestNo As String, _
    ByVal d_ProductType As String, ByVal gonderilenxml As String, ByVal wskullaniciad As String, _
    ByVal wssifre As String, ByVal suphelimi As String, ByVal suphelikod As Integer, _
    ByVal suphelimesaj As String, ByVal getdamagelog As String, ByVal hesaplog As String, _
    ByVal ipadres As String)

        Me.pkey = pkey
        Me.tarih = tarih
        Me.sirketpkey = sirketpkey
        Me.servisad = servisad
        Me.resultcode = resultcode
        Me.errorinfocode = errorinfocode
        Me.errorinfomessage = errorinfomessage
        Me.insertedcnt = insertedcnt
        Me.updatedcnt = updatedcnt
        Me.p_FirmCode = p_FirmCode
        Me.p_ProductCode = p_ProductCode
        Me.p_AgencyCode = p_AgencyCode
        Me.p_PolicyNumber = p_PolicyNumber
        Me.p_TecditNumber = p_TecditNumber
        Me.p_ZeylCode = p_ZeylCode
        Me.p_ZeylNo = p_ZeylNo
        Me.p_ProductType = p_ProductType
        Me.d_FirmCode = d_FirmCode
        Me.d_ProductCode = d_ProductCode
        Me.d_AgencyCode = d_AgencyCode
        Me.d_PolicyNumber = d_PolicyNumber
        Me.d_TecditNumber = d_TecditNumber
        Me.d_FileNo = d_FileNo
        Me.d_RequestNo = d_RequestNo
        Me.d_ProductType = d_ProductType
        Me.gonderilenxml = gonderilenxml
        Me.wskullaniciad = wskullaniciad
        Me.wssifre = wssifre
        Me.suphelimi = suphelimi
        Me.suphelikod = suphelikod
        Me.suphelimesaj = suphelimesaj
        Me.getdamagelog = getdamagelog
        Me.hesaplog = hesaplog
        Me.ipadres = ipadres



    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property tarih() As Nullable(Of DateTime)
        Get
            Return tarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            tarih_v = value
        End Set
    End Property


    Public Property sirketpkey() As Integer
        Get
            Return sirketpkey_v
        End Get
        Set(ByVal value As Integer)
            sirketpkey_v = value
        End Set
    End Property


    Public Property servisad() As String
        Get
            Return servisad_v
        End Get
        Set(ByVal value As String)
            servisad_v = value
        End Set
    End Property


    Public Property resultcode() As Integer
        Get
            Return resultcode_v
        End Get
        Set(ByVal value As Integer)
            resultcode_v = value
        End Set
    End Property


    Public Property errorinfocode() As Integer
        Get
            Return errorinfocode_v
        End Get
        Set(ByVal value As Integer)
            errorinfocode_v = value
        End Set
    End Property


    Public Property errorinfomessage() As String
        Get
            Return errorinfomessage_v
        End Get
        Set(ByVal value As String)
            errorinfomessage_v = value
        End Set
    End Property


    Public Property insertedcnt() As Integer
        Get
            Return insertedcnt_v
        End Get
        Set(ByVal value As Integer)
            insertedcnt_v = value
        End Set
    End Property


    Public Property updatedcnt() As Integer
        Get
            Return updatedcnt_v
        End Get
        Set(ByVal value As Integer)
            updatedcnt_v = value
        End Set
    End Property


    Public Property p_FirmCode() As String
        Get
            Return p_FirmCode_v
        End Get
        Set(ByVal value As String)
            p_FirmCode_v = value
        End Set
    End Property


    Public Property p_ProductCode() As String
        Get
            Return p_ProductCode_v
        End Get
        Set(ByVal value As String)
            p_ProductCode_v = value
        End Set
    End Property


    Public Property p_AgencyCode() As String
        Get
            Return p_AgencyCode_v
        End Get
        Set(ByVal value As String)
            p_AgencyCode_v = value
        End Set
    End Property


    Public Property p_PolicyNumber() As String
        Get
            Return p_PolicyNumber_v
        End Get
        Set(ByVal value As String)
            p_PolicyNumber_v = value
        End Set
    End Property


    Public Property p_TecditNumber() As String
        Get
            Return p_TecditNumber_v
        End Get
        Set(ByVal value As String)
            p_TecditNumber_v = value
        End Set
    End Property


    Public Property p_ZeylCode() As String
        Get
            Return p_ZeylCode_v
        End Get
        Set(ByVal value As String)
            p_ZeylCode_v = value
        End Set
    End Property


    Public Property p_ZeylNo() As String
        Get
            Return p_ZeylNo_v
        End Get
        Set(ByVal value As String)
            p_ZeylNo_v = value
        End Set
    End Property


    Public Property p_ProductType() As String
        Get
            Return p_ProductType_v
        End Get
        Set(ByVal value As String)
            p_ProductType_v = value
        End Set
    End Property


    Public Property d_FirmCode() As String
        Get
            Return d_FirmCode_v
        End Get
        Set(ByVal value As String)
            d_FirmCode_v = value
        End Set
    End Property


    Public Property d_ProductCode() As String
        Get
            Return d_ProductCode_v
        End Get
        Set(ByVal value As String)
            d_ProductCode_v = value
        End Set
    End Property


    Public Property d_AgencyCode() As String
        Get
            Return d_AgencyCode_v
        End Get
        Set(ByVal value As String)
            d_AgencyCode_v = value
        End Set
    End Property


    Public Property d_PolicyNumber() As String
        Get
            Return d_PolicyNumber_v
        End Get
        Set(ByVal value As String)
            d_PolicyNumber_v = value
        End Set
    End Property


    Public Property d_TecditNumber() As String
        Get
            Return d_TecditNumber_v
        End Get
        Set(ByVal value As String)
            d_TecditNumber_v = value
        End Set
    End Property


    Public Property d_FileNo() As String
        Get
            Return d_FileNo_v
        End Get
        Set(ByVal value As String)
            d_FileNo_v = value
        End Set
    End Property


    Public Property d_RequestNo() As String
        Get
            Return d_RequestNo_v
        End Get
        Set(ByVal value As String)
            d_RequestNo_v = value
        End Set
    End Property

    Public Property d_ProductType() As String
        Get
            Return d_ProductType_v
        End Get
        Set(ByVal value As String)
            d_ProductType_v = value
        End Set
    End Property


    Public Property gonderilenxml() As String
        Get
            Return gonderilenxml_v
        End Get
        Set(ByVal value As String)
            gonderilenxml_v = value
        End Set
    End Property

    Public Property wskullaniciad() As String
        Get
            Return wskullaniciad_v
        End Get
        Set(ByVal value As String)
            wskullaniciad_v = value
        End Set
    End Property


    Public Property wssifre() As String
        Get
            Return wssifre_v
        End Get
        Set(ByVal value As String)
            wssifre_v = value
        End Set
    End Property

    Public Property suphelimi() As String
        Get
            Return suphelimi_v
        End Get
        Set(ByVal value As String)
            suphelimi_v = value
        End Set
    End Property

    Public Property suphelikod() As Integer
        Get
            Return suphelikod_v
        End Get
        Set(ByVal value As Integer)
            suphelikod_v = value
        End Set
    End Property

    Public Property suphelimesaj() As String
        Get
            Return suphelimesaj_v
        End Get
        Set(ByVal value As String)
            suphelimesaj_v = value
        End Set
    End Property


    Public Property getdamagelog() As String
        Get
            Return getdamagelog_v
        End Get
        Set(ByVal value As String)
            getdamagelog_v = value
        End Set
    End Property


    Public Property hesaplog() As String
        Get
            Return hesaplog_v
        End Get
        Set(ByVal value As String)
            hesaplog_v = value
        End Set
    End Property


    Public Property ipadres() As String
        Get
            Return ipadres_v
        End Get
        Set(ByVal value As String)
            ipadres_v = value
        End Set
    End Property


End Class
