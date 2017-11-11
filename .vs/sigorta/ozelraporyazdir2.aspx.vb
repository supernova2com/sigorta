Public Partial Class ozelraporyazdir2
    Inherits System.Web.UI.Page



    Dim rapor As New CLASSRAPOR
    Dim ozelrapor2_erisim As New CLASSOZELRAPOR2_ERISIM
    Dim rapor_erisim As New CLASSRAPOR_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            rapor = ozelrapor2_erisim.temelrapor
            Labelraporbaslik.Text = rapor.baslik
            Labelraporbaslik2.Text = rapor.baslik
            Label1.Text = rapor.veri

        End If

    End Sub


    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = ozelrapor2_erisim.temelrapor
        rapor_erisim.yazdirpdf("ekran", rapor)
    End Sub

    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = ozelrapor2_erisim.temelrapor
        rapor_erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = ozelrapor2_erisim.temelrapor
        rapor_erisim.yazdirword("ekran", rapor)
    End Sub

End Class