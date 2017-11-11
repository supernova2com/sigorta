Public Partial Class headerbilgi
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNumeric(Session("webuye_pkey")) = False Then
            Response.Redirect("bilgiyonetimgiris.aspx")
        End If

        'login kontrol
        If IsNumeric(Session("webuye_pkey")) = True Then
            Literalloginkullaniciad.Text = Session("webuye_adsoyad")
            Dim menu2_Erisim As New CLASSMENU2_ERISIM
            Literalmenu.Text = menu2_Erisim.menuyuolustur
        End If

    End Sub

End Class