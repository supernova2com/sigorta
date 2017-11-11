Public Partial Class defaultacente
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("pano", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            'doğru yönlendir
            Dim kullanicirol As New CLASSKULLANICIROL
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
            kullanicirol = kullanicirol_erisim.bultek(Session("kullanici_rolpkey"))
            If InStr(HttpContext.Current.Request.Url.AbsolutePath, kullanicirol.yonsayfa, 0) <= 0 Then
                Response.Redirect(kullanicirol.yonsayfa)
            End If

            Label1.Text = "Merhaba " + Session("kullanici_adsoyad")

        End If

    End Sub



End Class