Public Partial Class logoutbilgi
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("webuye_pkey") = ""
        Session("webuye_sirketpkey") = ""
        Session("webuye_uyetip") = ""
        Session("webuye_adsoyad") = ""
        Session("webuye_rolpkey") = ""
        Response.Redirect("bilgiyonetimgiris.aspx")

    End Sub


End Class