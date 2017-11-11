Public Partial Class adminheader2
    Inherits System.Web.UI.UserControl

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        Dim t As String
        Dim stylesheet As String

        t = "jquery-ui-1.10.4.custom.min.css"

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM

        site = site_erisim.bultek(1)

        Dim tema As New CLASSTEMA
        Dim bulunantema As New CLASSTEMA
        Dim tema_erisim As New CLASSTEMA_ERISIM
        tema.pkey = site.temapkey

        bulunantema = tema_erisim.bultek(site.temapkey)

        If bulunantema.kimin = "sistem" Then
            stylesheet = "../temalar/" + bulunantema.temaad + "/" + t
        End If

        If bulunantema.kimin = "custom" Then
            stylesheet = "../customtemalar/" + bulunantema.temaad + "/" + t
        End If

        Dim myHtmlLink As New HtmlLink()
        myHtmlLink.Href = stylesheet
        myHtmlLink.Attributes.Add("rel", "stylesheet")
        myHtmlLink.Attributes.Add("type", "text/css")
        Page.Header.Controls.Add(myHtmlLink)

    End Sub



End Class