Public Partial Class birlikpersoneltanim
    Inherits System.Web.UI.Page


    Dim personel_erisim As New CLASSPERSONEL_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("birlikpersoneltanim", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = personel_erisim.listelebirlikpersoneliicin
        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        HttpContext.Current.Session("ltip") = "personeladsoyad"
        HttpContext.Current.Session("kriter") = TextBox1.Text
        Label1.Text = personel_erisim.listelebirlikpersoneliicin

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        HttpContext.Current.Session("ltip") = "kimlikno"
        HttpContext.Current.Session("kriter") = TextBox2.Text
        Label1.Text = personel_erisim.listelebirlikpersoneliicin

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        HttpContext.Current.Session("ltip") = "tpno"
        HttpContext.Current.Session("kriter") = TextBox3.Text
        Label1.Text = personel_erisim.listelebirlikpersoneliicin

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click

        HttpContext.Current.Session("ltip") = "onaylanmamislar"
        Label1.Text = personel_erisim.listelebirlikpersoneliicin

    End Sub
End Class