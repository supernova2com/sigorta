Public Partial Class bos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = aractarife_erisim.listele

    End Sub

End Class