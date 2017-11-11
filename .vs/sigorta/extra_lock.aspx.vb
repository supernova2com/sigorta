Public Partial Class extra_lock
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Labelcopyright.Text = site.copyrighttext

            If IsNumeric(HttpContext.Current.Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            End If

            Dim resim_erisim As New CLASSTEKRESIM_ERISIM

            Literaladsoyad.Text = Session("kullanici_adsoyad")
            Literalemail.Text = Session("kullanici_eposta")

            Dim adsoyaddegilmi As String
            adsoyaddegilmi = Session("kullanici_adsoyad") + " değilmisiniz?"
            Literaladsoyaddegilmi.Text = adsoyaddegilmi
            Labelimage.Text = resim_erisim.ekrankilitresimolustur(Session("kullanici_resimpkey"))

        End If
    End Sub

End Class