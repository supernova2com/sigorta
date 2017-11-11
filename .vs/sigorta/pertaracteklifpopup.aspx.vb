Public Partial Class pertaracteklifpopup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim pertaracpkey As String
            pertaracpkey = Request.QueryString("pertaracpkey")

            If IsNumeric(pertaracpkey) = True Then
                Dim teklif_erisim As New CLASSTEKLIF_ERISIM

                HttpContext.Current.Session("ltip") = "aracin"
                HttpContext.Current.Session("pertaracpkey") = pertaracpkey
                Label1.Text = teklif_erisim.listele_puretable()

            End If

        End If

    End Sub

End Class