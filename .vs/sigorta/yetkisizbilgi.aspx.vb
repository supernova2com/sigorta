Public Partial Class yetkisizbilgi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("webuye_pkey")) = False Then
            'Response.Redirect("bilgiyonetimgiris.aspx")
        End If

    End Sub

End Class