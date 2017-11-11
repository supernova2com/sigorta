Public Partial Class sirketbazfiyat
    Inherits System.Web.UI.Page



    Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirketbazfiyat", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            Dim bazfiyatgirissure As New CLASSBAZFIYATGIRISSURE
            Dim bazfiyatgirissure_erisim As New CLASSBAZFIYATGIRISSURE_ERISIM

            bazfiyatgirissure = bazfiyatgirissure_erisim.sureyetkilimi()
            If bazfiyatgirissure.pkey = 0 Then
                iframeyenikayit.Visible = False
            Else
                iframeyenikayit.Visible = True
            End If

            HttpContext.Current.Session("ltip") = "sirkettaraf"
            Label1.Text = bazfiyat_erisim.listele()

        End If
    End Sub



End Class