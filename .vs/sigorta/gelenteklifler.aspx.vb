Public Partial Class gelenteklifler
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'eğer şirket admin değilse giremez
            If Session("webuye_uyetip") <> "2" Then
                Response.Redirect("yetkisizbilgi.aspx")
            End If

            Dim teklif_erisim As New CLASSTEKLIF_ERISIM
            HttpContext.Current.Session("ltip") = "sirketin"
            Label1.Text = teklif_erisim.listele_sirketin

        End If

    End Sub

End Class