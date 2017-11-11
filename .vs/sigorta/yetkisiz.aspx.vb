Public Partial Class yetkisiz
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim yonlenlink As String

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                Dim kullanicirol As New CLASSKULLANICIROL
                Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
                kullanicirol = kullanicirol_erisim.bultek(Session("kullanici_rolpkey"))
                yonlenlink = "<a href='" + kullanicirol.yonsayfa + "'>" + "Anasayfama Yönlendir" + "</a>"
                literalyonlenlink.Text = yonlenlink
            End If

     

        End If
    End Sub

End Class