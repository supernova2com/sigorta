Public Partial Class takvimservis
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function doldurhepsi() As List(Of CLASSTAKVIM)

        Dim tumu As New List(Of CLASSTAKVIM)
        Dim logservisler As New List(Of CLASSTAKVIM)
        Dim loggeneller As New List(Of CLASSLOGGENEL)

        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM

        Dim baslangictarih As Date
        Dim bitistarih As Date

        baslangictarih = Date.Now.AddDays(-30)
        bitistarih = Date.Now.AddDays(1)

        logservisler = logservis_erisim.doldurtakvim(baslangictarih, bitistarih)
        tumu.AddRange(logservisler)
        'tumu.AddRange(aracservistakvimler)
        Return tumu

    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function takvimbilgi(ByVal tarih As String, ByVal tip As String) As String

        Dim donecek As String
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        HttpContext.Current.Session("tarih") = tarih
        HttpContext.Current.Session("tip") = tip

        donecek = logservis_erisim.listeletakvimicin()
        Return donecek

    End Function


End Class