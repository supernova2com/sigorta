Public Partial Class genericservis_ajax
    Inherits System.Web.UI.Page


    'genericservis tablo GÖSTER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericservistablogoster(ByVal genericservispkey As String) As String
        Dim donecek As String

        Dim genericservistablo_erisim As New CLASSGENERICSERVISTABLO_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("genericservispkey") = genericservispkey
        donecek = genericservistablo_erisim.listele()

        Return donecek
    End Function


    'genericservis INPUT GÖSTER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericservisinputgoster(ByVal genericservispkey As String) As String
        Dim donecek As String

        Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("genericservispkey") = genericservispkey
        donecek = genericservisinput_erisim.listele()

        Return donecek
    End Function

    'genericservis OUTPUT GÖSTER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericservisoutputgoster(ByVal genericservispkey As String) As String
        Dim donecek As String

        Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("genericservispkey") = genericservispkey
        donecek = genericservisoutput_erisim.listele()

        Return donecek
    End Function
  

    'genericservis KULLANICI GÖSTER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericserviskullanicigoster(ByVal genericservispkey As String) As String
        Dim donecek As String

        Dim genericserviskullanici_erisim As New CLASSGENERICSERVISKULLANICI_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("genericservispkey") = genericservispkey
        donecek = genericserviskullanici_erisim.listele()

        Return donecek
    End Function

 
    'SİLMELER ----------------------------------------------------------------------------
    'genericservis tablo sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericservistablosil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim genericservistablo_erisim As New CLASSGENERICSERVISTABLO_ERISIM
        result = genericservistablo_erisim.Sil(pkey)
        Return result

    End Function

    'genericservisinput sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericservisinputsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim genericservisinput_erisim As New CLASSGENERICSERVISINPUT_ERISIM
        result = genericservisinput_erisim.Sil(pkey)
        Return result

    End Function

    'genericservis output sil --------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericservisoutputsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim genericservisoutput_erisim As New CLASSGENERICSERVISOUTPUT_ERISIM
        result = genericservisoutput_erisim.Sil(pkey)
        Return result

    End Function

    'genericservis kullanici sil--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function genericserviskullanicisil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim genericserviskullanici_erisim As New CLASSGENERICSERVISKULLANICI_ERISIM
        result = genericserviskullanici_erisim.Sil(pkey)
        Return result

    End Function



    'GENERIC SERVİS BİLGİLERİNİ BUL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Function bultek_genericservis(ByVal genericservispkey As String) As CLASSGENERICSERVIS

        Dim genericservis As New CLASSGENERICSERVIS
        Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM
        genericservis = genericservis_erisim.bultek(genericservispkey)
        Return genericservis

    End Function




    'VTABLO 
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bul_vtablo(ByVal tabload As String) As CLASSVTABLO

        Dim vtablo As New CLASSVTABLO
        Dim vtablo_erisim As New CLASSVTABLO_ERISIM
        vtablo = vtablo_erisim.bultabloadagore(tabload)
        Return vtablo

    End Function

    'VKOLON
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bul_vkolon(ByVal tabload As String, ByVal kolonad As String) As CLASSVKOLON

        Dim vkolon As New CLASSVKOLON
        Dim vkolon_erisim As New CLASSVKOLON_ERISIM
        vkolon = vkolon_erisim.bultablovekolonadagore(tabload, kolonad)
        Return vkolon

    End Function







End Class