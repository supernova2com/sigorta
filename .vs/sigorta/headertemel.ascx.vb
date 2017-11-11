Public Partial Class headertemel
    Inherits System.Web.UI.UserControl

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Application("siteid") Is Nothing Then
            'Application("siteid") = "1"
            'Response.Redirect("yonetimgiris.aspx")
        End If

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
        'Label2.Text = "<a class=wbtn href=" + site.url + " title=Siteyi Görüntüle target=_blank><img src=images/preview-icon.png><span>Siteyi Görüntüle</span></a>"

        If bulunantema.kimin = "sistem" Then
            stylesheet = "/temalar/" + bulunantema.temaad + "/" + t
        End If

        If bulunantema.kimin = "custom" Then
            stylesheet = "/customtemalar/" + bulunantema.temaad + "/" + t
        End If

        Dim myHtmlLink As New HtmlLink()
        myHtmlLink.Href = stylesheet
        myHtmlLink.Attributes.Add("rel", "stylesheet")
        myHtmlLink.Attributes.Add("type", "text/css")
        Page.Header.Controls.Add(myHtmlLink)


        'Dim dosya_erisim As New CLASSDOSYA_ERISIM
        'Literal1.Text = "<a href='#'><span onclick='msggonder(" + CStr(Session("siteyoneticipkey")) + ")'>Yeni Mesaj</span></a> | " + _
        '"<a id='msgyaziust' href='mesajlarim.aspx'><span>Mesajlarım</span></a>"

        'Literal2.Text = dosya_erisim.dosyalarimyazisi(Session("siteyoneticipkey"))

    End Sub

End Class