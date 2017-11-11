Public Partial Class yardim
    Inherits System.Web.UI.Page


    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("yardim", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

    End Sub

End Class