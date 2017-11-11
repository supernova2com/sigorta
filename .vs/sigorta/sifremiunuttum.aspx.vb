Public Partial Class sifremiunuttum
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Labelcopyright.Text = site.copyrighttext
        End If
    End Sub

End Class