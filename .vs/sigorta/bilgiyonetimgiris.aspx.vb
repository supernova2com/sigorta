Public Partial Class bilgiyonetimgiris
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TextBox1.Focus()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


        Dim result As New CLADBOPRESULT
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM
        Dim webuye As New CLASSWEBUYE


        Dim kullaniciad, kullanicisifre As String
        Dim hata As String = ""
        Dim hatamsg As String = ""

        kullaniciad = TextBox1.Text
        kullanicisifre = TextBox2.Text

        result = webuye_erisim.logincontrol(kullaniciad, kullanicisifre)

        If result.durum = "Hayır" Then
            Labeluyari.Text = "<div class='alert alert-danger'>" + _
            result.hatastr + _
            "</div>"
        End If

        If result.durum = "Evet" Then

            webuye = webuye_erisim.bultek(result.etkilenen)
            Session("webuye_pkey") = webuye.pkey
            Session("webuye_sirketpkey") = webuye.sirketpkey
            Session("webuye_uyetip") = webuye.uyetip
            Session("webuye_adsoyad") = webuye.adsoyad
            Session("webuye_rolpkey") = webuye.rolpkey



            Response.Redirect("defaultbilgiadmin.aspx")

        End If 'result.durum=Evet

    End Sub

End Class