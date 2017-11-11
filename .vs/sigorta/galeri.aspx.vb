Public Partial Class galeri
    Inherits System.Web.UI.Page

    Dim galeriana_erisim As New CLASSGALERIANA_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("galeri", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = galeriana_erisim.listele

        End If
    End Sub

End Class