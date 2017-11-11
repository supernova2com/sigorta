Public Partial Class gelendosya
    Inherits System.Web.UI.Page


    Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
    Dim dosya_erisim As New CLASSDOSYA_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_Erisim.busayfayigormeyeyetkilimi("dosya", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then
            'GELEN DOSYALARIMI LİSTELE
            Label1.Text = dosya_erisim.gelendosyalarim(Session("kullanici_pkey"))
        End If

    End Sub

End Class