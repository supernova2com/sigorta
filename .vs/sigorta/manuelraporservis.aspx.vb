Public Partial Class manuelraporservis
    Inherits System.Web.UI.Page


    'manuel rapor parametrelerini göster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function manuelraporparametregoster(ByVal manuelraporpkey As String) As String
        Dim donecek As String

        Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM

        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("manuelraporpkey") = manuelraporpkey
        donecek = manuelraporparametre_erisim.listele
        Return donecek

    End Function


    'manuel rapor kullanıcılarını göster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function manuelraporkullanicigoster(ByVal manuelraporpkey As String) As String
        Dim donecek As String

        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM

        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("manuelraporpkey") = manuelraporpkey
        donecek = manuelraporkullanici_erisim.listele
        Return donecek

    End Function


    'SİLMELER ----------------------------------------------------
    'manuel rapor parametre sil
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function manuelraporparametresil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim manuelraporparametre_erisim As New CLASSMANUELRAPORPARAMETRE_ERISIM
        result = manuelraporparametre_erisim.Sil(pkey)
        Return result

    End Function

    'manuel rapor kullanıcısını sil
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function manuelraporkullanicisil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim manuelraporkullanici_erisim As New CLASSMANUELRAPORKULLANICI_ERISIM
        result = manuelraporkullanici_erisim.Sil(pkey)
        Return result

    End Function





End Class