Public Partial Class defaultbilgiadmin
    Inherits System.Web.UI.Page


    Dim webuye As New CLASSWEBUYE
    Dim webuye_erisim As New CLASSWEBUYE_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("webuye_uyetip") = "2" Then
            Response.Redirect("defaultbilgiuyeadmin.aspx")
        End If

        If Session("webuye_uyetip") = "3" Then
            Response.Redirect("pertaracliste.aspx")
        End If

        If Session("webuye_uyetip") <> "1" Then
            Response.Redirect("yetkisizbilgi.aspx")
        End If

        If Not Page.IsPostBack Then


            Dim webuye_erisim As New CLASSWEBUYE_ERISIM
            Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
            Dim oys_erisim As New CLASSOYS_ERISIM
            Dim oya_erisim As New CLASSOYA_ERISIM

            Literaltoplamuye.Text = webuye_erisim.toplamsayi("3").ToString("N0")
            Literaltoplampertarac.Text = pertarac_erisim.toplamsayi().ToString("N0")
            Literaltoplamoys.Text = oys_erisim.toplamsayi().ToString("N0")
            Literaltoplamoym.Text = oya_erisim.toplamsayi().ToString("N0")

        End If


    End Sub

End Class