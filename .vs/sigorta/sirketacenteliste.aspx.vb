Public Partial Class sirketacenteliste
    Inherits System.Web.UI.Page



    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim acente_erisim As New CLASSACENTE_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirketacenteliste", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            If kullanici_erisim.aktifsirketsecilmismi = "Hayır" Then
                Response.Redirect("profile.aspx")
            End If

            'ŞİRKETİN TÜM ACENTELERİNİ BUL
            Label1.Text = acente_erisim.listele_sirkettarafiicin
        End If 'postback

    End Sub


End Class