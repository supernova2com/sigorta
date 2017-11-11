Public Partial Class servislink
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim site_erisim As New CLASSSITE_ERISIM
            Dim site As New CLASSSITE
            Dim link As String

            site = site_erisim.bultek(1)
            link = site.path + "service.asmx"
            Response.Redirect(link)


        End If

    End Sub

End Class