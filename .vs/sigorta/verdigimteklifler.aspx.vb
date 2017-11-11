Public Partial Class verdigimteklifler
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'eğer paralı üye değilse teklif veremez.
            If Session("webuye_uyetip") <> "3" Then
                Response.Redirect("yetkisizbilgi.aspx")
            End If

            Dim teklif_erisim As New CLASSTEKLIF_ERISIM
            HttpContext.Current.Session("ltip") = "uyenin"
            Label1.Text = teklif_erisim.listele_uyenin()

        End If
    End Sub

End Class