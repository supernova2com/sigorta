Public Partial Class dinamikmanuelcalistir
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim raporpkey As String
            raporpkey = Request.QueryString("raporpkey")
            Dim backservis_erisim As New CLASSBACKSERVISLOG_ERISIM
            backservis_erisim.raporla()

        End If
    End Sub

End Class